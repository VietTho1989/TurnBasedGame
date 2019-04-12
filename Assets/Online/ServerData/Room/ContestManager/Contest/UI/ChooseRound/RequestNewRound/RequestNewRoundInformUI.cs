using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRoundInformUI : UIHaveTransformDataBehavior<RequestNewRoundInformUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RequestNewRound>> requestNewRound;

            #region limit

            public abstract class LimitUI : Data
            {

                public abstract RequestNewRound.Limit.Type getType();

            }

            public VP<LimitUI> limitUI;

            #endregion

            #region Constructor

            public enum Property
            {
                requestNewRound,
                limitUI
            }

            public UIData() : base()
            {
                this.requestNewRound = new VP<ReferenceData<RequestNewRound>>(this, (byte)Property.requestNewRound, new ReferenceData<RequestNewRound>(null));
                this.limitUI = new VP<LimitUI>(this, (byte)Property.limitUI, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // Chac la ko can
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Set Limit Count");

        static RequestNewRoundInformUI()
        {
            txtTitle.add(Language.Type.vi, "Số Hiệp Giới Hạn");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                // Debug.LogError("requestNewRoundInformUI refresh");
                if (this.data != null)
                {
                    RequestNewRound requestNewRound = this.data.requestNewRound.v.data;
                    if (requestNewRound != null)
                    {
                        // limitUI
                        {
                            RequestNewRound.Limit limit = requestNewRound.limit.v;
                            if (limit != null)
                            {
                                switch (limit.getType())
                                {
                                    case RequestNewRound.Limit.Type.NoLimit:
                                        {
                                            RequestNewRoundNoLimit noLimit = limit as RequestNewRoundNoLimit;
                                            // UIData
                                            RequestNewRoundNoLimitInformUI.UIData noLimitUIData = this.data.limitUI.newOrOld<RequestNewRoundNoLimitInformUI.UIData>();
                                            {
                                                noLimitUIData.noLimit.v = new ReferenceData<RequestNewRoundNoLimit>(noLimit);
                                            }
                                            this.data.limitUI.v = noLimitUIData;
                                        }
                                        break;
                                    case RequestNewRound.Limit.Type.HaveLimit:
                                        {
                                            RequestNewRoundHaveLimit haveLimit = limit as RequestNewRoundHaveLimit;
                                            // UIData
                                            RequestNewRoundHaveLimitInformUI.UIData haveLimitUIData = this.data.limitUI.newOrOld<RequestNewRoundHaveLimitInformUI.UIData>();
                                            {
                                                haveLimitUIData.haveLimit.v = new ReferenceData<RequestNewRoundHaveLimit>(haveLimit);
                                            }
                                            this.data.limitUI.v = haveLimitUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + limit.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("limit null: " + this);
                            }
                        }
                        // UI
                        {
                            float deltaY = 30;
                            // limitUI
                            deltaY += UIRectTransform.SetPosY(this.data.limitUI.v, deltaY);
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("requestNewRound null: " + this);
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

        public RequestNewRoundNoLimitInformUI noLimitPrefab;
        public RequestNewRoundHaveLimitInformUI haveLimitPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.requestNewRound.allAddCallBack(this);
                    uiData.limitUI.allAddCallBack(this);
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
                if (data is RequestNewRound)
                {
                    dirty = true;
                    return;
                }
                // limitUI
                {
                    if (data is UIData.LimitUI)
                    {
                        UIData.LimitUI limitUIData = data as UIData.LimitUI;
                        // UI
                        {
                            switch (limitUIData.getType())
                            {
                                case RequestNewRound.Limit.Type.NoLimit:
                                    {
                                        RequestNewRoundNoLimitInformUI.UIData noLimitUIData = limitUIData as RequestNewRoundNoLimitInformUI.UIData;
                                        UIUtils.Instantiate(noLimitUIData, noLimitPrefab, this.transform);
                                    }
                                    break;
                                case RequestNewRound.Limit.Type.HaveLimit:
                                    {
                                        RequestNewRoundHaveLimitInformUI.UIData haveLimitUIData = limitUIData as RequestNewRoundHaveLimitInformUI.UIData;
                                        UIUtils.Instantiate(haveLimitUIData, haveLimitPrefab, this.transform);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + limitUIData.getType() + "; " + this);
                                    break;
                            }
                        }
                        // Child
                        {
                            TransformData.AddCallBack(limitUIData, this);
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
                    uiData.requestNewRound.allRemoveCallBack(this);
                    uiData.limitUI.allRemoveCallBack(this);
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
                if (data is RequestNewRound)
                {
                    return;
                }
                // limitUIData
                {
                    if (data is UIData.LimitUI)
                    {
                        UIData.LimitUI limitUIData = data as UIData.LimitUI;
                        // Child
                        {
                            TransformData.RemoveCallBack(limitUIData, this);
                        }
                        // UI
                        {
                            switch (limitUIData.getType())
                            {
                                case RequestNewRound.Limit.Type.NoLimit:
                                    {
                                        RequestNewRoundNoLimitInformUI.UIData noLimitUIData = limitUIData as RequestNewRoundNoLimitInformUI.UIData;
                                        noLimitUIData.removeCallBackAndDestroy(typeof(RequestNewRoundNoLimitInformUI));
                                    }
                                    break;
                                case RequestNewRound.Limit.Type.HaveLimit:
                                    {
                                        RequestNewRoundHaveLimitInformUI.UIData haveLimitUIData = limitUIData as RequestNewRoundHaveLimitInformUI.UIData;
                                        haveLimitUIData.removeCallBackAndDestroy(typeof(RequestNewRoundHaveLimitInformUI));
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + limitUIData.getType() + "; " + this);
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
                    case UIData.Property.requestNewRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.limitUI:
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
                if (wrapProperty.p is RequestNewRound)
                {
                    switch ((RequestNewRound.Property)wrapProperty.n)
                    {
                        case RequestNewRound.Property.state:
                            break;
                        case RequestNewRound.Property.limit:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // limitUIData
                {
                    if (wrapProperty.p is UIData.LimitUI)
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
                        Debug.LogError("requestNewRoundInformUI transformData dirty");
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}