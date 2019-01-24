using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi.NoneRule
{
	public class XiangqiCustomMove : GameMove
	{

		public VP<int> fromX;

		public VP<int> fromY;

		public VP<int> destX;

		public VP<int> destY;

		#region Constructor

		public enum Property
		{
			fromX,
			fromY,
			destX,
			destY
		}

		public XiangqiCustomMove() : base()
		{
			this.fromX = new VP<int> (this, (byte)Property.fromX, 0);
			this.fromY = new VP<int> (this, (byte)Property.fromY, 0);
			this.destX = new VP<int> (this, (byte)Property.destX, 0);
			this.destY = new VP<int> (this, (byte)Property.destY, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.XiangqiCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("XiangqiCustomMove: {0}, {1}, {2}, {3}", this.fromX.v, this.fromY.v, this.destX.v, this.destY.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}