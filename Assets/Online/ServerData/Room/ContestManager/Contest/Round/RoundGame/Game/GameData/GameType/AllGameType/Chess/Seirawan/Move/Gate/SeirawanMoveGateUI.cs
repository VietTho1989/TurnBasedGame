using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
    public class SeirawanMoveGateUI : UIBehavior<SeirawanMoveGateUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            #region Constructor

            public enum Property
            {

            }

            public UIData() : base()
            {

            }

            #endregion

        }

        #endregion

        #region Refresh

        public UILineRenderer imgGating;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (imgGating != null)
                    {
                        // find pieceType
                        Common.Color color = Common.Color.WHITE;
                        Common.PieceType pieceType = Common.PieceType.HAWK;
                        bool isHint = false;
                        {
                            SeirawanMoveUI.UIData seirawanMoveUIData = this.data.findDataInParent<SeirawanMoveUI.UIData>();
                            if (seirawanMoveUIData != null)
                            {
                                SeirawanMove seirawanMove = seirawanMoveUIData.seirawanMove.v.data;
                                if (seirawanMove != null)
                                {
                                    if (Common.is_gating(seirawanMove.move.v))
                                    {
                                        pieceType = Common.gating_type(seirawanMove.move.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("why not gating");
                                        color = Common.Color.COLOR_NB;
                                    }
                                }
                                else
                                {
                                    Debug.LogError("seirawanMove null");
                                }
                                isHint = seirawanMoveUIData.isHint.v;
                            }
                            else
                            {
                                Debug.LogError("seirawanMoveUIData null");
                            }
                        }
                        // find color
                        if(color!= Common.Color.COLOR_NB)
                        {
                            SeirawanGameDataUI.UIData seirawanGameDataUIData = this.data.findDataInParent<SeirawanGameDataUI.UIData>();
                            if (seirawanGameDataUIData != null)
                            {
                                BoardUI.UIData boardUIData = seirawanGameDataUIData.board.v;
                                if (boardUIData != null)
                                {
                                    Seirawan seirawan = boardUIData.seirawan.v.data;
                                    if (seirawan != null)
                                    {
                                        if (seirawan.getPlayerIndex() == 0)
                                        {
                                            color = isHint ? Common.Color.WHITE : Common.Color.BLACK;
                                        }
                                        else
                                        {
                                            color = isHint ? Common.Color.BLACK : Common.Color.WHITE;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("seirawan null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("boardUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("seirawanGameDataUIData null");
                            }
                        }
                        // process
                        {
                            // find handUI
                            HandsUI handsUI = null;
                            {
                                SeirawanGameDataUI.UIData seirawanGameDataUIData = this.data.findDataInParent<SeirawanGameDataUI.UIData>();
                                if (seirawanGameDataUIData != null)
                                {
                                    BoardUI.UIData boardUIData = seirawanGameDataUIData.board.v;
                                    if (boardUIData != null)
                                    {
                                        HandsUI.UIData handsUIData = boardUIData.hands.v;
                                        if (handsUIData != null)
                                        {
                                            handsUI = handsUIData.findCallBack<HandsUI>();
                                        }
                                        else
                                        {
                                            Debug.LogError("handsUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("boardUIData null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("seirawanGameDataUIData null");
                                }
                            }
                            // process
                            if (handsUI != null)
                            {
                                switch (color)
                                {
                                    case Common.Color.WHITE:
                                        {
                                            imgGating.enabled = true;
                                            if (handsUI.whiteHand != null)
                                            {
                                                this.transform.SetParent(handsUI.whiteHand, false);
                                                // position
                                                {
                                                    switch (pieceType)
                                                    {
                                                        case Common.PieceType.HAWK:
                                                            {
                                                                UIRectTransform rect = new UIRectTransform();
                                                                {
                                                                    // anchoredPosition: (0.0, 2.5); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                                                    // offsetMin: (-0.5, 2.0); offsetMax: (0.5, 3.0); sizeDelta: (1.0, 1.0);
                                                                    rect.anchoredPosition = new Vector3(0.0f, 2.5f);
                                                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                                                    rect.pivot = new Vector2(0.5f, 0.5f);
                                                                    rect.offsetMin = new Vector2(-0.5f, 2.0f);
                                                                    rect.offsetMax = new Vector2(0.5f, 3.0f);
                                                                    rect.sizeDelta = new Vector2(1.0f, 1.0f);
                                                                }
                                                                rect.set((RectTransform)this.transform);
                                                            }
                                                            break;
                                                        case Common.PieceType.ELEPHANT:
                                                            {
                                                                UIRectTransform rect = new UIRectTransform();
                                                                {
                                                                    // anchoredPosition: (0.0, 3.5); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                                                    // offsetMin: (-0.5, 3.0); offsetMax: (0.5, 4.0); sizeDelta: (1.0, 1.0);
                                                                    rect.anchoredPosition = new Vector3(0.0f, 3.5f, 0.0f);
                                                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                                                    rect.pivot = new Vector2(0.5f, 0.5f);
                                                                    rect.offsetMin = new Vector2(-0.5f, 3.0f);
                                                                    rect.offsetMax = new Vector2(0.5f, 4.0f);
                                                                    rect.sizeDelta = new Vector2(1.0f, 1.0f);
                                                                }
                                                                rect.set((RectTransform)this.transform);
                                                            }
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown pieceType: " + pieceType);
                                                            break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("whiteHand null");
                                            }
                                        }
                                        break;
                                    case Common.Color.BLACK:
                                        {
                                            imgGating.enabled = true;
                                            if (handsUI.blackHand != null)
                                            {
                                                this.transform.SetParent(handsUI.blackHand, false);
                                                // position
                                                {
                                                    switch (pieceType)
                                                    {
                                                        case Common.PieceType.HAWK:
                                                            {
                                                                UIRectTransform rect = new UIRectTransform();
                                                                {
                                                                    // anchoredPosition: (0.0, -2.5); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                                                    // offsetMin: (-0.5, -3.0); offsetMax: (0.5, -2.0); sizeDelta: (1.0, 1.0);
                                                                    rect.anchoredPosition = new Vector3(0.0f, -2.5f);
                                                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                                                    rect.pivot = new Vector2(0.5f, 0.5f);
                                                                    rect.offsetMin = new Vector2(-0.5f, -3.0f);
                                                                    rect.offsetMax = new Vector2(0.5f, -2.0f);
                                                                    rect.sizeDelta = new Vector2(1.0f, 1.0f);
                                                                }
                                                                rect.set((RectTransform)this.transform);
                                                            }
                                                            break;
                                                        case Common.PieceType.ELEPHANT:
                                                            {
                                                                UIRectTransform rect = new UIRectTransform();
                                                                {
                                                                    // anchoredPosition: (0.0, -3.5); anchorMin: (0.5, 0.5); anchorMax: (0.5, 0.5); pivot: (0.5, 0.5);
                                                                    // offsetMin: (-0.5, -4.0); offsetMax: (0.5, -3.0); sizeDelta: (1.0, 1.0);
                                                                    rect.anchoredPosition = new Vector3(0.0f, -3.5f, 0.0f);
                                                                    rect.anchorMin = new Vector2(0.5f, 0.5f);
                                                                    rect.anchorMax = new Vector2(0.5f, 0.5f);
                                                                    rect.pivot = new Vector2(0.5f, 0.5f);
                                                                    rect.offsetMin = new Vector2(-0.5f, -4.0f);
                                                                    rect.offsetMax = new Vector2(0.5f, -3.0f);
                                                                    rect.sizeDelta = new Vector2(1.0f, 1.0f);
                                                                }
                                                                rect.set((RectTransform)this.transform);
                                                            }
                                                            break;
                                                        default:
                                                            Debug.LogError("unknown pieceType: " + pieceType);
                                                            break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("blackHand null");
                                            }
                                        }
                                        break;
                                    case Common.Color.COLOR_NB:
                                        imgGating.enabled = false;
                                        break;
                                    default:
                                        Debug.LogError("unknown color: " + color);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("handsUI null");
                            }
                        }
                        // color
                        imgGating.color = isHint ? new Color(0, 0, 1, 0.5f) : Color.blue;
                    }
                    else
                    {
                        Debug.LogError("imgGating null");
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private SeirawanMoveUI.UIData seirawanMoveUIData = null;
        private SeirawanGameDataUI.UIData seirawanGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.seirawanMoveUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.seirawanGameDataUIData);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                // seirawanMoveUIData
                {
                    if(data is SeirawanMoveUI.UIData)
                    {
                        SeirawanMoveUI.UIData seirawanMoveUIData = data as SeirawanMoveUI.UIData;
                        // Child
                        {
                            seirawanMoveUIData.seirawanMove.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is SeirawanMove)
                    {
                        dirty = true;
                        return;
                    }
                }
                // seirawanGameDataUIData
                {
                    if(data is SeirawanGameDataUI.UIData)
                    {
                        SeirawanGameDataUI.UIData seirawanGameDataUIData = data as SeirawanGameDataUI.UIData;
                        // Child
                        {
                            seirawanGameDataUIData.board.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if(data is BoardUI.UIData)
                        {
                            BoardUI.UIData boardUIData = data as BoardUI.UIData;
                            // Child
                            {
                                boardUIData.seirawan.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if(data is Seirawan)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.seirawanMoveUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.seirawanGameDataUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                // seirawanMoveUIData
                {
                    if (data is SeirawanMoveUI.UIData)
                    {
                        SeirawanMoveUI.UIData seirawanMoveUIData = data as SeirawanMoveUI.UIData;
                        // Child
                        {
                            seirawanMoveUIData.seirawanMove.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is SeirawanMove)
                    {
                        return;
                    }
                }
                // seirawanGameDataUIData
                {
                    if (data is SeirawanGameDataUI.UIData)
                    {
                        SeirawanGameDataUI.UIData seirawanGameDataUIData = data as SeirawanGameDataUI.UIData;
                        // Child
                        {
                            seirawanGameDataUIData.board.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is BoardUI.UIData)
                        {
                            BoardUI.UIData boardUIData = data as BoardUI.UIData;
                            // Child
                            {
                                boardUIData.seirawan.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is Seirawan)
                        {
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is UIData)
            {
                switch ((UIData.Property)wrapProperty.n)
                {
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                // seirawanMoveUIData
                {
                    if (wrapProperty.p is SeirawanMoveUI.UIData)
                    {
                        switch ((SeirawanMoveUI.UIData.Property)wrapProperty.n)
                        {
                            case SeirawanMoveUI.UIData.Property.seirawanMove:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case SeirawanMoveUI.UIData.Property.isHint:
                                dirty = true;
                                break;
                            case SeirawanMoveUI.UIData.Property.gate:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is SeirawanMove)
                    {
                        switch ((SeirawanMove.Property)wrapProperty.n)
                        {
                            case SeirawanMove.Property.move:
                                dirty = true;
                                break;
                            case SeirawanMove.Property.chess960:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // seirawanGameDataUIData
                {
                    if (wrapProperty.p is SeirawanGameDataUI.UIData)
                    {
                        switch ((SeirawanGameDataUI.UIData.Property)wrapProperty.n)
                        {
                            case SeirawanGameDataUI.UIData.Property.gameData:
                                break;
                            case SeirawanGameDataUI.UIData.Property.transformOrganizer:
                                break;
                            case SeirawanGameDataUI.UIData.Property.isOnAnimation:
                                break;
                            case SeirawanGameDataUI.UIData.Property.board:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case SeirawanGameDataUI.UIData.Property.lastMove:
                                break;
                            case SeirawanGameDataUI.UIData.Property.showHint:
                                break;
                            case SeirawanGameDataUI.UIData.Property.inputUI:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is BoardUI.UIData)
                        {
                            switch ((BoardUI.UIData.Property)wrapProperty.n)
                            {
                                case BoardUI.UIData.Property.seirawan:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case BoardUI.UIData.Property.boardIndexs:
                                    break;
                                case BoardUI.UIData.Property.hands:
                                    break;
                                case BoardUI.UIData.Property.pieces:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is Seirawan)
                        {
                            switch ((Seirawan.Property)wrapProperty.n)
                            {
                                case Seirawan.Property.board:
                                    break;
                                case Seirawan.Property.byTypeBB:
                                    break;
                                case Seirawan.Property.byColorBB:
                                    break;
                                case Seirawan.Property.inHand:
                                    break;
                                case Seirawan.Property.handScore:
                                    break;
                                case Seirawan.Property.pieceCount:
                                    break;
                                case Seirawan.Property.pieceList:
                                    break;
                                case Seirawan.Property.index:
                                    break;
                                case Seirawan.Property.castlingRightsMask:
                                    break;
                                case Seirawan.Property.castlingRookSquare:
                                    break;
                                case Seirawan.Property.castlingPath:
                                    break;
                                case Seirawan.Property.gamePly:
                                    break;
                                case Seirawan.Property.sideToMove:
                                    dirty = true;
                                    break;
                                case Seirawan.Property.st:
                                    break;
                                case Seirawan.Property.chess960:
                                    break;
                                case Seirawan.Property.isCustom:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}