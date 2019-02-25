using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using Foundation.Tasks;
using AdvancedCoroutines;

namespace GameManager.Match
{
    public class LobbyTeamHolder : SriaHolderBehavior<LobbyTeamHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<LobbyTeam>> lobbyTeam;

            public LP<LobbyPlayerHolder.UIData> holders;

            #region Constructor

            public enum Property
            {
                lobbyTeam,
                holders
            }

            public UIData() : base()
            {
                this.lobbyTeam = new VP<ReferenceData<LobbyTeam>>(this, (byte)Property.lobbyTeam, new ReferenceData<LobbyTeam>(null));
                this.holders = new LP<LobbyPlayerHolder.UIData>(this, (byte)Property.holders);
            }

            #endregion

            public void updateView(LobbyTeamAdapter.UIData myParams)
            {
                // Find LobbyTeam
                LobbyTeam lobbyTeam = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.lobbyTeams.Count)
                    {
                        lobbyTeam = myParams.lobbyTeams[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIndex error: " + this);
                    }
                }
                // Update
                this.lobbyTeam.v = new ReferenceData<LobbyTeam>(lobbyTeam);
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtTeam = new TxtLanguage();

        static LobbyTeamHolder()
        {
            txtTeam.add(Language.Type.vi, "Đội");
        }

        #endregion

        #region Refresh

        public Text tvTeamIndex;

        public override void refresh()
        {
            base.refresh();
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    LobbyTeam lobbyTeam = this.data.lobbyTeam.v.data;
                    if (lobbyTeam != null)
                    {
                        // tvTeamIndex
                        {
                            if (tvTeamIndex != null)
                            {
                                tvTeamIndex.text = txtTeam.get("Team") + ": " + lobbyTeam.teamIndex.v;
                            }
                            else
                            {
                                Debug.LogError("tvTeamIndex null: " + this);
                            }
                        }
                        // playerAdapter
                        {
                            // get old
                            List<LobbyPlayerHolder.UIData> oldPlayers = new List<LobbyPlayerHolder.UIData>();
                            {
                                oldPlayers.AddRange(this.data.holders.vs);
                            }
                            // Update
                            {
                                foreach (LobbyPlayer lobbyPlayer in lobbyTeam.players.vs)
                                {
                                    // Find UI
                                    LobbyPlayerHolder.UIData lobbyPlayerUIData = null;
                                    {
                                        // Find old
                                        if (oldPlayers.Count > 0)
                                        {
                                            lobbyPlayerUIData = oldPlayers[0];
                                        }
                                        // Make new
                                        if (lobbyPlayerUIData == null)
                                        {
                                            lobbyPlayerUIData = new LobbyPlayerHolder.UIData();
                                            {
                                                lobbyPlayerUIData.uid = this.data.holders.makeId();
                                            }
                                            this.data.holders.add(lobbyPlayerUIData);
                                        }
                                        else
                                        {
                                            oldPlayers.Remove(lobbyPlayerUIData);
                                        }
                                    }
                                    // Update Property
                                    {
                                        lobbyPlayerUIData.lobbyPlayer.v = new ReferenceData<LobbyPlayer>(lobbyPlayer);
                                    }
                                }
                            }
                            // Remove old
                            foreach (LobbyPlayerHolder.UIData oldPlayer in oldPlayers)
                            {
                                this.data.holders.remove(oldPlayer);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            deltaY += UIConstants.HeaderHeight;
                            // adapter
                            {
                                foreach (LobbyPlayerHolder.UIData holder in this.data.holders.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(holder, deltaY);
                                }
                            }
                            // set
                            // Debug.LogError("set deltaY: " + deltaY);
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                            this.refreshItemSize(deltaY);
                        }
                    }
                    else
                    {
                        Debug.LogError("lobbyTeam null: " + this);
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

        public LobbyPlayerHolder holderPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.lobbyTeam.allAddCallBack(this);
                    uiData.holders.allAddCallBack(this);
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
                if (data is LobbyTeam)
                {
                    dirty = true;
                    return;
                }
                // playerHolder
                {
                    if (data is LobbyPlayerHolder.UIData)
                    {
                        LobbyPlayerHolder.UIData playerHolderUIData = data as LobbyPlayerHolder.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(playerHolderUIData, holderPrefab, this.transform);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(playerHolderUIData, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if(data is TransformData)
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
                    uiData.lobbyTeam.allRemoveCallBack(this);
                    uiData.holders.allRemoveCallBack(this);
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
                if (data is LobbyTeam)
                {
                    return;
                }
                // playerHolder
                {
                    if (data is LobbyPlayerHolder.UIData)
                    {
                        LobbyPlayerHolder.UIData playerHolderUIData = data as LobbyPlayerHolder.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(playerHolderUIData, this);
                        }
                        // UI
                        {
                            playerHolderUIData.removeCallBackAndDestroy(typeof(LobbyPlayerHolder));
                        }
                        return;
                    }
                    // Child
                    if (data is TransformData)
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
                    case UIData.Property.lobbyTeam:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.holders:
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
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is LobbyTeam)
                {
                    switch ((LobbyTeam.Property)wrapProperty.n)
                    {
                        case LobbyTeam.Property.teamIndex:
                            dirty = true;
                            break;
                        case LobbyTeam.Property.players:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // lobbyPlayerHolderUIData
                {
                    if (wrapProperty.p is LobbyPlayerHolder.UIData)
                    {
                        return;
                    }
                    // Child
                    if (wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.position:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
                                dirty = true;
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

    }
}