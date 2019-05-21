using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using GamePlayerState;

public class GamePlayerStateSurrenderAskUI : UIHaveTransformDataBehavior<GamePlayerStateSurrenderAskUI.UIData>
{

    #region UIData

    public class UIData : GamePlayerStateSurrenderUI.UIData.Sub
    {

        public VP<ReferenceData<GamePlayerStateSurrenderAsk>> ask;

        public VP<WhoCanAskAdapter.UIData> whoCanAsks;

        #region state

        public enum State
        {
            None,
            RequestAccept,
            WaitAccept,
            RequestRefuse,
            WaitRefuse
        }

        public VP<State> state;

        #endregion

        #region Constructor

        public enum Property
        {
            ask,
            whoCanAsks,
            state
        }

        public UIData() : base()
        {
            this.ask = new VP<ReferenceData<GamePlayerStateSurrenderAsk>>(this, (byte)Property.ask, new ReferenceData<GamePlayerStateSurrenderAsk>(null));
            this.whoCanAsks = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAsks, new WhoCanAskAdapter.UIData());
            this.state = new VP<State>(this, (byte)Property.state, State.None);
        }

        #endregion

        public override GamePlayerStateSurrender.State.Type getType()
        {
            return GamePlayerStateSurrender.State.Type.Ask;
        }

        public void reset()
        {
            this.state.v = State.None;
        }

        public bool processEvent(Event e)
        {
            bool isProcess = false;
            {
                // shortKey
                if (!isProcess)
                {
                    if (Setting.get().useShortKey.v)
                    {
                        GamePlayerStateSurrenderAskUI gamePlayerStateSurrenderAskUI = this.findCallBack<GamePlayerStateSurrenderAskUI>();
                        if (gamePlayerStateSurrenderAskUI != null)
                        {
                            isProcess = gamePlayerStateSurrenderAskUI.useShortKey(e);
                        }
                        else
                        {
                            Debug.LogError("gamePlayerStateSurrenderAskUI null: " + this);
                        }
                    }
                }
            }
            return isProcess;
        }

    }

    #endregion

    public override int getStartAllocate()
    {
        return 1;
    }

    #region txt

    public Text lbTitle;
    private static readonly TxtLanguage txtTitle = new TxtLanguage("Answer request to stop surrendering");

    private static readonly TxtLanguage txtAccept = new TxtLanguage("Accept");
    private static readonly TxtLanguage txtCancelAccept = new TxtLanguage("Cancel accept?");
    private static readonly TxtLanguage txtAccepting = new TxtLanguage("Accepting...");
    private static readonly TxtLanguage txtCannotAccept = new TxtLanguage("Can't accept");

    private static readonly TxtLanguage txtRefuse = new TxtLanguage("Refuse");
    private static readonly TxtLanguage txtCancelRefuse = new TxtLanguage("Cancel refuse?");
    private static readonly TxtLanguage txtRefusing = new TxtLanguage("Refusing...");
    private static readonly TxtLanguage txtCannotRefuse = new TxtLanguage("Can't refuse");

    private static readonly TxtLanguage txtRequestError = new TxtLanguage("Send answer error");

    static GamePlayerStateSurrenderAskUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Trả lời yêu cầu xin ngừng đầu hàng");

            txtAccept.add(Language.Type.vi, "Chấp Nhận");
            txtCancelAccept.add(Language.Type.vi, "Huỷ chấp nhận?");
            txtAccepting.add(Language.Type.vi, "Đang chấp nhận");
            txtCannotAccept.add(Language.Type.vi, "Không thể chấp nhận");

            txtRefuse.add(Language.Type.vi, "Từ Chối");
            txtCancelRefuse.add(Language.Type.vi, "Huỷ từ chối?");
            txtRefusing.add(Language.Type.vi, "Đang từ chối");
            txtCannotRefuse.add(Language.Type.vi, "Không thể từ chối");

            txtRequestError.add(Language.Type.vi, "Gửi câu trả lời lỗi");
        }
        // rect
        {
            // whoCanAskAdapterRect
            {
                // anchoredPosition: (0.0, -24.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -84.0); offsetMax: (0.0, -24.0); sizeDelta: (0.0, 60.0);
                whoCanAskRect.anchoredPosition = new Vector3(0.0f, -24.0f, 0.0f);
                whoCanAskRect.anchorMin = new Vector2(0.0f, 1.0f);
                whoCanAskRect.anchorMax = new Vector2(1.0f, 1.0f);
                whoCanAskRect.pivot = new Vector2(0.5f, 1.0f);
                whoCanAskRect.offsetMin = new Vector2(0.0f, -84.0f);
                whoCanAskRect.offsetMax = new Vector2(0.0f, -24.0f);
                whoCanAskRect.sizeDelta = new Vector2(0.0f, 60.0f);
            }
        }
    }

    #endregion

    #region Refresh

    private bool needReset = true;

    public Button btnAccept;
    public Text tvAccept;

    public Button btnRefuse;
    public Text tvRefuse;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                GamePlayerStateSurrenderAsk ask = this.data.ask.v.data;
                if (ask != null)
                {
                    // whoCanAskAdapter
                    {
                        WhoCanAskAdapter.UIData whoCanAsks = this.data.whoCanAsks.v;
                        if (whoCanAsks != null)
                        {
                            whoCanAsks.ask.v = new ReferenceData<GamePlayerStateSurrenderAsk>(ask);
                        }
                        else
                        {
                            Debug.LogError("whoCanAsks null");
                        }
                    }
                    // reset
                    {
                        if (needReset)
                        {
                            this.data.state.v = UIData.State.None;
                            needReset = false;
                        }
                    }
                    // title
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null");
                        }
                    }
                    uint profileId = Server.getProfileUserId(ask);
                    // Task
                    {
                        switch (this.data.state.v)
                        {
                            case UIData.State.None:
                                {
                                    destroyRoutine(wait);
                                }
                                break;
                            case UIData.State.RequestAccept:
                                {
                                    destroyRoutine(wait);
                                    if (ask.isCanAccept(profileId))
                                    {
                                        if (Server.IsServerOnline(ask))
                                        {
                                            ask.requestAccept(profileId);
                                            this.data.state.v = UIData.State.WaitAccept;
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online: " + this);
                                        }
                                    }
                                    else
                                    {
                                        this.data.state.v = UIData.State.None;
                                    }
                                }
                                break;
                            case UIData.State.WaitAccept:
                                {
                                    if (ask.isCanAccept(profileId))
                                    {
                                        if (Server.IsServerOnline(ask))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            destroyRoutine(wait);
                                            this.data.state.v = UIData.State.None;
                                        }
                                    }
                                    else
                                    {
                                        destroyRoutine(wait);
                                        this.data.state.v = UIData.State.None;
                                    }
                                }
                                break;
                            case UIData.State.RequestRefuse:
                                {
                                    destroyRoutine(wait);
                                    if (ask.isCanRefuse(profileId))
                                    {
                                        if (Server.IsServerOnline(ask))
                                        {
                                            ask.requestRefuse(profileId);
                                            this.data.state.v = UIData.State.WaitRefuse;
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online: " + this);
                                        }
                                    }
                                    else
                                    {
                                        this.data.state.v = UIData.State.None;
                                    }
                                }
                                break;
                            case UIData.State.WaitRefuse:
                                {
                                    if (ask.isCanRefuse(profileId))
                                    {
                                        if (Server.IsServerOnline(ask))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            destroyRoutine(wait);
                                            this.data.state.v = UIData.State.None;
                                        }
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
                        // accept
                        {
                            if (btnAccept != null && tvAccept != null)
                            {
                                if (ask.isCanAccept(profileId))
                                {
                                    btnAccept.interactable = true;
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnAccept.interactable = true;
                                                tvAccept.text = txtAccept.get();
                                            }
                                            break;
                                        case UIData.State.RequestAccept:
                                            {
                                                btnAccept.interactable = true;
                                                tvAccept.text = txtCancelAccept.get();
                                            }
                                            break;
                                        case UIData.State.WaitAccept:
                                            {
                                                btnAccept.interactable = false;
                                                tvAccept.text = txtAccepting.get();
                                            }
                                            break;
                                        case UIData.State.RequestRefuse:
                                            {
                                                btnAccept.interactable = false;
                                                tvAccept.text = txtAccept.get();
                                            }
                                            break;
                                        case UIData.State.WaitRefuse:
                                            {
                                                btnAccept.interactable = false;
                                                tvAccept.text = txtAccept.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    btnAccept.interactable = false;
                                    tvAccept.text = txtCannotAccept.get();
                                }
                            }
                            else
                            {
                                Debug.LogError("btnAccept, tvAccept null: " + this);
                            }
                        }
                        // refuse
                        {
                            if (btnRefuse != null && tvRefuse != null)
                            {
                                if (ask.isCanRefuse(profileId))
                                {
                                    btnRefuse.interactable = true;
                                    switch (this.data.state.v)
                                    {
                                        case UIData.State.None:
                                            {
                                                btnRefuse.interactable = true;
                                                tvRefuse.text = txtRefuse.get();
                                            }
                                            break;
                                        case UIData.State.RequestAccept:
                                            {
                                                btnRefuse.interactable = false;
                                                tvRefuse.text = txtRefuse.get();
                                            }
                                            break;
                                        case UIData.State.WaitAccept:
                                            {
                                                btnRefuse.interactable = false;
                                                tvRefuse.text = txtRefuse.get();
                                            }
                                            break;
                                        case UIData.State.RequestRefuse:
                                            {
                                                btnRefuse.interactable = true;
                                                tvRefuse.text = txtCancelRefuse.get();
                                            }
                                            break;
                                        case UIData.State.WaitRefuse:
                                            {
                                                btnRefuse.interactable = false;
                                                tvRefuse.text = txtRefusing.get();
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown state: " + this.data.state.v + "; " + this);
                                            break;
                                    }
                                }
                                else
                                {
                                    btnRefuse.interactable = false;
                                    tvRefuse.text = txtCannotRefuse.get();
                                }
                            }
                            else
                            {
                                Debug.LogError("btnAccept, tvAccept null: " + this);
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("ask null: " + this);
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

    public WhoCanAskAdapter whoCanAskPrefab;
    private static readonly UIRectTransform whoCanAskRect = new UIRectTransform();

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.ask.allAddCallBack(this);
                uiData.whoCanAsks.allAddCallBack(this);
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
            // ask
            {
                if (data is GamePlayerStateSurrenderAsk)
                {
                    GamePlayerStateSurrenderAsk ask = data as GamePlayerStateSurrenderAsk;
                    // Child
                    {
                        ask.whoCanAsks.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Human)
                {
                    dirty = true;
                    return;
                }
            }
            if (data is WhoCanAskAdapter.UIData)
            {
                WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(whoCanAskAdapterUIData, whoCanAskPrefab, this.transform, whoCanAskRect);
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
                uiData.ask.allRemoveCallBack(this);
                uiData.whoCanAsks.allRemoveCallBack(this);
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
            // ask
            {
                if (data is GamePlayerStateSurrenderAsk)
                {
                    GamePlayerStateSurrenderAsk ask = data as GamePlayerStateSurrenderAsk;
                    // Child
                    {
                        ask.whoCanAsks.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Human)
                {
                    return;
                }
            }
            if (data is WhoCanAskAdapter.UIData)
            {
                WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
                // UI
                {
                    whoCanAskAdapterUIData.removeCallBackAndDestroy(typeof(WhoCanAskAdapter));
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
                case UIData.Property.ask:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.whoCanAsks:
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
            // ask
            {
                if (wrapProperty.p is GamePlayerStateSurrenderAsk)
                {
                    switch ((GamePlayerStateSurrenderAsk.Property)wrapProperty.n)
                    {
                        case GamePlayerStateSurrenderAsk.Property.whoCanAsks:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GamePlayerStateSurrenderAsk.Property.accepts:
                            {
                                needReset = true;
                                dirty = true;
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Human)
                {
                    Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
                    return;
                }
            }
            if (wrapProperty.p is WhoCanAskAdapter.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

    public override void Awake()
    {
        base.Awake();
        // OnClick
        {
            UIUtils.SetButtonOnClick(btnAccept, onClickBtnAccept);
            UIUtils.SetButtonOnClick(btnRefuse, onClickBtnRefuse);
        }
    }

    public bool useShortKey(Event e)
    {
        bool isProcess = false;
        {
            if (e.isKey && e.type == EventType.KeyUp)
            {
                switch (e.keyCode)
                {
                    case KeyCode.A:
                        {
                            if (btnAccept != null && btnAccept.gameObject.activeInHierarchy && btnAccept.interactable)
                            {
                                this.onClickBtnAccept();
                                isProcess = true;
                            }
                            else
                            {
                                Debug.LogError("cannot click");
                            }
                        }
                        break;
                    case KeyCode.R:
                        {
                            if (btnRefuse != null && btnRefuse.gameObject.activeInHierarchy && btnRefuse.interactable)
                            {
                                this.onClickBtnRefuse();
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
    public void onClickBtnAccept()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.RequestAccept;
                    break;
                case UIData.State.RequestAccept:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.WaitAccept:
                    break;
                case UIData.State.RequestRefuse:
                    break;
                case UIData.State.WaitRefuse:
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

    [UnityEngine.Scripting.Preserve]
    public void onClickBtnRefuse()
    {
        if (this.data != null)
        {
            switch (this.data.state.v)
            {
                case UIData.State.None:
                    this.data.state.v = UIData.State.RequestRefuse;
                    break;
                case UIData.State.RequestAccept:
                    break;
                case UIData.State.WaitAccept:
                    break;
                case UIData.State.RequestRefuse:
                    this.data.state.v = UIData.State.None;
                    break;
                case UIData.State.WaitRefuse:
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