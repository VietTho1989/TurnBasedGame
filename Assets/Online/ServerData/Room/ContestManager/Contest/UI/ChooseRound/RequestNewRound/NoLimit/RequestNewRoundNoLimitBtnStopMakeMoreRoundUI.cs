using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRoundNoLimitBtnStopMakeMoreRoundUI : UIBehavior<RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RequestNewRoundNoLimit>> requestNewRoundNoLimit;

            #region isStopMakeMoreRound

            public VP<RequestChangeBoolUI.UIData> isStopMakeMoreRound;

            public void makeRequestChangeIsStopMakeMoreRound(RequestChangeUpdate<bool>.UpdateData update, bool newIsStopMakeMoreRound)
            {
                // Find
                RequestNewRoundNoLimit requestNewRoundNoLimit = this.requestNewRoundNoLimit.v.data;
                // Process
                if (requestNewRoundNoLimit != null)
                {
                    requestNewRoundNoLimit.requestChangeIsStopMakeMoreRound(Server.getProfileUserId(requestNewRoundNoLimit), newIsStopMakeMoreRound);
                }
                else
                {
                    Debug.LogError("requestNewRoundNoLimit null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                requestNewRoundNoLimit,
                isStopMakeMoreRound
            }

            public UIData() : base()
            {
                this.requestNewRoundNoLimit = new VP<ReferenceData<RequestNewRoundNoLimit>>(this, (byte)Property.requestNewRoundNoLimit, new ReferenceData<RequestNewRoundNoLimit>(null));
                // isStopMakeMoreRound
                {
                    this.isStopMakeMoreRound = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.isStopMakeMoreRound, new RequestChangeBoolUI.UIData());
                    this.isStopMakeMoreRound.v.updateData.v.request.v = makeRequestChangeIsStopMakeMoreRound;
                }
            }

            #endregion

        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RequestNewRoundNoLimit noLimit = this.data.requestNewRoundNoLimit.v.data;
                    if (noLimit != null)
                    {
                        // get server state
                        Server.State.Type serverState = Server.State.Type.Connect;
                        {
                            Server server = noLimit.findDataInParent<Server>();
                            if (server != null)
                            {
                                if (server.state.v != null)
                                {
                                    serverState = server.state.v.getType();
                                }
                                else
                                {
                                    Debug.LogError("server state null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("server null: " + this);
                            }
                        }
                        // request
                        {
                            //isStopMakeMoreRound
                            {
                                RequestChangeBoolUI.UIData isStopMakeMoreRound = this.data.isStopMakeMoreRound.v;
                                if (isStopMakeMoreRound != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = isStopMakeMoreRound.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.origin.v = noLimit.isStopMakeMoreRound.v;
                                        updateData.canRequestChange.v = noLimit.isCanChangeIsStopMakeMoreRound(Server.getProfileUserId(noLimit));
                                        updateData.serverState.v = serverState;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                    // compare
                                    {
                                        isStopMakeMoreRound.showDifferent.v = false;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("isStopMakeMoreRound null: " + this);
                                }
                            }
                        }
                        // reset
                        if (needReset)
                        {
                            needReset = false;
                            // isStopMakeMoreRound
                            {
                                RequestChangeBoolUI.UIData isStopMakeMoreRound = this.data.isStopMakeMoreRound.v;
                                if (isStopMakeMoreRound != null)
                                {
                                    // update
                                    RequestChangeUpdate<bool>.UpdateData updateData = isStopMakeMoreRound.updateData.v;
                                    if (updateData != null)
                                    {
                                        updateData.current.v = noLimit.isStopMakeMoreRound.v;
                                        updateData.changeState.v = Data.ChangeState.None;
                                    }
                                    else
                                    {
                                        Debug.LogError("updateData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("isStopMakeMoreRound null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError ("contestManagerStatePlay null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public RequestChangeBoolUI requestBoolPrefab;

        public Transform isStopMakeMoreRoundContainer;

        private RoomCheckChangeAdminChange<RequestNewRoundNoLimit> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestNewRoundNoLimit>();

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.requestNewRoundNoLimit.allAddCallBack(this);
                    uiData.isStopMakeMoreRound.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                // requestNewRoundNoLimit
                {
                    if (data is RequestNewRoundNoLimit)
                    {
                        RequestNewRoundNoLimit requestNewRoundNoLimit = data as RequestNewRoundNoLimit;
                        // CheckChange
                        {
                            roomCheckAdminChange.addCallBack(this);
                            roomCheckAdminChange.setData(requestNewRoundNoLimit);
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(requestNewRoundNoLimit, this, ref this.server);
                        }
                        needReset = true;
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<RequestNewRoundNoLimit>)
                    {
                        dirty = true;
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        dirty = true;
                        return;
                    }
                }
                // isStopMakeMoreRound
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.isStopMakeMoreRound:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, isStopMakeMoreRoundContainer);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
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
                    uiData.requestNewRoundNoLimit.allRemoveCallBack(this);
                    uiData.isStopMakeMoreRound.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                // requestNewRoundNoLimit
                {
                    if (data is RequestNewRoundNoLimit)
                    {
                        RequestNewRoundNoLimit requestNewRoundNoLimit = data as RequestNewRoundNoLimit;
                        // CheckChange
                        {
                            roomCheckAdminChange.removeCallBack(this);
                            roomCheckAdminChange.setData(null);
                        }
                        // Parent
                        {
                            DataUtils.removeParentCallBack(requestNewRoundNoLimit, this, ref this.server);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<RequestNewRoundNoLimit>)
                    {
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                }
                // isStopMakeMoreRound
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
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
                    case UIData.Property.requestNewRoundNoLimit:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isStopMakeMoreRound:
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
                // requestNewRoundNoLimit
                {
                    if (wrapProperty.p is RequestNewRoundNoLimit)
                    {
                        switch ((RequestNewRoundNoLimit.Property)wrapProperty.n)
                        {
                            case RequestNewRoundNoLimit.Property.isStopMakeMoreRound:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is RoomCheckChangeAdminChange<RequestNewRoundNoLimit>)
                    {
                        dirty = true;
                        return;
                    }
                    // Parent
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                        return;
                    }
                }
                // isStopMakeMoreRound
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}