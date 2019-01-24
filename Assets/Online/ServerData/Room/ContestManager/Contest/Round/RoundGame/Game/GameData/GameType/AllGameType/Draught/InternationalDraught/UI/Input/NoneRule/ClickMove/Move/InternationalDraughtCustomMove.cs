using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
	public class InternationalDraughtCustomMove : GameMove
	{

		public VP<int> fromSquare;

		public VP<int> destSquare;

		#region Constructor

		public enum Property
		{
			fromSquare,
			destSquare
		}

		public InternationalDraughtCustomMove() : base()
		{
			this.fromSquare = new VP<int> (this, (byte)Property.fromSquare, 0);
			this.destSquare = new VP<int> (this, (byte)Property.destSquare, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.InternationalDraughtCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("InternationalDraughtCustomMove: {0}, {1}", this.fromSquare.v, this.destSquare.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}