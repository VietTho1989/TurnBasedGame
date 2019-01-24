using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ShogiCustomSetUI : UIBehavior<ShogiCustomSetUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<ShogiCustomSet>> shogiCustomSet;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				shogiCustomSet,
				isHint
			}

			public UIData() : base()
			{
				this.shogiCustomSet = new VP<ReferenceData<ShogiCustomSet>>(this, (byte)Property.shogiCustomSet, new ReferenceData<ShogiCustomSet>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.ShogiCustomSet;
			}
		}

		#endregion

		#region Refresh

		public UILineRenderer lineRenderer;

		public Image imgHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ShogiCustomSet shogiCustomSet = this.data.shogiCustomSet.v.data;
					if (shogiCustomSet != null) {
						// lineRenderer
						if (lineRenderer != null) {
							Vector2[] points = new Vector2[5];
							{
								Vector2 localPos = Common.convertSquareToLocalPosition (shogiCustomSet.square.v);
								points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
								points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
								points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
								points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
							}
							lineRenderer.Points = points;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (imgHint != null) {
							// Find style
							ShogiGameDataUI.UIData.Style style = ShogiGameDataUI.UIData.Style.Western;
							{
								ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData> ();
								if (shogiGameDataUIData != null) {
									style = shogiGameDataUIData.style.v;
								} else {
									Debug.LogError ("shogiGameDataUIData null: " + this);
								}
							}
							// Process
							ShogiGameDataUI.UIData.StyleInterface styleInterface = ShogiGameDataUI.GetStyleInterface (this.data, style);
							if (styleInterface != null) {
								if (this.data.isHint.v) {
									// sprite
									imgHint.sprite = styleInterface.getSprite (shogiCustomSet.piece.v);
									// position
									{
										imgHint.transform.localPosition = Common.convertSquareToLocalPosition (shogiCustomSet.square.v);
									}
									// scale
									{
										int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
										imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
									}
								} else {
									imgHint.sprite = styleInterface.getSprite (Common.Piece.Empty);
								}
							} else {
								Debug.LogError ("styleInterface null: " + this);
							}
						} else {
							Debug.LogError ("imgHint null: " + this);
						}
					} else {
						// Debug.LogError ("shogiCustomSet null: " + this);
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

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				// Child
				{
					uiData.shogiCustomSet.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
				dirty = true;
				return;
			}
			// Child
			if (data is ShogiCustomSet) {
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
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				// Child
				{
					uiData.shogiCustomSet.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
				return;
			}
			// Child
			if (data is ShogiCustomSet) {
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
				case UIData.Property.shogiCustomSet:
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
			// Parent
			if (wrapProperty.p is ShogiGameDataUI.UIData) {
				switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n) {
				case ShogiGameDataUI.UIData.Property.gameData:
					break;
				case ShogiGameDataUI.UIData.Property.updateTransform:
					break;
				case ShogiGameDataUI.UIData.Property.transformOrganizer:
					break;
				case ShogiGameDataUI.UIData.Property.style:
					dirty = true;
					break;
				case ShogiGameDataUI.UIData.Property.btnChangeStyle:
					break;
				case ShogiGameDataUI.UIData.Property.isOnAnimation:
					break;
				case ShogiGameDataUI.UIData.Property.board:
					break;
				case ShogiGameDataUI.UIData.Property.lastMove:
					break;
				case ShogiGameDataUI.UIData.Property.showHint:
					break;
				case ShogiGameDataUI.UIData.Property.inputUI:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is ShogiCustomSet) {
				switch ((ShogiCustomSet.Property)wrapProperty.n) {
				case ShogiCustomSet.Property.square:
					dirty = true;
					break;
				case ShogiCustomSet.Property.piece:
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