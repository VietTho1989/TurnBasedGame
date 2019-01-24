using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FileSystem
{
	public class SingleShowUI : UIBehavior<SingleShowUI.UIData>
	{

		#region UIData

		public class UIData : Show.UIData
		{

			public VP<ReferenceData<SingleShow>> singleShow;

			public VP<ShowDirectoryUI.UIData> showDirectoryUIData;

			#region Constructor

			public enum Property
			{
				singleShow,
				showDirectoryUIData
			}

			public UIData() : base()
			{
				this.singleShow = new VP<ReferenceData<SingleShow>>(this, (byte)Property.singleShow, new ReferenceData<SingleShow>(null));
				this.showDirectoryUIData = new VP<ShowDirectoryUI.UIData>(this, (byte)Property.showDirectoryUIData, new ShowDirectoryUI.UIData());
			}

			#endregion

			public override Show.Type getType ()
			{
				return Show.Type.Single;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// showDirectoryUIData
					if (!isProcess) {
						ShowDirectoryUI.UIData showDirectoryUIData = this.showDirectoryUIData.v;
						if (showDirectoryUIData != null) {
							isProcess = showDirectoryUIData.processEvent (e);
						} else {
							Debug.LogError ("showDirectoryUIData null: " + this);
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
					SingleShow singleShow = this.data.singleShow.v.data;
					if (singleShow != null) {
						// showDirectoryUIData
						{
							ShowDirectoryUI.UIData showDirectoryUIData = this.data.showDirectoryUIData.v;
							if (showDirectoryUIData != null) {
								showDirectoryUIData.showDirectory.v = new ReferenceData<ShowDirectory> (singleShow.showDirectory.v);
							} else {
								Debug.LogError ("showDirectoryUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("singleShow null: " + this);
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

		public ShowDirectoryUI showDirectoryPrefab;
		public Transform showDirectoryContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.singleShow.allAddCallBack (this);
					uiData.showDirectoryUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is SingleShow) {
					dirty = true;
					return;
				}
				if (data is ShowDirectoryUI.UIData) {
					ShowDirectoryUI.UIData showDirectoryUIData = data as ShowDirectoryUI.UIData;
					// UI
					{
						UIUtils.Instantiate (showDirectoryUIData, showDirectoryPrefab, showDirectoryContainer);
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
					uiData.singleShow.allRemoveCallBack (this);
					uiData.showDirectoryUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is SingleShow) {
					return;
				}
				if (data is ShowDirectoryUI.UIData) {
					ShowDirectoryUI.UIData showDirectoryUIData = data as ShowDirectoryUI.UIData;
					// UI
					{
						showDirectoryUIData.removeCallBackAndDestroy (typeof(ShowDirectoryUI));
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
				case UIData.Property.singleShow:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.showDirectoryUIData:
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
				if (wrapProperty.p is SingleShow) {
					switch ((SingleShow.Property)wrapProperty.n) {
					case SingleShow.Property.showDirectory:
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
				if (wrapProperty.p is ShowDirectoryUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}