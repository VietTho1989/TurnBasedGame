using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class CoTuongUpCustomMove : GameMove
	{

		public VP<byte> from;

		public VP<byte> dest;

		#region Constructor

		public enum Property
		{
			from,
			dest
		}

		public CoTuongUpCustomMove() : base()
		{
			this.from = new VP<byte> (this, (byte)Property.from, 0);
			this.dest = new VP<byte> (this, (byte)Property.dest, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.CoTuongUpCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("CoTuongUpCustomMove: {0}, {1}", this.from.v, this.dest.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}