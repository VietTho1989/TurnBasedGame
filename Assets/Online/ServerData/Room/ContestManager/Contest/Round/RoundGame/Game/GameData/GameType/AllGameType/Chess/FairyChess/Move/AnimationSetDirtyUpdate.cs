using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class AnimationSetDirtyUpdate : UpdateBehavior<BoardUI.UIData>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find MoveAnimation
					MoveAnimation moveAnimation = null;
					float time = 0;
					float duration = 0;
					{
						GameDataBoardUI.UIData.getCurrentMoveAnimationInfo (this.data, out moveAnimation, out time, out duration);
					}
					if (moveAnimation != null) {
						// Find pieceUIData need to dirty
						List<PieceUI.UIData> pieceUIDatas = new List<PieceUI.UIData>();
						{
							switch (moveAnimation.getType ()) {
							case GameMove.Type.FairyChessMove:
								{
									FairyChessMoveAnimation fairyChessMoveAnimation = moveAnimation as FairyChessMoveAnimation;
									{
										FairyChessMove.Move move = new FairyChessMove.Move (fairyChessMoveAnimation.move.v);
										foreach (PieceUI.UIData pieceUIData in this.data.pieces.vs) {
											switch (move.type) {
											case Common.MoveType.NORMAL:
											case Common.MoveType.PROMOTION:
											case Common.MoveType.PIECE_PROMOTION:
												{
													if ((int)move.ori == pieceUIData.position.v) {
														pieceUIDatas.Add (pieceUIData);
													}
												}
												break;
											case Common.MoveType.ENPASSANT:
												{
													if ((int)move.ori == pieceUIData.position.v) {
														pieceUIDatas.Add (pieceUIData);
													} else {
														bool isEnPassant = false;
														{
															if (Common.type_of (pieceUIData.piece.v) == Common.PieceType.PAWN) {
																Common.File destFile = Common.file_of (move.dest);
																Common.Rank destRank = Common.rank_of (move.dest);
																// find captureSquare
																Common.Square captureSquare = Common.Square.SQUARE_NB;
																if (destRank == Common.Rank.RANK_3) {
																	captureSquare = Common.make_square (destFile, Common.Rank.RANK_4);
																} else if (destRank == Common.Rank.RANK_6) {
																	captureSquare = Common.make_square (destFile, Common.Rank.RANK_5);
																}
																// Process
																if (pieceUIData.position.v == (int)captureSquare) {
																	isEnPassant = true;
																}
															}
														}
														if (isEnPassant)
															pieceUIDatas.Add (pieceUIData);
													}
												}
												break;
											case Common.MoveType.CASTLING:
												{
													if (Common.rank_of (move.ori) == Common.Rank.RANK_1) {
														if (Common.color_of (pieceUIData.piece.v) == Common.Color.WHITE) {
															if (Common.type_of (pieceUIData.piece.v) == Common.PieceType.KING) {
																pieceUIDatas.Add (pieceUIData);
															} else if (Common.type_of (pieceUIData.piece.v) == Common.PieceType.ROOK) { 
																// isCastiling or not and find dest
																bool isCastlingPiece = false;
																{
																	Common.File yourFile = Common.file_of ((Common.Square)pieceUIData.position.v);
																	Common.File originFile = Common.file_of (move.ori);
																	Common.File destFile = Common.file_of (move.dest);
																	// Debug.LogError ("originFile: " + originFile + "; destFile: " + destFile);
																	if (destFile >= yourFile && destFile <= originFile) {
																		isCastlingPiece = true;
																	} else if (destFile >= originFile && destFile <= yourFile) {
																		isCastlingPiece = true;
																	}
																}
																// Process
																if (isCastlingPiece) {
																	pieceUIDatas.Add (pieceUIData);	
																}
															}
														}
													} else if (Common.rank_of (move.ori) == Common.Rank.RANK_8) {
														if (Common.color_of (pieceUIData.piece.v) == Common.Color.BLACK) {
															if (Common.type_of (pieceUIData.piece.v) == Common.PieceType.KING) {
																pieceUIDatas.Add (pieceUIData);
															} else if (Common.type_of (pieceUIData.piece.v) == Common.PieceType.ROOK) { 
																// isCastiling or not and find dest
																bool isCastlingPiece = false;
																{
																	Common.File yourFile = Common.file_of ((Common.Square)pieceUIData.position.v);
																	Common.File originFile = Common.file_of (move.ori);
																	Common.File destFile = Common.file_of (move.dest);
																	if (destFile >= yourFile && destFile <= originFile) {
																		isCastlingPiece = true;
																	} else if (destFile >= originFile && destFile <= yourFile) {
																		isCastlingPiece = true;
																	}
																}
																// Process
																if (isCastlingPiece) {
																	pieceUIDatas.Add (pieceUIData);
																}
															}
														}
													}
												}
												break;
											case Common.MoveType.DROP:
												{
													if (pieceUIData.position.v == (int)move.ori || pieceUIData.position.v == (int)move.dest) {
														pieceUIDatas.Add (pieceUIData);
													}
												}
												break;
											default:
												{
													Debug.LogError ("unknown moveType: " + move.type + "; " + this);
													pieceUIDatas.Add (pieceUIData);
												}
												break;
											}
										}
									}
								}
								break;
							default:
								{
									// Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
									foreach (PieceUI.UIData pieceUIData in this.data.pieces.vs) {
										pieceUIDatas.Add (pieceUIData);
									}
								}
								break;
							}
						}
						// Set Dirty
						foreach (PieceUI.UIData pieceUIData in pieceUIDatas) {
							PieceUI pieceUI = pieceUIData.findCallBack<PieceUI> ();
							if (pieceUI != null) {
								pieceUI.makeDirty ();
							} else {
								Debug.LogError ("pieceUI null: " + this);
							}
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private AnimationManagerCheckChange<BoardUI.UIData> animationManagerCheckChange = new AnimationManagerCheckChange<BoardUI.UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is BoardUI.UIData) {
				BoardUI.UIData boardUIData = data as BoardUI.UIData;
				// checkChange
				{
					animationManagerCheckChange.needTimeChange = true;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (boardUIData);
				}
				dirty = true;
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<BoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is BoardUI.UIData) {
				BoardUI.UIData boardUIData = data as BoardUI.UIData;
				// checkChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				this.setDataNull (boardUIData);
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<BoardUI.UIData>) {
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
			if (wrapProperty.p is BoardUI.UIData) {
				switch ((BoardUI.UIData.Property)wrapProperty.n) {
				case BoardUI.UIData.Property.fairyChess:
					break;
				case BoardUI.UIData.Property.pieces:
					dirty = true;
					break;
				case BoardUI.UIData.Property.whiteHand:
					break;
				case BoardUI.UIData.Property.blackHand:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			{
				if (wrapProperty.p is AnimationManagerCheckChange<BoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}