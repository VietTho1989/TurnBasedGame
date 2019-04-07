using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class SolitaireInformationUI : UIHaveTransformDataBehavior<SolitaireInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Solitaire>> solitaire;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                solitare,
                showType
            }

            public UIData() : base()
            {
                this.solitaire = new VP<ReferenceData<Solitaire>>(this, (byte)Property.solitare, new ReferenceData<Solitaire>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Solitaire;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Patience_(game)");

        public Text lbDrawCount;
        public Text tvDrawCount;
        private static readonly TxtLanguage txtDrawCount = new TxtLanguage("Draw count");

        static SolitaireInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://en.wikipedia.org/wiki/Patience_(game)");
            txtDrawCount.add(Language.Type.vi, "Số quân bài rút");
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
                    Solitaire solitaire = this.data.solitaire.v.data;
                    if (solitaire != null)
                    {
                        // drawCount
                        {
                            if (tvDrawCount != null)
                            {
                                tvDrawCount.text = "" + solitaire.drawCount.v;
                            }
                            else
                            {
                                Debug.LogError("tvDrawCount null");
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
                            // drawCount
                            {
                                if (lbDrawCount != null)
                                {
                                    lbDrawCount.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbDrawCount.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbDrawCount null");
                                }
                                if (tvDrawCount != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tvDrawCount.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvDrawCount null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Solitaire);
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
                            if (lbDrawCount != null)
                            {
                                lbDrawCount.text = txtDrawCount.get();
                            }
                            else
                            {
                                Debug.LogError("lbBoardSize null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("solitaire null");
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
                    uiData.solitaire.allAddCallBack(this);
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
            if (data is Solitaire)
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
                    uiData.solitaire.allRemoveCallBack(this);
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
            if (data is Solitaire)
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
                    case UIData.Property.solitare:
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
            if (wrapProperty.p is Solitaire)
            {
                switch ((Solitaire.Property)wrapProperty.n)
                {
                    case Solitaire.Property.piles:
                        break;
                    case Solitaire.Property.cards:
                        break;
                    case Solitaire.Property.movesAvailableCount:
                        break;
                    case Solitaire.Property.movesAvailable:
                        break;
                    case Solitaire.Property.drawCount:
                        dirty = true;
                        break;
                    case Solitaire.Property.roundCount:
                        break;
                    case Solitaire.Property.foundationCount:
                        break;
                    case Solitaire.Property.solvedMoves:
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