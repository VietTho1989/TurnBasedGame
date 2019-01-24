using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllLimitRoomContainersUI : UIBehavior<AllLimitRoomContainersUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<AllLimitRoomContainers>> allLimitRoomContainers;

		#region Sub

		public abstract class Sub : Data
		{

			public enum Type
			{
				List,
				Limit
			}

			public abstract Type getType ();

			public abstract bool processEvent(Event e);

		}

		public VP<Sub> sub;

		#endregion

		#region Constructor

		public enum Property
		{
			allLimitRoomContainers,
			sub
		}

		public UIData() : base()
		{
			this.allLimitRoomContainers = new VP<ReferenceData<AllLimitRoomContainers>>(this, (byte)Property.allLimitRoomContainers, new ReferenceData<AllLimitRoomContainers>(null));
			this.sub = new VP<Sub>(this, (byte)Property.sub, null);
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// sub
				if (!isProcess) {
					Sub sub = this.sub.v;
					if (sub != null) {
						isProcess = sub.processEvent (e);
					} else {
						Debug.LogError ("sub null");
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
				AllLimitRoomContainers allLimitRoomContainers = this.data.allLimitRoomContainers.v.data;
				if (allLimitRoomContainers != null) {
					// find limitRoomContainer
					LimitRoomContainer limitRoomContainer = null;
					{
						uint profileId = Server.getProfileUserId (allLimitRoomContainers);
						foreach (LimitRoomContainer check in allLimitRoomContainers.limitRoomContainers.vs) {
							foreach (Human human in check.users.vs) {
								if (human.playerId.v == profileId) {
									limitRoomContainer = check;
									break;
								}
							}
						}
					}
					// process
					if (limitRoomContainer != null) {
						LimitRoomContainerUI.UIData limitRoomContainerUIData = this.data.sub.newOrOld<LimitRoomContainerUI.UIData> ();
						{
							limitRoomContainerUIData.limitRoomContainer.v = new ReferenceData<LimitRoomContainer> (limitRoomContainer);
						}
						this.data.sub.v = limitRoomContainerUIData;
					} else {
						LimitRoomContainerListUI.UIData limitRoomContainerListUIData = this.data.sub.newOrOld<LimitRoomContainerListUI.UIData> ();
						{
							limitRoomContainerListUIData.allLimitRoomContainers.v = new ReferenceData<AllLimitRoomContainers> (allLimitRoomContainers);
						}
						this.data.sub.v = limitRoomContainerListUIData;
					}
				} else {
					Debug.LogError ("allLimitRoomContainers null: " + this);
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

	public LimitRoomContainerListUI listPrefab;
	public LimitRoomContainerUI limitPrefab;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.allLimitRoomContainers.allAddCallBack (this);
				uiData.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			// allLimitRoomContainers
			{
				if (data is AllLimitRoomContainers) {
					AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
					// Child
					{
						allLimitRoomContainers.limitRoomContainers.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is LimitRoomContainer) {
						LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
						// Child
						{
							limitRoomContainer.users.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Human) {
						dirty = true;
						return;
					}
				}
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.List:
						{
							LimitRoomContainerListUI.UIData listUIData = sub as LimitRoomContainerListUI.UIData;
							UIUtils.Instantiate (listUIData, listPrefab, this.transform);
						}
						break;
					case UIData.Sub.Type.Limit:
						{
							LimitRoomContainerUI.UIData limitUIData = sub as LimitRoomContainerUI.UIData;
							UIUtils.Instantiate (limitUIData, limitPrefab, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType ());
						break;
					}
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
				uiData.allLimitRoomContainers.allRemoveCallBack (this);
				uiData.sub.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			// allLimitRoomContainers
			{
				if (data is AllLimitRoomContainers) {
					AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
					// Child
					{
						allLimitRoomContainers.limitRoomContainers.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is LimitRoomContainer) {
						LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
						// Child
						{
							limitRoomContainer.users.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Human) {
						return;
					}
				}
			}
			if (data is UIData.Sub) {
				UIData.Sub sub = data as UIData.Sub;
				// UI
				{
					switch (sub.getType ()) {
					case UIData.Sub.Type.List:
						{
							LimitRoomContainerListUI.UIData listUIData = sub as LimitRoomContainerListUI.UIData;
							listUIData.removeCallBackAndDestroy (typeof(LimitRoomContainerListUI));
						}
						break;
					case UIData.Sub.Type.Limit:
						{
							LimitRoomContainerUI.UIData limitUIData = sub as LimitRoomContainerUI.UIData;
							limitUIData.removeCallBackAndDestroy (typeof(LimitRoomContainerUI));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + sub.getType ());
						break;
					}
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
			case UIData.Property.sub:
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
			// allLimitRoomContainers
			{
				if (wrapProperty.p is AllLimitRoomContainers) {
					switch ((AllLimitRoomContainers.Property)wrapProperty.n) {
					case AllLimitRoomContainers.Property.limitRoomContainers:
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
						switch ((LimitRoomContainer.Property)wrapProperty.n) {
						case LimitRoomContainer.Property.maxUserCount:
							break;
						case LimitRoomContainer.Property.userCount:
							break;
						case LimitRoomContainer.Property.users:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case LimitRoomContainer.Property.gameTypes:
							break;
						case LimitRoomContainer.Property.rooms:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Human) {
						Human.onUpdateSyncPlayerIdChange (wrapProperty, this);
						return;
					}
				}
			}
			if (wrapProperty.p is UIData.Sub) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}