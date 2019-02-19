using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
    public class FairyChessAIUI : UIBehavior<FairyChessAIUI.UIData>, HaveTransformData
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<FairyChessAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find
                FairyChessAI fairyChessAI = null;
                {
                    EditData<FairyChessAI> editFairyChessAI = this.editAI.v;
                    if (editFairyChessAI != null)
                    {
                        fairyChessAI = editFairyChessAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editFairyChessAI null: " + this);
                    }
                }
                // Process
                if (fairyChessAI != null)
                {
                    fairyChessAI.requestChangeDepth(Server.getProfileUserId(fairyChessAI), newDepth);
                }
                else
                {
                    Debug.LogError("fairyChessAI null: " + this);
                }
            }

            #endregion

            #region skillLevel

            public VP<RequestChangeIntUI.UIData> skillLevel;

            public void makeRequestChangeSkillLevel(RequestChangeUpdate<int>.UpdateData update, int newSkillLevel)
            {
                // Find
                FairyChessAI fairyChessAI = null;
                {
                    EditData<FairyChessAI> editFairyChessAI = this.editAI.v;
                    if (editFairyChessAI != null)
                    {
                        fairyChessAI = editFairyChessAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editFairyChessAI null: " + this);
                    }
                }
                // Process
                if (fairyChessAI != null)
                {
                    fairyChessAI.requestChangeSkillLevel(Server.getProfileUserId(fairyChessAI), newSkillLevel);
                }
                else
                {
                    Debug.LogError("fairyChessAI null: " + this);
                }
            }

            #endregion

            #region Duration

            public VP<RequestChangeLongUI.UIData> duration;

            public void makeRequestChangeDuration(RequestChangeUpdate<long>.UpdateData update, long newDuration)
            {
                // Find
                FairyChessAI fairyChessAI = null;
                {
                    EditData<FairyChessAI> editFairyChessAI = this.editAI.v;
                    if (editFairyChessAI != null)
                    {
                        fairyChessAI = editFairyChessAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editFairyChessAI null: " + this);
                    }
                }
                // Process
                if (fairyChessAI != null)
                {
                    fairyChessAI.requestChangeDuration(Server.getProfileUserId(fairyChessAI), newDuration);
                }
                else
                {
                    Debug.LogError("fairyChessAI null: " + this);
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
                this.editAI = new VP<EditData<FairyChessAI>>(this, (byte)Property.editAI, new EditData<FairyChessAI>());
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
                return GameType.Type.FairyChess;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbDepth;
        public static readonly TxtLanguage txtDepth = new TxtLanguage();

        public Text lbSkillLevel;
        public static readonly TxtLanguage txtSkillLevel = new TxtLanguage();

        public Text lbDuration;
        public static readonly TxtLanguage txtDuration = new TxtLanguage();

        static FairyChessAIUI()
        {
            txtTitle.add(Language.Type.vi, "Biến Thể Cờ Vua AI");
            txtDepth.add(Language.Type.vi, "Độ sâu");
            txtSkillLevel.add(Language.Type.vi, "Mức kỹ năng");
            txtDuration.add(Language.Type.vi, "Thời gian");
        }

        #endregion

        #region TransformData

        public TransformData transformData = new TransformData();

        private void updateTransformData()
        {
            this.transformData.update(this.transform);
        }

        public TransformData getTransformData()
        {
            return this.transformData;
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public Image header;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<FairyChessAI> editFairyChessAI = this.data.editAI.v;
                    if (editFairyChessAI != null)
                    {
                        editFairyChessAI.update();
                        // get show
                        FairyChessAI show = editFairyChessAI.show.v.data;
                        FairyChessAI compare = editFairyChessAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editFairyChessAI.compareOtherType.v.data != null)
                                    {
                                        if (editFairyChessAI.compareOtherType.v.data.GetType() != show.GetType())
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
                                    Debug.LogError("server null: " + this);
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
                                            updateData.canRequestChange.v = editFairyChessAI.canEdit.v;
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
                                            updateData.canRequestChange.v = editFairyChessAI.canEdit.v;
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
                                            updateData.canRequestChange.v = editFairyChessAI.canEdit.v;
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
                            Debug.LogError("fairyChessAI null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editFairyChessAI null: " + this);
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
                                        if (header != null)
                                        {
                                            header.gameObject.SetActive(true);
                                        }
                                        else
                                        {
                                            Debug.LogError("header null");
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
                                        if (header != null)
                                        {
                                            header.gameObject.SetActive(false);
                                        }
                                        else
                                        {
                                            Debug.LogError("header null");
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
                        // Set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Fairy Chess AI");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbDepth != null)
                        {
                            lbDepth.text = txtDepth.get("Depth");
                        }
                        else
                        {
                            Debug.LogError("lbDepth null: " + this);
                        }
                        if (lbSkillLevel != null)
                        {
                            lbSkillLevel.text = txtSkillLevel.get("Skill level");
                        }
                        else
                        {
                            Debug.LogError("lbSkillLevel null: " + this);
                        }
                        if (lbDuration != null)
                        {
                            lbDuration.text = txtDuration.get("Duration");
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
            updateTransformData();
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private static readonly UIRectTransform depthRect = new UIRectTransform(UIConstants.RequestRect, UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
        private static readonly UIRectTransform skillLevelRect = new UIRectTransform(UIConstants.RequestRect, UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
        private static readonly UIRectTransform durationRect = new UIRectTransform(UIConstants.RequestRect, UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);

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
                    if (data is EditData<FairyChessAI>)
                    {
                        EditData<FairyChessAI> editAI = data as EditData<FairyChessAI>;
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
                        if (data is FairyChessAI)
                        {
                            FairyChessAI fairyChessAI = data as FairyChessAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(fairyChessAI, this, ref this.server);
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
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, depthRect);
                                    break;
                                case UIData.Property.skillLevel:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, skillLevelRect);
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
                                    UIUtils.Instantiate(requestChange, requestLongPrefab, this.transform, durationRect);
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
                    if (data is EditData<FairyChessAI>)
                    {
                        EditData<FairyChessAI> editAI = data as EditData<FairyChessAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is FairyChessAI)
                        {
                            FairyChessAI fairyChessAI = data as FairyChessAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(fairyChessAI, this, ref this.server);
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
                    if (wrapProperty.p is EditData<FairyChessAI>)
                    {
                        switch ((EditData<FairyChessAI>.Property)wrapProperty.n)
                        {
                            case EditData<FairyChessAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<FairyChessAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<FairyChessAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<FairyChessAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<FairyChessAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<FairyChessAI>.Property.editType:
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
                        if (wrapProperty.p is FairyChessAI)
                        {
                            switch ((FairyChessAI.Property)wrapProperty.n)
                            {
                                case FairyChessAI.Property.depth:
                                    dirty = true;
                                    break;
                                case FairyChessAI.Property.skillLevel:
                                    dirty = true;
                                    break;
                                case FairyChessAI.Property.duration:
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