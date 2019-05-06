using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
    public class SetHandHolder : SriaHolderBehavior<SetHandHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<Common.Piece> piece;

            #region Constructor

            public enum Property
            {
                piece
            }

            public UIData() : base()
            {
                this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.NO_PIECE);
            }

            #endregion

            public void updateView(SetHandAdapter.UIData myParams)
            {
                // Find
                Common.Piece piece = Common.Piece.NO_PIECE;
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
                            SetHandHolder setHandHolder = this.findCallBack<SetHandHolder>();
                            if (setHandHolder != null)
                            {
                                isProcess = setHandHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("setHandHolder null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvSet;
        private static readonly TxtLanguage txtSet = new TxtLanguage("Set");
        private static readonly TxtLanguage txtUnSet = new TxtLanguage("Unset");

        static SetHandHolder()
        {
            txtSet.add(Language.Type.vi, "Đặt");
            txtUnSet.add(Language.Type.vi, "Bỏ Đặt");
        }

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
                    // imgPiece
                    {
                        if (imgPiece != null)
                        {
                            imgPiece.sprite = SeirawanSpriteContainer.get().getSprite(this.data.piece.v);
                        }
                        else
                        {
                            Debug.LogError("imgPiece null: " + this);
                        }
                    }
                    // inHand
                    {
                        if (tvSet != null)
                        {
                            bool isInHand = true;
                            {
                                NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
                                if (noneRuleInputUIData != null)
                                {
                                    Seirawan seirawan = noneRuleInputUIData.seirawan.v.data;
                                    if (seirawan != null)
                                    {
                                        isInHand = Seirawan.IsInHand(seirawan.inHand.vs, this.data.piece.v);
                                    }
                                    else
                                    {
                                        Debug.LogError("seirawan null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("noneRuleInputUIData null: " + this);
                                }
                            }
                            tvSet.text = isInHand ? txtUnSet.get() : txtSet.get();
                        }
                        else
                        {
                            Debug.LogError("tvInHand null: " + this);
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
                        noneRuleInputUIData.seirawan.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Seirawan)
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
                        noneRuleInputUIData.seirawan.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Seirawan)
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
                        case NoneRuleInputUI.UIData.Property.seirawan:
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
                            dirty = true;
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

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
                                if (btnSet != null && btnSet.gameObject.activeInHierarchy && btnSet.interactable)
                                {
                                    this.onClickBtnSet();
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

        public Button btnSet;

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnSet()
        {
            if (this.data != null)
            {
                // Find ClientInput
                ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
                // Process
                if (clientInput != null)
                {
                    SeirawanCustomHand seirawanCustomHand = new SeirawanCustomHand();
                    {
                        seirawanCustomHand.piece.v = this.data.piece.v;
                    }
                    clientInput.makeSend(seirawanCustomHand);
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