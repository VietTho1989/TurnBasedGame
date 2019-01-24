using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexSwitchAnimation : MoveAnimation
	{

		public VP<System.UInt16> boardSize;

		public LP<sbyte> board;

		#region Constructor

		public enum Property
		{
			boardSize,
			board
		}

		public HexSwitchAnimation() : base()
		{
			this.boardSize = new VP<ushort> (this, (byte)Property.boardSize, 11);
			this.board = new LP<sbyte> (this, (byte)Property.board);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType()
		{
			return GameMove.Type.HexSwitch;
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
			HexSwitch hexSwitch = new HexSwitch ();
			{

			}
			return hexSwitch;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}