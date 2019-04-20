using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
    public class UITransformOrganizer : UpdateBehavior<UITransformOrganizer.UpdateData>
    {

        #region UpdateData

        public class UpdateData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UpdateData() : base()
            {

            }

            #endregion

        }

        #endregion

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    GomokuGameDataUI gomokuGameDataUI = null;
                    {
                        GomokuGameDataUI.UIData gomokuGameDataUIData = this.data.findDataInParent<GomokuGameDataUI.UIData>();
                        if (gomokuGameDataUIData != null)
                        {
                            gomokuGameDataUI = gomokuGameDataUIData.findCallBack<GomokuGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("gomokuGameDataUIData null");
                        }
                    }
                    GameDataBoardUI gameDataBoardUI = null;
                    GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData>();
                    {
                        if (gameDataBoardUIData != null)
                        {
                            gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    if (gomokuGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform gomokuTransform = (RectTransform)gomokuGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (gomokuTransform != null && boardTransform != null)
                        {
                            Vector2 gomokuSize = new Vector2(gomokuTransform.rect.width, gomokuTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (gomokuSize != null && boardSize != null)
                            {
                                if (gomokuSize != Vector2.zero && boardSize != Vector2.zero)
                                {
                                    // find boardSize
                                    float boardSizeX = 19f;
                                    float boardSizeY = 19f;
                                    {
                                        // Find gomoku
                                        /*Gomoku gomoku = null;
                                        {
                                            GameData gameData = gomokuGameDataUIData.gameData.v.data;
                                            if (gameData != null) {
                                                if (gameData.gameType.v != null && gameData.gameType.v is Gomoku) {
                                                    gomoku = gameData.gameType.v as Gomoku;
                                                }
                                            } else {
                                                Debug.LogError ("gameData null: " + this);
                                            }
                                        }
                                        // Process
                                        if (gomoku != null) {
                                            boardSizeX = Mathf.Clamp (gomoku.boardSize.v, Gomoku.MinBoardSize, Gomoku.MaxBoardSize);
                                            boardSizeY = gomoku.boardSize.v;
                                        } else {
                                            Debug.LogError ("gomoku null: " + this);
                                        }*/
                                        switch (Setting.get().boardIndex.v)
                                        {
                                            case Setting.BoardIndex.None:
                                                // nhu default
                                                break;
                                            case Setting.BoardIndex.InBoard:
                                                // nhu default
                                                break;
                                            case Setting.BoardIndex.OutBoard:
                                                {
                                                    boardSizeX = 20f;
                                                    boardSizeY = 20f;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown boardIndex: " + Setting.get().boardIndex.v);
                                                break;
                                        }
                                    }
                                    float scale = Mathf.Min(Mathf.Abs(boardSize.x / boardSizeX), Mathf.Abs(boardSize.y / boardSizeY));
                                    // new scale
                                    Vector3 newLocalScale = new Vector3();
                                    {
                                        Vector3 currentLocalScale = this.transform.localScale;
                                        // x
                                        newLocalScale.x = scale;
                                        // y
                                        newLocalScale.y = (gameDataBoardUIData.perspective.v.playerView.v == 0 ? 1 : -1) * scale;
                                        // z
                                        newLocalScale.z = 1;
                                    }
                                    this.transform.localScale = newLocalScale;
                                }
                                else
                                {
                                    Debug.LogError("why transform zero");
                                }
                            }
                            else
                            {
                                Debug.LogError("gomokuSize, boardSize null");
                            }
                        }
                        else
                        {
                            Debug.LogError("gomokuTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("gomokuGameDataUI or gameDataBoardUI null: " + this);
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

        private GomokuGameDataUI.UIData gomokuGameDataUIData = null;
        private GameDataBoardCheckTransformChange<UpdateData> gameDataBoardCheckTransformChange = new GameDataBoardCheckTransformChange<UpdateData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UpdateData)
            {
                UpdateData updateData = data as UpdateData;
                // Global
                Global.get().addCallBack(this);
                // Setting
                Setting.get().addCallBack(this);
                // CheckChange
                {
                    gameDataBoardCheckTransformChange.addCallBack(this);
                    gameDataBoardCheckTransformChange.setData(updateData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(updateData, this, ref this.gomokuGameDataUIData);
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
            // CheckChange
            if (data is GameDataBoardCheckTransformChange<UpdateData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is GomokuGameDataUI.UIData)
                {
                    GomokuGameDataUI.UIData gomokuGameDataUIData = data as GomokuGameDataUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(gomokuGameDataUIData, this);
                        gomokuGameDataUIData.gameData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is TransformData)
                    {
                        dirty = true;
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            // Child
                            {
                                gameData.gameType.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is GameType)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UpdateData)
            {
                UpdateData updateData = data as UpdateData;
                // Global
                Global.get().removeCallBack(this);
                // Setting
                Setting.get().removeCallBack(this);
                // CheckChange
                {
                    gameDataBoardCheckTransformChange.removeCallBack(this);
                    gameDataBoardCheckTransformChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(updateData, this, ref this.gomokuGameDataUIData);
                }
                this.setDataNull(updateData);
                return;
            }
            // Global
            if(data is Global)
            {
                return;
            }
            // Setting
            if(data is Setting)
            {
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckTransformChange<UpdateData>)
            {
                return;
            }
            // Parent
            {
                if (data is GomokuGameDataUI.UIData)
                {
                    GomokuGameDataUI.UIData gomokuGameDataUIData = data as GomokuGameDataUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(gomokuGameDataUIData, this);
                        gomokuGameDataUIData.gameData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is TransformData)
                    {
                        return;
                    }
                    // GameData
                    {
                        if (data is GameData)
                        {
                            GameData gameData = data as GameData;
                            // Child
                            {
                                gameData.gameType.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is GameType)
                        {
                            return;
                        }
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
            if (wrapProperty.p is UpdateData)
            {
                switch ((UpdateData.Property)wrapProperty.n)
                {
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
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckTransformChange<UpdateData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is GomokuGameDataUI.UIData)
                {
                    switch ((GomokuGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case GomokuGameDataUI.UIData.Property.gameData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GomokuGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case GomokuGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case GomokuGameDataUI.UIData.Property.board:
                            break;
                        case GomokuGameDataUI.UIData.Property.lastMove:
                            break;
                        case GomokuGameDataUI.UIData.Property.showHint:
                            break;
                        case GomokuGameDataUI.UIData.Property.inputUI:
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is TransformData)
                    {
                        dirty = true;
                        return;
                    }
                    // GameData
                    {
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
                        // Child
                        if (wrapProperty.p is GameType)
                        {
                            if (wrapProperty.p is Gomoku)
                            {
                                switch ((Gomoku.Property)wrapProperty.n)
                                {
                                    case Gomoku.Property.boardSize:
                                        dirty = true;
                                        break;
                                    case Gomoku.Property.gs:
                                        break;
                                    case Gomoku.Property.player:
                                        break;
                                    case Gomoku.Property.winningPlayer:
                                        break;
                                    case Gomoku.Property.lastMove:
                                        break;
                                    case Gomoku.Property.winSize:
                                        break;
                                    case Gomoku.Property.winCoord:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}