using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class TeamPlayerIdentity : DataIdentity
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

		private NetData<TeamPlayer> netData = new NetData<TeamPlayer>();

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
			if (data is TeamPlayer) {
				TeamPlayer teamPlayer = data as TeamPlayer;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, teamPlayer.makeSearchInforms ());
					this.playerIndex = teamPlayer.playerIndex.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (teamPlayer);
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
			if (data is TeamPlayer) {
				// TeamPlayer teamPlayer = data as TeamPlayer;
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
			if (wrapProperty.p is TeamPlayer) {
				switch ((TeamPlayer.Property)wrapProperty.n) {
				case TeamPlayer.Property.playerIndex:
					this.playerIndex = (System.Int32)wrapProperty.getValue ();
					break;
				case TeamPlayer.Property.inform:
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