using UnityEngine;
using System.Collections;

public class Typing : Data
{

	public VP<bool> isEnable;

	public VP<float> nextReceiveTime;
	public VP<float> stopDuration;

	#region Player

	public LP<TypingPlayer> typingPlayers;

	public TypingPlayer findPlayer(uint playerId)
	{
		/*for (int i = 0; i < typingPlayers.vs.Count; i++) {
			TypingPlayer typingPlayer = typingPlayers.vs [i];
			if (typingPlayer.playerId.v == playerId) {
				return typingPlayer;
			}
		}
		return null;*/
		return this.typingPlayers.vs.Find (typingPlayer => typingPlayer.playerId.v == playerId);
	}

	public int removePlayer(uint playerId)
	{
		int ret = 0;
		{
			for (int i = typingPlayers.vs.Count - 1; i >= 0; i--) {
				TypingPlayer typingPlayer = this.typingPlayers.vs [i];
				if (typingPlayer.playerId.v == playerId) {
					this.typingPlayers.remove (typingPlayer);
				}
			}
		}
		return ret;
	}

	#endregion

	#region Constructor

	public enum Property
	{
		isEnable,
		nextReceiveTime,
		stopDuration,
		typingPlayers
	}

	public Typing() : base()
	{
		this.isEnable = new VP<bool> (this, (byte)Property.isEnable, true);
		this.stopDuration = new VP<float> (this, (byte)Property.stopDuration, 5);
		this.nextReceiveTime = new VP<float> (this, (byte)Property.nextReceiveTime, 3);
		this.typingPlayers = new LP<TypingPlayer> (this, (byte)Property.typingPlayers);
	}

	#endregion

	#region Send you are typing

	public bool isCanTyping(uint userId)
	{
		if (this.isEnable.v) {
			TypingPlayer typingPlayer = this.findPlayer (userId);
			if (typingPlayer != null) {
				switch (typingPlayer.state.v) {
				case TypingPlayer.State.Start:
				case TypingPlayer.State.Normal:
					return false;
				case TypingPlayer.State.NextReceive:
					return true;
				default:
					Debug.LogError ("unknown state: " + typingPlayer.state.v);
					return false;
				}
			} else {
				return true;
			}
		} else {
			return false;
		}
	}

	public void requestSendTyping(uint userId){
		Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
		if (needRequest.canRequest) {
			if (!needRequest.needIdentity) {
				this.sendTyping (userId);
			} else {
				DataIdentity dataIdentity = null;
				if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
					if (dataIdentity is TypingIdentity) {
						TypingIdentity typingIdentity = dataIdentity as TypingIdentity;
						typingIdentity.requestSendTyping (userId);
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

	public void sendTyping(uint userId)
	{
		if (this.isCanTyping (userId)) {
			TypingPlayer old = this.findPlayer (userId);
			if (old == null) {
				// Make new 
				{
					TypingPlayer newPlayer = new TypingPlayer ();
					{
						newPlayer.uid = this.typingPlayers.makeId ();
						newPlayer.playerId.v = userId;
						newPlayer.state.v = TypingPlayer.State.Start;
					}
					this.typingPlayers.add (newPlayer);
				}
				// Add human inform
				{
					ChatRoom chatRoom = this.findDataInParent<ChatRoom> ();
					if (chatRoom != null) {
						chatRoom.addPlayer (userId);
					} else {
						Debug.LogError ("chatRoom null");
					}
				}
			} else {
				old.state.v = TypingPlayer.State.Start;
			}
		} else {
			Debug.LogError ("Cannot typing");
		}
	}

	#endregion
}