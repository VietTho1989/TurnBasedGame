using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi.NoneRule
{
	public class WeiqiCustomMove : GameMove
	{

		public VP<int> from;

		public VP<int> dest;

		#region Constructor

		public enum Property
		{
			from,
			dest
		}

		public WeiqiCustomMove() : base()
		{
			this.from = new VP<int> (this, (byte)Property.from, 0);
			this.dest = new VP<int> (this, (byte)Property.dest, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.WeiqiCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("WeiqiCustomMove: {0}, {1}", this.from.v, this.dest.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}