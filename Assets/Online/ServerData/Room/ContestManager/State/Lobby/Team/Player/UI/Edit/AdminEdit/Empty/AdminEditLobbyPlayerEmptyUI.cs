using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace GameManager.Match
{
    public class AdminEditLobbyPlayerEmptyUI : UIBehavior<AdminEditLobbyPlayerEmptyUI.UIData>
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

            #region Constructor

            public enum Property
            {
                lobbyPlayer,
                state
            }

            public UIData() : base()
            {
                this.lobbyPlayer = new VP<ReferenceData<LobbyPlayer>>(this, (byte)Property.lobbyPlayer, new ReferenceData<LobbyPlayer>(null));
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

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Make empty inform");

        private static readonly TxtLanguage txtRequest = new TxtLanguage("Request Empty");
        private static readonly TxtLanguage txtCancelRequest = new TxtLanguage("Cancel Request Empty?");
        private static readonly TxtLanguage txtRequesting = new TxtLanguage("Requesting Empty...");
        private static readonly TxtLanguage txtAlreadyEmpty = new TxtLanguage("Already Empty");

        static AdminEditLobbyPlayerEmptyUI()
        {
            txtTitle.add(Language.Type.vi, "Làm trống");

            txtRequest.add(Language.Type.vi, "Yêu cầu");
            txtCancelRequest.add(Language.Type.vi, "Huỷ yêu cầu?");
            txtRequesting.add(Language.Type.vi, "Đang yêu cầu...");
            txtAlreadyEmpty.add(Language.Type.vi, "Đã trống");
        }

        #endregion

        #region Refresh

        public Button btnRequest;
        public Text tvRequest;

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
                        if (!(lobbyPlayer.inform.v is EmptyInform))
                        {
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
                                                lobbyPlayer.requestAdminChangeEmpty(Server.getProfileUserId(lobbyPlayer));
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
                                                startRoutine(ref this.wait, TaskWait());
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
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
                                if (btnRequest != null && tvRequest != null)
                                {
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnRequest.interactable = true;
                                                tvRequest.text = txtRequest.get();
                                            }
                                            break;
                                        case UIData.State.Request:
                                            {
                                                btnRequest.interactable = true;
                                                tvRequest.text = txtCancelRequest.get();
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                btnRequest.interactable = false;
                                                tvRequest.text = txtRequesting.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("btnRequest, tvRequest null: " + this);
                                }
                            }
                        }
                        else
                        {
                            // already set
                            // Task
                            {
                                this.data.state.v = UIData.State.None;
                                destroyRoutine(wait);
                            }
                            // UI
                            {
                                if (btnRequest != null && tvRequest != null)
                                {
                                    btnRequest.interactable = false;
                                    tvRequest.text = txtAlreadyEmpty.get();
                                }
                                else
                                {
                                    Debug.LogError("btnRequest, tvRequest null: " + this);
                                }
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
                                Debug.LogError("lbTitle null: " + this);
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
                    // Parent
                    {
                        DataUtils.addParentCallBack(lobbyPlayer, this, ref this.server);
                    }
                    dirty = true;
                    needReset = true;
                    return;
                }
                // Parent
                if (data is Server)
                {
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
                    // Parent
                    {
                        DataUtils.removeParentCallBack(lobbyPlayer, this, ref this.server);
                    }
                    return;
                }
                // Parent
                if (data is Server)
                {
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
                            {
                                dirty = true;
                                needReset = true;
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnRequest()
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
                        Debug.LogError("already request: " + this);
                        break;
                    default:
                        Debug.LogError("unknown type: " + this.data.state.v + "; " + this);
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