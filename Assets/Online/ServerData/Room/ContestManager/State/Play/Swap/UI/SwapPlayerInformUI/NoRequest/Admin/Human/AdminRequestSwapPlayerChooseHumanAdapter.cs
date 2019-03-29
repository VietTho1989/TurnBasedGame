using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using frame8.ScrollRectItemsAdapter.Util;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using frame8.ScrollRectItemsAdapter.Util.Drawer;

namespace GameManager.Match.Swap
{
    public class AdminRequestSwapPlayerChooseHumanAdapter : SRIA<AdminRequestSwapPlayerChooseHumanAdapter.UIData, AdminRequestSwapPlayerChooseHumanHolder.UIData>
    {

        #region UIData

        [Serializable]
        public class UIData : BaseParams
        {

            public VP<ReferenceData<TeamPlayer>> teamPlayer;

            public LP<AdminRequestSwapPlayerChooseHumanHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                teamPlayer,
                holders
            }

            public UIData() : base()
            {
                this.teamPlayer = new VP<ReferenceData<TeamPlayer>>(this, (byte)Property.teamPlayer, new ReferenceData<TeamPlayer>(null));
                this.holders = new LP<AdminRequestSwapPlayerChooseHumanHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            [NonSerialized]
            public List<Human> humans = new List<Human>();

            public void reset()
            {
                this.humans.Clear();
            }

        }

        #endregion

        #region Adapter

        public AdminRequestSwapPlayerChooseHumanHolder holderPrefab;

        protected override AdminRequestSwapPlayerChooseHumanHolder.UIData CreateViewsHolder(int itemIndex)
        {
            AdminRequestSwapPlayerChooseHumanHolder.UIData uiData = new AdminRequestSwapPlayerChooseHumanHolder.UIData();
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

        protected override void UpdateViewsHolder(AdminRequestSwapPlayerChooseHumanHolder.UIData newOrRecycled)
        {
            newOrRecycled.updateView(_Params);
        }

        #endregion

        #region Refresh

        public GameObject noHumans;

        public override void refresh()
        {
            if (dirty)
            {
                if (this.Initialized)
                {
                    dirty = false;
                    if (this.data != null)
                    {
                        TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
                        if (teamPlayer != null)
                        {
                            // get list of human
                            List<Human> humans = new List<Human>();
                            {
                                Room room = teamPlayer.findDataInParent<Room>();
                                if (room != null)
                                {
                                    // get currentUserId
                                    uint currentUserId = uint.MaxValue;
                                    {
                                        if (teamPlayer.inform.v is Human)
                                        {
                                            Human human = teamPlayer.inform.v as Human;
                                            currentUserId = human.playerId.v;
                                        }
                                    }
                                    // get list of human
                                    foreach (RoomUser roomUser in room.users.vs)
                                    {
                                        if (roomUser.isInsideRoom())
                                        {
                                            Human human = roomUser.inform.v;
                                            if (human != null)
                                            {
                                                if (human.playerId.v != currentUserId)
                                                {
                                                    humans.Add(human);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("human null: " + this);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    Debug.LogError("room null: " + this);
                                }
                            }
                            // Add to adapter
                            {
                                int min = Mathf.Min(humans.Count, _Params.humans.Count);
                                // Update
                                {
                                    for (int i = 0; i < min; i++)
                                    {
                                        if (humans[i] != _Params.humans[i])
                                        {
                                            // change param
                                            _Params.humans[i] = humans[i];
                                            // Update holder
                                            foreach (AdminRequestSwapPlayerChooseHumanHolder.UIData holder in this.data.holders.vs)
                                            {
                                                if (holder.ItemIndex == i)
                                                {
                                                    holder.human.v = new ReferenceData<Human>(humans[i]);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                                // Add or Remove
                                {
                                    if (humans.Count > min)
                                    {
                                        // Add
                                        int insertCount = humans.Count - min;
                                        List<Human> addItems = humans.GetRange(min, insertCount);
                                        _Params.humans.AddRange(addItems);
                                        InsertItems(min, insertCount, false, false);
                                    }
                                    else
                                    {
                                        // Remove
                                        int deleteCount = _Params.humans.Count - min;
                                        if (deleteCount > 0)
                                        {
                                            RemoveItems(min, deleteCount, false, false);
                                            _Params.humans.RemoveRange(min, deleteCount);
                                        }
                                    }
                                }
                            }
                            // NoHumans
                            {
                                if (noHumans != null)
                                {
                                    bool haveAny = false;
                                    {
                                        foreach (AdminRequestSwapPlayerChooseHumanHolder.UIData holder in this.data.holders.vs)
                                        {
                                            if (holder.human.v.data != null)
                                            {
                                                AdminRequestSwapPlayerChooseHumanHolder holderUI = holder.findCallBack<AdminRequestSwapPlayerChooseHumanHolder>();
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
                                    noHumans.SetActive(!haveAny);
                                }
                                else
                                {
                                    Debug.LogError("noHumans null: " + this);
                                }
                            }
                        }
                        else
                        {
                            // Debug.LogError("teamPlayer null: " + this);
                        }
                    }
                    else
                    {
                        // Debug.LogError("data null: " + this);
                    }
                }
            }
        }

        #endregion

        #region implement callBacks

        private RoomCheckChangeAdminChange<TeamPlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<TeamPlayer>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.teamPlayer.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is TeamPlayer)
                {
                    TeamPlayer teamPlayer = data as TeamPlayer;
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
                    // CheckChange
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(teamPlayer);
                    }
                    // Child
                    {
                        teamPlayer.inform.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is RoomCheckChangeAdminChange<TeamPlayer>)
                {
                    dirty = true;
                    return;
                }
                // Child
                if (data is GamePlayer.Inform)
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
                // Child
                {
                    uiData.teamPlayer.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is TeamPlayer)
                {
                    TeamPlayer teamPlayer = data as TeamPlayer;
                    // CheckChange
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                    // Child
                    {
                        teamPlayer.inform.allRemoveCallBack(this);
                    }
                    return;
                }
                // CheckChange
                if (data is RoomCheckChangeAdminChange<TeamPlayer>)
                {
                    return;
                }
                // Child
                if (data is GamePlayer.Inform)
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
                    case UIData.Property.teamPlayer:
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
                if (wrapProperty.p is TeamPlayer)
                {
                    switch ((TeamPlayer.Property)wrapProperty.n)
                    {
                        case TeamPlayer.Property.playerIndex:
                            break;
                        case TeamPlayer.Property.inform:
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
                // CheckChange
                if (wrapProperty.p is RoomCheckChangeAdminChange<TeamPlayer>)
                {
                    dirty = true;
                    return;
                }
                // Child
                if (wrapProperty.p is GamePlayer.Inform)
                {
                    if (wrapProperty.p is Human)
                    {
                        Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}