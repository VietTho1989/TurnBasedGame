using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class HandPieceUI : UIBehavior<HandPieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<Common.HandPiece> handPiece;

			public VP<Common.Color> color;

			public VP<uint> count;

			#region Constructor

			public enum Property
			{
				handPiece,
				color,
				count
			}

			public UIData() : base()
			{
				this.handPiece = new VP<Common.HandPiece>(this, (byte)Property.handPiece, Common.HandPiece.HBishop);
				this.color = new VP<Common.Color>(this, (byte)Property.color, Common.Color.Black);
				this.count = new VP<uint>(this, (byte)Property.count, 1);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Transform shogiCustomHandContainer;

		public Image imgPiece;
		public Text tvCount;

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
						// imgPiece
						{
							if (imgPiece != null) {
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
								{
									ShogiGameDataUI.UIData.StyleInterface styleInterface = ShogiGameDataUI.GetStyleInterface (this.data, style);
									if (styleInterface != null) {
										Common.Color color = Common.Color.Black;
										{
											if (this.data.color.v == Common.Color.Black) {
												color = Common.Color.White;
											} else {
												color = Common.Color.Black;
											}
										}
										imgPiece.sprite = styleInterface.getSpriteForHandPiece (this.data.handPiece.v, color);
									} else {
										Debug.LogError ("styleInterface null: " + this);
									}
								}
							} else {
								Debug.LogError ("imgPiece null: " + this);
							}
						}
						// Count
						{
							if (tvCount != null) {
								tvCount.text = "X" + this.data.count.v;
							} else {
								Debug.LogError ("tvCount null: " + this);
							}
						}
						// Scale
						/*{
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							this.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
						}*/
					} else {
						Debug.LogError ("not load full");
						dirty = true;
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

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;
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
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
				// ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
				{

				}
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
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
				// ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
				{

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
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.handPiece:
					dirty = true;
					break;
				case UIData.Property.count:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Check Change
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				switch ((GameDataBoardCheckPerspectiveChange<UIData>.Property)wrapProperty.n) {
				case GameDataBoardCheckPerspectiveChange<UIData>.Property.change:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is ShogiGameDataUI.UIData) {
				switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n) {
				case ShogiGameDataUI.UIData.Property.gameData:
					break;
				case ShogiGameDataUI.UIData.Property.style:
					dirty = true;
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
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	
	}
}