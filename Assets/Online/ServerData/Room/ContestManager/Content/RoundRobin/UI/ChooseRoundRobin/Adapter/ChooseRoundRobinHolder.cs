using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class ChooseRoundRobinHolder : SriaHolderBehavior<ChooseRoundRobinHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<ReferenceData<RoundRobin>> roundRobin;

			#region Constructor

			public enum Property
			{
				roundRobin
			}

			public UIData() : base()
			{
				this.roundRobin = new VP<ReferenceData<RoundRobin>>(this, (byte)Property.roundRobin, new ReferenceData<RoundRobin>(null));
			}

			#endregion

			public void updateView(ChooseRoundRobinAdapter.UIData myParams)
			{
				// Find
				RoundRobin roundRobin = null;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.roundRobins.Count) {
						roundRobin = myParams.roundRobins [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.roundRobin.v = new ReferenceData<RoundRobin> (roundRobin);
			}

		}

		#endregion

		#region Refresh

		public Text tvIndex;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					RoundRobin roundRobin = this.data.roundRobin.v.data;
					if (roundRobin != null) {
						// tvIndex
						{
							if (tvIndex != null) {
								tvIndex.text = "Index: " + roundRobin.index.v;
							} else {
								Debug.LogError ("tvIndex null: " + this);
							}
						}
					} else {
						Debug.LogError ("roundRobin null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.roundRobin.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RoundRobin) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.roundRobin.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is RoundRobin) {
					return;
				}
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
				case UIData.Property.roundRobin:
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
			{
				if (wrapProperty.p is RoundRobin) {
					switch ((RoundRobin.Property)wrapProperty.n) {
					case RoundRobin.Property.state:
						break;
					case RoundRobin.Property.index:
						dirty = true;
						break;
					case RoundRobin.Property.roundContests:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnShow()
		{
			if (this.data != null) {
				RoundRobin roundRobin = this.data.roundRobin.v.data;
				if (roundRobin != null) {
					RoundRobinContentUI.UIData roundRobinContentUIData = this.data.findDataInParent<RoundRobinContentUI.UIData> ();
					if (roundRobinContentUIData != null) {
						RoundRobinUI.UIData roundRobinUIData = roundRobinContentUIData.roundRobinUIData.v;
						if (roundRobinUIData != null) {
							roundRobinUIData.roundRobin.v = new ReferenceData<RoundRobin> (roundRobin);
						} else {
							Debug.LogError ("roundRobinUIData null: " + this);
						}
					} else {
						Debug.LogError ("roundRobinContentUIData null: " + this);
					}
				} else {
					Debug.LogError ("roundRobin null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}