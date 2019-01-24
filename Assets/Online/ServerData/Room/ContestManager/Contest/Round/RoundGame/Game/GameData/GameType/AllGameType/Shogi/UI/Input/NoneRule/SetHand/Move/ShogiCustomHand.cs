using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
	public class ShogiCustomHand : GameMove
	{

		public VP<Common.HandPiece> handPiece;

		public VP<Common.Color> color;

		public VP<int> pieceCount;

		#region Constructor

		public enum Property
		{
			handPiece,
			color,
			pieceCount
		}

		public ShogiCustomHand() : base()
		{
			this.handPiece = new VP<Common.HandPiece> (this, (byte)Property.handPiece, Common.HandPiece.HBishop);
			this.color = new VP<Common.Color> (this, (byte)Property.color, Common.Color.Black);
			this.pieceCount = new VP<int> (this, (byte)Property.pieceCount, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.ShogiCustomHand;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return "ShogiCustomHand: " + this.handPiece.v + "; " + this.color.v + "; " + this.pieceCount.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}