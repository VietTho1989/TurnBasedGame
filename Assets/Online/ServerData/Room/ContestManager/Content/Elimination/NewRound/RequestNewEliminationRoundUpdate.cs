using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundUpdate : UpdateBehavior<RequestNewEliminationRound>
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
			if (data is RequestNewEliminationRound) {
				RequestNewEliminationRound requestNewEliminationRound = data as RequestNewEliminationRound;
				// Child
				{
					requestNewEliminationRound.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewEliminationRound.State) {
				RequestNewEliminationRound.State state = data as RequestNewEliminationRound.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewEliminationRound.State.Type.None:
						{
							RequestNewEliminationRoundStateNone none = state as RequestNewEliminationRoundStateNone;
							UpdateUtils.makeUpdate<RequestNewEliminationRoundStateNoneUpdate, RequestNewEliminationRoundStateNone> (none, this.transform);
						}
						break;
					case RequestNewEliminationRound.State.Type.Ask:
						{
							RequestNewEliminationRoundStateAsk ask = state as RequestNewEliminationRoundStateAsk;
							UpdateUtils.makeUpdate<RequestNewEliminationRoundStateAskUpdate, RequestNewEliminationRoundStateAsk> (ask, this.transform);
						}
						break;
					case RequestNewEliminationRound.State.Type.Accept:
						{
							RequestNewEliminationRoundStateAccept accept = state as RequestNewEliminationRoundStateAccept;
							UpdateUtils.makeUpdate<RequestNewEliminationRoundStateAcceptUpdate, RequestNewEliminationRoundStateAccept> (accept, this.transform);
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
			if (data is RequestNewEliminationRound) {
				RequestNewEliminationRound requestNewEliminationRound = data as RequestNewEliminationRound;
				// Child
				{
					requestNewEliminationRound.state.allRemoveCallBack (this);
				}
				this.setDataNull (requestNewEliminationRound);
				return;
			}
			// Child
			if (data is RequestNewEliminationRound.State) {
				RequestNewEliminationRound.State state = data as RequestNewEliminationRound.State;
				// Update
				{
					switch (state.getType ()) {
					case RequestNewEliminationRound.State.Type.None:
						{
							RequestNewEliminationRoundStateNone none = state as RequestNewEliminationRoundStateNone;
							none.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundStateNoneUpdate));
						}
						break;
					case RequestNewEliminationRound.State.Type.Ask:
						{
							RequestNewEliminationRoundStateAsk ask = state as RequestNewEliminationRoundStateAsk;
							ask.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundStateAskUpdate));
						}
						break;
					case RequestNewEliminationRound.State.Type.Accept:
						{
							RequestNewEliminationRoundStateAccept accept = state as RequestNewEliminationRoundStateAccept;
							accept.removeCallBackAndDestroy (typeof(RequestNewEliminationRoundStateAcceptUpdate));
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
			if (wrapProperty.p is RequestNewEliminationRound) {
				switch ((RequestNewEliminationRound.Property)wrapProperty.n) {
				case RequestNewEliminationRound.Property.state:
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
			// Child
			if (wrapProperty.p is RequestNewEliminationRound.State) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}