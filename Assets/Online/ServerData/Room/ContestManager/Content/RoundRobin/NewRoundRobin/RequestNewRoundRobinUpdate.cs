using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinUpdate : UpdateBehavior<RequestNewRoundRobin>
	{
		
		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {

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
			if (data is RequestNewRoundRobin) {
				RequestNewRoundRobin requestNewRoundRobin = data as RequestNewRoundRobin;
				// Child
				{
					requestNewRoundRobin.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewRoundRobin.State) {
				RequestNewRoundRobin.State state = data as RequestNewRoundRobin.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewRoundRobin.State.Type.None:
						{
							RequestNewRoundRobinStateNone none = state as RequestNewRoundRobinStateNone;
							UpdateUtils.makeUpdate<RequestNewRoundRobinStateNoneUpdate, RequestNewRoundRobinStateNone> (none, this.transform);
						}
						break;
					case RequestNewRoundRobin.State.Type.Ask:
						{
							RequestNewRoundRobinStateAsk ask = state as RequestNewRoundRobinStateAsk;
							UpdateUtils.makeUpdate<RequestNewRoundRobinStateAskUpdate, RequestNewRoundRobinStateAsk> (ask, this.transform);
						}
						break;
					case RequestNewRoundRobin.State.Type.Accept:
						{
							RequestNewRoundRobinStateAccept accept = state as RequestNewRoundRobinStateAccept;
							UpdateUtils.makeUpdate<RequestNewRoundRobinStateAcceptUpdate, RequestNewRoundRobinStateAccept> (accept, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewRoundRobin) {
				RequestNewRoundRobin requestNewRoundRobin = data as RequestNewRoundRobin;
				// Child
				{
					requestNewRoundRobin.state.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewRoundRobin);
				return;
			}
			// Child
			if (data is RequestNewRoundRobin.State) {
				RequestNewRoundRobin.State state = data as RequestNewRoundRobin.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewRoundRobin.State.Type.None:
						{
							RequestNewRoundRobinStateNone none = state as RequestNewRoundRobinStateNone;
							none.removeCallBackAndDestroy (typeof(RequestNewRoundRobinStateNoneUpdate));
						}
						break;
					case RequestNewRoundRobin.State.Type.Ask:
						{
							RequestNewRoundRobinStateAsk ask = state as RequestNewRoundRobinStateAsk;
							ask.removeCallBackAndDestroy (typeof(RequestNewRoundRobinStateAskUpdate));
						}
						break;
					case RequestNewRoundRobin.State.Type.Accept:
						{
							RequestNewRoundRobinStateAccept accept = state as RequestNewRoundRobinStateAccept;
							accept.removeCallBackAndDestroy (typeof(RequestNewRoundRobinStateAcceptUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + state.getType () + "; " + this);
						break;
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewRoundRobin) {
				switch ((RequestNewRoundRobin.Property)wrapProperty.n) {
				case RequestNewRoundRobin.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + data + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is RequestNewRoundRobin.State) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}