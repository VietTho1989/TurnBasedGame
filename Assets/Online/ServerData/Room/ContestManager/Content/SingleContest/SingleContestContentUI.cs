using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestContentUI : UIBehavior<SingleContestContentUI.UIData>
	{

		#region UIData

		public class UIData : ContestManagerContent.UIData
		{

			public VP<ReferenceData<SingleContestContent>> singleContestContent;

			public VP<ContestUI.UIData> contestUIData;

			#region Constructor

			public enum Property
			{
				singleContestContent,
				contestUIData
			}

			public UIData() : base()
			{
				this.singleContestContent = new VP<ReferenceData<SingleContestContent>>(this, (byte)Property.singleContestContent, new ReferenceData<SingleContestContent>(null));
				this.contestUIData = new VP<ContestUI.UIData>(this, (byte)Property.contestUIData, new ContestUI.UIData());
			}

			#endregion

			public override ContestManagerContent.Type getType ()
			{
				return ContestManagerContent.Type.Single;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// contestUIData
					if (!isProcess) {
						ContestUI.UIData contestUIData = this.contestUIData.v;
						if (contestUIData != null) {
							isProcess = contestUIData.processEvent (e);
						} else {
							Debug.LogError ("contestUIData null: " + this);
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
					SingleContestContent singleContestContent = this.data.singleContestContent.v.data;
					if (singleContestContent != null) {
						// contest
						{
							ContestUI.UIData contestUIData = this.data.contestUIData.v;
							if (contestUIData != null) {
								contestUIData.contest.v = new ReferenceData<Contest> (singleContestContent.contest.v);
							} else {
								Debug.LogError ("contestUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("singleContestContent null: " + this);
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

		public ContestUI contestPrefab;
		public Transform contestContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.singleContestContent.allAddCallBack (this);
					uiData.contestUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is SingleContestContent) {
					dirty = true;
					return;
				}
				if (data is ContestUI.UIData) {
					ContestUI.UIData contestUIData = data as ContestUI.UIData;
					// UI
					{
						UIUtils.Instantiate (contestUIData, contestPrefab, contestContainer);
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
					uiData.singleContestContent.allRemoveCallBack (this);
					uiData.contestUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is SingleContestContent) {
					return;
				}
				if (data is ContestUI.UIData) {
					ContestUI.UIData contestUIData = data as ContestUI.UIData;
					// UI
					{
						contestUIData.removeCallBackAndDestroy (typeof(ContestUI));
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
				case UIData.Property.singleContestContent:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.contestUIData:
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
				if (wrapProperty.p is SingleContestContent) {
					switch ((SingleContestContent.Property)wrapProperty.n) {
					case SingleContestContent.Property.contest:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ContestUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}