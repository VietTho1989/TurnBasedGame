using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalPref : MonoBehaviour, ValueChangeCallBack
{

    #region dirty

    private bool Dirty = true;

    protected bool dirty
    {
        get
        {
            return Dirty;
        }
        set
        {
            Dirty = value;
            if (this)
            {
                this.enabled = Dirty;
            }
        }
    }

    #endregion

    #region global ref

    private const string Global_RemoveAds = "Global_RemoveAds";

    private HashSet<byte> globalUpdateNames = new HashSet<byte>();

    #endregion

    #region lifeCycle

    void Awake()
    {
        // init Global
        {
            try
            {
                // removeAds
                Global.get().removeAds.v = PlayerPrefs.GetInt(Global_RemoveAds, 0) != 0;
                if (Global.get().removeAds.v)
                {
                    Ads.AdsManager.get().removeAds();
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
        Global.get().addCallBack(this);
    }

    void OnDestroy()
    {
        Global.get().removeCallBack(this);
    }

    #endregion

    #region Update

    void Update()
    {
        if (dirty)
        {
            dirty = false;
            // save
            try
            {
                // set
                bool needSave = false;
                {
                    // settings
                    {
                        foreach (byte updateName in globalUpdateNames)
                        {
                            switch ((Global.Property)updateName)
                            {
                                case Global.Property.networkReachability:
                                    break;
                                case Global.Property.deviceOrientation:
                                    break;
                                case Global.Property.screenOrientation:
                                    break;
                                case Global.Property.width:
                                    break;
                                case Global.Property.height:
                                    break;
                                case Global.Property.screenWidth:
                                    break;
                                case Global.Property.screenHeight:
                                    break;
                                case Global.Property.serverMessage:
                                    break;
                                case Global.Property.website:
                                    break;
                                case Global.Property.oldVersions:
                                    break;
                                case Global.Property.openSource:
                                    break;
                                case Global.Property.removeAds:
                                    {
                                        PlayerPrefs.SetInt(Global_RemoveAds, Setting.get().confirmQuit.v ? 1 : 0);
                                        needSave = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + updateName);
                                    break;
                            }
                        }
                        // clear
                        globalUpdateNames.Clear();
                    }
                }
                // save
                if (needSave)
                    PlayerPrefs.Save();
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if(data is Global)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if(data is Global)
        {
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
                    break;
                case Global.Property.screenOrientation:
                    break;
                case Global.Property.width:
                    break;
                case Global.Property.height:
                    break;
                case Global.Property.screenWidth:
                    break;
                case Global.Property.screenHeight:
                    break;
                case Global.Property.serverMessage:
                    break;
                case Global.Property.website:
                    break;
                case Global.Property.oldVersions:
                    break;
                case Global.Property.openSource:
                    break;
                case Global.Property.removeAds:
                    {
                        globalUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Global.Property.canPlayOnline:
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