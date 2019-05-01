using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnBlindFoldUI : UIBehavior<BtnBlindFoldUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestChangeBlindFold>> requestChangeBlindFold;

        #region Constructor

        public enum Property
        {
            requestChangeBlindFold
        }

        public UIData() : base()
        {
            this.requestChangeBlindFold = new VP<ReferenceData<RequestChangeBlindFold>>(this, (byte)Property.requestChangeBlindFold, new ReferenceData<RequestChangeBlindFold>(null));
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Blindfold");

    static BtnBlindFoldUI()
    {
        txtTitle.add(Language.Type.vi, "Cờ Mù");
    }

    #endregion

    #region Refresh

    public GameObject highlightIndicator;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestChangeBlindFold requestChangeBlindFold = this.data.requestChangeBlindFold.v.data;
                if (requestChangeBlindFold != null)
                {
                    // highlightIndicator
                    {
                        if (highlightIndicator != null)
                        {
                            highlightIndicator.SetActive(requestChangeBlindFold.state.v.getType() != RequestChangeBlindFold.State.Type.None);
                        }
                        else
                        {
                            Debug.LogError("highlightIndicator null");
                        }
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    // Debug.LogError("requestChangeBlindFold null");
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
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.requestChangeBlindFold.allAddCallBack(this);
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
        if (data is RequestChangeBlindFold)
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
                uiData.requestChangeBlindFold.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Setting
        if(data is Setting)
        {
            return;
        }
        // Child
        if (data is RequestChangeBlindFold)
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
                case UIData.Property.requestChangeBlindFold:
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
        if(wrapProperty.p is Setting)
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
        if (wrapProperty.p is RequestChangeBlindFold)
        {
            switch ((RequestChangeBlindFold.Property)wrapProperty.n)
            {
                case RequestChangeBlindFold.Property.state:
                    dirty = true;
                    break;
                case RequestChangeBlindFold.Property.whoCanAsks:
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
    public void onClickBtnBlindFold()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                if (gameDataUIData != null)
                {
                    RequestChangeBlindFoldUI.UIData requestChangeBlindFoldUIData = gameDataUIData.requestChangeBlindFold.newOrOld<RequestChangeBlindFoldUI.UIData>();
                    {

                    }
                    gameDataUIData.requestChangeBlindFold.v = requestChangeBlindFoldUIData;
                    // showAnimationUI
                    {
                        ShowAnimationUI.UIData showAnimationUIData = requestChangeBlindFoldUIData.showAnimation.v;
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