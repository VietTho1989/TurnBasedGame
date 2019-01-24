using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerListUI : UIBehavior<LimitRoomContainerListUI.UIData>
{

	#region UIData

	public class UIData : AllLimitRoomContainersUI.UIData.Sub
	{

		public VP<ReferenceData<AllLimitRoomContainers>> allLimitRoomContainers;

		public VP<LimitRoomContainerAdapter.UIData> adapter;

		public VP<JoinLimitRoomContainerUI.UIData> joinLimitRoomContainerUIData;

		#region Constructor

		public enum Property
		{
			allLimitRoomContainers,
			adapter,
			joinLimitRoomContainerUIData
		}

		public UIData() : base()
		{
			this.allLimitRoomContainers = new VP<ReferenceData<AllLimitRoomContainers>>(this, (byte)Property.allLimitRoomContainers, new ReferenceData<AllLimitRoomContainers>(null));
			this.adapter = new VP<LimitRoomContainerAdapter.UIData>(this, (byte)Property.adapter, new LimitRoomContainerAdapter.UIData());
			this.joinLimitRoomContainerUIData = new VP<JoinLimitRoomContainerUI.UIData>(this, (byte)Property.joinLimitRoomContainerUIData, new JoinLimitRoomContainerUI.UIData());
		}

		#endregion

		public override Type getType ()
		{
			return Type.List;
		}

		public override bool processEvent (Event e)
		{
			bool isProcess = false;
			{
				// joinLimitRoomContainerUIData
				if (!isProcess) {
					JoinLimitRoomContainerUI.UIData joinLimitRoomContainerUIData = this.joinLimitRoomContainerUIData.v;
					if (joinLimitRoomContainerUIData != null) {
						isProcess = joinLimitRoomContainerUIData.processEvent (e);
					} else {
						Debug.LogError ("joinLimitRoomContainerUIData null");
					}
				}
			}
			return isProcess;
		}

		public void reset()
		{
			this.joinLimitRoomContainerUIData.v = null;
		}

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				AllLimitRoomContainers allLimitRoomContainers = this.data.allLimitRoomContainers.v.data;
				if (allLimitRoomContainers != null) {
					// adapter
					{
						LimitRoomContainerAdapter.UIData adapter = this.data.adapter.v;
						if (adapter != null) {
							adapter.allLimitRoomContainers.v = new ReferenceData<AllLimitRoomContainers> (allLimitRoomContainers);
						} else {
							Debug.LogError ("adapter null");
						}
					}
				} else {
					Debug.LogError ("allLimitRoomContainers null");
				}
			} else {
				Debug.LogError ("data null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public LimitRoomContainerAdapter adapterPrefab;
	public Transform adapterContainer;

	public JoinLimitRoomContainerUI joinLimitRoomContainerPrefab;
	public Transform joinLimitRoomContainerContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// reset
			{
				if (this.data != null) {
					this.data.reset ();
				} else {
					Debug.LogError ("data null");
				}
			}
			// Child
			{
				uiData.adapter.allAddCallBack (this);
				uiData.joinLimitRoomContainerUIData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is LimitRoomContainerAdapter.UIData) {
				LimitRoomContainerAdapter.UIData limitRoomContainerAdapterUIData = data as LimitRoomContainerAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (limitRoomContainerAdapterUIData, adapterPrefab, adapterContainer);
				}
				dirty = true;
				return;
			}
			if (data is JoinLimitRoomContainerUI.UIData) {
				JoinLimitRoomContainerUI.UIData joinLimitRoomContainerUIData = data as JoinLimitRoomContainerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (joinLimitRoomContainerUIData, joinLimitRoomContainerPrefab, joinLimitRoomContainerContainer);
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
				uiData.adapter.allRemoveCallBack (this);
				uiData.joinLimitRoomContainerUIData.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is LimitRoomContainerAdapter.UIData) {
				LimitRoomContainerAdapter.UIData limitRoomContainerAdapterUIData = data as LimitRoomContainerAdapter.UIData;
				// UI
				{
					limitRoomContainerAdapterUIData.removeCallBackAndDestroy (typeof(LimitRoomContainerAdapter));
				}
				return;
			}
			if (data is JoinLimitRoomContainerUI.UIData) {
				JoinLimitRoomContainerUI.UIData joinLimitRoomContainerUIData = data as JoinLimitRoomContainerUI.UIData;
				// UI
				{
					joinLimitRoomContainerUIData.removeCallBackAndDestroy (typeof(JoinLimitRoomContainerUI));
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
			case UIData.Property.allLimitRoomContainers:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.adapter:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.joinLimitRoomContainerUIData:
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
			if (wrapProperty.p is LimitRoomContainerAdapter.UIData) {
				return;
			}
			if (wrapProperty.p is JoinLimitRoomContainerUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}