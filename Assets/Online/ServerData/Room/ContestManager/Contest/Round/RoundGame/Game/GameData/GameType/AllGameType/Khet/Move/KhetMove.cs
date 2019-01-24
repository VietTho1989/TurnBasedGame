using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	/**
	 * TODO Co the se them vi tri bi diet luc truoc
	 * */
	public class KhetMove : GameMove
	{

		public VP<uint> move;

		#region Constructor

		public enum Property
		{
			move
		}

		public KhetMove() : base()
		{
			this.move = new VP<uint> (this, (byte)Property.move, 0);
		}

		#endregion

		#region Utils

		public static int GetStart(uint m)
		{
			return (int)(m >> 1 & 0x7F);
		}

		public static int GetEnd(uint m)
		{
			return (int)(m >> 8 & 0x7F);
		}

		public static int GetRotation(uint m)
		{
			return (int)((m >> 15 & 0x3) - 2);
		}

		#endregion

		#region implement base

		public override Type getType ()
		{
			return GameMove.Type.KhetMove;
		}

		public override string print ()
		{
			return Core.unityGetStrMove (this.move.v);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Khet) {
				Khet khet = gameType as Khet;
				// make animation
				KhetMoveAnimation khetMoveAnimation = new KhetMoveAnimation();
				{
					khetMoveAnimation.move.v = this.move.v;
					khetMoveAnimation.playerToMove.v = khet._playerToMove.v;
					khetMoveAnimation.board.add (khet._board.vs);
				}
				return khetMoveAnimation;
			} else {
				Debug.LogError ("why gameType isn't chess: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

		#endregion

	}
}