using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match.Swap
{
	public class SwapRequestStateCancelUpdate : UpdateBehavior<SwapRequestStateCancel>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.time.v > this.data.duration.v) {
						// remove
						Swap swap = this.data.findDataInParent<Swap>();
						if (swap != null) {
							SwapRequest swapRequest = this.data.findDataInParent<SwapRequest> ();
							if (swapRequest != null) {
								swap.swapRequests.remove (swapRequest);
							} else {
								Debug.LogError ("swapRequest null: " + this);
							}
						} else {
							Debug.LogError ("swap null: " + this);
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region Task

		private Routine time;

		void Awake() {
			startRoutine (ref this.time, TaskUpdateTime());
		}

		public IEnumerator TaskUpdateTime()
		{
			while (true) {
				yield return new Wait (1f);
				if (this.data != null) {
					this.data.time.v = this.data.time.v + 1;
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (time);
			}
			return ret;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is SwapRequestStateCancel) {
				SwapRequestStateCancel swapRequestStateCancel = data as SwapRequestStateCancel;
				// Child
				{
					swapRequestStateCancel.whoCancel.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
				}
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is SwapRequestStateCancel) {
				SwapRequestStateCancel swapRequestStateCancel = data as SwapRequestStateCancel;
				// Child
				{
					swapRequestStateCancel.whoCancel.allRemoveCallBack (this);
				}
				this.setDataNull (swapRequestStateCancel);
				return;
			}
			// Child
			if (data is Human) {
				Human human = data as Human;
				// Update
				{
					human.removeCallBackAndDestroy (typeof(HumanUpdate));
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
			if (wrapProperty.p is SwapRequestStateCancel) {
				switch ((SwapRequestStateCancel.Property)wrapProperty.n) {
				case SwapRequestStateCancel.Property.whoCancel:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case SwapRequestStateCancel.Property.time:
					dirty = true;
					break;
				case SwapRequestStateCancel.Property.duration:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is Human) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}