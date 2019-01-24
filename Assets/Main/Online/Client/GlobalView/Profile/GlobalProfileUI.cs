using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class GlobalProfileUI : UIBehavior<GlobalProfileUI.UIData>
{

	#region UIData

	public class UIData : Data
	{

		public VP<ReferenceData<Server>> server;

		public VP<UserAdapter.UIData> userAdapter;

		public VP<UserUI.UIData> userUI;

		#region Constructor

		public enum Property
		{
			server,
			userAdapter,
			userUI
		}

		public UIData() : base()
		{
			this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
			this.userAdapter = new VP<UserAdapter.UIData>(this, (byte)Property.userAdapter, new UserAdapter.UIData());
			this.userUI = new VP<UserUI.UIData>(this, (byte)Property.userUI, null);
		}

		#endregion

		public void reset()
		{
			this.userUI.v = null;
		}

		public bool processEvent(Event e)
		{
			bool isProcess = false;
			{
				// userUI
				if (!isProcess) {
					UserUI.UIData userUIData = this.userUI.v;
					if (userUIData != null) {
						isProcess = userUIData.processEvent (e);
					} else {
						Debug.LogError ("userUIData null: " + this);
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
					// userAdapter
					{
						UserAdapter.UIData userAdapterUIData = this.data.userAdapter.v;
						if (userAdapterUIData != null) {
							userAdapterUIData.server.v = new ReferenceData<Server> (server);
						} else {
							Debug.LogError ("userAdapterUIData null: " + this);
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

	public UserAdapter userAdapterPrefab;
	public Transform userAdapterContainer;

	public UserUI userUIPrefab;
	public Transform userUIContainer;

	public override void onAddCallBack<T> (T data)
	{
		if (data is UIData) {
			UIData uiData = data as UIData;
			// Child
			{
				uiData.server.allAddCallBack (this);
				uiData.userAdapter.allAddCallBack (this);
				uiData.userUI.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Server) {
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
			if (data is UserAdapter.UIData) {
				UserAdapter.UIData userAdapterUIData = data as UserAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (userAdapterUIData, userAdapterPrefab, userAdapterContainer);
				}
				dirty = true;
				return;
			}
			if (data is UserUI.UIData) {
				UserUI.UIData userUIData = data as UserUI.UIData;
				// UI
				{
					UIUtils.Instantiate (userUIData, userUIPrefab, userUIContainer);
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
				uiData.userAdapter.allRemoveCallBack (this);
				uiData.userUI.allRemoveCallBack (this);
			}
			this.setDataNull (uiData);
			return;
		}
		// Child
		{
			if (data is Server) {
				return;
			}
			if (data is UserAdapter.UIData) {
				UserAdapter.UIData userAdapterUIData = data as UserAdapter.UIData;
				// UI
				{
					userAdapterUIData.removeCallBackAndDestroy (typeof(UserAdapter));
				}
				return;
			}
			if (data is UserUI.UIData) {
				UserUI.UIData userUIData = data as UserUI.UIData;
				// UI
				{
					userUIData.removeCallBackAndDestroy (typeof(UserUI));
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
			case UIData.Property.userAdapter:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case UIData.Property.userUI:
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
			if (wrapProperty.p is UserAdapter.UIData) {
				return;
			}
			if (wrapProperty.p is UserUI.UIData) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}