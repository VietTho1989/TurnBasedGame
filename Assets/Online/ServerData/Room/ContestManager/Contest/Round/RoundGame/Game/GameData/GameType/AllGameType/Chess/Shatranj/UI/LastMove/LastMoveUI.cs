using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Shatranj.NoneRule;

namespace Shatranj
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Shatranj ? 1 : 0;
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
                            case GameMove.Type.ShatranjMove:
                                {
                                    ShatranjMove shatranjMove = lastMove as ShatranjMove;
                                    // Find
                                    ShatranjMoveUI.UIData shatranjMoveUIData = this.data.sub.newOrOld<ShatranjMoveUI.UIData>();
                                    {
                                        // move
                                        shatranjMoveUIData.shatranjMove.v = new ReferenceData<ShatranjMove>(shatranjMove);
                                        // isHint
                                        shatranjMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shatranjMoveUIData;
                                }
                                break;
                            case GameMove.Type.ShatranjCustomSet:
                                {
                                    ShatranjCustomSet shatranjCustomSet = lastMove as ShatranjCustomSet;
                                    // Find
                                    ShatranjCustomSetUI.UIData shatranjCustomSetUIData = this.data.sub.newOrOld<ShatranjCustomSetUI.UIData>();
                                    {
                                        // move
                                        shatranjCustomSetUIData.shatranjCustomSet.v = new ReferenceData<ShatranjCustomSet>(shatranjCustomSet);
                                        // isHint
                                        shatranjCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shatranjCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.ShatranjCustomMove:
                                {
                                    ShatranjCustomMove shatranjCustomMove = lastMove as ShatranjCustomMove;
                                    // Find
                                    ShatranjCustomMoveUI.UIData shatranjCustomMoveUIData = this.data.sub.newOrOld<ShatranjCustomMoveUI.UIData>();
                                    {
                                        // move
                                        shatranjCustomMoveUIData.shatranjCustomMove.v = new ReferenceData<ShatranjCustomMove>(shatranjCustomMove);
                                        // isHint
                                        shatranjCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shatranjCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.ShatranjCustomFen:
                                {
                                    ShatranjCustomFen shatranjCustomFen = lastMove as ShatranjCustomFen;
                                    // Find
                                    ShatranjCustomFenUI.UIData shatranjCustomFenUIData = this.data.sub.newOrOld<ShatranjCustomFenUI.UIData>();
                                    {
                                        // move
                                        shatranjCustomFenUIData.shatranjCustomFen.v = new ReferenceData<ShatranjCustomFen>(shatranjCustomFen);
                                        // isHint
                                        shatranjCustomFenUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = shatranjCustomFenUIData;
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

        public ShatranjMoveUI shatranjMovePrefab;
        public ShatranjCustomSetUI shatranjCustomSetPrefab;
        public ShatranjCustomMoveUI shatranjCustomMovePrefab;
        public ShatranjCustomFenUI shatranjCustomFenPrefab;

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
                        case GameMove.Type.ShatranjMove:
                            {
                                ShatranjMoveUI.UIData shatranjMoveUIData = lastMoveSub as ShatranjMoveUI.UIData;
                                UIUtils.Instantiate(shatranjMoveUIData, shatranjMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ShatranjCustomSet:
                            {
                                ShatranjCustomSetUI.UIData shatranjCustomSetUIData = lastMoveSub as ShatranjCustomSetUI.UIData;
                                UIUtils.Instantiate(shatranjCustomSetUIData, shatranjCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ShatranjCustomMove:
                            {
                                ShatranjCustomMoveUI.UIData shatranjCustomMoveUIData = lastMoveSub as ShatranjCustomMoveUI.UIData;
                                UIUtils.Instantiate(shatranjCustomMoveUIData, shatranjCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.ShatranjCustomFen:
                            {
                                ShatranjCustomFenUI.UIData shatranjCustomFenUIData = lastMoveSub as ShatranjCustomFenUI.UIData;
                                UIUtils.Instantiate(shatranjCustomFenUIData, shatranjCustomFenPrefab, this.transform);
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
                        case GameMove.Type.ShatranjMove:
                            {
                                ShatranjMoveUI.UIData shatranjMoveUIData = lastMoveSub as ShatranjMoveUI.UIData;
                                shatranjMoveUIData.removeCallBackAndDestroy(typeof(ShatranjMoveUI));
                            }
                            break;
                        case GameMove.Type.ShatranjCustomSet:
                            {
                                ShatranjCustomSetUI.UIData shatranjCustomSetUIData = lastMoveSub as ShatranjCustomSetUI.UIData;
                                shatranjCustomSetUIData.removeCallBackAndDestroy(typeof(ShatranjCustomSetUI));
                            }
                            break;
                        case GameMove.Type.ShatranjCustomMove:
                            {
                                ShatranjCustomMoveUI.UIData shatranjCustomMoveUIData = lastMoveSub as ShatranjCustomMoveUI.UIData;
                                shatranjCustomMoveUIData.removeCallBackAndDestroy(typeof(ShatranjCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.ShatranjCustomFen:
                            {
                                ShatranjCustomFenUI.UIData shatranjCustomFenUIData = lastMoveSub as ShatranjCustomFenUI.UIData;
                                shatranjCustomFenUIData.removeCallBackAndDestroy(typeof(ShatranjCustomFenUI));
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