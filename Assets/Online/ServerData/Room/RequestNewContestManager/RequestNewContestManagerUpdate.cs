using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewContestManagerUpdate : UpdateBehavior<RequestNewContestManager>
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
			if (data is RequestNewContestManager) {
				RequestNewContestManager requestNewContestManager = data as RequestNewContestManager;
				// Child
				{
					requestNewContestManager.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Chid
			if (data is RequestNewContestManager.State) {
				RequestNewContestManager.State state = data as RequestNewContestManager.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewContestManager.State.Type.None:
						{
							RequestNewContestManagerStateNone none = state as RequestNewContestManagerStateNone;
							UpdateUtils.makeUpdate<RequestNewContestManagerStateNoneUpdate, RequestNewContestManagerStateNone> (none, this.transform);
						}
						break;
					case RequestNewContestManager.State.Type.Ask:
						{
							RequestNewContestManagerStateAsk ask = state as RequestNewContestManagerStateAsk;
							UpdateUtils.makeUpdate<RequestNewContestManagerStateAskUpdate, RequestNewContestManagerStateAsk> (ask, this.transform);
						}
						break;
					case RequestNewContestManager.State.Type.Accept:
						{
							RequestNewContestManagerStateAccept accept = state as RequestNewContestManagerStateAccept;
							UpdateUtils.makeUpdate<RequestNewContestManagerStateAcceptUpdate, RequestNewContestManagerStateAccept> (accept, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown state: " + state.getType () + "; " + this);
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
			if (data is RequestNewContestManager) {
				RequestNewContestManager requestNewContestManager = data as RequestNewContestManager;
				// Child
				{
					requestNewContestManager.state.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewContestManager);
				return;
			}
			// Chid
			if (data is RequestNewContestManager.State) {
				RequestNewContestManager.State state = data as RequestNewContestManager.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewContestManager.State.Type.None:
						{
							RequestNewContestManagerStateNone none = state as RequestNewContestManagerStateNone;
							none.removeCallBackAndDestroy (typeof(RequestNewContestManagerStateNoneUpdate));
						}
						break;
					case RequestNewContestManager.State.Type.Ask:
						{
							RequestNewContestManagerStateAsk ask = state as RequestNewContestManagerStateAsk;
							ask.removeCallBackAndDestroy (typeof(RequestNewContestManagerStateAskUpdate));
						}
						break;
					case RequestNewContestManager.State.Type.Accept:
						{
							RequestNewContestManagerStateAccept accept = state as RequestNewContestManagerStateAccept;
							accept.removeCallBackAndDestroy (typeof(RequestNewContestManagerStateAcceptUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown state: " + state.getType () + "; " + this);
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
			if (wrapProperty.p is RequestNewContestManager) {
				switch ((RequestNewContestManager.Property)wrapProperty.n) {
				case RequestNewContestManager.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Chid
			if (wrapProperty.p is RequestNewContestManager.State) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}