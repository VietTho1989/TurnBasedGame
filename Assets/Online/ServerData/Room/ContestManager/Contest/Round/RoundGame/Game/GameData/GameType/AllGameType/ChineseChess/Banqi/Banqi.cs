using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Banqi.NoneRule;

namespace Banqi
{
	public class Banqi : GameType
	{

		public VP<Token.Ecolor> color;

		public VP<string> state;

		private static void parseStrPiece(string strPiece, out Token.Ecolor color, out Token.Type type, out bool isFaceUp)
		{
			// init
			color = Token.Ecolor.None;
			type = Token.Type.SOLDIER;
			isFaceUp = true;
			// parse
			if (strPiece.Equals ("XXX")) {

			} else if (string.IsNullOrEmpty (strPiece)) {
				// Debug.LogError ("split i empty");

			} else {
				if (strPiece [0] == 'B') {
					color = Token.Ecolor.BLACK;
				} else
					color = Token.Ecolor.RED;

				int temp = strPiece [1];
				switch (temp) {
				case '7':
					type = Token.Type.GENERAL;
					break;
				case '6':
					type = Token.Type.ADVISOR;
					break;
				case '5':
					type = Token.Type.ELEPHANT;
					break;
				case '4':
					type = Token.Type.CHARIOT;
					break;
				case '3':
					type = Token.Type.HORSE;
					break;
				case '2':
					type = Token.Type.CANNON;
					break;
				case '1':
					type = Token.Type.SOLDIER;
					break;
				default:
					Debug.LogError ("unknown type: " + temp);
					type = Token.Type.SOLDIER;
					break;
				}
				if (strPiece [2] == 'U') {
					isFaceUp = true;
				} else
					isFaceUp = false;
			}
		}

		public void getPiece(int pos, out Token.Ecolor color, out Token.Type type, out bool isFaceUp)
		{
			// init
			color = Token.Ecolor.None;
			type = Token.Type.SOLDIER;
			isFaceUp = true;
			// find
			string[] graveyardSplit = this.state.v.Split (new char[]{ '.' });
			// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
			string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
			if (pos >= 0 && pos < split.Length) {
				parseStrPiece (split [pos], out color, out type, out isFaceUp);
			}
		}

		public VP<bool> isCustom;

		#region Constructor

		public enum Property
		{
			color,
			state,
			isCustom
		}

		public static readonly List<byte> AllowNames = new List<byte> ();

		static Banqi()
		{
			AllowNames.Add ((byte)Property.color);
			AllowNames.Add ((byte)Property.state);
			AllowNames.Add ((byte)Property.isCustom);
		}

		public Banqi() : base()
		{
			this.color = new VP<Token.Ecolor> (this, (byte)Property.color, Token.Ecolor.RED);
			this.state = new VP<string> (this, (byte)Property.state, "");
			this.isCustom = new VP<bool> (this, (byte)Property.isCustom, false);
		}

		#endregion

		#region convert

		public static AI convertToAI(Banqi banqi)
		{
			/*if (banqi.color.v == Token.Ecolor.RED) {
				Game game = new Game (banqi.state.v);
				AI ai = new AI (game, banqi.color.v);
				return ai;
			} else {
				string state = banqi.state.v;
				{
					for (int i = 0; i < state.Length; i++) {
						if (state [i] == 'R') {
							state.Remove (i, 1).Insert (i, "B");
						} else if (state [i] == 'B') {
							state.Remove (i, 1).Insert (i, "R");
						}
					}
				}
				Game game = new Game (state);
				AI ai = new AI (game, Token.Ecolor.RED);
				return ai;
			}*/
			Game game = new Game (banqi.state.v);
			AI ai = new AI (game, banqi.color.v);
			return ai;
		}

		public string print()
		{
			StringBuilder builder = new StringBuilder();
			{
				string[] splitState = this.state.v.Split(new string[]{" . "}, StringSplitOptions.None);
				string field_raw = splitState[0];
				string[] field = field_raw.Split(new char[]{' '});

				int i = 0;
				for(int y=4; y>0; y--) {
					for(int x=1; x<9; x++) {
						//System.out.print("[" + x + "," + y + "] ");
						builder.Append(field[i] + " ");
						i++;
					}
					builder.AppendLine();
				}
			}
			return builder.ToString();
		}

		#endregion

		#region implement base

		public override Type getType ()
		{
			return Type.Banqi;
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
			return (this.color.v == Token.Ecolor.RED) ? 0 : 1;
		}

		public override bool checkLegalMove (InputData inputData)
		{
			GameMove gameMove = inputData.gameMove.v;
			if (gameMove != null) {
				if (GameData.IsUseRule (this)) {
					switch (gameMove.getType ()) {
					case GameMove.Type.BanqiMove:
						{
							BanqiMove banqiMove = gameMove as BanqiMove;
							AI ai = Banqi.convertToAI (this);
							List<int[][]> allValidMoves = ai.validMoves (this.state.v);
							// check correct
							bool isCorrect = false;
							{
								foreach (int[][] allValidMove in allValidMoves) {
									foreach (int[] validMove in allValidMove) {
										if (validMove.Length == 4) {
											if (validMove [0] == banqiMove.fromX.v && validMove [1] == banqiMove.fromY.v
											   && validMove [2] == banqiMove.destX.v && validMove [3] == banqiMove.destY.v) {
												isCorrect = true;
												break;
											}
										} else {
											Debug.LogError ("validMove length error: " + validMove.Length);
										}
									}
								}
							}
							return isCorrect;
						}
					default:
						Debug.LogError ("unknown game move type: " + gameMove.getType () + "; " + this);
						break;
					}
				} else {
					// TODO Can hoan thien
					return true;
				}
			} else {
				Debug.LogError ("gameMove null: " + this);
			}
			return false;
		}

		#endregion

		#region processGameMove

		public override void processGameMove(GameMove gameMove)
		{
			switch (gameMove.getType ()) {
			case GameMove.Type.BanqiMove:
				{
					BanqiMove banqiMove = gameMove as BanqiMove;
					// change
					AI ai = Banqi.convertToAI(this);
					string state = ai.game.getBoard ().saveBoard ();
					int[] chosenMove = new int[4];
					{
						chosenMove [0] = banqiMove.fromX.v;
						chosenMove [1] = banqiMove.fromY.v;
						chosenMove [2] = banqiMove.destX.v;
						chosenMove [3] = banqiMove.destY.v;
					}
					string newState = ai.makeMove(chosenMove, state);
					// update
					this.state.v = newState;
					this.color.v = (this.color.v == Token.Ecolor.RED) ? Token.Ecolor.BLACK : Token.Ecolor.RED;
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
				bool needUpdate = true;
				{
					switch (gameMove.getType ()) {
					case GameMove.Type.EndTurn:
						{
							this.color.v = (this.color.v == Token.Ecolor.RED) ? Token.Ecolor.BLACK : Token.Ecolor.RED;
						}
						break;
					case GameMove.Type.Clear:
						{
							StringBuilder builder = new StringBuilder ();
							{
								for (int i = 0; i < 32; i++) {
									if (i != 31) {
										builder.Append ("XXX ");
									} else {
										builder.Append ("XXX");
									}
								}
							}
							this.state.v = builder.ToString ();
						}
						break;
					case GameMove.Type.BanqiCustomSet:
						{
							BanqiCustomSet banqiCustomSet = gameMove as BanqiCustomSet;
							// new state
							StringBuilder builder = new StringBuilder();
							{
								List<string> oldSplits = new List<string> ();
								{
									string[] graveyardSplit = this.state.v.Split (new char[]{ '.' });
									// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
									string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
									for (int i = 0; i < split.Length; i++) {
										if (string.IsNullOrEmpty (split [i])) {
											oldSplits.Add ("XXX");
											continue;
										} else {
											oldSplits.Add (split [i]);
										}
									}
								}
								// make new
								for (int i = 0; i < 32; i++) {
									if (i == 8 * banqiCustomSet.y.v + banqiCustomSet.x.v) {
										string split = "";
										{
											if (banqiCustomSet.color.v == Token.Ecolor.None) {
												split = "XXX";
											} else {
												// color
												split += (banqiCustomSet.color.v == Token.Ecolor.RED) ? "R" : "B";
												// type
												{
													switch (banqiCustomSet.type.v) {
													case Token.Type.GENERAL:
														split += "7";
														break;
													case Token.Type.ADVISOR:
														split += "6";
														break;
													case Token.Type.ELEPHANT:
														split += "5";
														break;
													case Token.Type.CHARIOT:
														split += "4";
														break;
													case Token.Type.HORSE:
														split += "3";
														break;
													case Token.Type.CANNON:
														split += "2";
														break;
													case Token.Type.SOLDIER:
														split += "1";
														break;
													default:
														Debug.LogError ("unknown type: " + banqiCustomSet.type.v);
														split += "1";
														break;
													}
												}
												// faceUp
												split += banqiCustomSet.isFaceUp.v ? "U" : "D";
											}
										}
										builder.Append (split);
									} else {
										// find old
										string split = "XXX";
										{
											if (i >= 0 && i < oldSplits.Count) {
												split = oldSplits [i];
											}
										}
										builder.Append (split);
									}
									if (i != 31) {
										builder.Append (" ");
									}
								}
							}
							this.state.v = builder.ToString ();
						}
						break;
					case GameMove.Type.BanqiCustomMove:
						{
							BanqiCustomMove banqiCustomMove = gameMove as BanqiCustomMove;
							// make state
							StringBuilder builder = new StringBuilder ();
							{
								List<string> oldSplits = new List<string> ();
								{
									string[] graveyardSplit = this.state.v.Split (new char[]{ '.' });
									// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
									string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
									for (int i = 0; i < split.Length; i++) {
										if (string.IsNullOrEmpty (split [i])) {
											oldSplits.Add ("XXX");
											continue;
										} else {
											oldSplits.Add (split [i]);
										}
									}
								}
								for (int i = 0; i < 32; i++) {
									if (i == 8 * banqiCustomMove.fromY.v + banqiCustomMove.fromX.v) {
										builder.Append ("XXX");
									} else if (i == 8 * banqiCustomMove.destY.v + banqiCustomMove.destX.v) {
										string split = "XXX";
										{
											int fromIndex = 8 * banqiCustomMove.fromY.v + banqiCustomMove.fromX.v;
											if (fromIndex >= 0 && fromIndex < oldSplits.Count) {
												split = oldSplits [fromIndex];
											} else {
												Debug.LogError ("fromIndex error: " + fromIndex + ", " + oldSplits.Count);
											}
										}
										builder.Append (split);
									} else {
										string split = "XXX";
										{
											if (i >= 0 && i < oldSplits.Count) {
												split = oldSplits [i];
											} else {
												Debug.LogError ("index error: " + i + ", " + oldSplits.Count);
											}
										}
										builder.Append (split);
									}
									if (i != 31) {
										builder.Append (" ");
									}
								}
							}
							this.state.v = builder.ToString ();
						}
						break;
					case GameMove.Type.BanqiCustomFlip:
						{
							BanqiCustomFlip banqiCustomFlip = gameMove as BanqiCustomFlip;
							// make state
							StringBuilder builder = new StringBuilder ();
							{
								List<string> oldSplits = new List<string> ();
								{
									string[] graveyardSplit = this.state.v.Split (new char[]{ '.' });
									// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
									string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
									for (int i = 0; i < split.Length; i++) {
										if (string.IsNullOrEmpty (split [i])) {
											oldSplits.Add ("XXX");
											continue;
										} else {
											oldSplits.Add (split [i]);
										}
									}
								}
								for (int i = 0; i < 32; i++) {
									if (i == 8 * banqiCustomFlip.y.v + banqiCustomFlip.x.v) {
										string split = "XXX";
										{
											if (i >= 0 && i < oldSplits.Count) {
												string oldSplit = oldSplits [i];
												if (oldSplit.Length == 3) {
													if (oldSplit != "XXX") {
														split = "";
														split += oldSplit [0];
														split += oldSplit [1];
														split += oldSplit [2] == 'U' ? 'D' : 'U';
													} else {
														Debug.LogError ("oldSplit error: " + oldSplit);
													}
												} else {
													Debug.LogError ("oldSplit length error: " + oldSplit.Length);
												}
											}
										}
										builder.Append (split);
									} else {
										string split = "XXX";
										{
											if (i >= 0 && i < oldSplits.Count) {
												split = oldSplits [i];
											} else {
												Debug.LogError ("index error: " + i + ", " + oldSplits.Count);
											}
										}
										builder.Append (split);
									}
									if (i != 31) {
										builder.Append (" ");
									}
								}
							}
							this.state.v = builder.ToString ();
						}
						break;
					default:
						Debug.LogError ("unknown gameMove: " + gameMove);
						needUpdate = false;
						break;
					}
				}
				if (needUpdate) {
					this.isCustom.v = true;
				}
			} else {
				Debug.LogError ("gameMove null");
			}
		}

		#endregion

		#region getAIMove

		// private static Dictionary<Tuple<string,string>, Double> Q = new Dictionary<Tuple<string,string>, Double> ();

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
						// useNormalMove = false;
						GameData gameData = this.findDataInParent<GameData>();
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
						}
					}
				}
				// find
				if (useNormalMove) {
					BanqiAI banqiAI = (computerAI != null && computerAI is BanqiAI) ? (BanqiAI)computerAI : new BanqiAI ();
					// make ai
					AI ai = Banqi.convertToAI (this);
					// make search
					string state = ai.game.getBoard().saveBoard();
					if (state.Split (new string[]{ " . " }, StringSplitOptions.None) [0].Contains ("R") && state.Split (new string[]{ " . " }, StringSplitOptions.None) [0].Contains ("B")) {
						// Debug.LogError ("while state split");
						int[] chosenMove = ai.negamax (state, banqiAI.depth.v);
						{
							// Q = ai.loadQ (qMapFileName);
							// chosenMove = ai.Qmove(state, 'R', Q);
						}
						if (chosenMove != null && chosenMove.Length == 4) {
							BanqiMove banqiMove = new BanqiMove ();
							{
								banqiMove.fromX.v = chosenMove [0];
								banqiMove.fromY.v = chosenMove [1];
								banqiMove.destX.v = chosenMove [2];
								banqiMove.destY.v = chosenMove [3];
							}
							ret = banqiMove;
						} else {
							Debug.LogError ("chosenMove error");
						}
					} else {
						Debug.LogError ("why already finish, cannot find ai move");
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
				List<string> oldSplits = new List<string> ();
				{
					string[] graveyardSplit = this.state.v.Split (new char[]{ '.' });
					// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
					string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
					for (int i = 0; i < split.Length; i++) {
						if (string.IsNullOrEmpty (split [i])) {
							oldSplits.Add ("XXX");
							continue;
						} else {
							oldSplits.Add (split [i]);
						}
					}
				}
				// get custom set
				{
					for (int i = 0; i < 32; i++) {
						// make empty
						{
							// check already empty
							bool alreadyEmpty = false;
							if (i >= 0 && i < oldSplits.Count) {
								if (oldSplits [i] == "XXX") {
									alreadyEmpty = true;
								}
							} else {
								Debug.LogError ("i error: " + i + ", " + oldSplits.Count);
							}
							// process
							if (!alreadyEmpty) {
								// add set empty
								BanqiCustomSet banqiCustomSet = new BanqiCustomSet ();
								{
									banqiCustomSet.x.v = i % 8;
									banqiCustomSet.y.v = i / 8;
									banqiCustomSet.color.v = Token.Ecolor.None;
									banqiCustomSet.type.v = Token.Type.SOLDIER;
									banqiCustomSet.isFaceUp.v = true;
								}
								moves.Add (banqiCustomSet);
							} else {
								// add flip
								BanqiCustomFlip banqiCustomFlip = new BanqiCustomFlip();
								{
									banqiCustomFlip.x.v = i % 8;
									banqiCustomFlip.y.v = i / 8;
								}
								moves.Add (banqiCustomFlip);
								// add move
								{
									for (int j = 0; j < 32; j++) {
										if (i != j) {
											BanqiCustomMove banqiCustomMove = new BanqiCustomMove ();
											{
												banqiCustomMove.fromX.v = i % 8;
												banqiCustomMove.fromY.v = i / 8;
												banqiCustomMove.destX.v = j % 8;
												banqiCustomMove.destY.v = j / 8;
											}
											moves.Add (banqiCustomMove);
										}
									}
								}
							}
						}
						// other
						{
							Token.Ecolor oldColor = Token.Ecolor.None;
							Token.Type oldType = Token.Type.SOLDIER;
							bool oldIsFaceUp = true;
							{
								if (i >= 0 && i < oldSplits.Count) {
									parseStrPiece (oldSplits [i], out oldColor, out oldType, out oldIsFaceUp);
								} else {
									Debug.LogError ("i error: " + i + ", " + oldSplits.Count);
								}
							}
							// add set
							foreach (Token.Ecolor color in System.Enum.GetValues(typeof(Token.Ecolor)))
								foreach (Token.Type type in System.Enum.GetValues(typeof(Token.Type))) {
									// add faceUp
									if (color != oldColor || type != oldType || !oldIsFaceUp) {
										BanqiCustomSet banqiCustomSet = new BanqiCustomSet ();
										{
											banqiCustomSet.x.v = i % 8;
											banqiCustomSet.y.v = i / 8;
											banqiCustomSet.color.v = color;
											banqiCustomSet.type.v = type;
											banqiCustomSet.isFaceUp.v = true;
										}
										moves.Add (banqiCustomSet);
									}
									// add faceDown
									if (color != oldColor || type != oldType || oldIsFaceUp) {
										BanqiCustomSet banqiCustomSet = new BanqiCustomSet ();
										{
											banqiCustomSet.x.v = i % 8;
											banqiCustomSet.y.v = i / 8;
											banqiCustomSet.color.v = color;
											banqiCustomSet.type.v = type;
											banqiCustomSet.isFaceUp.v = false;
										}
										moves.Add (banqiCustomSet);
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
					int isGameFinish = 0;
					{
						bool containRed = this.state.v.Split (new string[]{ " . " }, StringSplitOptions.None) [0].Contains ("R");
						bool containBlack = this.state.v.Split (new string[]{ " . " }, StringSplitOptions.None) [0].Contains ("B");
						if (containRed && containBlack) {
							isGameFinish = 0;
						} else if (!containRed && !containBlack) {
							isGameFinish = 3;
						} else if (containRed) {
							isGameFinish = 1;
						} else {
							isGameFinish = 2;
						}
					}
					switch (isGameFinish) {
					case 0:
						{
							result.isGameFinish = false;
						}
						break;
					case 1:
						// red win
						{
							result.isGameFinish = true;
							// score
							result.scores.Add (new GameType.Score (0, 1));// red
							result.scores.Add (new GameType.Score (1, 0));// black
						}
						break;
					case 2:
						// black win
						{
							result.isGameFinish = true;
							// score
							result.scores.Add (new GameType.Score (0, 0));// red
							result.scores.Add (new GameType.Score (1, 1));// black
						}
						break;
					case 3:
						// draw
						{
							result.isGameFinish = true;
							// score
							result.scores.Add (new GameType.Score (0, 0.5f));// red
							result.scores.Add (new GameType.Score (1, 0.5f));// black
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

	}
}