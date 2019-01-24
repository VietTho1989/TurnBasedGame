using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ChoosePieceHolder : SriaHolderBehavior<ChoosePieceHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<Common.Piece> piece;

			#region Constructor

			public enum Property
			{
				piece
			}

			public UIData() : base()
			{
				this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.BBishop);
			}

			#endregion

			public void updateView(ChoosePieceAdapter.UIData myParams)
			{
				// Find
				Common.Piece piece = Common.Piece.BBishop;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.pieces.Count) {
						piece = myParams.pieces [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.piece.v = piece;
			}

		}

		#endregion

		#region Refresh

		public Image imgPiece;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
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
							ShogiGameDataUI.UIData.StyleInterface styleInterface = ShogiGameDataUI.GetStyleInterface (this.data, style);
							if (styleInterface != null) {
								imgPiece.sprite = styleInterface.getSprite (this.data.piece.v);
							} else {
								Debug.LogError ("styleInterface null: " + this);
							}
						} else {
							Debug.LogError ("imgPiece null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
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
				case UIData.Property.piece:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnChoose()
		{
			if (this.data != null) {
				// Find ClientInput
				ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
				// Process
				if (clientInput != null) {
					ShogiCustomSet shogiCustomSet = new ShogiCustomSet ();
					{
						// square
						{
							SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData> ();
							if (setPieceUIData != null) {
								shogiCustomSet.square.v = setPieceUIData.square.v;
							} else {
								Debug.LogError ("setPieceUIData null: " + this);
							}
						}
						shogiCustomSet.piece.v = this.data.piece.v;
					}
					clientInput.makeSend (shogiCustomSet);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}