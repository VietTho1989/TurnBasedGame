using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DiscoveredServerListUI : UIBehavior<DiscoveredServers>
{
	#region Refresh

	public override void refresh ()
	{
		if (dirty) {
			dirty = false;
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public DiscoveredServerUI serverPrefab;
	public Transform content;

	public override void onAddCallBack<T> (T data)
	{
		if (data is DiscoveredServers) {
			DiscoveredServers discoveredServers = data as DiscoveredServers;
			{
				discoveredServers.servers.allAddCallBack (this);
			}
			return;
		}
		if (data is DiscoveredServer) {
			DiscoveredServer server = data as DiscoveredServer;
			UIUtils.Instantiate<DiscoveredServer> (server, serverPrefab, content);
			return;
		}
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is DiscoveredServers) {
			DiscoveredServers discoveredServers = data as DiscoveredServers;
			{
				for (int i = 0; i < discoveredServers.servers.vs.Count; i++) {
					DiscoveredServer discoveredServer = discoveredServers.servers.vs [i];
					discoveredServer.removeCallBack (this);
				}
			}
			// set data null
			this.setDataNull (discoveredServers);
			return;
		}
		if (data is DiscoveredServer) {
			DiscoveredServer server = data as DiscoveredServer;
			// remove UI
			server.removeCallBackAndDestroy (typeof(DiscoveredServerUI));
			return;
		}
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is DiscoveredServers) {
			switch ((DiscoveredServers.Property)wrapProperty.n) {
			case DiscoveredServers.Property.servers:
				ValueChangeUtils.replaceCallBack (this, syncs);
				break;
			default:
				Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
	}

	#endregion

}