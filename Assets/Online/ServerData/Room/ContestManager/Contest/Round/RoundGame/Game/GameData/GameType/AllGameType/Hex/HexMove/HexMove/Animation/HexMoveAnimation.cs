using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexMoveAnimation : MoveAnimation
	{

		public VP<System.UInt16> boardSize;

		public LP<sbyte> board;

		public VP<System.UInt16> move;

		public VP<Common.Color> color;

		#region Constructor

		public enum Property
		{
			boardSize,
			board,
			move,
			color
		}

		public HexMoveAnimation() : base()
		{
			this.boardSize = new VP<ushort> (this, (byte)Property.boardSize, 11);
			this.board = new LP<sbyte> (this, (byte)Property.board);
			this.move = new VP<ushort> (this, (byte)Property.move, 0);
			this.color = new VP<Common.Color> (this, (byte)Property.color, Common.Color.Red);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType()
		{
			return GameMove.Type.HexMove;
		}

		public override void initDuration ()
		{
			
		}

		public override float getDuration()
		{
			return AnimationManager.DefaultDuration;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{

		}

		public override GameMove makeGameMove()
		{
			HexMove hexMove = new HexMove ();
			{
				hexMove.move.v = this.move.v;
				hexMove.boardSize.v = this.boardSize.v;
				hexMove.color.v = this.color.v;
			}
			return hexMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}