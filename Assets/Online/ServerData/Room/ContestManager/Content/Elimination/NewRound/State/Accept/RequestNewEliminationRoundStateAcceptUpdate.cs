using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class RequestNewEliminationRoundStateAcceptUpdate : UpdateBehavior<RequestNewEliminationRoundStateAccept>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (!RequestNewEliminationRound.IsCanMakeNewRound (this.data)) {
						RequestNewEliminationRound requestNewEliminationRound = this.data.findDataInParent<RequestNewEliminationRound> ();
						if (requestNewEliminationRound != null) {
							// change to state none
							RequestNewEliminationRoundStateNone none = new RequestNewEliminationRoundStateNone();
							{
								none.uid = requestNewEliminationRound.state.makeId ();
							}
							requestNewEliminationRound.state.v = none;
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

		private EliminationRoundCheckChange<RequestNewEliminationRoundStateAccept> eliminationRoundCheckChange = new EliminationRoundCheckChange<RequestNewEliminationRoundStateAccept>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewEliminationRoundStateAccept) {
				RequestNewEliminationRoundStateAccept requestNewEliminationRoundStateAccept = data as RequestNewEliminationRoundStateAccept;
				// CheckChange
				{
					eliminationRoundCheckChange.addCallBack (this);
					eliminationRoundCheckChange.setData (requestNewEliminationRoundStateAccept);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<RequestNewEliminationRoundStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewEliminationRoundStateAccept) {
				RequestNewEliminationRoundStateAccept requestNewEliminationRoundStateAccept = data as RequestNewEliminationRoundStateAccept;
				// CheckChange
				{
					eliminationRoundCheckChange.removeCallBack (this);
					eliminationRoundCheckChange.setData (null);
				}
				this.setDataNull (requestNewEliminationRoundStateAccept);
				return;
			}
			// CheckChange
			if (data is EliminationRoundCheckChange<RequestNewEliminationRoundStateAccept>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewEliminationRoundStateAccept) {
				switch ((RequestNewEliminationRoundStateAccept.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is EliminationRoundCheckChange<RequestNewEliminationRoundStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}