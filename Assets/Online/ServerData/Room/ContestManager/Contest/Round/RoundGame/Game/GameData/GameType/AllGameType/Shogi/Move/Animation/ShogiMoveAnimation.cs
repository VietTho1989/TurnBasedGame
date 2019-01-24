using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class ShogiMoveAnimation : MoveAnimation
	{

		public LP<int> piece;

		public LP<System.UInt32> hand;

		public VP<System.UInt32> move;

		public VP<int> playerIndex;

		#region duration

		public VP<float> duration;

		public const float DropDuration = 1.5f;
		public const float PromotionDuration = 1.5f;

		public override void initDuration ()
		{
			ShogiMove shogiMove = new ShogiMove ();
			{
				shogiMove.move.v = this.move.v;
			}
			if (!shogiMove.isDrop ()) {
				float ret = 0;
				// distance
				{
					Common.Square from = shogiMove.from ();
					Common.Square dest = shogiMove.to ();
					if (from != dest) {
						// from
						Common.File fromFile = Common.makeFile (from);
						Common.File destFile = Common.makeFile (dest);
						// dest
						Common.Rank fromRank = Common.makeRank (from);
						Common.Rank destRank = Common.makeRank (dest);
						// get
						ret += GetDistanceMoveDuration (Mathf.Abs (destFile - fromFile) + Mathf.Abs (destRank - fromRank));
					}
				}
				// promotion
				if (shogiMove.isPromotion () != 0) {
					ret += PromotionDuration * AnimationManager.DefaultDuration;
				}
				// return
				this.duration.v = ret;
			} else {
				this.duration.v = DropDuration * AnimationManager.DefaultDuration;
			}
		}

		public override float getDuration ()
		{
			return this.duration.v;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			piece,
			hand,
			move,
			playerIndex,
			duration
		}

		public ShogiMoveAnimation() : base()
		{
			this.piece = new LP<int> (this, (byte)Property.piece);
			this.hand = new LP<uint> (this, (byte)Property.hand);
			this.move = new VP<uint> (this, (byte)Property.move, 0);
			this.playerIndex = new VP<int> (this, (byte)Property.playerIndex, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.ShogiMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			ShogiMove shogiMove = new ShogiMove ();
			{
				shogiMove.move.v = this.move.v;
			}
			return shogiMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}