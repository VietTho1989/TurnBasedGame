using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class CoTuongUpCustomSet : GameMove
	{

		public VP<byte> coord;

		public VP<byte> piece;

		#region Constructor

		public enum Property
		{
			coord,
			piece
		}

		public CoTuongUpCustomSet() : base()
		{
			this.coord = new VP<byte> (this, (byte)Property.coord, 0);
			this.piece = new VP<byte> (this, (byte)Property.piece, Common.x);
		}

		#endregion

		public override Type getType ()
		{
			return Type.CoTuongUpCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1})", this.coord.v, this.piece.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}