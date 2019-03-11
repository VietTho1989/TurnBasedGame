using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
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
                            case GameMove.Type.SolitaireMove:
                                {
                                    SolitaireMove solitaireMove = lastMove as SolitaireMove;
                                    // Find
                                    SolitaireMoveUI.UIData solitaireMoveUIData = this.data.sub.newOrOld<SolitaireMoveUI.UIData>();
                                    {
                                        // move
                                        solitaireMoveUIData.solitaireMove.v = new ReferenceData<SolitaireMove>(solitaireMove);
                                        // isHint
                                        solitaireMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = solitaireMoveUIData;
                                }
                                break;
                            case GameMove.Type.SolitaireReset:
                                {
                                    SolitaireReset solitaireReset = lastMove as SolitaireReset;
                                    // Find
                                    SolitaireResetUI.UIData solitaireResetUIData = this.data.sub.newOrOld<SolitaireResetUI.UIData>();
                                    {
                                        // move
                                        solitaireResetUIData.solitaireReset.v = new ReferenceData<SolitaireReset>(solitaireReset);
                                        // isHint
                                        solitaireResetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = solitaireResetUIData;
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

        public SolitaireMoveUI solitaireMovePrefab;
        public SolitaireResetUI solitaireResetPrefab;

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
                        case GameMove.Type.SolitaireMove:
                            {
                                SolitaireMoveUI.UIData solitaireMoveUIData = lastMoveSub as SolitaireMoveUI.UIData;
                                UIUtils.Instantiate(solitaireMoveUIData, solitaireMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.SolitaireReset:
                            {
                                SolitaireResetUI.UIData solitaireResetUIData = lastMoveSub as SolitaireResetUI.UIData;
                                UIUtils.Instantiate(solitaireResetUIData, solitaireResetPrefab, this.transform);
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
                        case GameMove.Type.SolitaireMove:
                            {
                                SolitaireMoveUI.UIData solitaireMoveUIData = lastMoveSub as SolitaireMoveUI.UIData;
                                solitaireMoveUIData.removeCallBackAndDestroy(typeof(SolitaireMoveUI));
                            }
                            break;
                        case GameMove.Type.SolitaireReset:
                            {
                                SolitaireResetUI.UIData solitaireResetUIData = lastMoveSub as SolitaireResetUI.UIData;
                                solitaireResetUIData.removeCallBackAndDestroy(typeof(SolitaireResetUI));
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