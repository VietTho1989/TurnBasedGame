using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AdvancedCoroutines;
using Foundation.Tasks;

public class ClientDisconnectStateUpdate : UpdateBehavior<Server.State.Disconnect>
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
		return false;
	}

	#endregion

	#region Task

	private Routine disconnectTime;

	void Awake() {
		if (Routine.IsNull (disconnectTime)) {
			disconnectTime = CoroutineManager.StartCoroutine (updateDisconnectTime (), this.gameObject);
		} else {
			Debug.LogError ("Why routine != null");
		}
	}

	public override List<Routine> getRoutineList ()
	{
		List<Routine> ret = new List<Routine> ();
		{
			ret.Add (disconnectTime);
		}
		return ret;
	}

	public IEnumerator updateDisconnectTime()
	{
		while (true) {
			yield return new Wait (1f);
			if (this.data != null) {
				this.data.time.v = this.data.time.v + 1;
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Server.State.Disconnect) {
			Server.State.Disconnect disconnect = data as Server.State.Disconnect;
			// Child
			{
				disconnect.login.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is Login) {
			Login login = data as Login;
			// Update
			{
				UpdateUtils.makeUpdate<ClientResumeConnectServerUpdate, Login> (login, this.transform);
				UpdateUtils.makeUpdate<LoginUpdate, Login> (login, this.transform);
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Server.State.Disconnect) {
			Server.State.Disconnect disconnect = data as Server.State.Disconnect;
			// Child
			{
				disconnect.login.allRemoveCallBack (this);
			}
			this.setDataNull (disconnect);
			return;
		}
		// Child
		if (data is Login) {
			Login login = data as Login;
			// Update
			{
				login.removeCallBackAndDestroy (typeof(ClientResumeConnectServerUpdate));
				login.removeCallBackAndDestroy (typeof(LoginUpdate));
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Server.State.Disconnect) {
			switch ((Server.State.Disconnect.Property)wrapProperty.n) {
			case Server.State.Disconnect.Property.login:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Server.State.Disconnect.Property.time:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is Login) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}