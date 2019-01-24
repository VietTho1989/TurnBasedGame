using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerUserListUI : UIBehavior<LimitRoomContainerUserListUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<LimitRoomContainer>> limitRoomContainer;

		public VP<LimitRoomContainerUserAdapter.UIData> adapter;

		#region Constructor

		public enum Property
		{
			limitRoomContainer,
			adapter
		}

		public UIData() : base()
		{
			this.limitRoomContainer = new VP<ReferenceData<LimitRoomContainer>>(this, (byte)Property.limitRoomContainer, new ReferenceData<LimitRoomContainer>(null));
			this.adapter = new VP<LimitRoomContainerUserAdapter.UIData>(this, (byte)Property.adapter, new LimitRoomContainerUserAdapter.UIData());
		}

		#endregion

	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				LimitRoomContainer limitRoomContainer = this.data.limitRoomContainer.v.data;
				if (limitRoomContainer != null) {
					// adapter
					{
						LimitRoomContainerUserAdapter.UIData adapter = this.data.adapter.v;
						if (adapter != null) {
							adapter.limitRoomContainer.v = new ReferenceData<LimitRoomContainer> (limitRoomContainer);
						} else {
							Debug.LogError ("adapter null");
						}
					}
				} else {
					Debug.LogError ("limitRoomContainer null");
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

	public LimitRoomContainerUserAdapter adapterPrefab;
	public Transform adapterContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.limitRoomContainer.allAddCallBack (this);
				uiData.adapter.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is LimitRoomContainer) {
				dirty = true;
				return;
			}
			if (data is LimitRoomContainerUserAdapter.UIData) {
				LimitRoomContainerUserAdapter.UIData adapterUIData = data as LimitRoomContainerUserAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (adapterUIData, adapterPrefab, adapterContainer);
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
				uiData.limitRoomContainer.allRemoveCallBack (this);
				uiData.adapter.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is LimitRoomContainer) {
				return;
			}
			if (data is LimitRoomContainerUserAdapter.UIData) {
				LimitRoomContainerUserAdapter.UIData adapterUIData = data as LimitRoomContainerUserAdapter.UIData;
				// UI
				{
					adapterUIData.removeCallBackAndDestroy (typeof(LimitRoomContainerUserAdapter));
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
			case UIData.Property.limitRoomContainer:
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
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is LimitRoomContainer) {
				return;
			}
			if (wrapProperty.p is LimitRoomContainerUserAdapter.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
	}

	#endregion

}