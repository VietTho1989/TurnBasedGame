using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Makruk.NoneRule;

namespace Makruk
{
	public class Makruk : GameType
	{
		// private static bool log = false;

		public const string DefaultFen = "rnsmksnr/8/pppppppp/8/8/PPPPPPPP/8/RNSKMSNR w 0 1";

		/**Piece board[SQUARE_NB];*/
		public LP<int> board;
		/**Bitboard byTypeBB[PIECE_TYPE_NB];*/
		public LP<ulong> byTypeBB;
		/**Bitboard byColorBB[COLOR_NB];*/
		public LP<ulong> byColorBB;
		/**int pieceCount[PIECE_NB];*/
		public LP<int> pieceCount;
		/**Square pieceList[PIECE_NB][16];*/
		public LP<int> pieceList;
		/**int index[SQUARE_NB];*/
		public LP<int> index;
		/**int gamePly;*/
		public VP<int> gamePly;
		/**Color sideToMove;*/
		public VP<int> sideToMove;

		/**StateInfo* st;*/
		public LP<MakrukStateInfo> st;

		public int rule50_count()
		{
			if (st.getValueCount() > 0) {
				MakrukStateInfo last = this.st.vs [st.getValueCount () - 1];
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
			pieceCount,
			pieceList,
			index,
			gamePly,
			sideToMove,
			st,
			chess960,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Makruk()
		{
			AllowNames.Add ((byte)Property.board);
			AllowNames.Add ((byte)Property.byTypeBB);
			AllowNames.Add ((byte)Property.byColorBB);
			AllowNames.Add ((byte)Property.pieceCount);
			AllowNames.Add ((byte)Property.pieceList);
			AllowNames.Add ((byte)Property.index);
			AllowNames.Add ((byte)Property.gamePly);
			AllowNames.Add ((byte)Property.sideToMove);
			AllowNames.Add ((byte)Property.st);
			AllowNames.Add ((byte)Property.chess960);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Makruk() : base()
		{
			this.board = new LP<int> (this, (byte)Property.board);
			this.byTypeBB = new LP<ulong> (this, (byte)Property.byTypeBB);
			this.byColorBB = new LP<ulong> (this, (byte)Property.byColorBB);
			this.pieceCount = new LP<int> (this, (byte)Property.pieceCount);
			this.pieceList = new LP<int> (this, (byte)Property.pieceList);
			this.index = new LP<int> (this, (byte)Property.index);
			this.gamePly = new VP<int> (this, (byte)Property.gamePly, 0);
			this.sideToMove = new VP<int> (this, (byte)Property.sideToMove, (int)Common.Color.BLACK);
			this.st = new LP<MakrukStateInfo> (this, (byte)Property.st);
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
						if (dataIdentity is MakrukIdentity) {
							MakrukIdentity makrukIdentity = dataIdentity as MakrukIdentity;
							if (makrukIdentity.st != this.st.vs.Count) {
								Debug.LogError ("st count error");
								ret = false;
							}
						} else {
							Debug.LogError ("why not makrukIdentity");
						}
					}
				}
			}
			return ret;
		}

		#endregion

		public override Type getType ()
		{
			return Type.Makruk;
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
					case GameMove.Type.MakrukMove:
						{
							MakrukMove makrukMove = (MakrukMove)gameMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, makrukMove.move.v);
						}
						// break;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.MakrukCustomSet:
					case GameMove.Type.MakrukCustomMove:
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

		#region ProcessGameMove

		private void processCustomGameMove(GameMove gameMove)
		{
			if (gameMove != null) {
				// make tempMakruk
				Makruk tempMakruk = DataUtils.cloneData (this) as Makruk;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.MakrukCustomSet:
						{
							NoneRule.MakrukCustomSet makrukCustomSet = gameMove as NoneRule.MakrukCustomSet;
							// set piece
							{
								Common.Square square = Common.make_square ((Common.File)makrukCustomSet.x.v, (Common.Rank)makrukCustomSet.y.v);
								tempMakruk.setPieceOn (square, makrukCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempMakruk.board.vs.Count; i++) {
								tempMakruk.board.vs [i] = (int)Common.Piece.NO_PIECE;
							}
						}
						break;
					case GameMove.Type.MakrukCustomMove:
						{
							NoneRule.MakrukCustomMove makrukCustomMove = gameMove as NoneRule.MakrukCustomMove;
							// update
							{
								Common.Square fromSquare = Common.make_square ((Common.File)makrukCustomMove.fromX.v, (Common.Rank)makrukCustomMove.fromY.v);
								Common.Square destSquare = Common.make_square ((Common.File)makrukCustomMove.destX.v, (Common.Rank)makrukCustomMove.destY.v);
								tempMakruk.setPieceOn (destSquare, tempMakruk.piece_on (fromSquare));
								tempMakruk.setPieceOn (fromSquare, Common.Piece.NO_PIECE);
							}
						}
						break;
					default:
						Debug.LogError ("unknown type: " + gameMove.getType () + "; " + this);
						needUpdate = false;
						break;
					}
				}
				// Update
				{
					if (needUpdate) {
						tempMakruk.isCustom.v = true;
						DataUtils.copyData (this, tempMakruk, AllowNames);

					}
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove(GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.MakrukMove:
				{
					// get information
					MakrukMove makrukMove = (MakrukMove)gameMove;
					// make request to native
					Makruk newMakruk = Core.unityDoMove(this, Core.CanCorrect, makrukMove.move.v);
					// Copy to current chess
					DataUtils.copyData (this, newMakruk, AllowNames);
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
			case GameMove.Type.MakrukCustomMove:
			case GameMove.Type.MakrukCustomSet:
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

		#region getMove

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
				// Process
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
					MakrukAI makrukAI = (ai != null && ai is MakrukAI) ? (MakrukAI)ai : new MakrukAI ();
					// search
					int move = Core.unityLetComputerThink (this, Core.CanCorrect, makrukAI.depth.v, 
						           makrukAI.skillLevel.v, makrukAI.duration.v);
					// make move
					if (move != 0) {
						MakrukMove makrukMove = new MakrukMove ();
						{
							makrukMove.move.v = move;
						}
						ret = makrukMove;
					} else {
						Debug.LogError ("Why cannot find move: " + this);
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
											NoneRule.MakrukCustomSet makrukCustomSet = new NoneRule.MakrukCustomSet ();
											{
												makrukCustomSet.x.v = x;
												makrukCustomSet.y.v = y;
												makrukCustomSet.piece.v = piece;
											}
											moves.Add (makrukCustomSet);
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
													MakrukCustomMove makrukCustomMove = new MakrukCustomMove ();
													{
														makrukCustomMove.fromX.v = x;
														makrukCustomMove.fromY.v = y;
														makrukCustomMove.destX.v = destX;
														makrukCustomMove.destY.v = destY;
													}
													moves.Add (makrukCustomMove);
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

		public static byte[] convertToBytes(Makruk makruk, bool needCheckCustom = true)
		{
			// custom
			if (makruk.isCustom.v && needCheckCustom) {
				string strFen = Core.unityPositionToFen (makruk, Core.CanCorrect);
				Debug.LogError ("makruk custom fen: " + strFen);
				Makruk newMakruk = Core.unityMakePositionByFen (strFen, makruk.chess960.v);
				return convertToBytes (newMakruk);
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
							if (i < makruk.board.vs.Count) {
								value = makruk.board.vs [i];
							} else {
								Debug.LogError ("index error: " + makruk);
							}
						}
						writer.Write (value);
					}
					/**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
					for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < makruk.byTypeBB.vs.Count) {
								value = makruk.byTypeBB.vs [i];
							} else {
								Debug.LogError ("index error: " + makruk);
							}
						}
						writer.Write (value);
					}
					/**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
					for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
						// get value
						ulong value = 0;
						{
							if (i < makruk.byColorBB.vs.Count) {
								value = makruk.byColorBB.vs [i];
							} else {
								Debug.LogError ("index error: " + makruk);
							}
						}
						writer.Write (value);
					}
					/**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
					for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < makruk.pieceCount.vs.Count) {
								value = makruk.pieceCount.vs [i];
							} else {
								Debug.LogError ("index error: " + makruk);
							}
						}
						writer.Write (value);
					}
					/**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
					for (int i = 0; i < (int)Common.Piece.PIECE_NB * 16; i++) {
						// get value
						int value = 0;
						{
							if (i < makruk.pieceList.vs.Count) {
								value = makruk.pieceList.vs [i];
							} else {
								Debug.LogError ("index error: " + makruk);
							}
						}
						writer.Write (value);
					}
					/**int index[SQUARE_NB]; public LP<int> index;*/
					for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
						// get value
						int value = 0;
						{
							if (i < makruk.index.vs.Count) {
								value = makruk.index.vs [i];
							} else {
								Debug.LogError ("index error: " + makruk);
							}
						}
						writer.Write (value);
					}
					/**int gamePly; public VP<int> gamePly;*/
					writer.Write (makruk.gamePly.v);
					/**Color sideToMove; public VP<int> sideToMove;*/
					writer.Write (makruk.sideToMove.v);
					/**StateInfo* st; public LP<StateInfo> st;*/
					{
						// Debug.LogError ("convertToBytes: NativeCore: st count: " + chess.st.getValueCount ());
						writer.Write (makruk.st.getValueCount ());
						for (int i = 0; i < makruk.st.getValueCount (); i++) {
							MakrukStateInfo st = makruk.st.vs [i];
							writer.Write (MakrukStateInfo.convertToBytes (st));
						}
					}
					/**bool chess960; public VP<bool> chess960;*/
					writer.Write (makruk.chess960.v);

					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			// Debug.LogError ("convert to byte array: " + byteArray.Length);
			return byteArray;
		}

		public static int parse(Makruk makruk, byte[] byteArray, int start)
		{
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				// Debug.LogError ("Parse NativeCore: st count: " + index + "; " + count + "; " + byteArray.Length);
				switch (index) {
				case 0:
					{
						/**Piece board[SQUARE_NB]; public LP<int> board;*/
						makruk.board.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
							if (count + size <= byteArray.Length) {
								makruk.board.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 1:
					{
						/**Bitboard byTypeBB[PIECE_TYPE_NB]; public LP<ulong> byTypeBB;*/
						makruk.byTypeBB.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.PieceType.PIECE_TYPE_NB; i++) {
							if (count + size <= byteArray.Length) {
								makruk.byTypeBB.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					{
						/**Bitboard byColorBB[COLOR_NB]; public LP<ulong> byColorBB;*/
						makruk.byColorBB.clear();
						int size = sizeof(ulong);
						for (int i = 0; i < (int)Common.Color.COLOR_NB; i++) {
							if (count + size <= byteArray.Length) {
								makruk.byColorBB.add(BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 3:
					{
						/**int pieceCount[PIECE_NB]; public LP<int> pieceCount;*/
						makruk.pieceCount.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Piece.PIECE_NB; i++) {
							if (count + size <= byteArray.Length) {
								makruk.pieceCount.add(BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 4:
					{
						/**Square pieceList[PIECE_NB][16]; public LP<int> pieceList;*/
						makruk.pieceList.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Piece.PIECE_NB * 16; i++) {
							if (count + size <= byteArray.Length) {
								makruk.pieceList.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: nonPawnMaterial: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 5:
					{
						/**int index[SQUARE_NB]; public LP<int> index;*/
						makruk.index.clear();
						int size = sizeof(int);
						for (int i = 0; i < (int)Common.Square.SQUARE_NB; i++) {
							if (count + size <= byteArray.Length) {
								makruk.index.add (BitConverter.ToInt32 (byteArray, count));
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
						/**int gamePly; public VP<int> gamePly;*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							makruk.gamePly.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 7:
					{
						/**Color sideToMove; public VP<int> sideToMove;*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							makruk.sideToMove.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: key: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 8:
					{
						/**StateInfo* st; public LP<StateInfo> st;*/
						makruk.st.clear ();
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
							List<MakrukStateInfo> sts = new List<MakrukStateInfo> ();
							for (int i = 0; i < stateInfoNumber; i++) {
								MakrukStateInfo st = new MakrukStateInfo ();
								int stateInfoByteLength = MakrukStateInfo.parse (st, byteArray, count);
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
								MakrukStateInfo st = sts [i];
								{
									st.uid = makruk.st.makeId ();
								}
								makruk.st.add (st);
							}
						}
						// Debug.LogError ("Parse NativeCore: st count: " + stateInfoNumber + "; " + chess.st.vs.Count);
					}
					break;
				case 9:
					{
						/**bool chess960; public VP<bool> chess960;*/
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							makruk.chess960.v = BitConverter.ToBoolean (byteArray, count);
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