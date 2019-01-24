using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class DataRecordTask : Data
	{

		public VP<ReferenceData<Data>> needRecordData;

		#region State

		public enum State
		{
			None,
			Start,
			Record,
			Finish
		}

		public VP<State> state;

		#endregion

		public DataRecord record = new DataRecord();

		#region Constructor

		public enum Property
		{
			needRecordData,
			state
		}

		public DataRecordTask() : base()
		{
			this.needRecordData = new VP<ReferenceData<Data>> (this, (byte)Property.needRecordData, new ReferenceData<Data> (null));
			this.state = new VP<State> (this, (byte)Property.state, State.None);
		}

		#endregion

	}
}