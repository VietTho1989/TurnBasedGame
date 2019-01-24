using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiMoveAnimation : MoveAnimation
	{

		public VP<sbyte> fromX;

		public VP<sbyte> fromY;

		public VP<sbyte> toX;

		public VP<sbyte> toY;

		public LP<uint> stones;

		#region duration

		public VP<float> duration;

		public override void initDuration ()
		{
			// find distance
			int distance = 1;
			{
				distance = Mathf.Abs (this.toX.v - this.fromX.v) + Mathf.Abs (this.toY.v - this.fromY.v);
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
			fromX,
			fromY,
			toX,
			toY,
			stones,
			duration
		}

		public JanggiMoveAnimation() : base()
		{
			this.fromX = new VP<sbyte> (this, (byte)Property.fromX, 0);
			this.fromY = new VP<sbyte> (this, (byte)Property.fromY, 0);
			this.toX = new VP<sbyte> (this, (byte)Property.toX, 0);
			this.toY = new VP<sbyte> (this, (byte)Property.toY, 0);
			this.stones = new LP<uint> (this, (byte)Property.stones);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.JanggiMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{

		}

		public override GameMove makeGameMove ()
		{
			JanggiMove janggiMove = new JanggiMove ();
			{
				janggiMove.fromX.v = this.fromX.v;
				janggiMove.fromY.v = this.fromY.v;
				janggiMove.toX.v = this.toX.v;
				janggiMove.toY.v = this.toY.v;
			}
			return janggiMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}