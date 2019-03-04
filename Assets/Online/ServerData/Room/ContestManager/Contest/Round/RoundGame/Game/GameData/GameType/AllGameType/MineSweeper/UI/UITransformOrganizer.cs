using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace MineSweeper
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
                    MineSweeperGameDataUI mineSweeperGameDataUI = null;
                    {
                        MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData>();
                        if (mineSweeperGameDataUIData != null)
                        {
                            mineSweeperGameDataUI = mineSweeperGameDataUIData.findCallBack<MineSweeperGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("mineSweeperGameDataUIData null");
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
                            Debug.LogError("gameDataBoardUI null");
                        }
                    }
                    if (mineSweeperGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform mineSweeperTransform = (RectTransform)mineSweeperGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (mineSweeperTransform != null && boardTransform != null)
                        {
                            Vector2 mineSweeperSize = new Vector2(mineSweeperTransform.rect.width, mineSweeperTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (mineSweeperSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                float scale = Mathf.Min(Mathf.Abs(boardSize.x / 20f), Mathf.Abs(boardSize.y / 20f));
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
                            Debug.LogError("mineSweeperTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("mineSweeperGameDataUI or gameDataBoardUI null: " + this);
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

        private MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = null;
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
                    DataUtils.addParentCallBack(updateData, this, ref this.mineSweeperGameDataUIData);
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
                if (data is MineSweeperGameDataUI.UIData)
                {
                    MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(mineSweeperGameDataUIData, this);
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
                    DataUtils.removeParentCallBack(updateData, this, ref this.mineSweeperGameDataUIData);
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
                if (data is MineSweeperGameDataUI.UIData)
                {
                    MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
                    // Child
                    {
                        MineSweeperGameDataUI mineSweeperGameDataUI = mineSweeperGameDataUIData.findCallBack<MineSweeperGameDataUI>();
                        if (mineSweeperGameDataUI != null)
                        {
                            mineSweeperGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("mineSweeperGameDataUI null");
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
                if (wrapProperty.p is MineSweeperGameDataUI.UIData)
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