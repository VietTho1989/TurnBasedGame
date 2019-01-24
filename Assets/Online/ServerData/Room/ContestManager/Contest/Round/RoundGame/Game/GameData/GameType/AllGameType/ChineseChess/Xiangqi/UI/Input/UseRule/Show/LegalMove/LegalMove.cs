using UnityEngine;
using System.Collections;

namespace Xiangqi.UseRule
{
	public class LegalMove : Data
	{

		public VP<System.UInt32> move;

		public VP<int> repStatus;

		#region Constructor

		public enum Property
		{
			move,
			repStatus
		}

		public LegalMove() : base()
		{
			this.move = new VP<uint> (this, (byte)Property.move, 0);
			this.repStatus = new VP<int> (this, (byte)Property.repStatus, (int)Common.RepStatus.REP_NONE);
		}

		#endregion

		public override string ToString ()
		{
			Common.MoveStruct moveStruct = new Common.MoveStruct (this.move.v);
			return string.Format ("[{0}, {1}, {2}, {3}, {4}]", Common.printMove (this.move.v), this.repStatus.v
				, Xiangqi.Src (this.move.v), Xiangqi.Dst (this.move.v), moveStruct);
		}
	}
}