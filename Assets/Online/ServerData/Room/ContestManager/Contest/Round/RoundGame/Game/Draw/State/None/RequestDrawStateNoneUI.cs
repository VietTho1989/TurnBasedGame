using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

public class RequestDrawStateNoneUI : UIHaveTransformDataBehavior<RequestDrawStateNoneUI.UIData>
{

    #region UIData

    public class UIData : RequestDrawUI.UIData.Sub
    {

        public VP<ReferenceData<RequestDrawStateNone>> requestDrawStateNone;

        #region State

        public enum State
        {
            None,
            Request,
            Wait
        }

        public VP<State> state;

        #endregion

        #region UIData

        public enum Property
        {
            requestDrawStateNone,
            state
        }

        public UIData() : base()
        {
            this.requestDrawStateNone = new VP<ReferenceData<RequestDrawStateNone>>(this, (byte)Property.requestDrawStateNone, new ReferenceData<RequestDrawStateNone>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override RequestDraw.State.Type getType()
        {
            return RequestDraw.State.Type.None;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

        public override bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        RequestDrawStateNoneUI requestDrawStateNoneUI = this.findCallBack<RequestDrawStateNoneUI>();
                        if (requestDrawStateNoneUI != null)
                        {
                            isProcess = requestDrawStateNoneUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("requestDrawStateNoneUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Make Request Draw");

    public Text tvRequest;
    private static readonly TxtLanguage txtRequestNone = new TxtLanguage("Request Draw");
    private static readonly TxtLanguage txtRequestRequest = new TxtLanguage("Requesting draw");

    public Text tvCannotRequest;
    private static readonly TxtLanguage txtCannotRequest = new TxtLanguage("Cannot make request draw");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Send request draw error");

    static RequestDrawStateNoneUI()
    {
        txtTitle.add(Language.Type.vi, "Gửi Yêu Cầu Hoà");
        // request
        {
            txtRequestNone.add(Language.Type.vi, "Cầu Hoà");
            txtRequestRequest.add(Language.Type.vi, "Đang cầu hoà");
        }
        txtCannotRequest.add(Language.Type.vi, "Không thể gửi yêu cầu hoà");
        txtRequestError.add(Language.Type.vi, "Gửi yêu cầu hoà lỗi");
    }

    #endregion

    #region Refresh

    public Button btnRequestDraw;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestDrawStateNone requestDrawStateNone = this.data.requestDrawStateNone.v.data;
                if (requestDrawStateNone != null)
                {
                    // check can request draw
                    uint userId = Server.getProfileUserId(requestDrawStateNone);
                    if (requestDrawStateNone.isCanRequestDraw(userId))
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
                                        // request
                                        if (Server.IsServerOnline(requestDrawStateNone))
                                        {
                                            if (!GameUI.UIData.IsReplay(this.data))
                                            {
                                                requestDrawStateNone.requestMakeRequestDraw(userId);
                                            }
                                            else
                                            {
                                                Debug.LogError("this is replay, cannot request: " + this);
                                            }
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
                                        if (Server.IsServerOnline(requestDrawStateNone))
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
                                    Debug.LogError("unknown state: " + this.data.state.v);
                                    break;
                            }
                        }
                        // UI
                        {
                            if (btnRequestDraw != null)
                            {
                                btnRequestDraw.gameObject.SetActive(true);
                                switch (this.data.state.v)
                                {
                                    case UIData.State.None:
                                        btnRequestDraw.interactable = true;
                                        break;
                                    case UIData.State.Request:
                                        btnRequestDraw.interactable = true;
                                        break;
                                    case UIData.State.Wait:
                                        btnRequestDraw.interactable = false;
                                        break;
                                    default:
                                        Debug.LogError("unknown state: " + this.data.state.v);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("btnRequestDraw null");
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
                            if (btnRequestDraw != null)
                            {
                                btnRequestDraw.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("btnRequestDraw null");
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestDrawStateNone null");
                }
                // UI
                {
                    float buttonSize = Setting.get().getButtonSize();
                    float deltaY = 0;
                    // header
                    {
                        UIRectTransform.SetTitleTransform(lbTitle);
                        deltaY += buttonSize;
                    }
                    // content
                    {
                        if (btnRequestDraw != null)
                        {
                            UIRectTransform.SetPosY((RectTransform)btnRequestDraw.transform, deltaY + 10);
                        }
                        else
                        {
                            Debug.LogError("btnRequestDraw null");
                        }
                        if (tvCannotRequest != null)
                        {
                            UIRectTransform.SetPosY(tvCannotRequest.rectTransform, deltaY);
                        }
                        else
                        {
                            Debug.LogError("tvCannotRequest null");
                        }
                        deltaY += 50;
                    }
                    // set height
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
                    if (tvRequest != null)
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                tvRequest.text = txtRequestNone.get();
                                break;
                            case UIData.State.Request:
                            case UIData.State.Wait:
                                tvRequest.text = txtRequestRequest.get();
                                break;
                            default:
                                Debug.LogError("unknown state: " + this.data.state.v);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("tvRequest null");
                    }
                    if (tvCannotRequest != null)
                    {
                        tvCannotRequest.text = txtCannotRequest.get();
                    }
                    else
                    {
                        Debug.LogError("tvCannotRequest null");
                    }
                }
            }
            else
            {
                // Debug.LogError ("data null");
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
            this.data.state.v = UIData.State.None;
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

    private GameIsPlayingChange<RequestDrawStateNone> gameIsPlayingChange = new GameIsPlayingChange<RequestDrawStateNone>();
    private GameCheckPlayerChange<RequestDrawStateNone> gameCheckPlayerChange = new GameCheckPlayerChange<RequestDrawStateNone>();
    private RoomCheckChangeAdminChange<RequestDrawStateNone> roomCheckAdminChange = new RoomCheckChangeAdminChange<RequestDrawStateNone>();

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
                uiData.requestDrawStateNone.allAddCallBack(this);
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
            if (data is RequestDrawStateNone)
            {
                RequestDrawStateNone requestDrawStateNone = data as RequestDrawStateNone;
                // reset
                {
                    if (this.data != null)
                    {
                        this.data.reset();
                    }
                    else
                    {
                        Debug.LogError("data null");
                    }
                }
                // CheckChange
                {
                    // isPlaying
                    {
                        gameIsPlayingChange.addCallBack(this);
                        gameIsPlayingChange.setData(requestDrawStateNone);
                    }
                    // gamePlayer
                    {
                        gameCheckPlayerChange.addCallBack(this);
                        gameCheckPlayerChange.setData(requestDrawStateNone);
                    }
                    // roomCheckAdminChange
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(requestDrawStateNone);
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(requestDrawStateNone, this, ref this.server);
                }
                dirty = true;
                return;
            }
            // CheckChange
            {
                if (data is GameIsPlayingChange<RequestDrawStateNone>)
                {
                    dirty = true;
                    return;
                }
                if (data is GameCheckPlayerChange<RequestDrawStateNone>)
                {
                    dirty = true;
                    return;
                }
                if (data is RoomCheckChangeAdminChange<RequestDrawStateNone>)
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
                uiData.requestDrawStateNone.allRemoveCallBack(this);
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
            if (data is RequestDrawStateNone)
            {
                RequestDrawStateNone requestDrawStateNone = data as RequestDrawStateNone;
                // CheckChange
                {
                    // isPlaying
                    {
                        gameIsPlayingChange.removeCallBack(this);
                        gameIsPlayingChange.setData(null);
                    }
                    // gamePlayer
                    {
                        gameCheckPlayerChange.removeCallBack(this);
                        gameCheckPlayerChange.setData(null);
                    }
                    // roomCheckAdminChange
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(requestDrawStateNone, this, ref this.server);
                }
                return;
            }
            // CheckChange
            {
                if (data is GameIsPlayingChange<RequestDrawStateNone>)
                {
                    return;
                }
                if (data is GameCheckPlayerChange<RequestDrawStateNone>)
                {
                    return;
                }
                if (data is RoomCheckChangeAdminChange<RequestDrawStateNone>)
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
                case UIData.Property.requestDrawStateNone:
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
            if (wrapProperty.p is RequestDrawStateNone)
            {
                switch ((RequestDrawStateNone.Property)wrapProperty.n)
                {
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            {
                if (wrapProperty.p is GameIsPlayingChange<RequestDrawStateNone>)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is GameCheckPlayerChange<RequestDrawStateNone>)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is RoomCheckChangeAdminChange<RequestDrawStateNone>)
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

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.R:
                        {
                            if (btnRequestDraw != null && btnRequestDraw.gameObject.activeInHierarchy && btnRequestDraw.interactable)
                            {
                                this.onClickBtnRequestDraw();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        return isProcess;
    }

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRequestDraw()
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