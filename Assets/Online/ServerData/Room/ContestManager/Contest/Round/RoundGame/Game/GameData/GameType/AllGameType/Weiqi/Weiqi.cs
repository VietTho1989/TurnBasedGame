using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Weiqi.NoneRule;

namespace Weiqi
{
	/** Viec tinh diem luon ngay khi do move se lam cham chuong trinh, nen de cho vao luong phu, tinh sau*/
	public class Weiqi : GameType
	{

		public const int MinBoardSize = 5;
		public const int MaxBoardSize = 19;
		
		public override Type getType ()
		{
			return Type.Weiqi;
		}

		#region Property

		#region board

		public VP<Board> b;

		public Common.stone getPieceByCoord(int coord)
		{
			int x = Common.coord_x (this.b.v.size.v, coord);
			int y = Common.coord_y (this.b.v.size.v, coord);
			int index = x + 21 * y;
			if (index >= 0 && index < this.b.v.b.vs.Count) {
				return (Common.stone)this.b.v.b.vs [index];
			} else {
				Debug.LogError ("index error: " + index);
				return Common.stone.S_OFFBOARD;
			}
		}

		public void setPieceByCoord(int coord, Common.stone stone)
		{
			int x = Common.coord_x (this.b.v.size.v, coord);
			int y = Common.coord_y (this.b.v.size.v, coord);
			int index = x + 21 * y;
			if (index >= 0 && index < this.b.v.b.vs.Count) {
				this.b.v.b.set (index, (int)stone);
			} else {
				Debug.LogError ("index error: " + index);
			}
		}

		#endregion

		public VP<MoveQueue> deadgroup;

		/** int scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];*/
		public LP<int> scoreOwnerMap;
		/** int scoreOwnerMapSize = 0;*/
		public VP<int> scoreOwnerMapSize;

		/** int scoreBlack = 0;*/
		public VP<int> scoreBlack;
		/** int scoreWhite = 0;*/
		public VP<int> scoreWhite;
		/** int dame = 0;*/
		public VP<int> dame;
		/** float score = 0;*/
		public VP<float> score;

		#endregion

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			b,
			deadgroup,
			scoreOwnerMap,
			scoreOwnerMapSize,
			scoreBlack,
			scoreWhite,
			dame,
			score,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();
		public static List<byte> UpdateScoreNames = new List<byte> ();

		static Weiqi()
		{
			// AllowNames
			{
				AllowNames.Add ((byte)Property.b);
				AllowNames.Add ((byte)Property.isCustom);
			}
			// UpdateScoreNames
			{
				UpdateScoreNames.Add ((byte)Weiqi.Property.deadgroup);
				UpdateScoreNames.Add ((byte)Weiqi.Property.scoreOwnerMap);
				UpdateScoreNames.Add ((byte)Weiqi.Property.scoreOwnerMapSize);
				UpdateScoreNames.Add ((byte)Weiqi.Property.scoreBlack);
				UpdateScoreNames.Add ((byte)Weiqi.Property.scoreWhite);
				UpdateScoreNames.Add ((byte)Weiqi.Property.dame);
				UpdateScoreNames.Add ((byte)Weiqi.Property.score);
			}
		}

		public Weiqi() : base()
		{
			this.b = new VP<Board> (this, (byte)Property.b, new Board ());
			{
				this.deadgroup = new VP<MoveQueue> (this, (byte)Property.deadgroup, new MoveQueue ());
				this.deadgroup.nh = 0;
			}
			{
				this.scoreOwnerMap = new LP<int> (this, (byte)Property.scoreOwnerMap);
				this.scoreOwnerMap.nh = 0;
			}
			{
				this.scoreOwnerMapSize = new VP<int> (this, (byte)Property.scoreOwnerMapSize, 0);
				this.scoreOwnerMapSize.nh = 0;
			}
			{
				this.scoreBlack = new VP<int> (this, (byte)Property.scoreBlack, 0);
				this.scoreBlack.nh = 0;
			}
			{
				this.scoreWhite = new VP<int> (this, (byte)Property.scoreWhite, 0);
				this.scoreWhite.nh = 0;
			}
			{
				this.dame = new VP<int> (this, (byte)Property.dame, 0);
				this.dame.nh = 0;
			}
			{
				this.score = new VP<float> (this, (byte)Property.score, 0);
				this.score.nh = 0;
			}
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// board
				if (ret) {
					Board b = this.b.v;
					if (b != null) {
						if (!b.isLoadFull ()) {
							Debug.LogError ("b not load full");
							ret = false;
						}
					} else {
						Debug.LogError ("b null");
						ret = false;
					}
				}
			}
			return ret;
		}

		#endregion

		public int getOwner(int coord)
		{
			if (coord >= 0 && coord < this.scoreOwnerMap.vs.Count) {
				return this.scoreOwnerMap.vs [coord];
			} else {
				Debug.LogError ("error, getOwner: coord error: " + coord);
				return 0;
			}
		}

		public int getLastMoveIndex(int coord)
		{
			if (this.b.v.last_move.v.coord.v == coord) {
				return 1;
			}
			if (this.b.v.last_move2.v.coord.v == coord) {
				return 2;
			}
			if (this.b.v.last_move3.v.coord.v == coord) {
				return 3;
			}
			if (this.b.v.last_move4.v.coord.v == coord) {
				return 4;
			}
			return 0;
		}

		#region Convert

		public static byte[] convertToBytes(Weiqi weiqi, bool needCheckCustom = true)
		{
			// custom
			if (weiqi.isCustom.v && needCheckCustom) {
				int size = weiqi.b.v.size.v;
				float komi = weiqi.b.v.komi.v;
				int rule = weiqi.b.v.rules.v;
				// board
				int[] board = new int[Common.BOARD_MAX_COORDS];
				{
					for (int i = 0; i < board.Length; i++) {
						if (i >= 0 && i < weiqi.b.v.b.vs.Count) {
							board [i] = weiqi.b.v.b.vs [i];
						} else {
							board [i] = (int)Common.stone.S_OFFBOARD;
						}
					}
				}
				int captureBlack = weiqi.b.v.getCaptures ((int)Common.stone.S_BLACK);
				int captureWhite = weiqi.b.v.getCaptures ((int)Common.stone.S_WHITE);
				int lastMoveColor = weiqi.getPlayerIndex () == 0 ? (int)Common.stone.S_BLACK : (int)Common.stone.S_WHITE;
				Weiqi newWeiqi = Core.unityMakeCustomPosition (size, komi, rule, board, captureBlack, captureWhite, lastMoveColor);
				return convertToBytes (newWeiqi);
			}
			// normal
			byte[] byteArray;
			using(MemoryStream memStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					// write value
					{
						// b
						writer.Write(Board.convertToBytes(weiqi.b.v));
						// deadgroup
						writer.Write(MoveQueue.convertToBytes(weiqi.deadgroup.v));
						/** int scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];*/
						{
							// scoreOwnerMap,
							for (int i = 0; i < (Common.BOARD_MAX_SIZE+2)*(Common.BOARD_MAX_SIZE+2); i++) {
								// get value
								int value = 0;
								{
									if (i < weiqi.scoreOwnerMap.vs.Count) {
										value = weiqi.scoreOwnerMap.vs [i];
									} else {
										Debug.LogError ("error, index:  scoreOwnerMap: " + weiqi);
									}
								}
								// write
								writer.Write (value);
							}
						}
						/** int scoreOwnerMapSize = 0;*/
						writer.Write (weiqi.scoreOwnerMapSize.v);
						/** int scoreBlack = 0;*/
						writer.Write (weiqi.scoreBlack.v);
						/** int scoreWhite = 0;*/
						writer.Write (weiqi.scoreWhite.v);
						/** int dame = 0;*/
						writer.Write (weiqi.dame.v);
						/** float score = 0;*/
						writer.Write (weiqi.score.v);
					}
					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			return byteArray;
		}

		public static int parse(Weiqi weiqi, byte[] byteArray, int start)
		{
			// TODO co the LittleEdian va BigEndian khac nhau se co loi
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					// b
					{
						// Debug.LogError ("weiqi parse: b: " + count);
						Board board = new Board();
						// parse
						{
							int byteLength = Board.parse (board, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							board.uid = weiqi.b.makeId ();
							weiqi.b.v = board;
						} else {
							Debug.LogError ("parse board error");
						}
					}
					break;
				case 1:
					// deadgroup
					{
						// Debug.LogError ("weiqi parse: moveQueue: " + count);
						MoveQueue moveQueue = new MoveQueue();
						// parse
						{
							int byteLength = MoveQueue.parse (moveQueue, byteArray, count);
							if (byteLength > 0) {
								// increase pointer index
								count += byteLength;
							} else {
								Debug.LogError ("cannot parse");
								isParseCorrect = false;
								break;
							}
						}
						// add to data
						if (isParseCorrect) {
							moveQueue.uid = weiqi.deadgroup.makeId ();
							weiqi.deadgroup.v = moveQueue;
						} else {
							Debug.LogError ("parse moveQueue error");
						}
					}
					break;
				case 2:
					/** int scoreOwnerMap[(BOARD_MAX_SIZE+2)*(BOARD_MAX_SIZE+2)];*/
					{
						// Debug.LogError ("weiqi parse: scoreOwnerMap: " + count);
						weiqi.scoreOwnerMap.clear ();
						int size = sizeof(int);
						for (int i = 0; i < (Common.BOARD_MAX_SIZE+2)*(Common.BOARD_MAX_SIZE+2); i++) {
							if (count + size <= byteArray.Length) {
								weiqi.scoreOwnerMap.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: scoreOwnerMap: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 3:
					/** int scoreOwnerMapSize = 0;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							weiqi.scoreOwnerMapSize.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: scoreOwnerMapSize: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					/** int scoreBlack = 0;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							weiqi.scoreBlack.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: scoreBlack: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 5:
					/** int scoreWhite = 0;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							weiqi.scoreWhite.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: scoreWhite: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 6:
					/** int dame = 0;*/
					{
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							weiqi.dame.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: dame: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 7:
					/** float score = 0;*/
					{
						int size = sizeof(float);
						if (count + size <= byteArray.Length) {
							weiqi.score.v = BitConverter.ToSingle (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("error, array not enough length: score: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
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
				Debug.LogError ("parse weiqi fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.Log ("parse weiqi success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

		#region implement callBacks

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
			// Black play first
			int color = (int)Common.stone.S_BLACK;
			{
				switch (this.b.v.last_move.v.color.v) {
				case (int)Common.stone.S_NONE:
					color = (int)Common.stone.S_BLACK;
					break;
				case (int)Common.stone.S_BLACK:
					color = (int)Common.stone.S_WHITE;
					break;
				case (int)Common.stone.S_WHITE:
					color = (int)Common.stone.S_BLACK;
					break;
				default:
					Debug.LogError ("error, unknown last move color: %" + this.b.v.last_move.v.color.v);
					color = (int)Common.stone.S_BLACK;
					break;
				}
			}
			// return
			switch (color) {
			case (int)Common.stone.S_NONE:
				return 0;
			case (int)Common.stone.S_BLACK:
				return 0;
			case (int)Common.stone.S_WHITE:
				return 1;
			default:
				Debug.LogError ("error, unknown stone color: " + color);
				return 0;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.WeiqiMove:
						{
							WeiqiMove move = gameMove as WeiqiMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, move);
						}
						// break;
					default:
						// Debug.LogError ("unknown game move type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.WeiqiMove:
						return true;
					case GameMove.Type.WeiqiCustomSet:
						return true;
					case GameMove.Type.EndTurn:
						return true;
					case GameMove.Type.Clear:
						return true;
					case GameMove.Type.WeiqiCustomMove:
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
				// make tempWeiqi
				Weiqi tempWeiqi = DataUtils.cloneData (this) as Weiqi;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.WeiqiCustomSet:
						{
							WeiqiCustomSet weiqiCustomSet = gameMove as WeiqiCustomSet;
							// set piece
							{
								tempWeiqi.setPieceByCoord (weiqiCustomSet.coord.v, weiqiCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempWeiqi.b.v.b.vs.Count; i++) {
								int piece = tempWeiqi.b.v.b.vs [i];
								if (piece == (int)Common.stone.S_BLACK || piece == (int)Common.stone.S_WHITE) {
									tempWeiqi.b.v.b.vs [i] = (int)Common.stone.S_NONE;
								}
							}
						}
						break;
					case GameMove.Type.WeiqiCustomMove:
						{
							WeiqiCustomMove weiqiCustomMove = gameMove as WeiqiCustomMove;
							// update
							{
								tempWeiqi.setPieceByCoord (weiqiCustomMove.dest.v, tempWeiqi.getPieceByCoord (weiqiCustomMove.from.v));
								tempWeiqi.setPieceByCoord (weiqiCustomMove.from.v, (int)Common.stone.S_NONE);
							}
						}
						break;
					case GameMove.Type.EndTurn:
						{
							// TODO Can hoan thien
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
					tempWeiqi.isCustom.v = true;
					DataUtils.copyData (this, tempWeiqi, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove (GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.WeiqiMove:
				{
					// get information
					WeiqiMove move = gameMove as WeiqiMove;
					Weiqi newWeiqi = Core.unityDoMove (this, Core.CanCorrect, move, false);
					if (newWeiqi != null) {
						DataUtils.copyData (this, newWeiqi, AllowNames);
					} else {
						Debug.LogError ("newWeiqi null: " + this);
					}
				}
				break;
			case GameMove.Type.None:
				break;
			case GameMove.Type.EndTurn:
			case GameMove.Type.WeiqiCustomSet:
			case GameMove.Type.Clear:
			case GameMove.Type.WeiqiCustomMove:
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
					WeiqiAI ai = (computerAI != null && computerAI is WeiqiAI) ? (WeiqiAI)computerAI : new WeiqiAI ();
					WeiqiMove move = Core.unityLetComputerThink (this, true, ai.canResign.v, ai.useBook.v, 
						ai.time.v, ai.games.v, ai.engine.v);
					{

					}
					// Debug.Log ("find ai move: " + Common.printMove (move));
					// return
					ret = move;
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
			List<Common.stone> CanChooseStones = new List<Common.stone> {
				Common.stone.S_NONE,
				Common.stone.S_BLACK,
				Common.stone.S_WHITE
			};
			// find moves
			List<GameMove> moves = new List<GameMove> ();
			{
				// get custom set
				{
					for (int coord = 0; coord < Common.BOARD_MAX_COORDS; coord++) {
						Common.stone alreadySelectPiece = this.getPieceByCoord (coord);
						if (CanChooseStones.Contains (alreadySelectPiece)) {
							foreach (Common.stone piece in CanChooseStones) {
								if (piece != alreadySelectPiece) {
									WeiqiCustomSet weiqiCustomSet = new WeiqiCustomSet ();
									{
										weiqiCustomSet.coord.v = coord;
										weiqiCustomSet.piece.v = piece;
									}
									moves.Add (weiqiCustomSet);
								}
							}
						}
					}
				}
				// get custom move
				{
					for (int coord = 0; coord < Common.BOARD_MAX_COORDS; coord++) {
						Common.stone piece = this.getPieceByCoord (coord);
						if (CanChooseStones.Contains(piece)) {
							if (piece != Common.stone.S_NONE) {
								for (int destCoord = 0; destCoord < Common.BOARD_MAX_COORDS; destCoord++) {
									if (destCoord != coord) {
										Common.stone destPiece = this.getPieceByCoord (destCoord);
										if (CanChooseStones.Contains (destPiece)) {
											WeiqiCustomMove weiqiCustomMove = new WeiqiCustomMove ();
											{
												weiqiCustomMove.from.v = coord;
												weiqiCustomMove.dest.v = destCoord;
											}
											moves.Add (weiqiCustomMove);
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
							if (turn.turn.v >= 3000) {
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