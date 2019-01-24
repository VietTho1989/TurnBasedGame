using UnityEngine;
using System.Collections;

namespace Chess
{
	public class ChessMove : GameMove
	{

		#region Move Structure

		/// A move needs 16 bits to be stored
		///
		/// bit  0- 5: destination square (from 0 to 63)
		/// bit  6-11: origin square (from 0 to 63)
		/// bit 12-13: promotion piece type - 2 (from KNIGHT-2 to QUEEN-2)
		/// bit 14-15: special move flag: promotion (1), en passant (2), castling (3)
		/// NOTE: EN-PASSANT bit is set only when a pawn can be captured
		///
		/// Special cases are MOVE_NONE and MOVE_NULL. We can sneak these in because in
		/// any normal move destination square is always different from origin square
		/// while MOVE_NONE and MOVE_NULL have the same origin and destination square.

		public struct Move
		{
			public Common.Square ori;
			public Common.Square dest;
			public Common.PieceType promotion;
			public Common.MoveType type;

			public Move(int m)
			{
				this.ori = from_sq(m);
				this.dest = to_sq(m);
				this.promotion = promotion_type(m);
				this.type = type_of(m);
			}

			public override string ToString ()
			{
				return string.Format ("[Move: {0}, {1},{2}, {3}]", ori, dest, promotion, type);
			}

		}

		public static Common.Square from_sq(int m) {
			return (Common.Square)((m >> 6) & 0x3F);
		}

		public static Common.Square to_sq(int m) {
			return (Common.Square)(m & 0x3F);
		}

		public static Common.MoveType type_of(int m) {
			return (Common.MoveType)(m & (3 << 14));
		}

		public static Common.PieceType promotion_type(int m) {
			return (Common.PieceType)(((m >> 12) & 3) + Common.PieceType.KNIGHT);
		}

		public static void GetClickPosition(int chessMove, out int fromX, out int fromY, out int destX, out int destY)
		{
			Move move = new Move (chessMove);
			fromX = (int)move.ori % 8;
			fromY = (int)move.ori / 8;
			if (move.type != Common.MoveType.CASTLING) {
				destX = (int)move.dest % 8;
				destY = (int)move.dest / 8;
			} else {
				{
					int normalDestX = (int)move.dest % 8;
					if (normalDestX > fromX) {
						destX = 6;
					} else {
						destX = 2;
					}
				}
				destY = (int)move.dest / 8;
			}
			// TODO Chess960 chua check
			{
				// TODO Can hoan thien
			}
		}

		public static bool IsClickCorrectPosition(int chessMove, int fromX, int fromY, int destX, int destY){
			int moveFromX = 0;
			int moveFromY = 0;
			int moveDestX = 0;
			int moveDestY = 0;
			GetClickPosition (chessMove, out moveFromX, out moveFromY, out moveDestX, out moveDestY);
			return fromX == moveFromX && fromY == moveFromY && destX == moveDestX && destY == moveDestY;
		}

		#endregion

		public VP<int> move;

		public VP<bool> chess960;

		#region Constructor

		public enum Property
		{
			move,
			chess960
		}

		public ChessMove() : base()
		{
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.chess960 = new VP<bool> (this, (byte)Property.chess960, false);
		}

		#endregion

		public override Type getType ()
		{
			return GameMove.Type.ChessMove;
		}

		public override string print ()
		{
			return Common.moveToString (this.move.v, this.chess960.v);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Chess) {
				Chess chess = gameType as Chess;
				// Make animation
				ChessMoveAnimation chessMoveAnimation = new ChessMoveAnimation();
				{
					chessMoveAnimation.board.vs.AddRange (chess.board.vs);
					chessMoveAnimation.move.v = this.move.v;
					chessMoveAnimation.chess960.v = this.chess960.v;
				}
				return chessMoveAnimation;
			} else {
				Debug.LogError ("why gameType isn't chess: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			if (gameType is Chess) {
				Chess chess = gameType as Chess;
				// get inform
				this.chess960.v = chess.chess960.v;
			} else {
				Debug.LogError ("why gameType not chess: " + gameType);
			}
		}
			
	}
}