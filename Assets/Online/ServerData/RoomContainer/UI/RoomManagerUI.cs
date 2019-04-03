using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoomManagerUI : UIBehavior<RoomManagerUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RoomManager>> roomManager;

        #region Show

        public VP<RoomContainer.Type> show;

        #endregion

        public VP<GlobalRoomContainerUI.UIData> globalRoomContainerUIData;

        public VP<AllLimitRoomContainersUI.UIData> allLimitRoomContainersUIData;

        #region Constructor

        public enum Property
        {
            roomManager,
            show,
            globalRoomContainerUIData,
            allLimitRoomContainersUIData
        }

        public UIData() : base()
        {
            this.roomManager = new VP<ReferenceData<RoomManager>>(this, (byte)Property.roomManager, new ReferenceData<RoomManager>(null));
            this.show = new VP<RoomContainer.Type>(this, (byte)Property.show, RoomContainer.Type.Global);
            this.globalRoomContainerUIData = new VP<GlobalRoomContainerUI.UIData>(this, (byte)Property.globalRoomContainerUIData, null);
            this.allLimitRoomContainersUIData = new VP<AllLimitRoomContainersUI.UIData>(this, (byte)Property.allLimitRoomContainersUIData, null);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                if (!isProcess)
                {
                    switch (this.show.v)
                    {
                        case RoomContainer.Type.Global:
                            {
                                GlobalRoomContainerUI.UIData globalRoomContainerUIData = this.globalRoomContainerUIData.v;
                                if (globalRoomContainerUIData != null)
                                {
                                    isProcess = globalRoomContainerUIData.processEvent(e);
                                }
                                else
                                {
                                    Debug.LogError("globalRoomContainerUIData null");
                                }
                            }
                            break;
                        case RoomContainer.Type.Limit:
                            {
                                AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = this.allLimitRoomContainersUIData.v;
                                if (allLimitRoomContainersUIData != null)
                                {
                                    isProcess = allLimitRoomContainersUIData.processEvent(e);
                                }
                                else
                                {
                                    Debug.LogError("allLimitRoomContainersUIData null");
                                }
                            }
                            break;
                        default:
                            Debug.LogError("unknown show: " + this.show.v);
                            break;
                    }
                }
            }
            return isProcess;
        }

        public MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                switch (this.show.v)
                {
                    case RoomContainer.Type.Global:
                        {
                            GlobalRoomContainerUI.UIData globalRoomContainerUIData = this.globalRoomContainerUIData.v;
                            if (globalRoomContainerUIData != null)
                            {
                                ret = globalRoomContainerUIData.getAllowShowBanner();
                            }
                            else
                            {
                                Debug.LogError("globalRoomContainerUIData null");
                            }
                        }
                        break;
                    case RoomContainer.Type.Limit:
                        {
                            AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = this.allLimitRoomContainersUIData.v;
                            if (allLimitRoomContainersUIData != null)
                            {
                                ret = allLimitRoomContainersUIData.getAllowShowBanner();
                            }
                            else
                            {
                                Debug.LogError("allLimitRoomContainersUIData null");
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown show: " + this.show.v);
                        break;
                }
            }
            return ret;
        }

    }

    #endregion

    #region Refresh

    public Button btnGlobal;
    public Button btnLimit;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RoomManager roomManager = this.data.roomManager.v.data;
                if (roomManager != null)
                {
                    // show
                    {
                        if (btnGlobal != null && btnLimit != null)
                        {
                            // get UI
                            GlobalRoomContainerUI globalRoomContainerUI = null;
                            {
                                GlobalRoomContainerUI.UIData globalRoomContainerUIData = this.data.globalRoomContainerUIData.v;
                                if (globalRoomContainerUIData != null)
                                {
                                    globalRoomContainerUI = globalRoomContainerUIData.findCallBack<GlobalRoomContainerUI>();
                                }
                                else
                                {
                                    Debug.LogError("globalRoomContainerUIData null");
                                }
                            }
                            AllLimitRoomContainersUI allLimitRoomContainersUI = null;
                            {
                                AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = this.data.allLimitRoomContainersUIData.v;
                                if (allLimitRoomContainersUIData != null)
                                {
                                    allLimitRoomContainersUI = allLimitRoomContainersUIData.findCallBack<AllLimitRoomContainersUI>();
                                }
                                else
                                {
                                    Debug.LogError("allLimitRoomContainersUIData null");
                                }
                            }
                            // show
                            switch (this.data.show.v)
                            {
                                case RoomContainer.Type.Global:
                                    {
                                        // btn
                                        {
                                            btnGlobal.interactable = false;
                                            btnLimit.interactable = true;
                                        }
                                        // sub
                                        if (this.data.globalRoomContainerUIData.v == null)
                                        {
                                            GlobalRoomContainerUI.UIData globalRoomContainerUIData = new GlobalRoomContainerUI.UIData();
                                            {
                                                globalRoomContainerUIData.uid = this.data.globalRoomContainerUIData.makeId();
                                            }
                                            this.data.globalRoomContainerUIData.v = globalRoomContainerUIData;
                                        }
                                        // container
                                        {
                                            if (globalRoomContainerUI != null)
                                            {
                                                globalRoomContainerUI.gameObject.SetActive(true);
                                            }
                                            if (allLimitRoomContainersUI != null)
                                            {
                                                allLimitRoomContainersUI.gameObject.SetActive(false);
                                            }
                                        }
                                    }
                                    break;
                                case RoomContainer.Type.Limit:
                                    {
                                        // btn
                                        {
                                            btnGlobal.interactable = true;
                                            btnLimit.interactable = false;
                                        }
                                        // sub
                                        if (this.data.allLimitRoomContainersUIData.v == null)
                                        {
                                            AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = new AllLimitRoomContainersUI.UIData();
                                            {
                                                allLimitRoomContainersUIData.uid = this.data.allLimitRoomContainersUIData.makeId();
                                            }
                                            this.data.allLimitRoomContainersUIData.v = allLimitRoomContainersUIData;
                                        }
                                        // container
                                        {
                                            if (globalRoomContainerUI != null)
                                            {
                                                globalRoomContainerUI.gameObject.SetActive(false);
                                            }
                                            if (allLimitRoomContainersUI != null)
                                            {
                                                allLimitRoomContainersUI.gameObject.SetActive(true);
                                            }
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown show: " + this.data.show.v);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("btnGlobal, btnLimit null");
                        }
                    }
                    // globalRoomContainer
                    {
                        GlobalRoomContainerUI.UIData globalRoomContainerUIData = this.data.globalRoomContainerUIData.v;
                        if (globalRoomContainerUIData != null)
                        {
                            globalRoomContainerUIData.globalRoomContainer.v = new ReferenceData<GlobalRoomContainer>(roomManager.globalRoomContainer.v);
                        }
                        else
                        {
                            Debug.LogError("globalRoomContainerUIData null");
                        }
                    }
                    // allLimitRoomContainers
                    {
                        AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = this.data.allLimitRoomContainersUIData.v;
                        if (allLimitRoomContainersUIData != null)
                        {
                            allLimitRoomContainersUIData.allLimitRoomContainers.v = new ReferenceData<AllLimitRoomContainers>(roomManager.allLimitRoomContainers.v);
                        }
                        else
                        {
                            Debug.LogError("allLimitRoomContainersUIData null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("roomManager null");
                }
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

    public GlobalRoomContainerUI globalPrefab;
    public AllLimitRoomContainersUI limitPrefab;

    public static readonly UIRectTransform subRect = UIRectTransform.CreateFullRect(0, 0, 0, 0);

    static RoomManagerUI()
    {

    }

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.roomManager.allAddCallBack(this);
                uiData.globalRoomContainerUIData.allAddCallBack(this);
                uiData.allLimitRoomContainersUIData.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is RoomManager)
            {
                dirty = true;
                return;
            }
            if (data is GlobalRoomContainerUI.UIData)
            {
                GlobalRoomContainerUI.UIData globalRoomContainerUIData = data as GlobalRoomContainerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(globalRoomContainerUIData, globalPrefab, this.transform, subRect);
                }
                dirty = true;
                return;
            }
            if (data is AllLimitRoomContainersUI.UIData)
            {
                AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = data as AllLimitRoomContainersUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(allLimitRoomContainersUIData, limitPrefab, this.transform, subRect);
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
            // Child
            {
                uiData.roomManager.allRemoveCallBack(this);
                uiData.globalRoomContainerUIData.allRemoveCallBack(this);
                uiData.allLimitRoomContainersUIData.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is RoomManager)
            {
                return;
            }
            if (data is GlobalRoomContainerUI.UIData)
            {
                GlobalRoomContainerUI.UIData globalRoomContainerUIData = data as GlobalRoomContainerUI.UIData;
                // UI
                {
                    globalRoomContainerUIData.removeCallBackAndDestroy(typeof(GlobalRoomContainerUI));
                }
                return;
            }
            if (data is AllLimitRoomContainersUI.UIData)
            {
                AllLimitRoomContainersUI.UIData allLimitRoomContainersUIData = data as AllLimitRoomContainersUI.UIData;
                // UI
                {
                    allLimitRoomContainersUIData.removeCallBackAndDestroy(typeof(AllLimitRoomContainersUI));
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
                case UIData.Property.roomManager:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.show:
                    dirty = true;
                    break;
                case UIData.Property.globalRoomContainerUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.allLimitRoomContainersUIData:
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
        {
            if (wrapProperty.p is RoomManager)
            {
                switch ((RoomManager.Property)wrapProperty.n)
                {
                    case RoomManager.Property.globalRoomContainer:
                        dirty = true;
                        break;
                    case RoomManager.Property.allLimitRoomContainers:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is GlobalRoomContainerUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is AllLimitRoomContainersUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnGlobal()
    {
        if (this.data != null)
        {
            this.data.show.v = RoomContainer.Type.Global;
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    public void onClickBtnLimit()
    {
        if (this.data != null)
        {
            this.data.show.v = RoomContainer.Type.Limit;
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}