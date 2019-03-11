using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Makruk.NoneRule;

namespace Makruk
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
                            case GameMove.Type.MakrukMove:
                                {
                                    MakrukMove makrukMove = lastMove as MakrukMove;
                                    // Find
                                    MakrukMoveUI.UIData makrukMoveUIData = this.data.sub.newOrOld<MakrukMoveUI.UIData>();
                                    {
                                        // move
                                        makrukMoveUIData.makrukMove.v = new ReferenceData<MakrukMove>(makrukMove);
                                        // isHint
                                        makrukMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = makrukMoveUIData;
                                }
                                break;
                            case GameMove.Type.MakrukCustomSet:
                                {
                                    MakrukCustomSet makrukCustomSet = lastMove as MakrukCustomSet;
                                    // Find
                                    MakrukCustomSetUI.UIData makrukCustomSetUIData = this.data.sub.newOrOld<MakrukCustomSetUI.UIData>();
                                    {
                                        // move
                                        makrukCustomSetUIData.makrukCustomSet.v = new ReferenceData<MakrukCustomSet>(makrukCustomSet);
                                        // isHint
                                        makrukCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = makrukCustomSetUIData;
                                }
                                break;
                            case GameMove.Type.MakrukCustomMove:
                                {
                                    MakrukCustomMove makrukCustomMove = lastMove as MakrukCustomMove;
                                    // Find
                                    MakrukCustomMoveUI.UIData makrukCustomMoveUIData = this.data.sub.newOrOld<MakrukCustomMoveUI.UIData>();
                                    {
                                        // move
                                        makrukCustomMoveUIData.makrukCustomMove.v = new ReferenceData<MakrukCustomMove>(makrukCustomMove);
                                        // isHint
                                        makrukCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = makrukCustomMoveUIData;
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

        public MakrukMoveUI makrukMovePrefab;
        public MakrukCustomSetUI makrukCustomSetPrefab;
        public MakrukCustomMoveUI makrukCustomMovePrefab;

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
                        case GameMove.Type.MakrukMove:
                            {
                                MakrukMoveUI.UIData makrukMoveUIData = lastMoveSub as MakrukMoveUI.UIData;
                                UIUtils.Instantiate(makrukMoveUIData, makrukMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.MakrukCustomSet:
                            {
                                MakrukCustomSetUI.UIData makrukCustomSetUIData = lastMoveSub as MakrukCustomSetUI.UIData;
                                UIUtils.Instantiate(makrukCustomSetUIData, makrukCustomSetPrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.MakrukCustomMove:
                            {
                                MakrukCustomMoveUI.UIData makrukCustomMoveUIData = lastMoveSub as MakrukCustomMoveUI.UIData;
                                UIUtils.Instantiate(makrukCustomMoveUIData, makrukCustomMovePrefab, this.transform);
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
                        case GameMove.Type.MakrukMove:
                            {
                                MakrukMoveUI.UIData makrukMoveUIData = lastMoveSub as MakrukMoveUI.UIData;
                                makrukMoveUIData.removeCallBackAndDestroy(typeof(MakrukMoveUI));
                            }
                            break;
                        case GameMove.Type.MakrukCustomSet:
                            {
                                MakrukCustomSetUI.UIData makrukCustomSetUIData = lastMoveSub as MakrukCustomSetUI.UIData;
                                makrukCustomSetUIData.removeCallBackAndDestroy(typeof(MakrukCustomSetUI));
                            }
                            break;
                        case GameMove.Type.MakrukCustomMove:
                            {
                                MakrukCustomMoveUI.UIData makrukCustomMoveUIData = lastMoveSub as MakrukCustomMoveUI.UIData;
                                makrukCustomMoveUIData.removeCallBackAndDestroy(typeof(MakrukCustomMoveUI));
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