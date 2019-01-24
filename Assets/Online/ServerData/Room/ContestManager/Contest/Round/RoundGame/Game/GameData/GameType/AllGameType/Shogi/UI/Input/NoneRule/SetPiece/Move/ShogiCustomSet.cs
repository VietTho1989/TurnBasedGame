using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ShogiCustomSet : GameMove
	{

		public VP<Common.Square> square;

		public VP<Common.Piece> piece;

		#region Constructor

		public enum Property
		{
			square,
			piece
		}

		public ShogiCustomSet() : base()
		{
			this.square = new VP<Common.Square> (this, (byte)Property.square, Common.Square.SQ11);
			this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.BBishop);
		}

		#endregion

		public override Type getType ()
		{
			return Type.ShogiCustomSet;
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