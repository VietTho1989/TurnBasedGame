using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
	public class SetHandHolder : SriaHolderBehavior<SetHandHolder.UIData>
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
				this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.NO_PIECE);
			}

			#endregion

			public void updateView(SetHandAdapter.UIData myParams)
			{
				// Find
				Common.Piece piece = Common.Piece.NO_PIECE;
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

		public Text tvSet;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// imgPiece
					{
						if (imgPiece != null) {
							imgPiece.sprite = SeirawanSpriteContainer.get ().getSprite (this.data.piece.v);
						} else {
							Debug.LogError ("imgPiece null: " + this);
						}
					}
					// inHand
					{
						if (tvSet != null) {
							bool isInHand = true;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									Seirawan seirawan = noneRuleInputUIData.seirawan.v.data;
									if (seirawan != null) {
										isInHand = Seirawan.IsInHand (seirawan.inHand.vs, this.data.piece.v);
									} else {
										Debug.LogError ("seirawan null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputUIData null: " + this);
								}
							}
							tvSet.text = isInHand ? "UnSet" : "Set";
						} else {
							Debug.LogError ("tvInHand null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		private NoneRuleInputUI.UIData noneRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.seirawan.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Seirawan) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.seirawan.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Seirawan) {
					return;
				}
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
			{
				if (wrapProperty.p is NoneRuleInputUI.UIData) {
					switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
					case NoneRuleInputUI.UIData.Property.seirawan:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case NoneRuleInputUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is Seirawan) {
					switch ((Seirawan.Property)wrapProperty.n) {
					case Seirawan.Property.board:
						break;
					case Seirawan.Property.byTypeBB:
						break;
					case Seirawan.Property.byColorBB:
						break;
					case Seirawan.Property.inHand:
						dirty = true;
						break;
					case Seirawan.Property.handScore:
						break;
					case Seirawan.Property.pieceCount:
						break;
					case Seirawan.Property.pieceList:
						break;
					case Seirawan.Property.index:
						break;
					case Seirawan.Property.castlingRightsMask:
						break;
					case Seirawan.Property.castlingRookSquare:
						break;
					case Seirawan.Property.castlingPath:
						break;
					case Seirawan.Property.gamePly:
						break;
					case Seirawan.Property.sideToMove:
						break;
					case Seirawan.Property.st:
						break;
					case Seirawan.Property.chess960:
						break;
					case Seirawan.Property.isCustom:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnSet()
		{
			if (this.data != null) {
				// Find ClientInput
				ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
				// Process
				if (clientInput != null) {
					SeirawanCustomHand seirawanCustomHand = new SeirawanCustomHand ();
					{
						seirawanCustomHand.piece.v = this.data.piece.v;
					}
					clientInput.makeSend (seirawanCustomHand);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}