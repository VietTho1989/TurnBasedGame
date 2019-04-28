using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireResetAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region drawCount

		[SyncVar(hook="onChangeDrawCount")]
		public System.Int32 drawCount;

		public void onChangeDrawCount(System.Int32 newDrawCount)
		{
			this.drawCount = newDrawCount;
			if (this.netData.clientData != null) {
				this.netData.clientData.drawCount.v = newDrawCount;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SolitaireResetAnimation> netData = new NetData<SolitaireResetAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeDrawCount(this.drawCount);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.drawCount);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SolitaireResetAnimation) {
				SolitaireResetAnimation solitaireResetAnimation = data as SolitaireResetAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, solitaireResetAnimation.makeSearchInforms ());
					this.drawCount = solitaireResetAnimation.drawCount.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (solitaireResetAnimation);
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
			if (data is SolitaireResetAnimation) {
				// SolitaireResetAnimation solitaireResetAnimation = data as SolitaireResetAnimation;
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
			if (wrapProperty.p is SolitaireResetAnimation) {
				switch ((SolitaireResetAnimation.Property)wrapProperty.n) {
				case SolitaireResetAnimation.Property.piles:
					break;
				case SolitaireResetAnimation.Property.drawCount:
					this.drawCount = (System.Int32)wrapProperty.getValue ();
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