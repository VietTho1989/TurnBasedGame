using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class PieceUI : UIBehavior<PieceUI.UIData>
	{

		#region Constructor

		public class UIData : Data
		{

			public VP<int> x;

			public VP<int> y;

			public VP<byte> board;

			public VP<byte> userSolve;

			#region Constructor

			public enum Property
			{
				x,
				y,
				board,
				userSolve
			}

			public UIData() : base()
			{
				this.x = new VP<int>(this, (byte)Property.x, 0);
				this.y = new VP<int>(this, (byte)Property.y, 0);
				this.board = new VP<byte>(this, (byte)Property.board, 0);
				this.userSolve = new VP<byte>(this, (byte)Property.userSolve, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Text tvValue;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// check load full
					bool isLoadFull = true;
					{
						// animation
						if (isLoadFull) {
							isLoadFull = AnimationManager.IsLoadFull (this.data);
						}
					}
					// process
					if (isLoadFull) {
						// position
						this.transform.localPosition = Common.GetLocalPos (this.data.x.v, this.data.y.v);
						// tvValue
						if (tvValue != null) {
							if (this.data.board.v >= 1 && this.data.board.v <= 9) {
								tvValue.color = Color.black;
								tvValue.text = "" + this.data.board.v;
							} else {
								if (this.data.userSolve.v >= 1 && this.data.userSolve.v <= 9) {
									tvValue.color = Color.blue;
									tvValue.text = "" + this.data.userSolve.v;
								} else {
									tvValue.text = "";
								}
							}
						} else {
							Debug.LogError ("tvValue null");
						}
					} else {
						Debug.LogError ("not load full");
						dirty = true;
					}
				} else {
					Debug.LogError ("data null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.x:
					dirty = true;
					break;
				case UIData.Property.y:
					dirty = true;
					break;
				case UIData.Property.board:
					dirty = true;
					break;
				case UIData.Property.userSolve:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}