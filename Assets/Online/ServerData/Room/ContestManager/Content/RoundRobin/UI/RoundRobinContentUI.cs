using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RoundRobinContentUI : UIBehavior<RoundRobinContentUI.UIData>
    {

        #region UIData

        public class UIData : ContestManagerContent.UIData
        {

            public VP<ReferenceData<RoundRobinContent>> roundRobinContent;

            public VP<RoundRobinUI.UIData> roundRobinUIData;

            public VP<ChooseRoundRobinUI.UIData> chooseRoundRobinUIData;

            public VP<RequestNewRoundRobinUI.UIData> requestNewRoundRobinUIData;

            #region Constructor

            public enum Property
            {
                roundRobinContent,
                roundRobinUIData,
                chooseRoundRobinUIData,
                requestNewRoundRobinUIData
            }

            public UIData() : base()
            {
                this.roundRobinContent = new VP<ReferenceData<RoundRobinContent>>(this, (byte)Property.roundRobinContent, new ReferenceData<RoundRobinContent>(null));
                this.roundRobinUIData = new VP<RoundRobinUI.UIData>(this, (byte)Property.roundRobinUIData, new RoundRobinUI.UIData());
                this.chooseRoundRobinUIData = new VP<ChooseRoundRobinUI.UIData>(this, (byte)Property.chooseRoundRobinUIData, null);
                this.requestNewRoundRobinUIData = new VP<RequestNewRoundRobinUI.UIData>(this, (byte)Property.requestNewRoundRobinUIData, new RequestNewRoundRobinUI.UIData());
            }

            #endregion

            public override ContestManagerContent.Type getType()
            {
                return ContestManagerContent.Type.RoundRobin;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // requestNewRoundRobinUIData
                    if (!isProcess)
                    {
                        RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = this.requestNewRoundRobinUIData.v;
                        if (requestNewRoundRobinUIData != null)
                        {
                            isProcess = requestNewRoundRobinUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("requestNewRoundRobinUIData null: " + this);
                        }
                    }
                    // chooseRoundRobinUIData
                    if (!isProcess)
                    {
                        ChooseRoundRobinUI.UIData chooseRoundRobinUIData = this.chooseRoundRobinUIData.v;
                        if (chooseRoundRobinUIData != null)
                        {
                            isProcess = chooseRoundRobinUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chooseRoundRobinUIData null: " + this);
                        }
                    }
                    // roundRobinUIData
                    if (!isProcess)
                    {
                        RoundRobinUI.UIData roundRobinUIData = this.roundRobinUIData.v;
                        if (roundRobinUIData != null)
                        {
                            isProcess = roundRobinUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roundRobinUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region Refresh

        private bool haveNewRound = false;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RoundRobinContent roundRobinContent = this.data.roundRobinContent.v.data;
                    if (roundRobinContent != null)
                    {
                        // roundRobinUIData
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(roundRobinContent, out dataIdentity))
                                    {
                                        if (dataIdentity is RoundRobinContentIdentity)
                                        {
                                            RoundRobinContentIdentity roundRobinContentIdentity = dataIdentity as RoundRobinContentIdentity;
                                            if (roundRobinContentIdentity.roundRobins != roundRobinContent.roundRobins.vs.Count)
                                            {
                                                Debug.LogError("roundRobinContent roundRobin count error");
                                                isLoadFull = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not roomIdentity");
                                        }
                                    }
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                RoundRobinUI.UIData roundRobinUIData = this.data.roundRobinUIData.v;
                                if (roundRobinUIData != null)
                                {
                                    if (roundRobinUIData.roundRobin.v.data == null || !roundRobinContent.roundRobins.vs.Contains(roundRobinUIData.roundRobin.v.data))
                                    {
                                        // choose last round
                                        if (roundRobinContent.roundRobins.vs.Count > 0)
                                        {
                                            RoundRobin lastRoundRobin = roundRobinContent.roundRobins.vs[roundRobinContent.roundRobins.vs.Count - 1];
                                            roundRobinUIData.roundRobin.v = new ReferenceData<RoundRobin>(lastRoundRobin);
                                        }
                                        else
                                        {
                                            Debug.LogError("don't have any round: " + this);
                                        }
                                    }
                                    else
                                    {
                                        if (haveNewRound)
                                        {
                                            // Debug.LogError ("have new round: " + this);
                                            if (roundRobinContent.roundRobins.vs.Count >= 2)
                                            {
                                                RoundRobin currentRoundRobin = roundRobinUIData.roundRobin.v.data;
                                                if (currentRoundRobin.index.v == roundRobinContent.roundRobins.vs.Count - 2)
                                                {
                                                    RoundRobin lastRoundRobin = roundRobinContent.roundRobins.vs[roundRobinContent.roundRobins.vs.Count - 1];
                                                    roundRobinUIData.roundRobin.v = new ReferenceData<RoundRobin>(lastRoundRobin);
                                                }
                                                else
                                                {
                                                    // Debug.LogError ("not round index correct: " + contest.rounds.vs.IndexOf (currentRound));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("roundRobinUIData null: " + this);
                                }
                                haveNewRound = false;
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        // chooseRoundRobinUIData
                        {
                            ChooseRoundRobinUI.UIData chooseRoundRobinUIData = this.data.chooseRoundRobinUIData.v;
                            if (chooseRoundRobinUIData != null)
                            {
                                chooseRoundRobinUIData.roundRobinContent.v = new ReferenceData<RoundRobinContent>(roundRobinContent);
                            }
                            else
                            {
                                // Debug.LogError ("chooseRoundRobinUIData null: " + this);
                            }
                        }
                        // requestNewRoundRobinUIData
                        {
                            RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = this.data.requestNewRoundRobinUIData.v;
                            if (requestNewRoundRobinUIData != null)
                            {
                                requestNewRoundRobinUIData.requestNewRoundRobin.v = new ReferenceData<RequestNewRoundRobin>(roundRobinContent.requestNewRoundRobin.v);
                            }
                            else
                            {
                                Debug.LogError("requestNewRoundRobinUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobinContent null: " + this);
                    }
                    // siblingIndex
                    {
                        UIRectTransform.SetSiblingIndex(this.data.roundRobinUIData.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.chooseRoundRobinUIData.v, 1);
                        UIRectTransform.SetSiblingIndex(this.data.requestNewRoundRobinUIData.v, 2);
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

        public RoundRobinUI roundRobinPrefab;

        public ChooseRoundRobinUI chooseRoundRobinPrefab;
        private static readonly UIRectTransform chooseRoundRobinRect = UIRectTransform.CreateCenterRect(360, 400);

        public RequestNewRoundRobinUI requestNewRoundRobinPrefab;

        private RoomUI.UIData roomUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.roomUIData);
                }
                // Child
                {
                    uiData.roundRobinContent.allAddCallBack(this);
                    uiData.roundRobinUIData.allAddCallBack(this);
                    uiData.chooseRoundRobinUIData.allAddCallBack(this);
                    uiData.requestNewRoundRobinUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Add BtnRoundRobinContentUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            BtnRoundRobinContentUI.UIData btnRoundRobinContentUIData = new BtnRoundRobinContentUI.UIData();
                            {
                                btnRoundRobinContentUIData.uid = roomBtnUIData.subs.makeId();
                                btnRoundRobinContentUIData.roundRobinContentUIData.v = new ReferenceData<UIData>(this.data);
                            }
                            roomBtnUIData.subs.add(btnRoundRobinContentUIData);
                        }
                        else
                        {
                            Debug.LogError("roomBtnUIData null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if (data is RoundRobinContent)
                {
                    dirty = true;
                    return;
                }
                if (data is RoundRobinUI.UIData)
                {
                    RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roundRobinUIData, roundRobinPrefab, this.transform, UIConstants.FullParent);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChooseRoundRobinUI.UIData)
                {
                    ChooseRoundRobinUI.UIData chooseRoundRobinUIData = data as ChooseRoundRobinUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundRobinUIData, chooseRoundRobinPrefab, this.transform, chooseRoundRobinRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is RequestNewRoundRobinUI.UIData)
                {
                    RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = data as RequestNewRoundRobinUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(requestNewRoundRobinUIData, requestNewRoundRobinPrefab, this.transform, UIConstants.FullParent);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.roomUIData);
                }
                // Child
                {
                    uiData.roundRobinContent.allRemoveCallBack(this);
                    uiData.roundRobinUIData.allRemoveCallBack(this);
                    uiData.chooseRoundRobinUIData.allRemoveCallBack(this);
                    uiData.requestNewRoundRobinUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Remove BtnRoundRobinContentUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs)
                            {
                                if (sub is BtnRoundRobinContentUI.UIData)
                                {
                                    BtnRoundRobinContentUI.UIData btnRoundRobinContentUIData = sub as BtnRoundRobinContentUI.UIData;
                                    if (btnRoundRobinContentUIData.roundRobinContentUIData.v.data == this.data)
                                    {
                                        roomBtnUIData.subs.remove(sub);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("roomBtnUIData null: " + this);
                        }
                    }
                    return;
                }
            }
            // Child
            {
                if (data is RoundRobinContent)
                {
                    return;
                }
                if (data is RoundRobinUI.UIData)
                {
                    RoundRobinUI.UIData roundRobinUIData = data as RoundRobinUI.UIData;
                    // UI
                    {
                        roundRobinUIData.removeCallBackAndDestroy(typeof(RoundRobinUI));
                    }
                    return;
                }
                if (data is ChooseRoundRobinUI.UIData)
                {
                    ChooseRoundRobinUI.UIData chooseRoundRobinUIData = data as ChooseRoundRobinUI.UIData;
                    // UI
                    {
                        chooseRoundRobinUIData.removeCallBackAndDestroy(typeof(ChooseRoundRobinUI));
                    }
                    return;
                }
                if (data is RequestNewRoundRobinUI.UIData)
                {
                    RequestNewRoundRobinUI.UIData requestNewRoundRobinUIData = data as RequestNewRoundRobinUI.UIData;
                    // UI
                    {
                        requestNewRoundRobinUIData.removeCallBackAndDestroy(typeof(RequestNewRoundRobinUI));
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
                    case UIData.Property.roundRobinContent:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundRobinUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseRoundRobinUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.requestNewRoundRobinUIData:
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
            if (wrapProperty.p is RoomUI.UIData)
            {
                return;
            }
            // Child
            {
                if (wrapProperty.p is RoundRobinContent)
                {
                    switch ((RoundRobinContent.Property)wrapProperty.n)
                    {
                        case RoundRobinContent.Property.singleContestFactory:
                            break;
                        case RoundRobinContent.Property.roundRobins:
                            dirty = true;
                            haveNewRound = true;
                            break;
                        case RoundRobinContent.Property.requestNewRoundRobin:
                            break;
                        case RoundRobinContent.Property.needReturnRound:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is RoundRobinUI.UIData)
                {
                    switch ((RoundRobinUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundRobinUI.UIData.Property.roundRobin:
                            dirty = true;
                            break;
                        case RoundRobinUI.UIData.Property.roundContestUIData:
                            break;
                        case RoundRobinUI.UIData.Property.chooseRoundContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ChooseRoundRobinUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestNewRoundRobinUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}