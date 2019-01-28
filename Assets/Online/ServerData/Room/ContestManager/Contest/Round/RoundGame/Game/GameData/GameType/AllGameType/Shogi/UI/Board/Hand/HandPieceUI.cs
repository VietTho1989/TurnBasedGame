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
								Setting.Style style = Setting.get().style.v;
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

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				dirty = true;
				return;
			}
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				this.setDataNull (uiData);
				return;
			}
            // Setting
            if(data is Setting)
            {
                return;
            }
            // checkChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
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
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        break;
                    case Setting.Property.style:
                        dirty = true;
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Check Change
            if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
                dirty = true;
                return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	
	}
}