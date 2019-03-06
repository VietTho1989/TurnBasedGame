using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Sudoku
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
                    SudokuGameDataUI sudokuGameDataUI = null;
                    {
                        SudokuGameDataUI.UIData sudokuGameDataUIData = this.data.findDataInParent<SudokuGameDataUI.UIData>();
                        if (sudokuGameDataUIData != null)
                        {
                            sudokuGameDataUI = sudokuGameDataUIData.findCallBack<SudokuGameDataUI>();
                        }
                        else
                        {
                            Debug.LogError("sudokuGameDataUIData null");
                        }
                    }
                    GameDataBoardUI gameDataBoardUI = null;
                    {
                        GameDataBoardUI.UIData gameDataBoardUIData = this.data.findDataInParent<GameDataBoardUI.UIData>();
                        if (gameDataBoardUIData != null)
                        {
                            gameDataBoardUI = gameDataBoardUIData.findCallBack<GameDataBoardUI>();
                        }
                        else
                        {
                            Debug.LogError("gameDataBoardUIData null");
                        }
                    }
                    if (sudokuGameDataUI != null && gameDataBoardUI != null)
                    {
                        RectTransform sudokuTransform = (RectTransform)sudokuGameDataUI.transform;
                        RectTransform boardTransform = (RectTransform)gameDataBoardUI.transform;
                        if (sudokuTransform != null && boardTransform != null)
                        {
                            Vector2 sudokuSize = new Vector2(sudokuTransform.rect.width, sudokuTransform.rect.height);
                            Vector2 boardSize = new Vector2(boardTransform.rect.width, boardTransform.rect.height);
                            if (sudokuSize != Vector2.zero && boardSize != Vector2.zero)
                            {
                                Debug.LogError("sudokuBoardSize: " + boardSize);
                                float scale = Mathf.Min(Mathf.Abs(boardSize.x / 9f), Mathf.Abs(boardSize.y / 9f));
                                // new scale
                                Vector3 newLocalScale = new Vector3();
                                {
                                    Vector3 currentLocalScale = this.transform.localScale;
                                    // x
                                    newLocalScale.x = scale;
                                    // y
                                    newLocalScale.y = scale;// (gameDataBoardUIData.perspective.v.playerView.v == 0 ? 1 : -1) * scale;
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
                            Debug.LogError("sudokuTransform, boardTransform null");
                        }
                    }
                    else
                    {
                        Debug.LogError("sudokuGameDataUI or gameDataBoardUI null: " + this);
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

        private SudokuGameDataUI.UIData sudokuGameDataUIData = null;
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
                    DataUtils.addParentCallBack(updateData, this, ref this.sudokuGameDataUIData);
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
            // CheckChange
            if (data is GameDataBoardCheckTransformChange<UpdateData>)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is SudokuGameDataUI.UIData)
                {
                    SudokuGameDataUI.UIData sudokuGameDataUIData = data as SudokuGameDataUI.UIData;
                    // Child
                    {
                        TransformData.AddCallBack(sudokuGameDataUIData, this);
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
                    DataUtils.removeParentCallBack(updateData, this, ref this.sudokuGameDataUIData);
                }
                this.setDataNull(updateData);
                return;
            }
            // Global
            if (data is Global)
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
                if (data is SudokuGameDataUI.UIData)
                {
                    SudokuGameDataUI.UIData sudokuGameDataUIData = data as SudokuGameDataUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(sudokuGameDataUIData, this);
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
                Debug.LogError("gameDataBoard change");
                dirty = true;
                return;
            }
            // Parent
            {
                if (wrapProperty.p is SudokuGameDataUI.UIData)
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