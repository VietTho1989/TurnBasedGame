using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomUI : UIBehavior<RoomUI.UIData>
{

    #region UIData

    public class UIData : RoomContainerUI.UIData.Sub
    {

        public VP<ReferenceData<Room>> room;

        public VP<RoomBtnUI.UIData> roomBtnUIData;

        #region ContestManager

        public VP<ContestManagerUI.UIData> contestManagerUIData;

        public VP<RequestNewContestManagerUI.UIData> requestNewContestManagerUIData;

        #endregion

        public VP<ChooseContestManagerUI.UIData> chooseContestManagerUIData;

        public VP<RoomUserInformUI.UIData> roomUserInformUI;

        #region Constructor

        public enum Property
        {
            room,
            roomBtnUIData,

            contestManagerUIData,
            requestNewContestManagerUIData,

            chooseContestManagerUIData,
            roomUserInformUI
        }

        public UIData() : base()
        {
            this.room = new VP<ReferenceData<Room>>(this, (byte)Property.room, new ReferenceData<Room>(null));
            this.roomBtnUIData = new VP<RoomBtnUI.UIData>(this, (byte)Property.roomBtnUIData, new RoomBtnUI.UIData());

            this.contestManagerUIData = new VP<ContestManagerUI.UIData>(this, (byte)Property.contestManagerUIData, new ContestManagerUI.UIData());
            this.requestNewContestManagerUIData = new VP<RequestNewContestManagerUI.UIData>(this, (byte)Property.requestNewContestManagerUIData, new RequestNewContestManagerUI.UIData());

            this.chooseContestManagerUIData = new VP<ChooseContestManagerUI.UIData>(this, (byte)Property.chooseContestManagerUIData, null);
            this.roomUserInformUI = new VP<RoomUserInformUI.UIData>(this, (byte)Property.roomUserInformUI, null);
        }

        #endregion

        public override Type getType()
        {
            return Type.RoomUI;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // roomUserInformUI
                if (!isProcess)
                {
                    RoomUserInformUI.UIData roomUserInformUIData = this.roomUserInformUI.v;
                    if (roomUserInformUIData != null)
                    {
                        isProcess = roomUserInformUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("roomUserInformUI null: " + this);
                    }
                }
                // chooseContestManagerUIData
                if (!isProcess)
                {
                    ChooseContestManagerUI.UIData chooseContestManagerUIData = this.chooseContestManagerUIData.v;
                    if (chooseContestManagerUIData != null)
                    {
                        isProcess = chooseContestManagerUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("chooseContestManagerUIData null: " + this);
                    }
                }
                // requestNewContestManagerUIData
                if (!isProcess)
                {
                    RequestNewContestManagerUI.UIData requestNewContestManagerUIData = this.requestNewContestManagerUIData.v;
                    if (requestNewContestManagerUIData != null)
                    {
                        isProcess = requestNewContestManagerUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("requestNewContestManagerUIData null: " + this);
                    }
                }
                // contestManagerUIData
                if (!isProcess)
                {
                    ContestManagerUI.UIData contestManagerUIData = this.contestManagerUIData.v;
                    if (contestManagerUIData != null)
                    {
                        isProcess = contestManagerUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("contestManagerUIData null: " + this);
                    }
                }
                // roomBtnUIData
                if (!isProcess)
                {
                    RoomBtnUI.UIData roomBtnUIData = this.roomBtnUIData.v;
                    if (roomBtnUIData != null)
                    {
                        isProcess = roomBtnUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("roomBtnUIData null: " + this);
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            MainUI.UIData.AllowShowBanner ret = MainUI.UIData.AllowShowBanner.ForceShow;
            {
                ContestManagerUI.UIData contestManagerUIData = this.contestManagerUIData.v;
                if (contestManagerUIData != null)
                {
                    ContestManagerUI.UIData.Sub sub = contestManagerUIData.sub.v;
                    if (sub != null)
                    {
                        switch (sub.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                ret = MainUI.UIData.AllowShowBanner.ForceShow;
                                break;
                            case ContestManager.State.Type.Play:
                                ret = MainUI.UIData.AllowShowBanner.StatusQuo;
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType());
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("sub null");
                    }
                }
                else
                {
                    Debug.LogError("contestManagerUIData null");
                }
            }
            return ret;
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

    #region txt, rect

    static RoomUI()
    {
        // rect
        {
            // roomBtnRect
            {
                // anchoredPosition: (-40.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -30.0); offsetMax: (-80.0, 0.0); sizeDelta: (-80.0, 30.0);
                roomBtnRect.anchoredPosition = new Vector3(-45.0f, 0.0f, 0.0f);
                roomBtnRect.anchorMin = new Vector2(0.0f, 1.0f);
                roomBtnRect.anchorMax = new Vector2(1.0f, 1.0f);
                roomBtnRect.pivot = new Vector2(0.5f, 1.0f);
                roomBtnRect.offsetMin = new Vector2(0.0f, -30.0f);
                roomBtnRect.offsetMax = new Vector2(-90.0f, 0.0f);
                roomBtnRect.sizeDelta = new Vector2(-90.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool haveNewContestManager = false;

    public Image freezeOverlay;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                Room room = this.data.room.v.data;
                if (room != null)
                {
                    // chon contestManager
                    {
                        // check isLoadFull
                        bool isLoadFull = true;
                        {
                            // dataIdentity
                            if (isLoadFull)
                            {
                                DataIdentity dataIdentity = null;
                                if (DataIdentity.clientMap.TryGetValue(room, out dataIdentity))
                                {
                                    if (dataIdentity is RoomIdentity)
                                    {
                                        RoomIdentity roomIdentity = dataIdentity as RoomIdentity;
                                        if (roomIdentity.contestManagers != room.contestManagers.vs.Count)
                                        {
                                            Debug.LogError("contestManagers count error");
                                            isLoadFull = false;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("why not roomIdentity");
                                    }
                                }
                            }
                        }
                        // process
                        if (isLoadFull)
                        {
                            ContestManagerUI.UIData contestManagerUIData = this.data.contestManagerUIData.v;
                            if (contestManagerUIData != null)
                            {
                                if (contestManagerUIData.contestManager.v.data == null ||
                                    !room.contestManagers.vs.Contains(contestManagerUIData.contestManager.v.data))
                                {
                                    // Find contestManager
                                    ContestManager contestManager = null;
                                    {
                                        if (room.contestManagers.vs.Count > 0)
                                        {
                                            contestManager = room.contestManagers.vs[room.contestManagers.vs.Count - 1];
                                        }
                                    }
                                    // Set
                                    contestManagerUIData.contestManager.v = new ReferenceData<ContestManager>(contestManager);
                                }
                                else
                                {
                                    if (haveNewContestManager)
                                    {
                                        ContestManager currentContestManager = contestManagerUIData.contestManager.v.data;
                                        if (currentContestManager != null)
                                        {
                                            if (currentContestManager.index.v == room.contestManagers.vs.Count - 2)
                                            {
                                                // set to new contestManager
                                                // Find contestManager
                                                ContestManager contestManager = null;
                                                {
                                                    if (room.contestManagers.vs.Count > 0)
                                                    {
                                                        contestManager = room.contestManagers.vs[room.contestManagers.vs.Count - 1];
                                                    }
                                                }
                                                // Set
                                                contestManagerUIData.contestManager.v = new ReferenceData<ContestManager>(contestManager);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("currentContestManager null: " + this);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("contestManagerUIData null: " + this);
                            }
                            haveNewContestManager = false;
                        }
                        else
                        {
                            Debug.LogError("not load full");
                            dirty = true;
                        }
                    }
                    // requestNewContestManagerUIData
                    {
                        RequestNewContestManagerUI.UIData requestNewContestManagerUIData = this.data.requestNewContestManagerUIData.v;
                        if (requestNewContestManagerUIData != null)
                        {
                            requestNewContestManagerUIData.requestNewContestManager.v = new ReferenceData<RequestNewContestManager>(room.requestNewContestManager.v);
                        }
                        else
                        {
                            Debug.LogError("requestNewContestManagerUIData null: " + this);
                        }
                    }
                    // chooseContestManagerUIData
                    {
                        ChooseContestManagerUI.UIData chooseContestManagerUIData = this.data.chooseContestManagerUIData.v;
                        if (chooseContestManagerUIData != null)
                        {
                            chooseContestManagerUIData.room.v = new ReferenceData<Room>(room);
                        }
                        else
                        {
                            // Debug.LogError ("chooseContestManagerUIData null: " + this);
                        }
                    }
                    // freezeOverlay
                    {
                        if (freezeOverlay != null)
                        {
                            bool isFreeze = false;
                            {
                                Room.State state = room.state.v;
                                if (state != null)
                                {
                                    switch (state.getType())
                                    {
                                        case Room.State.Type.Normal:
                                            {
                                                RoomStateNormal roomStateNormal = state as RoomStateNormal;
                                                if (roomStateNormal.state.v is RoomStateNormalFreeze)
                                                {
                                                    isFreeze = true;
                                                }
                                            }
                                            break;
                                        case Room.State.Type.End:
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("state null: " + this);
                                }
                            }
                            freezeOverlay.gameObject.SetActive(isFreeze);
                        }
                        else
                        {
                            Debug.LogError("freezeOverlay null");
                        }
                    }
                    // siblingIndex
                    {
                        int siblingIndex = 0;
                        // contestManagerUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.contestManagerUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // roomBtnUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.roomBtnUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // requestNewContestManagerUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.requestNewContestManagerUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // chooseContestManagerUIData
                        {
                            UIRectTransform.SetSiblingIndex(this.data.chooseContestManagerUIData.v, siblingIndex);
                            siblingIndex++;
                        }
                        // roomUserInformUI
                        {
                            UIRectTransform.SetSiblingIndex(this.data.roomUserInformUI.v, siblingIndex);
                            siblingIndex++;
                        }
                        // confirmBtnBackContainer
                        if (confirmBtnBackContainer != null)
                        {
                            confirmBtnBackContainer.SetSiblingIndex(siblingIndex);
                            siblingIndex++;
                        }
                        else
                        {
                            Debug.LogError("confirmBackContainer null");
                        }
                        // freezeOverlay
                        if (freezeOverlay != null)
                        {
                            freezeOverlay.transform.SetSiblingIndex(siblingIndex);
                            siblingIndex++;
                        }
                        else
                        {
                            Debug.LogError("freezeOverlay null");
                        }
                    }
                    // UI
                    {
                        float buttonSize = Setting.get().buttonSize.v;
                        // roombtn
                        {
                            roomBtnRect.anchoredPosition = new Vector3(-3*buttonSize/2, 0.0f, 0.0f);
                            roomBtnRect.anchorMin = new Vector2(0.0f, 1.0f);
                            roomBtnRect.anchorMax = new Vector2(1.0f, 1.0f);
                            roomBtnRect.pivot = new Vector2(0.5f, 1.0f);
                            roomBtnRect.offsetMin = new Vector2(0.0f, -buttonSize);
                            roomBtnRect.offsetMax = new Vector2(-3*buttonSize, 0.0f);
                            roomBtnRect.sizeDelta = new Vector2(-3*buttonSize, buttonSize);
                            UIRectTransform.Set(this.data.roomBtnUIData.v, roomBtnRect);
                        }
                        // contestManager
                        {
                            UIRectTransform rect = UIRectTransform.CreateFullRect(0, 0, buttonSize, 0);
                            UIRectTransform.Set(this.data.contestManagerUIData.v, rect);
                        }
                    }
                }
                else
                {
                    Debug.LogError("room null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBack

    public RoomBtnUI roomBtnPrefab;
    private static readonly UIRectTransform roomBtnRect = new UIRectTransform();

    public ContestManagerUI contestManagerPrefab;
    private static readonly UIRectTransform contestManagerRect = UIRectTransform.CreateFullRect(0, 0, UIConstants.HeaderHeight, 0);

    public ChooseContestManagerUI chooseContestManagerPrefab;

    public RequestNewContestManagerUI requestNewContestManagerPrefab;
    private static readonly UIRectTransform requestNewContestManagerRect = UIRectTransform.CreateFullRect(0, 0, 30, 0);

    public RoomUserInformUI roomUserInformPrefab;
    private static readonly UIRectTransform roomUserInformRect = UIConstants.FullParent;

    public Transform confirmBtnBackContainer;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.room.allAddCallBack(this);
                uiData.roomBtnUIData.allAddCallBack(this);
                uiData.contestManagerUIData.allAddCallBack(this);
                uiData.requestNewContestManagerUIData.allAddCallBack(this);
                uiData.chooseContestManagerUIData.allAddCallBack(this);
                uiData.roomUserInformUI.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            // Room
            {
                if (data is Room)
                {
                    Room room = data as Room;
                    // Child
                    {
                        room.contestManagers.allAddCallBack(this);
                        room.state.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is ContestManager)
                    {
                        haveNewContestManager = true;
                        dirty = true;
                        return;
                    }
                    // state
                    if (data is Room.State)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            if (data is RoomBtnUI.UIData)
            {
                RoomBtnUI.UIData roomBtnUIData = data as RoomBtnUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(roomBtnUIData, roomBtnPrefab, this.transform, roomBtnRect);
                }
                dirty = true;
                return;
            }
            if (data is ContestManagerUI.UIData)
            {
                ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(contestManagerUIData, contestManagerPrefab, this.transform, contestManagerRect);
                }
                dirty = true;
                return;
            }
            if (data is RequestNewContestManagerUI.UIData)
            {
                RequestNewContestManagerUI.UIData requestNewContestManagerUIData = data as RequestNewContestManagerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(requestNewContestManagerUIData, requestNewContestManagerPrefab, this.transform, requestNewContestManagerRect);
                }
                dirty = true;
                return;
            }
            if (data is ChooseContestManagerUI.UIData)
            {
                ChooseContestManagerUI.UIData chooseContestManagerUIData = data as ChooseContestManagerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(chooseContestManagerUIData, chooseContestManagerPrefab, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is RoomUserInformUI.UIData)
            {
                RoomUserInformUI.UIData roomUserInformUIData = data as RoomUserInformUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(roomUserInformUIData, roomUserInformPrefab, this.transform, roomUserInformRect);
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
            Setting.get().removeCallBack(this);
            // Child
            {
                uiData.room.allRemoveCallBack(this);
                uiData.roomBtnUIData.allRemoveCallBack(this);
                uiData.contestManagerUIData.allRemoveCallBack(this);
                uiData.requestNewContestManagerUIData.allRemoveCallBack(this);
                uiData.chooseContestManagerUIData.allRemoveCallBack(this);
                uiData.roomUserInformUI.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        {
            // Room
            {
                if (data is Room)
                {
                    Room room = data as Room;
                    // Child
                    {
                        room.contestManagers.allRemoveCallBack(this);
                        room.state.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is ContestManager)
                    {
                        return;
                    }
                    if (data is Room.State)
                    {
                        return;
                    }
                }
            }
            if (data is RoomBtnUI.UIData)
            {
                RoomBtnUI.UIData roomBtnUIData = data as RoomBtnUI.UIData;
                // UI
                {
                    roomBtnUIData.removeCallBackAndDestroy(typeof(RoomBtnUI));
                }
                return;
            }
            if (data is ContestManagerUI.UIData)
            {
                ContestManagerUI.UIData contestManagerUIData = data as ContestManagerUI.UIData;
                // UI
                {
                    contestManagerUIData.removeCallBackAndDestroy(typeof(ContestManagerUI));
                }
                return;
            }
            if (data is RequestNewContestManagerUI.UIData)
            {
                RequestNewContestManagerUI.UIData requestNewContestManagerUIData = data as RequestNewContestManagerUI.UIData;
                // UI
                {
                    requestNewContestManagerUIData.removeCallBackAndDestroy(typeof(RequestNewContestManagerUI));
                }
                return;
            }
            if (data is ChooseContestManagerUI.UIData)
            {
                ChooseContestManagerUI.UIData chooseContestManagerUIData = data as ChooseContestManagerUI.UIData;
                // UI
                {
                    chooseContestManagerUIData.removeCallBackAndDestroy(typeof(ChooseContestManagerUI));
                }
                return;
            }
            if (data is RoomUserInformUI.UIData)
            {
                RoomUserInformUI.UIData roomUserInformUIData = data as RoomUserInformUI.UIData;
                // UI
                {
                    roomUserInformUIData.removeCallBackAndDestroy(typeof(RoomUserInformUI));
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
                case UIData.Property.room:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.roomBtnUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.contestManagerUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.requestNewContestManagerUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.chooseContestManagerUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.roomUserInformUI:
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
        if(wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
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
                case Setting.Property.confirmQuit:
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
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // Room
            {
                if (wrapProperty.p is Room)
                {
                    switch ((Room.Property)wrapProperty.n)
                    {
                        case Room.Property.changeRights:
                            break;
                        case Room.Property.name:
                            break;
                        case Room.Property.password:
                            break;
                        case Room.Property.users:
                            break;
                        case Room.Property.state:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Room.Property.contestManagers:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Room.Property.timeCreated:
                            break;
                        case Room.Property.chatRoom:
                            break;
                        case Room.Property.allowHint:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is ContestManager)
                    {
                        return;
                    }
                    if(wrapProperty.p is Room.State)
                    {
                        Room.State roomState = wrapProperty.p as Room.State;
                        switch (roomState.getType())
                        {
                            case Room.State.Type.Normal:
                                {
                                    switch ((RoomStateNormal.Property)wrapProperty.n)
                                    {
                                        case RoomStateNormal.Property.state:
                                            dirty = true;
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                }
                                break;
                            case Room.State.Type.End:
                                break;
                            default:
                                Debug.LogError("unknown type: " + roomState.getType());
                                break;
                        }
                        return;
                    }
                }
            }
            if (wrapProperty.p is RoomBtnUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ContestManagerUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RequestNewContestManagerUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is ChooseContestManagerUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RoomUserInformUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}