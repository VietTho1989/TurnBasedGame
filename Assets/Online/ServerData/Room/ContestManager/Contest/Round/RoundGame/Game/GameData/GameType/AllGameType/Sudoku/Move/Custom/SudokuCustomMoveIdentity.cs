using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class SudokuCustomMoveIdentity : DataIdentity
	{

		#region SyncVar

		#region x

		[SyncVar(hook="onChangeX")]
		public System.Byte x;

		public void onChangeX(System.Byte newX)
		{
			this.x = newX;
			if (this.netData.clientData != null) {
				this.netData.clientData.x.v = newX;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region y

		[SyncVar(hook="onChangeY")]
		public System.Byte y;

		public void onChangeY(System.Byte newY)
		{
			this.y = newY;
			if (this.netData.clientData != null) {
				this.netData.clientData.y.v = newY;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region value

		[SyncVar(hook="onChangeValue")]
		public System.Byte value;

		public void onChangeValue(System.Byte newValue)
		{
			this.value = newValue;
			if (this.netData.clientData != null) {
				this.netData.clientData.value.v = newValue;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SudokuCustomMove> netData = new NetData<SudokuCustomMove>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeX(this.x);
				this.onChangeY(this.y);
				this.onChangeValue(this.value);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.x);
				ret += GetDataSize (this.y);
				ret += GetDataSize (this.value);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SudokuCustomMove) {
				SudokuCustomMove sudokuCustomMove = data as SudokuCustomMove;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, sudokuCustomMove.makeSearchInforms ());
					this.x = sudokuCustomMove.x.v;
					this.y = sudokuCustomMove.y.v;
					this.value = sudokuCustomMove.value.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (sudokuCustomMove);
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
			if (data is SudokuCustomMove) {
				// SudokuCustomMove sudokuCustomMove = data as SudokuCustomMove;
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
			if (wrapProperty.p is SudokuCustomMove) {
				switch ((SudokuCustomMove.Property)wrapProperty.n) {
				case SudokuCustomMove.Property.x:
					this.x = (System.Byte)wrapProperty.getValue ();
					break;
				case SudokuCustomMove.Property.y:
					this.y = (System.Byte)wrapProperty.getValue ();
					break;
				case SudokuCustomMove.Property.value:
					this.value = (System.Byte)wrapProperty.getValue ();
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