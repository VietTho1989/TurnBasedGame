using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Khet.NoneRule;

namespace Khet
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
                            case GameMove.Type.KhetMove:
                                {
                                    KhetMove khetMove = lastMove as KhetMove;
                                    // Find
                                    KhetMoveUI.UIData khetMoveUIData = this.data.sub.newOrOld<KhetMoveUI.UIData>();
                                    {
                                        // move
                                        khetMoveUIData.khetMove.v = new ReferenceData<KhetMove>(khetMove);
                                        // isHint
                                        khetMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = khetMoveUIData;
                                }
                                break;
                            case GameMove.Type.KhetCusomMove:
                                {
                                    KhetCustomMove khetCustomMove = lastMove as KhetCustomMove;
                                    // Find
                                    KhetCustomMoveUI.UIData khetCustomMoveUIData = this.data.sub.newOrOld<KhetCustomMoveUI.UIData>();
                                    {
                                        // move
                                        khetCustomMoveUIData.khetCustomMove.v = new ReferenceData<KhetCustomMove>(khetCustomMove);
                                        // isHint
                                        khetCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = khetCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.KhetCusomSet:
                                {
                                    KhetCustomSet khetCustomSet = lastMove as KhetCustomSet;
                                    // Find
                                    KhetCustomSetUI.UIData khetCustomSetUIData = this.data.sub.newOrOld<KhetCustomSetUI.UIData>();
                                    {
                                        // move
                                        khetCustomSetUIData.khetCustomSet.v = new ReferenceData<KhetCustomSet>(khetCustomSet);
                                        // isHint
                                        khetCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = khetCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.KhetCustomRotate:
                                {
                                    KhetCustomRotate khetCustomRotate = lastMove as KhetCustomRotate;
                                    // Find
                                    KhetCustomRotateUI.UIData khetCustomRotateUIData = this.data.sub.newOrOld<KhetCustomRotateUI.UIData>();
                                    {
                                        // move
                                        khetCustomRotateUIData.khetCustomRotate.v = new ReferenceData<KhetCustomRotate>(khetCustomRotate);
                                        // isHint
                                        khetCustomRotateUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = khetCustomRotateUIData;
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

        public KhetMoveUI khetMovePrefab;
        public KhetCustomMoveUI khetCustomMovePrefab;
        public KhetCustomSetUI khetCustomSetPrefab;
        public KhetCustomRotateUI khetCustomRotatePrefab;

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
                        case GameMove.Type.KhetMove:
                            {
                                KhetMoveUI.UIData khetMoveUIData = lastMoveSub as KhetMoveUI.UIData;
                                UIUtils.Instantiate(khetMoveUIData, khetMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.KhetCusomMove:
                            {
                                KhetCustomMoveUI.UIData khetCustomMoveUIData = lastMoveSub as KhetCustomMoveUI.UIData;
                                UIUtils.Instantiate(khetCustomMoveUIData, khetCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.KhetCusomSet:
                            {
                                KhetCustomSetUI.UIData khetCustomSetUIData = lastMoveSub as KhetCustomSetUI.UIData;
                                UIUtils.Instantiate(khetCustomSetUIData, khetCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.KhetCustomRotate:
                            {
                                KhetCustomRotateUI.UIData khetCustomRotateUIData = lastMoveSub as KhetCustomRotateUI.UIData;
                                UIUtils.Instantiate(khetCustomRotateUIData, khetCustomRotatePrefab, this.transform);
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
                        case GameMove.Type.KhetMove:
                            {
                                KhetMoveUI.UIData khetMoveUIData = lastMoveSub as KhetMoveUI.UIData;
                                khetMoveUIData.removeCallBackAndDestroy(typeof(KhetMoveUI));
                            }
                            break;
                        case GameMove.Type.KhetCusomMove:
                            {
                                KhetCustomMoveUI.UIData khetCustomMoveUIData = lastMoveSub as KhetCustomMoveUI.UIData;
                                khetCustomMoveUIData.removeCallBackAndDestroy(typeof(KhetCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.KhetCusomSet:
                            {
                                KhetCustomSetUI.UIData khetCustomSetUIData = lastMoveSub as KhetCustomSetUI.UIData;
                                khetCustomSetUIData.removeCallBackAndDestroy(typeof(KhetCustomSetUI));
                            }
                            break;
                        case GameMove.Type.KhetCustomRotate:
                            {
                                KhetCustomRotateUI.UIData khetCustomRotateUIData = lastMoveSub as KhetCustomRotateUI.UIData;
                                khetCustomRotateUIData.removeCallBackAndDestroy(typeof(KhetCustomRotateUI));
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