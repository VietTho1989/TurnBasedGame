using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class SolitaireResetUI : UIBehavior<SolitaireResetUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {

            public VP<ReferenceData<SolitaireReset>> solitaireReset;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                solitaireReset,
                isHint
            }

            public UIData() : base()
            {
                this.solitaireReset = new VP<ReferenceData<SolitaireReset>>(this, (byte)Property.solitaireReset, new ReferenceData<SolitaireReset>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.SolitaireReset;
            }

        }

        #endregion

        #region Refresh

        public GameObject normal;
        public GameObject hint;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    SolitaireReset solitaireReset = this.data.solitaireReset.v.data;
                    if (solitaireReset != null)
                    {
                        if (normal != null && hint != null)
                        {
                            if (this.data.isHint.v)
                            {
                                hint.SetActive(true);
                                normal.SetActive(false);
                            }
                            else
                            {
                                normal.SetActive(true);
                                hint.SetActive(false);
                            }
                        }
                        else
                        {
                            Debug.LogError("normal, hint null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("solitaireReset null: " + this);
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
                    uiData.solitaireReset.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is SolitaireReset)
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
                    uiData.solitaireReset.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is SolitaireReset)
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
                    case UIData.Property.solitaireReset:
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
            if (wrapProperty.p is SolitaireReset)
            {
                switch ((SolitaireReset.Property)wrapProperty.n)
                {
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