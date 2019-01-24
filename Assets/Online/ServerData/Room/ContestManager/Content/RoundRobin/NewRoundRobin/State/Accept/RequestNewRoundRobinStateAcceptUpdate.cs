using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateAcceptUpdate : UpdateBehavior<RequestNewRoundRobinStateAccept>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (!RequestNewRoundRobin.IsCanMakeNewRound (this.data)) {
						RequestNewRoundRobin requestNewRoundRobin = this.data.findDataInParent<RequestNewRoundRobin> ();
						if (requestNewRoundRobin != null) {
							// Chuyen sang none
							RequestNewRoundRobinStateNone none = new RequestNewRoundRobinStateNone();
							{
								none.uid = requestNewRoundRobin.state.makeId ();
							}
							requestNewRoundRobin.state.v = none;
						} else {
							Debug.LogError ("requestNewRoundRobin null: " + this);
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

		private RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAccept> requestNewRoundRobinCheckChange = new RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAccept>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundRobinStateAccept) {
				RequestNewRoundRobinStateAccept requestNewRoundRobinStateAccept = data as RequestNewRoundRobinStateAccept;
				// CheckChange
				{
					requestNewRoundRobinCheckChange.addCallBack (this);
					requestNewRoundRobinCheckChange.setData (requestNewRoundRobinStateAccept);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewRoundRobinStateAccept) {
				RequestNewRoundRobinStateAccept requestNewRoundRobinStateAccept = data as RequestNewRoundRobinStateAccept;
				// CheckChange
				{
					requestNewRoundRobinCheckChange.removeCallBack (this);
					requestNewRoundRobinCheckChange.setData (null);
				}
				this.setDataNull (requestNewRoundRobinStateAccept);
				return;
			}
			// CheckChange
			if (data is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAccept>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewRoundRobinStateAccept) {
				return;
			}
			// CheckChange
			if (wrapProperty.p is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}