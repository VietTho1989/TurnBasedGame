using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
	public class BtnShowSwapUI : UIBehavior<BtnShowSwapUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Swap>> swap;

			#region Constructor

			public enum Property
			{
				swap
			}

			public UIData() : base()
			{
				this.swap = new VP<ReferenceData<Swap>>(this, (byte)Property.swap, new ReferenceData<Swap>(null));
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Text tvRequestCount;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Swap swap = this.data.swap.v.data;
					if (swap != null) {
						// tvRequestCount
						{
							if (tvRequestCount != null) {
								if (swap.swapRequests.vs.Count > 0) {
									tvRequestCount.text = "" + swap.swapRequests.vs.Count;
								} else {
									tvRequestCount.text = "";
								}
							} else {
								Debug.LogError ("tvRequestCount null: " + this);
							}
						}
					} else {
						Debug.LogError ("swap null: " + this);
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
					uiData.swap.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Swap) {
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
					uiData.swap.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is Swap) {
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
				case UIData.Property.swap:
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
			if (wrapProperty.p is Swap) {
				switch ((Swap.Property)wrapProperty.n) {
				case Swap.Property.swapRequests:
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

		public void onClickBtnShow()
		{
			if (this.data != null) {
				ContestManagerStatePlayUI.UIData contestManagerStatePlayUIData = this.data.findDataInParent<ContestManagerStatePlayUI.UIData> ();
				if (contestManagerStatePlayUIData != null) {
					SwapUI.UIData swapUIData = contestManagerStatePlayUIData.swapUIData.newOrOld<SwapUI.UIData> ();
					{

					}
					contestManagerStatePlayUIData.swapUIData.v = swapUIData;
				} else {
					Debug.LogError ("contestManagerStatePlayUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}