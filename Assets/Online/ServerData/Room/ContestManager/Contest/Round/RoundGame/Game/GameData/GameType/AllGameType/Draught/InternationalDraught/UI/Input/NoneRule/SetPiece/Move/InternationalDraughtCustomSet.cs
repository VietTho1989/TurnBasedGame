using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
	public class InternationalDraughtCustomSet : GameMove
	{

		public VP<int> square;

		public VP<Common.Piece_Side> pieceSide;

		#region Constructor

		public enum Property
		{
			square,
			pieceSide
		}

		public InternationalDraughtCustomSet() : base()
		{
			this.square = new VP<int> (this, (byte)Property.square, 0);
			this.pieceSide = new VP<Common.Piece_Side> (this, (byte)Property.pieceSide, Common.Piece_Side.Empty);
		}

		#endregion

		public override Type getType ()
		{
			return Type.InternationalDraughtCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1})", this.square.v, this.pieceSide.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}