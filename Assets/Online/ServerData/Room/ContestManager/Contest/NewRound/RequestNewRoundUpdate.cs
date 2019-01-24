using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundUpdate : UpdateBehavior<RequestNewRound>
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
			if (data is RequestNewRound) {
				RequestNewRound requestNewRound = data as RequestNewRound;
				// Child
				{
					requestNewRound.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewRound.State) {
				RequestNewRound.State state = data as RequestNewRound.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewRound.State.Type.None:
						{
							RequestNewRoundStateNone none = state as RequestNewRoundStateNone;
							UpdateUtils.makeUpdate<RequestNewRoundStateNoneUpdate, RequestNewRoundStateNone> (none, this.transform);
						}
						break;
					case RequestNewRound.State.Type.Ask:
						{
							RequestNewRoundStateAsk ask = state as RequestNewRoundStateAsk;
							UpdateUtils.makeUpdate<RequestNewRoundStateAskUpdate, RequestNewRoundStateAsk> (ask, this.transform);
						}
						break;
					case RequestNewRound.State.Type.Accept:
						{
							RequestNewRoundStateAccept accept = state as RequestNewRoundStateAccept;
							UpdateUtils.makeUpdate<RequestNewRoundStateAcceptUpdate, RequestNewRoundStateAccept> (accept, this.transform);
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
			if (data is RequestNewRound) {
				RequestNewRound requestNewRound = data as RequestNewRound;
				// Child
				{
					requestNewRound.state.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewRound);
				return;
			}
			// Child
			if (data is RequestNewRound.State) {
				RequestNewRound.State state = data as RequestNewRound.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewRound.State.Type.None:
						{
							RequestNewRoundStateNone none = state as RequestNewRoundStateNone;
							none.removeCallBackAndDestroy (typeof(RequestNewRoundStateNoneUpdate));
						}
						break;
					case RequestNewRound.State.Type.Ask:
						{
							RequestNewRoundStateAsk ask = state as RequestNewRoundStateAsk;
							ask.removeCallBackAndDestroy (typeof(RequestNewRoundStateAskUpdate));
						}
						break;
					case RequestNewRound.State.Type.Accept:
						{
							RequestNewRoundStateAccept accept = state as RequestNewRoundStateAccept;
							accept.removeCallBackAndDestroy (typeof(RequestNewRoundStateAcceptUpdate));
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
			if (wrapProperty.p is RequestNewRound) {
				switch ((RequestNewRound.Property)wrapProperty.n) {
				case RequestNewRound.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RequestNewRound.Property.limit:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is RequestNewRound.State) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}