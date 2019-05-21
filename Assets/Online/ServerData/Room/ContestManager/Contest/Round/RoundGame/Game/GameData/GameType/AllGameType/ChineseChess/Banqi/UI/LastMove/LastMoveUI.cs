using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Banqi.NoneRule;

namespace Banqi
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Banqi ? 1 : 0;
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
                            case GameMove.Type.BanqiMove:
                                {
                                    BanqiMove banqiMove = lastMove as BanqiMove;
                                    // Find
                                    BanqiMoveUI.UIData banqiMoveUIData = this.data.sub.newOrOld<BanqiMoveUI.UIData>();
                                    {
                                        // move
                                        banqiMoveUIData.banqiMove.v = new ReferenceData<BanqiMove>(banqiMove);
                                        // isHint
                                        banqiMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = banqiMoveUIData;
                                }
                                break;
                            case GameMove.Type.BanqiCustomMove:
                                {
                                    BanqiCustomMove banqiCustomMove = lastMove as BanqiCustomMove;
                                    // Find
                                    BanqiCustomMoveUI.UIData banqiCustomMoveUIData = this.data.sub.newOrOld<BanqiCustomMoveUI.UIData>();
                                    {
                                        // move
                                        banqiCustomMoveUIData.banqiCustomMove.v = new ReferenceData<BanqiCustomMove>(banqiCustomMove);
                                        // isHint
                                        banqiCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = banqiCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.BanqiCustomSet:
                                {
                                    BanqiCustomSet banqiCustomSet = lastMove as BanqiCustomSet;
                                    // Find
                                    BanqiCustomSetUI.UIData banqiCustomSetUIData = this.data.sub.newOrOld<BanqiCustomSetUI.UIData>();
                                    {
                                        // move
                                        banqiCustomSetUIData.banqiCustomSet.v = new ReferenceData<BanqiCustomSet>(banqiCustomSet);
                                        // isHint
                                        banqiCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = banqiCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.BanqiCustomFlip:
                                {
                                    BanqiCustomFlip banqiCustomFlip = lastMove as BanqiCustomFlip;
                                    // Find
                                    BanqiCustomFlipUI.UIData banqiCustomFlipUIData = this.data.sub.newOrOld<BanqiCustomFlipUI.UIData>();
                                    {
                                        // move
                                        banqiCustomFlipUIData.banqiCustomFlip.v = new ReferenceData<BanqiCustomFlip>(banqiCustomFlip);
                                        // isHint
                                        banqiCustomFlipUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = banqiCustomFlipUIData;
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

        public BanqiMoveUI banqiMovePrefab;
        public BanqiCustomMoveUI banqiCustomMovePrefab;
        public BanqiCustomSetUI banqiCustomSetPrefab;
        public BanqiCustomFlipUI banqiCustomFlipPrefab;

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
                        case GameMove.Type.BanqiMove:
                            {
                                BanqiMoveUI.UIData banqiMoveUIData = lastMoveSub as BanqiMoveUI.UIData;
                                UIUtils.Instantiate(banqiMoveUIData, banqiMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.BanqiCustomMove:
                            {
                                BanqiCustomMoveUI.UIData banqiCustomMoveUIData = lastMoveSub as BanqiCustomMoveUI.UIData;
                                UIUtils.Instantiate(banqiCustomMoveUIData, banqiCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.BanqiCustomSet:
                            {
                                BanqiCustomSetUI.UIData banqiCustomSetUIData = lastMoveSub as BanqiCustomSetUI.UIData;
                                UIUtils.Instantiate(banqiCustomSetUIData, banqiCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.BanqiCustomFlip:
                            {
                                BanqiCustomFlipUI.UIData banqiCustomFlipUIData = lastMoveSub as BanqiCustomFlipUI.UIData;
                                UIUtils.Instantiate(banqiCustomFlipUIData, banqiCustomFlipPrefab, this.transform);
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
                        case GameMove.Type.BanqiMove:
                            {
                                BanqiMoveUI.UIData banqiMoveUIData = lastMoveSub as BanqiMoveUI.UIData;
                                banqiMoveUIData.removeCallBackAndDestroy(typeof(BanqiMoveUI));
                            }
                            break;
                        case GameMove.Type.BanqiCustomMove:
                            {
                                BanqiCustomMoveUI.UIData banqiCustomMoveUIData = lastMoveSub as BanqiCustomMoveUI.UIData;
                                banqiCustomMoveUIData.removeCallBackAndDestroy(typeof(BanqiCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.BanqiCustomSet:
                            {
                                BanqiCustomSetUI.UIData banqiCustomSetUIData = lastMoveSub as BanqiCustomSetUI.UIData;
                                banqiCustomSetUIData.removeCallBackAndDestroy(typeof(BanqiCustomSetUI));
                            }
                            break;
                        case GameMove.Type.BanqiCustomFlip:
                            {
                                BanqiCustomFlipUI.UIData banqiCustomFlipUIData = lastMoveSub as BanqiCustomFlipUI.UIData;
                                banqiCustomFlipUIData.removeCallBackAndDestroy(typeof(BanqiCustomFlipUI));
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