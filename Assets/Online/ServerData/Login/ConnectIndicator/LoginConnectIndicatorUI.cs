using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LoginConnectIndicatorUI : UIBehavior<LoginConnectIndicatorUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

        }

        #endregion

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
        return false;
    }

    public Sprite spriteOnline;
    public Sprite spriteOffline;
    public Image img;

    public override void LateUpdate()
    {
        base.LateUpdate();
        if (img != null)
        {
            bool isOnline = FindObjectOfType<ClientConnectIdentity>() != null;
            img.sprite = isOnline ? spriteOnline : spriteOffline;
        }
        else
        {
            Debug.LogError("img null");
        }
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            this.setDataNull(uiData);
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
        if(wrapProperty.p is UIData)
        {
            switch ((UIData.Property)wrapProperty.n)
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