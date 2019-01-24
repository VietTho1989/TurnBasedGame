using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX.NoneRule
{
	public class HexCustomMove : GameMove
	{

		public VP<ushort> from;

		public VP<ushort> dest;

		#region Constructor

		public enum Property
		{
			from,
			dest
		}

		public HexCustomMove() : base()
		{
			this.from = new VP<ushort> (this, (byte)Property.from, 0);
			this.dest = new VP<ushort> (this, (byte)Property.dest, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.HexCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("HexCustomMove: {0}, {1}", this.from.v, this.dest.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}