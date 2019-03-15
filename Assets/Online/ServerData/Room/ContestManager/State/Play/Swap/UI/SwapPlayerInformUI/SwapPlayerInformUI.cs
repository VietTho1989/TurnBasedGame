using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapPlayerInformUI : UIBehavior<SwapPlayerInformUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<TeamPlayer>> teamPlayer;

            public VP<InformUI> informUI;

            #region Sub

            public abstract class Sub : Data
            {

                public enum Type
                {
                    NoRequest,
                    HaveRequest
                }

                public abstract Type getType();

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                teamPlayer,
                informUI,
                sub
            }

            public UIData() : base()
            {
                this.teamPlayer = new VP<ReferenceData<TeamPlayer>>(this, (byte)Property.teamPlayer, new ReferenceData<TeamPlayer>(null));
                this.informUI = new VP<InformUI>(this, (byte)Property.informUI, null);
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

        }

        #endregion

        #region txt

        private static readonly TxtLanguage txtTeam = new TxtLanguage();
        private static readonly TxtLanguage txtPlayer = new TxtLanguage();

        static SwapPlayerInformUI()
        {
            // txt
            {
                txtTeam.add(Language.Type.vi, "Đội");
                txtPlayer.add(Language.Type.vi, "Người chơi");
            }
            // rect
            {
                // subRect
                {
                    // anchoredPosition: (0.0, 0.0); anchorMin: (0.0, 0.0); anchorMax: (1.0, 0.6); pivot: (0.5, 0.5);
                    // offsetMin: (0.0, 0.0); offsetMax: (0.0, 0.0); sizeDelta: (0.0, 0.0);
                    subRect.anchoredPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    subRect.anchorMin = new Vector2(0.0f, 0.0f);
                    subRect.anchorMax = new Vector2(1.0f, 0.6f);
                    subRect.pivot = new Vector2(0.5f, 0.5f);
                    subRect.offsetMin = new Vector2(0.0f, 0.0f);
                    subRect.offsetMax = new Vector2(0.0f, 0.0f);
                    subRect.sizeDelta = new Vector2(0.0f, 0.0f);
                }
            }
        }

        #endregion

        #region Refresh

        public Text tvPlayerIndex;
        public Text tvTeamIndex;

        private bool firstInit = false;
        public ScrollRect informScrollRect;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    TeamPlayer teamPlayer = this.data.teamPlayer.v.data;
                    if (teamPlayer != null)
                    {
                        // tvTeamIndex
                        int teamIndex = 0;
                        {
                            if (tvTeamIndex != null)
                            {
                                {
                                    MatchTeam matchTeam = teamPlayer.findDataInParent<MatchTeam>();
                                    if (matchTeam != null)
                                    {
                                        teamIndex = matchTeam.teamIndex.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("matchTeam null: " + this);
                                    }
                                }
                                tvTeamIndex.text = txtTeam.get("Team") + " " + teamIndex;
                            }
                            else
                            {
                                Debug.LogError("tvTeamIndex null: " + this);
                            }
                        }
                        // tvPlayerIndex
                        int playerIndex = teamPlayer.playerIndex.v;
                        {
                            if (tvPlayerIndex != null)
                            {
                                tvPlayerIndex.text = txtPlayer.get("Player") + " " + playerIndex;
                            }
                            else
                            {
                                Debug.LogError("tvPlayerIndex null: " + this);
                            }
                        }
                        // inform
                        {
                            GamePlayer.Inform inform = teamPlayer.inform.v;
                            if (inform != null)
                            {
                                switch (inform.getType())
                                {
                                    case GamePlayer.Inform.Type.None:
                                        {
                                            EmptyInform emptyInform = inform as EmptyInform;
                                            // UIData
                                            EmptyInformUI.UIData emptyInformUIData = this.data.informUI.newOrOld<EmptyInformUI.UIData>();
                                            {
                                                emptyInformUIData.editEmptyInform.v.origin.v = new ReferenceData<EmptyInform>(emptyInform);
                                                emptyInformUIData.editEmptyInform.v.canEdit.v = false;
                                            }
                                            this.data.informUI.v = emptyInformUIData;
                                        }
                                        break;
                                    case GamePlayer.Inform.Type.Human:
                                        {
                                            Human human = inform as Human;
                                            // UIData
                                            HumanUI.UIData humanUIData = this.data.informUI.newOrOld<HumanUI.UIData>();
                                            {
                                                humanUIData.editHuman.v.origin.v = new ReferenceData<Human>(human);
                                                humanUIData.editHuman.v.canEdit.v = false;
                                            }
                                            this.data.informUI.v = humanUIData;
                                        }
                                        break;
                                    case GamePlayer.Inform.Type.Computer:
                                        {
                                            Computer computer = inform as Computer;
                                            // UIData
                                            ComputerUI.UIData computerUIData = this.data.informUI.newOrOld<ComputerUI.UIData>();
                                            {
                                                computerUIData.editComputer.v.origin.v = new ReferenceData<Computer>(computer);
                                                computerUIData.editComputer.v.canEdit.v = false;
                                            }
                                            this.data.informUI.v = computerUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + inform.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("inform null: " + this);
                            }
                        }
                        // sub
                        {
                            // find
                            SwapRequest swapRequest = null;
                            {
                                ContestManagerStatePlay contestManagerStatePlay = teamPlayer.findDataInParent<ContestManagerStatePlay>();
                                if (contestManagerStatePlay != null)
                                {
                                    Swap swap = contestManagerStatePlay.swap.v;
                                    if (swap != null)
                                    {
                                        swapRequest = swap.findRequest(playerIndex, teamIndex);
                                    }
                                    else
                                    {
                                        Debug.LogError("swap null: " + this);
                                    }
                                }
                                else
                                {
                                    Debug.LogError("contestManagerStatePlay null: " + this);
                                }
                            }
                            // process
                            {
                                if (swapRequest != null)
                                {
                                    HaveRequestSwapPlayerUI.UIData haveRequestSwapPlayerUIData = this.data.sub.newOrOld<HaveRequestSwapPlayerUI.UIData>();
                                    {
                                        haveRequestSwapPlayerUIData.swapRequest.v = new ReferenceData<SwapRequest>(swapRequest);
                                    }
                                    this.data.sub.v = haveRequestSwapPlayerUIData;
                                }
                                else
                                {
                                    NoRequestSwapPlayerUI.UIData noRequestSwapPlayerUIData = this.data.sub.newOrOld<NoRequestSwapPlayerUI.UIData>();
                                    {
                                        noRequestSwapPlayerUIData.teamPlayer.v = new ReferenceData<TeamPlayer>(teamPlayer);
                                    }
                                    this.data.sub.v = noRequestSwapPlayerUIData;
                                }
                            }
                        }
                        // firstInit
                        {
                            if (firstInit)
                            {
                                firstInit = false;
                                if (informScrollRect != null)
                                {
                                    informScrollRect.verticalNormalizedPosition = 1;
                                }
                                else
                                {
                                    Debug.LogError("informScrollRect null");
                                }
                            }
                        }
                    }
                    else
                    {
                        // Debug.LogError ("teamPlayer null: " + this);
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

        public EmptyInformUI emptyPrefab;
        public HumanUI humanPrefab;
        public ComputerUI computerPrefab;
        public Transform informUIContainer;

        private MatchTeam matchTeam = null;

        public NoRequestSwapPlayerUI noRequestSwapPlayerPrefab;
        public HaveRequestSwapPlayerUI haveRequestSwapPlayerPrefab;
        private static readonly UIRectTransform subRect = new UIRectTransform();

        private ContestManagerStatePlay contestManagerStatePlay = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.teamPlayer.allAddCallBack(this);
                    uiData.informUI.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
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
                // teamPlayer
                {
                    if (data is TeamPlayer)
                    {
                        TeamPlayer teamPlayer = data as TeamPlayer;
                        // Parent
                        {
                            DataUtils.addParentCallBack(teamPlayer, this, ref this.matchTeam);
                            DataUtils.addParentCallBack(teamPlayer, this, ref this.contestManagerStatePlay);
                        }
                        firstInit = true;
                        dirty = true;
                        return;
                    }
                    // Parent
                    {
                        if (data is MatchTeam)
                        {
                            dirty = true;
                            return;
                        }
                        // contestManagerStatePlay
                        {
                            if (data is ContestManagerStatePlay)
                            {
                                ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                                // Child
                                {
                                    contestManagerStatePlay.swap.allAddCallBack(this);
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            {
                                if (data is Swap)
                                {
                                    Swap swap = data as Swap;
                                    // Child
                                    {
                                        swap.swapRequests.allAddCallBack(this);
                                    }
                                    dirty = true;
                                    return;
                                }
                                // Child
                                if (data is SwapRequest)
                                {
                                    dirty = true;
                                    return;
                                }
                            }
                        }
                    }
                }
                if (data is InformUI)
                {
                    InformUI informUI = data as InformUI;
                    // UI
                    {
                        switch (informUI.getType())
                        {
                            case GamePlayer.Inform.Type.None:
                                {
                                    EmptyInformUI.UIData emptyUIData = informUI as EmptyInformUI.UIData;
                                    UIUtils.Instantiate(emptyUIData, emptyPrefab, informUIContainer);
                                }
                                break;
                            case GamePlayer.Inform.Type.Computer:
                                {
                                    ComputerUI.UIData computerUIData = informUI as ComputerUI.UIData;
                                    UIUtils.Instantiate(computerUIData, computerPrefab, informUIContainer);
                                }
                                break;
                            case GamePlayer.Inform.Type.Human:
                                {
                                    HumanUI.UIData humanUIData = informUI as HumanUI.UIData;
                                    UIUtils.Instantiate(humanUIData, humanPrefab, informUIContainer);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + informUI.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.NoRequest:
                                {
                                    NoRequestSwapPlayerUI.UIData noRequestSwapPlayerUIData = sub as NoRequestSwapPlayerUI.UIData;
                                    UIUtils.Instantiate(noRequestSwapPlayerUIData, noRequestSwapPlayerPrefab, this.transform, subRect);
                                }
                                break;
                            case UIData.Sub.Type.HaveRequest:
                                {
                                    HaveRequestSwapPlayerUI.UIData haveRequestSwapPlayerUIData = sub as HaveRequestSwapPlayerUI.UIData;
                                    UIUtils.Instantiate(haveRequestSwapPlayerUIData, haveRequestSwapPlayerPrefab, this.transform, subRect);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + ";" + this);
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
                    uiData.teamPlayer.allRemoveCallBack(this);
                    uiData.informUI.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
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
                // teamPlayer
                {
                    if (data is TeamPlayer)
                    {
                        TeamPlayer teamPlayer = data as TeamPlayer;
                        // Parent
                        {
                            DataUtils.removeParentCallBack(teamPlayer, this, ref this.matchTeam);
                            DataUtils.removeParentCallBack(teamPlayer, this, ref this.contestManagerStatePlay);
                        }
                        return;
                    }
                    // Parent
                    {
                        if (data is MatchTeam)
                        {
                            return;
                        }
                        // contestManagerStatePlay
                        {
                            if (data is ContestManagerStatePlay)
                            {
                                ContestManagerStatePlay contestManagerStatePlay = data as ContestManagerStatePlay;
                                // Child
                                {
                                    contestManagerStatePlay.swap.allRemoveCallBack(this);
                                }
                                return;
                            }
                            // Child
                            {
                                if (data is Swap)
                                {
                                    Swap swap = data as Swap;
                                    // Child
                                    {
                                        swap.swapRequests.allRemoveCallBack(this);
                                    }
                                    return;
                                }
                                // Child
                                if (data is SwapRequest)
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
                if (data is InformUI)
                {
                    InformUI informUI = data as InformUI;
                    // UI
                    {
                        switch (informUI.getType())
                        {
                            case GamePlayer.Inform.Type.None:
                                {
                                    EmptyInformUI.UIData emptyUIData = informUI as EmptyInformUI.UIData;
                                    emptyUIData.removeCallBackAndDestroy(typeof(EmptyInformUI));
                                }
                                break;
                            case GamePlayer.Inform.Type.Computer:
                                {
                                    ComputerUI.UIData computerUIData = informUI as ComputerUI.UIData;
                                    computerUIData.removeCallBackAndDestroy(typeof(ComputerUI));
                                }
                                break;
                            case GamePlayer.Inform.Type.Human:
                                {
                                    HumanUI.UIData humanUIData = informUI as HumanUI.UIData;
                                    humanUIData.removeCallBackAndDestroy(typeof(HumanUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + informUI.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case UIData.Sub.Type.NoRequest:
                                {
                                    NoRequestSwapPlayerUI.UIData noRequestSwapPlayerUIData = sub as NoRequestSwapPlayerUI.UIData;
                                    noRequestSwapPlayerUIData.removeCallBackAndDestroy(typeof(NoRequestSwapPlayerUI));
                                }
                                break;
                            case UIData.Sub.Type.HaveRequest:
                                {
                                    HaveRequestSwapPlayerUI.UIData haveRequestSwapPlayerUIData = sub as HaveRequestSwapPlayerUI.UIData;
                                    haveRequestSwapPlayerUIData.removeCallBackAndDestroy(typeof(HaveRequestSwapPlayerUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                break;
                        }
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
                    case UIData.Property.teamPlayer:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.informUI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.sub:
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
                // teamPlayer
                {
                    if (wrapProperty.p is TeamPlayer)
                    {
                        switch ((TeamPlayer.Property)wrapProperty.n)
                        {
                            case TeamPlayer.Property.playerIndex:
                                dirty = true;
                                break;
                            case TeamPlayer.Property.inform:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Parent
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
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // contestManagerStatePlay
                        {
                            if (wrapProperty.p is ContestManagerStatePlay)
                            {
                                switch ((ContestManagerStatePlay.Property)wrapProperty.n)
                                {
                                    case ContestManagerStatePlay.Property.state:
                                        break;
                                    case ContestManagerStatePlay.Property.isForceEnd:
                                        break;
                                    case ContestManagerStatePlay.Property.teams:
                                        break;
                                    case ContestManagerStatePlay.Property.swap:
                                        {
                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                            dirty = true;
                                        }
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
                            // Child
                            {
                                if (wrapProperty.p is Swap)
                                {
                                    switch ((Swap.Property)wrapProperty.n)
                                    {
                                        case Swap.Property.swapRequests:
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
                                if (wrapProperty.p is SwapRequest)
                                {
                                    switch ((SwapRequest.Property)wrapProperty.n)
                                    {
                                        case SwapRequest.Property.state:
                                            break;
                                        case SwapRequest.Property.teamIndex:
                                            dirty = true;
                                            break;
                                        case SwapRequest.Property.playerIndex:
                                            dirty = true;
                                            break;
                                        case SwapRequest.Property.inform:
                                            break;
                                        default:
                                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                            break;
                                    }
                                    return;
                                }
                            }
                        }
                    }
                }
                if (wrapProperty.p is InformUI)
                {
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}