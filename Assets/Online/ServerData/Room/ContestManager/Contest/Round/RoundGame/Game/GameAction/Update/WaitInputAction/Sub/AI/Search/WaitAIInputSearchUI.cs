using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class WaitAIInputSearchUI : UIBehavior<WaitAIInputSearchUI.UIData>
{

    #region UIData

    public class UIData : WaitAIInputUI.UIData.Sub
    {

        public VP<ReferenceData<WaitAIInputSearch>> waitAIInputSearch;

        #region Constructor

        public enum Property
        {
            waitAIInputSearch
        }

        public UIData() : base()
        {
            this.waitAIInputSearch = new VP<ReferenceData<WaitAIInputSearch>>(this, (byte)Property.waitAIInputSearch, new ReferenceData<WaitAIInputSearch>(null));
        }

        #endregion

        public override WaitAIInput.Sub.Type getType()
        {
            return WaitAIInput.Sub.Type.Search;
        }

    }

    #endregion

    #region txt

    public Text tvMessage;
    public static readonly TxtLanguage txtMessage = new TxtLanguage("Wait AI Input: Search");

    static WaitAIInputSearchUI()
    {
        txtMessage.add(Language.Type.vi, "Đợi đầu vào AI: đang tìm");
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
                // txt
                {
                    if (tvMessage != null)
                    {
                        tvMessage.text = txtMessage.get();
                    }
                    else
                    {
                        Debug.LogError("tvMessage null: " + this);
                    }
                }
            }
            else
            {
                // Debug.LogError ("data null: " + this);
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
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.waitAIInputSearch.allAddCallBack(this);
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
        if (data is WaitAIInputSearch)
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
                uiData.waitAIInputSearch.allRemoveCallBack(this);
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
        if (data is WaitAIInputSearch)
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
                case UIData.Property.waitAIInputSearch:
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
        if (wrapProperty.p is WaitAIInputSearch)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}