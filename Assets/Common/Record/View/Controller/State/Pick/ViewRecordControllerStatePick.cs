using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewRecordControllerStatePick : ViewRecordControllerUI.UIData.State
	{

		public VP<float> startTime;

		public VP<float> pickTime;

		public VP<ViewRecordControllerStatePlay.State> playState;

		#region Constructor

		public enum Property
		{
			startTime,
			pickTime,
			playState
		}

		public ViewRecordControllerStatePick() : base()
		{
			this.startTime = new VP<float> (this, (byte)Property.startTime, 0);
			this.pickTime = new VP<float> (this, (byte)Property.pickTime, 0);
			this.playState = new VP<ViewRecordControllerStatePlay.State> (this, (byte)Property.playState, ViewRecordControllerStatePlay.State.Normal);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Pick;
		}

		public override float getCurrentShowTime ()
		{
			return this.pickTime.v;
		}

	}
}