using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderNone : GamePlayerStateSurrender.State
{

	#region Constructor

	public enum Property
	{

	}

	public GamePlayerStateSurrenderNone()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.None;
	}

	#region request cancel

	public bool isCanRequestCancel(uint userId)
	{
		// Check correct userId
		{
			GamePlayer gamePlayer = this.findDataInParent<GamePlayer> ();
			if (gamePlayer != null) {
				if (gamePlayer.inform.v is Human) {
					// normal user
					Human human = gamePlayer.inform.v as Human;
					if (human.playerId.v == userId) {
						return true;
					}
				} else {
					// admin
					RoomUser admin = Room.findAdmin (this);
					if (admin != null) {
						if (admin.inform.v.playerId.v == userId) {
							return true;
						}
					} else {
						Debug.LogError ("admin null");
					}
				}
			} else {
				Debug.LogError ("gamePlayer null");
			}
		}
		return false;
	}

	public void requestMakeRequestCancel(uint userId){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.makeRequestCancel (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is GamePlayerStateSurrenderNoneIdentity) {
						GamePlayerStateSurrenderNoneIdentity gamePlayerStateSurrenderNoneIdentity = dataIdentity as GamePlayerStateSurrenderNoneIdentity;
						gamePlayerStateSurrenderNoneIdentity.requestMakeRequestCancel (userId);
					} else {
						Debug.LogError ("Why isn't correct identity");
					}
				} else {
					Debug.LogError ("cannot find dataIdentity");
				}
			}
		} else {
			Debug.LogError ("You cannot request");
		}
	}

	public void makeRequestCancel(uint userId)
	{
		if (this.isCanRequestCancel (userId)) {
			GamePlayerStateSurrender gamePlayerStateSurrender = this.findDataInParent<GamePlayerStateSurrender> ();
			if (gamePlayerStateSurrender != null) {
				GamePlayerStateSurrenderAsk ask = new GamePlayerStateSurrenderAsk ();
				{
					ask.uid = gamePlayerStateSurrender.state.makeId ();
					ask.accepts.add (userId);
				}
				gamePlayerStateSurrender.state.v = ask;
			} else {
				Debug.LogError ("gamePlayerStateSurrender null: " + this);
			}
		} else {
			Debug.LogError ("Cannot request cancel surrender: " + userId);
		}
	}

	#endregion

}