using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinUpdate : UpdateBehavior<RoundRobin>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundRobin.State state = this.data.state.v;
					if (state != null) {
						switch (state.getType ()) {
						case RoundRobin.State.Type.Load:
						case RoundRobin.State.Type.Start:
							{
								foreach (RoundContest roundContest in this.data.roundContests.vs) {
									roundContest.removeCallBackAndDestroy (typeof(RoundContestUpdate));
								}
								this.data.removeCallBackAndDestroy (typeof(RoundRobinCheckEndUpdate));
							}
							break;
						case RoundRobin.State.Type.Play:
						case RoundRobin.State.Type.End:
							{
								foreach (RoundContest roundContest in this.data.roundContests.vs) {
									UpdateUtils.makeUpdate<RoundContestUpdate, RoundContest> (roundContest, this.transform);
								}
								UpdateUtils.makeUpdate<RoundRobinCheckEndUpdate, RoundRobin> (this.data, this.transform);
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("state null: " + this);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is RoundRobin) {
				RoundRobin roundRobin = data as RoundRobin;
				// Update
				{

				}
				// Child
				{
					roundRobin.roundContests.allAddCallBack (this);
					roundRobin.state.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RoundContest) {
					dirty = true;
					return;
				}
				if (data is RoundRobin.State) {
					RoundRobin.State state = data as RoundRobin.State;
					// Update
					{
						switch (state.getType ()) {
						case RoundRobin.State.Type.Load:
							{
								RoundRobinStateLoad load = state as RoundRobinStateLoad;
								UpdateUtils.makeUpdate<RoundRobinStateLoadUpdate, RoundRobinStateLoad> (load, this.transform);
							}
							break;
						case RoundRobin.State.Type.Start:
							{
								RoundRobinStateStart start = state as RoundRobinStateStart;
								UpdateUtils.makeUpdate<RoundRobinStateStartUpdate, RoundRobinStateStart> (start, this.transform);
							}
							break;
						case RoundRobin.State.Type.Play:
							{
								RoundRobinStatePlay play = state as RoundRobinStatePlay;
								UpdateUtils.makeUpdate<RoundRobinStatePlayUpdate, RoundRobinStatePlay> (play, this.transform);
							}
							break;
						case RoundRobin.State.Type.End:
							{
								RoundRobinStateEnd end = state as RoundRobinStateEnd;
								UpdateUtils.makeUpdate<RoundRobinStateEndUpdate, RoundRobinStateEnd> (end, this.transform);
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
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundRobin) {
				RoundRobin roundRobin = data as RoundRobin;
				// Update
				{
					roundRobin.removeCallBackAndDestroy (typeof(RoundRobinCheckEndUpdate));
				}
				// Child
				{
					roundRobin.roundContests.allRemoveCallBack (this);
					roundRobin.state.allRemoveCallBack (this);
				}
				this.setDataNull (roundRobin);
				return;
			}
			// Child
			{
				if (data is RoundContest) {
					RoundContest roundContest = data as RoundContest;
					// Update
					{
						roundContest.removeCallBackAndDestroy (typeof(RoundContestUpdate));
					}
					return;
				}
				if (data is RoundRobin.State) {
					RoundRobin.State state = data as RoundRobin.State;
					// Update
					{
						switch (state.getType ()) {
						case RoundRobin.State.Type.Load:
							{
								RoundRobinStateLoad load = state as RoundRobinStateLoad;
								load.removeCallBackAndDestroy (typeof(RoundRobinStateLoadUpdate));
							}
							break;
						case RoundRobin.State.Type.Start:
							{
								RoundRobinStateStart start = state as RoundRobinStateStart;
								start.removeCallBackAndDestroy (typeof(RoundRobinStateStartUpdate));
							}
							break;
						case RoundRobin.State.Type.Play:
							{
								RoundRobinStatePlay play = state as RoundRobinStatePlay;
								play.removeCallBackAndDestroy (typeof(RoundRobinStatePlayUpdate));
							}
							break;
						case RoundRobin.State.Type.End:
							{
								RoundRobinStateEnd end = state as RoundRobinStateEnd;
								end.removeCallBackAndDestroy (typeof(RoundRobinStateEndUpdate));
							}
							break;
						default:
							Debug.LogError ("unknown type: " + state.getType () + "; " + this);
							break;
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
			if (wrapProperty.p is RoundRobin) {
				switch ((RoundRobin.Property)wrapProperty.n) {
				case RoundRobin.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case RoundRobin.Property.index:
					break;
				case RoundRobin.Property.roundContests:
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
				if (wrapProperty.p is RoundContest) {
					return;
				}
				if (wrapProperty.p is RoundRobin.State) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}