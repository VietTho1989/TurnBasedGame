using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace UndoRedo
{
    public class ProcessIdentity : DataIdentity
    {

        #region SyncVar

        #region index

        [SyncVar(hook = "onChangeIndex")]
        public System.Int32 index;

        public void onChangeIndex(System.Int32 newIndex)
        {
            this.index = newIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.index.v = newIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<Process> netData = new NetData<Process>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeIndex(this.index);
            }
            else
            {
                Debug.Log("clientData null");
            }
        }

        public override int refreshDataSize()
        {
            int ret = GetDataSize(this.netId);
            {
                ret += GetDataSize(this.index);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is Process)
            {
                Process process = data as Process;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, process.makeSearchInforms());
                    this.index = process.index.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(process);
                    }
                    else
                    {
                        Debug.LogError("observer null: " + this);
                    }
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is Process)
            {
                // Process process = data as Process;
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.setCheckChangeData(null);
                    }
                    else
                    {
                        Debug.LogError("observer null: " + this);
                    }
                }
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
            if (wrapProperty.p is Process)
            {
                switch ((Process.Property)wrapProperty.n)
                {
                    case Process.Property.index:
                        this.index = (System.Int32)wrapProperty.getValue();
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}