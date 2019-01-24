using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
	public class TestCoTuongUp
	{

		private void testFlip()
		{
			// RedKing
			{
				byte piece = Common.K;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// RedAdvisor
			{
				byte piece = Common.A;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// RedElephant
			{
				byte piece = Common.B;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// RedChariot
			{
				byte piece = Common.R;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// RedCannon
			{
				byte piece = Common.C;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// RedHorse
			{
				byte piece = Common.N;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// RedPawn
			{
				byte piece = Common.P;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}

			// HideRedGeneral
			{
				byte piece = Common.HK;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideRedAdvisor
			{
				byte piece = Common.HA;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideRedElephant
			{
				byte piece = Common.HB;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideRedChariot
			{
				byte piece = Common.HR;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideRedCannon
			{
				byte piece = Common.HC;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideRedHorse
			{
				byte piece = Common.HN;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideRedPawn
			{
				byte piece = Common.HP;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}

			// BlackGeneral
			{
				byte piece = Common.k;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// BlackAdvisor
			{
				byte piece = Common.a;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// BlackElephant
			{
				byte piece = Common.b;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// BlackChariot
			{
				byte piece = Common.r;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// BlackCannon
			{
				byte piece = Common.c;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// BlackHorse
			{
				byte piece = Common.n;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// BlackPawn
			{
				byte piece = Common.p;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}

			// HideBlackGeneral
			{
				byte piece = Common.hk;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideBlackAdvisor
			{
				byte piece = Common.ha;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideBlackElephant
			{
				byte piece = Common.hb;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideBlackChariot
			{
				byte piece = Common.hr;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideBlackCannon
			{
				byte piece = Common.hc;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideBlackHorse
			{
				byte piece = Common.hn;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
			// HideBlackPawn
			{
				byte piece = Common.hp;
				Debug.LogError (string.Format ("flip {0} to {1}", Common.convert.convert (piece), 
					Common.convert.convert (Common.Visibility.flip (piece))));
			}
		}

		#region testGetAllLegalMoves

		private void testGetAllLegalMoves()
		{
			CoTuongUp coTuongUp = null;
			{
				DefaultCoTuongUp defaultCoTuongUp = new DefaultCoTuongUp ();
				coTuongUp = (CoTuongUp)defaultCoTuongUp.makeDefaultGameType ();
			}
			List<Rules.Move> legalMoves = Rule.getAllLegalMoves (coTuongUp, false);
			// print
			{
				Board board = Rule.getBoard (coTuongUp);
				for (byte x = 0; x < 9; x++)
					for (byte y = 0; y < 10; y++) {
						if (board.side [x, y] == coTuongUp.side.v) {
							List<Rules.Coord> legalCoords = new List<Rules.Coord> ();
							{
								for (int i = 0; i < legalMoves.Count; i++) {
									Rules.Move move = legalMoves [i];
									if (move.from.x == x && move.from.y == y) {
										legalCoords.Add (move.dest);
									}
								}
							}
							Debug.LogError (string.Format ("LegalMoves: {0}, {1}:\n{2}", x, y, board.convertToString (Common.convert, legalCoords)));
						}
					}
			}
		}

		#endregion

		#region testCheck

		private void testCheck()
		{
			CoTuongUp coTuongUp = new CoTuongUp ();
			{
				{
					DefaultCoTuongUp defaultCoTuongUp = new DefaultCoTuongUp ();
					coTuongUp = (CoTuongUp)defaultCoTuongUp.makeDefaultGameType ();
				}
				// Cho them quan co de check
				if (coTuongUp.nodes.vs.Count > 0) {
					Node node = coTuongUp.nodes.vs [coTuongUp.nodes.vs.Count - 1];
					node.setPieceByCoord (Common.makeCoord (3, 2), Common.N);
				}
			}
			Debug.LogError (Common.printPosition (coTuongUp));
			Debug.LogError ("isCheck: red side: " + Rule.isCheckingOpponent (coTuongUp, Common.Side.Red));
			Debug.LogError ("isCheck: black side: " + Rule.isCheckingOpponent (coTuongUp, Common.Side.Black));
		}

		#endregion

		private void testRule()
		{
			CoTuongUp coTuongUp = new CoTuongUp ();
			{
				DefaultCoTuongUp defaultCoTuongUp = new DefaultCoTuongUp ();
				coTuongUp = (CoTuongUp)defaultCoTuongUp.makeDefaultGameType ();
			}
			Board board = Rule.getBoard (coTuongUp);
			// Debug.LogError (board.convertToString (Common.convert));
			// rotate
			/*{
				Rule.rotateBoard (board, Common.Side.Black);
				Debug.LogError (board.convertToString (Common.convert));
			}*/
			// get legal coord
			{
				// Pawn
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.PawnRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: PawnRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// PromotedPawn
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.PromotedPawnRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: PromotedPawnRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// KnightRule
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.KnightRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: KnightRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// BishopRule
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.BishopRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: BishopRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// AdvisorRule
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.AdvisorRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: AdvisorRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// Cannon
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.CannonRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: CannonRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// Rook
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 1;
						pieceCoord.y = 7;
					}
					List<Rules.Coord> legalCoords = RuleList.RookRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: RookRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
				// KingRule
				{
					Rules.Coord pieceCoord = new Rules.Coord ();
					{
						pieceCoord.x = 5;
						pieceCoord.y = 9;
					}
					List<Rules.Coord> legalCoords = RuleList.KingRule.getLegalCoords (board, pieceCoord);
					Debug.LogError ("find legalCoords: KingRule: " + legalCoords.Count);
					Debug.LogError (board.convertToString (Common.convert, legalCoords));
				}
			}
		}

		private void testInitDefault ()
		{
			CoTuongUp coTuongUp = new CoTuongUp ();
			{
				DefaultCoTuongUp defaultCoTuongUp = new DefaultCoTuongUp ();
				coTuongUp = (CoTuongUp)defaultCoTuongUp.makeDefaultGameType ();
			}
			Debug.LogError (Common.printPosition (coTuongUp));
		}

		private void testPiece()
		{
			{
				byte piece = Common.x;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.K;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.A;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.B;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.R;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.C;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.N;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.P;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
				
			{
				byte piece = Common.HK;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.HA;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.HB;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.HR;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.HC;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.HN;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.HP;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
				
			{
				byte piece = Common.k;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.a;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.b;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.r;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.c;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.n;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.p;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
				
			{
				byte piece = Common.hk;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.ha;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.hb;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.hr;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.hc;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.hn;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}
			{
				byte piece = Common.hp;
				Debug.LogError ("piece: " + piece + "; strPiece: " + Common.getStrPiece (piece)
					+ "; Side: " + Common.getStrSide (Common.getPieceSide (piece))
					+ "; PieceType: " + Common.PieceType.getStrPieceType (Common.getPieceType (piece)));
			}

		}

	}
}