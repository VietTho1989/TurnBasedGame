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
            HaveTransformInterface haveTransform = data.findCallBack<HaveTransformInterface>();
            if (haveTransform != null)
            {
                RectTransform rectTransform = (RectTransform)haveTransform.getTransform();
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
                Debug.LogError("haveTransform null");
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
        else
        {
            Debug.LogError("unknown rect type");
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
        } else if (rectTransform.anchorMin.y == 0.0f
            && rectTransform.anchorMax.y == 0.0f
            && rectTransform.pivot.y == 0.0f)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, posY);
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, posY);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, rectTransform.sizeDelta.y + posY);
        }
        else
        {
            Debug.LogError("unknown rect type");
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
            HaveTransformInterface haveTransform = data.findCallBack<HaveTransformInterface>();
            if (haveTransform != null)
            {
                RectTransform rectTransform = (RectTransform)haveTransform.getTransform();
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
                Debug.LogError("haveTransform null");
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
            HaveTransformInterface haveTransform = data.findCallBack<HaveTransformInterface>();
            if (haveTransform != null)
            {
                RectTransform rectTransform = (RectTransform)haveTransform.getTransform();
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
                Debug.LogError("haveTransform null");
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
        } else if (rectTransform.anchorMin.y == 0.5f
            && rectTransform.anchorMax.y == 0.5f
            && rectTransform.pivot.y == 0.5f)
        {
            // offsetMin: (-180.0, -240.0); offsetMax: (180.0, 240.0); sizeDelta: (360.0, 480.0)
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x, -size / 2.0f);
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.x, size / 2.0f);
            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, size);
        }
        else
        {
            Debug.LogError("unknown rect type");
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
            HaveTransformInterface haveTransform = data.findCallBack<HaveTransformInterface>();
            if (haveTransform != null)
            {
                haveTransform.getTransform().SetSiblingIndex(siblingIndex);
                ret = true;
            }
            else
            {
                Debug.LogError("haveTransform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    public static bool SetActive(Data data, bool isActive)
    {
        bool ret = false;
        if (data != null)
        {
            HaveTransformInterface haveTransform = data.findCallBack<HaveTransformInterface>();
            if (haveTransform != null)
            {
                haveTransform.getTransform().gameObject.SetActive(isActive);
                ret = true;
            }
            else
            {
                Debug.LogError("haveTransform null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return ret;
    }

    #endregion

    public enum ShowType
    {
        Normal,
        HeadLess,
        OnlyHead
    }

}