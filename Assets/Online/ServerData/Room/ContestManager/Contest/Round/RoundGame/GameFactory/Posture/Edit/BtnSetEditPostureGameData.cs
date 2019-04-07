using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace Posture
{
    public class BtnSetEditPostureGameData : UIBehavior<BtnSetEditPostureGameData.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region state

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

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtSet = new TxtLanguage("Set");
        private static readonly TxtLanguage txtCancelSet = new TxtLanguage("Cancel Set?");
        private static readonly TxtLanguage txtSetting = new TxtLanguage("Setting");
        private static readonly TxtLanguage txtCannotSet = new TxtLanguage("Cannot Set");

        static BtnSetEditPostureGameData()
        {
            txtSet.add(Language.Type.vi, "Đặt");
            txtCancelSet.add(Language.Type.vi, "Huỷ đặt?");
            txtSetting.add(Language.Type.vi, "Đang đặt");
            txtCannotSet.add(Language.Type.vi, "Không thể đặt");
        }

        #endregion

        #region Refresh

        public Button btnSet;
        public Text tvSet;

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
                            this.data.state.v = UIData.State.None;
                            destroyRoutine(wait);
                        }
                    }
                    EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.findDataInParent<EditPostureGameDataUI.UIData>();
                    if (editPostureGameDataUIData != null)
                    {
                        PostureGameDataFactory postureGameDataFactory = editPostureGameDataUIData.postureGameDataFactory.v.data;
                        if (postureGameDataFactory != null)
                        {
                            // get current gameData
                            GameData gameData = null;
                            {
                                GameUI.UIData gameUIData = editPostureGameDataUIData.gameUIData.v;
                                if (gameUIData != null)
                                {
                                    Game game = gameUIData.game.v.data;
                                    if (game != null)
                                    {
                                        gameData = game.gameData.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("game null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameUIData null: " + this);
                                }
                            }
                            // Process
                            if (gameData != null)
                            {
                                // find is waiting action
                                bool isWaitInputAction = false;
                                {
                                    GameUI.UIData gameUIData = editPostureGameDataUIData.gameUIData.v;
                                    if (gameUIData != null)
                                    {
                                        Game game = gameUIData.game.v.data;
                                        if (game != null)
                                        {
                                            if (game.gameAction.v is WaitInputAction)
                                            {
                                                isWaitInputAction = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("game null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameUIData null: " + this);
                                    }
                                }
                                // Process
                                if (isWaitInputAction)
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
                                                    if (Server.IsServerOnline(postureGameDataFactory))
                                                    {
                                                        postureGameDataFactory.requestChangeGameData(Server.getProfileUserId(postureGameDataFactory), gameData);
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
                                                    if (Server.IsServerOnline(postureGameDataFactory))
                                                    {
                                                        startRoutine(ref this.wait, TaskWait());
                                                    }
                                                    else
                                                    {
                                                        this.data.state.v = UIData.State.None;
                                                        destroyRoutine(wait);
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
                                    // Task
                                    {
                                        this.data.state.v = UIData.State.None;
                                        destroyRoutine(wait);
                                    }
                                    // UI
                                    {
                                        if (btnSet != null && tvSet != null)
                                        {
                                            btnSet.interactable = false;
                                            tvSet.text = txtCannotSet.get();
                                        }
                                        else
                                        {
                                            Debug.LogError("btnSet, tvSet null: " + this);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("gameData null: " + this);
                                this.data.state.v = UIData.State.None;
                            }
                        }
                        else
                        {
                            Debug.LogError("postureGameDataFactory null: " + this);
                            this.data.state.v = UIData.State.None;
                        }
                    }
                    else
                    {
                        Debug.LogError("editPostureGameDataUIData null: " + this);
                        this.data.state.v = UIData.State.None;
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
                this.data.state.v = UIData.State.None;
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
        private EditPostureGameDataUI.UIData editPostureGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.editPostureGameDataUIData);
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
                if (data is EditPostureGameDataUI.UIData)
                {
                    EditPostureGameDataUI.UIData editPostureGameDataUIData = data as EditPostureGameDataUI.UIData;
                    // Child
                    {
                        editPostureGameDataUIData.postureGameDataFactory.allAddCallBack(this);
                        editPostureGameDataUIData.gameUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // PostureGameDataFactory
                {
                    if (data is PostureGameDataFactory)
                    {
                        PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
                        // Parent
                        {
                            DataUtils.addParentCallBack(postureGameDataFactory, this, ref this.server);
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
                // gameUIData
                {
                    if (data is GameUI.UIData)
                    {
                        GameUI.UIData gameUIData = data as GameUI.UIData;
                        // Child
                        {
                            gameUIData.game.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Game)
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.editPostureGameDataUIData);
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
                if (data is EditPostureGameDataUI.UIData)
                {
                    EditPostureGameDataUI.UIData editPostureGameDataUIData = data as EditPostureGameDataUI.UIData;
                    // Child
                    {
                        editPostureGameDataUIData.postureGameDataFactory.allRemoveCallBack(this);
                        editPostureGameDataUIData.gameUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // PostureGameDataFactory
                {
                    if (data is PostureGameDataFactory)
                    {
                        PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(postureGameDataFactory, this, ref this.server);
                        }
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                }
                // gameUIData
                {
                    if (data is GameUI.UIData)
                    {
                        GameUI.UIData gameUIData = data as GameUI.UIData;
                        // Child
                        {
                            gameUIData.game.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Game)
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
                if (wrapProperty.p is EditPostureGameDataUI.UIData)
                {
                    switch ((EditPostureGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case EditPostureGameDataUI.UIData.Property.postureGameDataFactory:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditPostureGameDataUI.UIData.Property.gameUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditPostureGameDataUI.UIData.Property.btnSet:
                            break;
                        case EditPostureGameDataUI.UIData.Property.choosePostureUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // PostureGameDataFactory
                {
                    if (wrapProperty.p is PostureGameDataFactory)
                    {
                        switch ((PostureGameDataFactory.Property)wrapProperty.n)
                        {
                            case PostureGameDataFactory.Property.gameData:
                                {
                                    dirty = true;
                                    needReset = true;
                                }
                                break;
                            case PostureGameDataFactory.Property.useRule:
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
                // gameUIData
                {
                    if (wrapProperty.p is GameUI.UIData)
                    {
                        switch ((GameUI.UIData.Property)wrapProperty.n)
                        {
                            case GameUI.UIData.Property.game:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GameUI.UIData.Property.isReplay:
                                break;
                            case GameUI.UIData.Property.stateUI:
                                break;
                            case GameUI.UIData.Property.gameDataUI:
                                break;
                            case GameUI.UIData.Property.undoRedoRequestUIData:
                                break;
                            case GameUI.UIData.Property.gameChatRoom:
                                break;
                            case GameUI.UIData.Property.requestDraw:
                                break;
                            case GameUI.UIData.Property.saveUIData:
                                break;
                            case GameUI.UIData.Property.gameHistoryUIData:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Game)
                    {
                        switch ((Game.Property)wrapProperty.n)
                        {
                            case Game.Property.gamePlayers:
                                break;
                            case Game.Property.requestDraw:
                                break;
                            case Game.Property.state:
                                break;
                            case Game.Property.gameData:
                                {
                                    dirty = true;
                                    {
                                        if (this.data != null)
                                        {
                                            this.data.state.v = UIData.State.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("data null: " + this);
                                        }
                                        destroyRoutine(wait);
                                    }
                                }
                                break;
                            case Game.Property.history:
                                break;
                            case Game.Property.gameAction:
                                dirty = true;
                                break;
                            case Game.Property.undoRedoRequest:
                                break;
                            case Game.Property.chatRoom:
                                break;
                            case Game.Property.animationData:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

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