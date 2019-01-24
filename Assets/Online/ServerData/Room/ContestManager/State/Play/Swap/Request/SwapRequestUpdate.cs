using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class SwapRequestUpdate : UpdateBehavior<SwapRequest>
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
			if (data is SwapRequest) {
				SwapRequest swapRequest = data as SwapRequest;
				// Child
				{
					swapRequest.state.allAddCallBack (this);
					swapRequest.inform.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is SwapRequest.State) {
					SwapRequest.State state = data as SwapRequest.State;
					// Update
					{
						switch (state.getType ()) {
						case SwapRequest.State.Type.Ask:
							{
								SwapRequestStateAsk ask = state as SwapRequestStateAsk;
								UpdateUtils.makeUpdate<SwapRequestStateAskUpdate, SwapRequestStateAsk> (ask, this.transform);
							}
							break;
						case SwapRequest.State.Type.Accept:
							{
								SwapRequestStateAccept accept = state as SwapRequestStateAccept;
								UpdateUtils.makeUpdate<SwapRequestStateAcceptUpdate, SwapRequestStateAccept> (accept, this.transform);
							}
							break;
						case SwapRequest.State.Type.Cancel:
							{
								SwapRequestStateCancel cancel = state as SwapRequestStateCancel;
								UpdateUtils.makeUpdate<SwapRequestStateCancelUpdate, SwapRequestStateCancel> (cancel, this.transform);
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
				if (data is GamePlayer.Inform) {
					GamePlayer.Inform inform = data as GamePlayer.Inform;
					// Update
					{
						if (inform is Human) {
							Human human = inform as Human;
							UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
						}
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SwapRequest) {
				SwapRequest swapRequest = data as SwapRequest;
				// Child
				{
					swapRequest.state.allRemoveCallBack (this);
					swapRequest.inform.allRemoveCallBack (this);
				}
				this.setDataNull (swapRequest);
				return;
			}
			// Child
			{
				if (data is SwapRequest.State) {
					SwapRequest.State state = data as SwapRequest.State;
					// Update
					{
						switch (state.getType ()) {
						case SwapRequest.State.Type.Ask:
							{
								SwapRequestStateAsk ask = state as SwapRequestStateAsk;
								ask.removeCallBackAndDestroy (typeof(SwapRequestStateAskUpdate));
							}
							break;
						case SwapRequest.State.Type.Accept:
							{
								SwapRequestStateAccept accept = state as SwapRequestStateAccept;
								accept.removeCallBackAndDestroy (typeof(SwapRequestStateAcceptUpdate));
							}
							break;
						case SwapRequest.State.Type.Cancel:
							{
								SwapRequestStateCancel cancel = state as SwapRequestStateCancel;
								cancel.removeCallBackAndDestroy (typeof(SwapRequestStateCancelUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown state: " + state.getType () + "; " + this);
							break;
						}
					}
					return;
				}
				if (data is GamePlayer.Inform) {
					GamePlayer.Inform inform = data as GamePlayer.Inform;
					// Update
					{
						if (inform is Human) {
							Human human = inform as Human;
							human.removeCallBackAndDestroy (typeof(HumanUpdate));
						}
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is SwapRequest) {
				switch ((SwapRequest.Property)wrapProperty.n) {
				case SwapRequest.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case SwapRequest.Property.teamIndex:
					break;
				case SwapRequest.Property.playerIndex:
					break;
				case SwapRequest.Property.inform:
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
			{
				if (wrapProperty.p is SwapRequest.State) {
					return;
				}
				if (wrapProperty.p is Human) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}