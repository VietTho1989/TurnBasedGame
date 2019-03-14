using UnityEngine;
using System.Collections;

public static class UIConstants
{

    public static readonly UIRectTransform FullParent = new UIRectTransform();

    public static readonly Color NormalTitleColor = new Color(50 / 255f, 50 / 255f, 50 / 255f);
    public static readonly Color DifferentIndicatorColor = Color.red;

    public const float HeaderHeight = 30;

    public const float DefaultMiniGameDataUISize = 120;
    public const float DefaultMiniGameDataUIPadding = 20;

    public const float ItemHeight = 60;

    public static readonly UIRectTransform MiniGameDataUIRect = new UIRectTransform();
    public static readonly UIRectTransform PostureMiniGameDataUIRect = new UIRectTransform();

    #region RequestBool

    public const float RequestBoolDim = 40;
    public static readonly UIRectTransform RequestBoolRect = new UIRectTransform();

    #endregion

    #region RequestEnum

    public const float RequestEnumHeight = 30;
    public static readonly UIRectTransform RequestEnumRect = new UIRectTransform();

    #endregion

    #region RequestInt

    public const float RequestHeight = 50;
    public static readonly UIRectTransform RequestRect = new UIRectTransform();

    #endregion

    #region requestChange

    public static readonly UIRectTransform RequestChangeFullRect = new UIRectTransform();
    public static readonly UIRectTransform RequestChangePartRect = new UIRectTransform();

    #endregion

    static UIConstants()
    {
        // FullParent
        {
            // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 1.0); pivot: (0.5, 0.5); 
            // offsetMin: (0.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (0.0, 0.0);
            FullParent.anchoredPosition = Vector2.zero;
            FullParent.anchorMin = Vector2.zero;
            FullParent.anchorMax = new Vector2(1.0f, 1.0f);
            FullParent.pivot = new Vector2(0.5f, 0.5f);
            FullParent.offsetMin = Vector2.zero;
            FullParent.offsetMax = Vector2.zero;
            FullParent.sizeDelta = Vector2.zero;
        }

        // MiniGameDataUIRect
        {
            float padding = DefaultMiniGameDataUIPadding;
            MiniGameDataUIRect.anchoredPosition = new Vector2(0.0f, -HeaderHeight - padding);
            MiniGameDataUIRect.anchorMin = new Vector2(0.5f, 1f);
            MiniGameDataUIRect.anchorMax = new Vector2(0.5f, 1f);
            MiniGameDataUIRect.pivot = new Vector2(0.5f, 1f);
            MiniGameDataUIRect.offsetMin = new Vector2(-(DefaultMiniGameDataUISize - 2*padding)/2.0f, -150.0f);
            MiniGameDataUIRect.offsetMax = new Vector2((DefaultMiniGameDataUISize - padding) / 2.0f, -HeaderHeight - padding);
            MiniGameDataUIRect.sizeDelta = new Vector2(DefaultMiniGameDataUISize - 2*padding, DefaultMiniGameDataUISize - 2*padding);
        }
        // PostureGameDataUIRect
        {
            PostureMiniGameDataUIRect = new UIRectTransform(MiniGameDataUIRect);
            PostureMiniGameDataUIRect.setPosY(105.0f);
        }

        float paddingLeft = 90;
        float paddingRight = 10;
        // RequestBoolRect
        { 
            RequestBoolRect.anchoredPosition = new Vector3(paddingLeft, 0, 0);
            RequestBoolRect.anchorMin = new Vector2(0.0f, 1.0f);
            RequestBoolRect.anchorMax = new Vector2(0.0f, 1.0f);
            RequestBoolRect.pivot = new Vector2(0.0f, 1.0f);
            RequestBoolRect.offsetMin = new Vector2(paddingLeft, -paddingLeft - RequestBoolDim);
            RequestBoolRect.offsetMax = new Vector2(paddingLeft + RequestBoolDim, -paddingLeft);
            RequestBoolRect.sizeDelta = new Vector2(RequestBoolDim, RequestBoolDim);
        }
        // RequestEnumRect
        {
            RequestEnumRect.anchoredPosition = new Vector3((paddingLeft - paddingRight) / 2, 0f, 0f);
            RequestEnumRect.anchorMin = new Vector2(0.0f, 1.0f);
            RequestEnumRect.anchorMax = new Vector2(1.0f, 1.0f);
            RequestEnumRect.pivot = new Vector2(0.5f, 1f);
            RequestEnumRect.offsetMin = new Vector2(paddingLeft, -RequestEnumHeight);
            RequestEnumRect.offsetMax = new Vector2(-paddingRight, 0);
            RequestEnumRect.sizeDelta = new Vector2(-paddingLeft - paddingRight, RequestEnumHeight);
        }
        // RequestIntLongFloatRect
        {
            RequestRect.anchoredPosition = new Vector3((paddingLeft - paddingRight) / 2, 0f, 0f);
            RequestRect.anchorMin = new Vector2(0.0f, 1.0f);
            RequestRect.anchorMax = new Vector2(1.0f, 1.0f);
            RequestRect.pivot = new Vector2(0.5f, 1f);
            RequestRect.offsetMin = new Vector2(paddingLeft, -RequestHeight);
            RequestRect.offsetMax = new Vector2(-paddingRight, 0);
            RequestRect.sizeDelta = new Vector2(-paddingLeft - paddingRight, RequestHeight);
        }

        // RequestChangeFullRect
        {
            // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.5); anchorMax: (1.0, 0.5); pivot: (0.5, 0.5);
            // offsetMin: (0.0, -15.0); offsetMax: (0.0, 15.0); sizeDelta: (0.0, 30.0);
            RequestChangeFullRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
            RequestChangeFullRect.anchorMin = new Vector2(0.0f, 0.5f);
            RequestChangeFullRect.anchorMax = new Vector2(1.0f, 0.5f);
            RequestChangeFullRect.pivot = new Vector2(0.5f, 0.5f);
            RequestChangeFullRect.offsetMin = new Vector2(0.0f, -15.0f);
            RequestChangeFullRect.offsetMax = new Vector2(0.0f, 15.0f);
            RequestChangeFullRect.sizeDelta = new Vector2(0.0f, 30.0f);
        }
        // RequestChangePartRect
        {
            // anchoredPosition: (2.5, 0.0); anchorMin: (0.5, 0.5); anchorMax: (1.0, 0.5); pivot: (0.5, 0.5);
            // offsetMin: (5.0, -15.0); offsetMax: (0.0, 15.0); sizeDelta: (-5.0, 30.0);
            RequestChangePartRect.anchoredPosition = new Vector3(2.5f, 0.0f, 0.0f);
            RequestChangePartRect.anchorMin = new Vector2(0.5f, 0.5f);
            RequestChangePartRect.anchorMax = new Vector2(1.0f, 0.5f);
            RequestChangePartRect.pivot = new Vector2(0.5f, 0.5f);
            RequestChangePartRect.offsetMin = new Vector2(5.0f, -15.0f);
            RequestChangePartRect.offsetMax = new Vector2(0.0f, 15.0f);
            RequestChangePartRect.sizeDelta = new Vector2(-5.0f, 30.0f);
        }
    }

}