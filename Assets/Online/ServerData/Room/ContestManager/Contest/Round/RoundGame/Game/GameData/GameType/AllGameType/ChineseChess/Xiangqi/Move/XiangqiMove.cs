using UnityEngine;
using System.Collections;

namespace Xiangqi
{
	public class XiangqiMove : GameMove
	{
		
		public VP<System.UInt32> move;

		#region Constructor

		public enum Property
		{
			move
		}

		public XiangqiMove() : base()
		{
			this.move = new VP<uint> (this, (byte)Property.move, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.XiangqiMove;
		}

		public override string print ()
		{
			return Common.printMove (this.move.v);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Xiangqi) {
				Xiangqi xiangqi = gameType as Xiangqi;
				// make animation
				XiangqiMoveAnimation xiangqiMoveAnimation = new XiangqiMoveAnimation();
				{
					xiangqiMoveAnimation.move.v = this.move.v;
					xiangqiMoveAnimation.ucpcSquares.vs.AddRange (xiangqi.ucpcSquares.vs);
				}
				return xiangqiMoveAnimation;
			} else {
				Debug.LogError ("why gameType not xiangqi: " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

	}
}