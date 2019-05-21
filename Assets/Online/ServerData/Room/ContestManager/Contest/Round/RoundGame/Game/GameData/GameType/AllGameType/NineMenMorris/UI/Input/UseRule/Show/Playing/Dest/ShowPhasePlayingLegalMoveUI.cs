using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
    public class ShowPhasePlayingLegalMoveUI : UIBehavior<ShowPhasePlayingLegalMoveUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<NineMenMorrisMove>> nineMenMorrisMove;

            #region Constructor

            public enum Property
            {
                nineMenMorrisMove
            }

            public UIData() : base()
            {
                this.nineMenMorrisMove = new VP<ReferenceData<NineMenMorrisMove>>(this, (byte)Property.nineMenMorrisMove, new ReferenceData<NineMenMorrisMove>(null));
            }

            #endregion

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.NineMenMorris ? 1 : 0;
        }

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    NineMenMorrisMove nineMenMorrisMove = this.data.nineMenMorrisMove.v.data;
                    if (nineMenMorrisMove != null)
                    {
                        this.transform.localPosition = Common.convertPositionToLocal(nineMenMorrisMove.moved_to.v);
                    }
                    else
                    {
                        Debug.LogError("nineMenMorrisMove null");
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
                    uiData.nineMenMorrisMove.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is NineMenMorrisMove)
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
                    uiData.nineMenMorrisMove.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is NineMenMorrisMove)
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
                    case UIData.Property.nineMenMorrisMove:
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
            if (wrapProperty.p is NineMenMorrisMove)
            {
                switch ((NineMenMorrisMove.Property)wrapProperty.n)
                {
                    case NineMenMorrisMove.Property.moved:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.moved_to:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.action:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.mill:
                        dirty = true;
                        break;
                    case NineMenMorrisMove.Property.removed:
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