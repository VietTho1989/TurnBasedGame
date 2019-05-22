using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
    public class SolitaireAIUI : UIHaveTransformDataBehavior<SolitaireAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<SolitaireAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region multiThreaded

            public VP<RequestChangeIntUI.UIData> multiThreaded;

            public void makeRequestChangeMultiThreaded(RequestChangeUpdate<int>.UpdateData update, int newMultiThreaded)
            {
                // Find
                SolitaireAI solitaireAI = null;
                {
                    EditData<SolitaireAI> editSolitaireAI = this.editAI.v;
                    if (editSolitaireAI != null)
                    {
                        solitaireAI = editSolitaireAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSolitaireAI null: " + this);
                    }
                }
                // Process
                if (solitaireAI != null)
                {
                    solitaireAI.requestChangeMultiThreaded(Server.getProfileUserId(solitaireAI), newMultiThreaded);
                }
                else
                {
                    Debug.LogError("solitaireAI null: " + this);
                }
            }

            #endregion

            #region maxClosedCount

            public VP<RequestChangeIntUI.UIData> maxClosedCount;

            public void makeRequestChangeMaxClosedCount(RequestChangeUpdate<int>.UpdateData update, int newMaxClosedCount)
            {
                // Find
                SolitaireAI solitaireAI = null;
                {
                    EditData<SolitaireAI> editSolitaireAI = this.editAI.v;
                    if (editSolitaireAI != null)
                    {
                        solitaireAI = editSolitaireAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSolitaireAI null: " + this);
                    }
                }
                // Process
                if (solitaireAI != null)
                {
                    solitaireAI.requestChangeMaxClosedCount(Server.getProfileUserId(solitaireAI), newMaxClosedCount);
                }
                else
                {
                    Debug.LogError("solitaireAI null: " + this);
                }
            }

            #endregion

            #region fastMode

            public VP<RequestChangeBoolUI.UIData> fastMode;

            public void makeRequestChangeFastMode(RequestChangeUpdate<bool>.UpdateData update, bool newFastMode)
            {
                // Find
                SolitaireAI solitaireAI = null;
                {
                    EditData<SolitaireAI> editSolitaireAI = this.editAI.v;
                    if (editSolitaireAI != null)
                    {
                        solitaireAI = editSolitaireAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editSolitaireAI null: " + this);
                    }
                }
                // Process
                if (solitaireAI != null)
                {
                    solitaireAI.requestChangeFastMode(Server.getProfileUserId(solitaireAI), newFastMode);
                }
                else
                {
                    Debug.LogError("solitaireAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                multiThreaded,
                maxClosedCount,
                fastMode
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<SolitaireAI>>(this, (byte)Property.editAI, new EditData<SolitaireAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // multiThreaded
                {
                    this.multiThreaded = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.multiThreaded, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.multiThreaded.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 5;
                        }
                        this.multiThreaded.v.limit.v = have;
                    }
                    // event
                    this.multiThreaded.v.updateData.v.request.v = makeRequestChangeMultiThreaded;
                }
                // maxClosedCount
                {
                    this.maxClosedCount = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.maxClosedCount, new RequestChangeIntUI.UIData());
                    // event
                    this.maxClosedCount.v.updateData.v.request.v = makeRequestChangeMaxClosedCount;
                }
                // fastMode
                {
                    this.fastMode = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.fastMode, new RequestChangeBoolUI.UIData());
                    // event
                    this.fastMode.v.updateData.v.request.v = makeRequestChangeFastMode;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Solitaire;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.Solitaire ? 1 : 0;
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Solitaire AI");

        public Text lbMultiThreaded;
        private static readonly TxtLanguage txtMultiThreaded = new TxtLanguage("MultiThreaded");

        public Text lbMaxClosedCount;
        private static readonly TxtLanguage txtMaxClosedCount = new TxtLanguage("Max closed count");

        public Text lbFastMode;
        private static readonly TxtLanguage txtFastMode = new TxtLanguage("Fast mode");

        static SolitaireAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "AI Solitaire");
                txtMultiThreaded.add(Language.Type.vi, "Đa luồng");
                txtMaxClosedCount.add(Language.Type.vi, "Max closed count");
                txtFastMode.add(Language.Type.vi, "Kiểu nhanh");
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
                    EditData<SolitaireAI> editSolitaireAI = this.data.editAI.v;
                    if (editSolitaireAI != null)
                    {
                        editSolitaireAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editSolitaireAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editSolitaireAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.multiThreaded.v, editSolitaireAI, serverState, needReset, editData => editData.multiThreaded.v);
                                RequestChange.RefreshUI(this.data.maxClosedCount.v, editSolitaireAI, serverState, needReset, editData => editData.maxClosedCount.v);
                                RequestChange.RefreshUI(this.data.fastMode.v, editSolitaireAI, serverState, needReset, editData => editData.fastMode.v);
                            }
                            needReset = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("editSolitaireAI null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // multiThreaded
                        UIUtils.SetLabelContentPosition(lbMultiThreaded, this.data.multiThreaded.v, ref deltaY);
                        // maxClosedCount
                        UIUtils.SetLabelContentPosition(lbMaxClosedCount, this.data.maxClosedCount.v, ref deltaY);
                        // fastMode
                        UIUtils.SetLabelContentPosition(lbFastMode, this.data.fastMode.v, ref deltaY);
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
                        if (lbMultiThreaded != null)
                        {
                            lbMultiThreaded.text = txtMultiThreaded.get();
                            Setting.get().setLabelTextSize(lbMultiThreaded);
                        }
                        else
                        {
                            Debug.LogError("lbMultiThreaded null: " + this);
                        }
                        if (lbMaxClosedCount != null)
                        {
                            lbMaxClosedCount.text = txtMaxClosedCount.get();
                            Setting.get().setLabelTextSize(lbMaxClosedCount);
                        }
                        else
                        {
                            Debug.LogError("lbMaxClosedCount null: " + this);
                        }
                        if (lbFastMode != null)
                        {
                            lbFastMode.text = txtFastMode.get();
                            Setting.get().setLabelTextSize(lbFastMode);
                        }
                        else
                        {
                            Debug.LogError("lbFastMode null: " + this);
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
                    uiData.multiThreaded.allAddCallBack(this);
                    uiData.maxClosedCount.allAddCallBack(this);
                    uiData.fastMode.allAddCallBack(this);
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
                    if (data is EditData<SolitaireAI>)
                    {
                        EditData<SolitaireAI> editAI = data as EditData<SolitaireAI>;
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
                        if (data is SolitaireAI)
                        {
                            SolitaireAI solitaireAI = data as SolitaireAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(solitaireAI, this, ref this.server);
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
                                case UIData.Property.multiThreaded:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestInt, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.maxClosedCount:
                                    UIUtils.Instantiate(requestChange, GlobalPrefab.instance.requestInt, this.transform, UIConstants.RequestRect);
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
                                case UIData.Property.fastMode:
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
                    uiData.multiThreaded.allRemoveCallBack(this);
                    uiData.maxClosedCount.allRemoveCallBack(this);
                    uiData.fastMode.allRemoveCallBack(this);
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
                    if (data is EditData<SolitaireAI>)
                    {
                        EditData<SolitaireAI> editAI = data as EditData<SolitaireAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is SolitaireAI)
                        {
                            SolitaireAI solitaireAI = data as SolitaireAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(solitaireAI, this, ref this.server);
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
                    case UIData.Property.multiThreaded:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.maxClosedCount:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.fastMode:
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
                // editAI
                {
                    if (wrapProperty.p is EditData<SolitaireAI>)
                    {
                        switch ((EditData<SolitaireAI>.Property)wrapProperty.n)
                        {
                            case EditData<SolitaireAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<SolitaireAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<SolitaireAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<SolitaireAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<SolitaireAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<SolitaireAI>.Property.editType:
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
                        if (wrapProperty.p is SolitaireAI)
                        {
                            switch ((SolitaireAI.Property)wrapProperty.n)
                            {
                                case SolitaireAI.Property.multiThreaded:
                                    dirty = true;
                                    break;
                                case SolitaireAI.Property.maxClosedCount:
                                    dirty = true;
                                    break;
                                case SolitaireAI.Property.fastMode:
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