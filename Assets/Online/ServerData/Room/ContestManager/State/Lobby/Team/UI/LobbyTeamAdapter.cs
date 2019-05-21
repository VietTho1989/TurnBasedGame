using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match
{
    public class LobbyTeamAdapter : SRIA<LobbyTeamAdapter.UIData, LobbyTeamHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<ContestManagerStateLobby>> contestManagerStateLobby;

            public LP<LobbyTeamHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                contestManagerStateLobby,
                holders
            }

            public UIData() : base()
            {
                this.contestManagerStateLobby = new VP<ReferenceData<ContestManagerStateLobby>>(this, (byte)Property.contestManagerStateLobby, new ReferenceData<ContestManagerStateLobby>(null));
                this.holders = new LP<LobbyTeamHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<LobbyTeam> lobbyTeams = new List<LobbyTeam>();

            public void reset()
            {
                this.lobbyTeams.Clear();
            }

        }

        #endregion

        #region Adapter

        public LobbyTeamHolder holderPrefab;

        protected override LobbyTeamHolder.UIData CreateViewsHolder(int itemIndex)
        {
            LobbyTeamHolder.UIData uiData = new LobbyTeamHolder.UIData();
            {
                // add
                {
                    uiData.uid = this.data.holders.makeId();
                    this.data.holders.add(uiData);
                }
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

        protected override void UpdateViewsHolder(LobbyTeamHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
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
                    ContestManagerStateLobby contestManagerStateLobby = this.data.contestManagerStateLobby.v.data;
                    if (contestManagerStateLobby != null)
                    {
                        // get list of lobbyTeam
                        List<LobbyTeam> lobbyTeams = new List<LobbyTeam>();
                        {
                            lobbyTeams.AddRange(contestManagerStateLobby.teams.vs);
                        }
                        // Add to adapter
                        {
                            int min = Mathf.Min(lobbyTeams.Count, _Params.lobbyTeams.Count);
                            // Update
                            {
                                for (int i = 0; i < min; i++)
                                {
                                    if (lobbyTeams[i] != _Params.lobbyTeams[i])
                                    {
                                        // change param
                                        _Params.lobbyTeams[i] = lobbyTeams[i];
                                        // Update holder
                                        foreach (LobbyTeamHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.ItemIndex == i)
                                            {
                                                holder.lobbyTeam.v = new ReferenceData<LobbyTeam>(lobbyTeams[i]);
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                            // Add or Remove
                            {
                                if (lobbyTeams.Count > min)
                                {
                                    // Add
                                    int insertCount = lobbyTeams.Count - min;
                                    List<LobbyTeam> addItems = lobbyTeams.GetRange(min, insertCount);
                                    _Params.lobbyTeams.AddRange(addItems);
                                    InsertItems(min, insertCount, false, false);
                                }
                                else
                                {
                                    // Remove
                                    int deleteCount = _Params.lobbyTeams.Count - min;
                                    if (deleteCount > 0)
                                    {
                                        RemoveItems(min, deleteCount, false, false);
                                        _Params.lobbyTeams.RemoveRange(min, deleteCount);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError ("contestManagerStateLobby null: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.contestManagerStateLobby.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is ContestManagerStateLobby)
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
                    uiData.contestManagerStateLobby.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is ContestManagerStateLobby)
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
                    case UIData.Property.contestManagerStateLobby:
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
            {
                if (wrapProperty.p is ContestManagerStateLobby)
                {
                    switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                    {
                        case ContestManagerStateLobby.Property.state:
                            break;
                        case ContestManagerStateLobby.Property.teams:
                            dirty = true;
                            break;
                        case ContestManagerStateLobby.Property.gameType:
                            break;
                        case ContestManagerStateLobby.Property.randomTeamIndex:
                            break;
                        case ContestManagerStateLobby.Property.contentFactory:
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