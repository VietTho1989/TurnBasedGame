using UnityEngine;
using System.Collections;

namespace Gomoku
{
	public class GomokuMove : GameMove
	{

		public VP<int> move;

		public VP<int> boardSize;

		#region Constructor

		public enum Property
		{
			move,
			boardSize
		}

		public GomokuMove() : base()
		{
			this.move = new VP<int> (this, (byte)Property.move, -1);
			this.boardSize = new VP<int> (this, (byte)Property.boardSize, 19);
		}

		#endregion

		public override Type getType ()
		{
			return Type.GomokuMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Gomoku) {
				Gomoku gomoku = gameType as Gomoku;
				// Make animation
				GomokuMoveAnimation gomokuMoveAnimation = new GomokuMoveAnimation ();
				{
					// move
					gomokuMoveAnimation.move.v = this.move.v;
					// gomoku
					gomokuMoveAnimation.gomoku.v = DataUtils.cloneData(gomoku) as Gomoku;
				}
				return gomokuMoveAnimation;
			} else {
				Debug.LogError ("why gameType not gomoku: " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

		public override string print()
		{
			// TODO Can hoan thien
			return "" + this.move.v;
		}

	}

}