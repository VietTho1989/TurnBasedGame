using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
    public class XiangqiInformationUI : UIHaveTransformDataBehavior<XiangqiInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Xiangqi>> xiangqi;

            public VP<UIRectTransform.ShowType> showType;

            public VP<XiangqiFenUI.UIData> xiangqiFenUIData;

            #region Constructor

            public enum Property
            {
                xiangqi,
                showType,
                xiangqiFenUIData
            }

            public UIData() : base()
            {
                this.xiangqi = new VP<ReferenceData<Xiangqi>>(this, (byte)Property.xiangqi, new ReferenceData<Xiangqi>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                this.xiangqiFenUIData = new VP<XiangqiFenUI.UIData>(this, (byte)Property.xiangqiFenUIData, new XiangqiFenUI.UIData());
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Xiangqi;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Xiangqi");

        static XiangqiInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://vi.wikipedia.org/wiki/C%E1%BB%9D_t%C6%B0%E1%BB%9Bng");
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
                    Xiangqi xiangqi = this.data.xiangqi.v.data;
                    if (xiangqi != null)
                    {
                        // fen
                        {
                            XiangqiFenUI.UIData xiangqiFenUIData = this.data.xiangqiFenUIData.v;
                            if (xiangqiFenUIData != null)
                            {
                                xiangqiFenUIData.xiangqi.v = new ReferenceData<Xiangqi>(xiangqi);
                            }
                            else
                            {
                                Debug.LogError("xiangqiFenUIData null");
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
                                if (this.data.xiangqiFenUIData.v != null)
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
                                    UIRectTransform.SetPosY(this.data.xiangqiFenUIData.v, deltaY);
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Xiangqi);
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
                        }
                    }
                    else
                    {
                        Debug.LogError("xiangqi null");
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

        public XiangqiFenUI xiangqiFenPrefab;
        private static readonly UIRectTransform xiangqiFenRect = UIRectTransform.createRequestRect(90, 50, 60);

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.xiangqi.allAddCallBack(this);
                    uiData.xiangqiFenUIData.allAddCallBack(this);
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
                if (data is Xiangqi)
                {
                    dirty = true;
                    return;
                }
                if (data is XiangqiFenUI.UIData)
                {
                    XiangqiFenUI.UIData xiangqiFenUIData = data as XiangqiFenUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(xiangqiFenUIData, xiangqiFenPrefab, this.transform, xiangqiFenRect);
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
                    uiData.xiangqi.allRemoveCallBack(this);
                    uiData.xiangqiFenUIData.allRemoveCallBack(this);
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
                if (data is Xiangqi)
                {
                    return;
                }
                if (data is XiangqiFenUI.UIData)
                {
                    XiangqiFenUI.UIData xiangqiFenUIData = data as XiangqiFenUI.UIData;
                    // UI
                    {
                        xiangqiFenUIData.removeCallBackAndDestroy(typeof(XiangqiFenUI));
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
                    case UIData.Property.xiangqi:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.xiangqiFenUIData:
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
                if (wrapProperty.p is Xiangqi)
                {
                    return;
                }
                if (wrapProperty.p is XiangqiFenUI.UIData)
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
                XiangqiFenUI.UIData xiangqiFenUIData = this.data.xiangqiFenUIData.v;
                if (xiangqiFenUIData != null)
                {
                    XiangqiFenUI xiangqiFenUI = xiangqiFenUIData.findCallBack<XiangqiFenUI>();
                    if (xiangqiFenUI != null)
                    {
                        Text tvFen = xiangqiFenUI.tvFen;
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
                        Debug.LogError("xiangqiFenUI null");
                    }
                }
                else
                {
                    Debug.LogError("xiangqiFenUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}