using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScreenCaptureSettingPref : MonoBehaviour, ValueChangeCallBack
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

    #region lifeCycle

    public const string ScreenCaptureSetting_WaitDuration = "ScreenCaptureSetting_WaitDuration";
    public const string ScreenCaptureSetting_AutoCloseSetting = "ScreenCaptureSetting_AutoCloseSetting";

    void Awake()
    {
        // init
        {
            try
            {
                Setting.get().screenCaptureSetting.v.waitDuration.v = PlayerPrefs.GetInt(ScreenCaptureSetting_WaitDuration, ScreenCaptureWaitUI.UIData.DefaultDuration);
                Setting.get().screenCaptureSetting.v.autoCloseSetting.v = PlayerPrefs.GetInt(ScreenCaptureSetting_AutoCloseSetting, ScreenCaptureSetting.DefaultAutoCloseSetting ? 1 : 0) != 0;
              
            }
            catch (System.Exception e)
            {
                Debug.LogError(e);
            }
        }
        Setting.get().addCallBack(this);
    }

    void OnDestroy()
    {
        Setting.get().removeCallBack(this);
    }

    #endregion

    #region update

    private HashSet<byte> updateNames = new HashSet<byte>();

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
                    // Debug.LogError("update setting pref");
                    foreach (byte updateName in updateNames)
                    {
                        switch ((ScreenCaptureSetting.Property)updateName)
                        {
                            case ScreenCaptureSetting.Property.waitDuration:
                                {
                                    PlayerPrefs.SetInt(ScreenCaptureSetting_WaitDuration, Setting.get().screenCaptureSetting.v.waitDuration.v);
                                    needSave = true;
                                }
                                break;
                            case ScreenCaptureSetting.Property.autoCloseSetting:
                                {
                                    PlayerPrefs.SetInt(ScreenCaptureSetting_AutoCloseSetting, Setting.get().screenCaptureSetting.v.autoCloseSetting.v ? 1 : 0);
                                    needSave = true;
                                }
                                break;
                            default:
                                Debug.LogError("Don't process: " + updateName);
                                break;
                        }
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
            // clear
            updateNames.Clear();
        }
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if (data is Setting)
        {
            Setting setting = data as Setting;
            // Child
            {
                setting.screenCaptureSetting.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if (data is ScreenCaptureSetting)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data is Setting)
        {
            Setting setting = data as Setting;
            // Child
            {
                setting.screenCaptureSetting.allRemoveCallBack(this);
            }
            return;
        }
        // Child
        if (data is ScreenCaptureSetting)
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
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    break;
                case Setting.Property.titleTextSize:
                    break;
                case Setting.Property.labelTextSize:
                    break;
                case Setting.Property.buttonSize:
                    break;
                case Setting.Property.itemSize:
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                case Setting.Property.screenCaptureSetting:
                    {
                        Debug.LogError("why screenCaptureSetting change");
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
        if (wrapProperty.p is ScreenCaptureSetting)
        {
            switch ((ScreenCaptureSetting.Property)wrapProperty.n)
            {
                case ScreenCaptureSetting.Property.waitDuration:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case ScreenCaptureSetting.Property.autoCloseSetting:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
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