using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using Rule;

namespace CoTuongUp.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<CoTuongUpMove>> legalMove;

            #region Constructor

            public enum Property
            {
                legalMove
            }

            public UIData() : base()
            {
                this.legalMove = new VP<ReferenceData<CoTuongUpMove>>(this, (byte)Property.legalMove, new ReferenceData<CoTuongUpMove>(null));
            }

            #endregion

        }

        #endregion

        #region Refresh

        public GameObject contentContainer;

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
                        CoTuongUpMove legalMove = this.data.legalMove.v.data;
                        if (legalMove != null)
                        {
                            // position
                            {
                                Rules.Move move = CoTuongUpMove.getMove(legalMove.move.v);
                                byte coord = Common.makeCoord(move.dest.x, move.dest.y);
                                this.transform.localPosition = Common.convertCoordToLocalPosition(coord);
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
            if (data is CoTuongUpMove)
            {
                // CoTuongUpMove coTuongUpMove = data as CoTuongUpMove;
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
            if (data is CoTuongUpMove)
            {
                // CoTuongUpMove coTuongUpMove = data as CoTuongUpMove;
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
            if (wrapProperty.p is CoTuongUpMove)
            {
                switch ((CoTuongUpMove.Property)wrapProperty.n)
                {
                    case CoTuongUpMove.Property.move:
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