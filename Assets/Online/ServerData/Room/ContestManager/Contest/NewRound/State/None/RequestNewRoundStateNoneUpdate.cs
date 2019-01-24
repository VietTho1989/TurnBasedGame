using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateNoneUpdate : UpdateBehavior<RequestNewRoundStateNone>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (RequestNewRound.IsCanMakeNewRound (this.data)) {
						RequestNewRound requestNewRound = this.data.findDataInParent<RequestNewRound> ();
						if (requestNewRound != null) {
							// Chuyen sang ask
							RequestNewRoundStateAsk ask = new RequestNewRoundStateAsk();
							{
								ask.uid = requestNewRound.state.makeId ();
							}
							requestNewRound.state.v = ask;
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

		private CheckCanMakeNewRoundChange<RequestNewRoundStateNone> checkCanMakeNewRoundChange = new CheckCanMakeNewRoundChange<RequestNewRoundStateNone>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is RequestNewRoundStateNone) {
				RequestNewRoundStateNone requestNewRoundStateNone = data as RequestNewRoundStateNone;
				// CheckChange
				{
					checkCanMakeNewRoundChange.addCallBack (this);
					checkCanMakeNewRoundChange.setData (requestNewRoundStateNone);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if(data is CheckCanMakeNewRoundChange<RequestNewRoundStateNone>){
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is RequestNewRoundStateNone) {
				RequestNewRoundStateNone requestNewRoundStateNone = data as RequestNewRoundStateNone;
				// CheckChange
				{
					checkCanMakeNewRoundChange.removeCallBack (this);
					checkCanMakeNewRoundChange.setData (null);
				}
				this.setDataNull (requestNewRoundStateNone);
				return;
			}
			// CheckChange
			if(data is CheckCanMakeNewRoundChange<RequestNewRoundStateNone>){
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is RequestNewRoundStateNone) {
				switch ((RequestNewRoundStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if(wrapProperty.p is CheckCanMakeNewRoundChange<RequestNewRoundStateNone>){
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}