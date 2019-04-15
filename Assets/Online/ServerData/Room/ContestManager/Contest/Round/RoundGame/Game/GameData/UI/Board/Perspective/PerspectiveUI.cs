using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PerspectiveUI : UIBehavior<PerspectiveUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Perspective>> perspective;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract Perspective.Sub.Type getType();

            public abstract bool processEvent(Event e);

        }

        public VP<Sub> sub;

        #endregion

        #region showAnimation

        public VP<ShowAnimationUI.UIData> showAnimation;

        public void OnHide()
        {
            PerspectiveUI perspectiveUI = this.findCallBack<PerspectiveUI>();
            if (perspectiveUI != null)
            {
                perspectiveUI.back();
            }
            else
            {
                Debug.LogError("perspectiveUI null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            perspective,
            sub,
            showAnimation
        }

        public UIData() : base()
        {
            this.perspective = new VP<ReferenceData<Perspective>>(this, (byte)Property.perspective, new ReferenceData<Perspective>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            // showAnimation
            {
                this.showAnimation = new VP<ShowAnimationUI.UIData>(this, (byte)Property.showAnimation, new ShowAnimationUI.UIData());
                this.showAnimation.v.onHide.v = OnHide;
            }
        }

        #endregion

        public bool processEvent(Event e)
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
                        Debug.LogError("sub null");
                    }
                }
                // back
                if (!isProcess)
                {
                    if (InputEvent.isBackEvent(e))
                    {
                        PerspectiveUI perspectiveUI = this.findCallBack<PerspectiveUI>();
                        if (perspectiveUI != null)
                        {
                            perspectiveUI.onClickBtnBack();
                            isProcess = true;
                        }
                        else
                        {
                            Debug.LogError("perspectiveUI null");
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage("Player Perspective");

    static PerspectiveUI()
    {
        txtTitle.add(Language.Type.vi, "Góc Nhìn Người Chơi");
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
                Perspective perspective = this.data.perspective.v.data;
                if (perspective != null)
                {
                    // tvPlayerIndex
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get() + " " + perspective.playerView.v;
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("tvPlayerIndex null: " + this);
                        }
                    }
                    // Sub
                    if (perspective.sub.v != null)
                    {
                        switch (perspective.sub.v.getType())
                        {
                            case Perspective.Sub.Type.Auto:
                                {
                                    PerspectiveAuto auto = perspective.sub.v as PerspectiveAuto;
                                    // UIData
                                    PerspectiveAutoUI.UIData subUIData = this.data.sub.newOrOld<PerspectiveAutoUI.UIData>();
                                    {
                                        subUIData.auto.v = new ReferenceData<PerspectiveAuto>(auto);
                                    }
                                    this.data.sub.v = subUIData;
                                }
                                break;
                            case Perspective.Sub.Type.Force:
                                {
                                    PerspectiveForce force = perspective.sub.v as PerspectiveForce;
                                    // UIData
                                    PerspectiveForceUI.UIData subUIData = this.data.sub.newOrOld<PerspectiveForceUI.UIData>();
                                    {
                                        subUIData.force.v = new ReferenceData<PerspectiveForce>(force);
                                    }
                                    this.data.sub.v = subUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown sub: " + perspective.sub.v.getType() + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("sub null: " + this);
                        this.data.sub.v = null;
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
                        // sub
                        deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        // set height
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                }
                else
                {
                    Debug.LogError("perpective null: " + this);
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

    public ShowAnimationUI showAnimationUI;

    public PerspectiveAutoUI autoPrefab;
    public PerspectiveForceUI forcePrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.perspective.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
                uiData.showAnimation.allAddCallBack(this);
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
        // Chid
        {
            // perspective
            {
                if (data is Perspective)
                {
                    Perspective perspective = data as Perspective;
                    // Child
                    {
                        perspective.sub.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Perspective.Sub)
                {
                    dirty = true;
                    return;
                }
            }
            // sub
            {
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case Perspective.Sub.Type.Auto:
                                {
                                    PerspectiveAutoUI.UIData autoUIData = sub as PerspectiveAutoUI.UIData;
                                    UIUtils.Instantiate(autoUIData, autoPrefab, this.transform);
                                }
                                break;
                            case Perspective.Sub.Type.Force:
                                {
                                    PerspectiveForceUI.UIData forceUIData = sub as PerspectiveForceUI.UIData;
                                    UIUtils.Instantiate(forceUIData, forcePrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown sub: " + sub + "; " + this);
                                break;
                        }
                    }
                    // Child
                    {
                        TransformData.AddCallBack(sub, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setData(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
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
            // Child
            {
                uiData.perspective.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
                uiData.showAnimation.allRemoveCallBack(this);
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
            // Perspective
            {
                if (data is Perspective)
                {
                    Perspective perspective = data as Perspective;
                    // Child
                    {
                        perspective.sub.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Perspective.Sub)
                {
                    return;
                }
            }
            // sub
            {
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // Child
                    {
                        TransformData.RemoveCallBack(sub, this);
                    }
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case Perspective.Sub.Type.Auto:
                                {
                                    PerspectiveAutoUI.UIData autoUIData = sub as PerspectiveAutoUI.UIData;
                                    autoUIData.removeCallBackAndDestroy(typeof(PerspectiveAutoUI));
                                }
                                break;
                            case Perspective.Sub.Type.Force:
                                {
                                    PerspectiveForceUI.UIData forceUIData = sub as PerspectiveForceUI.UIData;
                                    forceUIData.removeCallBackAndDestroy(typeof(PerspectiveForceUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown sub: " + sub + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // Child
                if(data is TransformData)
                {
                    return;
                }
            }
            if (data is ShowAnimationUI.UIData)
            {
                ShowAnimationUI.UIData showAnimationUIData = data as ShowAnimationUI.UIData;
                // UI
                {
                    if (showAnimationUI != null)
                    {
                        showAnimationUI.setDataNull(showAnimationUIData);
                    }
                    else
                    {
                        Debug.LogError("showAnimationUI null");
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
                case UIData.Property.perspective:
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
                case UIData.Property.showAnimation:
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
            // Perspective
            {
                if (wrapProperty.p is Perspective)
                {
                    switch ((Perspective.Property)wrapProperty.n)
                    {
                        case Perspective.Property.playerView:
                            dirty = true;
                            break;
                        case Perspective.Property.sub:
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
                if (wrapProperty.p is Perspective.Sub)
                {
                    return;
                }
            }
            // sub
            {
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
                // Child
                if(wrapProperty.p is TransformData)
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
            if (wrapProperty.p is ShowAnimationUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    #region back

    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            if (showAnimationUI != null)
            {
                ShowAnimationUI.UIData showAnimationUIData = this.data.showAnimation.v;
                if (showAnimationUIData != null)
                {
                    showAnimationUIData.hide();
                }
                else
                {
                    Debug.LogError("showAnimationUIData null");
                }
            }
            else
            {
                Debug.LogError("showAnimationUI null");
                back();
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    private void back()
    {
        if (this.data != null)
        {
            GameDataUI.UIData gameDataUIData = this.data.findDataInParent<GameDataUI.UIData>();
            if (gameDataUIData != null)
            {
                gameDataUIData.perspectiveUIData.v = null;
            }
            else
            {
                Debug.LogError("gameDataBoardUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #endregion

}