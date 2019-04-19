using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
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
                    FairyChessGameDataUI fairyChessGameDataUI = null;
                    {
                        FairyChessGameDataUI.UIData fairyChessGameDataUIData = this.data.findDataInParent<FairyChessGameDataUI.UIData>();
                        if (fairyChessGameDataUIData != null)
                        {
                            fairyChessGameDataUI = fairyChessGameDataUIData.findCallBack<FairyChessGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("fairyChessGameDataUIData null");
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
                    if (fairyChessGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform fairyChessTransform = (RectTransform)fairyChessGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (fairyChessTransform != null && boardTransform != null)
                        {
                            Vector2 fairyChessSize = new Vector2(fairyChessTransform.rect.width, fairyChessTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (fairyChessSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                // find scale
                                float scale = 1;
                                {
                                    // find X, Y
                                    float X = 8f;
                                    float Y = 8f;
                                    {
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
                                                    X = 9f;
                                                    Y = 9f;
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown boardIndex: " + Setting.get().boardIndex.v);
                                                break;
                                        }
                                    }
                                    // process
                                    scale = Mathf.Min(Mathf.Abs(boardSize.x / X), Mathf.Abs(boardSize.y / Y));
                                }
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
                            Debug.LogError("fairyChessTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChessGameDataUI or gameDataBoardUI null: " + this);
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

        private FairyChessGameDataUI.UIData fairyChessGameDataUIData = null;
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
                    DataUtils.addParentCallBack(updateData, this, ref this.fairyChessGameDataUIData);
                }
                dirty = true;
                return;
            }
            // Global
            if (data is Global)
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
                if (data is FairyChessGameDataUI.UIData)
                {
                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(fairyChessGameDataUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
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
                    DataUtils.removeParentCallBack(updateData, this, ref this.fairyChessGameDataUIData);
                }
                this.setDataNull(updateData);
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
            // CheckChange
            if (data is GameDataBoardCheckTransformChange<UpdateData>)
            {
                return;
            }
            // Parent
            {
                if (data is FairyChessGameDataUI.UIData)
                {
                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(fairyChessGameDataUIData, this);
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
                if (wrapProperty.p is FairyChessGameDataUI.UIData)
                {
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}