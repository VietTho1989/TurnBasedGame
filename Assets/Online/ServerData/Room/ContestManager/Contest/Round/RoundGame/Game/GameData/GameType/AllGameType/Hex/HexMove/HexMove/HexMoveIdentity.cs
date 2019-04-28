using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region move

		[SyncVar(hook="onChangeMove")]
		public System.UInt16 move;

		public void onChangeMove(System.UInt16 newMove)
		{
			this.move = newMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.move.v = newMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region boardSize

		[SyncVar(hook="onChangeBoardSize")]
		public System.UInt16 boardSize;

		public void onChangeBoardSize(System.UInt16 newBoardSize)
		{
			this.boardSize = newBoardSize;
			if (this.netData.clientData != null) {
				this.netData.clientData.boardSize.v = newBoardSize;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region color

		[SyncVar(hook="onChangeColor")]
		public Common.Color color;

		public void onChangeColor(Common.Color newColor)
		{
			this.color = newColor;
			if (this.netData.clientData != null) {
				this.netData.clientData.color.v = newColor;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<HexMove> netData = new NetData<HexMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMove(this.move);
				this.onChangeBoardSize(this.boardSize);
				this.onChangeColor (this.color);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.move);
				ret += GetDataSize (this.boardSize);
				ret += GetDataSize (this.color);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is HexMove) {
				HexMove hexMove = data as HexMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, hexMove.makeSearchInforms ());
					this.move = hexMove.move.v;
					this.boardSize = hexMove.boardSize.v;
					this.color = hexMove.color.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (hexMove);
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
			if (data is HexMove) {
				// HexMove hexMove = data as HexMove;
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
			if (wrapProperty.p is HexMove) {
				switch ((HexMove.Property)wrapProperty.n) {
				case HexMove.Property.move:
					this.move = (System.UInt16)wrapProperty.getValue ();
					break;
				case HexMove.Property.boardSize:
					this.boardSize = (System.UInt16)wrapProperty.getValue ();
					break;
				case HexMove.Property.color:
					this.color = (Common.Color)wrapProperty.getValue ();
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