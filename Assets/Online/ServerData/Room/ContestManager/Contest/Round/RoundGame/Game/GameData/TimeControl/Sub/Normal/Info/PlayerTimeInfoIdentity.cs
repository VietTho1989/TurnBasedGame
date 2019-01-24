using UnityEngine;
using Mirror;
using System;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
	public class PlayerTimeInfoIdentity : DataIdentity
	{

		#region SyncVar

		#region playerIndex

		[SyncVar(hook="onChangePlayerIndex")]
		public System.Int32 playerIndex;

		public void onChangePlayerIndex(System.Int32 newPlayerIndex)
		{
			this.playerIndex = newPlayerIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.playerIndex.v = newPlayerIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<PlayerTimeInfo> netData = new NetData<PlayerTimeInfo>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePlayerIndex(this.playerIndex);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.playerIndex);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is PlayerTimeInfo) {
				PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, playerTimeInfo.makeSearchInforms ());
					this.playerIndex = playerTimeInfo.playerIndex.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (playerTimeInfo);
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
			if (data is PlayerTimeInfo) {
				// PlayerTimeInfo playerTimeInfo = data as PlayerTimeInfo;
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
			if (wrapProperty.p is PlayerTimeInfo) {
				switch ((PlayerTimeInfo.Property)wrapProperty.n) {
				case PlayerTimeInfo.Property.playerIndex:
					this.playerIndex = (System.Int32)wrapProperty.getValue ();
					break;
				case PlayerTimeInfo.Property.timeInfo:
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

	}
}