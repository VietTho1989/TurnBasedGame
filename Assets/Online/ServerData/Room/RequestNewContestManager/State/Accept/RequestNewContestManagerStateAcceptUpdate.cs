using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewContestManagerStateAcceptUpdate : UpdateBehavior<RequestNewContestManagerStateAccept>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (!RequestNewContestManager.IsCanMakeNewContestManagerWithoutRequestState (this.data)) {
						// Chuyen sang none
						RequestNewContestManager requestNewContestManager = this.data.findDataInParent<RequestNewContestManager>();
						if (requestNewContestManager != null) {
							RequestNewContestManagerStateNone none = new RequestNewContestManagerStateNone ();
							{
								none.uid = requestNewContestManager.state.makeId ();
							}
							requestNewContestManager.state.v = none;
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

		private CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAccept> checkMakeNewContestManager = new CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAccept> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewContestManagerStateAccept) {
				RequestNewContestManagerStateAccept requestNewContestManagerStateAccept = data as RequestNewContestManagerStateAccept;
				// CheckChange
				{
					checkMakeNewContestManager.addCallBack (this);
					checkMakeNewContestManager.setData (requestNewContestManagerStateAccept);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewContestManagerStateAccept) {
				RequestNewContestManagerStateAccept requestNewContestManagerStateAccept = data as RequestNewContestManagerStateAccept;
				// CheckChange
				{
					checkMakeNewContestManager.removeCallBack (this);
					checkMakeNewContestManager.setData (null);
				}
				this.setDataNull (requestNewContestManagerStateAccept);
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAccept>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewContestManagerStateAccept) {
				switch ((RequestNewContestManagerStateAccept.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is CheckCanMakeNewContestManagerChange<RequestNewContestManagerStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}