using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Shogi.NoneRule;

namespace Shogi
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
                            case GameMove.Type.ShogiMove:
                                {
                                    ShogiMove shogiMove = lastMove as ShogiMove;
                                    // Find
                                    ShogiMoveUI.UIData shogiMoveUIData = this.data.sub.newOrOld<ShogiMoveUI.UIData>();
                                    {
                                        // move
                                        shogiMoveUIData.shogiMove.v = new ReferenceData<ShogiMove>(shogiMove);
                                        // isHint
                                        shogiMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shogiMoveUIData;
                                }
                                break;
                            case GameMove.Type.ShogiCustomSet:
                                {
                                    ShogiCustomSet shogiCustomSet = lastMove as ShogiCustomSet;
                                    // Find
                                    ShogiCustomSetUI.UIData shogiCustomSetUIData = this.data.sub.newOrOld<ShogiCustomSetUI.UIData>();
                                    {
                                        // move
                                        shogiCustomSetUIData.shogiCustomSet.v = new ReferenceData<ShogiCustomSet>(shogiCustomSet);
                                        // isHint
                                        shogiCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shogiCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.ShogiCustomMove:
                                {
                                    ShogiCustomMove shogiCustomMove = lastMove as ShogiCustomMove;
                                    // Find
                                    ShogiCustomMoveUI.UIData shogiCustomMoveUIData = this.data.sub.newOrOld<ShogiCustomMoveUI.UIData>();
                                    {
                                        // move
                                        shogiCustomMoveUIData.shogiCustomMove.v = new ReferenceData<ShogiCustomMove>(shogiCustomMove);
                                        // isHint
                                        shogiCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shogiCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.ShogiCustomHand:
                                {
                                    ShogiCustomHand shogiCustomHand = lastMove as ShogiCustomHand;
                                    // Find
                                    ShogiCustomHandUI.UIData shogiCustomHandUIData = this.data.sub.newOrOld<ShogiCustomHandUI.UIData>();
                                    {
                                        // move
                                        shogiCustomHandUIData.shogiCustomHand.v = new ReferenceData<ShogiCustomHand>(shogiCustomHand);
                                        // isHint
                                        shogiCustomHandUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shogiCustomHandUIData;
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

        public ShogiMoveUI shogiMovePrefab;
        public ShogiCustomSetUI shogiCustomSetPrefab;
        public ShogiCustomMoveUI shogiCustomMovePrefab;
        public ShogiCustomHandUI shogiCustomHandPrefab;

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
                        case GameMove.Type.ShogiMove:
                            {
                                ShogiMoveUI.UIData shogiMoveUIData = lastMoveSub as ShogiMoveUI.UIData;
                                UIUtils.Instantiate(shogiMoveUIData, shogiMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ShogiCustomSet:
                            {
                                ShogiCustomSetUI.UIData shogiCustomSetUIData = lastMoveSub as ShogiCustomSetUI.UIData;
                                UIUtils.Instantiate(shogiCustomSetUIData, shogiCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ShogiCustomMove:
                            {
                                ShogiCustomMoveUI.UIData shogiCustomMoveUIData = lastMoveSub as ShogiCustomMoveUI.UIData;
                                UIUtils.Instantiate(shogiCustomMoveUIData, shogiCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ShogiCustomHand:
                            {
                                ShogiCustomHandUI.UIData shogiCustomHandUIData = lastMoveSub as ShogiCustomHandUI.UIData;
                                UIUtils.Instantiate(shogiCustomHandUIData, shogiCustomHandPrefab, this.transform);
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
                        case GameMove.Type.ShogiMove:
                            {
                                ShogiMoveUI.UIData shogiMoveUIData = lastMoveSub as ShogiMoveUI.UIData;
                                shogiMoveUIData.removeCallBackAndDestroy(typeof(ShogiMoveUI));
                            }
                            break;
                        case GameMove.Type.ShogiCustomSet:
                            {
                                ShogiCustomSetUI.UIData shogiCustomSetUIData = lastMoveSub as ShogiCustomSetUI.UIData;
                                shogiCustomSetUIData.removeCallBackAndDestroy(typeof(ShogiCustomSetUI));
                            }
                            break;
                        case GameMove.Type.ShogiCustomMove:
                            {
                                ShogiCustomMoveUI.UIData shogiCustomMoveUIData = lastMoveSub as ShogiCustomMoveUI.UIData;
                                shogiCustomMoveUIData.removeCallBackAndDestroy(typeof(ShogiCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.ShogiCustomHand:
                            {
                                ShogiCustomHandUI.UIData shogiCustomHandUIData = lastMoveSub as ShogiCustomHandUI.UIData;
                                shogiCustomHandUIData.removeCallBackAndDestroy(typeof(ShogiCustomHandUI));
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