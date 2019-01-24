using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Chess.NoneRule
{
	public class ChessCustomMove : GameMove
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

		public ChessCustomMove() : base()
		{
			this.fromX = new VP<int> (this, (byte)Property.fromX, 0);
			this.fromY = new VP<int> (this, (byte)Property.fromY, 0);
			this.destX = new VP<int> (this, (byte)Property.destX, 0);
			this.destY = new VP<int> (this, (byte)Property.destY, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.ChessCustomMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("ChessCustomMove: {0}, {1}, {2}, {3}", this.fromX.v, this.fromY.v, this.destX.v, this.destY.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}