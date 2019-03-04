using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LastMoveCheckChange<K> : Data, ValueChangeCallBack where K : Data
{

    public VP<int> change;

    private void notifyChange()
    {
        this.change.v = this.change.v + 1;
    }

    #region Constructor

    public enum Property
    {
        change
    }

    public LastMoveCheckChange() : base()
    {
        this.change = new VP<int>(this, (byte)Property.change, 0);
    }

    #endregion

    public K data;

    public void setData(K newData)
    {
        if (this.data != newData)
        {
            // remove old
            {
                DataUtils.removeParentCallBack(this.data, this, ref this.gameDataBoardUIData);
            }
            // set new 
            {
                this.data = newData;
                DataUtils.addParentCallBack(this.data, this, ref this.gameDataBoardUIData);
            }
        }
        else
        {
            Debug.LogError("the same: " + this + ", " + data + ", " + newData);
        }
    }

    #region implement callBacks

    private GameDataBoardUI.UIData gameDataBoardUIData = null;

    private GameDataUI.UIData gameDataUIData = null;

    public void onAddCallBack<T>(T data) where T : Data
    {
        if (data is GameDataBoardUI.UIData)
        {
            GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
            // Setting
            {
                Setting.get().addCallBack(this);
            }
            // Parent
            {
                DataUtils.addParentCallBack(gameDataBoardUIData, this, ref this.gameDataUIData);
            }
            // Child
            {
                gameDataBoardUIData.animationManager.allAddCallBack(this);
            }
            this.notifyChange();
            return;
        }
        // Setting
        if (data is Setting)
        {
            this.notifyChange();
            return;
        }
        // Parent
        {
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // Child
                {
                    gameDataUIData.gameData.allAddCallBack(this);
                }
                this.notifyChange();
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Child
                    {
                        gameData.lastMove.allAddCallBack(this);
                    }
                    this.notifyChange();
                    return;
                }
                // Child
                if (data is LastMove)
                {
                    this.notifyChange();
                    return;
                }
            }
        }
        // Child
        {
            if (data is AnimationManager)
            {
                this.notifyChange();
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is GameDataBoardUI.UIData)
        {
            GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
            // Setting
            {
                Setting.get().removeCallBack(this);
            }
            // Parent
            {
                DataUtils.removeParentCallBack(gameDataBoardUIData, this, ref this.gameDataUIData);
            }
            // Child
            {
                gameDataBoardUIData.animationManager.allRemoveCallBack(this);
            }
            this.gameDataBoardUIData = null;
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Parent
        {
            if (data is GameDataUI.UIData)
            {
                GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
                // Child
                {
                    gameDataUIData.gameData.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Child
                    {
                        gameData.lastMove.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is LastMove)
                {
                    return;
                }
            }
        }
        // Child
        {
            if (data is AnimationManager)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is GameDataBoardUI.UIData)
        {
            switch ((GameDataBoardUI.UIData.Property)wrapProperty.n)
            {
                case GameDataBoardUI.UIData.Property.gameData:
                    break;
                case GameDataBoardUI.UIData.Property.animationManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        this.notifyChange();
                    }
                    break;
                case GameDataBoardUI.UIData.Property.sub:
                    break;
                case GameDataBoardUI.UIData.Property.heightWidth:
                    break;
                case GameDataBoardUI.UIData.Property.left:
                    break;
                case GameDataBoardUI.UIData.Property.right:
                    break;
                case GameDataBoardUI.UIData.Property.top:
                    break;
                case GameDataBoardUI.UIData.Property.bottom:
                    break;
                case GameDataBoardUI.UIData.Property.perspective:
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
                case Setting.Property.showLastMove:
                    this.notifyChange();
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
            if (wrapProperty.p is GameDataUI.UIData)
            {
                switch ((GameDataUI.UIData.Property)wrapProperty.n)
                {
                    case GameDataUI.UIData.Property.gameData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            this.notifyChange();
                        }
                        break;
                    case GameDataUI.UIData.Property.board:
                        break;
                    case GameDataUI.UIData.Property.allowLastMove:
                        this.notifyChange();
                        break;
                    case GameDataUI.UIData.Property.hintUI:
                        break;
                    case GameDataUI.UIData.Property.allowInput:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.turn:
                            break;
                        case GameData.Property.timeControl:
                            break;
                        case GameData.Property.lastMove:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                this.notifyChange();
                            }
                            break;
                        case GameData.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is LastMove)
                {
                    switch ((LastMove.Property)wrapProperty.n)
                    {
                        case LastMove.Property.turn:
                            break;
                        case LastMove.Property.gameMove:
                            this.notifyChange();
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
        }
        // Child
        {
            if (wrapProperty.p is AnimationManager)
            {
                switch ((AnimationManager.Property)wrapProperty.n)
                {
                    case AnimationManager.Property.isEnable:
                        break;
                    case AnimationManager.Property.animationProgresses:
                        this.notifyChange();
                        break;
                    case AnimationManager.Property.lastMove:
                        this.notifyChange();
                        break;
                    case AnimationManager.Property.state:
                        this.notifyChange();
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    #endregion

    public static GameMove getLastMove(Data data)
    {
        GameMove gameMove = null;
        if (data != null)
        {
            // GameData allow lastMove?
            Com.MyBool allow = Com.MyBool.None;
            {
                GameDataUI.UIData gameDataUIData = data.findDataInParent<GameDataUI.UIData>();
                if (gameDataUIData != null)
                {
                    allow = gameDataUIData.allowLastMove.v;
                }
                else
                {
                    // Debug.LogError ("gameDataUIData null: ");
                }
            }
            // check active or not
            bool isActive = true;
            {
                switch (allow)
                {
                    case Com.MyBool.None:
                        isActive = Setting.get().showLastMove.v;
                        break;
                    case Com.MyBool.True:
                        isActive = true;
                        break;
                    case Com.MyBool.False:
                        isActive = false;
                        break;
                    default:
                        Debug.LogError("unknown allow: " + allow + "; " + data);
                        break;
                }
            }
            // Process
            if (isActive)
            {
                // get lastMoveAnimation
                bool isOAnimation = false;
                {
                    GameDataBoardUI.UIData gameDataBoardUIData = data.findDataInParent<GameDataBoardUI.UIData>();
                    if (gameDataBoardUIData != null)
                    {
                        AnimationManager animationManager = gameDataBoardUIData.animationManager.v;
                        if (animationManager != null)
                        {
                            isOAnimation = animationManager.isOnAnimation();
                            if (animationManager.state.v == AnimationManager.State.Delay || animationManager.state.v == AnimationManager.State.Remove)
                            {
                                gameMove = animationManager.lastMove.v;
                            }
                        }
                        else
                        {
                            Debug.LogError("animationManager null: " + data);
                        }
                    }
                    else
                    {
                        Debug.LogError("gameDataBoardUIData null: " + data);
                    }
                }
                // get lastMove from gameData
                if (!isOAnimation)
                {
                    // Find gameData
                    GameData gameData = null;
                    {
                        GameDataUI.UIData gameDataUIData = data.findDataInParent<GameDataUI.UIData>();
                        if (gameDataUIData != null)
                        {
                            gameData = gameDataUIData.gameData.v.data;
                        }
                        else
                        {
                            // Debug.LogError ("gameDataUIData null: ");
                        }
                    }
                    // Process
                    if (gameData != null)
                    {
                        LastMove lastMove = gameData.lastMove.v;
                        if (lastMove != null)
                        {
                            gameMove = lastMove.gameMove.v;
                        }
                        else
                        {
                            // Debug.LogError ("lastMove null: " + data);
                        }
                    }
                    else
                    {
                        // Debug.LogError ("gameData null: " + data);
                    }
                }
            }
        }
        else
        {
            Debug.LogError("data null: " + data);
        }
        return gameMove;
    }

}