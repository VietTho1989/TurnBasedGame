using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet.NoneRule
{
	public class KhetCustomSet : GameMove
	{

		public VP<int> position;

		public VP<Common.Player> player;

		public VP<Common.Piece> piece;

		#region Constructor

		public enum Property
		{
			position,
			player,
			piece
		}

		public KhetCustomSet() : base()
		{
			this.position = new VP<int> (this, (byte)Property.position, 0);
			this.player = new VP<Common.Player> (this, (byte)Property.player, Common.Player.Silver);
			this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.None);
		}

		#endregion

		#region implement base

		public override Type getType()
		{
			return Type.KhetCusomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Khet) {
				return null;
			} else {
				Debug.LogError ("why not khet: " + gameType);
				return null;
			}
		}

		public override string print()
		{
			return "KhetCustomSet: " + this.position.v + ", " + this.player.v + ", " + this.piece.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

	}
}