using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundIdentity : DataIdentity
	{

		#region SyncVar

		#region index

		[SyncVar(hook="onChangeIndex")]
		public System.Int32 index;

		public void onChangeIndex(System.Int32 newIndex)
		{
			this.index = newIndex;
			if (this.netData.clientData != null) {
				this.netData.clientData.index.v = newIndex;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region roundGames

		[SyncVar]
		public int roundGames;

		#endregion

		#endregion

		#region NetData

		private NetData<Round> netData = new NetData<Round>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeIndex(this.index);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.index);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is Round) {
				Round round = data as Round;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, round.makeSearchInforms ());
					this.index = round.index.v;
					this.roundGames = round.roundGames.vs.Count;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (round);
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
			if (data is Round) {
				// Round round = data as Round;
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
			if (wrapProperty.p is Round) {
				switch ((Round.Property)wrapProperty.n) {
				case Round.Property.state:
					break;
				case Round.Property.index:
					this.index = (System.Int32)wrapProperty.getValue ();
					break;
				case Round.Property.roundGames:
					{
						Round round = wrapProperty.p as Round;
						this.roundGames = round.roundGames.vs.Count;
					}
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