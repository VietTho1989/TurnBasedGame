using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace UndoRedo
{
    public class RequestLastYourTurnUI : UIHaveTransformDataBehavior<RequestLastYourTurnUI.UIData>
    {

        #region UIData

        public class UIData : NoneUI.UIData.Sub
        {

            public VP<ReferenceData<RequestLastYourTurn>> requestLastYourTurn;

            #region State

            public enum State
            {
                None,
                RequestUndo,
                WaitUndo,
                RequestRedo,
                WaitRedo
            }

            public VP<State> state;

            #endregion

            #region Constructor

            public enum Property
            {
                requestLastYourTurn,
                state
            }

            public UIData() : base()
            {
                this.requestLastYourTurn = new VP<ReferenceData<RequestLastYourTurn>>(this, (byte)Property.requestLastYourTurn, new ReferenceData<RequestLastYourTurn>(null));
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

            public override RequestInform.Type getType()
            {
                return RequestInform.Type.LastYourTurn;
            }

            public void reset()
            {
                this.state.v = State.None;
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        private static readonly TxtLanguage txtTitle = new TxtLanguage();

        private static readonly TxtLanguage txtUndo = new TxtLanguage();
        private static readonly TxtLanguage txtCancelUndo = new TxtLanguage();
        private static readonly TxtLanguage txtUndoing = new TxtLanguage();
        private static readonly TxtLanguage txtCannotUndo = new TxtLanguage();

        private static readonly TxtLanguage txtRedo = new TxtLanguage();
        private static readonly TxtLanguage txtCancelRedo = new TxtLanguage();
        private static readonly TxtLanguage txtRedoing = new TxtLanguage();
        private static readonly TxtLanguage txtCannotRedo = new TxtLanguage();

        private static readonly TxtLanguage txtRequestError = new TxtLanguage();

        static RequestLastYourTurnUI()
        {
            txtTitle.add(Language.Type.vi, "Lượt Trước Của Bạn");

            txtUndo.add(Language.Type.vi, "Đi Lại");
            txtCancelUndo.add(Language.Type.vi, "Huỷ đi lại?");
            txtUndoing.add(Language.Type.vi, "Đang đi lại");
            txtCannotUndo.add(Language.Type.vi, "Không thể đi lại");

            txtRedo.add(Language.Type.vi, "Đi Tiếp");
            txtCancelRedo.add(Language.Type.vi, "Huỷ đi tiếp?");
            txtRedoing.add(Language.Type.vi, "Đang đi tiếp");
            txtCannotRedo.add(Language.Type.vi, "Không thể đi tiếp");

            txtRequestError.add(Language.Type.vi, "Gửi yêu cầu lỗi");
        }

        #endregion

        #region Refresh

        public Button btnUndo;
        public Text tvUndo;

        public Button btnRedo;
        public Text tvRedo;

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RequestLastYourTurn requestLastYourTurn = this.data.requestLastYourTurn.v.data;
                    if (requestLastYourTurn != null)
                    {
                        // Tasks
                        {
                            // Find None
                            None none = null;
                            {
                                NoneUI.UIData noneUIData = this.data.findDataInParent<NoneUI.UIData>();
                                if (noneUIData != null)
                                {
                                    none = noneUIData.none.v.data;
                                }
                                else
                                {
                                    Debug.LogError("noneUIData null: " + this);
                                }
                            }
                            // Process
                            if (none != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            destroyRoutine(wait);
                                        }
                                        break;
                                    case UIData.State.RequestUndo:
                                        {
                                            destroyRoutine(wait);
                                            // request
                                            if (Server.IsServerOnline(none))
                                            {
                                                none.requestAskLastYourTurn(Server.getProfileUserId(none), UndoRedoRequest.Operation.Undo);
                                                this.data.state.v = UIData.State.WaitUndo;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                            }
                                        }
                                        break;
                                    case UIData.State.WaitUndo:
                                        {
                                            if (Server.IsServerOnline(none))
                                            {
                                                startRoutine(ref wait, TaskWait());
                                            }
                                            else
                                            {
                                                this.data.state.v = UIData.State.None;
                                            }
                                        }
                                        break;
                                    case UIData.State.RequestRedo:
                                        {
                                            destroyRoutine(wait);
                                            // request
                                            if (Server.IsServerOnline(none))
                                            {
                                                none.requestAskLastYourTurn(Server.getProfileUserId(none), UndoRedoRequest.Operation.Redo);
                                                this.data.state.v = UIData.State.WaitRedo;
                                            }
                                            else
                                            {
                                                Debug.LogError("server not online: " + this);
                                            }
                                        }
                                        break;
                                    case UIData.State.WaitRedo:
                                        {
                                            if (Server.IsServerOnline(none))
                                            {
                                                startRoutine(ref wait, TaskWait());
                                            }
                                            else
                                            {
                                                this.data.state.v = UIData.State.None;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("none null: " + this);
                                this.data.state.v = UIData.State.None;
                                destroyRoutine(wait);
                            }
                        }
                        // UI
                        {
                            if (btnUndo != null && tvUndo != null && btnRedo != null && tvRedo != null)
                            {
                                UndoRedoRequestUI.UIData undoRedoRequestUIData = this.data.findDataInParent<UndoRedoRequestUI.UIData>();
                                if (undoRedoRequestUIData != null)
                                {
                                    UndoRedoRequest undoRedoRequest = undoRedoRequestUIData.undoRedoRequest.v.data;
                                    if (undoRedoRequest != null)
                                    {
                                        switch (this.data.state.v)
                                        {
                                            case UIData.State.None:
                                                {
                                                    // undo
                                                    {
                                                        if (undoRedoRequest.canUndo.v)
                                                        {
                                                            btnUndo.interactable = true;
                                                            tvUndo.text = txtUndo.get("Undo");
                                                        }
                                                        else
                                                        {
                                                            btnUndo.interactable = false;
                                                            tvUndo.text = txtCannotUndo.get("Cannot Undo");
                                                        }
                                                    }
                                                    // redo
                                                    {
                                                        if (undoRedoRequest.canRedo.v)
                                                        {
                                                            btnRedo.interactable = true;
                                                            tvRedo.text = txtRedo.get("Redo");
                                                        }
                                                        else
                                                        {
                                                            btnRedo.interactable = false;
                                                            tvRedo.text = txtCannotRedo.get("Cannot Redo");
                                                        }
                                                    }
                                                }
                                                break;
                                            case UIData.State.RequestUndo:
                                                {
                                                    // undo
                                                    {
                                                        btnUndo.interactable = true;
                                                        tvUndo.text = txtCancelUndo.get("Cancel undo?");
                                                    }
                                                    // redo
                                                    {
                                                        btnRedo.interactable = false;
                                                        tvRedo.text = txtRedo.get("Redo");
                                                    }
                                                }
                                                break;
                                            case UIData.State.WaitUndo:
                                                {
                                                    // undo
                                                    {
                                                        btnUndo.interactable = false;
                                                        tvUndo.text = txtUndoing.get("Requesting undo");
                                                    }
                                                    // redo
                                                    {
                                                        btnRedo.interactable = false;
                                                        tvRedo.text = txtRedo.get("Redo");
                                                    }
                                                }
                                                break;
                                            case UIData.State.RequestRedo:
                                                {
                                                    // undo
                                                    {
                                                        btnUndo.interactable = false;
                                                        tvUndo.text = txtUndo.get("Undo");
                                                    }
                                                    // redo
                                                    {
                                                        btnRedo.interactable = true;
                                                        tvRedo.text = txtCannotRedo.get("Cancel redo?");
                                                    }
                                                }
                                                break;
                                            case UIData.State.WaitRedo:
                                                {
                                                    // undo
                                                    {
                                                        btnUndo.interactable = false;
                                                        tvUndo.text = txtUndo.get("Undo");
                                                    }
                                                    // redo
                                                    {
                                                        btnRedo.interactable = false;
                                                        tvRedo.text = txtRedoing.get("Requesting redo");
                                                    }
                                                }
                                                break;
                                            default:
                                                Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("undoRedoRequest null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("undoRedoRequestUIData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("btnUndo, tvUndo, btnRedo, tvRedo null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("requestLastYourTurn null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Last Your Turn");
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region Task wait

        private Routine wait;

        public IEnumerator TaskWait()
        {
            if (this.data != null)
            {
                yield return new Wait(Global.WaitSendTime);
                this.data.state.v = UIData.State.None;
                Toast.showMessage(txtRequestError.get("Send request error"));
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public override List<Routine> getRoutineList()
        {
            List<Routine> ret = new List<Routine>();
            {
                ret.Add(wait);
            }
            return ret;
        }

        #endregion

        #region implement callBacks

        private NoneUI.UIData noneUIData = null;
        private Server server = null;

        private UndoRedoRequestUI.UIData undoRedoRequestUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.noneUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.undoRedoRequestUIData);
                }
                // Child
                {
                    uiData.requestLastYourTurn.allAddCallBack(this);
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
            // Parent
            {
                // noneUIData
                {
                    if (data is NoneUI.UIData)
                    {
                        NoneUI.UIData noneUIData = data as NoneUI.UIData;
                        // Child
                        {
                            noneUIData.none.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is None)
                        {
                            None none = data as None;
                            // Reset
                            {
                                if (this.data != null)
                                {
                                    this.data.reset();
                                }
                                else
                                {
                                    Debug.LogError("data null: " + this);
                                }
                            }
                            // Parent
                            {
                                DataUtils.addParentCallBack(none, this, ref this.server);
                            }
                            dirty = true;
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
                // undoRedoRequestUIData
                {
                    if (data is UndoRedoRequestUI.UIData)
                    {
                        UndoRedoRequestUI.UIData undoRedoRequestUIData = data as UndoRedoRequestUI.UIData;
                        // Child
                        {
                            undoRedoRequestUIData.undoRedoRequest.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is UndoRedoRequest)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            // Child
            if (data is RequestLastYourTurn)
            {
                dirty = true;
                return;
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
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.undoRedoRequestUIData);
                }
                // Child
                {
                    uiData.requestLastYourTurn.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Setting
            if (data is Setting)
            {
                return;
            }
            // Parent
            {
                // noneUIData
                {
                    if (data is NoneUI.UIData)
                    {
                        NoneUI.UIData noneUIData = data as NoneUI.UIData;
                        // Child
                        {
                            noneUIData.none.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is None)
                        {
                            None none = data as None;
                            // Parent
                            {
                                DataUtils.removeParentCallBack(none, this, ref this.server);
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
                // undoRedoRequestUIData
                {
                    if (data is UndoRedoRequestUI.UIData)
                    {
                        UndoRedoRequestUI.UIData undoRedoRequestUIData = data as UndoRedoRequestUI.UIData;
                        // Child
                        {
                            undoRedoRequestUIData.undoRedoRequest.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is UndoRedoRequest)
                    {
                        return;
                    }
                }
            }
            // Child
            if (data is RequestLastYourTurn)
            {
                return;
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
                    case UIData.Property.requestLastYourTurn:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.state:
                        dirty = true;
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
            // Parent
            {
                // noneUIData
                {
                    if (wrapProperty.p is NoneUI.UIData)
                    {
                        switch ((NoneUI.UIData.Property)wrapProperty.n)
                        {
                            case NoneUI.UIData.Property.none:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case NoneUI.UIData.Property.informType:
                                break;
                            case NoneUI.UIData.Property.requestType:
                                break;
                            case NoneUI.UIData.Property.sub:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is None)
                        {
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
                // undoRedoRequestUIData
                {
                    if (wrapProperty.p is UndoRedoRequestUI.UIData)
                    {
                        switch ((UndoRedoRequestUI.UIData.Property)wrapProperty.n)
                        {
                            case UndoRedoRequestUI.UIData.Property.undoRedoRequest:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case UndoRedoRequestUI.UIData.Property.sub:
                                break;
                            case UndoRedoRequestUI.UIData.Property.showAnimation:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is UndoRedoRequest)
                    {
                        switch ((UndoRedoRequest.Property)wrapProperty.n)
                        {
                            case UndoRedoRequest.Property.state:
                                break;
                            case UndoRedoRequest.Property.canUndo:
                                dirty = true;
                                break;
                            case UndoRedoRequest.Property.canRedo:
                                dirty = true;
                                break;
                            case UndoRedoRequest.Property.count:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            // Child
            if (wrapProperty.p is RequestLastYourTurn)
            {
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

        public void onClickBtnUndo()
        {
            if (this.data != null)
            {
                switch (this.data.state.v)
                {
                    case UIData.State.None:
                        this.data.state.v = UIData.State.RequestUndo;
                        break;
                    case UIData.State.RequestUndo:
                        this.data.state.v = UIData.State.None;
                        break;
                    case UIData.State.WaitUndo:
                        break;
                    case UIData.State.RequestRedo:
                        break;
                    case UIData.State.WaitRedo:
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

        public void onClickBtnRedo()
        {
            if (this.data != null)
            {
                switch (this.data.state.v)
                {
                    case UIData.State.None:
                        this.data.state.v = UIData.State.RequestRedo;
                        break;
                    case UIData.State.RequestUndo:
                        break;
                    case UIData.State.WaitUndo:
                        break;
                    case UIData.State.RequestRedo:
                        this.data.state.v = UIData.State.None;
                        break;
                    case UIData.State.WaitRedo:
                        break;
                    default:
                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
        }

    }
}