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

    public UIRectTransform(UIRectTransform rectTransform, float posY)
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
        // posY
        this.setPosY(posY);
    }

    public override string ToString()
    {
        return "anchoredPosition: " + this.anchoredPosition
            + "; anchorMin: " + this.anchorMin
            + "; anchorMax: " + this.anchorMax
            + "; pivot: " + this.pivot
             + "; offsetMin: " + this.offsetMin
             + "; offsetMax: " + this.offsetMax
            + "; sizeDelta: " + this.sizeDelta
            + "; localRotation: " + this.rotation
            + "; localScale: " + this.scale;
    }

    public static string PrintRectTransform(RectTransform rectTransform)
    {
        return "anchoredPosition: " + rectTransform.anchoredPosition
            + "; anchorMin: " + rectTransform.anchorMin
            + "; anchorMax: " + rectTransform.anchorMax
            + "; pivot: " + rectTransform.pivot
             + "; offsetMin: " + rectTransform.offsetMin
             + "; offsetMax: " + rectTransform.offsetMax
            + "; sizeDelta: " + rectTransform.sizeDelta
            + "; localRotation: " + rectTransform.localRotation
            + "; localScale: " + rectTransform.localScale;
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

    public static bool Set(Data data, UIRectTransform uiRectTransform)
    {
        bool ret = false;
        if (data != null)
        {
            RectTransform rectTransform = (RectTransform)Data.FindTransform(data);
            if (rectTransform != null)
            {
                if (uiRectTransform != null)
                {
                    uiRectTransform.set(rectTransform);
                    ret = true;
                }
                else
                {
                    Debug.LogError("uiRectTransform null");
                }
            }
            else
            {
                Debug.LogError("rectTransform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    public void setPosY(float posY)
    {
        // RequestIntLongFloatRect, RequestEnumRect
        if (this.anchorMin.y == 1.0f
            && this.anchorMax.y == 1.0f
            && this.pivot.y == 1.0f)
        {
            this.anchoredPosition.y = -posY;
            this.offsetMin.y = -this.sizeDelta.y - posY;
            this.offsetMax.y = -posY;
        }
        else if (this.anchorMin.y == 0.5f
            && this.anchorMax.y == 0.5f
            && this.pivot.y == 0.5f)
        {
            this.anchoredPosition.y = -posY;
            this.offsetMin.y = -posY - this.sizeDelta.y / 2.0f;
            this.offsetMax.y = -posY + this.sizeDelta.y / 2.0f;
        }
        else
        {
            Debug.LogError("unknown rect type: " + this);
        }
    }

    public static void SetPosY(RectTransform rectTransform, float posY)
    {
        if (rectTransform.anchorMin.y == 1.0f
            && rectTransform.anchorMax.y == 1.0f
            && rectTransform.pivot.y == 1.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -posY);
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -rectTransform.sizeDelta.y - posY);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -posY);
        }
        else if (rectTransform.anchorMin.y == 0.0f
          && rectTransform.anchorMax.y == 0.0f
          && rectTransform.pivot.y == 0.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, posY);
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, posY);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, rectTransform.sizeDelta.y + posY);
        }
        else
        {
            Debug.LogError("unknown rect type: " + UIRectTransform.PrintRectTransform(rectTransform) + ", " + rectTransform.gameObject);
        }
    }

    /**
     * get height
     * */
    public static float SetPosY(Data data, UIRectTransform originRect, float posY)
    {
        float ret = 0;
        if (data != null)
        {
            RectTransform rectTransform = (RectTransform)Data.FindTransform(data);
            if (rectTransform != null)
            {
                if (originRect != null)
                {
                    originRect.set(rectTransform);
                    SetPosY(rectTransform, posY);
                    ret = rectTransform.rect.height;
                }
                else
                {
                    Debug.LogError("originRect null");
                }
            }
            else
            {
                Debug.LogError("rectTransform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    /**
     * get height
     * */
    public static float SetPosY(Data data, float posY)
    {
        float ret = 0;
        if (data != null)
        {
            RectTransform rectTransform = (RectTransform)Data.FindTransform(data);
            if (rectTransform != null)
            {
                SetPosY(rectTransform, posY);
                ret = rectTransform.rect.height;
            }
            else
            {
                Debug.LogError("rectTransform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    public static float GetHeight(Data data)
    {
        float ret = 0;
        if (data != null)
        {
            RectTransform rectTransform = (RectTransform)Data.FindTransform(data);
            if (rectTransform != null)
            {
                ret = rectTransform.rect.height;
            }
            else
            {
                Debug.LogError("rectTransform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    /*public static void SetSize(RectTransform rectTransform, Vector2 size)
    {
        Vector2 oldSize = rectTransform.rect.size;
        Vector2 deltaSize = size - oldSize;

        rectTransform.offsetMin = rectTransform.offsetMin - new Vector2(
            deltaSize.x * rectTransform.pivot.x,
            deltaSize.y * rectTransform.pivot.y);
        rectTransform.offsetMax = rectTransform.offsetMax + new Vector2(
            deltaSize.x * (1f - rectTransform.pivot.x),
            deltaSize.y * (1f - rectTransform.pivot.y));
    }

    public static void SetWidth(RectTransform rectTransform, float size)
    {
        SetSize(rectTransform, new Vector2(size, rectTransform.rect.size.y));
    }

    public static void SetHeight(RectTransform rectTransform, float size)
    {
        Debug.LogError("setHeight: " + size);
        SetSize(rectTransform, new Vector2(rectTransform.rect.size.x, size));
    }*/

    public static void SetHeight(RectTransform rectTransform, float size)
    {
        // Debug.LogError("setHeight: " + size);
        if (rectTransform.anchorMin.y == 1.0f
            && rectTransform.anchorMax.y == 1.0f
            && rectTransform.pivot.y == 1.0f)
        {
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, rectTransform.anchoredPosition.y - size);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);
        }
        else if (rectTransform.anchorMin.y == 0.5f
          && rectTransform.anchorMax.y == 0.5f
          && rectTransform.pivot.y == 0.5f)
        {
            // offsetMin: (-180.0, -240.0); offsetMax: (180.0, 240.0); sizeDelta: (360.0, 480.0)
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -size / 2.0f);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, size / 2.0f);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);
        }
        else if (rectTransform.anchorMin.y == 0.0f
           && rectTransform.anchorMax.y == 0.0f
           && rectTransform.pivot.y == 0.0f)
        {
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, rectTransform.anchoredPosition.y - size);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);
        }
        else
        {
            Debug.LogError("unknown rect type: " + UIRectTransform.PrintRectTransform(rectTransform));
        }
    }

    public static UIRectTransform CreateFullRect(float left, float right, float top, float bottom)
    {
        UIRectTransform ret = new UIRectTransform(UIConstants.FullParent);
        {
            // left 5, right 10, top 30, bottom 60
            // anchoredPosition: (-2.5, 15.0); offsetMin: (5.0, 60.0); 
            // offsetMax: (-10.0, -30.0); sizeDelta: (-15.0, -90.0);
            ret.anchoredPosition = new Vector3((left - right) / 2.0f, (bottom - top) / 2.0f, 0);
            ret.offsetMin = new Vector2(left, bottom);
            ret.offsetMax = new Vector2(-right, -top);
            ret.sizeDelta = new Vector2(-(left + right), -(top + bottom));
        }
        return ret;
    }

    public static UIRectTransform CreateCenterRect(float width, float height)
    {
        UIRectTransform ret = new UIRectTransform();
        {
            ret.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
            ret.anchorMin = new Vector2(0.5f, 0.5f);
            ret.anchorMax = new Vector2(0.5f, 0.5f);
            ret.pivot = new Vector2(0.5f, 0.5f);
            ret.offsetMin = new Vector2(-width/2, -height/2);
            ret.offsetMax = new Vector2(width/2, height/2);
            ret.sizeDelta = new Vector2(width, height);
        }
        return ret;
    }

    #region set center posY

    public static void SetCenterPosY(RectTransform rectTransform, float posY)
    {
        if (rectTransform != null)
        {
            // -100
            // anchoredPosition: (0.0, 100.0); offsetMin: (-80.0, 85.0); offsetMax: (80.0, 115.0); sizeDelta: (160.0, 30.0);
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -posY);
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -posY - rectTransform.sizeDelta.y / 2.0f);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, -posY + rectTransform.sizeDelta.y / 2.0f);
        }
        else
        {
            Debug.LogError("rectTransform null");
        }
    }

    #endregion

    #region siblingIndex

    public static bool SetSiblingIndex(Data data, int siblingIndex)
    {
        bool ret = false;
        if (data != null)
        {
            Transform transform = Data.FindTransform(data);
            if (transform != null)
            {
                transform.SetSiblingIndex(siblingIndex);
                ret = true;
            }
            else
            {
                Debug.LogError("transform null");
            }
        }
        else
        {
            // Debug.LogError("data null");
        }
        return ret;
    }

    public static bool SetActive(Data data, bool isActive)
    {
        bool ret = false;
        if (data != null)
        {
            Transform transform = Data.FindTransform(data);
            if (transform != null)
            {
                transform.gameObject.SetActive(isActive);
                ret = true;
            }
            else
            {
                Debug.LogError("transform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    #endregion

    public static void GetMargin(RectTransform rectTransform, out float left, out float right, out float top, out float bottom)
    {
        if(rectTransform.anchorMin == new Vector2(0.5f, 0.5f) && rectTransform.anchorMax == new Vector2(0.5f, 0.5f) && rectTransform.pivot == new Vector2(0.5f, 0.5f))
        {
            left = rectTransform.rect.xMin + rectTransform.anchoredPosition.x;
            right = rectTransform.rect.xMax + rectTransform.anchoredPosition.x;
            top = rectTransform.rect.yMin + rectTransform.anchoredPosition.y;
            bottom = rectTransform.rect.yMax + rectTransform.anchoredPosition.y;
        }
        else
        {
            left = rectTransform.rect.xMin;
            right = rectTransform.rect.xMax;
            top = rectTransform.rect.yMin;
            bottom = rectTransform.rect.yMax;
        }
    }

    public enum ShowType
    {
        Normal,
        HeadLess,
        OnlyHead
    }

}