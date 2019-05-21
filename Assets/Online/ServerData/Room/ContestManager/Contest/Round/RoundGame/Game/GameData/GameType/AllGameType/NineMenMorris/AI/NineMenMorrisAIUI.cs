using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class NineMenMorrisAIUI : UIHaveTransformDataBehavior<NineMenMorrisAIUI.UIData>
    {

        #region UIData

        public class UIData : AIUI.UIData.Sub
        {

            public VP<EditData<NineMenMorrisAI>> editAI;

            public VP<UIRectTransform.ShowType> showType;

            #region MaxNormal

            public VP<RequestChangeIntUI.UIData> MaxNormal;

            public void makeRequestChangeMaxNormal(RequestChangeUpdate<int>.UpdateData update, int newMaxNormal)
            {
                // Find
                NineMenMorrisAI nineMenMorrisAI = null;
                {
                    EditData<NineMenMorrisAI> editNineMenMorrisAI = this.editAI.v;
                    if (editNineMenMorrisAI != null)
                    {
                        nineMenMorrisAI = editNineMenMorrisAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNineMenMorrisAI null: " + this);
                    }
                }
                // Process
                if (nineMenMorrisAI != null)
                {
                    nineMenMorrisAI.requestChangeMaxNormal(Server.getProfileUserId(nineMenMorrisAI), newMaxNormal);
                }
                else
                {
                    Debug.LogError("nineMenMorrisAI null: " + this);
                }
            }

            #endregion

            #region MaxPositioning

            public VP<RequestChangeIntUI.UIData> MaxPositioning;

            public void makeRequestChangeMaxPositioning(RequestChangeUpdate<int>.UpdateData update, int newMaxPositioning)
            {
                // Find
                NineMenMorrisAI nineMenMorrisAI = null;
                {
                    EditData<NineMenMorrisAI> editNineMenMorrisAI = this.editAI.v;
                    if (editNineMenMorrisAI != null)
                    {
                        nineMenMorrisAI = editNineMenMorrisAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNineMenMorrisAI null: " + this);
                    }
                }
                // Process
                if (nineMenMorrisAI != null)
                {
                    nineMenMorrisAI.requestChangeMaxPositioning(Server.getProfileUserId(nineMenMorrisAI), newMaxPositioning);
                }
                else
                {
                    Debug.LogError("nineMenMorrisAI null: " + this);
                }
            }

            #endregion

            #region MaxBlackAndWhite3

            public VP<RequestChangeIntUI.UIData> MaxBlackAndWhite3;

            public void makeRequestChangeMaxBlackAndWhite3(RequestChangeUpdate<int>.UpdateData update, int newMaxBlackAndWhite3)
            {
                // Find
                NineMenMorrisAI nineMenMorrisAI = null;
                {
                    EditData<NineMenMorrisAI> editNineMenMorrisAI = this.editAI.v;
                    if (editNineMenMorrisAI != null)
                    {
                        nineMenMorrisAI = editNineMenMorrisAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNineMenMorrisAI null: " + this);
                    }
                }
                // Process
                if (nineMenMorrisAI != null)
                {
                    nineMenMorrisAI.requestChangeMaxBlackAndWhite3(Server.getProfileUserId(nineMenMorrisAI), newMaxBlackAndWhite3);
                }
                else
                {
                    Debug.LogError("nineMenMorrisAI null: " + this);
                }
            }

            #endregion

            #region MaxBlackOrWhite3

            public VP<RequestChangeIntUI.UIData> MaxBlackOrWhite3;

            public void makeRequestChangeMaxBlackOrWhite3(RequestChangeUpdate<int>.UpdateData update, int newMaxBlackOrWhite3)
            {
                // Find
                NineMenMorrisAI nineMenMorrisAI = null;
                {
                    EditData<NineMenMorrisAI> editNineMenMorrisAI = this.editAI.v;
                    if (editNineMenMorrisAI != null)
                    {
                        nineMenMorrisAI = editNineMenMorrisAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNineMenMorrisAI null: " + this);
                    }
                }
                // Process
                if (nineMenMorrisAI != null)
                {
                    nineMenMorrisAI.requestChangeMaxBlackOrWhite3(Server.getProfileUserId(nineMenMorrisAI), newMaxBlackOrWhite3);
                }
                else
                {
                    Debug.LogError("nineMenMorrisAI null: " + this);
                }
            }

            #endregion

            #region pickBestMove

            public VP<RequestChangeIntUI.UIData> pickBestMove;

            public void makeRequestChangePickBestMove(RequestChangeUpdate<int>.UpdateData update, int newPickBestMove)
            {
                // Find
                NineMenMorrisAI nineMenMorrisAI = null;
                {
                    EditData<NineMenMorrisAI> editNineMenMorrisAI = this.editAI.v;
                    if (editNineMenMorrisAI != null)
                    {
                        nineMenMorrisAI = editNineMenMorrisAI.show.v.data;
                    }
                    else
                    {
                        Debug.LogError("editNineMenMorrisAI null: " + this);
                    }
                }
                // Process
                if (nineMenMorrisAI != null)
                {
                    nineMenMorrisAI.requestChangePickBestMove(Server.getProfileUserId(nineMenMorrisAI), newPickBestMove);
                }
                else
                {
                    Debug.LogError("nineMenMorrisAI null: " + this);
                }
            }

            #endregion

            #region Constructor

            public enum Property
            {
                editAI,
                showType,
                MaxNormal,
                MaxPositioning,
                MaxBlackAndWhite3,
                MaxBlackOrWhite3,
                pickBestMove
            }

            public UIData() : base()
            {
                this.editAI = new VP<EditData<NineMenMorrisAI>>(this, (byte)Property.editAI, new EditData<NineMenMorrisAI>());
                this.showType = new VP<UIRectTransform.ShowType>(this, (byte)Property.showType, UIRectTransform.ShowType.Normal);
                // MaxNormal
                {
                    this.MaxNormal = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.MaxNormal, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.MaxNormal.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 10;
                        }
                        this.MaxNormal.v.limit.v = have;
                    }
                    // event
                    this.MaxNormal.v.updateData.v.request.v = makeRequestChangeMaxNormal;
                }
                // MaxPositioning
                {
                    this.MaxPositioning = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.MaxPositioning, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.MaxPositioning.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 10;
                        }
                        this.MaxPositioning.v.limit.v = have;
                    }
                    // event
                    this.MaxPositioning.v.updateData.v.request.v = makeRequestChangeMaxPositioning;
                }
                // MaxBlackAndWhite3
                {
                    this.MaxBlackAndWhite3 = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.MaxBlackAndWhite3, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.MaxBlackAndWhite3.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 10;
                        }
                        this.MaxBlackAndWhite3.v.limit.v = have;
                    }
                    // event
                    this.MaxBlackAndWhite3.v.updateData.v.request.v = makeRequestChangeMaxBlackAndWhite3;
                }
                // MaxBlackOrWhite3
                {
                    this.MaxBlackOrWhite3 = new VP<RequestChangeIntUI.UIData>(this, (byte)Property.MaxBlackOrWhite3, new RequestChangeIntUI.UIData());
                    // have limit
                    {
                        IntLimit.Have have = new IntLimit.Have();
                        {
                            have.uid = this.MaxBlackOrWhite3.v.limit.makeId();
                            have.min.v = 1;
                            have.max.v = 10;
                        }
                        this.MaxBlackOrWhite3.v.limit.v = have;
                    }
                    // event
                    this.MaxBlackOrWhite3.v.updateData.v.request.v = makeRequestChangeMaxBlackOrWhite3;
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
                return GameType.Type.NineMenMorris;
            }

        }

        #endregion

        public override int getStartAllocate()
        {
            return Setting.get().defaultChosenGame.v.getGame() == GameType.Type.NineMenMorris ? 1 : 0;
        }

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage("Nine Men's Morriss AI");

        public Text lbMaxNormal;
        private static readonly TxtLanguage txtMaxNormal = new TxtLanguage("Max normal depth");

        public Text lbMaxPositioning;
        private static readonly TxtLanguage txtMaxPositioning = new TxtLanguage("Max positioning depth");

        public Text lbMaxBlackAndWhite3;
        private static readonly TxtLanguage txtMaxBlackAndWhite3 = new TxtLanguage("Max black and white 3 depth");

        public Text lbMaxBlackOrWhite3;
        private static readonly TxtLanguage txtMaxBlackOrWhite3 = new TxtLanguage("Max black or white 3 depth");

        public Text lbPickBestMove;
        private static readonly TxtLanguage txtPickBestMove = new TxtLanguage("Pick best move depth");

        static NineMenMorrisAIUI()
        {
            // txt
            {
                txtTitle.add(Language.Type.vi, "AI Nine Men's Morriss");
                txtMaxNormal.add(Language.Type.vi, "Độ sâu lúc bình ");
                txtMaxPositioning.add(Language.Type.vi, "Độ sâu lúc đặt quân");
                txtMaxBlackAndWhite3.add(Language.Type.vi, "Độ sâu khi cả 2 bên còn 3 quân");
                txtMaxBlackOrWhite3.add(Language.Type.vi, "Độ sâu khi 1 trong 2 bên còn 3 quân");
                txtPickBestMove.add(Language.Type.vi, "Tỷ lệ chọn nước đi tốt nhất");
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
                    EditData<NineMenMorrisAI> editNineMenMorrisAI = this.data.editAI.v;
                    if (editNineMenMorrisAI != null)
                    {
                        editNineMenMorrisAI.update();
                        // UI
                        {
                            // different
                            RequestChange.ShowDifferentTitle(lbTitle, editNineMenMorrisAI);
                            // get server state
                            Server.State.Type serverState = RequestChange.GetServerState(editNineMenMorrisAI);
                            // set origin
                            {
                                RequestChange.RefreshUI(this.data.MaxNormal.v, editNineMenMorrisAI, serverState, needReset, editData => editData.MaxNormal.v);
                                RequestChange.RefreshUI(this.data.MaxPositioning.v, editNineMenMorrisAI, serverState, needReset, editData => editData.MaxPositioning.v);
                                RequestChange.RefreshUI(this.data.MaxBlackAndWhite3.v, editNineMenMorrisAI, serverState, needReset, editData => editData.MaxBlackAndWhite3.v);
                                RequestChange.RefreshUI(this.data.MaxBlackOrWhite3.v, editNineMenMorrisAI, serverState, needReset, editData => editData.MaxBlackOrWhite3.v);
                                RequestChange.RefreshUI(this.data.pickBestMove.v, editNineMenMorrisAI, serverState, needReset, editData => editData.pickBestMove.v);
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
                        // MaxNormal
                        UIUtils.SetLabelContentPosition(lbMaxNormal, this.data.MaxNormal.v, ref deltaY);
                        // MaxPositioning
                        UIUtils.SetLabelContentPosition(lbMaxPositioning, this.data.MaxPositioning.v, ref deltaY);
                        // MaxBlackAndWhite3
                        UIUtils.SetLabelContentPosition(lbMaxBlackAndWhite3, this.data.MaxBlackAndWhite3.v, ref deltaY);
                        // MaxBlackOrWhite3
                        UIUtils.SetLabelContentPosition(lbMaxBlackOrWhite3, this.data.MaxBlackOrWhite3.v, ref deltaY);
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
                        if (lbMaxNormal != null)
                        {
                            lbMaxNormal.text = txtMaxNormal.get();
                            Setting.get().setLabelTextSize(lbMaxNormal);
                        }
                        else
                        {
                            Debug.LogError("lbMaxNormal null: " + this);
                        }
                        if (lbMaxPositioning != null)
                        {
                            lbMaxPositioning.text = txtMaxPositioning.get();
                            Setting.get().setLabelTextSize(lbMaxPositioning);
                        }
                        else
                        {
                            Debug.LogError("lbMaxPositioning null: " + this);
                        }
                        if (lbMaxBlackAndWhite3 != null)
                        {
                            lbMaxBlackAndWhite3.text = txtMaxBlackAndWhite3.get();
                            Setting.get().setLabelTextSize(lbMaxBlackAndWhite3);
                        }
                        else
                        {
                            Debug.LogError("lbMaxBlackAndWhite3 null: " + this);
                        }
                        if (lbMaxBlackOrWhite3 != null)
                        {
                            lbMaxBlackOrWhite3.text = txtMaxBlackOrWhite3.get();
                            Setting.get().setLabelTextSize(lbMaxBlackOrWhite3);
                        }
                        else
                        {
                            Debug.LogError("lbMaxBlackOrWhite3 null: " + this);
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
                    uiData.MaxNormal.allAddCallBack(this);
                    uiData.MaxPositioning.allAddCallBack(this);
                    uiData.MaxBlackAndWhite3.allAddCallBack(this);
                    uiData.MaxBlackOrWhite3.allAddCallBack(this);
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
                    if (data is EditData<NineMenMorrisAI>)
                    {
                        EditData<NineMenMorrisAI> editAI = data as EditData<NineMenMorrisAI>;
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
                        if (data is NineMenMorrisAI)
                        {
                            NineMenMorrisAI nineMenMorrisAI = data as NineMenMorrisAI;
                            // Parent
                            {
                                DataUtils.addParentCallBack(nineMenMorrisAI, this, ref this.server);
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
                                case UIData.Property.MaxNormal:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.MaxPositioning:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.MaxBlackAndWhite3:
                                    UIUtils.Instantiate(requestChange, requestIntPrefab, this.transform, UIConstants.RequestRect);
                                    break;
                                case UIData.Property.MaxBlackOrWhite3:
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
                    uiData.MaxNormal.allRemoveCallBack(this);
                    uiData.MaxPositioning.allRemoveCallBack(this);
                    uiData.MaxBlackAndWhite3.allRemoveCallBack(this);
                    uiData.MaxBlackOrWhite3.allRemoveCallBack(this);
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
                    if (data is EditData<NineMenMorrisAI>)
                    {
                        EditData<NineMenMorrisAI> editAI = data as EditData<NineMenMorrisAI>;
                        // Child
                        {
                            editAI.show.allRemoveCallBack(this);
                            editAI.compare.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is NineMenMorrisAI)
                        {
                            NineMenMorrisAI nineMenMorrisAI = data as NineMenMorrisAI;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(nineMenMorrisAI, this, ref this.server);
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
                    case UIData.Property.MaxNormal:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.MaxPositioning:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.MaxBlackAndWhite3:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.MaxBlackOrWhite3:
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
                    if (wrapProperty.p is EditData<NineMenMorrisAI>)
                    {
                        switch ((EditData<NineMenMorrisAI>.Property)wrapProperty.n)
                        {
                            case EditData<NineMenMorrisAI>.Property.origin:
                                dirty = true;
                                break;
                            case EditData<NineMenMorrisAI>.Property.show:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<NineMenMorrisAI>.Property.compare:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case EditData<NineMenMorrisAI>.Property.compareOtherType:
                                dirty = true;
                                break;
                            case EditData<NineMenMorrisAI>.Property.canEdit:
                                dirty = true;
                                break;
                            case EditData<NineMenMorrisAI>.Property.editType:
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
                        if (wrapProperty.p is NineMenMorrisAI)
                        {
                            switch ((NineMenMorrisAI.Property)wrapProperty.n)
                            {
                                case NineMenMorrisAI.Property.MaxNormal:
                                    dirty = true;
                                    break;
                                case NineMenMorrisAI.Property.MaxPositioning:
                                    dirty = true;
                                    break;
                                case NineMenMorrisAI.Property.MaxBlackAndWhite3:
                                    dirty = true;
                                    break;
                                case NineMenMorrisAI.Property.MaxBlackOrWhite3:
                                    dirty = true;
                                    break;
                                case NineMenMorrisAI.Property.pickBestMove:
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
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}