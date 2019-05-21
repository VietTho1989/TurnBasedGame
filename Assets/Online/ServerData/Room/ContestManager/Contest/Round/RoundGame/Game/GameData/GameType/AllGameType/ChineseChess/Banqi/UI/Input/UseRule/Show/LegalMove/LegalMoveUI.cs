using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Banqi.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<BanqiMove>> banqiMove;

            #region Constructor

            public enum Property
            {
                banqiMove
            }

            public UIData() : base()
            {
                this.banqiMove = new VP<ReferenceData<BanqiMove>>(this, (byte)Property.banqiMove, new ReferenceData<BanqiMove>(null));
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Banqi ? 1 : 0;
        }

        #region Refresh

        public UICircle ivLegal;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    BanqiMove banqiMove = this.data.banqiMove.v.data;
                    if (banqiMove != null)
                    {
                        // enable
                        if (ivLegal != null)
                        {
                            ivLegal.gameObject.SetActive(true);
                        }
                        else
                        {
                            Debug.LogError("ivLegal null");
                        }
                        // position
                        this.transform.localPosition = Common.convertPosToLocalPosition(8 * (3 - (banqiMove.destY.v - 1)) + (banqiMove.destX.v - 1));
                    }
                    else
                    {
                        // Debug.LogError ("banqiMove null");
                        // enable
                        if (ivLegal != null)
                        {
                            ivLegal.gameObject.SetActive(false);
                        }
                        else
                        {
                            Debug.LogError("ivLegal null");
                        }
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.banqiMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is BanqiMove)
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
                    uiData.banqiMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is BanqiMove)
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
                    case UIData.Property.banqiMove:
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
            // Child
            if (wrapProperty.p is BanqiMove)
            {
                switch ((BanqiMove.Property)wrapProperty.n)
                {
                    case BanqiMove.Property.fromX:
                        dirty = true;
                        break;
                    case BanqiMove.Property.fromY:
                        dirty = true;
                        break;
                    case BanqiMove.Property.destX:
                        dirty = true;
                        break;
                    case BanqiMove.Property.destY:
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