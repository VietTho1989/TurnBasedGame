using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateAcceptUpdate : UpdateBehavior<RequestNewRoundStateAccept>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (!RequestNewRound.IsCanMakeNewRound (this.data)) {
						// Chuyen ve none
						RequestNewRound requestNewRound = this.data.findDataInParent<RequestNewRound>();
						if (requestNewRound != null) {
							RequestNewRoundStateNone none = new RequestNewRoundStateNone ();
							{
								none.uid = requestNewRound.state.makeId ();
							}
							requestNewRound.state.v = none;
						} else {
							Debug.LogError ("requestNewRound null: " + this);
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

		private CheckCanMakeNewRoundChange<RequestNewRoundStateAccept> checkCanMakeNewRoundChange = new CheckCanMakeNewRoundChange<RequestNewRoundStateAccept> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundStateAccept) {
				RequestNewRoundStateAccept requestNewRoundStateAccept = data as RequestNewRoundStateAccept;
				// CheckChange
				{
					checkCanMakeNewRoundChange.addCallBack (this);
					checkCanMakeNewRoundChange.setData (requestNewRoundStateAccept);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewRoundChange<RequestNewRoundStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewRoundStateAccept) {
				RequestNewRoundStateAccept requestNewRoundStateAccept = data as RequestNewRoundStateAccept;
				// CheckChange
				{
					checkCanMakeNewRoundChange.removeCallBack (this);
					checkCanMakeNewRoundChange.setData (null);
				}
				this.setDataNull (requestNewRoundStateAccept);
				return;
			}
			// CheckChange
			if (data is CheckCanMakeNewRoundChange<RequestNewRoundStateAccept>) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is RequestNewRoundStateAccept) {
				switch ((RequestNewRoundStateAccept.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is CheckCanMakeNewRoundChange<RequestNewRoundStateAccept>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}