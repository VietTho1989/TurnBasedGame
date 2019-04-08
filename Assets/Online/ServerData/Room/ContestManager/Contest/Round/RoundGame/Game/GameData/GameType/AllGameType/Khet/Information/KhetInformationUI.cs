using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class KhetInformationUI : UIHaveTransformDataBehavior<KhetInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Khet>> khet;

            public VP<UIRectTransform.ShowType> showType;

            public VP<FenUI.UIData> fenUIData;

            #region Constructor

            public enum Property
            {
                khet,
                showType,
                fenUIData
            }

            public UIData() : base()
            {
                this.khet = new VP<ReferenceData<Khet>>(this, (byte)Property.khet, new ReferenceData<Khet>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.fenUIData = new VP<FenUI.UIData>(this, (byte)Property.fenUIData, new FenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Khet;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Khet_(game)");

        public Text lbFen;
        public Button btnCopyFen;

        public Text lbStartPos;
        public Dropdown drStartPos;
        private static readonly TxtLanguage txtStartPos = new TxtLanguage("Start pos");

        static KhetInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Khet_(game)");
            txtStartPos.add(Language.Type.vi, "Vị trí bắt đầu");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Khet khet = this.data.khet.v.data;
                    if (khet != null)
                    {
                        // fen
                        {
                            FenUI.UIData fenUIData = this.data.fenUIData.v;
                            if (fenUIData != null)
                            {
                                fenUIData.khet.v = new ReferenceData<Khet>(khet);
                            }
                            else
                            {
                                Debug.LogError("fenUIData null");
                            }
                        }
                        // startPos
                        {
                            if (drStartPos != null)
                            {
                                // options
                                {
                                    List<string> options = new List<string>();
                                    {
                                        options.Add("Standard");
                                        options.Add("Dynasty");
                                        options.Add("Imhotep");
                                        options.Add("Unknown");
                                    }
                                    UIUtils.RefreshDropDownOptions(drStartPos, options);
                                }
                                drStartPos.interactable = false;
                                drStartPos.value = (int)khet.startPos.v;
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
                                if (this.data.fenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.fenUIData.v, deltaY);
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
                            // startPos
                            {
                                if (lbStartPos != null)
                                {
                                    lbStartPos.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbStartPos.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbStartPos null");
                                }
                                if (drStartPos != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)drStartPos.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonDropDownHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("drStartPos null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Khet);
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
                            if (lbStartPos != null)
                            {
                                lbStartPos.text = txtStartPos.get();
                                Setting.get().setLabelTextSize(lbStartPos);
                            }
                            else
                            {
                                Debug.LogError("lbStartPos null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("khet null");
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

        public FenUI fenPrefab;
        private static readonly UIRectTransform fenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.khet.allAddCallBack(this);
                    uiData.fenUIData.allAddCallBack(this);
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
                if (data is Khet)
                {
                    dirty = true;
                    return;
                }
                if (data is FenUI.UIData)
                {
                    FenUI.UIData fenUIData = data as FenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(fenUIData, fenPrefab, this.transform, fenRect);
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
                    uiData.khet.allRemoveCallBack(this);
                    uiData.fenUIData.allRemoveCallBack(this);
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
                if (data is Khet)
                {
                    return;
                }
                if (data is FenUI.UIData)
                {
                    FenUI.UIData fenUIData = data as FenUI.UIData;
                    // UI
                    {
                        fenUIData.removeCallBackAndDestroy(typeof(FenUI));
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
                    case UIData.Property.khet:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.fenUIData:
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
                if (wrapProperty.p is Khet)
                {
                    switch ((Khet.Property)wrapProperty.n)
                    {
                        case Khet.Property._playerToMove:
                            break;
                        case Khet.Property._checkmate:
                            break;
                        case Khet.Property._drawn:
                            break;
                        case Khet.Property._moveNumber:
                            break;
                        case Khet.Property._laser:
                            break;
                        case Khet.Property._board:
                            break;
                        case Khet.Property._pharaohPositions:
                            break;
                        case Khet.Property.khetSub:
                            break;
                        case Khet.Property.isCustom:
                            break;
                        case Khet.Property.startPos:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is FenUI.UIData)
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
                FenUI.UIData fenUIData = this.data.fenUIData.v;
                if (fenUIData != null)
                {
                    FenUI fenUI = fenUIData.findCallBack<FenUI>();
                    if (fenUI != null)
                    {
                        Text tvFen = fenUI.tvFen;
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
                        Debug.LogError("fenUI null");
                    }
                }
                else
                {
                    Debug.LogError("fenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}