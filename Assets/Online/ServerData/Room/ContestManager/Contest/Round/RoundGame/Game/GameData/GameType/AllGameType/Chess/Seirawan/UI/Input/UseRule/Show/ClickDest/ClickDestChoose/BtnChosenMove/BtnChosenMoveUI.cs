using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Seirawan.UseRule
{
	public class BtnChosenMoveUI : UIBehavior<BtnChosenMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			public VP<ReferenceData<SeirawanMove>> seirawanMove;

			public VP<OnClick> onClick;

			#region Constructor

			public enum Property
			{
				seirawanMove,
				onClick
			}

			public UIData() : base()
			{
				this.seirawanMove = new VP<ReferenceData<SeirawanMove>>(this, (byte)Property.seirawanMove, new ReferenceData<SeirawanMove>(null));
				this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
			}

			#endregion
		}

		public interface OnClick
		{
			void onClickMove (SeirawanMove seirawanMove);
		}

		public void onClickMove()
		{
			if (this.data != null) {
				SeirawanMove seirawanMove = this.data.seirawanMove.v.data;
				if (seirawanMove != null) {
					if (this.data.onClick.v != null) {
						this.data.onClick.v.onClickMove (seirawanMove);
					}
				} else {
					Debug.LogError ("seirawanMove null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		#endregion

		#region Refresh

		public Image imgPromotion;

		public Text tvMoveType;
		public Text tvMove;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SeirawanMove seirawanMove = this.data.seirawanMove.v.data;
					if (seirawanMove != null) {
						SeirawanMove.Move move = new SeirawanMove.Move (seirawanMove.move.v);
						// imgPromotion
						{
							if (imgPromotion != null) {
								int playerIndex = 0;
								// Find playerIndex
								{
									UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
									if (useRuleInputUIData != null) {
										Seirawan seirawan = useRuleInputUIData.seirawan.v.data;
										if (seirawan != null) {
											playerIndex = seirawan.getPlayerIndex ();
										} else {
											Debug.LogError ("seirawan null: " + this);
										}
									} else {
										Debug.LogError ("useRuleInputUIData null: " + this);
									}
								}
								switch (move.type) {
								case Common.MoveType.PROMOTION:
									{
										imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (
											Common.make_piece (playerIndex == 0 ? Common.Color.WHITE 
												: Common.Color.BLACK, move.promotion));
									}
									break;
								case Common.MoveType.NORMAL:
									{
										if (Common.is_gating (seirawanMove.move.v)) {
											imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (
												Common.make_piece (playerIndex == 0 ? Common.Color.WHITE 
													: Common.Color.BLACK, Common.gating_type (seirawanMove.move.v)));
										} else {
											imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.NO_PIECE);
										}
									}
									break;
								default:
									imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.NO_PIECE);
									break;
								}
							} else {
								Debug.LogError ("imgPromotion null: " + this);
							}
						}
						// tvMoveType
						{
							if (tvMoveType != null) {
								switch (move.type) {
								case Common.MoveType.NORMAL:
									tvMoveType.text = "Normal";
									break;
								case Common.MoveType.PROMOTION:
									tvMoveType.text = "Promotion";
									break;
								default:
									tvMoveType.text = "";
									Debug.LogError ("unknown move type: " + move.type + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("tvMoveType null: " + this);
							}
						}
						// tvMove
						if (tvMove != null) {
							bool isChess960 = false;
							{
								UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
								if (useRuleInputUIData != null) {
									Seirawan seirawan = useRuleInputUIData.seirawan.v.data;
									if (seirawan != null) {
										isChess960 = seirawan.chess960.v;
									} else {
										Debug.LogError ("seirawan null: " + this);
									}
								} else {
									Debug.LogError ("useRuleInputUIData null: " + this);
								}
							}
							tvMove.text = Common.moveToString (seirawanMove.move.v, isChess960);
						} else {
							Debug.LogError ("tvMove null: " + this);
						}
					} else {
						Debug.LogError ("seirawanMove null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			// return false to receive click event
			return false;
		}

		#endregion

		#region implement callBacks

		private UseRuleInputUI.UIData useRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.useRuleInputUIData);
				}
				// Child
				{
					uiData.seirawanMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is UseRuleInputUI.UIData) {
					UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
					// Child
					{
						useRuleInputUIData.seirawan.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is Seirawan) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is SeirawanMove) {
					// SeirawanMove seirawanMove = data as SeirawanMove;
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
					DataUtils.removeParentCallBack (uiData, this, ref this.useRuleInputUIData);
				}
				// Child
				{
					uiData.seirawanMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is UseRuleInputUI.UIData) {
					UseRuleInputUI.UIData useRuleInputUIData = data as UseRuleInputUI.UIData;
					// Child
					{
						useRuleInputUIData.seirawan.allRemoveCallBack (this);
					}
					return;
				}
				if (data is Seirawan) {
					return;
				}
			}
			// Child
			{
				if (data is SeirawanMove) {
					// SeirawanMove seirawanMove = data as SeirawanMove;
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
				case UIData.Property.seirawanMove:
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
			// Parent
			{
				if (wrapProperty.p is UseRuleInputUI.UIData) {
					switch ((UseRuleInputUI.UIData.Property)wrapProperty.n) {
					case UseRuleInputUI.UIData.Property.seirawan:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case UseRuleInputUI.UIData.Property.state:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is Seirawan) {
					switch ((Seirawan.Property)wrapProperty.n) {
					case Seirawan.Property.board:
						break;
					case Seirawan.Property.byTypeBB:
						break;
					case Seirawan.Property.byColorBB:
						break;
					case Seirawan.Property.pieceCount:
						break;
					case Seirawan.Property.pieceList:
						break;
					case Seirawan.Property.index:
						break;
					case Seirawan.Property.gamePly:
						break;
					case Seirawan.Property.sideToMove:
						dirty = true;
						break;
					case Seirawan.Property.st:
						break;
					case Seirawan.Property.chess960:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
				if (wrapProperty.p is SeirawanMove) {
					switch ((SeirawanMove.Property)wrapProperty.n) {
					case SeirawanMove.Property.move:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}