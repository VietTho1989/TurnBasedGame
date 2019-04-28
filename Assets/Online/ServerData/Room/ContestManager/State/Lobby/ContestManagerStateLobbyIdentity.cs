using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStateLobbyIdentity : DataIdentity
	{

		#region SyncVar

		#region gameType

		[SyncVar(hook="onChangeGameType")]
		public GameType.Type gameType;

		public void onChangeGameType(GameType.Type newGameType)
		{
			this.gameType = newGameType;
			if (this.netData.clientData != null) {
				this.netData.clientData.gameType.v = newGameType;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region randomTeamIndex

		[SyncVar(hook="onChangeRandomTeamIndex")]
		public System.Boolean randomTeamIndex;

		public void onChangeRandomTeamIndex(System.Boolean newRandomTeamIndex)
		{
			this.randomTeamIndex = newRandomTeamIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.randomTeamIndex.v = newRandomTeamIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ContestManagerStateLobby> netData = new NetData<ContestManagerStateLobby>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeGameType(this.gameType);
				this.onChangeRandomTeamIndex(this.randomTeamIndex);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.gameType);
				ret += GetDataSize (this.randomTeamIndex);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ContestManagerStateLobby) {
				ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, contestManagerStateLobby.makeSearchInforms ());
					this.gameType = contestManagerStateLobby.gameType.v;
					this.randomTeamIndex = contestManagerStateLobby.randomTeamIndex.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (contestManagerStateLobby);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ContestManagerStateLobby) {
				// ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ContestManagerStateLobby) {
				switch ((ContestManagerStateLobby.Property)wrapProperty.n) {
				case ContestManagerStateLobby.Property.state:
					break;
				case ContestManagerStateLobby.Property.teams:
					break;
				case ContestManagerStateLobby.Property.gameType:
					this.gameType = (GameType.Type)wrapProperty.getValue ();
					break;
				case ContestManagerStateLobby.Property.randomTeamIndex:
					this.randomTeamIndex = (System.Boolean)wrapProperty.getValue ();
					break;
				case ContestManagerStateLobby.Property.contentFactory:
					break;
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		#region randomTeamIndex

		public void requestChangeRandomTeamIndex(uint userId, bool newRandomTeamIndex)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdContestManagerStateLobbyChangeRandomTeamIndex (this.netId, userId, newRandomTeamIndex);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeRandomTeamIndex(uint userId, bool newRandomTeamIndex)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeRandomTeamIndex(userId, newRandomTeamIndex);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Factory

		public void requestChangeContentFactoryType(uint userId, int newContentFactoryType)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdContestManagerStateLobbyChangeContentFactoryType (this.netId, userId, newContentFactoryType);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeContentFactoryType(uint userId, int newContentFactoryType)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeContentFactoryType(userId, newContentFactoryType);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}