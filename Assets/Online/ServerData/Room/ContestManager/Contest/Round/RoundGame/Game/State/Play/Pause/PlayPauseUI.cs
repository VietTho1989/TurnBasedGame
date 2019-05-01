using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

namespace GameState
{
    public class PlayPauseUI : UIBehavior<PlayPauseUI.UIData>
    {

        #region UIData

        public class UIData : PlayUI.UIData.Sub
        {

            public VP<ReferenceData<PlayPause>> playPause;

            public VP<AccountAvatarUI.UIData> accountAvatar;

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
                playPause,
                accountAvatar,
                state
            }

            public UIData() : base()
            {
                this.playPause = new VP<ReferenceData<PlayPause>>(this, (byte)Property.playPause, new ReferenceData<PlayPause>(null));
                this.accountAvatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.accountAvatar, new AccountAvatarUI.UIData());
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

            public override Play.Sub.Type getType()
            {
                return Play.Sub.Type.Pause;
            }

        }

        #endregion

        #region txt, rect

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Game Pause");

        private static readonly TxtLanguage txtUnpause = new TxtLanguage("Unpause");
        private static readonly TxtLanguage txtCancelUnpause = new TxtLanguage("Cancel unpause?");
        private static readonly TxtLanguage txtUnpausing = new TxtLanguage("Unpausing");
        private static readonly TxtLanguage txtCannotUnpause = new TxtLanguage("Cannot unpause");

        private static readonly TxtLanguage txtRequestError = new TxtLanguage("Request resume error");

        static PlayPauseUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Tạm Dừng");
                txtUnpause.add(Language.Type.vi, "Tiếp Tục Lại");
                txtCancelUnpause.add(Language.Type.vi, "Huỷ tiếp tục lại?");
                txtUnpausing.add(Language.Type.vi, "Đang tiếp tục lại...");
                txtCannotUnpause.add(Language.Type.vi, "Không thể tiếp tục lại");
                txtRequestError.add(Language.Type.vi, "Yêu cầu tiếp tục lại lỗi");
            }
            // rect
            {
                // accountAvatarRect
                {
                    // anchoredPosition: (0.0, -40.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (-30.0, -100.0); offsetMax: (30.0, -40.0); sizeDelta: (60.0, 60.0);
                    accountAvatarRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
                    accountAvatarRect.anchorMin = new Vector2(0.5f, 1.0f);
                    accountAvatarRect.anchorMax = new Vector2(0.5f, 1.0f);
                    accountAvatarRect.pivot = new Vector2(0.5f, 1.0f);
                    accountAvatarRect.offsetMin = new Vector2(-30.0f, -100.0f);
                    accountAvatarRect.offsetMax = new Vector2(30.0f, -40.0f);
                    accountAvatarRect.sizeDelta = new Vector2(60.0f, 60.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvName;

        public Button btnUnPause;
        public Text tvUnPause;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    PlayPause playPause = this.data.playPause.v.data;
                    if (playPause != null)
                    {
                        // UnPause
                        {
                            if (Play.IsCanChange(playPause, Server.getProfileUserId(playPause)))
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
                                                if (Server.IsServerOnline(playPause))
                                                {
                                                    playPause.requestUnPause(Server.getProfileUserId(playPause));
                                                    this.data.state.v = UIData.State.Wait;
                                                }
                                                else
                                                {
                                                    Debug.LogError("server offline: " + this);
                                                }
                                            }
                                            break;
                                        case UIData.State.Wait:
                                            {
                                                if (Server.IsServerOnline(playPause))
                                                {
                                                    startRoutine(ref this.wait, TaskWait());
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
                                    if (btnUnPause != null && tvUnPause != null)
                                    {
                                        switch (this.data.state.v)
                                        {
                                            case UIData.State.None:
                                                {
                                                    btnUnPause.interactable = true;
                                                    tvUnPause.text = txtUnpause.get();
                                                }
                                                break;
                                            case UIData.State.Request:
                                                {
                                                    btnUnPause.interactable = true;
                                                    tvUnPause.text = txtCancelUnpause.get();
                                                }
                                                break;
                                            case UIData.State.Wait:
                                                {
                                                    btnUnPause.interactable = false;
                                                    tvUnPause.text = txtUnpausing.get();
                                                }
                                                break;
                                            default:
                                                Debug.LogError("Unknown state: " + this.data.state.v + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("btnUnPause, tvUnPause null: " + this);
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
                                    if (btnUnPause != null && tvUnPause != null)
                                    {
                                        btnUnPause.interactable = false;
                                        tvUnPause.text = txtCannotUnpause.get();
                                    }
                                    else
                                    {
                                        Debug.LogError("btnUnPause, tvUnPause null: " + this);
                                    }
                                }
                            }
                        }
                        // inform
                        {
                            Human human = playPause.human.v;
                            // accountAvatar
                            {
                                AccountAvatarUI.UIData accountAvatarUIData = this.data.accountAvatar.v;
                                if (accountAvatarUIData != null)
                                {
                                    // Find account
                                    Account account = null;
                                    {
                                        if (human != null)
                                        {
                                            account = human.account.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("human null: " + this);
                                        }
                                    }
                                    // Process
                                    accountAvatarUIData.account.v = new ReferenceData<Account>(account);
                                }
                                else
                                {
                                    Debug.LogError("accountAvatarUIData null: " + this);
                                }
                            }
                            // name
                            if (tvName != null)
                            {
                                string name = "";
                                {
                                    if (human != null)
                                    {
                                        if (human.account.v != null)
                                        {
                                            name = human.account.v.getName();
                                        }
                                        else
                                        {
                                            Debug.LogError("account null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("human null: " + this);
                                    }
                                }
                                tvName.text = name;
                            }
                            else
                            {
                                Debug.LogError("tvName null: " + this);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            deltaY += UIConstants.HeaderHeight;
                            // avatar, name
                            {
                                bool need = true;
                                {
                                    if (tvName != null)
                                    {
                                        if (string.IsNullOrEmpty(tvName.text))
                                        {
                                            need = false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("tvName null");
                                    }
                                }
                                // avatar
                                UIRectTransform.SetActive(this.data.accountAvatar.v, need);
                                // name
                                if (tvName != null)
                                {
                                    tvName.gameObject.SetActive(need);
                                }
                                else
                                {
                                    Debug.LogError("tvName null");
                                }
                                // set
                                if (need)
                                    deltaY += 80 + 30;
                            }
                            // btn
                            {
                                if (btnUnPause != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)btnUnPause.transform, deltaY + 10);
                                }
                                else
                                {
                                    Debug.LogError("btnUnPause null");
                                }
                                deltaY += 50;
                            }
                            // set contentContainer 
                            {
                                float rightWidth = 0;
                                float bottomHeight = 0;
                                {
                                    GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                                    if (gameUIData != null)
                                    {
                                        GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                                        if (gameDataUIData != null)
                                        {
                                            rightWidth = gameDataUIData.rightWidth.v;
                                            bottomHeight = gameDataUIData.bottomHeight.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("gameDataUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameUIData null");
                                    }
                                }
                                // set
                                UIRectTransform.CreateCenterRect(300, deltaY, -rightWidth/2, bottomHeight/2).set(contentContainer);
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
                        }
                    }
                    else
                    {
                        Debug.LogError("playPause null: " + this);
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
                if (this.data != null)
                {
                    this.data.state.v = UIData.State.None;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
                Toast.showMessage(txtRequestError.get());
                Debug.LogError("error, why cannot request: " + this);
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

        private GameCheckPlayerChange<PlayPause> gamePlayerCheckChange = new GameCheckPlayerChange<PlayPause>();
        private RoomCheckChangeAdminChange<PlayPause> roomCheckAdminChange = new RoomCheckChangeAdminChange<PlayPause>();
        private Server server = null;

        public AccountAvatarUI accountAvatarPrefab;
        private static readonly UIRectTransform accountAvatarRect = new UIRectTransform();

        public RectTransform contentContainer;

        private GameUI.UIData gameUIData = null;
        private GameDataBoardTransformCheckChange<GameDataUI.UIData> gameDataBoardTransformCheckChange = new GameDataBoardTransformCheckChange<GameDataUI.UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.playPause.allAddCallBack(this);
                    uiData.accountAvatar.allAddCallBack(this);
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
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // Child
                    {
                        gameUIData.gameDataUI.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // CheckChange
                        {
                            gameDataBoardTransformCheckChange.addCallBack(this);
                            gameDataBoardTransformCheckChange.setData(gameDataUIData);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                // PlayPause
                {
                    if (data is PlayPause)
                    {
                        PlayPause playPause = data as PlayPause;
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
                            // gamePlayer
                            {
                                gamePlayerCheckChange.addCallBack(this);
                                gamePlayerCheckChange.setData(playPause);
                            }
                            // roomAdmin
                            {
                                roomCheckAdminChange.addCallBack(this);
                                roomCheckAdminChange.setData(playPause);
                            }
                        }
                        // Parent
                        {
                            DataUtils.addParentCallBack(playPause, this, ref this.server);
                        }
                        // Child
                        {
                            playPause.human.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    {
                        if (data is GameCheckPlayerChange<PlayPause>)
                        {
                            dirty = true;
                            return;
                        }
                        if (data is RoomCheckChangeAdminChange<PlayPause>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Parent
                    if (data is Server)
                    {
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Human)
                        {
                            Human human = data as Human;
                            // Child
                            {
                                human.account.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is Account)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (data is AccountAvatarUI.UIData)
                {
                    AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(accountAvatarUIData, accountAvatarPrefab, contentContainer, accountAvatarRect);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.playPause.allRemoveCallBack(this);
                    uiData.accountAvatar.allRemoveCallBack(this);
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
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // Child
                    {
                        gameUIData.gameDataUI.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is GameDataUI.UIData)
                    {
                        GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                        // CheckChange
                        {
                            gameDataBoardTransformCheckChange.removeCallBack(this);
                            gameDataBoardTransformCheckChange.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        return;
                    }
                }
            }
            // Child
            {
                // PlayPause
                {
                    if (data is PlayPause)
                    {
                        PlayPause playPause = data as PlayPause;
                        // CheckChange
                        {
                            // gamePlayer
                            {
                                gamePlayerCheckChange.removeCallBack(this);
                                gamePlayerCheckChange.setData(null);
                            }
                            // roomAdmin
                            {
                                roomCheckAdminChange.removeCallBack(this);
                                roomCheckAdminChange.setData(null);
                            }
                        }
                        // Parent
                        {
                            DataUtils.removeParentCallBack(playPause, this, ref this.server);
                        }
                        // Child
                        {
                            playPause.human.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // CheckChange
                    {
                        if (data is GameCheckPlayerChange<PlayPause>)
                        {
                            return;
                        }
                        if (data is RoomCheckChangeAdminChange<PlayPause>)
                        {
                            return;
                        }
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    {
                        if (data is Human)
                        {
                            Human human = data as Human;
                            // Child
                            {
                                human.account.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is Account)
                        {
                            return;
                        }
                    }
                }
                if (data is AccountAvatarUI.UIData)
                {
                    AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                    // UI
                    {
                        accountAvatarUIData.removeCallBackAndDestroy(typeof(AccountAvatarUI));
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
                    case UIData.Property.playPause:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.accountAvatar:
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
            // Parent
            {
                if (wrapProperty.p is GameUI.UIData)
                {
                    switch ((GameUI.UIData.Property)wrapProperty.n)
                    {
                        case GameUI.UIData.Property.game:
                            break;
                        case GameUI.UIData.Property.isReplay:
                            break;
                        case GameUI.UIData.Property.gameDataUI:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameUI.UIData.Property.gameBottom:
                            break;
                        case GameUI.UIData.Property.undoRedoRequestUIData:
                            break;
                        case GameUI.UIData.Property.requestDraw:
                            break;
                        case GameUI.UIData.Property.gameChatRoom:
                            break;
                        case GameUI.UIData.Property.gameHistoryUIData:
                            break;
                        case GameUI.UIData.Property.stateUI:
                            break;
                        case GameUI.UIData.Property.saveUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GameDataUI.UIData)
                    {
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is GameDataBoardTransformCheckChange<GameDataUI.UIData>)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            {
                // PlayPause
                {
                    if (wrapProperty.p is PlayPause)
                    {
                        switch ((PlayPause.Property)wrapProperty.n)
                        {
                            case PlayPause.Property.human:
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
                    // CheckChange
                    {
                        if (wrapProperty.p is GameCheckPlayerChange<PlayPause>)
                        {
                            dirty = true;
                            return;
                        }
                        if (wrapProperty.p is RoomCheckChangeAdminChange<PlayPause>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Parent
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is Human)
                        {
                            switch ((Human.Property)wrapProperty.n)
                            {
                                case Human.Property.playerId:
                                    break;
                                case Human.Property.account:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
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
                        // Child
                        if (wrapProperty.p is Account)
                        {
                            Account.OnUpdateSyncAccount(wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is AccountAvatarUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnUnPause()
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
                        Debug.LogError("You are requesting");
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v);
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