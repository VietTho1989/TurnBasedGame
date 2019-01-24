using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Khet.NoneRule;

namespace Khet
{
	public class Khet : GameType
	{
		// 10*8
		public const string Standard = "x33a3ka3p22/2p37/3P46/p11P31s1s21p21P4/p21P41S2S11p11P3/6p23/7P12/2P4A1KA13X1 0";
		public const string Dynasty = "x33p3a3p23/5k4/p13p3a3s23/p21s11P41P23/3p41p21S11P4/3S2A1P13P3/4K5/3P4A1P13X1 0";
		public const string Imhotep = "x33a3ka3s22//3P42p13/p1P32P2s22p2P4/p2P42S2p42p1P3/3P32p23//2S2A1KA13X1 0";

		/** Player _playerToMove*/
		public VP<int> _playerToMove;

		/** bool _checkmate = false*/
		public VP<bool> _checkmate;

		/** bool _drawn = false*/
		public VP<bool> _drawn;

		/** int32_t _moveNumber = 0*/
		public VP<int> _moveNumber;

		/** uint64_t _hashes[MaxGameLength]*/
		// public LP<ulong> _hashes;

		/** Laser _laser*/
		public VP<Laser> _laser;

		// Mailbox style storage is used with one layer of padding.
		/** Square _board[BoardArea]*/
		public LP<byte> _board;

		// Move list.
		/** Move _moves[MaxGameLength] = { NoMove }*/
		// public LP<uint> _moves;

		// The current pharaoh positions.
		/** int32_t _pharaohPositions[2]*/
		public LP<int> _pharaohPositions;

		// Cache the capture square and location so that it can be restored.
		/** Square _captureSquare[MaxGameLength]*/
		// public LP<byte> _captureSquare;

		/** int32_t _captureLocation[MaxGameLength]*/
		// public LP<int> _captureLocation;

		// Cache the number of moves since the last capture.
		/** int32_t _movesWithoutCapture[MaxGameLength]*/
		// public LP<int> _movesWithoutCapture;

		public LP<KhetSub> khetSub;

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			_playerToMove,
		 	_checkmate,
			_drawn,
			_moveNumber,
			_laser,
			_board,
		 	_pharaohPositions,
			khetSub,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Khet()
		{
			AllowNames.Add ((byte)Property._playerToMove);
			AllowNames.Add ((byte)Property._checkmate);
			AllowNames.Add ((byte)Property._drawn);
			AllowNames.Add ((byte)Property._moveNumber);
			AllowNames.Add ((byte)Property._laser);
			AllowNames.Add ((byte)Property._board);
			AllowNames.Add ((byte)Property._pharaohPositions);
			AllowNames.Add ((byte)Property.khetSub);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Khet() : base()
		{
			this._playerToMove = new VP<int> (this, (byte)Property._playerToMove, (int)Common.Player.Silver);
			this._checkmate = new VP<bool> (this, (byte)Property._checkmate, false);
			this._drawn = new VP<bool> (this, (byte)Property._drawn, false);
			this._moveNumber = new VP<int> (this, (byte)Property._moveNumber, 0);
			this._laser = new VP<Laser> (this, (byte)Property._laser, new Laser ());
			this._board = new LP<byte> (this, (byte)Property._board);
			this._pharaohPositions = new LP<int> (this, (byte)Property._pharaohPositions);
			this.khetSub = new LP<KhetSub> (this, (byte)Property.khetSub);
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		public bool isLoadFull()
		{
			bool ret = true;
			{
				// board
				if (ret) {
					if (this._board.vs.Count == 0) {
						Debug.LogError ("board count 0");
						ret = false;
					}
				}
				// sub
				if (ret) {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is KhetIdentity) {
							KhetIdentity khetIdentity = dataIdentity as KhetIdentity;
							if (khetIdentity.khetSubCount != this.khetSub.vs.Count) {
								Debug.LogError ("khetSub count error");
								ret = false;
							}
						} else {
							Debug.LogError ("why not chessIdentity");
						}
					}
				}
			}
			return ret;
		}

		#endregion

		#region implement base

		public override Type getType ()
		{
			return Type.Khet;
		}

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
			switch (this._playerToMove.v) {
			case (int)Common.Player.Silver:
				return 0;
			case (int)Common.Player.Red:
				return 1;
			default:
				Debug.LogError ("unknown side to move: " + this._playerToMove.v);
				return 0;
			}
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.KhetMove:
						{
							KhetMove khetMove = gameMove as KhetMove;
							return Core.unityIsLegalMove (this, Core.CanCorrect, khetMove.move.v);
						}
						// break;
					default:
						Debug.LogError ("unknown game type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					switch (gameMove.getType ()) {
					case GameMove.Type.KhetMove:
						return true;
					case GameMove.Type.KhetCusomMove:
						return true;
					case GameMove.Type.KhetCusomSet:
						return true;
					case GameMove.Type.KhetCustomRotate:
						return true;
					case GameMove.Type.Clear:
						return true;
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
				// make tempKhet
				Khet tempKhet = DataUtils.cloneData (this) as Khet;
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.KhetCusomSet:
						{
							KhetCustomSet khetCustomSet = gameMove as KhetCustomSet;
							// set piece
							{
								if (khetCustomSet.position.v >= 0 && khetCustomSet.position.v < tempKhet._board.vs.Count) {
									if (tempKhet._board.vs [khetCustomSet.position.v] != Common.OffBoard) {
										if (khetCustomSet.piece.v == Common.Piece.None) {
											tempKhet._board.vs [khetCustomSet.position.v] = Common.Empty;
										} else {
											tempKhet._board.vs [khetCustomSet.position.v] = Common.MakeSquare (khetCustomSet.player.v, khetCustomSet.piece.v, Common.Orientation.Up);
										}
									} else {
										Debug.LogError ("why offboard");
									}
								} else {
									Debug.LogError ("position error: " + khetCustomSet.position.v + ", " + tempKhet._board.vs.Count);
								}
							}
						}
						break;
					case GameMove.Type.Clear:
						{
							for (int i = 0; i < tempKhet._board.vs.Count; i++) {
								if (tempKhet._board.vs [i] != Common.OffBoard && tempKhet._board.vs [i] != Common.Empty) {
									tempKhet._board.vs [i] = Common.Empty;
								}
							}
						}
						break;
					case GameMove.Type.KhetCusomMove:
						{
							KhetCustomMove khetCustomMove = gameMove as KhetCustomMove;
							// update
							{
								if (khetCustomMove.from.v >= 0 && khetCustomMove.from.v < tempKhet._board.vs.Count) {
									if (khetCustomMove.dest.v >= 0 && khetCustomMove.dest.v < tempKhet._board.vs.Count) {
										if (tempKhet._board.vs [khetCustomMove.from.v] != Common.OffBoard && tempKhet._board.vs [khetCustomMove.dest.v] != Common.OffBoard) {
											tempKhet._board.vs [khetCustomMove.dest.v] = tempKhet._board.vs [khetCustomMove.from.v];
											tempKhet._board.vs [khetCustomMove.from.v] = Common.Empty;
										}
									}
								} else {
									Debug.LogError ("from error: " + khetCustomMove.from.v + ", " + tempKhet._board.vs.Count);
								}
							}
						}
						break;
					case GameMove.Type.KhetCustomRotate:
						{
							KhetCustomRotate khetCustomRotate = gameMove as KhetCustomRotate;
							if (khetCustomRotate.position.v >= 0 && khetCustomRotate.position.v < tempKhet._board.vs.Count) {
								byte s = tempKhet._board.vs [khetCustomRotate.position.v];
								if (s != Common.OffBoard && s != Common.Empty) {
									Common.Player player = Common.GetOwner (s);
									Common.Piece piece = Common.GetPiece (s);
									Common.Orientation orientation = Common.GetOrientation (s);
									Common.Orientation newOrientation = (Common.Orientation)(((int)orientation + 4 + (khetCustomRotate.isAdd.v ? 1 : -1)) % 4);
									byte newS = Common.MakeSquare (player, piece, newOrientation);
									tempKhet._board.vs [khetCustomRotate.position.v] = newS;
								} else {
									Debug.LogError ("empty or offboard: " + s);
								}
							} else {
								Debug.LogError ("position error: " + khetCustomRotate.position.v + ", " + tempKhet._board.vs.Count);
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
					tempKhet.isCustom.v = true;
					tempKhet.khetSub.clear ();
					DataUtils.copyData (this, tempKhet, AllowNames);
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
		}

		public override void processGameMove(GameMove gameMove)
		{
			if (gameMove != null) {
				switch (gameMove.getType ()) {
				case GameMove.Type.KhetMove:
					{
						// get information
						KhetMove khetMove = gameMove as KhetMove;
						// make request to native
						Khet newKhet = Core.unityDoMove (this, Core.CanCorrect, khetMove.move.v);
						// Copy to current khet
						DataUtils.copyData (this, newKhet, AllowNames);
					}
					break;
				case GameMove.Type.None:
					break;
				case GameMove.Type.EndTurn:
					{
						if (this._playerToMove.v == (int)Common.Player.Silver) {
							this._playerToMove.v = (int)Common.Player.Red;
						} else {
							this._playerToMove.v = (int)Common.Player.Silver;
						}
						this.khetSub.clear ();
						this.isCustom.v = true;
					}
					break;
				default:
					Debug.LogError ("unknown gameMove: " + gameMove + "; " + this);
					this.processCustomGameMove (gameMove);
					break;
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
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
						/*GameData gameData = this.findDataInParent<GameData> ();
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
					KhetAI khetAI = (ai != null && ai is KhetAI) ? (KhetAI)ai : new KhetAI ();
					// search
					uint move = Core.unityLetComputerThink (this, Core.CanCorrect, khetAI.infinite.v, khetAI.moveTime.v, khetAI.depth.v, khetAI.pickBestMove.v);
					// make move
					{
						KhetMove khetMove = new KhetMove ();
						{
							khetMove.move.v = move;
						}
						ret = khetMove;
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
					for (int position = 0; position < this._board.vs.Count; position++) {
						if (position < Common.BoardArea) {
							if (this._board.vs [position] != Common.OffBoard) {
								// add empty
								{
									if (this._board.vs [position] != Common.Empty) {
										KhetCustomSet khetCustomSet = new KhetCustomSet ();
										{
											khetCustomSet.position.v = position;
											khetCustomSet.player.v = Common.Player.Silver;
											khetCustomSet.piece.v = Common.Piece.None;
										}
										moves.Add (khetCustomSet);
									}
								}
								// add other piece
								{
									foreach (Common.Piece piece in System.Enum.GetValues(typeof(Common.Piece))) {
										if (piece != Common.Piece.None) {
											foreach (Common.Player player in System.Enum.GetValues(typeof(Common.Player))) {
												KhetCustomSet khetCustomSet = new KhetCustomSet ();
												{
													khetCustomSet.position.v = position;
													khetCustomSet.player.v = player;
													khetCustomSet.piece.v = piece;
												}
												moves.Add (khetCustomSet);
											}
										}
									}
								}
							}
						} else {
							Debug.LogError ("why outside board: " + position);
						}
					}
				}
				// get custom move
				{
					for (int from = 0; from < this._board.vs.Count; from++) {
						if (from < Common.BoardArea) {
							if (this._board.vs [from] != Common.OffBoard && this._board.vs [from] != Common.Empty) {
								for (int dest = 0; dest < this._board.vs.Count; dest++) {
									if (dest < Common.BoardArea) {
										if (this._board.vs [dest] != Common.OffBoard) {
											KhetCustomMove khetCustomMove = new KhetCustomMove ();
											{
												khetCustomMove.from.v = from;
												khetCustomMove.dest.v = dest;
											}
											moves.Add (khetCustomMove);
										}
									} else {
										Debug.LogError ("why outside board: " + dest);
									}
								}
							}
						} else {
							Debug.LogError ("why outside board: " + from);
						}
					}
				}
				// get custom rotate
				{
					for (int position = 0; position < this._board.vs.Count; position++) {
						if (position < Common.BoardArea) {
							if (this._board.vs [position] != Common.OffBoard && this._board.vs [position] != Common.Empty) {
								// add rotate add
								{
									KhetCustomRotate khetCustomRotate = new KhetCustomRotate ();
									{
										khetCustomRotate.position.v = position;
										khetCustomRotate.isAdd.v = true;
									}
									moves.Add (khetCustomRotate);
								}
								// add rotate sub
								{
									KhetCustomRotate khetCustomRotate = new KhetCustomRotate ();
									{
										khetCustomRotate.position.v = position;
										khetCustomRotate.isAdd.v = false;
									}
									moves.Add (khetCustomRotate);
								}
							}
						} else {
							Debug.LogError ("why outside board: " + position);
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

		#region convert

		public static byte[] convertToBytes(Khet khet, bool needCheckCustom = true)
		{
			// custom
			if (khet.isCustom.v && needCheckCustom) {
				string strFen = Core.unityPositionToFen (khet, Core.CanCorrect);
				Debug.LogError ("khet custom fen: " + strFen);
				Khet newKhet = Core.unityMakePositionByFen (strFen);
				return convertToBytes (newKhet);
			}
			// normal
			byte[] byteArray;
			using (MemoryStream memStream = new MemoryStream ()) {
				using (BinaryWriter writer = new BinaryWriter (memStream)) {
					/** Player _playerToMove*/
					writer.Write (khet._playerToMove.v);
					/** bool _checkmate = false*/
					writer.Write (khet._checkmate.v);
					/** bool _drawn = false*/
					writer.Write (khet._drawn.v);
					/** int32_t _moveNumber = 0*/
					writer.Write (khet._moveNumber.v);
					/** uint64_t _hashes[MaxGameLength]*/
					{
						// count
						int count = 0;
						{
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								count += khetSub._hashes.vs.Count;
							}
							if (count < 0 || count > Common.MaxGameLength) {
								Debug.LogError ("count error: " + count);
								count = 0;
							}
							writer.Write (count);
						}
						// content
						{
							int index = 0;;
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								foreach (ulong hash in khetSub._hashes.vs) {
									if (index < count) {
										writer.Write (hash);
										index++;
									} else {
										break;
									}
								}
							}
						}
					}
					/** Laser _laser*/
					writer.Write (Laser.convertToBytes (khet._laser.v));

					// Mailbox style storage is used with one layer of padding.
					/** Square _board[BoardArea]*/
					for (int i = 0; i < Common.BoardArea; i++) {
						// get value
						byte value = 0;
						{
							if (i < khet._board.vs.Count) {
								value = khet._board.vs [i];
							} else {
								Debug.LogError ("index error: _board: " + khet);
							}
						}
						writer.Write (value);
					}
					/** Move _moves[MaxGameLength] = { NoMove }*/
					{
						// count
						int count = 0;
						{
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								count += khetSub._moves.vs.Count;
							}
							if (count < 0 || count > Common.MaxGameLength) {
								Debug.LogError ("count error: " + count);
								count = 0;
							}
							writer.Write (count);
						}
						// content
						{
							int index = 0;;
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								foreach (uint move in khetSub._moves.vs) {
									if (index < count) {
										writer.Write (move);
										index++;
									} else {
										break;
									}
								}
							}
						}
					}
					/** int32_t _pharaohPositions[2]*/
					for (int i = 0; i < 2; i++) {
						// get value
						int value = 0;
						{
							if (i < khet._pharaohPositions.vs.Count) {
								value = khet._pharaohPositions.vs [i];
							} else {
								Debug.LogError ("index error: _pharaohPositions: " + khet);
							}
						}
						writer.Write (value);
					}
					/** Square _captureSquare[MaxGameLength]*/
					{
						// count
						int count = 0;
						{
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								count += khetSub._captureSquare.vs.Count;
							}
							if (count < 0 || count > Common.MaxGameLength) {
								Debug.LogError ("count error: " + count);
								count = 0;
							}
							writer.Write (count);
						}
						// content
						{
							int index = 0;;
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								foreach (byte captureSquare in khetSub._captureSquare.vs) {
									if (index < count) {
										writer.Write (captureSquare);
										index++;
									} else {
										break;
									}
								}
							}
						}
					}
					/** int32_t _captureLocation[MaxGameLength]*/
					{
						// count
						int count = 0;
						{
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								count += khetSub._captureLocation.vs.Count;
							}
							if (count < 0 || count > Common.MaxGameLength) {
								Debug.LogError ("count error: " + count);
								count = 0;
							}
							writer.Write (count);
						}
						// content
						{
							int index = 0;;
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								foreach (int captureLocation in khetSub._captureLocation.vs) {
									if (index < count) {
										writer.Write (captureLocation);
										index++;
									} else {
										break;
									}
								}
							}
						}
					}
					/** int32_t _movesWithoutCapture[MaxGameLength]*/
					{
						// count
						int count = 0;
						{
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								count += khetSub._movesWithoutCapture.vs.Count;
							}
							if (count < 0 || count > Common.MaxGameLength) {
								Debug.LogError ("count error: " + count);
								count = 0;
							}
							writer.Write (count);
						}
						// content
						{
							int index = 0;
							foreach (KhetSub khetSub in khet.khetSub.vs) {
								foreach (int moveWithoutCapture in khetSub._movesWithoutCapture.vs) {
									if (index < count) {
										writer.Write (moveWithoutCapture);
										index++;
									} else {
										break;
									}
								}
							}
						}
					}

					// write to byteArray
					byteArray = memStream.ToArray ();
				}
			}
			// Debug.LogError ("convert to byte array: " + byteArray.Length);
			return byteArray;
		}

		public static int parse(Khet khet, byte[] byteArray, int start)
		{
			// Debug.LogError ("parse byte array: " + byteArray.Length);
			int count = start;
			int index = 0;
			bool isParseCorrect = true;
			// init khetSub
			{
				khet.khetSub.clear ();
			}
			while (count < byteArray.Length) {
				bool alreadyPassAll = false;
				switch (index) {
				case 0:
					{
						/** Player _playerToMove*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							khet._playerToMove.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: _playerToMove: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 1:
					{
						/** bool _checkmate = false*/
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							khet._checkmate.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: _checkmate: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 2:
					{
						/** bool _drawn = false*/
						int size = sizeof(bool);
						if (count + size <= byteArray.Length) {
							khet._drawn.v = BitConverter.ToBoolean (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: _drawn: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 3:
					{
						/** int32_t _moveNumber = 0*/
						int size = sizeof(int);
						if (count + size <= byteArray.Length) {
							khet._moveNumber.v = BitConverter.ToInt32 (byteArray, count);
							count += size;
						} else {
							Debug.LogError ("array not enough length: _moveNumber: " + count + "; " + byteArray.Length);
							isParseCorrect = false;
						}
					}
					break;
				case 4:
					{
						/** uint64_t _hashes[MaxGameLength]*/
						// count
						int hashCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								hashCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: hashCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
							// correct
							if (hashCount < 0 || hashCount > Common.MaxGameLength) {
								Debug.LogError ("hashCount error: " + hashCount);
								hashCount = 0;
							}
						}
						// content
						{
							int size = sizeof(ulong);
							for (int i = 0; i < hashCount; i++) {
								if (count + size <= byteArray.Length) {
									// find khetSub
									KhetSub khetSub = null;
									{
										// find old
										{
											int khetSubIndex = i / KhetSub.MaxCount;
											if (khetSubIndex >= 0 && khetSubIndex < khet.khetSub.vs.Count) {
												khetSub = khet.khetSub.vs [khetSubIndex];
											}
										}
										// make new
										if (khetSub == null) {
											khetSub = new KhetSub ();
											{
												khetSub.uid = khet.khetSub.makeId ();
											}
											khet.khetSub.add (khetSub);
										}
									}
									// add
									khetSub._hashes.add (BitConverter.ToUInt64 (byteArray, count));
									count += size;
								} else {
									Debug.LogError ("array not enough length: _hashes: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
							}
						}
					}
					break;
				case 5:
					{
						/** Laser _laser*/
						Laser laser = new Laser ();
						// parse
						{
							int byteLength = Laser.parse (laser, byteArray, count);
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
							laser.uid = khet._laser.makeId ();
							khet._laser.v = laser;
						} else {
							Debug.LogError ("parse laser error");
						}
					}
					break;
				case 6:
					{
						/** Square _board[BoardArea]*/
						khet._board.clear ();
						int size = sizeof(byte);
						for (int i = 0; i < Common.BoardArea; i++) {
							if (count + size <= byteArray.Length) {
								khet._board.add (byteArray [count]);
								count += size;
							} else {
								Debug.LogError ("array not enough length: _board: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 7:
					{
						/** Move _moves[MaxGameLength] = { NoMove }*/
						// count
						int moveCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								moveCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: moveCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
							// correct
							if (moveCount < 0 || moveCount > Common.MaxGameLength) {
								Debug.LogError ("moveCount error: " + moveCount);
								moveCount = 0;
							}
						}
						// content
						{
							int size = sizeof(uint);
							for (int i = 0; i < moveCount; i++) {
								if (count + size <= byteArray.Length) {
									// find khetSub
									KhetSub khetSub = null;
									{
										// find old
										{
											int khetSubIndex = i / KhetSub.MaxCount;
											if (khetSubIndex >= 0 && khetSubIndex < khet.khetSub.vs.Count) {
												khetSub = khet.khetSub.vs [khetSubIndex];
											}
										}
										// make new
										if (khetSub == null) {
											khetSub = new KhetSub ();
											{
												khetSub.uid = khet.khetSub.makeId ();
											}
											khet.khetSub.add (khetSub);
										}
									}
									// add
									khetSub._moves.add (BitConverter.ToUInt32 (byteArray, count));
									count += size;
								} else {
									Debug.LogError ("array not enough length: _moves: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
							}
						}
					}
					break;
				case 8:
					{
						/** int32_t _pharaohPositions[2]*/
						khet._pharaohPositions.clear ();
						int size = sizeof(int);
						for (int i = 0; i < 2; i++) {
							if (count + size <= byteArray.Length) {
								khet._pharaohPositions.add (BitConverter.ToInt32 (byteArray, count));
								count += size;
							} else {
								Debug.LogError ("array not enough length: _pharaohPositions: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
								break;
							}
						}
					}
					break;
				case 9:
					{
						/** Square _captureSquare[MaxGameLength]*/
						// count
						int captureSquareCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								captureSquareCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: captureSquareCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
							// correct
							if (captureSquareCount < 0 || captureSquareCount > Common.MaxGameLength) {
								Debug.LogError ("captureSquareCount error: " + captureSquareCount);
								captureSquareCount = 0;
							}
						}
						// content
						{
							int size = sizeof(byte);
							for (int i = 0; i < captureSquareCount; i++) {
								if (count + size <= byteArray.Length) {
									// find khetSub
									KhetSub khetSub = null;
									{
										// find old
										{
											int khetSubIndex = i / KhetSub.MaxCount;
											if (khetSubIndex >= 0 && khetSubIndex < khet.khetSub.vs.Count) {
												khetSub = khet.khetSub.vs [khetSubIndex];
											}
										}
										// make new
										if (khetSub == null) {
											khetSub = new KhetSub ();
											{
												khetSub.uid = khet.khetSub.makeId ();
											}
											khet.khetSub.add (khetSub);
										}
									}
									// add
									khetSub._captureSquare.add (byteArray [count]);
									count += size;
								} else {
									Debug.LogError ("array not enough length: _captureSquare: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
							}
						}
					}
					break;
				case 10:
					{
						/** int32_t _captureLocation[MaxGameLength]*/
						// count
						int captureLocationCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								captureLocationCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: captureLocationCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
							// correct
							if (captureLocationCount < 0 || captureLocationCount > Common.MaxGameLength) {
								Debug.LogError ("captureLocationCount error: " + captureLocationCount);
								captureLocationCount = 0;
							}
						}
						// content
						{
							int size = sizeof(int);
							for (int i = 0; i < captureLocationCount; i++) {
								if (count + size <= byteArray.Length) {
									// find khetSub
									KhetSub khetSub = null;
									{
										// find old
										{
											int khetSubIndex = i / KhetSub.MaxCount;
											if (khetSubIndex >= 0 && khetSubIndex < khet.khetSub.vs.Count) {
												khetSub = khet.khetSub.vs [khetSubIndex];
											}
										}
										// make new
										if (khetSub == null) {
											khetSub = new KhetSub ();
											{
												khetSub.uid = khet.khetSub.makeId ();
											}
											khet.khetSub.add (khetSub);
										}
									}
									// add
									khetSub._captureLocation.add (BitConverter.ToInt32 (byteArray, count));
									count += size;
								} else {
									Debug.LogError ("array not enough length: _captureLocation: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
							}
						}
					}
					break;
				case 11:
					{
						/** int32_t _movesWithoutCapture[MaxGameLength]*/
						// count
						int moveWithoutCaptureCount = 0;
						{
							int size = sizeof(int);
							if (count + size <= byteArray.Length) {
								moveWithoutCaptureCount = BitConverter.ToInt32 (byteArray, count);
								count += size;
							} else {
								Debug.LogError ("array not enough length: moveWithoutCaptureCount: " + count + "; " + byteArray.Length);
								isParseCorrect = false;
							}
							// correct
							if (moveWithoutCaptureCount < 0 || moveWithoutCaptureCount > Common.MaxGameLength) {
								Debug.LogError ("moveWithoutCaptureCount error: " + moveWithoutCaptureCount);
								moveWithoutCaptureCount = 0;
							}
						}
						// content
						{
							int size = sizeof(int);
							for (int i = 0; i < moveWithoutCaptureCount; i++) {
								if (count + size <= byteArray.Length) {
									// find khetSub
									KhetSub khetSub = null;
									{
										// find old
										{
											int khetSubIndex = i / KhetSub.MaxCount;
											if (khetSubIndex >= 0 && khetSubIndex < khet.khetSub.vs.Count) {
												khetSub = khet.khetSub.vs [khetSubIndex];
											}
										}
										// make new
										if (khetSub == null) {
											khetSub = new KhetSub ();
											{
												khetSub.uid = khet.khetSub.makeId ();
											}
											khet.khetSub.add (khetSub);
										}
									}
									// add
									khetSub._movesWithoutCapture.add (BitConverter.ToInt32 (byteArray, count));
									count += size;
								} else {
									Debug.LogError ("array not enough length: _movesWithoutCapture: " + count + "; " + byteArray.Length);
									isParseCorrect = false;
									break;
								}
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
			// remove not use khetsub
			{
				for (int i = khet.khetSub.vs.Count - 1; i >= 0; i--) {
					KhetSub khetSub = khet.khetSub.vs [i];
					if (khetSub._hashes.vs.Count == 0 && khetSub._moves.vs.Count == 0 &&
					    khetSub._captureSquare.vs.Count == 0 && khetSub._captureLocation.vs.Count == 0 &&
					    khetSub._movesWithoutCapture.vs.Count == 0) {
						Debug.LogError ("need remove khetsub: " + khetSub);
						khet.khetSub.removeAt (i);
					}
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