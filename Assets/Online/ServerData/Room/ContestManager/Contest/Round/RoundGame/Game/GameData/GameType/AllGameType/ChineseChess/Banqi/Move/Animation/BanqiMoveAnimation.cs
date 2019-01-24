using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiMoveAnimation : MoveAnimation
	{

		public VP<int> fromX;

		public VP<int> fromY;

		public VP<int> destX;

		public VP<int> destY;

		public VP<string> state;

		#region duration

		public VP<float> duration;

		public override void initDuration ()
		{
			if (this.fromX.v != this.destX.v || this.fromY.v != this.destY.v) {
				// find distance
				int distance = 1;
				{
					distance = Mathf.Abs (this.destX.v - this.fromX.v) + Mathf.Abs (this.destY.v - this.fromY.v);
				}
				// set duration
				this.duration.v = (0.6f + 0.25f * distance) * AnimationManager.DefaultDuration;
			} else {
				this.duration.v = 3 * AnimationManager.DefaultDuration;
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
			fromX,
			fromY,
			destX,
			destY,
			state,
			duration
		}

		public BanqiMoveAnimation() : base()
		{
			this.fromX = new VP<int> (this, (byte)Property.fromX, 0);
			this.fromY = new VP<int> (this, (byte)Property.fromY, 0);
			this.destX = new VP<int> (this, (byte)Property.destX, 0);
			this.destY = new VP<int> (this, (byte)Property.destY, 0);
			this.state = new VP<string> (this, (byte)Property.state, "");
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.BanqiMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{

		}

		public override GameMove makeGameMove ()
		{
			BanqiMove banqiMove = new BanqiMove ();
			{
				banqiMove.fromX.v = this.fromX.v;
				banqiMove.fromY.v = this.fromY.v;
				banqiMove.destX.v = this.destX.v;
				banqiMove.destY.v = this.destY.v;
			}
			return banqiMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}