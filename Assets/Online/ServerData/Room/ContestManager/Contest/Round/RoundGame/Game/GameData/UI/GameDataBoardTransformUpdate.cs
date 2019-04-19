using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

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
                GameDataBoardUI.UIData boardUIData = this.data.board.v;
                if (boardUIData != null)
                {
                    RectTransform boardTransform = null;
                    float heightWidth = 1;
                    float boardLeft = 0;
                    float boardRight = 0;
                    float boardTop = 0;
                    float boardBottom = 0;
                    // find
                    {
                        // boardTransform
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
                        // margin
                        {
                            heightWidth = boardUIData.heightWidth.v;
                            boardLeft = boardUIData.left.v;
                            boardRight = boardUIData.right.v;
                            boardTop = boardUIData.top.v;
                            boardBottom = boardUIData.bottom.v;
                        }
                        // correct
                        if (heightWidth <= 0)
                        {
                            Debug.LogError("heightWidth: " + heightWidth);
                            heightWidth = 1;
                        }
                    }
                    // process
                    if (boardTransform != null)
                    {
                        // find UI Size
                        float rightWidth = this.data.rightWidth.v;
                        float bottomHeight = this.data.bottomHeight.v;
                        // find width, height
                        float width = 480;
                        float height = 480;
                        float gameDataWidth = 480;
                        float gameDataHeight = 480;
                        {
                            RectTransform gameDataTransform = (RectTransform)this.transform;
                            if (gameDataTransform != null)
                            {
                                gameDataWidth = gameDataTransform.rect.width - rightWidth;
                                gameDataHeight = gameDataTransform.rect.height - bottomHeight;
                                // check need other information
                                bool needOtherInformation = this.data.gamePlayerList.v != null || this.data.gameActionsUI.v != null;
                                // set width, height
                                {
                                    // find width
                                    {
                                        // find
                                        float portraitWidth = 0;
                                        float landscapeWidth = 0;
                                        if (needOtherInformation)
                                        {
                                            portraitWidth = Mathf.Min(gameDataWidth - (boardLeft + boardRight), (gameDataHeight - (boardTop + boardBottom) - 120 - 32) / heightWidth);
                                            landscapeWidth = Mathf.Min(gameDataWidth - (boardLeft + boardRight) - 320 - 32, (gameDataHeight - (boardTop + boardBottom) - 16) / heightWidth);
                                        }
                                        else
                                        {
                                            portraitWidth = Mathf.Min(gameDataWidth - (boardLeft + boardRight), (gameDataHeight - (boardTop + boardBottom) - 16) / heightWidth);
                                            landscapeWidth = Mathf.Min(gameDataWidth - (boardLeft + boardRight) - 16, (gameDataHeight - (boardTop + boardBottom) - 16) / heightWidth);
                                        }
                                        // set
                                        if (portraitWidth >= landscapeWidth)
                                        {
                                            boardUIData.screen.v = GameDataBoardUI.UIData.Screen.Portrait;
                                            width = portraitWidth;
                                        }
                                        else
                                        {
                                            boardUIData.screen.v = GameDataBoardUI.UIData.Screen.LandScape;
                                            width = landscapeWidth;
                                        }
                                    }
                                    height = width * heightWidth;
                                }
                            }
                            else
                            {
                                Debug.LogError("gameDataTransform null");
                            }
                        }
                        // find boardRect
                        // Debug.LogError("boardRect: " + width + ", " + height + ", " + bottomHeight + ", " + gameDataWidth + ", " + gameDataHeight);
                        UIRectTransform boardRect = UIRectTransform.CreateCenterRect(width, height, -rightWidth / 2, bottomHeight / 2);
                        {
                            // boardRect.setPosY(-bottomHeight / 2);
                        }
                        // set
                        boardRect.set(boardTransform);
                        // set board dirty
                        {
                            UIUtils.UpdateTransformData(this.data.board.v);
                        }
                    }
                    else
                    {
                        Debug.LogError("boardTransform null");
                    }
                }
                else
                {
                    Debug.LogError("boardUIData null");
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

    private ContestManagerUI.UIData contestManagerUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is GameDataUI.UIData)
        {
            GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
            // Global
            Global.get().addCallBack(this);
            // Setting
            Setting.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(gameDataUIData, this, ref this.contestManagerUIData);
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
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Parent
        {
            if(data is ContestManagerUI.UIData)
            {
                ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                // Child
                {
                    contestManagerUIData.btns.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if(data is ContestManagerBtnUI.UIData)
                {
                    ContestManagerBtnUI.UIData contestManagerBtnUIData = data as ContestManagerBtnUI.UIData;
                    // Child
                    {
                        contestManagerBtnUIData.btnChat.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is ContestManagerBtnChatUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
        }
        // Child
        {
            if (data is GameDataBoardUI.UIData)
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is GameDataUI.UIData)
        {
            GameDataUI.UIData gameDataUIData = data as GameDataUI.UIData;
            // Global
            Global.get().removeCallBack(this);
            // Setting
            Setting.get().removeCallBack(this);
            // Parent
            {
                DataUtils.removeParentCallBack(gameDataUIData, this, ref this.contestManagerUIData);
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
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Parent
        {
            if (data is ContestManagerUI.UIData)
            {
                ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                // Child
                {
                    contestManagerUIData.btns.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is ContestManagerBtnUI.UIData)
                {
                    ContestManagerBtnUI.UIData contestManagerBtnUIData = data as ContestManagerBtnUI.UIData;
                    // Child
                    {
                        contestManagerBtnUIData.btnChat.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is ContestManagerBtnChatUI.UIData)
                {
                    return;
                }
            }
        }
        // Child
        {
            if (data is GameDataBoardUI.UIData)
            {
                return;
            }
            if (data is TransformData)
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
                case GameDataUI.UIData.Property.bottomHeight:
                    dirty = true;
                    break;
                case GameDataUI.UIData.Property.rightWidth:
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
            Global.OnValueTransformChange(wrapProperty, this);
            return;
        }
        // Setting
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    break;
                case Setting.Property.titleTextSize:
                    break;
                case Setting.Property.labelTextSize:
                    break;
                case Setting.Property.buttonSize:
                    break;
                case Setting.Property.itemSize:
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.boardIndex:
                    dirty = true;
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Parent
        {
            if (wrapProperty.p is ContestManagerUI.UIData)
            {
                switch ((ContestManagerUI.UIData.Property)wrapProperty.n)
                {
                    case ContestManagerUI.UIData.Property.contestManager:
                        break;
                    case ContestManagerUI.UIData.Property.sub:
                        break;
                    case ContestManagerUI.UIData.Property.btns:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case ContestManagerUI.UIData.Property.roomChat:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is ContestManagerBtnUI.UIData)
                {
                    switch ((ContestManagerBtnUI.UIData.Property)wrapProperty.n)
                    {
                        case ContestManagerBtnUI.UIData.Property.btnChat:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ContestManagerBtnUI.UIData.Property.btnRoomUser:
                            break;
                        case ContestManagerBtnUI.UIData.Property.btnSetting:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is ContestManagerBtnChatUI.UIData)
                {
                    switch ((ContestManagerBtnChatUI.UIData.Property)wrapProperty.n)
                    {
                        case ContestManagerBtnChatUI.UIData.Property.visibility:
                            dirty = true;
                            break;
                        case ContestManagerBtnChatUI.UIData.Property.style:
                            dirty = true;
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
                    case GameDataBoardUI.UIData.Property.screen:
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