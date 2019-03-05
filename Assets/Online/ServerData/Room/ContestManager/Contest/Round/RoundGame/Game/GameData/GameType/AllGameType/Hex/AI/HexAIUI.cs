using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
    public class HexAIUI : UIHaveTransformDataBehavior<HexAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<HexAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region limitTime

            public VP<RequestChangeIntUI.UIData> limitTime;

            public void makeRequestChangeLimitTime(RequestChangeUpdate<int>.UpdateData update, int newLimitTime)
            {
                // Find hexAI
                HexAI hexAI = null;
                {
                    EditData<HexAI> editHexAI = this.editAI.v;
                    if (editHexAI != null)
                    {
                        hexAI = editHexAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editHexAI null: " + this);
                    }
                }
                // Process
                if (hexAI != null)
                {
                    hexAI.requestChangeLimitTime(Server.getProfileUserId(hexAI), newLimitTime);
                }
                else
                {
                    Debug.LogError("hexAI null: " + this);
                }
            }

            #endregion

            #region firstMoveCenter

            public VP<RequestChangeBoolUI.UIData> firstMoveCenter;

            public void makeRequestChangeFirstMoveCenter(RequestChangeUpdate<bool>.UpdateData update, bool newFirstMoveCenter)
            {
                // Find hexAI
                HexAI hexAI = null;
                {
                    EditData<HexAI> editHexAI = this.editAI.v;
                    if (editHexAI != null)
                    {
                        hexAI = editHexAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editHexAI null: " + this);
                    }
                }
                // Process
                if (hexAI != null)
                {
                    hexAI.requestChangeFirstMoveCenter(Server.getProfileUserId(hexAI), newFirstMoveCenter);
                }
                else
                {
                    Debug.LogError("hexAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                limitTime,
                firstMoveCenter
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<HexAI>>(this, (byte)Property.editAI, new EditData<HexAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // limitTime
                {
                    this.limitTime = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.limitTime, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.limitTime.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = Hex.MAX_LIMIT_TIME;
                        }
                        this.limitTime.v.limit.v = have;
                    }
                    // event
                    this.limitTime.v.updateData.v.request.v = makeRequestChangeLimitTime;
                }
                // firstMoveCenter
                {
                    this.firstMoveCenter = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.firstMoveCenter, new RequestChangeBoolUI.UIData());
                    this.firstMoveCenter.v.updateData.v.request.v = makeRequestChangeFirstMoveCenter;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Hex;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage();

        public Text lbLimitTime;
        public static readonly TxtLanguage txtLimitTime = new TxtLanguage();

        public Text lbFirstMoveCenter;
        public static readonly TxtLanguage txtFirstMoveCenter = new TxtLanguage();

        static HexAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Hex AI");
                txtLimitTime.add(Language.Type.vi, "Thời gian giới hạn");
                txtFirstMoveCenter.add(Language.Type.vi, "Nước đầu tiên vào trung tâm");
            }
            // rect
            {
                limitTimeRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                firstMoveCenterRect.setPosY(UIConstants.HeaderHeight + 1 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
            }
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
                    EditData<HexAI> editHexAI = this.data.editAI.v;
                    if (editHexAI != null)
                    {
                        // update
                        editHexAI.update();
                        // get show
                        HexAI show = editHexAI.show.v.data;
                        HexAI compare = editHexAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editHexAI.compareOtherType.v.data != null)
                                    {
                                        if (editHexAI.compareOtherType.v.data.GetType() != show.GetType())
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
                                // limitTime
                                {
                                    RequestChangeIntUI.UIData limitTime = this.data.limitTime.v;
                                    if (limitTime != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = limitTime.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.limitTime.v;
                                            updateData.canRequestChange.v = editHexAI.canEdit.v;
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
                                                limitTime.showDifferent.v = true;
                                                limitTime.compare.v = compare.limitTime.v;
                                            }
                                            else
                                            {
                                                limitTime.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("limitTime null: " + this);
                                    }
                                }
                                // firstMoveCenter
                                {
                                    RequestChangeBoolUI.UIData firstMoveCenter = this.data.firstMoveCenter.v;
                                    if (firstMoveCenter != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<bool>.UpdateData updateData = firstMoveCenter.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.firstMoveCenter.v;
                                            updateData.canRequestChange.v = editHexAI.canEdit.v;
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
                                                firstMoveCenter.showDifferent.v = true;
                                                firstMoveCenter.compare.v = compare.firstMoveCenter.v;
                                            }
                                            else
                                            {
                                                firstMoveCenter.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("firstMoveCenter null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // limitTime
                                {
                                    RequestChangeIntUI.UIData limitTime = this.data.limitTime.v;
                                    if (limitTime != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = limitTime.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.limitTime.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("limitTime null: " + this);
                                    }
                                }
                                // firstMoveCenter
                                {
                                    RequestChangeBoolUI.UIData firstMoveCenter = this.data.firstMoveCenter.v;
                                    if (firstMoveCenter != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<bool>.UpdateData updateData = firstMoveCenter.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.firstMoveCenter.v;
                                            updateData.changeState.v = Data.ChangeState.None;
                                        }
                                        else
                                        {
                                            Debug.LogError("updateData null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("firstMoveCenter null: " + this);
                                    }
                                }
                            }
                        }
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
                        // limitTime
                        {
                            if (this.data.limitTime.v != null)
                            {
                                if (lbLimitTime != null)
                                {
                                    lbLimitTime.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbLimitTime.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbLimitTime null");
                                }
                                UIRectTransform.SetPosY(this.data.limitTime.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbLimitTime != null)
                                {
                                    lbLimitTime.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbLimitTime null");
                                }
                            }
                        }
                        // firstMoveCenter
                        {
                            if (this.data.firstMoveCenter.v != null)
                            {
                                if (lbFirstMoveCenter != null)
                                {
                                    lbFirstMoveCenter.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbFirstMoveCenter.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbFirstMoveCenter null");
                                }
                                UIRectTransform.SetPosY(this.data.firstMoveCenter.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestBoolDim) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbFirstMoveCenter != null)
                                {
                                    lbFirstMoveCenter.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbFirstMoveCenter null");
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
                            lbTitle.text = txtTitle.get("Hex AI");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbLimitTime != null)
                        {
                            lbLimitTime.text = txtLimitTime.get("Limit time");
                        }
                        else
                        {
                            Debug.LogError("lbLimitTime null: " + this);
                        }
                        if (lbFirstMoveCenter != null)
                        {
                            lbFirstMoveCenter.text = txtFirstMoveCenter.get("First move center");
                        }
                        else
                        {
                            Debug.LogError("lbFirstMoveCenter null: " + this);
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

        public static readonly UIRectTransform limitTimeRect = new UIRectTransform(UIConstants.RequestRect);
        public static readonly UIRectTransform firstMoveCenterRect = new UIRectTransform(UIConstants.RequestBoolRect);

        public RequestChangeIntUI requestIntPrefab;
        public RequestChangeBoolUI requestBoolPrefab;

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
                    uiData.limitTime.allAddCallBack(this);
                    uiData.firstMoveCenter.allAddCallBack(this);
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
                    if (data is EditData<HexAI>)
                    {
                        EditData<HexAI> editAI = data as EditData<HexAI>;
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
                        if (data is HexAI)
                        {
                            HexAI hexAI = data as HexAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(hexAI, this, ref this.server);
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
                                case UIData.Property.limitTime:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, limitTimeRect);
                                    }
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
                                case UIData.Property.firstMoveCenter:
                                    {
                                        UIUtils.Instantiate(requestChange, requestBoolPrefab, this.transform, firstMoveCenterRect);
                                    }
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
                    uiData.limitTime.allRemoveCallBack(this);
                    uiData.firstMoveCenter.allRemoveCallBack(this);
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
                    if (data is EditData<HexAI>)
                    {
                        EditData<HexAI> editAI = data as EditData<HexAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is HexAI)
                        {
                            HexAI hexAI = data as HexAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(hexAI, this, ref this.server);
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
                if (data is RequestChangeIntUI.UIData)
                {
                    RequestChangeIntUI.UIData requestChange = data as RequestChangeIntUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeIntUI));
                    }
                    return;
                }
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
                    case UIData.Property.editAI:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.showType:
                        dirty = true;
                        break;
                    case UIData.Property.limitTime:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.firstMoveCenter:
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
                    if (wrapProperty.p is EditData<HexAI>)
                    {
                        switch ((EditData<HexAI>.Property)wrapProperty.n)
                        {
                            case EditData<HexAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<HexAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<HexAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<HexAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<HexAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<HexAI>.Property.editType:
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
                        if (wrapProperty.p is HexAI)
                        {
                            switch ((HexAI.Property)wrapProperty.n)
                            {
                                case HexAI.Property.limitTime:
                                    dirty = true;
                                    break;
                                case HexAI.Property.firstMoveCenter:
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
                if (wrapProperty.p is RequestChangeIntUI.UIData)
                {
                    return;
                }
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}