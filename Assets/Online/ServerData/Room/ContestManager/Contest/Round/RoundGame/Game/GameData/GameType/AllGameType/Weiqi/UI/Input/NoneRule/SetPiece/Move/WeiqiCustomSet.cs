using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi.NoneRule
{
	public class WeiqiCustomSet : GameMove
	{

		public VP<int> coord;

		public VP<Common.stone> piece;

		#region Constructor

		public enum Property
		{
			coord,
			piece
		}

		public WeiqiCustomSet() : base()
		{
			this.coord = new VP<int> (this, (byte)Property.coord, 0);
			this.piece = new VP<Common.stone> (this, (byte)Property.piece, Common.stone.S_BLACK);
		}

		#endregion

		public override Type getType ()
		{
			return Type.WeiqiCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("({0}, {1})", this.coord.v, this.piece.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}