using UnityEngine;
using System.Collections;

namespace Reversi
{
	public class ReversiMove : GameMove
	{

		public VP<sbyte> move;

		#region Constructor

		public enum Property
		{
			move
		}

		public ReversiMove() : base()
		{
			this.move = new VP<sbyte> (this, (byte)Property.move, -1);
		}

		#endregion

		public override Type getType ()
		{
			return Type.ReversiMove;
		}

		public override string print ()
		{
			return Common.printMove (this.move.v);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Reversi) {
				Reversi reversi = gameType as Reversi;
				// Make animation
				ReversiMoveAnimation reversiMoveAnimation = new ReversiMoveAnimation();
				{
					// reversi
					reversiMoveAnimation.reversi.v = DataUtils.cloneData(reversi) as Reversi;
					// move
					reversiMoveAnimation.move.v = this.move.v;
					// flips
					// Cai nay tinh toan sau
				}
				return reversiMoveAnimation;
			} else {
				Debug.LogError ("why gameType not reversi: " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

	}
}