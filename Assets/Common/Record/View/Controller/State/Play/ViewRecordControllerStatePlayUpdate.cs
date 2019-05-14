using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Record
{
	public class ViewRecordControllerStatePlayUpdate : UpdateBehavior<ViewRecordControllerStatePlay>
	{
		
		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					switch (this.data.state.v) {
					case ViewRecordControllerStatePlay.State.Normal:
						{
							dirty = true;
							{
								ViewRecordControllerUI.UIData viewRecordControllerUIData = this.data.findDataInParent<ViewRecordControllerUI.UIData> ();
								if (viewRecordControllerUIData != null) {
									DataRecord dataRecord = viewRecordControllerUIData.dataRecord.v;
									if (dataRecord != null) {
										if (viewRecordControllerUIData.speed.v != 0) {
											float newTime = Mathf.Clamp (this.data.time.v + viewRecordControllerUIData.speed.v * Time.fixedDeltaTime, 0, dataRecord.t);
											{
												if (viewRecordControllerUIData.speed.v > 0) {
													dataRecord.moveForward (newTime);
												} else {
													dataRecord.moveBackWard (newTime);
												}
											}
											this.data.time.v = newTime;
										} else {
											Debug.LogError ("why speed 0: " + this);
										}
									} else {
										// Debug.LogError ("dataRecord null: " + this);
									}
								} else {
									// Debug.LogError ("viewRecordControllerUIData null: " + this);
								}
							}
						}
						break;
					case ViewRecordControllerStatePlay.State.Pause:
						break;
					default:
						Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
						break;
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
			if (data is ViewRecordControllerStatePlay) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ViewRecordControllerStatePlay) {
				ViewRecordControllerStatePlay viewControllerStatePlay = data as ViewRecordControllerStatePlay;
				// Child
				{

				}
				this.setDataNull (viewControllerStatePlay);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is ViewRecordControllerStatePlay) {
				switch ((ViewRecordControllerStatePlay.Property)wrapProperty.n) {
				case ViewRecordControllerStatePlay.Property.time:
					dirty = true;
					break;
				case ViewRecordControllerStatePlay.Property.state:
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