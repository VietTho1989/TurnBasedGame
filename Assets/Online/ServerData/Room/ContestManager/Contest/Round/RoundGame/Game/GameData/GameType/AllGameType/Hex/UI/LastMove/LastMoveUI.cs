using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using HEX.NoneRule;

namespace HEX
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Hex ? 1 : 0;
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
                            case GameMove.Type.HexMove:
                                {
                                    HexMove hexMove = lastMove as HexMove;
                                    // Find
                                    HexMoveUI.UIData hexMoveUIData = this.data.sub.newOrOld<HexMoveUI.UIData>();
                                    {
                                        // move
                                        hexMoveUIData.hexMove.v = new ReferenceData<HexMove>(hexMove);
                                        // isHint
                                        hexMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = hexMoveUIData;
                                }
                                break;
                            case GameMove.Type.HexSwitch:
                                {
                                    HexSwitch hexSwitch = lastMove as HexSwitch;
                                    // Find
                                    HexSwitchUI.UIData hexSwitchUIData = this.data.sub.newOrOld<HexSwitchUI.UIData>();
                                    {
                                        // move
                                        hexSwitchUIData.hexSwitch.v = new ReferenceData<HexSwitch>(hexSwitch);
                                        // isHint
                                        hexSwitchUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = hexSwitchUIData;
                                }
                                break;
                            case GameMove.Type.HexCustomSet:
                                {
                                    HexCustomSet hexCustomSet = lastMove as HexCustomSet;
                                    // Find
                                    HexCustomSetUI.UIData hexCustomSetUIData = this.data.sub.newOrOld<HexCustomSetUI.UIData>();
                                    {
                                        // move
                                        hexCustomSetUIData.hexCustomSet.v = new ReferenceData<HexCustomSet>(hexCustomSet);
                                        // isHint
                                        hexCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = hexCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.HexCustomMove:
                                {
                                    HexCustomMove hexCustomMove = lastMove as HexCustomMove;
                                    // Find
                                    HexCustomMoveUI.UIData hexCustomMoveUIData = this.data.sub.newOrOld<HexCustomMoveUI.UIData>();
                                    {
                                        // move
                                        hexCustomMoveUIData.hexCustomMove.v = new ReferenceData<HexCustomMove>(hexCustomMove);
                                        // isHint
                                        hexCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = hexCustomMoveUIData;
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

        public HexMoveUI hexMovePrefab;
        public HexSwitchUI hexSwitchPrefab;
        public HexCustomSetUI hexCustomSetPrefab;
        public HexCustomMoveUI hexCustomMovePrefab;

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
                        case GameMove.Type.HexMove:
                            {
                                HexMoveUI.UIData hexMoveUIData = lastMoveSub as HexMoveUI.UIData;
                                UIUtils.Instantiate(hexMoveUIData, hexMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.HexSwitch:
                            {
                                HexSwitchUI.UIData hexSwitchUIData = lastMoveSub as HexSwitchUI.UIData;
                                UIUtils.Instantiate(hexSwitchUIData, hexSwitchPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.HexCustomSet:
                            {
                                HexCustomSetUI.UIData hexCustomSetUIData = lastMoveSub as HexCustomSetUI.UIData;
                                UIUtils.Instantiate(hexCustomSetUIData, hexCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.HexCustomMove:
                            {
                                HexCustomMoveUI.UIData hexCustomMoveUIData = lastMoveSub as HexCustomMoveUI.UIData;
                                UIUtils.Instantiate(hexCustomMoveUIData, hexCustomMovePrefab, this.transform);
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
                        case GameMove.Type.HexMove:
                            {
                                HexMoveUI.UIData hexMoveUIData = lastMoveSub as HexMoveUI.UIData;
                                hexMoveUIData.removeCallBackAndDestroy(typeof(HexMoveUI));
                            }
                            break;
                        case GameMove.Type.HexSwitch:
                            {
                                HexSwitchUI.UIData hexSwitchUIData = lastMoveSub as HexSwitchUI.UIData;
                                hexSwitchUIData.removeCallBackAndDestroy(typeof(HexSwitchUI));
                            }
                            break;
                        case GameMove.Type.HexCustomSet:
                            {
                                HexCustomSetUI.UIData hexCustomSetUIData = lastMoveSub as HexCustomSetUI.UIData;
                                hexCustomSetUIData.removeCallBackAndDestroy(typeof(HexCustomSetUI));
                            }
                            break;
                        case GameMove.Type.HexCustomMove:
                            {
                                HexCustomMoveUI.UIData hexCustomMoveUIData = lastMoveSub as HexCustomMoveUI.UIData;
                                hexCustomMoveUIData.removeCallBackAndDestroy(typeof(HexCustomMoveUI));
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