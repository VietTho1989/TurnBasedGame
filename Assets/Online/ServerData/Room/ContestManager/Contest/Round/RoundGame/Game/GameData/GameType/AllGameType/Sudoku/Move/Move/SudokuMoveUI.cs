using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Sudoku
{
	public class SudokuMoveUI : UIBehavior<SudokuMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			
			public VP<ReferenceData<SudokuMove>> sudokuMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				sudokuMove,
				isHint
			}

			public UIData() : base()
			{
				this.sudokuMove = new VP<ReferenceData<SudokuMove>>(this, (byte)Property.sudokuMove, new ReferenceData<SudokuMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.SudokuMove;
			}

		}

		#endregion

		#region Refresh

		public UILineRenderer lineRenderer;
		public Text tvHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SudokuMove sudokuMove = this.data.sudokuMove.v.data;
					if (sudokuMove != null) {
						// position
						this.transform.localPosition = Common.GetLocalPos (sudokuMove.x.v, sudokuMove.y.v);
						// lineRenderer
						if (lineRenderer != null) {
							// points
							{
								Vector2[] points = new Vector2[5];
								{
									Vector2 localPos = new Vector2 (0.5f, 0.5f);
									points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
									points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
									points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
									points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
									points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								}
								lineRenderer.Points = points;
							}
							// color
							lineRenderer.color = this.data.isHint.v ? Color.green : Color.blue;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (tvHint != null) {
							if (this.data.isHint.v) {
								// value
								tvHint.text = ""+sudokuMove.value.v;
							} else {
								tvHint.text = "";
							}
						} else {
							Debug.LogError ("tvHint null: " + this);
						}
					} else {
						Debug.LogError ("sudokuMove null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Child
				{
					uiData.sudokuMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (data is SudokuMove) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Child
				{
					uiData.sudokuMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Child
			if (data is SudokuMove) {
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
				case UIData.Property.sudokuMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is SudokuMove) {
				switch ((SudokuMove.Property)wrapProperty.n) {
				case SudokuMove.Property.x:
					dirty = true;
					break;
				case SudokuMove.Property.y:
					dirty = true;
					break;
				case SudokuMove.Property.value:
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