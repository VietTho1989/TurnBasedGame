using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewRecordControllerStatePlay : ViewRecordControllerUI.UIData.State
	{

		public VP<float> time;

		#region State

		public enum State
		{
			Normal,
			Pause
		}

		public VP<State> state;

		#endregion

		#region Constructor

		public enum Property
		{
			time,
			state
		}

		public ViewRecordControllerStatePlay() : base()
		{
			this.time = new VP<float> (this, (byte)Property.time, 0);
			this.state = new VP<State> (this, (byte)Property.state, State.Normal);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Play;
		}

		public override float getCurrentShowTime ()
		{
			return this.time.v;
		}

	}
}