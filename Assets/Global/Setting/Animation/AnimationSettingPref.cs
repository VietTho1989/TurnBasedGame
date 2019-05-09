using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationSettingPref : MonoBehaviour, ValueChangeCallBack
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

    private const string AnimationSetting_Scale = "AnimationSetting_Scale";
    private const string AnimationSetting_FastForward = "AnimationSetting_FastForward";
    private const string AnimationSetting_MaxWaitAnimationCount = "AnimationSetting_MaxWaitAnimationCount";

    void Awake()
    {
        // init
        {
            try
            {
                // scale
                Setting.get().animationSetting.v.scale.v = PlayerPrefs.GetFloat(AnimationSetting_Scale, 1);
                // fastForward 
                Setting.get().animationSetting.v.fastForward.v = PlayerPrefs.GetInt(AnimationSetting_FastForward, 1) != 0;
                // maxWaitAnimationCount
                Setting.get().animationSetting.v.maxWaitAnimationCount.v = PlayerPrefs.GetInt(AnimationSetting_MaxWaitAnimationCount, 10);
            }
            catch(System.Exception e)
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
                        switch ((AnimationSetting.Property)updateName)
                        {
                            case AnimationSetting.Property.scale:
                                {
                                    PlayerPrefs.SetFloat(AnimationSetting_Scale, Setting.get().animationSetting.v.scale.v);
                                    needSave = true;
                                }
                                break;
                            case AnimationSetting.Property.fastForward:
                                {
                                    PlayerPrefs.SetInt(AnimationSetting_FastForward, Setting.get().animationSetting.v.fastForward.v ? 1 : 0);
                                    needSave = true;
                                }
                                break;
                            case AnimationSetting.Property.maxWaitAnimationCount:
                                {
                                    PlayerPrefs.SetInt(AnimationSetting_MaxWaitAnimationCount, Setting.get().animationSetting.v.maxWaitAnimationCount.v);
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
        if(data is Setting)
        {
            Setting setting = data as Setting;
            // Child
            {
                setting.animationSetting.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if(data is AnimationSetting)
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
                setting.animationSetting.allRemoveCallBack(this);
            }
            return;
        }
        // Child
        if (data is AnimationSetting)
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
                    {
                        Debug.LogError("why animationSetting change");
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                case Setting.Property.defaultChosenGame:
                    break;
                case Setting.Property.defaultRoomName:
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if (wrapProperty.p is AnimationSetting)
        {
            switch ((AnimationSetting.Property)wrapProperty.n)
            {
                case AnimationSetting.Property.scale:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case AnimationSetting.Property.fastForward:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case AnimationSetting.Property.maxWaitAnimationCount:
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