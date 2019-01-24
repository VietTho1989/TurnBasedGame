using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateNoneUI : UIBehavior<RequestNewRoundStateNoneUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewRoundStateNone>> requestNewRoundStateNone;

			#region Constructor

			public enum Property
			{
				requestNewRoundStateNone
			}

			public UIData() : base()
			{
				this.requestNewRoundStateNone = new VP<ReferenceData<RequestNewRoundStateNone>>(this, (byte)Property.requestNewRoundStateNone, new ReferenceData<RequestNewRoundStateNone>(null));
			}

			#endregion

			public override RequestNewRound.State.Type getType ()
			{
				return RequestNewRound.State.Type.None;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{

				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RequestNewRoundStateNone requestNewRoundStateNone = this.data.requestNewRoundStateNone.v.data;
					if (requestNewRoundStateNone != null) {

					} else {
						Debug.LogError ("Don't process: " + requestNewRoundStateNone + "; " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
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
					uiData.requestNewRoundStateNone.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewRoundStateNone) {
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
					uiData.requestNewRoundStateNone.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RequestNewRoundStateNone) {
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
				case UIData.Property.requestNewRoundStateNone:
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
			if (wrapProperty.p is RequestNewRoundStateNone) {
				switch ((RequestNewRoundStateNone.Property)wrapProperty.n) {
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}