using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX.NoneRule
{
	public class HexCustomSet : GameMove
	{

		public VP<ushort> square;

		public VP<Common.Color> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public HexCustomSet() : base()
		{
			this.square = new VP<ushort> (this, (byte)Property.square, 0);
			this.piece = new VP<Common.Color> (this, (byte)Property.piece, Common.Color.Empty);
		}

		#endregion

		public override Type getType ()
		{
			return Type.HexCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1})", this.square.v, this.piece.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}