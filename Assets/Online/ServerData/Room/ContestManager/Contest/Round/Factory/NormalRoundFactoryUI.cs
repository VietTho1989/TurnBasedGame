﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class NormalRoundFactoryUI : UIHaveTransformDataBehavior<NormalRoundFactoryUI.UIData>
    {

        #region UIData

        public class UIData : SingleContestFactoryUI.UIData.RoundFactoryUI, EditDataUI.UIData<NormalRoundFactory>
        {

            public VP<EditData<NormalRoundFactory>> editNormalRoundFactory;

            #region gameFactory

            public VP<GameFactoryUI.UIData> gameFactory;

            #endregion

            #region isChangeSideBetweenRound

            public VP<RequestChangeBoolUI.UIData> isChangeSideBetweenRound;

            public void makeRequestChangeIsChangeSideBetweenRound(RequestChangeUpdate<bool>.UpdateData update, bool newIsChangeSideBetweenRound)
            {
                // Find
                NormalRoundFactory normalRoundFactory = null;
                {
                    EditData<NormalRoundFactory> editNormalRoundFactory = this.editNormalRoundFactory.v;
                    if (editNormalRoundFactory != null)
                    {
                        normalRoundFactory = editNormalRoundFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNormalRoundFactory null: " + this);
                    }
                }
                // Process
                if (normalRoundFactory != null)
                {
                    normalRoundFactory.requestChangeIsChangeSideBetweenRound(Server.getProfileUserId(normalRoundFactory), newIsChangeSideBetweenRound);
                }
                else
                {
                    Debug.LogError("normalRoundFactory null: " + this);
                }
            }

            #endregion

            #region isSwitchPlayer

            public VP<RequestChangeBoolUI.UIData> isSwitchPlayer;

            public void makeRequestChangeIsSwitchPlayer(RequestChangeUpdate<bool>.UpdateData update, bool newIsSwitchPlayer)
            {
                // Find
                NormalRoundFactory normalRoundFactory = null;
                {
                    EditData<NormalRoundFactory> editNormalRoundFactory = this.editNormalRoundFactory.v;
                    if (editNormalRoundFactory != null)
                    {
                        normalRoundFactory = editNormalRoundFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNormalRoundFactory null: " + this);
                    }
                }
                // Process
                if (normalRoundFactory != null)
                {
                    normalRoundFactory.requestChangeIsSwitchPlayer(Server.getProfileUserId(normalRoundFactory), newIsSwitchPlayer);
                }
                else
                {
                    Debug.LogError("normalRoundFactory null: " + this);
                }
            }

            #endregion

            #region isDifferentInTeam

            public VP<RequestChangeBoolUI.UIData> isDifferentInTeam;

            public void makeRequestChangeIsDifferentInTeam(RequestChangeUpdate<bool>.UpdateData update, bool newIsDifferentInTeam)
            {
                // Find
                NormalRoundFactory normalRoundFactory = null;
                {
                    EditData<NormalRoundFactory> editNormalRoundFactory = this.editNormalRoundFactory.v;
                    if (editNormalRoundFactory != null)
                    {
                        normalRoundFactory = editNormalRoundFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNormalRoundFactory null: " + this);
                    }
                }
                // Process
                if (normalRoundFactory != null)
                {
                    normalRoundFactory.requestChangeIsDifferentInTeam(Server.getProfileUserId(normalRoundFactory), newIsDifferentInTeam);
                }
                else
                {
                    Debug.LogError("normalRoundFactory null: " + this);
                }
            }

            #endregion

            #region calculateScore

            public VP<RequestChangeEnumUI.UIData> calculateScoreType;

            public void makeRequestChangeCalculateScoreType(RequestChangeUpdate<int>.UpdateData update, int newCalculateScoreType)
            {
                // Find
                NormalRoundFactory normalRoundFactory = null;
                {
                    EditData<NormalRoundFactory> editNormalRoundFactory = this.editNormalRoundFactory.v;
                    if (editNormalRoundFactory != null)
                    {
                        normalRoundFactory = editNormalRoundFactory.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNormalRoundFactory null: " + this);
                    }
                }
                // Process
                if (normalRoundFactory != null)
                {
                    normalRoundFactory.requestChangeCalculateScoreType(Server.getProfileUserId(normalRoundFactory), newCalculateScoreType);
                }
                else
                {
                    Debug.LogError("normalRoundFactory null: " + this);
                }
            }

            public VP<CalculateScore.UIData> calculateScoreUI;

            #endregion

            #region Constructor

            public enum Property
            {
                editNormalRoundFactory,
                gameFactory,
                isChangeSideBetweenRound,
                isSwitchPlayer,
                isDifferentInTeam,

                calculateScoreType,
                calculateScoreUI
            }

            public UIData() : base()
            {
                this.editNormalRoundFactory = new VP<EditData<NormalRoundFactory>>(this, (byte)Property.editNormalRoundFactory, new EditData<NormalRoundFactory>());
                this.gameFactory = new VP<GameFactoryUI.UIData>(this, (byte)Property.gameFactory, new GameFactoryUI.UIData());
                // isChangeSideBetweenRound
                {
                    this.isChangeSideBetweenRound = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.isChangeSideBetweenRound, new RequestChangeBoolUI.UIData());
                    this.isChangeSideBetweenRound.v.updateData.v.request.v = makeRequestChangeIsChangeSideBetweenRound;
                }
                // isSwitchPlayer
                {
                    this.isSwitchPlayer = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.isSwitchPlayer, new RequestChangeBoolUI.UIData());
                    this.isSwitchPlayer.v.updateData.v.request.v = makeRequestChangeIsSwitchPlayer;
                }
                // isDifferentInTeam
                {
                    this.isDifferentInTeam = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.isDifferentInTeam, new RequestChangeBoolUI.UIData());
                    this.isDifferentInTeam.v.updateData.v.request.v = makeRequestChangeIsDifferentInTeam;
                }
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

            public override RoundFactory.Type getType()
            {
                return RoundFactory.Type.Normal;
            }

            public override bool processEvent(Event e)
            {
                Debug.LogError("processEvent: " + e + "; " + this);
                bool isProcess = false;
                {
                    // gameFactory
                    if (!isProcess)
                    {
                        GameFactoryUI.UIData gameFactoryUIData = this.gameFactory.v;
                        if (gameFactoryUIData != null)
                        {
                            isProcess = gameFactoryUIData.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("gameFactoryUIData null: " + this);
                        }
                    }
                }
                return isProcess;
            }

            #region implement interface

            public EditData<NormalRoundFactory> getEditData()
            {
                return this.editNormalRoundFactory.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Set Factory");

        public Text lbIsChangeSideBetweenRound;
        private static readonly TxtLanguage txtIsChangeSideBetweenRound = new TxtLanguage("Change side between round");

        public Text lbIsSwitchPlayer;
        private static readonly TxtLanguage txtIsSwitchPlayer = new TxtLanguage("Switch player");

        public Text lbIsDifferentInTeam;
        private static readonly TxtLanguage txtIsDifferentInTeam = new TxtLanguage("Different in team");

        public Text lbCalculateScoreType;
        private static readonly TxtLanguage txtCalculateScoreType = new TxtLanguage("Calculate score type");

        static NormalRoundFactoryUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cách Tạo Hiệp Đấu");
                txtIsChangeSideBetweenRound.add(Language.Type.vi, "Đổi bên giữa các hiệp");
                txtIsSwitchPlayer.add(Language.Type.vi, "Hoán đổi bên");
                txtIsDifferentInTeam.add(Language.Type.vi, "Đổi trong đội");
                txtCalculateScoreType.add(Language.Type.vi, "Loại tính điểm");
            }
            // rect
            {

            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public Image bgGameFactory;
        public Image bgCalculateScore;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<NormalRoundFactory> editNormalRoundFactory = this.data.editNormalRoundFactory.v;
                    if (editNormalRoundFactory != null)
                    {
                        editNormalRoundFactory.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editNormalRoundFactory);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editNormalRoundFactory);
                                // set origin
                                {
                                    EditDataUI.RefreshChildUI(this.data, this.data.gameFactory.v, editData => editData.gameFactory.v);
                                    RequestChange.RefreshUI(this.data.isChangeSideBetweenRound.v, editNormalRoundFactory, serverState, needReset, editData => editData.isChangeSideBetweenRound.v);
                                    RequestChange.RefreshUI(this.data.isSwitchPlayer.v, editNormalRoundFactory, serverState, needReset, editData => editData.isSwitchPlayer.v);
                                    RequestChange.RefreshUI(this.data.isDifferentInTeam.v, editNormalRoundFactory, serverState, needReset, editData => editData.isDifferentInTeam.v);
                                    // calculateScoreType
                                    {
                                        RequestChangeEnumUI.RefreshOptions(this.data.calculateScoreType.v, CalculateScore.getStrTypes());
                                        RequestChange.RefreshUI(this.data.calculateScoreType.v, editNormalRoundFactory, serverState, needReset, editData => (int)editData.getCalculateScoreType());
                                    }
                                    // calculateScoreUI
                                    {
                                        NormalRoundFactory show = editNormalRoundFactory.show.v.data;
                                        NormalRoundFactory compare = editNormalRoundFactory.compare.v.data;
                                        if (show != null)
                                        {
                                            CalculateScore calculateScore = show.calculateScore.v;
                                            if (calculateScore != null)
                                            {
                                                // find origin 
                                                CalculateScore originCalculateScore = null;
                                                {
                                                    NormalRoundFactory originNormalRoundFactory = editNormalRoundFactory.origin.v.data;
                                                    if (originNormalRoundFactory != null)
                                                    {
                                                        originCalculateScore = originNormalRoundFactory.calculateScore.v;
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
                                                                    editCalculateScoreSum.canEdit.v = editNormalRoundFactory.canEdit.v;
                                                                    // editType
                                                                    editCalculateScoreSum.editType.v = editNormalRoundFactory.editType.v;
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
                                                                    editCalculateScoreWinLoseDraw.canEdit.v = editNormalRoundFactory.canEdit.v;
                                                                    // editType
                                                                    editCalculateScoreWinLoseDraw.editType.v = editNormalRoundFactory.editType.v;
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
                                needReset = false;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editNormalRoundFactory null: " + this);
                    }
                    // UI Size
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                        // gameFactory
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.gameFactory.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgGameFactory != null)
                            {
                                UIRectTransform.SetPosY(bgGameFactory.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgGameFactory.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgGameFactory null");
                            }
                        }
                        // isChangeSideBetweenRound
                        UIUtils.SetLabelContentPosition(lbIsChangeSideBetweenRound, this.data.isChangeSideBetweenRound.v, ref deltaY);
                        // isSwitchPlayer
                        UIUtils.SetLabelContentPosition(lbIsSwitchPlayer, this.data.isSwitchPlayer.v, ref deltaY);
                        // isDifferentInTeam
                        UIUtils.SetLabelContentPosition(lbIsDifferentInTeam, this.data.isDifferentInTeam.v, ref deltaY);
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
                                        lbCalculateScoreType.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY((RectTransform)lbCalculateScoreType.transform, deltaY);
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
                        if (lbIsChangeSideBetweenRound != null)
                        {
                            lbIsChangeSideBetweenRound.text = txtIsChangeSideBetweenRound.get();
                            Setting.get().setLabelTextSize(lbIsChangeSideBetweenRound);
                        }
                        else
                        {
                            Debug.LogError("lbIsChangeSideBetweenRound null: " + this);
                        }
                        if (lbIsSwitchPlayer != null)
                        {
                            lbIsSwitchPlayer.text = txtIsSwitchPlayer.get();
                            Setting.get().setLabelTextSize(lbIsSwitchPlayer);
                        }
                        else
                        {
                            Debug.LogError("lbIsSwitchPlayer null: " + this);
                        }
                        if (lbIsDifferentInTeam != null)
                        {
                            lbIsDifferentInTeam.text = txtIsDifferentInTeam.get();
                            Setting.get().setLabelTextSize(lbIsDifferentInTeam);
                        }
                        else
                        {
                            Debug.LogError("lbIsDifferentInTeam null: " + this);
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
                    // Debug.LogError("data null: " + this);
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

        public CalculateScoreSumUI calculateScoreSumPrefab;
        public CalculateScoreWinLoseDrawUI calculateScoreWinLoseDrawPrefab;

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
                    uiData.editNormalRoundFactory.allAddCallBack(this);
                    uiData.gameFactory.allAddCallBack(this);
                    uiData.isChangeSideBetweenRound.allAddCallBack(this);
                    uiData.isSwitchPlayer.allAddCallBack(this);
                    uiData.isDifferentInTeam.allAddCallBack(this);
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
                // editNormalRoundFactory
                {
                    if (data is EditData<NormalRoundFactory>)
                    {
                        EditData<NormalRoundFactory> editNormalRoundFactory = data as EditData<NormalRoundFactory>;
                        // Child
                        {
                            editNormalRoundFactory.show.allAddCallBack(this);
                            editNormalRoundFactory.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is NormalRoundFactory)
                        {
                            NormalRoundFactory normalRoundFactory = data as NormalRoundFactory;
                            // Parent
                            {
                                DataUtils.addParentCallBack(normalRoundFactory, this, ref this.server);
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
                // isChangeSideBetweenRound, isSwitchPlayer, isDifferentInTeam
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.isChangeSideBetweenRound:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.isSwitchPlayer:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.isDifferentInTeam:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestBool, this.transform, UIConstants.RequestBoolRect);
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
                // calculateScoreType
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
                                case UIData.Property.calculateScoreType:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestEnum, this.transform, UIConstants.RequestEnumRect);
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
                    uiData.editNormalRoundFactory.allRemoveCallBack(this);
                    uiData.gameFactory.allRemoveCallBack(this);
                    uiData.isChangeSideBetweenRound.allRemoveCallBack(this);
                    uiData.isSwitchPlayer.allRemoveCallBack(this);
                    uiData.isDifferentInTeam.allRemoveCallBack(this);
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
                // editNormalRoundFactory
                {
                    if (data is EditData<NormalRoundFactory>)
                    {
                        EditData<NormalRoundFactory> editNormalRoundFactory = data as EditData<NormalRoundFactory>;
                        // Child
                        {
                            editNormalRoundFactory.show.allRemoveCallBack(this);
                            editNormalRoundFactory.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is NormalRoundFactory)
                        {
                            NormalRoundFactory normalRoundFactory = data as NormalRoundFactory;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(normalRoundFactory, this, ref this.server);
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
                // isChangeSideBetweenRound, isSwitchPlayer, isDifferentInTeam
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    dirty = true;
                    return;
                }
                if (data is GameFactoryUI.UIData)
                {
                    GameFactoryUI.UIData gameFactoryUIData = data as GameFactoryUI.UIData;
                    // Child
                    {
                        TransformData.RemoveCallBack(gameFactoryUIData, this);
                    }
                    // UI
                    {
                        gameFactoryUIData.removeCallBackAndDestroy(typeof(GameFactoryUI));
                    }
                    return;
                }
                // calculateScoreType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
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
                    case UIData.Property.editNormalRoundFactory:
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
                    case UIData.Property.isChangeSideBetweenRound:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isSwitchPlayer:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.isDifferentInTeam:
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
                    case Setting.Property.style:
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
                    case Setting.Property.buttonSize:
                        dirty = true;
                        break;
                    case Setting.Property.itemSize:
                        dirty = true;
                        break;
                    case Setting.Property.confirmQuit:
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
                // editNormalRoundFactory
                {
                    if (wrapProperty.p is EditData<NormalRoundFactory>)
                    {
                        switch ((EditData<NormalRoundFactory>.Property)wrapProperty.n)
                        {
                            case EditData<NormalRoundFactory>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<NormalRoundFactory>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<NormalRoundFactory>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<NormalRoundFactory>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<NormalRoundFactory>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<NormalRoundFactory>.Property.editType:
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
                        if (wrapProperty.p is NormalRoundFactory)
                        {
                            switch ((NormalRoundFactory.Property)wrapProperty.n)
                            {
                                case NormalRoundFactory.Property.gameFactory:
                                    dirty = true;
                                    break;
                                case NormalRoundFactory.Property.isChangeSideBetweenRound:
                                    dirty = true;
                                    break;
                                case NormalRoundFactory.Property.isSwitchPlayer:
                                    dirty = true;
                                    break;
                                case NormalRoundFactory.Property.isDifferentInTeam:
                                    dirty = true;
                                    break;
                                case NormalRoundFactory.Property.calculateScore:
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
                // isChangeSideBetweenRound, isSwitchPlayer, isDifferentInTeam
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is GameFactoryUI.UIData)
                {
                    return;
                }
                // calculateScoreType
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
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