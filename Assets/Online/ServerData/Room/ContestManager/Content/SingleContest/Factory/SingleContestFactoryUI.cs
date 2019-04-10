using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class SingleContestFactoryUI : UIHaveTransformDataBehavior<SingleContestFactoryUI.UIData>
    {

        #region UIData

        public class UIData : ContestManagerContentFactoryUI.UIData.Sub, EditDataUI.UIData<SingleContestFactory>
        {

            public VP<EditData<SingleContestFactory>> editSingleContestFactory;

            #region playerPerTeam

            public VP<RequestChangeIntUI.UIData> playerPerTeam;

            public void makeRequestChangePlayerPerTeam(RequestChangeUpdate<int>.UpdateData update, int newPlayerPerTeam)
            {
                // Find
                SingleContestFactory singleContestFactory = null;
                {
                    EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
                    if (editSingleContestFactory != null)
                    {
                        singleContestFactory = editSingleContestFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSingleContestFactory null: " + this);
                    }
                }
                // Process
                if (singleContestFactory != null)
                {
                    singleContestFactory.requestChangePlayerPerTeam(Server.getProfileUserId(singleContestFactory), newPlayerPerTeam);
                }
                else
                {
                    Debug.LogError("singleContestFactory null: " + this);
                }
            }

            #endregion

            #region roundFactory

            public VP<RequestChangeEnumUI.UIData> roundFactoryType;

            public void makeRequestChangeRoundFactoryType(RequestChangeUpdate<int>.UpdateData update, int newRoundFactoryType)
            {
                // Find
                SingleContestFactory singleContestFactory = null;
                {
                    EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
                    if (editSingleContestFactory != null)
                    {
                        singleContestFactory = editSingleContestFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSingleContestFactory null: " + this);
                    }
                }
                // Process
                if (singleContestFactory != null)
                {
                    singleContestFactory.requestChangeRoundFactoryType(Server.getProfileUserId(singleContestFactory), newRoundFactoryType);
                }
                else
                {
                    Debug.LogError("singleContestFactory null: " + this);
                }
            }

            public abstract class RoundFactoryUI : Data
            {

                public abstract RoundFactory.Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<RoundFactoryUI> roundFactoryUI;

            #endregion

            #region limit

            public VP<RequestChangeEnumUI.UIData> newRoundLimitType;

            public void makeRequestChangeNewRoundLimitType(RequestChangeUpdate<int>.UpdateData update, int newRoundLimitType)
            {
                // Find
                SingleContestFactory singleContestFactory = null;
                {
                    EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
                    if (editSingleContestFactory != null)
                    {
                        singleContestFactory = editSingleContestFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSingleContestFactory null: " + this);
                    }
                }
                // Process
                if (singleContestFactory != null)
                {
                    singleContestFactory.requestChangeNewRoundLimitType(Server.getProfileUserId(singleContestFactory), newRoundLimitType);
                }
                else
                {
                    Debug.LogError("singleContestFactory null: " + this);
                }
            }

            public abstract class NewRoundLimitUI : Data
            {

                public abstract RequestNewRound.Limit.Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<NewRoundLimitUI> newRoundLimitUI;

            #endregion

            #region calculateScore

            public VP<RequestChangeEnumUI.UIData> calculateScoreType;

            public void makeRequestChangeCalculateScoreType(RequestChangeUpdate<int>.UpdateData update, int newCalculateScoreType)
            {
                // Find
                SingleContestFactory singleContestFactory = null;
                {
                    EditData<SingleContestFactory> editSingleContestFactory = this.editSingleContestFactory.v;
                    if (editSingleContestFactory != null)
                    {
                        singleContestFactory = editSingleContestFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSingleContestFactory null: " + this);
                    }
                }
                // Process
                if (singleContestFactory != null)
                {
                    singleContestFactory.requestChangeCalculateScoreType(Server.getProfileUserId(singleContestFactory), newCalculateScoreType);
                }
                else
                {
                    Debug.LogError("singleContestFactory null: " + this);
                }
            }

            public VP<CalculateScore.UIData> calculateScoreUI;

            #endregion

            #region Constructor

            public enum Property
            {
                editSingleContestFactory,
                playerPerTeam,

                roundFactoryType,
                roundFactoryUI,

                newRoundLimitType,
                newRoundLimitUI,

                calculateScoreType,
                calculateScoreUI
            }

            public UIData() : base()
            {
                this.editSingleContestFactory = new VP<EditData<SingleContestFactory>>(this, (byte)Property.editSingleContestFactory, new EditData<SingleContestFactory>());
                // playerPerTeam
                {
                    this.playerPerTeam = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.playerPerTeam, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.playerPerTeam.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 20;
                        }
                        this.playerPerTeam.v.limit.v = have;
                    }
                    // event
                    this.playerPerTeam.v.updateData.v.request.v = makeRequestChangePlayerPerTeam;
                }
                // roundFactoryType
                {
                    this.roundFactoryType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.roundFactoryType, null);
                    // event
                    // this.roundFactoryType.v.updateData.v.request.v = makeRequestChangeRoundFactoryType;
                    /*{
                        foreach (RoundFactory.Type type in System.Enum.GetValues(typeof(RoundFactory.Type)))
                        {
                            this.roundFactoryType.v.options.add(type.ToString());
                        }
                    }*/
                }
                this.roundFactoryUI = new VP<RoundFactoryUI>(this, (byte)Property.roundFactoryUI, null);
                // newRoundLimitType
                {
                    this.newRoundLimitType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.newRoundLimitType, new RequestChangeEnumUI.UIData());
                    // event
                    this.newRoundLimitType.v.updateData.v.request.v = makeRequestChangeNewRoundLimitType;
                    {
                        foreach (RequestNewRound.Limit.Type type in System.Enum.GetValues(typeof(RequestNewRound.Limit.Type)))
                        {
                            this.newRoundLimitType.v.options.add(type.ToString());
                        }
                    }
                }
                this.newRoundLimitUI = new VP<NewRoundLimitUI>(this, (byte)Property.newRoundLimitUI, null);
                // calculateScoreType
                {
                    this.calculateScoreType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.calculateScoreType, new RequestChangeEnumUI.UIData());
                    // event
                    this.calculateScoreType.v.updateData.v.request.v = makeRequestChangeCalculateScoreType;
                    {
                        foreach (CalculateScore.Type type in System.Enum.GetValues(typeof(CalculateScore.Type)))
                        {
                            this.calculateScoreType.v.options.add(type.ToString());
                        }
                    }
                }
                this.calculateScoreUI = new VP<CalculateScore.UIData>(this, (byte)Property.calculateScoreUI, null);
            }

            #endregion

            public override ContestManagerContent.Type getType()
            {
                return ContestManagerContent.Type.Single;
            }

            public override bool processEvent(Event e)
            {
                Debug.LogError("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    // newRoundLimitUI
                    if (!isProcess)
                    {
                        NewRoundLimitUI newRoundLimitUIData = this.newRoundLimitUI.v;
                        if (newRoundLimitUIData != null)
                        {
                            isProcess = newRoundLimitUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("newRoundLimitUIData null: " + this);
                        }
                    }
                    // roundFactoryUI
                    if (!isProcess)
                    {
                        RoundFactoryUI roundFactoryUI = this.roundFactoryUI.v;
                        if (roundFactoryUI != null)
                        {
                            isProcess = roundFactoryUI.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("roundFactoryUI null: " + this);
                        }
                    }
                }
                return isProcess;
            }

            #region implement base

            public EditData<SingleContestFactory> getEditData()
            {
                return this.editSingleContestFactory.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Match Factory");

        public Text lbPlayerPerTeam;
        private static readonly TxtLanguage txtPlayerPerTeam = new TxtLanguage("Player per team");

        public Text lbRoundFactoryType;
        private static readonly TxtLanguage txtRoundFactoryType = new TxtLanguage("Round factory type");

        public Text lbNewRoundLimitType;
        private static readonly TxtLanguage txtNewRoundLimitType = new TxtLanguage("New round limit type");

        public Text lbCalculateScoreType;
        private static readonly TxtLanguage txtCalculateScoreType = new TxtLanguage("Calculate score type");

        static SingleContestFactoryUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Tạo Trận Đấu");
                txtPlayerPerTeam.add(Language.Type.vi, "Số người chơi mỗi đội");
                txtRoundFactoryType.add(Language.Type.vi, "Loại tạo vòng đấu");
                txtNewRoundLimitType.add(Language.Type.vi, "Loại giới hạn số vòng");
                txtCalculateScoreType.add(Language.Type.vi, "Loại tính điểm");
            }
            // rect
            {

            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public Image bgRoundFactory;
        public Image bgNewRoundLimit;
        public Image bgCalculateScore;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<SingleContestFactory> editSingleContestFactory = this.data.editSingleContestFactory.v;
                    if (editSingleContestFactory != null)
                    {
                        editSingleContestFactory.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editSingleContestFactory);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editSingleContestFactory);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.playerPerTeam.v, editSingleContestFactory, serverState, needReset, editData => editData.playerPerTeam.v);
                                    RequestChange.RefreshUI(this.data.roundFactoryType.v, editSingleContestFactory, serverState, needReset, editData => (int)editData.getRoundFactoryType());
                                    // roundFactoryUI
                                    {
                                        SingleContestFactory show = editSingleContestFactory.show.v.data;
                                        SingleContestFactory compare = editSingleContestFactory.compare.v.data;
                                        if (show != null)
                                        {
                                            RoundFactory roundFactory = show.roundFactory.v;
                                            if (roundFactory != null)
                                            {
                                                // find origin 
                                                RoundFactory originRoundFactory = null;
                                                {
                                                    SingleContestFactory originSingleContestFactory = editSingleContestFactory.origin.v.data;
                                                    if (originSingleContestFactory != null)
                                                    {
                                                        originRoundFactory = originSingleContestFactory.roundFactory.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("origin null: " + this);
                                                    }
                                                }
                                                // find compare
                                                RoundFactory compareRoundFactory = null;
                                                {
                                                    if (compare != null)
                                                    {
                                                        compareRoundFactory = compare.roundFactory.v;
                                                    }
                                                    else
                                                    {
                                                        // Debug.LogError ("compare null: " + this);
                                                    }
                                                }
                                                switch (roundFactory.getType())
                                                {
                                                    case RoundFactory.Type.Normal:
                                                        {
                                                            NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                                            // UIData
                                                            NormalRoundFactoryUI.UIData normalRoundFactoryUIData = this.data.roundFactoryUI.newOrOld<NormalRoundFactoryUI.UIData>();
                                                            {
                                                                EditData<NormalRoundFactory> editNormalRoundFactory = normalRoundFactoryUIData.editNormalRoundFactory.v;
                                                                if (editNormalRoundFactory != null)
                                                                {
                                                                    // origin
                                                                    editNormalRoundFactory.origin.v = new ReferenceData<NormalRoundFactory>((NormalRoundFactory)originRoundFactory);
                                                                    // show
                                                                    editNormalRoundFactory.show.v = new ReferenceData<NormalRoundFactory>(normalRoundFactory);
                                                                    // compare
                                                                    editNormalRoundFactory.compare.v = new ReferenceData<NormalRoundFactory>((NormalRoundFactory)compareRoundFactory);
                                                                    // compareOtherType
                                                                    editNormalRoundFactory.compareOtherType.v = new ReferenceData<Data>(compareRoundFactory);
                                                                    // canEdit
                                                                    editNormalRoundFactory.canEdit.v = editSingleContestFactory.canEdit.v;
                                                                    // editType
                                                                    editNormalRoundFactory.editType.v = editSingleContestFactory.editType.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("editNormalRoundFactory null: " + this);
                                                                }
                                                            }
                                                            this.data.roundFactoryUI.v = normalRoundFactoryUIData;
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("show null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("show null");
                                        }
                                    }
                                    // newRoundLimitType
                                    {
                                        RequestChangeEnumUI.RefreshOptions(this.data.newRoundLimitType.v, RequestNewRound.Limit.getStrTypes());
                                        RequestChange.RefreshUI(this.data.newRoundLimitType.v, editSingleContestFactory, serverState, needReset, editData => (int)editData.getNewRoundLimitType());
                                    }
                                    // newRoundLimitUI
                                    {
                                        SingleContestFactory show = editSingleContestFactory.show.v.data;
                                        SingleContestFactory compare = editSingleContestFactory.compare.v.data;
                                        if (show != null)
                                        {
                                            RequestNewRound.Limit newRoundLimit = show.newRoundLimit.v;
                                            if (newRoundLimit != null)
                                            {
                                                // find origin 
                                                RequestNewRound.Limit originNewRoundLimit = null;
                                                {
                                                    SingleContestFactory originSingleContestFactory = editSingleContestFactory.origin.v.data;
                                                    if (originSingleContestFactory != null)
                                                    {
                                                        originNewRoundLimit = originSingleContestFactory.newRoundLimit.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("origin null: " + this);
                                                    }
                                                }
                                                // find compare
                                                RequestNewRound.Limit compareNewRoundLimit = null;
                                                {
                                                    if (compare != null)
                                                    {
                                                        compareNewRoundLimit = compare.newRoundLimit.v;
                                                    }
                                                    else
                                                    {
                                                        // Debug.LogError ("compare null: " + this);
                                                    }
                                                }
                                                switch (newRoundLimit.getType())
                                                {
                                                    case RequestNewRound.Limit.Type.NoLimit:
                                                        {
                                                            RequestNewRoundNoLimit newRoundNoLimit = newRoundLimit as RequestNewRoundNoLimit;
                                                            // UIData
                                                            RequestNewRoundNoLimitUI.UIData newRoundNoLimitUIData = this.data.newRoundLimitUI.newOrOld<RequestNewRoundNoLimitUI.UIData>();
                                                            {
                                                                EditData<RequestNewRoundNoLimit> editNoLimit = newRoundNoLimitUIData.editNoLimit.v;
                                                                if (editNoLimit != null)
                                                                {
                                                                    // origin
                                                                    editNoLimit.origin.v = new ReferenceData<RequestNewRoundNoLimit>((RequestNewRoundNoLimit)originNewRoundLimit);
                                                                    // show
                                                                    editNoLimit.show.v = new ReferenceData<RequestNewRoundNoLimit>(newRoundNoLimit);
                                                                    // compare
                                                                    editNoLimit.compare.v = new ReferenceData<RequestNewRoundNoLimit>((RequestNewRoundNoLimit)compareNewRoundLimit);
                                                                    // compareOtherType
                                                                    editNoLimit.compareOtherType.v = new ReferenceData<Data>(compareNewRoundLimit);
                                                                    // canEdit
                                                                    editNoLimit.canEdit.v = editSingleContestFactory.canEdit.v;
                                                                    // editType
                                                                    editNoLimit.editType.v = editSingleContestFactory.editType.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("editNoLimit null: " + this);
                                                                }
                                                                newRoundNoLimitUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                            }
                                                            this.data.newRoundLimitUI.v = newRoundNoLimitUIData;
                                                        }
                                                        break;
                                                    case RequestNewRound.Limit.Type.HaveLimit:
                                                        {
                                                            RequestNewRoundHaveLimit newRoundHaveLimit = newRoundLimit as RequestNewRoundHaveLimit;
                                                            // UIData
                                                            RequestNewRoundHaveLimitUI.UIData newRoundHaveLimitUIData = this.data.newRoundLimitUI.newOrOld<RequestNewRoundHaveLimitUI.UIData>();
                                                            {
                                                                EditData<RequestNewRoundHaveLimit> editHaveLimit = newRoundHaveLimitUIData.editHaveLimit.v;
                                                                if (editHaveLimit != null)
                                                                {
                                                                    // origin
                                                                    editHaveLimit.origin.v = new ReferenceData<RequestNewRoundHaveLimit>((RequestNewRoundHaveLimit)originNewRoundLimit);
                                                                    // show
                                                                    editHaveLimit.show.v = new ReferenceData<RequestNewRoundHaveLimit>(newRoundHaveLimit);
                                                                    // compare
                                                                    editHaveLimit.compare.v = new ReferenceData<RequestNewRoundHaveLimit>((RequestNewRoundHaveLimit)compareNewRoundLimit);
                                                                    // compareOtherType
                                                                    editHaveLimit.compareOtherType.v = new ReferenceData<Data>(compareNewRoundLimit);
                                                                    // canEdit
                                                                    editHaveLimit.canEdit.v = editSingleContestFactory.canEdit.v;
                                                                    // editType
                                                                    editHaveLimit.editType.v = editSingleContestFactory.editType.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("editHaveLimit null: " + this);
                                                                }
                                                                newRoundHaveLimitUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                            }
                                                            this.data.newRoundLimitUI.v = newRoundHaveLimitUIData;
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + newRoundLimit.getType() + "; " + this);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("show null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("show null");
                                        }
                                    }
                                    // calculateScoreType
                                    {
                                        RequestChangeEnumUI.RefreshOptions(this.data.calculateScoreType.v, CalculateScore.getStrTypes());
                                        RequestChange.RefreshUI(this.data.calculateScoreType.v, editSingleContestFactory, serverState, needReset, editData => (int)editData.getCalculateScoreType());
                                    }
                                    // calculateScoreUI
                                    {
                                        SingleContestFactory show = editSingleContestFactory.show.v.data;
                                        SingleContestFactory compare = editSingleContestFactory.compare.v.data;
                                        if (show != null)
                                        {
                                            CalculateScore calculateScore = show.calculateScore.v;
                                            if (calculateScore != null)
                                            {
                                                // find origin 
                                                CalculateScore originCalculateScore = null;
                                                {
                                                    SingleContestFactory originSingleContestFactory = editSingleContestFactory.origin.v.data;
                                                    if (originSingleContestFactory != null)
                                                    {
                                                        originCalculateScore = originSingleContestFactory.calculateScore.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("origin null: " + this);
                                                    }
                                                }
                                                // find compare
                                                CalculateScore compareCalculateScore = null;
                                                {
                                                    if (compare != null)
                                                    {
                                                        compareCalculateScore = compare.calculateScore.v;
                                                    }
                                                    else
                                                    {
                                                        // Debug.LogError ("compare null: " + this);
                                                    }
                                                }
                                                switch (calculateScore.getType())
                                                {
                                                    case CalculateScore.Type.Sum:
                                                        {
                                                            CalculateScoreSum calculateScoreSum = calculateScore as CalculateScoreSum;
                                                            // UIData
                                                            CalculateScoreSumUI.UIData calculateScoreSumUIData = this.data.calculateScoreUI.newOrOld<CalculateScoreSumUI.UIData>();
                                                            {
                                                                EditData<CalculateScoreSum> editCalculateScoreSum = calculateScoreSumUIData.editCalculateScoreSum.v;
                                                                if (editCalculateScoreSum != null)
                                                                {
                                                                    // origin
                                                                    editCalculateScoreSum.origin.v = new ReferenceData<CalculateScoreSum>((CalculateScoreSum)originCalculateScore);
                                                                    // show
                                                                    editCalculateScoreSum.show.v = new ReferenceData<CalculateScoreSum>(calculateScoreSum);
                                                                    // compare
                                                                    editCalculateScoreSum.compare.v = new ReferenceData<CalculateScoreSum>((CalculateScoreSum)compareCalculateScore);
                                                                    // compareOtherType
                                                                    editCalculateScoreSum.compareOtherType.v = new ReferenceData<Data>(compareCalculateScore);
                                                                    // canEdit
                                                                    editCalculateScoreSum.canEdit.v = editSingleContestFactory.canEdit.v;
                                                                    // editType
                                                                    editCalculateScoreSum.editType.v = editSingleContestFactory.editType.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("editCalculateScoreSum null: " + this);
                                                                }
                                                                calculateScoreSumUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                            }
                                                            this.data.calculateScoreUI.v = calculateScoreSumUIData;
                                                        }
                                                        break;
                                                    case CalculateScore.Type.WinLoseDraw:
                                                        {
                                                            CalculateScoreWinLoseDraw calculateScoreWinLoseDraw = calculateScore as CalculateScoreWinLoseDraw;
                                                            // UIData
                                                            CalculateScoreWinLoseDrawUI.UIData calculateScoreWinLoseDrawUIData = this.data.calculateScoreUI.newOrOld<CalculateScoreWinLoseDrawUI.UIData>();
                                                            {
                                                                EditData<CalculateScoreWinLoseDraw> editCalculateScoreWinLoseDraw = calculateScoreWinLoseDrawUIData.editCalculateScoreWinLoseDraw.v;
                                                                if (editCalculateScoreWinLoseDraw != null)
                                                                {
                                                                    // origin
                                                                    editCalculateScoreWinLoseDraw.origin.v = new ReferenceData<CalculateScoreWinLoseDraw>((CalculateScoreWinLoseDraw)originCalculateScore);
                                                                    // show
                                                                    editCalculateScoreWinLoseDraw.show.v = new ReferenceData<CalculateScoreWinLoseDraw>(calculateScoreWinLoseDraw);
                                                                    // compare
                                                                    editCalculateScoreWinLoseDraw.compare.v = new ReferenceData<CalculateScoreWinLoseDraw>((CalculateScoreWinLoseDraw)compareCalculateScore);
                                                                    // compareOtherType
                                                                    editCalculateScoreWinLoseDraw.compareOtherType.v = new ReferenceData<Data>(compareCalculateScore);
                                                                    // canEdit
                                                                    editCalculateScoreWinLoseDraw.canEdit.v = editSingleContestFactory.canEdit.v;
                                                                    // editType
                                                                    editCalculateScoreWinLoseDraw.editType.v = editSingleContestFactory.editType.v;
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("editCalculateScoreWinLoseDraw null: " + this);
                                                                }
                                                                calculateScoreWinLoseDrawUIData.showType.v = UIRectTransform.ShowType.HeadLess;
                                                            }
                                                            this.data.calculateScoreUI.v = calculateScoreWinLoseDrawUIData;
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + calculateScore.getType() + "; " + this);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("show null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("show null");
                                        }
                                    }
                                }
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editSingleContestFactory null: " + this);
                    }
                    // UISize
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // playerPerTeam
                        UIUtils.SetLabelContentPosition(lbPlayerPerTeam, this.data.playerPerTeam.v, ref deltaY);
                        // roundFactory
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // type
                            {
                                if (this.data.roundFactoryType.v != null)
                                {
                                    if (lbRoundFactoryType != null)
                                    {
                                        lbRoundFactoryType.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY((RectTransform)lbRoundFactoryType.transform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbRoundFactoryType null");
                                    }
                                    UIRectTransform.SetPosY(this.data.roundFactoryType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                    bgHeight += UIConstants.ItemHeight;
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbRoundFactoryType != null)
                                    {
                                        lbRoundFactoryType.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbRoundFactoryType null");
                                    }
                                }
                            }
                            // UI
                            {
                                float roundFactoryHeight = UIRectTransform.SetPosY(this.data.roundFactoryUI.v, deltaY);
                                bgHeight += roundFactoryHeight;
                                deltaY += roundFactoryHeight;
                            }
                            // bg
                            if (bgRoundFactory != null)
                            {
                                UIRectTransform.SetPosY(bgRoundFactory.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgRoundFactory.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgRoundFactory null");
                            }
                        }
                        // newRoundLimit
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // type
                            {
                                if (this.data.newRoundLimitType.v != null)
                                {
                                    if (lbNewRoundLimitType != null)
                                    {
                                        lbNewRoundLimitType.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY((RectTransform)lbNewRoundLimitType.transform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbNewRoundLimitType null");
                                    }
                                    UIRectTransform.SetPosY(this.data.newRoundLimitType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                    bgHeight += UIConstants.ItemHeight;
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbNewRoundLimitType != null)
                                    {
                                        lbNewRoundLimitType.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbNewRoundLimitType null");
                                    }
                                }
                            }
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.newRoundLimitUI.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgNewRoundLimit != null)
                            {
                                UIRectTransform.SetPosY(bgNewRoundLimit.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgNewRoundLimit.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgNewRoundLimit null");
                            }
                        }
                        // calculateScore
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // type
                            {
                                if (this.data.calculateScoreType.v != null)
                                {
                                    if (lbCalculateScoreType != null)
                                    {
                                        UIRectTransform.SetPosY((RectTransform)lbCalculateScoreType.transform, deltaY);
                                        lbCalculateScoreType.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbCalculateScoreType null");
                                    }
                                    UIRectTransform.SetPosY(this.data.calculateScoreType.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
                                    bgHeight += UIConstants.ItemHeight;
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbCalculateScoreType != null)
                                    {
                                        lbCalculateScoreType.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbCalculateScoreType null");
                                    }
                                }
                            }
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.calculateScoreUI.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgCalculateScore != null)
                            {
                                UIRectTransform.SetPosY(bgCalculateScore.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgCalculateScore.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgCalculateScore null");
                            }
                        }
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbPlayerPerTeam != null)
                        {
                            lbPlayerPerTeam.text = txtPlayerPerTeam.get();
                            Setting.get().setLabelTextSize(lbPlayerPerTeam);
                        }
                        else
                        {
                            Debug.LogError("lbPlayerPerTeam null: " + this);
                        }
                        if (lbRoundFactoryType != null)
                        {
                            lbRoundFactoryType.text = txtRoundFactoryType.get();
                            Setting.get().setLabelTextSize(lbRoundFactoryType);
                        }
                        else
                        {
                            Debug.LogError("lbRoundFactoryType null: " + this);
                        }
                        if (lbNewRoundLimitType != null)
                        {
                            lbNewRoundLimitType.text = txtNewRoundLimitType.get();
                            Setting.get().setLabelTextSize(lbNewRoundLimitType);
                        }
                        else
                        {
                            Debug.LogError("lbNewRoundLimitType null: " + this);
                        }
                        if (lbCalculateScoreType != null)
                        {
                            lbCalculateScoreType.text = txtCalculateScoreType.get();
                            Setting.get().setLabelTextSize(lbCalculateScoreType);
                        }
                        else
                        {
                            Debug.LogError("lbCalculateScoreType null: " + this);
                        }
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

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeEnumUI requestEnumPrefab;

        public NormalRoundFactoryUI normalRoundFactoryPrefab;

        public RequestNewRoundNoLimitUI requestNewRoundNoLimitPrefab;
        public RequestNewRoundHaveLimitUI requestNewRoundHaveLimitPrefab;

        public CalculateScoreSumUI calculateScoreSumPrefab;
        public CalculateScoreWinLoseDrawUI calculateScoreWinLoseDrawPrefab;

        private static readonly UIRectTransform playerPerTeamRect = new UIRectTransform(UIConstants.RequestRect);

        private static readonly UIRectTransform roundFactoryTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

        private static readonly UIRectTransform newRoundLimitTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

        private static readonly UIRectTransform calculateScoreTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editSingleContestFactory.allAddCallBack(this);
                    uiData.playerPerTeam.allAddCallBack(this);
                    // roundFactory
                    {
                        uiData.roundFactoryType.allAddCallBack(this);
                        uiData.roundFactoryUI.allAddCallBack(this);
                    }
                    // requestNewRoundLimit
                    {
                        uiData.newRoundLimitType.allAddCallBack(this);
                        uiData.newRoundLimitUI.allAddCallBack(this);
                    }
                    // calculateScore
                    {
                        uiData.calculateScoreType.allAddCallBack(this);
                        uiData.calculateScoreUI.allAddCallBack(this);
                    }
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
                // editSingleContestFactory
                {
                    if (data is EditData<SingleContestFactory>)
                    {
                        EditData<SingleContestFactory> editSingleContestFactory = data as EditData<SingleContestFactory>;
                        // Child
                        {
                            editSingleContestFactory.show.allAddCallBack(this);
                            editSingleContestFactory.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is SingleContestFactory)
                        {
                            SingleContestFactory singleContestFactory = data as SingleContestFactory;
                            // Parent
                            {
                                DataUtils.addParentCallBack(singleContestFactory, this, ref this.server);
                            }
                            needReset = true;
                            dirty = true;
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                dirty = true;
                                return;
                            }
                        }
                    }
                }
                // playerPerTeam
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.playerPerTeam:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, playerPerTeamRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                // roundFactoryType, newRoundLimitType, calculateScoreType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.roundFactoryType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, roundFactoryTypeRect);
                                    break;
                                case UIData.Property.newRoundLimitType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, newRoundLimitTypeRect);
                                    break;
                                case UIData.Property.calculateScoreType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, calculateScoreTypeRect);
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("wrapProperty null: " + this);
                        }
                    }
                    dirty = true;
                    return;
                }
                // roundFactoryUI
                if (data is UIData.RoundFactoryUI)
                {
                    UIData.RoundFactoryUI roundFactoryUI = data as UIData.RoundFactoryUI;
                    {
                        switch (roundFactoryUI.getType())
                        {
                            case RoundFactory.Type.Normal:
                                {
                                    NormalRoundFactoryUI.UIData normalRoundFactoryUIData = roundFactoryUI as NormalRoundFactoryUI.UIData;
                                    UIUtils.Instantiate(normalRoundFactoryUIData, normalRoundFactoryPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactoryUI.getType() + "; " + this);
                                break;
                        }
                    }
                    // Child
                    {
                        TransformData.AddCallBack(roundFactoryUI, this);
                    }
                    dirty = true;
                    return;
                }
                // newRoundLimitUI
                if (data is UIData.NewRoundLimitUI)
                {
                    UIData.NewRoundLimitUI newRoundLimitUI = data as UIData.NewRoundLimitUI;
                    // UI
                    {
                        switch (newRoundLimitUI.getType())
                        {
                            case RequestNewRound.Limit.Type.NoLimit:
                                {
                                    RequestNewRoundNoLimitUI.UIData noLimitUIData = newRoundLimitUI as RequestNewRoundNoLimitUI.UIData;
                                    UIUtils.Instantiate(noLimitUIData, requestNewRoundNoLimitPrefab, this.transform);
                                }
                                break;
                            case RequestNewRound.Limit.Type.HaveLimit:
                                {
                                    RequestNewRoundHaveLimitUI.UIData haveLimitUIData = newRoundLimitUI as RequestNewRoundHaveLimitUI.UIData;
                                    UIUtils.Instantiate(haveLimitUIData, requestNewRoundHaveLimitPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + newRoundLimitUI.getType() + "; " + this);
                                break;
                        }
                    }
                    // Child
                    {
                        TransformData.AddCallBack(newRoundLimitUI, this);
                    }
                    dirty = true;
                    return;
                }
                // calculateScoreUI
                if (data is CalculateScore.UIData)
                {
                    CalculateScore.UIData calculateScoreUIData = data as CalculateScore.UIData;
                    // UI
                    {
                        switch (calculateScoreUIData.getType())
                        {
                            case CalculateScore.Type.Sum:
                                {
                                    CalculateScoreSumUI.UIData calculateScoreSumUIData = calculateScoreUIData as CalculateScoreSumUI.UIData;
                                    UIUtils.Instantiate(calculateScoreSumUIData, calculateScoreSumPrefab, this.transform);
                                }
                                break;
                            case CalculateScore.Type.WinLoseDraw:
                                {
                                    CalculateScoreWinLoseDrawUI.UIData calculateScoreWinLoseDrawUIData = calculateScoreUIData as CalculateScoreWinLoseDrawUI.UIData;
                                    UIUtils.Instantiate(calculateScoreWinLoseDrawUIData, calculateScoreWinLoseDrawPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + calculateScoreUIData.getType() + "; " + this);
                                break;
                        }
                    }
                    // Child
                    {
                        TransformData.AddCallBack(calculateScoreUIData, this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is TransformData)
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
                    uiData.editSingleContestFactory.allRemoveCallBack(this);
                    uiData.playerPerTeam.allRemoveCallBack(this);
                    // roundFactory
                    {
                        uiData.roundFactoryType.allRemoveCallBack(this);
                        uiData.roundFactoryUI.allRemoveCallBack(this);
                    }
                    // requestNewRoundLimit
                    {
                        uiData.newRoundLimitType.allRemoveCallBack(this);
                        uiData.newRoundLimitUI.allRemoveCallBack(this);
                    }
                    // calculateScore
                    {
                        uiData.calculateScoreType.allRemoveCallBack(this);
                        uiData.calculateScoreUI.allRemoveCallBack(this);
                    }
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
                // editSingleContestFactory
                {
                    if (data is EditData<SingleContestFactory>)
                    {
                        EditData<SingleContestFactory> editSingleContestFactory = data as EditData<SingleContestFactory>;
                        // Child
                        {
                            editSingleContestFactory.show.allRemoveCallBack(this);
                            editSingleContestFactory.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is SingleContestFactory)
                        {
                            SingleContestFactory singleContestFactory = data as SingleContestFactory;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(singleContestFactory, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
                        {
                            if (data is Server)
                            {
                                return;
                            }
                        }
                    }
                }
                // playerPerTeam
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                // roundFactoryType, newRoundLimitType, calculateScoreType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                // roundFactoryUI
                if (data is UIData.RoundFactoryUI)
                {
                    UIData.RoundFactoryUI roundFactoryUI = data as UIData.RoundFactoryUI;
                    // Child
                    {
                        TransformData.RemoveCallBack(roundFactoryUI, this);
                    }
                    // UI
                    {
                        switch (roundFactoryUI.getType())
                        {
                            case RoundFactory.Type.Normal:
                                {
                                    NormalRoundFactoryUI.UIData normalRoundFactoryUIData = roundFactoryUI as NormalRoundFactoryUI.UIData;
                                    normalRoundFactoryUIData.removeCallBackAndDestroy(typeof(NormalRoundFactoryUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactoryUI.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // newRoundLimitUI
                if (data is UIData.NewRoundLimitUI)
                {
                    UIData.NewRoundLimitUI newRoundLimitUI = data as UIData.NewRoundLimitUI;
                    // Child
                    {
                        TransformData.RemoveCallBack(newRoundLimitUI, this);
                    }
                    // UI
                    {
                        switch (newRoundLimitUI.getType())
                        {
                            case RequestNewRound.Limit.Type.NoLimit:
                                {
                                    RequestNewRoundNoLimitUI.UIData noLimitUIData = newRoundLimitUI as RequestNewRoundNoLimitUI.UIData;
                                    noLimitUIData.removeCallBackAndDestroy(typeof(RequestNewRoundNoLimitUI));
                                }
                                break;
                            case RequestNewRound.Limit.Type.HaveLimit:
                                {
                                    RequestNewRoundHaveLimitUI.UIData haveLimitUIData = newRoundLimitUI as RequestNewRoundHaveLimitUI.UIData;
                                    haveLimitUIData.removeCallBackAndDestroy(typeof(RequestNewRoundHaveLimitUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + newRoundLimitUI.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // calculateScoreUI
                if (data is CalculateScore.UIData)
                {
                    CalculateScore.UIData calculateScoreUIData = data as CalculateScore.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(calculateScoreUIData, this);
                    }
                    // UI
                    {
                        switch (calculateScoreUIData.getType())
                        {
                            case CalculateScore.Type.Sum:
                                {
                                    CalculateScoreSumUI.UIData calculateScoreSumUIData = calculateScoreUIData as CalculateScoreSumUI.UIData;
                                    calculateScoreSumUIData.removeCallBackAndDestroy(typeof(CalculateScoreSumUI));
                                }
                                break;
                            case CalculateScore.Type.WinLoseDraw:
                                {
                                    CalculateScoreWinLoseDrawUI.UIData calculateScoreWinLoseDrawUIData = calculateScoreUIData as CalculateScoreWinLoseDrawUI.UIData;
                                    calculateScoreWinLoseDrawUIData.removeCallBackAndDestroy(typeof(CalculateScoreWinLoseDrawUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + calculateScoreUIData.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
                // Child
                if (data is TransformData)
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
                    case UIData.Property.editSingleContestFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.playerPerTeam:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundFactoryType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.roundFactoryUI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.newRoundLimitType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.newRoundLimitUI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.calculateScoreType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.calculateScoreUI:
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
                    case Setting.Property.contentTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.titleTextSize:
                        dirty = true;
                        break;
                    case Setting.Property.labelTextSize:
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
                // editSingleContestFactory
                {
                    if (wrapProperty.p is EditData<SingleContestFactory>)
                    {
                        switch ((EditData<SingleContestFactory>.Property)wrapProperty.n)
                        {
                            case EditData<SingleContestFactory>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<SingleContestFactory>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<SingleContestFactory>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<SingleContestFactory>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<SingleContestFactory>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<SingleContestFactory>.Property.editType:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is SingleContestFactory)
                        {
                            switch ((SingleContestFactory.Property)wrapProperty.n)
                            {
                                case SingleContestFactory.Property.playerPerTeam:
                                    dirty = true;
                                    break;
                                case SingleContestFactory.Property.roundFactory:
                                    dirty = true;
                                    break;
                                case SingleContestFactory.Property.newRoundLimit:
                                    dirty = true;
                                    break;
                                case SingleContestFactory.Property.calculateScore:
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
                            if (wrapProperty.p is Server)
                            {
                                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                                return;
                            }
                        }
                    }
                }
                // playerPerTeam
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                // roundFactoryType, newRoundLimit, calculateScoreType
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // roundFactoryUI
                if (wrapProperty.p is UIData.RoundFactoryUI)
                {
                    return;
                }
                // newRoundLimitUI
                if (wrapProperty.p is UIData.NewRoundLimitUI)
                {
                    return;
                }
                // calculateScoreUI
                if (wrapProperty.p is CalculateScore.UIData)
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
                            Debug.LogError("Don't process: " + wrapProperty + ", " + this);
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