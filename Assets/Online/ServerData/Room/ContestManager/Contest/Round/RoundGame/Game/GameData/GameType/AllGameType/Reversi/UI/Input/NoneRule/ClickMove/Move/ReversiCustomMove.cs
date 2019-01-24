using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reversi.NoneRule
{
	public class ReversiCustomMove : GameMove
	{

		public VP<sbyte> from;

		public VP<sbyte> dest;

		#region Constructor

		public enum Property
		{
			from,
			dest
		}

		public ReversiCustomMove() : base()
		{
			this.from = new VP<sbyte> (this, (byte)Property.from, 0);
			this.dest = new VP<sbyte> (this, (byte)Property.dest, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.ReversiCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("ReversiCustomMove: {0}, {1}", this.from.v, this.dest.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}