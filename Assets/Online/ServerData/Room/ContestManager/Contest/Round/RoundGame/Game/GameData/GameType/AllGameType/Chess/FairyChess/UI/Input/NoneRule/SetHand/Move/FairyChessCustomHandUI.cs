using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
    public class FairyChessCustomHandUI : UIBehavior<FairyChessCustomHandUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {
            public VP<ReferenceData<FairyChessCustomHand>> fairyChessCustomHand;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                fairyChessCustomHand,
                isHint
            }

            public UIData() : base()
            {
                this.fairyChessCustomHand = new VP<ReferenceData<FairyChessCustomHand>>(this, (byte)Property.fairyChessCustomHand, new ReferenceData<FairyChessCustomHand>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.FairyChessCustomHand;
            }
        }

        #endregion

        #region Refresh

        public Image imgHint;
        public GameObject contentContainer;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FairyChessCustomHand fairyChessCustomHand = this.data.fairyChessCustomHand.v.data;
                    if (fairyChessCustomHand != null)
                    {
                        // imgHint
                        if (imgHint != null)
                        {
                            if (this.data.isHint.v)
                            {
                                imgHint.color = new Color(1f, 1f, 1f, 0.5f);
                            }
                            else
                            {
                                imgHint.color = new Color(1f, 1f, 1f, 0.75f);
                            }
                        }
                        else
                        {
                            Debug.LogError("imgHint null: " + this);
                        }
                        // set parent transform
                        {
                            // find
                            Transform parentTransform = null;
                            {
                                FairyChessGameDataUI.UIData fairyChessGameDataUIData = this.data.findDataInParent<FairyChessGameDataUI.UIData>();
                                if (fairyChessGameDataUIData != null)
                                {
                                    BoardUI.UIData boardUIData = fairyChessGameDataUIData.board.v;
                                    if (boardUIData != null)
                                    {
                                        // get list
                                        List<HandPieceUI.UIData> handPieceUIDatas = new List<HandPieceUI.UIData>();
                                        {
                                            handPieceUIDatas.AddRange(boardUIData.whiteHand.vs);
                                            handPieceUIDatas.AddRange(boardUIData.blackHand.vs);
                                        }
                                        // find
                                        foreach (HandPieceUI.UIData handPieceUIData in handPieceUIDatas)
                                        {
                                            Common.Piece piece = handPieceUIData.piece.v;
                                            if (Common.color_of(piece) == fairyChessCustomHand.color.v && Common.type_of(piece) == fairyChessCustomHand.pieceType.v)
                                            {
                                                HandPieceUI handPieceUI = handPieceUIData.findCallBack<HandPieceUI>();
                                                if (handPieceUI != null)
                                                {
                                                    parentTransform = handPieceUI.transform;
                                                }
                                                else
                                                {
                                                    Debug.LogError("handPieceUI null: " + this);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("boardUIData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("fairyChessGameDataUIData null: " + this);
                                }
                            }
                            // set
                            if (parentTransform != null)
                            {
                                // contentContainer
                                if (contentContainer != null)
                                {
                                    contentContainer.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("contentContainer null: " + this);
                                }
                                // set parent
                                this.transform.SetParent(parentTransform, false);
                            }
                            else
                            {
                                Debug.LogError("parentTransform null: " + this);
                                // contentContainer
                                if (contentContainer != null)
                                {
                                    contentContainer.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("contentContainer null: " + this);
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChessCustomHand null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private FairyChessGameDataUI.UIData fairyChessGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.fairyChessGameDataUIData);
                }
                // Child
                {
                    uiData.fairyChessCustomHand.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is FairyChessGameDataUI.UIData)
                {
                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
                    // Child
                    {
                        fairyChessGameDataUIData.board.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is BoardUI.UIData)
                    {
                        BoardUI.UIData boardUIData = data as BoardUI.UIData;
                        // Child
                        {
                            boardUIData.whiteHand.allAddCallBack(this);
                            boardUIData.blackHand.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is HandPieceUI.UIData)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (data is FairyChessCustomHand)
            {
                dirty = true;
                return;
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.fairyChessGameDataUIData);
                }
                // Child
                {
                    uiData.fairyChessCustomHand.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is FairyChessGameDataUI.UIData)
                {
                    FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
                    // Child
                    {
                        fairyChessGameDataUIData.board.allRemoveCallBack(this);
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
                            boardUIData.whiteHand.allRemoveCallBack(this);
                            boardUIData.blackHand.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is HandPieceUI.UIData)
                    {
                        return;
                    }
                }
            }
            // Child
            if (data is FairyChessCustomHand)
            {
                return;
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
                    case UIData.Property.fairyChessCustomHand:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isHint:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                if (wrapProperty.p is FairyChessGameDataUI.UIData)
                {
                    switch ((FairyChessGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case FairyChessGameDataUI.UIData.Property.gameData:
                            break;
                        case FairyChessGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case FairyChessGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case FairyChessGameDataUI.UIData.Property.board:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case FairyChessGameDataUI.UIData.Property.lastMove:
                            break;
                        case FairyChessGameDataUI.UIData.Property.showHint:
                            break;
                        case FairyChessGameDataUI.UIData.Property.inputUI:
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
                            case BoardUI.UIData.Property.fairyChess:
                                break;
                            case BoardUI.UIData.Property.pieces:
                                break;
                            case BoardUI.UIData.Property.whiteHand:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case BoardUI.UIData.Property.blackHand:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is HandPieceUI.UIData)
                    {
                        switch ((HandPieceUI.UIData.Property)wrapProperty.n)
                        {
                            case HandPieceUI.UIData.Property.variantType:
                                break;
                            case HandPieceUI.UIData.Property.piece:
                                dirty = true;
                                break;
                            case HandPieceUI.UIData.Property.count:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            // Child
            if (wrapProperty.p is FairyChessCustomHand)
            {
                switch ((FairyChessCustomHand.Property)wrapProperty.n)
                {
                    case FairyChessCustomHand.Property.color:
                        dirty = true;
                        break;
                    case FairyChessCustomHand.Property.pieceType:
                        dirty = true;
                        break;
                    case FairyChessCustomHand.Property.pieceCount:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}