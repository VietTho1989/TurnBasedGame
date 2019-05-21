using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris.UseRule
{
    public class ShowPhasePositioningUI : UIBehavior<ShowPhasePositioningUI.UIData>
    {

        #region UIData

        public class UIData : ShowUI.UIData.Sub
        {

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    Place,
                    Remove
                }

                public abstract Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                sub
            }

            public UIData() : base()
            {
                this.sub = new VP<Sub>(this, (byte)Property.sub, new ShowPhasePositioningPlaceUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.Positioning;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // sub
                    if (!isProcess)
                    {
                        Sub sub = this.sub.v;
                        if (sub != null)
                        {
                            isProcess = sub.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("sub null");
                        }
                    }
                }
                return isProcess;
            }

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

        public ShowPhasePositioningPlaceUI placePrefab;
        public ShowPhasePositioningRemoveUI removePrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Place:
                            {
                                ShowPhasePositioningPlaceUI.UIData placeUIData = sub as ShowPhasePositioningPlaceUI.UIData;
                                UIUtils.Instantiate(placeUIData, placePrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Remove:
                            {
                                ShowPhasePositioningRemoveUI.UIData removeUIData = sub as ShowPhasePositioningRemoveUI.UIData;
                                UIUtils.Instantiate(removeUIData, removePrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unkown type: " + sub.getType());
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
                // Child
                {
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Place:
                            {
                                ShowPhasePositioningPlaceUI.UIData placeUIData = sub as ShowPhasePositioningPlaceUI.UIData;
                                placeUIData.removeCallBackAndDestroy(typeof(ShowPhasePositioningPlaceUI));
                            }
                            break;
                        case UIData.Sub.Type.Remove:
                            {
                                ShowPhasePositioningRemoveUI.UIData removeUIData = sub as ShowPhasePositioningRemoveUI.UIData;
                                removeUIData.removeCallBackAndDestroy(typeof(ShowPhasePositioningRemoveUI));
                            }
                            break;
                        default:
                            Debug.LogError("unkown type: " + sub.getType());
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
            // Child
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}