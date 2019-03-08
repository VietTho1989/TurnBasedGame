using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Posture;
using GameManager.Match;

public class PostureGameDataFactoryUI : UIHaveTransformDataBehavior<PostureGameDataFactoryUI.UIData>
{

    #region UIData

    public class UIData : GameFactoryUI.UIData.GameDataFactoryUIData
    {

        public VP<EditData<PostureGameDataFactory>> editPostureGameDataFactory;

        #region gameType

        public VP<RequestChangeEnumUI.UIData> gameType;

        public void makeRequestChangeGameType(RequestChangeUpdate<int>.UpdateData update, int newGameType)
        {
            // Find
            PostureGameDataFactory postureGameDataFactory = null;
            {
                EditData<PostureGameDataFactory> editPostureGameDataFactory = this.editPostureGameDataFactory.v;
                if (editPostureGameDataFactory != null)
                {
                    postureGameDataFactory = editPostureGameDataFactory.show.v.data;
                }
                else
                {
                    Debug.LogError("editPostureGameDataFactory null: " + this);
                }
            }
            // Process
            if (postureGameDataFactory != null)
            {
                // Find gameTypeType
                GameType.Type gameTypeType = GameType.Type.Xiangqi;
                {
                    if (newGameType >= 0 && newGameType < GameType.EnableTypes.Length)
                    {
                        gameTypeType = GameType.EnableTypes[newGameType];
                    }
                }
                postureGameDataFactory.requestChangeGameType(Server.getProfileUserId(postureGameDataFactory), gameTypeType);
            }
            else
            {
                Debug.LogError("postureGameDataFactory null: " + this);
            }
        }

        #endregion

        public VP<EditPostureGameDataUI.UIData> editPostureGameData;

        public VP<MiniGameDataUI.UIData> miniGameDataUI;

        #region useRule

        public VP<RequestChangeBoolUI.UIData> useRule;

        public void makeRequestChangeUseRule(RequestChangeUpdate<bool>.UpdateData update, bool newUseRule)
        {
            // Find
            PostureGameDataFactory postureGameDataFactory = null;
            {
                EditData<PostureGameDataFactory> editPostureGameDataFactory = this.editPostureGameDataFactory.v;
                if (editPostureGameDataFactory != null)
                {
                    postureGameDataFactory = editPostureGameDataFactory.show.v.data;
                }
                else
                {
                    Debug.LogError("editPostureGameDataFactory null: " + this);
                }
            }
            // Process
            if (postureGameDataFactory != null)
            {
                postureGameDataFactory.requestChangeUseRule(Server.getProfileUserId(postureGameDataFactory), newUseRule);
            }
            else
            {
                Debug.LogError("postureGameDataFactory null: " + this);
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            editPostureGameDataFactory,
            gameType,
            editPostureGameData,
            miniGameDataUI,
            useRule
        }

        public UIData() : base()
        {
            this.editPostureGameDataFactory = new VP<EditData<PostureGameDataFactory>>(this, (byte)Property.editPostureGameDataFactory, new EditData<PostureGameDataFactory>());
            // gameType
            {
                this.gameType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.gameType, new RequestChangeEnumUI.UIData());
                // event
                this.gameType.v.updateData.v.request.v = makeRequestChangeGameType;
                {
                    for (int i = 0; i < GameType.EnableTypes.Length; i++)
                    {
                        this.gameType.v.options.add(GameType.EnableTypes[i].ToString());
                    }
                }
            }
            this.editPostureGameData = new VP<EditPostureGameDataUI.UIData>(this, (byte)Property.editPostureGameData, null);
            this.miniGameDataUI = new VP<MiniGameDataUI.UIData>(this, (byte)Property.miniGameDataUI, new MiniGameDataUI.UIData());
            // useRule
            {
                this.useRule = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.useRule, new RequestChangeBoolUI.UIData());
                // event
                this.useRule.v.updateData.v.request.v = makeRequestChangeUseRule;
            }
        }

        #endregion

        public override GameDataFactory.Type getType()
        {
            return GameDataFactory.Type.Posture;
        }

        public override bool processEvent(Event e)
        {
            Debug.LogError("processEvent: " + e + "; " + this);
            bool isProcess = false;
            {
                // editPostureGameData
                if (!isProcess)
                {
                    EditPostureGameDataUI.UIData editPostureGameDataUIData = this.editPostureGameData.v;
                    if (editPostureGameDataUIData != null)
                    {
                        isProcess = editPostureGameDataUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("editPostureGameDataUIData null: " + this);
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage();

    public Text lbGameType;
    public static readonly TxtLanguage txtGameType = new TxtLanguage();

    public Text tvEdit;
    public static readonly TxtLanguage txtEdit = new TxtLanguage();

    public Text lbUseRule;
    public static readonly TxtLanguage txtUseRule = new TxtLanguage();

    static PostureGameDataFactoryUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Cách tạo thế cờ");
            txtGameType.add(Language.Type.vi, "Loại game");
            txtEdit.add(Language.Type.vi, "Chỉnh sửa");
            txtUseRule.add(Language.Type.vi, "Dùng luật");
        }
        // rect
        {
            gameTypeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            useRuleRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + UIConstants.DefaultMiniGameDataUISize + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
        }
    }

    #endregion

    #region Refresh

    public Button btnEdit;

    private bool needReset = true;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<PostureGameDataFactory> editPostureGameDataFactory = this.data.editPostureGameDataFactory.v;
                if (editPostureGameDataFactory != null)
                {
                    editPostureGameDataFactory.update();
                    // get show
                    PostureGameDataFactory show = editPostureGameDataFactory.show.v.data;
                    PostureGameDataFactory compare = editPostureGameDataFactory.compare.v.data;
                    if (show != null)
                    {
                        // different
                        if (lbTitle != null)
                        {
                            bool isDifferent = false;
                            {
                                if (editPostureGameDataFactory.compareOtherType.v.data != null)
                                {
                                    if (editPostureGameDataFactory.compareOtherType.v.data.GetType() != show.GetType())
                                    {
                                        isDifferent = true;
                                    }
                                }
                            }
                            lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        // requests
                        {
                            // get server state
                            Server.State.Type serverState = Server.State.Type.Connect;
                            {
                                Server server = show.findDataInParent<Server>();
                                if (server != null)
                                {
                                    if (server.state.v != null)
                                    {
                                        serverState = server.state.v.getType();
                                    }
                                    else
                                    {
                                        Debug.LogError("server state null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("server null: " + this);
                                }
                            }
                            // set origin
                            {
                                // gameType
                                {
                                    RequestChangeEnumUI.UIData gameType = this.data.gameType.v;
                                    if (gameType != null)
                                    {
                                        // options
                                        {
                                            gameType.options.copyList(GameType.GetEnableTypeString());
                                        }
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = gameType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = GameType.getEnableIndex(show.getGameTypeType());
                                            updateData.canRequestChange.v = editPostureGameDataFactory.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                gameType.showDifferent.v = true;
                                                gameType.compare.v = GameType.getEnableIndex(compare.getGameTypeType());
                                            }
                                            else
                                            {
                                                gameType.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // useRule
                                {
                                    RequestChangeBoolUI.UIData useRule = this.data.useRule.v;
                                    if (useRule != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = useRule.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.useRule.v;
                                            updateData.canRequestChange.v = editPostureGameDataFactory.canEdit.v;
                                            updateData.serverState.v = serverState;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                        // compare
                                        {
                                            if (compare != null)
                                            {
                                                useRule.showDifferent.v = true;
                                                useRule.compare.v = compare.useRule.v;
                                            }
                                            else
                                            {
                                                useRule.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // gameType
                                {
                                    RequestChangeEnumUI.UIData gameType = this.data.gameType.v;
                                    if (gameType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = gameType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = GameType.getEnableIndex(show.getGameTypeType());
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                                // useRule
                                {
                                    RequestChangeBoolUI.UIData useRule = this.data.useRule.v;
                                    if (useRule != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = useRule.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.useRule.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("useRule null: " + this);
                                    }
                                }
                            }
                        }
                        // miniGameDatas
                        {
                            MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUI.v;
                            if (miniGameDataUIData != null)
                            {
                                miniGameDataUIData.gameData.v = new ReferenceData<GameData>(show.gameData.v);
                            }
                            else
                            {
                                Debug.LogError("miniGameDataUIData null: " + this);
                            }
                        }
                        // btnEdit
                        {
                            if (btnEdit != null)
                            {
                                btnEdit.gameObject.SetActive(editPostureGameDataFactory.canEdit.v);
                            }
                            else
                            {
                                Debug.LogError("btnEdit null: " + this);
                            }
                        }
                        // editPostureGameDataUI
                        {
                            EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.editPostureGameData.v;
                            if (editPostureGameDataUIData != null)
                            {
                                editPostureGameDataUIData.postureGameDataFactory.v = new ReferenceData<PostureGameDataFactory>(show);
                            }
                            else
                            {
                                Debug.LogError("editPostureGameDataUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("show null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("editPostureGameDataFactory null: " + this);
                }
                // UISize
                {
                    if (btnEdit != null)
                    {
                        btnEdit.transform.SetAsLastSibling();
                    }
                    else
                    {
                        Debug.LogError("btnEdit null");
                    }
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Posture Game Data Factory");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbGameType != null)
                    {
                        lbGameType.text = txtGameType.get("Game type");
                    }
                    else
                    {
                        Debug.LogError("gameType null: " + this);
                    }
                    if (tvEdit != null)
                    {
                        tvEdit.text = txtEdit.get("Edit");
                    }
                    else
                    {
                        Debug.LogError("tvEdit null: " + this);
                    }
                    if (lbUseRule != null)
                    {
                        lbUseRule.text = txtUseRule.get("Use rule");
                    }
                    else
                    {
                        Debug.LogError("lbUseRule null: " + this);
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
        return true;
    }

    #endregion

    #region implement callBacks

    public MiniGameDataUI miniGameDataUIPrefab;

    public EditPostureGameDataUI editPostureGameDataPrefab;

    public RequestChangeBoolUI requestBoolPrefab;
    public RequestChangeEnumUI requestEnumPrefab;

    private static readonly UIRectTransform gameTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);
    private static readonly UIRectTransform useRuleRect = new UIRectTransform(UIConstants.RequestBoolRect);

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
                uiData.editPostureGameDataFactory.allAddCallBack(this);
                uiData.gameType.allAddCallBack(this);
                uiData.editPostureGameData.allAddCallBack(this);
                uiData.miniGameDataUI.allAddCallBack(this);
                uiData.useRule.allAddCallBack(this);
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
            // editPostureGameDataFactory
            {
                if (data is EditData<PostureGameDataFactory>)
                {
                    EditData<PostureGameDataFactory> editPostureGameDataFactory = data as EditData<PostureGameDataFactory>;
                    // Child
                    {
                        editPostureGameDataFactory.show.allAddCallBack(this);
                        editPostureGameDataFactory.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is PostureGameDataFactory)
                    {
                        PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
                        // Parent
                        {
                            DataUtils.addParentCallBack(postureGameDataFactory, this, ref this.server);
                        }
                        // Child
                        {
                            postureGameDataFactory.gameData.allAddCallBack(this);
                        }
                        needReset = true;
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
                    if (data is GameData)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // gameType
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.gameType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, gameTypeRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            // editPostureGameData
            if (data is EditPostureGameDataUI.UIData)
            {
                EditPostureGameDataUI.UIData editPostureGameDataUIData = data as EditPostureGameDataUI.UIData;
                // UI
                {
                    Transform container = null;
                    {
                        if (this.data != null)
                        {
                            ContestManagerStateLobbyUI.UIData lobbyUIData = this.data.findDataInParent<ContestManagerStateLobbyUI.UIData>();
                            if (lobbyUIData != null)
                            {
                                ContestManagerStateLobbyUI lobbyUI = lobbyUIData.findCallBack<ContestManagerStateLobbyUI>();
                                if (lobbyUI != null)
                                {
                                    container = lobbyUI.editPostureGameDataUIContainer;
                                }
                                else
                                {
                                    Debug.LogError("lobbyUI null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("lobbyUIData null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    UIUtils.Instantiate(editPostureGameDataUIData, editPostureGameDataPrefab, container);
                }
                dirty = true;
                return;
            }
            // miniGameDataUI
            if (data is MiniGameDataUI.UIData)
            {
                MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(miniGameDataUIData, miniGameDataUIPrefab, this.transform, UIConstants.PostureMiniGameDataUIRect);
                }
                dirty = true;
                return;
            }
            // useRule
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.useRule:
                                UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, useRuleRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
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
                uiData.editPostureGameDataFactory.allRemoveCallBack(this);
                uiData.gameType.allRemoveCallBack(this);
                uiData.editPostureGameData.allRemoveCallBack(this);
                uiData.miniGameDataUI.allRemoveCallBack(this);
                uiData.useRule.allRemoveCallBack(this);
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
            // editPostureGameDataFactory
            {
                if (data is EditData<PostureGameDataFactory>)
                {
                    EditData<PostureGameDataFactory> editPostureGameDataFactory = data as EditData<PostureGameDataFactory>;
                    // Child
                    {
                        editPostureGameDataFactory.show.allRemoveCallBack(this);
                        editPostureGameDataFactory.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is PostureGameDataFactory)
                    {
                        PostureGameDataFactory postureGameDataFactory = data as PostureGameDataFactory;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(postureGameDataFactory, this, ref this.server);
                        }
                        // Child
                        {
                            postureGameDataFactory.gameData.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    if (data is GameData)
                    {
                        return;
                    }
                }
            }
            // gameType
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            // editPostureGameData
            if (data is EditPostureGameDataUI.UIData)
            {
                EditPostureGameDataUI.UIData editPostureGameDataUIData = data as EditPostureGameDataUI.UIData;
                // UI
                {
                    editPostureGameDataUIData.removeCallBackAndDestroy(typeof(EditPostureGameDataUI));
                }
                return;
            }
            // miniGameDataUI
            if (data is MiniGameDataUI.UIData)
            {
                MiniGameDataUI.UIData miniGameDataUIData = data as MiniGameDataUI.UIData;
                // UI
                {
                    miniGameDataUIData.removeCallBackAndDestroy(typeof(MiniGameDataUI));
                }
                return;
            }
            // useRule
            if (data is RequestChangeBoolUI.UIData)
            {
                RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
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
                case UIData.Property.editPostureGameDataFactory:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.editPostureGameData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.miniGameDataUI:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.useRule:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + data + "; " + this);
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
            // editPostureGameDataFactory
            {
                if (wrapProperty.p is EditData<PostureGameDataFactory>)
                {
                    switch ((EditData<PostureGameDataFactory>.Property)wrapProperty.n)
                    {
                        case EditData<PostureGameDataFactory>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<PostureGameDataFactory>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<PostureGameDataFactory>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<PostureGameDataFactory>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<PostureGameDataFactory>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<PostureGameDataFactory>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is PostureGameDataFactory)
                    {
                        switch ((PostureGameDataFactory.Property)wrapProperty.n)
                        {
                            case PostureGameDataFactory.Property.gameData:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case PostureGameDataFactory.Property.useRule:
                                dirty = true;
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
                    if (wrapProperty.p is GameData)
                    {
                        switch ((GameData.Property)wrapProperty.n)
                        {
                            case GameData.Property.gameType:
                                dirty = true;
                                break;
                            case GameData.Property.useRule:
                                break;
                            case GameData.Property.turn:
                                break;
                            case GameData.Property.timeControl:
                                break;
                            case GameData.Property.lastMove:
                                break;
                            case GameData.Property.state:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                }
            }
            // gameType
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            // editPostureGameData
            if (wrapProperty.p is EditPostureGameDataUI.UIData)
            {
                return;
            }
            // miniGameDataUI
            if (wrapProperty.p is MiniGameDataUI.UIData)
            {
                return;
            }
            // useRule
            if (wrapProperty.p is RequestChangeBoolUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region EditGameData

    public void onClickBtnEditGameData()
    {
        Debug.LogError("onClickBtnEditGameData");
        if (this.data != null)
        {
            EditPostureGameDataUI.UIData editPostureGameDataUIData = this.data.editPostureGameData.newOrOld<EditPostureGameDataUI.UIData>();
            {

            }
            this.data.editPostureGameData.v = editPostureGameDataUIData;
        }
        else
        {
            Debug.LogError("postureGameDataFactory null");
        }
    }

    #endregion

}