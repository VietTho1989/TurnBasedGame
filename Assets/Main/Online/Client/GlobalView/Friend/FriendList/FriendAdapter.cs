using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class FriendAdapter : SRIA<FriendAdapter.UIData, FriendHolder.UIData>, FriendHashMap.Delegate
{

	#region UIData

	[Serializable]
	public class UIData : BaseParams
	{
		
		public VP<ReferenceData<Server>> server;

		public VP<SortDataUI.UIData> sortData;

		public LP<FriendHolder.UIData> holders;

		#region Constructor

		public enum Property
		{
			server,
			sortData,
			holders
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
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
			this.holders = new LP<FriendHolder.UIData>(this, (byte)Property.holders);
		}

		#endregion

		[NonSerialized]
		public List<Friend> friends = new List<Friend>();

		public void reset()
		{
			this.friends.Clear();
		}

	}

	#endregion

	#region Adapter

	public FriendHolder holderPrefab;

	protected override FriendHolder.UIData CreateViewsHolder (int itemIndex)
	{
		FriendHolder.UIData uiData = new FriendHolder.UIData();
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

	protected override void UpdateViewsHolder (FriendHolder.UIData newOrRecycled)
	{
		newOrRecycled.updateView (_Params);
	}

	#endregion

	#region Refresh

	#region txt

	public Text tvNoFriends;
	public static readonly TxtLanguage txtNoFriends = new TxtLanguage ();

	static FriendAdapter()
	{
		txtNoFriends.add (Language.Type.vi, "Không có bạn nào cả");
	}

	#endregion

	public GameObject noFriends;

	public override void refresh ()
	{
		if (dirty) {
			if (this.Initialized) {
				dirty = false;
				if (this.data != null) {
					Server server = this.data.server.v.data;
					if (server != null) {
						List<Friend> friends = new List<Friend> ();
						// filter
						{
							{
								FriendWorld friendWorld = server.friendWorld.v;
								if (friendWorld != null) {
									friends = friendWorld.getFriendList (server.profileId.v);
								} else {
									Debug.LogError ("friendWorld null: " + this);
								}
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
								uint profileId = server.profileId.v;
								// filter string
								{
									if (!string.IsNullOrEmpty (sortData.filter.v)) {
										for (int i = friends.Count - 1; i >= 0; i--) {
											Friend friend = friends [i];
											if (!friend.getName(profileId).Contains (sortData.filter.v)) {
												friends.RemoveAt (i);
											}
										}
									}
								}
								// sort
								{
									switch (sortData.sortType.v) {
									case SortData.SortType.None:
										break;
									case SortData.SortType.Name:
										{
											friends.Sort (delegate(Friend p1, Friend p2) {
												if(p1==null){
													return 1;
												}
												if(p2==null){
													return -1;
												}
												return  p1.getName(profileId).CompareTo (p2.getName(profileId));
											});
										}
										break;
									case SortData.SortType.Kind:
										{
											friends.Sort (delegate(Friend p1, Friend p2) {
												if(p1==null){
													return 1;
												}
												if(p2==null){
													return -1;
												}
												return  Friend.State.compare(p1.state.v.getType(), p2.state.v.getType());
											});
										}
										break;
									case SortData.SortType.Date:
										{
											friends.Sort (delegate(Friend p1, Friend p2) {
												if(p1==null){
													return 1;
												}
												if(p2==null){
													return -1;
												}
												return  p1.uid.CompareTo (p2.uid);
											});
										}
										break;
									default:
										Debug.LogError ("Unknown type: " + sortData.sortType.v + "; " + this);
										break;
									}
								}
							} else {
								Debug.LogError ("sortData null: " + this);
							}
						}
						// Make list
						{
							int min = Mathf.Min (friends.Count, _Params.friends.Count);
							// Update
							{
								for (int i = 0; i < min; i++) {
									if (friends[i] != _Params.friends [i]) {
										// change param
										_Params.friends [i] = friends [i];
										// Update holder
										foreach (FriendHolder.UIData holder in this.data.holders.vs) {
											if (holder.ItemIndex == i) {
												holder.friend.v = new ReferenceData<Friend> (friends [i]);
												break;
											}
										}
									}
								}
							}
							// Add or Remove
							{
								if (friends.Count > min) {
									// Add
									int insertCount = friends.Count - min;
									List<Friend> addItems = friends.GetRange (min, insertCount);
									_Params.friends.AddRange (addItems);
									InsertItems (min, insertCount, false, false);
								} else {
									// Remove
									int deleteCount = _Params.friends.Count - min;
									if (deleteCount > 0) {
										RemoveItems (min, deleteCount, false, false);
										_Params.friends.RemoveRange (min, deleteCount);
									}
								}
							}
						}
						// NoFriends
						{
							if (noFriends != null) {
								bool haveAny = false;
								{
									foreach (FriendHolder.UIData holder in this.data.holders.vs) {
										if (holder.friend.v.data != null) {
											FriendHolder holderUI = holder.findCallBack<FriendHolder> ();
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
								noFriends.SetActive (!haveAny);
							} else {
								Debug.LogError ("noFriends null: " + this);
							}
						}
					} else {
						Debug.LogError ("server null: " + this);
					}
					// txt
					{
						if (tvNoFriends != null) {
							tvNoFriends.text = txtNoFriends.get ("Don't have any friends");
						} else {
							Debug.LogError ("tvNoFriends null: " + this);
						}
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
				uiData.server.allAddCallBack (this);
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
			// Server
			{
				if (data is Server) {
					Server server = data as Server;
					// reset
					{
						if (this.data != null) {
							this.data.reset ();
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
					// Child
					{
						server.friendWorld.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is FriendWorld) {
					FriendWorld friendWorld = data as FriendWorld;
					// HashMap
					{
						friendWorld.friendHashMap.delegates.Add (this);
					}
					dirty = true;
					return;
				}
			}
			// SortData
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
				uiData.server.allRemoveCallBack (this);
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
			// Server
			{
				if (data is Server) {
					Server server = data as Server;
					// Child
					{
						server.friendWorld.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is FriendWorld) {
					FriendWorld friendWorld = data as FriendWorld;
					// HashMap
					{
						friendWorld.friendHashMap.delegates.Remove (this);
					}
					return;
				}
			}
			// SortData
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
			case UIData.Property.server:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.holders:
				break;
			case UIData.Property.sortData:
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
			// Server
			{
				if (wrapProperty.p is Server) {
					switch ((Server.Property)wrapProperty.n) {
					case Server.Property.serverConfig:
						break;
					case Server.Property.startState:
						break;
					case Server.Property.type:
						break;
					case Server.Property.profile:
						break;
					case Server.Property.state:
						break;
					case Server.Property.users:
						break;
					case Server.Property.globalChat:
						break;
					case Server.Property.friendWorld:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case Server.Property.guilds:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is FriendWorld) {
					// Co HashMap xu ly
					return;
				}
			}
			// SortData
			{
				if (wrapProperty.p is SortDataUI.UIData) {
					switch((SortDataUI.UIData.Property)wrapProperty.n){
					case SortDataUI.UIData.Property.editSortData:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case SortDataUI.UIData.Property.filter:
						break;
					case SortDataUI.UIData.Property.sortType:
						break;
					default:
						Debug.LogError("Don't process: "+wrapProperty+"; "+this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is EditData<SortData>) {
						switch((EditData<SortData>.Property)wrapProperty.n){
						case EditData<SortData>.Property.origin:
							break;
						case EditData<SortData>.Property.show:
							{
								ValueChangeUtils.replaceCallBack(this, syncs);
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
							Debug.LogError("Don't process: "+wrapProperty+"; "+this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is SortData) {
						switch((SortData.Property)wrapProperty.n){
						case SortData.Property.filter:
							dirty = true;
							break;
						case SortData.Property.sortType:
							dirty = true;
							break;
						default:
							Debug.LogError("Don't process: "+wrapProperty+"; "+this);
							break;
						}
						return;
					}
				}
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	public void onFriendListChange(uint userId)
	{
		if (this.data != null) {
			Server server = this.data.server.v.data;
			if (server != null) {
				if (userId == server.profileId.v) {
					dirty = true;
				}
			} else {
				Debug.LogError ("server null: " + this);
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	#endregion

}