using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Hint
{
    public class PreventAINullUpdate : UpdateBehavior<HintUI.UIData>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // find gameType
                    GameType gameType = null;
                    {
                        GameData gameData = this.data.gameData.v.data;
                        if (gameData != null)
                        {
                            gameType = gameData.gameType.v;
                        }
                        else
                        {
                            Debug.LogError("gameData null: " + this);
                        }
                    }
                    if (gameType != null)
                    {
                        // check need new ai
                        bool needNewAI = true;
                        {
                            if (this.data.ai.v != null)
                            {
                                if (this.data.ai.v.getType() == gameType.getType())
                                {
                                    needNewAI = false;
                                }
                            }
                        }
                        // Process
                        if (needNewAI)
                        {
                            Computer.AI newAI = Computer.AI.makeDefaultAI(gameType.getType());
                            {
                                newAI.uid = this.data.ai.makeId();
                            }
                            this.data.ai.v = newAI;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("gameType null: " + this);
                        this.data.ai.v = null;
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is HintUI.UIData)
            {
                HintUI.UIData hintUIData = data as HintUI.UIData;
                // Child
                {
                    hintUIData.gameData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is HintUI.UIData)
            {
                HintUI.UIData hintUIData = data as HintUI.UIData;
                // Child
                {
                    hintUIData.gameData.allRemoveCallBack(this);
                }
                this.setDataNull(hintUIData);
                return;
            }
            // Child
            {
                if (data is GameData)
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
            if (wrapProperty.p is HintUI.UIData)
            {
                switch ((HintUI.UIData.Property)wrapProperty.n)
                {
                    case HintUI.UIData.Property.gameData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case HintUI.UIData.Property.autoHint:
                        break;
                    case HintUI.UIData.Property.state:
                        break;
                    case HintUI.UIData.Property.ai:
                        dirty = true;
                        break;
                    case HintUI.UIData.Property.editHintAIUIData:
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
                            dirty = true;
                            break;
                        case GameData.Property.useRule:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}