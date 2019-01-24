using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Chess.UseRule
{
	public class ClickDestClickUI : UIBehavior<ClickDestClickUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : ClickDestUI.UIData.Sub
		{

			public LP<LegalMoveUI.UIData> legalMoves;

			public VP<ClickDestClickMoveOrChooseUI.UIData> moveOrChoose;

			#region keyEvent

			public VP<int> keyX;

			public VP<int> keyY;

			#endregion
			
			#region Constructor

			public enum Property
			{
				legalMoves,
				moveOrChoose,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.legalMoves = new LP<LegalMoveUI.UIData>(this, (byte)Property.legalMoves);
				this.moveOrChoose = new VP<ClickDestClickMoveOrChooseUI.UIData>(this, (byte)Property.moveOrChoose, null);
				// keyEvent
				{
					this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
					this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
				}
			}

			#endregion

			public override Type getType ()
			{
				return Type.Click;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// moveOrChoose
					if (!isProcess) {
						ClickDestClickMoveOrChooseUI.UIData moveOrChoose = this.moveOrChoose.v;
						if (moveOrChoose != null) {
							isProcess = moveOrChoose.processEvent (e);
						} else {
							Debug.LogError ("moveOrChoose null: " + this);
						}
					}
					// key
					if (!isProcess) {
						if (InputEvent.isEnter (e)) {
							// enter
							ClickDestClickUI clickDestClickUI = this.findCallBack<ClickDestClickUI> ();
							if (clickDestClickUI != null) {
								clickDestClickUI.onEnterKey ();
							} else {
								Debug.LogError ("clickDestClickUI null: " + this);
							}
							isProcess = true;
						} else if (InputEvent.isArrow (e)) {
							if (this.keyX.v >= 0 && this.keyX.v < 8
							    && this.keyY.v >= 0 && this.keyY.v < 8) {
								// find new key position
								int newKeyX = this.keyX.v;
								int newKeyY = this.keyY.v;
								{
									switch (e.keyCode) {
									case KeyCode.LeftArrow:
										newKeyX--;
										break;
									case KeyCode.RightArrow:
										newKeyX++;
										break;
									case KeyCode.UpArrow:
										newKeyY++;
										break;
									case KeyCode.DownArrow:
										newKeyY--;
										break;
									default:
										Debug.LogError ("unknown keyCode: " + e.keyCode);
										break;
									}
								}
								// set
								if (newKeyX >= 0 && newKeyX < 8
								    && newKeyY >= 0 && newKeyY < 8) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								// bring to lastMove
								int lastKeyX = 4;
								int lastKeyY = 4;
								{
									ClickDestUI.UIData clickDestUIData = this.findDataInParent<ClickDestUI.UIData> ();
									if (clickDestUIData != null) {
										lastKeyX = clickDestUIData.x.v;
										lastKeyY = clickDestUIData.y.v;
									} else {
										Debug.LogError ("clickDestUIData null: " + this);
									}
								}
								// set
								this.keyX.v = lastKeyX;
								this.keyY.v = lastKeyY;
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public Image imgSelect;

		public GameObject keySelect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// keySelect
					{
						if (keySelect != null) {
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.keyX.v, this.data.keyY.v);
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
					}
					// imgSelect
					{
						if (imgSelect != null) {
							ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
							if (clickDestUIData != null) {
								int x = clickDestUIData.x.v;
								int y = clickDestUIData.y.v;
								// Debug.LogError ("imgSelect: " + x + "; " + y);
								imgSelect.transform.localPosition = new Vector3 (x - 3.5f, y - 3.5f, 0);
							} else {
								Debug.LogError ("clickDestUIData null: " + this);
							}
							// TODO co the co rotate
							{
								// TODO Can hoan thien
							}
						} else {
							Debug.LogError ("imgSelect null: " + this);
						}
					}
					// Legal moves
					{
						List<LegalMoveUI.UIData> oldLegalMoves = new List<LegalMoveUI.UIData> ();
						// get oldLegalMoves
						oldLegalMoves.AddRange(this.data.legalMoves.vs);
						// Update
						{
							// Get legal move list
							List<ChessMove> legalMoves = new List<ChessMove>();
							{
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
								if (show != null) {
									for (int i = 0; i < show.legalMoves.vs.Count; i++) {
										ChessMove legalMove = show.legalMoves.vs [i];
										// check correct
										bool isCorrect = false;
										{
											int fromX = 0;
											int fromY = 0;
											int destX = 0;
											int destY = 0;
											ChessMove.GetClickPosition (legalMove.move.v, out fromX, out fromY, out destX, out destY);
											if (clickDestUIData.x.v == fromX && clickDestUIData.y.v == fromY) {
												isCorrect = true;
											}
										}
										if (isCorrect) {
											legalMoves.Add (legalMove);
										}
									}
								} else {
									Debug.LogError ("show null: " + this);
								}
							}
							// Debug.LogError ("clickDestClickUI: " + GameUtils.Utils.getListString (legalMoves) + "; " + this);
							// Make UI
							{
								for (int legalMoveIndex = 0; legalMoveIndex < legalMoves.Count; legalMoveIndex++) {
									ChessMove legalMove = legalMoves [legalMoveIndex];
									// Find LegalMoveUIData
									LegalMoveUI.UIData legalMoveUIData = null;
									{
										// Find old
										{
											for (int i = 0; i < oldLegalMoves.Count; i++) {
												LegalMoveUI.UIData check = oldLegalMoves [i];
												if (check.legalMove.v.data == legalMove) {
													legalMoveUIData = check;
													break;
												} else if (check.legalMove.v.data == null) {
													legalMoveUIData = check;
												}
											}
											if (legalMoveUIData != null) {
												oldLegalMoves.Remove (legalMoveUIData);
											}
										}
										// Make new
										if (legalMoveUIData == null) {
											legalMoveUIData = new LegalMoveUI.UIData ();
											{
												legalMoveUIData.uid = this.data.legalMoves.makeId ();
											}
											this.data.legalMoves.add (legalMoveUIData);
										}
									}
									// Update property
									if (legalMoveUIData != null) {
										// legalMove
										legalMoveUIData.legalMove.v = new ReferenceData<ChessMove> (legalMove);
									} else {
										Debug.LogError ("legalMoveUIData null: " + this);
									}
								}
							}
						}
						// Remove old
						foreach (LegalMoveUI.UIData legalMoveUIData in oldLegalMoves) {
							legalMoveUIData.legalMove.v = new ReferenceData<ChessMove> (null);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region implement callBacks

		public LegalMoveUI legalMovePrefab;
		public ClickDestClickMoveOrChooseUI moveOrChoosePrefab;

		private ClickDestUI.UIData clickDestUIData = null;
		private ShowUI.UIData show = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.clickDestUIData);
					DataUtils.addParentCallBack (uiData, this, ref this.show);
				}
				// Child
				{
					uiData.legalMoves.allAddCallBack (this);
					uiData.moveOrChoose.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is ClickDestUI.UIData) {
					dirty = true;
					return;
				}
				if (data is ShowUI.UIData) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is LegalMoveUI.UIData) {
					LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
					// UI
					{
						UIUtils.Instantiate (legalMoveUIData, legalMovePrefab, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is ClickDestClickMoveOrChooseUI.UIData) {
					ClickDestClickMoveOrChooseUI.UIData moveOrChoose = data as ClickDestClickMoveOrChooseUI.UIData;
					// UI
					{
						ClickDestClickMoveOrChooseUI moveOrChooseUI = (ClickDestClickMoveOrChooseUI)UIUtils.Instantiate (moveOrChoose, moveOrChoosePrefab, this.transform);
						if (moveOrChooseUI != null) {
							moveOrChooseUI.transform.SetAsLastSibling ();
						} else {
							Debug.LogError ("moveOrChooseUI null: " + this);
						}
					}
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
					DataUtils.removeParentCallBack (uiData, this, ref this.clickDestUIData);
					DataUtils.removeParentCallBack (uiData, this, ref this.show);
				}
				// Child
				{
					uiData.legalMoves.allRemoveCallBack (this);
					uiData.moveOrChoose.allRemoveCallBack (this);
				}
				return;
			}
			// Parent
			{
				if (data is ClickDestUI.UIData) {
					return;
				}
				if (data is ShowUI.UIData) {
					return;
				}
			}
			// Child
			{
				if (data is LegalMoveUI.UIData) {
					LegalMoveUI.UIData legalMoveUIData = data as LegalMoveUI.UIData;
					// UI
					{
						legalMoveUIData.removeCallBackAndDestroy (typeof(LegalMoveUI));
					}
					return;
				}
				if (data is ClickDestClickMoveOrChooseUI.UIData) {
					ClickDestClickMoveOrChooseUI.UIData moveOrChoose = data as ClickDestClickMoveOrChooseUI.UIData;
					// UI
					{
						moveOrChoose.removeCallBackAndDestroy (typeof(ClickDestClickMoveOrChooseUI));
					}
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
				case UIData.Property.legalMoves:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.moveOrChoose:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.keyX:
					dirty = true;
					break;
				case UIData.Property.keyY:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is ClickDestUI.UIData) {
					switch ((ClickDestUI.UIData.Property)wrapProperty.n) {
					case ClickDestUI.UIData.Property.x:
						{
							dirty = true;
							// reset moveOrChoose
							if (this.data != null) {
								if (this.data.moveOrChoose.v != null) {
									this.data.moveOrChoose.v = null;
								} else {
									Debug.LogError ("moveOrChoose null: " + this);
								}
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						break;
					case ClickDestUI.UIData.Property.y:
						{
							dirty = true;
							// reset moveOrChoose
							if (this.data != null) {
								if (this.data.moveOrChoose.v != null) {
									this.data.moveOrChoose.v = null;
								} else {
									Debug.LogError ("moveOrChoose null: " + this);
								}
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						break;
					case ClickDestUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ShowUI.UIData) {
					switch ((ShowUI.UIData.Property)wrapProperty.n) {
					case ShowUI.UIData.Property.legalMoves:
						dirty = true;
						break;
					case ShowUI.UIData.Property.sub:
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
				if (wrapProperty.p is LegalMoveUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		private void clickDest (int x, int y)
		{
			if (this.data != null) {
				if (this.data.moveOrChoose.v == null) {
					Chess chess = null;
					// Check isActive
					bool isActive = false;
					{
						UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
						if (useRuleInputUIData != null) {
							chess = useRuleInputUIData.chess.v.data;
							if (chess != null) {
								if (Game.IsPlaying (chess)) {
									isActive = true;
								}
							} else {
								Debug.LogError ("chess null: " + this);
								return;
							}
						} else {
							Debug.LogError ("useRuleInputUIData null: " + this);
						}
					}
					if (isActive) {
						if (x >= 0 && x < 8 && y >= 0 && y < 8) {
							// select other piece in the same side
							bool isSelectSameColor = false;
							{
								Common.Square square = Common.make_square ((Common.File)x, (Common.Rank)y);
								switch (chess.piece_on (square)) {
								case Common.Piece.NO_PIECE:
									break;
								case Common.Piece.W_PAWN: 
								case Common.Piece.W_KNIGHT: 
								case Common.Piece.W_BISHOP: 
								case Common.Piece.W_ROOK:
								case Common.Piece.W_QUEEN: 
								case Common.Piece.W_KING:
									{
										if (chess.getPlayerIndex () == 0) {
											isSelectSameColor = true;
										}
									}
									break;
								case Common.Piece.B_PAWN: 
								case Common.Piece.B_KNIGHT: 
								case Common.Piece.B_BISHOP: 
								case Common.Piece.B_ROOK:
								case Common.Piece.B_QUEEN: 
								case Common.Piece.B_KING:
									{
										if (chess.getPlayerIndex () == 1) {
											isSelectSameColor = true;
										}
									}
									break;
								case Common.Piece.PIECE_NB:
									break;
								default:
									Debug.LogError ("unknown piece type: " + chess.piece_on (square) + "; " + this);
									break;
								}
							}
							if (isSelectSameColor) {
								// Check have move same click?
								bool haveMoveSameClick = false;
								{
									ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
									ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
									if (show != null && clickDestUIData!=null) {
										int srcX = clickDestUIData.x.v;
										int srcY = clickDestUIData.y.v;
										for (int i = 0; i < show.legalMoves.vs.Count; i++) {
											ChessMove check = show.legalMoves.vs [i];
											if (ChessMove.IsClickCorrectPosition (check.move.v, clickDestUIData.x.v, 
												clickDestUIData.y.v, x, y)) {
												haveMoveSameClick = true;
												break;
											}
										}
									} else {
										Debug.LogError ("show null: " + this);
									}
								}
								if (!haveMoveSameClick) {
									// Check select same position
									bool isSelectSamePosition = false;
									{
										ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
										if (clickDestUIData != null) {
											if (clickDestUIData.x.v == x && clickDestUIData.y.v == y) {
												isSelectSamePosition = true;
											}
										} else {
											Debug.LogError ("clickDestUIData null: " + this);
										}
									}
									// process
									if (isSelectSamePosition) {
										// Chuyen ve ClickPieceUI
										ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData>();
										if (show != null) {
											ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
											{
												clickPieceUIData.uid = show.sub.makeId ();
											}
											show.sub.v = clickPieceUIData;
										} else {
											Debug.LogError ("show null: " + this);
										}
									} else {
										ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
										if (clickDestUIData != null) {
											clickDestUIData.x.v = x;
											clickDestUIData.y.v = y;
										} else {
											Debug.LogError ("clickDestUIData null: " + this);
										}
									}
								} else {
									Debug.LogError ("haveMoveSameClick: " + this);
									ClickDestClickMoveOrChooseUI.UIData moveOrChoose = new ClickDestClickMoveOrChooseUI.UIData ();
									{
										moveOrChoose.uid = this.data.moveOrChoose.makeId ();
										// destX
										moveOrChoose.destX.v = x;
										// destY
										moveOrChoose.destY.v = y;
									}
									this.data.moveOrChoose.v = moveOrChoose;
								}
							} else {
								// Find move click
								bool haveLegalMove = false;
								{
									ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
									ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
									if (show != null && clickDestUIData!=null) {
										int srcX = clickDestUIData.x.v;
										int srcY = clickDestUIData.y.v;
										for (int i = 0; i < show.legalMoves.vs.Count; i++) {
											ChessMove check = show.legalMoves.vs [i];
											if (ChessMove.IsClickCorrectPosition (check.move.v, clickDestUIData.x.v, 
												clickDestUIData.y.v, x, y)) {
												haveLegalMove = true;
											}
										}
									} else {
										Debug.LogError ("show null: " + this);
									}
								}
								if (haveLegalMove) {
									ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
									if (clickDestUIData != null) {
										ClickDestChooseUI.UIData clickDestChooseUIData = new ClickDestChooseUI.UIData ();
										{
											clickDestChooseUIData.uid = clickDestUIData.sub.makeId ();
											clickDestChooseUIData.x.v = x;
											clickDestChooseUIData.y.v = y;
										}
										clickDestUIData.sub.v = clickDestChooseUIData;
									} else {
										Debug.LogError ("clickDestUIData null: " + this);
									}
								} else {
									Debug.LogError ("click not dest position: " + this);
								}
							}
						} else {
							Debug.LogError ("click outside board");
						}
					} else {
						Debug.LogError ("not active: " + this);
					}
				} else {
					Debug.LogError ("moveOrChoose null: cannot click: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Debug.LogError ("OnPointerDown: " + eventData + "; " + this);
			int x = -1;
			int y = -1;
			{
				Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
				Common.convertLocalPositionToXY (localPosition, out x, out y);
				// Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			}
			this.clickDest (x, y);
		}

		public void onEnterKey()
		{
			if (this.data != null) {
				this.clickDest (this.data.keyX.v, this.data.keyY.v);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}