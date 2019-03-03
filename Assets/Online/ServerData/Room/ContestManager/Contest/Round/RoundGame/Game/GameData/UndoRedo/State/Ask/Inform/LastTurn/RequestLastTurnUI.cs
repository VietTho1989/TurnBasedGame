using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

namespace UndoRedo
{
    public class RequestLastTurnUI : UIBehavior<RequestLastTurnUI.UIData>, HaveTransformData
    {

        #region UIData

        public class UIData : NoneUI.UIData.Sub
        {

            public VP<ReferenceData<RequestLastTurn>> requestLastTurn;

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
                requestLastTurn,
                state
            }

            public UIData() : base()
            {
                this.requestLastTurn = new VP<ReferenceData<RequestLastTurn>>(this, (byte)Property.requestLastTurn, new ReferenceData<RequestLastTurn>(null));
                this.state = new VP<State>(this, (byte)Property.state, State.None);
            }

            #endregion

            public override RequestInform.Type getType()
            {
                return RequestInform.Type.LastTurn;
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

        static RequestLastTurnUI()
        {
            txtTitle.add(Language.Type.vi, "Lượt Trước");

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
                    RequestLastTurn requestLastTurn = this.data.requestLastTurn.v.data;
                    if (requestLastTurn != null)
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
                                                none.requestAskLastTurn(Server.getProfileUserId(none), UndoRedoRequest.Operation.Undo);
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
                                                none.requestAskLastTurn(Server.getProfileUserId(none), UndoRedoRequest.Operation.Redo);
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
                                // find history
                                History history = null;
                                {
                                    GameUI.UIData gameUIData = this.data.findDataInParent<GameUI.UIData>();
                                    if (gameUIData != null)
                                    {
                                        Game game = gameUIData.game.v.data;
                                        if (game != null)
                                        {
                                            history = game.history.v;
                                        }
                                        else
                                        {
                                            Debug.LogError("game null: " + this);
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("gameUIData null: " + this);
                                    }
                                }
                                // Process
                                if (history != null)
                                {
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                // undo
                                                {
                                                    if (history.position.v > 0)
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
                                                    if (history.position.v < history.changeCount.v - 1)
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
                                                    tvRedo.text = txtCancelRedo.get("Cancel redo?");
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
                                    Debug.LogError("history null: " + this);
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
                        Debug.LogError("requestLastTurn null: " + this);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get("Last Turn");
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
            updateTransformData();
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
                // Debug.LogError ("request error: " + this);
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

        private GameUI.UIData gameUIData = null;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Global
                Global.get().addCallBack(this);
                // Setting
                Setting.get().addCallBack(this);
                // Parent
                {
                    DataUtils.addParentCallBack(uiData, this, ref this.noneUIData);
                    DataUtils.addParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.requestLastTurn.allAddCallBack(this);
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
                // gameUIData
                {
                    if (data is GameUI.UIData)
                    {
                        GameUI.UIData gameUIData = data as GameUI.UIData;
                        // Child
                        {
                            gameUIData.game.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is Game)
                        {
                            Game game = data as Game;
                            // Child
                            {
                                game.history.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is History)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Child
            if (data is RequestLastTurn)
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
                // Global
                Global.get().removeCallBack(this);
                // Setting
                Setting.get().removeCallBack(this);
                // Parent
                {
                    DataUtils.removeParentCallBack(uiData, this, ref this.noneUIData);
                    DataUtils.removeParentCallBack(uiData, this, ref this.gameUIData);
                }
                // Child
                {
                    uiData.requestLastTurn.allRemoveCallBack(this);
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
                // gameUIData
                {
                    if (data is GameUI.UIData)
                    {
                        GameUI.UIData gameUIData = data as GameUI.UIData;
                        // Child
                        {
                            gameUIData.game.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is Game)
                        {
                            Game game = data as Game;
                            // Child
                            {
                                game.history.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is History)
                        {
                            return;
                        }
                    }
                }
            }
            // Child
            if (data is RequestLastTurn)
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
                    case UIData.Property.requestLastTurn:
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
                // gameUIData
                {
                    if (wrapProperty.p is GameUI.UIData)
                    {
                        switch ((GameUI.UIData.Property)wrapProperty.n)
                        {
                            case GameUI.UIData.Property.game:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GameUI.UIData.Property.isReplay:
                                break;
                            case GameUI.UIData.Property.stateUI:
                                break;
                            case GameUI.UIData.Property.gameDataUI:
                                break;
                            case GameUI.UIData.Property.undoRedoRequestUIData:
                                break;
                            case GameUI.UIData.Property.gameChatRoom:
                                break;
                            case GameUI.UIData.Property.requestDraw:
                                break;
                            case GameUI.UIData.Property.saveUIData:
                                break;
                            case GameUI.UIData.Property.gameHistoryUIData:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is Game)
                        {
                            switch ((Game.Property)wrapProperty.n)
                            {
                                case Game.Property.gamePlayers:
                                    break;
                                case Game.Property.requestDraw:
                                    break;
                                case Game.Property.state:
                                    break;
                                case Game.Property.gameData:
                                    break;
                                case Game.Property.history:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case Game.Property.gameAction:
                                    break;
                                case Game.Property.undoRedoRequest:
                                    break;
                                case Game.Property.chatRoom:
                                    break;
                                case Game.Property.animationData:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is History)
                        {
                            switch ((History.Property)wrapProperty.n)
                            {
                                case History.Property.isActive:
                                    break;
                                case History.Property.changes:
                                    break;
                                case History.Property.position:
                                    dirty = true;
                                    break;
                                case History.Property.changeCount:
                                    dirty = true;
                                    break;
                                case History.Property.humanConnections:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            // Child
            if (wrapProperty.p is RequestLastTurn)
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