using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet.NoneRule
{
	public class KhetCustomMove : GameMove
	{

		public VP<int> from;

		public VP<int> dest;

		#region Constructor

		public enum Property
		{
			from,
			dest
		}

		public KhetCustomMove() : base()
		{
			this.from = new VP<int> (this, (byte)Property.from, 0);
			this.dest = new VP<int> (this, (byte)Property.dest, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.KhetCusomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Khet) {
				return null;
			} else {
				Debug.LogError ("why not khet: " + gameType);
				return null;
			}
		}

		public override string print()
		{
			return "KhetCustomMove: " + this.from.v + ", " + this.dest.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}