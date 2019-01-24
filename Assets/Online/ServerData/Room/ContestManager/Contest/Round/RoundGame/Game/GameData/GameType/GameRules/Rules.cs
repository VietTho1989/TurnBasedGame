using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rule
{
	public class Rules
	{

		public struct Coord
		{
			public byte x;
			public byte y;

			public string printCoord()
			{
				return string.Format ("{0}{1}", (char)('A' + x), y);
			}
		}

		public class Move
		{
			public Coord from;
			public Coord dest;

			public bool equals (Move otherMove)
			{
				if (from.x == otherMove.from.x && from.y == otherMove.from.y
					&& dest.x == otherMove.dest.x && dest.y == otherMove.dest.y) {
					return true;
				} else {
					return false;
				}
			}

			public override string ToString ()
			{
				return string.Format ("[Move: ({0},{1});({2},{3})]", from.x, from.y, dest.x, dest.y);
			}

			public string printMove()
			{
				return string.Format ("{0}{1}", from.printCoord (), dest.printCoord ());
			}

		}

		public List<RuleSet> ruleSets = new List<RuleSet>();

		/** Thuong bang null*/
		public bool[,] restrict;

		public List<Coord> getLegalCoords(Board board, Coord pieceCoord)
		{
			List<Coord> ret = new List<Coord> ();
			{
				// check legal board
				bool legalBoard = false;
				{
					if (board != null) {
						if (board.board != null && board.side != null) {
							if (board.board.GetLength (0) == board.side.GetLength (0) && board.board.GetLength (1) == board.side.GetLength (1)) {
								legalBoard = true;
							} else {
								Debug.LogError ("not correct length");
							}
						} else {
							Debug.LogError ("board or side null");
						}
					} else {
						Debug.LogError ("board null");
					}
				}
				// get coord
				if (legalBoard) {
					// get pieceSide
					byte pieceSide = 0;
					{
						if (pieceCoord.x >= 0 && pieceCoord.x < board.side.GetLength (0)
						    && pieceCoord.y >= 0 && pieceCoord.y < board.side.GetLength (1)) {
							pieceSide = board.side [pieceCoord.x, pieceCoord.y];
						} else {
							Debug.LogError ("pieceCoord not on board: " + pieceCoord);
						}
					}
					// Process
					if (pieceSide != 0) {
						for (int ruleSetIndex = 0; ruleSetIndex < this.ruleSets.Count; ruleSetIndex++) {
							RuleSet ruleSet = this.ruleSets [ruleSetIndex];
							// get legal coords
							List<Coord> legalCoords = new List<Coord> ();
							bool isPin = false;
							{
								for (byte x = (byte)Mathf.Max (pieceCoord.x - ruleSet.x, 0); x < (byte)Mathf.Min (pieceCoord.x - ruleSet.x + ruleSet.matrix.GetLength (0), board.board.GetLength (0)); x++)
									for (byte y = (byte)Mathf.Max (pieceCoord.y - ruleSet.y, 0); y < (byte)Mathf.Min (pieceCoord.y - ruleSet.y + ruleSet.matrix.GetLength (1), board.board.GetLength (1)); y++) {
										int ruleX = x - (pieceCoord.x - ruleSet.x);
										int ruleY = y - (pieceCoord.y - ruleSet.y);
										switch (ruleSet.matrix [ruleX, ruleY]) {
										case 0:
											break;
										case AbstractRuleList.d:
											{
												if (board.side [x, y] != pieceSide) {
													Coord coord = new Coord ();
													{
														coord.x = x;
														coord.y = y;
													}
													legalCoords.Add (coord);
												}
											}
											break;
										case AbstractRuleList.r:
											{
												if (ruleX != ruleSet.x || ruleY != ruleSet.y) {
													int distance = 0;
													do {
														int rookX = x + distance * (ruleX - ruleSet.x);
														int rookY = y + distance * (ruleY - ruleSet.y);
														byte rookSide = 0;
														// Check in board
														if (rookX >= 0 && rookX < board.side.GetLength (0)
														    && rookY >= 0 && rookY < board.side.GetLength (1)) {
															rookSide = board.side [rookX, rookY];
														} else {
															// Debug.Log ("outside board: " + rookX + ", " + rookY + "; " + distance);
															break;
														}
														// Add
														{
															if (rookSide == 0) {
																Coord coord = new Coord ();
																{
																	coord.x = unchecked((byte)rookX);
																	coord.y = unchecked((byte)rookY);
																}
																legalCoords.Add (coord);
															} else {
																if (rookSide != pieceSide) {
																	Coord coord = new Coord ();
																	{
																		coord.x = unchecked((byte)rookX);
																		coord.y = unchecked((byte)rookY);
																	}
																	legalCoords.Add (coord);
																}
																// Debug.Log ("meet obstacle: " + rookX + ", " + rookY + "; " + distance + "; " + rookSide + ", " + board.board [rookX, rookY]);
																break;
															}
														}
														distance++;
													} while(true);
												} else {
													Debug.LogError ("why the same ruleXY: " + x + "; " + y + "; " + ruleX + "; " + ruleY + "; " + ruleSet.x + "; " + ruleSet.y);
												}
											}
											break;
										case AbstractRuleList.c:
											{
												if (ruleX != ruleSet.x || ruleY != ruleSet.y) {
													int distance = 0;
													bool alreadyMeetObstacle = false;
													do {
														int cannonX = x + distance * (ruleX - ruleSet.x);
														int cannonY = y + distance * (ruleY - ruleSet.y);
														byte cannonSide = 0;
														// Check in board
														if (cannonX >= 0 && cannonX < board.side.GetLength (0)
														    && cannonY >= 0 && cannonY < board.side.GetLength (1)) {
															cannonSide = board.side [cannonX, cannonY];
														} else {
															// Debug.Log ("outside board: cannon");
															break;
														}
														// Check add
														{
															if (!alreadyMeetObstacle) {
																if (cannonSide == 0) {
																	Coord coord = new Coord ();
																	{
																		coord.x = unchecked((byte)cannonX);
																		coord.y = unchecked((byte)cannonY);
																	}
																	legalCoords.Add (coord);
																} else {
																	alreadyMeetObstacle = true;
																}
															} else {
																if (cannonSide != 0) {
																	if (cannonSide != pieceSide) {
																		Coord coord = new Coord ();
																		{
																			coord.x = unchecked((byte)cannonX);
																			coord.y = unchecked((byte)cannonY);
																		}
																		legalCoords.Add (coord);
																	}
																	break;
																}
															}
														}
														distance++;
													} while(true);
												} else {
													Debug.LogError ("why the same ruleXY: " + x + "; " + y + "; " + ruleX + "; " + ruleY + "; " + ruleSet.x + "; " + ruleSet.y);
												}
											}
											break;
										case AbstractRuleList.p:
											{
												if (board.side [x, y] != 0) {
													// Debug.Log ("isPin: " + x + "; " + y);
													isPin = true;
												}
											}
											break;
										case AbstractRuleList.k:
											{
												// this position
												if (board.side [x, y] != pieceSide) {
													Coord coord = new Coord ();
													{
														coord.x = unchecked((byte)x);
														coord.y = unchecked((byte)y);
													}
													legalCoords.Add (coord);
												}
												// check other king
												{
													if (ruleX != ruleSet.x || ruleY != ruleSet.y) {
														int distance = 1;
														do {
															int kingX = x + distance * (ruleX - ruleSet.x);
															int kingY = y + distance * (ruleY - ruleSet.y);
															// Check in board
															if (kingX < 0 || kingX >= board.side.GetLength (0)
															    || kingY < 0 || kingY >= board.side.GetLength (1)) {
																// Debug.LogError ("outside board");
																break;
															}
															if (board.board [x, y] != 0) {
																if (board.board [x, y] == ruleSet.otherKing) {
																	Coord coord = new Coord ();
																	{
																		coord.x = unchecked((byte)kingX);
																		coord.y = unchecked((byte)kingY);
																	}
																	legalCoords.Add (coord);
																}
																break;
															}
															distance++;
														} while(true);
													} else {
														Debug.LogError ("why the same ruleXY: " + x + "; " + y + "; " + ruleX + "; " + ruleY + "; " + ruleSet.x + "; " + ruleSet.y);
													}
												}
											}
											break;
										default:
											Debug.LogError ("unknown: " + ruleSet.matrix [ruleX, ruleY]);
											break;
										}
									}
							}
							// Add
							if (!isPin) {
								ret.AddRange (legalCoords);
							} else {
								// Debug.Log ("isPin, so cannot add: " + this);
							}
						}
					} else {
						Debug.LogError ("Don't have pieceSide: " + board);
					}
				} else {
					Debug.LogError ("why not legal board");
				}
				// remove all not in restricts
				if (this.restrict != null) {
					if (this.restrict.GetLength (0) == board.side.GetLength (0)
					    && this.restrict.GetLength (1) == board.side.GetLength (1)) {
						for (int i = ret.Count - 1; i >= 0; i--) {
							Coord coord = ret [i];
							if (!this.restrict[coord.x, coord.y]) {
								ret.RemoveAt (i);
							}
						}
					} else {
						// Debug.LogError ("restrict not correct side");
					}
				}
			}
			return ret;
		}

	}
}