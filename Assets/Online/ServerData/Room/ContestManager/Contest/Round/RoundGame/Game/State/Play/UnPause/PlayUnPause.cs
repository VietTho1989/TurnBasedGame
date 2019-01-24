using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
	public class PlayUnPause : Play.Sub
	{

		public VP<Human> human;

		public VP<float> time;

		public VP<float> duration;

		#region Constructor

		public enum Property
		{
			human,
			time,
			duration
		}

		public PlayUnPause() : base()
		{
			this.human = new VP<Human> (this, (byte)Property.human, null);
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, 3f);
		}

		#endregion

		public override Type getType ()
		{
			return Type.UnPause;
		}

	}
}