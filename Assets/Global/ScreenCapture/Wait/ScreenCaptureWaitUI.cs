using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class ScreenCaptureWaitUI : UIBehavior<ScreenCaptureWaitUI.UIData>
{

    #region UIData

    public class UIData : ScreenCaptureUI.UIData.Sub
    {

        public const int DefaultDuration = 3;

        public VP<int> time;

        public VP<Texture2D> texture;

        #region Constructor

        public enum Property
        {
            time,
            texture
        }

        public UIData() : base()
        {
            this.time = new VP<int>(this, (byte)Property.time, DefaultDuration);
            this.texture = new VP<Texture2D>(this, (byte)Property.texture, null);
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.Wait;
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
                        ScreenCaptureWaitUI screenCaptureWaitUI = this.findCallBack<ScreenCaptureWaitUI>();
                        if (screenCaptureWaitUI != null)
                        {
                            screenCaptureWaitUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("screenCaptureWaitUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

        #endregion

    }

    #endregion

    #region txt, rect

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Screen Capture Wait");

    public Text tvWaitTime;
    private static readonly TxtLanguage txtWaitTime = new TxtLanguage("Wait");

    static ScreenCaptureWaitUI() 
    {
        txtTitle.add(Language.Type.vi, "Đợi Chụp Màn Hình");
        txtWaitTime.add(Language.Type.vi, "Đợi");
    }

    #endregion

    #region Refresh

    public RectTransform contentContainer;

    public Button btnBack;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // contentContainer
                {
                    if (contentContainer != null)
                    {
                        contentContainer.gameObject.SetActive(this.data.time.v > 0);
                    }
                    else
                    {
                        Debug.LogError("contentContainer null");
                    }
                }
                // UI
                {
                    float deltaY = 0;
                    float buttonSize = Setting.get().getButtonSize();
                    float itemSize = Setting.get().getItemSize();
                    // header
                    {
                        if (lbTitle != null)
                        {
                            UIRectTransform.SetTitleTransform(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                        UIRectTransform.SetButtonTopLeftTransform(btnBack);
                        deltaY += buttonSize;
                    }
                    // content
                    {
                        if (tvWaitTime != null)
                        {
                            UIRectTransform.SetHeight(tvWaitTime.rectTransform, itemSize);
                            UIRectTransform.SetPosY(tvWaitTime.rectTransform, deltaY);
                        }
                        else
                        {
                            Debug.LogError("tvWaitTime null");
                        }
                        deltaY += itemSize;
                    }
                    // set height
                    {
                        UIRectTransform rect = UIRectTransform.CreateCenterRect(300, deltaY);
                        rect.set(contentContainer);
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
                    if (tvWaitTime != null)
                    {
                        tvWaitTime.text = " " + this.data.time.v;// txtWaitTime.get() + " " + this.data.time.v;
                        Setting.get().setTitleTextSize(tvWaitTime);
                    }
                    else
                    {
                        Debug.LogError("tvWaitTime null");
                    }
                }
                // change
                {
                    if (this.data.time.v == -2)
                    {
                        this.data.time.v = -3;
                        ScreenCaptureUI.UIData screenCaptureUIData = this.data.findDataInParent<ScreenCaptureUI.UIData>();
                        if (screenCaptureUIData != null)
                        {
                            ScreenCaptureSaveUI.UIData screenCaptureSaveUIData = screenCaptureUIData.sub.newOrOld<ScreenCaptureSaveUI.UIData>();
                            {
                                screenCaptureSaveUIData.texture.v = this.data.texture.v;
                            }
                            screenCaptureUIData.sub.v = screenCaptureSaveUIData;
                        }
                        else
                        {
                            Debug.LogError("screenCaptureUIData null");
                        }
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
        return false;
    }

    public override void OnGUI()
    {
        base.OnGUI();
        if (this.data != null)
        {
            if (this.data.time.v == -1)
            {
                this.data.time.v = -2;
                this.data.texture.v = ScreenCapture.CaptureScreenshotAsTexture();
                Debug.LogError("captureScreenShot");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #endregion

    #region Task

    private Routine waitTimeRoutine;

    public override void Awake()
    {
        base.Awake();
        // onClick
        {

        }
        startRoutine(ref this.waitTimeRoutine, updateWaitTime());
    }

    public override List<Routine> getRoutineList()
    {
        List<Routine> ret = new List<Routine>();
        {
            ret.Add(waitTimeRoutine);
        }
        return ret;
    }

    public IEnumerator updateWaitTime()
    {
        while (true)
        {
            yield return new Wait(1f);
            if (this.data != null)
            {
                if (this.data.time.v >= 0)
                {
                    this.data.time.v--;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
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
                case UIData.Property.time:
                    dirty = true;
                    break;
                case UIData.Property.texture:
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            MainUI.UIData mainUIData = this.data.findDataInParent<MainUI.UIData>();
            if (mainUIData != null)
            {
                mainUIData.screenCaptureUIData.v = null;
            }
            else
            {
                Debug.LogError("mainUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}