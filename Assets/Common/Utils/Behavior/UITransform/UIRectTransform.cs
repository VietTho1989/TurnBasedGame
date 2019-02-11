using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIRectTransform
{

    public Vector3 anchoredPosition;

    public Vector2 anchorMin = new Vector2(0.5f, 0.5f);
    public Vector2 anchorMax = new Vector2(0.5f, 0.5f);
    public Vector2 pivot = new Vector2(0.5f, 0.5f);

    public Vector2 offsetMin = Vector2.zero;
    public Vector2 offsetMax = Vector2.zero;
    public Vector2 sizeDelta;

    public Quaternion rotation;
    public Vector3 scale = new Vector3(1, 1, 1);

    #region Constructor

    public UIRectTransform()
    {

    }

    public UIRectTransform(UIRectTransform rectTransform)
    {
        this.anchoredPosition = rectTransform.anchoredPosition;
        this.anchorMin = rectTransform.anchorMin;
        this.anchorMax = rectTransform.anchorMax;
        this.pivot = rectTransform.pivot;
        this.offsetMin = rectTransform.offsetMin;
        this.offsetMax = rectTransform.offsetMax;
        this.sizeDelta = rectTransform.sizeDelta;
        this.rotation = rectTransform.rotation;
        this.scale = rectTransform.scale;
    }

    #endregion

    public void set(RectTransform rectTransform)
    {
        if (rectTransform != null)
        {
            rectTransform.anchoredPosition = anchoredPosition;
            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
            rectTransform.pivot = pivot;
            rectTransform.offsetMin = offsetMin;
            rectTransform.offsetMax = offsetMax;
            rectTransform.sizeDelta = sizeDelta;
            rectTransform.localRotation = rotation;
            rectTransform.localScale = scale;
        }
        else
        {
            Debug.LogError("rectTransform null");
        }
    }

    public void setPosY(float posY)
    {
        // RequestIntLongFloatRect, RequestEnumRect
        if (this.anchorMin == new Vector2(0.0f, 1.0f)
            && this.anchorMax == new Vector2(1.0f, 1.0f)
            && this.pivot == new Vector2(0.5f, 1f))
        {
            this.anchoredPosition.y = -posY;
            this.offsetMin.y = -this.sizeDelta.y - posY;
            this.offsetMax.y = -posY;
        }
        // RequestBoolRect
        else if (this.anchorMin == new Vector2(0.0f, 1.0f)
            && this.anchorMax == new Vector2(0.0f, 1.0f)
            && this.pivot == new Vector2(0.0f, 1f))
        {
            this.anchoredPosition.y = -posY;
            this.offsetMin.y = -this.sizeDelta.y - posY;
            this.offsetMax.y = -posY;
        }
        else
        {
            Debug.LogError("unknown rect type");
        }

    }

}