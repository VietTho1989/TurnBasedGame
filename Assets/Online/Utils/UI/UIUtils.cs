﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityImageLoader;

public class UIUtils
{

    #region UrlImageView

    public static void SetUrlImageView(Image img, string url, string loadingPath, string errorPath)
    {
        DisplayOption.Builder builder = new DisplayOption.Builder();
        {
            builder.isMemoryCache = true;
            builder.isDiscCache = false;
            builder.loadingImagePath = loadingPath;
            builder.loadErrorImagePath = errorPath;
        }
        ImageLoader.GetInstance().Display(img, Setting.get().viewUrlImage.v ? url : "", builder.Build());
    }

    public static void SetUrlImageView(Image img, string url, Sprite loadingSprite, Sprite errorSprite)
    {
        DisplayOption.Builder builder = new DisplayOption.Builder();
        {
            builder.isMemoryCache = true;
            builder.isDiscCache = false;
            builder.loadingSprite = loadingSprite;
            builder.loadErrorSprite = errorSprite;
        }
        ImageLoader.GetInstance().Display(img, Setting.get().viewUrlImage.v ? url : "", builder.Build());
    }

    #endregion

    public static UIBehavior<T> Instantiate<T>(T data, UIBehavior<T> prefab, Transform transform) where T : Data
    {
        if (data != null)
        {
            if (transform != null && prefab != null)
            {
                UIBehavior<T> old = data.findCallBack<UIBehavior<T>>(prefab.GetType());
                if (old == null)
                {
                    /*UIBehavior<T> newUI = TrashMan.normalSpawnUI (prefab, transform, data);
					return newUI;*/
                    UIBehavior<T> newUI = TrashMan.normalSpawn(prefab, transform);
                    newUI.setData(data);
                    return newUI;
                }
                else
                {
                    Debug.LogError("already have");
                    return old;
                }
            }
            else
            {
                Debug.LogError("transform or prefab null");
                return null;
            }
        }
        else
        {
            Debug.LogError("error, Instantiate: why data null");
            return null;
        }
    }

    public static UIBehavior<T> Instantiate<T>(T data, UIBehavior<T> prefab, Transform transform, UIRectTransform uiRectTransform) where T : Data
    {
        if (data != null)
        {
            if (transform != null && prefab != null)
            {
                UIBehavior<T> old = data.findCallBack<UIBehavior<T>>(prefab.GetType());
                if (old == null)
                {
                    /*UIBehavior<T> newUI = TrashMan.normalSpawnUI (prefab, transform, data);
                    return newUI;*/
                    UIBehavior<T> newUI = TrashMan.normalSpawn(prefab, transform);
                    newUI.setData(data);
                    uiRectTransform.set((RectTransform)newUI.transform);
                    return newUI;
                }
                else
                {
                    Debug.LogError("already have");
                    return old;
                }
            }
            else
            {
                Debug.LogError("transform or prefab null");
                return null;
            }
        }
        else
        {
            Debug.LogError("error, Instantiate: why data null");
            return null;
        }
    }

    public static UIBehavior<T> Instantiate<T>(T data, UIBehavior<T> prefab, Transform transform, int siblingIndex) where T : Data
    {
        if (data != null)
        {
            if (transform != null && prefab != null)
            {
                UIBehavior<T> old = data.findCallBack<UIBehavior<T>>(prefab.GetType());
                if (old == null)
                {
                    UIBehavior<T> newUI = TrashMan.normalSpawn(prefab, transform);
                    newUI.setData(data);
                    newUI.transform.SetSiblingIndex(siblingIndex);
                    return newUI;
                }
                else
                {
                    Debug.LogError("already have");
                    return old;
                }
            }
            else
            {
                Debug.LogError("transform null");
                return null;
            }
        }
        else
        {
            Debug.LogError("error, Instantiate: why data null");
            return null;
        }
    }

    #region dropDown

    public static void RefreshDropDownOptions(Dropdown drValue, string[] options)
    {
        if (drValue.options.Count != options.Length)
        {
            drValue.options.Clear();
            for (int i = 0; i < options.Length; i++)
            {
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                {
                    optionData.text = options[i];
                }
                drValue.options.Add(optionData);
            }
        }
        else
        {
            // options
            for (int i = 0; i < options.Length; i++)
            {
                drValue.options[i].text = options[i];
            }
        }
    }

    public static void RefreshDropDownOptions(Dropdown drValue, List<string> options)
    {
        if (drValue.options.Count != options.Count)
        {
            drValue.options.Clear();
            for (int i = 0; i < options.Count; i++)
            {
                Dropdown.OptionData optionData = new Dropdown.OptionData();
                {
                    optionData.text = options[i];
                }
                drValue.options.Add(optionData);
            }
        }
        else
        {
            // options
            for (int i = 0; i < options.Count; i++)
            {
                drValue.options[i].text = options[i];
            }
        }
    }

    #endregion

    #region scale

    public static void SetGlobalScale(Transform transform, Vector3 globalScale)
    {
        if (transform.parent != null)
        {
            /*Vector3 parentScale = transform.parent.lossyScale;
            {
                if (parentScale.x == 0)
                {
                    Debug.LogError("parent scale x = 0");
                    parentScale.x = 1;
                }
                if (parentScale.y == 0)
                {
                    Debug.LogError("parent scale y = 0");
                    parentScale.y = 1;
                }
                if (parentScale.z == 0)
                {
                    Debug.LogError("parent scale x = 0");
                    parentScale.z = 1;
                }
            }
            transform.localScale = new Vector3(1 / parentScale.x, 1 / parentScale.y, 1 / parentScale.z);*/

            Vector3 localScale = transform.parent.InverseTransformVector(globalScale);
            transform.localScale = localScale;
        }
        else
        {
            Debug.LogError("transform parent null");
            transform.localScale = globalScale;
        }
    }

    #endregion

    public static void UpdateTransformData(Data data)
    {
        if (data != null)
        {
            // find
            HaveTransformData ui = data.findTransformData();
            // process
            if (ui != null)
            {
                ui.setDirtyForTransformData();
                // updateTransform
                TransformData transformData = ui.getTransformData();
                RectTransform transform = (RectTransform)ui.getUITransform();
                if (transformData != null && transform != null)
                {
                    transformData.update(transform);
                    Debug.LogError("haveUI set dirty: " + ui + ", " + transformData + ", " + transform);
                }
                else
                {
                    Debug.LogError("transformData, transform null");
                }
            }
            else
            {
                Debug.LogError("ui null");
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

    #region UI

    public static void SetHeaderPosition(Text lbTitle, UIRectTransform.ShowType showType, ref float deltaY)
    {
        switch (showType)
        {
            case UIRectTransform.ShowType.Normal:
                {
                    float headerHeight = Setting.get().getButtonSize();
                    if (lbTitle != null)
                    {
                        lbTitle.gameObject.SetActive(true);
                        UIRectTransform.SetHeight(lbTitle.rectTransform, headerHeight);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    deltaY += headerHeight;
                }
                break;
            case UIRectTransform.ShowType.HeadLess:
                {
                    if (lbTitle != null)
                    {
                        lbTitle.gameObject.SetActive(false);
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                }
                break;
            case UIRectTransform.ShowType.OnlyHead:
                break;
            default:
                Debug.LogError("unknown type: " + showType);
                break;
        }
    }

    #region setLabelContentPosition

    public static void SetLabelContentPosition(Text label, RequestChangeBoolUI.UIData requestChangeBoolUIData, ref float deltaY)
    {
        if (requestChangeBoolUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeBoolUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPosition(Text label, RequestChangeEnumUI.UIData requestChangeEnumUIData, ref float deltaY)
    {
        if (requestChangeEnumUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeEnumUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPosition(Text label, RequestChangeFloatUI.UIData requestChangeFloatUIData, ref float deltaY)
    {
        if (requestChangeFloatUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeFloatUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPosition(Text label, RequestChangeIntUI.UIData requestChangeIntUIData, ref float deltaY)
    {
        if (requestChangeIntUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeIntUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPosition(Text label, RequestChangeLongUI.UIData requestChangeLongUIData, ref float deltaY)
    {
        if (requestChangeLongUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeLongUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPosition(Text label, RequestChangeStringUI.UIData requestChangeStringUIData, ref float deltaY)
    {
        if (requestChangeStringUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeStringUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    #endregion

    #region setLabelPositionWithBg

    public static void SetLabelContentPositionBg(Text label, RequestChangeBoolUI.UIData requestChangeBoolUIData, ref float deltaY, ref float bgHeight)
    {
        if (requestChangeBoolUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeBoolUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            bgHeight += UIConstants.ItemHeight;
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPositionBg(Text label, RequestChangeEnumUI.UIData requestChangeEnumUIData, ref float deltaY, ref float bgHeight)
    {
        if (requestChangeEnumUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeEnumUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            bgHeight += UIConstants.ItemHeight;
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPositionBg(Text label, RequestChangeFloatUI.UIData requestChangeFloatUIData, ref float deltaY, ref float bgHeight)
    {
        if (requestChangeFloatUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeFloatUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            bgHeight += UIConstants.ItemHeight;
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPositionBg(Text label, RequestChangeIntUI.UIData requestChangeIntUIData, ref float deltaY, ref float bgHeight)
    {
        if (requestChangeIntUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeIntUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            bgHeight += UIConstants.ItemHeight;
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPositionBg(Text label, RequestChangeLongUI.UIData requestChangeLongUIData, ref float deltaY, ref float bgHeight)
    {
        if (requestChangeLongUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeLongUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
            bgHeight += UIConstants.ItemHeight;
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    public static void SetLabelContentPositionBg(Text label, RequestChangeStringUI.UIData requestChangeStringUIData, ref float deltaY, ref float bgHeight)
    {
        if (requestChangeStringUIData != null)
        {
            if (label != null)
            {
                label.gameObject.SetActive(true);
                UIRectTransform.SetPosY(label.rectTransform, deltaY);
            }
            else
            {
                Debug.LogError("label null");
            }
            UIRectTransform.SetPosY(requestChangeStringUIData, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            bgHeight += UIConstants.ItemHeight;
            deltaY += UIConstants.ItemHeight;
        }
        else
        {
            if (label != null)
            {
                label.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("label null");
            }
        }
    }

    #endregion

    #endregion

}