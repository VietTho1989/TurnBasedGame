using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerUI : UIBehavior<GamePlayerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {
        public VP<ReferenceData<GamePlayer>> gamePlayer;

        public VP<InformAvatarUI.UIData> avatar;

        public VP<GamePlayerTimeUI.UIData> time;

        public VP<GamePlayerStateUI.UIData> state;

        public VP<GameState.ResultUI.UIData> result;

        #region Constructor

        public enum Property
        {
            gamePlayer,
            avatar,
            time,
            state,
            result
        }

        public UIData() : base()
        {
            this.gamePlayer = new VP<ReferenceData<GamePlayer>>(this, (byte)Property.gamePlayer, new ReferenceData<GamePlayer>(null));
            this.avatar = new VP<InformAvatarUI.UIData>(this, (byte)Property.avatar, new InformAvatarUI.UIData());
            this.time = new VP<GamePlayerTimeUI.UIData>(this, (byte)Property.time, new GamePlayerTimeUI.UIData());
            this.state = new VP<GamePlayerStateUI.UIData>(this, (byte)Property.state, new GamePlayerStateUI.UIData());
            this.result = new VP<GameState.ResultUI.UIData>(this, (byte)Property.result, new GameState.ResultUI.UIData());
        }

        #endregion

    }

    #endregion

    #region txt, rect

    static GamePlayerUI()
    {
        //rect
        {
            // avatarRect
            {
                // anchoredPosition: (8.0, -8.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (8.0, -44.0); offsetMax: (44.0, -8.0); sizeDelta: (36.0, 36.0);
                avatarRect.anchoredPosition = new Vector3(8.0f, -8.0f, 0.0f);
                avatarRect.anchorMin = new Vector2(0.0f, 1.0f);
                avatarRect.anchorMax = new Vector2(0.0f, 1.0f);
                avatarRect.pivot = new Vector2(0.0f, 1.0f);
                avatarRect.offsetMin = new Vector2(8.0f, -44.0f);
                avatarRect.offsetMax = new Vector2(44.0f, -8.0f);
                avatarRect.sizeDelta = new Vector2(36.0f, 36.0f);
            }
        }
    }

    #endregion

    #region Update

    public Text tvName;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GamePlayer gamePlayer = this.data.gamePlayer.v.data;
                if (gamePlayer != null)
                {
                    // avatar
                    {
                        InformAvatarUI.UIData avatar = this.data.avatar.v;
                        if (avatar != null)
                        {
                            avatar.inform.v = new ReferenceData<GamePlayer.Inform>(gamePlayer.inform.v);
                        }
                        else
                        {
                            Debug.LogError("avatar null: " + this);
                        }
                    }
                    // tvName
                    {
                        if (tvName != null)
                        {
                            tvName.text = gamePlayer.inform.v.getPlayerName();
                        }
                        else
                        {
                            Debug.LogError("tvName null: " + this);
                        }
                    }
                    // result
                    {
                        GameState.ResultUI.UIData resultUIData = this.data.result.v;
                        if (resultUIData != null)
                        {
                            // Find result
                            GameState.Result result = null;
                            {
                                Game game = gamePlayer.findDataInParent<Game>();
                                if (game != null)
                                {
                                    if (game.state.v is GameState.End)
                                    {
                                        GameState.End end = game.state.v as GameState.End;
                                        result = end.findResult(gamePlayer.playerIndex.v);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("game null: " + this);
                                }
                            }
                            // Set
                            resultUIData.result.v = new ReferenceData<GameState.Result>(result);
                        }
                        else
                        {
                            Debug.LogError("resultUIData null: " + this);
                        }
                    }
                    // time
                    {
                        GamePlayerTimeUI.UIData gamePlayerTimeUIData = this.data.time.v;
                        if (gamePlayerTimeUIData != null)
                        {
                            gamePlayerTimeUIData.gamePlayer.v = new ReferenceData<GamePlayer>(gamePlayer);
                        }
                    }
                    // state
                    {
                        GamePlayerStateUI.UIData stateUIData = this.data.state.v;
                        if (stateUIData != null)
                        {
                            stateUIData.state.v = new ReferenceData<GamePlayer.State>(gamePlayer.state.v);
                        }
                        else
                        {
                            Debug.LogError("ui State null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("gamePlayer null");
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

    public InformAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    public Transform gamePlayerTimeUIContainer;
    public GamePlayerTimeUI gamePlayerTimeUIPrefab;

    public GamePlayerStateUI gamePlayerStateUI;

    private GameState.CheckEndResultChange<GamePlayer> checkEndResultChange = new GameState.CheckEndResultChange<GamePlayer>();
    public GameState.ResultUI resultPrefab;
    public Transform resultContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.gamePlayer.allAddCallBack(this);
                uiData.avatar.allAddCallBack(this);
                uiData.time.allAddCallBack(this);
                uiData.state.allAddCallBack(this);
                uiData.result.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            // GamePlayer
            {
                if (data is GamePlayer)
                {
                    GamePlayer gamePlayer = data as GamePlayer;
                    // CheckChange
                    {
                        checkEndResultChange.addCallBack(this);
                        checkEndResultChange.setData(gamePlayer);
                    }
                    // child
                    {
                        gamePlayer.inform.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is GameState.CheckEndResultChange<GamePlayer>)
                {
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is GamePlayer.Inform)
                    {
                        GamePlayer.Inform inform = data as GamePlayer.Inform;
                        // Child
                        {
                            if (inform is Human)
                            {
                                Human human = inform as Human;
                                human.account.allAddCallBack(this);
                            }
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
            if (data is InformAvatarUI.UIData)
            {
                InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(informAvatarUIData, avatarPrefab, this.transform, avatarRect);
                }
                dirty = true;
                return;
            }
            if (data is GamePlayerTimeUI.UIData)
            {
                GamePlayerTimeUI.UIData time = data as GamePlayerTimeUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(time, gamePlayerTimeUIPrefab, gamePlayerTimeUIContainer);
                }
                dirty = true;
                return;
            }
            if (data is GamePlayerStateUI.UIData)
            {
                GamePlayerStateUI.UIData uiState = data as GamePlayerStateUI.UIData;
                // UI
                if (gamePlayerStateUI != null)
                {
                    gamePlayerStateUI.setData(uiState);
                }
                else
                {
                    Debug.LogError("gamePlayerStateUI null");
                }
                return;
            }
            if (data is GameState.ResultUI.UIData)
            {
                GameState.ResultUI.UIData resultUIData = data as GameState.ResultUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(resultUIData, resultPrefab, resultContainer);
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
            // Child
            {
                uiData.gamePlayer.allRemoveCallBack(this);
                uiData.avatar.allRemoveCallBack(this);
                uiData.time.allRemoveCallBack(this);
                uiData.state.allRemoveCallBack(this);
                uiData.result.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            // GamePlayer
            {
                if (data is GamePlayer)
                {
                    GamePlayer gamePlayer = data as GamePlayer;
                    // CheckChange
                    {
                        checkEndResultChange.removeCallBack(this);
                        checkEndResultChange.setData(null);
                    }
                    // child
                    {
                        gamePlayer.inform.allRemoveCallBack(this);
                    }
                    return;
                }
                // CheckChange
                if (data is GameState.CheckEndResultChange<GamePlayer>)
                {
                    return;
                }
                // Child
                {
                    if (data is GamePlayer.Inform)
                    {
                        GamePlayer.Inform inform = data as GamePlayer.Inform;
                        // Child
                        {
                            if (inform is Human)
                            {
                                Human human = inform as Human;
                                human.account.allRemoveCallBack(this);
                            }
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
            if (data is InformAvatarUI.UIData)
            {
                InformAvatarUI.UIData informAvatarUIData = data as InformAvatarUI.UIData;
                // UI
                {
                    informAvatarUIData.removeCallBackAndDestroy(typeof(InformAvatarUI));
                }
                return;
            }
            if (data is GamePlayerTimeUI.UIData)
            {
                GamePlayerTimeUI.UIData time = data as GamePlayerTimeUI.UIData;
                // UI
                {
                    time.removeCallBackAndDestroy(typeof(GamePlayerTimeUI));
                }
                return;
            }
            if (data is GamePlayerStateUI.UIData)
            {
                GamePlayerStateUI.UIData state = data as GamePlayerStateUI.UIData;
                // UI
                if (gamePlayerStateUI != null)
                {
                    if (gamePlayerStateUI.data == state)
                    {
                        gamePlayerStateUI.setData(null);
                    }
                    else
                    {
                        Debug.LogError("why different");
                    }
                }
                else
                {
                    Debug.LogError("gamePlayerStateUI null");
                }
                return;
            }
            if (data is GameState.ResultUI.UIData)
            {
                GameState.ResultUI.UIData resultUIData = data as GameState.ResultUI.UIData;
                // UI
                {
                    resultUIData.removeCallBackAndDestroy(typeof(GameState.ResultUI));
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
                case UIData.Property.gamePlayer:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.avatar:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.time:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.result:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // GamePlayer
            {
                if (wrapProperty.p is GamePlayer)
                {
                    switch ((GamePlayer.Property)wrapProperty.n)
                    {
                        case GamePlayer.Property.playerIndex:
                            dirty = true;
                            break;
                        case GamePlayer.Property.inform:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GamePlayer.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // CheckChange
                if (wrapProperty.p is GameState.CheckEndResultChange<GamePlayer>)
                {
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is GamePlayer.Inform)
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
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
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
            if (wrapProperty.p is InformAvatarUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GamePlayerTimeUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GamePlayerStateUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is GameState.ResultUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}