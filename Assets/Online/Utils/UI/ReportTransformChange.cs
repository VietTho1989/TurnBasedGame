using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReportTransformChange : MonoBehaviour, ValueChangeCallBack
{

    private TransformData transformData = new TransformData();

    private bool dirty = true;

    void Update()
    {
        transformData.update(this.transform);
        if (dirty)
        {
            // Debug.Log("reportTransformChange");
            dirty = false;
            WrapContent.SetAncestorDirty(this.transform);
        }
    }

    #region lifeCycle

    void Awake()
    {
        transformData.addCallBack(this);
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if(data is TransformData)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if(data is TransformData)
        {
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if(wrapProperty.p is TransformData)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}