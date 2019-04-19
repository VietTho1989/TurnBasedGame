using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
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
                    MakrukGameDataUI makrukGameDataUI = null;
                    {
                        MakrukGameDataUI.UIData makrukGameDataUIData = this.data.findDataInParent<MakrukGameDataUI.UIData>();
                        if (makrukGameDataUIData != null)
                        {
                            makrukGameDataUI = makrukGameDataUIData.findCallBack<MakrukGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("makrukGameDataUIData null");
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
                    if (makrukGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform makrukTransform = (RectTransform)makrukGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (makrukTransform != null && boardTransform != null)
                        {
                            Vector2 makrukSize = new Vector2(makrukTransform.rect.width, makrukTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (makrukSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                // find scale
                                float scale = 1;
                                {
                                    // find
                                    float X = 8;
                                    float Y = 8;
                                    float boardIndexDistance = 0;
                                    {
                                        // X, Y
                                        switch (Setting.get().style.v)
                                        {
                                            case Setting.Style.Western:
                                                // nhu default
                                                break;
                                            case Setting.Style.Normal:
                                            default:
                                                {
                                                    X = 9;
                                                    Y = 9;
                                                }
                                                break;
                                        }
                                        // boardDistance
                                        switch ((Setting.get().boardIndex.v))
                                        {
                                            case Setting.BoardIndex.None:
                                                // nhu default
                                                break;
                                            case Setting.BoardIndex.InBoard:
                                                // nhu default
                                                break;
                                            case Setting.BoardIndex.OutBoard:
                                                boardIndexDistance = 1;
                                                break;
                                            default:
                                                Debug.LogError("unknown boardIndex: " + Setting.get().boardIndex.v);
                                                break;
                                        }
                                    }
                                    // process
                                    scale = Mathf.Min(Mathf.Abs(boardSize.x / (X + boardIndexDistance)), Mathf.Abs(boardSize.y / (Y + boardIndexDistance)));
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
                            Debug.LogError("makrukTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("makrukGameDataUI or gameDataBoardUI null: " + this);
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

        private MakrukGameDataUI.UIData makrukGameDataUIData = null;
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
                    DataUtils.addParentCallBack(updateData, this, ref this.makrukGameDataUIData);
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
                if (data is MakrukGameDataUI.UIData)
                {
                    MakrukGameDataUI.UIData makrukGameDataUIData = data as MakrukGameDataUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(makrukGameDataUIData, this);
                    }
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
                    DataUtils.removeParentCallBack(updateData, this, ref this.makrukGameDataUIData);
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
                if (data is MakrukGameDataUI.UIData)
                {
                    MakrukGameDataUI.UIData makrukGameDataUIData = data as MakrukGameDataUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(makrukGameDataUIData, this);
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
                        dirty = true;
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
                if (wrapProperty.p is MakrukGameDataUI.UIData)
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