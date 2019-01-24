using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Xiangqi.UseRule
{
	public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<ReferenceData<LegalMove>> legalMove;

			#region Constructor

			public enum Property
			{
				legalMove
			}

			public UIData() : base()
			{
				this.legalMove = new VP<ReferenceData<LegalMove>>(this, (byte)Property.legalMove, new ReferenceData<LegalMove>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Sprite spriteNone;
		public Sprite spriteDraw;
		public Sprite spriteLoss;
		public Sprite spriteWin;

		public Image imgLegal;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Image
					{
						if (imgLegal != null) {
							// Sprite
							LegalMove legalMove = this.data.legalMove.v.data;
							if (legalMove != null) {
								imgLegal.gameObject.SetActive (true);
								switch (legalMove.repStatus.v) {
								case (int)Common.RepStatus.REP_NONE:
									imgLegal.sprite = spriteNone;
									break;
								case (int)Common.RepStatus.REP_DRAW:
									imgLegal.sprite = spriteDraw;
									break;
								case (int)Common.RepStatus.REP_LOSS:
									imgLegal.sprite = spriteLoss;
									break;
								case (int)Common.RepStatus.REP_WIN:
									imgLegal.sprite = spriteWin;
									break;
								default:
									Debug.LogError ("unknown repStatus: " + this);
									imgLegal.sprite = spriteNone;
									break;
								}
							} else {
								Debug.LogError ("legalMove null: " + this);
								imgLegal.gameObject.SetActive (false);
							}
							// Scale
							{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								imgLegal.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
							}
						} else {
							Debug.LogError ("imgLegal null: " + this);
						}
					}
					// Position
					{
						LegalMove legalMove = this.data.legalMove.v.data;
						if (legalMove != null) {
							Common.MoveStruct moveStruct = new Common.MoveStruct (legalMove.move.v);
							this.transform.localPosition = new Vector3 (moveStruct.destX - 4f, moveStruct.destY - 4.5f, 0);
						} else {
							// Debug.LogError ("legalMove null: " + this);
						}
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
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Child
				{
					uiData.legalMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (data is LegalMove) {
				// LegalMove legalMove = data as LegalMove;
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
				// Child
				{
					uiData.legalMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Child
			if (data is LegalMove) {
				// LegalMove legalMove = data as LegalMove;
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
				case UIData.Property.legalMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
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
			// Child
			if (wrapProperty.p is LegalMove) {
				switch ((LegalMove.Property)wrapProperty.n) {
				case LegalMove.Property.move:
					dirty = true;
					break;
				case LegalMove.Property.repStatus:
					dirty = true;
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