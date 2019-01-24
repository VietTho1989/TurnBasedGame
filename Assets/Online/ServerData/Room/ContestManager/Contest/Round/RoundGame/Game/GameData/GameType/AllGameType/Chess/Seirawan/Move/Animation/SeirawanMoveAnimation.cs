using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
	public class SeirawanMoveAnimation : MoveAnimation
	{

		public LP<int> board;

		public LP<bool> inHand;

		public VP<int> move;

		public VP<bool> chess960;

		#region duration

		public VP<float> duration;

		public const float PromotionDuration = 3f;

		public static float GetNormalChessDuration(int myMove){
			float duration = 1*AnimationManager.DefaultDuration;
			{
				SeirawanMove.Move move = new SeirawanMove.Move (myMove);
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
					Debug.LogError ("unknown moveType: " + move.type);
					break;
				}
			}
			return duration;
		}

		public const float SeirawanDuration = 3f;

		public override void initDuration ()
		{
			float duration = GetNormalChessDuration (this.move.v);
			// add seirawan duration?
			{
				if (Common.is_gating (this.move.v)) {
					duration += SeirawanDuration * AnimationManager.DefaultDuration;
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
			inHand,
			move,
			chess960,
			duration
		}

		public SeirawanMoveAnimation() : base()
		{
			this.board = new LP<int> (this, (byte)Property.board);
			this.inHand = new LP<bool> (this, (byte)Property.inHand);
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.chess960 = new VP<bool> (this, (byte)Property.chess960, false);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		public override GameMove.Type getType ()
		{
			return GameMove.Type.SeirawanMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			SeirawanMove seirawanMove = new SeirawanMove ();
			{
				seirawanMove.move.v = this.move.v;
				seirawanMove.chess960.v = this.chess960.v;
			}
			return seirawanMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

	}
}