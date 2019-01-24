using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
	public class ChessMoveAnimation : MoveAnimation
	{

		/**Piece board[SQUARE_NB];*/
		public LP<int> board;

		public VP<int> move;

		public VP<bool> chess960;

		#region duration

		public VP<float> duration;

		public const float PromotionDuration = 3f;

		public override void initDuration()
		{
			// find distance
			float duration = 1*AnimationManager.DefaultDuration;
			{
				ChessMove.Move move = new ChessMove.Move (this.move.v);
				switch (move.type) {
				case Common.MoveType.NORMAL:
					{
						int distance = Common.GetDistance (move.ori, move.dest);
						duration = GetDistanceMoveDuration (distance);
					}
					break;
				case Common.MoveType.PROMOTION:
					{
						int distance = Common.GetDistance (move.ori, move.dest);
						duration = GetDistanceMoveDuration (distance) + PromotionDuration * AnimationManager.DefaultDuration;
					}
					break;
				case Common.MoveType.CASTLING:
					{
						duration = GetDistanceMoveDuration (2);
					}
					break;
				case Common.MoveType.ENPASSANT:
					{
						duration = GetDistanceMoveDuration (2);
					}
					break;
				default:
					Debug.LogError ("unknown moveType: " + move.type + "; " + this);
					break;
				}
			}
			// set duration
			this.duration.v = duration;
		}

		public override float getDuration ()
		{
			return this.duration.v;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			board,
			move,
			chess960,
			duration
		}

		public ChessMoveAnimation() : base()
		{
			this.board = new LP<int> (this, (byte)Property.board);
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.chess960 = new VP<bool> (this, (byte)Property.chess960, false);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		public override GameMove.Type getType ()
		{
			return GameMove.Type.ChessMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{

		}

		public override GameMove makeGameMove ()
		{
			ChessMove chessMove = new ChessMove ();
			{
				chessMove.move.v = this.move.v;
				chessMove.chess960.v = this.chess960.v;
			}
			return chessMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

	}
}