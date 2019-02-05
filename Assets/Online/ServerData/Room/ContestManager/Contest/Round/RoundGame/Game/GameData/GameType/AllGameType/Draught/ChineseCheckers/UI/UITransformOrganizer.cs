using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace ChineseCheckers
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
                    ChineseCheckersGameDataUI chineseCheckersGameDataUI = null;
                    {
                        ChineseCheckersGameDataUI.UIData chineseCheckersGameDataUIData = this.data.findDataInParent<ChineseCheckersGameDataUI.UIData>();
                        if (chineseCheckersGameDataUIData != null)
                        {
                            chineseCheckersGameDataUI = chineseCheckersGameDataUIData.findCallBack<ChineseCheckersGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("chineseCheckersGameDataUIData null");
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
                    if (chineseCheckersGameDataUI != null && gameDataBoardUI != null)
                    {
                        TransformData chineseCheckersTransform = chineseCheckersGameDataUI.transformData;
                        TransformData boardTransform = gameDataBoardUI.transformData;
                        if (chineseCheckersTransform.size.v != Vector2.zero && boardTransform.size.v != Vector2.zero)
                        {
                            float boardSizeX = 19f;
                            float boardSizeY = 19f;
                            float scale = Mathf.Min(Mathf.Abs(boardTransform.size.v.x / boardSizeX), Mathf.Abs(boardTransform.size.v.y / boardSizeY));
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
                        Debug.LogError("chineseCheckersGameDataUI or gameDataBoardUI null: " + this);
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

        private ChineseCheckersGameDataUI.UIData chineseCheckersGameDataUIData = null;
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
                    DataUtils.addParentCallBack(updateData, this, ref this.chineseCheckersGameDataUIData);
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
                if (data is ChineseCheckersGameDataUI.UIData)
                {
                    ChineseCheckersGameDataUI.UIData chineseCheckersGameDataUIData = data as ChineseCheckersGameDataUI.UIData;
                    // Child
                    {
                        ChineseCheckersGameDataUI chineseCheckersGameDataUI = chineseCheckersGameDataUIData.findCallBack<ChineseCheckersGameDataUI>();
                        if (chineseCheckersGameDataUI != null)
                        {
                            chineseCheckersGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("chineseCheckersGameDataUI null");
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
                    DataUtils.removeParentCallBack(updateData, this, ref this.chineseCheckersGameDataUIData);
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
                if (data is ChineseCheckersGameDataUI.UIData)
                {
                    ChineseCheckersGameDataUI.UIData chineseCheckersGameDataUIData = data as ChineseCheckersGameDataUI.UIData;
                    // Child
                    {
                        ChineseCheckersGameDataUI chineseCheckersGameDataUI = chineseCheckersGameDataUIData.findCallBack<ChineseCheckersGameDataUI>();
                        if (chineseCheckersGameDataUI != null)
                        {
                            chineseCheckersGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("chineseCheckersGameDataUI null");
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
                if (wrapProperty.p is ChineseCheckersGameDataUI.UIData)
                {
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.position:
                            dirty = true;
                            break;
                        case TransformData.Property.rotation:
                            dirty = true;
                            break;
                        case TransformData.Property.scale:
                            dirty = true;
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this + "; " + syncs);
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