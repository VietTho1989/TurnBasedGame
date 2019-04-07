using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;
using GameState;

public class BtnPausePauseUI : UIBehavior<BtnPausePauseUI.UIData>
{

    #region UIData

    public class UIData : BtnPauseUI.UIData.Sub
    {

        public VP<ReferenceData<PlayPause>> playPause;

        #region State

        public enum State
        {
            None,
            Request,
            Wait
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            playPause,
            state
        }

        public UIData() : base()
        {
            this.playPause = new VP<ReferenceData<PlayPause>>(this, (byte)Property.playPause, new ReferenceData<PlayPause>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Play.Sub.Type getType()
        {
            return Play.Sub.Type.Pause;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtUnpause = new TxtLanguage("Resume");
    private static readonly TxtLanguage txtCancelUnpause = new TxtLanguage("Cancel resume?");
    private static readonly TxtLanguage txtUnpausing = new TxtLanguage("Resuming");
    private static readonly TxtLanguage txtCannotUnpause = new TxtLanguage("Cannot resume");

    static BtnPausePauseUI()
    {
        txtUnpause.add(Language.Type.vi, "Tiếp Tục Lại");
        txtCancelUnpause.add(Language.Type.vi, "Huỷ tiếp tục lại?");
        txtUnpausing.add(Language.Type.vi, "Đang tiếp tục lại...");
        txtCannotUnpause.add(Language.Type.vi, "Không thể tiếp tục lại");
    }

    #endregion

    #region Refresh

    public Button btnPause;
    public Text tvPause;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                PlayPause playPause = this.data.playPause.v.data;
                if (playPause != null)
                {
                    if (Play.IsCanChange(playPause, Server.getProfileUserId(playPause)))
                    {
                        // Task
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    {
                                        destroyRoutine(wait);
                                    }
                                    break;
                                case UIData.State.Request:
                                    {
                                        destroyRoutine(wait);
                                        if (Server.IsServerOnline(playPause))
                                        {
                                            playPause.requestUnPause(Server.getProfileUserId(playPause));
                                            this.data.state.v = UIData.State.Wait;
                                        }
                                        else
                                        {
                                            Debug.LogError("server offline: " + this);
                                        }
                                    }
                                    break;
                                case UIData.State.Wait:
                                    {
                                        if (Server.IsServerOnline(playPause))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            this.data.state.v = UIData.State.None;
                                        }
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                    break;
                            }
                        }
                        // UI
                        {
                            if (btnPause != null && tvPause != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnPause.interactable = true;
                                            tvPause.text = txtUnpause.get();
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnPause.interactable = true;
                                            tvPause.text = txtCancelUnpause.get();
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnPause.interactable = false;
                                            tvPause.text = txtUnpausing.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("Unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnUnPause, tvUnPause null: " + this);
                            }
                        }
                    }
                    else
                    {
                        // Task
                        {
                            this.data.state.v = UIData.State.None;
                            destroyRoutine(wait);
                        }
                        // UI
                        {
                            if (btnPause != null && tvPause != null)
                            {
                                btnPause.interactable = false;
                                tvPause.text = txtCannotUnpause.get();
                            }
                            else
                            {
                                Debug.LogError("btnPause, tvPause null: " + this);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("playPause null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return false;
    }

    #endregion

    #region Task wait

    private Routine wait;

    public IEnumerator TaskWait()
    {
        if (this.data != null)
        {
            yield return new Wait(Global.WaitSendTime);
            if (this.data != null)
            {
                this.data.state.v = UIData.State.None;
            }
            else
            {
                Debug.LogError("data null: " + this);
            }
            Debug.LogError("error, why cannot request: " + this);
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

    private GameCheckPlayerChange<PlayPause> gamePlayerCheckChange = new GameCheckPlayerChange<PlayPause>();
    private RoomCheckChangeAdminChange<PlayPause> roomCheckAdminChange = new RoomCheckChangeAdminChange<PlayPause>();
    private Server server = null;

    public override void onAddCallBack<T>(T data)
    {
        if(data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.playPause.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Setting
        if(data is Setting)
        {
            dirty = true;
            return;
        }
        // Child
        {
            if(data is PlayPause)
            {
                PlayPause playPause = data as PlayPause;
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
                // CheckChange
                {
                    // gamePlayer
                    {
                        gamePlayerCheckChange.addCallBack(this);
                        gamePlayerCheckChange.setData(playPause);
                    }
                    // roomAdmin
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(playPause);
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(playPause, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // CheckChange
            {
                if (data is GameCheckPlayerChange<PlayPause>)
                {
                    dirty = true;
                    return;
                }
                if (data is RoomCheckChangeAdminChange<PlayPause>)
                {
                    dirty = true;
                    return;
                }
            }
            // Parent
            if (data is Server)
            {
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
                uiData.playPause.allRemoveCallBack(this);
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
            if (data is PlayPause)
            {
                PlayPause playPause = data as PlayPause;
                // CheckChange
                {
                    // gamePlayer
                    {
                        gamePlayerCheckChange.removeCallBack(this);
                        gamePlayerCheckChange.setData(null);
                    }
                    // roomAdmin
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(playPause, this, ref this.server);
                }
                return;
            }
            // CheckChange
            {
                if (data is GameCheckPlayerChange<PlayPause>)
                {
                    return;
                }
                if (data is RoomCheckChangeAdminChange<PlayPause>)
                {
                    return;
                }
            }
            // Parent
            if (data is Server)
            {
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
                case UIData.Property.playPause:
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
                case Setting.Property.style:
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
            if (wrapProperty.p is PlayPause)
            {
                switch ((PlayPause.Property)wrapProperty.n)
                {
                    case PlayPause.Property.human:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            {
                if (wrapProperty.p is GameCheckPlayerChange<PlayPause>)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is RoomCheckChangeAdminChange<PlayPause>)
                {
                    dirty = true;
                    return;
                }
            }
            // Parent
            if (wrapProperty.p is Server)
            {
                Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnResume()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.Request;
                    break;
                case UIData.State.Request:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.Wait:
                    Debug.LogError("you are requesting");
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}