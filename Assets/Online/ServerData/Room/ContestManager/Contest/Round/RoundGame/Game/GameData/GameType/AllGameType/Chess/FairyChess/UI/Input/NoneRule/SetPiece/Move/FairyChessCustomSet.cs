using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
	public class FairyChessCustomSet : GameMove
	{

		public VP<int> x;

		public VP<int> y;

		public VP<Common.Color> color;

		public VP<Common.PieceType> pieceType;

		#region Constructor

		public enum Property
		{
			x,
			y,
			color,
			pieceType
		}

		public FairyChessCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.color = new VP<Common.Color> (this, (byte)Property.color, Common.Color.WHITE);
			this.pieceType = new VP<Common.PieceType> (this, (byte)Property.pieceType, Common.PieceType.BISHOP);
		}

		#endregion

		public override Type getType ()
		{
			return Type.FairyChessCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1}, {2}, {3})", this.x.v, this.y.v, this.color.v, this.pieceType.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}