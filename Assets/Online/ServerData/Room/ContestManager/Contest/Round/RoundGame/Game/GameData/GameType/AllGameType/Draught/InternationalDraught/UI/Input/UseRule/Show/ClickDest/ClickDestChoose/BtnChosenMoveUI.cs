using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace InternationalDraught.UseRule
{
	public class BtnChosenMoveUI : UIBehavior<BtnChosenMoveUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			public VP<ReferenceData<InternationalDraughtMove>> internationalDraughtMove;

			public VP<OnClick> onClick;

			#region Constructor

			public enum Property
			{
				internationalDraughtMove,
				onClick
			}

			public UIData() : base()
			{
				this.internationalDraughtMove = new VP<ReferenceData<InternationalDraughtMove>>(this, (byte)Property.internationalDraughtMove, new ReferenceData<InternationalDraughtMove>(null));
				this.onClick = new VP<OnClick>(this, (byte)Property.onClick, null);
			}

			#endregion
		}

		public interface OnClick
		{
			void onClickMove (InternationalDraughtMove internationalDraughtMove);
		}

		public void onClickMove()
		{
			if (this.data != null) {
				InternationalDraughtMove internationalDraughtMove = this.data.internationalDraughtMove.v.data;
				if (internationalDraughtMove != null) {
					if (this.data.onClick.v != null) {
						this.data.onClick.v.onClickMove (internationalDraughtMove);
					} else {
						Debug.LogError ("onClick null: " + this);
					}
				} else {
					Debug.LogError ("internationalDraughtMove null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		#endregion

		#region Refresh

		public Sprite whiteMan;
		public Sprite whiteKing;
		public Sprite blackMan;
		public Sprite blackKing;
		public Sprite empty;
		public Image imgPiece;

		public Text tvMove;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					InternationalDraughtMove internationalDraughtMove = this.data.internationalDraughtMove.v.data;
					if (internationalDraughtMove != null) {
						// imgPiece
						{
							if (imgPiece != null) {
								// find piece
								int pieceSide = (int)Common.Piece_Side.Empty;
								{
									InternationalDraughtGameDataUI.UIData internationalDraughtGameDataUIData = this.data.findDataInParent<InternationalDraughtGameDataUI.UIData> ();
									if (internationalDraughtGameDataUIData != null) {
										GameData gameData = internationalDraughtGameDataUIData.gameData.v.data;
										if (gameData != null) {
											if(gameData.gameType.v !=null && gameData.gameType.v is InternationalDraught){
												InternationalDraught internationalDraught = gameData.gameType.v as InternationalDraught;
												if (internationalDraught.node.vs.Count > 0) {
													Node node = internationalDraught.node.vs [internationalDraught.node.vs.Count - 1];
													Pos pos = node.p_pos.v;
													if (pos != null) {
														pieceSide = pos.piece_side (InternationalDraughtMove.from (internationalDraughtMove.move.v));
													} else {
														Debug.LogError ("pos null: " + this);
													}
												}
											}
										} else {
											Debug.LogError ("gameData null: " + this);
										}
									} else {
										Debug.LogError ("internationalDraughtGameDataUIData null: " + this);
									}
								}
								// set
								{
									switch (pieceSide) {
									case (int)Common.Piece_Side.White_Man:
										imgPiece.sprite = whiteMan;
										break;
									case (int)Common.Piece_Side.Black_Man:
										imgPiece.sprite = blackMan;
										break;
									case (int)Common.Piece_Side.White_King:
										imgPiece.sprite = whiteKing;
										break;
									case (int)Common.Piece_Side.Black_King:
										imgPiece.sprite = blackKing;
										break;
									case (int)Common.Piece_Side.Empty:
										imgPiece.sprite = empty;
										break;
									default:
										Debug.LogError ("unknown piece side: " + pieceSide + "; " + this);
										imgPiece.sprite = empty;
										break;
									}
								}
							} else {
								Debug.LogError ("imgPromotion null: " + this);
							}
						}
						// tvMove
						if (tvMove != null) {
							tvMove.text = Common.printMove (internationalDraughtMove.move.v);
						} else {
							Debug.LogError ("tvMove null: " + this);
						}
					} else {
						Debug.LogError ("chessMove null: " + this);
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
					uiData.internationalDraughtMove.allAddCallBack (this);
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
						useRuleInputUIData.internationalDraught.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// InternationalDraught
				{
					if (data is InternationalDraught) {
						InternationalDraught internationalDraught = data as InternationalDraught;
						// Child
						{
							internationalDraught.node.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Node
					{
						if (data is Node) {
							Node node = data as Node;
							// Child
							{
								node.p_pos.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
						if (data is Pos) {
							// Pos pos = data as Pos;
							{

							}
							dirty = true;
							return;
						}
					}
				}
			}
			// Child
			{
				if (data is InternationalDraughtMove) {
					// InternationalDraughtMove internationalDraughtMove = data as InternationalDraughtMove;
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
					uiData.internationalDraughtMove.allRemoveCallBack (this);
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
						useRuleInputUIData.internationalDraught.allRemoveCallBack (this);
					}
					return;
				}
				// InternationalDraught
				{
					if (data is InternationalDraught) {
						InternationalDraught internationalDraught = data as InternationalDraught;
						// Child
						{
							internationalDraught.node.allRemoveCallBack (this);
						}
						return;
					}
					// Node
					{
						if (data is Node) {
							Node node = data as Node;
							// Child
							{
								node.p_pos.allRemoveCallBack (this);
							}
							return;
						}
						if (data is Pos) {
							// Pos pos = data as Pos;
							{

							}
							return;
						}
					}
				}
			}
			// Child
			{
				if (data is InternationalDraughtMove) {
					// InternationalDraughtMove internationalDraughtMove = data as InternationalDraughtMove;
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
				case UIData.Property.internationalDraughtMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.onClick:
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
					case UseRuleInputUI.UIData.Property.internationalDraught:
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
				// InternationalDraught
				{
					if (wrapProperty.p is InternationalDraught) {
						switch ((InternationalDraught.Property)wrapProperty.n) {
						case InternationalDraught.Property.node:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case InternationalDraught.Property.var:
							break;
						case InternationalDraught.Property.lastMove:
							break;
						case InternationalDraught.Property.ply:
							break;

						// CaptureSquares
						case InternationalDraught.Property.captureSize:
							break;
						case InternationalDraught.Property.captureSquares:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Node
					{
						if (wrapProperty.p is Node) {
							switch ((Node.Property)wrapProperty.n) {
							case Node.Property.p_pos:
								{
									ValueChangeUtils.replaceCallBack (this, syncs);
									dirty = true;
								}
								break;
							case Node.Property.p_ply:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						if (wrapProperty.p is Pos) {
							switch ((Pos.Property)wrapProperty.n) {
							case Pos.Property.p_piece:
								dirty = true;
								break;
							case Pos.Property.p_side:
								dirty = true;
								break;
							case Pos.Property.p_all:
								dirty = true;
								break;
							case Pos.Property.p_turn:
								dirty = true;
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
			}
			// Child
			{
				if (wrapProperty.p is InternationalDraughtMove) {
					switch ((InternationalDraughtMove.Property)wrapProperty.n) {
					case InternationalDraughtMove.Property.move:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}