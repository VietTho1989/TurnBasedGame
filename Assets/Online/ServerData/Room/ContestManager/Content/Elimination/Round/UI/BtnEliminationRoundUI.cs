using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class BtnEliminationRoundUI : UIHaveTransformDataBehavior<BtnEliminationRoundUI.UIData>
    {

        #region UIData

        public class UIData : RoomBtnUI.UIData.Sub
        {

            public VP<ReferenceData<EliminationRoundUI.UIData>> eliminationRoundUIData;

            #region Constructor

            public enum Property
            {
                eliminationRoundUIData
            }

            public UIData() : base()
            {
                this.eliminationRoundUIData = new VP<ReferenceData<EliminationRoundUI.UIData>>(this, (byte)Property.eliminationRoundUIData, new ReferenceData<EliminationRoundUI.UIData>(null));
            }

            #endregion

            public override Type getType()
            {
                return Type.EliminationRound;
            }

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // shortKey
                    if (!isProcess)
                    {
                        if (Setting.get().useShortKey.v)
                        {
                            BtnEliminationRoundUI btnEliminationRoundUI = this.findCallBack<BtnEliminationRoundUI>();
                            if (btnEliminationRoundUI != null)
                            {
                                isProcess = btnEliminationRoundUI.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("btnEliminationRoundUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtEliminationRound = new TxtLanguage("Bracket");

        static BtnEliminationRoundUI()
        {
            txtEliminationRound.add(Language.Type.vi, "Nhánh");
        }

        #endregion

        #region Refresh

        public Text tvEliminationRound;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = this.data.eliminationRoundUIData.v.data;
                    if (eliminationRoundUIData != null)
                    {
                        // tvEliminationRound
                        {
                            if (tvEliminationRound != null)
                            {
                                int bracketIndex = 0;
                                int bracketCount = 0;
                                {
                                    // bracketIndex
                                    {
                                        BracketUI.UIData bracketUIData = eliminationRoundUIData.bracketUIData.v;
                                        if (bracketUIData != null)
                                        {
                                            Bracket bracket = bracketUIData.bracket.v.data;
                                            if (bracket != null)
                                            {
                                                bracketIndex = bracket.index.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("bracket null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("bracketUIData null: " + this);
                                        }
                                    }
                                    // bracketCount
                                    {
                                        EliminationRound eliminationRound = eliminationRoundUIData.eliminationRound.v.data;
                                        if (eliminationRound != null)
                                        {
                                            foreach (Bracket bracket in eliminationRound.brackets.vs)
                                            {
                                                if (bracket.isActive.v)
                                                {
                                                    bracketCount++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("eliminationRound null: " + this);
                                        }
                                    }
                                }
                                tvEliminationRound.text = txtEliminationRound.get() + " " + (bracketIndex + 1) + "/" + bracketCount;
                            }
                            else
                            {
                                Debug.LogError("tvElimination null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("eliminationRoundUIData null: " + this);
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
                    uiData.eliminationRoundUIData.allAddCallBack(this);
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
                if (data is EliminationRoundUI.UIData)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = data as EliminationRoundUI.UIData;
                    // Child
                    {
                        eliminationRoundUIData.eliminationRound.allAddCallBack(this);
                        eliminationRoundUIData.bracketUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is EliminationRound)
                    {
                        EliminationRound eliminationRound = data as EliminationRound;
                        // Child
                        {
                            eliminationRound.brackets.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // bracketUIData
                    {
                        if (data is BracketUI.UIData)
                        {
                            dirty = true;
                            return;
                        }
                    }
                    // Child
                    if (data is Bracket)
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
                    uiData.eliminationRoundUIData.allRemoveCallBack(this);
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
                if (data is EliminationRoundUI.UIData)
                {
                    EliminationRoundUI.UIData eliminationRoundUIData = data as EliminationRoundUI.UIData;
                    // Child
                    {
                        eliminationRoundUIData.eliminationRound.allRemoveCallBack(this);
                        eliminationRoundUIData.bracketUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is EliminationRound)
                    {
                        EliminationRound eliminationRound = data as EliminationRound;
                        // Child
                        {
                            eliminationRound.brackets.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // bracketUIData
                    {
                        if (data is BracketUI.UIData)
                        {
                            return;
                        }
                    }
                    // Child
                    if (data is Bracket)
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
                    case UIData.Property.eliminationRoundUIData:
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
                if (wrapProperty.p is EliminationRoundUI.UIData)
                {
                    switch ((EliminationRoundUI.UIData.Property)wrapProperty.n)
                    {
                        case EliminationRoundUI.UIData.Property.eliminationRound:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EliminationRoundUI.UIData.Property.bracketUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EliminationRoundUI.UIData.Property.chooseBracketUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is EliminationRound)
                    {
                        switch ((EliminationRound.Property)wrapProperty.n)
                        {
                            case EliminationRound.Property.isActive:
                                break;
                            case EliminationRound.Property.state:
                                break;
                            case EliminationRound.Property.index:
                                break;
                            case EliminationRound.Property.brackets:
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
                    // bracketUIData
                    {
                        if (wrapProperty.p is BracketUI.UIData)
                        {
                            switch ((BracketUI.UIData.Property)wrapProperty.n)
                            {
                                case BracketUI.UIData.Property.bracket:
                                    dirty = true;
                                    break;
                                case BracketUI.UIData.Property.bracketContestUIData:
                                    break;
                                case BracketUI.UIData.Property.chooseBracketContestUIData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                    // Child
                    if (wrapProperty.p is Bracket)
                    {
                        switch ((Bracket.Property)wrapProperty.n)
                        {
                            case Bracket.Property.isActive:
                                dirty = true;
                                break;
                            case Bracket.Property.state:
                                break;
                            case Bracket.Property.index:
                                dirty = true;
                                break;
                            case Bracket.Property.bracketContests:
                                break;
                            case Bracket.Property.byeTeamIndexs:
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

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnEliminationRound()
        {
            if (this.data != null)
            {
                EliminationRoundUI.UIData eliminationRoundUIData = this.data.eliminationRoundUIData.v.data;
                if (eliminationRoundUIData != null)
                {
                    ChooseBracketUI.UIData chooseBracketUIData = eliminationRoundUIData.chooseBracketUIData.newOrOld<ChooseBracketUI.UIData>();
                    {

                    }
                    eliminationRoundUIData.chooseBracketUIData.v = chooseBracketUIData;
                }
                else
                {
                    Debug.LogError("eliminationRoundUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}