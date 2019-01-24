using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ShogiCustomMove : GameMove
	{

		public VP<Common.Square> from;

		public VP<Common.Square> dest;

		#region Constructor

		public enum Property
		{
			from,
			dest
		}

		public ShogiCustomMove() : base()
		{
			this.from = new VP<Common.Square> (this, (byte)Property.from, Common.Square.SQ11);
			this.dest = new VP<Common.Square> (this, (byte)Property.dest, Common.Square.SQ11);
		}

		#endregion

		public override Type getType()
		{
			return Type.ShogiCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("ShogiCustomMove: {0}, {1}", this.from.v, this.dest.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}