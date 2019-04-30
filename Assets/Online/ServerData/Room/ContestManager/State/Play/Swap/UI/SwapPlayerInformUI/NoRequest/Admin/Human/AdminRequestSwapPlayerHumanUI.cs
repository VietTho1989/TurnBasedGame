using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameManager.Match.Swap
{
    public class AdminRequestSwapPlayerHumanUI : UIBehavior<AdminRequestSwapPlayerHumanUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<TeamPlayer>> teamPlayer;

            #region State

            public abstract class State : Data
            {

                public enum Type
                {
                    None,
                    Request,
                    Wait
                }

                public abstract Type getType();

            }

            public class StateNone : State
            {

                #region Constructor

                public enum Property
                {

                }

                public StateNone() : base()
                {

                }

                #endregion

                public override Type getType()
                {
                    return Type.None;
                }

            }

            public class StateRequest : State
            {

                public VP<uint> humanId;

                #region Constructor

                public enum Property
                {
                    humanId
                }

                public StateRequest() : base()
                {
                    this.humanId = new VP<uint>(this, (byte)Property.humanId, 0);
                }

                #endregion

                public override Type getType()
                {
                    return Type.Request;
                }

            }

            public class StateWait : State
            {

                #region Constructor

                public enum Property
                {

                }

                public StateWait() : base()
                {

                }

                #endregion

                public override Type getType()
                {
                    return Type.Wait;
                }

            }

            public VP<State> state;

            #endregion

            public VP<AdminRequestSwapPlayerChooseHumanAdapter.UIData> humanAdapter;

            #region Constructor

            public enum Property
            {
                teamPlayer,
                state,
                humanAdapter
            }

            public UIData() : base()
            {
                this.teamPlayer = new VP<ReferenceData<TeamPlayer>>(this, (byte)Property.teamPlayer, new ReferenceData<TeamPlayer>(null));
                this.state = new VP<State>(this, (byte)Property.state, new StateNone());
                this.humanAdapter = new VP<AdminRequestSwapPlayerChooseHumanAdapter.UIData>(this, (byte)Property.humanAdapter, new AdminRequestSwapPlayerChooseHumanAdapter.UIData());
            }

            #endregion

            public void reset()
            {
                if (!(this.state.v is StateNone))
                {
                    StateNone stateNone = new StateNone();
                    {
                        stateNone.uid = this.state.makeId();
                    }
                    this.state.v = stateNone;
                }
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Human");

        public Text tvRequesting;
        private static readonly TxtLanguage txtRequesting = new TxtLanguage("Requesting...");

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        static AdminRequestSwapPlayerHumanUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn Người");
            txtRequesting.add(Language.Type.vi, "Đang yêu cầu...");
            txtCancel.add(Language.Type.vi, "Huỷ");
        }

        #endregion

        #region Refresh

        public GameObject requestingContainer;
        public Button btnCancel;

        private bool needReset = false;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // reset
                    {
                        if (needReset)
                        {
                            needReset = false;
                            this.data.reset();
                        }
                    }
                    TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
                    if (teamPlayer != null)
                    {
                        // humanAdapter
                        {
                            AdminRequestSwapPlayerChooseHumanAdapter.UIData humanAdapter = this.data.humanAdapter.v;
                            if (humanAdapter != null)
                            {
                                humanAdapter.teamPlayer.v = new ReferenceData<TeamPlayer>(teamPlayer);
                            }
                            else
                            {
                                Debug.LogError("humanAdapter null: " + this);
                            }
                        }
                        // state
                        {
                            UIData.State state = this.data.state.v;
                            if (state != null)
                            {
                                // Task
                                {
                                    switch (state.getType())
                                    {
                                        case UIData.State.Type.None:
                                            {
                                                destroyRoutine(wait);
                                            }
                                            break;
                                        case UIData.State.Type.Request:
                                            {
                                                destroyRoutine(wait);
                                                UIData.StateRequest stateRequest = state as UIData.StateRequest;
                                                if (Server.IsServerOnline(teamPlayer))
                                                {
                                                    // Request
                                                    {
                                                        // find swap
                                                        Swap swap = null;
                                                        {
                                                            ContestManagerStatePlay contestManagerStatePlay = teamPlayer.findDataInParent<ContestManagerStatePlay>();
                                                            if (contestManagerStatePlay != null)
                                                            {
                                                                swap = contestManagerStatePlay.swap.v;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("contestManagerStatePlay null: " + this);
                                                            }
                                                        }
                                                        // process
                                                        if (swap != null)
                                                        {
                                                            int playerIndex = teamPlayer.playerIndex.v;
                                                            // get teamIndex
                                                            int teamIndex = 0;
                                                            {
                                                                MatchTeam matchTeam = teamPlayer.findDataInParent<MatchTeam>();
                                                                if (matchTeam != null)
                                                                {
                                                                    teamIndex = matchTeam.teamIndex.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("matchTeam null: " + this);
                                                                }
                                                            }
                                                            swap.requestChangeHuman(Server.getProfileUserId(teamPlayer), teamIndex, playerIndex, stateRequest.humanId.v);
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("swap null: " + this);
                                                        }
                                                    }
                                                    // change to wait
                                                    {
                                                        UIData.StateWait stateWait = new UIData.StateWait();
                                                        {
                                                            stateWait.uid = this.data.state.makeId();
                                                        }
                                                        this.data.state.v = stateWait;
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("server not online");
                                                }
                                            }
                                            break;
                                        case UIData.State.Type.Wait:
                                            {
                                                if (Server.IsServerOnline(teamPlayer))
                                                {
                                                    startRoutine(ref this.wait, TaskWait());
                                                }
                                                else
                                                {
                                                    // Chuyen sang state none
                                                    UIData.StateNone stateNone = new UIData.StateNone();
                                                    {
                                                        stateNone.uid = this.data.state.makeId();
                                                    }
                                                    this.data.state.v = stateNone;
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                            break;
                                    }
                                }
                                // UI
                                {
                                    if (requestingContainer != null && btnCancel != null)
                                    {
                                        switch (state.getType())
                                        {
                                            case UIData.State.Type.None:
                                                {
                                                    requestingContainer.SetActive(false);
                                                    btnCancel.gameObject.SetActive(false);
                                                }
                                                break;
                                            case UIData.State.Type.Request:
                                                {
                                                    requestingContainer.SetActive(true);
                                                    btnCancel.gameObject.SetActive(true);
                                                }
                                                break;
                                            case UIData.State.Type.Wait:
                                                {
                                                    requestingContainer.SetActive(true);
                                                    btnCancel.gameObject.SetActive(false);
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("requestingContainer, btnCancel null: " + this);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("state null: " + this);
                            }
                        }
                        // siblingIndex
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.transform.SetSiblingIndex(0);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            UIRectTransform.SetSiblingIndex(this.data.humanAdapter.v, 1);
                            if (requestingContainer != null)
                            {
                                requestingContainer.transform.SetSiblingIndex(2);
                            }
                            else
                            {
                                Debug.LogError("requestingContainer null");
                            }
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            if (tvRequesting != null)
                            {
                                tvRequesting.text = txtRequesting.get();
                            }
                            else
                            {
                                Debug.LogError("tvRequesting null");
                            }
                            if (tvCancel != null)
                            {
                                tvCancel.text = txtCancel.get();
                            }
                            else
                            {
                                Debug.LogError("tvCancel null");
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError("lobbyPlayer null: " + this);
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
            return false;
        }

        #endregion

        #region Task wait

        private Routine wait;

        public IEnumerator TaskWait()
        {
            if (this.data != null)
            {
                yield return new Wait(Global.WaitSendTime);
                // Chuyen sang state none
                {
                    if (this.data != null)
                    {
                        if (!(this.data.state.v is UIData.StateNone))
                        {
                            UIData.StateNone stateNone = new UIData.StateNone();
                            {
                                stateNone.uid = this.data.state.makeId();
                            }
                            this.data.state.v = stateNone;
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                Toast.showMessage("request error");
                Debug.LogError("request error: " + this);
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(wait);
            }
            return ret;
        }

        #endregion

        #region implement callBacks

        public AdminRequestSwapPlayerChooseHumanAdapter humanAdapterPrefab;
        private static readonly UIRectTransform humanAdapterRect = UIRectTransform.CreateFullRect(0, 0, 30, 0);

        private Server server = null;

        private ContestManagerStatePlay contestManagerStatePlay = null;
        private ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.teamPlayer.allAddCallBack(this);
                    uiData.humanAdapter.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                // teamPlayer
                {
                    if (data is TeamPlayer)
                    {
                        TeamPlayer teamPlayer = data as TeamPlayer;
                        // reset
                        {
                            needReset = true;
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(teamPlayer, this, ref this.server);
                            DataUtils.addParentCallBack(teamPlayer, this, ref this.contestManagerStatePlay);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is Server)
                        {
                            dirty = true;
                            return;
                        }
                        // contestMaangerStatePlay
                        {
                            if (data is ContestManagerStatePlay)
                            {
                                ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                                // CheckChange
                                {
                                    contestManagerStatePlayTeamCheckChange.addCallBack(this);
                                    contestManagerStatePlayTeamCheckChange.setData(contestManagerStatePlay);
                                }
                                dirty = true;
                                return;
                            }
                            // CheckChange
                            if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
                }
                if (data is AdminRequestSwapPlayerChooseHumanAdapter.UIData)
                {
                    AdminRequestSwapPlayerChooseHumanAdapter.UIData humanAdapter = data as AdminRequestSwapPlayerChooseHumanAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(humanAdapter, humanAdapterPrefab, this.transform, humanAdapterRect);
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
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.teamPlayer.allRemoveCallBack(this);
                    uiData.humanAdapter.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // teamPlayer
                {
                    if (data is TeamPlayer)
                    {
                        TeamPlayer teamPlayer = data as TeamPlayer;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(teamPlayer, this, ref this.server);
                            DataUtils.removeParentCallBack(teamPlayer, this, ref this.contestManagerStatePlay);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is Server)
                        {
                            return;
                        }
                        // contestManagerStatePlay
                        {
                            if (data is ContestManagerStatePlay)
                            {
                                // ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                                // CheckChange
                                {
                                    contestManagerStatePlayTeamCheckChange.removeCallBack(this);
                                    contestManagerStatePlayTeamCheckChange.setData(null);
                                }
                                return;
                            }
                            // CheckChange
                            if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                            {
                                return;
                            }
                        }
                    }
                }
                if (data is AdminRequestSwapPlayerChooseHumanAdapter.UIData)
                {
                    AdminRequestSwapPlayerChooseHumanAdapter.UIData humanAdapter = data as AdminRequestSwapPlayerChooseHumanAdapter.UIData;
                    // UI
                    {
                        humanAdapter.removeCallBackAndDestroy(typeof(AdminRequestSwapPlayerChooseHumanAdapter));
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
                    case UIData.Property.teamPlayer:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.state:
                        dirty = true;
                        break;
                    case UIData.Property.humanAdapter:
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
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                // teamPlayer
                {
                    if (wrapProperty.p is TeamPlayer)
                    {
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                        // contestManagerStatePlay
                        {
                            if (wrapProperty.p is ContestManagerStatePlay)
                            {
                                return;
                            }
                            // CheckChange
                            if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                            {
                                dirty = true;
                                needReset = true;
                                return;
                            }
                        }
                    }
                }
                if (wrapProperty.p is AdminRequestSwapPlayerChooseHumanAdapter.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnCancel()
        {
            if (this.data != null)
            {
                if (this.data.state.v is UIData.StateRequest)
                {
                    UIData.StateNone stateNone = new UIData.StateNone();
                    {
                        stateNone.uid = this.data.state.makeId();
                    }
                    this.data.state.v = stateNone;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}