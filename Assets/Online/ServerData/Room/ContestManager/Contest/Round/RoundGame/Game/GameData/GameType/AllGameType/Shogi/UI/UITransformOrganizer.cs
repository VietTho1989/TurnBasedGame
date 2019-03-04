using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Shogi
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
                    ShogiGameDataUI shogiGameDataUI = null;
                    {
                        ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData>();
                        if (shogiGameDataUIData != null)
                        {
                            shogiGameDataUI = shogiGameDataUIData.findCallBack<ShogiGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("shogiGameDataUIData null");
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
                    if (shogiGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform shogiTransform = (RectTransform)shogiGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (shogiTransform != null && boardTransform != null)
                        {
                            Vector2 shogiSize = new Vector2(shogiTransform.rect.width, shogiTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (shogiSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                float boardSizeX = 9f;
                                float boardSizeY = 9f;
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
                            Debug.LogError("shogiTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("shogiGameDataUI or gameDataBoardUI null: " + this);
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

        private ShogiGameDataUI.UIData shogiGameDataUIData = null;
        private GameDataBoardCheckTransformChange<UpdateData> gameDataBoardCheckTransformChange = new GameDataBoardCheckTransformChange<UpdateData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UpdateData)
            {
                UpdateData updateData = data as UpdateData;
                // CheckChange
                {
                    gameDataBoardCheckTransformChange.addCallBack(this);
                    gameDataBoardCheckTransformChange.setData(updateData);
                }
                // Parent
                {
                    DataUtils.addParentCallBack(updateData, this, ref this.shogiGameDataUIData);
                }
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
                if (data is ShogiGameDataUI.UIData)
                {
                    ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
                    // Child
                    {
                        ShogiGameDataUI shogiGameDataUI = shogiGameDataUIData.findCallBack<ShogiGameDataUI>();
                        if (shogiGameDataUI != null)
                        {
                            shogiGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("shogiGameDataUI null");
                        }
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
                // CheckChange
                {
                    gameDataBoardCheckTransformChange.removeCallBack(this);
                    gameDataBoardCheckTransformChange.setData(null);
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(updateData, this, ref this.shogiGameDataUIData);
                }
                this.setDataNull(updateData);
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckTransformChange<UpdateData>)
            {
                return;
            }
            // Parent
            {
                if (data is ShogiGameDataUI.UIData)
                {
                    ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
                    // Child
                    {
                        ShogiGameDataUI shogiGameDataUI = shogiGameDataUIData.findCallBack<ShogiGameDataUI>();
                        if (shogiGameDataUI != null)
                        {
                            shogiGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("shogiGameDataUI null");
                        }
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
            // CheckChange
            if (wrapProperty.p is GameDataBoardCheckTransformChange<UpdateData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is ShogiGameDataUI.UIData)
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