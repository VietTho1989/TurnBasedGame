using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Gomoku.NoneRule;

namespace Gomoku
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
                            case GameMove.Type.GomokuMove:
                                {
                                    GomokuMove gomokuMove = lastMove as GomokuMove;
                                    // Find
                                    GomokuMoveUI.UIData gomokuMoveUIData = this.data.sub.newOrOld<GomokuMoveUI.UIData>();
                                    {
                                        // move
                                        gomokuMoveUIData.gomokuMove.v = new ReferenceData<GomokuMove>(gomokuMove);
                                        // isHint
                                        gomokuMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = gomokuMoveUIData;
                                }
                                break;
                            case GameMove.Type.GomokuCustomSet:
                                {
                                    GomokuCustomSet gomokuCustomSet = lastMove as GomokuCustomSet;
                                    // Find
                                    GomokuCustomSetUI.UIData gomokuCustomSetUIData = this.data.sub.newOrOld<GomokuCustomSetUI.UIData>();
                                    {
                                        // move
                                        gomokuCustomSetUIData.gomokuCustomSet.v = new ReferenceData<GomokuCustomSet>(gomokuCustomSet);
                                        // isHint
                                        gomokuCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = gomokuCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.GomokuCustomMove:
                                {
                                    GomokuCustomMove gomokuCustomMove = lastMove as GomokuCustomMove;
                                    // Find
                                    GomokuCustomMoveUI.UIData gomokuCustomMoveUIData = this.data.sub.newOrOld<GomokuCustomMoveUI.UIData>();
                                    {
                                        // move
                                        gomokuCustomMoveUIData.gomokuCustomMove.v = new ReferenceData<GomokuCustomMove>(gomokuCustomMove);
                                        // isHint
                                        gomokuCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = gomokuCustomMoveUIData;
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

        public GomokuMoveUI gomokuMovePrefab;
        public GomokuCustomSetUI gomokuCustomSetPrefab;
        public GomokuCustomMoveUI gomokuCustomMovePrefab;

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
                        case GameMove.Type.GomokuMove:
                            {
                                GomokuMoveUI.UIData gomokuMoveUIData = lastMoveSub as GomokuMoveUI.UIData;
                                UIUtils.Instantiate(gomokuMoveUIData, gomokuMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.GomokuCustomSet:
                            {
                                GomokuCustomSetUI.UIData gomokuCustomSetUIData = lastMoveSub as GomokuCustomSetUI.UIData;
                                UIUtils.Instantiate(gomokuCustomSetUIData, gomokuCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.GomokuCustomMove:
                            {
                                GomokuCustomMoveUI.UIData gomokuCustomMoveUIData = lastMoveSub as GomokuCustomMoveUI.UIData;
                                UIUtils.Instantiate(gomokuCustomMoveUIData, gomokuCustomMovePrefab, this.transform);
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
                        case GameMove.Type.GomokuMove:
                            {
                                GomokuMoveUI.UIData gomokuMoveUIData = lastMoveSub as GomokuMoveUI.UIData;
                                gomokuMoveUIData.removeCallBackAndDestroy(typeof(GomokuMoveUI));
                            }
                            break;
                        case GameMove.Type.GomokuCustomSet:
                            {
                                GomokuCustomSetUI.UIData gomokuCustomSetUIData = lastMoveSub as GomokuCustomSetUI.UIData;
                                gomokuCustomSetUIData.removeCallBackAndDestroy(typeof(GomokuCustomSetUI));
                            }
                            break;
                        case GameMove.Type.GomokuCustomMove:
                            {
                                GomokuCustomMoveUI.UIData gomokuCustomMoveUIData = lastMoveSub as GomokuCustomMoveUI.UIData;
                                gomokuCustomMoveUIData.removeCallBackAndDestroy(typeof(GomokuCustomMoveUI));
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