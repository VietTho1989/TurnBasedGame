using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateNoneUpdate : UpdateBehavior<RequestNewRoundRobinStateNone>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewRoundRobin.IsCanMakeNewRound (this.data)) {
						RequestNewRoundRobin requestNewRoundRobin = this.data.findDataInParent<RequestNewRoundRobin> ();
						if (requestNewRoundRobin != null) {
							// Chuyen sang ask
							RequestNewRoundRobinStateAsk ask = new RequestNewRoundRobinStateAsk();
							{
								ask.uid = requestNewRoundRobin.state.makeId ();
							}
							requestNewRoundRobin.state.v = ask;
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

		private RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateNone> requestNewRoundRobinCheckChange = new RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateNone>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundRobinStateNone) {
				RequestNewRoundRobinStateNone requestNewRoundRobinStateNone = data as RequestNewRoundRobinStateNone;
				// CheckChange
				{
					requestNewRoundRobinCheckChange.addCallBack (this);
					requestNewRoundRobinCheckChange.setData (requestNewRoundRobinStateNone);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateNone>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewRoundRobinStateNone) {
				RequestNewRoundRobinStateNone requestNewRoundRobinStateNone = data as RequestNewRoundRobinStateNone;
				// CheckChange
				{
					requestNewRoundRobinCheckChange.removeCallBack (this);
					requestNewRoundRobinCheckChange.setData (null);
				}
				this.setDataNull (requestNewRoundRobinStateNone);
				return;
			}
			// CheckChange
			if (data is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateNone>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewRoundRobinStateNone) {
				return;
			}
			// CheckChange
			if (wrapProperty.p is RequestNewRoundRobinCheckChange<RequestNewRoundRobinStateNone>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}