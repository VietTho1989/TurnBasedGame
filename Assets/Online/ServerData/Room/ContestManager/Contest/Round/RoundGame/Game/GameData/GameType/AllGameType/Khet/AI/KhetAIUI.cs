using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
    public class KhetAIUI : UIHaveTransformDataBehavior<KhetAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<KhetAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region infinite

            public VP<RequestChangeBoolUI.UIData> infinite;

            public void makeRequestChangeInfinite(RequestChangeUpdate<bool>.UpdateData update, bool newInfinite)
            {
                // Find
                KhetAI khetAI = null;
                {
                    EditData<KhetAI> editKhetAI = this.editAI.v;
                    if (editKhetAI != null)
                    {
                        khetAI = editKhetAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editKhetAI null: " + this);
                    }
                }
                // Process
                if (khetAI != null)
                {
                    khetAI.requestChangeInfinite(Server.getProfileUserId(khetAI), newInfinite);
                }
                else
                {
                    Debug.LogError("khetAI null: " + this);
                }
            }

            #endregion

            #region moveTime

            public VP<RequestChangeIntUI.UIData> moveTime;

            public void makeRequestChangeMoveTime(RequestChangeUpdate<int>.UpdateData update, int newMoveTime)
            {
                // Find
                KhetAI khetAI = null;
                {
                    EditData<KhetAI> editKhetAI = this.editAI.v;
                    if (editKhetAI != null)
                    {
                        khetAI = editKhetAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editKhetAI null: " + this);
                    }
                }
                // Process
                if (khetAI != null)
                {
                    khetAI.requestChangeMoveTime(Server.getProfileUserId(khetAI), newMoveTime);
                }
                else
                {
                    Debug.LogError("khetAI null: " + this);
                }
            }

            #endregion

            #region depth

            public VP<RequestChangeIntUI.UIData> depth;

            public void makeRequestChangeDepth(RequestChangeUpdate<int>.UpdateData update, int newDepth)
            {
                // Find
                KhetAI khetAI = null;
                {
                    EditData<KhetAI> editKhetAI = this.editAI.v;
                    if (editKhetAI != null)
                    {
                        khetAI = editKhetAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editKhetAI null: " + this);
                    }
                }
                // Process
                if (khetAI != null)
                {
                    khetAI.requestChangeDepth(Server.getProfileUserId(khetAI), newDepth);
                }
                else
                {
                    Debug.LogError("khetAI null: " + this);
                }
            }

            #endregion

            #region pickBestMove

            public VP<RequestChangeIntUI.UIData> pickBestMove;

            public void makeRequestChangePickBestMove(RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
            {
                // Find
                KhetAI khetAI = null;
                {
                    EditData<KhetAI> editKhetAI = this.editAI.v;
                    if (editKhetAI != null)
                    {
                        khetAI = editKhetAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editKhetAI null: " + this);
                    }
                }
                // Process
                if (khetAI != null)
                {
                    khetAI.requestChangePickBestMove(Server.getProfileUserId(khetAI), newPickBestMove);
                }
                else
                {
                    Debug.LogError("khetAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                infinite,
                moveTime,
                depth,
                pickBestMove
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<KhetAI>>(this, (byte)Property.editAI, new EditData<KhetAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // infinite
                {
                    this.infinite = new VP<RequestChangeBoolUI.UIData>(this, (byte)Property.infinite, new RequestChangeBoolUI.UIData());
                    // event
                    this.infinite.v.updateData.v.request.v = makeRequestChangeInfinite;
                }
                // moveTime
                {
                    this.moveTime = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.moveTime, new RequestChangeIntUI.UIData());
                    // event
                    this.moveTime.v.updateData.v.request.v = makeRequestChangeMoveTime;
                }
                // depth
                {
                    this.depth = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.depth, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.depth.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 6;
                        }
                        this.depth.v.limit.v = have;
                    }
                    // event
                    this.depth.v.updateData.v.request.v = makeRequestChangeDepth;
                }
                // pickBestMove
                {
                    this.pickBestMove = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.pickBestMove, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.pickBestMove.v.limit.makeId();
                            have.min.v = 0;
                            have.max.v = 100;
                        }
                        this.pickBestMove.v.limit.v = have;
                    }
                    // event
                    this.pickBestMove.v.updateData.v.request.v = makeRequestChangePickBestMove;
                }
            }

            #endregion

            public override GameType.Type getType()
            {
                return GameType.Type.Khet;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Khet AI");

        public Text lbInfinite;
        private static readonly TxtLanguage txtInfinite = new TxtLanguage("Infinite");

        public Text lbMoveTime;
        private static readonly TxtLanguage txtMoveTime = new TxtLanguage("Move time");

        public Text lbDepth;
        private static readonly TxtLanguage txtDepth = new TxtLanguage("Depth");

        public Text lbPickBestMove;
        private static readonly TxtLanguage txtPickBestMove = new TxtLanguage("Pick best move");

        static KhetAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "AI Khet");
                txtInfinite.add(Language.Type.vi, "Vô hạn");
                txtMoveTime.add(Language.Type.vi, "Thời gian");
                txtDepth.add(Language.Type.vi, "Dộ sâu");
                txtPickBestMove.add(Language.Type.vi, "Chọn nước đi tốt nhất");
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
                    EditData<KhetAI> editKhetAI = this.data.editAI.v;
                    if (editKhetAI != null)
                    {
                        editKhetAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editKhetAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editKhetAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.infinite.v, editKhetAI, serverState, needReset, editData => editData.infinite.v);
                                RequestChange.RefreshUI(this.data.moveTime.v, editKhetAI, serverState, needReset, editData => editData.moveTime.v);
                                RequestChange.RefreshUI(this.data.depth.v, editKhetAI, serverState, needReset, editData => editData.depth.v);
                                RequestChange.RefreshUI(this.data.pickBestMove.v, editKhetAI, serverState, needReset, editData => editData.pickBestMove.v);
                            }
                            needReset = false;
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
                        UIUtils.SetHeaderPosition(lbTitle, this.data.showType.v, ref deltaY);
                        // infinite
                        UIUtils.SetLabelContentPosition(lbInfinite, this.data.infinite.v, ref deltaY);
                        // moveTime
                        UIUtils.SetLabelContentPosition(lbMoveTime, this.data.moveTime.v, ref deltaY);
                        // depth
                        UIUtils.SetLabelContentPosition(lbDepth, this.data.depth.v, ref deltaY);
                        // pickBestMove
                        UIUtils.SetLabelContentPosition(lbPickBestMove, this.data.pickBestMove.v, ref deltaY);
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
                        if (lbInfinite != null)
                        {
                            lbInfinite.text = txtInfinite.get();
                            Setting.get().setLabelTextSize(lbInfinite);
                        }
                        else
                        {
                            Debug.LogError("lbInfinite null: " + this);
                        }
                        if (lbMoveTime != null)
                        {
                            lbMoveTime.text = txtMoveTime.get();
                            Setting.get().setLabelTextSize(lbMoveTime);
                        }
                        else
                        {
                            Debug.LogError("lbMoveTime null: " + this);
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
                        if (lbPickBestMove != null)
                        {
                            lbPickBestMove.text = txtPickBestMove.get();
                            Setting.get().setLabelTextSize(lbPickBestMove);
                        }
                        else
                        {
                            Debug.LogError("lbPickBestMove null: " + this);
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
                    uiData.infinite.allAddCallBack(this);
                    uiData.moveTime.allAddCallBack(this);
                    uiData.depth.allAddCallBack(this);
                    uiData.pickBestMove.allAddCallBack(this);
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
                    if (data is EditData<KhetAI>)
                    {
                        EditData<KhetAI> editAI = data as EditData<KhetAI>;
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
                        if (data is KhetAI)
                        {
                            KhetAI khetAI = data as KhetAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(khetAI, this, ref this.server);
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
                                case UIData.Property.infinite:
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
                                case UIData.Property.moveTime:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.depth:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.pickBestMove:
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
                    uiData.infinite.allRemoveCallBack(this);
                    uiData.moveTime.allRemoveCallBack(this);
                    uiData.depth.allRemoveCallBack(this);
                    uiData.pickBestMove.allRemoveCallBack(this);
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
                    if (data is EditData<KhetAI>)
                    {
                        EditData<KhetAI> editAI = data as EditData<KhetAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is KhetAI)
                        {
                            KhetAI khetAI = data as KhetAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(khetAI, this, ref this.server);
                            }
                            return;
                        }
                        if (data is Server)
                        {
                            return;
                        }
                    }
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
                    case UIData.Property.infinite:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.moveTime:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.depth:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.pickBestMove:
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
                    if (wrapProperty.p is EditData<KhetAI>)
                    {
                        switch ((EditData<KhetAI>.Property)wrapProperty.n)
                        {
                            case EditData<KhetAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<KhetAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<KhetAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<KhetAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<KhetAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<KhetAI>.Property.editType:
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
                        if (wrapProperty.p is KhetAI)
                        {
                            switch ((KhetAI.Property)wrapProperty.n)
                            {
                                case KhetAI.Property.infinite:
                                    dirty = true;
                                    break;
                                case KhetAI.Property.moveTime:
                                    dirty = true;
                                    break;
                                case KhetAI.Property.depth:
                                    dirty = true;
                                    break;
                                case KhetAI.Property.pickBestMove:
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
                if (wrapProperty.p is RequestChangeBoolUI.UIData)
                {
                    return;
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