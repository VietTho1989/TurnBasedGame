using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class HexInformationUI : UIHaveTransformDataBehavior<HexInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Hex>> hex;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                hex,
                showType
            }

            public UIData() : base()
            {
                this.hex = new VP<ReferenceData<Hex>>(this, (byte)Property.hex, new ReferenceData<Hex>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Hex;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage();

        private static readonly TxtLanguage txtBoardSize = new TxtLanguage();

        private static readonly TxtLanguage txtIsSwitch = new TxtLanguage();

        static HexInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Hex_(board_game)");
            txtBoardSize.add(Language.Type.vi, "Kích thước bàn cờ");
            txtIsSwitch.add(Language.Type.vi, "Đổi bên");
        }

        #endregion

        #region Refresh

        public Text lbBoardSize;
        public Text tvBoardSize;

        public Text lbIsSwitch;
        public Toggle tgIsSwitch;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Hex hex = this.data.hex.v.data;
                    if (hex != null)
                    {
                        // boardSize
                        {
                            if (tvBoardSize != null)
                            {
                                tvBoardSize.text = "" + hex.boardSize.v;
                            }
                            else
                            {
                                Debug.LogError("tvBoardSize null");
                            }
                        }
                        // isSwitch
                        {
                            if (tgIsSwitch != null)
                            {
                                tgIsSwitch.isOn = false;
                                tgIsSwitch.isOn = hex.isSwitch.v;
                            }
                            else
                            {
                                Debug.LogError("tgIsSwitch nulll");
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
                            // boardSize
                            {
                                if (lbBoardSize != null)
                                {
                                    lbBoardSize.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbBoardSize.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbBoardSize null");
                                }
                                if (tvBoardSize != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tvBoardSize.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvBoardSize null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // isSwitch
                            {
                                if (lbIsSwitch != null)
                                {
                                    lbIsSwitch.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbIsSwitch.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbIsSwitch null");
                                }
                                if (tgIsSwitch != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tgIsSwitch.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonToggleHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tgIsSwitch null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Hex);
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                            if (tvMessage != null)
                            {
                                tvMessage.text = txtMessage.get("https://en.wikipedia.org/wiki/Hex_(board_game)");
                            }
                            else
                            {
                                Debug.LogError("tvMessage null");
                            }
                            if (lbBoardSize != null)
                            {
                                lbBoardSize.text = txtBoardSize.get("Board size");
                            }
                            else
                            {
                                Debug.LogError("lbBoardSize null");
                            }
                            if (lbIsSwitch != null)
                            {
                                lbIsSwitch.text = txtIsSwitch.get("Switch side");
                            }
                            else
                            {
                                Debug.LogError("lbIsSwitch null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("hex null");
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
                    uiData.hex.allAddCallBack(this);
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
            if (data is Hex)
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
                    uiData.hex.allRemoveCallBack(this);
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
            if (data is Hex)
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
                    case UIData.Property.hex:
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
            if (wrapProperty.p is Hex)
            {
                switch ((Hex.Property)wrapProperty.n)
                {
                    case Hex.Property.boardSize:
                        dirty = true;
                        break;
                    case Hex.Property.board:
                        break;
                    case Hex.Property.isSwitch:
                        dirty = true;
                        break;
                    case Hex.Property.isCustom:
                        break;
                    case Hex.Property.playerIndex:
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