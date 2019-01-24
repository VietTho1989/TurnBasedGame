using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using HEX.NoneRule;

namespace HEX
{
	/**
	 * row la truc y, col la truc x
	 * */
	public class Hex : GameType
	{

		public const System.UInt16 MIN_BOARD_SIZE = 4;
		public const System.UInt16 MAX_BOARD_SIZE = 50;

		public const int MAX_LIMIT_TIME = 120;

		public VP<System.UInt16> boardSize;

		#region board

		public LP<sbyte> board;

		public sbyte getPiece(ushort square)
		{
			if (square >= 0 && square < board.vs.Count) {
				return this.board.vs [square];
			} else {
				Debug.LogError ("square error: " + square);
				return (sbyte)Common.Color.Empty;
			}
		}

		public void setPiece(ushort square, sbyte piece)
		{
			if (square >= 0 && square < board.vs.Count) {
				this.board.set ((int)square, piece);
			} else {
				Debug.LogError ("square error: " + square);
			}
		}

		#endregion

		public VP<bool> isSwitch;

		public VP<bool> isCustom;

		public VP<int> playerIndex;

		#region Constructor

		public enum Property
		{
			boardSize,
			board,
			isSwitch,
			isCustom,
			playerIndex
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Hex()
		{
			AllowNames.Add ((byte)Property.boardSize);
			AllowNames.Add ((byte)Property.board);
			AllowNames.Add ((byte)Property.isCustom);
			AllowNames.Add ((byte)Property.playerIndex);
		}

		public Hex() : base()
		{
			this.boardSize = new VP<ushort> (this, (byte)Property.boardSize, 11);
			this.board = new LP<sbyte> (this, (byte)Property.board);
			this.isSwitch = new VP<bool> (this, (byte)Property.isSwitch, false);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// board
				if (ret) {
					if (this.board.vs.Count == 0) {
						Debug.LogError ("board count = 0");
						ret = false;
					}
				}
			}
			return ret;
		}

		#endregion

		public int rounds()
		{
			int ret = 0;
			{
				for (int i = 0; i < this.board.vs.Count; i++) {
					if (this.board.vs [i] != (sbyte)Common.Color.Empty) {
						ret++;
					}
				}
			}
			return ret;
		}

		public Common.Color getCurrentColor()
		{
			return (this.rounds () % 2 == 0) ? Common.Color.Red : Common.Color.Blue;
		}

		#region implement base

		public override Type getType ()
		{
			return Type.Hex;
		}

		public override int getTeamCount ()
		{
			return 2;
		}

		public override int getPerspectiveCount ()
		{
			return 1;
		}

		public override int getPlayerIndex ()
		{
			if (!this.isCustom.v) {
				if (!this.isSwitch.v) {
					return (this.rounds () % 2 == 0) ? 0 : 1;
				} else {
					return (this.rounds () % 2 == 0) ? 1 : 0;
				}
			} else {
				return this.playerIndex.v == 0 ? 0 : 1;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.HexMove:
						{
							HexMove hexMove = gameMove as HexMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, hexMove.move.v);
						}
						// break;
					case GameMove.Type.HexSwitch:
						{
							if (this.rounds () == 1) {
								return true;
							} else {
								Debug.LogError ("why switch not in turn 1");
							}
						}
						break;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.HexCustomSet:
						return true;
					case GameMove.Type.EndTurn:
						return true;
					case GameMove.Type.Clear:
						return true;
					case GameMove.Type.HexCustomMove:
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
				// make tempHex
				Hex tempHex = DataUtils.cloneData (this) as Hex;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.HexCustomSet:
						{
							NoneRule.HexCustomSet hexCustomSet = gameMove as NoneRule.HexCustomSet;
							// set piece
							{
								tempHex.setPiece (hexCustomSet.square.v, (sbyte)hexCustomSet.piece.v);
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempHex.board.vs.Count; i++) {
								tempHex.board.vs [i] = (sbyte)Common.Color.Empty;
							}
						}
						break;
					case GameMove.Type.HexCustomMove:
						{
							NoneRule.HexCustomMove hexCustomMove = gameMove as NoneRule.HexCustomMove;
							// update
							{
								tempHex.setPiece (hexCustomMove.dest.v, tempHex.getPiece (hexCustomMove.from.v));
								tempHex.setPiece (hexCustomMove.from.v, (sbyte)Common.Color.Empty);
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
					// playerIndex
					{
						if (tempHex.getPlayerIndex () == 0) {
							tempHex.playerIndex.v = 0;
						} else {
							tempHex.playerIndex.v = 1;
						}
					}
					tempHex.isCustom.v = true;
					DataUtils.copyData (this, tempHex, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove (GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.HexMove:
				{
					// get information
					HexMove hexMove = gameMove as HexMove;
					Debug.LogError ("process gameMove: hexMove: " + hexMove.print ());
					// make request to native
					Hex newHex = Core.unityDoMove (this, Core.CanCorrect, hexMove.move.v);
					// Copy to current chess
					DataUtils.copyData (this, newHex, AllowNames);
				}
				break;
			case GameMove.Type.HexSwitch:
				{
					this.isSwitch.v = !this.isSwitch.v;
				}
				break;
			case GameMove.Type.None:
				break;
			case GameMove.Type.EndTurn:
				{
					if (this.getPlayerIndex () == 0) {
						this.playerIndex.v = 1;
					} else {
						this.playerIndex.v = 0;
					}
					this.isCustom.v = true;
				}
				break;
			case GameMove.Type.HexCustomSet:
			case GameMove.Type.Clear:
			case GameMove.Type.HexCustomMove:
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
					// get ai
					HexAI hexAI = (ai != null && ai is HexAI) ? (HexAI)ai : new HexAI ();
					// search
					System.UInt16 move = Core.unityLetComputerThink (this, Core.CanCorrect, hexAI.limitTime.v, hexAI.firstMoveCenter.v);
					// make move
					{
						HexMove hexMove = new HexMove ();
						{
							hexMove.move.v = move;
						}
						ret = hexMove;
					}
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
					for (ushort square = 0; square < this.boardSize.v*this.boardSize.v; square++) {
						Common.Color alreadySelectPiece = (Common.Color)this.getPiece (square);
						foreach (Common.Color piece in System.Enum.GetValues(typeof(Common.Color))) {
							if (piece != alreadySelectPiece) {
								NoneRule.HexCustomSet hexCustomSet = new NoneRule.HexCustomSet ();
								{
									hexCustomSet.square.v = square;
									hexCustomSet.piece.v = piece;
								}
								moves.Add (hexCustomSet);
							}
						}
					}
				}
				// get custom move
				{
					for (ushort square = 0; square < this.boardSize.v * this.boardSize.v; square++) {
						Common.Color piece = (Common.Color)this.getPiece (square);
						if (piece != Common.Color.Empty) {
							for (ushort destSquare = 0; destSquare < this.boardSize.v * this.boardSize.v; destSquare++) {
								if (destSquare != square) {
									HexCustomMove hexCustomMove = new HexCustomMove ();
									{
										hexCustomMove.from.v = square;
										hexCustomMove.dest.v = destSquare;
									}
									moves.Add (hexCustomMove);
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
				System.Random random = new System.Random ((int)global::Global.getRealTimeInMiliSeconds ());
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
				// switch?
				{
					if (this.isSwitch.v) {
						if (isGameFinish == 1) {
							isGameFinish = 2;
						} else if (isGameFinish == 2) {
							isGameFinish = 1;
						}
					}
				}
				// make result
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
						result.scores.Add (new GameType.Score (0, 0.5f));// white
						result.scores.Add (new GameType.Score (1, 0.5f));// black
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

		#region Convert

		public static byte[] convertToBytes(Hex hex, bool needCheckCustom = true)
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
						// public VP<System.UInt16> boardSize;
						writer.Write(hex.boardSize.v);
						// public LP<sbyte> board;
						{
							System.UInt16 boardSize2 = (System.UInt16)(hex.boardSize.v * hex.boardSize.v);
							for (int i = 0; i < boardSize2; i++) {
								sbyte value = (sbyte)Common.Color.Empty;
								{
									if (i>=0 && i < hex.board.vs.Count) {
										value = hex.board.vs [i];
									} else {
										Debug.LogError ("index error: "+i+"; "+hex.board.vs.Count);
									}
								}
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

		public static int parse(Hex hex, byte[] byteArray, int start)
		{
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						// public VP<System.UInt16> boardSize;
						int size = sizeof(System.UInt16);
						if (count + size <= byteArray.Length) {
							hex.boardSize.v = BitConverter.ToUInt16 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: boardSize: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						// public LP<sbyte> board;
						hex.board.clear();
						int size = sizeof(sbyte);
						for (int i = 0; i < hex.boardSize.v * hex.boardSize.v; i++) {
							if (count + size <= byteArray.Length) {
								hex.board.add ((sbyte)byteArray [count]);
								count += size;
							} else {
								Debug.LogError ("array not enough length: board: " + count + "; " + byteArray.Length);
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
				Debug.LogError ("parse fail: " + count + "; " + byteArray.Length + "; " + start);
				return -1;
			} else {
				// Debug.LogError ("parse success: " + count + "; " + byteArray.Length + "; " + start);
				return (count - start);
			}
		}

		#endregion

	}
}