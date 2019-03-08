using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickPosTxt
{

    #region clickPos

    public static readonly TxtLanguage txtClickPosTitle = new TxtLanguage();
    public const string DefaultClickPosTitle = "Choose Action";

    public static readonly TxtLanguage txtClickPosSetPiece = new TxtLanguage();
    public const string DefaultClickPosSetPiece = "Set piece";

    public static readonly TxtLanguage txtClickPosSetHand = new TxtLanguage();
    public const string DefaultClickPosSetHand = "Set hand";

    public static readonly TxtLanguage txtClickPosMove = new TxtLanguage();
    public const string DefaultClickPosMove = "Move piece";

    public static readonly TxtLanguage txtClickPosEndTurn = new TxtLanguage();
    public const string DefaultClickPosEndTurn = "End turn";

    public static readonly TxtLanguage txtClickPosClear = new TxtLanguage();
    public const string DefaultClickPosClear = "Clear";

    public static readonly TxtLanguage txtClickPosFlip = new TxtLanguage();
    public const string DefaultClickPosFlip = "Flip";

    #endregion

    #region setPiece

    public static readonly TxtLanguage txtSetPieceTitle = new TxtLanguage();
    public const string DefaultSetPieceTitle = "Choose Piece To Set";

    public static readonly UIRectTransform setPieceChoosePieceAdapterRect = new UIRectTransform();

    #endregion

    #region setHand

    public static readonly TxtLanguage txtSetHandTitle = new TxtLanguage();
    public const string DefaultSetHandTitle = "Place Pieces In Hand";

    public static readonly TxtLanguage txtEdtPieceCountPlaceHolder = new TxtLanguage();
    public const string DefaultEdtPieceCountPlaceHolder = "Enter new piece count...";

    public static readonly TxtLanguage txtSet = new TxtLanguage();
    public const string DefaultSet = "Set";

    public static readonly UIRectTransform setHandChoosePieceAdapterRect = new UIRectTransform();

    #endregion

    #region moveOrChoose

    public static readonly TxtLanguage txtMoveOrChooseTitle = new TxtLanguage();
    public const string DefaultMoveOrChooseTitle = "Move Or Choose";

    public static readonly TxtLanguage txtMove = new TxtLanguage();
    public const string DefaultMove = "Move";

    #endregion

    #region clickDestChoose

    public static readonly TxtLanguage txtClickDestChooseTitle = new TxtLanguage();
    public const string DefaultClickDestChooseTitle = "Choose Move";

    #endregion

    #region dropPieceUI

    public static readonly TxtLanguage txtDropPieceTitle = new TxtLanguage();
    public const string DefaultDropPieceTitle = "Choose Piece To Drop";

    #endregion

    #region Common

    public static readonly TxtLanguage txtChoose = new TxtLanguage();
    public const string DefaultChoose = "Choose";

    public static readonly TxtLanguage txtCancel = new TxtLanguage();
    public const string DefaultCancel = "Cancel";

    #endregion

    static ClickPosTxt()
    {
        // clickPos
        {
            txtClickPosTitle.add(Language.Type.vi, "Chọn Hành Động");
            txtClickPosSetPiece.add(Language.Type.vi, "Đặt quân cờ");
            txtClickPosSetHand.add(Language.Type.vi, "Cầm quân cờ");
            txtClickPosMove.add(Language.Type.vi, "Dời quân cờ");
            txtClickPosEndTurn.add(Language.Type.vi, "Kết thúc lượt");
            txtClickPosClear.add(Language.Type.vi, "Xoá sạch");
            txtClickPosFlip.add(Language.Type.vi, "Lật");
        }
        // setPiece
        {
            txtSetPieceTitle.add(Language.Type.vi, "Chọn Quân Cờ Để Đặt");
            // rect
            {
                setPieceChoosePieceAdapterRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
                setPieceChoosePieceAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                setPieceChoosePieceAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                setPieceChoosePieceAdapterRect.pivot = new Vector2(0.5f, 1.0f);
                setPieceChoosePieceAdapterRect.offsetMin = new Vector2(0.0f, -100.0f);
                setPieceChoosePieceAdapterRect.offsetMax = new Vector2(0.0f, -40.0f);
                setPieceChoosePieceAdapterRect.sizeDelta = new Vector2(0.0f, 60.0f);
            }
        }
        // setHand
        {
            txtClickPosSetHand.add(Language.Type.vi, "Cầm Quân Cờ");
            txtEdtPieceCountPlaceHolder.add(Language.Type.vi, "Điền số quân cờ mới vào...");
            txtSet.add(Language.Type.vi, "Đặt");
            // rect
            {
                setHandChoosePieceAdapterRect.anchoredPosition = new Vector3(0.0f, -40.0f, 0.0f);
                setHandChoosePieceAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                setHandChoosePieceAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                setHandChoosePieceAdapterRect.pivot = new Vector2(0.5f, 1.0f);
                setHandChoosePieceAdapterRect.offsetMin = new Vector2(0.0f, -100.0f);
                setHandChoosePieceAdapterRect.offsetMax = new Vector2(0.0f, -40.0f);
                setHandChoosePieceAdapterRect.sizeDelta = new Vector2(0.0f, 60.0f);
            }
        }
        // moveOrChoose
        {
            txtMoveOrChooseTitle.add(Language.Type.vi, "Di Chuyển Hay Chọn");
            txtMove.add(Language.Type.vi, "Di Chuyển");
        }
        // clickDestChoose
        {
            txtClickDestChooseTitle.add(Language.Type.vi, "Chọn Nước Đi");
        }
        // dropPieceUI
        {
            txtDropPieceTitle.add(Language.Type.vi, "Chọn Quân Cờ Để Đặt");
        }
        // Common
        {
            txtChoose.add(Language.Type.vi, "Chọn");
            txtCancel.add(Language.Type.vi, "Huỷ Bỏ");
        }
    }

}