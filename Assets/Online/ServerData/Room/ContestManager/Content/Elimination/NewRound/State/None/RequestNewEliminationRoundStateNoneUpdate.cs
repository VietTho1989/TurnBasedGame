using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundStateNoneUpdate : UpdateBehavior<RequestNewEliminationRoundStateNone>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewEliminationRound.IsCanMakeNewRound (this.data)) {
						RequestNewEliminationRound requestNewEliminationRound = this.data.findDataInParent<RequestNewEliminationRound> ();
						if (requestNewEliminationRound != null) {
							// change to state ask
							RequestNewEliminationRoundStateAsk ask = new RequestNewEliminationRoundStateAsk();
							{
								ask.uid = requestNewEliminationRound.state.makeId ();
							}
							requestNewEliminationRound.state.v = ask;
						} else {
							Debug.LogError ("requestNewEliminationRound null: " + this);
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

		private EliminationRoundCheckChange<RequestNewEliminationRoundStateNone> eliminationRoundCheckChange = new EliminationRoundCheckChange<RequestNewEliminationRoundStateNone>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewEliminationRoundStateNone) {
				RequestNewEliminationRoundStateNone requestNewEliminationRoundStateNone = data as RequestNewEliminationRoundStateNone;
				// CheckChange
				{
					eliminationRoundCheckChange.addCallBack (this);
					eliminationRoundCheckChange.setData (requestNewEliminationRoundStateNone);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<RequestNewEliminationRoundStateNone>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewEliminationRoundStateNone) {
				RequestNewEliminationRoundStateNone requestNewEliminationRoundStateNone = data as RequestNewEliminationRoundStateNone;
				// CheckChange
				{
					eliminationRoundCheckChange.removeCallBack (this);
					eliminationRoundCheckChange.setData (null);
				}
				this.setDataNull (requestNewEliminationRoundStateNone);
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<RequestNewEliminationRoundStateNone>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewEliminationRoundStateNone) {
				switch ((RequestNewEliminationRoundStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is EliminationRoundCheckChange<RequestNewEliminationRoundStateNone>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}