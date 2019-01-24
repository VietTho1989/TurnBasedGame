using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class GlobalRoomsUI : UIBehavior<GlobalRoomsUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Server>> server;

		public VP<RoomManagerUI.UIData> roomManagerUIData;

		#region Constructor

		public enum Property
		{
			server,
			roomManagerUIData
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
			this.roomManagerUIData = new VP<RoomManagerUI.UIData>(this, (byte)Property.roomManagerUIData, new RoomManagerUI.UIData());
		}

		#endregion

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// sub
				if (!isProcess) {
					RoomManagerUI.UIData roomManagerUIData = this.roomManagerUIData.v;
					if (roomManagerUIData != null) {
						isProcess = roomManagerUIData.processEvent (e);
					} else {
						Debug.LogError ("roomManagerUIData null");
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
				Server server = this.data.server.v.data;
				if (server != null) {
					// roomManagerUIData
					{
						RoomManagerUI.UIData roomManagerUIData = this.data.roomManagerUIData.v;
						if (roomManagerUIData != null) {
							roomManagerUIData.roomManager.v = new ReferenceData<RoomManager> (server.roomManager.v);
						} else {
							Debug.LogError ("roomManagerUIData null");
						}
					}
				} else {
					Debug.LogError ("server null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public RoomManagerUI roomManagerPrefab;
	public Transform roomManagerContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.server.allAddCallBack (this);
				uiData.roomManagerUIData.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Server) {
				dirty = true;
				return;
			}
			if (data is RoomManagerUI.UIData) {
				RoomManagerUI.UIData roomManagerUIData = data as RoomManagerUI.UIData;
				// UI
				{
					UIUtils.Instantiate (roomManagerUIData, roomManagerPrefab, roomManagerContainer);
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
				uiData.server.allRemoveCallBack (this);
				uiData.roomManagerUIData.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Server) {
				return;
			}
			if (data is RoomManagerUI.UIData) {
				RoomManagerUI.UIData roomManagerUIData = data as RoomManagerUI.UIData;
				// UI
				{
					roomManagerUIData.removeCallBackAndDestroy (typeof(RoomManagerUI));
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
			case UIData.Property.server:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.roomManagerUIData:
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
			if (wrapProperty.p is Server) {
				switch ((Server.Property)wrapProperty.n) {
				case Server.Property.serverConfig:
					break;
				case Server.Property.instanceId:
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
				case Server.Property.disconnectTime:
					break;
				case Server.Property.roomManager:
					dirty = true;
					break;
				case Server.Property.globalChat:
					break;
				case Server.Property.friendWorld:
					break;
				case Server.Property.guilds:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			if (wrapProperty.p is RoomManagerUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}