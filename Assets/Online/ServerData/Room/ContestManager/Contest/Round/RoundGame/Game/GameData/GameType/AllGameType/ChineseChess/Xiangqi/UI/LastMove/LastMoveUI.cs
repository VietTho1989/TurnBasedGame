using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Xiangqi.NoneRule;

namespace Xiangqi
{
    public class LastMoveUI : UIBehavior<LastMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<GameData>> gameData;

            public VP<LastMoveSub> sub;

            #region Constructor

            public enum Property
            {
                gameData,
                sub
            }

            public UIData() : base()
            {
                this.gameData = new VP<ReferenceData<GameData>>(this, (byte)Property.gameData, new ReferenceData<GameData>(null));
                this.sub = new VP<LastMoveSub>(this, (byte)Property.sub, null);
            }

            #endregion

        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // Find last move
                    GameMove lastMove = LastMoveCheckChange<UIData>.getLastMove(this.data);
                    // Process
                    if (lastMove != null)
                    {
                        switch (lastMove.getType())
                        {
                            case GameMove.Type.XiangqiMove:
                                {
                                    XiangqiMove xiangqiMove = lastMove as XiangqiMove;
                                    // Find
                                    XiangqiMoveUI.UIData xiangqiMoveUIData = this.data.sub.newOrOld<XiangqiMoveUI.UIData>();
                                    {
                                        // move
                                        xiangqiMoveUIData.xiangqiMove.v = new ReferenceData<XiangqiMove>(xiangqiMove);
                                        // isHint
                                        xiangqiMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = xiangqiMoveUIData;
                                }
                                break;
                            case GameMove.Type.XiangqiCustomSet:
                                {
                                    XiangqiCustomSet xiangqiCustomSet = lastMove as XiangqiCustomSet;
                                    // Find
                                    XiangqiCustomSetUI.UIData xiangqiCustomSetUIData = this.data.sub.newOrOld<XiangqiCustomSetUI.UIData>();
                                    {
                                        // move
                                        xiangqiCustomSetUIData.xiangqiCustomSet.v = new ReferenceData<XiangqiCustomSet>(xiangqiCustomSet);
                                        // isHint
                                        xiangqiCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = xiangqiCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.XiangqiCustomMove:
                                {
                                    XiangqiCustomMove xiangqiCustomMove = lastMove as XiangqiCustomMove;
                                    // Find
                                    XiangqiCustomMoveUI.UIData xiangqiCustomMoveUIData = this.data.sub.newOrOld<XiangqiCustomMoveUI.UIData>();
                                    {
                                        // move
                                        xiangqiCustomMoveUIData.xiangqiCustomMove.v = new ReferenceData<XiangqiCustomMove>(xiangqiCustomMove);
                                        // isHint
                                        xiangqiCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = xiangqiCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.XiangqiCustomFen:
                                {
                                    XiangqiCustomFen xiangqiCustomFen = lastMove as XiangqiCustomFen;
                                    // Find
                                    XiangqiCustomFenUI.UIData xiangqiCustomFenUIData = this.data.sub.newOrOld<XiangqiCustomFenUI.UIData>();
                                    {
                                        // move
                                        xiangqiCustomFenUIData.xiangqiCustomFen.v = new ReferenceData<XiangqiCustomFen>(xiangqiCustomFen);
                                        // isHint
                                        xiangqiCustomFenUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = xiangqiCustomFenUIData;
                                }
                                break;
                            case GameMove.Type.None:
                                this.data.sub.v = null;
                                break;
                            default:
                                Debug.LogError("unknown lastMove: " + lastMove + ";" + this);
                                this.data.sub.v = null;
                                break;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("lastMove null: " + this);
                        this.data.sub.v = null;
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public XiangqiMoveUI xiangqiMovePrefab;
        public XiangqiCustomSetUI xiangqiCustomSetPrefab;
        public XiangqiCustomMoveUI xiangqiCustomMovePrefab;
        public XiangqiCustomFenUI xiangqiCustomFenPrefab;

        private LastMoveCheckChange<UIData> lastMoveCheckChange = new LastMoveCheckChange<UIData>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    lastMoveCheckChange.addCallBack(this);
                    lastMoveCheckChange.setData(uiData);
                }
                // Child
                {
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is LastMoveCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            if (data is LastMoveSub)
            {
                LastMoveSub lastMoveSub = data as LastMoveSub;
                // UI
                {
                    switch (lastMoveSub.getType())
                    {
                        case GameMove.Type.XiangqiMove:
                            {
                                XiangqiMoveUI.UIData xiangqiMoveUIData = lastMoveSub as XiangqiMoveUI.UIData;
                                UIUtils.Instantiate(xiangqiMoveUIData, xiangqiMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.XiangqiCustomSet:
                            {
                                XiangqiCustomSetUI.UIData xiangqiCustomSetUIData = lastMoveSub as XiangqiCustomSetUI.UIData;
                                UIUtils.Instantiate(xiangqiCustomSetUIData, xiangqiCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.XiangqiCustomMove:
                            {
                                XiangqiCustomMoveUI.UIData xiangqiCustomMoveUIData = lastMoveSub as XiangqiCustomMoveUI.UIData;
                                UIUtils.Instantiate(xiangqiCustomMoveUIData, xiangqiCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.XiangqiCustomFen:
                            {
                                XiangqiCustomFenUI.UIData xiangqiCustomFenUIData = lastMoveSub as XiangqiCustomFenUI.UIData;
                                UIUtils.Instantiate(xiangqiCustomFenUIData, xiangqiCustomFenPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + lastMoveSub.getType() + "; " + this);
                            break;
                    }
                }
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // CheckChange
                {
                    lastMoveCheckChange.removeCallBack(this);
                    lastMoveCheckChange.setData(null);
                }
                // Child
                {
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // CheckChange
            if (data is LastMoveCheckChange<UIData>)
            {
                return;
            }
            // Child
            if (data is LastMoveSub)
            {
                LastMoveSub lastMoveSub = data as LastMoveSub;
                // UI
                {
                    switch (lastMoveSub.getType())
                    {
                        case GameMove.Type.XiangqiMove:
                            {
                                XiangqiMoveUI.UIData xiangqiMoveUIData = lastMoveSub as XiangqiMoveUI.UIData;
                                xiangqiMoveUIData.removeCallBackAndDestroy(typeof(XiangqiMoveUI));
                            }
                            break;
                        case GameMove.Type.XiangqiCustomSet:
                            {
                                XiangqiCustomSetUI.UIData xiangqiCustomSetUIData = lastMoveSub as XiangqiCustomSetUI.UIData;
                                xiangqiCustomSetUIData.removeCallBackAndDestroy(typeof(XiangqiCustomSetUI));
                            }
                            break;
                        case GameMove.Type.XiangqiCustomMove:
                            {
                                XiangqiCustomMoveUI.UIData xiangqiCustomMoveUIData = lastMoveSub as XiangqiCustomMoveUI.UIData;
                                xiangqiCustomMoveUIData.removeCallBackAndDestroy(typeof(XiangqiCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.XiangqiCustomFen:
                            {
                                XiangqiCustomFenUI.UIData xiangqiCustomFenUIData = lastMoveSub as XiangqiCustomFenUI.UIData;
                                xiangqiCustomFenUIData.removeCallBackAndDestroy(typeof(XiangqiCustomFenUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + lastMoveSub.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    case UIData.Property.gameData:
                        dirty = true;
                        break;
                    case UIData.Property.sub:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            if (wrapProperty.p is LastMoveCheckChange<UIData>)
            {
                dirty = true;
                return;
            }
            // Child
            if (wrapProperty.p is LastMoveSub)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}