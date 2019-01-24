using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;
using Foundation.Server;
using Foundation.Server.Api;
using Foundation.Tasks;

public class LoginUpdate : UpdateBehavior<Login>
{

	#region Update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {

			} else {
				// Debug.LogError ("login null");
			}
		}
	}

	public override bool isShouldDisableUpdate ()
	{
		return false;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Login) {
			Login login = data as Login;
			// Child
			{
				login.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		{
			if (data is Login.State) {
				Login.State state = data as Login.State;
				// Child
				{
					switch (state.getType ()) {
					case Login.State.Type.None:
						{
							LoginState.None none = state as LoginState.None;
							UpdateUtils.makeUpdate<LoginState.NoneUpdate, LoginState.None> (none, this.transform);
						}
						break;
					case Login.State.Type.Log:
						{
							LoginState.Log log = state as LoginState.Log;
							UpdateUtils.makeUpdate<LoginState.LogUpdate, LoginState.Log> (log, this.transform);
						}
						break;
					default:
						Debug.LogError ("unknown type: " + this);
						break;
					}
				}
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Login) {
			Login login = data as Login;
			// Child
			{
				login.state.allRemoveCallBack (this);
			}
			this.setDataNull (login);
			return;
		}
		// Child
		{
			if (data is Login.State) {
				Login.State state = data as Login.State;
				// Child
				{
					switch (state.getType ()) {
					case Login.State.Type.None:
						{
							LoginState.None none = state as LoginState.None;
							none.removeCallBackAndDestroy (typeof(LoginState.NoneUpdate));
						}
						break;
					case Login.State.Type.Log:
						{
							LoginState.Log log = state as LoginState.Log;
							log.removeCallBackAndDestroy (typeof(LoginState.LogUpdate));
						}
						break;
					default:
						Debug.LogError ("unknown type: " + this);
						break;
					}
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
		if (wrapProperty.p is Login) {
			switch ((Login.Property)wrapProperty.n) {
			case Login.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Login.Property.account:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is Login.State) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}