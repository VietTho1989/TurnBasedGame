using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData: Data
		{
			
			public VP<ReferenceData<Gomoku>> gomoku;

			public VP<int> boardSize;

			public VP<Weiqi.BoardBackgroundUI.UIData> background;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				gomoku,
				boardSize,
				background,
				pieces
			}

			public UIData() : base()
			{
				this.gomoku = new VP<ReferenceData<Gomoku>>(this, (byte)Property.gomoku, new ReferenceData<Gomoku>(null));
				this.boardSize = new VP<int>(this, (byte)Property.boardSize, 19);
				this.background = new VP<Weiqi.BoardBackgroundUI.UIData>(this, (byte)Property.background, new Weiqi.BoardBackgroundUI.UIData());
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
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
					Gomoku gomoku = this.data.gomoku.v.data;
					if (gomoku != null) {
						// check load full
						bool isLoadFull = true;
						{
							// gomoku
							if (isLoadFull) {
								isLoadFull = gomoku.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							int moveCoord = -1;
							{
								MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.GomokuMove:
										{
											GomokuMoveAnimation gomokuMoveAnimation = moveAnimation as GomokuMoveAnimation;
											gomoku = gomokuMoveAnimation.gomoku.v;
											moveCoord = gomokuMoveAnimation.move.v;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + moveAnimation.getType () + "; " + this);
										break;
									}
								} else {
									Debug.LogError ("moveAnimation null: " + this);
								}
							}
							// Board
							{
								// Find old list
								List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData> ();
								{
									oldPieces.AddRange (this.data.pieces.vs);
								}
								// Update Board
								{
									long length = gomoku.gs.vs.Count;
									if (length == gomoku.boardSize.v * gomoku.boardSize.v) {
										for (int y = 0; y < gomoku.boardSize.v; y++) {
											for (int x = 0; x < gomoku.boardSize.v; x++) {
												int coord = x + gomoku.boardSize.v * y;
												if (gomoku.gs.vs [coord] == '1' || gomoku.gs.vs [coord] == '2'
												    || coord == moveCoord) {
													bool needAdd = false;
													// Find piece
													PieceUI.UIData pieceUI = null;
													{
														// find old
                                                        foreach(PieceUI.UIData check in oldPieces)
                                                        {
                                                            if (check.coord.v == coord)
                                                            {
                                                                pieceUI = check;
                                                                break;
                                                            }
                                                        }
														// make new
														if (pieceUI == null) {
															pieceUI = new PieceUI.UIData ();
															{
																pieceUI.uid = this.data.pieces.makeId ();
															}
															needAdd = true;
														} else {
															oldPieces.Remove (pieceUI);
														}
													}
													// update
													{
														// coord
														pieceUI.coord.v = coord;
														// type
														{
															if (gomoku.gs.vs [coord] == '1') {
																pieceUI.type.v = Common.Type.Black;
															} else if (gomoku.gs.vs [coord] == '2') {
																pieceUI.type.v = Common.Type.White;
															} else {
																if (coord == moveCoord) {
																	pieceUI.type.v = gomoku.getPlayerIndex () == 0 
																	? Common.Type.Black 
																	: Common.Type.White;
																} else {
																	pieceUI.type.v = Common.Type.None;
																}
															}
														}
														// lastMoveIndex
														{
															// find lastMoveIndex
															int lastMoveIndex = -1;
															for (int i = Gomoku.LastMoveCount - 1; i >= 0; i--) {
																if (i < gomoku.lastMove.vs.Count) {
																	if (coord == gomoku.lastMove.vs [i]) {
																		lastMoveIndex = i;
																		break;
																	}
																} else {
																	Debug.LogError ("error, gomoku lastMoveCount error: " + i + "; " + gomoku.lastMove.vs.Count);
																}
															}
															pieceUI.lastMoveIndex.v = lastMoveIndex;
														}
														// isWinCoord
														{
															bool isWinCoord = false;
															// check is win coord
															{
																if (gomoku.winSize.v >= 0 && gomoku.winSize.v < 100) {
																	for (int i = 0; i < gomoku.winSize.v; i++) {
																		if (i < gomoku.winCoord.vs.Count) {
																			if (gomoku.winCoord.vs [i] == coord) {
																				isWinCoord = true;
																				break;
																			}
																		} else {
																			Debug.LogError ("winCoord size error: " + i + "; " + gomoku.winCoord.vs.Count);
																		}
																	}
																} else {
																	Debug.LogError ("winSize error: " + gomoku.winSize.v);
																}
															}
															pieceUI.isWinCoord.v = isWinCoord;
														}
													}
													// add
													if (needAdd) {
														this.data.pieces.add (pieceUI);
													}
												}
											}
										}
									} else {
										Debug.LogError (string.Format ("error, length error: {0}, {1}", length, gomoku.boardSize.v));
									}
								}
								// remove unused piece
								foreach (PieceUI.UIData oldPiece in oldPieces) {
									this.data.pieces.remove (oldPiece);
								}
							}
							// set board size
							{
								this.data.boardSize.v = gomoku.boardSize.v;
								if (this.data.background.v != null) {
									this.data.background.v.size.v = gomoku.boardSize.v;
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("gomoku null");
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

		public Weiqi.BoardBackgroundUI backgroundPrefab;
		public PieceUI piecePrefab;
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
					uiData.gomoku.allAddCallBack (this);
					uiData.background.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
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
				if (data is Gomoku) {
					dirty = true;
					return;
				}
				if (data is Weiqi.BoardBackgroundUI.UIData) {
					Weiqi.BoardBackgroundUI.UIData subUIData = data as Weiqi.BoardBackgroundUI.UIData;
					// UI
					{
						UIUtils.Instantiate (subUIData, backgroundPrefab, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData subUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (subUIData, piecePrefab, this.transform);
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
					uiData.gomoku.allRemoveCallBack (this);
					uiData.background.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
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
				if (data is Gomoku) {
					return;
				}
				if (data is Weiqi.BoardBackgroundUI.UIData) {
					Weiqi.BoardBackgroundUI.UIData boardBackgroundUIData = data as Weiqi.BoardBackgroundUI.UIData;
					// UI
					{
						boardBackgroundUIData.removeCallBackAndDestroy (typeof(Weiqi.BoardBackgroundUI));
					}
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						pieceUIData.removeCallBackAndDestroy (typeof(PieceUI));
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
				case UIData.Property.gomoku:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.boardSize:
					dirty = true;
					break;
				case UIData.Property.background:
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
				if (wrapProperty.p is Gomoku) {
					switch ((Gomoku.Property)wrapProperty.n) {
					case Gomoku.Property.boardSize:
						dirty = true;
						break;
					case Gomoku.Property.gs:
						dirty = true;
						break;
					case Gomoku.Property.player:
						dirty = true;
						break;
					case Gomoku.Property.winningPlayer:
						dirty = true;
						break;
					case Gomoku.Property.lastMove:
						dirty = true;
						break;
					case Gomoku.Property.winSize:
						dirty = true;
						break;
					case Gomoku.Property.winCoord:
						dirty = true;
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is Weiqi.BoardBackgroundUI.UIData) {
					return;
				}
				if (wrapProperty.p is PieceUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}