using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
	public class ReversiMoveAnimationIdentity : DataIdentity
	{

		#region SyncVar

		#region move

		[SyncVar(hook="onChangeMove")]
		public System.SByte move;

		public void onChangeMove(System.SByte newMove)
		{
			this.move = newMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.move.v = newMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region change

		[SyncVar(hook="onChangeChange")]
		public System.UInt64 change;

		public void onChangeChange(System.UInt64 newChange)
		{
			this.change = newChange;
			if (this.netData.clientData != null) {
				this.netData.clientData.change.v = newChange;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ReversiMoveAnimation> netData = new NetData<ReversiMoveAnimation>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove(this.move);
				this.onChangeChange(this.change);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.change);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ReversiMoveAnimation) {
				ReversiMoveAnimation reversiMoveAnimation = data as ReversiMoveAnimation;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, reversiMoveAnimation.makeSearchInforms ());
					this.move = reversiMoveAnimation.move.v;
					this.change = reversiMoveAnimation.change.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (reversiMoveAnimation);
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
			if (data is ReversiMoveAnimation) {
				// ReversiMoveAnimation reversiMoveAnimation = data as ReversiMoveAnimation;
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
			if (wrapProperty.p is ReversiMoveAnimation) {
				switch ((ReversiMoveAnimation.Property)wrapProperty.n) {
				case ReversiMoveAnimation.Property.reversi:
					break;
				case ReversiMoveAnimation.Property.move:
					this.move = (System.SByte)wrapProperty.getValue ();
					break;
				case ReversiMoveAnimation.Property.change:
					this.change = (System.UInt64)wrapProperty.getValue ();
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