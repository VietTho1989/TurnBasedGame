using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class SwapRequestStateCancel : SwapRequest.State
	{

		public VP<Human> whoCancel;

		public VP<float> time;

		public VP<float> duration;

		#region Constructor

		public enum Property
		{
			whoCancel,
			time,
			duration
		}

		public SwapRequestStateCancel() : base()
		{
			this.whoCancel = new VP<Human> (this, (byte)Property.whoCancel, new Human ());
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, 3);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Cancel;
		}

	}
}