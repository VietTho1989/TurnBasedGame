using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRoundNoLimitInformUI : UIHaveTransformDataBehavior<RequestNewRoundNoLimitInformUI.UIData>
    {

        #region UIData

        public class UIData : RequestNewRoundInformUI.UIData.LimitUI
        {

            public VP<ReferenceData<RequestNewRoundNoLimit>> noLimit;

            public VP<RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData> btnStopMakeMoreRound;

            #region Constructor

            public enum Property
            {
                noLimit,
                btnStopMakeMoreRound
            }

            public UIData() : base()
            {
                this.noLimit = new VP<ReferenceData<RequestNewRoundNoLimit>>(this, (byte)Property.noLimit, new ReferenceData<RequestNewRoundNoLimit>(null));
                this.btnStopMakeMoreRound = new VP<RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData>(this, (byte)Property.btnStopMakeMoreRound, new RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData());
            }

            #endregion

            public override RequestNewRound.Limit.Type getType()
            {
                return RequestNewRound.Limit.Type.NoLimit;
            }

        }

        #endregion

        #region txt

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("No limit, Stop?");

        static RequestNewRoundNoLimitInformUI()
        {
            txtMessage.add(Language.Type.vi, "Không giới hạn, Dừng?");
            // rect
            {
                // btnStopMakeMoreRoundRect
                {
                    // anchoredPosition: (90.0, -10.0); anchorMin: (0.0, 1.0); anchorMax: (0.0, 1.0); pivot: (0.0, 1.0);
                    // offsetMin: (90.0, -50.0); offsetMax: (130.0, -10.0); sizeDelta: (40.0, 40.0);
                    btnStopMakeMoreRoundRect.anchoredPosition = new Vector3(90.0f, -10.0f, 0.0f);
                    btnStopMakeMoreRoundRect.anchorMin = new Vector2(0.0f, 1.0f);
                    btnStopMakeMoreRoundRect.anchorMax = new Vector2(0.0f, 1.0f);
                    btnStopMakeMoreRoundRect.pivot = new Vector2(0.0f, 1.0f);
                    btnStopMakeMoreRoundRect.offsetMin = new Vector2(90.0f, -50.0f);
                    btnStopMakeMoreRoundRect.offsetMax = new Vector2(130.0f, -10.0f);
                    btnStopMakeMoreRoundRect.sizeDelta = new Vector2(40.0f, 40.0f);
                }
            }
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
                    RequestNewRoundNoLimit noLimit = this.data.noLimit.v.data;
                    if (noLimit != null)
                    {
                        // btnStopMakeMoreRound
                        {
                            RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData btnStopMakeMoreRound = this.data.btnStopMakeMoreRound.v;
                            if (btnStopMakeMoreRound != null)
                            {
                                btnStopMakeMoreRound.requestNewRoundNoLimit.v = new ReferenceData<RequestNewRoundNoLimit>(noLimit);
                            }
                            else
                            {
                                Debug.LogError("btnStopMakeMoreRound null: " + this);
                            }
                        }
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
                        Debug.LogError("noLimit null: " + this);
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

        public RequestNewRoundNoLimitBtnStopMakeMoreRoundUI btnStopMakeMoreRoundPrefab;
        private static readonly UIRectTransform btnStopMakeMoreRoundRect = new UIRectTransform();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.noLimit.allAddCallBack(this);
                    uiData.btnStopMakeMoreRound.allAddCallBack(this);
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
                if (data is RequestNewRoundNoLimit)
                {
                    dirty = true;
                    return;
                }
                if (data is RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData)
                {
                    RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData btnStopMakeMoreRound = data as RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(btnStopMakeMoreRound, btnStopMakeMoreRoundPrefab, this.transform, btnStopMakeMoreRoundRect);
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
                    uiData.noLimit.allRemoveCallBack(this);
                    uiData.btnStopMakeMoreRound.allRemoveCallBack(this);
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
                if (data is RequestNewRoundNoLimit)
                {
                    return;
                }
                if (data is RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData)
                {
                    RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData btnStopMakeMoreRound = data as RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData;
                    // UI
                    {
                        btnStopMakeMoreRound.removeCallBackAndDestroy(typeof(RequestNewRoundNoLimitBtnStopMakeMoreRoundUI));
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
                    case UIData.Property.noLimit:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.btnStopMakeMoreRound:
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
                if (wrapProperty.p is RequestNewRoundNoLimit)
                {
                    return;
                }
                if (wrapProperty.p is RequestNewRoundNoLimitBtnStopMakeMoreRoundUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}