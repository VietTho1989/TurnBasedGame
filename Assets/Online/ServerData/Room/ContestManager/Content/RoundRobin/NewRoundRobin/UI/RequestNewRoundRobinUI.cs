using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
    public class RequestNewRoundRobinUI : UIBehavior<RequestNewRoundRobinUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RequestNewRoundRobin>> requestNewRoundRobin;

            #region Sub

            public abstract class Sub : Data
            {

                public abstract RequestNewRoundRobin.State.Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                requestNewRoundRobin,
                sub
            }

            public UIData() : base()
            {
                this.requestNewRoundRobin = new VP<ReferenceData<RequestNewRoundRobin>>(this, (byte)Property.requestNewRoundRobin, new ReferenceData<RequestNewRoundRobin>(null));
                this.sub = new VP<Sub>(this, (byte)Property.sub, null);
            }

            #endregion

            public bool processEvent(Event e)
            {
                bool isProcess = false;
                {
                    // sub
                    if (!isProcess)
                    {
                        Sub sub = this.sub.v;
                        if (sub != null)
                        {
                            isProcess = sub.processEvent(e);
                        }
                        else
                        {
                            Debug.LogError("sub null: " + this);
                        }
                    }
                }
                return isProcess;
            }

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
                    RequestNewRoundRobin requestNewRoundRobin = this.data.requestNewRoundRobin.v.data;
                    if (requestNewRoundRobin != null)
                    {
                        // sub
                        {
                            RequestNewRoundRobin.State state = requestNewRoundRobin.state.v;
                            if (state != null)
                            {
                                switch (state.getType())
                                {
                                    case RequestNewRoundRobin.State.Type.None:
                                        {
                                            RequestNewRoundRobinStateNone requestNewRoundRobinStateNone = state as RequestNewRoundRobinStateNone;
                                            // UIData
                                            RequestNewRoundRobinStateNoneUI.UIData requestNewRoundRobinStateNoneUIData = this.data.sub.newOrOld<RequestNewRoundRobinStateNoneUI.UIData>();
                                            {
                                                requestNewRoundRobinStateNoneUIData.requestNewRoundRobinStateNone.v = new ReferenceData<RequestNewRoundRobinStateNone>(requestNewRoundRobinStateNone);
                                            }
                                            this.data.sub.v = requestNewRoundRobinStateNoneUIData;
                                        }
                                        break;
                                    case RequestNewRoundRobin.State.Type.Ask:
                                        {
                                            RequestNewRoundRobinStateAsk requestNewRoundRobinStateAsk = state as RequestNewRoundRobinStateAsk;
                                            // UIData
                                            RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAskUIData = this.data.sub.newOrOld<RequestNewRoundRobinStateAskUI.UIData>();
                                            {
                                                requestNewRoundRobinStateAskUIData.requestNewRoundRobinStateAsk.v = new ReferenceData<RequestNewRoundRobinStateAsk>(requestNewRoundRobinStateAsk);
                                            }
                                            this.data.sub.v = requestNewRoundRobinStateAskUIData;
                                        }
                                        break;
                                    case RequestNewRoundRobin.State.Type.Accept:
                                        {
                                            RequestNewRoundRobinStateAccept requestNewRoundRobinStateAccept = state as RequestNewRoundRobinStateAccept;
                                            // UIData
                                            RequestNewRoundRobinStateAcceptUI.UIData requestNewRoundRobinStateAcceptUIData = this.data.sub.newOrOld<RequestNewRoundRobinStateAcceptUI.UIData>();
                                            {
                                                requestNewRoundRobinStateAcceptUIData.requestNewRoundRobinStateAccept.v = new ReferenceData<RequestNewRoundRobinStateAccept>(requestNewRoundRobinStateAccept);
                                            }
                                            this.data.sub.v = requestNewRoundRobinStateAcceptUIData;
                                        }
                                        break;
                                    default:
                                        Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                        break;
                                }
                            }
                            else
                            {
                                Debug.LogError("state null: " + this);
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("requestNewRoundRobin null: " + this);
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

        #region implement callBacks

        public RequestNewRoundRobinStateNoneUI nonePrefab;
        public RequestNewRoundRobinStateAskUI askPrefab;
        public RequestNewRoundRobinStateAcceptUI acceptPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.requestNewRoundRobin.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is RequestNewRoundRobin)
                {
                    dirty = true;
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case RequestNewRoundRobin.State.Type.None:
                                {
                                    RequestNewRoundRobinStateNoneUI.UIData requestNewRoundRobinStateNone = sub as RequestNewRoundRobinStateNoneUI.UIData;
                                    UIUtils.Instantiate(requestNewRoundRobinStateNone, nonePrefab, this.transform, UIConstants.FullParent);
                                }
                                break;
                            case RequestNewRoundRobin.State.Type.Ask:
                                {
                                    RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAsk = sub as RequestNewRoundRobinStateAskUI.UIData;
                                    UIUtils.Instantiate(requestNewRoundRobinStateAsk, askPrefab, this.transform, UIConstants.FullParent);
                                }
                                break;
                            case RequestNewRoundRobin.State.Type.Accept:
                                {
                                    RequestNewRoundRobinStateAcceptUI.UIData requestNewRoundRobinStateAccept = sub as RequestNewRoundRobinStateAcceptUI.UIData;
                                    UIUtils.Instantiate(requestNewRoundRobinStateAccept, acceptPrefab, this.transform, UIConstants.FullParent);
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
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.requestNewRoundRobin.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is RequestNewRoundRobin)
                {
                    return;
                }
                if (data is UIData.Sub)
                {
                    UIData.Sub sub = data as UIData.Sub;
                    // UI
                    {
                        switch (sub.getType())
                        {
                            case RequestNewRoundRobin.State.Type.None:
                                {
                                    RequestNewRoundRobinStateNoneUI.UIData requestNewRoundRobinStateNone = sub as RequestNewRoundRobinStateNoneUI.UIData;
                                    requestNewRoundRobinStateNone.removeCallBackAndDestroy(typeof(RequestNewRoundRobinStateNoneUI));
                                }
                                break;
                            case RequestNewRoundRobin.State.Type.Ask:
                                {
                                    RequestNewRoundRobinStateAskUI.UIData requestNewRoundRobinStateAsk = sub as RequestNewRoundRobinStateAskUI.UIData;
                                    requestNewRoundRobinStateAsk.removeCallBackAndDestroy(typeof(RequestNewRoundRobinStateAskUI));
                                }
                                break;
                            case RequestNewRoundRobin.State.Type.Accept:
                                {
                                    RequestNewRoundRobinStateAcceptUI.UIData requestNewRoundRobinStateAccept = sub as RequestNewRoundRobinStateAcceptUI.UIData;
                                    requestNewRoundRobinStateAccept.removeCallBackAndDestroy(typeof(RequestNewRoundRobinStateAcceptUI));
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
                    case UIData.Property.requestNewRoundRobin:
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
            // Child
            {
                if (wrapProperty.p is RequestNewRoundRobin)
                {
                    switch ((RequestNewRoundRobin.Property)wrapProperty.n)
                    {
                        case RequestNewRoundRobin.Property.state:
                            dirty = true;
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                if (wrapProperty.p is UIData.Sub)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}