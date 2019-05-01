using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using GameState;

public class BtnPauseNormalUI : UIBehavior<BtnPauseNormalUI.UIData>
{

    #region UIData

    public class UIData : BtnPauseUI.UIData.Sub
    {

        public VP<ReferenceData<PlayNormal>> playNormal;

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
            playNormal,
            state
        }

        public UIData() : base()
        {
            this.playNormal = new VP<ReferenceData<PlayNormal>>(this, (byte)Property.playNormal, new ReferenceData<PlayNormal>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override Play.Sub.Type getType()
        {
            return Play.Sub.Type.Normal;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

    }

    #endregion

    #region txt

    private static readonly TxtLanguage txtPause = new TxtLanguage("Pause");
    private static readonly TxtLanguage txtCancelPause = new TxtLanguage("Cancel pause?");
    private static readonly TxtLanguage txtPausing = new TxtLanguage("Pausing");
    private static readonly TxtLanguage txtCannotPause = new TxtLanguage("Cannot pause");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Request pause error");

    static BtnPauseNormalUI()
    {
        txtPause.add(Language.Type.vi, "Tạm Dừng");
        txtCancelPause.add(Language.Type.vi, "Huỷ tạm dừng?");
        txtPausing.add(Language.Type.vi, "Đang tạm dừng");
        txtCannotPause.add(Language.Type.vi, "Không thể tạm dừng");
        txtRequestError.add(Language.Type.vi, "Yêu cầu tạm dừng lỗi");
    }

    #endregion

    #region Refresh

    public Button btnNormal;
    public Text tvNormal;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                PlayNormal playNormal = this.data.playNormal.v.data;
                if (playNormal != null)
                {
                    if (Play.IsCanChange(playNormal, Server.getProfileUserId(playNormal)))
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
                                        if (Server.IsServerOnline(playNormal))
                                        {
                                            playNormal.requestPause(Server.getProfileUserId(playNormal));
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
                                        if (Server.IsServerOnline(playNormal))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            destroyRoutine(wait);
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
                            if (btnNormal != null && tvNormal != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnNormal.interactable = true;
                                            tvNormal.text = txtPause.get();
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnNormal.interactable = true;
                                            tvNormal.text = txtCancelPause.get();
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnNormal.interactable = false;
                                            tvNormal.text = txtPausing.get();
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnPause, tvPause null: " + this);
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
                            if (btnNormal != null && tvNormal != null)
                            {
                                btnNormal.interactable = false;
                                tvNormal.text = txtCannotPause.get();
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
                    // Debug.LogError("playNormal null");
                }
            }
            else
            {
                // Debug.LogError("data null");
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
            Toast.showMessage(txtRequestError.get());
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

    private GameCheckPlayerChange<PlayNormal> gamePlayerCheckChange = new GameCheckPlayerChange<PlayNormal>();
    private RoomCheckChangeAdminChange<PlayNormal> roomCheckAdminChange = new RoomCheckChangeAdminChange<PlayNormal>();
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
                uiData.playNormal.allAddCallBack(this);
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
            if (data is PlayNormal)
            {
                PlayNormal playNormal = data as PlayNormal;
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
                        gamePlayerCheckChange.setData(playNormal);
                    }
                    // roomAdmin
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(playNormal);
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(playNormal, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // CheckChange
            {
                if (data is GameCheckPlayerChange<PlayNormal>)
                {
                    dirty = true;
                    return;
                }
                if (data is RoomCheckChangeAdminChange<PlayNormal>)
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
                uiData.playNormal.allRemoveCallBack(this);
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
            if (data is PlayNormal)
            {
                PlayNormal playNormal = data as PlayNormal;
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
                    DataUtils.removeParentCallBack(playNormal, this, ref this.server);
                }
                return;
            }
            // CheckChange
            {
                if (data is GameCheckPlayerChange<PlayNormal>)
                {
                    return;
                }
                if (data is RoomCheckChangeAdminChange<PlayNormal>)
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
                case UIData.Property.playNormal:
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
            if (wrapProperty.p is PlayNormal)
            {
                switch ((PlayNormal.Property)wrapProperty.n)
                {
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            {
                if (wrapProperty.p is GameCheckPlayerChange<PlayNormal>)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is RoomCheckChangeAdminChange<PlayNormal>)
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnPause()
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
            Debug.LogError("data null: " + this);
        }
    }

}