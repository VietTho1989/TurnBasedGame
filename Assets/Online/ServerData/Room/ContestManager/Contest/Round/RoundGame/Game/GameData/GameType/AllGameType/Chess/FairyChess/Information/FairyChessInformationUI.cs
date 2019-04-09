using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
    public class FairyChessInformationUI : UIHaveTransformDataBehavior<FairyChessInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<FairyChess>> fairyChess;

            public VP<UIRectTransform.ShowType> showType;

            public VP<FairyChessFenUI.UIData> fairyChessFenUIData;

            #region Constructor

            public enum Property
            {
                fairyChess,
                showType,
                fairyChessFenUIData
            }

            public UIData() : base()
            {
                this.fairyChess = new VP<ReferenceData<FairyChess>>(this, (byte)Property.fairyChess, new ReferenceData<FairyChess>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.fairyChessFenUIData = new VP<FairyChessFenUI.UIData>(this, (byte)Property.fairyChessFenUIData, new FairyChessFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.FairyChess;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

        }

        #endregion

        #region txt, rect

        public Text lbTitle;

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Fairy_chess");

        public Text lbFen;
        public Button btnCopyFen;

        public Text lbVariant;
        private static readonly TxtLanguage txtVariant = new TxtLanguage("Variant");

        public Text lbChess960;

        static FairyChessInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Fairy_chess");
            txtVariant.add(Language.Type.vi, "Biến thể");
        }

        #endregion

        #region Refresh

        public Dropdown drVariant;
        public Toggle tgChess960;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    FairyChess fairyChess = this.data.fairyChess.v.data;
                    if (fairyChess != null)
                    {
                        // fen
                        {
                            FairyChessFenUI.UIData fairyChessFenUIData = this.data.fairyChessFenUIData.v;
                            if (fairyChessFenUIData != null)
                            {
                                fairyChessFenUIData.fairyChess.v = new ReferenceData<FairyChess>(fairyChess);
                            }
                            else
                            {
                                Debug.LogError("fairyChessFenUIData null");
                            }
                        }
                        // variant
                        {
                            if (drVariant != null)
                            {
                                // options
                                {
                                    List<string> options = new List<string>();
                                    {
                                        for (int i = 0; i < VariantMap.EnableVariants.Length; i++)
                                        {
                                            options.Add(VariantMap.EnableVariants[i].ToString());
                                        }
                                    }
                                    UIUtils.RefreshDropDownOptions(drVariant, options);
                                }
                                drVariant.interactable = false;
                                drVariant.value = VariantMap.getEnableVariantIndex((Common.VariantType)fairyChess.variantType.v);
                            }
                            else
                            {
                                Debug.LogError("drVariant null");
                            }
                        }
                        // chess960
                        {
                            if (tgChess960 != null)
                            {
                                tgChess960.interactable = false;
                                tgChess960.isOn = fairyChess.chess960.v;
                            }
                            else
                            {
                                Debug.LogError("tgChess960 null");
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                            // tvMessage
                            {
                                if (tvMessage != null)
                                {
                                    UIRectTransform.SetPosY(tvMessage.rectTransform, deltaY);
                                    deltaY += 30;
                                }
                                else
                                {
                                    Debug.LogError("tvMessage null");
                                }
                            }
                            // fen
                            {
                                if (this.data.fairyChessFenUIData.v != null)
                                {
                                    if (lbFen != null)
                                    {
                                        lbFen.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY(lbFen.rectTransform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbFen null");
                                    }
                                    if (btnCopyFen != null)
                                    {
                                        btnCopyFen.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY((RectTransform)btnCopyFen.transform, deltaY + (UIConstants.ItemHeight - 30) / 2);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnCopyFen null");
                                    }
                                    UIRectTransform.SetPosY(this.data.fairyChessFenUIData.v, deltaY);
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbFen != null)
                                    {
                                        lbFen.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbFen null");
                                    }
                                    if (btnCopyFen != null)
                                    {
                                        btnCopyFen.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnCopyFen null");
                                    }
                                }
                            }
                            // variant
                            {
                                if (lbVariant != null)
                                {
                                    lbVariant.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbVariant.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbVariant null");
                                }
                                if (drVariant != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)drVariant.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonToggleHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("drVariant null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // chess960
                            {
                                if (lbChess960 != null)
                                {
                                    lbChess960.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbChess960.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbChess960 null");
                                }
                                if (tgChess960 != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tgChess960.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonToggleHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tgChess960 null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.FairyChess);
                                Setting.get().setTitleTextSize(lbTitle);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            if (tvMessage != null)
                            {
                                tvMessage.text = txtMessage.get();
                                Setting.get().setContentTextSize(tvMessage);
                            }
                            else
                            {
                                Debug.LogError("tvMessage null");
                            }
                            if (lbFen != null)
                            {
                                Setting.get().setLabelTextSize(lbFen);
                            }
                            else
                            {
                                Debug.LogError("lbFen null");
                            }
                            if (lbVariant != null)
                            {
                                lbVariant.text = txtVariant.get();
                                Setting.get().setLabelTextSize(lbVariant);
                            }
                            else
                            {
                                Debug.LogError("lbVariant null");
                            }
                            if (lbChess960 != null)
                            {
                                Setting.get().setLabelTextSize(lbChess960);
                            }
                            else
                            {
                                Debug.LogError("lbChess960 null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChess null");
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

        public FairyChessFenUI fairyChessFenPrefab;
        private static readonly UIRectTransform fairyChessFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.fairyChess.allAddCallBack(this);
                    uiData.fairyChessFenUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Setting
            if(data is Setting)
            {
                dirty = true;
                return;
            }
            // Child
            {
                if(data is FairyChess)
                {
                    dirty = true;
                    return;
                }
                if(data is FairyChessFenUI.UIData)
                {
                    FairyChessFenUI.UIData fairyChessFenUIData = data as FairyChessFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(fairyChessFenUIData, fairyChessFenPrefab, this.transform, fairyChessFenRect);
                    }
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
                // Child
                {
                    uiData.fairyChess.allRemoveCallBack(this);
                    uiData.fairyChessFenUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                if (data is FairyChess)
                {
                    return;
                }
                if (data is FairyChessFenUI.UIData)
                {
                    FairyChessFenUI.UIData fairyChessFenUIData = data as FairyChessFenUI.UIData;
                    // UI
                    {
                        fairyChessFenUIData.removeCallBackAndDestroy(typeof(FairyChessFenUI));
                    }
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
                    case UIData.Property.fairyChess:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.fairyChessFenUIData:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
                    case Setting.Property.defaultChosenGame:
                        break;
                    case Setting.Property.defaultRoomName:
                        break;
                    case Setting.Property.defaultChatRoomStyle:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
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
                            dirty = true;
                            break;
                        case FairyChess.Property.pieceCountInHand:
                            break;
                        case FairyChess.Property.promotedPieces:
                            break;
                        case FairyChess.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is FairyChessFenUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnCopyFen()
        {
            if (this.data != null)
            {
                FairyChessFenUI.UIData fairyChessFenUIData = this.data.fairyChessFenUIData.v;
                if (fairyChessFenUIData != null)
                {
                    FairyChessFenUI fairyChessFenUI = fairyChessFenUIData.findCallBack<FairyChessFenUI>();
                    if (fairyChessFenUI != null)
                    {
                        Text tvFen = fairyChessFenUI.tvFen;
                        if (tvFen != null)
                        {
                            string fen = tvFen.text;
                            UniClipboard.SetText(fen);
                            Toast.showMessage("Copy Fen: " + fen);
                        }
                        else
                        {
                            Debug.LogError("tvFen null");
                        }
                    }
                    else
                    {
                        Debug.LogError("fairyChessFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("fairyChessFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}