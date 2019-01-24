using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
	public class FairyChessCustomHand : GameMove
	{

		public VP<Common.Color> color;

		public VP<Common.PieceType> pieceType;

		public VP<int> pieceCount;

		#region Constructor

		public enum Property
		{
			color,
			pieceType,
			pieceCount
		}

		public FairyChessCustomHand() : base()
		{
			this.color = new VP<Common.Color> (this, (byte)Property.color, Common.Color.WHITE);
			this.pieceType = new VP<Common.PieceType> (this, (byte)Property.pieceType, Common.PieceType.BISHOP);
			this.pieceCount = new VP<int> (this, (byte)Property.pieceCount, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.FairyChessCustomHand;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return "FairyChessCustomHand: " + this.color.v + "; " + this.pieceType.v + "; " + this.pieceCount.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}