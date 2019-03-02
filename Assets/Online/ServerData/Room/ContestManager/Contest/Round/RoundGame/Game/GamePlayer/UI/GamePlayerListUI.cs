using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerListUI : UIBehavior<GamePlayerListUI.UIData>, HaveTransformData
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Game>> game;

        public LP<GamePlayerUI.UIData> gamePlayerUIs;

        #region Constructor

        public enum Property
        {
            game,
            gamePlayerUIs
        }

        public UIData() : base()
        {
            this.game = new VP<ReferenceData<Game>>(this, (byte)Property.game, new ReferenceData<Game>(null));
            this.gamePlayerUIs = new LP<GamePlayerUI.UIData>(this, (byte)Property.gamePlayerUIs);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                foreach(GamePlayerUI.UIData gamePlayerUI in this.gamePlayerUIs.vs)
                {
                    if (!isProcess)
                    {
                        isProcess = gamePlayerUI.processEvent(e);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region TransformData

    public TransformData transformData = new TransformData();

    private void updateTransformData()
    {
        this.transformData.update(this.transform);
    }

    public TransformData getTransformData()
    {
        return this.transformData;
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
                    // get old
                    List<GamePlayerUI.UIData> oldGamePlayerUIDatas = new List<GamePlayerUI.UIData>();
                    {
                        oldGamePlayerUIDatas.AddRange(this.data.gamePlayerUIs.vs);
                    }
                    // update
                    {
                        foreach (GamePlayer gamePlayer in game.gamePlayers.vs)
                        {
                            Debug.LogError("update gamePlayer: " + gamePlayer);
                            // Find UI
                            GamePlayerUI.UIData gamePlayerUIData = null;
                            {
                                // Find old
                                if (oldGamePlayerUIDatas.Count > 0)
                                {
                                    gamePlayerUIData = oldGamePlayerUIDatas[0];
                                }
                                // Make new
                                if (gamePlayerUIData == null)
                                {
                                    gamePlayerUIData = new GamePlayerUI.UIData();
                                    {
                                        gamePlayerUIData.uid = this.data.gamePlayerUIs.makeId();
                                    }
                                    this.data.gamePlayerUIs.add(gamePlayerUIData);
                                }
                                else
                                {
                                    oldGamePlayerUIDatas.Remove(gamePlayerUIData);
                                }
                            }
                            // Update
                            {
                                gamePlayerUIData.gamePlayer.v = new ReferenceData<GamePlayer>(gamePlayer);
                            }
                        }
                    }
                    // remove old
                    foreach (GamePlayerUI.UIData oldGamePlayerUIData in oldGamePlayerUIDatas)
                    {
                        this.data.gamePlayerUIs.remove(oldGamePlayerUIData);
                    }
                }
                else
                {
                    Debug.LogError("gamePlayers null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
        updateTransformData();
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public GamePlayerUI gamePlayerPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.game.allAddCallBack(this);
                uiData.gamePlayerUIs.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is GamePlayerUI.UIData)
            {
                GamePlayerUI.UIData gamePlayerUIData = data as GamePlayerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(gamePlayerUIData, gamePlayerPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            // Game
            if (data is Game)
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
            // Child
            {
                uiData.game.allRemoveCallBack(this);
                uiData.gamePlayerUIs.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is GamePlayerUI.UIData)
            {
                GamePlayerUI.UIData gamePlayerUIData = data as GamePlayerUI.UIData;
                // UI
                {
                    gamePlayerUIData.removeCallBackAndDestroy(typeof(GamePlayerUI));
                }
                return;
            }
            // Game
            if (data is Game)
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
                case UIData.Property.gamePlayerUIs:
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
            if (wrapProperty.p is GamePlayerUI.UIData)
            {
                return;
            }
            // Game
            if (wrapProperty.p is Game)
            {
                switch ((Game.Property)wrapProperty.n)
                {
                    case Game.Property.state:
                        break;
                    case Game.Property.gamePlayers:
                        dirty = true;
                        break;
                    case Game.Property.requestDraw:
                        break;
                    case Game.Property.gameData:
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
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}