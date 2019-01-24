using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.NoneRule
{
	public class EnglishDraughtCustomSet : GameMove
	{

		public VP<int> square;

		public VP<byte> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public EnglishDraughtCustomSet() : base()
		{
			this.square = new VP<int> (this, (byte)Property.square, 0);
			this.piece = new VP<byte> (this, (byte)Property.piece, Common.BKING);
		}

		#endregion

		public override Type getType ()
		{
			return Type.EnglishDraughtCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1}, {2})", this.square.v, this.piece.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}