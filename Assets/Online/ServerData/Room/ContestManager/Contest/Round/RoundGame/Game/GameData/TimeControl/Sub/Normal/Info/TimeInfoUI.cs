using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.Normal
{
    public class TimeInfoUI : UIHaveTransformDataBehavior<TimeInfoUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<EditData<TimeInfo>> editTimeInfo;

            public VP<UIRectTransform.ShowType> showType;

            #region timePerTurn

            public VP<RequestChangeEnumUI.UIData> timePerTurnType;

            public void makeRequestChangeTimePerTurnType(RequestChangeUpdate<int>.UpdateData update, int newTimePerTurnType)
            {
                // Find
                TimeInfo timeInfo = null;
                {
                    EditData<TimeInfo> editTimeInfo = this.editTimeInfo.v;
                    if (editTimeInfo != null)
                    {
                        timeInfo = editTimeInfo.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editTimeInfo null: " + this);
                    }
                }
                // Process
                if (timeInfo != null)
                {
                    timeInfo.requestChangeTimePerTurnType(Server.getProfileUserId(timeInfo), newTimePerTurnType);
                }
                else
                {
                    Debug.LogError("timeInfo null: " + this);
                }
            }

            public VP<TimePerTurnInfoUI.UIData> timePerTurn;

            #endregion

            #region totalTime

            public VP<RequestChangeEnumUI.UIData> totalTimeType;

            public void makeRequestChangeTotalTimeType(RequestChangeUpdate<int>.UpdateData update, int newTotalTimeType)
            {
                // Find
                TimeInfo timeInfo = null;
                {
                    EditData<TimeInfo> editTimeInfo = this.editTimeInfo.v;
                    if (editTimeInfo != null)
                    {
                        timeInfo = editTimeInfo.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editTimeInfo null: " + this);
                    }
                }
                // Process
                if (timeInfo != null)
                {
                    timeInfo.requestChangeTotalTimeType(Server.getProfileUserId(timeInfo), newTotalTimeType);
                }
                else
                {
                    Debug.LogError("timeInfo null: " + this);
                }
            }

            public VP<TotalTimeInfoUI.UIData> totalTime;

            #endregion

            #region overTimePerTurn

            public VP<RequestChangeEnumUI.UIData> overTimePerTurnType;

            public void makeRequestChangeOverTimePerTurnType(RequestChangeUpdate<int>.UpdateData update, int newOverTimePerTurnType)
            {
                // Find
                TimeInfo timeInfo = null;
                {
                    EditData<TimeInfo> editTimeInfo = this.editTimeInfo.v;
                    if (editTimeInfo != null)
                    {
                        timeInfo = editTimeInfo.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editTimeInfo null: " + this);
                    }
                }
                // Process
                if (timeInfo != null)
                {
                    timeInfo.requestChangeOverTimePerTurnType(Server.getProfileUserId(timeInfo), newOverTimePerTurnType);
                }
                else
                {
                    Debug.LogError("timeInfo null: " + this);
                }
            }

            public VP<TimePerTurnInfoUI.UIData> overTimePerTurn;

            #endregion

            #region lagCompensation

            public VP<RequestChangeFloatUI.UIData> lagCompensation;

            public void makeRequestChangeLagCompensation(RequestChangeUpdate<float>.UpdateData update, float newLagCompensation)
            {
                // Find
                TimeInfo timeInfo = null;
                {
                    EditData<TimeInfo> editTimeInfo = this.editTimeInfo.v;
                    if (editTimeInfo != null)
                    {
                        timeInfo = editTimeInfo.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editTimeInfo null: " + this);
                    }
                }
                // Process
                if (timeInfo != null)
                {
                    timeInfo.requestChangeLagCompensation(Server.getProfileUserId(timeInfo), newLagCompensation);
                }
                else
                {
                    Debug.LogError("timeInfo null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editTimeInfo,
                showType,
                timePerTurnType,
                timePerTurn,
                totalTimeType,
                totalTime,
                overTimePerTurnType,
                overTimePerTurn,
                lagCompensation
            }

            public UIData() : base()
            {
                this.editTimeInfo = new VP<EditData<TimeInfo>>(this, (byte)Property.editTimeInfo, new EditData<TimeInfo>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // timePerTurnType
                {
                    this.timePerTurnType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.timePerTurnType, new RequestChangeEnumUI.UIData());
                    // event
                    this.timePerTurnType.v.updateData.v.request.v = makeRequestChangeTimePerTurnType;
                    {
                        foreach (TimePerTurnInfo.Type type in System.Enum.GetValues(typeof(TimePerTurnInfo.Type)))
                        {
                            this.timePerTurnType.v.options.add(type.ToString());
                        }
                    }
                }
                this.timePerTurn = new VP<TimePerTurnInfoUI.UIData>(this, (byte)Property.timePerTurn, new TimePerTurnInfoUI.UIData());
                // totalTimeType
                {
                    this.totalTimeType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.totalTimeType, new RequestChangeEnumUI.UIData());
                    // event
                    this.totalTimeType.v.updateData.v.request.v = makeRequestChangeTotalTimeType;
                    {
                        foreach (TotalTimeInfo.Type type in System.Enum.GetValues(typeof(TotalTimeInfo.Type)))
                        {
                            this.totalTimeType.v.options.add(type.ToString());
                        }
                    }
                }
                this.totalTime = new VP<TotalTimeInfoUI.UIData>(this, (byte)Property.totalTime, new TotalTimeInfoUI.UIData());
                // overTimePerTurnType
                {
                    this.overTimePerTurnType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.overTimePerTurnType, new RequestChangeEnumUI.UIData());
                    // event
                    this.overTimePerTurnType.v.updateData.v.request.v = makeRequestChangeOverTimePerTurnType;
                    {
                        foreach (TimePerTurnInfo.Type type in System.Enum.GetValues(typeof(TimePerTurnInfo.Type)))
                        {
                            this.overTimePerTurnType.v.options.add(type.ToString());
                        }
                    }
                }
                this.overTimePerTurn = new VP<TimePerTurnInfoUI.UIData>(this, (byte)Property.overTimePerTurn, new TimePerTurnInfoUI.UIData());
                // lagCompensation
                {
                    this.lagCompensation = new VP<RequestChangeFloatUI.UIData>(this, (byte)Property.lagCompensation, new RequestChangeFloatUI.UIData());
                    // event
                    this.lagCompensation.v.updateData.v.request.v = makeRequestChangeLagCompensation;
                }
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbTimePerTurnType;
        private static readonly TxtLanguage txtTimePerTurnType = new TxtLanguage();

        public Text lbTotalTimeType;
        private static readonly TxtLanguage txtTotalTimeType = new TxtLanguage();

        public Text lbOverTimePerTurnType;
        private static readonly TxtLanguage txtOverTimePerTurnType = new TxtLanguage();

        public Text lbLagCompensation;
        private static readonly TxtLanguage txtLagCompensation = new TxtLanguage();

        static TimeInfoUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Thông Tin Thời Gian");
                txtTimePerTurnType.add(Language.Type.vi, "Loại thời gian mỗi lượt");
                txtTotalTimeType.add(Language.Type.vi, "Loại tổng thời gian");
                txtOverTimePerTurnType.add(Language.Type.vi, "Loại quá thời gian mỗi lượt");
                txtLagCompensation.add(Language.Type.vi, "Đền bù lag");
            }
            // rect
            {

            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public Image bgTimePerTurn;
        public Image bgTotalTime;
        public Image bgOverTimePerTurn;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<TimeInfo> editTimeInfo = this.data.editTimeInfo.v;
                    if (editTimeInfo != null)
                    {
                        // update
                        editTimeInfo.update();
                        // get show
                        TimeInfo show = editTimeInfo.show.v.data;
                        TimeInfo compare = editTimeInfo.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editTimeInfo.compareOtherType.v.data != null)
                                    {
                                        if (editTimeInfo.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = Server.State.Type.Connect;
                                {
                                    Server server = show.findDataInParent<Server>();
                                    if (server != null)
                                    {
                                        if (server.state.v != null)
                                        {
                                            serverState = server.state.v.getType();
                                        }
                                        else
                                        {
                                            Debug.LogError("server state null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        // Debug.LogError ("server null: " + this);
                                    }
                                }
                                // set origin
                                {
                                    // timePerTurnType
                                    {
                                        RequestChangeEnumUI.UIData timePerTurnType = this.data.timePerTurnType.v;
                                        if (timePerTurnType != null)
                                        {
                                            // options
                                            timePerTurnType.options.copyList(TimePerTurnInfo.getStrTypes());
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = timePerTurnType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.getTimePerTurnType();
                                                updateData.canRequestChange.v = editTimeInfo.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    timePerTurnType.showDifferent.v = true;
                                                    timePerTurnType.compare.v = (int)compare.getTimePerTurnType();
                                                }
                                                else
                                                {
                                                    timePerTurnType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("timePerTurnType null: " + this);
                                        }
                                    }
                                    // timePerTurn
                                    {
                                        TimePerTurnInfoUI.UIData timerPerTurn = this.data.timePerTurn.v;
                                        if (timerPerTurn != null)
                                        {
                                            EditData<TimePerTurnInfo> editTimePerTurnInfo = timerPerTurn.editTimePerTurnInfo.v;
                                            if (editTimePerTurnInfo != null)
                                            {
                                                // origin
                                                {
                                                    TimePerTurnInfo originTimePerTurn = null;
                                                    {
                                                        TimeInfo originTimeInfo = editTimeInfo.origin.v.data;
                                                        if (originTimeInfo != null)
                                                        {
                                                            originTimePerTurn = originTimeInfo.timePerTurn.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("originTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editTimePerTurnInfo.origin.v = new ReferenceData<TimePerTurnInfo>(originTimePerTurn);
                                                }
                                                // show
                                                {
                                                    TimePerTurnInfo showTimePerTurn = null;
                                                    {
                                                        TimeInfo showTimeInfo = editTimeInfo.show.v.data;
                                                        if (showTimeInfo != null)
                                                        {
                                                            showTimePerTurn = showTimeInfo.timePerTurn.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("showTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editTimePerTurnInfo.show.v = new ReferenceData<TimePerTurnInfo>(showTimePerTurn);
                                                }
                                                // compare
                                                {
                                                    TimePerTurnInfo compareTimePerTurn = null;
                                                    {
                                                        TimeInfo compareTimeInfo = editTimeInfo.compare.v.data;
                                                        if (compareTimeInfo != null)
                                                        {
                                                            compareTimePerTurn = compareTimeInfo.timePerTurn.v;
                                                        }
                                                        else
                                                        {
                                                            // Debug.LogError ("compareTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editTimePerTurnInfo.compare.v = new ReferenceData<TimePerTurnInfo>(compareTimePerTurn);
                                                }
                                                // compare other type
                                                {
                                                    TimePerTurnInfo compareOtherTypeTimePerTurn = null;
                                                    {
                                                        TimeInfo compareOtherTypeTimeInfo = (TimeInfo)editTimeInfo.compareOtherType.v.data;
                                                        if (compareOtherTypeTimeInfo != null)
                                                        {
                                                            compareOtherTypeTimePerTurn = compareOtherTypeTimeInfo.timePerTurn.v;
                                                        }
                                                    }
                                                    editTimePerTurnInfo.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeTimePerTurn);
                                                }
                                                // canEdit
                                                editTimePerTurnInfo.canEdit.v = editTimeInfo.canEdit.v;
                                                // editType
                                                editTimePerTurnInfo.editType.v = editTimeInfo.editType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("editTimePerTurnInfo null: " + this);
                                            }
                                            timerPerTurn.showType.v = UIRectTransform.ShowType.HeadLess;
                                        }
                                        else
                                        {
                                            Debug.LogError("timePerTurn null: " + this);
                                        }
                                    }
                                    // totalTimeType
                                    {
                                        RequestChangeEnumUI.UIData totalTimeType = this.data.totalTimeType.v;
                                        if (totalTimeType != null)
                                        {
                                            // options
                                            totalTimeType.options.copyList(TotalTimeInfo.getStrTypes());
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = totalTimeType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.getTotalTimeType();
                                                updateData.canRequestChange.v = editTimeInfo.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    totalTimeType.showDifferent.v = true;
                                                    totalTimeType.compare.v = (int)compare.getTotalTimeType();
                                                }
                                                else
                                                {
                                                    totalTimeType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("totalTimeType null: " + this);
                                        }
                                    }
                                    // totalTime
                                    {
                                        TotalTimeInfoUI.UIData totalTime = this.data.totalTime.v;
                                        if (totalTime != null)
                                        {
                                            EditData<TotalTimeInfo> editTotalTimeInfo = totalTime.editTotalTimeInfo.v;
                                            if (editTotalTimeInfo != null)
                                            {
                                                // origin
                                                {
                                                    TotalTimeInfo originTotalTime = null;
                                                    {
                                                        TimeInfo originTimeInfo = editTimeInfo.origin.v.data;
                                                        if (originTimeInfo != null)
                                                        {
                                                            originTotalTime = originTimeInfo.totalTime.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("originTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editTotalTimeInfo.origin.v = new ReferenceData<TotalTimeInfo>(originTotalTime);
                                                }
                                                // show
                                                {
                                                    TotalTimeInfo showTotalTime = null;
                                                    {
                                                        TimeInfo showTimeInfo = editTimeInfo.show.v.data;
                                                        if (showTimeInfo != null)
                                                        {
                                                            showTotalTime = showTimeInfo.totalTime.v;
                                                        }
                                                        else
                                                        {
                                                            // Debug.LogError ("showTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editTotalTimeInfo.show.v = new ReferenceData<TotalTimeInfo>(showTotalTime);
                                                }
                                                // compare
                                                {
                                                    TotalTimeInfo compareTotalTime = null;
                                                    {
                                                        TimeInfo compareTimeInfo = editTimeInfo.compare.v.data;
                                                        if (compareTimeInfo != null)
                                                        {
                                                            compareTotalTime = compareTimeInfo.totalTime.v;
                                                        }
                                                        else
                                                        {
                                                            // Debug.LogError ("compareTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editTotalTimeInfo.compare.v = new ReferenceData<TotalTimeInfo>(compareTotalTime);
                                                }
                                                // compare other type
                                                {
                                                    TotalTimeInfo compareOtherTypeTotalTime = null;
                                                    {
                                                        TimeInfo compareOtherTypeTimeInfo = (TimeInfo)editTimeInfo.compareOtherType.v.data;
                                                        if (compareOtherTypeTimeInfo != null)
                                                        {
                                                            compareOtherTypeTotalTime = compareOtherTypeTimeInfo.totalTime.v;
                                                        }
                                                    }
                                                    editTotalTimeInfo.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeTotalTime);
                                                }
                                                // canEdit
                                                editTotalTimeInfo.canEdit.v = editTimeInfo.canEdit.v;
                                                // editType
                                                editTotalTimeInfo.editType.v = editTimeInfo.editType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("editTotalTimeInfo null: " + this);
                                            }
                                            totalTime.showType.v = UIRectTransform.ShowType.HeadLess;
                                        }
                                        else
                                        {
                                            Debug.LogError("timePerTurn null: " + this);
                                        }
                                    }
                                    // overTimePerTurnType
                                    {
                                        RequestChangeEnumUI.UIData overTimePerTurnType = this.data.overTimePerTurnType.v;
                                        if (overTimePerTurnType != null)
                                        {
                                            // options
                                            overTimePerTurnType.options.copyList(TimePerTurnInfo.getStrTypes());
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = overTimePerTurnType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.getOverTimePerTurnType();
                                                updateData.canRequestChange.v = editTimeInfo.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    overTimePerTurnType.showDifferent.v = true;
                                                    overTimePerTurnType.compare.v = (int)compare.getOverTimePerTurnType();
                                                }
                                                else
                                                {
                                                    overTimePerTurnType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("overTimePerTurnType null: " + this);
                                        }
                                    }
                                    // overTimePerTurn
                                    {
                                        TimePerTurnInfoUI.UIData overTimePerTurn = this.data.overTimePerTurn.v;
                                        if (overTimePerTurn != null)
                                        {
                                            EditData<TimePerTurnInfo> editOverTimePerTurnInfo = overTimePerTurn.editTimePerTurnInfo.v;
                                            if (editOverTimePerTurnInfo != null)
                                            {
                                                // origin
                                                {
                                                    TimePerTurnInfo originOverTimePerTurn = null;
                                                    {
                                                        TimeInfo originTimeInfo = editTimeInfo.origin.v.data;
                                                        if (originTimeInfo != null)
                                                        {
                                                            originOverTimePerTurn = originTimeInfo.overTimePerTurn.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("originTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editOverTimePerTurnInfo.origin.v = new ReferenceData<TimePerTurnInfo>(originOverTimePerTurn);
                                                }
                                                // show
                                                {
                                                    TimePerTurnInfo showOverTimePerTurn = null;
                                                    {
                                                        TimeInfo showTimeInfo = editTimeInfo.show.v.data;
                                                        if (showTimeInfo != null)
                                                        {
                                                            showOverTimePerTurn = showTimeInfo.overTimePerTurn.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("showTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editOverTimePerTurnInfo.show.v = new ReferenceData<TimePerTurnInfo>(showOverTimePerTurn);
                                                }
                                                // compare
                                                {
                                                    TimePerTurnInfo compareOverTimePerTurn = null;
                                                    {
                                                        TimeInfo compareTimeInfo = editTimeInfo.compare.v.data;
                                                        if (compareTimeInfo != null)
                                                        {
                                                            compareOverTimePerTurn = compareTimeInfo.overTimePerTurn.v;
                                                        }
                                                        else
                                                        {
                                                            // Debug.LogError ("compareTimeInfo null: " + this);
                                                        }
                                                    }
                                                    editOverTimePerTurnInfo.compare.v = new ReferenceData<TimePerTurnInfo>(compareOverTimePerTurn);
                                                }
                                                // compare other type
                                                {
                                                    TimePerTurnInfo compareOtherTypeOverTimePerTurn = null;
                                                    {
                                                        TimeInfo compareOtherTypeTimeInfo = (TimeInfo)editTimeInfo.compareOtherType.v.data;
                                                        if (compareOtherTypeTimeInfo != null)
                                                        {
                                                            compareOtherTypeOverTimePerTurn = compareOtherTypeTimeInfo.overTimePerTurn.v;
                                                        }
                                                    }
                                                    editOverTimePerTurnInfo.compareOtherType.v = new ReferenceData<Data>(compareOtherTypeOverTimePerTurn);
                                                }
                                                // canEdit
                                                editOverTimePerTurnInfo.canEdit.v = editTimeInfo.canEdit.v;
                                                // editType
                                                editOverTimePerTurnInfo.editType.v = editTimeInfo.editType.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("editOverTimePerTurnInfo null: " + this);
                                            }
                                            overTimePerTurn.showType.v = UIRectTransform.ShowType.HeadLess;
                                        }
                                        else
                                        {
                                            Debug.LogError("timePerTurn null: " + this);
                                        }
                                    }
                                    // lagCompensation
                                    {
                                        RequestChangeFloatUI.UIData lagCompensation = this.data.lagCompensation.v;
                                        if (lagCompensation != null)
                                        {
                                            // update
                                            RequestChangeUpdate<float>.UpdateData updateData = lagCompensation.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.lagCompensation.v;
                                                updateData.canRequestChange.v = editTimeInfo.canEdit.v;
                                                updateData.serverState.v = serverState;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                            // compare
                                            {
                                                if (compare != null)
                                                {
                                                    lagCompensation.showDifferent.v = true;
                                                    lagCompensation.compare.v = compare.lagCompensation.v;
                                                }
                                                else
                                                {
                                                    lagCompensation.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("lagCompensation null: " + this);
                                        }
                                    }
                                }
                                // reset?
                                if (needReset)
                                {
                                    needReset = false;
                                    // timePerTurnType
                                    {
                                        RequestChangeEnumUI.UIData timePerTurnType = this.data.timePerTurnType.v;
                                        if (timePerTurnType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = timePerTurnType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = (int)show.getTimePerTurnType();
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("timePerTurnType null: " + this);
                                        }
                                    }
                                    // totalTimeType
                                    {
                                        RequestChangeEnumUI.UIData totalTimeType = this.data.totalTimeType.v;
                                        if (totalTimeType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = totalTimeType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = (int)show.getTotalTimeType();
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("totalTimeType null: " + this);
                                        }
                                    }
                                    // overTimePerTurnType
                                    {
                                        RequestChangeEnumUI.UIData overTimePerTurnType = this.data.overTimePerTurnType.v;
                                        if (overTimePerTurnType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = overTimePerTurnType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = (int)show.getOverTimePerTurnType();
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("overTimePerTurnType null: " + this);
                                        }
                                    }
                                    // lagCompensation
                                    {
                                        RequestChangeFloatUI.UIData lagCompensation = this.data.lagCompensation.v;
                                        if (lagCompensation != null)
                                        {
                                            // update
                                            RequestChangeUpdate<float>.UpdateData updateData = lagCompensation.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.current.v = show.lagCompensation.v;
                                                updateData.changeState.v = Data.ChangeState.None;
                                            }
                                            else
                                            {
                                                Debug.LogError("updateData null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("lagCompensation null: " + this);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Debug.LogError ("show null: " + this);
                        }
                        // UI Position
                        {
                            float deltaY = 0;
                            // header
                            {
                                switch (this.data.showType.v)
                                {
                                    case UIRectTransform.ShowType.Normal:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(true);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                            deltaY += UIConstants.HeaderHeight;
                                        }
                                        break;
                                    case UIRectTransform.ShowType.HeadLess:
                                        {
                                            if (lbTitle != null)
                                            {
                                                lbTitle.gameObject.SetActive(false);
                                            }
                                            else
                                            {
                                                Debug.LogError("lbTitle null");
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown showType: " + this.data.showType.v);
                                        break;
                                }
                            }
                            // timePerTurn
                            {
                                float bgY = deltaY;
                                float bgHeight = 0;
                                // type
                                {
                                    if (this.data.timePerTurnType.v != null)
                                    {
                                        UIRectTransform.SetPosY(this.data.timePerTurnType.v, UIConstants.RequestEnumRect, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                                        if (lbTimePerTurnType != null)
                                        {
                                            lbTimePerTurnType.gameObject.SetActive(true);
                                            UIRectTransform.SetPosY((RectTransform)lbTimePerTurnType.transform, deltaY);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbTimePerTurnType null: " + this);
                                        }
                                        bgHeight += UIConstants.ItemHeight;
                                        deltaY += UIConstants.ItemHeight;
                                    }
                                    else
                                    {
                                        if (lbTimePerTurnType != null)
                                        {
                                            lbTimePerTurnType.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbTimePerTurnType null");
                                        }
                                    }
                                }
                                // UI
                                {
                                    float height = UIRectTransform.SetPosY(this.data.timePerTurn.v, deltaY);
                                    bgHeight += height;
                                    deltaY += height;
                                }
                                // bg
                                if (bgTimePerTurn != null)
                                {
                                    UIRectTransform.SetPosY(bgTimePerTurn.rectTransform, bgY);
                                    UIRectTransform.SetHeight(bgTimePerTurn.rectTransform, bgHeight);
                                }
                                else
                                {
                                    Debug.LogError("bgTimePerTurn null");
                                }
                            }
                            // totalTime
                            {
                                float bgY = deltaY;
                                float bgHeight = 0;
                                // type
                                {
                                    if (this.data.totalTimeType.v != null)
                                    {
                                        UIRectTransform.SetPosY(this.data.totalTimeType.v, UIConstants.RequestEnumRect, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                                        if (lbTotalTimeType != null)
                                        {
                                            lbTotalTimeType.gameObject.SetActive(true);
                                            UIRectTransform.SetPosY((RectTransform)lbTotalTimeType.transform, deltaY);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbTotalTimeType null: " + this);
                                        }
                                        bgHeight += UIConstants.ItemHeight;
                                        deltaY += UIConstants.ItemHeight;
                                    }
                                    else
                                    {
                                        if (lbTotalTimeType != null)
                                        {
                                            lbTotalTimeType.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbTotalTimeType null");
                                        }
                                    }
                                }
                                // UI
                                {
                                    float height = UIRectTransform.SetPosY(this.data.totalTime.v, deltaY);
                                    bgHeight += height;
                                    deltaY += height;
                                }
                                // bg
                                if (bgTotalTime != null)
                                {
                                    UIRectTransform.SetPosY(bgTotalTime.rectTransform, bgY);
                                    UIRectTransform.SetHeight(bgTotalTime.rectTransform, bgHeight);
                                }
                                else
                                {
                                    Debug.LogError("bgTotalTime null");
                                }
                            }
                            // overTimePerTurn
                            {
                                float bgY = deltaY;
                                float bgHeight = 0;
                                // Type
                                {
                                    if (this.data.overTimePerTurnType.v != null)
                                    {
                                        UIRectTransform.SetPosY(this.data.overTimePerTurnType.v, UIConstants.RequestEnumRect, deltaY + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2);
                                        if (lbOverTimePerTurnType != null)
                                        {
                                            lbOverTimePerTurnType.gameObject.SetActive(true);
                                            UIRectTransform.SetPosY((RectTransform)lbOverTimePerTurnType.transform, deltaY);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbOverTimePerTurnType null: " + this);
                                        }
                                        bgHeight += UIConstants.ItemHeight;
                                        deltaY += UIConstants.ItemHeight;
                                    }
                                    else
                                    {
                                        if (lbOverTimePerTurnType != null)
                                        {
                                            lbOverTimePerTurnType.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("lbOverTimePerTurnType null");
                                        }
                                    }
                                }
                                // UI
                                {
                                    float height = UIRectTransform.SetPosY(this.data.overTimePerTurn.v, deltaY);
                                    bgHeight += height;
                                    deltaY += height;
                                }
                                // bg
                                if (bgOverTimePerTurn != null)
                                {
                                    UIRectTransform.SetPosY(bgOverTimePerTurn.rectTransform, bgY);
                                    UIRectTransform.SetHeight(bgOverTimePerTurn.rectTransform, bgHeight);
                                }
                                else
                                {
                                    Debug.LogError("bgOverTimePerTurn null");
                                }
                            }
                            // lagCompensation
                            {
                                if (this.data.lagCompensation.v != null)
                                {
                                    UIRectTransform.SetPosY(this.data.lagCompensation.v, UIConstants.RequestRect, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2);
                                    if (lbLagCompensation != null)
                                    {
                                        lbLagCompensation.gameObject.SetActive(true);
                                        UIRectTransform.SetPosY((RectTransform)lbLagCompensation.transform, deltaY);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbLagCompensation null: " + this);
                                    }
                                    deltaY += UIConstants.ItemHeight;
                                }
                                else
                                {
                                    if (lbLagCompensation != null)
                                    {
                                        lbLagCompensation.gameObject.SetActive(false);
                                    }
                                    else
                                    {
                                        Debug.LogError("lbLagCompensation null");
                                    }
                                }
                            }
                            // set
                            UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                        }
                        // txt
                        {
                            if (lbTitle != null)
                            {
                                lbTitle.text = txtTitle.get("Time Information");
                            }
                            else
                            {
                                Debug.LogError("lbTitle null: " + this);
                            }
                            if (lbTimePerTurnType != null)
                            {
                                lbTimePerTurnType.text = txtTimePerTurnType.get("Time per turn type");
                            }
                            else
                            {
                                Debug.LogError("lbTimePerTurnType null: " + this);
                            }
                            if (lbTotalTimeType != null)
                            {
                                lbTotalTimeType.text = txtTotalTimeType.get("Total time type");
                            }
                            else
                            {
                                Debug.LogError("lbTotalTimeType null: " + this);
                            }
                            if (lbOverTimePerTurnType != null)
                            {
                                lbOverTimePerTurnType.text = txtOverTimePerTurnType.get("Over time per turn type");
                            }
                            else
                            {
                                Debug.LogError("lbOverTimePerTurnType null: " + this);
                            }
                            if (lbLagCompensation != null)
                            {
                                lbLagCompensation.text = txtLagCompensation.get("Lag compensation");
                            }
                            else
                            {
                                Debug.LogError("lbLagCompensation null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("editTimeInfo null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        public TimePerTurnInfoUI timePerTurnPrefab;
        public TotalTimeInfoUI totalTimePrefab;

        public RequestChangeFloatUI requestFloatPrefab;
        public RequestChangeEnumUI requestEnumPrefab;

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
                    uiData.editTimeInfo.allAddCallBack(this);
                    uiData.timePerTurnType.allAddCallBack(this);
                    uiData.timePerTurn.allAddCallBack(this);
                    uiData.totalTimeType.allAddCallBack(this);
                    uiData.totalTime.allAddCallBack(this);
                    uiData.overTimePerTurnType.allAddCallBack(this);
                    uiData.overTimePerTurn.allAddCallBack(this);
                    uiData.lagCompensation.allAddCallBack(this);
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
                // editTimeInfo
                {
                    if (data is EditData<TimeInfo>)
                    {
                        EditData<TimeInfo> editTimeInfo = data as EditData<TimeInfo>;
                        // Child
                        {
                            editTimeInfo.show.allAddCallBack(this);
                            editTimeInfo.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is TimeInfo)
                        {
                            TimeInfo timeInfo = data as TimeInfo;
                            // Parent
                            {
                                DataUtils.addParentCallBack(timeInfo, this, ref this.server);
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
                                case UIData.Property.timePerTurnType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform);
                                    break;
                                case UIData.Property.totalTimeType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform);
                                    break;
                                case UIData.Property.overTimePerTurnType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform);
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
                // InfoUI
                {
                    if (data is TimePerTurnInfoUI.UIData)
                    {
                        TimePerTurnInfoUI.UIData timePerTurnInfoUIData = data as TimePerTurnInfoUI.UIData;
                        // UI
                        {
                            WrapProperty wrapProperty = timePerTurnInfoUIData.p;
                            if (wrapProperty != null)
                            {
                                switch ((UIData.Property)wrapProperty.n)
                                {
                                    case UIData.Property.timePerTurn:
                                        UIUtils.Instantiate(timePerTurnInfoUIData, timePerTurnPrefab, this.transform);
                                        break;
                                    case UIData.Property.overTimePerTurn:
                                        UIUtils.Instantiate(timePerTurnInfoUIData, timePerTurnPrefab, this.transform);
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
                        // Child
                        {
                            TransformData.AddCallBack(timePerTurnInfoUIData, this);
                        }
                        dirty = true;
                        return;
                    }
                    if (data is TotalTimeInfoUI.UIData)
                    {
                        TotalTimeInfoUI.UIData totalTimeInfoUIData = data as TotalTimeInfoUI.UIData;
                        // UI
                        {
                            UIUtils.Instantiate(totalTimeInfoUIData, totalTimePrefab, this.transform);
                        }
                        // Child
                        {
                            TransformData.AddCallBack(totalTimeInfoUIData, this);
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
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.lagCompensation:
                                    UIUtils.Instantiate(requestChange, requestFloatPrefab, this.transform);
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
                    uiData.editTimeInfo.allRemoveCallBack(this);
                    uiData.timePerTurnType.allRemoveCallBack(this);
                    uiData.timePerTurn.allRemoveCallBack(this);
                    uiData.totalTimeType.allRemoveCallBack(this);
                    uiData.totalTime.allRemoveCallBack(this);
                    uiData.overTimePerTurnType.allRemoveCallBack(this);
                    uiData.overTimePerTurn.allRemoveCallBack(this);
                    uiData.lagCompensation.allRemoveCallBack(this);
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
                // editTimeInfo
                {
                    if (data is EditData<TimeInfo>)
                    {
                        EditData<TimeInfo> editTimeInfo = data as EditData<TimeInfo>;
                        // Child
                        {
                            editTimeInfo.show.allRemoveCallBack(this);
                            editTimeInfo.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is TimeInfo)
                        {
                            TimeInfo timeInfo = data as TimeInfo;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(timeInfo, this, ref this.server);
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
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                // InfoUI
                {
                    if (data is TimePerTurnInfoUI.UIData)
                    {
                        TimePerTurnInfoUI.UIData timePerTurnInfoUIData = data as TimePerTurnInfoUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(timePerTurnInfoUIData, this);
                        }
                        // UI
                        {
                            timePerTurnInfoUIData.removeCallBackAndDestroy(typeof(TimePerTurnInfoUI));
                        }
                        return;
                    }
                    if (data is TotalTimeInfoUI.UIData)
                    {
                        TotalTimeInfoUI.UIData totalTimeInfoUIData = data as TotalTimeInfoUI.UIData;
                        // Child
                        {
                            TransformData.RemoveCallBack(totalTimeInfoUIData, this);
                        }
                        // UI
                        {
                            totalTimeInfoUIData.removeCallBackAndDestroy(typeof(TotalTimeInfoUI));
                        }
                        return;
                    }
                    // Child
                    if (data is TransformData)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is RequestChangeFloatUI.UIData)
                {
                    RequestChangeFloatUI.UIData requestChange = data as RequestChangeFloatUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeFloatUI));
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
                    case UIData.Property.editTimeInfo:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.timePerTurnType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.timePerTurn:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.totalTimeType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.totalTime:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.overTimePerTurnType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.overTimePerTurn:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.lagCompensation:
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
                // editTimeInfo
                {
                    if (wrapProperty.p is EditData<TimeInfo>)
                    {
                        switch ((EditData<TimeInfo>.Property)wrapProperty.n)
                        {
                            case EditData<TimeInfo>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<TimeInfo>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimeInfo>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<TimeInfo>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<TimeInfo>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<TimeInfo>.Property.editType:
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
                        if (wrapProperty.p is TimeInfo)
                        {
                            switch ((TimeInfo.Property)wrapProperty.n)
                            {
                                case TimeInfo.Property.timePerTurn:
                                    dirty = true;
                                    break;
                                case TimeInfo.Property.totalTime:
                                    dirty = true;
                                    break;
                                case TimeInfo.Property.overTimePerTurn:
                                    dirty = true;
                                    break;
                                case TimeInfo.Property.lagCompensation:
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
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // InfoUI
                {
                    if (wrapProperty.p is TimePerTurnInfoUI.UIData)
                    {
                        return;
                    }
                    if (wrapProperty.p is TotalTimeInfoUI.UIData)
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
                if (wrapProperty.p is RequestChangeFloatUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}