using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region fromX

		[SyncVar(hook="onChangeFromX")]
		public System.SByte fromX;

		public void onChangeFromX(System.SByte newFromX)
		{
			this.fromX = newFromX;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromX.v = newFromX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region fromY

		[SyncVar(hook="onChangeFromY")]
		public System.SByte fromY;

		public void onChangeFromY(System.SByte newFromY)
		{
			this.fromY = newFromY;
			if (this.netData.clientData != null) {
				this.netData.clientData.fromY.v = newFromY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region toX

		[SyncVar(hook="onChangeToX")]
		public System.SByte toX;

		public void onChangeToX(System.SByte newToX)
		{
			this.toX = newToX;
			if (this.netData.clientData != null) {
				this.netData.clientData.toX.v = newToX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region toY

		[SyncVar(hook="onChangeToY")]
		public System.SByte toY;

		public void onChangeToY(System.SByte newToY)
		{
			this.toY = newToY;
			if (this.netData.clientData != null) {
				this.netData.clientData.toY.v = newToY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<JanggiMove> netData = new NetData<JanggiMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFromX(this.fromX);
				this.onChangeFromY(this.fromY);
				this.onChangeToX(this.toX);
				this.onChangeToY(this.toY);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.fromX);
				ret += GetDataSize (this.fromY);
				ret += GetDataSize (this.toX);
				ret += GetDataSize (this.toY);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is JanggiMove) {
				JanggiMove janggiMove = data as JanggiMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, janggiMove.makeSearchInforms ());
					this.fromX = janggiMove.fromX.v;
					this.fromY = janggiMove.fromY.v;
					this.toX = janggiMove.toX.v;
					this.toY = janggiMove.toY.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (janggiMove);
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
			if (data is JanggiMove) {
				// JanggiMove janggiMove = data as JanggiMove;
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
			if (wrapProperty.p is JanggiMove) {
				switch ((JanggiMove.Property)wrapProperty.n) {
				case JanggiMove.Property.fromX:
					this.fromX = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMove.Property.fromY:
					this.fromY = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMove.Property.toX:
					this.toX = (System.SByte)wrapProperty.getValue ();
					break;
				case JanggiMove.Property.toY:
					this.toY = (System.SByte)wrapProperty.getValue ();
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