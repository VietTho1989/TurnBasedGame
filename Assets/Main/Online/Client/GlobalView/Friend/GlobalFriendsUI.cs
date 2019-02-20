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

    #region rect, txt

    static GlobalFriendsUI()
    {
        // rect
        {
            // friendDetailRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                // offsetMin: (-180.0, -180.0); offsetMax: (180.0, 180.0); sizeDelta: (360.0, 360.0);
                friendDetailRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                friendDetailRect.anchorMin = new Vector2(0.5f, 0.5f);
                friendDetailRect.anchorMax = new Vector2(0.5f, 0.5f);
                friendDetailRect.pivot = new Vector2(0.5f, 0.5f);
                friendDetailRect.offsetMin = new Vector2(-180.0f, -180f);
                friendDetailRect.offsetMax = new Vector2(180.0f, 180.0f);
                friendDetailRect.sizeDelta = new Vector2(360.0f, 360.0f);
            }
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
                // UI
                {
                    UIRectTransform.SetSiblingIndex(this.data.friendAdapter.v, 0);
                    UIRectTransform.SetSiblingIndex(this.data.friendDetail.v, 1);
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
	private static readonly UIRectTransform friendAdapterRect = UIConstants.FullParent;

	public FriendDetailUI friendDetailPrefab;
	private static readonly UIRectTransform friendDetailRect = new UIRectTransform();

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
					UIUtils.Instantiate (friendAdapterUIData, friendAdapterPrefab, this.transform, friendAdapterRect);
				}
				dirty = true;
				return;
			}
			if (data is FriendDetailUI.UIData) {
				FriendDetailUI.UIData friendDetailUIData = data as FriendDetailUI.UIData;
				// UI
				{
					UIUtils.Instantiate (friendDetailUIData, friendDetailPrefab, this.transform, friendDetailRect);
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