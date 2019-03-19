using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class BtnBracketUI : UIBehavior<BtnBracketUI.UIData>
    {

        #region UIData

        public class UIData : RoomBtnUI.UIData.Sub
        {

            public VP<ReferenceData<BracketUI.UIData>> bracketUIData;

            #region Constructor

            public enum Property
            {
                bracketUIData
            }

            public UIData() : base()
            {
                this.bracketUIData = new VP<ReferenceData<BracketUI.UIData>>(this, (byte)Property.bracketUIData, new ReferenceData<BracketUI.UIData>(null));
            }

            #endregion

            public override Type getType()
            {
                return Type.Bracket;
            }

        }

        #endregion

        #region txt

        public static readonly TxtLanguage txtBracket = new TxtLanguage();

        static BtnBracketUI()
        {
            txtBracket.add(Language.Type.vi, "Trận đấu nhánh");
        }

        #endregion

        #region Refresh

        public Text tvBracket;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    BracketUI.UIData bracketUIData = this.data.bracketUIData.v.data;
                    if (bracketUIData != null)
                    {
                        // tvBracket
                        {
                            if (tvBracket != null)
                            {
                                int bracketContestIndex = 0;
                                int bracketContestCount = 0;
                                {
                                    // bracketContestIndex
                                    {
                                        BracketContestUI.UIData bracketContestUIData = bracketUIData.bracketContestUIData.v;
                                        if (bracketContestUIData != null)
                                        {
                                            BracketContest bracketContest = bracketContestUIData.bracketContest.v.data;
                                            if (bracketContest != null)
                                            {
                                                bracketContestIndex = bracketContest.index.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("bracketContest null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("bracketContestUIData null: " + this);
                                        }
                                    }
                                    // bracketContestCount
                                    {
                                        Bracket bracket = bracketUIData.bracket.v.data;
                                        if (bracket != null)
                                        {
                                            foreach (BracketContest bracketContest in bracket.bracketContests.vs)
                                            {
                                                if (bracketContest.isActive.v)
                                                {
                                                    bracketContestCount++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("bracket null: " + this);
                                        }
                                    }
                                }
                                tvBracket.text = txtBracket.get("Bracket Contest") + " " + (bracketContestIndex + 1) + "/" + bracketContestCount;
                            }
                            else
                            {
                                Debug.LogError("tvBracket null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("bracketUIData null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
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
                    uiData.bracketUIData.allAddCallBack(this);
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
                if (data is BracketUI.UIData)
                {
                    BracketUI.UIData bracketUIData = data as BracketUI.UIData;
                    // Child
                    {
                        bracketUIData.bracket.allAddCallBack(this);
                        bracketUIData.bracketContestUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is Bracket)
                    {
                        Bracket bracket = data as Bracket;
                        // Child
                        {
                            bracket.bracketContests.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // bracketContestUIData
                    {
                        if (data is BracketContestUI.UIData)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Child
                    if (data is BracketContest)
                    {
                        dirty = true;
                        return;
                    }
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
                    uiData.bracketUIData.allRemoveCallBack(this);
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
                if (data is BracketUI.UIData)
                {
                    BracketUI.UIData bracketUIData = data as BracketUI.UIData;
                    // Child
                    {
                        bracketUIData.bracket.allRemoveCallBack(this);
                        bracketUIData.bracketContestUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is Bracket)
                    {
                        Bracket bracket = data as Bracket;
                        // Child
                        {
                            bracket.bracketContests.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // bracketContestUIData
                    {
                        if (data is BracketContestUI.UIData)
                        {
                            return;
                        }
                    }
                    // Child
                    if (data is BracketContest)
                    {
                        return;
                    }
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
                    case UIData.Property.bracketUIData:
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
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is BracketUI.UIData)
                {
                    switch ((BracketUI.UIData.Property)wrapProperty.n)
                    {
                        case BracketUI.UIData.Property.bracket:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case BracketUI.UIData.Property.bracketContestUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case BracketUI.UIData.Property.chooseBracketContestUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is Bracket)
                    {
                        switch ((Bracket.Property)wrapProperty.n)
                        {
                            case Bracket.Property.isActive:
                                break;
                            case Bracket.Property.state:
                                break;
                            case Bracket.Property.index:
                                break;
                            case Bracket.Property.bracketContests:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Bracket.Property.byeTeamIndexs:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // bracketContestUIData
                    {
                        if (wrapProperty.p is BracketContestUI.UIData)
                        {
                            switch ((BracketContestUI.UIData.Property)wrapProperty.n)
                            {
                                case BracketContestUI.UIData.Property.bracketContest:
                                    dirty = true;
                                    break;
                                case BracketContestUI.UIData.Property.contestUIData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                    // Child
                    if (wrapProperty.p is BracketContest)
                    {
                        switch ((BracketContest.Property)wrapProperty.n)
                        {
                            case BracketContest.Property.isActive:
                                dirty = true;
                                break;
                            case BracketContest.Property.index:
                                dirty = true;
                                break;
                            case BracketContest.Property.teamIndexs:
                                break;
                            case BracketContest.Property.contest:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnBracket()
        {
            if (this.data != null)
            {
                BracketUI.UIData bracketUIData = this.data.bracketUIData.v.data;
                if (bracketUIData != null)
                {
                    ChooseBracketContestUI.UIData chooseBracketContestUIData = bracketUIData.chooseBracketContestUIData.newOrOld<ChooseBracketContestUI.UIData>();
                    {

                    }
                    bracketUIData.chooseBracketContestUIData.v = chooseBracketContestUIData;
                }
                else
                {
                    Debug.LogError("bracketUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}