using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku.NoneRule
{
	public class GomokuCustomSet : GameMove
	{

		public VP<int> square;

		public VP<Common.Type> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public GomokuCustomSet() : base()
		{
			this.square = new VP<int> (this, (byte)Property.square, 0);
			this.piece = new VP<Common.Type> (this, (byte)Property.piece, Common.Type.None);
		}

		#endregion

		public override Type getType ()
		{
			return Type.GomokuCustomSet;
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