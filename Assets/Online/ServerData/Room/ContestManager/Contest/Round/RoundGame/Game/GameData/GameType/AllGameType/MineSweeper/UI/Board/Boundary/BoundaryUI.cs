using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class BoundaryUI : UIBehavior<BoundaryUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			#region Constructor

			public enum Property
			{

			}

			public UIData() : base()
			{

			}

			#endregion

		}

		#endregion

		#region Refresh

		public RectTransform left;
		public RectTransform right;
		public RectTransform top;
		public RectTransform bottom;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
					if (boardUIData != null) {
						int width = boardUIData.width.v;
						int height = boardUIData.height.v;
						// left
						{
							if (left != null) {
								left.sizeDelta = new Vector2 (1, height + 2);
								float x = Common.converPosToBoundaryLocalPosition (-1, 0, boardUIData).x;
								left.localPosition = new Vector2 (x, 0);
							} else {
								Debug.LogError ("left null: " + this);
							}
						}
						// right
						{
							if (right != null) {
								right.sizeDelta = new Vector2 (1, height + 2);
								float x = Common.converPosToBoundaryLocalPosition (width, 0, boardUIData).x;
								right.localPosition = new Vector2 (x, 0);
							} else {
								Debug.LogError ("right null: " + this);
							}
						}
						// top
						{
							if (top != null) {
								top.sizeDelta = new Vector2 (width + 2, 1);
								float y = Common.converPosToBoundaryLocalPosition (0, -1, boardUIData).y;
								top.localPosition = new Vector2 (0, y);
							} else {
								Debug.LogError ("top null: " + this);
							}
						}
						// bottom
						{
							if (bottom != null) {
								bottom.sizeDelta = new Vector2 (width + 2, 1);
								float y = Common.converPosToBoundaryLocalPosition (0, height, boardUIData).y;
								bottom.localPosition = new Vector2 (0, y);
							} else {
								Debug.LogError ("bottom null: " + this);
							}
						}
					} else {
						Debug.LogError ("boardUIData null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private BoardUI.UIData boardUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.boardUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is BoardUI.UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.boardUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			if (data is BoardUI.UIData) {
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
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is BoardUI.UIData) {
				switch ((BoardUI.UIData.Property)wrapProperty.n) {
				case BoardUI.UIData.Property.mineSweeper:
					break;
				case BoardUI.UIData.Property.pieces:
					break;
				case BoardUI.UIData.Property.booom:
					break;
				case BoardUI.UIData.Property.allowWatchBomb:
					break;
				case BoardUI.UIData.Property.maxWidth:
					break;
				case BoardUI.UIData.Property.maxHeight:
					break;
				case BoardUI.UIData.Property.x:
					break;
				case BoardUI.UIData.Property.y:
					break;
				case BoardUI.UIData.Property.width:
					dirty = true;
					break;
				case BoardUI.UIData.Property.height:
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