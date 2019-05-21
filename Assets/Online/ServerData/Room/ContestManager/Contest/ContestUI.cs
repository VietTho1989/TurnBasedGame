using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestUI : UIBehavior<ContestUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Contest>> contest;

            public VP<RoundUI.UIData> roundUIData;

            public VP<RequestNewRoundUI.UIData> requestNewRoundUIData;

            public VP<ChooseRoundUI.UIData> chooseRoundUIData;

            public VP<bool> isAutoNewRound;

            #region Constructor

            public enum Property
            {
                contest,
                roundUIData,
                requestNewRoundUIData,
                chooseRoundUIData,
                isAutoNewRound
            }

            public UIData() : base()
            {
                this.contest = new VP<ReferenceData<Contest>>(this, (byte)Property.contest, new ReferenceData<Contest>(null));
                this.roundUIData = new VP<RoundUI.UIData>(this, (byte)Property.roundUIData, new RoundUI.UIData());
                this.requestNewRoundUIData = new VP<RequestNewRoundUI.UIData>(this, (byte)Property.requestNewRoundUIData, new RequestNewRoundUI.UIData());
                this.chooseRoundUIData = new VP<ChooseRoundUI.UIData>(this, (byte)Property.chooseRoundUIData, null);
                this.isAutoNewRound = new VP<bool>(this, (byte)Property.isAutoNewRound, true);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // chooseRoundUIData
                    if (!isProcess)
                    {
                        ChooseRoundUI.UIData chooseRoundUIData = this.chooseRoundUIData.v;
                        if (chooseRoundUIData != null)
                        {
                            isProcess = chooseRoundUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chooseRoundUIData null: " + this);
                        }
                    }
                    // requestNewRoundUIData
                    if (!isProcess)
                    {
                        RequestNewRoundUI.UIData requestNewRoundUIData = this.requestNewRoundUIData.v;
                        if (requestNewRoundUIData != null)
                        {
                            isProcess = requestNewRoundUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("requestNewRoundUIData null: " + this);
                        }
                    }
                    // roundUIData
                    if (!isProcess)
                    {
                        RoundUI.UIData roundUIData = this.roundUIData.v;
                        if (roundUIData != null)
                        {
                            isProcess = roundUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roundUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return 1;
        }

        #region Refresh

        private bool haveNewRound = false;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Contest contest = this.data.contest.v.data;
                    if (contest != null)
                    {
                        // roundUIData
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(contest, out dataIdentity))
                                    {
                                        if (dataIdentity is ContestIdentity)
                                        {
                                            ContestIdentity contestIdentity = dataIdentity as ContestIdentity;
                                            if (contestIdentity.rounds != contest.rounds.vs.Count)
                                            {
                                                Debug.LogError("contestManagers count error");
                                                isLoadFull = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not contestIdentity");
                                        }
                                    }
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                RoundUI.UIData roundUIData = this.data.roundUIData.v;
                                if (roundUIData != null)
                                {
                                    if (roundUIData.round.v.data == null || !contest.rounds.vs.Contains(roundUIData.round.v.data))
                                    {
                                        // choose last round
                                        if (contest.rounds.vs.Count > 0)
                                        {
                                            Round lastRound = contest.rounds.vs[contest.rounds.vs.Count - 1];
                                            roundUIData.round.v = new ReferenceData<Round>(lastRound);
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
                                            if (this.data.isAutoNewRound.v)
                                            {
                                                if (contest.rounds.vs.Count >= 2)
                                                {
                                                    Round currentRound = roundUIData.round.v.data;
                                                    if (currentRound.index.v == contest.rounds.vs.Count - 2)
                                                    {
                                                        Round lastRound = contest.rounds.vs[contest.rounds.vs.Count - 1];
                                                        roundUIData.round.v = new ReferenceData<Round>(lastRound);
                                                    }
                                                    else
                                                    {
                                                        // Debug.LogError ("not round index correct: " + contest.rounds.vs.IndexOf (currentRound));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("roundUIData null: " + this);
                                }
                                haveNewRound = false;
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        // requestNewRoundUIData
                        {
                            RequestNewRoundUI.UIData requestNewRoundUIData = this.data.requestNewRoundUIData.v;
                            if (requestNewRoundUIData != null)
                            {
                                requestNewRoundUIData.requestNewRound.v = new ReferenceData<RequestNewRound>(contest.requestNewRound.v);
                            }
                            else
                            {
                                Debug.LogError("requestNewRoundUIData null: " + this);
                            }
                        }
                        // chooseRoundUIData
                        {
                            ChooseRoundUI.UIData chooseRoundUIData = this.data.chooseRoundUIData.v;
                            if (chooseRoundUIData != null)
                            {
                                chooseRoundUIData.contest.v = new ReferenceData<Contest>(contest);
                            }
                            else
                            {
                                // Debug.LogError("chooseRoundUIData null: " + this);
                            }
                        }
                        // SiblingIndex
                        {
                            UIRectTransform.SetSiblingIndex(this.data.roundUIData.v, 0);
                            UIRectTransform.SetSiblingIndex(this.data.requestNewRoundUIData.v, 1);
                            UIRectTransform.SetSiblingIndex(this.data.chooseRoundUIData.v, 2);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("contest null: " + this);
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

        public RoundUI roundPrefab;
        private static readonly UIRectTransform roundRect = UIConstants.FullParent;

        public RequestNewRoundUI requestNewRoundPrefab;
        private static readonly UIRectTransform requestNewRoundRect = UIConstants.FullParent;

        public ChooseRoundUI chooseRoundPrefab;

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
                    uiData.contest.allAddCallBack(this);
                    uiData.roundUIData.allAddCallBack(this);
                    uiData.requestNewRoundUIData.allAddCallBack(this);
                    uiData.chooseRoundUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Add BtnContestUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            BtnContestUI.UIData btnContestUIData = new BtnContestUI.UIData();
                            {
                                btnContestUIData.uid = roomBtnUIData.subs.makeId();
                                btnContestUIData.contestUIData.v = new ReferenceData<UIData>(this.data);
                            }
                            roomBtnUIData.subs.add(btnContestUIData);
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
                if (data is Contest)
                {
                    dirty = true;
                    return;
                }
                if (data is RoundUI.UIData)
                {
                    RoundUI.UIData roundUIData = data as RoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roundUIData, roundPrefab, this.transform, roundRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is RequestNewRoundUI.UIData)
                {
                    RequestNewRoundUI.UIData requestNewRoundUIData = data as RequestNewRoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(requestNewRoundUIData, requestNewRoundPrefab, this.transform, requestNewRoundRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChooseRoundUI.UIData)
                {
                    ChooseRoundUI.UIData chooseRoundUIData = data as ChooseRoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundUIData, chooseRoundPrefab, this.transform);
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
                    uiData.contest.allRemoveCallBack(this);
                    uiData.roundUIData.allRemoveCallBack(this);
                    uiData.requestNewRoundUIData.allRemoveCallBack(this);
                    uiData.chooseRoundUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Remove BtnContestUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs)
                            {
                                if (sub is BtnContestUI.UIData)
                                {
                                    BtnContestUI.UIData btnContestUIData = sub as BtnContestUI.UIData;
                                    if (btnContestUIData.contestUIData.v.data == this.data)
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
                if (data is Contest)
                {
                    return;
                }
                if (data is RoundUI.UIData)
                {
                    RoundUI.UIData roundUIData = data as RoundUI.UIData;
                    // UI
                    {
                        roundUIData.removeCallBackAndDestroy(typeof(RoundUI));
                    }
                    return;
                }
                if (data is RequestNewRoundUI.UIData)
                {
                    RequestNewRoundUI.UIData requestNewRoundUIData = data as RequestNewRoundUI.UIData;
                    // UI
                    {
                        requestNewRoundUIData.removeCallBackAndDestroy(typeof(RequestNewRoundUI));
                    }
                    return;
                }
                if (data is ChooseRoundUI.UIData)
                {
                    ChooseRoundUI.UIData chooseRoundUIData = data as ChooseRoundUI.UIData;
                    // UI
                    {
                        chooseRoundUIData.removeCallBackAndDestroy(typeof(ChooseRoundUI));
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
                    case UIData.Property.contest:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.requestNewRoundUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseRoundUIData:
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
                if (wrapProperty.p is Contest)
                {
                    switch ((Contest.Property)wrapProperty.n)
                    {
                        case Contest.Property.state:
                            break;
                        case Contest.Property.playerPerTeam:
                            break;
                        case Contest.Property.teams:
                            break;
                        case Contest.Property.roundFactory:
                            break;
                        case Contest.Property.rounds:
                            dirty = true;
                            haveNewRound = true;
                            break;
                        case Contest.Property.requestNewRound:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is RoundUI.UIData)
                {
                    switch ((RoundUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundUI.UIData.Property.round:
                            dirty = true;
                            break;
                        case RoundUI.UIData.Property.roundGameUIData:
                            break;
                        case RoundUI.UIData.Property.chooseRoundGameUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is RequestNewRoundUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is ChooseRoundUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}