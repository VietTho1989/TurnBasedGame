using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundStateAcceptUI : UIBehavior<RequestNewRoundStateAcceptUI.UIData>
	{

		#region UIData

		public class UIData : RequestNewRoundUI.UIData.Sub
		{

			public VP<ReferenceData<RequestNewRoundStateAccept>> requestNewRoundStateAccept;

			#region Constructor

			public enum Property
			{
				requestNewRoundStateAccept
			}

			public UIData() : base()
			{
				this.requestNewRoundStateAccept = new VP<ReferenceData<RequestNewRoundStateAccept>>(this, (byte)Property.requestNewRoundStateAccept, new ReferenceData<RequestNewRoundStateAccept>(null));
			}

			#endregion

			public override RequestNewRound.State.Type getType ()
			{
				return RequestNewRound.State.Type.Accept;
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
					RequestNewRoundStateAccept requestNewRoundStateAccept = this.data.requestNewRoundStateAccept.v.data;
					if (requestNewRoundStateAccept != null) {

					} else {
						Debug.LogError ("requestNewRoundStateAccept null: " + this);
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
					uiData.requestNewRoundStateAccept.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RequestNewRoundStateAccept) {
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
					uiData.requestNewRoundStateAccept.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is RequestNewRoundStateAccept) {
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
				case UIData.Property.requestNewRoundStateAccept:
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
			if (wrapProperty.p is RequestNewRoundStateAccept) {
				switch ((RequestNewRoundStateAccept.Property)wrapProperty.n) {
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