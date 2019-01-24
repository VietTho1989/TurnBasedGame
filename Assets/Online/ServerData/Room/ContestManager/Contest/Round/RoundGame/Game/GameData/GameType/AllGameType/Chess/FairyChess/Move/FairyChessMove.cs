using UnityEngine;
using System.Collections;

namespace FairyChess
{
	public class FairyChessMove : GameMove
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
				this.ori = Common.from_sq((Common.Move)m);
				this.dest = Common.to_sq((Common.Move)m);
				this.promotion = Common.promotion_type((Common.Move)m);
				this.type =  Common.type_of((Common.Move)m);
			}

			public override string ToString ()
			{
				return string.Format ("[Move: {0}, {1},{2}, {3}]", ori, dest, promotion, type);
			}
		}

		public static void GetClickPosition(int fairyChessMove, out int fromX, out int fromY, out int destX, out int destY)
		{
			Move move = new Move (fairyChessMove);
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

		public static bool IsClickCorrectPosition(int fairyChessMove, int fromX, int fromY, int destX, int destY){
			int moveFromX = 0;
			int moveFromY = 0;
			int moveDestX = 0;
			int moveDestY = 0;
			GetClickPosition (fairyChessMove, out moveFromX, out moveFromY, out moveDestX, out moveDestY);
			return fromX == moveFromX && fromY == moveFromY && destX == moveDestX && destY == moveDestY;
		}

		#endregion

		public VP<int> move;

		public VP<string> strMove;

		#region Constructor

		public enum Property
		{
			move,
			strMove
		}

		public FairyChessMove() : base()
		{
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.strMove = new VP<string> (this, (byte)Property.strMove, "");
		}

		#endregion

		public override Type getType ()
		{
			return GameMove.Type.FairyChessMove;
		}

		public override string print ()
		{
			return this.strMove.v;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is FairyChess) {
				FairyChess fairyChess = gameType as FairyChess;
				// Make animation
				FairyChessMoveAnimation fairyChessMoveAnimation = new FairyChessMoveAnimation ();
				{
					// board
					fairyChessMoveAnimation.board.vs.AddRange (fairyChess.board.vs);
					// pieceCountInHand
					fairyChessMoveAnimation.pieceCountInHand.vs.AddRange (fairyChess.pieceCountInHand.vs);
					// move
					fairyChessMoveAnimation.move.v = this.move.v;
				}
				return fairyChessMoveAnimation;
			} else {
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			if (gameType is FairyChess) {
				FairyChess fairyChess = gameType as FairyChess;
				// get inform
				this.strMove.v = Core.unityGetStrMove (fairyChess, Core.CanCorrect, this.move.v);
			} else {
				Debug.LogError ("why gameType not fairyChess: " + gameType);
			}
		}

	}
}