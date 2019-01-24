using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationRoundIdentity : DataIdentity
	{

		#region SyncVar

		#region isActive

		[SyncVar(hook="onChangeIsActive")]
		public System.Boolean isActive;

		public void onChangeIsActive(System.Boolean newIsActive)
		{
			this.isActive = newIsActive;
			if (this.netData.clientData != null) {
				this.netData.clientData.isActive.v = newIsActive;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

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

		#region brackets

		[SyncVar]
		public int brackets;

		#endregion

		#endregion

		#region NetData

		private NetData<EliminationRound> netData = new NetData<EliminationRound>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeIsActive(this.isActive);
				this.onChangeIndex(this.index);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.isActive);
				ret += GetDataSize (this.index);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is EliminationRound) {
				EliminationRound eliminationRound = data as EliminationRound;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, eliminationRound.makeSearchInforms ());
					this.isActive = eliminationRound.isActive.v;
					this.index = eliminationRound.index.v;
					this.brackets = eliminationRound.brackets.vs.Count;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (eliminationRound);
					} else {
						Debug.LogError ("observer null: " + this);
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is EliminationRound) {
				// EliminationRound eliminationRound = data as EliminationRound;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null: " + this);
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
			if (wrapProperty.p is EliminationRound) {
				switch ((EliminationRound.Property)wrapProperty.n) {
				case EliminationRound.Property.isActive:
					this.isActive = (System.Boolean)wrapProperty.getValue ();
					break;
				case EliminationRound.Property.state:
					break;
				case EliminationRound.Property.index:
					this.index = (System.Int32)wrapProperty.getValue ();
					break;
				case EliminationRound.Property.brackets:
					{
						EliminationRound eliminationRound = wrapProperty.p as EliminationRound;
						this.brackets = eliminationRound.brackets.vs.Count;
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