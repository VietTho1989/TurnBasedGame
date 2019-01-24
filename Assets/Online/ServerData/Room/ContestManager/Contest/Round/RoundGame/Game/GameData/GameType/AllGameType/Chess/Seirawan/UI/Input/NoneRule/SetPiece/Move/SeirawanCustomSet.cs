using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
	public class SeirawanCustomSet : GameMove
	{

		public VP<int> x;

		public VP<int> y;

		public VP<Common.Piece> piece;

		#region Constructor

		public enum Property
		{
			x,
			y,
			piece
		}

		public SeirawanCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.NO_PIECE);
		}

		#endregion

		public override Type getType ()
		{
			return Type.SeirawanCustomSet;
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