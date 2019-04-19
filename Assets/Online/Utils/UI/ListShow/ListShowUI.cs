using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ListShowUI : UIHaveTransformDataBehavior<ListShowUI.UIData>
{

    #region UIData

    public class UIData : Data
    {

        public VP<ReferenceData<ListShow>> listShow;

        #region sub

        public abstract class Sub : Data
        {

            public abstract ListShow.Type getType();

        }

        public VP<Sub> sub;

        #endregion

        #region Constructor

        public enum Property
        {
            listShow,
            sub
        }

        public UIData() : base()
        {
            this.listShow = new VP<ReferenceData<ListShow>>(this, (byte)Property.listShow, new ReferenceData<ListShow>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
        }

        #endregion

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
                ListShow listShow = this.data.listShow.v.data;
                if (listShow != null)
                {
                    // sub
                    {
                        switch (listShow.getType())
                        {
                            case ListShow.Type.All:
                                {
                                    ListShowAll listShowAll = listShow as ListShowAll;
                                    // UI
                                    ListShowAllUI.UIData listShowAllUIData = this.data.sub.newOrOld<ListShowAllUI.UIData>();
                                    {
                                        listShowAllUIData.listShowAll.v = new ReferenceData<ListShowAll>(listShowAll);
                                    }
                                    this.data.sub.v = listShowAllUIData;
                                }
                                break;
                            case ListShow.Type.Limit:
                                {
                                    ListShowLimit listShowLimit = listShow as ListShowLimit;
                                    // UI
                                    ListShowLimitUI.UIData listShowLimitUIData = this.data.sub.newOrOld<ListShowLimitUI.UIData>();
                                    {
                                        listShowLimitUIData.listShowLimit.v = new ReferenceData<ListShowLimit>(listShowLimit);
                                    }
                                    this.data.sub.v = listShowLimitUIData;
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + listShow.getType());
                                break;
                        }
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // sub
                        deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        // set height
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                }
                else
                {
                    Debug.LogError("listShow null");
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

    public ListShowAllUI listShowAllPrefab;
    public ListShowLimitUI listShowLimitPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Child
            {
                uiData.listShow.allAddCallBack(this);
                uiData.sub.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if(data is ListShow)
            {
                dirty = true;
                return;
            }
            // sub
            {
                if(data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case ListShow.Type.All:
                                {
                                    ListShowAllUI.UIData listShowAllUIData = sub as ListShowAllUI.UIData;
                                    UIUtils.Instantiate(listShowAllUIData, listShowAllPrefab, this.transform);
                                }
                                break;
                            case ListShow.Type.Limit:
                                {
                                    ListShowLimitUI.UIData listShowLimitUIData = sub as ListShowLimitUI.UIData;
                                    UIUtils.Instantiate(listShowLimitUIData, listShowLimitPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType());
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
                uiData.listShow.allRemoveCallBack(this);
                uiData.sub.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        {
            if (data is ListShow)
            {
                return;
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
                            case ListShow.Type.All:
                                {
                                    ListShowAllUI.UIData listShowAllUIData = sub as ListShowAllUI.UIData;
                                    listShowAllUIData.removeCallBackAndDestroy(typeof(ListShowAllUI));
                                }
                                break;
                            case ListShow.Type.Limit:
                                {
                                    ListShowLimitUI.UIData listShowLimitUIData = sub as ListShowLimitUI.UIData;
                                    listShowLimitUIData.removeCallBackAndDestroy(typeof(ListShowLimitUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType());
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
                case UIData.Property.listShow:
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
        // Child
        {
            if (wrapProperty.p is ListShow)
            {
                return;
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
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}