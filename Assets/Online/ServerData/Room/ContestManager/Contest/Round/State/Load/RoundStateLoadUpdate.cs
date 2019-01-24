using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RoundStateLoadUpdate : UpdateBehavior<RoundStateLoad>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// chuyen sang start
					Round round = this.data.findDataInParent<Round>();
					if (round != null) {
						RoundStateStart start = new RoundStateStart ();
						{
							start.uid = round.state.makeId ();
						}
						round.state.v = start;
					} else {
						Debug.LogError ("round null: " + this);
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
			if (data is RoundStateLoad) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RoundStateLoad) {
				RoundStateLoad roundStateLoad = data as RoundStateLoad;
				// Child
				{

				}
				this.setDataNull (roundStateLoad);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is RoundStateLoad) {
				switch ((RoundStateLoad.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}