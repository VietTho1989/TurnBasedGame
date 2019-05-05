using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscoveredServerListUI : UIBehavior<DiscoveredServers>
{

    #region Refresh

    public override void refresh()
    {
        if (dirty)
        {
            dirty = false;
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public DiscoveredServerUI serverPrefab;
    public Transform content;

    public override void onAddCallBack<T>(T data)
    {
        if (data is DiscoveredServers)
        {
            DiscoveredServers discoveredServers = data as DiscoveredServers;
            // Child
            {
                discoveredServers.servers.allAddCallBack(this);
            }
            return;
        }
        // Child
        if (data is DiscoveredServer)
        {
            DiscoveredServer server = data as DiscoveredServer;
            // UI
            {
                UIUtils.Instantiate(server, serverPrefab, content);
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is DiscoveredServers)
        {
            DiscoveredServers discoveredServers = data as DiscoveredServers;
            // Child
            {
                discoveredServers.servers.allRemoveCallBack(this);
            }
            // set data null
            this.setDataNull(discoveredServers);
            return;
        }
        // UI
        if (data is DiscoveredServer)
        {
            DiscoveredServer server = data as DiscoveredServer;
            // UI
            {
                server.removeCallBackAndDestroy(typeof(DiscoveredServerUI));
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
        if (wrapProperty.p is DiscoveredServers)
        {
            switch ((DiscoveredServers.Property)wrapProperty.n)
            {
                case DiscoveredServers.Property.servers:
                    ValueChangeUtils.replaceCallBack(this, syncs);
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        if(wrapProperty.p is DiscoveredServer)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}