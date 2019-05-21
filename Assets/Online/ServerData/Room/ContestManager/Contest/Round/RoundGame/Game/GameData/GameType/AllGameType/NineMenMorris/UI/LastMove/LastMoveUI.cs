using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NineMenMorris.NoneRule;

namespace NineMenMorris
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.NineMenMorris ? 1 : 0;
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
                            case GameMove.Type.NineMenMorrisMove:
                                {
                                    NineMenMorrisMove nineMenMorrisMove = lastMove as NineMenMorrisMove;
                                    // Find
                                    NineMenMorrisMoveUI.UIData nineMenMorrisMoveUIData = this.data.sub.newOrOld<NineMenMorrisMoveUI.UIData>();
                                    {
                                        // move
                                        nineMenMorrisMoveUIData.nineMenMorrisMove.v = new ReferenceData<NineMenMorrisMove>(nineMenMorrisMove);
                                        // isHint
                                        nineMenMorrisMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = nineMenMorrisMoveUIData;
                                }
                                break;
                            case GameMove.Type.NineMenMorrisCustomMove:
                                {
                                    NineMenMorrisCustomMove nineMenMorrisCustomMove = lastMove as NineMenMorrisCustomMove;
                                    // Find
                                    NineMenMorrisCustomMoveUI.UIData nineMenMorrisCustomMoveUIData = this.data.sub.newOrOld<NineMenMorrisCustomMoveUI.UIData>();
                                    {
                                        // move
                                        nineMenMorrisCustomMoveUIData.nineMenMorrisCustomMove.v = new ReferenceData<NineMenMorrisCustomMove>(nineMenMorrisCustomMove);
                                        // isHint
                                        nineMenMorrisCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = nineMenMorrisCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.NineMenMorrisCustomSet:
                                {
                                    NineMenMorrisCustomSet nineMenMorrisCustomSet = lastMove as NineMenMorrisCustomSet;
                                    // Find
                                    NineMenMorrisCustomSetUI.UIData nineMenMorrisCustomSetUIData = this.data.sub.newOrOld<NineMenMorrisCustomSetUI.UIData>();
                                    {
                                        // move
                                        nineMenMorrisCustomSetUIData.nineMenMorrisCustomSet.v = new ReferenceData<NineMenMorrisCustomSet>(nineMenMorrisCustomSet);
                                        // isHint
                                        nineMenMorrisCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = nineMenMorrisCustomSetUIData;
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

        public NineMenMorrisMoveUI nineMenMorrisMovePrefab;
        public NineMenMorrisCustomMoveUI nineMenMorrisCustomMovePrefab;
        public NineMenMorrisCustomSetUI nineMenMorrisCustomSetPrefab;

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
                        case GameMove.Type.NineMenMorrisMove:
                            {
                                NineMenMorrisMoveUI.UIData nineMenMorrisMoveUIData = lastMoveSub as NineMenMorrisMoveUI.UIData;
                                UIUtils.Instantiate(nineMenMorrisMoveUIData, nineMenMorrisMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.NineMenMorrisCustomMove:
                            {
                                NineMenMorrisCustomMoveUI.UIData nineMenMorrisCustomMoveUIData = lastMoveSub as NineMenMorrisCustomMoveUI.UIData;
                                UIUtils.Instantiate(nineMenMorrisCustomMoveUIData, nineMenMorrisCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.NineMenMorrisCustomSet:
                            {
                                NineMenMorrisCustomSetUI.UIData nineMenMorrisCustomSetUIData = lastMoveSub as NineMenMorrisCustomSetUI.UIData;
                                UIUtils.Instantiate(nineMenMorrisCustomSetUIData, nineMenMorrisCustomSetPrefab, this.transform);
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
                        case GameMove.Type.NineMenMorrisMove:
                            {
                                NineMenMorrisMoveUI.UIData nineMenMorrisMoveUIData = lastMoveSub as NineMenMorrisMoveUI.UIData;
                                nineMenMorrisMoveUIData.removeCallBackAndDestroy(typeof(NineMenMorrisMoveUI));
                            }
                            break;
                        case GameMove.Type.NineMenMorrisCustomMove:
                            {
                                NineMenMorrisCustomMoveUI.UIData nineMenMorrisCustomMoveUIData = lastMoveSub as NineMenMorrisCustomMoveUI.UIData;
                                nineMenMorrisCustomMoveUIData.removeCallBackAndDestroy(typeof(NineMenMorrisCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.NineMenMorrisCustomSet:
                            {
                                NineMenMorrisCustomSetUI.UIData nineMenMorrisCustomSetUIData = lastMoveSub as NineMenMorrisCustomSetUI.UIData;
                                nineMenMorrisCustomSetUIData.removeCallBackAndDestroy(typeof(NineMenMorrisCustomSetUI));
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