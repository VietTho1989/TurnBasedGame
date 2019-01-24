using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class LimitRoomContainerAdapter : SRIA<LimitRoomContainerAdapter.UIData, LimitRoomContainerHolder.UIData>
{

	#region UIData

	[Serializable]
	public class UIData : BaseParams
	{

		public VP<ReferenceData<AllLimitRoomContainers>> allLimitRoomContainers;

		public VP<SortDataUI.UIData> sortData;

		public LP<LimitRoomContainerHolder.UIData> holders;

		#region Constructor

		public enum Property
		{
			allLimitRoomContainers,
			sortData,
			holders
		}

		public UIData() : base()
		{
			this.allLimitRoomContainers = new VP<ReferenceData<AllLimitRoomContainers>>(this, (byte)Property.allLimitRoomContainers, new ReferenceData<AllLimitRoomContainers>(null));
			// sortData
			{
				this.sortData = new VP<SortDataUI.UIData>(this, (byte)Property.sortData, new SortDataUI.UIData());
				{
					EditData<SortData> editSortData = this.sortData.v.editSortData.v;
					if(editSortData!=null){
						editSortData.origin.v = new ReferenceData<SortData>(new SortData());
						editSortData.canEdit.v = true;
						editSortData.editType.v = EditType.Immediate;
					}else{
						Debug.LogError("editSortData null: "+this);
					}
				}
			}
			this.holders = new LP<LimitRoomContainerHolder.UIData>(this, (byte)Property.holders);
		}

		#endregion

		[NonSerialized]
		public List<LimitRoomContainer> limitRoomContainers = new List<LimitRoomContainer>();

		public void reset()
		{
			this.limitRoomContainers.Clear();
		}

	}

	#endregion

	#region Adapter

	public LimitRoomContainerHolder holderPrefab;

	protected override LimitRoomContainerHolder.UIData CreateViewsHolder (int itemIndex)
	{
		LimitRoomContainerHolder.UIData uiData = new LimitRoomContainerHolder.UIData();
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

	protected override void UpdateViewsHolder (LimitRoomContainerHolder.UIData newOrRecycled)
	{
		newOrRecycled.updateView (_Params);
	}

	#endregion

	#region Refresh

	public GameObject noLimitRoomContainers;

	public override void refresh ()
	{
		if (dirty) {
			if (this.Initialized) {
				dirty = false;
				if (this.data != null) {
					AllLimitRoomContainers allLimitRoomContainers = this.data.allLimitRoomContainers.v.data;
					if (allLimitRoomContainers != null) {
						List<LimitRoomContainer> limitRoomContainers = new List<LimitRoomContainer> ();
						// filter
						{
							// add
							{
								limitRoomContainers.AddRange (allLimitRoomContainers.limitRoomContainers.vs);
							}
							// find sort
							SortData sortData = null;
							{
								SortDataUI.UIData sortDataUIData = this.data.sortData.v;
								if (sortDataUIData != null) {
									EditData<SortData> editSortData = sortDataUIData.editSortData.v;
									if (editSortData != null) {
										sortData = editSortData.show.v.data;
									} else {
										Debug.LogError ("editSortData null: " + this);
									}
								} else {
									Debug.LogError ("sortDataUIData null: " + this);
								}
							}
							// Process
							if (sortData != null) {
								// Co le ko can
							} else {
								Debug.LogError ("sortData null: " + this);
							}
						}
						// Make list
						{
							int min = Mathf.Min (limitRoomContainers.Count, _Params.limitRoomContainers.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (limitRoomContainers[i] != _Params.limitRoomContainers [i]) {
										// change param
										_Params.limitRoomContainers [i] = limitRoomContainers [i];
										// Update holder
										foreach (LimitRoomContainerHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.limitRoomContainer.v = new ReferenceData<LimitRoomContainer> (limitRoomContainers [i]);
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (limitRoomContainers.Count > min) {
									// Add
									int insertCount = limitRoomContainers.Count - min;
									List<LimitRoomContainer> addItems = limitRoomContainers.GetRange (min, insertCount);
									_Params.limitRoomContainers.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.limitRoomContainers.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.limitRoomContainers.RemoveRange (min, deleteCount);
									}
								}
							}
						}
						// NoLimitRoomContainers
						{
							if (noLimitRoomContainers != null) {
								bool haveAny = false;
								{
									foreach (LimitRoomContainerHolder.UIData holder in this.data.holders.vs) {
										if (holder.limitRoomContainer.v.data != null) {
											LimitRoomContainerHolder holderUI = holder.findCallBack<LimitRoomContainerHolder> ();
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
								noLimitRoomContainers.SetActive (!haveAny);
							} else {
								Debug.LogError ("noRooms null: " + this);
							}
						}
						// txt
						/*{
							if (tvNoRooms != null) {
								tvNoRooms.text = txtNoRooms.get ("Don't have any rooms");
							} else {
								Debug.LogError ("tvNoRooms null: " + this);
							}
						}*/
					} else {
						Debug.LogError ("allLimitRoomContainers null");
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			} else {
				Debug.LogError ("not initalized: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public SortDataUI sortDataPrefab;
	public Transform sortDataContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().addCallBack(this);
			// Child
			{
				uiData.allLimitRoomContainers.allAddCallBack (this);
				uiData.sortData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Setting
		if (data is Setting) {
			dirty = true;
			return;
		}
		// Child
		{
			if (data is AllLimitRoomContainers) {
				dirty = true;
				return;
			}
			// sortDataUIData
			{
				if (data is SortDataUI.UIData) {
					SortDataUI.UIData sortDataUIData = data as SortDataUI.UIData;
					// UI
					{
						UIUtils.Instantiate (sortDataUIData, sortDataPrefab, sortDataContainer);
					}
					// Child
					{
						sortDataUIData.editSortData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is EditData<SortData>) {
						EditData<SortData> editSortData = data as EditData<SortData>;
						// Child
						{
							editSortData.show.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is SortData) {
						dirty = true;
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Setting
			Setting.get().removeCallBack(this);
			// Child
			{
				uiData.allLimitRoomContainers.allRemoveCallBack (this);
				uiData.sortData.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Setting
		if (data is Setting) {
			return;
		}
		// Child
		{
			if (data is AllLimitRoomContainers) {
				return;
			}
			// sortDataUIData
			{
				if (data is SortDataUI.UIData) {
					SortDataUI.UIData sortDataUIData = data as SortDataUI.UIData;
					// UI
					{
						sortDataUIData.removeCallBackAndDestroy (typeof(SortDataUI));
					}
					// Child
					{
						sortDataUIData.editSortData.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is EditData<SortData>) {
						EditData<SortData> editSortData = data as EditData<SortData>;
						// Child
						{
							editSortData.show.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is SortData) {
						return;
					}
				}
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
			case UIData.Property.sortData:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.holders:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Setting
		if (wrapProperty.p is Setting) {
			switch ((Setting.Property)wrapProperty.n) {
			case Setting.Property.language:
				dirty = true;
				break;
			case Setting.Property.showLastMove:
				break;
			case Setting.Property.viewUrlImage:
				break;
			case Setting.Property.animationSetting:
				break;
			case Setting.Property.maxThinkCount:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is AllLimitRoomContainers) {
				switch ((AllLimitRoomContainers.Property)wrapProperty.n) {
				case AllLimitRoomContainers.Property.limitRoomContainers:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// sortDataUIData
			{
				if (wrapProperty.p is SortDataUI.UIData) {
					switch ((SortDataUI.UIData.Property)wrapProperty.n) {
					case SortDataUI.UIData.Property.editSortData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case SortDataUI.UIData.Property.filter:
						break;
					case SortDataUI.UIData.Property.sortType:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is EditData<SortData>) {
						switch ((EditData<SortData>.Property)wrapProperty.n) {
						case EditData<SortData>.Property.origin:
							break;
						case EditData<SortData>.Property.show:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case EditData<SortData>.Property.compare:
							break;
						case EditData<SortData>.Property.compareOtherType:
							break;
						case EditData<SortData>.Property.canEdit:
							break;
						case EditData<SortData>.Property.editType:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is SortData) {
						switch ((SortData.Property)wrapProperty.n) {
						case SortData.Property.filter:
							dirty = true;
							break;
						case SortData.Property.sortType:
							dirty = true;
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}