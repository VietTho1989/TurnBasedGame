using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
	public class SeirawanCustomHand : GameMove
	{

		public VP<Common.Piece> piece;

		#region Constructor

		public enum Property
		{
			piece
		}

		public SeirawanCustomHand() : base()
		{
			this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.B_ELEPHANT);
		}

		#endregion

		public override Type getType ()
		{
			return Type.SeirawanCustomHand;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return "SeirawanCustomHand: " + this.piece.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}