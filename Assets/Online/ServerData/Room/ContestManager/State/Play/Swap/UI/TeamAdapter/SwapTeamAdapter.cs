using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match.Swap
{
    public class SwapTeamAdapter : SRIA<SwapTeamAdapter.UIData, SwapTeamHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<ContestManagerStatePlay>> contestManagerStatePlay;

            public LP<SwapTeamHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                contestManagerStatePlay,
                holders
            }

            public UIData() : base()
            {
                this.contestManagerStatePlay = new VP<ReferenceData<ContestManagerStatePlay>>(this, (byte)Property.contestManagerStatePlay, new ReferenceData<ContestManagerStatePlay>(null));
                this.holders = new LP<SwapTeamHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<MatchTeam> matchTeams = new List<MatchTeam>();

            public void reset()
            {
                this.matchTeams.Clear();
            }

        }

        #endregion

        #region Adapter

        public SwapTeamHolder holderPrefab;

        protected override SwapTeamHolder.UIData CreateViewsHolder(int itemIndex)
        {
            SwapTeamHolder.UIData uiData = new SwapTeamHolder.UIData();
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

        protected override void UpdateViewsHolder(SwapTeamHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region Refresh

        public GameObject noTeams;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        ContestManagerStatePlay contestManagerStatePlay = this.data.contestManagerStatePlay.v.data;
                        if (contestManagerStatePlay != null)
                        {
                            List<MatchTeam> matchTeams = new List<MatchTeam>();
                            // get
                            {
                                matchTeams.AddRange(contestManagerStatePlay.teams.vs);
                            }
                            // Make list
                            {
                                int min = Mathf.Min(matchTeams.Count, _Params.matchTeams.Count);
                                // Update
                                {
                                    for (int i = 0; i < min; i++)
                                    {
                                        if (matchTeams[i] != _Params.matchTeams[i])
                                        {
                                            // change param
                                            _Params.matchTeams[i] = matchTeams[i];
                                            // Update holder
                                            foreach (SwapTeamHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.ItemIndex == i)
                                                {
                                                    holder.matchTeam.v = new ReferenceData<MatchTeam>(matchTeams[i]);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Add or Remove
                                {
                                    if (matchTeams.Count > min)
                                    {
                                        // Add
                                        int insertCount = matchTeams.Count - min;
                                        List<MatchTeam> addItems = matchTeams.GetRange(min, insertCount);
                                        _Params.matchTeams.AddRange(addItems);
                                        InsertItems(min, insertCount, false, false);
                                    }
                                    else
                                    {
                                        // Remove
                                        int deleteCount = _Params.matchTeams.Count - min;
                                        if (deleteCount > 0)
                                        {
                                            RemoveItems(min, deleteCount, false, false);
                                            _Params.matchTeams.RemoveRange(min, deleteCount);
                                        }
                                    }
                                }
                            }
                            // NoTeams
                            {
                                if (noTeams != null)
                                {
                                    bool haveAny = false;
                                    {
                                        foreach (SwapTeamHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.matchTeam.v.data != null)
                                            {
                                                SwapTeamHolder holderUI = holder.findCallBack<SwapTeamHolder>();
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
                                    noTeams.SetActive(!haveAny);
                                }
                                else
                                {
                                    Debug.LogError("noTeams null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
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
                // Child
                {
                    uiData.contestManagerStatePlay.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            if (data is ContestManagerStatePlay)
            {
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
                // Child
                {
                    uiData.contestManagerStatePlay.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            if (data is ContestManagerStatePlay)
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
                    case UIData.Property.contestManagerStatePlay:
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
            // Child
            if (wrapProperty.p is ContestManagerStatePlay)
            {
                switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                {
                    case ContestManagerStatePlay.Property.state:
                        break;
                    case ContestManagerStatePlay.Property.isForceEnd:
                        break;
                    case ContestManagerStatePlay.Property.teams:
                        dirty = true;
                        break;
                    case ContestManagerStatePlay.Property.swap:
                        break;
                    case ContestManagerStatePlay.Property.content:
                        break;
                    case ContestManagerStatePlay.Property.contentTeamResult:
                        break;
                    case ContestManagerStatePlay.Property.randomTeamIndex:
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