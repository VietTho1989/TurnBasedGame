using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

public class RoomUserAdapter : SRIA<RoomUserAdapter.UIData, RoomUserHolder.UIData>
{

	#region UIData

	[Serializable]
	public class UIData : BaseParams
	{

		public VP<ReferenceData<Room>> room;

		public LP<RoomUserHolder.UIData> holders;

        #region type

        public enum Type
        {
            Lobby,
            Play
        }

        public VP<Type> type;

        #endregion

        #region Constructor

        public enum Property
		{
			room,
			holders,
            type
		}

		public UIData() : base()
		{
			this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
			this.holders = new LP<RoomUserHolder.UIData>(this, (byte)Property.holders);
            this.type = new VP<Type>(this, (byte)Property.type, Type.Lobby);
		}

		#endregion

		[NonSerialized]
		public List<RoomUser> roomUsers = new List<RoomUser>();

		public void reset()
		{
			this.roomUsers.Clear ();
		}

	}

	#endregion

	#region Adapter

	public RoomUserHolder holderPrefab;

	protected override RoomUserHolder.UIData CreateViewsHolder (int itemIndex)
	{
		RoomUserHolder.UIData uiData = new RoomUserHolder.UIData();
		{
			// add
			{
				uiData.uid = this.data.holders.makeId ();
				this.data.holders.add (uiData);
			}
			if (holderPrefab != null) {
				uiData.Init (holderPrefab.gameObject, itemIndex);
			} else {
				Debug.LogError ("holderPrefab null: " + this);
			}
		}
		return uiData;
	}

	protected override void UpdateViewsHolder (RoomUserHolder.UIData newOrRecycled)
	{
		newOrRecycled.updateView (_Params);
	}

	#endregion

	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				Room room = this.data.room.v.data;
				if (room != null) {
					// get list of roomUser
					List<RoomUser> roomUsers = new List<RoomUser>();
					{
						for (int i = 0; i < room.users.vs.Count; i++) {
							RoomUser roomUser = room.users.vs [i];
							// if (roomUser.isInsideRoom ()) 
							{
								roomUsers.Add (roomUser);
							}
						}
					}
					// Add to adapter
					{
						int min = Mathf.Min (roomUsers.Count, _Params.roomUsers.Count);
						// Update
						{
							for (int i = 0; i < min; i++) {
								if (roomUsers [i] != _Params.roomUsers [i]) {
									// change param
									_Params.roomUsers [i] = roomUsers [i];
									// Update holder
									foreach (RoomUserHolder.UIData holder in this.data.holders.vs) {
										if (holder.ItemIndex == i) {
											holder.roomUser.v = new ReferenceData<RoomUser> (roomUsers [i]);
											break;
										}
									}
								}
							}
						}
						// Add or Remove
						{
							if (roomUsers.Count > min) {
								// Add
								int insertCount = roomUsers.Count - min;
								List<RoomUser> addItems = roomUsers.GetRange (min, insertCount);
								_Params.roomUsers.AddRange (addItems);
								InsertItems (min, insertCount, false, false);
							} else {
								// Remove
								int deleteCount = _Params.roomUsers.Count - min;
								if (deleteCount > 0) {
									RemoveItems (min, deleteCount, false, false);
									_Params.roomUsers.RemoveRange (min, deleteCount);
								}
							}
						}
					}
				} else {
					Debug.LogError ("room null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
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
				uiData.room.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Room) {
				Room room = data as Room;
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
					room.users.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is RoomUser) {
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
				uiData.room.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Room) {
				Room room = data as Room;
				// Child
				{
					room.users.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is RoomUser) {
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
			case UIData.Property.room:
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
		// Child
		{
			if (wrapProperty.p is Room) {
				switch ((Room.Property)wrapProperty.n) {
				case Room.Property.changeRights:
					break;
				case Room.Property.name:
					break;
				case Room.Property.password:
					break;
				case Room.Property.users:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Room.Property.state:
					break;
				case Room.Property.contestManagers:
					break;
				case Room.Property.timeCreated:
					break;
				case Room.Property.chatRoom:
					break;
				case Room.Property.allowHint:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is RoomUser) {
				switch ((RoomUser.Property)wrapProperty.n) {
				case RoomUser.Property.role:
					break;
				case RoomUser.Property.inform:
					break;
				case RoomUser.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}

		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}