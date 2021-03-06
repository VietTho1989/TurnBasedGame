﻿using UnityEngine;
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

    #region setting pref

    private const string Setting_FastStart = "Setting_FastStart";
    private const string Setting_TimeStep = "Setting_TimeStep";
    private const string Setting_Language = "Setting_Language";
    private const string Setting_Style = "Setting_Style";
    private const string Setting_ConfirmQuit = "Setting_ConfirmQuit";
    private const string Setting_BoardIndex = "Setting_BoardIndex";
    private const string Setting_ShowLastMove = "Setting_ShowLastMove";
    private const string Setting_ViewUrlImage = "Setting_ViewUrlImage";
    private const string Setting_MaxThinkCount = "Setting_MaxThinkCount";

    private const string Setting_ContentTextSize = "Setting_ContentTextSize";
    private const string Setting_TitleTextSize = "Setting_TitleTextSize";
    private const string Setting_LabelTextSize = "Setting_LabelTextSize";
    private const string Setting_ButtonSize = "Setting_ButtonSize";
    private const string Setting_ItemSize = "Setting_ItemSize";

    private HashSet<byte> settingUpdateNames = new HashSet<byte>();

    #endregion

    #region defaultChosenGame

    private const string SettingDefaultChosenGameType = "SettingDefaultChosenGameType";
    private const string SettingDefaultChosenGame = "SettingDefaultChosenGame";

    private bool needUpdateDefaultChosenGameType = false;
    private bool needUpdateDefaultChosenGame = false;

    #endregion

    #region defaultRoomName

    private const string SettingDefaultRoomNameType = "SettingDefaultRoomNameType";
    private const string SettingDefaultRoomName = "SettingDefaultRoomName";

    private bool needUpdateDefaultRoomNameType = false;
    private bool needUpdateDefaultRoomName = false;

    #endregion

    #region defaultChatRoomStyle

    private const string SettingDefaultChatRoomStyleType = "SettingDefaultChatRoomStyleType";
    private const string SettingDefaultChatRoomStyleVisibility = "SettingDefaultChatRoomStyleVisibility";
    private const string SettingDefaultChatRoomStyleStyle = "SettingDefaultChatRoomStyleStyle";

    private bool needUpdateDefaultChatRoomStyleType = false;
    private bool needUpdateDefaultChatRoomStyleVisiblity = false;
    private bool needUpdateDefaultChatRoomStyleStyle = false;

    #endregion

    #region lifeCycle

    public void MyAwake()
    {
        Debug.LogError("SettingPrefab Awake");
        // init Setting
        {
            try
            {
                // fastStart
                Setting.get().fastStart.v = PlayerPrefs.GetInt(Setting_FastStart, 1) != 0;
                // timeStep
                Setting.get().timeStep.v = PlayerPrefs.GetInt(Setting_TimeStep, Setting.DefaultTimeStep);
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
                // confirmQuit
                Setting.get().confirmQuit.v = PlayerPrefs.GetInt(Setting_ConfirmQuit, 1) != 0;
                // boardIndex
                Setting.get().boardIndex.v = (Setting.BoardIndex)PlayerPrefs.GetInt(Setting_BoardIndex, (int)Setting.BoardIndex.None);
                // showLastMove
                Setting.get().showLastMove.v = PlayerPrefs.GetInt(Setting_ShowLastMove, 1) != 0;
                // viewUrlImage
                Setting.get().viewUrlImage.v = PlayerPrefs.GetInt(Setting_ViewUrlImage, 1) != 0;
                // maxThinkCount
                Setting.get().maxThinkCount.v = PlayerPrefs.GetInt(Setting_MaxThinkCount, 12);
                // textSize
                {
                    Setting.get().contentTextSize.v = PlayerPrefs.GetInt(Setting_ContentTextSize, Setting.DefaultContentTextSize);
                    Setting.get().titleTextSize.v = PlayerPrefs.GetInt(Setting_TitleTextSize, Setting.DefaultTitleTextSize);
                    Setting.get().labelTextSize.v = PlayerPrefs.GetInt(Setting_LabelTextSize, Setting.DefaultLabelTextSize);
                    // buttonSize
                    {
                        float defaultButtonSize = Setting.DefaultButtonSize;
                        {
                            float width = Screen.width;
                            float height = Screen.height;
                            if (width > 0 && height > 0)
                            {
                                float ratio = height > width ? height / width : width / height;
                                if (ratio <= 5 / 4.0f)
                                {
                                    defaultButtonSize = 30;
                                }
                                else if (ratio <= 4 / 3.0f)
                                {
                                    defaultButtonSize = 32;
                                }
                                else if (ratio <= 3 / 2.0f)
                                {
                                    defaultButtonSize = 32;
                                }
                                else if (ratio <= 16 / 10.0f)
                                {
                                    defaultButtonSize = 36;
                                }
                                else if (ratio <= 16 / 9.0f)
                                {
                                    defaultButtonSize = 40;
                                }
                                else
                                {
                                    defaultButtonSize = 45;
                                }
                            }
                            else
                            {
                                Debug.LogError("why width, height = 0: " + width + ", " + height);
                            }
                            // correct defaultButtonSize
                            {
                                defaultButtonSize = Mathf.Clamp(defaultButtonSize, 30, 50);
                            }
                            Debug.LogError("defaultButtonSize: " + defaultButtonSize + ", " + width + ", " + height);
                        }
                        Setting.get().buttonSize.v = PlayerPrefs.GetFloat(Setting_ButtonSize, defaultButtonSize);
                    }
                    Setting.get().itemSize.v = PlayerPrefs.GetFloat(Setting_ItemSize, Setting.DefaultItemSize);
                }

                // defaultChosenGameType
                {
                    // find default Game
                    GameType.Type defaultGame = GameType.Type.CHESS;
                    {
                        switch (Application.systemLanguage)
                        {
                            case SystemLanguage.Vietnamese:
                                defaultGame = GameType.Type.Xiangqi;
                                break;
                            case SystemLanguage.Chinese:
                            case SystemLanguage.ChineseSimplified:
                            case SystemLanguage.ChineseTraditional:
                                defaultGame = GameType.Type.Xiangqi;
                                break;
                            default:
                                defaultGame = GameType.Type.CHESS;
                                break;
                        }
                    }
                    GameType.Type defaultGameType = (GameType.Type)PlayerPrefs.GetInt(SettingDefaultChosenGame, (int)defaultGame);
                    switch((DefaultChosenGame.Type)PlayerPrefs.GetInt(SettingDefaultChosenGameType, (int)DefaultChosenGame.Type.Last))
                    {
                        case DefaultChosenGame.Type.Last:
                            {
                                DefaultChosenGameLast last = Setting.get().defaultChosenGame.newOrOld<DefaultChosenGameLast>();
                                {
                                    last.gameType.v = defaultGameType;
                                }
                                Setting.get().defaultChosenGame.v = last;
                            }
                            break;
                        case DefaultChosenGame.Type.Always:
                            {
                                DefaultChosenGameAlways always = Setting.get().defaultChosenGame.newOrOld<DefaultChosenGameAlways>();
                                {
                                    always.gameType.v = defaultGameType;
                                }
                                Setting.get().defaultChosenGame.v = always;
                            }
                            break;
                        default:
                            Debug.LogError("unknown type");
                            break;
                    }
                }
                // defaultRoomName
                {
                    string defaultRoomName = PlayerPrefs.GetString(SettingDefaultRoomName, "");
                    switch ((DefaultRoomName.Type)PlayerPrefs.GetInt(SettingDefaultRoomNameType, (int)DefaultRoomName.Type.Last))
                    {
                        case DefaultRoomName.Type.Last:
                            {
                                DefaultRoomNameLast last = Setting.get().defaultRoomName.newOrOld<DefaultRoomNameLast>();
                                {
                                    last.roomName.v = defaultRoomName;
                                }
                                Setting.get().defaultRoomName.v = last;
                            }
                            break;
                        case DefaultRoomName.Type.Always:
                            {
                                DefaultRoomNameAlways always = Setting.get().defaultRoomName.newOrOld<DefaultRoomNameAlways>();
                                {
                                    always.roomName.v = defaultRoomName;
                                }
                                Setting.get().defaultRoomName.v = always;
                            }
                            break;
                        default:
                            Debug.LogError("unknown type");
                            break;
                    }
                }
                // defaultChatRoomStyle
                {
                    ContestManagerBtnChatUI.UIData.Visibility defaultVisibility = (ContestManagerBtnChatUI.UIData.Visibility)PlayerPrefs.GetInt(SettingDefaultChatRoomStyleVisibility, (int)ContestManagerBtnChatUI.UIData.Visibility.Hide);
                    ContestManagerBtnChatUI.UIData.Style defaultStyle = (ContestManagerBtnChatUI.UIData.Style)PlayerPrefs.GetInt(SettingDefaultChatRoomStyleStyle, (int)ContestManagerBtnChatUI.UIData.Style.Overlay);
                    switch ((DefaultChatRoomStyle.Type)PlayerPrefs.GetInt(SettingDefaultChatRoomStyleType, (int)DefaultChatRoomStyle.Type.Last))
                    {
                        case DefaultChatRoomStyle.Type.Last:
                            {
                                DefaultChatRoomStyleLast last = Setting.get().defaultChatRoomStyle.newOrOld<DefaultChatRoomStyleLast>();
                                {
                                    last.visibility.v = defaultVisibility;
                                    last.style.v = defaultStyle;
                                }
                                Setting.get().defaultChatRoomStyle.v = last;
                            }
                            break;
                        case DefaultChatRoomStyle.Type.Always:
                            {
                                DefaultChatRoomStyleAlways always = Setting.get().defaultChatRoomStyle.newOrOld<DefaultChatRoomStyleAlways>();
                                {
                                    always.visibility.v = defaultVisibility;
                                    always.style.v = defaultStyle;
                                }
                                Setting.get().defaultChatRoomStyle.v = always;
                            }
                            break;
                        default:
                            Debug.LogError("unknown type");
                            break;
                    }
                }
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
                        foreach (byte updateName in settingUpdateNames)
                        {
                            switch ((Setting.Property)updateName)
                            {
                                case Setting.Property.fastStart:
                                    {
                                        PlayerPrefs.SetInt(Setting_FastStart, Setting.get().fastStart.v ? 1 : 0);
                                        needSave = true;
                                    }
                                    break;
                                case Setting.Property.timeStep:
                                    {
                                        PlayerPrefs.SetInt(Setting_TimeStep, Setting.get().timeStep.v);
                                        needSave = true;
                                    }
                                    break;
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
                                case Setting.Property.confirmQuit:
                                    {
                                        PlayerPrefs.SetInt(Setting_ConfirmQuit, Setting.get().confirmQuit.v ? 1 : 0);
                                        needSave = true;
                                    }
                                    break;
                                case Setting.Property.boardIndex:
                                    {
                                        PlayerPrefs.SetInt(Setting_BoardIndex, (int)Setting.get().boardIndex.v);
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
                                case Setting.Property.contentTextSize:
                                    {
                                        PlayerPrefs.SetInt(Setting_ContentTextSize, Setting.get().contentTextSize.v);
                                        needSave = true;
                                    }
                                    break;
                                case Setting.Property.titleTextSize:
                                    {
                                        PlayerPrefs.SetInt(Setting_TitleTextSize, Setting.get().titleTextSize.v);
                                        needSave = true;
                                    }
                                    break;
                                case Setting.Property.labelTextSize:
                                    {
                                        PlayerPrefs.SetInt(Setting_LabelTextSize, Setting.get().labelTextSize.v);
                                        needSave = true;
                                    }
                                    break;
                                case Setting.Property.buttonSize:
                                    {
                                        PlayerPrefs.SetFloat(Setting_ButtonSize, Setting.get().buttonSize.v);
                                        needSave = true;
                                    }
                                    break;
                                case Setting.Property.itemSize:
                                    {
                                        PlayerPrefs.SetFloat(Setting_ItemSize, Setting.get().itemSize.v);
                                        needSave = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + updateName);
                                    break;
                            }
                        }
                        // clear
                        settingUpdateNames.Clear();
                    }
                    // defaultChosenGame
                    {
                        if (needUpdateDefaultChosenGameType)
                        {
                            PlayerPrefs.SetInt(SettingDefaultChosenGameType, (int)Setting.get().defaultChosenGame.v.getType());
                            needUpdateDefaultChosenGameType = false;
                            needSave = true;
                        }
                        if (needUpdateDefaultChosenGame)
                        {
                            PlayerPrefs.SetInt(SettingDefaultChosenGame, (int)Setting.get().defaultChosenGame.v.getGame());
                            needUpdateDefaultChosenGame = false;
                            needSave = true;
                        }
                    }
                    // defaultRoomName
                    {
                        if (needUpdateDefaultRoomNameType)
                        {
                            PlayerPrefs.SetInt(SettingDefaultRoomNameType, (int)Setting.get().defaultRoomName.v.getType());
                            needUpdateDefaultRoomNameType = false;
                            needSave = true;
                        }
                        if (needUpdateDefaultRoomName)
                        {
                            PlayerPrefs.SetString(SettingDefaultRoomName, Setting.get().defaultRoomName.v.getRoomName());
                            needUpdateDefaultRoomName = false;
                            needSave = true;
                        }
                    }
                    // defaultChatRoomStyle
                    {
                        if (needUpdateDefaultChatRoomStyleType)
                        {
                            PlayerPrefs.SetInt(SettingDefaultChatRoomStyleType, (int)Setting.get().defaultChatRoomStyle.v.getType());
                            needUpdateDefaultChatRoomStyleType = false;
                            needSave = true;
                        }
                        if (needUpdateDefaultChatRoomStyleVisiblity)
                        {
                            PlayerPrefs.SetInt(SettingDefaultChatRoomStyleVisibility, (int)Setting.get().defaultChatRoomStyle.v.getVisibility());
                            needUpdateDefaultChatRoomStyleVisiblity = false;
                            needSave = true;
                        }
                        if (needUpdateDefaultChatRoomStyleStyle)
                        {
                            PlayerPrefs.SetInt(SettingDefaultChatRoomStyleStyle, (int)Setting.get().defaultChatRoomStyle.v.getStyle());
                            needUpdateDefaultChatRoomStyleStyle = false;
                            needSave = true;
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
                setting.defaultChosenGame.allAddCallBack(this);
                setting.defaultRoomName.allAddCallBack(this);
                setting.defaultChatRoomStyle.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is DefaultChosenGame)
            {
                dirty = true;
                return;
            }
            if(data is DefaultRoomName)
            {
                dirty = true;
                return;
            }
            if (data is DefaultChatRoomStyle)
            {
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if(data is Setting)
        {
            Setting setting = data as Setting;
            // Child
            {
                setting.defaultChosenGame.allRemoveCallBack(this);
                setting.defaultRoomName.allRemoveCallBack(this);
                setting.defaultChatRoomStyle.allRemoveCallBack(this);
            }
            return;
        }
        // Child
        {
            if (data is DefaultChosenGame)
            {
                return;
            }
            if(data is DefaultRoomName)
            {
                return;
            }
            if (data is DefaultChatRoomStyle)
            {
                return;
            }
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
                case Setting.Property.fastStart:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.timeStep:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.language:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.style:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.confirmQuit:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.boardIndex:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.showLastMove:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.viewUrlImage:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.defaultChosenGame:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        needUpdateDefaultChosenGameType = true;
                        dirty = true;
                    }
                    break;
                case Setting.Property.defaultRoomName:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        needUpdateDefaultRoomNameType = true;
                        dirty = true;
                    }
                    break;
                case Setting.Property.defaultChatRoomStyle:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        needUpdateDefaultChatRoomStyleType = true;
                        dirty = true;
                    }
                    break;
                case Setting.Property.contentTextSize:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.titleTextSize:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.labelTextSize:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.buttonSize:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
                        dirty = true;
                    }
                    break;
                case Setting.Property.itemSize:
                    {
                        settingUpdateNames.Add(wrapProperty.n);
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
        {
            if (wrapProperty.p is DefaultChosenGame)
            {
                DefaultChosenGame defaultChosenGame = wrapProperty.p as DefaultChosenGame;
                switch (defaultChosenGame.getType())
                {
                    case DefaultChosenGame.Type.Last:
                        {
                            switch ((DefaultChosenGameLast.Property)wrapProperty.n)
                            {
                                case DefaultChosenGameLast.Property.gameType:
                                    {
                                        needUpdateDefaultChosenGame = true;
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    case DefaultChosenGame.Type.Always:
                        {
                            switch ((DefaultChosenGameAlways.Property)wrapProperty.n)
                            {
                                case DefaultChosenGameAlways.Property.gameType:
                                    {
                                        needUpdateDefaultChosenGame = true;
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + defaultChosenGame.getType());
                        break;
                }
                return;
            }
            if (wrapProperty.p is DefaultRoomName)
            {
                DefaultRoomName defaultRoomName = wrapProperty.p as DefaultRoomName;
                switch (defaultRoomName.getType())
                {
                    case DefaultRoomName.Type.Last:
                        {
                            switch ((DefaultRoomNameLast.Property)wrapProperty.n)
                            {
                                case DefaultRoomNameLast.Property.roomName:
                                    {
                                        needUpdateDefaultRoomName = true;
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    case DefaultRoomName.Type.Always:
                        {
                            switch ((DefaultRoomNameAlways.Property)wrapProperty.n)
                            {
                                case DefaultRoomNameAlways.Property.roomName:
                                    {
                                        needUpdateDefaultRoomName = true;
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + defaultRoomName.getType());
                        break;
                }
                return;
            }
            if (wrapProperty.p is DefaultChatRoomStyle)
            {
                DefaultChatRoomStyle defaultChatRoomStyle = wrapProperty.p as DefaultChatRoomStyle;
                switch (defaultChatRoomStyle.getType())
                {
                    case DefaultChatRoomStyle.Type.Last:
                        {
                            switch ((DefaultChatRoomStyleLast.Property)wrapProperty.n)
                            {
                                case DefaultChatRoomStyleLast.Property.visibility:
                                    {
                                        needUpdateDefaultChatRoomStyleVisiblity = true;
                                        dirty = true;
                                    }
                                    break;
                                case DefaultChatRoomStyleLast.Property.style:
                                    {
                                        needUpdateDefaultChatRoomStyleStyle = true;
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    case DefaultChatRoomStyle.Type.Always:
                        {
                            switch ((DefaultChatRoomStyleAlways.Property)wrapProperty.n)
                            {
                                case DefaultChatRoomStyleAlways.Property.visibility:
                                    {
                                        needUpdateDefaultChatRoomStyleVisiblity = true;
                                        dirty = true;
                                    }
                                    break;
                                case DefaultChatRoomStyleAlways.Property.style:
                                    {
                                        needUpdateDefaultChatRoomStyleStyle = true;
                                        dirty = true;
                                    }
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + defaultChatRoomStyle.getType());
                        break;
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}