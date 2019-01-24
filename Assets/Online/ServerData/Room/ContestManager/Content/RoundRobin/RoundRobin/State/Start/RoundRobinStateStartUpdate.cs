using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinStateStartUpdate : UpdateBehavior<RoundRobinStateStart>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundRobin roundRobin = this.data.findDataInParent<RoundRobin> ();
					if (roundRobin != null) {
						RoundRobinStatePlay roundRobinStatePlay = new RoundRobinStatePlay ();
						{
							roundRobinStatePlay.uid = roundRobin.state.makeId ();
						}
						roundRobin.state.v = roundRobinStatePlay;
					} else {
						Debug.LogError ("roundRobin null: " + this);
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
			if (data is RoundRobinStateStart) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundRobinStateStart) {
				RoundRobinStateStart roundRobinStateStart = data as RoundRobinStateStart;
				// Child
				{

				}
				this.setDataNull (roundRobinStateStart);;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RoundRobinStateStart) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}