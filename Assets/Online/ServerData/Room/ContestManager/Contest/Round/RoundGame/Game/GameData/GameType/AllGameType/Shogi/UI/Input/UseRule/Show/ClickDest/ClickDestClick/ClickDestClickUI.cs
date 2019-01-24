using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Shogi.UseRule
{
	public class ClickDestClickUI : UIBehavior<ClickDestClickUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : ClickDestUI.UIData.Sub
		{

			public LP<LegalMoveUI.UIData> legalMoves;

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				legalMoves,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.legalMoves = new LP<LegalMoveUI.UIData>(this, (byte)Property.legalMoves);
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
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
						if (this.keyX.v >= 0 && this.keyX.v < 9
							&& this.keyY.v >= 0 && this.keyY.v < 9) {
							// find new key position
							int newKeyX = this.keyX.v;
							int newKeyY = this.keyY.v;
							{
								switch (e.keyCode) {
								case KeyCode.LeftArrow:
									newKeyX++;
									break;
								case KeyCode.RightArrow:
									newKeyX--;
									break;
								case KeyCode.UpArrow:
									newKeyY--;
									break;
								case KeyCode.DownArrow:
									newKeyY++;
									break;
								default:
									Debug.LogError ("unknown keyCode: " + e.keyCode);
									break;
								}
							}
							// set
							if (newKeyX >= 0 && newKeyX < 9
								&& newKeyY >= 0 && newKeyY < 9) {
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
									lastKeyX = (int)Common.makeFile (clickDestUIData.square.v);
									lastKeyY = (int)Common.makeRank (clickDestUIData.square.v);
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
				return isProcess;
			}

		}

		#endregion

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
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 9
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 9) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertSquareToLocalPosition (Common.makeSquare ((Common.File)this.data.keyX.v, (Common.Rank)this.data.keyY.v));
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
								imgSelect.transform.localPosition = Common.convertSquareToLocalPosition (clickDestUIData.square.v);
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
							List<ShogiMove> legalMoves = new List<ShogiMove>();
							{
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
								if (show != null) {
									for (int i = 0; i < show.legalMoves.vs.Count; i++) {
										ShogiMove legalMove = show.legalMoves.vs [i];
										// check correct
										bool isCorrect = false;
										{
											if (!legalMove.isDrop ()) {
												if (legalMove.from () == clickDestUIData.square.v) {
													isCorrect = true;
												}
											} else {
												Debug.LogError ("Don't set drop");
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
							Debug.LogError ("clickDestClickUI: " + GameUtils.Utils.getListString (legalMoves) + "; " + this);
							// Make UI
							{
								for (int legalMoveIndex = 0; legalMoveIndex < legalMoves.Count; legalMoveIndex++) {
									ShogiMove legalMove = legalMoves [legalMoveIndex];
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
										legalMoveUIData.legalMove.v = new ReferenceData<ShogiMove> (legalMove);
									} else {
										Debug.LogError ("legalMoveUIData null: " + this);
									}
								}
							}
						}
						// Remove old
						foreach (LegalMoveUI.UIData legalMoveUIData in oldLegalMoves) {
							legalMoveUIData.legalMove.v = new ReferenceData<ShogiMove> (null);
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

		#region implement callBacks

		public LegalMoveUI legalMovePrefab;

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
					case ClickDestUI.UIData.Property.square:
						{
							dirty = true;
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

		private void clickDest(int x, int y)
		{
			if (this.data != null) {
				Shogi shogi = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						shogi = useRuleInputUIData.shogi.v.data;
						if (shogi != null) {
							if (Game.IsPlaying (shogi)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("shogi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 9 && y >= 0 && y < 9) {
						Common.Square square = Common.makeSquare ((Common.File)x, (Common.Rank)y);
						// select other piece in the same side
						bool isSelectSameColor = false;
						{
							Common.Piece piece = shogi.getPiece (square);
							if (Common.isRealPiece (piece)) {
								switch (piece) {
								case Common.Piece.BPawn:
								case Common.Piece.BLance:
								case Common.Piece.BKnight:
								case Common.Piece.BSilver:
								case Common.Piece.BBishop: 
								case Common.Piece.BRook:
								case Common.Piece.BGold: 
								case Common.Piece.BKing:
								case Common.Piece.BProPawn:
								case Common.Piece.BProLance:
								case Common.Piece.BProKnight:
								case Common.Piece.BProSilver:
								case Common.Piece.BHorse:
								case Common.Piece.BDragon: 
									{
										if (shogi.getPlayerIndex () == 0) {
											isSelectSameColor = true;
										}
									}
									break;
								case Common.Piece.WPawn:
								case Common.Piece.WLance: 
								case Common.Piece.WKnight: 
								case Common.Piece.WSilver: 
								case Common.Piece.WBishop: 
								case Common.Piece.WRook:
								case Common.Piece.WGold: 
								case Common.Piece.WKing:
								case Common.Piece.WProPawn: 
								case Common.Piece.WProLance: 
								case Common.Piece.WProKnight:
								case Common.Piece.WProSilver:
								case Common.Piece.WHorse:
								case Common.Piece.WDragon:
									{
										if (shogi.getPlayerIndex () == 1) {
											isSelectSameColor = true;
										}
									}
									break;
								default:
									Debug.LogError ("unknown piece: " + piece + "; " + this);
									break;
								}
							} else {
								Debug.LogError ("not click real piece: " + piece + "; " + this);
							}
						}
						if (isSelectSameColor) {
							// Check select same position
							bool isSelectSamePosition = false;
							{
								ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
								if (clickDestUIData != null) {
									if (clickDestUIData.square.v == square) {
										isSelectSamePosition = true;
									}
								} else {
									Debug.LogError ("clickDestUIData null: " + this);
								}
							}
							// process
							if (isSelectSamePosition) {
								// Chuyen ve ClickPieceUI
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
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
									clickDestUIData.square.v = square;
								} else {
									Debug.LogError ("clickDestUIData null: " + this);
								}
							}
						} else {
							// Find move click
							bool haveLegalMove = false;
							{
								ShowUI.UIData show = this.data.findDataInParent<ShowUI.UIData> ();
								ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
								if (show != null && clickDestUIData!=null) {
									for (int i = 0; i < show.legalMoves.vs.Count; i++) {
										ShogiMove check = show.legalMoves.vs [i];
										if (check.from () == clickDestUIData.square.v && check.to () == square) {
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
										clickDestChooseUIData.square.v = square;
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
						Debug.LogError ("click outside: " + this);
					}
				} else {
					Debug.LogError ("not active: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onEnterKey()
		{
			if (this.data != null) {
				this.clickDest (this.data.keyX.v, this.data.keyY.v);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int x = 0;
			int y = 0;
			Common.convertLocalPositionToXY (localPosition, out x, out y);
			this.clickDest (x, y);
		}

	}
}