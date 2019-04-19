using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ListShowAllUI : UIHaveTransformDataBehavior<ListShowAllUI.UIData>
{

    #region UIData

    public class UIData : ListShowUI.UIData.Sub
    {

        public VP<ReferenceData<ListShowAll>> listShowAll;

        #region Constructor

        public enum Property
        {
            listShowAll
        }

        public UIData() : base()
        {
            this.listShowAll = new VP<ReferenceData<ListShowAll>>(this, (byte)Property.listShowAll, new ReferenceData<ListShowAll>(null));
        }

        #endregion

        public override ListShow.Type getType()
        {
            return ListShow.Type.All;
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
                ListShowAll listShowAll = this.data.listShowAll.v.data;
                if (listShowAll != null)
                {

                }
                else
                {
                    Debug.LogError("listShowAll null");
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
            // Child
            {
                uiData.listShowAll.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        if(data is ListShowAll)
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
            // Child
            {
                uiData.listShowAll.allRemoveCallBack(this);
            }
            this.setDataNull(uiData);
            return;
        }
        // Child
        if (data is ListShowAll)
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
                case UIData.Property.listShowAll:
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
        if (wrapProperty.p is ListShowAll)
        {
            switch ((ListShowAll.Property)wrapProperty.n)
            {
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}