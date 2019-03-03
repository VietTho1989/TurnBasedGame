using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
    public class UndoRedoRightUI : UIBehavior<UndoRedoRightUI.UIData>, HaveTransformData
    {

        #region UIData

        public class UIData : Data
        {

            public VP<EditData<UndoRedoRight>> editUndoRedoRight;

            #region needAccept

            public VP<RequestChangeBoolUI.UIData> needAccept;

            public void makeRequestChangeNeedAccept(RequestChangeUpdate<bool>.UpdateData update, bool newNeedAccept)
            {
                // Find
                UndoRedoRight undoRedoRight = null;
                {
                    EditData<UndoRedoRight> editUndoRedoRight = this.editUndoRedoRight.v;
                    if (editUndoRedoRight != null)
                    {
                        undoRedoRight = editUndoRedoRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editUndoRedoRight null: " + this);
                    }
                }
                // Process
                if (undoRedoRight != null)
                {
                    undoRedoRight.requestChangeNeedAccept(Server.getProfileUserId(undoRedoRight), newNeedAccept);
                }
                else
                {
                    Debug.LogError("undoRedoRight null: " + this);
                }
            }

            #endregion

            #region needAdmin

            public VP<RequestChangeBoolUI.UIData> needAdmin;

            public void makeRequestChangeNeedAdmin(RequestChangeUpdate<bool>.UpdateData update, bool newNeedAdmin)
            {
                // Find
                UndoRedoRight undoRedoRight = null;
                {
                    EditData<UndoRedoRight> editUndoRedoRight = this.editUndoRedoRight.v;
                    if (editUndoRedoRight != null)
                    {
                        undoRedoRight = editUndoRedoRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editUndoRedoRight null: " + this);
                    }
                }
                // Process
                if (undoRedoRight != null)
                {
                    undoRedoRight.requestChangeNeedAdmin(Server.getProfileUserId(undoRedoRight), newNeedAdmin);
                }
                else
                {
                    Debug.LogError("undoRedoRight null: " + this);
                }
            }

            #endregion

            #region limit

            public VP<RequestChangeEnumUI.UIData> limitType;

            public void makeRequestChangeLimitType(RequestChangeUpdate<int>.UpdateData update, int newLimitType)
            {
                // Find
                UndoRedoRight undoRedoRight = null;
                {
                    EditData<UndoRedoRight> editUndoRedoRight = this.editUndoRedoRight.v;
                    if (editUndoRedoRight != null)
                    {
                        undoRedoRight = editUndoRedoRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editUndoRedoRight null: " + this);
                    }
                }
                // Process
                if (undoRedoRight != null)
                {
                    undoRedoRight.requestChangeLimitType(Server.getProfileUserId(undoRedoRight), newLimitType);
                }
                else
                {
                    Debug.LogError("undoRedoRight null: " + this);
                }
            }

            public VP<Limit.UIData> limitUIData;

            #endregion

            #region Constructor

            public enum Property
            {
                editUndoRedoRight,
                needAccept,
                needAdmin,
                limitType,
                limitUIData
            }

            public UIData() : base()
            {
                this.editUndoRedoRight = new VP<EditData<UndoRedoRight>>(this, (byte)Property.editUndoRedoRight, new EditData<UndoRedoRight>());
                // needAccept
                {
                    this.needAccept = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needAccept, new RequestChangeBoolUI.UIData());
                    this.needAccept.v.updateData.v.request.v = makeRequestChangeNeedAccept;
                }
                // needAdmin
                {
                    this.needAdmin = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needAdmin, new RequestChangeBoolUI.UIData());
                    this.needAdmin.v.updateData.v.request.v = makeRequestChangeNeedAdmin;
                }
                // limitType
                {
                    this.limitType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.limitType, new RequestChangeEnumUI.UIData());
                    this.limitType.v.updateData.v.request.v = makeRequestChangeLimitType;
                    foreach (Limit.Type type in System.Enum.GetValues(typeof(Limit.Type)))
                    {
                        this.limitType.v.options.add(type.ToString());
                    }
                }
                this.limitUIData = new VP<Limit.UIData>(this, (byte)Property.limitUIData, null);
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbNeedAccept;
        public static readonly TxtLanguage txtNeedAccept = new TxtLanguage();

        public Text lbNeedAdmin;
        public static readonly TxtLanguage txtNeedAdmin = new TxtLanguage();

        public Text lbLimitType;
        public static readonly TxtLanguage txtLimitType = new TxtLanguage();

        static UndoRedoRightUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Quyền đi lại");
                txtNeedAccept.add(Language.Type.vi, "Cần chấp nhận");
                txtNeedAdmin.add(Language.Type.vi, "Cần admin");
                txtLimitType.add(Language.Type.vi, "Loại giới hạn");
            }
            // rect
            {
                needAcceptRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                needAdminRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                limitTypeRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);
            }
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

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    EditData<UndoRedoRight> editUndoRedoRight = this.data.editUndoRedoRight.v;
                    if (editUndoRedoRight != null)
                    {
                        editUndoRedoRight.update();
                        // get show
                        UndoRedoRight show = editUndoRedoRight.show.v.data;
                        UndoRedoRight compare = editUndoRedoRight.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editUndoRedoRight.compareOtherType.v.data != null)
                                    {
                                        if (editUndoRedoRight.compareOtherType.v.data.GetType() != show.GetType())
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
                                        Debug.LogError("server null: " + this);
                                    }
                                }
                                // set origin
                                {
                                    // needAccept
                                    {
                                        RequestChangeBoolUI.UIData needAccept = this.data.needAccept.v;
                                        if (needAccept != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = needAccept.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.needAccept.v;
                                                updateData.canRequestChange.v = editUndoRedoRight.canEdit.v;
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
                                                    needAccept.showDifferent.v = true;
                                                    needAccept.compare.v = compare.needAccept.v;
                                                }
                                                else
                                                {
                                                    needAccept.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("needAccept null: " + this);
                                        }
                                    }
                                    // needAdmin
                                    {
                                        RequestChangeBoolUI.UIData needAdmin = this.data.needAdmin.v;
                                        if (needAdmin != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = needAdmin.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.needAdmin.v;
                                                updateData.canRequestChange.v = editUndoRedoRight.canEdit.v;
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
                                                    needAdmin.showDifferent.v = true;
                                                    needAdmin.compare.v = compare.needAdmin.v;
                                                }
                                                else
                                                {
                                                    needAdmin.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("needAdmin null: " + this);
                                        }
                                    }
                                    // limitType
                                    {
                                        RequestChangeEnumUI.UIData limitType = this.data.limitType.v;
                                        if (limitType != null)
                                        {
                                            // update
                                            RequestChangeUpdate<int>.UpdateData updateData = limitType.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = (int)show.getLimitType();
                                                updateData.canRequestChange.v = editUndoRedoRight.canEdit.v;
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
                                                    limitType.showDifferent.v = true;
                                                    limitType.compare.v = (int)compare.getLimitType();
                                                }
                                                else
                                                {
                                                    limitType.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("limitType null: " + this);
                                        }
                                    }
                                    // limitUIData
                                    {
                                        Limit limit = show.limit.v;
                                        if (limit != null)
                                        {
                                            // find origin 
                                            Limit originLimit = null;
                                            {
                                                UndoRedoRight originUndoRedoRight = editUndoRedoRight.origin.v.data;
                                                if (originUndoRedoRight != null)
                                                {
                                                    originLimit = originUndoRedoRight.limit.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("origin null: " + this);
                                                }
                                            }
                                            // find compare
                                            Limit compareLimit = null;
                                            {
                                                if (compare != null)
                                                {
                                                    compareLimit = compare.limit.v;
                                                }
                                                else
                                                {
                                                    // Debug.LogError ("compare null: " + this);
                                                }
                                            }
                                            switch (limit.getType())
                                            {
                                                case Limit.Type.NoLimit:
                                                    {
                                                        NoLimit noLimit = limit as NoLimit;
                                                        // Find
                                                        NoLimitUI.UIData noLimitUIData = this.data.limitUIData.newOrOld<NoLimitUI.UIData>();
                                                        // Update
                                                        {
                                                            EditData<NoLimit> editNoLimit = noLimitUIData.editNoLimit.v;
                                                            if (editNoLimit != null)
                                                            {
                                                                // origin
                                                                editNoLimit.origin.v = new ReferenceData<NoLimit>((NoLimit)originLimit);
                                                                // show
                                                                editNoLimit.show.v = new ReferenceData<NoLimit>(noLimit);
                                                                // compare
                                                                editNoLimit.compare.v = new ReferenceData<NoLimit>((NoLimit)compareLimit);
                                                                // compareOtherType
                                                                editNoLimit.compareOtherType.v = new ReferenceData<Data>(compareLimit);
                                                                // canEdit
                                                                editNoLimit.canEdit.v = editUndoRedoRight.canEdit.v;
                                                                // editType
                                                                editNoLimit.editType.v = editUndoRedoRight.editType.v;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("editNoLimit null: " + this);
                                                            }
                                                        }
                                                        this.data.limitUIData.v = noLimitUIData;
                                                    }
                                                    break;
                                                case Limit.Type.HaveLimit:
                                                    {
                                                        HaveLimit haveLimit = limit as HaveLimit;
                                                        // UIData
                                                        HaveLimitUI.UIData haveLimitUIData = this.data.limitUIData.newOrOld<HaveLimitUI.UIData>();
                                                        {
                                                            EditData<HaveLimit> editHaveLimit = haveLimitUIData.editHaveLimit.v;
                                                            if (editHaveLimit != null)
                                                            {
                                                                // origin
                                                                editHaveLimit.origin.v = new ReferenceData<HaveLimit>((HaveLimit)originLimit);
                                                                // show
                                                                editHaveLimit.show.v = new ReferenceData<HaveLimit>(haveLimit);
                                                                // compare
                                                                editHaveLimit.compare.v = new ReferenceData<HaveLimit>((HaveLimit)compareLimit);
                                                                // compareOtherType
                                                                editHaveLimit.compareOtherType.v = new ReferenceData<Data>(compareLimit);
                                                                // canEdit
                                                                editHaveLimit.canEdit.v = editUndoRedoRight.canEdit.v;
                                                                // editType
                                                                editHaveLimit.editType.v = editUndoRedoRight.editType.v;
                                                            }
                                                            else
                                                            {
                                                                Debug.LogError("editHaveLimit null: " + this);
                                                            }
                                                        }
                                                        this.data.limitUIData.v = haveLimitUIData;
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown type: " + limit.getType() + "; " + this);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("show null: " + this);
                                        }
                                    }
                                }
                            }
                            // reset
                            if (needReset)
                            {
                                needReset = false;
                                // needAccept
                                {
                                    RequestChangeBoolUI.UIData needAccept = this.data.needAccept.v;
                                    if (needAccept != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = needAccept.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.needAccept.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("needAccept null: " + this);
                                    }
                                }
                                // needAdmin
                                {
                                    RequestChangeBoolUI.UIData needAdmin = this.data.needAdmin.v;
                                    if (needAdmin != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = needAdmin.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.needAdmin.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("needAdmin null: " + this);
                                    }
                                }
                                // limitType
                                {
                                    RequestChangeEnumUI.UIData limitType = this.data.limitType.v;
                                    if (limitType != null)
                                    {
                                        // update
                                        RequestChangeUpdate<int>.UpdateData updateData = limitType.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = (int)show.getLimitType();
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("limitType null: " + this);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("show null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editUndoRedoRight null: " + this);
                    }
                    // UI Size
                    {
                        float deltaY = UIConstants.HeaderHeight;
                        // needAccept
                        {
                            deltaY += UIConstants.ItemHeight;
                        }
                        // needAdmin
                        {
                            deltaY += UIConstants.ItemHeight;
                        }
                        // limitType
                        {
                            deltaY += UIConstants.ItemHeight;
                        }
                        // limitUIData
                        deltaY += UIRectTransform.SetPosY(this.data.limitUIData.v, deltaY);
                        // set
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Undo/Redo Right");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbNeedAccept != null)
                        {
                            lbNeedAccept.text = txtNeedAccept.get("Need accept");
                        }
                        else
                        {
                            Debug.LogError("lbNeedAccept null: " + this);
                        }
                        if (lbNeedAdmin != null)
                        {
                            lbNeedAdmin.text = txtNeedAdmin.get("Need admin");
                        }
                        else
                        {
                            Debug.LogError("lbNeedAdmin null: " + this);
                        }
                        if (lbLimitType != null)
                        {
                            lbLimitType.text = txtLimitType.get("Limit type");
                        }
                        else
                        {
                            Debug.LogError("lbLimitType null: " + this);
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

        private static readonly UIRectTransform needAcceptRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform needAdminRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform limitTypeRect = new UIRectTransform(UIConstants.RequestEnumRect);

        public RequestChangeBoolUI requestBoolPrefab;
        public RequestChangeEnumUI requestEnumPrefab;

        public NoLimitUI noLimitPrefab;
        public HaveLimitUI haveLimitPrefab;

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Global
                Global.get().addCallBack(this);
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.editUndoRedoRight.allAddCallBack(this);
                    uiData.needAccept.allAddCallBack(this);
                    uiData.needAdmin.allAddCallBack(this);
                    uiData.limitType.allAddCallBack(this);
                    uiData.limitUIData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Global
            if (data is Global)
            {
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
                // editUndoRedoRight
                {
                    if (data is EditData<UndoRedoRight>)
                    {
                        EditData<UndoRedoRight> editUndoRedoRight = data as EditData<UndoRedoRight>;
                        // Child
                        {
                            editUndoRedoRight.show.allAddCallBack(this);
                            editUndoRedoRight.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is UndoRedoRight)
                        {
                            UndoRedoRight undoRedoRight = data as UndoRedoRight;
                            // Parent
                            {
                                DataUtils.addParentCallBack(undoRedoRight, this, ref this.server);
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
                // needAccept, needAdmin
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
                                case UIData.Property.needAccept:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, needAcceptRect);
                                    break;
                                case UIData.Property.needAdmin:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, needAdminRect);
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
                // limitType
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
                                case UIData.Property.limitType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, limitTypeRect);
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
                // limitUIData
                if (data is Limit.UIData)
                {
                    Limit.UIData limitUIData = data as Limit.UIData;
                    // UI
                    {
                        switch (limitUIData.getType())
                        {
                            case Limit.Type.NoLimit:
                                {
                                    NoLimitUI.UIData noLimitUIData = limitUIData as NoLimitUI.UIData;
                                    UIUtils.Instantiate(noLimitUIData, noLimitPrefab, this.transform);
                                }
                                break;
                            case Limit.Type.HaveLimit:
                                {
                                    HaveLimitUI.UIData haveLimitUIData = limitUIData as HaveLimitUI.UIData;
                                    UIUtils.Instantiate(haveLimitUIData, haveLimitPrefab, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + limitUIData.getType() + "; " + this);
                                break;
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
                // Global
                Global.get().removeCallBack(this);
                // Setting
                Setting.get().removeCallBack(this);
                // Child
                {
                    uiData.editUndoRedoRight.allRemoveCallBack(this);
                    uiData.needAccept.allRemoveCallBack(this);
                    uiData.needAdmin.allRemoveCallBack(this);
                    uiData.limitType.allRemoveCallBack(this);
                    uiData.limitUIData.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Global
            if (data is Global)
            {
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Child
            {
                // editUndoRedoRight
                {
                    if (data is EditData<UndoRedoRight>)
                    {
                        EditData<UndoRedoRight> editUndoRedoRight = data as EditData<UndoRedoRight>;
                        // Child
                        {
                            editUndoRedoRight.show.allRemoveCallBack(this);
                            editUndoRedoRight.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is UndoRedoRight)
                        {
                            UndoRedoRight undoRedoRight = data as UndoRedoRight;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(undoRedoRight, this, ref this.server);
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
                // needAccept, needAdmin
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
                    }
                    return;
                }
                // limitType
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                // limitUIData
                if (data is Limit.UIData)
                {
                    Limit.UIData limitUIData = data as Limit.UIData;
                    // UI
                    {
                        switch (limitUIData.getType())
                        {
                            case Limit.Type.NoLimit:
                                {
                                    NoLimitUI.UIData noLimitUIData = limitUIData as NoLimitUI.UIData;
                                    noLimitUIData.removeCallBackAndDestroy(typeof(NoLimitUI));
                                }
                                break;
                            case Limit.Type.HaveLimit:
                                {
                                    HaveLimitUI.UIData haveLimitUIData = limitUIData as HaveLimitUI.UIData;
                                    haveLimitUIData.removeCallBackAndDestroy(typeof(HaveLimitUI));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + limitUIData.getType() + "; " + this);
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
                    case UIData.Property.editUndoRedoRight:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.needAccept:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.needAdmin:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.limitType:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.limitUIData:
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
            // Global
            if (wrapProperty.p is Global)
            {
                Global.OnValueTransformChange(wrapProperty, this);
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
                // editUndoRedoRight
                {
                    if (wrapProperty.p is EditData<UndoRedoRight>)
                    {
                        switch ((EditData<UndoRedoRight>.Property)wrapProperty.n)
                        {
                            case EditData<UndoRedoRight>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<UndoRedoRight>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<UndoRedoRight>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<UndoRedoRight>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<UndoRedoRight>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<UndoRedoRight>.Property.editType:
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
                        if (wrapProperty.p is UndoRedoRight)
                        {
                            switch ((UndoRedoRight.Property)wrapProperty.n)
                            {
                                case UndoRedoRight.Property.needAccept:
                                    dirty = true;
                                    break;
                                case UndoRedoRight.Property.needAdmin:
                                    dirty = true;
                                    break;
                                case UndoRedoRight.Property.limit:
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
                // needAccept, needAdmin
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
                // limitType
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // limitUIData
                if (wrapProperty.p is Limit.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}