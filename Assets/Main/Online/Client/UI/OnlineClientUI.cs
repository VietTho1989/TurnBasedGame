using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OnlineClientUI : UIBehavior<OnlineClientUI.UIData>
{

    #region UIData

    public class UIData : PlayOnlineUI.UIData.Sub
    {

        #region sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                Menu,
                Play
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
            this.sub = new VP<Sub>(this, (byte)Property.sub, new OnlineClientMenuUI.UIData());
        }

        #endregion

        public override Type getType()
        {
            return Type.Client;
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

    public OnlineClientMenuUI menuPrefab;
    public OnlineClientPlayUI playPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
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
        if(data is UIData.Sub)
        {
            UIData.Sub sub = data as UIData.Sub;
            // UI
            {
                switch (sub.getType())
                {
                    case UIData.Sub.Type.Menu:
                        {
                            OnlineClientMenuUI.UIData menuUIData = sub as OnlineClientMenuUI.UIData;
                            UIUtils.Instantiate(menuUIData, menuPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    case UIData.Sub.Type.Play:
                        {
                            OnlineClientPlayUI.UIData playUIData = sub as OnlineClientPlayUI.UIData;
                            UIUtils.Instantiate(playUIData, playPrefab, this.transform, UIConstants.FullParent);
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType());
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
                            OnlineClientMenuUI.UIData menuUIData = sub as OnlineClientMenuUI.UIData;
                            menuUIData.removeCallBackAndDestroy(typeof(OnlineClientMenuUI));
                        }
                        break;
                    case UIData.Sub.Type.Play:
                        {
                            OnlineClientPlayUI.UIData playUIData = sub as OnlineClientPlayUI.UIData;
                            playUIData.removeCallBackAndDestroy(typeof(OnlineClientPlayUI));
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + sub.getType());
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