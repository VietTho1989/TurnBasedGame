using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class RequestNewRoundUI : UIBehavior<RequestNewRoundUI.UIData>
    {

        #region UIData

        public class UIData : Data
        {

            public VP<ReferenceData<RequestNewRound>> requestNewRound;

            #region Sub

            public abstract class Sub : Data
            {

                public abstract RequestNewRound.State.Type getType();

                public abstract bool processEvent(Event e);

            }

            public VP<Sub> sub;

            #endregion

            #region Constructor

            public enum Property
            {
                requestNewRound,
                sub
            }

            public UIData() : base()
            {
                this.requestNewRound = new VP<ReferenceData<RequestNewRound>>(this, (byte)Property.requestNewRound, new ReferenceData<RequestNewRound>(null));
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
                    RequestNewRound requestNewRound = this.data.requestNewRound.v.data;
                    if (requestNewRound != null)
                    {
                        // sub
                        {
                            RequestNewRound.State state = requestNewRound.state.v;
                            if (state != null)
                            {
                                switch (state.getType())
                                {
                                    case RequestNewRound.State.Type.None:
                                        {
                                            RequestNewRoundStateNone requestNewRoundStateNone = state as RequestNewRoundStateNone;
                                            // UIData
                                            RequestNewRoundStateNoneUI.UIData requestNewRoundStateNoneUIData = this.data.sub.newOrOld<RequestNewRoundStateNoneUI.UIData>();
                                            {
                                                requestNewRoundStateNoneUIData.requestNewRoundStateNone.v = new ReferenceData<RequestNewRoundStateNone>(requestNewRoundStateNone);
                                            }
                                            this.data.sub.v = requestNewRoundStateNoneUIData;
                                        }
                                        break;
                                    case RequestNewRound.State.Type.Ask:
                                        {
                                            RequestNewRoundStateAsk requestNewRoundStateAsk = state as RequestNewRoundStateAsk;
                                            // UIData
                                            RequestNewRoundStateAskUI.UIData requestNewRoundStateAskUIData = this.data.sub.newOrOld<RequestNewRoundStateAskUI.UIData>();
                                            {
                                                requestNewRoundStateAskUIData.requestNewRoundStateAsk.v = new ReferenceData<RequestNewRoundStateAsk>(requestNewRoundStateAsk);
                                            }
                                            this.data.sub.v = requestNewRoundStateAskUIData;
                                        }
                                        break;
                                    case RequestNewRound.State.Type.Accept:
                                        {
                                            RequestNewRoundStateAccept requestNewRoundStateAccept = state as RequestNewRoundStateAccept;
                                            // UIData
                                            RequestNewRoundStateAcceptUI.UIData requestNewRoundStateAcceptUIData = this.data.sub.newOrOld<RequestNewRoundStateAcceptUI.UIData>();
                                            {
                                                requestNewRoundStateAcceptUIData.requestNewRoundStateAccept.v = new ReferenceData<RequestNewRoundStateAccept>(requestNewRoundStateAccept);
                                            }
                                            this.data.sub.v = requestNewRoundStateAcceptUIData;
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
                        // Debug.LogError ("requestNewRound null: " + this);
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

        public RequestNewRoundStateNoneUI nonePrefab;
        public RequestNewRoundStateAskUI askPrefab;
        public RequestNewRoundStateAcceptUI acceptPrefab;

        public override void onAddCallBack<T>(T data)
        {
            if (data is UIData)
            {
                UIData uiData = data as UIData;
                // Child
                {
                    uiData.requestNewRound.allAddCallBack(this);
                    uiData.sub.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is RequestNewRound)
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
                            case RequestNewRound.State.Type.None:
                                {
                                    RequestNewRoundStateNoneUI.UIData requestNewRoundStateNone = sub as RequestNewRoundStateNoneUI.UIData;
                                    UIUtils.Instantiate(requestNewRoundStateNone, nonePrefab, this.transform, UIConstants.FullParent);
                                }
                                break;
                            case RequestNewRound.State.Type.Ask:
                                {
                                    RequestNewRoundStateAskUI.UIData requestNewRoundStateAsk = sub as RequestNewRoundStateAskUI.UIData;
                                    UIUtils.Instantiate(requestNewRoundStateAsk, askPrefab, this.transform, UIConstants.FullParent);
                                }
                                break;
                            case RequestNewRound.State.Type.Accept:
                                {
                                    RequestNewRoundStateAcceptUI.UIData requestNewRoundStateAccept = sub as RequestNewRoundStateAcceptUI.UIData;
                                    UIUtils.Instantiate(requestNewRoundStateAccept, acceptPrefab, this.transform, UIConstants.FullParent);
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
                    uiData.requestNewRound.allRemoveCallBack(this);
                    uiData.sub.allRemoveCallBack(this);
                }
                this.setDataNull(uiData);
                return;
            }
            // Child
            {
                if (data is RequestNewRound)
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
                            case RequestNewRound.State.Type.None:
                                {
                                    RequestNewRoundStateNoneUI.UIData requestNewRoundStateNone = sub as RequestNewRoundStateNoneUI.UIData;
                                    requestNewRoundStateNone.removeCallBackAndDestroy(typeof(RequestNewRoundStateNoneUI));
                                }
                                break;
                            case RequestNewRound.State.Type.Ask:
                                {
                                    RequestNewRoundStateAskUI.UIData requestNewRoundStateAsk = sub as RequestNewRoundStateAskUI.UIData;
                                    requestNewRoundStateAsk.removeCallBackAndDestroy(typeof(RequestNewRoundStateAskUI));
                                }
                                break;
                            case RequestNewRound.State.Type.Accept:
                                {
                                    RequestNewRoundStateAcceptUI.UIData requestNewRoundStateAccept = sub as RequestNewRoundStateAcceptUI.UIData;
                                    requestNewRoundStateAccept.removeCallBackAndDestroy(typeof(RequestNewRoundStateAcceptUI));
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
                    case UIData.Property.requestNewRound:
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
                if (wrapProperty.p is RequestNewRound)
                {
                    switch ((RequestNewRound.Property)wrapProperty.n)
                    {
                        case RequestNewRound.Property.state:
                            dirty = true;
                            break;
                        case RequestNewRound.Property.limit:
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