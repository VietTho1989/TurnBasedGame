using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ListShowLimitUI : UIHaveTransformDataBehavior<ListShowLimitUI.UIData>
{

    #region UIData

    public class UIData : ListShowUI.UIData.Sub
    {

        public VP<ReferenceData<ListShowLimit>> listShowLimit;

        #region index

        public VP<RequestChangeIntUI.UIData> index;

        public void makeRequestChangeIndex(RequestChangeUpdate<int>.UpdateData update, int newIndex)
        {
            // Find
            ListShowLimit listShowLimit = null;
            {
                listShowLimit = this.listShowLimit.v.data;
            }
            // Process
            if (listShowLimit != null)
            {
                listShowLimit.index.v = (uint)Mathf.Clamp(newIndex, 0, listShowLimit.itemCount.v);
            }
            else
            {
                Debug.LogError("listShowLimit null");
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            listShowLimit,
            index
        }

        public UIData() : base()
        {
            this.listShowLimit = new VP<ReferenceData<ListShowLimit>>(this, (byte)Property.listShowLimit, new ReferenceData<ListShowLimit>(null));
            // index
            {
                this.index = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.index, new RequestChangeIntUI.UIData());
                this.index.v.updateData.v.request.v = makeRequestChangeIndex;
            }
        }

        #endregion

        public override ListShow.Type getType()
        {
            return ListShow.Type.Limit;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        ListShowLimitUI listShowLimitUI = this.findCallBack<ListShowLimitUI>();
                        if (listShowLimitUI != null)
                        {
                            isProcess = listShowLimitUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("listShowLimitUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt, rect

    static ListShowLimitUI()
    {
        // rect
        {
            // anchoredPosition: (-80.0, 0.0); anchorMin: (1.0, 1.0); anchorMax: (1.0, 1.0); pivot: (1.0, 1.0);
            // offsetMin: (-130.0, -30.0); offsetMax: (-80.0, 0.0); sizeDelta: (50.0, 30.0);
            indexRect.anchoredPosition = new Vector3(-90.0f, 0.0f);
            indexRect.anchorMin = new Vector2(1.0f, 1.0f);
            indexRect.anchorMax = new Vector2(1.0f, 1.0f);
            indexRect.pivot = new Vector2(1.0f, 1.0f);
            indexRect.offsetMin = new Vector2(-150.0f, -30.0f);
            indexRect.offsetMax = new Vector2(-90.0f, 0.0f);
            indexRect.sizeDelta = new Vector2(60.0f, 30.0f);
        }
    }

    #endregion

    #region Refresh

    public Text tvItemCount;

    public Button btnBack;
    public Button btnNext;

    private bool needReset = false;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                ListShowLimit listShowLimit = this.data.listShowLimit.v.data;
                if (listShowLimit != null)
                {
                    // index
                    {
                        RequestChangeIntUI.UIData index = this.data.index.v;
                        if (index != null)
                        {
                            // update
                            RequestChangeUpdate<int>.UpdateData updateData = index.updateData.v;
                            if (updateData != null)
                            {
                                updateData.origin.v = (int)listShowLimit.index.v;
                                updateData.canRequestChange.v = true;
                                updateData.serverState.v = Server.State.Type.Connect;
                            }
                            else
                            {
                                Debug.LogError("updateData null");
                            }
                            // reset
                            if (needReset)
                            {
                                updateData.current.v = (int)listShowLimit.index.v;
                                updateData.changeState.v = Data.ChangeState.None;
                            }
                            needReset = false;
                        }
                        else
                        {
                            Debug.LogError("index null");
                        }
                    }
                    // itemCount
                    if (tvItemCount != null)
                    {
                        tvItemCount.text = "/" + listShowLimit.itemCount.v;
                    }
                    else
                    {
                        Debug.LogError("tvItemCount null");
                    }
                    // btnBack
                    if (btnBack != null)
                    {
                        btnBack.interactable = listShowLimit.index.v > 0;
                    }
                    else
                    {
                        Debug.LogError("btnBack null");
                    }
                    // btnNext
                    if (btnNext != null)
                    {
                        btnNext.interactable = listShowLimit.itemCount.v - listShowLimit.count.v > listShowLimit.index.v;
                    }
                    else
                    {
                        Debug.LogError("btnNext null");
                    }
                }
                else
                {
                    Debug.LogError("listShowLimit null");
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

    public RequestChangeIntUI requestIntPrefab;
    private static readonly UIRectTransform indexRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.listShowLimit.allAddCallBack(this);
                uiData.index.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is ListShowLimit)
            {
                dirty = true;
                return;
            }
            // index
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    WrapProperty wrapProperty = requestChange.p;
                    if (wrapProperty != null)
                    {
                        switch ((UIData.Property)wrapProperty.n)
                        {
                            case UIData.Property.index:
                                UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, indexRect);
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("wrapProperty null: " + this);
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
            // Child
            {
                uiData.listShowLimit.allRemoveCallBack(this);
                uiData.index.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is ListShowLimit)
            {
                return;
            }
            // index
            if (data is RequestChangeIntUI.UIData)
            {
                RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                // UI
                {
                    requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
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
                case UIData.Property.listShowLimit:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.index:
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
        {
            if (wrapProperty.p is ListShowLimit)
            {
                switch ((ListShowLimit.Property)wrapProperty.n)
                {
                    case ListShowLimit.Property.index:
                        dirty = true;
                        break;
                    case ListShowLimit.Property.count:
                        dirty = true;
                        break;
                    case ListShowLimit.Property.itemCount:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // index
            if (wrapProperty.p is RequestChangeIntUI.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnBack, onClickBtnBack);
            UIUtils.SetButtonOnClick(btnNext, onClickBtnNext);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.B:
                        {
                            if (btnBack != null && btnBack.gameObject.activeInHierarchy && btnBack.interactable)
                            {
                                this.onClickBtnBack();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    case KeyCode.N:
                        {
                            if (btnNext != null && btnNext.gameObject.activeInHierarchy && btnNext.interactable)
                            {
                                this.onClickBtnNext();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnBack()
    {
        if (this.data != null)
        {
            ListShowLimit listShowLimit = this.data.listShowLimit.v.data;
            if (listShowLimit != null)
            {
                listShowLimit.index.v = (uint)Mathf.Max(listShowLimit.index.v - listShowLimit.count.v, 0);
            }
            else
            {
                Debug.LogError("listShowLimit null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnNext()
    {
        if (this.data != null)
        {
            ListShowLimit listShowLimit = this.data.listShowLimit.v.data;
            if (listShowLimit != null)
            {
                listShowLimit.index.v = (uint)Mathf.Min(listShowLimit.index.v + listShowLimit.count.v, listShowLimit.itemCount.v - 1);
            }
            else
            {
                Debug.LogError("listShowLimit null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}