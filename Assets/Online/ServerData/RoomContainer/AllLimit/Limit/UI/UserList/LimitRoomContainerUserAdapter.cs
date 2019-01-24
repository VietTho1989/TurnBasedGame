using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class LimitRoomContainerUserAdapter : SRIA<LimitRoomContainerUserAdapter.UIData, LimitRoomContainerUserHolder.UIData>
{

	#region UIData

	[Serializable]
	public class UIData : BaseParams
	{
		public VP<ReferenceData<LimitRoomContainer>> limitRoomContainer;

		public LP<LimitRoomContainerUserHolder.UIData> holders;

		#region Constructor

		public enum Property
		{
			limitRoomContainer,
			holders
		}

		public UIData() : base()
		{
			this.limitRoomContainer = new VP<ReferenceData<LimitRoomContainer>>(this, (byte)Property.limitRoomContainer, new ReferenceData<LimitRoomContainer>(null));
			this.holders = new LP<LimitRoomContainerUserHolder.UIData>(this, (byte)Property.holders);
		}

		#endregion

		public void reset()
		{
			this.humans.Clear ();
		}

		[NonSerialized]
		public List<Human> humans = new List<Human>();
	}

	#endregion

	#region Adapter

	public LimitRoomContainerUserHolder holderPrefab;

	protected override LimitRoomContainerUserHolder.UIData CreateViewsHolder (int itemIndex)
	{
		LimitRoomContainerUserHolder.UIData uiData = new LimitRoomContainerUserHolder.UIData();
		{
			// add
			{
				uiData.uid = this.data.holders.makeId ();
				this.data.holders.add (uiData);
			}
			// MakeUI
			if (holderPrefab != null) {
				uiData.Init (holderPrefab.gameObject, itemIndex);
			} else {
				Debug.LogError ("holderPrefab null: " + this);
			}
		}
		return uiData;
	}

	protected override void UpdateViewsHolder (LimitRoomContainerUserHolder.UIData newOrRecycled)
	{
		newOrRecycled.updateView (_Params);
	}

	#endregion

	#region Refresh

	public GameObject noLimitRoomContainerUsers;

	public override void refresh ()
	{
		if (dirty) {
			if (this.Initialized) {
				dirty = false;
				if (this.data != null) {
					LimitRoomContainer limitRoomContainer = this.data.limitRoomContainer.v.data;
					if (limitRoomContainer != null) {
						// get user list
						List<Human> humans = new List<Human>();
						{
							humans.AddRange (limitRoomContainer.users.vs);
						}
						// Process
						{
							int min = Mathf.Min (humans.Count, _Params.humans.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (humans [i] != _Params.humans [i]) {
										// change param
										_Params.humans [i] = humans [i];
										// Update holder
										foreach (LimitRoomContainerUserHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.human.v = new ReferenceData<Human> (humans [i]);
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (humans.Count > min) {
									// Add
									int insertCount = humans.Count - min;
									List<Human> addItems = humans.GetRange (min, insertCount);
									_Params.humans.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.humans.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.humans.RemoveRange (min, deleteCount);
									}
								}
							}
						}
						// NoLimitRoomContainerUsers
						{
							if (noLimitRoomContainerUsers != null) {
								bool haveAny = false;
								{
									foreach (LimitRoomContainerUserHolder.UIData holder in this.data.holders.vs) {
										if (holder.human.v.data != null) {
											LimitRoomContainerUserHolder holderUI = holder.findCallBack<LimitRoomContainerUserHolder> ();
											if (holderUI != null) {
												if (holderUI.gameObject.activeSelf) {
													haveAny = true;
													break;
												}
											} else {
												Debug.LogError ("holderUI null: " + this);
											}
										}
									}
								}
								noLimitRoomContainerUsers.SetActive (!haveAny);
							} else {
								Debug.LogError ("noRooms null: " + this);
							}
						}
					} else {
						Debug.Log ("limitRoomContainer null: " + this);
					}
				} else {
					Debug.Log ("data null: " + this);
				}
			} else {
				Debug.Log ("not intialized: " + this);
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
				uiData.limitRoomContainer.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is LimitRoomContainer) {
			// reset
			{
				if (this.data != null) {
					this.data.reset ();
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
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
			case UIData.Property.holders:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is LimitRoomContainer) {
			switch ((LimitRoomContainer.Property)wrapProperty.n) {
			case LimitRoomContainer.Property.maxUserCount:
				break;
			case LimitRoomContainer.Property.userCount:
				break;
			case LimitRoomContainer.Property.users:
				dirty = true;
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}