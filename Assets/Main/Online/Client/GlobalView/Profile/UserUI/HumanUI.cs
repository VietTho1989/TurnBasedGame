using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

public class HumanUI : UIHaveTransformDataBehavior<HumanUI.UIData>
{

    #region UIData

    public class UIData : InformUI, EditDataUI.UIData<Human>
    {

        public VP<EditData<Human>> editHuman;

        public VP<UIRectTransform.ShowType> showType;

        // playerId
        public VP<RequestChangeIntUI.UIData> playerId;

        // account
        public VP<AccountUI.UIData> account;

        #region email

        public VP<RequestChangeStringUI.UIData> email;

        public void makeRequestChangeEmail(RequestChangeUpdate<string>.UpdateData update, string newEmail)
        {
            // Find
            Human human = null;
            {
                EditData<Human> editHuman = this.editHuman.v;
                if (editHuman != null)
                {
                    human = editHuman.show.v.data;
                }
                else
                {
                    Debug.LogError("editHuman null: " + this);
                }
            }
            // Process
            if (human != null)
            {
                human.requestChangeEmail(Server.getProfileUserId(human), newEmail);
            }
            else
            {
                Debug.LogError("human null: " + this);
            }
        }

        #endregion

        #region phoneNumber

        public VP<RequestChangeStringUI.UIData> phoneNumber;

        public void makeRequestChangePhoneNumber(RequestChangeUpdate<string>.UpdateData update, string newPhoneNumber)
        {
            // Find
            Human human = null;
            {
                EditData<Human> editHuman = this.editHuman.v;
                if (editHuman != null)
                {
                    human = editHuman.show.v.data;
                }
                else
                {
                    Debug.LogError("editHuman null: " + this);
                }
            }
            // Process
            if (human != null)
            {
                human.requestChangePhoneNumber(Server.getProfileUserId(human), newPhoneNumber);
            }
            else
            {
                Debug.LogError("human null: " + this);
            }
        }

        #endregion

        #region status

        public VP<RequestChangeStringUI.UIData> status;

        public void makeRequestChangeStatus(RequestChangeUpdate<string>.UpdateData update, string newStatus)
        {
            // Find
            Human human = null;
            {
                EditData<Human> editHuman = this.editHuman.v;
                if (editHuman != null)
                {
                    human = editHuman.show.v.data;
                }
                else
                {
                    Debug.LogError("editHuman null: " + this);
                }
            }
            // Process
            if (human != null)
            {
                human.requestChangeStatus(Server.getProfileUserId(human), newStatus);
            }
            else
            {
                Debug.LogError("human null: " + this);
            }
        }

        #endregion

        #region birthday

        public VP<RequestChangeStringUI.UIData> birthday;

        public void makeRequestChangeBirthday(RequestChangeUpdate<string>.UpdateData update, string newStrBirthday)
        {
            long newBirthday = Constants.UNKNOWN_TIME;
            {
                DateTime convertedDate;
                try
                {
                    convertedDate = Convert.ToDateTime(newStrBirthday);
                    DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    newBirthday = (long)(convertedDate - epoch).TotalMilliseconds;
                }
                catch (FormatException)
                {
                    Debug.LogError("not in proper format");
                }
            }
            // Find
            Human human = null;
            {
                EditData<Human> editHuman = this.editHuman.v;
                if (editHuman != null)
                {
                    human = editHuman.show.v.data;
                }
                else
                {
                    Debug.LogError("editHuman null: " + this);
                }
            }
            // Process
            if (human != null)
            {
                human.requestChangeBirthday(Server.getProfileUserId(human), newBirthday);
            }
            else
            {
                Debug.LogError("human null: " + this);
            }
        }

        #endregion

        #region sex

        public VP<RequestChangeEnumUI.UIData> sex;

        public void makeRequestChangeSex(RequestChangeUpdate<int>.UpdateData update, int newSex)
        {
            // Find
            Human human = null;
            {
                EditData<Human> editHuman = this.editHuman.v;
                if (editHuman != null)
                {
                    human = editHuman.show.v.data;
                }
                else
                {
                    Debug.LogError("editHuman null: " + this);
                }
            }
            // Process
            if (human != null)
            {
                human.requestChangeSex(Server.getProfileUserId(human), (User.SEX)newSex);
            }
            else
            {
                Debug.LogError("human null: " + this);
            }
        }

        #endregion

        // ban
        public VP<BanUI.UIData> ban;

        #region Constructor

        public enum Property
        {
            editHuman,
            showType,
            playerId,
            account,
            email,
            phoneNumber,
            status,
            birthday,
            sex,
            ban
        }

        public UIData() : base()
        {
            this.editHuman = new VP<EditData<Human>>(this, (byte)Property.editHuman, new EditData<Human>());
            this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            //playerId
            {
                this.playerId = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.playerId, new RequestChangeIntUI.UIData());
                this.playerId.v.updateData.v.canRequestChange.v = false;
            }
            this.account = new VP<AccountUI.UIData>(this, (byte)Property.account, new AccountUI.UIData());
            // email
            {
                this.email = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.email, new RequestChangeStringUI.UIData());
                this.email.v.updateData.v.request.v = makeRequestChangeEmail;
            }
            // phoneNumber
            {
                this.phoneNumber = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.phoneNumber, new RequestChangeStringUI.UIData());
                this.phoneNumber.v.updateData.v.request.v = makeRequestChangePhoneNumber;
            }
            // status
            {
                this.status = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.status, new RequestChangeStringUI.UIData());
                this.status.v.updateData.v.request.v = makeRequestChangeStatus;
            }
            // birthday
            {
                this.birthday = new VP<RequestChangeStringUI.UIData>(this, (byte)Property.birthday, new RequestChangeStringUI.UIData());
                this.birthday.v.updateData.v.request.v = makeRequestChangeBirthday;
            }
            // sex
            {
                this.sex = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.sex, new RequestChangeEnumUI.UIData());
                foreach (User.SEX sex in System.Enum.GetValues(typeof(User.SEX)))
                {
                    this.sex.v.options.add(sex.ToString());
                }
                this.sex.v.updateData.v.request.v = makeRequestChangeSex;
            }
            // ban
            this.ban = new VP<BanUI.UIData>(this, (byte)Property.ban, null);
        }

        #endregion

        public override GamePlayer.Inform.Type getType()
        {
            return GamePlayer.Inform.Type.Human;
        }

        #region implement interface

        public EditData<Human> getEditData()
        {
            return this.editHuman.v;
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Human");

    public Text lbPlayerId;
    private static readonly TxtLanguage txtPlayerId = new TxtLanguage("Id");

    public Text lbEmail;
    private static readonly TxtLanguage txtEmail = new TxtLanguage("Email");

    public Text lbPhoneNumber;
    private static readonly TxtLanguage txtPhoneNumber = new TxtLanguage("Phone number");

    public Text lbStatus;
    private static readonly TxtLanguage txtStatus = new TxtLanguage("Status");

    public Text lbBirthday;
    private static readonly TxtLanguage txtBirthday = new TxtLanguage("Birthday");

    public Text lbSex;
    private static readonly TxtLanguage txtSex = new TxtLanguage("Sex");

    public Text lbBan;
    private static readonly TxtLanguage txtBan = new TxtLanguage("Ban");

    static HumanUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Con người");
            txtPlayerId.add(Language.Type.vi, "Id");
            txtEmail.add(Language.Type.vi, "Email");
            txtPhoneNumber.add(Language.Type.vi, "Số điện thoại");
            txtStatus.add(Language.Type.vi, "Status");
            txtBirthday.add(Language.Type.vi, "Sinh nhật");
            txtSex.add(Language.Type.vi, "Giới tính");
            txtBan.add(Language.Type.vi, "Trạng thái ban");
        }
        // rect
        {

        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public Image bgAccount;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                EditData<Human> editHuman = this.data.editHuman.v;
                if (editHuman != null)
                {
                    editHuman.update();
                    // UI
                    {
                        // different
                        RequestChange.ShowDifferentTitle(lbTitle, editHuman);
                        // get server state
                        Server.State.Type serverState = RequestChange.GetServerState(editHuman);
                        // set origin
                        {
                            RequestChange.RefreshUIWithCanEdit(this.data.playerId.v, editHuman, serverState, needReset, editData => (int)editData.playerId.v, false);
                            EditDataUI.RefreshChildUI(this.data, this.data.account.v, editData => editData.account.v);
                            RequestChange.RefreshUI(this.data.email.v, editHuman, serverState, needReset, editData => editData.email.v);
                            RequestChange.RefreshUI(this.data.phoneNumber.v, editHuman, serverState, needReset, editData => editData.phoneNumber.v);
                            RequestChange.RefreshUI(this.data.status.v, editHuman, serverState, needReset, editData => editData.status.v);
                            RequestChange.RefreshUI(this.data.birthday.v, editHuman, serverState, needReset, editData => Human.GetStrBirthday(editData.birthday.v));
                            // sex
                            {
                                RequestChangeEnumUI.RefreshOptions(this.data.sex.v, User.GetStrSex());
                                RequestChange.RefreshUI(this.data.sex.v, editHuman, serverState, needReset, editData => (int)editData.sex.v);
                            }
                            // ban
                            {
                                BanUI.UIData banUIData = this.data.ban.v;
                                if (banUIData != null)
                                {
                                    Human show = editHuman.show.v.data;
                                    if (show != null)
                                    {
                                        banUIData.ban.v = new ReferenceData<Ban>(show.ban.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("show null");
                                    }
                                }
                                else
                                {
                                    // Debug.LogError("banUIData null: " + this);
                                }
                            }
                        }
                        needReset = false;
                    }
                }
                else
                {
                    Debug.LogError("editHuman null: " + this);
                }
                // UI Size
                {
                    float deltaY = 0;
                    // header
                    UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                    // playerId
                    UIUtils.SetLabelContentPosition(lbPlayerId, this.data.playerId.v, ref deltaY);
                    // account
                    {
                        float bgY = deltaY;
                        float bgHeight = 0;
                        // UI
                        {
                            float height = UIRectTransform.SetPosY(this.data.account.v, deltaY);
                            bgHeight += height;
                            deltaY += height;
                        }
                        // bg
                        if (bgAccount != null)
                        {
                            UIRectTransform.SetPosY(bgAccount.rectTransform, bgY);
                            UIRectTransform.SetHeight(bgAccount.rectTransform, bgHeight);
                        }
                        else
                        {
                            Debug.LogError("bgAccount null");
                        }
                    }
                    // email
                    UIUtils.SetLabelContentPosition(lbEmail, this.data.email.v, ref deltaY);
                    // phoneNumber
                    UIUtils.SetLabelContentPosition(lbPhoneNumber, this.data.phoneNumber.v, ref deltaY);
                    // status
                    UIUtils.SetLabelContentPosition(lbStatus, this.data.status.v, ref deltaY);
                    // birthday
                    UIUtils.SetLabelContentPosition(lbBirthday, this.data.birthday.v, ref deltaY);
                    // sex
                    UIUtils.SetLabelContentPosition(lbSex, this.data.sex.v, ref deltaY);
                    // ban
                    {
                        if (this.data.ban.v != null)
                        {
                            if (lbBan != null)
                            {
                                lbBan.gameObject.SetActive(true);
                                UIRectTransform.SetPosY(lbBan.rectTransform, deltaY + 5);
                            }
                            else
                            {
                                Debug.LogError("lbBan null");
                            }
                            UIRectTransform.SetPosY(this.data.ban.v, deltaY + 5);
                            deltaY += UIConstants.ItemHeight + 10;
                        }
                        else
                        {
                            if (lbBan != null)
                            {
                                lbBan.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("lbBan null");
                            }
                        }
                    }
                    // set
                    UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
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
                    if (lbPlayerId != null)
                    {
                        lbPlayerId.text = txtPlayerId.get();
                        Setting.get().setLabelTextSize(lbPlayerId);
                    }
                    else
                    {
                        Debug.LogError("lbPlayerId null: " + this);
                    }
                    if (lbEmail != null)
                    {
                        lbEmail.text = txtEmail.get();
                        Setting.get().setLabelTextSize(lbEmail);
                    }
                    else
                    {
                        Debug.LogError("lbEmail null: " + this);
                    }
                    if (lbPhoneNumber != null)
                    {
                        lbPhoneNumber.text = txtPhoneNumber.get();
                        Setting.get().setLabelTextSize(lbPhoneNumber);
                    }
                    else
                    {
                        Debug.LogError("lbPhoneNumber null: " + this);
                    }
                    if (lbStatus != null)
                    {
                        lbStatus.text = txtStatus.get();
                        Setting.get().setLabelTextSize(lbStatus);
                    }
                    else
                    {
                        Debug.LogError("lbStatus null: " + this);
                    }
                    if (lbBirthday != null)
                    {
                        lbBirthday.text = txtBirthday.get();
                        Setting.get().setLabelTextSize(lbBirthday);
                    }
                    else
                    {
                        Debug.LogError("lbBirthday null: " + this);
                    }
                    if (lbSex != null)
                    {
                        lbSex.text = txtSex.get();
                        Setting.get().setLabelTextSize(lbSex);
                    }
                    else
                    {
                        Debug.LogError("lbSex null: " + this);
                    }
                    if (lbBan != null)
                    {
                        lbBan.text = txtBan.get();
                        Setting.get().setLabelTextSize(lbBan);
                    }
                    else
                    {
                        Debug.LogError("lbBan null: " + this);
                    }
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

    public RequestChangeIntUI requestIntPrefab;
    public AccountUI accountPrefab;
    public RequestChangeStringUI requestStringPrefab;
    public RequestChangeEnumUI requestEnumPrefab;
    public BanUI banPrefab;

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
                uiData.editHuman.allAddCallBack(this);
                uiData.playerId.allAddCallBack(this);
                uiData.account.allAddCallBack(this);
                uiData.email.allAddCallBack(this);
                uiData.phoneNumber.allAddCallBack(this);
                uiData.status.allAddCallBack(this);
                uiData.birthday.allAddCallBack(this);
                uiData.sex.allAddCallBack(this);
                uiData.ban.allAddCallBack(this);
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
            // editHuman
            {
                if (data is EditData<Human>)
                {
                    EditData<Human> editHuman = data as EditData<Human>;
                    // Child
                    {
                        editHuman.show.allAddCallBack(this);
                        editHuman.compare.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Parent
                        {
                            DataUtils.addParentCallBack(human, this, ref this.server);
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
                }
            }
            // playerId
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.playerId:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
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
            // email, phoneNumber, status
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
                            case UIData.Property.email:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.phoneNumber:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.status:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
                                break;
                            case UIData.Property.birthday:
                                UIUtils.Instantiate(requestChange, requestStringPrefab, this.transform, UIConstants.RequestEnumRect);
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
            // sex
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
                            case UIData.Property.sex:
                                UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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
            // account
            if (data is AccountUI.UIData)
            {
                AccountUI.UIData accountUIData = data as AccountUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(accountUIData, accountPrefab, this.transform);
                }
                // Child
                {
                    TransformData.AddCallBack(accountUIData, this);
                }
                dirty = true;
                return;
            }
            // ban
            if (data is BanUI.UIData)
            {
                BanUI.UIData banUIData = data as BanUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(banUIData, banPrefab, this.transform);
                }
                // Child
                {
                    TransformData.AddCallBack(banUIData, this);
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
                uiData.editHuman.allRemoveCallBack(this);
                uiData.playerId.allRemoveCallBack(this);
                uiData.account.allRemoveCallBack(this);
                uiData.email.allRemoveCallBack(this);
                uiData.phoneNumber.allRemoveCallBack(this);
                uiData.status.allRemoveCallBack(this);
                uiData.birthday.allRemoveCallBack(this);
                uiData.sex.allRemoveCallBack(this);
                uiData.ban.allRemoveCallBack(this);
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
            // editHuman
            {
                if (data is EditData<Human>)
                {
                    EditData<Human> editHuman = data as EditData<Human>;
                    // Child
                    {
                        editHuman.show.allRemoveCallBack(this);
                        editHuman.compare.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(human, this, ref this.server);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is Server)
                        {
                            return;
                        }
                    }
                }
            }
            // playerId
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                }
                return;
            }
            // email, phoneNumber, status
            if (data is RequestChangeStringUI.UIData)
            {
                RequestChangeStringUI.UIData requestChange = data as RequestChangeStringUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeStringUI));
                }
                return;
            }
            // sex
            if (data is RequestChangeEnumUI.UIData)
            {
                RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                }
                return;
            }
            // account
            if (data is AccountUI.UIData)
            {
                AccountUI.UIData accountUIData = data as AccountUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(accountUIData, this);
                }
                // UI
                {
                    accountUIData.removeCallBackAndDestroy(typeof(AccountUI));
                }
                return;
            }
            // ban
            if (data is BanUI.UIData)
            {
                BanUI.UIData banUIData = data as BanUI.UIData;
                // Child
                {
                    TransformData.RemoveCallBack(banUIData, this);
                }
                // UI
                {
                    banUIData.removeCallBackAndDestroy(typeof(BanUI));
                }
                return;
            }
            // Child
            if (data is TransformData)
            {
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
                case UIData.Property.editHuman:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.showType:
                    dirty = true;
                    break;
                case UIData.Property.playerId:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.account:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.email:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.phoneNumber:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.status:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.birthday:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sex:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.ban:
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
            // editHuman
            {
                if (wrapProperty.p is EditData<Human>)
                {
                    switch ((EditData<Human>.Property)wrapProperty.n)
                    {
                        case EditData<Human>.Property.origin:
                            dirty = true;
                            break;
                        case EditData<Human>.Property.show:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Human>.Property.compare:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EditData<Human>.Property.compareOtherType:
                            dirty = true;
                            break;
                        case EditData<Human>.Property.canEdit:
                            dirty = true;
                            break;
                        case EditData<Human>.Property.editType:
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
                    if (wrapProperty.p is Human)
                    {
                        switch ((Human.Property)wrapProperty.n)
                        {
                            case Human.Property.playerId:
                                dirty = true;
                                break;
                            case Human.Property.account:
                                dirty = true;
                                break;
                            case Human.Property.state:
                                dirty = true;
                                break;
                            case Human.Property.email:
                                dirty = true;
                                break;
                            case Human.Property.phoneNumber:
                                dirty = true;
                                break;
                            case Human.Property.status:
                                dirty = true;
                                break;
                            case Human.Property.birthday:
                                dirty = true;
                                break;
                            case Human.Property.sex:
                                dirty = true;
                                break;
                            case Human.Property.connection:
                                break;
                            case Human.Property.ban:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                    }
                }
            }
            // playerId
            if (wrapProperty.p is RequestChangeIntUI.UIData)
            {
                return;
            }
            // email, phoneNumber, status
            if (wrapProperty.p is RequestChangeStringUI.UIData)
            {
                return;
            }
            // sex
            if (wrapProperty.p is RequestChangeEnumUI.UIData)
            {
                return;
            }
            // account
            if (wrapProperty.p is AccountUI.UIData)
            {
                return;
            }
            // ban
            if (wrapProperty.p is BanUI.UIData)
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}