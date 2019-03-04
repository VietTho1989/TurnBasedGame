using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
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
                    WeiqiGameDataUI weiqiGameDataUI = null;
                    {
                        WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.findDataInParent<WeiqiGameDataUI.UIData>();
                        if (weiqiGameDataUIData != null)
                        {
                            weiqiGameDataUI = weiqiGameDataUIData.findCallBack<WeiqiGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("weiqiGameDataUIData null");
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
                    if (weiqiGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform weiqiTransform = (RectTransform)weiqiGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (weiqiTransform != null && boardTransform != null)
                        {
                            Vector2 weiqiSize = new Vector2(weiqiTransform.rect.width, weiqiTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (weiqiSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                float boardSizeX = 19f;
                                float boardSizeY = 19f;
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
                            Debug.LogError("weiqiTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("weiqiGameDataUI or gameDataBoardUI null: " + this);
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

        private WeiqiGameDataUI.UIData weiqiGameDataUIData = null;
        private GameDataBoardCheckTransformChange<UpdateData> gameDataBoardCheckTransformChange = new GameDataBoardCheckTransformChange<UpdateData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UpdateData)
            {
                UpdateData updateData = data as UpdateData;
                // Global
                Global.get().addCallBack(this);
                // CheckChange
                {
                    gameDataBoardCheckTransformChange.addCallBack(this);
                    gameDataBoardCheckTransformChange.setData(updateData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(updateData, this, ref this.weiqiGameDataUIData);
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
            // CheckChange
            if (data is GameDataBoardCheckTransformChange<UpdateData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is WeiqiGameDataUI.UIData)
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(weiqiGameDataUIData, this);
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
                // CheckChange
                {
                    gameDataBoardCheckTransformChange.removeCallBack(this);
                    gameDataBoardCheckTransformChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(updateData, this, ref this.weiqiGameDataUIData);
                }
                this.setDataNull(updateData);
                return;
            }
            // Global
            if(data is Global)
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
                if (data is WeiqiGameDataUI.UIData)
                {
                    WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(weiqiGameDataUIData, this);
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
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckTransformChange<UpdateData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is WeiqiGameDataUI.UIData)
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