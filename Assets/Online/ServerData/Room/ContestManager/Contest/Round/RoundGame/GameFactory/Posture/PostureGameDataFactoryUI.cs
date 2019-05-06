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

        #region Constructor

        public enum Property
        {
            editPostureGameDataFactory,
            gameType,
            editPostureGameData,
            miniGameDataUI
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
        }

        #endregion

        public override GameDataFactory.Type getType()
        {
            return GameDataFactory.Type.Posture;
        }

        public override bool processEvent(Event e)
        {
            // Debug.LogError("processEvent: " + e + "; " + this);
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
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        PostureGameDataFactoryUI postureGameDataFactoryUI = this.findCallBack<PostureGameDataFactoryUI>();
                        if (postureGameDataFactoryUI != null)
                        {
                            isProcess = postureGameDataFactoryUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("postureGameDataFactoryUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Posture Game Data Factory");

    public Text lbGameType;
    private static readonly TxtLanguage txtGameType = new TxtLanguage("Game type");

    public Text tvEdit;
    private static readonly TxtLanguage txtEdit = new TxtLanguage("Edit");

    static PostureGameDataFactoryUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Cách tạo thế cờ");
            txtGameType.add(Language.Type.vi, "Loại game");
            txtEdit.add(Language.Type.vi, "Chỉnh sửa");
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
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editPostureGameDataFactory);
                        // requests
                        {
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editPostureGameDataFactory);
                            // set origin
                            {
                                // gameType
                                {
                                    RequestChangeEnumUI.RefreshOptions(this.data.gameType.v, GameType.GetEnableTypeString());
                                    RequestChange.RefreshUI(this.data.gameType.v, editPostureGameDataFactory, serverState, needReset, editData => GameType.getEnableIndex(editData.getGameTypeType()));
                                }
                            }
                            needReset = false;
                        }
                        // miniGameDatas
                        {
                            MiniGameDataUI.UIData miniGameDataUIData = this.data.miniGameDataUI.v;
                            if (miniGameDataUIData != null)
                            {
                                PostureGameDataFactory show = editPostureGameDataFactory.show.v.data;
                                if (show != null)
                                {
                                    miniGameDataUIData.gameData.v = new ReferenceData<GameData>(show.gameData.v);
                                }
                                else
                                {
                                    Debug.LogError("show null");
                                }
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
                                editPostureGameDataUIData.postureGameDataFactory.v = new ReferenceData<PostureGameDataFactory>(editPostureGameDataFactory.show.v.data);
                            }
                            else
                            {
                                Debug.LogError("editPostureGameDataUIData null: " + this);
                            }
                        }
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
                // UI
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                    // gameType
                    UIUtils.SetLabelContentPosition(lbGameType, this.data.gameType.v, ref deltaY);
                    // miniGameDataUIData
                    {
                        UIRectTransform.SetPosY(this.data.miniGameDataUI.v, deltaY + UIConstants.DefaultMiniGameDataUIPadding);
                        // btnEdit
                        {
                            if (btnEdit != null)
                            {
                                UIRectTransform.SetPosY((RectTransform)btnEdit.transform, deltaY + (UIConstants.DefaultMiniGameDataUISize - 50) / 2.0f);
                            }
                            else
                            {
                                Debug.LogError("btnEdit null");
                            }
                        }
                        deltaY += UIConstants.DefaultMiniGameDataUISize;
                    }
                    // set height
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get();
                        Setting.get().setTitleTextSize(lbTitle);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (lbGameType != null)
                    {
                        lbGameType.text = txtGameType.get();
                        Setting.get().setLabelTextSize(lbGameType);
                    }
                    else
                    {
                        Debug.LogError("gameType null: " + this);
                    }
                    if (tvEdit != null)
                    {
                        tvEdit.text = txtEdit.get();
                    }
                    else
                    {
                        Debug.LogError("tvEdit null: " + this);
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

    public RequestChangeEnumUI requestEnumPrefab;

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
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
                    dirty = true;
                    break;
                case Setting.Property.itemSize:
                    dirty = true;
                    break;
                case Setting.Property.confirmQuit:
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
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region EditGameData

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnEdit, onClickBtnEditGameData);
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
                    case KeyCode.E:
                        {
                            if (btnEdit != null && btnEdit.gameObject.activeInHierarchy && btnEdit.interactable)
                            {
                                this.onClickBtnEditGameData();
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