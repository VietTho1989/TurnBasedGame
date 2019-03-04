using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace EnglishDraught
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
                    EnglishDraughtGameDataUI englishDraughtGameDataUI = null;
                    {
                        EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = this.data.findDataInParent<EnglishDraughtGameDataUI.UIData>();
                        if (englishDraughtGameDataUIData != null)
                        {
                            englishDraughtGameDataUI = englishDraughtGameDataUIData.findCallBack<EnglishDraughtGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("englishDraughtGameDataUI null");
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
                    if (englishDraughtGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform englishDraughtTransform = (RectTransform)englishDraughtGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (englishDraughtTransform != null && boardTransform != null)
                        {
                            Vector2 englishDraughtSize = new Vector2(englishDraughtTransform.rect.width, englishDraughtTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (englishDraughtSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                float boardSizeX = 8f;
                                float boardSizeY = 8f;
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
                            Debug.LogError("englishDraughtTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("englishDraughtGameDataUI or gameDataBoardUI null: " + this);
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

        private EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = null;
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
                    DataUtils.addParentCallBack(updateData, this, ref this.englishDraughtGameDataUIData);
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
                if (data is EnglishDraughtGameDataUI.UIData)
                {
                    EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = data as EnglishDraughtGameDataUI.UIData;
                    // Child
                    {
                        EnglishDraughtGameDataUI englishDraughtGameDataUI = englishDraughtGameDataUIData.findCallBack<EnglishDraughtGameDataUI>();
                        if (englishDraughtGameDataUI != null)
                        {
                            englishDraughtGameDataUI.transformData.addCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("englishDraughtGameDataUI null");
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
                    DataUtils.removeParentCallBack(updateData, this, ref this.englishDraughtGameDataUIData);
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
                if (data is EnglishDraughtGameDataUI.UIData)
                {
                    EnglishDraughtGameDataUI.UIData englishDraughtGameDataUIData = data as EnglishDraughtGameDataUI.UIData;
                    // Child
                    {
                        EnglishDraughtGameDataUI englishDraughtGameDataUI = englishDraughtGameDataUIData.findCallBack<EnglishDraughtGameDataUI>();
                        if (englishDraughtGameDataUI != null)
                        {
                            englishDraughtGameDataUI.transformData.removeCallBack(this);
                        }
                        else
                        {
                            Debug.LogError("englishDraughtGameDataUI null");
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
                if (wrapProperty.p is EnglishDraughtGameDataUI.UIData)
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