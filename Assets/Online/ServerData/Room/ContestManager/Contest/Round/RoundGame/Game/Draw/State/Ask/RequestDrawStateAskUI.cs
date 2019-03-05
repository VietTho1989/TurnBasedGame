using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;
using RequestDrawAsk;

public class RequestDrawStateAskUI : UIHaveTransformDataBehavior<RequestDrawStateAskUI.UIData>
{

    #region UIData

    public class UIData : RequestDrawUI.UIData.Sub
    {

        public VP<ReferenceData<RequestDrawStateAsk>> requestDrawStateAsk;

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

        public VP<WhoCanAskAdapter.UIData> whoCanAskAdapter;

        #region Constructor

        public enum Property
        {
            requestDrawStateAsk,
            state,
            whoCanAskAdapter
        }

        public UIData() : base()
        {
            this.requestDrawStateAsk = new VP<ReferenceData<RequestDrawStateAsk>>(this, (byte)Property.requestDrawStateAsk, new ReferenceData<RequestDrawStateAsk>(null));
            this.state = new VP<State>(this, (byte)Property.state, State.None);
            this.whoCanAskAdapter = new VP<WhoCanAskAdapter.UIData>(this, (byte)Property.whoCanAskAdapter, new WhoCanAskAdapter.UIData());
        }

        public override RequestDraw.State.Type getType()
        {
            return RequestDraw.State.Type.Ask;
        }

        #endregion

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

    public Text tvAccept;
    private static readonly TxtLanguage txtAccept = new TxtLanguage();
    private static readonly TxtLanguage txtAccepting = new TxtLanguage();
    private static readonly TxtLanguage txtAlreadyAccept = new TxtLanguage();

    public Text tvRefuse;
    private static readonly TxtLanguage txtRefuse = new TxtLanguage();
    private static readonly TxtLanguage txtRefusing = new TxtLanguage();
    private static readonly TxtLanguage txtAlreadyRefuse = new TxtLanguage();

    public Text tvCannotAnswer;
    private static readonly TxtLanguage txtCannotAnswer = new TxtLanguage();

    private static readonly TxtLanguage txtRequestError = new TxtLanguage();

    static RequestDrawStateAskUI()
    {
        // txt
        {
            txtTitle.add(Language.Type.vi, "Trả Lời Yêu Cầu Hoà");

            // accept
            txtAccept.add(Language.Type.vi, "Chấp Nhận");
            txtAccepting.add(Language.Type.vi, "Đang chấp nhận");
            txtAlreadyAccept.add(Language.Type.vi, "Đã Chấp Nhận");
            // refuse
            txtRefuse.add(Language.Type.vi, "Từ Chối");
            txtRefusing.add(Language.Type.vi, "Đang từ chối");
            txtAlreadyRefuse.add(Language.Type.vi, "Đã Từ Chối");

            txtCannotAnswer.add(Language.Type.vi, "Không có quyền trả lời yêu cầu hoà");
            txtRequestError.add(Language.Type.vi, "Trả lời yêu cầu hoà lỗi");
        }
        // rect
        {
            // whoCanAskAdapterRect
            {
                // anchoredPosition: (0.0, -30.0); anchorMin: (0.0, 1.0); anchorMax: (1.0, 1.0); pivot: (0.5, 1.0);
                // offsetMin: (0.0, -90.0); offsetMax: (0.0, -30.0); sizeDelta: (0.0, 60.0);
                whoCanAskAdapterRect.anchoredPosition = new Vector3(0.0f, -30.0f, 0.0f);
                whoCanAskAdapterRect.anchorMin = new Vector2(0.0f, 1.0f);
                whoCanAskAdapterRect.anchorMax = new Vector2(1.0f, 1.0f);
                whoCanAskAdapterRect.pivot = new Vector2(0.5f, 1.0f);
                whoCanAskAdapterRect.offsetMin = new Vector2(0.0f, -90.0f);
                whoCanAskAdapterRect.offsetMax = new Vector2(0.0f, -30.0f);
                whoCanAskAdapterRect.sizeDelta = new Vector2(0.0f, 60.0f);
            }
        }
    }

    #endregion

    #region Refresh

    public Button btnAccept;
    public Button btnRefuse;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                RequestDrawStateAsk requestDrawStateAsk = this.data.requestDrawStateAsk.v.data;
                if (requestDrawStateAsk != null)
                {
                    // adapter
                    {
                        WhoCanAskAdapter.UIData whoCanAskAdapterUIData = this.data.whoCanAskAdapter.v;
                        if (whoCanAskAdapterUIData != null)
                        {
                            // find requestDraw
                            RequestDraw requestDraw = requestDrawStateAsk.findDataInParent<RequestDraw>();
                            whoCanAskAdapterUIData.requestDraw.v = new ReferenceData<RequestDraw>(requestDraw);
                        }
                        else
                        {
                            Debug.LogError("whoCanAskAdapterUIData null");
                        }
                    }
                    // UI
                    uint profileId = Server.getProfileUserId(requestDrawStateAsk);
                    // check can answer
                    bool canAnswer = false;
                    {
                        RequestDraw requestDraw = requestDrawStateAsk.findDataInParent<RequestDraw>();
                        if (requestDraw != null)
                        {
                            if (requestDraw.getWhoCanAsk().Contains(profileId))
                            {
                                canAnswer = true;
                            }
                        }
                        else
                        {
                            Debug.LogError("requestDraw null");
                        }
                    }
                    // process
                    if (canAnswer)
                    {
                        // Task
                        {
                            switch (this.data.state.v)
                            {
                                case UIData.State.None:
                                    destroyRoutine(wait);
                                    break;
                                case UIData.State.RequestAccept:
                                    {
                                        destroyRoutine(wait);
                                        if (!GameUI.UIData.IsReplay(this.data))
                                        {
                                            if (requestDrawStateAsk.isCanAnswer(profileId, RequestDrawStateAsk.Answer.Accept))
                                            {
                                                if (Server.IsServerOnline(requestDrawStateAsk))
                                                {
                                                    requestDrawStateAsk.requestAnswer(profileId, RequestDrawStateAsk.Answer.Accept);
                                                    this.data.state.v = UIData.State.WaitAccept;
                                                }
                                                else
                                                {
                                                    Debug.LogError("server not online");
                                                }
                                            }
                                            else
                                            {
                                                this.data.state.v = UIData.State.None;
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
                                        if (Server.IsServerOnline(requestDrawStateAsk))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online");
                                            destroyRoutine(wait);
                                            this.data.state.v = UIData.State.None;
                                        }
                                    }
                                    break;
                                case UIData.State.RequestRefuse:
                                    {
                                        destroyRoutine(wait);
                                        if (!GameUI.UIData.IsReplay(this.data))
                                        {
                                            if (requestDrawStateAsk.isCanAnswer(profileId, RequestDrawStateAsk.Answer.Refuse))
                                            {
                                                if (Server.IsServerOnline(requestDrawStateAsk))
                                                {
                                                    requestDrawStateAsk.requestAnswer(profileId, RequestDrawStateAsk.Answer.Refuse);
                                                    this.data.state.v = UIData.State.WaitRefuse;
                                                }
                                                else
                                                {
                                                    Debug.LogError("server not online");
                                                }
                                            }
                                            else
                                            {
                                                this.data.state.v = UIData.State.None;
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
                                        if (Server.IsServerOnline(requestDrawStateAsk))
                                        {
                                            startRoutine(ref this.wait, TaskWait());
                                        }
                                        else
                                        {
                                            Debug.LogError("server not online");
                                            destroyRoutine(wait);
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
                            // visibility
                            {
                                if (btnAccept != null)
                                {
                                    btnAccept.gameObject.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("btnAccept null");
                                }
                                if (btnRefuse != null)
                                {
                                    btnRefuse.gameObject.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("btnRefuse null");
                                }
                                if (tvCannotAnswer != null)
                                {
                                    tvCannotAnswer.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("tvCannotAnswer null");
                                }
                            }
                            // UI
                            {
                                // accept
                                {
                                    if (btnAccept != null && tvAccept != null)
                                    {
                                        if (!requestDrawStateAsk.accepts.vs.Contains(profileId))
                                        {
                                            switch (this.data.state.v)
                                            {
                                                case UIData.State.None:
                                                    {
                                                        btnAccept.interactable = true;
                                                        tvAccept.text = txtAccept.get("Accept");
                                                    }
                                                    break;
                                                case UIData.State.RequestAccept:
                                                    {
                                                        btnAccept.interactable = true;
                                                        tvAccept.text = txtAccepting.get("Accepting");
                                                    }
                                                    break;
                                                case UIData.State.WaitAccept:
                                                    {
                                                        btnAccept.interactable = false;
                                                        tvAccept.text = txtAccepting.get("Accepting");
                                                    }
                                                    break;
                                                case UIData.State.RequestRefuse:
                                                case UIData.State.WaitRefuse:
                                                    {
                                                        btnAccept.interactable = false;
                                                        tvAccept.text = txtAccept.get("Accept");
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown state: " + this.data.state.v);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            btnAccept.interactable = false;
                                            tvAccept.text = txtAlreadyAccept.get("Already Accept");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("btnAccept, tvAccept null");
                                    }
                                }
                                // refuse
                                {
                                    if (btnRefuse != null && tvRefuse != null)
                                    {
                                        if (!requestDrawStateAsk.refuses.vs.Contains(profileId))
                                        {
                                            switch (this.data.state.v)
                                            {
                                                case UIData.State.None:
                                                    {
                                                        btnRefuse.interactable = true;
                                                        tvRefuse.text = txtRefuse.get("Refuse");
                                                    }
                                                    break;
                                                case UIData.State.RequestAccept:
                                                case UIData.State.WaitAccept:
                                                    {
                                                        btnRefuse.interactable = false;
                                                        tvRefuse.text = txtRefuse.get("Refuse");
                                                    }
                                                    break;
                                                case UIData.State.RequestRefuse:
                                                    {
                                                        btnRefuse.interactable = true;
                                                        tvRefuse.text = txtRefusing.get("Refusing");
                                                    }
                                                    break;
                                                case UIData.State.WaitRefuse:
                                                    {
                                                        btnRefuse.interactable = false;
                                                        tvRefuse.text = txtRefusing.get("Refusing");
                                                    }
                                                    break;
                                                default:
                                                    Debug.LogError("unknown state: " + this.data.state.v);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            btnRefuse.interactable = false;
                                            tvRefuse.text = txtAlreadyRefuse.get("Already Refuse");
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("btnRefuse, tvRefuse null");
                                    }
                                }
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
                            if (btnAccept != null)
                            {
                                btnAccept.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("btnAccept null");
                            }
                            if (btnRefuse != null)
                            {
                                btnRefuse.gameObject.SetActive(false);
                            }
                            else
                            {
                                Debug.LogError("btnRefuse null");
                            }
                            if (tvCannotAnswer != null)
                            {
                                tvCannotAnswer.gameObject.SetActive(true);
                            }
                            else
                            {
                                Debug.LogError("tvCannotAnswer null");
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("requestDrawStateAsk null");
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Answer Request Draw");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null");
                    }
                    if (tvCannotAnswer != null)
                    {
                        tvCannotAnswer.text = txtCannotAnswer.get("Cannot answer request draw");
                    }
                    else
                    {
                        Debug.LogError("tvCannotAnswer null");
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
            this.data.state.v = UIData.State.None;
            Toast.showMessage(txtRequestError.get("Answer request draw error"));
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

    private GameIsPlayingChange<RequestDrawStateAsk> gameIsPlayingChange = new GameIsPlayingChange<RequestDrawStateAsk>();

    public WhoCanAskAdapter whoCanAskAdapterPrefab;
    private static readonly UIRectTransform whoCanAskAdapterRect = new UIRectTransform();

    private RequestDraw requestDraw = null;
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
                uiData.requestDrawStateAsk.allAddCallBack(this);
                uiData.whoCanAskAdapter.allAddCallBack(this);
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
            // requestDrawStateAsk
            {
                if (data is RequestDrawStateAsk)
                {
                    RequestDrawStateAsk requestDrawStateAsk = data as RequestDrawStateAsk;
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
                        gameIsPlayingChange.addCallBack(this);
                        gameIsPlayingChange.setData(requestDrawStateAsk);
                    }
                    // Parent
                    {
                        DataUtils.addParentCallBack(requestDrawStateAsk, this, ref this.requestDraw);
                        DataUtils.addParentCallBack(requestDrawStateAsk, this, ref this.server);

                    }
                    dirty = true;
                    return;
                }
                // CheckChange
                if (data is GameIsPlayingChange<RequestDrawStateAsk>)
                {
                    dirty = true;
                    return;
                }
                // parent
                {
                    // requestDraw
                    {
                        if (data is RequestDraw)
                        {
                            RequestDraw requestDraw = data as RequestDraw;
                            // Child
                            {
                                requestDraw.whoCanAsks.allAddCallBack(this);
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
                    if (data is Server)
                    {
                        dirty = true;
                        return;
                    }
                }
            }
            if (data is WhoCanAskAdapter.UIData)
            {
                WhoCanAskAdapter.UIData whoCanAskAdapterUIData = data as WhoCanAskAdapter.UIData;
                // UI
                {
                    UIUtils.Instantiate(whoCanAskAdapterUIData, whoCanAskAdapterPrefab, this.transform, whoCanAskAdapterRect);
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
                uiData.requestDrawStateAsk.allRemoveCallBack(this);
                uiData.whoCanAskAdapter.allRemoveCallBack(this);
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
            // requestDrawStateAsk
            {
                if (data is RequestDrawStateAsk)
                {
                    RequestDrawStateAsk requestDrawStateAsk = data as RequestDrawStateAsk;
                    // CheckChange
                    {
                        gameIsPlayingChange.removeCallBack(this);
                        gameIsPlayingChange.setData(null);
                    }
                    // Parent
                    {
                        DataUtils.removeParentCallBack(requestDrawStateAsk, this, ref this.requestDraw);
                        DataUtils.removeParentCallBack(requestDrawStateAsk, this, ref this.server);
                    }
                    return;
                }
                // CheckChange
                if (data is GameIsPlayingChange<RequestDrawStateAsk>)
                {
                    return;
                }
                // parent
                {
                    // requestDraw
                    {
                        if (data is RequestDraw)
                        {
                            RequestDraw requestDraw = data as RequestDraw;
                            // Child
                            {
                                requestDraw.whoCanAsks.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is Human)
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
                case UIData.Property.requestDrawStateAsk:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.state:
                    dirty = true;
                    break;
                case UIData.Property.whoCanAskAdapter:
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
            // requestDrawStateAsk
            {
                if (wrapProperty.p is RequestDrawStateAsk)
                {
                    switch ((RequestDrawStateAsk.Property)wrapProperty.n)
                    {
                        case RequestDrawStateAsk.Property.accepts:
                            {
                                dirty = true;
                                if (this.data != null)
                                {
                                    this.data.state.v = UIData.State.None;
                                }
                                else
                                {
                                    Debug.LogError("data null");
                                }
                            }
                            break;
                        case RequestDrawStateAsk.Property.refuses:
                            {
                                dirty = true;
                                if (this.data != null)
                                {
                                    this.data.state.v = UIData.State.None;
                                }
                                else
                                {
                                    Debug.LogError("data null");
                                }
                            }
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // CheckChange
                if (wrapProperty.p is GameIsPlayingChange<RequestDrawStateAsk>)
                {
                    dirty = true;
                    return;
                }
                // parent
                {
                    // requestDraw
                    {
                        if (wrapProperty.p is RequestDraw)
                        {
                            switch ((RequestDraw.Property)wrapProperty.n)
                            {
                                case RequestDraw.Property.state:
                                    break;
                                case RequestDraw.Property.whoCanAsks:
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
                        // Child
                        if (wrapProperty.p is Human)
                        {
                            Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
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
            if (wrapProperty.p is WhoCanAskAdapter.UIData)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

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
                    Debug.LogError("unknown state: " + this.data.state.v);
                    break;
            }
        }
        else
        {
            Debug.LogError("data null");
        }
    }

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