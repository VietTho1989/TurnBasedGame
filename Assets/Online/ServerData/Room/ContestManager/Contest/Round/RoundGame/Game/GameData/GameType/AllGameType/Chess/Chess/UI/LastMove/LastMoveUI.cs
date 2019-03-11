using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Chess.NoneRule;

namespace Chess
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
                            case GameMove.Type.ChessMove:
                                {
                                    ChessMove chessMove = lastMove as ChessMove;
                                    // Find
                                    ChessMoveUI.UIData chessMoveUIData = this.data.sub.newOrOld<ChessMoveUI.UIData>();
                                    {
                                        // move
                                        chessMoveUIData.chessMove.v = new ReferenceData<ChessMove>(chessMove);
                                        // isHint
                                        chessMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = chessMoveUIData;
                                }
                                break;
                            case GameMove.Type.ChessCustomSet:
                                {
                                    ChessCustomSet chessCustomSet = lastMove as ChessCustomSet;
                                    // Find
                                    ChessCustomSetUI.UIData chessCustomSetUIData = this.data.sub.newOrOld<ChessCustomSetUI.UIData>();
                                    {
                                        // move
                                        chessCustomSetUIData.chessCustomSet.v = new ReferenceData<ChessCustomSet>(chessCustomSet);
                                        // isHint
                                        chessCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = chessCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.ChessCustomMove:
                                {
                                    ChessCustomMove chessCustomMove = lastMove as ChessCustomMove;
                                    // Find
                                    ChessCustomMoveUI.UIData chessCustomMoveUIData = this.data.sub.newOrOld<ChessCustomMoveUI.UIData>();
                                    {
                                        // move
                                        chessCustomMoveUIData.chessCustomMove.v = new ReferenceData<ChessCustomMove>(chessCustomMove);
                                        // isHint
                                        chessCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = chessCustomMoveUIData;
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

        public ChessMoveUI chessMovePrefab;
        public ChessCustomSetUI chessCustomSetPrefab;
        public ChessCustomMoveUI chessCustomMovePrefab;

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
                        case GameMove.Type.ChessMove:
                            {
                                ChessMoveUI.UIData chessMoveUIData = lastMoveSub as ChessMoveUI.UIData;
                                UIUtils.Instantiate(chessMoveUIData, chessMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ChessCustomSet:
                            {
                                ChessCustomSetUI.UIData chessCustomSetUIData = lastMoveSub as ChessCustomSetUI.UIData;
                                UIUtils.Instantiate(chessCustomSetUIData, chessCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ChessCustomMove:
                            {
                                ChessCustomMoveUI.UIData chessCustomMoveUIData = lastMoveSub as ChessCustomMoveUI.UIData;
                                UIUtils.Instantiate(chessCustomMoveUIData, chessCustomMovePrefab, this.transform);
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
                        case GameMove.Type.ChessMove:
                            {
                                ChessMoveUI.UIData chessMoveUIData = lastMoveSub as ChessMoveUI.UIData;
                                chessMoveUIData.removeCallBackAndDestroy(typeof(ChessMoveUI));
                            }
                            break;
                        case GameMove.Type.ChessCustomSet:
                            {
                                ChessCustomSetUI.UIData chessCustomSetUIData = lastMoveSub as ChessCustomSetUI.UIData;
                                chessCustomSetUIData.removeCallBackAndDestroy(typeof(ChessCustomSetUI));
                            }
                            break;
                        case GameMove.Type.ChessCustomMove:
                            {
                                ChessCustomMoveUI.UIData chessCustomMoveUIData = lastMoveSub as ChessCustomMoveUI.UIData;
                                chessCustomMoveUIData.removeCallBackAndDestroy(typeof(ChessCustomMoveUI));
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