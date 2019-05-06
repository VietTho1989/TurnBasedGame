using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
    public class ChoosePieceHolder : SriaHolderBehavior<ChoosePieceHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<Common.ColorAndPiece> piece;

            #region Constructor

            public enum Property
            {
                piece
            }

            public UIData() : base()
            {
                this.piece = new VP<Common.ColorAndPiece>(this, (byte)Property.piece, null);
            }

            #endregion

            public void updateView(ChoosePieceAdapter.UIData myParams)
            {
                // Find
                Common.ColorAndPiece piece = new Common.ColorAndPiece();
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

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            ChoosePieceHolder choosePieceHolder = this.findCallBack<ChoosePieceHolder>();
                            if (choosePieceHolder != null)
                            {
                                isProcess = choosePieceHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("choosePieceHolder null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvChoose;

        #endregion

        #region Refresh

        public Image imgPiece;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Common.ColorAndPiece piece = this.data.piece.v;
                    if (piece != null)
                    {
                        // imgPiece
                        {
                            if (imgPiece != null)
                            {
                                // find variantType
                                Common.VariantType variantType = Common.VariantType.asean;
                                {
                                    NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                                    if (noneRuleInputUIData != null)
                                    {
                                        FairyChess fairyChess = noneRuleInputUIData.fairyChess.v.data;
                                        if (fairyChess != null)
                                        {
                                            variantType = (Common.VariantType)fairyChess.variantType.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("fairyChess null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("noneRuleInputUIData null: " + this);
                                    }
                                }
                                SpriteContainer.setImagePiece(imgPiece, variantType, piece.color, piece.pieceType);
                            }
                            else
                            {
                                Debug.LogError("imgPiece null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("piece null: " + this);
                    }
                    // txt
                    {
                        if (tvChoose != null)
                        {
                            tvChoose.text = ClickPosTxt.txtChoose.get();
                        }
                        else
                        {
                            Debug.LogError("tvChoose null");
                        }
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
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.fairyChess.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is FairyChess)
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
                if (data is NoneRuleInputUI.UIData)
                {
                    NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
                    // Child
                    {
                        noneRuleInputUIData.fairyChess.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is FairyChess)
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
                if (wrapProperty.p is NoneRuleInputUI.UIData)
                {
                    switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n)
                    {
                        case NoneRuleInputUI.UIData.Property.fairyChess:
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
                if (wrapProperty.p is FairyChess)
                {
                    switch ((FairyChess.Property)wrapProperty.n)
                    {
                        case FairyChess.Property.board:
                            break;
                        case FairyChess.Property.unpromotedBoard:
                            break;
                        case FairyChess.Property.byTypeBB:
                            break;
                        case FairyChess.Property.byColorBB:
                            break;
                        case FairyChess.Property.pieceCount:
                            break;
                        case FairyChess.Property.pieceList:
                            break;
                        case FairyChess.Property.index:
                            break;
                        case FairyChess.Property.castlingRightsMask:
                            break;
                        case FairyChess.Property.castlingRookSquare:
                            break;
                        case FairyChess.Property.castlingPath:
                            break;
                        case FairyChess.Property.gamePly:
                            break;
                        case FairyChess.Property.sideToMove:
                            break;
                        case FairyChess.Property.variantType:
                            dirty = true;
                            break;
                        case FairyChess.Property.st:
                            break;
                        case FairyChess.Property.chess960:
                            break;
                        case FairyChess.Property.pieceCountInHand:
                            break;
                        case FairyChess.Property.promotedPieces:
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

        public override void Awake()
        {
            base.Awake();
            // OnClick
            {
                UIUtils.SetButtonOnClick(btnChoose, onClickBtnChoose);
            }
        }

        public bool useShortKey(Event e)
        {
            bool isProcess = false;
            {
                if (e.isKey && e.type == EventType.KeyUp)
                {
                    switch (e.keyCode)
                    {
                        case KeyCode.KeypadEnter:
                            {
                                if (btnChoose != null && btnChoose.gameObject.activeInHierarchy && btnChoose.interactable)
                                {
                                    this.onClickBtnChoose();
                                    isProcess = true;
                                }
                                else
                                {
                                    Debug.LogError("cannot click");
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            return isProcess;
        }

        public Button btnChoose;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnChoose()
        {
            if (this.data != null)
            {
                // Find ClientInput
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                // Process
                if (clientInput != null)
                {
                    FairyChessCustomSet fairyChessCustomSet = new FairyChessCustomSet();
                    {
                        // x, y
                        {
                            SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData>();
                            if (setPieceUIData != null)
                            {
                                fairyChessCustomSet.x.v = setPieceUIData.x.v;
                                fairyChessCustomSet.y.v = setPieceUIData.y.v;
                            }
                            else
                            {
                                Debug.LogError("setPieceUIData null: " + this);
                            }
                        }
                        fairyChessCustomSet.color.v = this.data.piece.v.color;
                        fairyChessCustomSet.pieceType.v = this.data.piece.v.pieceType;
                    }
                    clientInput.makeSend(fairyChessCustomSet);
                }
                else
                {
                    Debug.LogError("clientInput null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}