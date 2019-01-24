using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class ChooseRoundRobinUI : UIBehavior<ChooseRoundRobinUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<RoundRobinContent>> roundRobinContent;

			public VP<ChooseRoundRobinAdapter.UIData> chooseRoundRobinAdapter;

			#region Constructor

			public enum Property
			{
				roundRobinContent,
				chooseRoundRobinAdapter
			}

			public UIData() : base()
			{
				this.roundRobinContent = new VP<ReferenceData<RoundRobinContent>>(this, (byte)Property.roundRobinContent, new ReferenceData<RoundRobinContent>(null));
				this.chooseRoundRobinAdapter = new VP<ChooseRoundRobinAdapter.UIData>(this, (byte)Property.chooseRoundRobinAdapter, new ChooseRoundRobinAdapter.UIData());
			}

			#endregion

			public bool processEvent(Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							ChooseRoundRobinUI chooseRoundRobinUI = this.findCallBack<ChooseRoundRobinUI> ();
							if (chooseRoundRobinUI != null) {
								chooseRoundRobinUI.onClickBtnBack ();
							} else {
								Debug.LogError ("chooseRoundRobinUI null: " + this);
							}
							isProcess = true;
						}
					}
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
					RoundRobinContent roundRobinContent = this.data.roundRobinContent.v.data;
					if (roundRobinContent != null) {
						// chooseRoundRobinAdapter
						{
							ChooseRoundRobinAdapter.UIData chooseRoundRobinAdapterUIData = this.data.chooseRoundRobinAdapter.v;
							if (chooseRoundRobinAdapterUIData != null) {
								chooseRoundRobinAdapterUIData.roundRobinContent.v = new ReferenceData<RoundRobinContent> (roundRobinContent);
							} else {
								Debug.LogError ("chooseRoundRobinAdapterUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("roundRobinContent null: " + this);
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

		public ChooseRoundRobinAdapter chooseRoundRobinAdapterPrefab;
		public Transform chooseRoundRobinAdapterContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.roundRobinContent.allAddCallBack (this);
					uiData.chooseRoundRobinAdapter.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RoundRobinContent) {
					dirty = true;
					return;
				}
				if (data is ChooseRoundRobinAdapter.UIData) {
					ChooseRoundRobinAdapter.UIData chooseRoundRobinAdapterUIData = data as ChooseRoundRobinAdapter.UIData;
					// UI
					{
						UIUtils.Instantiate (chooseRoundRobinAdapterUIData, chooseRoundRobinAdapterPrefab, chooseRoundRobinAdapterContainer);
					}
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
					uiData.roundRobinContent.allRemoveCallBack (this);
					uiData.chooseRoundRobinAdapter.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is RoundRobinContent) {
					return;
				}
				if (data is ChooseRoundRobinAdapter.UIData) {
					ChooseRoundRobinAdapter.UIData chooseRoundRobinAdapterUIData = data as ChooseRoundRobinAdapter.UIData;
					// UI
					{
						chooseRoundRobinAdapterUIData.removeCallBackAndDestroy (typeof(ChooseRoundRobinAdapter));
					}
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
				case UIData.Property.roundRobinContent:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.chooseRoundRobinAdapter:
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
				if (wrapProperty.p is RoundRobinContent) {
					return;
				}
				if (wrapProperty.p is ChooseRoundRobinAdapter.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				RoundRobinContentUI.UIData roundRobinContentUIData = this.data.findDataInParent<RoundRobinContentUI.UIData> ();
				if (roundRobinContentUIData != null) {
					roundRobinContentUIData.chooseRoundRobinUIData.v = null;
				} else {
					Debug.LogError ("roundRobinContentUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}