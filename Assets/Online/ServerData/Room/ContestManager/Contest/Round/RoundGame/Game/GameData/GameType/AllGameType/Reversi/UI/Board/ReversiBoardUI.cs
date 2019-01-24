using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{

	public class ReversiBoardUI : UIBehavior<ReversiBoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<ReferenceData<Reversi>> reversi;

			public LP<ReversiPieceUI.UIData> pieces;

			public LP<ReversiLegalUI.UIData> legals;

			#region Constructor

			public enum Property
			{
				reversi,
				pieces,
				legals
			}

			public UIData() : base()
			{
				this.reversi = new VP<ReferenceData<Reversi>>(this, (byte)Property.reversi, new ReferenceData<Reversi>(null));
				this.pieces = new LP<ReversiPieceUI.UIData>(this, (byte)Property.pieces);
				this.legals = new LP<ReversiLegalUI.UIData>(this, (byte)Property.legals);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find reversi
					Reversi reversi = this.data.reversi.v.data;
					if (reversi != null) {
						// check load full
						bool isLoadFull = true;
						{
							// reversi
							if (isLoadFull) {
								isLoadFull = reversi.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							int move = -1;
							{
								MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.ReversiMove:
										{
											ReversiMoveAnimation reversiMoveAnimation = moveAnimation as ReversiMoveAnimation;
											reversi = reversiMoveAnimation.reversi.v;
											move = reversiMoveAnimation.move.v;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + moveAnimation.getType () + "; " + this);
										break;
									}
								} else {
									// Debug.LogError ("moveAnimation null: " + this);
								}
							}
							// pieces
							{
								// get old list
								List<ReversiPieceUI.UIData> oldPieceUIs = new List<ReversiPieceUI.UIData> ();
								List<ReversiLegalUI.UIData> oldLegalUIs = new List<ReversiLegalUI.UIData> ();
								{
									oldPieceUIs.AddRange (this.data.pieces.vs);
									oldLegalUIs.AddRange (this.data.legals.vs);
								}
								// make board
								{
									// last move
									sbyte lastMove = -1;
									System.UInt64 change = 0;
									{
										if (reversi.nMoveNum.v >= 1 && reversi.nMoveNum.v <= 64) {
											// lastMove
											{
												if (reversi.nMoveNum.v - 1 >= 0 && reversi.nMoveNum.v - 1 < reversi.moves.vs.Count) {
													lastMove = reversi.moves.vs [reversi.nMoveNum.v - 1];
												} else {
													Debug.LogError ("error, nMoveNum, moves error: " + reversi);
												}
											}
											// change
											{
												if (reversi.nMoveNum.v - 1 >= 0 && reversi.nMoveNum.v - 1 < reversi.changes.vs.Count) {
													change = reversi.changes.vs [reversi.nMoveNum.v - 1];
												} else {
													Debug.LogError ("error, nMoveNum, changes error: " + reversi);
												}
											}
										}
									}
									// board
									{
										System.UInt64 taken = reversi.white.v | reversi.black.v;
										// legal
										System.UInt64 legal = Common.getLegal (reversi.white.v, reversi.black.v, reversi.side.v);
										for (int y = 0; y < 8; y++) {
											for (int x = 0; x < 8; x++) {
												int position = 8 * y + x;
												// piece in position
												if ((taken & Common.MOVEMASK [position]) != 0 || position == move) {
													bool needAdd = false;
													// find 
													ReversiPieceUI.UIData pieceUI = null;
													{
														// find old
														{
															for (int i = 0; i < oldPieceUIs.Count; i++) {
																ReversiPieceUI.UIData check = oldPieceUIs [i];
																if (check.position.v < 0) {
																	pieceUI = check;
																} else {
																	if (check.position.v == position) {
																		pieceUI = check;
																		break;
																	}
																}
															}
														}
														// make new
														if (pieceUI == null) {
															pieceUI = new ReversiPieceUI.UIData ();
															{
																pieceUI.uid = this.data.pieces.makeId ();
															}
															needAdd = true;
														} else {
															oldPieceUIs.Remove (pieceUI);
														}
													}
													// update property
													{
														// position
														pieceUI.position.v = position;
														// type
														{
															if (position != move) {
																if ((reversi.black.v & Common.MOVEMASK [position]) != 0) {
																	pieceUI.type.v = Reversi.BLACK;
																} else if ((reversi.white.v & Common.MOVEMASK [position]) != 0) {
																	pieceUI.type.v = Reversi.WHITE;
																} else {
																	pieceUI.type.v = 2;
																}
															} else {
																pieceUI.type.v = reversi.getPlayerIndex () == 0 ? Reversi.BLACK : Reversi.WHITE;
															}
														}
														//flip
														{
															if (position != move) {
																if (move == -1) {
																	if (position == lastMove) {
																		pieceUI.flip.v = lastMove;
																	} else if ((change & Common.MOVEMASK [position]) != 0) {
																		pieceUI.flip.v = lastMove;
																	} else {
																		pieceUI.flip.v = -1;
																	}
																} else {
																	pieceUI.flip.v = -1;
																}
															} else {
																pieceUI.flip.v = -1;
															}
														}
													}
													// add
													if (needAdd) {
														this.data.pieces.add (pieceUI);
													}
												} else {
													if ((legal & Common.MOVEMASK [position]) != 0 && move == -1) {
														// find 
														ReversiLegalUI.UIData legalUI = null;
														{
															// find old
															{
																for (int i = 0; i < oldLegalUIs.Count; i++) {
																	ReversiLegalUI.UIData check = oldLegalUIs [i];
																	if (check.position.v == -1) {
																		legalUI = check;
																	} else {
																		if (check.position.v == position) {
																			legalUI = check;
																			break;
																		}
																	}
																}
															}
															// make new
															if (legalUI == null) {
																legalUI = new ReversiLegalUI.UIData ();
																{
																	legalUI.uid = this.data.legals.makeId ();
																}
																this.data.legals.add (legalUI);
															} else {
																oldLegalUIs.Remove (legalUI);
															}
														}
														// update property
														{
															// position
															legalUI.position.v = position;
														}
													} else {
														// not legal move, empty
													}
												}
											}
										}
									}
								}
								// remove old not use
								{
									foreach (ReversiPieceUI.UIData oldPieceUI in oldPieceUIs) {
										this.data.pieces.remove (oldPieceUI);
									}
									foreach (ReversiLegalUI.UIData oldLegalUI in oldLegalUIs) {
										this.data.legals.remove (oldLegalUI);
									}
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						// Debug.LogError ("reversi null: " + this);
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

		public ReversiPieceUI piecePrefab;
		public ReversiLegalUI legalPrefab;
		private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					animationManagerCheckChange.needTimeChange = false;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (uiData);
				}
				// Update
				{
					UpdateUtils.makeUpdate<AnimationSetDirtyUpdate, UIData> (uiData, this.transform);
				}
				// Child
				{
					uiData.reversi.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
					uiData.legals.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<UIData>) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is Reversi) {
					dirty = true;
					return;
				}
				if (data is ReversiPieceUI.UIData) {
					ReversiPieceUI.UIData piece = data as ReversiPieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (piece, piecePrefab, this.transform);
					}
					// dirty = true;
					return;
				}
				if (data is ReversiLegalUI.UIData) {
					ReversiLegalUI.UIData legal = data as ReversiLegalUI.UIData;
					// UI
					{
						UIUtils.Instantiate (legal, legalPrefab, this.transform);
					}
					// dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				// Update
				{
					uiData.removeCallBackAndDestroy (typeof(AnimationSetDirtyUpdate));
				}
				// Child
				{
					uiData.reversi.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack(this);
					uiData.legals.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<UIData>) {
					return;
				}
			}
			// Child
			{
				if (data is Reversi) {
					return;
				}
				if (data is ReversiPieceUI.UIData) {
					ReversiPieceUI.UIData piece = data as ReversiPieceUI.UIData;
					// UI
					{
						piece.removeCallBackAndDestroy (typeof(ReversiPieceUI));
					}
					return;
				}
				if (data is ReversiLegalUI.UIData) {
					ReversiLegalUI.UIData legal = data as ReversiLegalUI.UIData;
					// UI
					{
						legal.removeCallBackAndDestroy (typeof(ReversiLegalUI));
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
				case UIData.Property.reversi:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pieces:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						// dirty = true;
					}
					break;
				case UIData.Property.legals:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						// dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Check Change
			{
				if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (wrapProperty.p is Reversi) {
					switch ((Reversi.Property)wrapProperty.n) {
					case Reversi.Property.side:
						dirty = true;
						break;
					case Reversi.Property.white:
						dirty = true;
						break;
					case Reversi.Property.black:
						dirty = true;
						break;
					case Reversi.Property.nMoveNum:
						dirty = true;
						break;
					case Reversi.Property.moves:
						dirty = true;
						break;
					case Reversi.Property.changes:
						dirty = true;
						break;
					case Reversi.Property.oldSides:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ReversiPieceUI.UIData) {
					return;
				}
				if (wrapProperty.p is ReversiLegalUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}
			
		#endregion
	}
}