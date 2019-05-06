using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UserUI : UIBehavior<UserUI.UIData>
{

    #region UIData

    public class UIData : Data, EditDataUI.UIData<User>
    {

        public VP<EditData<User>> editUser;

        #region editType

        public VP<EditType> editType;

        public VP<RequestChangeEnumUI.UIData> requestEditType;

        public void makeRequestChangeEditType(RequestChangeUpdate<int>.UpdateData update, int newEditType)
        {
            this.editType.v = (EditType)newEditType;
        }

        #endregion

        // human
        public VP<HumanUI.UIData> human;

        #region role

        public VP<RequestChangeEnumUI.UIData> role;

        public void makeRequestChangeRole(RequestChangeUpdate<int>.UpdateData update, int newRole)
        {
            // Find
            User user = null;
            {
                EditData<User> editUser = this.editUser.v;
                if (editUser != null)
                {
                    user = editUser.show.v.data;
                }
                else
                {
                    Debug.LogError("editUser null: " + this);
                }
            }
            // Process
            if (user != null)
            {
                user.requestChangeRole(Server.getProfileUserId(user), (User.Role)newRole);
            }
            else
            {
                Debug.LogError("user null: " + this);
            }
        }

        #endregion

        // ipAddress
        public VP<RequestChangeStringUI.UIData> ipAddress;

        // registerTime
        public VP<RequestChangeStringUI.UIData> registerTime;

        public VP<BtnUpdateUser.UIData> btnUpdate;

        public VP<UserChatUI.UIData> userChat;

        #region Constructor

        public enum Property
        {
            editUser,
            editType,
            requestEditType,
            human,
            role,
            ipAddress,
            registerTime,
            btnUpdate,
            userChat
        }

        public UIData() : base()
        {
            this.editUser = new VP<EditData<User>>(this, (byte)Property.editUser, new EditData<User>());
            this.editType = new VP<EditType>(this, (byte)Property.editType, EditType.Later);
            // editType
            {
                this.requestEditType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.requestEditType, new RequestChangeEnumUI.UIData());
                foreach (EditType editType in System.Enum.GetValues(typeof(EditType)))
                {
                    this.requestEditType.v.options.add(editType.ToString());
                }
                this.requestEditType.v.updateData.v.request.v = makeRequestChangeEditType;
            }
            // human
            {
                this.human = new VP<HumanUI.UIData>(this, (byte)Property.human, new HumanUI.UIData());
                this.human.v.showType.v = UIRectTransform.ShowType.HeadLess;
            }
            // role
            {
                this.role = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.role, new RequestChangeEnumUI.UIData());
                foreach (User.Role role in System.Enum.GetValues(typeof(User.Role)))
                {
                    this.role.v.options.add(role.ToString());
                }
                this.role.v.updateData.v.request.v = makeRequestChangeRole;
            }
            // ipAddress
            {
                this.ipAddress = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.ipAddress, new RequestChangeStringUI.UIData());
                this.ipAddress.v.updateData.v.canRequestChange.v = false;
            }
            // registerTime
            {
                this.registerTime = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.registerTime, new RequestChangeStringUI.UIData());
                this.registerTime.v.updateData.v.canRequestChange.v = false;
            }
            this.btnUpdate = new VP<BtnUpdateUser.UIData>(this, (byte)Property.btnUpdate, new BtnUpdateUser.UIData());
            this.userChat = new VP<UserChatUI.UIData>(this, (byte)Property.userChat, null);
        }

        #endregion

        public void reset()
        {
            if (this.btnUpdate.v != null)
            {
                this.btnUpdate.v.state.v = BtnUpdateUser.UIData.State.None;
            }
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // userChat
                if (!isProcess)
                {
                    UserChatUI.UIData userChatUIData = this.userChat.v;
                    if (userChatUIData != null)
                    {
                        isProcess = userChatUIData.processEvent(e);
                    }
                    else
                    {
                        Debug.LogError("userChatUIData null: " + this);
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        UserUI userUI = this.findCallBack<UserUI>();
                        if (userUI != null)
                        {
                            userUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("userUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        UserUI userUI = this.findCallBack<UserUI>();
                        if (userUI != null)
                        {
                            isProcess = userUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("userUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

        #region implement interface

        public EditData<User> getEditData()
        {
            return this.editUser.v;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("User Information");

    public Text lbRole;
    private static readonly TxtLanguage txtRole = new TxtLanguage("Role");

    public Text lbIpAddress;
    private static readonly TxtLanguage txtIpAddress = new TxtLanguage("Ip address");

    public Text lbRegisterTime;
    private static readonly TxtLanguage txtRegisterTime = new TxtLanguage("Register time");

    public Text tvReset;
    private static readonly TxtLanguage txtReset = new TxtLanguage("Reset");
    private static readonly TxtLanguage txtCannotReset = new TxtLanguage("Reset");

    static UserUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thông Tin Người Dùng");
            txtRole.add(Language.Type.vi, "Vai trò");
            txtIpAddress.add(Language.Type.vi, "Địa chỉ ip");
            txtRegisterTime.add(Language.Type.vi, "Thời điểm đăng ký");
            // reset
            {
                txtReset.add(Language.Type.vi, "Đặt Lại");
                txtCannotReset.add(Language.Type.vi, "Dặt Lại");
            }
        }
        // rect
        {
            // requestEditTypeRect
            {
                // anchoredPosition: (-160.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0); 
                // offsetMin: (-320.0, -30.0); offsetMax: (-160.0, 0.0); sizeDelta: (160.0, 30.0);
                requestEditTypeRect.anchoredPosition = new Vector3(-30.0f, 0f, 0f);
                requestEditTypeRect.anchorMin = new Vector2(1.0f, 1.0f);
                requestEditTypeRect.anchorMax = new Vector2(1.0f, 1.0f);
                requestEditTypeRect.pivot = new Vector2(1.0f, 1.0f);
                requestEditTypeRect.offsetMin = new Vector2(-110.0f, -30.0f);
                requestEditTypeRect.offsetMax = new Vector2(-30.0f, 0.0f);
                requestEditTypeRect.sizeDelta = new Vector2(80.0f, 30.0f);
            }
            // btnUpdateUserRect
            {
                // anchoredPosition: (-80.0, 15.0); anchorMin: (0.5, 0.0); anchorMax: (0.5, 0.0); pivot: (0.5, 0.0);
                // offsetMin: (-160.0, 15.0); offsetMax: (0.0, 45.0); sizeDelta: (160.0, 30.0);
                btnUpdateUserRect.anchoredPosition = new Vector3(-80.0f, 15.0f, 0.0f);
                btnUpdateUserRect.anchorMin = new Vector2(0.5f, 0.0f);
                btnUpdateUserRect.anchorMax = new Vector2(0.5f, 0.0f);
                btnUpdateUserRect.pivot = new Vector2(0.5f, 0.0f);
                btnUpdateUserRect.offsetMin = new Vector2(-160.0f, 15.0f);
                btnUpdateUserRect.offsetMax = new Vector2(0.0f, 45.0f);
                btnUpdateUserRect.sizeDelta = new Vector2(160.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public Image bgHuman;

    public Button btnReset;

    public Button btnBack;
    public Button btnChat;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // requestEditType
                {
                    Data.RefreshStrEditType(this.data.requestEditType.v);
                }
                EditData<User> editUser = this.data.editUser.v;
                if (editUser != null)
                {
                    {
                        // check is your user?
                        bool isYourUser = false;
                        {
                            User originUser = editUser.origin.v.data;
                            if (originUser != null)
                            {
                                Human human = originUser.human.v;
                                if (human != null)
                                {
                                    if (human.playerId.v == Server.getProfileUserId(originUser))
                                    {
                                        isYourUser = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("human null: " + this);
                                }
                            }
                            else
                            {
                                Debug.LogError("originUser null: " + this);
                            }
                        }
                        // Process
                        {
                            if (isYourUser)
                            {
                                editUser.canEdit.v = true;
                            }
                            else
                            {
                                editUser.canEdit.v = false;
                                editUser.editType.v = Data.EditType.Immediate;
                            }
                        }
                    }
                    // editType
                    {
                        if (editUser.canEdit.v)
                        {
                            editUser.editType.v = this.data.editType.v;
                        }
                        else
                        {
                            this.data.editType.v = Data.EditType.Immediate;
                        }
                    }
                    // requestEditType
                    {
                        // request
                        {
                            RequestChangeEnumUI.UIData requestEditType = this.data.requestEditType.v;
                            if (requestEditType != null)
                            {
                                RequestChangeUpdate<int>.UpdateData updateData = requestEditType.updateData.v;
                                if (updateData != null)
                                {
                                    updateData.canRequestChange.v = editUser.canEdit.v;
                                    updateData.origin.v = (int)this.data.editType.v;
                                }
                                else
                                {
                                    Debug.LogError("updateData null: " + this);
                                }
                                // show or not
                                {
                                    RequestChangeEnumUI requestEditTypeUI = requestEditType.findCallBack<RequestChangeEnumUI>();
                                    if (requestEditTypeUI != null)
                                    {
                                        requestEditTypeUI.gameObject.SetActive(editUser.canEdit.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("requestEditTypeUI null");
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("editType null: " + this);
                            }
                        }
                    }
                    // bottom
                    {
                        bool isShowBottom = editUser.canEdit.v && editUser.editType.v == Data.EditType.Later;
                        // btnReset
                        if (btnReset != null)
                        {
                            btnReset.gameObject.SetActive(isShowBottom);
                        }
                        else
                        {
                            Debug.LogError("btnReset null");
                        }
                        // btnUpdateUser
                        {
                            BtnUpdateUser.UIData btnUpdateUIData = this.data.btnUpdate.v;
                            if (btnUpdateUIData != null)
                            {
                                BtnUpdateUser btnUpdate = btnUpdateUIData.findCallBack<BtnUpdateUser>();
                                if (btnUpdate != null)
                                {
                                    btnUpdate.gameObject.SetActive(isShowBottom);
                                }
                                else
                                {
                                    Debug.LogError("btnUpdate null");
                                }
                            }
                            else
                            {
                                Debug.LogError("btnUpdateUIData null");
                            }
                        }
                        // scrollRect
                        if (scrollRect != null)
                        {
                            float buttonSize = Setting.get().getButtonSize();
                            if (isShowBottom)
                            {
                                UIRectTransform scrollRectLater = UIRectTransform.CreateFullRect(0, 0, buttonSize, UIConstants.ItemHeight);
                                scrollRectLater.set(scrollRect);
                            }
                            else
                            {
                                UIRectTransform scrollRectImmeditate = UIRectTransform.CreateFullRect(0, 0, buttonSize, 0);
                                scrollRectImmeditate.set(scrollRect);
                            }
                        }
                        else
                        {
                            Debug.LogError("scrollRect null");
                        }
                    }
                    editUser.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editUser);
                        // get server state
                        Server.State.Type serverState = RequestChange.GetServerState(editUser);
                        // set origin
                        {
                            EditDataUI.RefreshChildUI(this.data, this.data.human.v, editData => editData.human.v);
                            // role
                            {
                                bool canRequestChange = false;
                                {
                                    User show = editUser.show.v.data;
                                    if (show != null)
                                    {
                                        canRequestChange = show.isCanChangeRole(Server.getProfileUserId(editUser.origin.v.data));
                                    }
                                    else
                                    {
                                        Debug.LogError("show null");
                                    }
                                }
                                RequestChange.RefreshUIWithCanEdit(this.data.role.v, editUser, serverState, needReset, editData => (int)editData.role.v, canRequestChange);
                            }
                            RequestChange.RefreshUIWithCanEdit(this.data.ipAddress.v, editUser, serverState, needReset, editData => editData.ipAddress.v, false);
                            RequestChange.RefreshUIWithCanEdit(this.data.registerTime.v, editUser, serverState, needReset, editData => Human.GetStrBirthday(editData.registerTime.v), false);
                        }
                        needReset = false;
                    }
                    // userChat
                    {
                        UserChatUI.UIData userChatUIData = this.data.userChat.v;
                        if (userChatUIData != null)
                        {
                            userChatUIData.user.v = new ReferenceData<User>(editUser.origin.v.data);
                        }
                        else
                        {
                            Debug.LogError("userChatUIData null: " + this);
                        }
                    }
                    // human
                    {
                        HumanUI.UIData humanUIData = this.data.human.v;
                        if (humanUIData != null)
                        {
                            bool isYouAdmin = false;
                            {
                                User profileUser = Server.GetProfileUser(editUser.origin.v.data);
                                if (profileUser != null)
                                {
                                    if (profileUser.role.v == User.Role.Admin)
                                    {
                                        isYouAdmin = true;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("profileUser null");
                                }
                            }
                            if (isYouAdmin)
                            {
                                BanUI.UIData banUIData = humanUIData.ban.newOrOld<BanUI.UIData>();
                                {

                                }
                                humanUIData.ban.v = banUIData;
                            }
                            else
                            {
                                humanUIData.ban.v = null;
                            }
                        }
                        else
                        {
                            Debug.LogError("humanUIData null");
                        }
                    }
                    // Header
                    {
                        UIRectTransform.SetTitleTransform(lbTitle);
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        UIRectTransform.SetButtonTopRightTransform(btnChat);
                    }
                    // Content UI Size
                    {
                        float deltaY = 0;
                        // human
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.human.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgHuman != null)
                            {
                                UIRectTransform.SetPosY(bgHuman.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgHuman.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgHuman null");
                            }
                        }
                        // role
                        UIUtils.SetLabelContentPosition(lbRole, this.data.role.v, ref deltaY);
                        // ipAddress
                        UIUtils.SetLabelContentPosition(lbIpAddress, this.data.ipAddress.v, ref deltaY);
                        // registerTime
                        UIUtils.SetLabelContentPosition(lbRegisterTime, this.data.registerTime.v, ref deltaY);
                        // set height
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight((RectTransform)contentContainer, deltaY);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                    }
                    // btnReset
                    {
                        if (btnReset != null && tvReset != null)
                        {
                            // find
                            bool isDifferent = true;
                            {
                                if (editUser.canEdit.v && editUser.editType.v == Data.EditType.Later)
                                {
                                    User originUser = editUser.origin.v.data;
                                    User showUser = editUser.show.v.data;
                                    if (originUser != null && showUser != null)
                                    {
                                        isDifferent = DataUtils.IsDifferent(originUser, showUser);
                                    }
                                }
                            }
                            // process
                            if (isDifferent)
                            {
                                btnReset.interactable = true;
                                tvReset.text = txtReset.get();
                            }
                            else
                            {
                                btnReset.interactable = false;
                                tvReset.text = txtCannotReset.get();
                            }
                        }
                        else
                        {
                            Debug.LogError("btnReset, tvReset null");
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbRole != null)
                        {
                            lbRole.text = txtRole.get();
                            Setting.get().setLabelTextSize(lbRole);
                        }
                        else
                        {
                            Debug.LogError("lbRole null: " + this);
                        }
                        if (lbIpAddress != null)
                        {
                            lbIpAddress.text = txtIpAddress.get();
                            Setting.get().setLabelTextSize(lbIpAddress);
                        }
                        else
                        {
                            Debug.LogError("lbIpAddress null: " + this);
                        }
                        if (lbRegisterTime != null)
                        {
                            lbRegisterTime.text = txtRegisterTime.get();
                            Setting.get().setLabelTextSize(lbRegisterTime);
                        }
                        else
                        {
                            Debug.LogError("lbRegisterTime null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("editUser null: " + this);
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

    #region implement callBacks

    public RectTransform scrollRect;

    private static readonly UIRectTransform requestEditTypeRect = new UIRectTransform();

    public Transform contentContainer;

    public HumanUI humanPrefab;
    public RequestChangeEnumUI requestEnumPrefab;
    public RequestChangeStringUI requestStringPrefab;

    public BtnUpdateUser btnUpdateUserPrefab;
    private static readonly UIRectTransform btnUpdateUserRect = new UIRectTransform();

    public UserChatUI userChatPrefab;

    private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.editUser.allAddCallBack(this);
                uiData.requestEditType.allAddCallBack(this);
                uiData.human.allAddCallBack(this);
                uiData.role.allAddCallBack(this);
                uiData.ipAddress.allAddCallBack(this);
                uiData.registerTime.allAddCallBack(this);
                uiData.btnUpdate.allAddCallBack(this);
                uiData.userChat.allAddCallBack(this);
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
            // human
            {
                if (data is HumanUI.UIData)
                {
                    HumanUI.UIData humanUIData = data as HumanUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(humanUIData, humanPrefab, contentContainer);
                    }
                    // Child
                    {
                        TransformData.AddCallBack(humanUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
            // role
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.requestEditType:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, requestEditTypeRect);
                                break;
                            case UIData.Property.role:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, contentContainer, UIConstants.RequestEnumRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            // ipAddress, registerTime
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.ipAddress:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, contentContainer, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.registerTime:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, contentContainer, UIConstants.RequestEnumRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
                    }
                }
                dirty = true;
                return;
            }
            if (data is BtnUpdateUser.UIData)
            {
                BtnUpdateUser.UIData btnUpdateUserUIData = data as BtnUpdateUser.UIData;
                // UI
                {
                    UIUtils.Instantiate(btnUpdateUserUIData, btnUpdateUserPrefab, this.transform, btnUpdateUserRect);
                }
                dirty = true;
                return;
            }
            if (data is UserChatUI.UIData)
            {
                UserChatUI.UIData userChatUIData = data as UserChatUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(userChatUIData, userChatPrefab, this.transform, UIConstants.FullParent);
                }
                dirty = true;
                return;
            }
            // editUser
            {
                if (data is EditData<User>)
                {
                    EditData<User> editUser = data as EditData<User>;
                    // Child
                    {
                        editUser.show.allAddCallBack(this);
                        editUser.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is User)
                    {
                        User user = data as User;
                        // Parent
                        {
                            DataUtils.addParentCallBack(user, this, ref this.server);
                        }
                        // Child
                        {
                            user.addCallBackAllChildren(this);
                        }
                        needReset = true;
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is Server)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Child
                    {
                        data.addCallBackAllChildren(this);
                        dirty = true;
                        return;
                    }
                }
            }
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
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
                uiData.editUser.allRemoveCallBack(this);
                uiData.requestEditType.allRemoveCallBack(this);
                uiData.human.allRemoveCallBack(this);
                uiData.role.allRemoveCallBack(this);
                uiData.ipAddress.allRemoveCallBack(this);
                uiData.registerTime.allRemoveCallBack(this);
                uiData.btnUpdate.allRemoveCallBack(this);
                uiData.userChat.allRemoveCallBack(this);
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
            // human
            {
                if (data is HumanUI.UIData)
                {
                    HumanUI.UIData humanUIData = data as HumanUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(humanUIData, this);
                    }
                    // UI
                    {
                        humanUIData.removeCallBackAndDestroy(typeof(HumanUI));
                    }
                    return;
                }
                // Child
                if (data is TransformData)
                {
                    return;
                }
            }
            // role
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            // ipAddress, registerTime
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
                }
                return;
            }
            if (data is BtnUpdateUser.UIData)
            {
                BtnUpdateUser.UIData btnUpdateUserUIData = data as BtnUpdateUser.UIData;
                // UI
                {
                    btnUpdateUserUIData.removeCallBackAndDestroy(typeof(BtnUpdateUser));
                }
                return;
            }
            if (data is UserChatUI.UIData)
            {
                UserChatUI.UIData userChatUIData = data as UserChatUI.UIData;
                // UI
                {
                    userChatUIData.removeCallBackAndDestroy(typeof(UserChatUI));
                }
                return;
            }
            // editUser
            {
                if (data is EditData<User>)
                {
                    EditData<User> editUser = data as EditData<User>;
                    // Child
                    {
                        editUser.show.allRemoveCallBack(this);
                        editUser.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is User)
                    {
                        User user = data as User;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(user, this, ref this.server);
                        }
                        // Child
                        {
                            user.removeCallBackAllChildren(this);
                        }
                        return;
                    }
                    // Parent
                    if (data is Server)
                    {
                        return;
                    }
                    // Child
                    {
                        data.removeCallBackAllChildren(this);
                        return;
                    }
                }
            }
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
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
                case UIData.Property.editUser:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.editType:
                    dirty = true;
                    break;
                case UIData.Property.requestEditType:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.human:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.role:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.ipAddress:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.registerTime:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.btnUpdate:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.userChat:
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
                case Setting.Property.itemSize:
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
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            // human
            {
                if (wrapProperty.p is HumanUI.UIData)
                {
                    return;
                }
                // Child
                if (wrapProperty.p is TransformData)
                {
                    switch ((TransformData.Property)wrapProperty.n)
                    {
                        case TransformData.Property.anchoredPosition:
                            break;
                        case TransformData.Property.anchorMin:
                            break;
                        case TransformData.Property.anchorMax:
                            break;
                        case TransformData.Property.pivot:
                            break;
                        case TransformData.Property.offsetMin:
                            break;
                        case TransformData.Property.offsetMax:
                            break;
                        case TransformData.Property.sizeDelta:
                            break;
                        case TransformData.Property.rotation:
                            break;
                        case TransformData.Property.scale:
                            break;
                        case TransformData.Property.size:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // role
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            // ipAddress, registerTime
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
            // btnUpdate
            if (wrapProperty.p is BtnUpdateUser.UIData)
            {
                return;
            }
            if (wrapProperty.p is UserChatUI.UIData)
            {
                return;
            }
            // editUser
            {
                if (wrapProperty.p is EditData<User>)
                {
                    switch ((EditData<User>.Property)wrapProperty.n)
                    {
                        case EditData<User>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<User>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<User>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<User>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<User>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<User>.Property.editType:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is User)
                    {
                        if (Generic.IsAddCallBackInterface<T>())
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
                    if (wrapProperty.p is Server)
                    {
                        Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                        return;
                    }
                    // Child
                    {
                        if (Generic.IsAddCallBackInterface<T>())
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                        }
                        dirty = true;
                        return;
                    }
                }
            }
        }
        // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.R:
                        {
                            if (btnReset != null && btnReset.gameObject.activeInHierarchy && btnReset.interactable)
                            {
                                this.onClickBtnReset();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    case KeyCode.C:
                        {
                            if (btnChat != null && btnChat.gameObject.activeInHierarchy && btnChat.interactable)
                            {
                                this.onClickBtnChat();
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            GlobalProfileUI.UIData globalProfileUIData = this.data.findDataInParent<GlobalProfileUI.UIData>();
            if (globalProfileUIData != null)
            {
                globalProfileUIData.userUI.v = null;
            }
            else
            {
                Debug.LogError("globalProfileUIData null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnReset()
    {
        if (this.data != null)
        {
            EditData<User> editUser = this.data.editUser.v;
            if (editUser != null)
            {
                editUser.show.v = new ReferenceData<User>(null);
            }
            else
            {
                Debug.LogError("editUser null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnChat()
    {
        if (this.data != null)
        {
            UserChatUI.UIData userChatUIData = this.data.userChat.newOrOld<UserChatUI.UIData>();
            {

            }
            this.data.userChat.v = userChatUIData;
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}