using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class MineSweeperMove : GameMove
	{

		public VP<int> move;

		public VP<int> Y;

		public VP<int> X;

		#region Constructor

		public enum Property
		{
			move,
			Y,
			X
		}

		public MineSweeperMove() : base()
		{
			this.move = new VP<int> (this, (byte)Property.move, -1);
			this.Y = new VP<int> (this, (byte)Property.Y, 10);
			this.X = new VP<int> (this, (byte)Property.X, 10);
		}

		#endregion

		public override Type getType()
		{
			return Type.MineSweeperMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is MineSweeper) {
				MineSweeper mineSweeper = gameType as MineSweeper;
				// Make animation
				MineSweeperMoveAnimation mineSweeperMoveAnimation = new MineSweeperMoveAnimation();
				{
					// inform
					{
						mineSweeperMoveAnimation.X.v = mineSweeper.X.v;
						mineSweeperMoveAnimation.Y.v = mineSweeper.Y.v;
                        // sub
                        {
                            foreach(MineSweeperSub sub in mineSweeper.sub.vs)
                            {
                                MineSweeperSub newSub = DataUtils.cloneData(sub) as MineSweeperSub;
                                {
                                    newSub.uid = mineSweeperMoveAnimation.sub.makeId();
                                }
                                mineSweeperMoveAnimation.sub.add(newSub);
                            }
                        }
						mineSweeperMoveAnimation.booom.v = mineSweeper.booom.v;
					}
					mineSweeperMoveAnimation.move.v = this.move.v;
				}
				return mineSweeperMoveAnimation;
			} else {
				Debug.LogError ("why not mineSweeper: " + gameType + "; " + this);
				return null;
			}
		}

		public override string print()
		{
			int x = 0;
			int y = 0;
			if (this.Y.v > 0) {
				x = this.move.v / this.Y.v;
				y = this.move.v % this.Y.v;
			} else {
				Debug.LogError ("N error: " + this.Y.v);
			}
			return "" + x + "," + y;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			if (gameType is MineSweeper) {
				MineSweeper mineSweeper = gameType as MineSweeper;
				// get Inform
				{
					this.Y.v = mineSweeper.Y.v;
					this.X.v = mineSweeper.X.v;
				}
			} else {
				Debug.LogError ("why gameType not MineSweeper: " + gameType + "; " + this);
			}
		}

		public override bool isCanMakeMoveMessage ()
		{
			return false;
		}

	}
}