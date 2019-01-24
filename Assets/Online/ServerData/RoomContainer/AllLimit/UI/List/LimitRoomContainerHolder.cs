using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerHolder : SriaHolderBehavior<LimitRoomContainerHolder.UIData>
{

	#region UIData

	public class UIData : BaseItemViewsHolder
	{

		public VP<ReferenceData<LimitRoomContainer>> limitRoomContainer;

		#region Constructor

		public enum Property
		{
			limitRoomContainer
		}

		public UIData() : base()
		{
			this.limitRoomContainer = new VP<ReferenceData<LimitRoomContainer>>(this, (byte)Property.limitRoomContainer, new ReferenceData<LimitRoomContainer>(null));
		}

		#endregion

		public void updateView(LimitRoomContainerAdapter.UIData myParams)
		{
			// Find
			LimitRoomContainer limitRoomContainer = null;
			{
				if (ItemIndex >= 0 && ItemIndex < myParams.limitRoomContainers.Count) {
					limitRoomContainer = myParams.limitRoomContainers [ItemIndex];
				} else {
					Debug.LogError ("ItemIdex error: " + this);
				}
			}
			// Update
			this.limitRoomContainer.v = new ReferenceData<LimitRoomContainer> (limitRoomContainer);
		}

	}

	#endregion

	#region Refresh

	public Text tvIndex;
	public Text tvGameType;
	public Text tvUserCount;

	public override void refresh ()
	{
		base.refresh ();
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				LimitRoomContainer limitRoomContainer = this.data.limitRoomContainer.v.data;
				if (limitRoomContainer != null) {
					// tvIndex
					{
						if (tvIndex != null) {
							int index = 0;
							{
								AllLimitRoomContainers allLimitRoomContainers = limitRoomContainer.findDataInParent<AllLimitRoomContainers> ();
								if (allLimitRoomContainers != null) {
									index = allLimitRoomContainers.limitRoomContainers.vs.IndexOf (limitRoomContainer);
								} else {
									Debug.LogError ("limitRoomContainer null");
								}
							}
							tvIndex.text = "" + index;
						} else {
							Debug.LogError ("tvIndex null");
						}
					}
					// tvGameType
					{
						if (tvGameType != null) {
							if (limitRoomContainer.gameTypes.vs.Count == 0) {
								tvGameType.text = "None";
							} else if (limitRoomContainer.gameTypes.vs.Count == 1) {
								GameType.Type gameType = limitRoomContainer.gameTypes.vs [0];
								tvGameType.text = "" + gameType;
							} else if (limitRoomContainer.gameTypes.vs.Count > 1) {
								tvGameType.text = "Mix";
							}
						} else {
							Debug.LogError ("tvGameType null");
						}
					}
					// tvUserCount
					{
						if (tvUserCount != null) {
							tvUserCount.text = limitRoomContainer.userCount.v + "/" + limitRoomContainer.maxUserCount.v;
						} else {
							Debug.LogError ("tvUserCount null");
						}
					}
				} else {
					Debug.LogError ("limitRoomContainer null");
				}
			} else {
				// Debug.LogError ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement callback

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.limitRoomContainer.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is LimitRoomContainer) {
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
				uiData.limitRoomContainer.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		if (data is LimitRoomContainer) {
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
			case UIData.Property.limitRoomContainer:
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
		if (wrapProperty.p is LimitRoomContainer) {
			switch ((LimitRoomContainer.Property)wrapProperty.n) {
			case LimitRoomContainer.Property.maxUserCount:
				dirty = true;
				break;
			case LimitRoomContainer.Property.userCount:
				dirty = true;
				break;
			case LimitRoomContainer.Property.users:
				break;
			case LimitRoomContainer.Property.gameTypes:
				dirty = true;
				break;
			case LimitRoomContainer.Property.rooms:
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

	#region Click Button

	public void OnClickCell()
	{
		if (this.data != null) {
			LimitRoomContainer limitRoomContainer = this.data.limitRoomContainer.v.data;
			if (limitRoomContainer != null) {
				Debug.LogError ("onClickCell: " + limitRoomContainer);
				LimitRoomContainerListUI.UIData limitRoomContainerListUIData = this.data.findDataInParent<LimitRoomContainerListUI.UIData> ();
				if (limitRoomContainerListUIData != null) {
					JoinLimitRoomContainerUI.UIData joinLimitRoomContainerUIData = limitRoomContainerListUIData.joinLimitRoomContainerUIData.newOrOld<JoinLimitRoomContainerUI.UIData> ();
					{
						joinLimitRoomContainerUIData.limitRoomContainer.v = new ReferenceData<LimitRoomContainer> (limitRoomContainer);
					}
					limitRoomContainerListUIData.joinLimitRoomContainerUIData.v = joinLimitRoomContainerUIData;
				} else {
					Debug.LogError ("limitRoomContainerListUIData null");
				}
			} else {
				Debug.LogError ("limitRoomContainer null");
			}
		} else {
			Debug.LogError ("data null");
		}
	}

	#endregion
}