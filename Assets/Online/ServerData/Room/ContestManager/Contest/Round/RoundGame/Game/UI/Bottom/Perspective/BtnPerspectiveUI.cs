using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnPerspectiveUI : UIBehavior<BtnPerspectiveUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<Perspective>> perspective;

        #region Constructor

        public enum Property
        {
            perspective
        }

        public UIData() : base()
        {
            this.perspective = new VP<ReferenceData<Perspective>>(this, (byte)Property.perspective, new ReferenceData<Perspective>(null));
        }

        #endregion

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        BtnPerspectiveUI btnPerspectiveUI = this.findCallBack<BtnPerspectiveUI>();
                        if (btnPerspectiveUI != null)
                        {
                            isProcess = btnPerspectiveUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("btnPerspectiveUI null: " + this);
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
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Perspective");

    static BtnPerspectiveUI()
    {
        txtTitle.add(Language.Type.vi, "Góc Nhìn");
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
                Perspective perspective = this.data.perspective.v.data;
                if (perspective != null)
                {
                    // title
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get() + " " + perspective.playerView.v;
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("perspective null");
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
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.perspective.allAddCallBack(this);
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
        if (data is Perspective)
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
            // Child
            {
                uiData.perspective.allRemoveCallBack(this);
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
        if (data is Perspective)
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
                case UIData.Property.perspective:
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
        if (wrapProperty.p is Perspective)
        {
            switch ((Perspective.Property)wrapProperty.n)
            {
                case Perspective.Property.playerView:
                    dirty = true;
                    break;
                case Perspective.Property.sub:
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
    public void onClickBtnPerspective()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                if (gameDataUIData != null)
                {
                    PerspectiveUI.UIData perspectiveUIData = gameDataUIData.perspectiveUIData.newOrOld<PerspectiveUI.UIData>();
                    {

                    }
                    gameDataUIData.perspectiveUIData.v = perspectiveUIData;
                    // showAnimationUI
                    {
                        ShowAnimationUI.UIData showAnimationUIData = perspectiveUIData.showAnimation.v;
                        if (showAnimationUIData != null)
                        {
                            showAnimationUIData.show();
                        }
                        else
                        {
                            Debug.LogError("showAnimationUIData null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("gameDataUIData null");
                }
            }
            else
            {
                Debug.LogError("gameUIData null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}