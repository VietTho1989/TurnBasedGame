using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData: Data
		{
			
			public VP<ReferenceData<Chess>> chess;

			public VP<ChessFenUI.UIData> chessFen;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				chess,
				chessFen,
				pieces
			}

			public UIData() : base()
			{
				this.chess = new VP<ReferenceData<Chess>>(this, (byte)Property.chess, new ReferenceData<Chess>(null));
				this.chessFen = new VP<ChessFenUI.UIData>(this, (byte)Property.chessFen, new ChessFenUI.UIData());
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
			}

			#endregion

		}

		#endregion

		#region refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Chess chess = this.data.chess.v.data;
					if (chess != null) {
						// check load full
						bool isLoadFull = true;
						{
							// chess
							if (isLoadFull) {
								if (chess.board.vs.Count == 0) {
									Debug.LogError ("board not load");
									isLoadFull = false;
								}
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// chessFen
							{
								ChessFenUI.UIData chessFenUIData = this.data.chessFen.v;
								if (chessFenUIData != null) {
									chessFenUIData.chess.v = new ReferenceData<Chess> (chess);
								} else {
									Debug.LogError ("chessFenUIData null: " + this);
								}
							}
							// Normal board
							{
								// get olds
								List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData> ();
								{
									oldPieceUIs.AddRange (this.data.pieces.vs);
								}
								// Find board
								List<int> board = chess.board.vs;
								{
									MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.ChessMove:
											{
												ChessMoveAnimation chessMoveAnimation = moveAnimation as ChessMoveAnimation;
												board = chessMoveAnimation.board.vs;
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
								// Make pieceUI
								{
									for (int index = 0; index < board.Count; index++) {
										int pieceIndex = board [index];
										if (pieceIndex >= 0 && pieceIndex <= (int)Common.Piece.PIECE_NB) {
											Common.Piece piece = (Common.Piece)pieceIndex;
											if (piece != Common.Piece.NO_PIECE) {
												bool needAdd = false;
												// Find pieceUI
												PieceUI.UIData pieceUIData = null;
												{
													// Find old
													for (int i = 0; i < oldPieceUIs.Count; i++) {
														PieceUI.UIData check = oldPieceUIs [i];
														if (check.position.v < 0) {
															pieceUIData = check;
														} else {
															if (check.position.v == index) {
																pieceUIData = check;
																break;
															}
														}
													}
													// Make new
													if (pieceUIData == null) {
														pieceUIData = new PieceUI.UIData ();
														{
															pieceUIData.uid = this.data.pieces.makeId ();
														}
														needAdd = true;
													} else {
														oldPieceUIs.Remove (pieceUIData);
													}
												}
												// Update Property
												{
													// piece
													pieceUIData.piece.v = piece;
													// position
													pieceUIData.position.v = index;
												}
												// add
												if (needAdd) {
													this.data.pieces.add (pieceUIData);
												}
											} else {
												// Debug.Log ("pieceIndex wrong: " + piece + "; " + this);
											}
										}
									}
								}
								// Remove oldPieceUIs not reuse
								foreach (PieceUI.UIData oldPieceUI in oldPieceUIs) {
									// oldPieceUI.position.v = -1;
									this.data.pieces.remove (oldPieceUI);
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("chess null");
					}
				} else {
					// Debug.LogError ("why data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public ChessFenUI chessFenPrefab;
		public Transform chessFenContainer;

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
					uiData.chess.allAddCallBack (this);
					uiData.chessFen.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Chess) {
					dirty = true;
					return;
				}
				if (data is ChessFenUI.UIData) {
					ChessFenUI.UIData chessFenUIData = data as ChessFenUI.UIData;
					// UI
					{
						UIUtils.Instantiate (chessFenUIData, chessFenPrefab, chessFenContainer);
					}
					dirty = true;
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, this.transform);
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
					uiData.chess.allRemoveCallBack (this);
					uiData.chessFen.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				return;
			}
			// Child
			{
				if (data is Chess) {
					return;
				}
				if (data is ChessFenUI.UIData) {
					ChessFenUI.UIData chessFenUIData = data as ChessFenUI.UIData;
					// UI
					{
						chessFenUIData.removeCallBackAndDestroy (typeof(ChessFenUI));
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
				case UIData.Property.chess:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.chessFen:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pieces:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Check Change
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is Chess) {
					switch ((Chess.Property)wrapProperty.n) {
					case Chess.Property.board:
						dirty = true;
						break;
					case Chess.Property.byTypeBB:
						break;
					case Chess.Property.byColorBB:
						break;
					case Chess.Property.pieceCount:
						break;
					case Chess.Property.pieceList:
						break;
					case Chess.Property.index:
						break;
					case Chess.Property.castlingRightsMask:
						break;
					case Chess.Property.castlingRookSquare:
						break;
					case Chess.Property.castlingPath:
						break;
					case Chess.Property.gamePly:
						break;
					case Chess.Property.sideToMove:
						break;
					case Chess.Property.st:
						break;
					case Chess.Property.chess960:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ChessFenUI.UIData) {
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