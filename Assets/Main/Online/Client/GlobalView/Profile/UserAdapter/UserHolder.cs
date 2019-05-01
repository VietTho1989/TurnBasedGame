using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using UnityImageLoader;

public class UserHolder : SriaHolderBehavior<UserHolder.UIData>
{

    #region UIData

    public class UIData : BaseItemViewsHolder
    {

        public VP<ReferenceData<User>> user;

        public VP<AccountAvatarUI.UIData> avatar;

        public VP<BanUI.UIData> ban;

        #region Constructor

        public enum Property
        {
            user,
            avatar,
            ban
        }

        public UIData() : base()
        {
            this.user = new VP<ReferenceData<User>>(this, (byte)Property.user, new ReferenceData<User>(null));
            this.avatar = new VP<AccountAvatarUI.UIData>(this, (byte)Property.avatar, new AccountAvatarUI.UIData());
            this.ban = new VP<BanUI.UIData>(this, (byte)Property.ban, new BanUI.UIData());
        }

        #endregion

        public void updateView(UserAdapter.UIData myParams)
        {
            // Find
            User user = null;
            {
                if (ItemIndex >= 0 && ItemIndex < myParams.users.Count)
                {
                    user = myParams.users[ItemIndex];
                }
                else
                {
                    Debug.LogError("ItemIdex error: " + this);
                }
            }
            // Update
            this.user.v = new ReferenceData<User>(user);
        }

    }

    #endregion

    #region txt

    public Text tvView;
    private static readonly TxtLanguage txtView = new TxtLanguage("View");

    private static readonly TxtLanguage txtName = new TxtLanguage("Name");
    private static readonly TxtLanguage txtIpAddress = new TxtLanguage("IP address");

    static UserHolder()
    {
        // txt
        {
            txtView.add(Language.Type.vi, "Xem");
            txtName.add(Language.Type.vi, "Tên");
            txtIpAddress.add(Language.Type.vi, "Địa chỉ IP");
        }
        // rect
        {
            // banRect
            {
                // anchoredPosition: (0.0, 0.0); anchorMin: (1.0, 0.5); anchorMax: (1.0, 0.5); pivot: (1.0, 0.5);
                // offsetMin: (-120.0, -30.0); offsetMax: (0.0, 30.0); sizeDelta: (120.0, 60.0);
                banRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                banRect.anchorMin = new Vector2(1.0f, 0.5f);
                banRect.anchorMax = new Vector2(1.0f, 0.5f);
                banRect.pivot = new Vector2(1.0f, 0.5f);
                banRect.offsetMin = new Vector2(-120.0f, -30.0f);
                banRect.offsetMax = new Vector2(0.0f, 30.0f);
                banRect.sizeDelta = new Vector2(120.0f, 60.0f);
            }
            // avatarRect
            {
                // anchoredPosition: (40.0, -20.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (10.0, -80.0); offsetMax: (70.0, -20.0); sizeDelta: (60.0, 60.0);
                avatarRect.anchoredPosition = new Vector3(40.0f, -20.0f, 0.0f);
                avatarRect.anchorMin = new Vector2(0.0f, 1.0f);
                avatarRect.anchorMax = new Vector2(0.0f, 1.0f);
                avatarRect.pivot = new Vector2(0.5f, 1.0f);
                avatarRect.offsetMin = new Vector2(10.0f, -80.0f);
                avatarRect.offsetMax = new Vector2(70.0f, -20.0f);
                avatarRect.sizeDelta = new Vector2(60.0f, 60.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public Text tvId;
    public Text tvName;
    public Text tvIpAddress;

    public override void refresh()
    {
        base.refresh();
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                User user = this.data.user.v.data;
                if (user != null)
                {
                    // avatar
                    {
                        AccountAvatarUI.UIData accountAvatarUIData = this.data.avatar.v;
                        if (accountAvatarUIData != null)
                        {
                            // Find account
                            Account account = null;
                            {
                                Human human = user.human.v;
                                if (human != null)
                                {
                                    account = human.account.v;
                                }
                                else
                                {
                                    Debug.LogError("human null: " + this);
                                }
                            }
                            // Set
                            accountAvatarUIData.account.v = new ReferenceData<Account>(account);
                        }
                        else
                        {
                            Debug.LogError("accountAvatarUIData null: " + this);
                        }
                    }
                    // id
                    {
                        if (tvId != null)
                        {
                            tvId.text = "Id: " + user.human.v.playerId.v;
                        }
                        else
                        {
                            Debug.LogError("tvId null");
                        }
                    }
                    // name
                    {
                        if (tvName != null)
                        {
                            tvName.text = txtName.get() + ": " + user.human.v.getPlayerName();
                        }
                        else
                        {
                            Debug.LogError("tvName null");
                        }
                    }
                    // ipAddress
                    {
                        if (tvIpAddress != null)
                        {
                            tvIpAddress.text = txtIpAddress.get() + ": " + user.ipAddress.v;
                        }
                        else
                        {
                            Debug.LogError("tvIpAddress null");
                        }
                    }
                    // ban
                    {
                        BanUI.UIData banUIData = this.data.ban.v;
                        if (banUIData != null)
                        {
                            // Find Ban
                            Ban ban = null;
                            {
                                Human human = user.human.v;
                                if (human != null)
                                {
                                    ban = human.ban.v;
                                }
                                else
                                {
                                    Debug.LogError("human null: " + this);
                                }
                            }
                            // set
                            banUIData.ban.v = new ReferenceData<Ban>(ban);
                        }
                        else
                        {
                            Debug.LogError("banUIData null: " + this);
                        }
                    }
                    // txt
                    {
                        if (tvView != null)
                        {
                            tvView.text = txtView.get();
                        }
                        else
                        {
                            Debug.LogError("tvView null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.Log("user null: " + this);
                }
            }
            else
            {
                Debug.Log("data null: " + this);
            }
        }
    }

    #endregion

    #region implement Change

    public AccountAvatarUI avatarPrefab;
    private static readonly UIRectTransform avatarRect = new UIRectTransform();

    public BanUI banPrefab;
    private static readonly UIRectTransform banRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.user.allAddCallBack(this);
                uiData.avatar.allAddCallBack(this);
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
            // User
            {
                if (data is User)
                {
                    User user = data as User;
                    // Child
                    {
                        user.human.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Child
                        {
                            human.account.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Account)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Avatar
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(accountAvatarUIData, avatarPrefab, this.transform, avatarRect);
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
                    UIUtils.Instantiate(banUIData, banPrefab, this.transform, banRect);
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
                uiData.user.allRemoveCallBack(this);
                uiData.avatar.allRemoveCallBack(this);
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
            // User
            {
                if (data is User)
                {
                    User user = data as User;
                    // child
                    {
                        user.human.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Human)
                    {
                        Human human = data as Human;
                        // Child
                        {
                            human.account.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is Account)
                        {
                            return;
                        }
                    }
                }
            }
            // Avatar
            if (data is AccountAvatarUI.UIData)
            {
                AccountAvatarUI.UIData accountAvatarUIData = data as AccountAvatarUI.UIData;
                // UI
                {
                    accountAvatarUIData.removeCallBackAndDestroy(typeof(AccountAvatarUI));
                }
                return;
            }
            // ban
            if (data is BanUI.UIData)
            {
                BanUI.UIData banUIData = data as BanUI.UIData;
                // UI
                {
                    banUIData.removeCallBackAndDestroy(typeof(BanUI));
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
                case UIData.Property.user:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.avatar:
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
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
        // Child
        {
            // User
            {
                if (wrapProperty.p is User)
                {
                    switch ((User.Property)wrapProperty.n)
                    {
                        case User.Property.human:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case User.Property.role:
                            break;
                        case User.Property.ipAddress:
                            dirty = true;
                            break;
                        case User.Property.registerTime:
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
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
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Human.Property.state:
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
                    // Child
                    {
                        if (wrapProperty.p is Account)
                        {
                            Account.OnUpdateSyncAccount(wrapProperty, this);
                            return;
                        }
                    }
                }
            }
            // Avatar
            if (wrapProperty.p is AccountAvatarUI.UIData)
            {
                return;
            }
            // ban
            if (wrapProperty.p is BanUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnView()
    {
        if (this.data != null)
        {
            User user = this.data.user.v.data;
            if (user != null)
            {
                GlobalProfileUI.UIData globalProfileUIData = this.data.findDataInParent<GlobalProfileUI.UIData>();
                if (globalProfileUIData != null)
                {
                    UserUI.UIData userUIData = globalProfileUIData.userUI.newOrOld<UserUI.UIData>();
                    {
                        userUIData.editUser.v.origin.v = new ReferenceData<User>(user);
                        userUIData.editUser.v.compare.v = new ReferenceData<User>(user);
                    }
                    globalProfileUIData.userUI.v = userUIData;
                }
                else
                {
                    Debug.LogError("globalProfileUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("user null: " + this);
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}