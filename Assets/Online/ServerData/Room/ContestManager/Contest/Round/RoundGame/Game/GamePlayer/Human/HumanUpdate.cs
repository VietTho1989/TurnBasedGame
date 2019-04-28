using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class HumanUpdate : UpdateBehavior<Human>
{

    #region Update

    private Human serverHuman = null;

    public override void OnDestroy()
    {
        base.OnDestroy();
        if (this.serverHuman != null)
        {
            this.serverHuman.removeCallBack(this);
            this.serverHuman = null;
        }
    }

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // check correct serverHuman
                {
                    if (this.serverHuman != null)
                    {
                        if (this.serverHuman.playerId.v != this.data.playerId.v)
                        {
                            this.serverHuman.removeCallBack(this);
                            this.serverHuman = null;
                        }
                    }
                }
                // find server human
                {
                    if (this.serverHuman == null)
                    {
                        Server server = this.data.findDataInParent<Server>();
                        if (server != null)
                        {
                            User serverUser = server.users.getInList(this.data.playerId.v);
                            if (serverUser != null)
                            {
                                this.serverHuman = serverUser.human.v;
                                this.serverHuman.addCallBack(this);
                            }
                            else
                            {
                                Debug.LogError("serverHuman null: " + this + ", " + this.data.playerId.v);
                            }
                        }
                        else
                        {
                            Debug.LogError("server null: " + this);
                        }
                    }
                }
                // copy
                if (serverHuman != null)
                {
                    DataUtils.copyData(this.data, serverHuman);
                }
                else
                {
                    Debug.LogError("server human null: " + this);
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
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is Human)
        {
            Human human = data as Human;
            // Child
            {
                human.addCallBackAllChildren(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            data.addCallBackAllChildren(this);
            dirty = true;
            return;
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is Human)
        {
            Human human = data as Human;
            // Child
            {
                human.removeCallBackAllChildren(this);
            }
            if (this.data == human)
            {
                this.setDataNull(human);
            }
            return;
        }
        // Child
        {
            data.removeCallBackAllChildren(this);
            return;
        }
        // Debug.LogError ("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is Human)
        {
            if (Generic.IsAddCallBackInterface<T>())
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (Generic.IsAddCallBackInterface<T>())
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            dirty = true;
            return;
        }
        // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}