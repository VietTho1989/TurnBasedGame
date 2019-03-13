using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class EliminationContentUI : UIBehavior<EliminationContentUI.UIData>
    {

        #region UIData

        public class UIData : ContestManagerContent.UIData
        {

            public VP<ReferenceData<EliminationContent>> eliminationContent;

            public VP<EliminationRoundUI.UIData> eliminationRoundUIData;

            public VP<ChooseEliminationRoundUI.UIData> chooseEliminationRoundUIData;

            public VP<RequestNewEliminationRoundUI.UIData> requestNewEliminationRoundUIData;

            #region Constructor

            public enum Property
            {
                eliminationContent,
                eliminationRoundUIData,
                chooseEliminationRoundUIData,
                requestNewEliminationRoundUIData
            }

            public UIData() : base()
            {
                this.eliminationContent = new VP<ReferenceData<EliminationContent>>(this, (byte)Property.eliminationContent, new ReferenceData<EliminationContent>(null));
                this.eliminationRoundUIData = new VP<EliminationRoundUI.UIData>(this, (byte)Property.eliminationRoundUIData, new EliminationRoundUI.UIData());
                this.chooseEliminationRoundUIData = new VP<ChooseEliminationRoundUI.UIData>(this, (byte)Property.chooseEliminationRoundUIData, null);
                this.requestNewEliminationRoundUIData = new VP<RequestNewEliminationRoundUI.UIData>(this, (byte)Property.requestNewEliminationRoundUIData, new RequestNewEliminationRoundUI.UIData());
            }

            #endregion

            public override ContestManagerContent.Type getType()
            {
                return ContestManagerContent.Type.Elimination;
            }

            public void reset()
            {
                this.chooseEliminationRoundUIData.v = null;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // requestNewEliminationRoundUIData
                    if (!isProcess)
                    {
                        RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = this.requestNewEliminationRoundUIData.v;
                        if (requestNewEliminationRoundUIData != null)
                        {
                            isProcess = requestNewEliminationRoundUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("requestNewEliminationRoundUIData null: " + this);
                        }
                    }
                    // chooseEliminationRoundUIData
                    if (!isProcess)
                    {
                        ChooseEliminationRoundUI.UIData chooseEliminationRoundUIData = this.chooseEliminationRoundUIData.v;
                        if (chooseEliminationRoundUIData != null)
                        {
                            isProcess = chooseEliminationRoundUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chooseEliminationRoundUIData null: " + this);
                        }
                    }
                    // eliminationRoundUIData
                    if (!isProcess)
                    {
                        EliminationRoundUI.UIData eliminationRoundUIData = this.eliminationRoundUIData.v;
                        if (eliminationRoundUIData != null)
                        {
                            isProcess = eliminationRoundUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("eliminationRoundUIData null: " + this);
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
                    EliminationContent eliminationContent = this.data.eliminationContent.v.data;
                    if (eliminationContent != null)
                    {
                        // eliminationRoundUIData
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(eliminationContent, out dataIdentity))
                                    {
                                        if (dataIdentity is EliminationContentIdentity)
                                        {
                                            EliminationContentIdentity eliminationContentIdentity = dataIdentity as EliminationContentIdentity;
                                            if (eliminationContentIdentity.rounds != eliminationContent.rounds.vs.Count)
                                            {
                                                Debug.LogError("eliminationontent round count error");
                                                isLoadFull = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not eliminationContentIdentity");
                                        }
                                    }
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                EliminationRoundUI.UIData eliminationRoundUIData = this.data.eliminationRoundUIData.v;
                                if (eliminationRoundUIData != null)
                                {
                                    // get active list
                                    List<EliminationRound> eliminationRounds = new List<EliminationRound>();
                                    {
                                        foreach (EliminationRound eliminationRound in eliminationContent.rounds.vs)
                                        {
                                            if (eliminationRound.isActive.v)
                                            {
                                                eliminationRounds.Add(eliminationRound);
                                            }
                                        }
                                    }
                                    // find
                                    bool alreadySet = false;
                                    {
                                        EliminationRound eliminationRound = eliminationRoundUIData.eliminationRound.v.data;
                                        if (eliminationRound != null)
                                        {
                                            if (eliminationRound.isActive.v)
                                            {
                                                if (eliminationContent.rounds.vs.Contains(eliminationRound))
                                                {
                                                    alreadySet = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("eliminationRound null: " + this);
                                        }
                                    }
                                    // set
                                    if (!alreadySet)
                                    {
                                        // Process
                                        if (eliminationRounds.Count > 0)
                                        {
                                            // find
                                            EliminationRound chosenEliminationRound = eliminationRounds[eliminationRounds.Count - 1];
                                            // set
                                            eliminationRoundUIData.eliminationRound.v = new ReferenceData<EliminationRound>(chosenEliminationRound);
                                        }
                                        else
                                        {
                                            Debug.LogError("why don't have bracketContests: " + this);
                                        }
                                    }
                                    else
                                    {
                                        // khi next round
                                        if (haveNewRound)
                                        {
                                            if (eliminationRounds.Count >= 2)
                                            {
                                                // find needNext
                                                bool needNext = false;
                                                {
                                                    EliminationRound current = eliminationRoundUIData.eliminationRound.v.data;
                                                    if (current != null)
                                                    {
                                                        if (current.index.v == eliminationRounds.Count - 2)
                                                        {
                                                            needNext = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("current null: " + this);
                                                    }
                                                }
                                                // process
                                                if (needNext)
                                                {
                                                    eliminationRoundUIData.eliminationRound.v = new ReferenceData<EliminationRound>(eliminationRounds[eliminationRounds.Count - 1]);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("bracketContestUIData null: " + this);
                                }
                                haveNewRound = false;
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        // chooseEliminationRoundUIData
                        {
                            ChooseEliminationRoundUI.UIData chooseEliminationRoundUIData = this.data.chooseEliminationRoundUIData.v;
                            if (chooseEliminationRoundUIData != null)
                            {
                                chooseEliminationRoundUIData.eliminationContent.v = new ReferenceData<EliminationContent>(eliminationContent);
                            }
                            else
                            {
                                // Debug.LogError ("chooseEliminationRoundUIData null: " + this);
                            }
                        }
                        // requestNewEliminationRoundUIData
                        {
                            RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = this.data.requestNewEliminationRoundUIData.v;
                            if (requestNewEliminationRoundUIData != null)
                            {
                                requestNewEliminationRoundUIData.requestNewEliminationRound.v = new ReferenceData<RequestNewEliminationRound>(eliminationContent.requestNewRound.v);
                            }
                            else
                            {
                                Debug.LogError("requestNewEliminationRoundUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("bracket null: " + this);
                    }
                    // siblingIndex
                    {
                        UIRectTransform.SetSiblingIndex(this.data.eliminationRoundUIData.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.chooseEliminationRoundUIData.v, 1);
                        UIRectTransform.SetSiblingIndex(this.data.requestNewEliminationRoundUIData.v, 2);
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

        public EliminationRoundUI eliminationRoundPrefab;

        public ChooseEliminationRoundUI chooseEliminationRoundPrefab;
        private static readonly UIRectTransform chooseEliminationRoundRect = UIRectTransform.CreateCenterRect(360, 400);

        public RequestNewEliminationRoundUI requestNewEliminationRoundPrefab;

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
                    uiData.eliminationContent.allAddCallBack(this);
                    uiData.eliminationRoundUIData.allAddCallBack(this);
                    uiData.chooseEliminationRoundUIData.allAddCallBack(this);
                    uiData.requestNewEliminationRoundUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Add BtnEliminationContentUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            BtnEliminationContentUI.UIData btnEliminationContentUIData = new BtnEliminationContentUI.UIData();
                            {
                                btnEliminationContentUIData.uid = roomBtnUIData.subs.makeId();
                                btnEliminationContentUIData.eliminationContentUIData.v = new ReferenceData<UIData>(this.data);
                            }
                            roomBtnUIData.subs.add(btnEliminationContentUIData);
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
                // eliminationContent
                {
                    if (data is EliminationContent)
                    {
                        EliminationContent eliminationContent = data as EliminationContent;
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
                        // Child
                        {
                            eliminationContent.rounds.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is EliminationRound)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is EliminationRoundUI.UIData)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = data as EliminationRoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(eliminationRoundUIData, eliminationRoundPrefab, this.transform, UIConstants.FullParent);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChooseEliminationRoundUI.UIData)
                {
                    ChooseEliminationRoundUI.UIData chooseEliminationRoundUIData = data as ChooseEliminationRoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseEliminationRoundUIData, chooseEliminationRoundPrefab, this.transform, chooseEliminationRoundRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is RequestNewEliminationRoundUI.UIData)
                {
                    RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = data as RequestNewEliminationRoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(requestNewEliminationRoundUIData, requestNewEliminationRoundPrefab, this.transform, UIConstants.FullParent);
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
                    uiData.eliminationContent.allRemoveCallBack(this);
                    uiData.eliminationRoundUIData.allRemoveCallBack(this);
                    uiData.chooseEliminationRoundUIData.allRemoveCallBack(this);
                    uiData.requestNewEliminationRoundUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Remove BtnEliminationContentUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs)
                            {
                                if (sub is BtnEliminationContentUI.UIData)
                                {
                                    BtnEliminationContentUI.UIData btnEliminationContentUIData = sub as BtnEliminationContentUI.UIData;
                                    if (btnEliminationContentUIData.eliminationContentUIData.v.data == this.data)
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
                // eliminationContent
                {
                    if (data is EliminationContent)
                    {
                        EliminationContent eliminationContent = data as EliminationContent;
                        // Child
                        {
                            eliminationContent.rounds.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is EliminationRound)
                    {
                        return;
                    }
                }
                if (data is EliminationRoundUI.UIData)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = data as EliminationRoundUI.UIData;
                    // UI
                    {
                        eliminationRoundUIData.removeCallBackAndDestroy(typeof(EliminationRoundUI));
                    }
                    return;
                }
                if (data is ChooseEliminationRoundUI.UIData)
                {
                    ChooseEliminationRoundUI.UIData chooseEliminationRoundUIData = data as ChooseEliminationRoundUI.UIData;
                    // UI
                    {
                        chooseEliminationRoundUIData.removeCallBackAndDestroy(typeof(ChooseEliminationRoundUI));
                    }
                    return;
                }
                if (data is RequestNewEliminationRoundUI.UIData)
                {
                    RequestNewEliminationRoundUI.UIData requestNewEliminationRoundUIData = data as RequestNewEliminationRoundUI.UIData;
                    // UI
                    {
                        requestNewEliminationRoundUIData.removeCallBackAndDestroy(typeof(RequestNewEliminationRoundUI));
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
                    case UIData.Property.eliminationContent:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.eliminationRoundUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseEliminationRoundUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.requestNewEliminationRoundUIData:
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
                // eliminationContent
                {
                    if (wrapProperty.p is EliminationContent)
                    {
                        switch ((EliminationContent.Property)wrapProperty.n)
                        {
                            case EliminationContent.Property.singleContestFactory:
                                break;
                            case EliminationContent.Property.initTeamCounts:
                                break;
                            case EliminationContent.Property.requestNewRound:
                                break;
                            case EliminationContent.Property.rounds:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                    haveNewRound = true;
                                }
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is EliminationRound)
                    {
                        switch ((EliminationRound.Property)wrapProperty.n)
                        {
                            case EliminationRound.Property.isActive:
                                dirty = true;
                                break;
                            case EliminationRound.Property.state:
                                break;
                            case EliminationRound.Property.index:
                                break;
                            case EliminationRound.Property.brackets:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is EliminationRoundUI.UIData)
                {
                    switch ((EliminationRoundUI.UIData.Property)wrapProperty.n)
                    {
                        case EliminationRoundUI.UIData.Property.eliminationRound:
                            dirty = true;
                            break;
                        case EliminationRoundUI.UIData.Property.bracketUIData:
                            break;
                        case EliminationRoundUI.UIData.Property.chooseBracketUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ChooseEliminationRoundUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestNewEliminationRoundUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}