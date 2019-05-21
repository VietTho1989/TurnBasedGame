using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class LobbyMiniSettingUI : UIHaveTransformDataBehavior<LobbyMiniSettingUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<ContestManagerStateLobby>> contestManagerStateLobby;

            public VP<GameFactoryUI.UIData> gameFactory;

            #region Constructor

            public enum Property
            {
                contestManagerStateLobby,
                gameFactory
            }

            public UIData() : base()
            {
                this.contestManagerStateLobby = new VP<ReferenceData<ContestManagerStateLobby>>(this, (byte)Property.contestManagerStateLobby, new ReferenceData<ContestManagerStateLobby>(null));
                // gameFactory
                {
                    this.gameFactory = new VP<GameFactoryUI.UIData>(this, (byte)Property.gameFactory, new GameFactoryUI.UIData());
                    this.gameFactory.v.useRule.v = null;
                    this.gameFactory.v.blindFold.v = null;
                    this.gameFactory.v.timeControl.v = null;
                }
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // gameFactory
                    if (!isProcess)
                    {
                        GameFactoryUI.UIData gameFactory = this.gameFactory.v;
                        if (gameFactory != null)
                        {
                            isProcess = gameFactory.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("gameFactory null");
                        }
                    }
                }
                return isProcess;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return 1;
        }

        #region txt, rect

        public Button btnExpand;
        public Text tvExpand;
        private static readonly TxtLanguage txtExpand = new TxtLanguage("Expand");

        static LobbyMiniSettingUI()
        {
            txtExpand.add(Language.Type.vi, "Mở Rộng");
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
                        // gameFactory
                        {
                            GameFactoryUI.UIData gameFactoryUIData = this.data.gameFactory.v;
                            if (gameFactoryUIData != null)
                            {
                                // origin
                                {
                                    GameFactory origin = null;
                                    {
                                        // find singleContestFactory
                                        SingleContestFactory singleContestFactory = null;
                                        {
                                            ContestManagerContentFactory contestManagerContentFactory = contestManagerStateLobby.contentFactory.v;
                                            if (contestManagerContentFactory != null)
                                            {
                                                switch (contestManagerContentFactory.getType())
                                                {

                                                    case ContestManagerContent.Type.Single:
                                                        {
                                                            singleContestFactory = contestManagerContentFactory as SingleContestFactory;
                                                        }
                                                        break;
                                                    case ContestManagerContent.Type.RoundRobin:
                                                        {
                                                            RoundRobin.RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobin.RoundRobinFactory;
                                                            singleContestFactory = roundRobinFactory.singleContestFactory.v;
                                                        }
                                                        break;
                                                    case ContestManagerContent.Type.Elimination:
                                                        {
                                                            Elimination.EliminationFactory eliminationFactory = contestManagerContentFactory as Elimination.EliminationFactory;
                                                            singleContestFactory = eliminationFactory.singleContestFactory.v;
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + contestManagerContentFactory.getType());
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("contestManagerContentFactory null");
                                            }
                                        }
                                        // process
                                        if (singleContestFactory != null)
                                        {
                                            RoundFactory roundFactory = singleContestFactory.roundFactory.v;
                                            if (roundFactory != null)
                                            {
                                                switch (roundFactory.getType())
                                                {
                                                    case RoundFactory.Type.Normal:
                                                        {
                                                            NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                                            origin = normalRoundFactory.gameFactory.v;
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + roundFactory.getType());
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("roundFactory null");
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("singleContestFactory null");
                                        }
                                    }
                                    gameFactoryUIData.editGameFactory.v.origin.v = new ReferenceData<GameFactory>(origin);
                                }
                                // canEdit?
                                {
                                    bool canEdit = false;
                                    {
                                        uint profileId = Server.getProfileUserId(contestManagerStateLobby);
                                        if (contestManagerStateLobby.isCanChange(profileId))
                                        {
                                            canEdit = true;
                                        }
                                    }
                                    gameFactoryUIData.editGameFactory.v.canEdit.v = canEdit;
                                }
                            }
                            else
                            {
                                // Debug.LogError("contentFactoryUIData null: " + this);
                            }
                        }
                        // UI
                        {
                            // UISize
                            {
                                float deltaY = 0;
                                float itemSize = Setting.get().getItemSize();
                                // gameFactory
                                deltaY += UIRectTransform.SetPosY(this.data.gameFactory.v, deltaY);
                                // btn
                                {
                                    if (btnExpand != null)
                                    {
                                        UIRectTransform.SetPosY((RectTransform)btnExpand.transform, deltaY + (itemSize - 30) / 2.0f);
                                    }
                                    else
                                    {
                                        Debug.LogError("btnExpand null");
                                    }
                                    deltaY += itemSize;
                                }
                                // set
                                UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                            }
                        }
                        // txt
                        {
                            if (tvExpand != null)
                            {
                                tvExpand.text = txtExpand.get();
                                Setting.get().setContentTextSize(tvExpand);
                            }
                            else
                            {
                                Debug.LogError("tvExpand null");
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("contestManagerStateLobby null");
                    }
                }
                else
                {
                    Debug.LogError("data null");
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public GameFactoryUI gameFactoryPrefab;

        private RoomCheckChangeAdminChange<ContestManagerStateLobby> roomCheckAdminChange = new RoomCheckChangeAdminChange<ContestManagerStateLobby>();

        public override void onAddCallBack<T>(T data)
        {
            if(data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.contestManagerStateLobby.allAddCallBack(this);
                    uiData.gameFactory.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                // contestManagerStateLobby
                {
                    if(data is ContestManagerStateLobby)
                    {
                        ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                        // checkChange
                        {
                            roomCheckAdminChange.addCallBack(this);
                            roomCheckAdminChange.setData(contestManagerStateLobby);
                        }
                        // Child
                        {
                            contestManagerStateLobby.contentFactory.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // checkChange
                    if(data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        // singleContestFactory
                        {
                            if (data is SingleContestFactory)
                            {
                                SingleContestFactory singleContestFactory = data as SingleContestFactory;
                                // Child
                                {
                                    singleContestFactory.roundFactory.allAddCallBack(this);
                                }
                                dirty = true;
                                return;
                            }
                            // Child
                            if (data is RoundFactory)
                            {
                                dirty = true;
                                return;
                            }
                        }
                        if (data is ContestManagerContentFactory)
                        {
                            ContestManagerContentFactory contestManagerContentFactory = data as ContestManagerContentFactory;
                            // Child
                            {
                                switch (contestManagerContentFactory.getType())
                                {
                                    case ContestManagerContent.Type.Single:
                                        break;
                                    case ContestManagerContent.Type.RoundRobin:
                                        {
                                            RoundRobin.RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobin.RoundRobinFactory;
                                            roundRobinFactory.singleContestFactory.allAddCallBack(this);
                                        }
                                        break;
                                    case ContestManagerContent.Type.Elimination:
                                        {
                                            Elimination.EliminationFactory eliminationFactory = contestManagerContentFactory as Elimination.EliminationFactory;
                                            eliminationFactory.singleContestFactory.allAddCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + contestManagerContentFactory.getType());
                                        break;
                                }
                            }
                            dirty = true;
                            return;
                        }
                    }
                }
                // gameFactoryUIData 
                {
                    if (data is GameFactoryUI.UIData)
                    {
                        GameFactoryUI.UIData gameFactoryUIData = data as GameFactoryUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(gameFactoryUIData, gameFactoryPrefab, this.transform);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(gameFactoryUIData, this);
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
                // Child
                {
                    uiData.contestManagerStateLobby.allRemoveCallBack(this);
                    uiData.gameFactory.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                // contestManagerStateLobby
                {
                    if (data is ContestManagerStateLobby)
                    {
                        ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                        // checkChange
                        {
                            roomCheckAdminChange.removeCallBack(this);
                            roomCheckAdminChange.setData(null);
                        }
                        // Child
                        {
                            contestManagerStateLobby.contentFactory.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // checkChange
                    if (data is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        return;
                    }
                    // Child
                    {
                        // singleContestFactory
                        {
                            if (data is SingleContestFactory)
                            {
                                SingleContestFactory singleContestFactory = data as SingleContestFactory;
                                // Child
                                {
                                    singleContestFactory.roundFactory.allRemoveCallBack(this);
                                }
                                return;
                            }
                            // Child
                            if (data is RoundFactory)
                            {
                                return;
                            }
                        }
                        if (data is ContestManagerContentFactory)
                        {
                            ContestManagerContentFactory contestManagerContentFactory = data as ContestManagerContentFactory;
                            // Child
                            {
                                switch (contestManagerContentFactory.getType())
                                {
                                    case ContestManagerContent.Type.Single:
                                        break;
                                    case ContestManagerContent.Type.RoundRobin:
                                        {
                                            RoundRobin.RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobin.RoundRobinFactory;
                                            roundRobinFactory.singleContestFactory.allRemoveCallBack(this);
                                        }
                                        break;
                                    case ContestManagerContent.Type.Elimination:
                                        {
                                            Elimination.EliminationFactory eliminationFactory = contestManagerContentFactory as Elimination.EliminationFactory;
                                            eliminationFactory.singleContestFactory.allRemoveCallBack(this);
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + contestManagerContentFactory.getType());
                                        break;
                                }
                            }
                            return;
                        }
                    }
                }
                // gameFactoryUIData 
                {
                    if (data is GameFactoryUI.UIData)
                    {
                        GameFactoryUI.UIData gameFactoryUIData = data as GameFactoryUI.UIData;
                        // UI
                        {
                            gameFactoryUIData.removeCallBackAndDestroy(typeof(GameFactoryUI));
                        }
                        // Child
                        {
                            TransformData.RemoveCallBack(gameFactoryUIData, this);
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
                    case UIData.Property.contestManagerStateLobby:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.gameFactory:
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
            {
                // contestManagerStateLobby
                {
                    if (wrapProperty.p is ContestManagerStateLobby)
                    {
                        switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                        {
                            case ContestManagerStateLobby.Property.state:
                                break;
                            case ContestManagerStateLobby.Property.teams:
                                break;
                            case ContestManagerStateLobby.Property.gameType:
                                break;
                            case ContestManagerStateLobby.Property.randomTeamIndex:
                                break;
                            case ContestManagerStateLobby.Property.contentFactory:
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
                    // checkChange
                    if (wrapProperty.p is RoomCheckChangeAdminChange<ContestManagerStateLobby>)
                    {
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        // singleContestFactory
                        {
                            if (wrapProperty.p is SingleContestFactory)
                            {
                                switch ((SingleContestFactory.Property)wrapProperty.n)
                                {
                                    case SingleContestFactory.Property.playerPerTeam:
                                        break;
                                    case SingleContestFactory.Property.roundFactory:
                                        {
                                            ValueChangeUtils.replaceCallBack(this, syncs);
                                            dirty = true;
                                        }
                                        break;
                                    case SingleContestFactory.Property.newRoundLimit:
                                        break;
                                    case SingleContestFactory.Property.calculateScore:
                                        break;
                                    default:
                                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                        break;
                                }
                                return;
                            }
                            // Child
                            if (wrapProperty.p is RoundFactory)
                            {
                                RoundFactory roundFactory = wrapProperty.p as RoundFactory;
                                switch (roundFactory.getType())
                                {
                                    case RoundFactory.Type.Normal:
                                        {
                                            switch ((NormalRoundFactory.Property)wrapProperty.n)
                                            {
                                                case NormalRoundFactory.Property.gameFactory:
                                                    dirty = true;
                                                    break;
                                                case NormalRoundFactory.Property.isChangeSideBetweenRound:
                                                    break;
                                                case NormalRoundFactory.Property.isSwitchPlayer:
                                                    break;
                                                case NormalRoundFactory.Property.isDifferentInTeam:
                                                    break;
                                                case NormalRoundFactory.Property.calculateScore:
                                                    break;
                                                default:
                                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                    break;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + roundFactory.getType());
                                        break;
                                }
                                return;
                            }
                        }
                        if (wrapProperty.p is ContestManagerContentFactory)
                        {
                            ContestManagerContentFactory contestManagerContentFactory = wrapProperty.p as ContestManagerContentFactory;
                            switch (contestManagerContentFactory.getType())
                            {
                                case ContestManagerContent.Type.Single:
                                    break;
                                case ContestManagerContent.Type.RoundRobin:
                                    {
                                        switch ((RoundRobin.RoundRobinFactory.Property)wrapProperty.n)
                                        {
                                            case RoundRobin.RoundRobinFactory.Property.singleContestFactory:
                                                {
                                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                                    dirty = true;
                                                }
                                                break;
                                            case RoundRobin.RoundRobinFactory.Property.teamCount:
                                                break;
                                            case RoundRobin.RoundRobinFactory.Property.needReturnRound:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                case ContestManagerContent.Type.Elimination:
                                    {
                                        switch ((Elimination.EliminationFactory.Property)wrapProperty.n)
                                        {
                                            case Elimination.EliminationFactory.Property.singleContestFactory:
                                                {
                                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                                    dirty = true;
                                                }
                                                break;
                                            case Elimination.EliminationFactory.Property.initTeamCounts:
                                                break;
                                            default:
                                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                                break;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + contestManagerContentFactory.getType());
                                    break;
                            }
                            return;
                        }
                    }
                }
                // gameFactoryUIData 
                {
                    if (wrapProperty.p is GameFactoryUI.UIData)
                    {
                        return;
                    }
                    // Child
                    if (wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
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
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

        public void onClickBtnExpand()
        {
            if (this.data != null)
            {
                ContestManagerStateLobbyUI.UIData contestManagerStateLobbyUIData = this.data.findDataInParent<ContestManagerStateLobbyUI.UIData>();
                if (contestManagerStateLobbyUIData != null)
                {
                    // contestManagerFactory
                    {
                        ContestManagerContentFactoryUI.UIData contestManagerContentFactoryUIData = contestManagerStateLobbyUIData.contentFactory.newOrOld<ContestManagerContentFactoryUI.UIData>();
                        {

                        }
                        contestManagerStateLobbyUIData.contentFactory.v = contestManagerContentFactoryUIData;
                    }
                    // roomSetting
                    {
                        RoomSettingUI.UIData roomSettingUIData = contestManagerStateLobbyUIData.roomSetting.newOrOld<RoomSettingUI.UIData>();
                        {

                        }
                        contestManagerStateLobbyUIData.roomSetting.v = roomSettingUIData;
                    }
                }
                else
                {
                    Debug.LogError("contestManagerStateLobbyUIData null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }

    }
}