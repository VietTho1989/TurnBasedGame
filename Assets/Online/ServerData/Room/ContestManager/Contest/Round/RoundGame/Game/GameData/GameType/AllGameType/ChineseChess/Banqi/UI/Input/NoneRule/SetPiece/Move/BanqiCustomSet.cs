using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi.NoneRule
{
	public class BanqiCustomSet : GameMove
	{

		public VP<int> x;

		public VP<int> y;

		public VP<Token.Ecolor> color;

		public VP<Token.Type> type;

		public VP<bool> isFaceUp;

		#region Constructor

		public enum Property
		{
			x,
			y,
			color,
			type,
			isFaceUp
		}

		public BanqiCustomSet() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
			this.color = new VP<Token.Ecolor> (this, (byte)Property.color, Token.Ecolor.RED);
			this.type = new VP<Token.Type> (this, (byte)Property.type, Token.Type.SOLDIER);
			this.isFaceUp = new VP<bool> (this, (byte)Property.isFaceUp, true);
		}

		#endregion

		public override Type getType()
		{
			return Type.BanqiCustomSet;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("BanqiCustomSet: {0}, {1}, {2}, {3}, {4}", this.x.v, this.y.v, this.color.v, this.type.v, this.isFaceUp.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}