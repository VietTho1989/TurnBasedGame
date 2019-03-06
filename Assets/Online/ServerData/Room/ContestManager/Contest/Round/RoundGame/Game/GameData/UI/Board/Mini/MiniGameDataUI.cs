using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameDataUI : UIBehavior<MiniGameDataUI.UIData>
{

    #region UIData

    public class UIData : Data
    {
        public VP<ReferenceData<GameData>> gameData;

        public VP<GameDataBoardUI.UIData> board;

        #region Constructor

        public enum Property
        {
            gameData,
            board
        }

        public UIData() : base()
        {
            this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
            // Board
            {
                GameDataBoardUI.UIData board = new GameDataBoardUI.UIData();
                {

                }
                this.board = new VP<GameDataBoardUI.UIData>(this, (byte)Property.board, board);
            }
        }

        #endregion
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
                GameData gameData = this.data.gameData.v.data;
                if (gameData != null)
                {
                    // board
                    {
                        GameDataBoardUI.UIData board = this.data.board.v;
                        if (board != null)
                        {
                            board.gameData.v = new ReferenceData<GameData>(gameData);
                        }
                        else
                        {
                            Debug.LogError("board null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("gameData null: " + this);
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

    public GameDataBoardUI gameDataBoardUIPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.board.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is GameDataBoardUI.UIData)
            {
                GameDataBoardUI.UIData boardUIData = data as GameDataBoardUI.UIData;
                {
                    UIUtils.Instantiate(boardUIData, gameDataBoardUIPrefab, this.transform);
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
                uiData.board.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is GameDataBoardUI.UIData)
            {
                GameDataBoardUI.UIData boardUIData = data as GameDataBoardUI.UIData;
                {
                    boardUIData.removeCallBackAndDestroy(typeof(GameDataBoardUI));
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
                case UIData.Property.gameData:
                    {
                        dirty = true;
                    }
                    break;
                case UIData.Property.board:
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
            if (wrapProperty.p is GameDataBoardUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion
}