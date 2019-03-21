using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewSaveGameUI : UIBehavior<ViewSaveGameUI.UIData>
{

    #region UIData

    public class UIData : ViewSaveDataUI.UIData.Sub
    {

        public VP<ReferenceData<Game>> game;

        public VP<GameDataUI.UIData> gameDataUIData;

        public VP<ViewSaveGameHistoryUI.UIData> history;

        #region Constructor

        public enum Property
        {
            game,
            gameDataUIData,
            history
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            // gameUIData
            {
                this.gameDataUIData = new VP<GameDataUI.UIData>(this, (byte)Property.gameDataUIData, new GameDataUI.UIData());
                // child
                {
                    this.gameDataUIData.v.hintUI.v = null;
                    this.gameDataUIData.v.allowInput.v = false;
                    this.gameDataUIData.v.informGameMessage.v = null;
                }
                this.gameDataUIData.v.type.v = GameDataUI.UIData.Type.ViewSave;
                this.gameDataUIData.v.bottomHeight.v = 0;
            }
            this.history = new VP<ViewSaveGameHistoryUI.UIData>(this, (byte)Property.history, new ViewSaveGameHistoryUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.Game;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // history
                if (!isProcess)
                {
                    ViewSaveGameHistoryUI.UIData history = this.history.v;
                    if (history != null)
                    {
                        isProcess = history.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("history null: " + this);
                    }
                }
                // gameDataUIData
                if (!isProcess)
                {
                    GameDataUI.UIData gameDataUIData = this.gameDataUIData.v;
                    if (gameDataUIData != null)
                    {
                        isProcess = gameDataUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("gameDataUIData null: " + this);
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    static ViewSaveGameUI()
    {
        // rect
        {
            // viewSaveGameHistoryRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 0.0); pivot: (0.5, 0.0);
                // offsetMin: (0.0, 0.0); offsetMax: (0.0, 75.0); sizeDelta: (0.0, 75.0);
                viewSaveGameHistoryRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                viewSaveGameHistoryRect.anchorMin = new Vector2(0.0f, 0.0f);
                viewSaveGameHistoryRect.anchorMax = new Vector2(1.0f, 0.0f);
                viewSaveGameHistoryRect.pivot = new Vector2(0.5f, 0.0f);
                viewSaveGameHistoryRect.offsetMin = new Vector2(0.0f, 0.0f);
                viewSaveGameHistoryRect.offsetMax = new Vector2(0.0f, 60.0f);
                viewSaveGameHistoryRect.sizeDelta = new Vector2(0.0f, 60.0f);
            }
        }
    }

    #endregion

    #region Refresh

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
                    // gameUIData
                    {
                        if (this.data.gameDataUIData.v != null)
                        {
                            this.data.gameDataUIData.v.gameData.v = new ReferenceData<GameData>(game.gameData.v);
                        }
                    }
                    // history
                    {
                        ViewSaveGameHistoryUI.UIData viewSaveGameHistoryUIData = this.data.history.v;
                        if (viewSaveGameHistoryUIData != null)
                        {
                            viewSaveGameHistoryUIData.history.v = new ReferenceData<History>(game.history.v);
                        }
                        else
                        {
                            Debug.LogError("viewSaveGameHistoryUIData null: " + this);
                        }
                    }
                    // siblingIndex
                    {
                        UIRectTransform.SetSiblingIndex(this.data.gameDataUIData.v, 0);
                        UIRectTransform.SetSiblingIndex(this.data.history.v, 1);
                    }
                }
                else
                {
                    Debug.LogError("game null: " + this);
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

    public GameDataUI gameDataUIDataPrefab;
    private static readonly UIRectTransform gameDataUIDataRect = UIRectTransform.CreateFullRect(0, 0, 0, 60);

    public ViewSaveGameHistoryUI viewSaveGameHistoryPrefab;
    private static readonly UIRectTransform viewSaveGameHistoryRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.gameDataUIData.allAddCallBack(this);
                uiData.history.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Game)
            {
                dirty = true;
                return;
            }
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gameDataUIData, gameDataUIDataPrefab, this.transform, gameDataUIDataRect);
                }
                dirty = true;
                return;
            }
            if (data is ViewSaveGameHistoryUI.UIData)
            {
                ViewSaveGameHistoryUI.UIData viewSaveGameHistoryUIData = data as ViewSaveGameHistoryUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(viewSaveGameHistoryUIData, viewSaveGameHistoryPrefab, this.transform, viewSaveGameHistoryRect);
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
                uiData.game.allRemoveCallBack(this);
                uiData.gameDataUIData.allRemoveCallBack(this);
                uiData.history.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is Game)
            {
                return;
            }
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // UI
                {
                    gameDataUIData.removeCallBackAndDestroy(typeof(GameDataUI));
                }
                return;
            }
            if (data is ViewSaveGameHistoryUI.UIData)
            {
                ViewSaveGameHistoryUI.UIData viewSaveGameHistoryUIData = data as ViewSaveGameHistoryUI.UIData;
                // UI
                {
                    viewSaveGameHistoryUIData.removeCallBackAndDestroy(typeof(ViewSaveGameHistoryUI));
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
                case UIData.Property.game:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.gameDataUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.history:
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
                        dirty = true;
                        break;
                    case Game.Property.history:
                        dirty = true;
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
            if (wrapProperty.p is GameDataUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ViewSaveGameHistoryUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}