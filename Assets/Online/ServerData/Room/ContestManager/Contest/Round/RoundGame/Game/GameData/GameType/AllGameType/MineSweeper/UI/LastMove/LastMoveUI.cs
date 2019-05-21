using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using MineSweeper.NoneRule;

namespace MineSweeper
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.MineSweeper ? 1 : 0;
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
                            case GameMove.Type.MineSweeperMove:
                                {
                                    MineSweeperMove mineSweeperMove = lastMove as MineSweeperMove;
                                    // Find
                                    MineSweeperMoveUI.UIData mineSweeperMoveUIData = this.data.sub.newOrOld<MineSweeperMoveUI.UIData>();
                                    {
                                        // move
                                        mineSweeperMoveUIData.mineSweeperMove.v = new ReferenceData<MineSweeperMove>(mineSweeperMove);
                                        // isHint
                                        mineSweeperMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = mineSweeperMoveUIData;
                                }
                                break;
                            case GameMove.Type.MineSweeperCustomSet:
                                {
                                    MineSweeperCustomSet mineSweeperCustomSet = lastMove as MineSweeperCustomSet;
                                    // Find
                                    MineSweeperCustomSetUI.UIData mineSweeperCustomSetUIData = this.data.sub.newOrOld<MineSweeperCustomSetUI.UIData>();
                                    {
                                        // move
                                        mineSweeperCustomSetUIData.mineSweeperCustomSet.v = new ReferenceData<MineSweeperCustomSet>(mineSweeperCustomSet);
                                        // isHint
                                        mineSweeperCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = mineSweeperCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.MineSweeperCustomMove:
                                {
                                    MineSweeperCustomMove mineSweeperCustomMove = lastMove as MineSweeperCustomMove;
                                    // Find
                                    MineSweeperCustomMoveUI.UIData mineSweeperCustomMoveUIData = this.data.sub.newOrOld<MineSweeperCustomMoveUI.UIData>();
                                    {
                                        // move
                                        mineSweeperCustomMoveUIData.mineSweeperCustomMove.v = new ReferenceData<MineSweeperCustomMove>(mineSweeperCustomMove);
                                        // isHint
                                        mineSweeperCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = mineSweeperCustomMoveUIData;
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

        public MineSweeperMoveUI mineSweeperMovePrefab;
        public MineSweeperCustomSetUI mineSweeperCustomSetPrefab;
        public MineSweeperCustomMoveUI mineSweeperCustomMovePrefab;

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
                        case GameMove.Type.MineSweeperMove:
                            {
                                MineSweeperMoveUI.UIData mineSweeperMoveUIData = lastMoveSub as MineSweeperMoveUI.UIData;
                                UIUtils.Instantiate(mineSweeperMoveUIData, mineSweeperMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.MineSweeperCustomSet:
                            {
                                MineSweeperCustomSetUI.UIData mineSweeperCustomSetUIData = lastMoveSub as MineSweeperCustomSetUI.UIData;
                                UIUtils.Instantiate(mineSweeperCustomSetUIData, mineSweeperCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.MineSweeperCustomMove:
                            {
                                MineSweeperCustomMoveUI.UIData mineSweeperCustomMoveUIData = lastMoveSub as MineSweeperCustomMoveUI.UIData;
                                UIUtils.Instantiate(mineSweeperCustomMoveUIData, mineSweeperCustomMovePrefab, this.transform);
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
                        case GameMove.Type.MineSweeperMove:
                            {
                                MineSweeperMoveUI.UIData mineSweeperMoveUIData = lastMoveSub as MineSweeperMoveUI.UIData;
                                mineSweeperMoveUIData.removeCallBackAndDestroy(typeof(MineSweeperMoveUI));
                            }
                            break;
                        case GameMove.Type.MineSweeperCustomSet:
                            {
                                MineSweeperCustomSetUI.UIData mineSweeperCustomSetUIData = lastMoveSub as MineSweeperCustomSetUI.UIData;
                                mineSweeperCustomSetUIData.removeCallBackAndDestroy(typeof(MineSweeperCustomSetUI));
                            }
                            break;
                        case GameMove.Type.MineSweeperCustomMove:
                            {
                                MineSweeperCustomMoveUI.UIData mineSweeperCustomMoveUIData = lastMoveSub as MineSweeperCustomMoveUI.UIData;
                                mineSweeperCustomMoveUIData.removeCallBackAndDestroy(typeof(MineSweeperCustomMoveUI));
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