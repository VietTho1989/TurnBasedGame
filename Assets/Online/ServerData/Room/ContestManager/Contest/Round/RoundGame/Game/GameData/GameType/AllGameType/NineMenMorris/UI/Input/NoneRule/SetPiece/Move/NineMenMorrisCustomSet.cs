using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.NoneRule
{
	public class NineMenMorrisCustomSet : GameMove
	{

		public VP<int> x;

		public VP<int> y;

		public VP<Common.SpotStatus> piece;

		#region Constructor

		public enum Property
		{
			x,
			y,
			piece
		}

		public NineMenMorrisCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.piece = new VP<Common.SpotStatus> (this, (byte)Property.piece, Common.SpotStatus.SS_Empty);
		}

		#endregion

		public override Type getType ()
		{
			return Type.NineMenMorrisCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1}, {2})", this.x.v, this.y.v, this.piece.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}