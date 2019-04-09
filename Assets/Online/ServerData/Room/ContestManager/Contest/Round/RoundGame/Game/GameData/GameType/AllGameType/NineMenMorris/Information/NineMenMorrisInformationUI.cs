using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class NineMenMorrisInformationUI : UIHaveTransformDataBehavior<NineMenMorrisInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<NineMenMorris>> nineMenMorris;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                nineMenMorris,
                showType
            }

            public UIData() : base()
            {
                this.nineMenMorris = new VP<ReferenceData<NineMenMorris>>(this, (byte)Property.nineMenMorris, new ReferenceData<NineMenMorris>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.NineMenMorris;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Nine_men%27s_morris");

        public Text lbWhiteCount;
        public Text tvWhiteCount;
        private static readonly TxtLanguage txtWhiteCount = new TxtLanguage("White count");

        public Text lbBlackCount;
        public Text tvBlackCount;
        private static readonly TxtLanguage txtBlackCount = new TxtLanguage("Black count");

        static NineMenMorrisInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Nine_men%27s_morris");
            txtWhiteCount.add(Language.Type.vi, "Số quân trắng");
            txtBlackCount.add(Language.Type.vi, "Số quân đen");
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
                    NineMenMorris nineMenMorris = this.data.nineMenMorris.v.data;
                    if (nineMenMorris != null)
                    {
                        int whiteCount = 0;
                        int blackCount = 0;
                        {
                            foreach(int piece in nineMenMorris.board.vs)
                            {
                                switch ((Common.SpotStatus)piece)
                                {
                                    case Common.SpotStatus.SS_Empty:
                                        break;
                                    case Common.SpotStatus.SS_Black:
                                        blackCount++;
                                        break;
                                    case Common.SpotStatus.SS_White:
                                        whiteCount++;
                                        break;
                                    default:
                                        Debug.LogError("unknown piece: " + piece);
                                        break;
                                }
                            }
                        }
                        // white count
                        {
                            if (tvWhiteCount != null)
                            {
                                tvWhiteCount.text = "" + whiteCount;
                                Setting.get().setContentTextSize(tvWhiteCount);
                            }
                            else
                            {
                                Debug.LogError("tvWhiteCount null");
                            }
                        }
                        // black count
                        {
                            if (tvBlackCount != null)
                            {
                                tvBlackCount.text = "" + blackCount;
                                Setting.get().setContentTextSize(tvBlackCount);
                            }
                            else
                            {
                                Debug.LogError("tvBlackCount null");
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
                            // whiteCount
                            {
                                if (lbWhiteCount != null)
                                {
                                    lbWhiteCount.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbWhiteCount.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbWhiteCount null");
                                }
                                if (tvWhiteCount != null)
                                {
                                    UIRectTransform.SetPosY(tvWhiteCount.rectTransform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvWhiteCount null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // blackCount
                            {
                                if (lbBlackCount != null)
                                {
                                    lbBlackCount.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbBlackCount.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbBlackCount null");
                                }
                                if (tvBlackCount != null)
                                {
                                    UIRectTransform.SetPosY(tvBlackCount.rectTransform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvBlackCount null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.NineMenMorris);
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
                            if (lbWhiteCount != null)
                            {
                                lbWhiteCount.text = txtWhiteCount.get();
                                Setting.get().setLabelTextSize(lbWhiteCount);
                            }
                            else
                            {
                                Debug.LogError("lbWhiteCount null");
                            }
                            if (lbBlackCount != null)
                            {
                                lbBlackCount.text = txtBlackCount.get();
                                Setting.get().setLabelTextSize(lbBlackCount);
                            }
                            else
                            {
                                Debug.LogError("lbBlackCount null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("nineMenMorris null");
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
                    uiData.nineMenMorris.allAddCallBack(this);
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
            if (data is NineMenMorris)
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
                    uiData.nineMenMorris.allRemoveCallBack(this);
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
            if (data is NineMenMorris)
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
                    case UIData.Property.nineMenMorris:
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
            if (wrapProperty.p is NineMenMorris)
            {
                switch ((NineMenMorris.Property)wrapProperty.n)
                {
                    case NineMenMorris.Property.board:
                        dirty = true;
                        break;
                    case NineMenMorris.Property.moved:
                        break;
                    case NineMenMorris.Property.moved_to:
                        break;
                    case NineMenMorris.Property.action:
                        break;
                    case NineMenMorris.Property.mill:
                        break;
                    case NineMenMorris.Property.terminal:
                        break;
                    case NineMenMorris.Property.removed:
                        break;
                    case NineMenMorris.Property.utility:
                        break;
                    case NineMenMorris.Property.turn:
                        break;
                    case NineMenMorris.Property.isCustom:
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