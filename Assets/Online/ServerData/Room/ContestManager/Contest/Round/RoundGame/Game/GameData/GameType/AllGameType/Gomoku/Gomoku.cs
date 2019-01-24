using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Gomoku.NoneRule;

namespace Gomoku
{
	public class Gomoku : GameType
	{
		public const int MinBoardSize = 6;
		public const int MaxBoardSize = 100;

		public const int LastMoveCount = 8;

		#region Property

		/** int boardSize = 19;*/
		public VP<int> boardSize;

		#region gs

		/** char* gs = NULL;*/
		public LP<byte> gs;

		public Common.Type getPieceType(int square)
		{
			if (square >= 0 && square < gs.vs.Count) {
				byte pieceByte = gs.vs [square];
				if (pieceByte == '1') {
					return Common.Type.Black;
				} else if (pieceByte == '2') {
					return Common.Type.White;
				} else {
					return Common.Type.None;
				}
			} else {
				Debug.LogError ("square error: " + square);
				return Common.Type.None;
			}
		}

		public void setPieceType(int square, Common.Type piece)
		{
			if (square >= 0 && square < gs.vs.Count) {
				switch (piece) {
				case Common.Type.None:
					this.gs.set (square, (byte)'0');
					break;
				case Common.Type.Black:
					this.gs.set (square, (byte)'1');
					break;
				case Common.Type.White:
					this.gs.set (square, (byte)'2');
					break;
				default:
					Debug.LogError ("unknown piece: " + piece + "; " + this);
					break;
				}
			} else {
				Debug.LogError ("square error: " + square);
			}
		}

		#endregion

		/** int player = 1;*/
		public VP<int> player;
		/** int winningPlayer = 0;*/
		public VP<int> winningPlayer;
		/** int lastMove[LastMoveCount];*/
		public LP<int> lastMove;

		// win information
		/** int winSize = 0;*/
		public VP<int> winSize;
		/** int winCoord[100];*/
		public LP<int> winCoord;

		#endregion

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			boardSize,
			gs,
			player,
			winningPlayer,
			lastMove,
			winSize,
			winCoord,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Gomoku()
		{
			AllowNames.Add ((byte)Property.boardSize);
			AllowNames.Add ((byte)Property.gs);
			AllowNames.Add ((byte)Property.player);
			AllowNames.Add ((byte)Property.winningPlayer);
			AllowNames.Add ((byte)Property.lastMove);
			AllowNames.Add ((byte)Property.winSize);
			AllowNames.Add ((byte)Property.winCoord);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Gomoku() : base()
		{
			this.boardSize = new VP<int> (this, (byte)Property.boardSize, 19);
			this.gs = new LP<byte> (this, (byte)Property.gs);
			this.player = new VP<int> (this, (byte)Property.player, 1);
			this.winningPlayer = new VP<int> (this, (byte)Property.winningPlayer, 0);
			this.lastMove = new LP<int> (this, (byte)Property.lastMove);
			this.winSize = new VP<int> (this, (byte)Property.winSize, 0);
			this.winCoord = new LP<int> (this, (byte)Property.winCoord);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// gs
				if (ret) {
					if (this.gs.vs.Count == 0) {
						Debug.LogError ("gs count = 0");
						ret = false;
					}
				}
			}
			return ret;
		}

		#endregion

		#region Convert Byte Array

		public static byte[] convertToBytes(Gomoku gomoku, bool needCheckCustom = true)
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
						/** int boardSize = 19;*/
						writer.Write (gomoku.boardSize.v);
						/** char* gs = NULL;*/
						{
							int sizeIndex = gomoku.boardSize.v * gomoku.boardSize.v;
							for (int i = 0; i < sizeIndex; i++) {
								// get value
								byte value = (byte)'0';
								{
									if (i < gomoku.gs.vs.Count) {
										value = gomoku.gs.vs [i];
									} else {
										Debug.LogError ("error, index: gs: " + gomoku);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** int player = 1;*/
						writer.Write (gomoku.player.v);
						/** int winningPlayer = 0;*/
						writer.Write (gomoku.winningPlayer.v);
						/** int lastMove[LastMoveCount];*/
						{
							for (int i = 0; i < LastMoveCount; i++) {
								// get value
								int value = -1;
								{
									if (i < gomoku.lastMove.vs.Count) {
										value = gomoku.lastMove.vs [i];
									} else {
										Debug.LogError ("error, index: lastMove: " + gomoku);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** int winSize = 0;*/
						writer.Write (gomoku.winSize.v);
						/** int winCoord[100];*/
						{
							for (int i = 0; i < 100; i++) {
								// get value
								int value = -1;
								{
									if (i < gomoku.winCoord.vs.Count) {
										value = gomoku.winCoord.vs [i];
									} else {
										Debug.LogError ("error, index: winCoord: " + gomoku + "; " + i + "; " + gomoku.winCoord.vs.Count);
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

		public static int parse(Gomoku gomoku, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					/** int boardSize = 19;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							gomoku.boardSize.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: boardSize: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					/** char* gs = NULL;*/
					{
						gomoku.gs.clear ();
						int size = sizeof(byte);
						int sizeIndex = gomoku.boardSize.v * gomoku.boardSize.v;
						for (int i = 0; i < sizeIndex; i++) {
							if (count + size <= byteArray.Length) {
								gomoku.gs.add (byteArray[count]);
								count += size;
							} else {
								Debug.LogError ("array not enough length: gs: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 2:
					/** int player = 1;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							gomoku.player.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: player: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					/** int winningPlayer = 0;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							gomoku.winningPlayer.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: winningPlayer: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** int lastMove[LastMoveCount];*/
					{
						gomoku.lastMove.clear ();
						int size = sizeof(int);
						for (int i = 0; i < LastMoveCount; i++) {
							if (count + size <= byteArray.Length) {
								gomoku.lastMove.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: lastMove: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 5:
					/** int winSize = 0;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							gomoku.winSize.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: winSize: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 6:
					/** int winCoord[100];*/
					{
						gomoku.winCoord.clear ();
						int size = sizeof(int);
						for (int i = 0; i < 100; i++) {
							if (count + size <= byteArray.Length) {
								gomoku.winCoord.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: winCoord: " + count + "; " + byteArray.Length + "; " + i);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				default:
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
				Debug.LogError ("parse gomoku fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.Log ("parse gomoku success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

		public override Type getType ()
		{
			return Type.Gomoku;
		}

		public override int getTeamCount ()
		{
			return 2;
		}

		public override int getPerspectiveCount ()
		{
			return 2;
		}

		#region implement GameType

		public override int getPlayerIndex ()
		{
			switch (this.player.v) {
			case 1:
				return 0;
			case 2:
				return 1;
			default:
				Debug.LogError ("unknown player: " + this.player.v);
				return 0;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.GomokuMove:
						{
							GomokuMove move = (GomokuMove)gameMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, move.move.v);
						}
					// break;
					default:
						Debug.LogError ("unknown game move type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.GomokuCustomSet:
						return true;
					case GameMove.Type.EndTurn:
						return true;
					case GameMove.Type.Clear:
						return true;
					case GameMove.Type.GomokuCustomMove:
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
				// make tempGomoku
				Gomoku tempGomoku = DataUtils.cloneData (this) as Gomoku;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.GomokuCustomSet:
						{
							NoneRule.GomokuCustomSet gomokuCustomSet = gameMove as NoneRule.GomokuCustomSet;
							// set piece
							{
								tempGomoku.setPieceType (gomokuCustomSet.square.v, gomokuCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempGomoku.gs.vs.Count; i++) {
								tempGomoku.gs.vs [i] = (byte)'0';
							}
						}
						break;
					case GameMove.Type.GomokuCustomMove:
						{
							NoneRule.GomokuCustomMove gomokuCustomMove = gameMove as NoneRule.GomokuCustomMove;
							// update
							{
								tempGomoku.setPieceType (gomokuCustomMove.dest.v, tempGomoku.getPieceType (gomokuCustomMove.from.v));
								tempGomoku.setPieceType (gomokuCustomMove.from.v, Common.Type.None);
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
					tempGomoku.isCustom.v = true;
					DataUtils.copyData (this, tempGomoku, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove (GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.GomokuMove:
				{
					// get information
					GomokuMove move = (GomokuMove)gameMove;
					Gomoku newGomoku = Core.unityDoMove (this, Core.CanCorrect, move.move.v);
					if (newGomoku != null) {
						DataUtils.copyData (this, newGomoku, AllowNames);
					} else {
						Debug.LogError ("newGomoku null: " + this);
					}
				}
				break;
			case GameMove.Type.None:
				break;
			case GameMove.Type.EndTurn:
				{
					// change player
					{
						switch (this.player.v) {
						case 1:
							this.player.v = 0;
							break;
						case 2:
							this.player.v = 1;
							break;
						default:
							Debug.LogError ("unknown player: " + this.player.v);
							this.player.v = 0;
							break;
						}
					}
					this.isCustom.v = true;
				}
				break;
			case GameMove.Type.GomokuCustomSet:
			case GameMove.Type.Clear:
			case GameMove.Type.GomokuCustomMove:
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

		public override GameMove getAIMove (Computer.AI ai, bool isFindHint)
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
					GomokuAI gomokuAI = (ai!=null && ai is GomokuAI) ? (GomokuAI)ai : new GomokuAI();
					int move = Core.unityLetComputerThink (this, true, gomokuAI.searchDepth.v, 
						gomokuAI.timeLimit.v, gomokuAI.level.v);
					// Add Move
					GomokuMove gomokuMove =new GomokuMove();
					{
						gomokuMove.move.v = move;
						gomokuMove.boardSize.v = this.boardSize.v;
					}
					ret = gomokuMove;
				} else {
					// Debug.LogError ("not use rule: " + this);
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
					for (int square = 0; square < this.boardSize.v*this.boardSize.v; square++) {
						Common.Type alreadySelectPiece = this.getPieceType (square);
						foreach (Common.Type piece in System.Enum.GetValues(typeof(Common.Type))) {
							if (piece != alreadySelectPiece) {
								NoneRule.GomokuCustomSet gomokuCustomSet = new NoneRule.GomokuCustomSet ();
								{
									gomokuCustomSet.square.v = square;
									gomokuCustomSet.piece.v = piece;
								}
								moves.Add (gomokuCustomSet);
							}
						}
					}
				}
				// get custom move
				{
					for (int square = 0; square < this.boardSize.v * this.boardSize.v; square++) {
						Common.Type piece = this.getPieceType (square);
						if (piece != Common.Type.None) {
							for (int destSquare = 0; destSquare < this.boardSize.v * this.boardSize.v; destSquare++) {
								if (destSquare != square) {
									GomokuCustomMove gomokuCustomMove = new GomokuCustomMove ();
									{
										gomokuCustomMove.from.v = square;
										gomokuCustomMove.dest.v = destSquare;
									}
									moves.Add (gomokuCustomMove);
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
			// use rule or not
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
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 1));// black: 0 index
						result.scores.Add (new GameType.Score (1, 0));// white: 1 index
					}
					break;
				case 2:
					// white win
					{
						result.isGameFinish = true;
						// score
						result.scores.Add (new GameType.Score (0, 0));// black: 0 index
						result.scores.Add (new GameType.Score (1, 1));// white: 1 index
					}
					break;
				case 3:
					// draw
					{
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
			return result;
		}

		#endregion

	}
}