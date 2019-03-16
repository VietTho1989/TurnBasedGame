using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SettingPref : MonoBehaviour, ValueChangeCallBack
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

    private const string Setting_Language = "Setting_Language";
    private const string Setting_Style = "Setting_Style";
    private const string Setting_ShowLastMove = "Setting_ShowLastMove";
    private const string Setting_ViewUrlImage = "Setting_ViewUrlImage";
    // private const string Setting_AnimationSetting = "Setting_AnimationSetting";
    private const string Setting_MaxThinkCount = "Setting_MaxThinkCount";

    void Awake()
    {
        // init Setting
        {
            try
            {
                // language
                {
                    // find default
                    Language.Type defaultLanguage = Language.Type.en;
                    {
                        switch (Application.systemLanguage)
                        {
                            case SystemLanguage.Vietnamese:
                                defaultLanguage = Language.Type.vi;
                                break;
                            default:
                                defaultLanguage = Language.Type.en;
                                break;
                        }
                    }
                    // set
                    Setting.get().language.v = (Language.Type)PlayerPrefs.GetInt(Setting_Language, (int)defaultLanguage);
                }
                // style
                Setting.get().style.v = (Setting.Style)PlayerPrefs.GetInt(Setting_Style, (int)Setting.Style.Normal);
                // showLastMove
                Setting.get().showLastMove.v = PlayerPrefs.GetInt(Setting_ShowLastMove, 1) != 0;
                // viewUrlImage
                Setting.get().viewUrlImage.v = PlayerPrefs.GetInt(Setting_ViewUrlImage, 1) != 0;
                // maxThinkCount
                Setting.get().maxThinkCount.v = PlayerPrefs.GetInt(Setting_MaxThinkCount, 12);
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
                        switch ((Setting.Property)updateName)
                        {
                            case Setting.Property.language:
                                {
                                    PlayerPrefs.SetInt(Setting_Language, (int)Setting.get().language.v);
                                    needSave = true;
                                }
                                break;
                            case Setting.Property.style:
                                {
                                    PlayerPrefs.SetInt(Setting_Style, (int)Setting.get().style.v);
                                    needSave = true;
                                }
                                break;
                            case Setting.Property.showLastMove:
                                {
                                    PlayerPrefs.SetInt(Setting_ShowLastMove, Setting.get().showLastMove.v ? 1 : 0);
                                    needSave = true;
                                }
                                break;
                            case Setting.Property.viewUrlImage:
                                {
                                    PlayerPrefs.SetInt(Setting_ViewUrlImage, Setting.get().viewUrlImage.v ? 1 : 0);
                                    needSave = true;
                                }
                                break;
                            case Setting.Property.animationSetting:
                                break;
                            case Setting.Property.maxThinkCount:
                                {
                                    PlayerPrefs.SetInt(Setting_MaxThinkCount, Setting.get().maxThinkCount.v);
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
            catch(System.Exception e)
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
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if(data is Setting)
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
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.style:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.showLastMove:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.viewUrlImage:
                    {
                        updateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
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