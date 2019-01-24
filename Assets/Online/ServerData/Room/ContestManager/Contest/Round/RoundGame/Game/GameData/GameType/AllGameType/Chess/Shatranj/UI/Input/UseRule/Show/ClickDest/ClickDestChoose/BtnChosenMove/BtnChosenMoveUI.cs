using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Shatranj.UseRule
{
	public class BtnChosenMoveUI : UIBehavior<BtnChosenMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			public VP<ReferenceData<ShatranjMove>> shatranjMove;

			public VP<OnClick> onClick;

			#region Constructor

			public enum Property
			{
				shatranjMove,
				onClick
			}

			public UIData() : base()
			{
				this.shatranjMove = new VP<ReferenceData<ShatranjMove>>(this, (byte)Property.shatranjMove, new ReferenceData<ShatranjMove>(null));
				this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
			}

			#endregion
		}

		public interface OnClick
		{
			void onClickMove (ShatranjMove shatranjMove);
		}

		public void onClickMove()
		{
			if (this.data != null) {
				ShatranjMove shatranjMove = this.data.shatranjMove.v.data;
				if (shatranjMove != null) {
					if (this.data.onClick.v != null) {
						this.data.onClick.v.onClickMove (shatranjMove);
					}
				} else {
					Debug.LogError ("shatranjMove null: " + this);
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
					ShatranjMove shatranjMove = this.data.shatranjMove.v.data;
					if (shatranjMove != null) {
						ShatranjMove.Move move = new ShatranjMove.Move (shatranjMove.move.v);
						// imgPromotion
						{
							if (imgPromotion != null) {
								if (move.type == Common.MoveType.PROMOTION) {
									int playerIndex = 0;
									// Find playerIndex
									{
										UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
										if (useRuleInputUIData != null) {
											Shatranj shatranj = useRuleInputUIData.shatranj.v.data;
											if (shatranj != null) {
												playerIndex = shatranj.getPlayerIndex ();
											} else {
												Debug.LogError ("shatranj null: " + this);
											}
										} else {
											Debug.LogError ("useRuleInputUIData null: " + this);
										}
									}
									// Process
									imgPromotion.sprite = ShatranjSpriteContainer.get ().getSprite (Common.make_piece (playerIndex == 0 ? Common.Color.WHITE : Common.Color.BLACK, move.promotion));
								} else {
									imgPromotion.sprite = ShatranjSpriteContainer.get ().getSprite (Common.Piece.NO_PIECE);
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
									Shatranj shatranj = useRuleInputUIData.shatranj.v.data;
									if (shatranj != null) {
										isChess960 = shatranj.chess960.v;
									} else {
										Debug.LogError ("shatranj null: " + this);
									}
								} else {
									Debug.LogError ("useRuleInputUIData null: " + this);
								}
							}
							tvMove.text = Common.moveToString (shatranjMove.move.v, isChess960);
						} else {
							Debug.LogError ("tvMove null: " + this);
						}
					} else {
						Debug.LogError ("shatranjMove null: " + this);
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
					uiData.shatranjMove.allAddCallBack (this);
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
						useRuleInputUIData.shatranj.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				if (data is Shatranj) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is ShatranjMove) {
					// ShatranjMove shatranjMove = data as ShatranjMove;
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
					uiData.shatranjMove.allRemoveCallBack (this);
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
						useRuleInputUIData.shatranj.allRemoveCallBack (this);
					}
					return;
				}
				if (data is Shatranj) {
					return;
				}
			}
			// Child
			{
				if (data is ShatranjMove) {
					// ShatranjMove shatranjMove = data as ShatranjMove;
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
				case UIData.Property.shatranjMove:
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
					case UseRuleInputUI.UIData.Property.shatranj:
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
				if (wrapProperty.p is Shatranj) {
					switch ((Shatranj.Property)wrapProperty.n) {
					case Shatranj.Property.board:
						break;
					case Shatranj.Property.byTypeBB:
						break;
					case Shatranj.Property.byColorBB:
						break;
					case Shatranj.Property.pieceCount:
						break;
					case Shatranj.Property.pieceList:
						break;
					case Shatranj.Property.index:
						break;
					case Shatranj.Property.gamePly:
						break;
					case Shatranj.Property.sideToMove:
						dirty = true;
						break;
					case Shatranj.Property.st:
						break;
					case Shatranj.Property.chess960:
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
				if (wrapProperty.p is ShatranjMove) {
					switch ((ShatranjMove.Property)wrapProperty.n) {
					case ShatranjMove.Property.move:
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