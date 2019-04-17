using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDataCheckChangeRule<K> : Data, ValueChangeCallBack where K : Data
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

    public GameDataCheckChangeRule() : base()
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
                DataUtils.removeParentCallBack(this.data, this, ref this.gameData);
            }
            // set new 
            {
                this.data = newData;
                DataUtils.addParentCallBack(this.data, this, ref this.gameData);
            }
        }
        else
        {
            Debug.LogError("the same: " + this + ", " + data + ", " + newData);
        }
    }

    #region implement callBacks

    private GameData gameData = null;

    public void onAddCallBack<T>(T data) where T : Data
    {
        if (data is GameData)
        {
            // GameData gameData = data as GameData;
            this.notifyChange();
            return;
        }
        Debug.LogError("Don't process : " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is GameData)
        {
            // GameData gameData = data as GameData;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is GameData)
        {
            switch ((GameData.Property)wrapProperty.n)
            {
                case GameData.Property.gameType:
                    break;
                case GameData.Property.useRule:
                    this.notifyChange();
                    break;
                case GameData.Property.requestChangeUseRule:
                    break;
                case GameData.Property.blindFold:
                    break;
                case GameData.Property.requestChangeBlindFold:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}