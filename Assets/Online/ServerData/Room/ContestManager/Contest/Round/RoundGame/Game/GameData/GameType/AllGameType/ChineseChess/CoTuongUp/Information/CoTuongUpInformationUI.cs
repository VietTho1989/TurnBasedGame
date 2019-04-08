using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
    public class CoTuongUpInformationUI : UIHaveTransformDataBehavior<CoTuongUpInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<CoTuongUp>> coTuongUp;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                coTuongUp,
                showType
            }

            public UIData() : base()
            {
                this.coTuongUp = new VP<ReferenceData<CoTuongUp>>(this, (byte)Property.coTuongUp, new ReferenceData<CoTuongUp>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.CO_TUONG_UP;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://vi.wikipedia.org/wiki/C%E1%BB%9D_%C3%BAp");

        static CoTuongUpInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://vi.wikipedia.org/wiki/C%E1%BB%9D_%C3%BAp");
        }

        #endregion

        #region Refresh

        public Text lbAllowViewCapture;
        public Toggle tgAllowViewCapture;

        public Text lbAllowWatcherViewHidden;
        public Toggle tgAllowWatcherViewHidden;

        public Text lbAllowOnlyFlip;
        public Toggle tgAllowOnlyFlip;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    CoTuongUp coTuongUp = this.data.coTuongUp.v.data;
                    if (coTuongUp != null)
                    {
                        // allowViewCapture
                        {
                            if (tgAllowViewCapture != null)
                            {
                                tgAllowViewCapture.interactable = false;
                                tgAllowViewCapture.isOn = coTuongUp.allowViewCapture.v;
                            }
                            else
                            {
                                Debug.LogError("tgAllowViewCapture null");
                            }
                        }
                        // allowWatcherViewHidden
                        {
                            if (tgAllowWatcherViewHidden != null)
                            {
                                tgAllowWatcherViewHidden.interactable = false;
                                tgAllowWatcherViewHidden.isOn = coTuongUp.allowWatcherViewHidden.v;
                            }
                            else
                            {
                                Debug.LogError("tgAllowWatcherViewHidden null");
                            }
                        }
                        // allowOnlyFlip
                        {
                            if (tgAllowOnlyFlip != null)
                            {
                                tgAllowOnlyFlip.interactable = false;
                                tgAllowOnlyFlip.isOn = coTuongUp.allowOnlyFlip.v;
                            }
                            else
                            {
                                Debug.LogError("tgAllowOnlyFlip null");
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
                            // allowViewCapture
                            {
                                if (lbAllowViewCapture != null)
                                {
                                    lbAllowViewCapture.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbAllowViewCapture.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbAllowViewCapture null");
                                }
                                if (tgAllowViewCapture != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tgAllowViewCapture.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonToggleHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tgAllowViewCapture null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // allowWatcherViewHidden
                            {
                                if (lbAllowWatcherViewHidden != null)
                                {
                                    lbAllowWatcherViewHidden.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbAllowWatcherViewHidden.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbAllowWatcherViewHidden null");
                                }
                                if (tgAllowWatcherViewHidden != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tgAllowWatcherViewHidden.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonToggleHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tgAllowWatcherViewHidden null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // allowOnlyFlip
                            {
                                if (lbAllowOnlyFlip != null)
                                {
                                    lbAllowOnlyFlip.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbAllowOnlyFlip.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbAllowOnlyFlip null");
                                }
                                if (tgAllowOnlyFlip != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tgAllowOnlyFlip.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonToggleHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tgAllowOnlyFlip null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.CO_TUONG_UP);
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
                            if (lbAllowViewCapture != null)
                            {
                                lbAllowViewCapture.text = DefaultCoTuongUpUI.txtAllowViewCapture.get();
                                Setting.get().setLabelTextSize(lbAllowViewCapture);
                            }
                            else
                            {
                                Debug.LogError("lbAllowViewCapture null");
                            }
                            if (lbAllowWatcherViewHidden != null)
                            {
                                lbAllowWatcherViewHidden.text = DefaultCoTuongUpUI.txtAllowWatcherViewHidden.get();
                                Setting.get().setLabelTextSize(lbAllowWatcherViewHidden);
                            }
                            else
                            {
                                Debug.LogError("lbAllowWatcherViewHidden null");
                            }
                            if (lbAllowOnlyFlip != null)
                            {
                                lbAllowOnlyFlip.text = DefaultCoTuongUpUI.txtAllowOnlyFlip.get();
                                Setting.get().setLabelTextSize(lbAllowOnlyFlip);
                            }
                            else
                            {
                                Debug.LogError("lbAllowOnlyFlip null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("coTuongUp null");
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.coTuongUp.allAddCallBack(this);
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
            if (data is CoTuongUp)
            {
                dirty = true;
                return;
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
                    uiData.coTuongUp.allRemoveCallBack(this);
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
            if (data is CoTuongUp)
            {
                return;
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
                    case UIData.Property.coTuongUp:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
            if (wrapProperty.p is CoTuongUp)
            {
                switch ((CoTuongUp.Property)wrapProperty.n)
                {
                    case CoTuongUp.Property.allowViewCapture:
                        dirty = true;
                        break;
                    case CoTuongUp.Property.allowWatcherViewHidden:
                        dirty = true;
                        break;
                    case CoTuongUp.Property.allowOnlyFlip:
                        dirty = true;
                        break;
                    case CoTuongUp.Property.turn:
                        break;
                    case CoTuongUp.Property.side:
                        break;
                    case CoTuongUp.Property.nodes:
                        break;
                    case CoTuongUp.Property.plyDraw:
                        break;
                    case CoTuongUp.Property.isCustom:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}