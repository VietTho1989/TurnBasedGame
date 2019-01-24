using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class MineSweeperMoveAnimation : MoveAnimation
	{

		#region mineSweeper inform

		public VP<int> X;

		public VP<int> Y;

		public LP<sbyte> board;

		public LP<sbyte> bombs;

		public LP<sbyte> flags;

		public VP<bool> booom;

		#endregion

		#region move

		public VP<int> move;

		#endregion

		#region Constructor

		public enum Property
		{
			X,
			Y,
			board,
			bombs,
			flags,
			booom,

			move
		}

		public MineSweeperMoveAnimation() : base()
		{
			// inform
			{
				this.X = new VP<int> (this, (byte)Property.X, 10);
				this.Y = new VP<int> (this, (byte)Property.Y, 10);
				this.board = new LP<sbyte> (this, (byte)Property.board);
				this.bombs = new LP<sbyte> (this, (byte)Property.bombs);
				this.flags = new LP<sbyte> (this, (byte)Property.flags);
				this.booom = new VP<bool> (this, (byte)Property.booom, false);
			}
			this.move = new VP<int> (this, (byte)Property.move, -1);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.MineSweeperMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override void initDuration ()
		{
			
		}

		public override float getDuration ()
		{
			return 1 * AnimationManager.DefaultDuration;
		}

		public override GameMove makeGameMove ()
		{
			MineSweeperMove mineSweeperMove = new MineSweeperMove ();
			{
				mineSweeperMove.move.v = this.move.v;
				// N
				// M
			}
			return mineSweeperMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}