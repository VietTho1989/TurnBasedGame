using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class WaitInputActionUI : UIBehavior<WaitInputActionUI.UIData>
{

    #region UIData

    public class UIData : GameActionsUI.UIData.Sub
    {

        public VP<ReferenceData<WaitInputAction>> waitInputAction;

        #region Sub

        public abstract class Sub : Data
        {
            public abstract WaitInputAction.Sub.Type getType();
        }

        public VP<Sub> sub;

        #endregion

        public VP<ClientInputUI.UIData> clientInputUIData;

        #region Constructor

        public enum Property
        {
            waitInputAction,
            sub,
            clientInputUIData
        }

        public UIData() : base()
        {
            this.waitInputAction = new VP<ReferenceData<WaitInputAction>>(this, (byte)Property.waitInputAction, new ReferenceData<WaitInputAction>(null));
            this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            this.clientInputUIData = new VP<ClientInputUI.UIData>(this, (byte)Property.clientInputUIData, new ClientInputUI.UIData());
        }

        public override GameAction.Type getType()
        {
            return GameAction.Type.WaitInput;
        }

        #endregion

    }

    #endregion

    #region Refresh

    #region txt

    public Text lbTitle;
    public static readonly TxtLanguage txtTitle = new TxtLanguage();

    public static readonly TxtLanguage txtServerTime = new TxtLanguage();
    public static readonly TxtLanguage txtClientTime = new TxtLanguage();
    public static readonly TxtLanguage txtCheckingLegalMove = new TxtLanguage();
    public static readonly TxtLanguage txtNotReceiveMove = new TxtLanguage();

    static WaitInputActionUI()
    {
        txtTitle.add(Language.Type.vi, "Đang đợi nước đi");
        txtServerTime.add(Language.Type.vi, "Thời Gian Trên Server");
        txtClientTime.add(Language.Type.vi, "Thời Gian Trên Client");
        txtCheckingLegalMove.add(Language.Type.vi, "Đang kiểm tra nước đi hợp lệ");
        txtNotReceiveMove.add(Language.Type.vi, "Chưa nhận nước đi nào cả");
    }

    #endregion

    public Text tvServerTime;
    public Text tvClientTime;
    public Text tvCheckLegalMove;

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                WaitInputAction waitInputAction = this.data.waitInputAction.v.data;
                if (waitInputAction != null)
                {
                    // tvServerTime
                    if (tvServerTime != null)
                    {
                        tvServerTime.text = txtServerTime.get("Server Time") + ": " + waitInputAction.serverTime.v;
                    }
                    else
                    {
                        Debug.LogError("tvServerTime null: " + this);
                    }
                    // tvClientTime
                    if (tvClientTime != null)
                    {
                        tvClientTime.text = txtClientTime.get("Client Time") + ": " + waitInputAction.clientTime.v;
                    }
                    else
                    {
                        Debug.LogError("tvClientTime null: " + this);
                    }
                    // tvCheckLegalMove
                    if (tvCheckLegalMove != null)
                    {
                        if (waitInputAction.inputs.vs.Count > 0)
                        {
                            tvCheckLegalMove.text = txtCheckingLegalMove.get("Checking legal move");
                        }
                        else
                        {
                            tvCheckLegalMove.text = txtNotReceiveMove.get("not receive any move");
                        }
                    }
                    else
                    {
                        Debug.LogError("tvCheckLegalMove null: " + this);
                    }
                    // sub
                    {
                        if (waitInputAction.sub.v != null)
                        {
                            switch (waitInputAction.sub.v.getType())
                            {
                                case WaitInputAction.Sub.Type.Human:
                                    {
                                        WaitHumanInput waitHumanInput = waitInputAction.sub.v as WaitHumanInput;
                                        // UIData
                                        WaitHumanInputUI.UIData waitHumanInputUIData = this.data.sub.newOrOld<WaitHumanInputUI.UIData>();
                                        {
                                            waitHumanInputUIData.waitHumanInput.v = new ReferenceData<WaitHumanInput>(waitHumanInput);
                                        }
                                        this.data.sub.v = waitHumanInputUIData;
                                    }
                                    break;
                                case WaitInputAction.Sub.Type.AI:
                                    {
                                        WaitAIInput waitAIInput = waitInputAction.sub.v as WaitAIInput;
                                        // UIData
                                        WaitAIInputUI.UIData waitAIInputUIData = this.data.sub.newOrOld<WaitAIInputUI.UIData>();
                                        {
                                            waitAIInputUIData.waitAIInput.v = new ReferenceData<WaitAIInput>(waitAIInput);
                                        }
                                        this.data.sub.v = waitAIInputUIData;
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown sub: " + waitInputAction.sub.v + "; " + this);
                                    break;
                            }
                        }
                        else
                        {
                            Debug.LogError("sub null: " + this);
                        }
                        UIRectTransform.SetActive(this.data.sub.v, false);
                    }
                    // clientInputUIData
                    {
                        ClientInputUI.UIData clientInputUIData = this.data.clientInputUIData.v;
                        if (clientInputUIData != null)
                        {
                            clientInputUIData.clientInput.v = new ReferenceData<ClientInput>(waitInputAction.clientInput.v);
                        }
                        else
                        {
                            Debug.LogError("clientInputUIData null: " + this);
                        }
                    }
                    // UI
                    {

                    }
                }
                else
                {
                    // Debug.LogError ("waitInputAction null: " + this);
                }
                // txt
                {
                    if (lbTitle != null)
                    {
                        lbTitle.text = txtTitle.get("Waiting move");
                    }
                    else
                    {
                        Debug.LogError("lbTitle null: " + this);
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

    public WaitHumanInputUI waitHumanInputUIPrefab;
    public WaitAIInputUI waitAIInputUIPrefab;

    public ClientInputUI clientInputUIPrefab;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UIData)
        {
            UIData uiData = data as UIData;
            // Setting
            Setting.get().addCallBack(this);
            // Child
            {
                uiData.sub.allAddCallBack(this);
                uiData.clientInputUIData.allAddCallBack(this);
                uiData.waitInputAction.allAddCallBack(this);
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
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case WaitInputAction.Sub.Type.Human:
                            {
                                WaitHumanInputUI.UIData waitHumanInputUIData = sub as WaitHumanInputUI.UIData;
                                UIUtils.Instantiate(waitHumanInputUIData, waitHumanInputUIPrefab, this.transform, UIConstants.FullParent);
                            }
                            break;
                        case WaitInputAction.Sub.Type.AI:
                            {
                                WaitAIInputUI.UIData waitAIInputUIData = sub as WaitAIInputUI.UIData;
                                UIUtils.Instantiate(waitAIInputUIData, waitAIInputUIPrefab, this.transform, UIConstants.FullParent);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                dirty = true;
                return;
            }
            if (data is ClientInputUI.UIData)
            {
                ClientInputUI.UIData clientInputUIData = data as ClientInputUI.UIData;
                {
                    UIUtils.Instantiate(clientInputUIData, clientInputUIPrefab, this.transform, UIConstants.FullParent);
                }
                dirty = true;
                return;
            }
            // WaitInputAction
            {
                if (data is WaitInputAction)
                {
                    WaitInputAction waitInputAction = data as WaitInputAction;
                    // Child
                    {
                        waitInputAction.sub.allAddCallBack(this);
                        waitInputAction.clientInput.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                {
                    if (data is WaitInputAction.Sub)
                    {
                        dirty = true;
                        return;
                    }
                    if (data is ClientInput)
                    {
                        dirty = true;
                        return;
                    }
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
                uiData.sub.allRemoveCallBack(this);
                uiData.clientInputUIData.allRemoveCallBack(this);
                uiData.waitInputAction.allRemoveCallBack(this);
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
            if (data is UIData.Sub)
            {
                UIData.Sub sub = data as UIData.Sub;
                {
                    switch (sub.getType())
                    {
                        case WaitInputAction.Sub.Type.Human:
                            {
                                WaitHumanInputUI.UIData waitHumanInputUIData = sub as WaitHumanInputUI.UIData;
                                waitHumanInputUIData.removeCallBackAndDestroy(typeof(WaitHumanInputUI));
                            }
                            break;
                        case WaitInputAction.Sub.Type.AI:
                            {
                                WaitAIInputUI.UIData waitAIInputUIData = sub as WaitAIInputUI.UIData;
                                waitAIInputUIData.removeCallBackAndDestroy(typeof(WaitAIInputUI));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
            if (data is ClientInputUI.UIData)
            {
                ClientInputUI.UIData clientInputUIData = data as ClientInputUI.UIData;
                {
                    clientInputUIData.removeCallBackAndDestroy(typeof(ClientInputUI));
                }
                return;
            }
            // WaitInputAction
            {
                if (data is WaitInputAction)
                {
                    WaitInputAction waitInputAction = data as WaitInputAction;
                    // Child
                    {
                        waitInputAction.sub.allRemoveCallBack(this);
                        waitInputAction.clientInput.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                {
                    if (data is WaitInputAction.Sub)
                    {
                        return;
                    }
                    if (data is ClientInput)
                    {
                        return;
                    }
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
                case UIData.Property.waitInputAction:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.sub:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case UIData.Property.clientInputUIData:
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
            if (wrapProperty.p is UIData.Sub)
            {
                return;
            }
            if (wrapProperty.p is ClientInputUI.UIData)
            {
                return;
            }
            // WaitInputAction
            {
                if (wrapProperty.p is WaitInputAction)
                {
                    switch ((WaitInputAction.Property)wrapProperty.n)
                    {
                        case WaitInputAction.Property.serverTime:
                            dirty = true;
                            break;
                        case WaitInputAction.Property.clientTime:
                            dirty = true;
                            break;
                        case WaitInputAction.Property.sub:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case WaitInputAction.Property.inputs:
                            dirty = true;
                            break;
                        case WaitInputAction.Property.clientInput:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        default:
                            Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                {
                    if (wrapProperty.p is WaitInputAction.Sub)
                    {
                        return;
                    }
                    if (wrapProperty.p is ClientInput)
                    {
                        return;
                    }
                }
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}