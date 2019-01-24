using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundContestUI : UIBehavior<RoundContestUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<RoundContest>> roundContest;

			public VP<ContestUI.UIData> contestUIData;

			#region Constructor

			public enum Property
			{
				roundContest,
				contestUIData
			}

			public UIData() : base()
			{
				this.roundContest = new VP<ReferenceData<RoundContest>>(this, (byte)Property.roundContest, new ReferenceData<RoundContest>(null));
				this.contestUIData = new VP<ContestUI.UIData>(this, (byte)Property.contestUIData, new ContestUI.UIData());
			}

			#endregion

			public bool processEvent(Event e)
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
					RoundContest roundContest = this.data.roundContest.v.data;
					if (roundContest != null) {
						// contestUIData
						{
							ContestUI.UIData contestUIData = this.data.contestUIData.v;
							if (contestUIData != null) {
								contestUIData.contest.v = new ReferenceData<Contest> (roundContest.contest.v);
							} else {
								Debug.LogError ("contestUIData null: " + this);
							}
						}
					} else {
						Debug.LogError ("roundContest null: " + this);
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
					uiData.roundContest.allAddCallBack (this);
					uiData.contestUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is RoundContest) {
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
					uiData.roundContest.allRemoveCallBack (this);
					uiData.contestUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is RoundContest) {
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
				case UIData.Property.roundContest:
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
				if (wrapProperty.p is RoundContest) {
					switch ((RoundContest.Property)wrapProperty.n) {
					case RoundContest.Property.index:
						break;
					case RoundContest.Property.teamIndexs:
						break;
					case RoundContest.Property.contest:
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