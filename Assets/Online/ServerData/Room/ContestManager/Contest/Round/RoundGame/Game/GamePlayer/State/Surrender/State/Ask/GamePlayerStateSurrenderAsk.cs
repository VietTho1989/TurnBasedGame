using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateSurrenderAsk : GamePlayerStateSurrender.State
{

	#region whoCanAsks

	public LP<Human> whoCanAsks;

	public HashSet<uint> getWhoCanAsks()
	{
		HashSet<uint> ret = new HashSet<uint>();
		{
			// GamePlayer
			{
				Game game = this.findDataInParent<Game> ();
				if (game != null) {
					foreach (GamePlayer gamePlayer in game.gamePlayers.vs) {
						if (gamePlayer.inform.v is Human) {
							Human human = gamePlayer.inform.v as Human;
							ret.Add (human.playerId.v);
						}
					}
				} else {
					Debug.LogError ("duel null");
				}
			}
			// Admin
			if (ret.Count == 0) {
				RoomUser admin = Room.findAdmin (this);
				if (admin != null) {
					ret.Add (admin.inform.v.playerId.v);
				} else {
					Debug.LogError ("admin null");
				}
			}
		}
		return ret;
	}

	#endregion

	#region accepts

	public LP<uint> accepts;

	#region accept

	public void requestAccept(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.accept (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is GamePlayerStateSurrenderAskIdentity) {
						GamePlayerStateSurrenderAskIdentity gamePlayerStateSurrenderAskIdentity = dataIdentity as GamePlayerStateSurrenderAskIdentity;
						gamePlayerStateSurrenderAskIdentity.requestAccept (userId);
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

	public bool isCanAccept(uint userId)
	{
		if (!this.accepts.vs.Contains (userId)) {
			// Find
			bool canAccept = false;
			{
				foreach (Human human in whoCanAsks.vs) {
					if (human.playerId.v == userId) {
						canAccept = true;
						break;
					}
				}
			}
			// Process
			if (canAccept) {
				return true;
			} else {
				return false;
			}
		} else {
			// Debug.LogError ("already accept: " + this);
			return false;
		}
	}

	public void accept(uint userId)
	{
		if (isCanAccept (userId)) {
			this.accepts.add (userId);
		} else {
			Debug.LogError ("Cannot accept: " + userId);
		}
	}

	#endregion

	#region cancel

	public void requestRefuse(uint userId)
	{
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.refuse (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is GamePlayerStateSurrenderAskIdentity) {
						GamePlayerStateSurrenderAskIdentity gamePlayerStateSurrenderAskIdentity = dataIdentity as GamePlayerStateSurrenderAskIdentity;
						gamePlayerStateSurrenderAskIdentity.requestRefuse (userId);
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

	public bool isCanRefuse(uint userId)
	{
		// Find
		bool canRefuse = false;
		{
			foreach (Human human in whoCanAsks.vs) {
				if (human.playerId.v == userId) {
					canRefuse = true;
					break;
				}
			}
		}
		// return
		return canRefuse;
	}

	public void refuse(uint userId)
	{
		if (isCanRefuse (userId)) {
			GamePlayerStateSurrender gamePlayerStateSurrender = this.findDataInParent<GamePlayerStateSurrender> ();
			if (gamePlayerStateSurrender != null) {
				GamePlayerStateSurrenderNone none = new GamePlayerStateSurrenderNone ();
				{
					none.uid = gamePlayerStateSurrender.state.makeId ();
				}
				gamePlayerStateSurrender.state.v = none;
			} else {
				Debug.LogError ("gamePlayerStateSurrender null: " + this);
			}
		} else {
			Debug.LogError ("Cannot cancel: " + userId);
		}
	}

	#endregion

	#endregion

	#region Constructor

	public enum Property
	{
		whoCanAsks,
		accepts
	}

	public GamePlayerStateSurrenderAsk() : base()
	{
		this.whoCanAsks = new LP<Human> (this, (byte)Property.whoCanAsks);
		this.accepts = new LP<uint> (this, (byte)Property.accepts);
	}

	#endregion

	public override Type getType ()
	{
		return Type.Ask;
	}

}