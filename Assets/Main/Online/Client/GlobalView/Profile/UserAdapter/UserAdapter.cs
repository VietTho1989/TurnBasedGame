using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

/**
 * TODO List Show chua co, chua xu ly voi luong nguoi choi cuc lon
 * */
public class UserAdapter : SRIA<UserAdapter.UIData, UserHolder.UIData>
{

    #region UIData

    [Serializable]
    public class UIData : BaseParams
    {

        public VP<ReferenceData<Server>> server;

        #region listShow

        public VP<ListShow> listShow;

        public VP<ListShowUI.UIData> listShowUIData;

        #endregion

        public LP<UserHolder.UIData> holders;

        #region Constructor

        public enum Property
        {
            server,

            listShow,
            listShowUIData,

            holders
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));

            this.listShow = new VP<ListShow>(this, (byte)Property.listShow, new ListShowAll());
            this.listShowUIData = new VP<ListShowUI.UIData>(this, (byte)Property.listShowUIData, new ListShowUI.UIData());

            this.holders = new LP<UserHolder.UIData>(this, (byte)Property.holders);
        }

        #endregion

        public void reset()
        {
            // listShow
            {
                if (this.listShow.v != null && this.listShow.v is ListShowLimit)
                {
                    ListShowLimit listShowLimit = this.listShow.v as ListShowLimit;
                    listShowLimit.index.v = 0;
                }
            }
            this.users.Clear();
        }

        [NonSerialized]
        public List<User> users = new List<User>();
    }

    #endregion

    #region Adapter

    public UserHolder holderPrefab;

    protected override UserHolder.UIData CreateViewsHolder(int itemIndex)
    {
        UserHolder.UIData uiData = new UserHolder.UIData();
        {
            // add
            {
                uiData.uid = this.data.holders.makeId();
                this.data.holders.add(uiData);
            }
            // MakeUI
            if (holderPrefab != null)
            {
                uiData.Init(holderPrefab.gameObject, itemIndex);
            }
            else
            {
                Debug.LogError("holderPrefab null: " + this);
            }
        }
        return uiData;
    }

    protected override void UpdateViewsHolder(UserHolder.UIData newOrRecycled)
    {
        newOrRecycled.updateView(_Params);
    }

    #endregion

    #region Refresh

    public RectTransform viewPort;
    public RectTransform scrollBar;

    public override void refresh()
    {
        if (dirty)
        {
            if (this.Initialized)
            {
                dirty = false;
                if (this.data != null)
                {
                    Server server = this.data.server.v.data;
                    if (server != null)
                    {
                        // get user list
                        List<User> userList = new List<User>();
                        {
                            // check correct
                            {
                                if (server.users.vs.Count > ListShowAll.MaxShowAll)
                                {
                                    // Make limit
                                    ListShowLimit listShowLimit = null;
                                    {
                                        // get old
                                        if (this.data.listShow.v != null)
                                        {
                                            if (this.data.listShow.v is ListShowLimit)
                                            {
                                                listShowLimit = this.data.listShow.v as ListShowLimit;
                                            }
                                        }
                                        // Make new
                                        if (listShowLimit == null)
                                        {
                                            listShowLimit = new ListShowLimit();
                                            {
                                                listShowLimit.uid = this.data.listShow.makeId();
                                            }
                                            this.data.listShow.v = listShowLimit;
                                        }
                                        // Update
                                        {
                                            listShowLimit.itemCount.v = (uint)server.users.vs.Count;
                                            // correct index
                                            if (listShowLimit.index.v >= server.users.vs.Count)
                                            {
                                                if (listShowLimit.count.v > 0)
                                                {
                                                    listShowLimit.index.v = (uint)((server.users.vs.Count / listShowLimit.count.v) * listShowLimit.count.v);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    ListShowAll listShowAll = null;
                                    {
                                        // get old
                                        if (this.data.listShow.v != null)
                                        {
                                            if (this.data.listShow.v is ListShowAll)
                                            {
                                                listShowAll = this.data.listShow.v as ListShowAll;
                                            }
                                        }
                                        // Make new
                                        if (listShowAll == null)
                                        {
                                            listShowAll = new ListShowAll();
                                            {
                                                listShowAll.uid = this.data.listShow.makeId();
                                            }
                                            this.data.listShow.v = listShowAll;
                                        }
                                    }
                                    // Update
                                    {

                                    }
                                }
                            }
                            ListShow listShow = this.data.listShow.v;
                            if (listShow != null)
                            {
                                // get
                                userList = listShow.getList(server.users.vs);
                            }
                            else
                            {
                                Debug.LogError("listShow null: " + this);
                            }
                        }
                        // Process
                        {
                            int min = Mathf.Min(userList.Count, _Params.users.Count);
                            // Update
                            {
                                for (int i = 0; i < min; i++)
                                {
                                    if (userList[i] != _Params.users[i])
                                    {
                                        // change param
                                        _Params.users[i] = userList[i];
                                        // Update holder
                                        foreach (UserHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.ItemIndex == i)
                                            {
                                                holder.user.v = new ReferenceData<User>(userList[i]);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            // Add or Remove
                            {
                                if (userList.Count > min)
                                {
                                    // Add
                                    int insertCount = userList.Count - min;
                                    List<User> addItems = userList.GetRange(min, insertCount);
                                    _Params.users.AddRange(addItems);
                                    InsertItems(min, insertCount, false, false);
                                }
                                else
                                {
                                    // Remove
                                    int deleteCount = _Params.users.Count - min;
                                    if (deleteCount > 0)
                                    {
                                        RemoveItems(min, deleteCount, false, false);
                                        _Params.users.RemoveRange(min, deleteCount);
                                    }
                                }
                            }
                        }
                        // listShowUI
                        {
                            ListShowUI.UIData listShowUIData = this.data.listShowUIData.v;
                            if (listShowUIData != null)
                            {
                                listShowUIData.listShow.v = new ReferenceData<ListShow>(this.data.listShow.v);
                            }
                            else
                            {
                                Debug.LogError("listShowUIData null");
                            }
                        }
                        // UI
                        {
                            // header
                            float headerHeight = UIRectTransform.SetPosY(this.data.listShowUIData.v, 0);
                            {
                                UIRectTransform.SetSiblingIndex(this.data.listShowUIData.v, 0);
                            }
                            // viewPort
                            if (viewPort != null)
                            {
                                UIRectTransform rect = UIRectTransform.CreateFullRect(0, 0, headerHeight, 0);
                                rect.set(viewPort);
                            }
                            else
                            {
                                Debug.LogError("viewPort null");
                            }
                            // scrollBar
                            if (scrollBar != null)
                            {
                                UIRectTransform rect = new UIRectTransform();
                                {
                                    // anchoredPosition: (0.0, -14.0); anchorMin: (1.0, 0.0); anchorMax: (1.0, 1.0); pivot: (1.0, 0.5);
                                    // offsetMin: (-10.0, 0.0); offsetMax: (0.0, -28.0); sizeDelta: (10.0, -28.0);
                                    rect.anchoredPosition = new Vector3(0.0f, -headerHeight/2, 0.0f);
                                    rect.anchorMin = new Vector2(1.0f, 0.0f);
                                    rect.anchorMax = new Vector2(1.0f, 1.0f);
                                    rect.pivot = new Vector2(1.0f, 0.5f);
                                    rect.offsetMin = new Vector2(-10.0f, 0.0f);
                                    rect.offsetMax = new Vector2(0.0f, -headerHeight);
                                    rect.sizeDelta = new Vector2(10.0f, -headerHeight);
                                }
                                rect.set(scrollBar);
                            }
                            else
                            {
                                Debug.LogError("scrollBar null");
                            }
                        }
                    }
                    else
                    {
                        Debug.Log("server null: " + this);
                    }
                }
                else
                {
                    Debug.Log("data null: " + this);
                }
            }
            else
            {
                Debug.Log("not intialized: " + this);
            }
        }
    }

    #endregion

    #region implement callBacks

    public ListShowUI listShowPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.listShow.allAddCallBack(this);
                uiData.listShowUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Server)
            {
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            if (data is ListShow)
            {
                dirty = true;
                return;
            }
            // listShowUIData
            {
                if(data is ListShowUI.UIData)
                {
                    ListShowUI.UIData listShowUIData = data as ListShowUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(listShowUIData, listShowPrefab, this.transform);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(listShowUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.server.allRemoveCallBack(this);
                uiData.listShow.allRemoveCallBack(this);
                uiData.listShowUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Server)
            {
                return;
            }
            if (data is ListShow)
            {
                return;
            }
            // listShowUIData
            {
                if (data is ListShowUI.UIData)
                {
                    ListShowUI.UIData listShowUIData = data as ListShowUI.UIData;
                    // UI
                    {
                        listShowUIData.removeCallBackAndDestroy(typeof(ListShowUI));
                    }
                    // Child
                    {
                        TransformData.RemoveCallBack(listShowUIData, this);
                    }
                    return;
                }
                // Child
                if (data is TransformData)
                {
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
            {
                case UIData.Property.server:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.listShow:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.holders:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is Server)
            {
                switch ((Server.Property)wrapProperty.n)
                {
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
                        {
                            dirty = true;
                        }
                        break;
                    case Server.Property.globalChat:
                        break;
                    case Server.Property.friendWorld:
                        break;
                    case Server.Property.guilds:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is ListShow)
            {
                ListShow listShow = wrapProperty.p as ListShow;
                {
                    switch (listShow.getType())
                    {
                        case ListShow.Type.All:
                            {
                                switch ((ListShowAll.Property)wrapProperty.n)
                                {
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        case ListShow.Type.Limit:
                            {
                                switch ((ListShowLimit.Property)wrapProperty.n)
                                {
                                    case ListShowLimit.Property.index:
                                        dirty = true;
                                        break;
                                    case ListShowLimit.Property.count:
                                        dirty = true;
                                        break;
                                    default:
                                        Debug.LogError("Don't proces: " + wrapProperty + "; " + this);
                                        break;
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + listShow.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
            // listShowUIData
            {
                if (wrapProperty.p is ListShowUI.UIData)
                {
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.anchoredPosition:
                            break;
                        case TransformData.Property.anchorMin:
                            break;
                        case TransformData.Property.anchorMax:
                            break;
                        case TransformData.Property.pivot:
                            break;
                        case TransformData.Property.offsetMin:
                            break;
                        case TransformData.Property.offsetMax:
                            break;
                        case TransformData.Property.sizeDelta:
                            break;
                        case TransformData.Property.rotation:
                            break;
                        case TransformData.Property.scale:
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}