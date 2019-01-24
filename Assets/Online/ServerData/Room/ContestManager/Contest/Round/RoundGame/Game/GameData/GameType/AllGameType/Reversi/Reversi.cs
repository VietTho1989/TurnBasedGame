using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Reversi.NoneRule;

namespace Reversi
{
	public class Reversi : GameType
	{

		public override Type getType ()
		{
			return Type.Reversi;
		}

		#region Property

		public const int WHITE = 0;
		public const int BLACK = 1;
		public const int NONE = 2;
		/** int side = BLACK;*/
		public VP<int> side;

		#region board

		/** bitbrd white;*/
		public VP<System.UInt64> white;
		/** bitbrd black;*/
		public VP<System.UInt64> black;

		public int getPiece(sbyte square)
		{
			if (square >= 0 && square < 64) {
				if ((this.white.v & Common.MOVEMASK [square]) != 0) {
					return WHITE;
				}
				if ((this.black.v & Common.MOVEMASK [square]) != 0) {
					return BLACK;
				}
			} else {
				Debug.LogError ("square error: " + square + "; " + this);
			}
			return NONE;
		}

		public void setPiece(sbyte square, int piece)
		{
			if (square >= 0 && square < 64) {
				// white
				{
					if (piece == WHITE) {
						this.white.v |= 1UL << square;
					} else {
						this.white.v &= ~(1UL << square);
					}
				}
				// black
				{
					if (piece == BLACK) {
						this.black.v |= 1UL << square;
					} else {
						this.black.v &= ~(1UL << square);
					}
				}
			} else {
				Debug.LogError ("square error: " + square + "; " + this);
			}
		}

		#endregion

		// history
		/** int8_t nMoveNum = 0;*/
		public VP<sbyte> nMoveNum;
		/** int8_t moves[64];*/
		public LP<sbyte> moves;
		/** bitbrd changes[64];*/
		public LP<System.UInt64> changes;
		/** int oldSides[64];*/
		public LP<int> oldSides;

		#endregion

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			side,
			white,
			black,
			nMoveNum,
			moves,
			changes,
			oldSides,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Reversi()
		{
			AllowNames.Add ((byte)Property.side);
			AllowNames.Add ((byte)Property.white);
			AllowNames.Add ((byte)Property.black);
			AllowNames.Add ((byte)Property.nMoveNum);
			AllowNames.Add ((byte)Property.moves);
			AllowNames.Add ((byte)Property.changes);
			AllowNames.Add ((byte)Property.oldSides);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Reversi() : base()
		{
			/** int side = BLACK;*/
			this.side = new VP<int> (this, (byte)Property.side, BLACK);
			/** bitbrd white;*/
			this.white = new VP<ulong>(this, (byte)Property.white, 0);
			/** bitbrd black;*/
			this.black = new VP<ulong> (this, (byte)Property.black, 0);
			/** int8_t nMoveNum = 0;*/
			this.nMoveNum = new VP<sbyte> (this, (byte)Property.nMoveNum, 0);
			/** int8_t moves[64];*/
			this.moves = new LP<sbyte> (this, (byte)Property.moves);
			/** bitbrd changes[64];*/
			this.changes = new LP<ulong> (this, (byte)Property.changes);
			/** int oldSides[64];*/
			this.oldSides = new LP<int> (this, (byte)Property.oldSides);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// TODO Co can kiem tra cai gi ko
			}
			return ret;
		}

		#endregion

		#region Convert

		public static byte[] convertToBytes(Reversi reversi, bool needCheckCustom = true)
		{
			// custom
			/*if (chess.isCustom.v && needCheckCustom) {
				string strFen = Core.unityPositionToFen (chess, Core.CanCorrect);
				Debug.LogError ("chess custom fen: " + strFen);
				Chess newChess = Core.unityMakePositionByFen (strFen, chess.chess960.v);
				return convertToBytes (newChess);
			}*/
			// normal
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						/** int side = BLACK;*/
						writer.Write (reversi.side.v);
						/** bitbrd white;*/
						writer.Write (reversi.white.v);
						/** bitbrd black;*/
						writer.Write (reversi.black.v);
						/** int8_t nMoveNum = 0;*/
						writer.Write (reversi.nMoveNum.v);
						/** int8_t moves[64];*/
						{
							for (int i = 0; i < 64; i++) {
								// get value
								sbyte value = 0;
								{
									if (i < reversi.moves.vs.Count) {
										value = reversi.moves.vs [i];
									} else {
										Debug.LogError ("error, index:  moves: " + reversi);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** bitbrd changes[64];*/
						{
							for (int i = 0; i < 64; i++) {
								// get value
								System.UInt64 value = 0;
								{
									if (i < reversi.changes.vs.Count) {
										value = reversi.changes.vs [i];
									} else {
										Debug.LogError ("error, index:  changes: " + reversi);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** int oldSides[64];*/
						{
							for (int i = 0; i < 64; i++) {
								// get value
								int value = 0;
								{
									if (i < reversi.oldSides.vs.Count) {
										value = reversi.oldSides.vs [i];
									} else {
										Debug.LogError ("error, index:  oldSides: " + reversi);
									}
								}
								// write
								writer.Write (value);
							}
						}
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Reversi reversi, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** int side = BLACK;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							reversi.side.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: side: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** bitbrd white;*/
					{
						int size = sizeof(System.UInt64);
						if (count + size <= byteArray.Length) {
							reversi.white.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: white: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					/** bitbrd black;*/
					{
						int size = sizeof(System.UInt64);
						if (count + size <= byteArray.Length) {
							reversi.black.v = BitConverter.ToUInt64 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: black: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** int8_t nMoveNum = 0;*/
					{
						int size = sizeof(sbyte);
						if (count + size <= byteArray.Length) {
							reversi.nMoveNum.v = (sbyte)byteArray [count];
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: nMoveNum: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** int8_t moves[64];*/
					{
						reversi.moves.clear ();
						int size = sizeof(sbyte);
						for (int i = 0; i < 64; i++) {
							if (count + size <= byteArray.Length) {
								reversi.moves.add ((sbyte)byteArray [count]);
								count += size;
							} else {
								Debug.LogError ("array not enough length: moves: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 5:
					/** bitbrd changes[64];*/
					{
						reversi.changes.clear ();
						int size = sizeof(System.UInt64);
						for (int i = 0; i < 64; i++) {
							if (count + size <= byteArray.Length) {
								reversi.changes.add (BitConverter.ToUInt64 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: moves: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 6:
					/** int oldSides[64];*/
					{
						reversi.oldSides.clear ();
						int size = sizeof(int);
						for (int i = 0; i < 64; i++) {
							if (count + size <= byteArray.Length) {
								reversi.oldSides.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: oldSides: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
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
				// Debug.Log ("parse stateInfo success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

		#region implement 

		public override int getTeamCount ()
		{
			return 2;
		}

		public override int getPerspectiveCount ()
		{
			return 2;
		}

		public override int getPlayerIndex ()
		{
			// Black move first
			switch (this.side.v) {
			case BLACK:
				return 0;
			case WHITE:
				return 1;
			default:
				Debug.LogError ("unknown side: " + this.side.v);
				return 0;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.ReversiMove:
						{
							ReversiMove reversiMove = (ReversiMove)gameMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, reversiMove.move.v);
						}
						// break;
					default:
						Debug.LogError ("unknown game move type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.ReversiMove:
						return true;
					case GameMove.Type.ReversiCustomSet:
						return true;
					case GameMove.Type.EndTurn:
						return true;
					case GameMove.Type.Clear:
						return true;
					case GameMove.Type.ReversiCustomMove:
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
				// make tempReversi
				Reversi tempReversi = DataUtils.cloneData (this) as Reversi;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.ReversiCustomSet:
						{
							ReversiCustomSet reversiCustomSet = gameMove as ReversiCustomSet;
							// set piece
							{
								tempReversi.setPiece (reversiCustomSet.square.v, reversiCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							tempReversi.white.v = 0;
							tempReversi.black.v = 0;
						}
						break;
					case GameMove.Type.ReversiCustomMove:
						{
							ReversiCustomMove reversiCustomMove = gameMove as ReversiCustomMove;
							// update
							{
								tempReversi.setPiece (reversiCustomMove.dest.v, tempReversi.getPiece (reversiCustomMove.from.v));
								tempReversi.setPiece (reversiCustomMove.from.v, Reversi.NONE);
							}
						}
						break;
					case GameMove.Type.EndTurn:
						{
							switch (tempReversi.side.v) {
							case BLACK:
								tempReversi.side.v = WHITE;
								break;
							case WHITE:
								tempReversi.side.v = BLACK;
								break;
							default:
								Debug.LogError ("unknown side: " + this.side.v);
								tempReversi.side.v = WHITE;
								break;
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
				if (needUpdate) {
					{
						tempReversi.nMoveNum.v = 0;
						// moves
						for (int i = 0; i < tempReversi.moves.vs.Count; i++) { 
							tempReversi.moves.vs [i] = 0;
						}
						// changes
						for (int i = 0; i < tempReversi.changes.vs.Count; i++) {
							tempReversi.changes.vs [i] = 0;
						}
						// oldSides
						for (int i = 0; i < tempReversi.oldSides.vs.Count; i++) {
							tempReversi.oldSides.vs [i] = 0;
						}
					}
					tempReversi.isCustom.v = true;
					DataUtils.copyData (this, tempReversi, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove (GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.ReversiMove:
				{
					// get information
					ReversiMove reversiMove = (ReversiMove)gameMove;
					// make request to native
					Reversi newReversi = Core.unityDoMove(this, Core.CanCorrect, reversiMove.move.v);
					// update
					DataUtils.copyData (this, newReversi, AllowNames);
				}
				break;
			case GameMove.Type.None:
				break;
			case GameMove.Type.EndTurn:
			case GameMove.Type.ReversiCustomSet:
			case GameMove.Type.Clear:
			case GameMove.Type.ReversiCustomMove:
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

		public override GameMove getAIMove (Computer.AI computerAI, bool isFindHint)
		{
			GameMove ret = new NonMove ();
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
					ReversiAI ai = (computerAI != null && computerAI is ReversiAI) ? (ReversiAI)computerAI : new ReversiAI ();
					sbyte move = Core.unityLetComputerThink (this, true, ai.sort.v, ai.min.v, ai.max.v, ai.end.v, 
						             ai.msLeft.v, ai.useBook.v, ai.percent.v);
					Debug.Log ("find reversi move: " + move + "; " + Common.printMove (move));
					if (move >= 0 && move < 64) {
						ReversiMove reversiMove = new ReversiMove ();
						{
							reversiMove.move.v = move;
						}
						ret = reversiMove;
					} else {
						Debug.LogError ("why cannot find move: " + this);
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
					int[] CanChosePieces = {NONE, WHITE, BLACK };
					for (sbyte square = 0; square < 64; square++) {
						int alreadySelectPiece = this.getPiece (square);
						foreach (int piece in CanChosePieces) {
							if (piece != alreadySelectPiece) {
								ReversiCustomSet reversiCustomSet = new ReversiCustomSet ();
								{
									reversiCustomSet.square.v = square;
									reversiCustomSet.piece.v = piece;
								}
								moves.Add (reversiCustomSet);
							}
						}
					}
				}
				// get custom move
				{
					for (sbyte square = 0; square < 64; square++) {
						int piece = this.getPiece (square);
						if (piece != NONE) {
							for (sbyte destSquare = 0; destSquare < 64; destSquare++) {
								if (destSquare != square) {
									ReversiCustomMove reversiCustomMove = new ReversiCustomMove ();
									{
										reversiCustomMove.from.v = square;
										reversiCustomMove.dest.v = destSquare;
									}
									moves.Add (reversiCustomMove);
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

		public override Result isGameFinish ()
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
					// black win
					{
						Debug.Log ("black: PlayerIndex 0 win: \n" + Common.printPosition (this));
						Debug.Log ("black count: " + Common.countSetBits (this.black.v) + "; white count: " + Common.countSetBits (this.white.v));
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 1));// black: 0 index
						result.scores.Add (new GameType.Score (1, 0));// white: 1 index
					}
					break;
				case 2:
					// white win
					{
						Debug.Log ("white: PlayerIndex 1 win: \n" + Common.printPosition (this));
						Debug.Log ("black count: " + Common.countSetBits (this.black.v) + "; white count: " + Common.countSetBits (this.white.v));
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0));// black: 0 index
						result.scores.Add (new GameType.Score (1, 1));// white: 1 index
					}
					break;
				case 3:
					// draw
					{
						Debug.Log ("the game draw");
						Debug.Log ("black count: " + Common.countSetBits (this.black.v) + "; white count: " + Common.countSetBits (this.white.v));
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0.5f));// black: 0 index
						result.scores.Add (new GameType.Score (1, 0.5f));// white: 1 index
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
	}

}