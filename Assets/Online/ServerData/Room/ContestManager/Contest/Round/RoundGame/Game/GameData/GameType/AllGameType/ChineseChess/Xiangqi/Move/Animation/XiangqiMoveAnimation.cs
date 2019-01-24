using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiMoveAnimation : MoveAnimation
	{

		public VP<System.UInt32> move;

		public LP<byte> ucpcSquares;

		#region duration

		public VP<float> duration;

		public override void initDuration ()
		{
			// find distance
			int distance = 1;
			{
				Common.MoveStruct moveStruct = new Common.MoveStruct (this.move.v);
				distance = Mathf.Abs (moveStruct.destX - moveStruct.srcX) + Mathf.Abs (moveStruct.destY - moveStruct.srcY);
			}
			// set duration
			this.duration.v = (0.6f + 0.25f * distance) * AnimationManager.DefaultDuration;
		}

		public override float getDuration ()
		{
			return this.duration.v;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			move,
			ucpcSquares,
			duration
		}

		public XiangqiMoveAnimation() : base()
		{
			this.move = new VP<uint> (this, (byte)Property.move, 0);
			this.ucpcSquares = new LP<byte> (this, (byte)Property.ucpcSquares);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.XiangqiMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			XiangqiMove xiangqiMove = new XiangqiMove ();
			{
				xiangqiMove.move.v = this.move.v;
			}
			return xiangqiMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}