using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
    public class SeirawanInformationUI : UIHaveTransformDataBehavior<SeirawanInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Seirawan>> seirawan;

            public VP<UIRectTransform.ShowType> showType;

            public VP<SeirawanFenUI.UIData> seirawanFenUIData;

            #region Constructor

            public enum Property
            {
                seirawan,
                showType,
                seirawanFenUIData
            }

            public UIData() : base()
            {
                this.seirawan = new VP<ReferenceData<Seirawan>>(this, (byte)Property.seirawan, new ReferenceData<Seirawan>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.seirawanFenUIData = new VP<SeirawanFenUI.UIData>(this, (byte)Property.seirawanFenUIData, new SeirawanFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Seirawan;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            SeirawanInformationUI seirawanInformationUI = this.findCallBack<SeirawanInformationUI>();
                            if (seirawanInformationUI != null)
                            {
                                isProcess = seirawanInformationUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("seirawanInformationUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt, rect

        public Text lbTitle;

        public Text tvMessage;
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Seirawan_chess");

        static SeirawanInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Seirawan_chess");
        }

        #endregion

        #region Refresh

        public Text lbFen;
        public Button btnCopyFen;

        public Text lbChess960;
        public Toggle tgChess960;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Seirawan seirawan = this.data.seirawan.v.data;
                    if (seirawan != null)
                    {
                        // fen
                        {
                            SeirawanFenUI.UIData seirawanFenUIData = this.data.seirawanFenUIData.v;
                            if (seirawanFenUIData != null)
                            {
                                seirawanFenUIData.seirawan.v = new ReferenceData<Seirawan>(seirawan);
                            }
                            else
                            {
                                Debug.LogError("seirawanFenUIData null");
                            }
                        }
                        // tgChess960
                        {
                            if (tgChess960 != null)
                            {
                                tgChess960.interactable = false;
                                tgChess960.isOn = seirawan.chess960.v;
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
                                if (this.data.seirawanFenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.seirawanFenUIData.v, deltaY);
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Seirawan);
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
                        Debug.LogError("seirawan null");
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

        public SeirawanFenUI seirawanFenPrefab;
        private static readonly UIRectTransform seirawanFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.seirawan.allAddCallBack(this);
                    uiData.seirawanFenUIData.allAddCallBack(this);
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
                if (data is Seirawan)
                {
                    dirty = true;
                    return;
                }
                if (data is SeirawanFenUI.UIData)
                {
                    SeirawanFenUI.UIData seirawanFenUIData = data as SeirawanFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(seirawanFenUIData, seirawanFenPrefab, this.transform, seirawanFenRect);
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
                    uiData.seirawan.allRemoveCallBack(this);
                    uiData.seirawanFenUIData.allRemoveCallBack(this);
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
                if (data is Seirawan)
                {
                    return;
                }
                if (data is SeirawanFenUI.UIData)
                {
                    SeirawanFenUI.UIData seirawanFenUIData = data as SeirawanFenUI.UIData;
                    // UI
                    {
                        seirawanFenUIData.removeCallBackAndDestroy(typeof(SeirawanFenUI));
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
                    case UIData.Property.seirawan:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.seirawanFenUIData:
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
                    case Setting.Property.buttonSize:
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
                            break;
                        case Seirawan.Property.st:
                            break;
                        case Seirawan.Property.chess960:
                            dirty = true;
                            break;
                        case Seirawan.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is SeirawanFenUI.UIData)
                {
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
                UIUtils.SetButtonOnClick(btnCopyFen, onClickBtnCopyFen);
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
                        case KeyCode.C:
                            {
                                if (btnCopyFen != null && btnCopyFen.gameObject.activeInHierarchy && btnCopyFen.interactable)
                                {
                                    this.onClickBtnCopyFen();
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

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnCopyFen()
        {
            if (this.data != null)
            {
                SeirawanFenUI.UIData seirawanFenUIData = this.data.seirawanFenUIData.v;
                if (seirawanFenUIData != null)
                {
                    SeirawanFenUI seirawanFenUI = seirawanFenUIData.findCallBack<SeirawanFenUI>();
                    if (seirawanFenUI != null)
                    {
                        Text tvFen = seirawanFenUI.tvFen;
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
                        Debug.LogError("seirawanFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("seirawanFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}