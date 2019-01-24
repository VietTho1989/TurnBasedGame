using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi.NoneRule
{
	public class BanqiCustomFlip : GameMove
	{

		public VP<int> x;

		public VP<int> y;

		#region Constructor

		public enum Property
		{
			x,
			y
		}

		public BanqiCustomFlip() : base()
		{
			this.x = new VP<int> (this, (byte)Property.x, 0);
			this.y = new VP<int> (this, (byte)Property.y, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.BanqiCustomFlip;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("BanqiCustomFlip: {0}, {1}", this.x.v, this.y.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}