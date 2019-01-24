using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class SwapRequestStateAcceptUI : UIBehavior<SwapRequestStateAcceptUI.UIData>
	{

		#region UIData

		public class UIData : HaveRequestSwapPlayerUI.UIData.StateUI
		{

			public VP<ReferenceData<SwapRequestStateAccept>> swapRequestStateAccept;

			#region Constructor

			public enum Property
			{
				swapRequestStateAccept
			}

			public UIData() : base()
			{
				this.swapRequestStateAccept = new VP<ReferenceData<SwapRequestStateAccept>>(this, (byte)Property.swapRequestStateAccept, new ReferenceData<SwapRequestStateAccept>(null));
			}

			#endregion

			public override SwapRequest.State.Type getType ()
			{
				return SwapRequest.State.Type.Accept;
			}

		}

		#endregion

		#region Refresh

		public Text tvTime;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SwapRequestStateAccept swapRequestStateAccept = this.data.swapRequestStateAccept.v.data;
					if (swapRequestStateAccept != null) {
						// tvTime
						{
							if (tvTime != null) {
								tvTime.text = "Time: " + swapRequestStateAccept.time.v + "/" + swapRequestStateAccept.duration.v;
							} else {
								Debug.LogError ("tvTime null: " + this);
							}
						}
					} else {
						Debug.LogError ("swapRequestStateAccept null: " + this);
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
					uiData.swapRequestStateAccept.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is SwapRequestStateAccept) {
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
					uiData.swapRequestStateAccept.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is SwapRequestStateAccept) {
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
				case UIData.Property.swapRequestStateAccept:
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
			if (wrapProperty.p is SwapRequestStateAccept) {
				switch ((SwapRequestStateAccept.Property)wrapProperty.n) {
				case SwapRequestStateAccept.Property.time:
					dirty = true;
					break;
				case SwapRequestStateAccept.Property.duration:
					dirty = true;
					break;
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