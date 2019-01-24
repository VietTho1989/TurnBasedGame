using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper.NoneRule
{
	public class MineSweeperCustomSet : GameMove
	{

		public VP<int> square;

		public VP<sbyte> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public MineSweeperCustomSet() : base()
		{
			this.square = new VP<int> (this, (byte)Property.square, 0);
			this.piece = new VP<sbyte> (this, (byte)Property.piece, -1);
		}

		#endregion

		public override Type getType ()
		{
			return Type.MineSweeperCustomSet;
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