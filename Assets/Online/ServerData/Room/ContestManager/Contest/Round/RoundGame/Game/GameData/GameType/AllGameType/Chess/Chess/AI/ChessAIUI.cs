using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Chess
{
    public class ChessAIUI : UIHaveTransformDataBehavior<ChessAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<ChessAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find
                ChessAI chessAI = null;
                {
                    EditData<ChessAI> editChessAI = this.editAI.v;
                    if (editChessAI != null)
                    {
                        chessAI = editChessAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChessAI null: " + this);
                    }
                }
                // Process
                if (chessAI != null)
                {
                    chessAI.requestChangeDepth(Server.getProfileUserId(chessAI), newDepth);
                }
                else
                {
                    Debug.LogError("chessAI null: " + this);
                }
            }

            #endregion

            #region skillLevel

            public VP<RequestChangeIntUI.UIData> skillLevel;

            public void makeRequestChangeSkillLevel(RequestChangeUpdate<int>.UpdateData update, int newSkillLevel)
            {
                // Find
                ChessAI chessAI = null;
                {
                    EditData<ChessAI> editChessAI = this.editAI.v;
                    if (editChessAI != null)
                    {
                        chessAI = editChessAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChessAI null: " + this);
                    }
                }
                // Process
                if (chessAI != null)
                {
                    chessAI.requestChangeSkillLevel(Server.getProfileUserId(chessAI), newSkillLevel);
                }
                else
                {
                    Debug.LogError("chessAI null: " + this);
                }
            }

            #endregion

            #region Duration

            public VP<RequestChangeLongUI.UIData> duration;

            public void makeRequestChangeDuration(RequestChangeUpdate<long>.UpdateData update, long newDuration)
            {
                // Find
                ChessAI chessAI = null;
                {
                    EditData<ChessAI> editChessAI = this.editAI.v;
                    if (editChessAI != null)
                    {
                        chessAI = editChessAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChessAI null: " + this);
                    }
                }
                // Process
                if (chessAI != null)
                {
                    chessAI.requestChangeDuration(Server.getProfileUserId(chessAI), newDuration);
                }
                else
                {
                    Debug.LogError("chessAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                depth,
                skillLevel,
                duration
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<ChessAI>>(this, (byte)Property.editAI, new EditData<ChessAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // Depth
                {
                    this.depth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.depth, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.depth.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 30;
                        }
                        this.depth.v.limit.v = have;
                    }
                    // event
                    this.depth.v.updateData.v.request.v = makeRequestChangeDepth;
                }
                // SkillLevel
                {
                    this.skillLevel = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.skillLevel, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.skillLevel.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 20;
                        }
                        this.skillLevel.v.limit.v = have;
                    }
                    // event
                    this.skillLevel.v.updateData.v.request.v = makeRequestChangeSkillLevel;
                }
                // Duration
                {
                    this.duration = new VP<RequestChangeLongUI.UIData>(this, (byte)Property.duration, new RequestChangeLongUI.UIData());
                    // event
                    this.duration.v.updateData.v.request.v = makeRequestChangeDuration;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.CHESS;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Chess AI");

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage("Depth");

        public Text lbSkillLevel;
        private static readonly TxtLanguage txtSkillLevel = new TxtLanguage("Skill level");

        public Text lbDuration;
        private static readonly TxtLanguage txtDuration = new TxtLanguage("Duration");

        static ChessAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "AI Cờ Vua");
                txtDepth.add(Language.Type.vi, "Độ sâu");
                txtSkillLevel.add(Language.Type.vi, "Mức kỹ năng");
                txtDuration.add(Language.Type.vi, "Thời gian");
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<ChessAI> editChessAI = this.data.editAI.v;
                    if (editChessAI != null)
                    {
                        editChessAI.update();
                        // get show
                        ChessAI show = editChessAI.show.v.data;
                        ChessAI compare = editChessAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editChessAI.compareOtherType.v.data != null)
                                    {
                                        if (editChessAI.compareOtherType.v.data.GetType() != show.GetType())
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
                                // depth
                                {
                                    RequestChangeIntUI.UIData depth = this.data.depth.v;
                                    if (depth != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.depth.v;
                                            updateData.canRequestChange.v = editChessAI.canEdit.v;
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
                                                depth.showDifferent.v = true;
                                                depth.compare.v = compare.depth.v;
                                            }
                                            else
                                            {
                                                depth.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("depth null: " + this);
                                    }
                                }
                                // skillLevel
                                {
                                    RequestChangeIntUI.UIData skillLevel = this.data.skillLevel.v;
                                    if (skillLevel != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = skillLevel.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.skillLevel.v;
                                            updateData.canRequestChange.v = editChessAI.canEdit.v;
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
                                                skillLevel.showDifferent.v = true;
                                                skillLevel.compare.v = compare.skillLevel.v;
                                            }
                                            else
                                            {
                                                skillLevel.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("skillLevel null: " + this);
                                    }
                                }
                                // duration
                                {
                                    RequestChangeLongUI.UIData duration = this.data.duration.v;
                                    if (duration != null)
                                    {
                                        // update
                                        RequestChangeUpdate<long>.UpdateData updateData = duration.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.duration.v;
                                            updateData.canRequestChange.v = editChessAI.canEdit.v;
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
                                                duration.showDifferent.v = true;
                                                duration.compare.v = compare.duration.v;
                                            }
                                            else
                                            {
                                                duration.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("duration null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // depth
                                {
                                    RequestChangeIntUI.UIData depth = this.data.depth.v;
                                    if (depth != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = depth.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.depth.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("depth null: " + this);
                                    }
                                }
                                // skillLevel
                                {
                                    RequestChangeIntUI.UIData skillLevel = this.data.skillLevel.v;
                                    if (skillLevel != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = skillLevel.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.skillLevel.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("skillLevel null: " + this);
                                    }
                                }
                                // duration
                                {
                                    RequestChangeLongUI.UIData duration = this.data.duration.v;
                                    if (duration != null)
                                    {
                                        RequestChangeUpdate<long>.UpdateData updateData = duration.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.duration.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("duration null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("chessAI null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editChessAI null: " + this);
                    }
                    // UI
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
                                case UIRectTransform.ShowType.OnlyHead:
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + this.data.showType.v);
                                    break;
                            }
                        }
                        // depth
                        {
                            if (this.data.depth.v != null)
                            {
                                if (lbDepth != null)
                                {
                                    lbDepth.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbDepth.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbDepth null");
                                }
                                UIRectTransform.SetPosY(this.data.depth.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbDepth != null)
                                {
                                    lbDepth.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbDepth null");
                                }
                            }
                        }
                        // skillLevel
                        {
                            if (this.data.skillLevel.v != null)
                            {
                                if (lbSkillLevel != null)
                                {
                                    lbSkillLevel.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbSkillLevel.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbSkillLevel null");
                                }
                                UIRectTransform.SetPosY(this.data.skillLevel.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbSkillLevel != null)
                                {
                                    lbSkillLevel.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbSkillLevel null");
                                }
                            }
                        }
                        // duration
                        {
                            if (this.data.duration.v != null)
                            {
                                if (lbDuration != null)
                                {
                                    lbDuration.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbDuration.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbDuration null");
                                }
                                UIRectTransform.SetPosY(this.data.duration.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbDuration != null)
                                {
                                    lbDuration.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbDuration null");
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
                            lbTitle.text = txtTitle.get();
                            Setting.get().setTitleTextSize(lbTitle);
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get();
                            Setting.get().setLabelTextSize(lbDepth);
                        }
                        else
                        {
                            Debug.LogError("lbDepth null: " + this);
                        }
                        if (lbSkillLevel != null)
                        {
                            lbSkillLevel.text = txtSkillLevel.get();
                            Setting.get().setLabelTextSize(lbSkillLevel);
                        }
                        else
                        {
                            Debug.LogError("lbSkillLevel null: " + this);
                        }
                        if (lbDuration != null)
                        {
                            lbDuration.text = txtDuration.get();
                            Setting.get().setLabelTextSize(lbDuration);
                        }
                        else
                        {
                            Debug.LogError("lbDuration null: " + this);
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
        public RequestChangeLongUI requestLongPrefab;

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
                    uiData.editAI.allAddCallBack(this);
                    uiData.depth.allAddCallBack(this);
                    uiData.skillLevel.allAddCallBack(this);
                    uiData.duration.allAddCallBack(this);
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
                // editAI
                {
                    if (data is EditData<ChessAI>)
                    {
                        EditData<ChessAI> editAI = data as EditData<ChessAI>;
                        // Child
                        {
                            editAI.show.allAddCallBack(this);
                            editAI.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChessAI)
                        {
                            ChessAI chessAI = data as ChessAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(chessAI, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
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
                                case UIData.Property.depth:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.skillLevel:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
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
                if (data is RequestChangeLongUI.UIData)
                {
                    RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.duration:
                                    UIUtils.Instantiate(requestChange, requestLongPrefab, this.transform, UIConstants.RequestRect);
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
                    uiData.editAI.allRemoveCallBack(this);
                    uiData.depth.allRemoveCallBack(this);
                    uiData.skillLevel.allRemoveCallBack(this);
                    uiData.duration.allRemoveCallBack(this);
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
                // editAI
                {
                    if (data is EditData<ChessAI>)
                    {
                        EditData<ChessAI> editAI = data as EditData<ChessAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChessAI)
                        {
                            ChessAI chessAI = data as ChessAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(chessAI, this, ref this.server);
                            }
                            return;
                        }
                        if (data is Server)
                        {
                            return;
                        }
                    }
                }
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
                if (data is RequestChangeLongUI.UIData)
                {
                    RequestChangeLongUI.UIData requestChange = data as RequestChangeLongUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeLongUI));
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
                    case UIData.Property.editAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.depth:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.skillLevel:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.duration:
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
                // editAI
                {
                    if (wrapProperty.p is EditData<ChessAI>)
                    {
                        switch ((EditData<ChessAI>.Property)wrapProperty.n)
                        {
                            case EditData<ChessAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ChessAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChessAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChessAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ChessAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ChessAI>.Property.editType:
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
                        if (wrapProperty.p is ChessAI)
                        {
                            switch ((ChessAI.Property)wrapProperty.n)
                            {
                                case ChessAI.Property.depth:
                                    dirty = true;
                                    break;
                                case ChessAI.Property.skillLevel:
                                    dirty = true;
                                    break;
                                case ChessAI.Property.duration:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        if (wrapProperty.p is Server)
                        {
                            Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                            return;
                        }
                    }
                }
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeLongUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}