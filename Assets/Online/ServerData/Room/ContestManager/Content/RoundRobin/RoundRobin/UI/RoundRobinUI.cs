using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RoundRobinUI : UIBehavior<RoundRobinUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RoundRobin>> roundRobin;

            public VP<RoundContestUI.UIData> roundContestUIData;

            public VP<ChooseRoundContestUI.UIData> chooseRoundContestUIData;

            #region Constructor

            public enum Property
            {
                roundRobin,
                roundContestUIData,
                chooseRoundContestUIData
            }

            public UIData() : base()
            {
                this.roundRobin = new VP<ReferenceData<RoundRobin>>(this, (byte)Property.roundRobin, new ReferenceData<RoundRobin>(null));
                this.roundContestUIData = new VP<RoundContestUI.UIData>(this, (byte)Property.roundContestUIData, new RoundContestUI.UIData());
                this.chooseRoundContestUIData = new VP<ChooseRoundContestUI.UIData>(this, (byte)Property.chooseRoundContestUIData, null);
            }

            #endregion

            public void reset()
            {
                this.chooseRoundContestUIData.v = null;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // chooseRoundContestUIData
                    if (!isProcess)
                    {
                        ChooseRoundContestUI.UIData chooseRoundContestUIData = this.chooseRoundContestUIData.v;
                        if (chooseRoundContestUIData != null)
                        {
                            isProcess = chooseRoundContestUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chooseRoundContestUIData null: " + this);
                        }
                    }
                    // roundContestUIData
                    if (!isProcess)
                    {
                        RoundContestUI.UIData roundContestUIData = this.roundContestUIData.v;
                        if (roundContestUIData != null)
                        {
                            isProcess = roundContestUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roundContestUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

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
                    RoundRobin roundRobin = this.data.roundRobin.v.data;
                    if (roundRobin != null)
                    {
                        // roundContestUIData
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(roundRobin, out dataIdentity))
                                    {
                                        if (dataIdentity is RoundRobinIdentity)
                                        {
                                            RoundRobinIdentity roundRobinIdentity = dataIdentity as RoundRobinIdentity;
                                            if (roundRobinIdentity.roundContests != roundRobin.roundContests.vs.Count)
                                            {
                                                Debug.LogError("roundRobin roundContest count error");
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
                                RoundContestUI.UIData roundContestUIData = this.data.roundContestUIData.v;
                                if (roundContestUIData != null)
                                {
                                    if (roundContestUIData.roundContest.v.data == null || !roundRobin.roundContests.vs.Contains(roundContestUIData.roundContest.v.data))
                                    {
                                        // find roundContest
                                        if (roundRobin.roundContests.vs.Count > 0)
                                        {
                                            // find
                                            RoundContest chosenRoundContest = roundRobin.roundContests.vs[0];
                                            {
                                                uint profileId = Server.getProfileUserId(roundRobin);
                                                foreach (RoundContest roundContest in roundRobin.roundContests.vs)
                                                {
                                                    // find have you
                                                    bool haveYouInside = false;
                                                    {
                                                        Contest contest = roundContest.contest.v;
                                                        if (contest != null)
                                                        {
                                                            foreach (MatchTeam matchTeam in contest.teams.vs)
                                                            {
                                                                foreach (TeamPlayer teamPlayer in matchTeam.players.vs)
                                                                {
                                                                    if (teamPlayer.inform.v is Human)
                                                                    {
                                                                        Human human = teamPlayer.inform.v as Human;
                                                                        if (human.playerId.v == profileId)
                                                                        {
                                                                            haveYouInside = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("contest null: " + this);
                                                        }
                                                    }
                                                    // process
                                                    if (haveYouInside)
                                                    {
                                                        chosenRoundContest = roundContest;
                                                        break;
                                                    }
                                                }
                                            }
                                            // set
                                            roundContestUIData.roundContest.v = new ReferenceData<RoundContest>(chosenRoundContest);
                                        }
                                        else
                                        {
                                            Debug.LogError("why don't have any roundContest: " + this);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("roundContestUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        // chooseRoundContestUIData
                        {
                            ChooseRoundContestUI.UIData chooseRoundContestUIData = this.data.chooseRoundContestUIData.v;
                            if (chooseRoundContestUIData != null)
                            {
                                chooseRoundContestUIData.roundRobin.v = new ReferenceData<RoundRobin>(roundRobin);
                            }
                            else
                            {
                                // Debug.LogError ("chooseRoundContestUIData null: " + this);
                            }
                        }
                        // siblingIndex
                        {
                            UIRectTransform.SetSiblingIndex(this.data.roundContestUIData.v, 0);
                            UIRectTransform.SetSiblingIndex(this.data.chooseRoundContestUIData.v, 1);
                        }
                    }
                    else
                    {
                        Debug.LogError("roundRobin null: " + this);
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

        public RoundContestUI roundContestPrefab;

        public ChooseRoundContestUI chooseRoundContestPrefab;

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
                    uiData.roundRobin.allAddCallBack(this);
                    uiData.roundContestUIData.allAddCallBack(this);
                    uiData.chooseRoundContestUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Add BtnRoundRobinUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            BtnRoundRobinUI.UIData btnRoundRobinUIData = new BtnRoundRobinUI.UIData();
                            {
                                btnRoundRobinUIData.uid = roomBtnUIData.subs.makeId();
                                btnRoundRobinUIData.roundRobinUIData.v = new ReferenceData<UIData>(this.data);
                            }
                            roomBtnUIData.subs.add(btnRoundRobinUIData);
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
                if (data is RoundRobin)
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
                if (data is RoundContestUI.UIData)
                {
                    RoundContestUI.UIData roundContestUIData = data as RoundContestUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(roundContestUIData, roundContestPrefab, this.transform, UIConstants.FullParent);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChooseRoundContestUI.UIData)
                {
                    ChooseRoundContestUI.UIData chooseRoundContestUIData = data as ChooseRoundContestUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundContestUIData, chooseRoundContestPrefab, this.transform);
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
                    uiData.roundRobin.allRemoveCallBack(this);
                    uiData.roundContestUIData.allRemoveCallBack(this);
                    uiData.chooseRoundContestUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Remove BtnRoundRobinUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs)
                            {
                                if (sub is BtnRoundRobinUI.UIData)
                                {
                                    BtnRoundRobinUI.UIData btnRoundRobinUIData = sub as BtnRoundRobinUI.UIData;
                                    if (btnRoundRobinUIData.roundRobinUIData.v.data == this.data)
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
                if (data is RoundRobin)
                {
                    return;
                }
                if (data is RoundContestUI.UIData)
                {
                    RoundContestUI.UIData roundContestUIData = data as RoundContestUI.UIData;
                    // UI
                    {
                        roundContestUIData.removeCallBackAndDestroy(typeof(RoundContestUI));
                    }
                    return;
                }
                if (data is ChooseRoundContestUI.UIData)
                {
                    ChooseRoundContestUI.UIData chooseRoundContestUIData = data as ChooseRoundContestUI.UIData;
                    // UI
                    {
                        chooseRoundContestUIData.removeCallBackAndDestroy(typeof(ChooseRoundContestUI));
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
                    case UIData.Property.roundRobin:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundContestUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseRoundContestUIData:
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
                if (wrapProperty.p is RoundRobin)
                {
                    switch ((RoundRobin.Property)wrapProperty.n)
                    {
                        case RoundRobin.Property.state:
                            break;
                        case RoundRobin.Property.index:
                            break;
                        case RoundRobin.Property.roundContests:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is RoundContestUI.UIData)
                {
                    switch ((RoundContestUI.UIData.Property)wrapProperty.n)
                    {
                        case RoundContestUI.UIData.Property.roundContest:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ChooseRoundContestUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}