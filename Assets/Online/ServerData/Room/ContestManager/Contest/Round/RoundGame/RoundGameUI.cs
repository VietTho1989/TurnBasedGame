using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RoundGameUI : UIBehavior<RoundGameUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RoundGame>> roundGame;

            public VP<GameUI.UIData> gameUIData;

            #region Constructor

            public enum Property
            {
                roundGame,
                gameUIData
            }

            public UIData() : base()
            {
                this.roundGame = new VP<ReferenceData<RoundGame>>(this, (byte)Property.roundGame, new ReferenceData<RoundGame>(null));
                this.gameUIData = new VP<GameUI.UIData>(this, (byte)Property.gameUIData, new GameUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // gameUIData
                    if (!isProcess)
                    {
                        GameUI.UIData gameUIData = this.gameUIData.v;
                        if (gameUIData != null)
                        {
                            isProcess = gameUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("gameUIData null: " + this);
                        }
                    }
                }
                return isProcess;
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
                    RoundGame roundGame = this.data.roundGame.v.data;
                    if (roundGame != null)
                    {
                        // gameUIData
                        {
                            GameUI.UIData gameUIData = this.data.gameUIData.v;
                            if (gameUIData != null)
                            {
                                gameUIData.game.v = new ReferenceData<Game>(roundGame.game.v);
                            }
                            else
                            {
                                Debug.LogError("gameUIData null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("roundGame null: " + this);
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
            return true;
        }

        #endregion

        #region implement callBacks

        public GameUI gamePrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.roundGame.allAddCallBack(this);
                    uiData.gameUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is RoundGame)
                {
                    dirty = true;
                    return;
                }
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(gameUIData, gamePrefab, this.transform, UIConstants.FullParent);
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
                    uiData.roundGame.allRemoveCallBack(this);
                    uiData.gameUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is RoundGame)
                {
                    return;
                }
                if (data is GameUI.UIData)
                {
                    GameUI.UIData gameUIData = data as GameUI.UIData;
                    // UI
                    {
                        gameUIData.removeCallBackAndDestroy(typeof(GameUI));
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
                    case UIData.Property.roundGame:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.gameUIData:
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
                if (wrapProperty.p is RoundGame)
                {
                    switch ((RoundGame.Property)wrapProperty.n)
                    {
                        case RoundGame.Property.index:
                            break;
                        case RoundGame.Property.playerInTeam:
                            break;
                        case RoundGame.Property.playerInGame:
                            break;
                        case RoundGame.Property.game:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is GameUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}