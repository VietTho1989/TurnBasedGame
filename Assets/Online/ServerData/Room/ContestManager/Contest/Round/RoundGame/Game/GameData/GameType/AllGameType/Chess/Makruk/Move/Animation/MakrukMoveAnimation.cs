using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
{
	public class MakrukMoveAnimation : MoveAnimation
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
				MakrukMove.Move move = new MakrukMove.Move (this.move.v);
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

		public MakrukMoveAnimation() : base()
		{
			this.board = new LP<int> (this, (byte)Property.board);
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.chess960 = new VP<bool> (this, (byte)Property.chess960, false);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		public override GameMove.Type getType ()
		{
			return GameMove.Type.MakrukMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			MakrukMove makrukMove = new MakrukMove ();
			{
				makrukMove.move.v = this.move.v;
				makrukMove.chess960.v = this.chess960.v;
			}
			return makrukMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

	}
}