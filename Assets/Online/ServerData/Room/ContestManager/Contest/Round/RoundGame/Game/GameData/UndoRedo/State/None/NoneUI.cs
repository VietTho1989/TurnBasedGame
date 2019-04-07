using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
    public class NoneUI : UIHaveTransformDataBehavior<NoneUI.UIData>
    {

        #region UIData

        public class UIData : UndoRedoRequestUI.UIData.Sub
        {

            public VP<ReferenceData<None>> none;

            #region type

            public VP<RequestInform.Type> informType;

            public VP<RequestChangeEnumUI.UIData> requestType;

            public void makeRequestChangeRequestType(RequestChangeUpdate<int>.UpdateData update, int newRequestType)
            {
                this.requestType.v.updateData.v.origin.v = newRequestType;
                this.informType.v = (RequestInform.Type)newRequestType;
            }

            #endregion

            #region Sub

            public abstract class Sub : Data
            {
                public abstract RequestInform.Type getType();
            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                none,
                informType,
                requestType,
                sub
            }

            public UIData() : base()
            {
                this.none = new VP<ReferenceData<None>>(this, (byte)Property.none, new ReferenceData<None>(null));
                this.informType = new VP<RequestInform.Type>(this, (byte)Property.informType, RequestInform.Type.LastYourTurn);
                // lastMoveType
                {
                    this.requestType = new VP<RequestChangeEnumUI.UIData>(this, (byte)Property.requestType, new RequestChangeEnumUI.UIData());
                    this.requestType.v.showDifferent.v = false;
                    // event
                    {
                        this.requestType.v.updateData.v.canRequestChange.v = true;
                        this.requestType.v.updateData.v.request.v = makeRequestChangeRequestType;
                    }
                    // Options
                    foreach (RequestInform.Type type in System.Enum.GetValues(typeof(RequestInform.Type)))
                    {
                        this.requestType.v.options.add(type.ToString());
                    }
                }
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

            public override UndoRedoRequest.State.Type getType()
            {
                return UndoRedoRequest.State.Type.None;
            }

            public override bool processEvent(Event e)
            {
                bool isProcess = false;
                {

                }
                return isProcess;
            }

            public void reset()
            {
                /*this.informType.v = RequestInform.Type.LastYourTurn;
				// dropDown
				RequestChangeEnumUI.UIData lastMoveType = this.requestType.v;
				if (lastMoveType != null) {
					lastMoveType.updateData.v.origin.v = (int)RequestInform.Type.LastYourTurn;
					lastMoveType.updateData.v.current.v = (int)RequestInform.Type.LastYourTurn;
				} else {
					Debug.LogError ("lastMoveType null: " + this);
				}*/
            }

        }

        #endregion

        #region txt

        public Text lbTitle;
        public static readonly TxtLanguage txtTitle = new TxtLanguage("Make Undo/Redo Request");

        public Text lbRequestType;
        public static readonly TxtLanguage txtRequestType = new TxtLanguage("Request type");

        public Text tvCannotRequest;
        public static readonly TxtLanguage txtCannotRequest = new TxtLanguage("Cannot request");

        static NoneUI()
        {
            txtTitle.add(Language.Type.vi, "Tạo Yêu Cầu Undo/Redo");
            txtRequestType.add(Language.Type.vi, "Loại yêu cầu");
            txtCannotRequest.add(Language.Type.vi, "Không thể yêu cầu");
        }

        #endregion

        #region Refresh

        public override void refresh()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    None none = this.data.none.v.data;
                    if (none != null)
                    {
                        // requestType
                        {
                            RequestChangeEnumUI.UIData requestType = this.data.requestType.v;
                            if (requestType != null)
                            {
                                requestType.options.copyList(RequestInform.getStrTypes());
                            }
                            else
                            {
                                Debug.LogError("requestType null");
                            }
                        }
                        // Check can ask
                        bool canAsk = false;
                        {
                            HashSet<uint> whoCanAsks = UndoRedoRequest.getWhoCanAnswer(none);
                            if (whoCanAsks.Contains(Server.getProfileUserId(none)))
                            {
                                canAsk = true;
                            }
                        }
                        // Process
                        if (canAsk)
                        {
                            // tvCannotRequest
                            {
                                if (tvCannotRequest != null)
                                {
                                    tvCannotRequest.gameObject.SetActive(false);
                                }
                                else
                                {
                                    Debug.LogError("tvCannotRequest null");
                                }
                            }
                            // get current type
                            RequestInform.Type type = RequestInform.Type.LastTurn;
                            {
                                RequestChangeEnumUI.UIData requestType = this.data.requestType.v;
                                if (requestType != null)
                                {
                                    type = (RequestInform.Type)requestType.updateData.v.current.v;
                                }
                                else
                                {
                                    Debug.LogError("lastMoveType null: " + this);
                                }
                            }
                            // Update UI
                            {
                                switch (type)
                                {
                                    case RequestInform.Type.LastTurn:
                                        {
                                            if (!(this.data.sub.v is RequestLastTurnUI.UIData))
                                            {
                                                RequestLastTurnUI.UIData requestLastTurnUIData = new RequestLastTurnUI.UIData();
                                                {
                                                    requestLastTurnUIData.uid = this.data.sub.makeId();
                                                    requestLastTurnUIData.requestLastTurn.v = new ReferenceData<RequestLastTurn>(new RequestLastTurn());
                                                }
                                                this.data.sub.v = requestLastTurnUIData;
                                            }
                                        }
                                        break;
                                    case RequestInform.Type.LastYourTurn:
                                        {
                                            if (!(this.data.sub.v is RequestLastYourTurnUI.UIData))
                                            {
                                                RequestLastYourTurnUI.UIData requestLastYourTurnUIData = new RequestLastYourTurnUI.UIData();
                                                {
                                                    requestLastYourTurnUIData.uid = this.data.sub.makeId();
                                                    requestLastYourTurnUIData.requestLastYourTurn.v = new ReferenceData<RequestLastYourTurn>(new RequestLastYourTurn());
                                                }
                                                this.data.sub.v = requestLastYourTurnUIData;
                                            }
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + type + "; " + this);
                                        break;
                                }
                            }
                        }
                        else
                        {
                            // tvCannotRequest
                            {
                                if (tvCannotRequest != null)
                                {
                                    tvCannotRequest.gameObject.SetActive(true);
                                }
                                else
                                {
                                    Debug.LogError("tvCannotRequest null");
                                }
                            }
                            this.data.sub.v = null;
                        }
                    }
                    else
                    {
                        Debug.LogError("none null: " + this);
                    }
                    // UI
                    {
                        float deltaY = 0;
                        // header
                        deltaY += UIConstants.HeaderHeight;
                        // requestType
                        deltaY += UIConstants.ItemHeight;
                        // sub
                        deltaY += UIRectTransform.SetPosY(this.data.sub.v, deltaY);
                        // set
                        // Debug.LogError("noneUI height: " + deltaY);
                        UIRectTransform.SetHeight((RectTransform)this.transform, deltaY);
                    }
                    // txt
                    {
                        if (lbTitle != null)
                        {
                            lbTitle.text = txtTitle.get();
                        }
                        else
                        {
                            Debug.LogError("lbTitle null: " + this);
                        }
                        if (lbRequestType != null)
                        {
                            lbRequestType.text = txtRequestType.get();
                        }
                        else
                        {
                            Debug.LogError("lbRequestType null: " + this);
                        }
                        if (tvCannotRequest != null)
                        {
                            tvCannotRequest.text = txtCannotRequest.get();
                        }
                        else
                        {
                            Debug.LogError("tvCannotRequest null: " + this);
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

        public RequestChangeEnumUI requestEnumPrefab;
        private static readonly UIRectTransform requestTypeRect = new UIRectTransform(UIConstants.RequestEnumRect, UIConstants.HeaderHeight + (UIConstants.ItemHeight - UIConstants.RequestEnumHeight) / 2.0f);

        public RequestLastTurnUI requestLastTurnPrefab;
        public RequestLastYourTurnUI requestLastYourTurnPrefab;

        private CheckWhoCanAskChange<None> checkWhoCanAskChange = new CheckWhoCanAskChange<None>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
                // Child
                {
                    uiData.none.allAddCallBack(this);
                    uiData.requestType.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
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
                // None
                {
                    if (data is None)
                    {
                        None none = data as None;
                        // reset
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
                        // checkChange
                        {
                            checkWhoCanAskChange.addCallBack(this);
                            checkWhoCanAskChange.setData(none);
                        }
                        dirty = true;
                        return;
                    }
                    // CheckChange
                    if (data is CheckWhoCanAskChange<None>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        WrapProperty wrapProperty = requestChange.p;
                        if (wrapProperty != null)
                        {
                            switch ((UIData.Property)wrapProperty.n)
                            {
                                case UIData.Property.requestType:
                                    UIUtils.Instantiate(requestChange, requestEnumPrefab, this.transform, requestTypeRect);
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
                // sub
                {
                    if (data is UIData.Sub)
                    {
                        UIData.Sub sub = data as UIData.Sub;
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case RequestInform.Type.LastTurn:
                                    {
                                        RequestLastTurnUI.UIData requestLastTurnUIData = sub as RequestLastTurnUI.UIData;
                                        UIUtils.Instantiate(requestLastTurnUIData, requestLastTurnPrefab, this.transform);
                                    }
                                    break;
                                case RequestInform.Type.LastYourTurn:
                                    {
                                        RequestLastYourTurnUI.UIData requestLastYourTurnUIData = sub as RequestLastYourTurnUI.UIData;
                                        UIUtils.Instantiate(requestLastYourTurnUIData, requestLastYourTurnPrefab, this.transform);
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        // Child
                        {
                            TransformData.AddCallBack(sub, this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is TransformData)
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
                    uiData.none.allRemoveCallBack(this);
                    uiData.requestType.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
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
                // None
                {
                    if (data is None)
                    {
                        // None none = data as None;
                        // CheckChange
                        {
                            checkWhoCanAskChange.removeCallBack(this);
                            checkWhoCanAskChange.setData(null);
                        }
                        return;
                    }
                    // CheckChange
                    if (data is CheckWhoCanAskChange<None>)
                    {
                        return;
                    }
                }
                if (data is RequestChangeEnumUI.UIData)
                {
                    RequestChangeEnumUI.UIData requestChange = data as RequestChangeEnumUI.UIData;
                    // UI
                    {
                        requestChange.removeCallBackAndDestroy(typeof(RequestChangeEnumUI));
                    }
                    return;
                }
                // sub
                {
                    if (data is UIData.Sub)
                    {
                        UIData.Sub sub = data as UIData.Sub;
                        // Child
                        {
                            TransformData.RemoveCallBack(sub, this);
                        }
                        // UI
                        {
                            switch (sub.getType())
                            {
                                case RequestInform.Type.LastTurn:
                                    {
                                        RequestLastTurnUI.UIData requestLastTurnUIData = sub as RequestLastTurnUI.UIData;
                                        requestLastTurnUIData.removeCallBackAndDestroy(typeof(RequestLastTurnUI));
                                    }
                                    break;
                                case RequestInform.Type.LastYourTurn:
                                    {
                                        RequestLastYourTurnUI.UIData requestLastYourTurnUIData = sub as RequestLastYourTurnUI.UIData;
                                        requestLastYourTurnUIData.removeCallBackAndDestroy(typeof(RequestLastYourTurnUI));
                                    }
                                    break;
                                default:
                                    Debug.LogError("unknown type: " + sub.getType() + "; " + this);
                                    break;
                            }
                        }
                        return;
                    }
                    // Child
                    if (data is TransformData)
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
                    case UIData.Property.none:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case UIData.Property.informType:
                        dirty = true;
                        break;
                    case UIData.Property.requestType:
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
                // None
                {
                    if (wrapProperty.p is None)
                    {
                        return;
                    }
                    // CheckChange
                    if (wrapProperty.p is CheckWhoCanAskChange<None>)
                    {
                        dirty = true;
                        return;
                    }
                }
                if (wrapProperty.p is RequestChangeEnumUI.UIData)
                {
                    return;
                }
                // sub
                {
                    if (wrapProperty.p is UIData.Sub)
                    {
                        return;
                    }
                    // Child
                    if (wrapProperty.p is TransformData)
                    {
                        switch ((TransformData.Property)wrapProperty.n)
                        {
                            case TransformData.Property.anchoredPosition:
                                break;
                            case TransformData.Property.anchorMin:
                                break;
                            case TransformData.Property.anchorMax:
                                break;
                            case TransformData.Property.pivot:
                                break;
                            case TransformData.Property.offsetMin:
                                break;
                            case TransformData.Property.offsetMax:
                                break;
                            case TransformData.Property.sizeDelta:
                                break;
                            case TransformData.Property.rotation:
                                break;
                            case TransformData.Property.scale:
                                break;
                            case TransformData.Property.size:
                                dirty = true;
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}