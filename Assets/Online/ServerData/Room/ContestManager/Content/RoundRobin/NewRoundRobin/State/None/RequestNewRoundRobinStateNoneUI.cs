using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateNoneUI : UIBehavior<RequestNewRoundRobinStateNoneUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundRobinUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewRoundRobinStateNone>> requestNewRoundRobinStateNone;

			#region Constructor

			public enum Property
			{
				requestNewRoundRobinStateNone
			}

			public UIData() : base()
			{
				this.requestNewRoundRobinStateNone = new VP<ReferenceData<RequestNewRoundRobinStateNone>>(this, (byte)Property.requestNewRoundRobinStateNone, new ReferenceData<RequestNewRoundRobinStateNone>(null));
			}

			#endregion

			public override RequestNewRoundRobin.State.Type getType ()
			{
				return RequestNewRoundRobin.State.Type.None;
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
					RequestNewRoundRobinStateNone requestNewRoundRobinStateNone = this.data.requestNewRoundRobinStateNone.v.data;
					if (requestNewRoundRobinStateNone != null) {

					} else {
						Debug.LogError ("requestNewRoundRobinStateNone null: " + this);
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
					uiData.requestNewRoundRobinStateNone.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewRoundRobinStateNone) {
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
					uiData.requestNewRoundRobinStateNone.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RequestNewRoundRobinStateNone) {
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
				case UIData.Property.requestNewRoundRobinStateNone:
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
			if (wrapProperty.p is RequestNewRoundRobinStateNone) {
				switch ((RequestNewRoundRobinStateNone.Property)wrapProperty.n) {
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