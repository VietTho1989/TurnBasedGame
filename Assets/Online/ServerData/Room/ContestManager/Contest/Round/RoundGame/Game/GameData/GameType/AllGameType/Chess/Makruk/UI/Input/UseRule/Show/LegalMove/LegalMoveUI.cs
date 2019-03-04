using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Makruk.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {
            public VP<ReferenceData<MakrukMove>> legalMove;

            #region Constructor

            public enum Property
            {
                legalMove
            }

            public UIData() : base()
            {
                this.legalMove = new VP<ReferenceData<MakrukMove>>(this, (byte)Property.legalMove, new ReferenceData<MakrukMove>(null));
            }

            #endregion
        }

        #endregion

        #region Refresh

        public GameObject contentContainer;

        public UICircle ivType;
        private static readonly Color normalColor = Color.blue;
        private static readonly Color promotionColor = Color.yellow;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // contentContainer
                    if (contentContainer != null)
                    {
                        if (this.data.legalMove.v.data != null)
                        {
                            contentContainer.SetActive(true);
                        }
                        else
                        {
                            contentContainer.SetActive(false);
                        }
                    }
                    else
                    {
                        Debug.LogError("contentContainer null: " + this);
                    }
                    // Update
                    {
                        MakrukMove legalMove = this.data.legalMove.v.data;
                        if (legalMove != null)
                        {
                            // position
                            {
                                int fromX = 0;
                                int fromY = 0;
                                int destX = 0;
                                int destY = 0;
                                MakrukMove.GetClickPosition(legalMove.move.v, out fromX, out fromY, out destX, out destY);
                                this.transform.localPosition = new Vector3(destX - 3.5f, destY - 3.5f, 0);
                            }
                            // ivType
                            if (ivType != null)
                            {
                                MakrukMove.Move move = new MakrukMove.Move(legalMove.move.v);
                                switch (move.type)
                                {
                                    case Common.MoveType.NORMAL:
                                        ivType.color = normalColor;
                                        break;
                                    case Common.MoveType.PROMOTION:
                                        ivType.color = promotionColor;
                                        break;
                                    default:
                                        Debug.LogError("unknown move type: " + move.type + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("imgType null: " + this);
                            }
                        }
                        else
                        {
                            Debug.LogError("legalMove null: " + this);
                        }
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.legalMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            if (data is MakrukMove)
            {
                // MakrukMove legalMove = data as MakrukMove;
                {

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
                {
                    uiData.legalMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            if (data is MakrukMove)
            {
                // MakrukMove legalMove = data as MakrukMove;
                {

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
                    case UIData.Property.legalMove:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is MakrukMove)
            {
                switch ((MakrukMove.Property)wrapProperty.n)
                {
                    case MakrukMove.Property.move:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}