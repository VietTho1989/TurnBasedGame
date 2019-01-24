using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi.NoneRule
{
	public class JanggiCustomSet : GameMove
	{

		public VP<int> x;

		public VP<int> y;

		public VP<StoneHelper.Stones> piece;

		#region Constructor

		public enum Property
		{
			x,
			y,
			piece
		}

		public JanggiCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.piece = new VP<StoneHelper.Stones> (this, (byte)Property.piece, StoneHelper.Stones.Empty);
		}

		#endregion

		public override Type getType ()
		{
			return Type.JanggiCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("Janggi Custom Set ({0}, {1}, {2})", this.x.v, this.y.v, this.piece.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}