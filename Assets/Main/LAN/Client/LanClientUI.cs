using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LanClientUI : UIBehavior<LanClientUI.UIData>
{

    #region UIData

    public class UIData : LanUI.UIData.Sub
    {

        public abstract class Sub : Data
        {

            public enum Type
            {
                Menu,
                Play
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<Sub> sub;

        #region Constructor

        public enum Property
        {
            sub
        }

        public UIData() : base()
        {
            this.sub = new VP<Sub>(this, (byte)Property.sub, new LanClientMenuUI.UIData());
        }

        #endregion

        public override LanUI.UIData.Sub.Type getType()
        {
            return LanUI.UIData.Sub.Type.Client;
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

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                Sub sub = this.sub.v;
                if (sub != null)
                {
                    ret = sub.getAllowShowBanner();
                }
                else
                {
                    Debug.LogError("sub null");
                }
            }
            return ret;
        }

    }

    #endregion

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

    public LanClientMenuUI lanClientMenuPrefab;
    public LanClientPlayUI lanClientPlayPrefab;

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
                    case UIData.Sub.Type.Menu:
                        {
                            LanClientMenuUI.UIData menu = sub as LanClientMenuUI.UIData;
                            UIUtils.Instantiate(menu, lanClientMenuPrefab, this.transform);
                        }
                        break;
                    case UIData.Sub.Type.Play:
                        {
                            LanClientPlayUI.UIData play = sub as LanClientPlayUI.UIData;
                            UIUtils.Instantiate(play, lanClientPlayPrefab, this.transform);
                        }
                        break;
                    default:
                        Debug.LogError("unknown sub type: " + sub.getType());
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
                    case UIData.Sub.Type.Menu:
                        {
                            LanClientMenuUI.UIData menu = sub as LanClientMenuUI.UIData;
                            menu.removeCallBackAndDestroy(typeof(LanClientMenuUI));
                        }
                        break;
                    case UIData.Sub.Type.Play:
                        {
                            LanClientPlayUI.UIData play = sub as LanClientPlayUI.UIData;
                            play.removeCallBackAndDestroy(typeof(LanClientPlayUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknown sub type: " + sub.getType());
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
            switch ((LanClientUI.UIData.Property)wrapProperty.n)
            {
                case LanClientUI.UIData.Property.sub:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}