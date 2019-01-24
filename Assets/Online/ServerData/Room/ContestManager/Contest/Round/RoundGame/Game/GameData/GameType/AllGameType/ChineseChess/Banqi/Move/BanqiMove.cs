using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiMove : GameMove
	{

		public VP<int> fromX;

		public VP<int> fromY;

		public VP<int> destX;

		public VP<int> destY;

		#region Constructor

		public enum Property
		{
			fromX,
			fromY,
			destX,
			destY
		}

		public BanqiMove() : base()
		{
			this.fromX = new VP<int> (this, (byte)Property.fromX, -1);
			this.fromY = new VP<int> (this, (byte)Property.fromY, -1);
			this.destX = new VP<int> (this, (byte)Property.destX, -1);
			this.destY = new VP<int> (this, (byte)Property.destY, -1);
		}

		#endregion

		#region implement base

		public override Type getType()
		{
			return Type.BanqiMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Banqi) {
				Banqi banqi = gameType as Banqi;
				// make animation
				BanqiMoveAnimation banqiMoveAnimation = new BanqiMoveAnimation ();
				{
					banqiMoveAnimation.fromX.v = this.fromX.v;
					banqiMoveAnimation.fromY.v = this.fromY.v;
					banqiMoveAnimation.destX.v = this.destX.v;
					banqiMoveAnimation.destY.v = this.destY.v;
					banqiMoveAnimation.state.v = banqi.state.v;
				}
				return banqiMoveAnimation;
			} else {
				Debug.LogError ("why not banqi: " + gameType);
				return null;
			}
		}

		public override string print()
		{
			return string.Format ("({0}, {1}) -> ({2}, {3})", this.fromX.v, this.fromY.v, this.destX.v, this.destY.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

	}
}