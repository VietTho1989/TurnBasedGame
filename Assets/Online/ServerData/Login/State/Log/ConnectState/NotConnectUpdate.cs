using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;

#pragma warning disable CS0618
namespace LoginState
{
    public class NotConnectUpdate : UpdateBehavior<NotConnect>
    {

        #region update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    switch (this.data.state.v)
                    {
                        case NotConnect.State.Start:
                            {
                                destroyRoutine(wait);
                                if (Global.get().networkReachability.v != NetworkReachability.NotReachable)
                                {
                                    this.data.state.v = NotConnect.State.Connect;
                                }
                            }
                            break;
                        case NotConnect.State.Connect:
                            {
                                destroyRoutine(wait);
                                // connect server
                                {
                                    ServerManager clientManager = (ServerManager)NetworkManager.singleton;
                                    if (clientManager != null && clientManager.data != null && clientManager.data.server.v.data != null
                                        && clientManager.data.server.v.data.type.v == Server.Type.Client)
                                    {
                                        // Start Client
                                        if (clientManager.client == null)
                                        {
                                            // Debug.Log ("need to make new client");
                                            clientManager.myStartClient();
                                        }
                                        else
                                        {
                                            // Debug.Log ("user old client");
                                            // only shutdown this client, not ALL clients.
                                            if (!clientManager.client.isConnected)
                                            {
                                                // Debug.LogError ("client not connected");
                                                // Close old
                                                {
                                                    clientManager.client.Disconnect();
                                                    clientManager.client.Shutdown();
                                                    clientManager.client = null;
                                                }
                                                // start Client
                                                clientManager.myStartClient();
                                            }
                                            else
                                            {
                                                // Debug.Log ("client already connected");
                                            }
                                        }
                                        this.data.state.v = NotConnect.State.Wait;
                                    }
                                    else
                                    {
                                        Debug.LogError("error, clientManager null: " + this);
                                        Login login = this.data.findDataInParent<Login>();
                                        if (login != null)
                                        {
                                            None none = new None();
                                            {
                                                none.uid = login.state.makeId();
                                                // state
                                                {
                                                    StateFail stateFail = new StateFail();
                                                    {
                                                        stateFail.uid = none.state.makeId();
                                                        stateFail.reason.v = StateFail.Reason.ConnectFail;
                                                    }
                                                    none.state.v = stateFail;
                                                }
                                            }
                                            login.state.v = none;
                                        }
                                        else
                                        {
                                            Debug.LogError("login null: " + this);
                                        }
                                    }
                                }
                            }
                            break;
                        case NotConnect.State.Wait:
                            {
                                if (Global.get().networkReachability.v != NetworkReachability.NotReachable)
                                {
                                    if (Routine.IsNull(wait))
                                    {
                                        wait = CoroutineManager.StartCoroutine(TaskWait(), this.gameObject);
                                    }
                                    else
                                    {
                                        Debug.LogError("Why routine != null: " + this);
                                    }
                                }
                                else
                                {
                                    this.data.state.v = NotConnect.State.Start;
                                }
                            }
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
                yield return new Wait(240f);
                if (this.data != null)
                {
                    this.data.state.v = NotConnect.State.Start;
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
                Debug.LogError("resend: " + this);
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is NotConnect)
            {
                // NotConnect notConnect = data as NotConnect;
                {

                }
                // Global
                {
                    Global.get().addCallBack(this);
                }
                dirty = true;
                return;
            }
            // Global
            if (data is Global)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is NotConnect)
            {
                NotConnect notConnect = data as NotConnect;
                {

                }
                // Global
                {
                    Global.get().removeCallBack(this);
                }
                this.setDataNull(notConnect);
                return;
            }
            // Global
            if (data is Global)
            {
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is NotConnect)
            {
                switch ((NotConnect.Property)wrapProperty.n)
                {
                    case NotConnect.Property.state:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Global
            if (wrapProperty.p is Global)
            {
                switch ((Global.Property)wrapProperty.n)
                {
                    case Global.Property.networkReachability:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}