using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewContestManagerStateNoneUpdate : UpdateBehavior<RequestNewContestManagerStateNone>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewContestManager.IsCanMakeNewContestManagerWithoutRequestState (this.data)) {
						// Chuyen sang ask
						RequestNewContestManager requestNewContestManager = this.data.findDataInParent<RequestNewContestManager>();
						if (requestNewContestManager != null) {
							RequestNewContestManagerStateAsk ask = new RequestNewContestManagerStateAsk ();
							{
								ask.uid = requestNewContestManager.state.makeId ();
							}
							requestNewContestManager.state.v = ask;
						} else {
							Debug.LogError ("requestNewContestManager null: " + this);
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

		private CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateNone> checkMakeNewContestManager = new CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateNone> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewContestManagerStateNone) {
				RequestNewContestManagerStateNone requestNewContestManagerStateNone = data as RequestNewContestManagerStateNone;
				// CheckChange
				{
					checkMakeNewContestManager.addCallBack (this);
					checkMakeNewContestManager.setData (requestNewContestManagerStateNone);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateNone>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewContestManagerStateNone) {
				RequestNewContestManagerStateNone requestNewContestManagerStateNone = data as RequestNewContestManagerStateNone;
				// CheckChange
				{
					checkMakeNewContestManager.removeCallBack (this);
					checkMakeNewContestManager.setData (null);
				}
				this.setDataNull (requestNewContestManagerStateNone);
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateNone>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewContestManagerStateNone) {
				switch ((RequestNewContestManagerStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateNone>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}