using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaitAIInputUI : UIBehavior<WaitAIInputUI.UIData>
{

    #region UIData

    public class UIData : WaitInputActionUI.UIData.Sub
    {

        public VP<ReferenceData<WaitAIInput>> waitAIInput;

        #region Sub

        public abstract class Sub : Data
        {

            public abstract WaitAIInput.Sub.Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            waitAIInput,
            sub
        }

        public UIData() : base()
        {
            this.waitAIInput = new VP<ReferenceData<WaitAIInput>>(this, (byte)Property.waitAIInput, new ReferenceData<WaitAIInput>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

        public override WaitInputAction.Sub.Type getType()
        {
            return WaitInputAction.Sub.Type.AI;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtYourAI = new TxtLanguage("Your AI is thinking");
    private static readonly TxtLanguage txtOtherAI = new TxtLanguage("Other AI is thinking");

    static WaitAIInputUI()
    {
        txtYourAI.add(Language.Type.vi, "AI của bạn đang nghĩ");
        txtOtherAI.add(Language.Type.vi, "AI của người khác đang nghĩ");
    }

    #endregion

    #region Refresh

    public Text tvUserThink;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                WaitAIInput waitAIInput = this.data.waitAIInput.v.data;
                if (waitAIInput != null)
                {
                    // tvUserThink
                    if (tvUserThink != null)
                    {
                        if (Server.getProfileUserId(waitAIInput) == waitAIInput.userThink.v)
                        {
                            tvUserThink.text = txtYourAI.get();
                        }
                        else
                        {
                            tvUserThink.text = txtOtherAI.get();
                        }
                    }
                    else
                    {
                        Debug.LogError("tvUserThink null: " + this);
                    }
                    // sub
                    if (waitAIInput.sub.v != null)
                    {
                        switch (waitAIInput.sub.v.getType())
                        {
                            case WaitAIInput.Sub.Type.None:
                                {
                                    WaitAIInputNone none = waitAIInput.sub.v as WaitAIInputNone;
                                    // UIData
                                    WaitAIInputNoneUI.UIData noneUIData = this.data.sub.newOrOld<WaitAIInputNoneUI.UIData>();
                                    {
                                        noneUIData.waitAIInputNone.v = new ReferenceData<WaitAIInputNone>(none);
                                    }
                                    this.data.sub.v = noneUIData;
                                }
                                break;
                            case WaitAIInput.Sub.Type.Search:
                                {
                                    WaitAIInputSearch search = waitAIInput.sub.v as WaitAIInputSearch;
                                    // UIData
                                    WaitAIInputSearchUI.UIData searchUIData = this.data.sub.newOrOld<WaitAIInputSearchUI.UIData>();
                                    {
                                        searchUIData.waitAIInputSearch.v = new ReferenceData<WaitAIInputSearch>(search);
                                    }
                                    this.data.sub.v = searchUIData;
                                }
                                break;
                            case WaitAIInput.Sub.Type.Solved:
                                {
                                    WaitAIInputSolved solved = waitAIInput.sub.v as WaitAIInputSolved;
                                    // UIData
                                    WaitAIInputSolvedUI.UIData solvedUIData = this.data.sub.newOrOld<WaitAIInputSolvedUI.UIData>();
                                    {
                                        solvedUIData.waitAIInputSolved.v = new ReferenceData<WaitAIInputSolved>(solved);
                                    }
                                    this.data.sub.v = solvedUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + waitAIInput.sub.getType() + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("sub null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("waitAIInput null: " + this);
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

    public Transform subContainer;
    public WaitAIInputNoneUI nonePrefab;
    public WaitAIInputSearchUI searchPrefab;
    public WaitAIInputSolvedUI solvedPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.sub.allAddCallBack(this);
                uiData.waitAIInput.allAddCallBack(this);
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
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case WaitAIInput.Sub.Type.None:
                            {
                                WaitAIInputNoneUI.UIData noneUIData = sub as WaitAIInputNoneUI.UIData;
                                UIUtils.Instantiate(noneUIData, nonePrefab, subContainer);
                            }
                            break;
                        case WaitAIInput.Sub.Type.Search:
                            {
                                WaitAIInputSearchUI.UIData searchUIData = sub as WaitAIInputSearchUI.UIData;
                                UIUtils.Instantiate(searchUIData, searchPrefab, subContainer);
                            }
                            break;
                        case WaitAIInput.Sub.Type.Solved:
                            {
                                WaitAIInputSolvedUI.UIData solvedUIData = sub as WaitAIInputSolvedUI.UIData;
                                UIUtils.Instantiate(solvedUIData, solvedPrefab, subContainer);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                dirty = true;
                return;
            }
            // WaitAIInput
            {
                if (data is WaitAIInput)
                {
                    WaitAIInput waitAIInput = data as WaitAIInput;
                    {
                        waitAIInput.sub.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                if (data is WaitAIInput.Sub)
                {
                    dirty = true;
                    return;
                }
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
                uiData.sub.allRemoveCallBack(this);
                uiData.waitAIInput.allRemoveCallBack(this);
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
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case WaitAIInput.Sub.Type.None:
                            {
                                WaitAIInputNoneUI.UIData noneUIData = sub as WaitAIInputNoneUI.UIData;
                                noneUIData.removeCallBackAndDestroy(typeof(WaitAIInputNoneUI));
                            }
                            break;
                        case WaitAIInput.Sub.Type.Search:
                            {
                                WaitAIInputSearchUI.UIData searchUIData = sub as WaitAIInputSearchUI.UIData;
                                searchUIData.removeCallBackAndDestroy(typeof(WaitAIInputSearchUI));
                            }
                            break;
                        case WaitAIInput.Sub.Type.Solved:
                            {
                                WaitAIInputSolvedUI.UIData solvedUIData = sub as WaitAIInputSolvedUI.UIData;
                                solvedUIData.removeCallBackAndDestroy(typeof(WaitAIInputSolvedUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
            // WaitAIInput
            {
                if (data is WaitAIInput)
                {
                    WaitAIInput waitAIInput = data as WaitAIInput;
                    {
                        waitAIInput.sub.allRemoveCallBack(this);
                    }
                    return;
                }
                if (data is WaitAIInput.Sub)
                {
                    return;
                }
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
                case UIData.Property.waitAIInput:
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
        {
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            // WaitAIInput
            {
                if (wrapProperty.p is WaitAIInput)
                {
                    switch ((WaitAIInput.Property)wrapProperty.n)
                    {
                        case WaitAIInput.Property.userThink:
                            dirty = true;
                            break;
                        case WaitAIInput.Property.reThink:
                            break;
                        case WaitAIInput.Property.sub:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case WaitAIInput.Property.isGettingSolvedMove:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is WaitAIInput.Sub)
                {
                    return;
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

}