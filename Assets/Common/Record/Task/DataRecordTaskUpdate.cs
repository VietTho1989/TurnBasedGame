using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class DataRecordTaskUpdate : UpdateBehavior<DataRecordTask>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Data needRecordData = this.data.needRecordData.v.data;
					if (needRecordData != null) {
						switch (this.data.state.v) {
						case DataRecordTask.State.None:
							break;
						case DataRecordTask.State.Start:
							{
								dirty = true;
								this.data.record.reset ();
								// init value
								{
									this.data.record.startTime = Global.getRealTimeInMiliSeconds ();
									this.data.record.data = DataUtils.cloneData (needRecordData);
								}
								// record
								this.data.state.v = DataRecordTask.State.Record;
							}
							break;
						case DataRecordTask.State.Record:
							{
								dirty = true;
								this.data.record.t += Time.fixedDeltaTime;
							}
							break;
						case DataRecordTask.State.Finish:
							break;
						default:
							Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("needRecordData null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is DataRecordTask) {
				DataRecordTask dataRecordTask = data as DataRecordTask;
				// Child
				{
					dataRecordTask.needRecordData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				data.addCallBackAllChildren (this);
				return;
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is DataRecordTask) {
				DataRecordTask dataRecordTask = data as DataRecordTask;
				// Child
				{
					dataRecordTask.needRecordData.allRemoveCallBack (this);
				}
				this.setDataNull (dataRecordTask);
				return;
			}
			// Child
			{
				data.removeCallBackAllChildren (this);
				return;
			}
			// Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is DataRecordTask) {
				switch ((DataRecordTask.Property)wrapProperty.n) {
				case DataRecordTask.Property.needRecordData:
					{
						// reset
						{
							if (this.data != null) {
								this.data.state.v = DataRecordTask.State.None;
							} else {
								Debug.LogError ("data null: " + this);
							}
						}
						// replace callBacks
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case DataRecordTask.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				// makeChange
				if (this.data != null) {
					if (this.data.needRecordData.v.data != null) {
						if (this.data.state.v == DataRecordTask.State.Record) {
							this.data.record.makeChange (this.data.needRecordData.v.data, wrapProperty, syncs);
						}
					} else {
						Debug.LogError ("needRecordData null: " + this);
					}
				}
				// callBack
				if (Generic.IsAddCallBackInterface<T> ()) {
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				return;
			}
			// Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}