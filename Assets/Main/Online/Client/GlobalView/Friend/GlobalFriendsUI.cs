using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class GlobalFriendsUI : UIBehavior<GlobalFriendsUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Server>> server;

		public VP<FriendAdapter.UIData> friendAdapter;

		public VP<FriendDetailUI.UIData> friendDetail;

		#region Constructor

		public enum Property
		{
			server,
			friendAdapter,
			friendDetail
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
			this.friendAdapter = new VP<FriendAdapter.UIData>(this, (byte)Property.friendAdapter, new FriendAdapter.UIData());
			this.friendDetail = new VP<FriendDetailUI.UIData>(this,(byte)Property.friendDetail, null);
		}

		#endregion

		public void reset()
		{
			this.friendDetail.v = null;
		}

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// adapter
				if(!isProcess){
					// TODO Can hoan thien
				}
				// friendDetail
				if (!isProcess) {
					FriendDetailUI.UIData friendDetailUIData = this.friendDetail.v;
					if (friendDetailUIData != null) {
						isProcess = friendDetailUIData.processEvent (e);
					} else {
						Debug.LogError ("friendDetailUIData null: " + this);
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
					// friendAdapter
					{
						FriendAdapter.UIData friendAdapterUIData = this.data.friendAdapter.v;
						if (friendAdapterUIData != null) {
							friendAdapterUIData.server.v = new ReferenceData<Server> (server);
						} else {
							Debug.LogError ("friendAdapterUIData null: " + this);
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

	public FriendAdapter friendAdapterPrefab;
	public Transform friendAdapterContainer;

	public FriendDetailUI friendDetailPrefab;
	public Transform friendDetailContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.server.allAddCallBack (this);
				uiData.friendAdapter.allAddCallBack (this);
				uiData.friendDetail.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Server) {
				// Server server = data as Server;
				// Reset
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
			if (data is FriendAdapter.UIData) {
				FriendAdapter.UIData friendAdapterUIData = data as FriendAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (friendAdapterUIData, friendAdapterPrefab, friendAdapterContainer);
				}
				dirty = true;
				return;
			}
			if (data is FriendDetailUI.UIData) {
				FriendDetailUI.UIData friendDetailUIData = data as FriendDetailUI.UIData;
				// UI
				{
					UIUtils.Instantiate (friendDetailUIData, friendDetailPrefab, friendDetailContainer);
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
				uiData.friendAdapter.allRemoveCallBack (this);
				uiData.friendDetail.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Server) {
				return;
			}
			if (data is FriendAdapter.UIData) {
				FriendAdapter.UIData friendAdapterUIData = data as FriendAdapter.UIData;
				// UI
				{
					friendAdapterUIData.removeCallBackAndDestroy (typeof(FriendAdapter));
				}
				return;
			}
			if (data is FriendDetailUI.UIData) {
				FriendDetailUI.UIData friendDetailUIData = data as FriendDetailUI.UIData;
				// UI
				{
					friendDetailUIData.removeCallBackAndDestroy (typeof(FriendDetailUI));
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
			case UIData.Property.friendAdapter:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.friendDetail:
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
				return;
			}
			if (wrapProperty.p is FriendAdapter.UIData) {
				return;
			}
			if (wrapProperty.p is FriendDetailUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}