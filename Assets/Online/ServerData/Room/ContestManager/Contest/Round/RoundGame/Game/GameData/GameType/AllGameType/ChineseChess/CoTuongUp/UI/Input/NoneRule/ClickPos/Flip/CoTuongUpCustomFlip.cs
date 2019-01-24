using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class CoTuongUpCustomFlip : GameMove
	{

		public VP<byte> coord;

		#region Constructor

		public enum Property
		{
			coord
		}

		public CoTuongUpCustomFlip() : base()
		{
			this.coord = new VP<byte> (this, (byte)Property.coord, 0);
		}

		#endregion

		public override Type getType()
		{
			return Type.CoTuongUpCustomFlip;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			return null;
		}

		public override string print()
		{
			return string.Format ("CoTuongUpCustomFlip: {0}", this.coord.v);
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}