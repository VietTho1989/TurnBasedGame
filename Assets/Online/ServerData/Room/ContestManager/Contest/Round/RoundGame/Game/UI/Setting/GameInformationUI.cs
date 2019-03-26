using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class GameInformationUI : UIBehavior<GameInformationUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Game>> game;

        public VP<GameTypeInformationUI.UIData> gameTypeInformationUIData;

        public VP<RoomSettingUI.UIData> roomSetting;

        #region Constructor

        public enum Property
        {
            game,
            gameTypeInformationUIData,
            roomSetting
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            this.gameTypeInformationUIData = new VP<GameTypeInformationUI.UIData>(this, (byte)Property.gameTypeInformationUIData, new GameTypeInformationUI.UIData());
            this.roomSetting = new VP<RoomSettingUI.UIData>(this, (byte)Property.roomSetting, new RoomSettingUI.UIData());
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // gameTypeInformationUIData
                if (!isProcess)
                {
                    GameTypeInformationUI.UIData gameTypeInformationUIData = this.gameTypeInformationUIData.v;
                    if (gameTypeInformationUIData != null)
                    {
                        isProcess = gameTypeInformationUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gameTypeInformationUIData null");
                    }
                }
                // roomSetting
                if (!isProcess)
                {
                    RoomSettingUI.UIData roomSetting = this.roomSetting.v;
                    if (roomSetting != null)
                    {
                        isProcess = roomSetting.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("roomSetting null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        GameInformationUI gameInformationUI = this.findCallBack<GameInformationUI>();
                        if (gameInformationUI != null)
                        {
                            gameInformationUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("gameInformationUI null");
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    static GameInformationUI()
    {
        txtTitle.add(Language.Type.vi, "Thông Tin Game");
    }

    #endregion

    #region Refresh

    private bool firstSet = false;
    public ScrollRect contentScrollRect;

    public Image bgGameTypeInformation;
    public Image bgRoomSetting;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Game game = this.data.game.v.data;
                if (game != null)
                {
                    // gameTypeInformationUIData
                    {
                        GameTypeInformationUI.UIData gameTypeInformationUIData = this.data.gameTypeInformationUIData.v;
                        if (gameTypeInformationUIData != null)
                        {
                            // find
                            GameType gameType = null;
                            {
                                GameData gameData = game.gameData.v;
                                if (gameData != null)
                                {
                                    gameType = gameData.gameType.v;
                                }
                                else
                                {
                                    Debug.LogError("gameData null");
                                }
                            }
                            // set
                            gameTypeInformationUIData.gameType.v = new ReferenceData<GameType>(gameType);
                        }
                        else
                        {
                            Debug.LogError("gameTypeInformationUIData null");
                        }
                    }
                    // roomSetting
                    {
                        RoomSettingUI.UIData roomSettingUIData = this.data.roomSetting.v;
                        if (roomSettingUIData != null)
                        {
                            // room
                            {
                                Room room = game.findDataInParent<Room>();
                                roomSettingUIData.editRoom.v.origin.v = new ReferenceData<Room>(room);
                            }
                            // roomState
                            {
                                RoomStateUI.UIData roomStateUIData = roomSettingUIData.roomStateUIData.v;
                                if (roomStateUIData != null)
                                {
                                    // find roomState
                                    Room.State roomState = null;
                                    {
                                        Room room = game.findDataInParent<Room>();
                                        if (room != null)
                                        {
                                            roomState = room.state.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("room null");
                                        }
                                    }
                                    // set
                                    roomStateUIData.roomState.v = new ReferenceData<Room.State>(roomState);
                                }
                                else
                                {
                                    Debug.LogError("roomStateUIData null");
                                }
                            }
                            // canEdit?
                            {
                                bool canEdit = false;
                                {
                                    uint profileId = Server.getProfileUserId(game);
                                    if (Room.IsCanEditSetting(game, profileId))
                                    {
                                        canEdit = true;
                                    }
                                }
                                roomSettingUIData.editRoom.v.canEdit.v = canEdit;
                            }
                        }
                        else
                        {
                            Debug.LogError("roomSettingUIData null: " + this);
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // gameTypeInformationUIData
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.gameTypeInformationUIData.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgGameTypeInformation != null)
                            {
                                UIRectTransform.SetPosY(bgGameTypeInformation.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgGameTypeInformation.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgGameTypeInformation null");
                            }
                        }
                        // roomSetting
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.roomSetting.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgRoomSetting != null)
                            {
                                UIRectTransform.SetPosY(bgRoomSetting.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgRoomSetting.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgRoomSetting null");
                            }
                        }
                        // set
                        UIRectTransform.SetHeight(contentContainer, deltaY);
                    }
                    // firstSet
                    {
                        if (firstSet)
                        {
                            firstSet = false;
                            if (contentScrollRect != null)
                            {
                                contentScrollRect.verticalNormalizedPosition = 1;
                            }
                            else
                            {
                                Debug.LogError("contentScrollRect null");
                            }
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Game Information");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("game null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public RectTransform contentContainer;

    public GameTypeInformationUI gameTypeInformationPrefab;
    public RoomSettingUI roomSettingPrefab;

    private RoomCheckChangeAdminChange<Game> roomCheckAdminChange = new RoomCheckChangeAdminChange<Game>();
    private Room room = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.gameTypeInformationUIData.allAddCallBack(this);
                uiData.roomSetting.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            // game
            {
                if (data is Game)
                {
                    Game game = data as Game;
                    // reset
                    {
                        firstSet = true;
                    }
                    // CheckChange
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(game);
                    }
                    // Parent
                    {
                        DataUtils.addParentCallBack(game, this, ref this.room);
                    }
                    // Child
                    {
                        game.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // checkChange
                if (data is RoomCheckChangeAdminChange<Game>)
                {
                    dirty = true;
                    return;
                }
                // Parent
                if (data is Room)
                {
                    dirty = true;
                    return;
                }
                // Child
                if(data is GameData)
                {
                    dirty = true;
                    return;
                }
            }
            // gameTypeInformationUIData
            if(data is GameTypeInformationUI.UIData)
            {
                GameTypeInformationUI.UIData gameTypeInformationUIData = data as GameTypeInformationUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gameTypeInformationUIData, gameTypeInformationPrefab, contentContainer);
                }
                // Child
                {
                    TransformData.AddCallBack(gameTypeInformationUIData, this);
                }
                dirty = true;
                return;
            }
            // roomSettingUIData
            if (data is RoomSettingUI.UIData)
            {
                RoomSettingUI.UIData roomSettingUIData = data as RoomSettingUI.UIData;
                // Child
                {
                    TransformData.AddCallBack(roomSettingUIData, this);
                }
                // UI
                {
                    UIUtils.Instantiate(roomSettingUIData, roomSettingPrefab, contentContainer);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is TransformData)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.game.allRemoveCallBack(this);
                uiData.gameTypeInformationUIData.allRemoveCallBack(this);
                uiData.roomSetting.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        {
            // game
            {
                if (data is Game)
                {
                    Game game = data as Game;
                    // CheckChange
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                    // Parent
                    {
                        DataUtils.removeParentCallBack(game, this, ref this.room);
                    }
                    // Child
                    {
                        game.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // checkChange
                if (data is RoomCheckChangeAdminChange<Game>)
                {
                    return;
                }
                // Parent
                if (data is Room)
                {
                    return;
                }
                // Child
                if(data is GameData)
                {
                    return;
                }
            }
            // gameTypeInformationUIData
            if (data is GameTypeInformationUI.UIData)
            {
                GameTypeInformationUI.UIData gameTypeInformationUIData = data as GameTypeInformationUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(gameTypeInformationUIData, this);
                }
                // UI
                {
                    gameTypeInformationUIData.removeCallBackAndDestroy(typeof(GameTypeInformationUI));
                }
                return;
            }
            // roomSettingUIData
            if (data is RoomSettingUI.UIData)
            {
                RoomSettingUI.UIData roomSettingUIData = data as RoomSettingUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(roomSettingUIData, this);
                }
                // UI
                {
                    roomSettingUIData.removeCallBackAndDestroy(typeof(RoomSettingUI));
                }
                return;
            }
            // Child
            if(data is TransformData)
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
                case UIData.Property.game:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameTypeInformationUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.roomSetting:
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
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // game
            {
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
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Game.Property.history:
                            break;
                        case Game.Property.gameAction:
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
                // checkChange
                if (wrapProperty.p is RoomCheckChangeAdminChange<Game>)
                {
                    return;
                }
                // Parent
                if (wrapProperty.p is Room)
                {
                    switch ((Room.Property)wrapProperty.n)
                    {
                        case Room.Property.roomInform:
                            break;
                        case Room.Property.changeRights:
                            break;
                        case Room.Property.name:
                            break;
                        case Room.Property.password:
                            break;
                        case Room.Property.users:
                            break;
                        case Room.Property.state:
                            dirty = true;
                            break;
                        case Room.Property.requestNewContestManager:
                            break;
                        case Room.Property.contestManagers:
                            break;
                        case Room.Property.timeCreated:
                            break;
                        case Room.Property.chatRoom:
                            break;
                        case Room.Property.allowHint:
                            break;
                        case Room.Property.allowLoadHistory:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if(wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            dirty = true;
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.requestChangeUseRule:
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
                    return;
                }
            }
            // gameTypeInformationUIData
            if(wrapProperty.p is GameTypeInformationUI.UIData)
            {
                return;
            }
            // roomSettingUIData
            if (wrapProperty.p is RoomSettingUI.UIData)
            {
                return;
            }
            // Child
            if(wrapProperty.p is TransformData)
            {
                switch ((TransformData.Property)wrapProperty.n)
                {
                    case TransformData.Property.anchoredPosition:
                        break;
                    case TransformData.Property.anchorMin:
                        break;
                    case TransformData.Property.anchorMax:
                        break;
                    case TransformData.Property.pivot:
                        break;
                    case TransformData.Property.offsetMin:
                        break;
                    case TransformData.Property.offsetMax:
                        break;
                    case TransformData.Property.sizeDelta:
                        break;
                    case TransformData.Property.rotation:
                        break;
                    case TransformData.Property.scale:
                        break;
                    case TransformData.Property.size:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            ContestManagerUI.UIData contestManagerUIData = this.data.findDataInParent<ContestManagerUI.UIData>();
            if (contestManagerUIData != null)
            {
                ContestManagerBtnUI.UIData btns = contestManagerUIData.btns.v;
                if (btns != null)
                {
                    ContestManagerBtnSettingUI.UIData btnSetting = btns.btnSetting.v;
                    if (btnSetting != null) 
                    {
                        btnSetting.visibility.v = ContestManagerBtnSettingUI.UIData.Visibility.Hide;
                    }
                    else
                    {
                        Debug.LogError("btnSetting null");
                    }
                }
                else
                {
                    Debug.LogError("btns null");
                }
            }
            else
            {
                Debug.LogError("contestManagerUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}