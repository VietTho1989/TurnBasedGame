using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi.NoneRule
{
	public class XiangqiCustomSet : GameMove
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

		public XiangqiCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.None);
		}

		#endregion

		public override Type getType ()
		{
			return Type.XiangqiCustomSet;
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

	}
}