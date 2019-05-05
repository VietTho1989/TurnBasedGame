using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
    public class ShatranjInformationUI : UIHaveTransformDataBehavior<ShatranjInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Shatranj>> shatranj;

            public VP<UIRectTransform.ShowType> showType;

            public VP<ShatranjFenUI.UIData> shatranjFenUIData;

            #region Constructor

            public enum Property
            {
                shatranj,
                showType,
                shatranjFenUIData
            }

            public UIData() : base()
            {
                this.shatranj = new VP<ReferenceData<Shatranj>>(this, (byte)Property.shatranj, new ReferenceData<Shatranj>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.shatranjFenUIData = new VP<ShatranjFenUI.UIData>(this, (byte)Property.shatranjFenUIData, new ShatranjFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Shatranj;
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
                            ShatranjInformationUI shatranjInformationUI = this.findCallBack<ShatranjInformationUI>();
                            if (shatranjInformationUI != null)
                            {
                                isProcess = shatranjInformationUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("shatranjInformationUI null: " + this);
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Shatranj");

        static ShatranjInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Shatranj");
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
                    Shatranj shatranj = this.data.shatranj.v.data;
                    if (shatranj != null)
                    {
                        // fen
                        {
                            ShatranjFenUI.UIData shatranjFenUIData = this.data.shatranjFenUIData.v;
                            if (shatranjFenUIData != null)
                            {
                                shatranjFenUIData.shatranj.v = new ReferenceData<Shatranj>(shatranj);
                            }
                            else
                            {
                                Debug.LogError("shatranjFenUIData null");
                            }
                        }
                        // tgChess960
                        {
                            if (tgChess960 != null)
                            {
                                tgChess960.interactable = false;
                                tgChess960.isOn = shatranj.chess960.v;
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
                                if (this.data.shatranjFenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.shatranjFenUIData.v, deltaY);
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Shatranj);
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
                        Debug.LogError("shatranj null");
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

        public ShatranjFenUI shatranjFenPrefab;
        private static readonly UIRectTransform shatranjFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.shatranj.allAddCallBack(this);
                    uiData.shatranjFenUIData.allAddCallBack(this);
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
                if (data is Shatranj)
                {
                    dirty = true;
                    return;
                }
                if (data is ShatranjFenUI.UIData)
                {
                    ShatranjFenUI.UIData shatranjFenUIData = data as ShatranjFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(shatranjFenUIData, shatranjFenPrefab, this.transform, shatranjFenRect);
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
                    uiData.shatranj.allRemoveCallBack(this);
                    uiData.shatranjFenUIData.allRemoveCallBack(this);
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
                if (data is Shatranj)
                {
                    return;
                }
                if (data is ShatranjFenUI.UIData)
                {
                    ShatranjFenUI.UIData shatranjFenUIData = data as ShatranjFenUI.UIData;
                    // UI
                    {
                        shatranjFenUIData.removeCallBackAndDestroy(typeof(ShatranjFenUI));
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
                    case UIData.Property.shatranj:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.shatranjFenUIData:
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
                if (wrapProperty.p is Shatranj)
                {
                    switch ((Shatranj.Property)wrapProperty.n)
                    {
                        case Shatranj.Property.board:
                            break;
                        case Shatranj.Property.byTypeBB:
                            break;
                        case Shatranj.Property.byColorBB:
                            break;
                        case Shatranj.Property.pieceCount:
                            break;
                        case Shatranj.Property.pieceList:
                            break;
                        case Shatranj.Property.index:
                            break;
                        case Shatranj.Property.gamePly:
                            break;
                        case Shatranj.Property.sideToMove:
                            break;
                        case Shatranj.Property.st:
                            break;
                        case Shatranj.Property.chess960:
                            dirty = true;
                            break;
                        case Shatranj.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is ShatranjFenUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnCopyFen()
        {
            if (this.data != null)
            {
                ShatranjFenUI.UIData shatranjFenUIData = this.data.shatranjFenUIData.v;
                if (shatranjFenUIData != null)
                {
                    ShatranjFenUI shatranjFenUI = shatranjFenUIData.findCallBack<ShatranjFenUI>();
                    if (shatranjFenUI != null)
                    {
                        Text tvFen = shatranjFenUI.tvFen;
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
                        Debug.LogError("shatranjFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("shatranjFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}