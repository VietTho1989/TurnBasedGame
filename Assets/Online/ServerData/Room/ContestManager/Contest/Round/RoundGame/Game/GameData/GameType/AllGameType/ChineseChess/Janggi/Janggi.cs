using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Janggi.NoneRule;

namespace Janggi
{
	public class Janggi : GameType
	{

		public LP<uint> stones;

		public LP<uint> targets;

		public LP<uint> blocks;

		public LP<Common.Pos> positions;

		public VP<bool> isMyTurn;

		public VP<int> Point;

		public VP<bool> isMyFirst;

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			stones,
			targets,
			blocks,
			positions,
			isMyTurn,
			Point,
			isMyFirst,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Janggi()
		{
			AllowNames.Add ((byte)Property.stones);
			AllowNames.Add ((byte)Property.targets);
			AllowNames.Add ((byte)Property.blocks);
			AllowNames.Add ((byte)Property.positions);
			AllowNames.Add ((byte)Property.isMyTurn);
			AllowNames.Add ((byte)Property.Point);
			AllowNames.Add ((byte)Property.isMyFirst);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Janggi() : base()
		{
			this.stones = new LP<uint> (this, (byte)Property.stones);
			this.targets = new LP<uint> (this, (byte)Property.targets);
			this.blocks = new LP<uint> (this, (byte)Property.blocks);
			this.positions = new LP<Common.Pos> (this, (byte)Property.positions);
			this.isMyTurn = new VP<bool> (this, (byte)Property.isMyTurn, true);
			this.Point = new VP<int> (this, (byte)Property.Point, 0);
			this.isMyFirst = new VP<bool> (this, (byte)Property.isMyFirst, true);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		#endregion

		#region Convert

		public static Board convertToBoard(Janggi janggi)
		{
			if (!janggi.isCustom.v) {
				Board board = new Board ();
				{
					// stones
					{
						for (int y = 0; y < Board.Height; y++) {
							for (int x = 0; x < Board.Width; x++) {
								uint value = 0;
								{
									int index = y * Board.Width + x;
									if (index >= 0 && index < janggi.stones.vs.Count) {
										value = janggi.stones.vs [index];
									} else {
										Debug.LogError ("index error: " + index + ", " + janggi.stones.vs.Count);
									}
								}
								board.stones [y, x] = value;
							}
						}
					}
					// targets
					{
						for (int y = 0; y < Board.Height; y++) {
							for (int x = 0; x < Board.Width; x++) {
								uint value = 0;
								{
									int index = y * Board.Width + x;
									if (index >= 0 && index < janggi.targets.vs.Count) {
										value = janggi.targets.vs [index];
									} else {
										Debug.LogError ("index error: " + index + ", " + janggi.targets.vs.Count);
									}
								}
								board.targets [y, x] = value;
							}
						}
					}
					// blocks
					{
						for (int y = 0; y < Board.Height; y++) {
							for (int x = 0; x < Board.Width; x++) {
								uint value = 0;
								{
									int index = y * Board.Width + x;
									if (index >= 0 && index < janggi.blocks.vs.Count) {
										value = janggi.blocks.vs [index];
									} else {
										Debug.LogError ("index error: " + index + ", " + janggi.blocks.vs.Count);
									}
								}
								board.blocks [y, x] = value;
							}
						}
					}
					// positions
					{
						for (int i = 0; i < Board.StoneCount; i++) {
							Common.Pos pos = new Common.Pos ();
							{
								if (i >= 0 && i < janggi.positions.vs.Count) {
									Common.Pos janggiPos = janggi.positions.vs [i];
									pos.X = janggiPos.X;
									pos.Y = janggiPos.Y;
								}
							}
							board.positions [i] = pos;
						}
					}
					// isMyTurn
					board.IsMyTurn = janggi.isMyTurn.v;
					// Point
					board.Point = janggi.Point.v;
					// isMyFirst
					board.IsMyFirst = janggi.isMyFirst.v;
				}
				return board;
			} else {
				// custom board
				Board board = new Board ();
				{
					// stones
					uint[,] stones = new uint[Board.Height, Board.Width];
					{
						for (int y = 0; y < Board.Height; y++) {
							for (int x = 0; x < Board.Width; x++) {
								uint value = 0;
								{
									int index = y * Board.Width + x;
									if (index >= 0 && index < janggi.stones.vs.Count) {
										value = janggi.stones.vs [index];
									} else {
										Debug.LogError ("index error: " + index + ", " + janggi.stones.vs.Count);
									}
								}
								stones [y, x] = value;
							}
						}
					}
					// set
					board.Set (stones, janggi.isMyFirst.v, janggi.isMyTurn.v);
				}
				return board;
			}
		}

		public static void parseFromBoard(Janggi janggi, Board board)
		{
			// stones
			{
				janggi.stones.clear ();
				for (int y = 0; y < Board.Height; y++) {
					for (int x = 0; x < Board.Width; x++) {
						janggi.stones.add (board.stones [y, x]);
					}
				}
			}
			// targets
			{
				janggi.targets.clear ();
				for (int y = 0; y < Board.Height; y++) {
					for (int x = 0; x < Board.Width; x++) {
						janggi.targets.add (board.targets [y, x]);
					}
				}
			}
			// blocks
			{
				janggi.blocks.clear ();
				for (int y = 0; y < Board.Height; y++) {
					for (int x = 0; x < Board.Width; x++) {
						janggi.blocks.add (board.blocks [y, x]);
					}
				}
			}
			// positions
			{
				janggi.positions.clear ();
				for (int i = 0; i < Board.StoneCount; i++) {
					Common.Pos pos = new Common.Pos ();
					{
						pos.X = board.positions [i].X;
						pos.Y = board.positions [i].Y;
					}
					janggi.positions.add (pos);
				}
			}
			// isMyTurn
			janggi.isMyTurn.v = board.IsMyTurn;
			// Point
			janggi.Point.v = board.Point;
			// isMyFirst
			janggi.isMyFirst.v = board.IsMyFirst;
		}

		#endregion

		#region implement base

		public override Type getType ()
		{
			return Type.Janggi;
		}

		public override int getTeamCount()
		{
			return 2;
		}

		public override int getPerspectiveCount()
		{
			return 2;
		}

		public override int getPlayerIndex ()
		{
			return this.isMyTurn.v ? 0 : 1;
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.JanggiMove:
						{
							JanggiMove janggiMove = gameMove as JanggiMove;
							return Core.isLegalMove (this, janggiMove);
						}
					default:
						Debug.LogError ("unknown game move type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.JanggiCustomSet:
					case GameMove.Type.JanggiCustomMove:
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

		public override void processGameMove(GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.JanggiMove:
				{
					JanggiMove janggiMove = gameMove as JanggiMove;
					Janggi newJanggi = Core.doMove (this, janggiMove);
					// update
					DataUtils.copyData (this, newJanggi, AllowNames);
				}
				break;
			case GameMove.Type.EndTurn:
			case GameMove.Type.JanggiCustomSet:
			case GameMove.Type.Clear:
			case GameMove.Type.JanggiCustomMove:
				{
					this.processCustomGameMove (gameMove);
				}
				break;
			default:
				Debug.LogError ("typicalProcessGameMove: unknown gameMove: " + gameMove + "; " + this);
				this.processCustomGameMove (gameMove);
				break;
			}
		}

		private void processCustomGameMove(GameMove gameMove)
		{
			if (gameMove != null) {
				// make tempJanggi
				Janggi tempJanggi = DataUtils.cloneData (this) as Janggi;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.EndTurn:
						{
							tempJanggi.isMyTurn.v = !tempJanggi.isMyTurn.v;
						}
						break;
					case GameMove.Type.JanggiCustomSet:
						{
							JanggiCustomSet janggiCustomSet = gameMove as JanggiCustomSet;
							// set piece
							{
								Debug.LogError ("janggiCustomSet: " + janggiCustomSet.x.v + "; " + janggiCustomSet.y.v + "; " + janggiCustomSet.piece.v);
								if (janggiCustomSet.x.v >= 0 && janggiCustomSet.x.v < 9 && janggiCustomSet.y.v >= 0 && janggiCustomSet.y.v < 10) {
									int index = janggiCustomSet.y.v * Board.Width + janggiCustomSet.x.v;
									if (index >= 0 && index < tempJanggi.stones.vs.Count) {
										tempJanggi.stones.vs [index] = (uint)janggiCustomSet.piece.v;
									}
								} else {
									Debug.LogError ("outside board: " + janggiCustomSet.x.v + ", " + janggiCustomSet.y.v);
								}
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempJanggi.stones.vs.Count; i++) {
								tempJanggi.stones.vs [i] = (uint)StoneHelper.Stones.Empty;
							}
						}
						break;
					case GameMove.Type.JanggiCustomMove:
						{
							JanggiCustomMove janggiCustomMove = gameMove as JanggiCustomMove;
							// update
							{
								if (janggiCustomMove.fromX.v >= 0 && janggiCustomMove.fromX.v < 9
								    && janggiCustomMove.fromY.v >= 0 && janggiCustomMove.fromY.v < 10) {
									if (janggiCustomMove.destX.v >= 0 && janggiCustomMove.destX.v < 9
									    && janggiCustomMove.destY.v >= 0 && janggiCustomMove.destY.v < 10) {
										int fromIndex = janggiCustomMove.fromY.v * Board.Width + janggiCustomMove.fromX.v;
										int destIndex = janggiCustomMove.destY.v * Board.Width + janggiCustomMove.destX.v;
										if (fromIndex >= 0 && fromIndex < tempJanggi.stones.vs.Count) {
											if (destIndex >= 0 && destIndex < tempJanggi.stones.vs.Count) {
												tempJanggi.stones.vs [destIndex] = tempJanggi.stones.vs [fromIndex];
												tempJanggi.stones.vs [fromIndex] = (uint)StoneHelper.Stones.Empty;
											} else {
												Debug.LogError ("destIndex error: " + destIndex + ", " + tempJanggi.stones.vs.Count);
											}
										} else {
											Debug.LogError ("fromIndex error: " + fromIndex + ", " + tempJanggi.stones.vs.Count);
										}
									} else {
										Debug.LogError ("from outside board: " + janggiCustomMove.destX.v + ", " + janggiCustomMove.destY.v);
									}
								} else {
									Debug.LogError ("from outside board: " + janggiCustomMove.fromX.v + ", " + janggiCustomMove.fromY.v);
								}
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
						tempJanggi.isCustom.v = true;
						tempJanggi.targets.clear ();
						tempJanggi.positions.clear ();
						tempJanggi.Point.v = 0;
						tempJanggi.blocks.clear ();
						DataUtils.copyData (this, tempJanggi, AllowNames);

					}
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

        #endregion

        #region getAIMove

        public override int getStackSize()
        {
            return 0;
        }

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
				// find
				if (useNormalMove) {
					JanggiAI ai = (computerAI != null && computerAI is JanggiAI) ? (JanggiAI)computerAI : new JanggiAI ();
					ret = Core.letComputerThink (this, ai.maxVisitCount.v);
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
					for (int y = 0; y < 10; y++) {
						for (int x = 0; x < 9; x++) {
							int index = y * Board.Width + x;
							// get already select piece
							StoneHelper.Stones alreadySelectPiece = StoneHelper.Stones.Empty;
							{
								if (index >= 0 && index < this.stones.vs.Count) {
									alreadySelectPiece = (StoneHelper.Stones)this.stones.vs [index];
								} else {
									Debug.LogError ("index error: " + index + ", " + this.stones.vs.Count);
								}
								alreadySelectPiece = StoneHelper.ConvertToNormalStone (alreadySelectPiece);
							}
							// make move
							foreach (StoneHelper.Stones piece in StoneHelper.NormalStones) {
								if (piece != alreadySelectPiece) {
									JanggiCustomSet janggiCustomSet = new JanggiCustomSet ();
									{
										janggiCustomSet.x.v = x;
										janggiCustomSet.y.v = y;
										janggiCustomSet.piece.v = piece;
									}
									moves.Add (janggiCustomSet);
								}
							}
						}
					}
				}
				// get custom move
				{
					for (int y = 0; y < 10; y++) {
						for (int x = 0; x < 9; x++) {
							StoneHelper.Stones stone = StoneHelper.Stones.Empty;
							{
								int index = y * Board.Width + x;
								if (index >= 0 && index < this.stones.vs.Count) {
									stone = (StoneHelper.Stones)this.stones.vs [index];
								} else {
									Debug.LogError ("index error: " + index + ", " + this.stones.vs.Count);
								}
							}
							if (stone != StoneHelper.Stones.Empty) {
								for (int destY = 0; destY < 10; destY++) {
									for (int destX = 0; destX < 9; destX++) {
										if (destX != x || destY != y) {
											JanggiCustomMove janggiCustomMove = new JanggiCustomMove ();
											{
												janggiCustomMove.fromX.v = x;
												janggiCustomMove.fromY.v = y;
												janggiCustomMove.destX.v = destX;
												janggiCustomMove.destY.v = destY;
											}
											moves.Add (janggiCustomMove);
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

		public override Result isGameFinish()
		{
			Result result = Result.makeDefault ();
			// process
			bool isTooManyTurn = false;
			{
				GameData gameData = this.findDataInParent<GameData> ();
				if (gameData != null) {
					Turn turn = gameData.turn.v;
					if (turn != null) {
						if (turn.turn.v >= 5000) {
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
			} else {
				if (GameData.IsUseRule (this)) {
					int isGameFinish = Core.isGameFinish (this);
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
							result.scores.Add (new GameType.Score (0, 1));// silver
							result.scores.Add (new GameType.Score (1, 0));// red
						}
						break;
					case 2:
						// black win
						{
							result.isGameFinish = true;
							// score
							result.scores.Add (new GameType.Score (0, 0));// silver
							result.scores.Add (new GameType.Score (1, 1));// red
						}
						break;
					case 3:
						// draw
						{
							result.isGameFinish = true;
							// score
							result.scores.Add (new GameType.Score (0, 0.5f));// silver
							result.scores.Add (new GameType.Score (1, 0.5f));// red
						}
						break;
					default:
						Debug.LogError ("unknown result: " + this);
						break;
					}
				} else {
					// ko het co duoc
				}
			}
			// return
			return result;
		}

		#endregion

	}
}