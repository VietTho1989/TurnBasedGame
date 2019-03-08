using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
    public class ShogiCustomHandUI : UIBehavior<ShogiCustomHandUI.UIData>
    {

        #region UIData

        public class UIData : LastMoveSub
        {
            public VP<ReferenceData<ShogiCustomHand>> shogiCustomHand;

            public VP<bool> isHint;

            #region Constructor

            public enum Property
            {
                shogiCustomHand,
                isHint
            }

            public UIData() : base()
            {
                this.shogiCustomHand = new VP<ReferenceData<ShogiCustomHand>>(this, (byte)Property.shogiCustomHand, new ReferenceData<ShogiCustomHand>(null));
                this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
            }

            #endregion

            public override GameMove.Type getType()
            {
                return GameMove.Type.ShogiCustomHand;
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
                    ShogiCustomHand shogiCustomHand = this.data.shogiCustomHand.v.data;
                    if (shogiCustomHand != null)
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
                                ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData>();
                                if (shogiGameDataUIData != null)
                                {
                                    BoardUI.UIData boardUIData = shogiGameDataUIData.board.v;
                                    if (boardUIData != null)
                                    {
                                        HandUI.UIData handUIData = boardUIData.hand.v;
                                        if (handUIData != null)
                                        {
                                            foreach (HandPieceUI.UIData handPieceUIData in handUIData.handPieces.vs)
                                            {
                                                if (handPieceUIData.handPiece.v == shogiCustomHand.handPiece.v && handPieceUIData.color.v == shogiCustomHand.color.v)
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
                                            Debug.LogError("handUIData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("boardUIData null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("shogiGameDataUIData null: " + this);
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
                        Debug.LogError("shogiCustomHand null: " + this);
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

        private ShogiGameDataUI.UIData shogiGameDataUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.shogiGameDataUIData);
                }
                // Child
                {
                    uiData.shogiCustomHand.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Parent
            {
                if (data is ShogiGameDataUI.UIData)
                {
                    ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
                    // Child
                    {
                        shogiGameDataUIData.board.allAddCallBack(this);
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
                            boardUIData.hand.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is HandUI.UIData)
                        {
                            HandUI.UIData handUIData = data as HandUI.UIData;
                            // Child
                            {
                                handUIData.handPieces.allAddCallBack(this);
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
            }
            // Child
            if (data is ShogiCustomHand)
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
                    DataUtils.removeParentCallBack(uiData, this, ref this.shogiGameDataUIData);
                }
                // Child
                {
                    uiData.shogiCustomHand.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Parent
            {
                if (data is ShogiGameDataUI.UIData)
                {
                    ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
                    // Child
                    {
                        shogiGameDataUIData.board.allRemoveCallBack(this);
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
                            boardUIData.hand.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is HandUI.UIData)
                        {
                            HandUI.UIData handUIData = data as HandUI.UIData;
                            // Child
                            {
                                handUIData.handPieces.allRemoveCallBack(this);
                            }
                            return;
                        }
                        if (data is HandPieceUI.UIData)
                        {
                            return;
                        }
                    }
                }
            }
            // Child
            if (data is ShogiCustomHand)
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
                    case UIData.Property.shogiCustomHand:
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
                if (wrapProperty.p is ShogiGameDataUI.UIData)
                {
                    switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n)
                    {
                        case ShogiGameDataUI.UIData.Property.gameData:
                            break;
                        case ShogiGameDataUI.UIData.Property.transformOrganizer:
                            break;
                        case ShogiGameDataUI.UIData.Property.isOnAnimation:
                            break;
                        case ShogiGameDataUI.UIData.Property.board:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case ShogiGameDataUI.UIData.Property.lastMove:
                            break;
                        case ShogiGameDataUI.UIData.Property.showHint:
                            break;
                        case ShogiGameDataUI.UIData.Property.inputUI:
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
                            case BoardUI.UIData.Property.shogi:
                                break;
                            case BoardUI.UIData.Property.pieces:
                                break;
                            case BoardUI.UIData.Property.hand:
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
                            case HandPieceUI.UIData.Property.handPiece:
                                dirty = true;
                                break;
                            case HandPieceUI.UIData.Property.color:
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
            if (wrapProperty.p is ShogiCustomHand)
            {
                switch ((ShogiCustomHand.Property)wrapProperty.n)
                {
                    case ShogiCustomHand.Property.color:
                        dirty = true;
                        break;
                    case ShogiCustomHand.Property.handPiece:
                        dirty = true;
                        break;
                    case ShogiCustomHand.Property.pieceCount:
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