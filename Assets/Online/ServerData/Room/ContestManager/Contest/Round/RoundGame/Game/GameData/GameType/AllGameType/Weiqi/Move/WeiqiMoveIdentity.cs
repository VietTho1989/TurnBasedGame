using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class WeiqiMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region coord

		[SyncVar(hook="onChangeCoord")]
		public System.Int32 coord;

		public void onChangeCoord(System.Int32 newCoord)
		{
			this.coord = newCoord;
			if (this.netData.clientData != null) {
				this.netData.clientData.coord.v = newCoord;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region color

		[SyncVar(hook="onChangeColor")]
		public System.Int32 color;

		public void onChangeColor(System.Int32 newColor)
		{
			this.color = newColor;
			if (this.netData.clientData != null) {
				this.netData.clientData.color.v = newColor;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region boardSize

		[SyncVar(hook="onChangeBoardSize")]
		public System.Int32 boardSize;

		public void onChangeBoardSize(System.Int32 newBoardSize)
		{
			this.boardSize = newBoardSize;
			if (this.netData.clientData != null) {
				this.netData.clientData.boardSize.v = newBoardSize;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<WeiqiMove> netData = new NetData<WeiqiMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeCoord (this.coord);
				this.onChangeColor (this.color);
				this.onChangeBoardSize (this.boardSize);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.coord);
				ret += GetDataSize (this.color);
				ret += GetDataSize (this.boardSize);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is WeiqiMove) {
				WeiqiMove move = data as WeiqiMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, move.makeSearchInforms ());
					this.coord = move.coord.v;
					this.color = move.color.v;
					this.boardSize = move.boardSize.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (move);
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
			if (data is WeiqiMove) {
				// Move move = data as Move;
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
			if (wrapProperty.p is WeiqiMove) {
				switch ((WeiqiMove.Property)wrapProperty.n) {
				case WeiqiMove.Property.coord:
					this.coord = (System.Int32)wrapProperty.getValue ();
					break;
				case WeiqiMove.Property.color:
					this.color = (System.Int32)wrapProperty.getValue ();
					break;
				case WeiqiMove.Property.boardSize:
					this.boardSize = (System.Int32)wrapProperty.getValue ();
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