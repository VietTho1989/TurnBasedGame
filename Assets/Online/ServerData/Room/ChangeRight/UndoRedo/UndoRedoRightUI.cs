using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
    public class UndoRedoRightUI : UIHaveTransformDataBehavior<UndoRedoRightUI.UIData>
    {

        #region UIData

        public class UIData : Data, EditDataUI.UIData<UndoRedoRight>
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

            #region implement base

            public EditData<UndoRedoRight> getEditData()
            {
                return this.editUndoRedoRight.v;
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Undo/Redo Right");

        public Text lbNeedAccept;
        private static readonly TxtLanguage txtNeedAccept = new TxtLanguage("Need accept");

        public Text lbNeedAdmin;
        private static readonly TxtLanguage txtNeedAdmin = new TxtLanguage("Need admin");

        public Text lbLimitType;
        private static readonly TxtLanguage txtLimitType = new TxtLanguage("Limit type");

        static UndoRedoRightUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Quyền đi lại");
                txtNeedAccept.add(Language.Type.vi, "Cần chấp nhận");
                txtNeedAdmin.add(Language.Type.vi, "Cần admin");
                txtLimitType.add(Language.Type.vi, "Loại giới hạn");
            }
        }

        #endregion

        #region Refresh

        private bool needReset = true;

        public Image bgLimit;

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
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editUndoRedoRight);
                            // request
                            {
                                // get server state
                                Server.State.Type serverState = RequestChange.GetServerState(editUndoRedoRight);
                                // set origin
                                {
                                    RequestChange.RefreshUI(this.data.needAccept.v, editUndoRedoRight, serverState, needReset, editData => editData.needAccept.v);
                                    RequestChange.RefreshUI(this.data.needAdmin.v, editUndoRedoRight, serverState, needReset, editData => editData.needAdmin.v);
                                    // limitType
                                    {
                                        RequestChangeEnumUI.RefreshOptions(this.data.limitType.v, Limit.getStrTypes());
                                        RequestChange.RefreshUI(this.data.limitType.v, editUndoRedoRight, serverState, needReset, editData => (int)editData.getLimitType());
                                    }
                                    // limitUIData
                                    {
                                        UndoRedoRight show = editUndoRedoRight.show.v.data;
                                        UndoRedoRight compare = editUndoRedoRight.compare.v.data;
                                        if (show != null)
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
                                                                noLimitUIData.showType.v = UIRectTransform.ShowType.HeadLess;
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
                                                                haveLimitUIData.showType.v = UIRectTransform.ShowType.HeadLess;
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
                        Debug.LogError("editUndoRedoRight null: " + this);
                    }
                    // UI Size
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, UIRectTransform.ShowType.Normal, ref deltaY);
                        // needAccept
                        UIUtils.SetLabelContentPosition(lbNeedAccept, this.data.needAccept.v, ref deltaY);
                        // needAdmin
                        UIUtils.SetLabelContentPosition(lbNeedAdmin, this.data.needAdmin.v, ref deltaY);
                        // limit
                        {
                            float bgY = deltaY;
                            float bgHeight = 0;
                            // type
                            UIUtils.SetLabelContentPositionBg(lbLimitType, this.data.limitType.v, ref deltaY, ref bgHeight);
                            // UI
                            {
                                float height = UIRectTransform.SetPosY(this.data.limitUIData.v, deltaY);
                                bgHeight += height;
                                deltaY += height;
                            }
                            // bg
                            if (bgLimit != null)
                            {
                                UIRectTransform.SetPosY(bgLimit.rectTransform, bgY);
                                UIRectTransform.SetHeight(bgLimit.rectTransform, bgHeight);
                            }
                            else
                            {
                                Debug.LogError("bgLimit null");
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
                        if (lbNeedAccept != null)
                        {
                            lbNeedAccept.text = txtNeedAccept.get();
                            Setting.get().setLabelTextSize(lbNeedAccept);
                        }
                        else
                        {
                            Debug.LogError("lbNeedAccept null: " + this);
                        }
                        if (lbNeedAdmin != null)
                        {
                            lbNeedAdmin.text = txtNeedAdmin.get();
                            Setting.get().setLabelTextSize(lbNeedAdmin);
                        }
                        else
                        {
                            Debug.LogError("lbNeedAdmin null: " + this);
                        }
                        if (lbLimitType != null)
                        {
                            lbLimitType.text = txtLimitType.get();
                            Setting.get().setLabelTextSize(lbLimitType);
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
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

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
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
                                    break;
                                case UIData.Property.needAdmin:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, UIConstants.RequestBoolRect);
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
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, UIConstants.RequestEnumRect);
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