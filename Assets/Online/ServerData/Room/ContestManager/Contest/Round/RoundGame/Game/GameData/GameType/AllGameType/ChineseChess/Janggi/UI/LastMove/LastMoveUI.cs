using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Janggi.NoneRule;

namespace Janggi
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
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Janggi ? 1 : 0;
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
                            case GameMove.Type.JanggiMove:
                                {
                                    JanggiMove janggiMove = lastMove as JanggiMove;
                                    // Find
                                    JanggiMoveUI.UIData janggiMoveUIData = this.data.sub.newOrOld<JanggiMoveUI.UIData>();
                                    {
                                        // move
                                        janggiMoveUIData.janggiMove.v = new ReferenceData<JanggiMove>(janggiMove);
                                        // isHint
                                        janggiMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = janggiMoveUIData;
                                }
                                break;
                            case GameMove.Type.JanggiCustomMove:
                                {
                                    JanggiCustomMove janggiCustomMove = lastMove as JanggiCustomMove;
                                    // Find
                                    JanggiCustomMoveUI.UIData janggiCustomMoveUIData = this.data.sub.newOrOld<JanggiCustomMoveUI.UIData>();
                                    {
                                        // move
                                        janggiCustomMoveUIData.janggiCustomMove.v = new ReferenceData<JanggiCustomMove>(janggiCustomMove);
                                        // isHint
                                        janggiCustomMoveUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = janggiCustomMoveUIData;
                                }
                                break;
                            case GameMove.Type.JanggiCustomSet:
                                {
                                    JanggiCustomSet janggiCustomSet = lastMove as JanggiCustomSet;
                                    // Find
                                    JanggiCustomSetUI.UIData janggiCustomSetUIData = this.data.sub.newOrOld<JanggiCustomSetUI.UIData>();
                                    {
                                        // move
                                        janggiCustomSetUIData.janggiCustomSet.v = new ReferenceData<JanggiCustomSet>(janggiCustomSet);
                                        // isHint
                                        janggiCustomSetUIData.isHint.v = false;
                                    }
                                    this.data.sub.v = janggiCustomSetUIData;
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

        public JanggiMoveUI janggiMovePrefab;
        public JanggiCustomMoveUI janggiCustomMovePrefab;
        public JanggiCustomSetUI janggiCustomSetPrefab;

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
                        case GameMove.Type.JanggiMove:
                            {
                                JanggiMoveUI.UIData janggiMoveUIData = lastMoveSub as JanggiMoveUI.UIData;
                                UIUtils.Instantiate(janggiMoveUIData, janggiMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.JanggiCustomMove:
                            {
                                JanggiCustomMoveUI.UIData janggiCustomMoveUIData = lastMoveSub as JanggiCustomMoveUI.UIData;
                                UIUtils.Instantiate(janggiCustomMoveUIData, janggiCustomMovePrefab, this.transform);
                            }
                            break;
                        case GameMove.Type.JanggiCustomSet:
                            {
                                JanggiCustomSetUI.UIData janggiCustomSetUIData = lastMoveSub as JanggiCustomSetUI.UIData;
                                UIUtils.Instantiate(janggiCustomSetUIData, janggiCustomSetPrefab, this.transform);
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
                        case GameMove.Type.JanggiMove:
                            {
                                JanggiMoveUI.UIData janggiMoveUIData = lastMoveSub as JanggiMoveUI.UIData;
                                janggiMoveUIData.removeCallBackAndDestroy(typeof(JanggiMoveUI));
                            }
                            break;
                        case GameMove.Type.JanggiCustomMove:
                            {
                                JanggiCustomMoveUI.UIData janggiCustomMoveUIData = lastMoveSub as JanggiCustomMoveUI.UIData;
                                janggiCustomMoveUIData.removeCallBackAndDestroy(typeof(JanggiCustomMoveUI));
                            }
                            break;
                        case GameMove.Type.JanggiCustomSet:
                            {
                                JanggiCustomSetUI.UIData janggiCustomSetUIData = lastMoveSub as JanggiCustomSetUI.UIData;
                                janggiCustomSetUIData.removeCallBackAndDestroy(typeof(JanggiCustomSetUI));
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