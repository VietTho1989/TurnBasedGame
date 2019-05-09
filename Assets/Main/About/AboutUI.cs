using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AboutUI : UIBehavior<AboutUI.UIData>
{

    #region UIData

    public class UIData : MainUI.UIData.Sub
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.About;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        AboutUI aboutUI = this.findCallBack<AboutUI>();
                        if (aboutUI != null)
                        {
                            aboutUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("aboutUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        AboutUI aboutUI = this.findCallBack<AboutUI>();
                        if (aboutUI != null)
                        {
                            isProcess = aboutUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("aboutUI null: " + this);
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

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("About");

    public Text lbAuthor;
    public Text tvAuthor;
    private static readonly TxtLanguage txtLbAuthor = new TxtLanguage("Author");
    private static readonly TxtLanguage txtAuthor = new TxtLanguage("Doan Viet Tho");

    public Text lbWebsite;
    public Text tvWebsite;
    public Button btnWebsite;
    private static readonly TxtLanguage txtWebsite = new TxtLanguage("Website");

    public Text lbContact;
    public Text tvContact;
    private static readonly TxtLanguage txtContact = new TxtLanguage("Contact");

    public Text lbMessage;
    public Text tvMessage;
    private static readonly TxtLanguage txtMessage = new TxtLanguage("Message");

    static AboutUI()
    {
        txtTitle.add(Language.Type.vi, "Thông Tin");
        txtLbAuthor.add(Language.Type.vi, "Tác giả");
        txtAuthor.add(Language.Type.vi, "Đoàn Việt Thọ");
        txtWebsite.add(Language.Type.vi, "Trang web");
        txtContact.add(Language.Type.vi, "Liên hệ");
        txtMessage.add(Language.Type.vi, "Thông báo");
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // UI
                {
                    float deltaY = 0;
                    float itemSize = Setting.get().getItemSize();
                    float buttonSize = Setting.get().getButtonSize();
                    // header
                    {
                        UIRectTransform.SetTitleTransform(lbTitle);
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        deltaY += buttonSize;
                    }
                    // author
                    {
                        if (lbAuthor != null)
                        {
                            UIRectTransform.SetPosY(lbAuthor.rectTransform, deltaY);
                            UIRectTransform.SetHeight(lbAuthor.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("lbAuthor null");
                        }
                        if (tvAuthor != null)
                        {
                            UIRectTransform.SetPosY(tvAuthor.rectTransform, deltaY);
                            UIRectTransform.SetHeight(tvAuthor.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("tvAuthor null");
                        }
                        deltaY += itemSize;
                    }
                    // website
                    {
                        if (lbWebsite != null)
                        {
                            UIRectTransform.SetPosY(lbWebsite.rectTransform, deltaY);
                            UIRectTransform.SetHeight(lbWebsite.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("lbWebsite null");
                        }
                        if (tvWebsite != null)
                        {
                            UIRectTransform.SetPosY(tvWebsite.rectTransform, deltaY);
                            UIRectTransform.SetHeight(tvWebsite.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("tvWebsite null");
                        }
                        if (btnWebsite != null)
                        {
                            UIRectTransform.SetPosY((RectTransform)btnWebsite.transform, deltaY + (itemSize - 30) / 2.0f);
                        }
                        else
                        {
                            Debug.LogError("btnWebsite null");
                        }
                        deltaY += itemSize;
                    }
                    // contact
                    {
                        if (lbContact != null)
                        {
                            UIRectTransform.SetPosY(lbContact.rectTransform, deltaY);
                            UIRectTransform.SetHeight(lbContact.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("lbContact null");
                        }
                        if (tvContact != null)
                        {
                            UIRectTransform.SetPosY(tvContact.rectTransform, deltaY);
                            UIRectTransform.SetHeight(tvContact.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("tvContact null");
                        }
                        deltaY += itemSize;
                    }
                    // message
                    {
                        if (lbMessage != null)
                        {
                            UIRectTransform.SetPosY(lbMessage.rectTransform, deltaY);
                            UIRectTransform.SetHeight(lbMessage.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("lbMessage null");
                        }
                        if (tvMessage != null)
                        {
                            UIRectTransform.SetPosY(tvMessage.rectTransform, deltaY);
                            UIRectTransform.SetHeight(tvMessage.rectTransform, itemSize);
                        }
                        else
                        {
                            Debug.LogError("tvMessage null");
                        }
                        deltaY += itemSize;
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
                        Debug.LogError("lbTitle null");
                    }
                    if (lbAuthor != null)
                    {
                        lbAuthor.text = txtLbAuthor.get();
                        Setting.get().setLabelTextSize(lbAuthor);
                    }
                    else
                    {
                        Debug.LogError("lbAuthor null");
                    }
                    if (tvAuthor != null)
                    {
                        tvAuthor.text = txtAuthor.get();
                        Setting.get().setContentTextSize(tvAuthor);
                    }
                    else
                    {
                        Debug.LogError("tvAuthor null");
                    }
                    if (lbWebsite != null)
                    {
                        lbWebsite.text = txtWebsite.get();
                        Setting.get().setLabelTextSize(lbWebsite);
                    }
                    else
                    {
                        Debug.LogError("lbWebsite null");
                    }
                    if (tvWebsite != null)
                    {
                        tvWebsite.text = Global.get().website.v;
                        Setting.get().setContentTextSize(tvWebsite);
                    }
                    else
                    {
                        Debug.LogError("tvWebsite null");
                    }
                    if (lbContact != null)
                    {
                        lbContact.text = txtContact.get();
                        Setting.get().setLabelTextSize(lbContact);
                    }
                    else
                    {
                        Debug.LogError("lbContact null");
                    }
                    if (tvContact != null)
                    {
                        Setting.get().setContentTextSize(tvContact);
                    }
                    else
                    {
                        Debug.LogError("tvContact null");
                    }
                    if (lbMessage != null)
                    {
                        lbMessage.text = txtMessage.get();
                        Setting.get().setLabelTextSize(lbMessage);
                    }
                    else
                    {
                        Debug.LogError("lbMessage null");
                    }
                    if (tvMessage != null)
                    {
                        tvMessage.text = Global.get().serverMessage.v;
                        Setting.get().setContentTextSize(tvMessage);
                    }
                    else
                    {
                        Debug.LogError("tvMessage null");
                    }
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

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            // UIData uiData = data as UIData;
            // Global
            Global.get().addCallBack(this);
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Global
        if (data is Global)
        {
            dirty = true;
            return;
        }
        // Setting
        if (data is Setting)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Global
            Global.get().removeCallBack(this);
            // Setting
            Setting.get().removeCallBack(this);
            this.setDataNull(uiData);
            return;
        }
        // Global
        if(data is Global)
        {
            return;
        }
        // Setting
        if (data is Setting)
        {
            return;
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
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Global
        if(wrapProperty.p is Global)
        {
            switch ((Global.Property)wrapProperty.n)
            {
                case Global.Property.networkReachability:
                    break;
                case Global.Property.deviceOrientation:
                    break;
                case Global.Property.screenOrientation:
                    break;
                case Global.Property.width:
                    break;
                case Global.Property.height:
                    break;
                case Global.Property.screenWidth:
                    break;
                case Global.Property.screenHeight:
                    break;
                case Global.Property.serverMessage:
                    dirty = true;
                    break;
                case Global.Property.website:
                    dirty = true;
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
                case Setting.Property.itemSize:
                    dirty = true;
                    break;
                case Setting.Property.confirmQuit:
                    break;
                case Setting.Property.boardIndex:
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
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // onClick
        {
            UIUtils.SetButtonOnClick(btnWebsite, onClickBtnWebsite);
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
                    case KeyCode.W:
                        {
                            if (btnWebsite != null && btnWebsite.gameObject.activeInHierarchy && btnWebsite.interactable)
                            {
                                onClickBtnWebsite();
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
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                HomeUI.UIData homeUIData = mainUIData.sub.newOrOld<HomeUI.UIData>();
                {

                }
                mainUIData.sub.v = homeUIData;
            }
            else
            {
                Debug.LogError("mainUI null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnWebsite()
    {
        Application.OpenURL(Global.get().website.v);
    }

}