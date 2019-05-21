using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameManager.Match
{
    public class AdminEditLobbyPlayerHumanUI : UIBehavior<AdminEditLobbyPlayerHumanUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<LobbyPlayer>> lobbyPlayer;

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

            public VP<AdminEditLobbyPlayerChooseHumanAdapter.UIData> humanAdapter;

            #region Constructor

            public enum Property
            {
                lobbyPlayer,
                state,
                humanAdapter
            }

            public UIData() : base()
            {
                this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
                this.state = new VP<State>(this, (byte)Property.state, new StateNone());
                this.humanAdapter = new VP<AdminEditLobbyPlayerChooseHumanAdapter.UIData>(this, (byte)Property.humanAdapter, new AdminEditLobbyPlayerChooseHumanAdapter.UIData());
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

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            AdminEditLobbyPlayerHumanUI adminEditLobbyPlayerHumanUI = this.findCallBack<AdminEditLobbyPlayerHumanUI>();
                            if (adminEditLobbyPlayerHumanUI != null)
                            {
                                isProcess = adminEditLobbyPlayerHumanUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("adminEditLobbyPlayerHumanUI null: " + this);
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

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Human");

        public Text tvRequesting;
        private static readonly TxtLanguage txtRequesting = new TxtLanguage("Requesting to choose human...");

        public Text tvCancel;
        private static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

        private static readonly TxtLanguage txtError = new TxtLanguage("request error");

        static AdminEditLobbyPlayerHumanUI()
        {
            txtTitle.add(Language.Type.vi, "Chọn người");
            txtRequesting.add(Language.Type.vi, "Đang yêu cầu chọn người...");
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
            txtError.add(Language.Type.vi, "yêu cầu bị lỗi");
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
                    LobbyPlayer lobbyPlayer = this.data.lobbyPlayer.v.data;
                    if (lobbyPlayer != null)
                    {
                        // humanAdapter
                        {
                            AdminEditLobbyPlayerChooseHumanAdapter.UIData humanAdapter = this.data.humanAdapter.v;
                            if (humanAdapter != null)
                            {
                                humanAdapter.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
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
                                                if (Server.IsServerOnline(lobbyPlayer))
                                                {
                                                    // Request
                                                    {
                                                        lobbyPlayer.requestAdminChangeHuman(Server.getProfileUserId(lobbyPlayer), stateRequest.humanId.v);
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
                                                if (Server.IsServerOnline(lobbyPlayer))
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
                    }
                    else
                    {
                        Debug.LogError("lobbyPlayer null: " + this);
                    }
                    // UI
                    {
                        // HumanAdapter
                        UIRectTransform.SetSiblingIndex(this.data.humanAdapter.v, 1);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (tvRequesting != null)
                        {
                            tvRequesting.text = txtRequesting.get();
                        }
                        else
                        {
                            Debug.LogError("tvRequesting null: " + this);
                        }
                        if (tvCancel != null)
                        {
                            tvCancel.text = txtCancel.get();
                        }
                        else
                        {
                            Debug.LogError("tvCancel null: " + this);
                        }
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
                Toast.showMessage(txtError.get());
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

        public AdminEditLobbyPlayerChooseHumanAdapter humanAdapterPrefab;
        private static readonly UIRectTransform humanAdapterRect = UIRectTransform.CreateFullRect(10, 10, 30, 10);

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
                // LobbyPlayer
                {
                    if (data is LobbyPlayer)
                    {
                        LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                        // Reset
                        {
                            needReset = true;
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(lobbyPlayer, this, ref this.server);
                        }
                        // Child
                        {
                            lobbyPlayer.inform.allAddCallBack(this);
                        }
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
                    if (data is GamePlayer.Inform)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is AdminEditLobbyPlayerChooseHumanAdapter.UIData)
                {
                    AdminEditLobbyPlayerChooseHumanAdapter.UIData humanAdapter = data as AdminEditLobbyPlayerChooseHumanAdapter.UIData;
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
                    uiData.lobbyPlayer.allRemoveCallBack(this);
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
                // LobbyPlayer
                {
                    if (data is LobbyPlayer)
                    {
                        LobbyPlayer lobbyPlayer = data as LobbyPlayer;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(lobbyPlayer, this, ref this.server);
                        }
                        // Child
                        {
                            lobbyPlayer.inform.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    if (data is GamePlayer.Inform)
                    {
                        return;
                    }
                }
                if (data is AdminEditLobbyPlayerChooseHumanAdapter.UIData)
                {
                    AdminEditLobbyPlayerChooseHumanAdapter.UIData humanAdapter = data as AdminEditLobbyPlayerChooseHumanAdapter.UIData;
                    // UI
                    {
                        humanAdapter.removeCallBackAndDestroy(typeof(AdminEditLobbyPlayerChooseHumanAdapter));
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
                    case UIData.Property.lobbyPlayer:
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
                // LobbyPlayer
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
                                    // Reset
                                    {
                                        needReset = true;
                                    }
                                }
                                break;
                            case LobbyPlayer.Property.isReady:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
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
                                    {
                                        dirty = true;
                                        // reset
                                        {
                                            needReset = true;
                                        }
                                    }
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
                            return;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is AdminEditLobbyPlayerChooseHumanAdapter.UIData)
                {
                    return;
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
                UIUtils.SetButtonOnClick(btnCancel, onClickBtnCancel);
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
                        case KeyCode.C:
                            {
                                if (btnCancel != null && btnCancel.gameObject.activeInHierarchy && btnCancel.interactable)
                                {
                                    this.onClickBtnCancel();
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