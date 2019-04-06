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

        public VP<ListShow> listShow;

        public LP<UserHolder.UIData> holders;

        #region Constructor

        public enum Property
        {
            server,
            listShow,
            holders
        }

        public UIData() : base()
        {
            this.server = new VP<ReferenceData<Server>>(this, (byte)Property.server, new ReferenceData<Server>(null));
            this.listShow = new VP<ListShow>(this, (byte)Property.listShow, new ListShowAll());
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

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.server.allAddCallBack(this);
                uiData.listShow.allAddCallBack(this);
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
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}