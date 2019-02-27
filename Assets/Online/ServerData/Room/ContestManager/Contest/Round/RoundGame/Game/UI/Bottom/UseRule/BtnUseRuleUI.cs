using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class BtnUseRuleUI : UIBehavior<BtnUseRuleUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<RequestChangeUseRule>> requestChangeUseRule;

        #region Constructor

        public enum Property
        {
            requestChangeUseRule
        }

        public UIData() : base()
        {
            this.requestChangeUseRule = new VP<ReferenceData<RequestChangeUseRule>>(this, (byte)Property.requestChangeUseRule, new ReferenceData<RequestChangeUseRule>(null));
        }

        #endregion

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    static BtnUseRuleUI()
    {
        txtTitle.add(Language.Type.vi, "Dùng Luật");
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
                RequestChangeUseRule requestChangeUseRule = this.data.requestChangeUseRule.v.data;
                if (requestChangeUseRule != null)
                {
                    // highlightIndicator
                    {
                        if (highlightIndicator != null)
                        {
                            highlightIndicator.SetActive(requestChangeUseRule.state.v.getType() != RequestChangeUseRule.State.Type.None);
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
                            lbTitle.text = txtTitle.get("Use Rule");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestChangeUseRule null");
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
                uiData.requestChangeUseRule.allAddCallBack(this);
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
        if (data is RequestChangeUseRule)
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
                uiData.requestChangeUseRule.allRemoveCallBack(this);
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
        if (data is RequestChangeUseRule)
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
                case UIData.Property.requestChangeUseRule:
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
        if (wrapProperty.p is RequestChangeUseRule)
        {
            switch ((RequestChangeUseRule.Property)wrapProperty.n)
            {
                case RequestChangeUseRule.Property.state:
                    dirty = true;
                    break;
                case RequestChangeUseRule.Property.whoCanAsks:
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

    public void onClickBtnUseRule()
    {
        if (this.data != null)
        {
            GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
            if (gameUIData != null)
            {
                GameDataUI.UIData gameDataUIData = gameUIData.gameDataUI.v;
                if (gameDataUIData != null)
                {
                    RequestChangeUseRuleUI.UIData requestChangeUseRuleUIData = gameDataUIData.requestChangeUseRule.newOrOld<RequestChangeUseRuleUI.UIData>();
                    {

                    }
                    gameDataUIData.requestChangeUseRule.v = requestChangeUseRuleUIData;
                    // showAnimationUI
                    {
                        ShowAnimationUI.UIData showAnimationUIData = requestChangeUseRuleUIData.showAnimation.v;
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