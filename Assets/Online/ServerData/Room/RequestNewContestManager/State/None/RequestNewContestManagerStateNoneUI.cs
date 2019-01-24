using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

namespace GameManager.ContestManager
{
	public class RequestNewContestManagerStateNoneUI : UIBehavior<RequestNewContestManagerStateNoneUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewContestManagerUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewContestManagerStateNone>> requestNewContestManagerStateNone;

			#region Constructor

			public enum Property
			{
				requestNewContestManagerStateNone
			}

			public UIData() : base()
			{
				this.requestNewContestManagerStateNone = new VP<ReferenceData<RequestNewContestManagerStateNone>>(this, (byte)Property.requestNewContestManagerStateNone, new ReferenceData<RequestNewContestManagerStateNone>(null));
			}

			#endregion

			public override RequestNewContestManager.State.Type getType ()
			{
				return RequestNewContestManager.State.Type.None;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewContestManagerStateNone requestNewContestManagerStateNone = this.data.requestNewContestManagerStateNone.v.data;
					if (requestNewContestManagerStateNone != null) {

					} else {
						Debug.LogError ("requestNewContestManagerStateNone null: " + this);
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
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.requestNewContestManagerStateNone.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewContestManagerStateNone) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.requestNewContestManagerStateNone.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RequestNewContestManagerStateNone) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.requestNewContestManagerStateNone:
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
			if (wrapProperty.p is RequestNewContestManagerStateNone) {
				switch ((RequestNewContestManagerStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
		}

		#endregion

	}
}