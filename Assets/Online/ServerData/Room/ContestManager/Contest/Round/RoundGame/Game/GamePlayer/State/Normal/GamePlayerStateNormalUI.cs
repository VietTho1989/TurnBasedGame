using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class GamePlayerStateNormalUI : UIHaveTransformDataBehavior<GamePlayerStateNormalUI.UIData>
{

    #region UIData

    public class UIData : GamePlayerStateUI.UIData.Sub
    {

        public VP<ReferenceData<GamePlayerStateNormal>> normal;

        #region state

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
            normal,
            state
        }

        public UIData() : base()
        {
            this.normal = new VP<ReferenceData<GamePlayerStateNormal>>(this, (byte)Property.normal, new ReferenceData<GamePlayerStateNormal>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override GamePlayer.State.Type getType()
        {
            return GamePlayer.State.Type.Normal;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {

            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage();

    private static readonly TxtLanguage txtSurrender = new TxtLanguage();
    private static readonly TxtLanguage txtCancelSurrender = new TxtLanguage();
    private static readonly TxtLanguage txtSurrenderring = new TxtLanguage();
    private static readonly TxtLanguage txtCannotSurrender = new TxtLanguage();

    private static readonly TxtLanguage txtRequestError = new TxtLanguage();

    static GamePlayerStateNormalUI()
    {
        txtTitle.add(Language.Type.vi, "Bạn có muốn bỏ cuộc không?");

        txtSurrender.add(Language.Type.vi, "Đầu Hàng");
        txtCancelSurrender.add(Language.Type.vi, "Huỷ đầu hàng?");
        txtSurrenderring.add(Language.Type.vi, "Đang đầu hàng");
        txtCannotSurrender.add(Language.Type.vi, "Không thể hàng");

        txtRequestError.add(Language.Type.vi, "Gửi yêu cầu bỏ cuộc lỗi");
    }

    #endregion

    #region Refresh

    public Button btnSurrender;
    public Text tvSurrender;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GamePlayerStateNormal normal = this.data.normal.v.data;
                if (normal != null)
                {
                    uint profileId = Server.getProfileUserId(normal);
                    if (normal.isCanSurrender(profileId))
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
                                        if (Server.IsServerOnline(normal))
                                        {
                                            normal.requestSurrender(profileId);
                                            this.data.state.v = UIData.State.Wait;
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online");
                                        }
                                    }
                                    break;
                                case UIData.State.Wait:
                                    {
                                        if (Server.IsServerOnline(normal))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            this.data.state.v = UIData.State.None;
                                            destroyRoutine(wait);
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
                            if (btnSurrender != null && tvSurrender != null)
                            {
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        {
                                            btnSurrender.interactable = true;
                                            tvSurrender.text = txtSurrender.get("Surrender");
                                        }
                                        break;
                                    case UIData.State.Request:
                                        {
                                            btnSurrender.interactable = true;
                                            tvSurrender.text = txtCancelSurrender.get("Cancel surrender?");
                                        }
                                        break;
                                    case UIData.State.Wait:
                                        {
                                            btnSurrender.interactable = false;
                                            tvSurrender.text = txtSurrenderring.get("Surrendering");
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnSurrender, tvSurrender null: " + this);
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
                            if (btnSurrender != null && tvSurrender != null)
                            {
                                tvSurrender.text = txtCannotSurrender.get("Cannot surrender");
                            }
                            else
                            {
                                Debug.LogError("btnSurrender, tvSurrender null: " + this);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("normal null");
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Do you want to surrender?");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
                    }
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
            Toast.showMessage(txtRequestError.get("send request to surrender error"));
            Debug.LogError("request error: " + this);
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

    private RoomCheckChangeAdminChange<GamePlayerStateNormal> roomCheckAdminChange = new RoomCheckChangeAdminChange<GamePlayerStateNormal>();
    private GameIsPlayingChange<GamePlayerStateNormal> gameIsPlayingChange = new GameIsPlayingChange<GamePlayerStateNormal>();

    private GamePlayer gamePlayer = null;
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
                uiData.normal.allAddCallBack(this);
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
            if (data is GamePlayerStateNormal)
            {
                GamePlayerStateNormal gamePlayerStateNormal = data as GamePlayerStateNormal;
                // CheckChange
                {
                    // check admin
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(gamePlayerStateNormal);
                    }
                    // gameIsPlayingChange
                    {
                        gameIsPlayingChange.addCallBack(this);
                        gameIsPlayingChange.setData(gamePlayerStateNormal);
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(gamePlayerStateNormal, this, ref this.gamePlayer);
                    DataUtils.addParentCallBack(gamePlayerStateNormal, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // CheckChange
            {
                if (data is RoomCheckChangeAdminChange<GamePlayerStateNormal>)
                {
                    dirty = true;
                    return;
                }
                if (data is GameIsPlayingChange<GamePlayerStateNormal>)
                {
                    dirty = true;
                    return;
                }
            }
            // Parent
            {
                // gamePlayer
                {
                    if (data is GamePlayer)
                    {
                        GamePlayer gamePlayer = data as GamePlayer;
                        // Child
                        {
                            gamePlayer.inform.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is GamePlayer.Inform)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is Server)
                {
                    dirty = true;
                    return;
                }
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
                uiData.normal.allRemoveCallBack(this);
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
            if (data is GamePlayerStateNormal)
            {
                GamePlayerStateNormal gamePlayerStateNormal = data as GamePlayerStateNormal;
                // CheckChange
                {
                    // check admin
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                    // gameIsPlayingChange
                    {
                        gameIsPlayingChange.removeCallBack(this);
                        gameIsPlayingChange.setData(null);
                    }
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(gamePlayerStateNormal, this, ref this.gamePlayer);
                    DataUtils.removeParentCallBack(gamePlayerStateNormal, this, ref this.server);
                }
                return;
            }
            // CheckChange
            {
                if (data is RoomCheckChangeAdminChange<GamePlayerStateNormal>)
                {
                    return;
                }
                if (data is GameIsPlayingChange<GamePlayerStateNormal>)
                {
                    return;
                }
            }
            // Parent
            {
                // gamePlayer
                {
                    if (data is GamePlayer)
                    {
                        GamePlayer gamePlayer = data as GamePlayer;
                        // Child
                        {
                            gamePlayer.inform.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is GamePlayer.Inform)
                    {
                        return;
                    }
                }
                if (data is Server)
                {
                    return;
                }
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
                case UIData.Property.normal:
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
        // Child
        {
            if (wrapProperty.p is GamePlayerStateNormal)
            {
                switch ((GamePlayerStateNormal.Property)wrapProperty.n)
                {
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            {
                // check admin change
                if (wrapProperty.p is RoomCheckChangeAdminChange<GamePlayerStateNormal>)
                {
                    dirty = true;
                    return;
                }
                // check is playing
                if (wrapProperty.p is GameIsPlayingChange<GamePlayerStateNormal>)
                {
                    dirty = true;
                    return;
                }
            }
            // Parent
            {
                // gamePlayer
                {
                    if (wrapProperty.p is GamePlayer)
                    {
                        switch ((GamePlayer.Property)wrapProperty.n)
                        {
                            case GamePlayer.Property.playerIndex:
                                break;
                            case GamePlayer.Property.inform:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case GamePlayer.Property.state:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    if (wrapProperty.p is GamePlayer.Inform)
                    {
                        if (wrapProperty.p is Human)
                        {
                            Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                        }
                        return;
                    }
                }
                if (wrapProperty.p is Server)
                {
                    Server.State.OnUpdateSyncStateChange(wrapProperty, this);
                    return;
                }
            }
        }

        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public void onClickBtnSurrender()
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
                    Debug.LogError("You are requesting: " + this);
                    break;
                default:
                    Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

}