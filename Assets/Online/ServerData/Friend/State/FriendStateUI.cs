using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateUI : UIBehavior<FriendStateUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Friend>> friend;

        #region sub

        public abstract class Sub : Data
        {

            public abstract Friend.State.Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            friend,
            sub
        }

        public UIData() : base()
        {
            this.friend = new VP<ReferenceData<Friend>>(this, (byte)Property.friend, new ReferenceData<Friend>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

    }

    #endregion

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Friend friend = this.data.friend.v.data;
                if (friend != null)
                {
                    Friend.State state = friend.state.v;
                    if (state != null)
                    {
                        switch (state.getType())
                        {
                            case Friend.State.Type.None:
                                {
                                    FriendStateNone friendStateNone = state as FriendStateNone;
                                    // UIData
                                    FriendStateNoneUI.UIData friendStateNoneUIData = this.data.sub.newOrOld<FriendStateNoneUI.UIData>();
                                    {
                                        friendStateNoneUIData.friendStateNone.v = new ReferenceData<FriendStateNone>(friendStateNone);
                                    }
                                    this.data.sub.v = friendStateNoneUIData;
                                }
                                break;
                            case Friend.State.Type.Request:
                                {
                                    FriendStateRequest friendStateRequest = state as FriendStateRequest;
                                    // UIData
                                    FriendStateRequestUI.UIData friendStateRequestUIData = this.data.sub.newOrOld<FriendStateRequestUI.UIData>();
                                    {
                                        friendStateRequestUIData.friendStateRequest.v = new ReferenceData<FriendStateRequest>(friendStateRequest);
                                    }
                                    this.data.sub.v = friendStateRequestUIData;
                                }
                                break;
                            case Friend.State.Type.Accept:
                                {
                                    FriendStateAccept friendStateAccept = state as FriendStateAccept;
                                    // UIData
                                    FriendStateAcceptUI.UIData friendStateAcceptUIData = this.data.sub.newOrOld<FriendStateAcceptUI.UIData>();
                                    {
                                        friendStateAcceptUIData.friendStateAccept.v = new ReferenceData<FriendStateAccept>(friendStateAccept);
                                    }
                                    this.data.sub.v = friendStateAcceptUIData;
                                }
                                break;
                            case Friend.State.Type.Cancel:
                                {
                                    FriendStateCancel friendStateCancel = state as FriendStateCancel;
                                    // UIData
                                    FriendStateCancelUI.UIData friendStateCancelUIData = this.data.sub.newOrOld<FriendStateCancelUI.UIData>();
                                    {
                                        friendStateCancelUIData.friendStateCancel.v = new ReferenceData<FriendStateCancel>(friendStateCancel);
                                    }
                                    this.data.sub.v = friendStateCancelUIData;
                                }
                                break;
                            case Friend.State.Type.Ban:
                                {
                                    FriendStateBan friendStateBan = state as FriendStateBan;
                                    // UIData
                                    FriendStateBanUI.UIData friendStateBanUIData = this.data.sub.newOrOld<FriendStateBanUI.UIData>();
                                    {
                                        friendStateBanUIData.friendStateBan.v = new ReferenceData<FriendStateBan>(friendStateBan);
                                    }
                                    this.data.sub.v = friendStateBanUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("state null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("friend null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public FriendStateNoneUI friendStateNonePrefab;
    public FriendStateRequestUI friendStateRequestPrefab;
    public FriendStateAcceptUI friendStateAcceptPrefab;
    public FriendStateCancelUI friendStateCancelPrefab;
    public FriendStateBanUI friendStateBanPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.friend.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Friend)
            {
                dirty = true;
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case Friend.State.Type.Accept:
                            {
                                FriendStateAcceptUI.UIData friendStateAcceptUIData = sub as FriendStateAcceptUI.UIData;
                                UIUtils.Instantiate(friendStateAcceptUIData, friendStateAcceptPrefab, this.transform);
                            }
                            break;
                        case Friend.State.Type.Request:
                            {
                                FriendStateRequestUI.UIData friendStateRequestUIData = sub as FriendStateRequestUI.UIData;
                                UIUtils.Instantiate(friendStateRequestUIData, friendStateRequestPrefab, this.transform);
                            }
                            break;
                        case Friend.State.Type.None:
                            {
                                FriendStateNoneUI.UIData friendStateNoneUIData = sub as FriendStateNoneUI.UIData;
                                UIUtils.Instantiate(friendStateNoneUIData, friendStateNonePrefab, this.transform);
                            }
                            break;
                        case Friend.State.Type.Cancel:
                            {
                                FriendStateCancelUI.UIData friendStateCancelUIData = sub as FriendStateCancelUI.UIData;
                                UIUtils.Instantiate(friendStateCancelUIData, friendStateCancelPrefab, this.transform);
                            }
                            break;
                        case Friend.State.Type.Ban:
                            {
                                FriendStateBanUI.UIData friendStateBanUIData = sub as FriendStateBanUI.UIData;
                                UIUtils.Instantiate(friendStateBanUIData, friendStateBanPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
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
                uiData.friend.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Friend)
            {
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case Friend.State.Type.Accept:
                            {
                                FriendStateAcceptUI.UIData friendStateAcceptUIData = sub as FriendStateAcceptUI.UIData;
                                friendStateAcceptUIData.removeCallBackAndDestroy(typeof(FriendStateAcceptUI));
                            }
                            break;
                        case Friend.State.Type.Request:
                            {
                                FriendStateRequestUI.UIData friendStateRequestUIData = sub as FriendStateRequestUI.UIData;
                                friendStateRequestUIData.removeCallBackAndDestroy(typeof(FriendStateRequestUI));
                            }
                            break;
                        case Friend.State.Type.None:
                            {
                                FriendStateNoneUI.UIData friendStateNoneUIData = sub as FriendStateNoneUI.UIData;
                                friendStateNoneUIData.removeCallBackAndDestroy(typeof(FriendStateNoneUI));
                            }
                            break;
                        case Friend.State.Type.Cancel:
                            {
                                FriendStateCancelUI.UIData friendStateCancelUIData = sub as FriendStateCancelUI.UIData;
                                friendStateCancelUIData.removeCallBackAndDestroy(typeof(FriendStateCancelUI));
                            }
                            break;
                        case Friend.State.Type.Ban:
                            {
                                FriendStateBanUI.UIData friendStateBanUIData = sub as FriendStateBanUI.UIData;
                                friendStateBanUIData.removeCallBackAndDestroy(typeof(FriendStateBanUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
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
                case UIData.Property.friend:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is Friend)
            {
                switch ((Friend.Property)wrapProperty.n)
                {
                    case Friend.Property.state:
                        dirty = true;
                        break;
                    case Friend.Property.user1:
                        break;
                    case Friend.Property.user2:
                        break;
                    case Friend.Property.time:
                        break;
                    case Friend.Property.chatRoom:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}