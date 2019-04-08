using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
{
    public class MakrukInformationUI : UIHaveTransformDataBehavior<MakrukInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Makruk>> makruk;

            public VP<UIRectTransform.ShowType> showType;

            public VP<MakrukFenUI.UIData> makrukFenUIData;

            #region Constructor

            public enum Property
            {
                makruk,
                showType,
                makrukFenUIData
            }

            public UIData() : base()
            {
                this.makruk = new VP<ReferenceData<Makruk>>(this, (byte)Property.makruk, new ReferenceData<Makruk>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.makrukFenUIData = new VP<MakrukFenUI.UIData>(this, (byte)Property.makrukFenUIData, new MakrukFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Makruk;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Makruk");

        static MakrukInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Makruk");
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
                    Makruk makruk = this.data.makruk.v.data;
                    if (makruk != null)
                    {
                        // fen
                        {
                            MakrukFenUI.UIData makrukFenUIData = this.data.makrukFenUIData.v;
                            if (makrukFenUIData != null)
                            {
                                makrukFenUIData.makruk.v = new ReferenceData<Makruk>(makruk);
                            }
                            else
                            {
                                Debug.LogError("makrukFenUIData null");
                            }
                        }
                        // tgChess960
                        {
                            if (tgChess960 != null)
                            {
                                tgChess960.interactable = false;
                                tgChess960.isOn = makruk.chess960.v;
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
                                if (this.data.makrukFenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.makrukFenUIData.v, deltaY);
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Makruk);
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
                        Debug.LogError("makruk null");
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

        public MakrukFenUI makrukFenPrefab;
        private static readonly UIRectTransform makrukFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.makruk.allAddCallBack(this);
                    uiData.makrukFenUIData.allAddCallBack(this);
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
                if (data is Makruk)
                {
                    dirty = true;
                    return;
                }
                if (data is MakrukFenUI.UIData)
                {
                    MakrukFenUI.UIData makrukFenUIData = data as MakrukFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(makrukFenUIData, makrukFenPrefab, this.transform, makrukFenRect);
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
                    uiData.makruk.allRemoveCallBack(this);
                    uiData.makrukFenUIData.allRemoveCallBack(this);
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
                if (data is Makruk)
                {
                    return;
                }
                if (data is MakrukFenUI.UIData)
                {
                    MakrukFenUI.UIData makrukFenUIData = data as MakrukFenUI.UIData;
                    // UI
                    {
                        makrukFenUIData.removeCallBackAndDestroy(typeof(MakrukFenUI));
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
                    case UIData.Property.makruk:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.makrukFenUIData:
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
                if (wrapProperty.p is Makruk)
                {
                    switch ((Makruk.Property)wrapProperty.n)
                    {
                        case Makruk.Property.board:
                            break;
                        case Makruk.Property.byTypeBB:
                            break;
                        case Makruk.Property.byColorBB:
                            break;
                        case Makruk.Property.pieceCount:
                            break;
                        case Makruk.Property.pieceList:
                            break;
                        case Makruk.Property.index:
                            break;
                        case Makruk.Property.gamePly:
                            break;
                        case Makruk.Property.sideToMove:
                            break;
                        case Makruk.Property.st:
                            break;
                        case Makruk.Property.chess960:
                            dirty = true;
                            break;
                        case Makruk.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is MakrukFenUI.UIData)
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
                MakrukFenUI.UIData makrukFenUIData = this.data.makrukFenUIData.v;
                if (makrukFenUIData != null)
                {
                    MakrukFenUI makrukFenUI = makrukFenUIData.findCallBack<MakrukFenUI>();
                    if (makrukFenUI != null)
                    {
                        Text tvFen = makrukFenUI.tvFen;
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
                        Debug.LogError("makrukFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("makrukFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}