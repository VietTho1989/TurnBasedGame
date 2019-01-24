using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet.NoneRule
{
	public class KhetCustomRotate : GameMove
	{

		public VP<int> position;

		public VP<bool> isAdd;

		#region Constructor

		public enum Property
		{
			position,
			isAdd
		}

		public KhetCustomRotate() : base()
		{
			this.position = new VP<int> (this, (byte)Property.position, 0);
			this.isAdd = new VP<bool> (this, (byte)Property.isAdd, true);
		}

		#endregion

		#region implement base

		public override Type getType()
		{
			return Type.KhetCustomRotate;
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
			return "KhetCustomRotate: " + this.position.v + ", " + this.isAdd.v;
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

		#endregion

	}
}