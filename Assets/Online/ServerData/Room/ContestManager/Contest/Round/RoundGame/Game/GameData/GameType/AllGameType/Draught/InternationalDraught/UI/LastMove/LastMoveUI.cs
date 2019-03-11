using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using InternationalDraught.NoneRule;

namespace InternationalDraught
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
                            case GameMove.Type.InternationalDraughtMove:
                                {
                                    InternationalDraughtMove internationalDraughtMove = lastMove as InternationalDraughtMove;
                                    // UIData
                                    InternationalDraughtMoveUI.UIData internationalDraughtMoveUIData = this.data.sub.newOrOld<InternationalDraughtMoveUI.UIData>();
                                    {
                                        // move
                                        internationalDraughtMoveUIData.internationalDraughtMove.v = new ReferenceData<InternationalDraughtMove>(internationalDraughtMove);
                                        // isHint
                                        internationalDraughtMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = internationalDraughtMoveUIData;
                                }
                                break;
                            case GameMove.Type.InternationalDraughtCustomSet:
                                {
                                    InternationalDraughtCustomSet internationalDraughtCustomSet = lastMove as InternationalDraughtCustomSet;
                                    // Find
                                    InternationalDraughtCustomSetUI.UIData internationalDraughtCustomSetUIData = this.data.sub.newOrOld<InternationalDraughtCustomSetUI.UIData>();
                                    {
                                        // move
                                        internationalDraughtCustomSetUIData.internationalDraughtCustomSet.v = new ReferenceData<InternationalDraughtCustomSet>(internationalDraughtCustomSet);
                                        // isHint
                                        internationalDraughtCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = internationalDraughtCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.InternationalDraughtCustomMove:
                                {
                                    InternationalDraughtCustomMove internationalDraughtCustomMove = lastMove as InternationalDraughtCustomMove;
                                    // Find
                                    InternationalDraughtCustomMoveUI.UIData internationalDraughtCustomMoveUIData = this.data.sub.newOrOld<InternationalDraughtCustomMoveUI.UIData>();
                                    {
                                        // move
                                        internationalDraughtCustomMoveUIData.internationalDraughtCustomMove.v = new ReferenceData<InternationalDraughtCustomMove>(internationalDraughtCustomMove);
                                        // isHint
                                        internationalDraughtCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = internationalDraughtCustomMoveUIData;
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

        public InternationalDraughtMoveUI internationalDraughtMovePrefab;
        public InternationalDraughtCustomSetUI internationalDraughtCustomSetPrefab;
        public InternationalDraughtCustomMoveUI internationalDraughtCustomMovePrefab;

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
                        case GameMove.Type.InternationalDraughtMove:
                            {
                                InternationalDraughtMoveUI.UIData internationalDraughtMoveUIData = lastMoveSub as InternationalDraughtMoveUI.UIData;
                                UIUtils.Instantiate(internationalDraughtMoveUIData, internationalDraughtMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.InternationalDraughtCustomSet:
                            {
                                InternationalDraughtCustomSetUI.UIData internationalDraughtCustomSetUIData = lastMoveSub as InternationalDraughtCustomSetUI.UIData;
                                UIUtils.Instantiate(internationalDraughtCustomSetUIData, internationalDraughtCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.InternationalDraughtCustomMove:
                            {
                                InternationalDraughtCustomMoveUI.UIData internationalDraughtCustomMoveUIData = lastMoveSub as InternationalDraughtCustomMoveUI.UIData;
                                UIUtils.Instantiate(internationalDraughtCustomMoveUIData, internationalDraughtCustomMovePrefab, this.transform);
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
                        case GameMove.Type.InternationalDraughtMove:
                            {
                                InternationalDraughtMoveUI.UIData internationalDraughtMoveUIData = lastMoveSub as InternationalDraughtMoveUI.UIData;
                                internationalDraughtMoveUIData.removeCallBackAndDestroy(typeof(InternationalDraughtMoveUI));
                            }
                            break;
                        case GameMove.Type.InternationalDraughtCustomSet:
                            {
                                InternationalDraughtCustomSetUI.UIData internationalDraughtCustomSetUIData = lastMoveSub as InternationalDraughtCustomSetUI.UIData;
                                internationalDraughtCustomSetUIData.removeCallBackAndDestroy(typeof(InternationalDraughtCustomSetUI));
                            }
                            break;
                        case GameMove.Type.InternationalDraughtCustomMove:
                            {
                                InternationalDraughtCustomMoveUI.UIData internationalDraughtCustomMoveUIData = lastMoveSub as InternationalDraughtCustomMoveUI.UIData;
                                internationalDraughtCustomMoveUIData.removeCallBackAndDestroy(typeof(InternationalDraughtCustomMoveUI));
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