using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientOfflineStateUpdate : UpdateBehavior<Server.State.Offline>
{
	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return true;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Server.State.Offline) {
			Server.State.Offline offline = data as Server.State.Offline;
			// Child
			{
				offline.login.allAddCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is Login) {
				Login login = data as Login;
				// Update
				{
					UpdateUtils.makeUpdate<LoginUpdate, Login> (login, this.transform);
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Server.State.Offline) {
			Server.State.Offline offline = data as Server.State.Offline;
			// Child
			{
				offline.login.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (offline);
			return;
		}
		// Child
		{
			if (data is Login) {
				Login login = data as Login;
				// Update
				{
					login.removeCallBackAndDestroy (typeof(LoginUpdate));
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Server.State.Offline) {
			switch ((Server.State.Offline.Property)wrapProperty.n) {
			case Server.State.Offline.Property.login:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is Login) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}