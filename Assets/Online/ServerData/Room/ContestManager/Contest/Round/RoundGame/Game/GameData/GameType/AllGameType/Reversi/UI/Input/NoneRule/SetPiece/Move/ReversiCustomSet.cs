using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reversi.NoneRule
{
	public class ReversiCustomSet : GameMove
	{

		public VP<sbyte> square;

		public VP<int> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public ReversiCustomSet() : base()
		{
			this.square = new VP<sbyte> (this, (byte)Property.square, 0);
			this.piece = new VP<int> (this, (byte)Property.piece, Reversi.NONE);
		}

		#endregion

		public override Type getType ()
		{
			return Type.ReversiCustomSet;
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