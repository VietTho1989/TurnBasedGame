using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class LaserTargetUI : UIBehavior<LaserTargetUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Khet>> khet;

            #region Constructor

            public enum Property
            {
                khet
            }

            public UIData() : base()
            {
                this.khet = new VP<ReferenceData<Khet>>(this, (byte)Property.khet, new ReferenceData<Khet>(null));
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Khet ? 1 : 0;
        }

        #region Refresh

        public GameObject contentContainer;
        public Text tvPiece;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Khet khet = this.data.khet.v.data;
                    if (khet != null)
                    {
                        Laser laser = khet._laser.v;
                        if (laser != null)
                        {
                            // check load full
                            bool isLoadFull = true;
                            {
                                // animation
                                if (isLoadFull)
                                {
                                    isLoadFull = AnimationManager.IsLoadFull(this.data);
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                // Debug.LogError (string.Format ("targetIndex: {0}, targetSquare: {1}, targetPiece: {2}", laser._targetIndex.v, laser._targetSquare.v, laser._targetPiece.v));
                                // tvPiece
                                if (tvPiece != null)
                                {
                                    tvPiece.text = "" + laser._targetPiece.v;
                                }
                                else
                                {
                                    Debug.LogError("tvPiece null");
                                }
                                // position
                                this.transform.localPosition = Common.getLocalPosition(laser._targetIndex.v);
                                // contentContainer
                                {
                                    if (contentContainer != null)
                                    {
                                        bool isShow = false;
                                        {
                                            if (laser._targetIndex.v >= 0 && laser._targetIndex.v < khet._board.vs.Count)
                                            {
                                                if (khet._board.vs[laser._targetIndex.v] == Common.Empty)
                                                {
                                                    // check onAnimation
                                                    bool isOnAnimation = false;
                                                    {
                                                        KhetGameDataUI.UIData khetGameDataUIData = this.data.findDataInParent<KhetGameDataUI.UIData>();
                                                        if (khetGameDataUIData != null)
                                                        {
                                                            isOnAnimation = khetGameDataUIData.isOnAnimation.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("khetGameDataUIData null");
                                                        }
                                                    }
                                                    // process
                                                    if (!isOnAnimation)
                                                    {
                                                        isShow = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("outside board: " + laser._targetIndex.v + ", " + khet._board.vs.Count);
                                            }
                                        }
                                        contentContainer.SetActive(isShow);
                                    }
                                    else
                                    {
                                        Debug.LogError("contentContainer null");
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("laser null");
                        }
                    }
                    else
                    {
                        Debug.LogError("khet null");
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private KhetGameDataUI.UIData khetGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.khetGameDataUIData);
                }
                // Child
                {
                    uiData.khet.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            if (data is KhetGameDataUI.UIData)
            {
                dirty = true;
                return;
            }
            // Child
            {
                if (data is Khet)
                {
                    Khet khet = data as Khet;
                    // Child
                    {
                        khet._laser.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Laser)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.khetGameDataUIData);
                }
                // Child
                {
                    uiData.khet.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            if (data is KhetGameDataUI.UIData)
            {
                return;
            }
            // Child
            {
                if (data is Khet)
                {
                    Khet khet = data as Khet;
                    // Child
                    {
                        khet._laser.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Laser)
                {
                    return;
                }
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
                    case UIData.Property.khet:
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
            // Parent
            if (wrapProperty.p is KhetGameDataUI.UIData)
            {
                switch ((KhetGameDataUI.UIData.Property)wrapProperty.n)
                {
                    case KhetGameDataUI.UIData.Property.gameData:
                        break;
                    case KhetGameDataUI.UIData.Property.transformOrganizer:
                        break;
                    case KhetGameDataUI.UIData.Property.isOnAnimation:
                        dirty = true;
                        break;
                    case KhetGameDataUI.UIData.Property.board:
                        break;
                    case KhetGameDataUI.UIData.Property.lastMove:
                        break;
                    case KhetGameDataUI.UIData.Property.showHint:
                        break;
                    case KhetGameDataUI.UIData.Property.inputUI:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is Khet)
                {
                    switch ((Khet.Property)wrapProperty.n)
                    {
                        case Khet.Property._playerToMove:
                            break;
                        case Khet.Property._checkmate:
                            break;
                        case Khet.Property._drawn:
                            break;
                        case Khet.Property._moveNumber:
                            break;
                        case Khet.Property._laser:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Khet.Property._board:
                            dirty = true;
                            break;
                        case Khet.Property._pharaohPositions:
                            break;
                        case Khet.Property.khetSub:
                            break;
                        case Khet.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Laser)
                {
                    switch ((Laser.Property)wrapProperty.n)
                    {
                        case Laser.Property._targetIndex:
                            dirty = true;
                            break;
                        case Laser.Property._targetSquare:
                            dirty = true;
                            break;
                        case Laser.Property._targetPiece:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}