using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match;

public class RoomUserInformUI : UIBehavior<RoomUserInformUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RoomUser>> roomUser;

        public VP<HumanUI.UIData> humanUI;

        public VP<UserMakeFriendUI.UIData> userMakeFriend;

        public VP<RoomUserKickUI.UIData> kickUI;

        #region type

        public enum Type
        {
            Lobby,
            Play
        }

        public VP<Type> type;

        #endregion

        #region Constructor

        public enum Property
        {
            roomUser,
            humanUI,
            userMakeFriend,
            kickUI,
            type
        }

        public UIData() : base()
        {
            this.roomUser = new VP<ReferenceData<RoomUser>>(this, (byte)Property.roomUser, new ReferenceData<RoomUser>(null));
            // humanUI
            {
                this.humanUI = new VP<HumanUI.UIData>(this, (byte)Property.humanUI, new HumanUI.UIData());
                this.humanUI.v.editHuman.v.canEdit.v = false;
                this.humanUI.v.showType.v = UIRectTransform.ShowType.HeadLess;
            }
            this.userMakeFriend = new VP<UserMakeFriendUI.UIData>(this, (byte)Property.userMakeFriend, new UserMakeFriendUI.UIData());
            this.kickUI = new VP<RoomUserKickUI.UIData>(this, (byte)Property.kickUI, new RoomUserKickUI.UIData());
            this.type = new VP<Type>(this, (byte)Property.type, Type.Lobby);
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        RoomUserInformUI roomUserInformUI = this.findCallBack<RoomUserInformUI>();
                        if (roomUserInformUI != null)
                        {
                            roomUserInformUI.onClickBtnBack();
                        }
                        else
                        {
                            Debug.LogError("roomUserInformUI null: " + this);
                        }
                        isProcess = true;
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Room User Information");

    public Text tvCannotBeKicked;
    private static readonly TxtLanguage txtCannotBeKicked = new TxtLanguage("Cannot be kicked");

    static RoomUserInformUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Thông tin người trong phòng");
            txtCannotBeKicked.add(Language.Type.vi, "Không thể bị kick");
        }
        // rect
        {
            // userMakeFriendRect
            {
                // anchoredPosition: (0.0, -230.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -280.0); offsetMax: (0.0, -230.0); sizeDelta: (0.0, 50.0);
                userMakeFriendRect.anchoredPosition = new Vector3(0.0f, -230.0f, 0.0f);
                userMakeFriendRect.anchorMin = new Vector2(0.0f, 1.0f);
                userMakeFriendRect.anchorMax = new Vector2(1.0f, 1.0f);
                userMakeFriendRect.pivot = new Vector2(0.5f, 1.0f);
                userMakeFriendRect.offsetMin = new Vector2(0.0f, -280.0f);
                userMakeFriendRect.offsetMax = new Vector2(0.0f, -230.0f);
                userMakeFriendRect.sizeDelta = new Vector2(0.0f, 50.0f);
            }
            // kickRect
            {
                // anchoredPosition: (0.0, -290.0); anchorMin: (0.5, 1.0); anchorMax: (0.5, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (-60.0, -320.0); offsetMax: (60.0, -290.0); sizeDelta: (120.0, 30.0);
                kickRect.anchoredPosition = new Vector3(0.0f, -290.0f, 0.0f);
                kickRect.anchorMin = new Vector2(0.5f, 1.0f);
                kickRect.anchorMax = new Vector2(0.5f, 1.0f);
                kickRect.pivot = new Vector2(0.5f, 1.0f);
                kickRect.offsetMin = new Vector2(-60.0f, -320.0f);
                kickRect.offsetMax = new Vector2(60.0f, -290.0f);
                kickRect.sizeDelta = new Vector2(120.0f, 30.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public Button btnBack;
    public RectTransform humanUIScrollView;
    public RectTransform bgCannotBeKicked;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RoomUser roomUser = this.data.roomUser.v.data;
                if (roomUser != null)
                {
                    // humanUI
                    {
                        HumanUI.UIData humanUIData = this.data.humanUI.v;
                        if (humanUIData != null)
                        {
                            humanUIData.editHuman.v.origin.v = new ReferenceData<Human>(roomUser.inform.v);
                        }
                        else
                        {
                            Debug.LogError("humanUIData null: " + this);
                        }
                    }
                    // userMakeFriend
                    {
                        UserMakeFriendUI.UIData userMakeFriend = this.data.userMakeFriend.v;
                        if (userMakeFriend != null)
                        {
                            userMakeFriend.human.v = new ReferenceData<Human>(roomUser.inform.v);
                        }
                        else
                        {
                            Debug.LogError("userMakeFriend null: " + this);
                        }
                    }
                    // btnKick
                    {
                        RoomUserKickUI.UIData kickUIData = this.data.kickUI.v;
                        if (kickUIData != null)
                        {
                            kickUIData.roomUser.v = new ReferenceData<RoomUser>(roomUser);
                        }
                        else
                        {
                            Debug.LogError("kickUIData null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("roomUser null: " + this);
                }
                // UI
                {
                    float buttonSize = Setting.get().getButtonSize();
                    float deltaY = 0;
                    // header
                    {
                        UIRectTransform.SetTitleTransform(lbTitle);
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        deltaY += buttonSize;
                    }
                    // humanScrollView
                    {
                        if (humanUIScrollView != null)
                        {
                            UIRectTransform.SetPosY(humanUIScrollView, deltaY);
                        }
                        else
                        {
                            Debug.LogError("humanUIScrollView null");
                        }
                        deltaY += 200;
                    }
                    // bottom
                    {
                        UIRectTransform.SetPosY(this.data.userMakeFriend.v, deltaY);
                        if (bgCannotBeKicked != null)
                        {
                            UIRectTransform.SetPosY(bgCannotBeKicked, deltaY + 60);
                        }
                        else
                        {
                            Debug.LogError("bgCannotBeKicked null");
                        }
                        if (tvCannotBeKicked != null)
                        {
                            UIRectTransform.SetPosY(tvCannotBeKicked.rectTransform, deltaY + 60);
                        }
                        else
                        {
                            Debug.LogError("tvCannotBeKicked null");
                        }
                        UIRectTransform.SetPosY(this.data.kickUI.v, deltaY + 60);
                        deltaY += 100;
                    }
                    // setHeight
                    {
                        if (contentContainer != null)
                        {
                            UIRectTransform.SetHeight(contentContainer, deltaY);
                        }
                        else
                        {
                            Debug.LogError("contentContainer null");
                        }
                    }
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        string userName = "";
                        {
                            if (roomUser != null)
                            {
                                Human human = roomUser.inform.v;
                                if (human != null)
                                {
                                    userName = human.getPlayerName();
                                }
                                else
                                {
                                    Debug.LogError("human null");
                                }
                            }
                            else
                            {
                                Debug.LogError("roomUser null");
                            }
                        }
                        lbTitle.text = userName;// txtTitle.get ("Room User Information");
                        Setting.get().setTitleTextSize(lbTitle);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
                    if (tvCannotBeKicked != null)
                    {
                        tvCannotBeKicked.text = txtCannotBeKicked.get();
                    }
                    else
                    {
                        Debug.LogError("tvCannotBeKicked null: " + this);
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

    public HumanUI humanPrefab;
    public Transform humanContainer;

    public RectTransform contentContainer;

    public UserMakeFriendUI userMakeFriendPrefab;
    private static readonly UIRectTransform userMakeFriendRect = new UIRectTransform();

    public RoomUserKickUI kickPrefab;
    private static readonly UIRectTransform kickRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.roomUser.allAddCallBack(this);
                uiData.humanUI.allAddCallBack(this);
                uiData.userMakeFriend.allAddCallBack(this);
                uiData.kickUI.allAddCallBack(this);
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
            if (data is RoomUser)
            {
                dirty = true;
                return;
            }
            if (data is HumanUI.UIData)
            {
                HumanUI.UIData humanUIData = data as HumanUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(humanUIData, humanPrefab, humanContainer);
                }
                dirty = true;
                return;
            }
            if (data is UserMakeFriendUI.UIData)
            {
                UserMakeFriendUI.UIData userMakeFriendUIData = data as UserMakeFriendUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(userMakeFriendUIData, userMakeFriendPrefab, contentContainer, userMakeFriendRect);
                }
                dirty = true;
                return;
            }
            if (data is RoomUserKickUI.UIData)
            {
                RoomUserKickUI.UIData kickUIData = data as RoomUserKickUI.UIData;
                // UI
                {
                    UIUtils.Instantiate(kickUIData, kickPrefab, contentContainer, kickRect);
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
                uiData.roomUser.allRemoveCallBack(this);
                uiData.humanUI.allRemoveCallBack(this);
                uiData.userMakeFriend.allRemoveCallBack(this);
                uiData.kickUI.allRemoveCallBack(this);
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
            if (data is RoomUser)
            {
                return;
            }
            if (data is HumanUI.UIData)
            {
                HumanUI.UIData humanUIData = data as HumanUI.UIData;
                // UI
                {
                    humanUIData.removeCallBackAndDestroy(typeof(HumanUI));
                }
                return;
            }
            if (data is UserMakeFriendUI.UIData)
            {
                UserMakeFriendUI.UIData userMakeFriendUIData = data as UserMakeFriendUI.UIData;
                // UI
                {
                    userMakeFriendUIData.removeCallBackAndDestroy(typeof(UserMakeFriendUI));
                }
                return;
            }
            if (data is RoomUserKickUI.UIData)
            {
                RoomUserKickUI.UIData kickUIData = data as RoomUserKickUI.UIData;
                // UI
                {
                    kickUIData.removeCallBackAndDestroy(typeof(RoomUserKickUI));
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
                case UIData.Property.roomUser:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.humanUI:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.userMakeFriend:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.kickUI:
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
            if (wrapProperty.p is RoomUser)
            {
                switch ((RoomUser.Property)wrapProperty.n)
                {
                    case RoomUser.Property.role:
                        break;
                    case RoomUser.Property.inform:
                        dirty = true;
                        break;
                    case RoomUser.Property.state:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            if (wrapProperty.p is HumanUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is UserMakeFriendUI.UIData)
            {
                return;
            }
            if (wrapProperty.p is RoomUserKickUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            switch (this.data.type.v)
            {
                case UIData.Type.Lobby:
                    {
                        RoomUI.UIData roomUIData = this.data.findDataInParent<RoomUI.UIData>();
                        if (roomUIData != null)
                        {
                            roomUIData.roomUserInformUI.v = null;
                        }
                        else
                        {
                            Debug.LogError("roomUIData null: " + this);
                        }
                    }
                    break;
                case UIData.Type.Play:
                    {
                        RoomUserListUI.UIData roomUserListUIData = this.data.findDataInParent<RoomUserListUI.UIData>();
                        if (roomUserListUIData != null)
                        {
                            roomUserListUIData.userInformUIData.v = null;
                        }
                        else
                        {
                            Debug.LogError("roomUserListUIData null");
                        }
                    }
                    break;
                default:
                    Debug.LogError("unknown type: " + this.data.type.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null: " + this);
        }
    }

}