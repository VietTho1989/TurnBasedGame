using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AllLimitRoomContainersUpdate : UpdateBehavior<AllLimitRoomContainers>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// remove all the same in two limitRoomContainer
				for (int limitIndex = 0; limitIndex < this.data.limitRoomContainers.vs.Count; limitIndex++) {
					LimitRoomContainer limitRoomContainer = this.data.limitRoomContainers.vs [limitIndex];
					// get all userId in limitRoomContainer
					List<uint> userIds = new List<uint>();
					{
						for (int j = limitRoomContainer.users.vs.Count - 1; j >= 0; j--) {
							uint userId = limitRoomContainer.users.vs [j].playerId.v;
							if (!userIds.Contains (userId)) {
								userIds.Add (userId);
							} else {
								Debug.LogError ("why already contain userId: " + userId);
								limitRoomContainer.users.removeAt (j);
							}
						}
					}
					// remove in other limit
					for (int otherLimitIndex = limitIndex + 1; otherLimitIndex < this.data.limitRoomContainers.vs.Count; otherLimitIndex++) {
						LimitRoomContainer checkLimitRoomContainer = this.data.limitRoomContainers.vs [otherLimitIndex];
						// check already contain users
						for (int i = checkLimitRoomContainer.users.vs.Count - 1; i >= 0; i--) {
							if (userIds.Contains (checkLimitRoomContainer.users.vs [i].playerId.v)) {
								Debug.LogError ("why already contain: " + checkLimitRoomContainer.users.vs [i]);
								checkLimitRoomContainer.users.removeAt (i);
							}
						}
					}
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is AllLimitRoomContainers) {
			AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
			// Update
			{
				UpdateUtils.makeUpdate<AutoMakeLimitRoomContainersUpdate, AllLimitRoomContainers> (allLimitRoomContainers, this.transform);
			}
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
				// Update
				{
					UpdateUtils.makeUpdate<LimitRoomContainerUpdate, LimitRoomContainer> (limitRoomContainer, this.transform);
				}
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
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is AllLimitRoomContainers) {
			AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
			// Update
			{
				allLimitRoomContainers.removeCallBackAndDestroy (typeof(AutoMakeLimitRoomContainersUpdate));
			}
			// Child
			{
				allLimitRoomContainers.limitRoomContainers.allRemoveCallBack (this);
			}
			this.setDataNull (allLimitRoomContainers);
			return;
		}
		// Child
		{
			if (data is LimitRoomContainer) {
				LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
				// Update
				{
					limitRoomContainer.removeCallBackAndDestroy (typeof(LimitRoomContainerUpdate));
				}
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
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}