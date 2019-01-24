using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class Variant
	{

		public Common.Rank maxRank = Common.Rank.RANK_8;

		public Common.File maxFile = Common.File.FILE_H;

		public HashSet<Common.PieceType> pieceTypes = new HashSet<Common.PieceType>{ Common.PieceType.PAWN, Common.PieceType.KNIGHT, Common.PieceType.BISHOP, Common.PieceType.ROOK, Common.PieceType.QUEEN, Common.PieceType.KING };

		public string pieceToChar = " PNBRQ" + new string (' ', (int)Common.PieceType.KING - (int)Common.PieceType.QUEEN - 1) + "K" + new string (' ', (int)Common.PieceType.PIECE_TYPE_NB - (int)Common.PieceType.KING - 1)
			+ " pnbrq" + new string (' ', (int)Common.PieceType.KING - (int)Common.PieceType.QUEEN - 1) + "k" + new string (' ', (int)Common.PieceType.PIECE_TYPE_NB - (int)Common.PieceType.KING - 1);

		public string startFen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1";

		public Common.Rank promotionRank = Common.Rank.RANK_8;

		// std::set<PieceType, std::greater<PieceType> > promotionPieceTypes = { QUEEN, ROOK, BISHOP, KNIGHT };
		public HashSet<Common.PieceType> promotionPieceTypes = new HashSet<Common.PieceType>{Common.PieceType.QUEEN, Common.PieceType.ROOK, Common.PieceType.BISHOP, Common.PieceType.KNIGHT};

		public Common.PieceType[] promotedPieceType = new Common.PieceType[(int)Common.PieceType.PIECE_TYPE_NB];

		public bool mandatoryPiecePromotion = false;

		public bool endgameEval = false;

		public bool doubleStep = true;

		public bool castling = true;

		public bool checking = true;

		public bool mustCapture = false;

		public bool pieceDrops = false;

		public bool dropLoop = false;

		public bool capturesToHand = false;

		public bool firstRankDrops = false;

		// game end
		public int stalemateValue = (int)Common.Value.VALUE_DRAW;

		public int checkmateValue = -(int)Common.Value.VALUE_MATE;

		public int bareKingValue = (int)Common.Value.VALUE_NONE;

		public int extinctionValue = (int)Common.Value.VALUE_NONE;

		public bool bareKingMove = false;

		public HashSet<Common.PieceType> extinctionPieceTypes = new HashSet<Common.PieceType>();

		public ulong whiteFlag = 0;

		public ulong blackFlag = 0;

		public bool flagMove = false;

		public int maxCheckCount = 0;

		#region add, remove piece

		private static void ReplaceCharInString(ref string str, int index, char c)
		{
			char[] ch = str.ToCharArray ();
			ch [index] = c;
			str = new string (ch);
		}

		public void add_piece(Common.PieceType pt, char c) {
			ReplaceCharInString (ref pieceToChar, (int)Common.make_piece (Common.Color.WHITE, pt), char.ToUpper (c));
			ReplaceCharInString (ref pieceToChar, (int)Common.make_piece (Common.Color.BLACK, pt), char.ToLower (c));
			pieceTypes.Add (pt);
		}

		public void remove_piece(Common.PieceType pt) {
			ReplaceCharInString (ref pieceToChar, (int)Common.make_piece (Common.Color.WHITE, pt), ' ');
			ReplaceCharInString (ref pieceToChar, (int)Common.make_piece (Common.Color.BLACK, pt), ' ');
			pieceTypes.Remove (pt);
		}

		#endregion

		public void reset_pieces() {
			pieceToChar = new string(' ', (int)Common.Piece.PIECE_NB);
			pieceTypes.Clear();
		}

	}
}