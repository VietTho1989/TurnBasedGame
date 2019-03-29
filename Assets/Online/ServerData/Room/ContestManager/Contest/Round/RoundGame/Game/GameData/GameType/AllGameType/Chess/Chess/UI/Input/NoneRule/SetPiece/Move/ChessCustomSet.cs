using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Chess.NoneRule
{
	public class ChessCustomSet : GameMove
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

		public ChessCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.NO_PIECE);
		}

        #endregion

        #region implement base

        public override Type getType ()
		{
			return Type.ChessCustomSet;
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

        #endregion

    }
}