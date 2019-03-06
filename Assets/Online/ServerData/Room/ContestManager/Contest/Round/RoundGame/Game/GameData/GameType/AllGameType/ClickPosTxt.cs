using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickPosTxt
{

    #region clickPos

    public static readonly TxtLanguage txtClickPosTitle = new TxtLanguage();
    public const string DefaultTitle = "Choose Action";

    public static readonly TxtLanguage txtSetPiece = new TxtLanguage();
    public const string DefaultSetPiece = "Set piece";

    public static readonly TxtLanguage txtSetHand = new TxtLanguage();
    public const string DefaultSetHand = "Set hand";

    public static readonly TxtLanguage txtMove = new TxtLanguage();
    public const string DefaultMove = "Move piece";

    public static readonly TxtLanguage txtEndTurn = new TxtLanguage();
    public const string DefaultEndTurn = "End turn";

    public static readonly TxtLanguage txtClear = new TxtLanguage();
    public const string DefaultClear = "Clear";

    #endregion

    #region setPiece

    public static readonly TxtLanguage txtSetPieceTitle = new TxtLanguage();
    public const string DefaultSetPieceTitle = "Choose Piece To Set";

    public static readonly TxtLanguage txtChoose = new TxtLanguage();
    public const string DefaultChoose = "Choose";

    public static readonly UIRectTransform setPieceChoosePieceAdapterRect = new UIRectTransform();

    #endregion

    static ClickPosTxt()
    {
        // txt
        {
            // clickPos
            {
                txtClickPosTitle.add(Language.Type.vi, "Chọn Hành Động");
                txtSetPiece.add(Language.Type.vi, "Đặt quân cờ");
                txtSetHand.add(Language.Type.vi, "Cầm quân cờ");
                txtMove.add(Language.Type.vi, "Dời quân cờ");
                txtEndTurn.add(Language.Type.vi, "Kết thúc lượt");
                txtClear.add(Language.Type.vi, "Xoá sạch");
            }
            // setPiece
            {
                txtSetPieceTitle.add(Language.Type.vi, "Chọn Quân Cờ Để Đặt");
                txtChoose.add(Language.Type.vi, "Chọn");
            }
        }
        // adapterRect
        {
            // anchoredPosition: (0.0, -40.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
            // offsetMin: (0.0, -100.0); offsetMax: (0.0, -40.0); sizeDelta: (0.0, 60.0);
            setPieceChoosePieceAdapterRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
            setPieceChoosePieceAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
            setPieceChoosePieceAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
            setPieceChoosePieceAdapterRect.pivot = new Vector2(0.5f, 1.0f);
            setPieceChoosePieceAdapterRect.offsetMin = new Vector2(0.0f, -100.0f);
            setPieceChoosePieceAdapterRect.offsetMax = new Vector2(0.0f, -40.0f);
            setPieceChoosePieceAdapterRect.sizeDelta = new Vector2(0.0f, 60.0f);
        }
    }

}