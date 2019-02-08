using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class UIRectTransform
{

    public Vector3 anchoredPosition;

    public Vector2 sizeDelta;

    public Vector2 anchorMin = new Vector2(0.5f, 0.5f);
    public Vector2 anchorMax = new Vector2(0.5f, 0.5f);
    public Vector2 pivot = new Vector2(0.5f, 0.5f);

    public Vector3 rotation;
    public Vector3 scale = new Vector3(1, 1, 1);

    public void set(RectTransform rectTransform)
    {
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = sizeDelta;
        rectTransform.anchorMin = anchorMin;
        rectTransform.anchorMax = anchorMax;
        rectTransform.pivot = pivot;
        rectTransform.localRotation = Quaternion.Euler(rotation);
        rectTransform.localScale = scale;
    }

}