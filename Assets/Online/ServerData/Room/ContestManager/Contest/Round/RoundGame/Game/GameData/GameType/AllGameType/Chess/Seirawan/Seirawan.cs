using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Seirawan.NoneRule;

namespace Seirawan
{
	/**
	 * https://www.gnu.org/software/xboard/whats_new/rules/Seirawan.png
	 * */
	public class Seirawan : GameType
	{

		public const string DefaultFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR[HEhe] w KQBCDFGkqbcdfg - 0 1";

		/**Piece board[SQUARE_NB];*/
		public LP<int> board;

		/**Bitboard byTypeBB[PIECE_TYPE_NB];*/
		public LP<ulong> byTypeBB;

		/**Bitboard byColorBB[COLOR_NB];*/
		public LP<ulong> byColorBB;

		#region inHand

		/** bool inHand[PIECE_NB];*/
		public LP<bool> inHand;

		public static bool IsInHand(List<bool> inHand, Common.Piece piece)
		{
			if ((int)piece >= 0 && (int)piece < inHand.Count) {
				return inHand [(int)piece];
			} else {
				Debug.LogError ("piece error: " + piece);
				return false;
			}
		}

		public void setInHand(Common.Piece piece)
		{
			if ((int)piece >= 0 && (int)piece < this.inHand.vs.Count) {
				this.inHand.set ((int)piece, !this.inHand.vs [(int)piece]);
			} else {
				Debug.LogError ("piece error: " + piece);
			}
		}

		#endregion

		/** Score handScore[COLOR_NB];*/
		public LP<int> handScore;

		/**int pieceCount[PIECE_NB];*/
		public LP<int> pieceCount;

		/**Square pieceList[PIECE_NB][16];*/
		public LP<int> pieceList;

		/**int index[SQUARE_NB];*/
		public LP<int> index;

		/** int32_t castlingRightsMask[SQUARE_NB];*/
		public LP<int> castlingRightsMask;

		/** Square castlingRookSquare[CASTLING_RIGHT_NB];*/
		public LP<int> castlingRookSquare;

		/** Bitboard castlingPath[CASTLING_RIGHT_NB];*/
		public LP<ulong> castlingPath;

		/**int gamePly;*/
		public VP<int> gamePly;
		/**Color sideToMove;*/
		public VP<int> sideToMove;

		/**StateInfo* st;*/
		public LP<SeirawanStateInfo> st;

		public int rule50_count()
		{
			if (st.getValueCount() > 0) {
				SeirawanStateInfo last = this.st.vs [st.getValueCount () - 1];
				return last.rule50.v;
			}
			return 0;
		}

		/**bool chess960;*/
		public VP<bool> chess960;

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			board,
			byTypeBB,
			byColorBB,
			inHand,
			handScore,
			pieceCount,
			pieceList,
			index,
			castlingRightsMask,
			castlingRookSquare,
			castlingPath,
			gamePly,
			sideToMove,
			st,
			chess960,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Seirawan()
		{
			AllowNames.Add ((byte)Property.board);
			AllowNames.Add ((byte)Property.byTypeBB);
			AllowNames.Add ((byte)Property.byColorBB);
			AllowNames.Add ((byte)Property.inHand);
			AllowNames.Add ((byte)Property.handScore);
			AllowNames.Add ((byte)Property.pieceCount);
			AllowNames.Add ((byte)Property.pieceList);
			AllowNames.Add ((byte)Property.index);
			AllowNames.Add ((byte)Property.castlingRightsMask);
			AllowNames.Add ((byte)Property.castlingRookSquare);
			AllowNames.Add ((byte)Property.castlingPath);
			AllowNames.Add ((byte)Property.gamePly);
			AllowNames.Add ((byte)Property.sideToMove);
			AllowNames.Add ((byte)Property.st);
			AllowNames.Add ((byte)Property.chess960);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Seirawan() : base()
		{
			this.board = new LP<int> (this, (byte)Property.board);
			this.byTypeBB = new LP<ulong> (this, (byte)Property.byTypeBB);
			this.byColorBB = new LP<ulong> (this, (byte)Property.byColorBB);
			this.inHand = new LP<bool> (this, (byte)Property.inHand);
			this.handScore = new LP<int> (this, (byte)Property.handScore);
			this.pieceCount = new LP<int> (this, (byte)Property.pieceCount);
			this.pieceList = new LP<int> (this, (byte)Property.pieceList);
			this.index = new LP<int> (this, (byte)Property.index);
			this.castlingRightsMask = new LP<int> (this, (byte)Property.castlingRightsMask);
			this.castlingRookSquare = new LP<int> (this, (byte)Property.castlingRookSquare);
			this.castlingPath = new LP<ulong> (this, (byte)Property.castlingPath);
			this.gamePly = new VP<int> (this, (byte)Property.gamePly, 0);
			this.sideToMove = new VP<int> (this, (byte)Property.sideToMove, (int)Common.Color.BLACK);
			this.st = new LP<SeirawanStateInfo> (this, (byte)Property.st);
			this.chess960 = new VP<bool> (this, (byte)Property.chess960, false);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// board
				if (ret) {
					if (this.board.vs.Count == 0) {
						Debug.LogError ("Don't have any piece");
						ret = false;
					}
				}
				// st
				if (ret) {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SeirawanIdentity) {
							SeirawanIdentity seirawanIdentity = dataIdentity as SeirawanIdentity;
							if (seirawanIdentity.st != this.st.vs.Count) {
								Debug.LogError ("st count error");
								ret = false;
							}
						} else {
							Debug.LogError ("why not seirawanIdentity");
						}
					}
				}
			}
			return ret;
		}

		#endregion

		public override Type getType ()
		{
			return Type.Seirawan;
		}

		public override int getTeamCount ()
		{
			return 2;
		}

		public override int getPerspectiveCount ()
		{
			return 2;
		}

		public Common.Piece piece_on(Common.Square s)
		{
			if ((int)s >= 0 && (int)s < this.board.vs.Count) {
				return (Common.Piece)this.board.vs [(int)s];
			} else {
				return Common.Piece.NO_PIECE;
			}
		}

		public void setPieceOn(Common.Square square, Common.Piece piece)
		{
			if ((int)square >= 0 && (int)square < this.board.vs.Count) {
				this.board.set ((int)square, (int)piece);
			} else {
				Debug.LogError ("outside board: " + this);
			}
		}

		#region Logic

		public override int getPlayerIndex ()
		{
			switch (this.sideToMove.v) {
			case (int)Common.Color.WHITE:
				return 0;
			case (int)Common.Color.BLACK:
				return 1;
			default:
				Debug.LogError ("unknown side to move: " + this.sideToMove.v);
				return 0;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.SeirawanMove:
						{
							SeirawanMove seirawanMove = (SeirawanMove)gameMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, seirawanMove.move.v);
						}
					// break;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.SeirawanCustomSet:
					case GameMove.Type.SeirawanCustomMove:
					case GameMove.Type.SeirawanCustomHand:
					case GameMove.Type.Clear:
					case GameMove.Type.EndTurn:
						return true;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						return true;
					}
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
			return false;
		}

		#region processGameMove

		private void processCustomGameMove(GameMove gameMove)
		{
			if (gameMove != null) {
				// make tempSeirawan
				Seirawan tempSeirawan = DataUtils.cloneData (this) as Seirawan;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.SeirawanCustomSet:
						{
							NoneRule.SeirawanCustomSet seirawanCustomSet = gameMove as NoneRule.SeirawanCustomSet;
							// set piece
							{
								Common.Square square = Common.make_square ((Common.File)seirawanCustomSet.x.v, (Common.Rank)seirawanCustomSet.y.v);
								tempSeirawan.setPieceOn (square, seirawanCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempSeirawan.board.vs.Count; i++) {
								tempSeirawan.board.vs [i] = (int)Common.Piece.NO_PIECE;
							}
						}
						break;
					case GameMove.Type.SeirawanCustomMove:
						{
							NoneRule.SeirawanCustomMove seirawanCustomMove = gameMove as NoneRule.SeirawanCustomMove;
							// update
							{
								Common.Square fromSquare = Common.make_square ((Common.File)seirawanCustomMove.fromX.v, (Common.Rank)seirawanCustomMove.fromY.v);
								Common.Square destSquare = Common.make_square ((Common.File)seirawanCustomMove.destX.v, (Common.Rank)seirawanCustomMove.destY.v);
								tempSeirawan.setPieceOn (destSquare, tempSeirawan.piece_on (fromSquare));
								tempSeirawan.setPieceOn (fromSquare, Common.Piece.NO_PIECE);
							}
						}
						break;
					case GameMove.Type.SeirawanCustomHand:
						{
							SeirawanCustomHand seirawanCustomHand = gameMove as SeirawanCustomHand;
							tempSeirawan.setInHand (seirawanCustomHand.piece.v);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + gameMove.getType () + "; " + this);
						needUpdate = false;
						break;
					}
				}
				// Update
				if (needUpdate) {
					tempSeirawan.isCustom.v = true;
					DataUtils.copyData (this, tempSeirawan, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove(GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.SeirawanMove:
				{
					// get information
					SeirawanMove seirawanMove = (SeirawanMove)gameMove;
					// make request to native
					Seirawan newSeirawan = Core.unityDoMove(this, Core.CanCorrect, seirawanMove.move.v);
					// Copy to current chess
					DataUtils.copyData (this, newSeirawan, AllowNames);
				}
				break;
			case GameMove.Type.EndTurn:
				{
					if (this.sideToMove.v == (int)Common.Color.BLACK) {
						this.sideToMove.v = (int)Common.Color.WHITE;
					} else {
						this.sideToMove.v = (int)Common.Color.BLACK;
					}
					this.isCustom.v = true;
				}
				break;
			case GameMove.Type.SeirawanCustomMove:
			case GameMove.Type.SeirawanCustomSet:
			case GameMove.Type.SeirawanCustomHand:
			case GameMove.Type.Clear:
				this.processCustomGameMove (gameMove);
				break;
			default:
				Debug.LogError ("unknown gameMove: " + gameMove + "; " + this);
				this.processCustomGameMove (gameMove);
				break;
			}
		}

		#endregion

		#region getAIMove

		public override GameMove getAIMove(Computer.AI ai, bool isFindHint)
		{
			GameMove ret = new NonMove();
			{
				// check is userNormalMove
				bool useNormalMove = true;
				{
					if (GameData.IsUseRule (this)) {
						useNormalMove = true;
					} else {
						useNormalMove = false;
						/*GameData gameData = this.findDataInParent<GameData>();
						if (gameData != null) {
							Turn turn = gameData.turn.v;
							if (turn != null) {
								if (turn.turn.v % 4 == 0 || turn.turn.v % 4 == 2) {
									useNormalMove = false;
								}
							} else {
								Debug.LogError ("turn null: " + this);
							}
						} else {
							Debug.LogError ("gameData null: " + this);
						}*/
					}
				}
				// process
				if (useNormalMove) {
					// sleep until get enough data
					{
						int count = 0;
						while (true) {
							if (isLoadFull ()) {
								break;
							} else {
								System.Threading.Thread.Sleep (1000);
								Debug.LogError ("need sleep: " + count);
								count++;
								if (count >= 360) {
									Debug.LogError ("why don't have data");
									return new NonMove ();
								}
							}
						}
					}
					// get ai
					SeirawanAI seirawanAI = (ai != null && ai is SeirawanAI) ? (SeirawanAI)ai : new SeirawanAI ();
					// search
					int move = Core.unityLetComputerThink (this, Core.CanCorrect, seirawanAI.depth.v, 
						           seirawanAI.skillLevel.v, seirawanAI.duration.v);
					// make move
					if (move != 0) {
						SeirawanMove seirawanMove = new SeirawanMove ();
						{
							seirawanMove.move.v = move;
						}
						ret = seirawanMove;
					} else {
						Debug.LogError ("Why cannot find move");
					}
				} else {
					GameMove customMove = getCustomMove ();
					if (customMove != null) {
						ret = customMove;
					} else {
						Debug.LogError ("customMove null: " + this);
					}
				}
			}
			return ret;
		}

		public GameMove getCustomMove()
		{
			// find moves
			List<GameMove> moves = new List<GameMove> ();
			{
				// get inHand
				{
					Common.Piece[] pieces = {Common.Piece.W_ELEPHANT, Common.Piece.W_HAWK, Common.Piece.B_ELEPHANT, Common.Piece.B_HAWK };
					foreach (Common.Piece piece in pieces) {
						SeirawanCustomHand seirawanCustomHand = new SeirawanCustomHand ();
						{
							seirawanCustomHand.piece.v = piece;
						}
						moves.Add (seirawanCustomHand);
					}
				}
				// get custom set
				{
					for (int x = 0; x < 8; x++) {
						for (int y = 0; y < 8; y++) {
							Common.Square square = Common.make_square ((Common.File)x, (Common.Rank)y);
							Common.Piece alreadySelectPiece = this.piece_on (square);
							if (alreadySelectPiece != Common.Piece.W_KING && alreadySelectPiece != Common.Piece.B_KING) {
								foreach (Common.Piece piece in System.Enum.GetValues(typeof(Common.Piece))) {
									if (piece != alreadySelectPiece && piece != Common.Piece.PIECE_NB) {
										if (piece != Common.Piece.W_KING && piece != Common.Piece.B_KING) {
											NoneRule.SeirawanCustomSet seirawanCustomSet = new NoneRule.SeirawanCustomSet ();
											{
												seirawanCustomSet.x.v = x;
												seirawanCustomSet.y.v = y;
												seirawanCustomSet.piece.v = piece;
											}
											moves.Add (seirawanCustomSet);
										}
									}
								}
							}
						}
					}
				}
				// get custom move
				{
					for (int x = 0; x < 8; x++) {
						for (int y = 0; y < 8; y++) {
							Common.Square square = Common.make_square ((Common.File)x, (Common.Rank)y);
							Common.Piece piece = this.piece_on (square);
							if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.PIECE_NB) {
								if (piece != Common.Piece.W_KING && piece != Common.Piece.B_KING) {
									for (int destX = 0; destX < 8; destX++) {
										for (int destY = 0; destY < 8; destY++) {
											if (destX != x || destY != y) {
												Common.Piece destPiece = this.piece_on (Common.make_square ((Common.File)destX, (Common.Rank)destY));
												if (destPiece != Common.Piece.W_KING && destPiece != Common.Piece.B_KING) {
													SeirawanCustomMove seirawanCustomMove = new SeirawanCustomMove ();
													{
														seirawanCustomMove.fromX.v = x;
														seirawanCustomMove.fromY.v = y;
														seirawanCustomMove.destX.v = destX;
														seirawanCustomMove.destY.v = destY;
													}
													moves.Add (seirawanCustomMove);
												}
											}
										}
									}
								}
							}
						}
					}
				}
				// get clear
				{
					Clear clear = new Clear ();
					{

					}
					moves.Add (clear);
				}
				// endTurn
				{
					EndTurn endTurn = new EndTurn ();
					{

					}
					moves.Add (endTurn);
				}
			}
			// choose
			if (moves.Count > 0) {
				System.Random random = new System.Random ();
				int index = random.Next (0, moves.Count);
				if (index >= 0 && index < moves.Count) {
					return moves [index];
				} else {
					Debug.LogError ("index error: " + index + "; " + this);
					return null;
				}
			} else {
				return null;
			}
		}

		#endregion

		/**
		 * TODO cai ham nay co ve chua that su chinh xac
		 * */
		public override Result isGameFinish()
		{
			Result result = Result.makeDefault ();
			// process
			if (GameData.IsUseRule (this)) {
				int isGameFinish = Core.unityIsGameFinish (this, Core.CanCorrect);
				switch (isGameFinish) {
				case 0:
					{
						result.isGameFinish = false;
					}
					break;
				case 1:
					// white win
					{
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 1));// white
						result.scores.Add (new GameType.Score (1, 0));// black
					}
					break;
				case 2:
					// black win
					{
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0));// white
						result.scores.Add (new GameType.Score (1, 1));// black
					}
					break;
				case 3:
					// draw
					{
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0));// white
						result.scores.Add (new GameType.Score (1, 0));// black
					}
					break;
				default:
					Debug.LogError ("unknown result: " + this);
					break;
				}
			} else {
				bool isTooManyTurn = false;
				{
					GameData gameData = this.findDataInParent<GameData> ();
					if (gameData != null) {
						Turn turn = gameData.turn.v;
						if (turn != null) {
							if (turn.turn.v >= 1000) {
								isTooManyTurn = true;
							}
						} else {
							Debug.LogError ("turn null: " + this);
						}
					} else {
						Debug.LogError ("gameData null: " + this);
					}
				}
				if (isTooManyTurn) {
					// draw
					result.isGameFinish = true;
					// score
					result.scores.Add (new GameType.Score (0, 0.5f));// white
					result.scores.Add (new GameType.Score (1, 0.5f));// black
				}
			}
			// return
			return result;
		}

		#endregion

		#region convert

		public static byte[] convertToBytes(Seirawan seirawan, bool needCheckCustom = true)
		{
			// custom
			if (seirawan.isCustom.v && needCheckCustom) {
				string strFen = Core.unityGetPositionFen (seirawan, Core.CanCorrect);
				Debug.LogError ("seirawan custom fen: " + strFen);
				Seirawan newSeirawan = Core.unityMakePositionByFen (strFen, seirawan.chess960.v);
				return convertToBytes (newSeirawan);
			}
			// normal
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					/**Piece board[SQUARE_NB]; public LP<int> board;*/
					for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.board.vs.Count) {
								value = seirawan.board.vs [i];
							} else {
								Debug.LogError ("index error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
					for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < seirawan.byTypeBB.vs.Count) {
								value = seirawan.byTypeBB.vs [i];
							} else {
								Debug.LogError ("index error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < seirawan.byColorBB.vs.Count) {
								value = seirawan.byColorBB.vs [i];
							} else {
								Debug.LogError ("index error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/** bool inHand[PIECE_NB];*/
					for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++) {
						// get value
						bool value = true;
						{
							if (i < seirawan.inHand.vs.Count) {
								value = seirawan.inHand.vs [i];
							} else {
								Debug.LogError ("inHand error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/** Score handScore[COLOR_NB];*/
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.handScore.vs.Count) {
								value = seirawan.handScore.vs [i];
							} else {
								Debug.LogError ("handScore error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
					for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.pieceCount.vs.Count) {
								value = seirawan.pieceCount.vs [i];
							} else {
								Debug.LogError ("index error: " + seirawan);
							}
						}
						writer.Write (value);
					}	
					/**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
					for (int i = 0; i < (int)Common.Piece.PIECE_NB*16; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.pieceList.vs.Count) {
								value = seirawan.pieceList.vs [i];
							} else {
								Debug.LogError ("index error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/**int index[SQUARE_NB]; public LP<int> index;*/
					for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.index.vs.Count) {
								value = seirawan.index.vs [i];
							} else {
								Debug.LogError ("index error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/** int32_t castlingRightsMask[SQUARE_NB];*/
					for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.castlingRightsMask.vs.Count) {
								value = seirawan.castlingRightsMask.vs [i];
							} else {
								Debug.LogError ("castlingRightsMask error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/** Square castlingRookSquare[CASTLING_RIGHT_NB];*/
					for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < seirawan.castlingRookSquare.vs.Count) {
								value = seirawan.castlingRookSquare.vs [i];
							} else {
								Debug.LogError ("castlingRookSquare error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/** Bitboard castlingPath[CASTLING_RIGHT_NB];*/
					for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < seirawan.castlingPath.vs.Count) {
								value = seirawan.castlingPath.vs [i];
							} else {
								Debug.LogError ("castlingPath error: " + seirawan);
							}
						}
						writer.Write (value);
					}
					/**int gamePly; public VP<int> gamePly;*/
					writer.Write (seirawan.gamePly.v);
					/**Color sideToMove; public VP<int> sideToMove;*/
					writer.Write (seirawan.sideToMove.v);
					/**StateInfo* st; public LP<StateInfo> st;*/
					{
						// Debug.LogError ("convertToBytes: NativeCore: st count: " + chess.st.getValueCount ());
						writer.Write (seirawan.st.getValueCount ());
						for (int i = 0; i < seirawan.st.getValueCount (); i++) {
							SeirawanStateInfo st = seirawan.st.vs [i];
							writer.Write (SeirawanStateInfo.convertToBytes (st));
						}
					}
					/**bool chess960; public VP<bool> chess960;*/
					writer.Write (seirawan.chess960.v);

					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			// Debug.LogError ("convert to byte array: " + byteArray.Length);
			return byteArray;
		}

		public static int parse(Seirawan seirawan, byte[] byteArray, int start)
		{
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						/**Piece board[SQUARE_NB]; public LP<int> board;*/
						seirawan.board.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.board.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: board: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 1:
					{
						/**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
						seirawan.byTypeBB.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.byTypeBB.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: byTypeBB: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					{
						/**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
						seirawan.byColorBB.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.byColorBB.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: byColorBB: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 3:
					{
						/** bool inHand[PIECE_NB];*/
						seirawan.inHand.clear();
						int size = sizeof(bool);
						for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.inHand.add(BitConverter.ToBoolean (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: inHand: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 4:
					{
						/** Score handScore[COLOR_NB];*/
						seirawan.handScore.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.handScore.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: handScore: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 5:
					{
						/**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
						seirawan.pieceCount.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.pieceCount.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 6:
					{
						/**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
						seirawan.pieceList.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Piece.PIECE_NB * 16; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.pieceList.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: pieceList: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 7:
					{
						/**int index[SQUARE_NB]; public LP<int> index;*/
						seirawan.index.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.index.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: index: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 8:
					{
						/** int32_t castlingRightsMask[SQUARE_NB];*/
						seirawan.castlingRightsMask.clear ();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.castlingRightsMask.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: castlingRightsMask: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 9:
					{
						/** Square castlingRookSquare[CASTLING_RIGHT_NB];*/
						seirawan.castlingRookSquare.clear ();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.castlingRookSquare.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: castlingRookSquare: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 10:
					{
						/** Bitboard castlingPath[CASTLING_RIGHT_NB];*/
						seirawan.castlingPath.clear ();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.CastlingRight.CASTLING_RIGHT_NB; i++) {
							if (count + size <= byteArray.Length) {
								seirawan.castlingPath.add (BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: castlingPath: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 11:
					{
						/**int gamePly; public VP<int> gamePly;*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							seirawan.gamePly.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 12:
					{
						/**Color sideToMove; public VP<int> sideToMove;*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							seirawan.sideToMove.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 13:
					{
						/**StateInfo* st; public LP<StateInfo> st;*/
						seirawan.st.clear ();
						int stateInfoNumber = 0;
						{
							if (count + sizeof(int) <= byteArray.Length) {
								stateInfoNumber = BitConverter.ToInt32 (byteArray, count);
								count += sizeof(int);
							} else {
								Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
						}
						// parse
						{
							// Debug.LogError ("parse position stateInfo: " + stateInfoNumber);
							// get list of stateInfo
							List<SeirawanStateInfo> sts = new List<SeirawanStateInfo> ();
							for (int i = 0; i < stateInfoNumber; i++) {
								SeirawanStateInfo st = new SeirawanStateInfo ();
								int stateInfoByteLength = SeirawanStateInfo.parse (st, byteArray, count);
								if (stateInfoByteLength > 0) {
									// add to chess
									{
										sts.Add (st);
										// Debug.LogError ("parse stateInfo: " + st.uid + "; " + st.key.v);
									}
									count += stateInfoByteLength;
								} else {
									Debug.LogError ("cannot parse");
									break;
								}
							}
							// Debug.LogError ("parse stateInfo count: " + chess.st.getValueCount ());
							// add to chess data
							for (int i = 0; i < sts.Count; i++) {
								SeirawanStateInfo st = sts [i];
								{
									st.uid = seirawan.st.makeId ();
								}
								seirawan.st.add (st);
							}
						}
						// Debug.LogError ("Parse NativeCore: st count: " + stateInfoNumber + "; " + chess.st.vs.Count);
					}
					break;
				case 14:
					{
						/**bool chess960; public VP<bool> chess960;*/
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							seirawan.chess960.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: chess960: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				default:
					// Debug.LogError ("unknown index: " + index);
					alreadyPassAll = true;
					break;
				}
				index++;
				if (!isParseCorrect) {
					Debug.LogError ("not parse correct");
					break;
				}
				if (alreadyPassAll) {
					break;
				}
			}
			// return
			if (!isParseCorrect) {
				Debug.LogError ("parse stateInfo fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion
	}
}