using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
    public class InternationalDraughtInformationUI : UIHaveTransformDataBehavior<InternationalDraughtInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<InternationalDraught>> internationalDraught;

            public VP<UIRectTransform.ShowType> showType;

            public VP<InternationalDraughtFenUI.UIData> internationalDraughtFenUIData;

            #region Constructor

            public enum Property
            {
                internationalDraught,
                showType,
                internationalDraughtFenUIData
            }

            public UIData() : base()
            {
                this.internationalDraught = new VP<ReferenceData<InternationalDraught>>(this, (byte)Property.internationalDraught, new ReferenceData<InternationalDraught>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.internationalDraughtFenUIData = new VP<InternationalDraughtFenUI.UIData>(this, (byte)Property.internationalDraughtFenUIData, new InternationalDraughtFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.InternationalDraught;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/International_draughts");

        public Text lbVariant;
        private static readonly TxtLanguage txtVariant = new TxtLanguage("Variant");

        static InternationalDraughtInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/International_draughts");
            txtVariant.add(Language.Type.vi, "Biến thể");
        }

        #endregion

        #region Refresh

        public Text lbFen;
        public Button btnCopyFen;

        public Dropdown drVariant;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    InternationalDraught internationalDraught = this.data.internationalDraught.v.data;
                    if (internationalDraught != null)
                    {
                        // fen
                        {
                            InternationalDraughtFenUI.UIData internationalDraughtFenUIData = this.data.internationalDraughtFenUIData.v;
                            if (internationalDraughtFenUIData != null)
                            {
                                internationalDraughtFenUIData.internationalDraught.v = new ReferenceData<InternationalDraught>(internationalDraught);
                            }
                            else
                            {
                                Debug.LogError("internationalDraughtFenUIData null");
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
                                        options.Add("Normal");
                                        options.Add("Killer");
                                        options.Add("Breakthrough");
                                    }
                                    UIUtils.RefreshDropDownOptions(drVariant, options);
                                }
                                drVariant.interactable = false;
                                drVariant.value = internationalDraught.var.v.Variant.v;
                            }
                            else
                            {
                                Debug.LogError("drVariant null");
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            {
                                switch (this.data.showType.v)
                                {
                                    case UIRectTransform.ShowType.Normal:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(true);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                            deltaY += UIConstants.HeaderHeight;
                                        }
                                        break;
                                    case UIRectTransform.ShowType.HeadLess:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(false);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown showType: " + this.data.showType.v);
                                        break;
                                }
                            }
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
                                if (this.data.internationalDraughtFenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.internationalDraughtFenUIData.v, deltaY);
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
                                    UIRectTransform.SetPosY((RectTransform)drVariant.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonDropDownHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("drVariant null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.InternationalDraught);
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
                            if (lbVariant != null)
                            {
                                lbVariant.text = txtVariant.get();
                                Setting.get().setLabelTextSize(lbVariant);
                            }
                            else
                            {
                                Debug.LogError("lbVariant null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("internationalDraught null");
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

        public InternationalDraughtFenUI internationalDraughtFenPrefab;
        private static readonly UIRectTransform internationalDraughtFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.internationalDraught.allAddCallBack(this);
                    uiData.internationalDraughtFenUIData.allAddCallBack(this);
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
            // Child
            {
                // internationalDraught
                {
                    if (data is InternationalDraught)
                    {
                        InternationalDraught internationalDraught = data as InternationalDraught;
                        // Child
                        {
                            internationalDraught.var.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is Var)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is InternationalDraughtFenUI.UIData)
                {
                    InternationalDraughtFenUI.UIData internationalDraughtFenUIData = data as InternationalDraughtFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(internationalDraughtFenUIData, internationalDraughtFenPrefab, this.transform, internationalDraughtFenRect);
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
                    uiData.internationalDraught.allRemoveCallBack(this);
                    uiData.internationalDraughtFenUIData.allRemoveCallBack(this);
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
                // internationalDraught
                {
                    if (data is InternationalDraught)
                    {
                        InternationalDraught internationalDraught = data as InternationalDraught;
                        // Child
                        {
                            internationalDraught.var.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if(data is Var)
                    {
                        return;
                    }
                }
                if (data is InternationalDraughtFenUI.UIData)
                {
                    InternationalDraughtFenUI.UIData internationalDraughtFenUIData = data as InternationalDraughtFenUI.UIData;
                    // UI
                    {
                        internationalDraughtFenUIData.removeCallBackAndDestroy(typeof(InternationalDraughtFenUI));
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
                    case UIData.Property.internationalDraught:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.internationalDraughtFenUIData:
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
                // internationalDraught
                {
                    if (wrapProperty.p is InternationalDraught)
                    {
                        switch ((InternationalDraught.Property)wrapProperty.n)
                        {
                            case InternationalDraught.Property.node:
                                break;
                            case InternationalDraught.Property.var:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case InternationalDraught.Property.lastMove:
                                break;
                            case InternationalDraught.Property.ply:
                                break;
                            case InternationalDraught.Property.captureSize:
                                break;
                            case InternationalDraught.Property.captureSquares:
                                break;
                            case InternationalDraught.Property.isCustom:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if(wrapProperty.p is Var)
                    {
                        switch ((Var.Property)wrapProperty.n)
                        {
                            case Var.Property.Variant:
                                dirty = true;
                                break;
                            case Var.Property.Book:
                                break;
                            case Var.Property.Book_Ply:
                                break;
                            case Var.Property.Book_Margin:
                                break;
                            case Var.Property.Ponder:
                                break;
                            case Var.Property.SMP:
                                break;
                            case Var.Property.SMP_Threads:
                                break;
                            case Var.Property.TT_Size:
                                break;
                            case Var.Property.BB:
                                break;
                            case Var.Property.BB_Size:
                                break;
                            case Var.Property.pickBestMove:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                if (wrapProperty.p is InternationalDraughtFenUI.UIData)
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
                InternationalDraughtFenUI.UIData internationalDraughtFenUIData = this.data.internationalDraughtFenUIData.v;
                if (internationalDraughtFenUIData != null)
                {
                    InternationalDraughtFenUI internationalDraughtFenUI = internationalDraughtFenUIData.findCallBack<InternationalDraughtFenUI>();
                    if (internationalDraughtFenUI != null)
                    {
                        Text tvFen = internationalDraughtFenUI.tvFen;
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
                        Debug.LogError("internationalDraughtFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("internationalDraughtFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}