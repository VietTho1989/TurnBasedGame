using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameState
{
    public class PlayNormalUI : UIBehavior<PlayNormalUI.UIData>
    {

        #region UIData

        public class UIData : PlayUI.UIData.Sub
        {

            public VP<ReferenceData<PlayNormal>> playNormal;

            #region Constructor

            public enum Property
            {
                playNormal
            }

            public UIData() : base()
            {
                this.playNormal = new VP<ReferenceData<PlayNormal>>(this, (byte)Property.playNormal, new ReferenceData<PlayNormal>(null));
            }

            #endregion

            public override Play.Sub.Type getType()
            {
                return Play.Sub.Type.Normal;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return 1;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    PlayNormal playNormal = this.data.playNormal.v.data;
                    if (playNormal != null)
                    {

                    }
                    else
                    {
                        // Debug.LogError ("playNormal null: " + this);
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
                    uiData.playNormal.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is PlayNormal)
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
                    uiData.playNormal.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is PlayNormal)
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
                    case UIData.Property.playNormal:
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
            if (wrapProperty.p is PlayNormal)
            {
                switch ((PlayNormal.Property)wrapProperty.n)
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