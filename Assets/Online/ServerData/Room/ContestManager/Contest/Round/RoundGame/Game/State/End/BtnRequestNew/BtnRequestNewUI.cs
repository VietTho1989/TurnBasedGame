using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class BtnRequestNewUI : UIHaveTransformDataBehavior<BtnRequestNewUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Round,
                ContestManager
            }

            public abstract Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            sub
        }

        public UIData() : base()
        {
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
                // make sub
                bool isHaveSub = false;
                {
                    // requestNewContestManager
                    if (!isHaveSub)
                    {
                        // find
                        RequestNewContestManager requestNewContestManager = null;
                        {
                            RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                            if (roomUIData != null)
                            {
                                RequestNewContestManagerUI.UIData requestNewContestManagerUIData = roomUIData.requestNewContestManagerUIData.v;
                                if (requestNewContestManagerUIData != null)
                                {
                                    requestNewContestManager = requestNewContestManagerUIData.requestNewContestManager.v.data;
                                }
                                else
                                {
                                    Debug.LogError("requestNewContestManagerUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("roomUIData null");
                            }
                        }
                        // process
                        if (requestNewContestManager != null)
                        {
                            if (requestNewContestManager.state.v.getType() != RequestNewContestManager.State.Type.None)
                            {
                                isHaveSub = true;
                                // makeUI
                                BtnNewContestManagerUI.UIData btnNewContestManagerUIData = this.data.sub.newOrOld<BtnNewContestManagerUI.UIData>();
                                {
                                    btnNewContestManagerUIData.requestNewContestManager.v = new ReferenceData<RequestNewContestManager>(requestNewContestManager);
                                }
                                this.data.sub.v = btnNewContestManagerUIData;
                            }
                        }
                        else
                        {
                            Debug.LogError("requestNewContestManager null");
                        }
                    }
                    // requestNewRound
                    if (!isHaveSub)
                    {
                        // find
                        RequestNewRound requestNewRound = null;
                        {
                            ContestUI.UIData contestUIData = this.data.findDataInParent<ContestUI.UIData>();
                            if (contestUIData != null)
                            {
                                RequestNewRoundUI.UIData requestNewRoundUIData = contestUIData.requestNewRoundUIData.v;
                                if (requestNewRoundUIData != null)
                                {
                                    requestNewRound = requestNewRoundUIData.requestNewRound.v.data;
                                }
                                else
                                {
                                    Debug.LogError("requestNewRoundUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("contestUIData null");
                            }
                        }
                        // process
                        if (requestNewRound != null)
                        {
                            if (requestNewRound.state.v.getType() != RequestNewRound.State.Type.None)
                            {
                                isHaveSub = true;
                                // make UI
                                BtnNewRoundUI.UIData btnNewRoundUIData = this.data.sub.newOrOld<BtnNewRoundUI.UIData>();
                                {
                                    btnNewRoundUIData.requestNewRound.v = new ReferenceData<RequestNewRound>(requestNewRound);
                                }
                                this.data.sub.v = btnNewRoundUIData;
                            }
                        }
                        else
                        {
                            Debug.LogError("requestNewRound null");
                        }
                    }
                }
                // process
                if (!isHaveSub)
                {
                    this.data.sub.v = null;
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    private ContestUI.UIData contestUIData = null;
    public BtnNewRoundUI btnNewRoundPrefab;

    private RoomUI.UIData roomUIData = null;
    public BtnNewContestManagerUI btnNewContestManagerPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.contestUIData);
                DataUtils.addParentCallBack(uiData, this, ref this.roomUIData);
            }
            // Child
            {
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            // contestUIData
            {
                if (data is ContestUI.UIData)
                {
                    ContestUI.UIData contestUIData = data as ContestUI.UIData;
                    // Child
                    {
                        contestUIData.requestNewRoundUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundUI.UIData)
                    {
                        RequestNewRoundUI.UIData requestNewRoundUIData = data as RequestNewRoundUI.UIData;
                        // Child
                        {
                            requestNewRoundUIData.requestNewRound.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is RequestNewRound)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // roomUIData
            {
                if(data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Child
                    {
                        roomUIData.requestNewContestManagerUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if(data is RequestNewContestManagerUI.UIData)
                    {
                        RequestNewContestManagerUI.UIData requestNewContestManagerUIData = data as RequestNewContestManagerUI.UIData;
                        // Child
                        {
                            requestNewContestManagerUIData.requestNewContestManager.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is RequestNewContestManager)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
        }
        // Child
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.Round:
                        {
                            BtnNewRoundUI.UIData btnNewRoundUIData = sub as BtnNewRoundUI.UIData;
                            UIUtils.Instantiate(btnNewRoundUIData, btnNewRoundPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.ContestManager:
                        {
                            BtnNewContestManagerUI.UIData btnNewContestManagerUIData = sub as BtnNewContestManagerUI.UIData;
                            UIUtils.Instantiate(btnNewContestManagerUIData, btnNewContestManagerPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType());
                        break;
                }
            }
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.contestUIData);
                DataUtils.removeParentCallBack(uiData, this, ref this.roomUIData);
            }
            // Child
            {
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Parent
        {
            // contestUIData
            {
                if (data is ContestUI.UIData)
                {
                    ContestUI.UIData contestUIData = data as ContestUI.UIData;
                    // Child
                    {
                        contestUIData.requestNewRoundUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundUI.UIData)
                    {
                        RequestNewRoundUI.UIData requestNewRoundUIData = data as RequestNewRoundUI.UIData;
                        // Child
                        {
                            requestNewRoundUIData.requestNewRound.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is RequestNewRound)
                    {
                        return;
                    }
                }
            }
            // roomUIData
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Child
                    {
                        roomUIData.requestNewContestManagerUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RequestNewContestManagerUI.UIData)
                    {
                        RequestNewContestManagerUI.UIData requestNewContestManagerUIData = data as RequestNewContestManagerUI.UIData;
                        // Child
                        {
                            requestNewContestManagerUIData.requestNewContestManager.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is RequestNewContestManager)
                    {
                        return;
                    }
                }
            }
        }
        // Child
        if (data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.Round:
                        {
                            BtnNewRoundUI.UIData btnNewRoundUIData = sub as BtnNewRoundUI.UIData;
                            btnNewRoundUIData.removeCallBackAndDestroy(typeof(BtnNewRoundUI));
                        }
                        break;
                    case UIData.Sub.Type.ContestManager:
                        {
                            BtnNewContestManagerUI.UIData btnNewContestManagerUIData = sub as BtnNewContestManagerUI.UIData;
                            btnNewContestManagerUIData.removeCallBackAndDestroy(typeof(BtnNewContestManagerUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType());
                        break;
                }
            }
            return;
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
        // Parent
        {
            // contestUIData
            {
                if (wrapProperty.p is ContestUI.UIData)
                {
                    switch ((ContestUI.UIData.Property)wrapProperty.n)
                    {
                        case ContestUI.UIData.Property.contest:
                            break;
                        case ContestUI.UIData.Property.roundUIData:
                            break;
                        case ContestUI.UIData.Property.requestNewRoundUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ContestUI.UIData.Property.chooseRoundUIData:
                            break;
                        case ContestUI.UIData.Property.isAutoNewRound:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is RequestNewRoundUI.UIData)
                    {
                        switch ((RequestNewRoundUI.UIData.Property)wrapProperty.n)
                        {
                            case RequestNewRoundUI.UIData.Property.requestNewRound:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case RequestNewRoundUI.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is RequestNewRound)
                    {
                        switch ((RequestNewRound.Property)wrapProperty.n)
                        {
                            case RequestNewRound.Property.state:
                                dirty = true;
                                break;
                            case RequestNewRound.Property.limit:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            // roomUIData
            {
                if (wrapProperty.p is RoomUI.UIData)
                {
                    switch ((RoomUI.UIData.Property)wrapProperty.n)
                    {
                        case RoomUI.UIData.Property.room:
                            break;
                        case RoomUI.UIData.Property.roomBtnUIData:
                            break;
                        case RoomUI.UIData.Property.contestManagerUIData:
                            break;
                        case RoomUI.UIData.Property.requestNewContestManagerUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case RoomUI.UIData.Property.chooseContestManagerUIData:
                            break;
                        case RoomUI.UIData.Property.roomUserInformUI:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is RequestNewContestManagerUI.UIData)
                    {
                        switch ((RequestNewContestManagerUI.UIData.Property)wrapProperty.n)
                        {
                            case RequestNewContestManagerUI.UIData.Property.requestNewContestManager:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case RequestNewContestManagerUI.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is RequestNewContestManager)
                    {
                        switch ((RequestNewContestManager.Property)wrapProperty.n)
                        {
                            case RequestNewContestManager.Property.state:
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
        }
        // Child
        if (wrapProperty.p is UIData.Sub)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}