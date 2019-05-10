using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EulaUI : UIBehavior<EulaUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        #region Constructor

        public enum Property
        {

        }

        public UIData() : base()
        {

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
                        EulaUI eulaUI = this.findCallBack<EulaUI>();
                        if (eulaUI != null)
                        {
                            eulaUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("eulaUI null: " + this);
                        }
                    }
                }
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        EulaUI eulaUI = this.findCallBack<EulaUI>();
                        if (eulaUI != null)
                        {
                            isProcess = eulaUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("eulaUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("End-user License Agreement");

    static EulaUI()
    {
        txtTitle.add(Language.Type.vi, "Điều Khoản Dịch Vụ");
    }

    #endregion

    #region Refresh

    public Button btnBack;

    public Text tvEula;
    private bool isAlreadyLoad = false;

    public RectTransform contentScrollView;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // tvEula
                if (tvEula != null)
                {
                    if (!isAlreadyLoad)
                    {
                        isAlreadyLoad = true;
                        TextAsset asset = Resources.Load("Eula") as TextAsset;
                        if (asset != null)
                        {
                            tvEula.text = asset.text;
                        }
                        else
                        {
                            Debug.LogError("asset null");
                        }
                    }
                    Setting.get().setTitleTextSize(tvEula);
                }
                else
                {
                    Debug.LogError("tvEula null");
                }
                // contentScrollView
                if (contentScrollView != null)
                {
                    UIRectTransform rect = UIRectTransform.CreateFullRect(0, 0, Setting.get().getButtonSize(), 0);
                    rect.set(contentScrollView);
                }
                else
                {
                    Debug.LogError("contentScrollView null");
                }
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
                }
            }
            else
            {
                // Debug.LogError("data null");
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
        if (data is UIData)
        {
            // Setting
            Setting.get().addCallBack(this);
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
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
            // Setting
            Setting.get().removeCallBack(this);
            this.setDataNull(uiData);
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
        // Setting
        if (wrapProperty.p is Setting)
        {
            switch ((Setting.Property)wrapProperty.n)
            {
                case Setting.Property.language:
                    dirty = true;
                    break;
                case Setting.Property.useShortKey:
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
            AboutUI.UIData aboutUIData = this.data.findDataInParent<AboutUI.UIData>();
            if (aboutUIData != null)
            {
                aboutUIData.eula.v = null;
            }
            else
            {
                Debug.LogError("aboutUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}