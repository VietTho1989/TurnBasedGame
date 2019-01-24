using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewRecordControllerStatePickUpdate : UpdateBehavior<ViewRecordControllerStatePick>
	{

		#if UNITY_STANDALONE

		public const uint ProcessPerUpdate = 500;

		#else

		public const uint ProcessPerUpdate = 100;

		#endif

		#region Update

		public override void update ()
		{
			if (dirty) {
				// dirty = false;
				if (this.data != null) {
					// dirty = true;
					ViewRecordControllerUI.UIData viewRecordControllerUIData = this.data.findDataInParent<ViewRecordControllerUI.UIData> ();
					if (viewRecordControllerUIData != null) {
						// correct pickTime
						{
							/*DataRecord dataRecord = viewRecordControllerUIData.dataRecord.v;
							if (dataRecord != null) {
								this.data.pickTime.v = Mathf.Clamp (this.data.pickTime.v, 0, dataRecord.t);
							} else {
								Debug.LogError ("dataRecord null: " + this);
							}*/
						}
						Debug.LogError ("pick update: " + this.data.pickTime.v + "; " + this.data.startTime.v);
						// make change
						{
							if (this.data.startTime.v != this.data.pickTime.v) {
								// find processCount
								uint processCount = 0;
								{
									DataRecord dataRecord = viewRecordControllerUIData.dataRecord.v;
									if (dataRecord != null) {
										if (this.data.pickTime.v > this.data.startTime.v) {
											processCount = dataRecord.moveForward (this.data.pickTime.v, ProcessPerUpdate);
										} else {
											processCount = dataRecord.moveBackWard (this.data.pickTime.v, ProcessPerUpdate);
										}
									} else {
										Debug.LogError ("dataRecord null: " + this);
									}
								}
								Debug.LogError ("processCount: " + processCount);
								// process
								if (processCount == 0) {
									// don't process changes more, change to state play
									ViewRecordControllerStatePlay play = new ViewRecordControllerStatePlay ();
									{
										play.uid = viewRecordControllerUIData.state.makeId ();
										play.time.v = this.data.pickTime.v;
										play.state.v = this.data.playState.v;
									}
									viewRecordControllerUIData.state.v = play;
								} else {
									// have process, need process more
								}
							} else {
								// change to state play
								ViewRecordControllerStatePlay play = new ViewRecordControllerStatePlay ();
								{
									play.uid = viewRecordControllerUIData.state.makeId ();
									play.time.v = this.data.pickTime.v;
									play.state.v = this.data.playState.v;
								}
								viewRecordControllerUIData.state.v = play;
							}
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is ViewRecordControllerStatePick) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ViewRecordControllerStatePick) {
				ViewRecordControllerStatePick pick = data as ViewRecordControllerStatePick;
				// Child
				{

				}
				this.setDataNull (pick);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ViewRecordControllerStatePick) {
				switch ((ViewRecordControllerStatePick.Property)wrapProperty.n) {
				case ViewRecordControllerStatePick.Property.startTime:
					dirty = true;
					break;
				case ViewRecordControllerStatePick.Property.pickTime:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}