using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapUI : UIBehavior<SwapUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<Swap>> swap;

            public VP<SwapTeamAdapter.UIData> swapTeamAdapter;

            public VP<SwapPlayerInformUI.UIData> swapPlayerInformUIData;

            #region Constructor

            public enum Property
            {
                swap,
                swapTeamAdapter,
                swapPlayerInformUIData
            }

            public UIData() : base()
            {
                this.swap = new VP<ReferenceData<Swap>>(this, (byte)Property.swap, new ReferenceData<Swap>(null));
                this.swapTeamAdapter = new VP<SwapTeamAdapter.UIData>(this, (byte)Property.swapTeamAdapter, new SwapTeamAdapter.UIData());
                this.swapPlayerInformUIData = new VP<SwapPlayerInformUI.UIData>(this, (byte)Property.swapPlayerInformUIData, new SwapPlayerInformUI.UIData());
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // back
                    if (!isProcess)
                    {
                        if (InputEvent.isBackEvent(e))
                        {
                            SwapUI swapUI = this.findCallBack<SwapUI>();
                            if (swapUI != null)
                            {
                                swapUI.onClickBtnBack();
                            }
                            else
                            {
                                Debug.LogError("swapUI null: " + this);
                            }
                            isProcess = true;
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Swap Player");

        static SwapUI()
        {
            txtTitle.add(Language.Type.vi, "Thay Người");
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
                    Swap swap = this.data.swap.v.data;
                    if (swap != null)
                    {
                        // swapTeamAdapter
                        {
                            SwapTeamAdapter.UIData swapTeamAdapter = this.data.swapTeamAdapter.v;
                            if (swapTeamAdapter != null)
                            {
                                ContestManagerStatePlay contestManagerStatePlay = swap.findDataInParent<ContestManagerStatePlay>();
                                swapTeamAdapter.contestManagerStatePlay.v = new ReferenceData<ContestManagerStatePlay>(contestManagerStatePlay);
                            }
                            else
                            {
                                Debug.LogError("swapTeamAdapter null: " + this);
                            }
                        }
                        // swapPlayerInformUIData
                        {
                            SwapPlayerInformUI.UIData swapPlayerInformUIData = this.data.swapPlayerInformUIData.v;
                            if (swapPlayerInformUIData != null)
                            {
                                bool isNotAlreadyShow = true;
                                {
                                    TeamPlayer teamPlayer = swapPlayerInformUIData.teamPlayer.v.data;
                                    if (teamPlayer != null)
                                    {
                                        ContestManagerStatePlay contestManagerStatePlay = swap.findDataInParent<ContestManagerStatePlay>();
                                        if (contestManagerStatePlay != null)
                                        {
                                            foreach (MatchTeam matchTeam in contestManagerStatePlay.teams.vs)
                                            {
                                                if (matchTeam.players.vs.Contains(teamPlayer))
                                                {
                                                    isNotAlreadyShow = false;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("teamPlayer null: " + this);
                                    }
                                }
                                if (isNotAlreadyShow)
                                {
                                    // find first TeamPlayer
                                    TeamPlayer firstTeamPlayer = null;
                                    {
                                        ContestManagerStatePlay contestManagerStatePlay = swap.findDataInParent<ContestManagerStatePlay>();
                                        if (contestManagerStatePlay != null)
                                        {
                                            if (contestManagerStatePlay.teams.vs.Count > 0)
                                            {
                                                MatchTeam firstTeam = contestManagerStatePlay.teams.vs[0];
                                                if (firstTeam.players.vs.Count > 0)
                                                {
                                                    firstTeamPlayer = firstTeam.players.vs[0];
                                                }
                                                else
                                                {
                                                    Debug.LogError("Don't have any players");
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("Don't have any teams: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("contestManagerStatePlay null: " + this);
                                        }
                                    }
                                    swapPlayerInformUIData.teamPlayer.v = new ReferenceData<TeamPlayer>(firstTeamPlayer);
                                }
                            }
                            else
                            {
                                Debug.LogError("swapPlayerInformUIData null: " + this);
                            }
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get();
                            }
                            else
                            {
                                Debug.LogError("lbTitle null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("swap null: " + this);
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

        public SwapTeamAdapter swapTeamAdapterPrefab;
        private static readonly UIRectTransform swapTeamAdapterRect = UIRectTransform.CreateFullRect(0, 240, UIConstants.HeaderHeight, 0);

        public SwapPlayerInformUI swapPlayerInformPrefab;
        private static readonly UIRectTransform swapPlayerInformRect = UIRectTransform.CreateFullRect(120, 0, UIConstants.HeaderHeight, 0);

        private ContestManagerStatePlay contestManagerStatePlay = null;
        private ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay> contestManagerStatePlayTeamCheckChange = new ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.swap.allAddCallBack(this);
                    uiData.swapTeamAdapter.allAddCallBack(this);
                    uiData.swapPlayerInformUIData.allAddCallBack(this);
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
                // swap
                {
                    if (data is Swap)
                    {
                        Swap swap = data as Swap;
                        // Parent
                        {
                            DataUtils.addParentCallBack(swap, this, ref this.contestManagerStatePlay);
                        }
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is ContestManagerStatePlay)
                        {
                            ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                            // CheckChange
                            {
                                contestManagerStatePlayTeamCheckChange.addCallBack(this);
                                contestManagerStatePlayTeamCheckChange.setData(contestManagerStatePlay);
                            }
                            dirty = true;
                            return;
                        }
                        // CheckChange
                        if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (data is SwapTeamAdapter.UIData)
                {
                    SwapTeamAdapter.UIData swapTeamAdapterUIData = data as SwapTeamAdapter.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(swapTeamAdapterUIData, swapTeamAdapterPrefab, this.transform, swapTeamAdapterRect);
                    }
                    dirty = true;
                    return;
                }
                if (data is SwapPlayerInformUI.UIData)
                {
                    SwapPlayerInformUI.UIData swapPlayerInformUIData = data as SwapPlayerInformUI.UIData;
                    // UI
                    {
                        UIUtils.Instantiate(swapPlayerInformUIData, swapPlayerInformPrefab, this.transform, swapPlayerInformRect);
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
                    uiData.swap.allRemoveCallBack(this);
                    uiData.swapTeamAdapter.allRemoveCallBack(this);
                    uiData.swapPlayerInformUIData.allRemoveCallBack(this);
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
                // swap
                {
                    if (data is Swap)
                    {
                        Swap swap = data as Swap;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(swap, this, ref this.contestManagerStatePlay);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is ContestManagerStatePlay)
                        {
                            // ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                            // CheckChange
                            {
                                contestManagerStatePlayTeamCheckChange.removeCallBack(this);
                                contestManagerStatePlayTeamCheckChange.setData(null);
                            }
                            return;
                        }
                        // CheckChange
                        if (data is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                        {
                            return;
                        }
                    }
                }
                if (data is SwapTeamAdapter.UIData)
                {
                    SwapTeamAdapter.UIData swapTeamAdapterUIData = data as SwapTeamAdapter.UIData;
                    // UI
                    {
                        swapTeamAdapterUIData.removeCallBackAndDestroy(typeof(SwapTeamAdapter));
                    }
                    return;
                }
                if (data is SwapPlayerInformUI.UIData)
                {
                    SwapPlayerInformUI.UIData swapPlayerInformUIData = data as SwapPlayerInformUI.UIData;
                    // UI
                    {
                        swapPlayerInformUIData.removeCallBackAndDestroy(typeof(SwapPlayerInformUI));
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
                    case UIData.Property.swap:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.swapTeamAdapter:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.swapPlayerInformUIData:
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
                // swap
                {
                    if (wrapProperty.p is Swap)
                    {
                        return;
                    }
                    // Parent
                    {
                        if (wrapProperty.p is ContestManagerStatePlay)
                        {
                            return;
                        }
                        // CheckChange
                        if (wrapProperty.p is ContestManagerStatePlayTeamCheckChange<ContestManagerStatePlay>)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
                if (wrapProperty.p is SwapTeamAdapter.UIData)
                {
                    return;
                }
                if (wrapProperty.p is SwapPlayerInformUI.UIData)
                {
                    switch ((SwapPlayerInformUI.UIData.Property)wrapProperty.n)
                    {
                        case SwapPlayerInformUI.UIData.Property.teamPlayer:
                            dirty = true;
                            break;
                        case SwapPlayerInformUI.UIData.Property.informUI:
                            break;
                        case SwapPlayerInformUI.UIData.Property.sub:
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

        public void onClickBtnBack()
        {
            if (this.data != null)
            {
                ContestManagerStatePlayUI.UIData contestManagerStatePlayUIData = this.data.findDataInParent<ContestManagerStatePlayUI.UIData>();
                if (contestManagerStatePlayUIData != null)
                {
                    contestManagerStatePlayUIData.swapUIData.v = null;
                }
                else
                {
                    Debug.LogError("contestManagerStatePlayUIData null: " + this);
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}