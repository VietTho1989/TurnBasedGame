using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class ChangeGamePlayerRightUI : UIHaveTransformDataBehavior<ChangeGamePlayerRightUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<EditData<ChangeGamePlayerRight>> editChangeGamePlayerRight;

            #region canChange

            public VP<RequestChangeBoolUI.UIData> canChange;

            public void makeRequestChangeCanChange(RequestChangeUpdate<bool>.UpdateData update, bool newCanChange)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeCanChange(Server.getProfileUserId(changeGamePlayerRight), newCanChange);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region canChangePlayerLeft

            public VP<RequestChangeBoolUI.UIData> canChangePlayerLeft;

            public void makeRequestChangeCanChangePlayerLeft(RequestChangeUpdate<bool>.UpdateData update, bool newCanChangePlayerLeft)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeCanChangePlayerLeft(Server.getProfileUserId(changeGamePlayerRight), newCanChangePlayerLeft);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region needAdminAccept

            public VP<RequestChangeBoolUI.UIData> needAdminAccept;

            public void makeRequestChangeNeedAdminAccept(RequestChangeUpdate<bool>.UpdateData update, bool newNeedAdminAccept)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeNeedAdminAccept(Server.getProfileUserId(changeGamePlayerRight), newNeedAdminAccept);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region onlyAdminNeed

            public VP<RequestChangeBoolUI.UIData> onlyAdminNeed;

            public void makeRequestChangeOnlyAdminNeed(RequestChangeUpdate<bool>.UpdateData update, bool newOnlyAdminNeed)
            {
                // Find
                ChangeGamePlayerRight changeGamePlayerRight = null;
                {
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        changeGamePlayerRight = editChangeGamePlayerRight.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editChangeGamePlayerRight null: " + this);
                    }
                }
                // Process
                if (changeGamePlayerRight != null)
                {
                    changeGamePlayerRight.requestChangeOnlyAdminNeed(Server.getProfileUserId(changeGamePlayerRight), newOnlyAdminNeed);
                }
                else
                {
                    Debug.LogError("changeGamePlayerRight null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editChangeGamePlayerRight,
                canChange,
                canChangePlayerLeft,
                needAdminAccept,
                onlyAdminNeed
            }

            public UIData() : base()
            {
                this.editChangeGamePlayerRight = new VP<EditData<ChangeGamePlayerRight>>(this, (byte)Property.editChangeGamePlayerRight, new EditData<ChangeGamePlayerRight>());
                // canChange
                {
                    this.canChange = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canChange, new RequestChangeBoolUI.UIData());
                    this.canChange.v.updateData.v.request.v = makeRequestChangeCanChange;
                }
                // canChangePlayerLeft
                {
                    this.canChangePlayerLeft = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.canChangePlayerLeft, new RequestChangeBoolUI.UIData());
                    this.canChangePlayerLeft.v.updateData.v.request.v = makeRequestChangeCanChangePlayerLeft;
                }
                // needAdminAccept
                {
                    this.needAdminAccept = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.needAdminAccept, new RequestChangeBoolUI.UIData());
                    this.needAdminAccept.v.updateData.v.request.v = makeRequestChangeNeedAdminAccept;
                }
                // onlyAdminNeed
                {
                    this.onlyAdminNeed = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.onlyAdminNeed, new RequestChangeBoolUI.UIData());
                    this.onlyAdminNeed.v.updateData.v.request.v = makeRequestChangeOnlyAdminNeed;
                }
            }

            #endregion

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Change Game Player Rights");

        public Text lbCanChange;
        private static readonly TxtLanguage txtCanChange = new TxtLanguage("Can change");

        public Text lbCanChangePlayerLeft;
        private static readonly TxtLanguage txtCanChangePlayerLeft = new TxtLanguage("Can change player left");

        public Text lbNeedAdminAccept;
        private static readonly TxtLanguage txtNeedAdminAccept = new TxtLanguage("Need admin accepted");

        public Text lbOnlyAdminNeed;
        private static readonly TxtLanguage txtOnlyAdminNeed = new TxtLanguage("Only admin needed");

        static ChangeGamePlayerRightUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Quyền Thay Đổi Người Chơi");
                txtCanChange.add(Language.Type.vi, "Có thể đổi");
                txtCanChangePlayerLeft.add(Language.Type.vi, "Có thể đổi người đã rời");
                txtNeedAdminAccept.add(Language.Type.vi, "Cần admin chấp nhận");
                txtOnlyAdminNeed.add(Language.Type.vi, "Chỉ cần admin");
            }
            // rect
            {
                canChangeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                canChangePlayerLeftRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                needAdminAcceptRect.setPosY(UIConstants.HeaderHeight + 2 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                onlyAdminNeedRect.setPosY(UIConstants.HeaderHeight + 3 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
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
                    EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = this.data.editChangeGamePlayerRight.v;
                    if (editChangeGamePlayerRight != null)
                    {
                        editChangeGamePlayerRight.update();
                        // get show
                        ChangeGamePlayerRight show = editChangeGamePlayerRight.show.v.data;
                        ChangeGamePlayerRight compare = editChangeGamePlayerRight.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editChangeGamePlayerRight.compareOtherType.v.data != null)
                                    {
                                        if (editChangeGamePlayerRight.compareOtherType.v.data.GetType() != show.GetType())
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
                                    // canChange
                                    {
                                        RequestChangeBoolUI.UIData canChange = this.data.canChange.v;
                                        if (canChange != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = canChange.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.canChange.v;
                                                updateData.canRequestChange.v = editChangeGamePlayerRight.canEdit.v;
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
                                                    canChange.showDifferent.v = true;
                                                    canChange.compare.v = compare.canChange.v;
                                                }
                                                else
                                                {
                                                    canChange.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("canChange null: " + this);
                                        }
                                    }
                                    // canChangePlayerLeft
                                    {
                                        RequestChangeBoolUI.UIData canChangePlayerLeft = this.data.canChangePlayerLeft.v;
                                        if (canChangePlayerLeft != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = canChangePlayerLeft.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.canChangePlayerLeft.v;
                                                updateData.canRequestChange.v = editChangeGamePlayerRight.canEdit.v;
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
                                                    canChangePlayerLeft.showDifferent.v = true;
                                                    canChangePlayerLeft.compare.v = compare.canChangePlayerLeft.v;
                                                }
                                                else
                                                {
                                                    canChangePlayerLeft.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("canChangePlayerLeft null: " + this);
                                        }
                                    }
                                    // needAdminAccept
                                    {
                                        RequestChangeBoolUI.UIData needAdminAccept = this.data.needAdminAccept.v;
                                        if (needAdminAccept != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = needAdminAccept.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.needAdminAccept.v;
                                                updateData.canRequestChange.v = editChangeGamePlayerRight.canEdit.v;
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
                                                    needAdminAccept.showDifferent.v = true;
                                                    needAdminAccept.compare.v = compare.needAdminAccept.v;
                                                }
                                                else
                                                {
                                                    needAdminAccept.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("needAdminAccept null: " + this);
                                        }
                                    }
                                    // onlyAdminNeed
                                    {
                                        RequestChangeBoolUI.UIData onlyAdminNeed = this.data.onlyAdminNeed.v;
                                        if (onlyAdminNeed != null)
                                        {
                                            // update
                                            RequestChangeUpdate<bool>.UpdateData updateData = onlyAdminNeed.updateData.v;
                                            if (updateData != null)
                                            {
                                                updateData.origin.v = show.onlyAdminNeed.v;
                                                updateData.canRequestChange.v = editChangeGamePlayerRight.canEdit.v;
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
                                                    onlyAdminNeed.showDifferent.v = true;
                                                    onlyAdminNeed.compare.v = compare.onlyAdminNeed.v;
                                                }
                                                else
                                                {
                                                    onlyAdminNeed.showDifferent.v = false;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("onlyAdminNeed null: " + this);
                                        }
                                    }
                                }
                            }
                            // reset
                            if (needReset)
                            {
                                needReset = false;
                                // canChange
                                {
                                    RequestChangeBoolUI.UIData canChange = this.data.canChange.v;
                                    if (canChange != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = canChange.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.canChange.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("canChange null: " + this);
                                    }
                                }
                                // canChangePlayerLeft
                                {
                                    RequestChangeBoolUI.UIData canChangePlayerLeft = this.data.canChangePlayerLeft.v;
                                    if (canChangePlayerLeft != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = canChangePlayerLeft.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.canChangePlayerLeft.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("canChangePlayerLeft null: " + this);
                                    }
                                }
                                // needAdminAccept
                                {
                                    RequestChangeBoolUI.UIData needAdminAccept = this.data.needAdminAccept.v;
                                    if (needAdminAccept != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = needAdminAccept.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.needAdminAccept.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("needAdminAccept null: " + this);
                                    }
                                }
                                // onlyAdminNeed
                                {
                                    RequestChangeBoolUI.UIData onlyAdminNeed = this.data.onlyAdminNeed.v;
                                    if (onlyAdminNeed != null)
                                    {
                                        // update
                                        RequestChangeUpdate<bool>.UpdateData updateData = onlyAdminNeed.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.onlyAdminNeed.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("onlyAdminNeed null: " + this);
                                    }
                                }
                            }
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
                        if (lbCanChange != null)
                        {
                            lbCanChange.text = txtCanChange.get();
                        }
                        else
                        {
                            Debug.LogError("lbCanChange null");
                        }
                        if (lbCanChangePlayerLeft != null)
                        {
                            lbCanChangePlayerLeft.text = txtCanChangePlayerLeft.get();
                        }
                        else
                        {
                            Debug.LogError("lbCanChangePlayerLeft null");
                        }
                        if (lbNeedAdminAccept != null)
                        {
                            lbNeedAdminAccept.text = txtNeedAdminAccept.get();
                        }
                        else
                        {
                            Debug.LogError("lbNeedAdminAccept null");
                        }
                        if (lbOnlyAdminNeed != null)
                        {
                            lbOnlyAdminNeed.text = txtOnlyAdminNeed.get();
                        }
                        else
                        {
                            Debug.LogError("lbOnlyAdminNeed null");
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

        private static readonly UIRectTransform canChangeRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform canChangePlayerLeftRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform needAdminAcceptRect = new UIRectTransform(UIConstants.RequestBoolRect);
        private static readonly UIRectTransform onlyAdminNeedRect = new UIRectTransform(UIConstants.RequestBoolRect);

        public RequestChangeBoolUI requestBoolPrefab;

        private Server server = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.editChangeGamePlayerRight.allAddCallBack(this);
                    uiData.canChange.allAddCallBack(this);
                    uiData.canChangePlayerLeft.allAddCallBack(this);
                    uiData.needAdminAccept.allAddCallBack(this);
                    uiData.onlyAdminNeed.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                // editChangeGamePlayerRight
                {
                    if (data is EditData<ChangeGamePlayerRight>)
                    {
                        EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = data as EditData<ChangeGamePlayerRight>;
                        // Child
                        {
                            editChangeGamePlayerRight.show.allAddCallBack(this);
                            editChangeGamePlayerRight.compare.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeGamePlayerRight)
                        {
                            ChangeGamePlayerRight changeGamePlayerRight = data as ChangeGamePlayerRight;
                            // Parent
                            {
                                DataUtils.addParentCallBack(changeGamePlayerRight, this, ref this.server);
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
                // canChange, canChangePlayerLeft, needAdminAccept, onlyAdminNeed
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
                                case UIData.Property.canChange:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, canChangeRect);
                                    break;
                                case UIData.Property.canChangePlayerLeft:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, canChangePlayerLeftRect);
                                    break;
                                case UIData.Property.needAdminAccept:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, needAdminAcceptRect);
                                    break;
                                case UIData.Property.onlyAdminNeed:
                                    UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, onlyAdminNeedRect);
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
                // Child
                {
                    uiData.editChangeGamePlayerRight.allRemoveCallBack(this);
                    uiData.canChange.allRemoveCallBack(this);
                    uiData.canChangePlayerLeft.allRemoveCallBack(this);
                    uiData.needAdminAccept.allRemoveCallBack(this);
                    uiData.onlyAdminNeed.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                // editChangeGamePlayerRight
                {
                    if (data is EditData<ChangeGamePlayerRight>)
                    {
                        EditData<ChangeGamePlayerRight> editChangeGamePlayerRight = data as EditData<ChangeGamePlayerRight>;
                        // Child
                        {
                            editChangeGamePlayerRight.show.allRemoveCallBack(this);
                            editChangeGamePlayerRight.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeGamePlayerRight)
                        {
                            ChangeGamePlayerRight changeGamePlayerRight = data as ChangeGamePlayerRight;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(changeGamePlayerRight, this, ref this.server);
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
                // canChange, canChangePlayerLeft, needAdminAccept, onlyAdminNeed
                if (data is RequestChangeBoolUI.UIData)
                {
                    RequestChangeBoolUI.UIData requestChange = data as RequestChangeBoolUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeBoolUI));
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
                    case UIData.Property.editChangeGamePlayerRight:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.canChange:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.canChangePlayerLeft:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.needAdminAccept:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.onlyAdminNeed:
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
                // editChangeGamePlayerRight
                {
                    if (wrapProperty.p is EditData<ChangeGamePlayerRight>)
                    {
                        switch ((EditData<ChangeGamePlayerRight>.Property)wrapProperty.n)
                        {
                            case EditData<ChangeGamePlayerRight>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<ChangeGamePlayerRight>.Property.editType:
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
                        if (wrapProperty.p is ChangeGamePlayerRight)
                        {
                            switch ((ChangeGamePlayerRight.Property)wrapProperty.n)
                            {
                                case ChangeGamePlayerRight.Property.canChange:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.canChangePlayerLeft:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.needAdminAccept:
                                    dirty = true;
                                    break;
                                case ChangeGamePlayerRight.Property.onlyAdminNeed:
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
                // canChange, canChangePlayerLeft, needAdminAccept, onlyAdminNeed
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
        }

        #endregion

    }
}