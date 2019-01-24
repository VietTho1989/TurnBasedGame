using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexMove : GameMove
	{

		public VP<System.UInt16> move;

		public VP<System.UInt16> boardSize;

		public VP<Common.Color> color;

		#region Constructor

		public enum Property
		{
			move,
			boardSize,
			color
		}

		public HexMove() : base()
		{
			this.move = new VP<ushort> (this, (byte)Property.move, 0);
			this.boardSize = new VP<ushort> (this, (byte)Property.boardSize, 11);
			this.color = new VP<Common.Color> (this, (byte)Property.color, Common.Color.Red);
		}

		#endregion

		#region implement base

		public override Type getType()
		{
			return Type.HexMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Hex) {
				Hex hex = gameType as Hex;
				// make animation
				HexMoveAnimation hexMoveAnimation = new HexMoveAnimation ();
				{
					hexMoveAnimation.boardSize.v = hex.boardSize.v;
					hexMoveAnimation.board.vs.AddRange (hex.board.vs);
					hexMoveAnimation.move.v = this.move.v;
					hexMoveAnimation.color.v = hex.getCurrentColor ();
				}
				return hexMoveAnimation;
			} else {
				return null;
			}
		}

		public override string print()
		{
			System.UInt16 x = 0;
			System.UInt16 y = 0;
			{
				if (this.boardSize.v > 0) {
					x = (System.UInt16)(this.move.v % this.boardSize.v);
					y = (System.UInt16)(this.move.v / this.boardSize.v);
				} else {
					Debug.LogError ("why board size too small: " + this);
				}
			}
			return x + " " + y;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			if (gameType is Hex) {
				Hex hex = gameType as Hex;
				this.boardSize.v = hex.boardSize.v;
				this.color.v = hex.getCurrentColor ();
			}
		}

		#endregion

	}
}