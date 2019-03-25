using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestManagerPlayBtnForceEndUI : UIBehavior<ContestManagerPlayBtnForceEndUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

            #region isForceEnd

            public VP<RequestChangeBoolUI.UIData> isForceEnd;

            public void makeRequestChangeIsForceEnd(RequestChangeUpdate<bool>.UpdateData update, bool newIsForceEnd)
            {
                // Find
                ContestManagerStatePlay contestManagerStatePlay = this.contestManagerStatePlay.v.data;
                // Process
                if (contestManagerStatePlay != null)
                {
                    contestManagerStatePlay.requestChangeIsForceEnd(Server.getProfileUserId(contestManagerStatePlay), newIsForceEnd);
                }
                else
                {
                    Debug.LogError("singleContestFactory null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                contestManagerStatePlay,
                isForceEnd
            }

            public UIData() : base()
            {
                this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
                // isForceEnd
                {
                    this.isForceEnd = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.isForceEnd, new RequestChangeBoolUI.UIData());
                    this.isForceEnd.v.updateData.v.request.v = makeRequestChangeIsForceEnd;
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
                    ContestManagerStatePlay contestManagerStatePlay = this.data.contestManagerStatePlay.v.data;
                    if (contestManagerStatePlay != null)
                    {
                        // get server state
                        Server.State.Type serverState = Server.State.Type.Connect;
                        {
                            Server server = contestManagerStatePlay.findDataInParent<Server>();
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
                            RequestChangeBoolUI.UIData isForceEnd = this.data.isForceEnd.v;
                            if (isForceEnd != null)
                            {
                                // update
                                RequestChangeUpdate<bool>.UpdateData updateData = isForceEnd.updateData.v;
                                if (updateData != null)
                                {
                                    updateData.origin.v = contestManagerStatePlay.isForceEnd.v;
                                    updateData.canRequestChange.v = contestManagerStatePlay.isCanChangeForceEnd(Server.getProfileUserId(contestManagerStatePlay));
                                    updateData.serverState.v = serverState;
                                }
                                else
                                {
                                    Debug.LogError("updateData null: " + this);
                                }
                                // compare
                                {
                                    isForceEnd.showDifferent.v = false;
                                }
                            }
                            else
                            {
                                Debug.LogError("isForceEnd null: " + this);
                            }
                        }
                        // reset
                        if (needReset)
                        {
                            needReset = false;
                            RequestChangeBoolUI.UIData isForceEnd = this.data.isForceEnd.v;
                            if (isForceEnd != null)
                            {
                                // update
                                RequestChangeUpdate<bool>.UpdateData updateData = isForceEnd.updateData.v;
                                if (updateData != null)
                                {
                                    updateData.current.v = contestManagerStatePlay.isForceEnd.v;
                                    updateData.changeState.v = Data.ChangeState.None;
                                }
                                else
                                {
                                    Debug.LogError("updateData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("isForceEnd null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerStatePlay null: " + this);
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

        public RequestChangeBoolUI requestBoolPrefab;

        public Transform isForceEndContainer;
        private static readonly UIRectTransform isFroceEndRect = UIConstants.FullParent;

        private RoomCheckChangeAdminChange<ContestManagerStatePlay> roomCheckAdminChange = new RoomCheckChangeAdminChange<ContestManagerStatePlay>();

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.contestManagerStatePlay.allAddCallBack(this);
                    uiData.isForceEnd.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                // contestManagerStatePlay
                {
                    if (data is ContestManagerStatePlay)
                    {
                        ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                        // CheckChange
                        {
                            roomCheckAdminChange.addCallBack(this);
                            roomCheckAdminChange.setData(contestManagerStatePlay);
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(contestManagerStatePlay, this, ref this.server);
                        }
                        needReset = true;
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStatePlay>)
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
                // isForceEnd
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
                                case UIData.Property.isForceEnd:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, isForceEndContainer, isFroceEndRect);
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
                    uiData.contestManagerStatePlay.allRemoveCallBack(this);
                    uiData.isForceEnd.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                // contestManagerStatePlay
                {
                    if (data is ContestManagerStatePlay)
                    {
                        ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                        // CheckChange
                        {
                            roomCheckAdminChange.removeCallBack(this);
                            roomCheckAdminChange.setData(null);
                        }
                        // Parent
                        {
                            DataUtils.removeParentCallBack(contestManagerStatePlay, this, ref this.server);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStatePlay>)
                    {
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                }
                // isForceEnd
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
                    case UIData.Property.contestManagerStatePlay:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isForceEnd:
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
                // contestManagerStatePlay
                {
                    if (wrapProperty.p is ContestManagerStatePlay)
                    {
                        switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                        {
                            case ContestManagerStatePlay.Property.state:
                                break;
                            case ContestManagerStatePlay.Property.isForceEnd:
                                dirty = true;
                                break;
                            case ContestManagerStatePlay.Property.teams:
                                break;
                            case ContestManagerStatePlay.Property.content:
                                break;
                            case ContestManagerStatePlay.Property.randomTeamIndex:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is RoomCheckChangeAdminChange<ContestManagerStatePlay>)
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
                // isForceEnd
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