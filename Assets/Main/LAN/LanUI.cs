using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class LanUI : UIBehavior<LanUI.UIData>
{

    #region UIData

    public class UIData : MainUI.UIData.Sub
    {

        public abstract class Sub : Data
        {

            public enum Type
            {
                Menu,
                Host,
                Client
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract MainUI.UIData.AllowShowBanner getAllowShowBanner();

        }

        public VP<LanUI.UIData.Sub> sub;

        #region Constructor

        public enum Property
        {
            display
        }

        public UIData() : base()
        {
            this.sub = new VP<Sub>(this, (byte)Property.display, new LanMenuUI.UIData());
        }

        #endregion

        public override MainUI.UIData.Sub.Type getType()
        {
            return MainUI.UIData.Sub.Type.Lan;
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

    public LanMenuUI menuPrefab;
    public LanHostUI hostPrefab;
    public LanClientUI clientPrefab;

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
                            LanMenuUI.UIData lanMenuUIData = sub as LanMenuUI.UIData;
                            UIUtils.Instantiate(lanMenuUIData, menuPrefab, this.transform);
                        }
                        break;
                    case UIData.Sub.Type.Host:
                        {
                            LanHostUI.UIData lanHostUIData = sub as LanHostUI.UIData;
                            UIUtils.Instantiate(lanHostUIData, hostPrefab, this.transform);
                        }
                        break;
                    case UIData.Sub.Type.Client:
                        {
                            LanClientUI.UIData lanClientUIData = sub as LanClientUI.UIData;
                            UIUtils.Instantiate(lanClientUIData, clientPrefab, this.transform);
                        }
                        break;
                    default:
                        Debug.LogError("unknow sub type: " + sub.getType() + "; " + this);
                        break;
                }
            }
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
                            LanMenuUI.UIData lanMenuUIData = sub as LanMenuUI.UIData;
                            lanMenuUIData.removeCallBackAndDestroy(typeof(LanMenuUI));
                        }
                        break;
                    case UIData.Sub.Type.Host:
                        {
                            LanHostUI.UIData lanHostUIData = sub as LanHostUI.UIData;
                            lanHostUIData.removeCallBackAndDestroy(typeof(LanHostUI));
                        }
                        break;
                    case UIData.Sub.Type.Client:
                        {
                            LanClientUI.UIData clientUIData = sub as LanClientUI.UIData;
                            clientUIData.removeCallBackAndDestroy(typeof(LanClientUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknow sub type: " + sub.getType() + "; " + this);
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
                case UIData.Property.display:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
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