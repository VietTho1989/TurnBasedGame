using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;
using GameManager.Match.Elimination;
using GameManager.Match.RoundRobin;
using Ads;

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
                ContestManager,
                EliminationRound,
                RoundRobin
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

    public override int getStartAllocate()
    {
        return 1;
    }

    #region Refresh

    private bool lastHaveSub = false;

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
                            // Debug.LogError("requestNewContestManager null");
                        }
                    }
                    // requestNewEliminationRound
                    if (!isHaveSub)
                    {
                        // find
                        RequestNewEliminationRound requestNewEliminationRound = null;
                        {
                            EliminationContentUI.UIData eliminationContentUIData = this.data.findDataInParent<EliminationContentUI.UIData>();
                            if (eliminationContentUIData != null)
                            {
                                RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = eliminationContentUIData.requestNewEliminationRoundUIData.v;
                                if (requestNewEliminationRoundUIData != null)
                                {
                                    requestNewEliminationRound = requestNewEliminationRoundUIData.requestNewEliminationRound.v.data;
                                }
                                else
                                {
                                    Debug.LogError("requestNewEliminationRoundUIData null");
                                }
                            }
                            else
                            {
                                // Debug.LogError("eliminationContentUIData null");
                            }
                        }
                        // process
                        if (requestNewEliminationRound != null)
                        {
                            if (requestNewEliminationRound.state.v.getType() != RequestNewEliminationRound.State.Type.None)
                            {
                                isHaveSub = true;
                                // make UI
                                BtnNewEliminationRoundUI.UIData btnNewEliminationRoundUIData = this.data.sub.newOrOld<BtnNewEliminationRoundUI.UIData>();
                                {
                                    btnNewEliminationRoundUIData.requestNewEliminationRound.v = new ReferenceData<RequestNewEliminationRound>(requestNewEliminationRound);
                                }
                                this.data.sub.v = btnNewEliminationRoundUIData;
                            }
                        }
                    }
                    // requestNewRoundRobin
                    if (!isHaveSub)
                    {
                        // find
                        RequestNewRoundRobin requestNewRoundRobin = null;
                        {
                            RoundRobinContentUI.UIData roundRobinContentUIData = this.data.findDataInParent<RoundRobinContentUI.UIData>();
                            if (roundRobinContentUIData != null)
                            {
                                RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = roundRobinContentUIData.requestNewRoundRobinUIData.v;
                                if (requestNewRoundRobinUIData != null)
                                {
                                    requestNewRoundRobin = requestNewRoundRobinUIData.requestNewRoundRobin.v.data;
                                }
                                else
                                {
                                    Debug.LogError("requestNewRoundRobinUIData null");
                                }
                            }
                            else
                            {
                                // Debug.LogError("roundRobinContentUIData null");
                            }
                        }
                        // process
                        if (requestNewRoundRobin != null)
                        {
                            if (requestNewRoundRobin.state.v.getType() != RequestNewRoundRobin.State.Type.None)
                            {
                                isHaveSub = true;
                                // make UI
                                BtnNewRoundRobinUI.UIData btnNewRoundRobinUIData = this.data.sub.newOrOld<BtnNewRoundRobinUI.UIData>();
                                {
                                    btnNewRoundRobinUIData.requestNewRoundRobin.v = new ReferenceData<RequestNewRoundRobin>(requestNewRoundRobin);
                                }
                                this.data.sub.v = btnNewRoundRobinUIData;
                            }
                        }
                        else
                        {
                            // Debug.LogError("requestNewRoundRobin null");
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
                            // Debug.LogError("requestNewRound null");
                        }
                    }
                }
                // process
                if (!isHaveSub)
                {
                    this.data.sub.v = null;
                }
                // ads
                {
                    if (this.data.sub.v != null)
                    {
                        if (!lastHaveSub)
                        {
                            if (AdsManager.get().showAdsWhenGameEnd.v)
                            {
                                AdsManager.get().prepareBannerVisibility.v = AdsManager.PrepareBannerVisibility.Show;
                            }
                        }
                    }
                    else
                    {
                        if (lastHaveSub)
                        {
                            if (AdsManager.get().hideAdsWhenGameStart.v)
                            {
                                AdsManager.get().prepareBannerVisibility.v = AdsManager.PrepareBannerVisibility.Hide;
                            }
                        }
                    }
                    lastHaveSub = (this.data.sub.v != null);
                }
            }
            else
            {
                // Debug.LogError("data null");
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

    private EliminationContentUI.UIData eliminationContentUIData = null;
    public BtnNewEliminationRoundUI btnNewEliminationRoundPrefab;

    private RoundRobinContentUI.UIData roundRobinContentUIData = null;
    public BtnNewRoundRobinUI btnNewRoundRobinPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.contestUIData);
                DataUtils.addParentCallBack(uiData, this, ref this.roomUIData);
                DataUtils.addParentCallBack(uiData, this, ref this.eliminationContentUIData);
                DataUtils.addParentCallBack(uiData, this, ref this.roundRobinContentUIData);
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
                if (data is RoomUI.UIData)
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
                    if (data is RequestNewContestManagerUI.UIData)
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
                    if (data is RequestNewContestManager)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // eliminationContentUIData
            {
                if (data is EliminationContentUI.UIData)
                {
                    EliminationContentUI.UIData eliminationContentUIData = data as EliminationContentUI.UIData;
                    // Child
                    {
                        eliminationContentUIData.requestNewEliminationRoundUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RequestNewEliminationRoundUI.UIData)
                    {
                        RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = data as RequestNewEliminationRoundUI.UIData;
                        // Child
                        {
                            requestNewEliminationRoundUIData.requestNewEliminationRound.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is RequestNewEliminationRound)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // roundRobinContentUIData
            {
                if (data is RoundRobinContentUI.UIData)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = data as RoundRobinContentUI.UIData;
                    // Child
                    {
                        roundRobinContentUIData.requestNewRoundRobinUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundRobinUI.UIData)
                    {
                        RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = data as RequestNewRoundRobinUI.UIData;
                        // Child
                        {
                            requestNewRoundRobinUIData.requestNewRoundRobin.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is RequestNewRoundRobin)
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
                    case UIData.Sub.Type.EliminationRound:
                        {
                            BtnNewEliminationRoundUI.UIData btnNewEliminationRoundUIData = sub as BtnNewEliminationRoundUI.UIData;
                            UIUtils.Instantiate(btnNewEliminationRoundUIData, btnNewEliminationRoundPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.RoundRobin:
                        {
                            BtnNewRoundRobinUI.UIData btnNewRoundRobinUIData = sub as BtnNewRoundRobinUI.UIData;
                            UIUtils.Instantiate(btnNewRoundRobinUIData, btnNewRoundRobinPrefab, this.transform, UIConstants.FullParent);
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
                DataUtils.removeParentCallBack(uiData, this, ref this.eliminationContentUIData);
                DataUtils.removeParentCallBack(uiData, this, ref this.roundRobinContentUIData);
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
            // eliminationContentUIData
            {
                if (data is EliminationContentUI.UIData)
                {
                    EliminationContentUI.UIData eliminationContentUIData = data as EliminationContentUI.UIData;
                    // Child
                    {
                        eliminationContentUIData.requestNewEliminationRoundUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RequestNewEliminationRoundUI.UIData)
                    {
                        RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = data as RequestNewEliminationRoundUI.UIData;
                        // Child
                        {
                            requestNewEliminationRoundUIData.requestNewEliminationRound.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is RequestNewEliminationRound)
                    {
                        return;
                    }
                }
            }
            // roundRobinContentUIData
            {
                if (data is RoundRobinContentUI.UIData)
                {
                    RoundRobinContentUI.UIData roundRobinContentUIData = data as RoundRobinContentUI.UIData;
                    // Child
                    {
                        roundRobinContentUIData.requestNewRoundRobinUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundRobinUI.UIData)
                    {
                        RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = data as RequestNewRoundRobinUI.UIData;
                        // Child
                        {
                            requestNewRoundRobinUIData.requestNewRoundRobin.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is RequestNewRoundRobin)
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
                    case UIData.Sub.Type.EliminationRound:
                        {
                            BtnNewEliminationRoundUI.UIData btnNewEliminationRoundUIData = sub as BtnNewEliminationRoundUI.UIData;
                            btnNewEliminationRoundUIData.removeCallBackAndDestroy(typeof(BtnNewEliminationRoundUI));
                        }
                        break;
                    case UIData.Sub.Type.RoundRobin:
                        {
                            BtnNewRoundRobinUI.UIData btnNewRoundRobinUIData = sub as BtnNewRoundRobinUI.UIData;
                            btnNewRoundRobinUIData.removeCallBackAndDestroy(typeof(BtnNewRoundRobinUI));
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
            // eliminationContentUIData
            {
                if (wrapProperty.p is EliminationContentUI.UIData)
                {
                    switch ((EliminationContentUI.UIData.Property)wrapProperty.n)
                    {
                        case EliminationContentUI.UIData.Property.eliminationContent:
                            break;
                        case EliminationContentUI.UIData.Property.eliminationRoundUIData:
                            break;
                        case EliminationContentUI.UIData.Property.chooseEliminationRoundUIData:
                            break;
                        case EliminationContentUI.UIData.Property.requestNewEliminationRoundUIData:
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
                    if (wrapProperty.p is RequestNewEliminationRoundUI.UIData)
                    {
                        switch ((RequestNewEliminationRoundUI.UIData.Property)wrapProperty.n)
                        {
                            case RequestNewEliminationRoundUI.UIData.Property.requestNewEliminationRound:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case RequestNewEliminationRoundUI.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is RequestNewEliminationRound)
                    {
                        switch ((RequestNewEliminationRound.Property)wrapProperty.n)
                        {
                            case RequestNewEliminationRound.Property.state:
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
            // roundRobinContentUIData
            {
                if (wrapProperty.p is RoundRobinContentUI.UIData)
                {
                    switch ((RoundRobinContentUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinContentUI.UIData.Property.roundRobinContent:
                            break;
                        case RoundRobinContentUI.UIData.Property.roundRobinUIData:
                            break;
                        case RoundRobinContentUI.UIData.Property.chooseRoundRobinUIData:
                            break;
                        case RoundRobinContentUI.UIData.Property.requestNewRoundRobinUIData:
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
                    if (wrapProperty.p is RequestNewRoundRobinUI.UIData)
                    {
                        switch ((RequestNewRoundRobinUI.UIData.Property)wrapProperty.n)
                        {
                            case RequestNewRoundRobinUI.UIData.Property.requestNewRoundRobin:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case RequestNewRoundRobinUI.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is RequestNewRoundRobin)
                    {
                        switch ((RequestNewRoundRobin.Property)wrapProperty.n)
                        {
                            case RequestNewRoundRobin.Property.state:
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