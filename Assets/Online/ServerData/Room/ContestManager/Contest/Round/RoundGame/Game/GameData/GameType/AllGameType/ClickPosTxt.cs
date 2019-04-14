﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClickPosTxt
{

    #region clickPos

    public static readonly TxtLanguage txtClickPosTitle = new TxtLanguage("Choose Action");
    public static readonly TxtLanguage txtClickPosSetPiece = new TxtLanguage("Set Piece");
    public static readonly TxtLanguage txtClickPosSetHand = new TxtLanguage("Set Hand");
    public static readonly TxtLanguage txtClickPosMove = new TxtLanguage("Move Piece");
    public static readonly TxtLanguage txtClickPosEndTurn = new TxtLanguage("End Turn");
    public static readonly TxtLanguage txtClickPosClear = new TxtLanguage("Clear");
    public static readonly TxtLanguage txtClickPosCreateByFen = new TxtLanguage("Create By Fen");
    public static readonly TxtLanguage txtClickPosFlip = new TxtLanguage("Flip");

    #endregion

    #region setPiece

    public static readonly TxtLanguage txtSetPieceTitle = new TxtLanguage("Choose Piece To Set");

    public const float setPieceChoosePieceAdapterHeight = 60;
    public static readonly UIRectTransform setPieceChoosePieceAdapterRect = new UIRectTransform();

    #endregion

    #region setHand

    public static readonly TxtLanguage txtSetHandTitle = new TxtLanguage("Place Pieces In Hand");
    public static readonly TxtLanguage txtEdtPieceCountPlaceHolder = new TxtLanguage("Enter new piece count...");
    public static readonly TxtLanguage txtSet = new TxtLanguage("Set");

    public static readonly UIRectTransform setHandChoosePieceAdapterRect = new UIRectTransform();

    #endregion

    #region moveOrChoose

    public static readonly TxtLanguage txtMoveOrChooseTitle = new TxtLanguage("Move Or Choose");
    public static readonly TxtLanguage txtMove = new TxtLanguage("Move");

    #endregion

    #region clickDestChoose

    public static readonly TxtLanguage txtClickDestChooseTitle = new TxtLanguage("Choose Move");

    #endregion

    #region dropPieceUI

    public static readonly TxtLanguage txtDropPieceTitle = new TxtLanguage("Choose Piece To Drop");

    #endregion

    #region Common

    public static readonly TxtLanguage txtChoose = new TxtLanguage("Choose");
    public static readonly TxtLanguage txtCancel = new TxtLanguage("Cancel");

    #endregion

    #region createByFenUI

    public static readonly TxtLanguage txtCreateByFenTitle = new TxtLanguage("Create Board By Fen");
    public static readonly TxtLanguage txtCreateByFenPlaceHolder = new TxtLanguage("Enter the fen...");
    public static readonly TxtLanguage txtCreateByFenCreate = new TxtLanguage("Create");
    public static readonly TxtLanguage txtCreateByFenMove = new TxtLanguage("Create By Fen");

    #endregion

    static ClickPosTxt()
    {
        // clickPos
        {
            txtClickPosTitle.add(Language.Type.vi, "Chọn Hành Động");
            txtClickPosSetPiece.add(Language.Type.vi, "Đặt Quân Cờ");
            txtClickPosSetHand.add(Language.Type.vi, "Cầm Quân Cờ");
            txtClickPosMove.add(Language.Type.vi, "Dời quân cờ");
            txtClickPosEndTurn.add(Language.Type.vi, "Kết Thúc Lượt");
            txtClickPosClear.add(Language.Type.vi, "Xoá sạch");
            txtClickPosCreateByFen.add(Language.Type.vi, "Tạo Bàn Cờ Theo Fen");
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
                setPieceChoosePieceAdapterRect.offsetMin = new Vector2(0.0f, -40.0f - setPieceChoosePieceAdapterHeight);
                setPieceChoosePieceAdapterRect.offsetMax = new Vector2(0.0f, -40.0f);
                setPieceChoosePieceAdapterRect.sizeDelta = new Vector2(0.0f, setPieceChoosePieceAdapterHeight);
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
        // createByFen
        {
            txtCreateByFenTitle.add(Language.Type.vi, "Tạo Bàn Cờ Theo Fen");
            txtCreateByFenPlaceHolder.add(Language.Type.vi, "Điền fen...");
            txtCreateByFenCreate.add(Language.Type.vi, "Tạo");
            txtCreateByFenMove.add(Language.Type.vi, "Tạo Theo Fen");
        }
    }

}