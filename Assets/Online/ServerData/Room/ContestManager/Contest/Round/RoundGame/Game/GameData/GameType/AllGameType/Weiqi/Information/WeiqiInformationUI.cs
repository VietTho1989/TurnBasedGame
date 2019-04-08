using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
    public class WeiqiInformationUI : UIHaveTransformDataBehavior<WeiqiInformationUI.UIData>
    {

        #region UIData

        public class UIData : GameTypeInformationUI.UIData.Sub
        {

            public VP<ReferenceData<Weiqi>> weiqi;

            public VP<UIRectTransform.ShowType> showType;

            #region Constructor

            public enum Property
            {
                weiqi,
                showType
            }

            public UIData() : base()
            {
                this.weiqi = new VP<ReferenceData<Weiqi>>(this, (byte)Property.weiqi, new ReferenceData<Weiqi>(null));
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Weiqi;
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
        private static readonly TxtLanguage txtMessage = new TxtLanguage("https://en.wikipedia.org/wiki/Go_(game)");

        public Text lbSize;
        public Text tvSize;
        private static readonly TxtLanguage txtSize = new TxtLanguage("Size");

        public Text lbKomi;
        public Text tvKomi;
        private static readonly TxtLanguage txtKomi = new TxtLanguage("Komi");

        public Text lbRule;
        public Dropdown drRule;
        private static readonly TxtLanguage txtRule = new TxtLanguage("Rule");

        public Text lbHandicap;
        public Text tvHandicap;
        private static readonly TxtLanguage txtHandicap = new TxtLanguage("Handicap");

        static WeiqiInformationUI()
        {
            txtMessage.add(Language.Type.vi, "https://vi.wikipedia.org/wiki/C%E1%BB%9D_v%C3%A2y");
            txtSize.add(Language.Type.vi, "Kích thước");
            txtKomi.add(Language.Type.vi, "Komi");
            txtRule.add(Language.Type.vi, "Luật");
            txtHandicap.add(Language.Type.vi, "Chấp");
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
                    Weiqi weiqi = this.data.weiqi.v.data;
                    if (weiqi != null)
                    {
                        Board board = weiqi.b.v;
                        if (board != null)
                        {
                            // size
                            {
                                if (tvSize != null)
                                {
                                    tvSize.text = "" + (board.size.v - 2);
                                    Setting.get().setContentTextSize(tvSize);
                                }
                                else
                                {
                                    Debug.LogError("tvSize null");
                                }
                            }
                            // komi
                            {
                                if (tvKomi != null)
                                {
                                    tvKomi.text = "" + board.komi.v;
                                    Setting.get().setContentTextSize(tvKomi);
                                }
                                else
                                {
                                    Debug.LogError("tvKomi null");
                                }
                            }
                            // rule
                            {
                                if (drRule != null)
                                {
                                    // options
                                    {
                                        List<string> options = new List<string>();
                                        {
                                            options.Add("Chinese");
                                            options.Add("AGA");
                                            options.Add("New Zealand");
                                            options.Add("Japanese");
                                            options.Add("Stones Only");
                                            options.Add("SIMING");
                                        }
                                        UIUtils.RefreshDropDownOptions(drRule, options);
                                    }
                                    // value
                                    drRule.value = board.rules.v;
                                }
                                else
                                {
                                    Debug.LogError("drRule null");
                                }
                            }
                            // handicap
                            {
                                if (tvHandicap != null)
                                {
                                    tvHandicap.text = "" + board.handicap.v;
                                    Setting.get().setContentTextSize(tvHandicap);
                                }
                                else
                                {
                                    Debug.LogError("tvHandicap null");
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("board null");
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
                            // size
                            {
                                if (lbSize != null)
                                {
                                    lbSize.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbSize.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbSize null");
                                }
                                if (tvSize != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tvSize.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvSize null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // komi
                            {
                                if (lbKomi != null)
                                {
                                    lbKomi.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbKomi.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbKomi null");
                                }
                                if (tvKomi != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tvKomi.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvKomi null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // rule
                            {
                                if (lbRule != null)
                                {
                                    lbRule.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbRule.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbRule null");
                                }
                                if (drRule != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)drRule.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonDropDownHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("drRule null");
                                }
                                deltaY += UIConstants.ItemHeight;
                            }
                            // handicap
                            {
                                if (lbHandicap != null)
                                {
                                    lbHandicap.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbHandicap.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbHandicap null");
                                }
                                if (tvHandicap != null)
                                {
                                    UIRectTransform.SetPosY((RectTransform)tvHandicap.transform, deltaY + (UIConstants.ItemHeight - UIRectTransform.CommonTextHeight) / 2);
                                }
                                else
                                {
                                    Debug.LogError("tvHandicap null");
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
                                lbTitle.text = GameType.GetStrGameType(GameType.Type.Weiqi);
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
                            if (lbSize != null)
                            {
                                lbSize.text = txtSize.get();
                                Setting.get().setLabelTextSize(lbSize);
                            }
                            else
                            {
                                Debug.LogError("lbSize null");
                            }
                            if (lbKomi != null)
                            {
                                lbKomi.text = txtKomi.get();
                                Setting.get().setLabelTextSize(lbKomi);
                            }
                            else
                            {
                                Debug.LogError("lbKomi null");
                            }
                            if (lbRule != null)
                            {
                                lbRule.text = txtRule.get();
                                Setting.get().setLabelTextSize(lbRule);
                            }
                            else
                            {
                                Debug.LogError("lbRule null");
                            }
                            if (lbHandicap != null)
                            {
                                lbHandicap.text = txtHandicap.get();
                                Setting.get().setLabelTextSize(lbHandicap);
                            }
                            else
                            {
                                Debug.LogError("lbHandicap null");
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
                    uiData.weiqi.allAddCallBack(this);
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
                if (data is Weiqi)
                {
                    Weiqi weiqi = data as Weiqi;
                    // Child
                    {
                        weiqi.b.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is Board)
                {
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
                    uiData.weiqi.allRemoveCallBack(this);
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
                if (data is Weiqi)
                {
                    Weiqi weiqi = data as Weiqi;
                    // Child
                    {
                        weiqi.b.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if(data is Board)
                {
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
                    case UIData.Property.weiqi:
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
            {
                if (wrapProperty.p is Weiqi)
                {
                    switch ((Weiqi.Property)wrapProperty.n)
                    {
                        case Weiqi.Property.b:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case Weiqi.Property.deadgroup:
                            break;
                        case Weiqi.Property.scoreOwnerMap:
                            break;
                        case Weiqi.Property.scoreOwnerMapSize:
                            break;
                        case Weiqi.Property.scoreBlack:
                            break;
                        case Weiqi.Property.scoreWhite:
                            break;
                        case Weiqi.Property.dame:
                            break;
                        case Weiqi.Property.score:
                            break;
                        case Weiqi.Property.isCustom:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if(wrapProperty.p is Board)
                {
                    switch ((Board.Property)wrapProperty.n)
                    {
                        case Board.Property.size:
                            dirty = true;
                            break;
                        case Board.Property.size2:
                            break;
                        case Board.Property.bits2:
                            break;
                        case Board.Property.captures:
                            break;
                        case Board.Property.komi:
                            dirty = true;
                            break;
                        case Board.Property.handicap:
                            dirty = true;
                            break;
                        case Board.Property.rules:
                            dirty = true;
                            break;
                        case Board.Property.moves:
                            break;
                        case Board.Property.last_move:
                            break;
                        case Board.Property.last_move2:
                            break;
                        case Board.Property.last_move3:
                            break;
                        case Board.Property.last_move4:
                            break;
                        case Board.Property.superko_violation:
                            break;
                        case Board.Property.b:
                            break;
                        case Board.Property.g:
                            break;
                        case Board.Property.pp:
                            break;
                        case Board.Property.pat3:
                            break;
                        case Board.Property.gi:
                            break;
                        case Board.Property.c:
                            break;
                        case Board.Property.clen:
                            break;
                        case Board.Property.symmetry:
                            break;
                        case Board.Property.last_ko:
                            break;
                        case Board.Property.last_ko_age:
                            break;
                        case Board.Property.ko:
                            break;
                        case Board.Property.quicked:
                            break;
                        case Board.Property.history_hash:
                            break;
                        case Board.Property.hash:
                            break;
                        case Board.Property.qhash:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}