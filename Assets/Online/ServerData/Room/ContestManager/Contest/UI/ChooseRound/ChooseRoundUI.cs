using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ChooseRoundUI : UIBehavior<ChooseRoundUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Contest>> contest;

            public VP<ChooseRoundAdapter.UIData> chooseRoundAdapter;

            public VP<RequestNewRoundInformUI.UIData> requestNewRoundInformUIData;

            #region Constructor

            public enum Property
            {
                contest,
                chooseRoundAdapter,
                requestNewRoundInformUIData
            }

            public UIData() : base()
            {
                this.contest = new VP<ReferenceData<Contest>>(this, (byte)Property.contest, new ReferenceData<Contest>(null));
                this.chooseRoundAdapter = new VP<ChooseRoundAdapter.UIData>(this, (byte)Property.chooseRoundAdapter, new ChooseRoundAdapter.UIData());
                this.requestNewRoundInformUIData = new VP<RequestNewRoundInformUI.UIData>(this, (byte)Property.requestNewRoundInformUIData, new RequestNewRoundInformUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // requestNewRoundInformUIData
                    if (!isProcess)
                    {
                        RequestNewRoundInformUI.UIData requestNewRoundInformUIData = this.requestNewRoundInformUIData.v;
                        if (requestNewRoundInformUIData != null)
                        {
                            isProcess = requestNewRoundInformUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("requestNewRoundInformUIData null: " + this);
                        }
                    }
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            ChooseRoundUI chooseRoundUI = this.findCallBack<ChooseRoundUI>();
                            if (chooseRoundUI != null)
                            {
                                chooseRoundUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("chooseRoundUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChooseRoundUI chooseRoundUI = this.findCallBack<ChooseRoundUI>();
                            if (chooseRoundUI != null)
                            {
                                isProcess = chooseRoundUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundUI null: " + this);
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
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Choose Set In Match");

        static ChooseRoundUI()
        {
            // txt
            txtTitle.add(Language.Type.vi, "Chọn Hiệp Đấu");
            // rect
            {
                // chooseRoundAdapterRect
                {
                    // anchoredPosition: (0.0, -30.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                    // offsetMin: (0.0, -330.0); offsetMax: (0.0, -30.0); sizeDelta: (0.0, 300.0);
                    chooseRoundAdapterRect.anchoredPosition = new Vector3(0.0f, -30.0f);
                    chooseRoundAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                    chooseRoundAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                    chooseRoundAdapterRect.pivot = new Vector2(0.5f, 1.0f);
                    chooseRoundAdapterRect.offsetMin = new Vector2(0.0f, -330.0f);
                    chooseRoundAdapterRect.offsetMax = new Vector2(0.0f, -30.0f);
                    chooseRoundAdapterRect.sizeDelta = new Vector2(0.0f, 300.0f);
                }
            }
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
                    Contest contest = this.data.contest.v.data;
                    if (contest != null)
                    {
                        // chooseRoundAdapter
                        {
                            ChooseRoundAdapter.UIData chooseRoundAdapterUIData = this.data.chooseRoundAdapter.v;
                            if (chooseRoundAdapterUIData != null)
                            {
                                chooseRoundAdapterUIData.contest.v = new ReferenceData<Contest>(contest);
                            }
                            else
                            {
                                Debug.LogError("chooseRoundAdapterUIData null: " + this);
                            }
                        }
                        // requestNewRoundInformUIData
                        {
                            RequestNewRoundInformUI.UIData requestNewRoundInformUIData = this.data.requestNewRoundInformUIData.v;
                            if (requestNewRoundInformUIData != null)
                            {
                                requestNewRoundInformUIData.requestNewRound.v = new ReferenceData<RequestNewRound>(contest.requestNewRound.v);
                            }
                            else
                            {
                                Debug.LogError("requestNewRoundInformUIData null: " + this);
                            }
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
                            // adapter
                            deltaY += UIRectTransform.SetPosY(this.data.chooseRoundAdapter.v, deltaY);
                            // requestNewRound
                            deltaY += UIRectTransform.SetPosY(this.data.requestNewRoundInformUIData.v, deltaY);
                            Debug.LogError("chooseRoundUI: " + deltaY);
                            // set
                            {
                                UIRectTransform rect = UIRectTransform.CreateCenterRect(400, deltaY, 0, 30);
                                {
                                    // rect.setPosY(-30);
                                }
                                rect.set((RectTransform)this.transform);
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
                                Debug.LogError("lbTitle null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contest null: " + this);
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

        public ChooseRoundAdapter chooseRoundAdapterPrefab;
        private static readonly UIRectTransform chooseRoundAdapterRect = new UIRectTransform();

        public RequestNewRoundInformUI requestNewRoundInformPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.contest.allAddCallBack(this);
                    uiData.chooseRoundAdapter.allAddCallBack(this);
                    uiData.requestNewRoundInformUIData.allAddCallBack(this);
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
                if (data is Contest)
                {
                    dirty = true;
                    return;
                }
                if (data is ChooseRoundAdapter.UIData)
                {
                    ChooseRoundAdapter.UIData chooseRoundAdapterUIData = data as ChooseRoundAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(chooseRoundAdapterUIData, chooseRoundAdapterPrefab, this.transform, chooseRoundAdapterRect);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is RequestNewRoundInformUI.UIData)
                    {
                        RequestNewRoundInformUI.UIData requestNewRoundInformUIData = data as RequestNewRoundInformUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(requestNewRoundInformUIData, requestNewRoundInformPrefab, this.transform); //, requestNewRoundInformRect);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(requestNewRoundInformUIData, this);
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
                    uiData.contest.allRemoveCallBack(this);
                    uiData.chooseRoundAdapter.allRemoveCallBack(this);
                    uiData.requestNewRoundInformUIData.allRemoveCallBack(this);
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
                if (data is Contest)
                {
                    return;
                }
                if (data is ChooseRoundAdapter.UIData)
                {
                    ChooseRoundAdapter.UIData chooseRoundAdapterUIData = data as ChooseRoundAdapter.UIData;
                    // UI
                    {
                        chooseRoundAdapterUIData.removeCallBackAndDestroy(typeof(ChooseRoundAdapter));
                    }
                    return;
                }
                // requestNewRoundInformUIData
                {
                    if (data is RequestNewRoundInformUI.UIData)
                    {
                        RequestNewRoundInformUI.UIData requestNewRoundInformUIData = data as RequestNewRoundInformUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(requestNewRoundInformUIData, this);
                        }
                        // UI
                        {
                            requestNewRoundInformUIData.removeCallBackAndDestroy(typeof(RequestNewRoundInformUI));
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
                    case UIData.Property.contest:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.chooseRoundAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.requestNewRoundInformUIData:
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
                if (wrapProperty.p is Contest)
                {
                    return;
                }
                if (wrapProperty.p is ChooseRoundAdapter.UIData)
                {
                    return;
                }
                // requestNewRoundInformUIData
                {
                    if (wrapProperty.p is RequestNewRoundInformUI.UIData)
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
                        Debug.LogError("transform data dirty");
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                ContestUI.UIData contestUIData = this.data.findDataInParent<ContestUI.UIData>();
                if (contestUIData != null)
                {
                    contestUIData.chooseRoundUIData.v = null;
                }
                else
                {
                    Debug.LogError("contestUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}