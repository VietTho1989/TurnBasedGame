using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataBoardTransformCheckChange<K> : Data, ValueChangeCallBack where K : Data
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

    public GameDataBoardTransformCheckChange() : base()
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
                DataUtils.removeParentCallBack(this.data, this, ref this.gameDataUIData);
            }
            // set new 
            {
                this.data = newData;
                DataUtils.addParentCallBack(this.data, this, ref this.gameDataUIData);
            }
        }
        else
        {
            Debug.LogError("the same: " + this + ", " + data + ", " + newData);
        }
    }

    #region implement callBacks

    private GameDataUI.UIData gameDataUIData = null;

    public void onAddCallBack<T>(T data) where T : Data
    {
        if (data is GameDataUI.UIData)
        {
            GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
            // Child
            {
                gameDataUIData.board.allAddCallBack(this);
            }
            this.notifyChange();
            return;
        }
        // Child
        {
            if (data is GameDataBoardUI.UIData)
            {
                GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                // Child
                {
                    TransformData.AddCallBack(gameDataBoardUIData, this);
                }
                this.notifyChange();
                return;
            }
            // Child
            if (data is TransformData)
            {
                this.notifyChange();
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        // gameDataUIData
        if (data is GameDataUI.UIData)
        {
            GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
            // Child
            {
                gameDataUIData.board.allRemoveCallBack(this);
            }
            // set data null
            {
                if (this.gameDataUIData == gameDataUIData)
                {
                    this.gameDataUIData = null;
                }
            }
            return;
        }
        // Child
        {
            if (data is GameDataBoardUI.UIData)
            {
                GameDataBoardUI.UIData gameDataBoardUIData = data as GameDataBoardUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(gameDataBoardUIData, this);
                }
                return;
            }
            // Child
            if (data is TransformData)
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
        if (wrapProperty.p is GameDataUI.UIData)
        {
            switch ((GameDataUI.UIData.Property)wrapProperty.n)
            {
                case GameDataUI.UIData.Property.gameData:
                    break;
                case GameDataUI.UIData.Property.board:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        this.notifyChange();
                    }
                    break;
                case GameDataUI.UIData.Property.allowLastMove:
                    break;
                case GameDataUI.UIData.Property.hintUI:
                    break;
                case GameDataUI.UIData.Property.allowInput:
                    break;
                case GameDataUI.UIData.Property.requestChangeUseRule:
                    break;
                case GameDataUI.UIData.Property.perspectiveUIData:
                    break;
                case GameDataUI.UIData.Property.gamePlayerList:
                    break;
                case GameDataUI.UIData.Property.gameActionsUI:
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
                switch ((GameDataBoardUI.UIData.Property)wrapProperty.n)
                {
                    case GameDataBoardUI.UIData.Property.gameData:
                        break;
                    case GameDataBoardUI.UIData.Property.animationManager:
                        break;
                    case GameDataBoardUI.UIData.Property.sub:
                        break;
                    case GameDataBoardUI.UIData.Property.heightWidth:
                        break;
                    case GameDataBoardUI.UIData.Property.left:
                        this.notifyChange();
                        break;
                    case GameDataBoardUI.UIData.Property.right:
                        this.notifyChange();
                        break;
                    case GameDataBoardUI.UIData.Property.top:
                        this.notifyChange();
                        break;
                    case GameDataBoardUI.UIData.Property.bottom:
                        this.notifyChange();
                        break;
                    case GameDataBoardUI.UIData.Property.perspective:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is TransformData)
            {
                this.notifyChange();
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}