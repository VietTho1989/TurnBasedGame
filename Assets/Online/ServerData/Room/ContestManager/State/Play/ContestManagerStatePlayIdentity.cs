using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class ContestManagerStatePlayIdentity : DataIdentity
	{

		#region SyncVar

		#region isForceEnd

		[SyncVar(hook="onChangeIsForceEnd")]
		public System.Boolean isForceEnd;

		public void onChangeIsForceEnd(System.Boolean newIsForceEnd)
		{
			this.isForceEnd = newIsForceEnd;
			if (this.netData.clientData != null) {
				this.netData.clientData.isForceEnd.v = newIsForceEnd;
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

		#region gameTypeType

		[SyncVar(hook="onChangeGameTypeType")]
		public GameType.Type gameTypeType;

		public void onChangeGameTypeType(GameType.Type newGameTypeType)
		{
			this.gameTypeType = newGameTypeType;
			if (this.netData.clientData != null) {
				this.netData.clientData.gameTypeType.v = newGameTypeType;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ContestManagerStatePlay> netData = new NetData<ContestManagerStatePlay>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeIsForceEnd(this.isForceEnd);
				this.onChangeRandomTeamIndex (this.randomTeamIndex);
				this.onChangeGameTypeType (this.gameTypeType);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.isForceEnd);
				ret += GetDataSize (this.randomTeamIndex);
				ret += GetDataSize (this.gameTypeType);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ContestManagerStatePlay) {
				ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, contestManagerStatePlay.makeSearchInforms ());
					this.isForceEnd = contestManagerStatePlay.isForceEnd.v;
					this.randomTeamIndex = contestManagerStatePlay.randomTeamIndex.v;
					this.gameTypeType = contestManagerStatePlay.gameTypeType.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (contestManagerStatePlay);
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
			if (data is ContestManagerStatePlay) {
				// ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
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
			if (wrapProperty.p is ContestManagerStatePlay) {
				switch ((ContestManagerStatePlay.Property)wrapProperty.n) {
				case ContestManagerStatePlay.Property.state:
					break;
				case ContestManagerStatePlay.Property.isForceEnd:
					this.isForceEnd = (System.Boolean)wrapProperty.getValue ();
					break;
				case ContestManagerStatePlay.Property.teams:
					break;
				case ContestManagerStatePlay.Property.content:
					break;
				case ContestManagerStatePlay.Property.contentTeamResult:
					break;
				case ContestManagerStatePlay.Property.gameTypeType:
					this.gameTypeType = (GameType.Type)wrapProperty.getValue ();
					break;
				case ContestManagerStatePlay.Property.randomTeamIndex:
					this.randomTeamIndex = (System.Boolean)wrapProperty.getValue ();
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

		#region isForceEnd

		public void requestChangeIsForceEnd(uint userId, bool newIsForceEnd)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdContestManagerStatePlayChangeIsForceEnd (this.netId, userId, newIsForceEnd);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeIsForceEnd(uint userId, bool newIsForceEnd)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeIsForceEnd(userId, newIsForceEnd);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}