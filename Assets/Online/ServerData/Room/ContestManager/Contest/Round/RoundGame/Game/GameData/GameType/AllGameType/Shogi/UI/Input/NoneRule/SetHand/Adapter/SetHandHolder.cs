using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Shogi.NoneRule
{
    public class SetHandHolder : SriaHolderBehavior<SetHandHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<Common.ColorAndHandPiece> piece;

            #region Constructor

            public enum Property
            {
                piece
            }

            public UIData() : base()
            {
                this.piece = new VP<Common.ColorAndHandPiece>(this, (byte)Property.piece, null);
            }

            #endregion

            public void updateView(SetHandAdapter.UIData myParams)
            {
                // Find
                Common.ColorAndHandPiece piece = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.pieces.Count)
                    {
                        piece = myParams.pieces[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.piece.v = piece;
            }

        }

        #endregion

        #region Refresh

        public Image imgPiece;
        public Text tvPieceCount;

        public Button btnChoose;
        public Text tvChoose;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Common.ColorAndHandPiece piece = this.data.piece.v;
                    if (piece != null)
                    {
                        // imgPiece
                        {
                            if (imgPiece != null)
                            {
                                // Find style
                                Setting.Style style = Setting.get().style.v;
                                // Process
                                imgPiece.sprite = ShogiSpriteContainer.get().getSpriteForHandPiece(style, piece.handPiece, piece.color);
                            }
                            else
                            {
                                Debug.LogError("imgPiece null: " + this);
                            }
                        }
                        // tvPieceCount
                        {
                            if (tvPieceCount != null)
                            {
                                uint pieceCount = 0;
                                {
                                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                                    if (noneRuleInputUIData != null)
                                    {
                                        Shogi shogi = noneRuleInputUIData.shogi.v.data;
                                        if (shogi != null)
                                        {
                                            pieceCount = Shogi.numOf(Shogi.getHand(shogi.hand.vs, piece.color), piece.handPiece);
                                        }
                                        else
                                        {
                                            Debug.LogError("shogi null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("noneRuleInputUIData null: " + this);
                                    }
                                }
                                tvPieceCount.text = "" + pieceCount;
                            }
                            else
                            {
                                Debug.LogError("tvPieceCount null: " + this);
                            }
                        }
                        // isChosen
                        {
                            if (btnChoose != null)
                            {
                                bool isChosen = false;
                                {
                                    SetHandAdapter.UIData setHandAdapterUIData = this.data.findDataInParent<SetHandAdapter.UIData>();
                                    if (setHandAdapterUIData != null)
                                    {
                                        isChosen = (setHandAdapterUIData.chosen.v == piece);
                                    }
                                    else
                                    {
                                        Debug.LogError("setHandIndicator null: " + this);
                                    }
                                }
                                btnChoose.interactable = !isChosen;
                            }
                            else
                            {
                                Debug.LogError("btnChoose null");
                            }
                        }
                        // txt
                        {
                            if (tvChoose != null)
                            {
                                tvChoose.text = ClickPosTxt.txtChoose.get(ClickPosTxt.DefaultChoose);
                            }
                            else
                            {
                                Debug.LogError("tvChoose null");
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError ("piece null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        private NoneRuleInputUI.UIData noneRuleInputUIData = null;
        private SetHandAdapter.UIData setHandAdapterUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.setHandAdapterUIData);
                }
                dirty = true;
                return;
            }
            // Setting
            if (data is Setting)
            {
                dirty = true;
                return;
            }
            // Parent
            {
                // noneRuleInputUIData
                {
                    if (data is NoneRuleInputUI.UIData)
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                        // Child
                        {
                            noneRuleInputUIData.shogi.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is Shogi)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is ShogiGameDataUI.UIData)
                {
                    dirty = true;
                    return;
                }
                if (data is SetHandAdapter.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneRuleInputUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.setHandAdapterUIData);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                // noneRuleInputUIData
                {
                    if (data is NoneRuleInputUI.UIData)
                    {
                        NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                        // Child
                        {
                            noneRuleInputUIData.shogi.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is Shogi)
                    {
                        return;
                    }
                }
                if (data is SetHandAdapter.UIData)
                {
                    return;
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
                    case UIData.Property.piece:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Setting
            if (wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        dirty = true;
                        break;
                    case Setting.Property.style:
                        dirty = true;
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Parent
            {
                // noneRuleInputUIData
                {
                    if (wrapProperty.p is NoneRuleInputUI.UIData)
                    {
                        switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n)
                        {
                            case NoneRuleInputUI.UIData.Property.shogi:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case NoneRuleInputUI.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is Shogi)
                    {
                        switch ((Shogi.Property)wrapProperty.n)
                        {
                            case Shogi.Property.byTypeBB:
                                break;
                            case Shogi.Property.byColorBB:
                                break;
                            case Shogi.Property.goldsBB:
                                break;
                            case Shogi.Property.piece:
                                break;
                            case Shogi.Property.kingSquare:
                                break;
                            case Shogi.Property.hand:
                                dirty = true;
                                break;
                            case Shogi.Property.turn:
                                break;
                            case Shogi.Property.evalList:
                                break;
                            case Shogi.Property.startState:
                                break;
                            case Shogi.Property.st:
                                break;
                            case Shogi.Property.gamePly:
                                break;
                            case Shogi.Property.nodes:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is SetHandAdapter.UIData)
                {
                    switch ((SetHandAdapter.UIData.Property)wrapProperty.n)
                    {
                        case SetHandAdapter.UIData.Property.holders:
                            break;
                        case SetHandAdapter.UIData.Property.chosen:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnChose()
        {
            if (this.data != null)
            {
                Common.ColorAndHandPiece piece = this.data.piece.v;
                if (piece != null)
                {
                    SetHandAdapter.UIData setHandAdapterUIData = this.data.findDataInParent<SetHandAdapter.UIData>();
                    if (setHandAdapterUIData != null)
                    {
                        setHandAdapterUIData.chosen.v = piece;
                    }
                    else
                    {
                        Debug.LogError("setHandAdapterUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("piece null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}