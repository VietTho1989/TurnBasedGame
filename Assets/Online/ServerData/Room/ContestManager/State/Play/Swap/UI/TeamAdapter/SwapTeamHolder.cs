using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapTeamHolder : SriaHolderBehavior<SwapTeamHolder.UIData>
    {

        #region UIData

        public class UIData : BaseItemViewsHolder
        {

            public VP<ReferenceData<MatchTeam>> matchTeam;

            public LP<SwapPlayerUI.UIData> players;

            #region Constructor

            public enum Property
            {
                matchTeam,
                players
            }

            public UIData() : base()
            {
                this.matchTeam = new VP<ReferenceData<MatchTeam>>(this, (byte)Property.matchTeam, new ReferenceData<MatchTeam>(null));
                this.players = new LP<SwapPlayerUI.UIData>(this, (byte)Property.players);
            }

            #endregion

            public void updateView(SwapTeamAdapter.UIData myParams)
            {
                // Find
                MatchTeam matchTeam = null;
                {
                    if (ItemIndex >= 0 && ItemIndex < myParams.matchTeams.Count)
                    {
                        matchTeam = myParams.matchTeams[ItemIndex];
                    }
                    else
                    {
                        Debug.LogError("ItemIdex error: " + this);
                    }
                }
                // Update
                this.matchTeam.v = new ReferenceData<MatchTeam>(matchTeam);
            }

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtTeam = new TxtLanguage("Team");

        static SwapTeamHolder()
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
                    MatchTeam matchTeam = this.data.matchTeam.v.data;
                    if (matchTeam != null)
                    {
                        // tvIndex
                        {
                            if (tvTeamIndex != null)
                            {
                                tvTeamIndex.text = txtTeam.get() + " " + matchTeam.teamIndex.v;
                            }
                            else
                            {
                                Debug.LogError("tvIndex null: " + this);
                            }
                        }
                        // players
                        {
                            // get old
                            List<SwapPlayerUI.UIData> oldPlayers = new List<SwapPlayerUI.UIData>();
                            {
                                oldPlayers.AddRange(this.data.players.vs);
                            }
                            // Update
                            {
                                foreach (TeamPlayer teamPlayer in matchTeam.players.vs)
                                {
                                    // find
                                    SwapPlayerUI.UIData swapPlayerUIData = null;
                                    {
                                        // find old
                                        if (oldPlayers.Count > 0)
                                        {
                                            swapPlayerUIData = oldPlayers[0];
                                        }
                                        // make new
                                        if (swapPlayerUIData == null)
                                        {
                                            swapPlayerUIData = new SwapPlayerUI.UIData();
                                            {
                                                swapPlayerUIData.uid = this.data.players.makeId();
                                            }
                                            this.data.players.add(swapPlayerUIData);
                                        }
                                        else
                                        {
                                            oldPlayers.Remove(swapPlayerUIData);
                                        }
                                    }
                                    // Update
                                    {
                                        swapPlayerUIData.teamPlayer.v = new ReferenceData<TeamPlayer>(teamPlayer);
                                    }
                                }
                            }
                            // remove old
                            foreach (SwapPlayerUI.UIData oldPlayer in oldPlayers)
                            {
                                this.data.players.remove(oldPlayer);
                            }
                        }
                        // UI
                        {
                            float deltaY = 0;
                            // header
                            deltaY += UIConstants.HeaderHeight;
                            // players
                            {
                                foreach (SwapPlayerUI.UIData playerUIData in this.data.players.vs)
                                {
                                    deltaY += UIRectTransform.SetPosY(playerUIData, deltaY);
                                }
                            }
                            // set
                            {
                                UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                                this.refreshItemSize(deltaY);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("matchTeam null: " + this);
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

        public SwapPlayerUI swapPlayerPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.matchTeam.allAddCallBack(this);
                    uiData.players.allAddCallBack(this);
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
                if (data is MatchTeam)
                {
                    dirty = true;
                    return;
                }
                if (data is SwapPlayerUI.UIData)
                {
                    SwapPlayerUI.UIData swapPlayerUIData = data as SwapPlayerUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(swapPlayerUIData, swapPlayerPrefab, this.transform);
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
                // Child
                {
                    uiData.matchTeam.allRemoveCallBack(this);
                    uiData.players.allRemoveCallBack(this);
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
                if (data is MatchTeam)
                {
                    return;
                }
                if (data is SwapPlayerUI.UIData)
                {
                    SwapPlayerUI.UIData swapPlayerUIData = data as SwapPlayerUI.UIData;
                    // UI
                    {
                        swapPlayerUIData.removeCallBackAndDestroy(typeof(SwapPlayerUI));
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
                    case UIData.Property.matchTeam:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.players:
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
                if (wrapProperty.p is MatchTeam)
                {
                    switch ((MatchTeam.Property)wrapProperty.n)
                    {
                        case MatchTeam.Property.teamIndex:
                            dirty = true;
                            break;
                        case MatchTeam.Property.state:
                            break;
                        case MatchTeam.Property.players:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is SwapPlayerUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}