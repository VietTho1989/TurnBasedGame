using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Seirawan.NoneRule;

namespace Seirawan
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

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Seirawan ? 1 : 0;
        }

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
                            case GameMove.Type.SeirawanMove:
                                {
                                    SeirawanMove seirawanMove = lastMove as SeirawanMove;
                                    // Find
                                    SeirawanMoveUI.UIData seirawanMoveUIData = this.data.sub.newOrOld<SeirawanMoveUI.UIData>();
                                    {
                                        // move
                                        seirawanMoveUIData.seirawanMove.v = new ReferenceData<SeirawanMove>(seirawanMove);
                                        // isHint
                                        seirawanMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = seirawanMoveUIData;
                                }
                                break;
                            case GameMove.Type.SeirawanCustomSet:
                                {
                                    SeirawanCustomSet seirawanCustomSet = lastMove as SeirawanCustomSet;
                                    // Find
                                    SeirawanCustomSetUI.UIData seirawanCustomSetUIData = this.data.sub.newOrOld<SeirawanCustomSetUI.UIData>();
                                    {
                                        // move
                                        seirawanCustomSetUIData.seirawanCustomSet.v = new ReferenceData<SeirawanCustomSet>(seirawanCustomSet);
                                        // isHint
                                        seirawanCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = seirawanCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.SeirawanCustomMove:
                                {
                                    SeirawanCustomMove seirawanCustomMove = lastMove as SeirawanCustomMove;
                                    // Find
                                    SeirawanCustomMoveUI.UIData seirawanCustomMoveUIData = this.data.sub.newOrOld<SeirawanCustomMoveUI.UIData>();
                                    {
                                        // move
                                        seirawanCustomMoveUIData.seirawanCustomMove.v = new ReferenceData<SeirawanCustomMove>(seirawanCustomMove);
                                        // isHint
                                        seirawanCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = seirawanCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.SeirawanCustomHand:
                                {
                                    SeirawanCustomHand seirawanCustomHand = lastMove as SeirawanCustomHand;
                                    // Find
                                    SeirawanCustomHandUI.UIData seirawanCustomHandUIData = this.data.sub.newOrOld<SeirawanCustomHandUI.UIData>();
                                    {
                                        // move
                                        seirawanCustomHandUIData.seirawanCustomHand.v = new ReferenceData<SeirawanCustomHand>(seirawanCustomHand);
                                        // isHint
                                        seirawanCustomHandUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = seirawanCustomHandUIData;
                                }
                                break;
                            case GameMove.Type.SeirawanCustomFen:
                                {
                                    SeirawanCustomFen seirawanCustomFen = lastMove as SeirawanCustomFen;
                                    // Find
                                    SeirawanCustomFenUI.UIData seirawanCustomFenUIData = this.data.sub.newOrOld<SeirawanCustomFenUI.UIData>();
                                    {
                                        // move
                                        seirawanCustomFenUIData.seirawanCustomFen.v = new ReferenceData<SeirawanCustomFen>(seirawanCustomFen);
                                        // isHint
                                        seirawanCustomFenUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = seirawanCustomFenUIData;
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
                        // Debug.LogError("lastMove null: " + this);
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

        public SeirawanMoveUI seirawanMovePrefab;
        public SeirawanCustomSetUI seirawanCustomSetPrefab;
        public SeirawanCustomMoveUI seirawanCustomMovePrefab;
        public SeirawanCustomHandUI seirawanCustomHandPrefab;
        public SeirawanCustomFenUI seirawanCustomFenPrefab;

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
                        case GameMove.Type.SeirawanMove:
                            {
                                SeirawanMoveUI.UIData seirawanMoveUIData = lastMoveSub as SeirawanMoveUI.UIData;
                                UIUtils.Instantiate(seirawanMoveUIData, seirawanMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.SeirawanCustomSet:
                            {
                                SeirawanCustomSetUI.UIData seirawanCustomSetUIData = lastMoveSub as SeirawanCustomSetUI.UIData;
                                UIUtils.Instantiate(seirawanCustomSetUIData, seirawanCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.SeirawanCustomMove:
                            {
                                SeirawanCustomMoveUI.UIData seirawanCustomMoveUIData = lastMoveSub as SeirawanCustomMoveUI.UIData;
                                UIUtils.Instantiate(seirawanCustomMoveUIData, seirawanCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.SeirawanCustomHand:
                            {
                                SeirawanCustomHandUI.UIData seirawanCustomHandUIData = lastMoveSub as SeirawanCustomHandUI.UIData;
                                UIUtils.Instantiate(seirawanCustomHandUIData, seirawanCustomHandPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.SeirawanCustomFen:
                            {
                                SeirawanCustomFenUI.UIData seirawanCustomFenUIData = lastMoveSub as SeirawanCustomFenUI.UIData;
                                UIUtils.Instantiate(seirawanCustomFenUIData, seirawanCustomFenPrefab, this.transform);
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
                        case GameMove.Type.SeirawanMove:
                            {
                                SeirawanMoveUI.UIData seirawanMoveUIData = lastMoveSub as SeirawanMoveUI.UIData;
                                seirawanMoveUIData.removeCallBackAndDestroy(typeof(SeirawanMoveUI));
                            }
                            break;
                        case GameMove.Type.SeirawanCustomSet:
                            {
                                SeirawanCustomSetUI.UIData seirawanCustomSetUIData = lastMoveSub as SeirawanCustomSetUI.UIData;
                                seirawanCustomSetUIData.removeCallBackAndDestroy(typeof(SeirawanCustomSetUI));
                            }
                            break;
                        case GameMove.Type.SeirawanCustomMove:
                            {
                                SeirawanCustomMoveUI.UIData seirawanCustomMoveUIData = lastMoveSub as SeirawanCustomMoveUI.UIData;
                                seirawanCustomMoveUIData.removeCallBackAndDestroy(typeof(SeirawanCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.SeirawanCustomHand:
                            {
                                SeirawanCustomHandUI.UIData seirawanCustomHandUIData = lastMoveSub as SeirawanCustomHandUI.UIData;
                                seirawanCustomHandUIData.removeCallBackAndDestroy(typeof(SeirawanCustomHandUI));
                            }
                            break;
                        case GameMove.Type.SeirawanCustomFen:
                            {
                                SeirawanCustomFenUI.UIData seirawanCustomFenUIData = lastMoveSub as SeirawanCustomFenUI.UIData;
                                seirawanCustomFenUIData.removeCallBackAndDestroy(typeof(SeirawanCustomFenUI));
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