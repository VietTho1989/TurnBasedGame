using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalUICheckChange : ValueChangeCallBack
{

    #region Constructor

    private HaveTransformData haveTransformData = null;

    public GlobalUICheckChange(HaveTransformData haveTransformData)
    {
        this.haveTransformData = haveTransformData;
    }

    #endregion

    #region data

    public Global data;

    public void setData(Global newData)
    {
        // set
        if (this.data != newData)
        {
            // remove old
            if (this.data != null)
            {
                this.data.removeCallBack(this);
            }
            // set new 
            {
                this.data = newData;
                if (this.data != null)
                {
                    this.data.addCallBack(this);
                }
            }
        }
        else
        {
            // Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
        }
    }

    public void setDataNull(Global removeData)
    {
        if (this.data == removeData)
        {
            this.data = null;
        }
        else
        {
            Debug.LogError("not correct removeData: " + removeData);
        }
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if(data is Global)
        {
            if (haveTransformData != null)
            {
                haveTransformData.setDirtyForTransformData();
            }
            else
            {
                Debug.LogError("haveTransformData null");
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is Global)
        {
            Global global = data as Global;
            this.setDataNull(global);
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if(wrapProperty.p is Global)
        {
            switch ((Global.Property)wrapProperty.n)
            {
                case Global.Property.networkReachability:
                    break;
                case Global.Property.deviceOrientation:
                case Global.Property.screenOrientation:
                case Global.Property.width:
                case Global.Property.height:
                case Global.Property.screenWidth:
                case Global.Property.screenHeight:
                    {
                        if (haveTransformData != null)
                        {
                            haveTransformData.setDirtyForTransformData();
                        }
                        else
                        {
                            Debug.LogError("haveTransformData null");
                        }
                    }
                    break;
                case Global.Property.serverMessage:
                    break;
                case Global.Property.website:
                    break;
                case Global.Property.oldVersions:
                    break;
                case Global.Property.openSource:
                    break;
                case Global.Property.showRemoveAds:
                    break;
                case Global.Property.removeAds:
                    break;
                case Global.Property.canPlayOnline:
                    break;
                case Global.Property.serverAddress:
                    break;
                case Global.Property.serverPort:
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