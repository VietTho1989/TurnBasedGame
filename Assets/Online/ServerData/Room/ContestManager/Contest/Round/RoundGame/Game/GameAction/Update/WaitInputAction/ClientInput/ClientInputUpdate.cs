using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClientInputUpdate : UpdateBehavior<ClientInput>
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
		if (data is ClientInput) {
			ClientInput clientInput = data as ClientInput;
			// Child
			{
				clientInput.sub.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is ClientInput.Sub) {
			ClientInput.Sub sub = data as ClientInput.Sub;
			{
				switch (sub.getType ()) {
				case ClientInput.Sub.Type.None:
					break;
				case ClientInput.Sub.Type.Send:
					{
						ClientInputSend send = sub as ClientInputSend;
						UpdateUtils.makeUpdate<ClientInputSendUpdate, ClientInputSend> (send, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
					break;
				}
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is ClientInput) {
			ClientInput clientInput = data as ClientInput;
			// Child
			{
				clientInput.sub.allRemoveCallBack (this);
			}
			this.setDataNull (clientInput);
			return;
		}
		// Child
		if (data is ClientInput.Sub) {
			ClientInput.Sub sub = data as ClientInput.Sub;
			{
				switch (sub.getType ()) {
				case ClientInput.Sub.Type.None:
					break;
				case ClientInput.Sub.Type.Send:
					{
						ClientInputSend send = sub as ClientInputSend;
						send.removeCallBackAndDestroy (typeof(ClientInputSendUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + sub.getType () + "; " + this);
					break;
				}
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
		if (wrapProperty.p is ClientInput) {
			switch ((ClientInput.Property)wrapProperty.n) {
			case ClientInput.Property.sub:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is ClientInput.Sub) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}