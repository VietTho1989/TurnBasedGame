using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet.UseRule
{
    public class LegalMoveUI : UIBehavior<LegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<KhetMove>> khetMove;

            #region Constructor

            public enum Property
            {
                khetMove
            }

            public UIData() : base()
            {
                this.khetMove = new VP<ReferenceData<KhetMove>>(this, (byte)Property.khetMove, new ReferenceData<KhetMove>(null));
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

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    KhetMove khetMove = this.data.khetMove.v.data;
                    if (khetMove != null)
                    {
                        if (contentContainer != null)
                        {
                            contentContainer.SetActive(true);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                        // position
                        {
                            this.transform.localPosition = Common.getLocalPosition(KhetMove.GetEnd(khetMove.move.v));
                        }
                    }
                    else
                    {
                        Debug.LogError("khetMove null");
                        if (contentContainer != null)
                        {
                            contentContainer.SetActive(false);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
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
                    uiData.khetMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is KhetMove)
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
                    uiData.khetMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is KhetMove)
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
                    case UIData.Property.khetMove:
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
            if (wrapProperty.p is KhetMove)
            {
                switch ((KhetMove.Property)wrapProperty.n)
                {
                    case KhetMove.Property.move:
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