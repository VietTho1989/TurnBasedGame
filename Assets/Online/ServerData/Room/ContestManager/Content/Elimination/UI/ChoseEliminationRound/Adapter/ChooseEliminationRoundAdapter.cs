using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match.Elimination
{
    public class ChooseEliminationRoundAdapter : SRIA<ChooseEliminationRoundAdapter.UIData, ChooseEliminationRoundHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<EliminationContent>> eliminationContent;

            public LP<ChooseEliminationRoundHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                eliminationContent,
                holders
            }

            public UIData() : base()
            {
                this.eliminationContent = new VP<ReferenceData<EliminationContent>>(this, (byte)Property.eliminationContent, new ReferenceData<EliminationContent>(null));
                this.holders = new LP<ChooseEliminationRoundHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<EliminationRound> eliminationRounds = new List<EliminationRound>();

            public void reset()
            {
                eliminationRounds.Clear();
            }

        }

        #endregion

        #region Adapter

        public ChooseEliminationRoundHolder holderPrefab;

        protected override ChooseEliminationRoundHolder.UIData CreateViewsHolder(int itemIndex)
        {
            ChooseEliminationRoundHolder.UIData uiData = new ChooseEliminationRoundHolder.UIData();
            {
                // add
                {
                    uiData.uid = this.data.holders.makeId();
                    this.data.holders.add(uiData);
                }
                // MakeUI
                if (holderPrefab != null)
                {
                    uiData.Init(holderPrefab.gameObject, itemIndex);
                }
                else
                {
                    Debug.LogError("holderPrefab null: " + this);
                }
            }
            return uiData;
        }

        protected override void UpdateViewsHolder(ChooseEliminationRoundHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region txt

        public Text tvNoEliminationRounds;
        private static readonly TxtLanguage txtNoEmliminationRounds = new TxtLanguage("Don't have any elimination rounds");

        static ChooseEliminationRoundAdapter()
        {
            txtNoEmliminationRounds.add(Language.Type.vi, "Không có vòng loại trực tiếp nào");
        }

        #endregion

        #region Refresh

        public GameObject noEliminationRounds;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        EliminationContent eliminationContent = this.data.eliminationContent.v.data;
                        if (eliminationContent != null)
                        {
                            // check isLoadFull
                            bool isLoadFull = true;
                            {
                                // dataIdentity
                                if (isLoadFull)
                                {
                                    DataIdentity dataIdentity = null;
                                    if (DataIdentity.clientMap.TryGetValue(eliminationContent, out dataIdentity))
                                    {
                                        if (dataIdentity is EliminationContentIdentity)
                                        {
                                            EliminationContentIdentity eliminationContentIdentity = dataIdentity as EliminationContentIdentity;
                                            if (eliminationContentIdentity.rounds != eliminationContent.rounds.vs.Count)
                                            {
                                                Debug.LogError("eliminationontent round count error");
                                                isLoadFull = false;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("why not eliminationContentIdentity");
                                        }
                                    }
                                }
                            }
                            // process
                            if (isLoadFull)
                            {
                                List<EliminationRound> eliminationRounds = new List<EliminationRound>();
                                // get
                                {
                                    foreach (EliminationRound eliminationRound in eliminationContent.rounds.vs)
                                    {
                                        if (eliminationRound.isActive.v)
                                        {
                                            eliminationRounds.Add(eliminationRound);
                                        }
                                    }
                                }
                                // Make list
                                {
                                    int min = Mathf.Min(eliminationRounds.Count, _Params.eliminationRounds.Count);
                                    // Update
                                    {
                                        for (int i = 0; i < min; i++)
                                        {
                                            if (eliminationRounds[i] != _Params.eliminationRounds[i])
                                            {
                                                // change param
                                                _Params.eliminationRounds[i] = eliminationRounds[i];
                                                // Update holder
                                                foreach (ChooseEliminationRoundHolder.UIData holder in this.data.holders.vs)
                                                {
                                                    if (holder.ItemIndex == i)
                                                    {
                                                        holder.eliminationRound.v = new ReferenceData<EliminationRound>(eliminationRounds[i]);
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    // Add or Remove
                                    {
                                        if (eliminationRounds.Count > min)
                                        {
                                            // Add
                                            int insertCount = eliminationRounds.Count - min;
                                            List<EliminationRound> addItems = eliminationRounds.GetRange(min, insertCount);
                                            _Params.eliminationRounds.AddRange(addItems);
                                            InsertItems(min, insertCount, false, false);
                                        }
                                        else
                                        {
                                            // Remove
                                            int deleteCount = _Params.eliminationRounds.Count - min;
                                            if (deleteCount > 0)
                                            {
                                                RemoveItems(min, deleteCount, false, false);
                                                _Params.eliminationRounds.RemoveRange(min, deleteCount);
                                            }
                                        }
                                    }
                                }
                                // NoEliminationRounds
                                {
                                    if (noEliminationRounds != null)
                                    {
                                        bool haveAny = false;
                                        {
                                            foreach (ChooseEliminationRoundHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.eliminationRound.v.data != null)
                                                {
                                                    ChooseEliminationRoundHolder holderUI = holder.findCallBack<ChooseEliminationRoundHolder>();
                                                    if (holderUI != null)
                                                    {
                                                        if (holderUI.gameObject.activeSelf)
                                                        {
                                                            haveAny = true;
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("holderUI null: " + this);
                                                    }
                                                }
                                            }
                                        }
                                        noEliminationRounds.SetActive(!haveAny);
                                    }
                                    else
                                    {
                                        Debug.LogError("noEliminationRounds null: " + this);
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("not load full");
                                dirty = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                        // txt
                        {
                            if (tvNoEliminationRounds != null)
                            {
                                tvNoEliminationRounds.text = txtNoEmliminationRounds.get();
                            }
                            else
                            {
                                Debug.LogError("tvNoEliminationRounds null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("data null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("not initalized: " + this);
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
                    uiData.eliminationContent.allAddCallBack(this);
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
                if (data is EliminationContent)
                {
                    EliminationContent eliminationContent = data as EliminationContent;
                    // reset
                    {
                        if (this.data != null)
                        {
                            this.data.reset();
                        }
                        else
                        {
                            Debug.LogError("data null: " + this);
                        }
                    }
                    // Child
                    {
                        eliminationContent.rounds.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is EliminationRound)
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
                    uiData.eliminationContent.allRemoveCallBack(this);
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
                if (data is EliminationContent)
                {
                    EliminationContent eliminationContent = data as EliminationContent;
                    // Child
                    {
                        eliminationContent.rounds.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is EliminationRound)
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
                    case UIData.Property.eliminationContent:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.holders:
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
                if (wrapProperty.p is EliminationContent)
                {
                    switch ((EliminationContent.Property)wrapProperty.n)
                    {
                        case EliminationContent.Property.singleContestFactory:
                            break;
                        case EliminationContent.Property.initTeamCounts:
                            break;
                        case EliminationContent.Property.requestNewRound:
                            break;
                        case EliminationContent.Property.rounds:
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
                if (wrapProperty.p is EliminationRound)
                {
                    switch ((EliminationRound.Property)wrapProperty.n)
                    {
                        case EliminationRound.Property.isActive:
                            dirty = true;
                            break;
                        case EliminationRound.Property.state:
                            break;
                        case EliminationRound.Property.index:
                            break;
                        case EliminationRound.Property.brackets:
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