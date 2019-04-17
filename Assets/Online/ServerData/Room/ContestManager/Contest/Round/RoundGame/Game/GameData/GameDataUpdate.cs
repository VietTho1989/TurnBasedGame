using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TimeControl;

public class GameDataUpdate : UpdateBehavior<GameData>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {

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

    public override void onAddCallBack<T>(T data)
    {
        if (data is GameData)
        {
            GameData gameData = data as GameData;
            // child
            {
                gameData.requestChangeUseRule.allAddCallBack(this);
                gameData.requestChangeBlindFold.allAddCallBack(this);
                gameData.gameType.allAddCallBack(this);
                gameData.timeControl.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is RequestChangeUseRule)
            {
                RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
                // Update
                {
                    UpdateUtils.makeUpdate<RequestChangeUseRuleUpdate, RequestChangeUseRule>(requestChangeUseRule, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is RequestChangeBlindFold)
            {
                RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                // Update
                {
                    UpdateUtils.makeUpdate<RequestChangeBlindFoldUpdate, RequestChangeBlindFold>(requestChangeBlindFold, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is GameType)
            {
                GameType gameType = data as GameType;
                // Update
                {
                    UpdateUtils.makeUpdate<GameTypeUpdate, GameType>(gameType, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is TimeControl.TimeControl)
            {
                TimeControl.TimeControl timeControls = data as TimeControl.TimeControl;
                {
                    UpdateUtils.makeUpdate<TimeControlUpdate, TimeControl.TimeControl>(timeControls, this.transform);
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is GameData)
        {
            GameData gameData = data as GameData;
            // child
            {
                gameData.requestChangeUseRule.allRemoveCallBack(this);
                gameData.requestChangeBlindFold.allRemoveCallBack(this);
                gameData.gameType.allRemoveCallBack(this);
                gameData.timeControl.allRemoveCallBack(this);
            }
            this.setDataNull(gameData);
            return;
        }
        // Child
        {
            if (data is RequestChangeUseRule)
            {
                RequestChangeUseRule requestChangeUseRule = data as RequestChangeUseRule;
                // Update
                {
                    requestChangeUseRule.removeCallBackAndDestroy(typeof(RequestChangeUseRuleUpdate));
                }
                return;
            }
            if (data is RequestChangeBlindFold)
            {
                RequestChangeBlindFold requestChangeBlindFold = data as RequestChangeBlindFold;
                // Update
                {
                    requestChangeBlindFold.removeCallBackAndDestroy(typeof(RequestChangeBlindFoldUpdate));
                }
                return;
            }
            if (data is GameType)
            {
                GameType gameType = data as GameType;
                // Update
                {
                    gameType.removeCallBackAndDestroy(typeof(GameTypeUpdate));
                }
                return;
            }
            if (data is TimeControl.TimeControl)
            {
                TimeControl.TimeControl timeControls = data as TimeControl.TimeControl;
                {
                    timeControls.removeCallBackAndDestroy(typeof(TimeControlUpdate));
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
        if (wrapProperty.p is GameData)
        {
            switch ((GameData.Property)wrapProperty.n)
            {
                case GameData.Property.gameType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case GameData.Property.useRule:
                    break;
                case GameData.Property.requestChangeUseRule:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case GameData.Property.blindFold:
                    break;
                case GameData.Property.requestChangeBlindFold:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case GameData.Property.turn:
                    break;
                case GameData.Property.timeControl:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
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
        // Child
        {
            if (wrapProperty.p is RequestChangeUseRule)
            {
                return;
            }
            if (wrapProperty.p is RequestChangeBlindFold)
            {
                return;
            }
            if (wrapProperty.p is GameType)
            {
                return;
            }
            if (wrapProperty.p is TimeControl.TimeControl)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + "; " + syncs + "; " + this);
    }

    #endregion

}