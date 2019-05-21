using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.UseRule
{
    public class ClickDestUI : UIBehavior<ClickDestUI.UIData>
    {

        #region UIData

        public class UIData : ShowUI.UIData.Sub
        {

            public VP<int> square;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    /** Receive click dest position event*/
                    Click,
                    /** Choose move*/
                    Choose
                }

                public abstract Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                square,
                sub
            }

            public UIData() : base()
            {
                this.square = new VP<int>(this, (byte)Property.square, 0);
                this.sub = new VP<Sub>(this, (byte)Property.sub, new ClickDestClickUI.UIData());
            }

            #endregion

            public override Type getType()
            {
                return Type.ClickDest;
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
                            Debug.LogError("sub null: " + this);
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.EnglishDraught ? 1 : 0;
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
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return false;
        }

        #endregion

        #region implement callBacks

        public ClickDestClickUI clickDestClickPrefab;
        public ClickDestChooseUI clickDestChoosePrefab;

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
                        case UIData.Sub.Type.Click:
                            {
                                ClickDestClickUI.UIData clickDestClickUIData = sub as ClickDestClickUI.UIData;
                                UIUtils.Instantiate(clickDestClickUIData, clickDestClickPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Choose:
                            {
                                ClickDestChooseUI.UIData clickDestChooseUIData = sub as ClickDestChooseUI.UIData;
                                UIUtils.Instantiate(clickDestChooseUIData, clickDestChoosePrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
                        case UIData.Sub.Type.Click:
                            {
                                ClickDestClickUI.UIData clickDestClickUIData = sub as ClickDestClickUI.UIData;
                                clickDestClickUIData.removeCallBackAndDestroy(typeof(ClickDestClickUI));
                            }
                            break;
                        case UIData.Sub.Type.Choose:
                            {
                                ClickDestChooseUI.UIData clickDestChooseUIData = sub as ClickDestChooseUI.UIData;
                                clickDestChooseUIData.removeCallBackAndDestroy(typeof(ClickDestChooseUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
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
                    case UIData.Property.square:
                        break;
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
            if(wrapProperty.p is UIData.Sub)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}