using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught.NoneRule
{
	public class RussianDraughtCustomSet : GameMove
	{

		public VP<int> square;

		public VP<int> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public RussianDraughtCustomSet() : base()
		{
			this.square = new VP<int> (this, (byte)Property.square, 0);
			this.piece = new VP<int> (this, (byte)Property.piece, Common.FREE);
		}

		#endregion

		public override Type getType ()
		{
			return Type.RussianDraughtCustomSet;
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