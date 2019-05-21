using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameManager.Match
{
    public class NormalEditLobbyPlayerBtnSetUI : UIBehavior<NormalEditLobbyPlayerBtnSetUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

            #region State

            public enum State
            {
                None,
                Request,
                Wait
            }

            public VP<State> state;

            #endregion

            public VP<bool> canSet;

            #region Constructor

            public enum Property
            {
                lobbyPlayer,
                state,
                canSet
            }

            public UIData() : base()
            {
                this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
                this.state = new VP<State>(this, (byte)Property.state, State.None);
                this.canSet = new VP<bool>(this, (byte)Property.canSet, true);
            }

            #endregion

            public void reset()
            {
                this.state.v = State.None;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            NormalEditLobbyPlayerBtnSetUI normalEditLobbyPlayerBtnSetUI = this.findCallBack<NormalEditLobbyPlayerBtnSetUI>();
                            if (normalEditLobbyPlayerBtnSetUI != null)
                            {
                                isProcess = normalEditLobbyPlayerBtnSetUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("normalEditLobbyPlayerBtnSetUI null: " + this);
                            }
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

        #region txt

        private static readonly TxtLanguage txtSet = new TxtLanguage("Set");
        private static readonly TxtLanguage txtCancelSet = new TxtLanguage("Cancel Set?");
        private static readonly TxtLanguage txtSetting = new TxtLanguage("Setting");

        static NormalEditLobbyPlayerBtnSetUI()
        {
            txtSet.add(Language.Type.vi, "Đặt");
            txtCancelSet.add(Language.Type.vi, "Huỷ đặt?");
            txtSetting.add(Language.Type.vi, "Đang đặt");
        }

        #endregion

        #region Refresh

        public GameObject contentContainer;

        public Button btnSet;
        public Text tvSet;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
                    if (lobbyPlayer != null)
                    {
                        uint profileId = Server.getProfileUserId(lobbyPlayer);
                        if (lobbyPlayer.isNormalCanSet(profileId))
                        {
                            this.data.canSet.v = true;
                            // contentContainer
                            if (contentContainer != null)
                            {
                                contentContainer.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("contentContainer null: " + this);
                            }
                            // Task
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            destroyRoutine(wait);
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            destroyRoutine(wait);
                                            if (Server.IsServerOnline(lobbyPlayer))
                                            {
                                                lobbyPlayer.requestNormaSet(profileId);
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
                                            if (Server.IsServerOnline(lobbyPlayer))
                                            {
                                                startRoutine(ref wait, TaskWait());
                                            }
                                            else
                                            {
                                                this.data.state.v = UIData.State.None;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            // UI
                            {
                                if (btnSet != null && tvSet != null)
                                {
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnSet.interactable = true;
                                                tvSet.text = txtSet.get();
                                            }
                                            break;
                                        case UIData.State.Request:
                                            {
                                                btnSet.interactable = true;
                                                tvSet.text = txtCancelSet.get();
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                btnSet.interactable = false;
                                                tvSet.text = txtSetting.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("btnSet, tvSet null: " + this);
                                }
                            }
                        }
                        else
                        {
                            this.data.canSet.v = false;
                            // contentContainer
                            if (contentContainer != null)
                            {
                                contentContainer.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("contentContainer null: " + this);
                            }
                            // Task
                            {
                                this.data.state.v = UIData.State.None;
                                destroyRoutine(wait);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("lobbyPlayer null: " + this);
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
                        this.data.state.v = UIData.State.None;
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

        private RoomCheckChangeAdminChange<LobbyPlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<LobbyPlayer>();
        private ContestManagerStateLobby contestManagerStateLobby = null;

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.lobbyPlayer.allAddCallBack(this);
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
                if (data is LobbyPlayer)
                {
                    LobbyPlayer lobbyPlayer = data as LobbyPlayer;
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
                    // CheckChange
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(lobbyPlayer);
                    }
                    // Parent
                    {
                        DataUtils.addParentCallBack(lobbyPlayer, this, ref this.contestManagerStateLobby);
                        DataUtils.addParentCallBack(lobbyPlayer, this, ref this.server);
                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is RoomCheckChangeAdminChange<LobbyPlayer>)
                {
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if (data is ContestManagerStateLobby)
                    {
                        dirty = true;
                        return;
                    }
                    if (data is Server)
                    {
                        dirty = true;
                        return;
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
                // Child
                {
                    uiData.lobbyPlayer.allRemoveCallBack(this);
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
                if (data is LobbyPlayer)
                {
                    LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                    // CheckChange
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                    // Parent
                    {
                        DataUtils.removeParentCallBack(lobbyPlayer, this, ref this.contestManagerStateLobby);
                        DataUtils.removeParentCallBack(lobbyPlayer, this, ref this.server);
                    }
                    return;
                }
                // CheckChange
                if (data is RoomCheckChangeAdminChange<LobbyPlayer>)
                {
                    return;
                }
                // Parent
                {
                    if (data is ContestManagerStateLobby)
                    {
                        return;
                    }
                    if (data is Server)
                    {
                        return;
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
                    case UIData.Property.lobbyPlayer:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.state:
                        dirty = true;
                        break;
                    case UIData.Property.canSet:
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
            // Child
            {
                if (wrapProperty.p is LobbyPlayer)
                {
                    switch ((LobbyPlayer.Property)wrapProperty.n)
                    {
                        case LobbyPlayer.Property.playerIndex:
                            break;
                        case LobbyPlayer.Property.inform:
                            dirty = true;
                            break;
                        case LobbyPlayer.Property.isReady:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // CheckChange
                if (wrapProperty.p is RoomCheckChangeAdminChange<LobbyPlayer>)
                {
                    dirty = true;
                    return;
                }
                // Parent
                {
                    if (wrapProperty.p is ContestManagerStateLobby)
                    {
                        switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                        {
                            case ContestManagerStateLobby.Property.state:
                                dirty = true;
                                break;
                            case ContestManagerStateLobby.Property.teams:
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
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnSet, onClickBtnSet);
            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.S:
                            {
                                if (btnSet != null && btnSet.gameObject.activeInHierarchy && btnSet.interactable)
                                {
                                    this.onClickBtnSet();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnSet()
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
                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
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