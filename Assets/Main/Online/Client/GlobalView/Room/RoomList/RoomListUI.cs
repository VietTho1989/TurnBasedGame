using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class RoomListUI : UIBehavior<RoomListUI.UIData>
{

    #region UIData

    public class UIData : RoomContainerUI.UIData.Sub
    {

        public VP<RoomAdapter.UIData> roomAdapter;

        public VP<BtnLeaveLimitRoomContainerUI.UIData> btnLeaveLimitRoomContainerUIData;

        public VP<LimitRoomContainerUserListUI.UIData> limitRoomContainerUserListUIData;

        #region Sub

        public abstract class Sub : Data
        {

            public enum Type
            {
                CreateRoom,
                JoinRoom,
                Delete
            }

            public abstract Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            roomAdapter,
            btnLeaveLimitRoomContainerUIData,
            limitRoomContainerUserListUIData,
            sub
        }

        public UIData() : base()
        {
            this.roomAdapter = new VP<RoomAdapter.UIData>(this, (byte)Property.roomAdapter, new RoomAdapter.UIData());
            this.btnLeaveLimitRoomContainerUIData = new VP<BtnLeaveLimitRoomContainerUI.UIData>(this, (byte)Property.btnLeaveLimitRoomContainerUIData, null);
            this.limitRoomContainerUserListUIData = new VP<LimitRoomContainerUserListUI.UIData>(this, (byte)Property.limitRoomContainerUserListUIData, null);
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

        public override Type getType()
        {
            return Type.RoomList;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // sub
                if (!isProcess)
                {
                    Sub sub = this.sub.v;
                    if (sub != null)
                    {
                        isProcess = sub.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RoomListUI roomListUI = this.findCallBack<RoomListUI>();
                        if (roomListUI != null)
                        {
                            isProcess = roomListUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("roomListUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

        public override MainUI.UIData.AllowShowBanner getAllowShowBanner()
        {
            return MainUI.UIData.AllowShowBanner.ForceShow;
        }

    }

    #endregion

    #region txt

    public Text tvCreateRoom;
    private static readonly TxtLanguage txtCreateRoom = new TxtLanguage("Create Room");

    static RoomListUI()
    {
        // txt
        txtCreateRoom.add(Language.Type.vi, "Tạo phòng");
        // rect
        {
            // btnLeaveLimitRoomContainerRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                // offsetMin: (0.0, -30.0); offsetMax: (160.0, 0.0); sizeDelta: (160.0, 30.0);
                btnLeaveLimitRoomContainerRect.anchoredPosition = new Vector3(0.0f, 0f, 0f);
                btnLeaveLimitRoomContainerRect.anchorMin = new Vector2(0.0f, 1.0f);
                btnLeaveLimitRoomContainerRect.anchorMax = new Vector2(0.0f, 1.0f);
                btnLeaveLimitRoomContainerRect.pivot = new Vector2(0.0f, 1.0f);
                btnLeaveLimitRoomContainerRect.offsetMin = new Vector2(0.0f, -30.0f);
                btnLeaveLimitRoomContainerRect.offsetMax = new Vector2(160.0f, 0.0f);
                btnLeaveLimitRoomContainerRect.sizeDelta = new Vector2(160.0f, 30.0f);
            }
            // LimitRoomContainerUserListRect
            {
                // anchoredPosition: (0.0, -15.0); anchorMin: (0.8, 0.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.5); 
                // offsetMin: (0.0, 0.0); offsetMax: (0.0, -30.0); sizeDelta: (0.0, -30.0);
                limitRoomContainerUserListRect.anchoredPosition = new Vector3(0.0f, -15f, 0f);
                limitRoomContainerUserListRect.anchorMin = new Vector2(0.8f, 0.0f);
                limitRoomContainerUserListRect.anchorMax = new Vector2(1.0f, 1.0f);
                limitRoomContainerUserListRect.pivot = new Vector2(0.5f, 0.5f);
                limitRoomContainerUserListRect.offsetMin = new Vector2(0.0f, 0.0f);
                limitRoomContainerUserListRect.offsetMax = new Vector2(0.0f, -30.0f);
                limitRoomContainerUserListRect.sizeDelta = new Vector2(0.0f, -30.0f);
            }
        }
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
                // RoomAdapter
                {
                    RoomAdapter.UIData roomAdapter = this.data.roomAdapter.v;
                    if (roomAdapter != null)
                    {

                    }
                    else
                    {
                        Debug.LogError("roomAdapter null: " + this);
                    }
                }
                // txt
                {
                    if (tvCreateRoom != null)
                    {
                        tvCreateRoom.text = txtCreateRoom.get(); ;
                    }
                    else
                    {
                        Debug.LogError("tvCreateRoom null: " + this);
                    }
                }
                // limitRoomContainer
                {
                    LimitRoomContainer limitRoomContainer = null;
                    // find
                    {
                        LimitRoomContainerUI.UIData limitRoomContainerUIData = this.data.findDataInParent<LimitRoomContainerUI.UIData>();
                        if (limitRoomContainerUIData != null)
                        {
                            limitRoomContainer = limitRoomContainerUIData.limitRoomContainer.v.data;
                        }
                        else
                        {
                            // Debug.LogError ("limitRoomContainerUIData null");
                        }
                    }
                    // process
                    if (limitRoomContainer != null)
                    {
                        // btnLeaveLimitRoomContainerUIData
                        {
                            BtnLeaveLimitRoomContainerUI.UIData btnLeaveLimitRoomContainerUIData = this.data.btnLeaveLimitRoomContainerUIData.newOrOld<BtnLeaveLimitRoomContainerUI.UIData>();
                            {
                                btnLeaveLimitRoomContainerUIData.limitRoomContainer.v = new ReferenceData<LimitRoomContainer>(limitRoomContainer);
                            }
                            this.data.btnLeaveLimitRoomContainerUIData.v = btnLeaveLimitRoomContainerUIData;
                        }
                        // limitRoomContainerUserListUIData
                        {
                            LimitRoomContainerUserListUI.UIData limitRoomContainerUserListUIData = this.data.limitRoomContainerUserListUIData.newOrOld<LimitRoomContainerUserListUI.UIData>();
                            {
                                limitRoomContainerUserListUIData.limitRoomContainer.v = new ReferenceData<LimitRoomContainer>(limitRoomContainer);
                            }
                            this.data.limitRoomContainerUserListUIData.v = limitRoomContainerUserListUIData;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("limitRoomContainer null");
                        this.data.btnLeaveLimitRoomContainerUIData.v = null;
                        this.data.limitRoomContainerUserListUIData.v = null;
                    }
                    // transform
                    {
                        // roomAdapterContainer
                        // TODO Can hoan thien
                        /*if (roomAdapterContainer != null && roomAdapterContainer is RectTransform) {
							((RectTransform)roomAdapterContainer).anchorMax = (limitRoomContainer != null) ? new Vector2 (0.8f, 1f) : new Vector2 (1f, 1f);
						} else {
							Debug.LogError ("roomAdapterContainer null");
						}*/
                        // limitRoomContainerUserListContainer
                        {
                            LimitRoomContainerUserListUI.UIData userListUIData = this.data.limitRoomContainerUserListUIData.v;
                            if (userListUIData != null)
                            {
                                LimitRoomContainerUserListUI userListUI = userListUIData.findCallBack<LimitRoomContainerUserListUI>();
                                if (userListUI != null)
                                {
                                    userListUI.gameObject.SetActive(limitRoomContainer != null);
                                }
                            }
                            else
                            {
                                // Debug.LogError("userListUIData null");
                            }
                        }
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
        return true;
    }

    #endregion

    #region implement callBacks

    public RoomAdapter roomAdapterPrefab;
    public static readonly UIRectTransform roomAdapterRect = UIConstants.FullParent;

    public CreateRoomUI createRoomPrefab;
    public JoinRoomUI joinRoomPrefab;
    public RoomAdminBtnDeleteUI roomAdminBtnDeletePrefab;

    public BtnLeaveLimitRoomContainerUI btnLeaveLimitRoomContainerPrefab;
    public static readonly UIRectTransform btnLeaveLimitRoomContainerRect = new UIRectTransform();

    public LimitRoomContainerUserListUI limitRoomContainerUserListPrefab;
    public static readonly UIRectTransform limitRoomContainerUserListRect = new UIRectTransform();

    private LimitRoomContainerUI.UIData limitRoomContainerUIData = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Parent
            {
                DataUtils.addParentCallBack(uiData, this, ref this.limitRoomContainerUIData);
            }
            // Child
            {
                uiData.roomAdapter.allAddCallBack(this);
                uiData.btnLeaveLimitRoomContainerUIData.allAddCallBack(this);
                uiData.limitRoomContainerUserListUIData.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
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
        // Parent
        if (data is LimitRoomContainerUI.UIData)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if (data is RoomAdapter.UIData)
            {
                RoomAdapter.UIData roomAdapterUIData = data as RoomAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(roomAdapterUIData, roomAdapterPrefab, this.transform, roomAdapterRect);
                }
                dirty = true;
                return;
            }
            if (data is BtnLeaveLimitRoomContainerUI.UIData)
            {
                BtnLeaveLimitRoomContainerUI.UIData btnLeaveLimitRoomContainerUIData = data as BtnLeaveLimitRoomContainerUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnLeaveLimitRoomContainerUIData, btnLeaveLimitRoomContainerPrefab, this.transform, btnLeaveLimitRoomContainerRect);
                }
                dirty = true;
                return;
            }
            if (data is LimitRoomContainerUserListUI.UIData)
            {
                LimitRoomContainerUserListUI.UIData limitRoomContainerUserListUIData = data as LimitRoomContainerUserListUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(limitRoomContainerUserListUIData, limitRoomContainerUserListPrefab, this.transform, limitRoomContainerUserListRect);
                }
                dirty = true;
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.CreateRoom:
                            {
                                CreateRoomUI.UIData createRoomUIData = sub as CreateRoomUI.UIData;
                                UIUtils.Instantiate(createRoomUIData, createRoomPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.JoinRoom:
                            {
                                JoinRoomUI.UIData joinRoomUIData = sub as JoinRoomUI.UIData;
                                UIUtils.Instantiate(joinRoomUIData, joinRoomPrefab, this.transform);
                            }
                            break;
                        case UIData.Sub.Type.Delete:
                            {
                                RoomAdminBtnDeleteUI.UIData roomAdminBtnDeleteUIData = sub as RoomAdminBtnDeleteUI.UIData;
                                UIUtils.Instantiate(roomAdminBtnDeleteUIData, roomAdminBtnDeletePrefab, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
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
            // Parent
            {
                DataUtils.removeParentCallBack(uiData, this, ref this.limitRoomContainerUIData);
            }
            // Child
            {
                uiData.roomAdapter.allRemoveCallBack(this);
                uiData.btnLeaveLimitRoomContainerUIData.allRemoveCallBack(this);
                uiData.limitRoomContainerUserListUIData.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
        }
        // Parent
        if (data is LimitRoomContainerUI.UIData)
        {
            return;
        }
        // Child
        {
            if (data is RoomAdapter.UIData)
            {
                RoomAdapter.UIData roomAdapterUIData = data as RoomAdapter.UIData;
                // UI
                {
                    roomAdapterUIData.removeCallBackAndDestroy(typeof(RoomAdapter));
                }
                return;
            }
            if (data is BtnLeaveLimitRoomContainerUI.UIData)
            {
                BtnLeaveLimitRoomContainerUI.UIData btnLeaveLimitRoomContainerUIData = data as BtnLeaveLimitRoomContainerUI.UIData;
                // UI
                {
                    btnLeaveLimitRoomContainerUIData.removeCallBackAndDestroy(typeof(BtnLeaveLimitRoomContainerUI));
                }
                return;
            }
            if (data is LimitRoomContainerUserListUI.UIData)
            {
                LimitRoomContainerUserListUI.UIData limitRoomContainerUserListUIData = data as LimitRoomContainerUserListUI.UIData;
                // UI
                {
                    limitRoomContainerUserListUIData.removeCallBackAndDestroy(typeof(LimitRoomContainerUserListUI));
                }
                return;
            }
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                // UI
                {
                    switch (sub.getType())
                    {
                        case UIData.Sub.Type.CreateRoom:
                            {
                                CreateRoomUI.UIData createRoomUIData = sub as CreateRoomUI.UIData;
                                createRoomUIData.removeCallBackAndDestroy(typeof(CreateRoomUI));
                            }
                            break;
                        case UIData.Sub.Type.JoinRoom:
                            {
                                JoinRoomUI.UIData joinRoomUIData = sub as JoinRoomUI.UIData;
                                joinRoomUIData.removeCallBackAndDestroy(typeof(JoinRoomUI));
                            }
                            break;
                        case UIData.Sub.Type.Delete:
                            {
                                RoomAdminBtnDeleteUI.UIData roomAdminBtnDeleteUIData = sub as RoomAdminBtnDeleteUI.UIData;
                                roomAdminBtnDeleteUIData.removeCallBackAndDestroy(typeof(RoomAdminBtnDeleteUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
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
                case UIData.Property.roomAdapter:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnLeaveLimitRoomContainerUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.limitRoomContainerUserListUIData:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
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
        // Parent
        if (wrapProperty.p is LimitRoomContainerUI.UIData)
        {
            switch ((LimitRoomContainerUI.UIData.Property)wrapProperty.n)
            {
                case LimitRoomContainerUI.UIData.Property.limitRoomContainer:
                    dirty = true;
                    break;
                case LimitRoomContainerUI.UIData.Property.roomContainerUIData:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is RoomAdapter.UIData)
            {
                return;
            }
            if (wrapProperty.p is BtnLeaveLimitRoomContainerUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is LimitRoomContainerUserListUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnCreateMatch, onClickBtnCreateMatch);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.C:
                        {
                            if (btnCreateMatch != null && btnCreateMatch.gameObject.activeInHierarchy && btnCreateMatch.interactable)
                            {
                                this.onClickBtnCreateMatch();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    public Button btnCreateMatch;

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnCreateMatch()
    {
        if (this.data != null)
        {
            // Check need new?
            bool needNew = true;
            {
                if (this.data.sub.v != null)
                {
                    if (this.data.sub.v.getType() == UIData.Sub.Type.CreateRoom)
                    {
                        needNew = false;
                    }
                }
            }
            // Process
            if (needNew)
            {
                CreateRoomUI.UIData createRoomUIData = new CreateRoomUI.UIData();
                {
                    createRoomUIData.uid = this.data.sub.makeId();
                    {
                        EditData<CreateRoom> editCreateRoom = createRoomUIData.editCreateRoom.v;
                        // origin
                        {
                            CreateRoom createRoom = new CreateRoom();
                            {
                                createRoom.gameType.v = Setting.get().defaultChosenGame.v.getGame();
                                createRoom.roomName.v = Setting.get().defaultRoomName.v.getRoomName();
                            }
                            editCreateRoom.origin.v = new ReferenceData<CreateRoom>(createRoom);
                        }
                        // show
                        // compare
                        // compareOtherType
                        // canEdit
                        editCreateRoom.canEdit.v = true;
                        // editType
                        editCreateRoom.editType.v = Data.EditType.Immediate;
                    }
                }
                this.data.sub.v = createRoomUIData;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}