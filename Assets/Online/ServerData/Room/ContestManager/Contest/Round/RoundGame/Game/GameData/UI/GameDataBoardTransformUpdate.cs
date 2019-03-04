using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameDataBoardTransformUpdate : UpdateBehavior<GameDataUI.UIData>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // find boardTransform
                RectTransform boardTransform = null;
                {
                    GameDataBoardUI.UIData boardUIData = this.data.board.v;
                    if (boardUIData != null)
                    {
                        GameDataBoardUI boardUI = boardUIData.findCallBack<GameDataBoardUI>();
                        if (boardUI != null)
                        {
                            boardTransform = (RectTransform)boardUI.transform;
                        }
                        else
                        {
                            Debug.LogError("boardUI null");
                        }
                    }
                    else
                    {
                        Debug.LogError("boardUIData null");
                    }
                }
                // process
                if (boardTransform != null)
                {
                    // find bottomHeight
                    float bottomHeight = 0;
                    {
                        // find gameBottom transform
                        RectTransform gameBottomTransform = null;
                        {
                            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                            if (gameUIData != null)
                            {
                                GameBottomUI.UIData gameBottomUIData = gameUIData.gameBottom.v;
                                if (gameBottomUIData != null)
                                {
                                    GameBottomUI gameBottomUI = gameBottomUIData.findCallBack<GameBottomUI>();
                                    if (gameBottomUI != null)
                                    {
                                        gameBottomTransform = (RectTransform)gameBottomUI.transform;
                                    }
                                    else
                                    {
                                        Debug.LogError("gameBottomUI null");
                                        // TODO Can kiem tra lai
                                        bottomHeight = 60;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameBottomUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("gameUIData null");
                            }
                        }
                        // process
                        if (gameBottomTransform != null)
                        {
                            bottomHeight = gameBottomTransform.rect.height;
                        }
                        else
                        {
                            Debug.LogError("gameBottomTransform null");
                        }
                    }
                    // find width, height
                    float width = 480;
                    float height = 480;
                    float gameDataWidth = 480;
                    float gameDataHeight = 480;
                    {
                        RectTransform gameDataTransform = (RectTransform)this.transform;
                        if (gameDataTransform != null)
                        {
                            gameDataWidth = gameDataTransform.rect.width;
                            gameDataHeight = gameDataTransform.rect.height - bottomHeight;
                            // check need other information
                            bool needOtherInformation = this.data.gamePlayerList.v != null || this.data.gameActionsUI.v != null;
                            if (needOtherInformation)
                            {
                                // portrait
                                if (gameDataWidth <= gameDataHeight)
                                {
                                    width = Mathf.Min(gameDataWidth, gameDataHeight - 120 - 32);
                                    height = Mathf.Min(gameDataWidth, gameDataHeight - 120 - 32);
                                }
                                // landscape
                                else
                                {
                                    width = Mathf.Min(gameDataWidth - 360 - 32, gameDataHeight - 16);
                                    height = Mathf.Min(gameDataWidth - 360 - 32, gameDataHeight - 16);
                                }
                            }
                            else
                            {
                                width = Mathf.Min(gameDataWidth, gameDataHeight - 16);
                                height = Mathf.Min(gameDataWidth, gameDataHeight - 16);
                            }
                        }
                        else
                        {
                            Debug.LogError("gameDataTransform null");
                        }
                    }
                    // find boardRect
                    Debug.LogError("boardRect: " + width + ", " + height + ", " + bottomHeight + ", " + gameDataWidth + ", " + gameDataHeight);
                    UIRectTransform boardRect = UIRectTransform.CreateCenterRect(width, height);
                    {
                        boardRect.setPosY(-bottomHeight/2);
                    }
                    // set
                    boardRect.set(boardTransform);
                }
                else
                {
                    Debug.LogError("boardTransform null");
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

    private GameUI.UIData gameUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is GameDataUI.UIData)
        {
            GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
            // Global
            Global.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(gameDataUIData, this, ref this.gameUIData);
            }
            // Child
            {
                gameDataUIData.board.allAddCallBack(this);
                TransformData.AddCallBack(gameDataUIData, this);
            }
            dirty = true;
            return;
        }
        // Global
        if(data is Global)
        {
            dirty = true;
            return;
        }
        // Parent
        {
            if(data is GameUI.UIData)
            {
                GameUI.UIData gameUIData = data as GameUI.UIData;
                // Child
                {
                    gameUIData.gameBottom.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if(data is GameBottomUI.UIData)
                {
                    GameBottomUI.UIData gameBottomUIData = data as GameBottomUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(gameBottomUIData, this);
                    }
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                if(data is GameDataBoardUI.UIData)
                {
                    dirty = true;
                    return;
                }
                if (data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is GameDataUI.UIData)
        {
            GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
            // Global
            Global.get().removeCallBack(this);
            // Parent
            {
                DataUtils.removeParentCallBack(gameDataUIData, this, ref this.gameUIData);
            }
            // Child
            {
                gameDataUIData.board.allRemoveCallBack(this);
                TransformData.RemoveCallBack(gameDataUIData, this);
            }
            this.setDataNull(gameDataUIData);
            return;
        }
        // Global
        if (data is Global)
        {
            return;
        }
        // Parent
        {
            if (data is GameUI.UIData)
            {
                GameUI.UIData gameUIData = data as GameUI.UIData;
                // Child
                {
                    gameUIData.gameBottom.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is GameBottomUI.UIData)
                {
                    GameBottomUI.UIData gameBottomUIData = data as GameBottomUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(gameBottomUIData, this);
                    }
                    return;
                }
            }
            // Child
            {
                if(data is GameDataBoardUI.UIData)
                {
                    return;
                }
                if (data is TransformData)
                {
                    return;
                }
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
        if (wrapProperty.p is GameDataUI.UIData)
        {
            switch ((GameDataUI.UIData.Property)wrapProperty.n)
            {
                case GameDataUI.UIData.Property.gameData:
                    break;
                case GameDataUI.UIData.Property.board:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
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
                    dirty = true;
                    break;
                case GameDataUI.UIData.Property.gameActionsUI:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Global
        if (wrapProperty.p is Global)
        {
            switch ((Global.Property)wrapProperty.n)
            {
                case Global.Property.networkReachability:
                    break;
                case Global.Property.deviceOrientation:
                    dirty = true;
                    break;
                case Global.Property.screenOrientation:
                    dirty = true;
                    break;
                case Global.Property.width:
                    dirty = true;
                    break;
                case Global.Property.height:
                    dirty = true;
                    break;
                case Global.Property.screenWidth:
                    dirty = true;
                    break;
                case Global.Property.screenHeight:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is GameUI.UIData)
            {
                switch ((GameUI.UIData.Property)wrapProperty.n)
                {
                    case GameUI.UIData.Property.game:
                        break;
                    case GameUI.UIData.Property.isReplay:
                        break;
                    case GameUI.UIData.Property.gameDataUI:
                        break;
                    case GameUI.UIData.Property.gameBottom:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case GameUI.UIData.Property.undoRedoRequestUIData:
                        break;
                    case GameUI.UIData.Property.requestDraw:
                        break;
                    case GameUI.UIData.Property.gameChatRoom:
                        break;
                    case GameUI.UIData.Property.gameHistoryUIData:
                        break;
                    case GameUI.UIData.Property.stateUI:
                        break;
                    case GameUI.UIData.Property.saveUIData:
                        break;
                    default:
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is GameBottomUI.UIData)
                {
                    return;
                }
            }
        }
        // Child
        {
            if(wrapProperty.p is GameDataBoardUI.UIData)
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
                        dirty = true;
                        break;
                    case GameDataBoardUI.UIData.Property.left:
                        dirty = true;
                        break;
                    case GameDataBoardUI.UIData.Property.right:
                        dirty = true;
                        break;
                    case GameDataBoardUI.UIData.Property.top:
                        dirty = true;
                        break;
                    case GameDataBoardUI.UIData.Property.bottom:
                        dirty = true;
                        break;
                    case GameDataBoardUI.UIData.Property.perspective:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is TransformData)
            {
                switch ((TransformData.Property)wrapProperty.n)
                {
                    case TransformData.Property.anchoredPosition:
                        break;
                    case TransformData.Property.anchorMin:
                        break;
                    case TransformData.Property.anchorMax:
                        break;
                    case TransformData.Property.pivot:
                        break;
                    case TransformData.Property.offsetMin:
                        break;
                    case TransformData.Property.offsetMax:
                        break;
                    case TransformData.Property.sizeDelta:
                        break;
                    case TransformData.Property.rotation:
                        break;
                    case TransformData.Property.scale:
                        break;
                    case TransformData.Property.size:
                        dirty = true;
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