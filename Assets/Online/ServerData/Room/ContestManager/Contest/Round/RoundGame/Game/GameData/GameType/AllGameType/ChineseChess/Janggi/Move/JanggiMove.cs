using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiMove : GameMove
	{

		public VP<sbyte> fromX;

		public VP<sbyte> fromY;

		public VP<sbyte> toX;

		public VP<sbyte> toY;

		#region Constructor

		public enum Property
		{
			fromX,
			fromY,
			toX,
			toY
		}

		public JanggiMove() : base()
		{
			this.fromX = new VP<sbyte> (this, (byte)Property.fromX, 0);
			this.fromY = new VP<sbyte> (this, (byte)Property.fromY, 0);
			this.toX = new VP<sbyte> (this, (byte)Property.toX, 0);
			this.toY = new VP<sbyte> (this, (byte)Property.toY, 0);
		}

		#endregion

		#region implement base

		public override Type getType()
		{
			return Type.JanggiMove;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Janggi) {
				Janggi janggi = gameType as Janggi;
				// make animation
				JanggiMoveAnimation janggiMoveAnimation = new JanggiMoveAnimation();
				{
					janggiMoveAnimation.fromX.v = this.fromX.v;
					janggiMoveAnimation.fromY.v = this.fromY.v;
					janggiMoveAnimation.toX.v = this.toX.v;
					janggiMoveAnimation.toY.v = this.toY.v;
					janggiMoveAnimation.stones.vs.AddRange (janggi.stones.vs);
				}
				return janggiMoveAnimation;
			} else {
				Debug.LogError ("why not janggi: " + gameType);
				return null;
			}
		}

		public override string print()
		{
			return string.Format ("({0}, {1}) -> ({2}, {3})", this.fromX.v, this.fromY.v, this.toX.v, this.toY.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

	}
}