using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
    public class ChooseEliminationRoundHolder : SriaHolderBehavior<ChooseEliminationRoundHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<EliminationRound>> eliminationRound;

            public LP<ChooseEliminationRoundBracketUI.UIData> brackets;

            #region Constructor

            public enum Property
            {
                eliminationRound,
                brackets
            }

            public UIData() : base()
            {
                this.eliminationRound = new VP<ReferenceData<EliminationRound>>(this, (byte)Property.eliminationRound, new ReferenceData<EliminationRound>(null));
                this.brackets = new LP<ChooseEliminationRoundBracketUI.UIData>(this, (byte)Property.brackets);
            }

            #endregion

            public void updateView(ChooseEliminationRoundAdapter.UIData myParams)
            {
                // Find
                EliminationRound eliminationRound = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.eliminationRounds.Count)
                    {
                        eliminationRound = myParams.eliminationRounds[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.eliminationRound.v = new ReferenceData<EliminationRound>(eliminationRound);
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
                            ChooseEliminationRoundHolder chooseEliminationRoundHolder = this.findCallBack<ChooseEliminationRoundHolder>();
                            if (chooseEliminationRoundHolder != null)
                            {
                                isProcess = chooseEliminationRoundHolder.useShortKey(e);
                            }
                            else
                            {
                                Debug.LogError("chooseDatabaseUI null: " + this);
                            }
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text tvShow;
        private static readonly TxtLanguage txtShow = new TxtLanguage("Show");

        #region state

        private static readonly TxtLanguage txtLoad = new TxtLanguage("Loading");
        private static readonly TxtLanguage txtStart = new TxtLanguage("Starting");
        private static readonly TxtLanguage txtPlay = new TxtLanguage("Playing");
        private static readonly TxtLanguage txtEnd = new TxtLanguage("End");

        #endregion

        static ChooseEliminationRoundHolder()
        {
            // txt
            {
                txtShow.add(Language.Type.vi, "Hiện");
                // state
                {
                    txtLoad.add(Language.Type.vi, "Đang Tải");
                    txtStart.add(Language.Type.vi, "Bắt Đầu");
                    txtPlay.add(Language.Type.vi, "Đang Chơi");
                    txtEnd.add(Language.Type.vi, "Kết Thúc");
                }
            }
            // rect
            {
                // anchoredPosition: (-44.0, 0.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (30.0, -30.0); offsetMax: (-118.0, 0.0); sizeDelta: (-148.0, 30.0);
                bracketRect.anchoredPosition = new Vector3(-44.0f, 0.0f);
                bracketRect.anchorMin = new Vector2(0.0f, 1.0f);
                bracketRect.anchorMax = new Vector2(1.0f, 1.0f);
                bracketRect.pivot = new Vector2(0.5f, 1.0f);
                bracketRect.offsetMin = new Vector2(30.0f, -50.0f);
                bracketRect.offsetMax = new Vector2(-122.0f, 0.0f);
                bracketRect.sizeDelta = new Vector2(-152.0f, 50.0f);
            }
        }

        #endregion

        #region Refresh

        public Text tvIndex;
        public Text tvState;

        public Button btnShow;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EliminationRound eliminationRound = this.data.eliminationRound.v.data;
                    if (eliminationRound != null)
                    {
                        // tvIndex
                        {
                            if (tvIndex != null)
                            {
                                tvIndex.text = "" + (eliminationRound.index.v + 1);
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // brackets
                        {
                            // get old
                            List<ChooseEliminationRoundBracketUI.UIData> oldBrackets = new List<ChooseEliminationRoundBracketUI.UIData>();
                            {
                                oldBrackets.AddRange(this.data.brackets.vs);
                            }
                            // Update
                            {
                                // get active list
                                List<Bracket> brackets = new List<Bracket>();
                                {
                                    foreach (Bracket bracket in eliminationRound.brackets.vs)
                                    {
                                        if (bracket.isActive.v)
                                        {
                                            brackets.Add(bracket);
                                        }
                                    }
                                }
                                // Update
                                foreach (Bracket bracket in brackets)
                                {
                                    // find
                                    ChooseEliminationRoundBracketUI.UIData bracketUIData = null;
                                    {
                                        // find old
                                        if (oldBrackets.Count > 0)
                                        {
                                            bracketUIData = oldBrackets[0];
                                        }
                                        // make new
                                        if (bracketUIData == null)
                                        {
                                            bracketUIData = new ChooseEliminationRoundBracketUI.UIData();
                                            {
                                                bracketUIData.uid = this.data.brackets.makeId();
                                            }
                                            this.data.brackets.add(bracketUIData);
                                        }
                                        else
                                        {
                                            oldBrackets.Remove(bracketUIData);
                                        }
                                    }
                                    // update
                                    {
                                        bracketUIData.bracket.v = new ReferenceData<Bracket>(bracket);
                                    }
                                }
                            }
                            // remove old
                            foreach (ChooseEliminationRoundBracketUI.UIData oldBracket in oldBrackets)
                            {
                                this.data.brackets.remove(oldBracket);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // brackets
                            foreach (ChooseEliminationRoundBracketUI.UIData bracket in this.data.brackets.vs)
                            {
                                deltaY += UIRectTransform.SetPosY(bracket, deltaY);
                            }
                            // set
                            this.setHolderSize(deltaY);
                        }
                        // tvState
                        {
                            if (tvState != null)
                            {
                                switch (eliminationRound.state.v.getType())
                                {
                                    case EliminationRound.State.Type.Load:
                                        tvState.text = txtLoad.get();
                                        break;
                                    case EliminationRound.State.Type.Start:
                                        tvState.text = txtStart.get();
                                        break;
                                    case EliminationRound.State.Type.Play:
                                        tvState.text = txtPlay.get();
                                        break;
                                    case EliminationRound.State.Type.End:
                                        tvState.text = txtEnd.get();
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + eliminationRound.state.v.getType());
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("tvStatate null: " + this);
                            }
                        }
                        // btnShow
                        {
                            if (btnShow != null)
                            {
                                bool isAlreadyShow = false;
                                {
                                    EliminationContentUI.UIData eliminationContentUIData = this.data.findDataInParent<EliminationContentUI.UIData>();
                                    if (eliminationContentUIData != null)
                                    {
                                        EliminationRoundUI.UIData eliminationRoundUIData = eliminationContentUIData.eliminationRoundUIData.v;
                                        if (eliminationRoundUIData != null)
                                        {
                                            if (eliminationRoundUIData.eliminationRound.v.data == eliminationRound)
                                            {
                                                isAlreadyShow = true;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("eliminationRoundUIData null");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("eliminationContentUIData null");
                                    }
                                }
                                btnShow.interactable = !isAlreadyShow;
                            }
                            else
                            {
                                Debug.LogError("btnShow null");
                            }
                        }
                        // txt
                        {
                            if (tvShow != null)
                            {
                                tvShow.text = txtShow.get();
                            }
                            else
                            {
                                Debug.LogError("tvShow null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("eliminationRound null: " + this);
                    }
                }
                else
                {
                    // Debug.LogError ("data null: " + this);
                }
            }
        }

        #endregion

        #region implement callBacks

        public ChooseEliminationRoundBracketUI bracketPrefab;
        private static readonly UIRectTransform bracketRect = new UIRectTransform();

        private EliminationContentUI.UIData eliminationContentUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.eliminationContentUIData);
                }
                // Child
                {
                    uiData.eliminationRound.allAddCallBack(this);
                    uiData.brackets.allAddCallBack(this);
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
            // Parent
            {
                if(data is EliminationContentUI.UIData)
                {
                    EliminationContentUI.UIData eliminationContentUIData = data as EliminationContentUI.UIData;
                    // Child
                    {
                        eliminationContentUIData.eliminationRoundUIData.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if(data is EliminationRoundUI.UIData)
                {
                    dirty = true;
                    return;
                }
            }
            // Child
            {
                // eliminationRound
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
                    // Child
                    if (data is Bracket)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is ChooseEliminationRoundBracketUI.UIData)
                {
                    ChooseEliminationRoundBracketUI.UIData bracketUIData = data as ChooseEliminationRoundBracketUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(bracketUIData, bracketPrefab, this.transform, bracketRect);
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.eliminationContentUIData);
                }
                // Child
                {
                    uiData.eliminationRound.allRemoveCallBack(this);
                    uiData.brackets.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                if (data is EliminationContentUI.UIData)
                {
                    EliminationContentUI.UIData eliminationContentUIData = data as EliminationContentUI.UIData;
                    // Child
                    {
                        eliminationContentUIData.eliminationRoundUIData.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is EliminationRoundUI.UIData)
                {
                    return;
                }
            }
            // Child
            {
                // eliminationRound
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
                    // Child
                    if (data is Bracket)
                    {
                        return;
                    }
                }
                if (data is ChooseEliminationRoundBracketUI.UIData)
                {
                    ChooseEliminationRoundBracketUI.UIData bracketUIData = data as ChooseEliminationRoundBracketUI.UIData;
                    // UI
                    {
                        bracketUIData.removeCallBackAndDestroy(typeof(ChooseEliminationRoundBracketUI));
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
                    case UIData.Property.eliminationRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.brackets:
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
            // Parent
            {
                if (wrapProperty.p is EliminationContentUI.UIData)
                {
                    switch ((EliminationContentUI.UIData.Property)wrapProperty.n)
                    {
                        case EliminationContentUI.UIData.Property.eliminationContent:
                            break;
                        case EliminationContentUI.UIData.Property.eliminationRoundUIData:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case EliminationContentUI.UIData.Property.chooseEliminationRoundUIData:
                            break;
                        case EliminationContentUI.UIData.Property.requestNewEliminationRoundUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is EliminationRoundUI.UIData)
                {
                    switch ((EliminationRoundUI.UIData.Property)wrapProperty.n)
                    {
                        case EliminationRoundUI.UIData.Property.eliminationRound:
                            dirty = true;
                            break;
                        case EliminationRoundUI.UIData.Property.bracketUIData:
                            break;
                        case EliminationRoundUI.UIData.Property.chooseBracketUIData:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
            }
            // Child
            {
                // eliminationRound
                {
                    if (wrapProperty.p is EliminationRound)
                    {
                        switch ((EliminationRound.Property)wrapProperty.n)
                        {
                            case EliminationRound.Property.isActive:
                                break;
                            case EliminationRound.Property.state:
                                dirty = true;
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
                                break;
                            case Bracket.Property.bracketContests:
                                break;
                            case Bracket.Property.byeTeamIndexs:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                    }
                }
                if (wrapProperty.p is ChooseEliminationRoundBracketUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        [UnityEngine.Scripting.Preserve]
        public void onClickBtnShow()
        {
            if (this.data != null)
            {
                EliminationRound eliminationRound = this.data.eliminationRound.v.data;
                if (eliminationRound != null)
                {
                    EliminationContentUI.UIData eliminationContentUIData = this.data.findDataInParent<EliminationContentUI.UIData>();
                    if (eliminationContentUIData != null)
                    {
                        EliminationRoundUI.UIData eliminationRoundUIData = eliminationContentUIData.eliminationRoundUIData.v;
                        if (eliminationRoundUIData != null)
                        {
                            eliminationRoundUIData.eliminationRound.v = new ReferenceData<EliminationRound>(eliminationRound);
                        }
                        else
                        {
                            Debug.LogError("eliminationRoundUIData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("eliminationContentUIData null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("eliminationRound null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}