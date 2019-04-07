using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match
{
    public class LobbyBtnStart : UIBehavior<LobbyBtnStart.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region State

            public enum State
            {
                None,
                Request,
                Wait
            }

            public VP<State> state;

            #endregion

            #region Constructor

            public enum Property
            {
                state
            }

            public UIData() : base()
            {
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

            public void reset()
            {
                this.state.v = State.None;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtStart = new TxtLanguage("Start");
        private static readonly TxtLanguage txtCancelStart = new TxtLanguage("Cancel Start?");
        private static readonly TxtLanguage txtStarting = new TxtLanguage("Starting");
        private static readonly TxtLanguage txtNotAllReady = new TxtLanguage("Not All Ready");

        private static readonly TxtLanguage txtStartingTime = new TxtLanguage("Starting");

        static LobbyBtnStart()
        {
            txtStart.add(Language.Type.vi, "Bắt Đầu");
            txtCancelStart.add(Language.Type.vi, "Huỷ bắt đầu?");
            txtStarting.add(Language.Type.vi, "Đang bắt đầu");
            txtNotAllReady.add(Language.Type.vi, "Chưa sẵn sàng");
            txtStartingTime.add(Language.Type.vi, "Đang bắt đầu");
        }

        #endregion

        #region Refresh

        public Button btnStart;
        public Text tvStart;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStateLobbyUI.UIData lobbyUIData = this.data.findDataInParent<ContestManagerStateLobbyUI.UIData>();
                    if (lobbyUIData != null)
                    {
                        ContestManagerStateLobby lobby = lobbyUIData.contestManagerStateLobby.v.data;
                        if (lobby != null)
                        {
                            // find is you admin
                            bool isAdmin = false;
                            {
                                if (Room.isYouAdmin(lobby))
                                {
                                    isAdmin = true;
                                }
                            }
                            // Process
                            {
                                // set content
                                ContestManagerStateLobby.State state = lobby.state.v;
                                if (state != null)
                                {
                                    switch (state.getType())
                                    {
                                        case ContestManagerStateLobby.State.Type.Normal:
                                            {
                                                Lobby.StateNormal stateNormal = state as Lobby.StateNormal;
                                                if (lobby.IsCanStart())
                                                {
                                                    // Task
                                                    {
                                                        if (isAdmin)
                                                        {
                                                            switch (this.data.state.v)
                                                            {
                                                                case UIData.State.None:
                                                                    {
                                                                        destroyRoutine(waitSendCoroutine);
                                                                    }
                                                                    break;
                                                                case UIData.State.Request:
                                                                    {
                                                                        destroyRoutine(waitSendCoroutine);
                                                                        // request
                                                                        if (Server.IsServerOnline(lobby))
                                                                        {
                                                                            stateNormal.requestStart(Server.getProfileUserId(stateNormal));
                                                                            this.data.state.v = UIData.State.Wait;
                                                                        }
                                                                        else
                                                                        {
                                                                            Debug.LogError("server not online: " + this);
                                                                        }
                                                                    }
                                                                    break;
                                                                case UIData.State.Wait:
                                                                    {
                                                                        if (Server.IsServerOnline(lobby))
                                                                        {
                                                                            startRoutine(ref this.waitSendCoroutine, TaskWaitSend());
                                                                        }
                                                                        else
                                                                        {
                                                                            this.data.state.v = UIData.State.None;
                                                                        }
                                                                    }
                                                                    break;
                                                                default:
                                                                    Debug.LogError("unknown type: " + this.data.state.v + "; " + this);
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.data.state.v = UIData.State.None;
                                                            destroyRoutine(waitSendCoroutine);
                                                        }
                                                    }
                                                    // UI
                                                    {
                                                        if (btnStart != null && tvStart != null)
                                                        {
                                                            switch (this.data.state.v)
                                                            {
                                                                case UIData.State.None:
                                                                    {
                                                                        btnStart.interactable = isAdmin;
                                                                        tvStart.text = txtStart.get();
                                                                    }
                                                                    break;
                                                                case UIData.State.Request:
                                                                    {
                                                                        btnStart.interactable = isAdmin;
                                                                        tvStart.text = txtCancelStart.get();
                                                                    }
                                                                    break;
                                                                case UIData.State.Wait:
                                                                    {
                                                                        btnStart.interactable = false;
                                                                        tvStart.text = txtStarting.get();
                                                                    }
                                                                    break;
                                                                default:
                                                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                                                    break;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("btnStart, tvStart null: " + this);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    // Task
                                                    {
                                                        this.data.state.v = UIData.State.None;
                                                        destroyRoutine(waitSendCoroutine);
                                                    }
                                                    // UI
                                                    {
                                                        if (btnStart != null && tvStart != null)
                                                        {
                                                            btnStart.interactable = false;
                                                            tvStart.text = txtNotAllReady.get();
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("btnStart, tvStart null: " + this);
                                                        }
                                                    }
                                                }
                                            }
                                            break;
                                        case ContestManagerStateLobby.State.Type.Start:
                                            {
                                                Lobby.StateStart stateStart = state as Lobby.StateStart;
                                                // Task
                                                {
                                                    this.data.state.v = UIData.State.None;
                                                    destroyRoutine(waitSendCoroutine);
                                                }
                                                // UI
                                                {
                                                    if (btnStart != null && tvStart != null)
                                                    {
                                                        btnStart.interactable = false;
                                                        tvStart.text = txtStartingTime.get() + " " + stateStart.time.v + "/" + stateStart.duration.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("btnStart null, tvStart null: " + this);
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("state null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("lobby null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("lobbyUIData null: " + this);
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

        #region Task

        private Routine waitSendCoroutine;

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(waitSendCoroutine);
            }
            return ret;
        }

        public IEnumerator TaskWaitSend()
        {
            yield return new Wait(Global.WaitSendTime);
            if (this.data != null)
            {
                this.data.state.v = UIData.State.None;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        #endregion

        #region implement callBacks

        private RoomCheckChangeAdminChange<ContestManagerStateLobby> roomCheckAdminChange = new RoomCheckChangeAdminChange<ContestManagerStateLobby>();
        private ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = null;
        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.contestManagerStateLobbyUIData);
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
            // Parent
            {
                if (data is ContestManagerStateLobbyUI.UIData)
                {
                    ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = data as ContestManagerStateLobbyUI.UIData;
                    // Child
                    {
                        contestManagerStateLobbyUIData.contestManagerStateLobby.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ContestManagerStateLobby)
                    {
                        ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                        // Reset
                        {
                            if (this.data != null)
                            {
                                this.data.state.v = UIData.State.None;
                            }
                            else
                            {
                                Debug.LogError("data null: " + this);
                            }
                        }
                        // CheckChange
                        {
                            roomCheckAdminChange.addCallBack(this);
                            roomCheckAdminChange.setData(contestManagerStateLobby);
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(contestManagerStateLobby, this, ref this.server);
                        }
                        // Child
                        {
                            contestManagerStateLobby.state.allAddCallBack(this);
                            contestManagerStateLobby.teams.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
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
                    // Child
                    {
                        if (data is ContestManagerStateLobby.State)
                        {
                            dirty = true;
                            return;
                        }
                        // LobbyTeams
                        {
                            if (data is LobbyTeam)
                            {
                                LobbyTeam lobbyTeam = data as LobbyTeam;
                                // Child
                                {
                                    lobbyTeam.players.allAddCallBack(this);
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            {
                                if (data is LobbyPlayer)
                                {
                                    LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                                    // Child
                                    {
                                        lobbyPlayer.inform.allAddCallBack(this);
                                    }
                                    dirty = true;
                                    return;
                                }
                                // Child
                                if (data is GamePlayer.Inform)
                                {
                                    dirty = true;
                                    return;
                                }
                            }
                        }
                    }
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.contestManagerStateLobbyUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is ContestManagerStateLobbyUI.UIData)
                {
                    ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = data as ContestManagerStateLobbyUI.UIData;
                    // Child
                    {
                        contestManagerStateLobbyUIData.contestManagerStateLobby.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ContestManagerStateLobby)
                    {
                        ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                        // CheckChange
                        {
                            roomCheckAdminChange.removeCallBack(this);
                            roomCheckAdminChange.setData(null);
                        }
                        // Parent
                        {
                            DataUtils.removeParentCallBack(contestManagerStateLobby, this, ref this.server);
                        }
                        // Child
                        {
                            contestManagerStateLobby.state.allRemoveCallBack(this);
                            contestManagerStateLobby.teams.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    {
                        if (data is ContestManagerStateLobby.State)
                        {
                            return;
                        }
                        // LobbyTeams
                        {
                            if (data is LobbyTeam)
                            {
                                LobbyTeam lobbyTeam = data as LobbyTeam;
                                // Child
                                {
                                    lobbyTeam.players.allRemoveCallBack(this);
                                }
                                return;
                            }
                            // Child
                            {
                                if (data is LobbyPlayer)
                                {
                                    LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                                    // Child
                                    {
                                        lobbyPlayer.inform.allRemoveCallBack(this);
                                    }
                                    return;
                                }
                                // Child
                                if (data is GamePlayer.Inform)
                                {
                                    return;
                                }
                            }
                        }
                    }
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
                    case UIData.Property.state:
                        dirty = true;
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
            // Parent
            {
                if (wrapProperty.p is ContestManagerStateLobbyUI.UIData)
                {
                    switch ((ContestManagerStateLobbyUI.UIData.Property)wrapProperty.n)
                    {
                        case ContestManagerStateLobbyUI.UIData.Property.contestManagerStateLobby:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ContestManagerStateLobbyUI.UIData.Property.roomUserAdapter:
                            break;
                        case ContestManagerStateLobbyUI.UIData.Property.chatRoomUIData:
                            break;
                        case ContestManagerStateLobbyUI.UIData.Property.contentFactory:
                            break;
                        case ContestManagerStateLobbyUI.UIData.Property.btnStart:
                            break;
                        case ContestManagerStateLobbyUI.UIData.Property.teamAdapter:
                            break;
                        case ContestManagerStateLobbyUI.UIData.Property.editLobbyPlayer:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is ContestManagerStateLobby)
                    {
                        switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                        {
                            case ContestManagerStateLobby.Property.state:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case ContestManagerStateLobby.Property.teams:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case ContestManagerStateLobby.Property.gameType:
                                break;
                            case ContestManagerStateLobby.Property.randomTeamIndex:
                                break;
                            case ContestManagerStateLobby.Property.contentFactory:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
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
                    // Child
                    {
                        if (wrapProperty.p is ContestManagerStateLobby.State)
                        {
                            ContestManagerStateLobby.State state = wrapProperty.p as ContestManagerStateLobby.State;
                            switch (state.getType())
                            {
                                case ContestManagerStateLobby.State.Type.Normal:
                                    {
                                        switch ((Lobby.StateNormal.Property)wrapProperty.n)
                                        {
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                case ContestManagerStateLobby.State.Type.Start:
                                    {
                                        switch ((Lobby.StateStart.Property)wrapProperty.n)
                                        {
                                            case GameManager.Match.Lobby.StateStart.Property.time:
                                                dirty = true;
                                                break;
                                            case GameManager.Match.Lobby.StateStart.Property.duration:
                                                dirty = true;
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // LobbyTeams
                        {
                            if (wrapProperty.p is LobbyTeam)
                            {
                                switch ((LobbyTeam.Property)wrapProperty.n)
                                {
                                    case LobbyTeam.Property.teamIndex:
                                        break;
                                    case LobbyTeam.Property.players:
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
                                if (wrapProperty.p is LobbyPlayer)
                                {
                                    switch ((LobbyPlayer.Property)wrapProperty.n)
                                    {
                                        case LobbyPlayer.Property.playerIndex:
                                            break;
                                        case LobbyPlayer.Property.inform:
                                            {
                                                ValueChangeUtils.replaceCallBack(this, syncs);
                                                dirty = true;
                                            }
                                            break;
                                        case LobbyPlayer.Property.isReady:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                    return;
                                }
                                // Child
                                if (wrapProperty.p is GamePlayer.Inform)
                                {
                                    if (wrapProperty.p is Human)
                                    {
                                        switch ((Human.Property)wrapProperty.n)
                                        {
                                            case Human.Property.playerId:
                                                dirty = true;
                                                break;
                                            case Human.Property.account:
                                                break;
                                            case Human.Property.state:
                                                break;
                                            case Human.Property.email:
                                                break;
                                            case Human.Property.phoneNumber:
                                                break;
                                            case Human.Property.status:
                                                break;
                                            case Human.Property.birthday:
                                                break;
                                            case Human.Property.sex:
                                                break;
                                            case Human.Property.connection:
                                                break;
                                            case Human.Property.ban:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnStart()
        {
            if (this.data != null)
            {
                switch (this.data.state.v)
                {
                    case UIData.State.None:
                        this.data.state.v = UIData.State.Request;
                        break;
                    case UIData.State.Request:
                        this.data.state.v = UIData.State.None;
                        break;
                    case UIData.State.Wait:
                        Debug.LogError("you are requesting: " + this);
                        break;
                    default:
                        Debug.LogError("unknowns state: " + this.data.state.v + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}