using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class MainUI : UIBehavior<MainUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public abstract class Sub : Data
        {

            public enum Type
            {
                Home,
                Online,
                Offline,
                Lan,
                LoadData
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

            public abstract AllowShowBanner getAllowShowBanner();

        }

        public VP<MainUI.UIData.Sub> sub;

        public VP<ShowSettingUI.UIData> showSettingUIData;

        #region Constructor

        public enum Property
        {
            sub,
            showSettingUIData
        }

        public UIData() : base()
        {
            sub = new VP<Sub>(this, (byte)Property.sub, new HomeUI.UIData());
            this.showSettingUIData = new VP<ShowSettingUI.UIData>(this, (byte)Property.showSettingUIData, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            Debug.LogError("processEvent: " + e + "; " + this);
            bool isProcessed = false;
            {
                // Child
                {
                    // setting
                    if (!isProcessed)
                    {
                        ShowSettingUI.UIData showSettingUIData = this.showSettingUIData.v;
                        if (showSettingUIData != null)
                        {
                            isProcessed = showSettingUIData.processEvent(e);
                            isProcessed = true;
                        }
                    }
                    // sub
                    if (!isProcessed)
                    {
                        UIData.Sub sub = this.sub.v;
                        if (this.sub.v != null)
                        {
                            isProcessed = this.sub.v.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("sub null: " + this);
                        }
                    }
                }
                // short key

            }
            return isProcessed;
        }

        public void reset()
        {

        }

        #region allowShowBanner

        public enum AllowShowBanner
        {
            ForceShow,
            ForceHide,
            StatusQuo
        }

        public AllowShowBanner getAllowShowBanner()
        {
            AllowShowBanner ret = AllowShowBanner.ForceShow;
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

        #endregion

    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // Display data
        UIData uiData = new UIData();
        this.setData(uiData);
    }

    void OnApplicationFocus(bool hasFocus)
    {
        // Debug.LogError ("OnApplicationFocus: " + hasFocus);
    }

    void OnApplicationPause(bool pauseStatus)
    {
        // Debug.LogError ("OnApplicationPause: " + pauseStatus);
    }

    #region txt


    static MainUI()
    {

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
                // UI Sibling
                {
                    int siblingIndex = 0;
                    // sub
                    if (UIRectTransform.SetSiblingIndex(this.data.sub.v, siblingIndex))
                    {
                        siblingIndex++;
                    }
                    // showSettingUIData
                    if (UIRectTransform.SetSiblingIndex(this.data.showSettingUIData.v, siblingIndex))
                    {
                        siblingIndex++;
                    }
                    // btnSetting
                    if (btnSetting != null)
                    {
                        btnSetting.transform.SetAsLastSibling();
                    }
                    else
                    {
                        Debug.LogError("btnSetting null");
                    }
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    private bool alreadyPress = false;

    public override void OnGUI()
    {
        Event e = Event.current;
        if (this.data != null)
        {
            bool canProcess = false;
            {
                if (Application.isFocused)
                {
                    // current select allow
                    bool currentSelectAllow = true;
                    {
                        GameObject currentSelect = EventSystem.current.currentSelectedGameObject;
                        if (currentSelect != null)
                        {
                            // Debug.LogError ("currentSelect: " + currentSelect);
                            if (currentSelect.GetComponent<Button>() == null)
                            {
                                currentSelectAllow = false;
                            }
                            else
                            {
                                if (InputEvent.isEnter(e))
                                {
                                    currentSelectAllow = false;
                                }
                                else if (InputEvent.isArrow(e))
                                {
                                    currentSelectAllow = false;
                                }
                            }
                        }
                    }
                    // process
                    if (currentSelectAllow)
                    {
                        if (e.isKey)
                        {
                            // press
                            if (e.type == EventType.KeyDown)
                            {
                                alreadyPress = true;
                            }
                            // release
                            else if (e.type == EventType.KeyUp && alreadyPress)
                            {
                                canProcess = true;
                                alreadyPress = false;
                            }
                        }
                    }
                }
                else
                {
                    // application not focus, so cannot process event
                }
            }
            if (canProcess)
            {
                this.data.processEvent(e);
            }
        }
        else
        {
            // Debug.LogError ("data null");
        }
    }

    #endregion

    #region implement callBacks

    public HomeUI homePrefab;
    public PlayOnlineUI playOnlinePrefab;
    public OfflineUI playOfflinePrefab;
    public LanUI lanPrefab;
    public LoadDataUI loadDataPrefab;

    public ShowSettingUI showSettingPrefab;

    public GameObject btnSetting;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            {
                Setting.get().addCallBack(this);
            }
            // Child
            {
                uiData.sub.allAddCallBack(this);
                uiData.showSettingUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Home:
                            {
                                HomeUI.UIData homeUIData = sub as HomeUI.UIData;
                                UIUtils.Instantiate(homeUIData, homePrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Online:
                            {
                                PlayOnlineUI.UIData playOnlineUIData = sub as PlayOnlineUI.UIData;
                                UIUtils.Instantiate(playOnlineUIData, playOnlinePrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Offline:
                            {
                                OfflineUI.UIData playOfflineUIData = sub as OfflineUI.UIData;
                                UIUtils.Instantiate(playOfflineUIData, playOfflinePrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Lan:
                            {
                                LanUI.UIData lanUIData = sub as LanUI.UIData;
                                UIUtils.Instantiate(lanUIData, lanPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.LoadData:
                            {
                                LoadDataUI.UIData loadDataUIData = sub as LoadDataUI.UIData;
                                UIUtils.Instantiate(loadDataUIData, loadDataPrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknow sub type: " + sub.getType());
                            break;
                    }
                }
                dirty = true;
                return;
            }
            if (data is ShowSettingUI.UIData)
            {
                ShowSettingUI.UIData showSettingUIData = data as ShowSettingUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(showSettingUIData, showSettingPrefab, this.transform);
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            {
                Setting.get().removeCallBack(this);
            }
            // Child
            {
                uiData.sub.allRemoveCallBack(this);
                uiData.showSettingUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Child
        {
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.Home:
                            {
                                HomeUI.UIData homeUIData = sub as HomeUI.UIData;
                                homeUIData.removeCallBackAndDestroy(typeof(HomeUI));
                            }
                            break;
                        case UIData.Sub.Type.Online:
                            {
                                PlayOnlineUI.UIData playOnlineUIData = sub as PlayOnlineUI.UIData;
                                playOnlineUIData.removeCallBackAndDestroy(typeof(PlayOnlineUI));
                            }
                            break;
                        case UIData.Sub.Type.Offline:
                            {
                                OfflineUI.UIData offlineUIData = sub as OfflineUI.UIData;
                                offlineUIData.removeCallBackAndDestroy(typeof(OfflineUI));
                            }
                            break;
                        case UIData.Sub.Type.Lan:
                            {
                                LanUI.UIData lanUIData = sub as LanUI.UIData;
                                lanUIData.removeCallBackAndDestroy(typeof(LanUI));
                            }
                            break;
                        case UIData.Sub.Type.LoadData:
                            {
                                LoadDataUI.UIData loadDataUIData = sub as LoadDataUI.UIData;
                                loadDataUIData.removeCallBackAndDestroy(typeof(LoadDataUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknow sub type: " + sub.getType());
                            break;
                    }
                }
                return;
            }
            if (data is ShowSettingUI.UIData)
            {
                ShowSettingUI.UIData showSettingUIData = data as ShowSettingUI.UIData;
                // UI
                {
                    showSettingUIData.removeCallBackAndDestroy(typeof(ShowSettingUI));
                }
                return;
            }
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
                case UIData.Property.showSettingUIData:
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
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.style:
                    break;
                case Setting.Property.contentTextSize:
                    dirty = true;
                    break;
                case Setting.Property.titleTextSize:
                    dirty = true;
                    break;
                case Setting.Property.labelTextSize:
                    dirty = true;
                    break;
                case Setting.Property.buttonSize:
                    dirty = true;
                    break;
                case Setting.Property.showLastMove:
                    break;
                case Setting.Property.viewUrlImage:
                    break;
                case Setting.Property.animationSetting:
                    break;
                case Setting.Property.maxThinkCount:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            if (wrapProperty.p is ShowSettingUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnSetting()
    {
        if (this.data != null)
        {
            if (this.data.showSettingUIData.v == null)
            {
                ShowSettingUI.UIData showSettingUIData = new ShowSettingUI.UIData();
                {
                    showSettingUIData.uid = this.data.showSettingUIData.makeId();
                }
                this.data.showSettingUIData.v = showSettingUIData;
            }
            else
            {
                // this.data.showSettingUIData.v = null;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}