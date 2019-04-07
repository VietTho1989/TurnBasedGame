using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
    public class EnglishDraughtInformationUI : UIHaveTransformDataBehavior<EnglishDraughtInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<EnglishDraught>> englishDraught;

            public VP<UIRectTransform.ShowType> showType;

            public VP<EnglishDraughtFenUI.UIData> englishDraughtFenUIData;

            #region Constructor

            public enum Property
            {
                englishDraught,
                showType,
                englishDraughtFenUIData
            }

            public UIData() : base()
            {
                this.englishDraught = new VP<ReferenceData<EnglishDraught>>(this, (byte)Property.englishDraught, new ReferenceData<EnglishDraught>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.englishDraughtFenUIData = new VP<EnglishDraughtFenUI.UIData>(this, (byte)Property.englishDraughtFenUIData, new EnglishDraughtFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.EnglishDraught;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/English_draughts");

        static EnglishDraughtInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/English_draughts");
        }

        #endregion

        #region Refresh

        public Text lbFen;
        public Button btnCopyFen;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EnglishDraught englishDraught = this.data.englishDraught.v.data;
                    if (englishDraught != null)
                    {
                        // fen
                        {
                            EnglishDraughtFenUI.UIData englishDraughtFenUIData = this.data.englishDraughtFenUIData.v;
                            if (englishDraughtFenUIData != null)
                            {
                                englishDraughtFenUIData.englishDraught.v = new ReferenceData<EnglishDraught>(englishDraught);
                            }
                            else
                            {
                                Debug.LogError("englishDraughtFenUIData null");
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
                                if (this.data.englishDraughtFenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.englishDraughtFenUIData.v, deltaY);
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
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.EnglishDraught);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            if (tvMessage != null)
                            {
                                tvMessage.text = txtMessage.get();
                            }
                            else
                            {
                                Debug.LogError("tvMessage null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("englishDraught null");
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

        public EnglishDraughtFenUI englishDraughtFenPrefab;
        private static readonly UIRectTransform englishDraughtFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.englishDraught.allAddCallBack(this);
                    uiData.englishDraughtFenUIData.allAddCallBack(this);
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
                if (data is EnglishDraught)
                {
                    dirty = true;
                    return;
                }
                if (data is EnglishDraughtFenUI.UIData)
                {
                    EnglishDraughtFenUI.UIData englishDraughtFenUIData = data as EnglishDraughtFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(englishDraughtFenUIData, englishDraughtFenPrefab, this.transform, englishDraughtFenRect);
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
                    uiData.englishDraught.allRemoveCallBack(this);
                    uiData.englishDraughtFenUIData.allRemoveCallBack(this);
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
                if (data is EnglishDraught)
                {
                    return;
                }
                if (data is EnglishDraughtFenUI.UIData)
                {
                    EnglishDraughtFenUI.UIData englishDraughtFenUIData = data as EnglishDraughtFenUI.UIData;
                    // UI
                    {
                        englishDraughtFenUIData.removeCallBackAndDestroy(typeof(EnglishDraughtFenUI));
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
                    case UIData.Property.englishDraught:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.englishDraughtFenUIData:
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
                if (wrapProperty.p is EnglishDraught)
                {
                    return;
                }
                if (wrapProperty.p is EnglishDraughtFenUI.UIData)
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
                EnglishDraughtFenUI.UIData englishDraughtFenUIData = this.data.englishDraughtFenUIData.v;
                if (englishDraughtFenUIData != null)
                {
                    EnglishDraughtFenUI englishDraughtFenUI = englishDraughtFenUIData.findCallBack<EnglishDraughtFenUI>();
                    if (englishDraughtFenUI != null)
                    {
                        Text tvFen = englishDraughtFenUI.tvFen;
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
                        Debug.LogError("englishDraughtFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("englishDraughtFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}