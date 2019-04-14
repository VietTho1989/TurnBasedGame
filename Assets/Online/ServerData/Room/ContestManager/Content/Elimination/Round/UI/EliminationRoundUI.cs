using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class EliminationRoundUI : UIBehavior<EliminationRoundUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<EliminationRound>> eliminationRound;

            public VP<BracketUI.UIData> bracketUIData;

            public VP<ChooseBracketUI.UIData> chooseBracketUIData;

            #region Constructor

            public enum Property
            {
                eliminationRound,
                bracketUIData,
                chooseBracketUIData
            }

            public UIData() : base()
            {
                this.eliminationRound = new VP<ReferenceData<EliminationRound>>(this, (byte)Property.eliminationRound, new ReferenceData<EliminationRound>(null));
                this.bracketUIData = new VP<BracketUI.UIData>(this, (byte)Property.bracketUIData, new BracketUI.UIData());
                this.chooseBracketUIData = new VP<ChooseBracketUI.UIData>(this, (byte)Property.chooseBracketUIData, null);
            }

            #endregion

            public void reset()
            {
                this.chooseBracketUIData.v = null;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // chooseBracketUIData
                    if (!isProcess)
                    {
                        ChooseBracketUI.UIData chooseBracketUIData = this.chooseBracketUIData.v;
                        if (chooseBracketUIData != null)
                        {
                            chooseBracketUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("chooseBracketUIData null: " + this);
                        }
                    }
                    // bracketUIData
                    if (!isProcess)
                    {
                        BracketUI.UIData bracketUIData = this.bracketUIData.v;
                        if (bracketUIData != null)
                        {
                            isProcess = bracketUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("bracketUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt, rect

        static EliminationRoundUI()
        {

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
                    EliminationRound eliminationRound = this.data.eliminationRound.v.data;
                    if (eliminationRound != null)
                    {
                        // bracketUIData
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(eliminationRound, out dataIdentity))
                                    {
                                        if (dataIdentity is EliminationRoundIdentity)
                                        {
                                            EliminationRoundIdentity eliminationRoundIdentity = dataIdentity as EliminationRoundIdentity;
                                            if (eliminationRoundIdentity.brackets != eliminationRound.brackets.vs.Count)
                                            {
                                                Debug.LogError("eliminationRound bracket count error");
                                                isLoadFull = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not eliminationRoundIdentity");
                                        }
                                    }
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                BracketUI.UIData bracketUIData = this.data.bracketUIData.v;
                                if (bracketUIData != null)
                                {
                                    // find
                                    bool alreadySet = false;
                                    {
                                        Bracket bracket = bracketUIData.bracket.v.data;
                                        if (bracket != null)
                                        {
                                            if (bracket.isActive.v)
                                            {
                                                if (eliminationRound.brackets.vs.Contains(bracket))
                                                {
                                                    alreadySet = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("bracket null: " + this);
                                        }
                                    }
                                    // set
                                    if (!alreadySet)
                                    {
                                        // get active list
                                        List<Bracket> brackets = new List<Bracket>();
                                        {
                                            foreach (Bracket bracket in eliminationRound.brackets.vs)
                                            {
                                                if (bracket.isActive.v)
                                                {
                                                    brackets.Add(bracket);
                                                }
                                            }
                                        }
                                        // Process
                                        if (brackets.Count > 0)
                                        {
                                            // find
                                            Bracket chosenBracket = brackets[0];
                                            // get default chosen
                                            {
                                                foreach (Bracket bracket in brackets)
                                                {
                                                    if (bracket.isActive.v)
                                                    {
                                                        if (bracket.bracketContests.vs.Count > 0)
                                                        {
                                                            chosenBracket = bracket;
                                                        }
                                                    }
                                                }
                                            }
                                            // get the bracket you are in
                                            {
                                                uint profileId = Server.getProfileUserId(eliminationRound);
                                                foreach (Bracket bracket in brackets)
                                                {
                                                    // find have you
                                                    bool haveYouInside = false;
                                                    {
                                                        foreach (BracketContest bracketContest in bracket.bracketContests.vs)
                                                        {
                                                            if (bracketContest.isActive.v)
                                                            {
                                                                Contest contest = bracketContest.contest.v;
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
                                                            else
                                                            {
                                                                Debug.LogError("bracketContest not active: " + this);
                                                            }
                                                        }
                                                    }
                                                    // process
                                                    if (haveYouInside)
                                                    {
                                                        chosenBracket = bracket;
                                                        break;
                                                    }
                                                }
                                            }
                                            // set
                                            bracketUIData.bracket.v = new ReferenceData<Bracket>(chosenBracket);
                                        }
                                        else
                                        {
                                            Debug.LogError("why don't have bracketContests: " + this);
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("bracketContestUIData null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        // chooseBracketUIData
                        {
                            ChooseBracketUI.UIData chooseBracketUIData = this.data.chooseBracketUIData.v;
                            if (chooseBracketUIData != null)
                            {
                                chooseBracketUIData.eliminationRound.v = new ReferenceData<EliminationRound>(eliminationRound);
                            }
                            else
                            {
                                // Debug.LogError ("chooseBracketUIData null: " + this);
                            }
                        }
                        // siblingIndex
                        {
                            UIRectTransform.SetSiblingIndex(this.data.bracketUIData.v, 0);
                            UIRectTransform.SetSiblingIndex(this.data.chooseBracketUIData.v, 1);
                        }
                    }
                    else
                    {
                        Debug.LogError("bracket null: " + this);
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

        public BracketUI bracketPrefab;
        private static readonly UIRectTransform bracketRect = UIConstants.FullParent;

        public ChooseBracketUI chooseBracketPrefab;

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
                    uiData.eliminationRound.allAddCallBack(this);
                    uiData.bracketUIData.allAddCallBack(this);
                    uiData.chooseBracketUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Add BtnEliminationRoundUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            BtnEliminationRoundUI.UIData btnEliminationRoundUIData = new BtnEliminationRoundUI.UIData();
                            {
                                btnEliminationRoundUIData.uid = roomBtnUIData.subs.makeId();
                                btnEliminationRoundUIData.eliminationRoundUIData.v = new ReferenceData<UIData>(this.data);
                            }
                            roomBtnUIData.subs.add(btnEliminationRoundUIData);
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
                // eliminationRound
                {
                    if (data is EliminationRound)
                    {
                        EliminationRound eliminationRound = data as EliminationRound;
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
                            eliminationRound.brackets.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Bracket)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is BracketUI.UIData)
                {
                    BracketUI.UIData bracketUIData = data as BracketUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(bracketUIData, bracketPrefab, this.transform, bracketRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is ChooseBracketUI.UIData)
                {
                    ChooseBracketUI.UIData chooseBracketUIData = data as ChooseBracketUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseBracketUIData, chooseBracketPrefab, this.transform);
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
                    uiData.eliminationRound.allRemoveCallBack(this);
                    uiData.bracketUIData.allRemoveCallBack(this);
                    uiData.chooseBracketUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is RoomUI.UIData)
                {
                    RoomUI.UIData roomUIData = data as RoomUI.UIData;
                    // Remove BtnEliminationRoundUI
                    {
                        RoomBtnUI.UIData roomBtnUIData = roomUIData.roomBtnUIData.v;
                        if (roomBtnUIData != null)
                        {
                            foreach (RoomBtnUI.UIData.Sub sub in roomBtnUIData.subs.vs)
                            {
                                if (sub is BtnEliminationRoundUI.UIData)
                                {
                                    BtnEliminationRoundUI.UIData btnEliminationRoundUIData = sub as BtnEliminationRoundUI.UIData;
                                    if (btnEliminationRoundUIData.eliminationRoundUIData.v.data == this.data)
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
                // eliminationRound
                {
                    if (data is EliminationRound)
                    {
                        EliminationRound eliminationRound = data as EliminationRound;
                        // Child
                        {
                            eliminationRound.brackets.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Bracket)
                    {
                        return;
                    }
                }
                if (data is BracketUI.UIData)
                {
                    BracketUI.UIData bracketUIData = data as BracketUI.UIData;
                    // UI
                    {
                        bracketUIData.removeCallBackAndDestroy(typeof(BracketUI));
                    }
                    return;
                }
                if (data is ChooseBracketUI.UIData)
                {
                    ChooseBracketUI.UIData chooseBracketUIData = data as ChooseBracketUI.UIData;
                    // UI
                    {
                        chooseBracketUIData.removeCallBackAndDestroy(typeof(ChooseBracketUI));
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
                    case UIData.Property.eliminationRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.bracketUIData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseBracketUIData:
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
                // eliminationRound
                {
                    if (wrapProperty.p is EliminationRound)
                    {
                        switch ((EliminationRound.Property)wrapProperty.n)
                        {
                            case EliminationRound.Property.isActive:
                                break;
                            case EliminationRound.Property.state:
                                break;
                            case EliminationRound.Property.index:
                                break;
                            case EliminationRound.Property.brackets:
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
                    if (wrapProperty.p is Bracket)
                    {
                        switch ((Bracket.Property)wrapProperty.n)
                        {
                            case Bracket.Property.isActive:
                                dirty = true;
                                break;
                            case Bracket.Property.state:
                                break;
                            case Bracket.Property.index:
                                break;
                            case Bracket.Property.bracketContests:
                                break;
                            case Bracket.Property.byeTeamIndexs:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is BracketUI.UIData)
                {
                    switch ((BracketUI.UIData.Property)wrapProperty.n)
                    {
                        case BracketUI.UIData.Property.bracket:
                            dirty = true;
                            break;
                        case BracketUI.UIData.Property.bracketContestUIData:
                            break;
                        case BracketUI.UIData.Property.chooseBracketContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ChooseBracketUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}