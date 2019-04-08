using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
    public class JanggiAIUI : UIHaveTransformDataBehavior<JanggiAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<JanggiAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region maxVisitCount

            public VP<RequestChangeIntUI.UIData> maxVisitCount;

            public void makeRequestChangeMaxVisitCount(RequestChangeUpdate<int>.UpdateData update, int newMaxVisitCount)
            {
                // Find janggiAI
                JanggiAI janggiAI = null;
                {
                    EditData<JanggiAI> editJanggiAI = this.editAI.v;
                    if (editJanggiAI != null)
                    {
                        janggiAI = editJanggiAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editJanggiAI null: " + this);
                    }
                }
                // Process
                if (janggiAI != null)
                {
                    janggiAI.requestChangeMaxVisitCount(Server.getProfileUserId(janggiAI), newMaxVisitCount);
                }
                else
                {
                    Debug.LogError("janggiAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                maxVisitCount
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<JanggiAI>>(this, (byte)Property.editAI, new EditData<JanggiAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // maxVisitCount
                {
                    this.maxVisitCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxVisitCount, new RequestChangeIntUI.UIData());
                    // event
                    this.maxVisitCount.v.updateData.v.request.v = makeRequestChangeMaxVisitCount;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Janggi;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Janggi AI");

        public Text lbMaxVisitCount;
        private static readonly TxtLanguage txtMaxVisitCount = new TxtLanguage("Max node visit count");

        static JanggiAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "Cờ Tướng Triều Tiên AI");
                txtMaxVisitCount.add(Language.Type.vi, "Số nốt thăm tối đa");
            }
            // rect
            {
                maxVisitCountRect.setPosY(UIConstants.HeaderHeight + 0 * UIConstants.ItemHeight + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
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
                    EditData<JanggiAI> editJanggiAI = this.data.editAI.v;
                    if (editJanggiAI != null)
                    {
                        // update
                        editJanggiAI.update();
                        // get show
                        JanggiAI show = editJanggiAI.show.v.data;
                        JanggiAI compare = editJanggiAI.compare.v.data;
                        if (show != null)
                        {
                            // different
                            if (lbTitle != null)
                            {
                                bool isDifferent = false;
                                {
                                    if (editJanggiAI.compareOtherType.v.data != null)
                                    {
                                        if (editJanggiAI.compareOtherType.v.data.GetType() != show.GetType())
                                        {
                                            isDifferent = true;
                                        }
                                    }
                                }
                                lbTitle.color = isDifferent ? UIConstants.DifferentIndicatorColor : UIConstants.NormalTitleColor;
                            }
                            else
                            {
                                Debug.LogError("different null: " + this);
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
                                // maxVisitCount
                                {
                                    RequestChangeIntUI.UIData maxVisitCount = this.data.maxVisitCount.v;
                                    if (maxVisitCount != null)
                                    {
                                        // updateData
                                        RequestChangeUpdate<int>.UpdateData updateData = maxVisitCount.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.origin.v = show.maxVisitCount.v;
                                            updateData.canRequestChange.v = editJanggiAI.canEdit.v;
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
                                                maxVisitCount.showDifferent.v = true;
                                                maxVisitCount.compare.v = compare.maxVisitCount.v;
                                            }
                                            else
                                            {
                                                maxVisitCount.showDifferent.v = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("depth null: " + this);
                                    }
                                }
                            }
                            // reset?
                            if (needReset)
                            {
                                needReset = false;
                                // maxVisitCount
                                {
                                    RequestChangeIntUI.UIData maxVisitCount = this.data.maxVisitCount.v;
                                    if (maxVisitCount != null)
                                    {
                                        RequestChangeUpdate<int>.UpdateData updateData = maxVisitCount.updateData.v;
                                        if (updateData != null)
                                        {
                                            updateData.current.v = show.maxVisitCount.v;
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
                            }
                        }
                        else
                        {
                            Debug.LogError("janggiAI null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("editJanggiAI null: " + this);
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
                        // maxVisitCount
                        {
                            if (this.data.maxVisitCount.v != null)
                            {
                                if (lbMaxVisitCount != null)
                                {
                                    lbMaxVisitCount.gameObject.SetActive(true);
                                    UIRectTransform.SetPosY(lbMaxVisitCount.rectTransform, deltaY);
                                }
                                else
                                {
                                    Debug.LogError("lbMaxVisitCount null");
                                }
                                UIRectTransform.SetPosY(this.data.maxVisitCount.v, deltaY + (UIConstants.ItemHeight - UIConstants.RequestHeight) / 2.0f);
                                deltaY += UIConstants.ItemHeight;
                            }
                            else
                            {
                                if (lbMaxVisitCount != null)
                                {
                                    lbMaxVisitCount.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("lbMaxVisitCount null");
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
                        if (lbMaxVisitCount != null)
                        {
                            lbMaxVisitCount.text = txtMaxVisitCount.get();
                            Setting.get().setLabelTextSize(lbMaxVisitCount);
                        }
                        else
                        {
                            Debug.LogError("lbMaxVisitCount null: " + this);
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

        private static readonly UIRectTransform maxVisitCountRect = new UIRectTransform(UIConstants.RequestRect);

        public RequestChangeIntUI requestIntPrefab;

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
                    uiData.maxVisitCount.allAddCallBack(this);
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
                    if (data is EditData<JanggiAI>)
                    {
                        EditData<JanggiAI> editAI = data as EditData<JanggiAI>;
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
                        if (data is JanggiAI)
                        {
                            JanggiAI janggiAI = data as JanggiAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(janggiAI, this, ref this.server);
                            }
                            dirty = true;
                            needReset = true;
                            return;
                        }
                        // Parent
                        if (data is Server)
                        {
                            dirty = true;
                            return;
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
                                case UIData.Property.maxVisitCount:
                                    {
                                        UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, maxVisitCountRect);
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
                    uiData.maxVisitCount.allRemoveCallBack(this);
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
                    if (data is EditData<JanggiAI>)
                    {
                        EditData<JanggiAI> editAI = data as EditData<JanggiAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is JanggiAI)
                        {
                            JanggiAI janggiAI = data as JanggiAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(janggiAI, this, ref this.server);
                            }
                            return;
                        }
                        // Parent
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
                    case UIData.Property.maxVisitCount:
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
                    if (wrapProperty.p is EditData<JanggiAI>)
                    {
                        switch ((EditData<JanggiAI>.Property)wrapProperty.n)
                        {
                            case EditData<JanggiAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<JanggiAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<JanggiAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<JanggiAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<JanggiAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<JanggiAI>.Property.editType:
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
                        if (wrapProperty.p is JanggiAI)
                        {
                            switch ((JanggiAI.Property)wrapProperty.n)
                            {
                                case JanggiAI.Property.maxVisitCount:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Parent
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}