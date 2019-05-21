using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
    public class SeirawanCustomHandUI : UIBehavior<SeirawanCustomHandUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {
            public VP<ReferenceData<SeirawanCustomHand>> seirawanCustomHand;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                seirawanCustomHand,
                isHint
            }

            public UIData() : base()
            {
                this.seirawanCustomHand = new VP<ReferenceData<SeirawanCustomHand>>(this, (byte)Property.seirawanCustomHand, new ReferenceData<SeirawanCustomHand>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.SeirawanCustomHand;
            }
        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Seirawan ? 1 : 0;
        }

        #region Refresh

        public Image imgHint;
        public GameObject contentContainer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    SeirawanCustomHand seirawanCustomHand = this.data.seirawanCustomHand.v.data;
                    if (seirawanCustomHand != null)
                    {
                        // imgHint
                        if (imgHint != null)
                        {
                            if (this.data.isHint.v)
                            {
                                imgHint.color = new Color(0f, 0f, 0f, 0.25f);
                            }
                            else
                            {
                                imgHint.color = new Color(0f, 0f, 0f, 0.75f);
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                        // set parent transform
                        {
                            // find
                            Transform parentTransform = null;
                            {
                                SeirawanGameDataUI.UIData seirawanGameDataUIData = this.data.findDataInParent<SeirawanGameDataUI.UIData>();
                                if (seirawanGameDataUIData != null)
                                {
                                    BoardUI.UIData boardUIData = seirawanGameDataUIData.board.v;
                                    if (boardUIData != null)
                                    {
                                        HandsUI.UIData handUIData = boardUIData.hands.v;
                                        if (handUIData != null)
                                        {
                                            HandsUI handsUI = handUIData.findCallBack<HandsUI>();
                                            if (handsUI != null)
                                            {
                                                switch (seirawanCustomHand.piece.v)
                                                {
                                                    case Common.Piece.W_ELEPHANT:
                                                        {
                                                            if (handsUI.imgWhiteElephant != null)
                                                            {
                                                                parentTransform = handsUI.imgWhiteElephant.transform;
                                                            }
                                                        }
                                                        break;
                                                    case Common.Piece.W_HAWK:
                                                        {
                                                            if (handsUI.imgWhiteHawk != null)
                                                            {
                                                                parentTransform = handsUI.imgWhiteHawk.transform;
                                                            }
                                                        }
                                                        break;
                                                    case Common.Piece.B_ELEPHANT:
                                                        {
                                                            if (handsUI.imgBlackElephant != null)
                                                            {
                                                                parentTransform = handsUI.imgBlackElephant.transform;
                                                            }
                                                        }
                                                        break;
                                                    case Common.Piece.B_HAWK:
                                                        {
                                                            if (handsUI.imgBlackHawk != null)
                                                            {
                                                                parentTransform = handsUI.imgBlackHawk.transform;
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown piece: " + seirawanCustomHand.piece.v + "; " + this);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("handsUI null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("handUIData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("boardUIData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("seirawanGameDataUIData null: " + this);
                                }
                            }
                            // set
                            if (parentTransform != null)
                            {
                                // contentContainer
                                if (contentContainer != null)
                                {
                                    contentContainer.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("contentContainer null: " + this);
                                }
                                // set parent
                                this.transform.SetParent(parentTransform, false);
                            }
                            else
                            {
                                Debug.LogError("parentTransform null: " + this);
                                // contentContainer
                                if (contentContainer != null)
                                {
                                    contentContainer.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("contentContainer null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("seirawanCustomHand null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.seirawanCustomHand.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is SeirawanCustomHand)
            {
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
                // Child
                {
                    uiData.seirawanCustomHand.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is SeirawanCustomHand)
            {
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
                    case UIData.Property.seirawanCustomHand:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isHint:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            if (wrapProperty.p is SeirawanCustomHand)
            {
                switch ((SeirawanCustomHand.Property)wrapProperty.n)
                {
                    case SeirawanCustomHand.Property.piece:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}