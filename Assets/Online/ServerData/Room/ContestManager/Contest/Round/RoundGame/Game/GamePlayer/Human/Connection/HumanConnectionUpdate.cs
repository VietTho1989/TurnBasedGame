using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanConnectionUpdate : UpdateBehavior<HumanConnection>
{

	#region Update

	private Human serverHuman = null;

	public override void OnDestroy()
	{
		base.OnDestroy ();
		if (this.serverHuman != null) {
			this.serverHuman.removeCallBack (this);
			this.serverHuman = null;
		}
	}

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				// check correct serverHuman
				{
					if (this.serverHuman != null) {
						if (this.serverHuman.playerId.v != this.data.playerId.v) {
							this.serverHuman.removeCallBack (this);
							this.serverHuman = null;
						}
					}
				}
				// find server human
				{
					if (this.serverHuman == null) {
						Server server = this.data.findDataInParent<Server> ();
						if (server != null) {
							User serverUser = server.findUser (this.data.playerId.v);
							if (serverUser != null) {
								this.serverHuman = serverUser.human.v;
								this.serverHuman.addCallBack (this);
							} else {
								Debug.LogError ("serverHuman null: " + this);
							}
						} else {
							Debug.LogError ("server null: " + this);
						}
					}
				}
				// copy
				if (this.serverHuman != null) {
					this.data.connection.v = this.serverHuman.connection.v;
				} else {
					Debug.LogError ("server human null: " + this);
				}
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
		if (data is HumanConnection) {
			dirty = true;
			return;
		}
		if (data is Human) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is HumanConnection) {
			HumanConnection humanConnection = data as HumanConnection;
			// Child
			{

			}
			this.setDataNull (humanConnection);
			return;
		}
		if (data is Human) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is HumanConnection) {
			switch ((HumanConnection.Property)wrapProperty.n) {
			case HumanConnection.Property.playerId:
				dirty = true;
				break;
			case HumanConnection.Property.connection:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is Human) {
			switch ((Human.Property)wrapProperty.n) {
			case Human.Property.playerId:
				dirty = true;
				break;
			case Human.Property.account:
				break;
			case Human.Property.state:
				break;
			case Human.Property.email:
				break;
			case Human.Property.phoneNumber:
				break;
			case Human.Property.status:
				break;
			case Human.Property.birthday:
				break;
			case Human.Property.sex:
				break;
			case Human.Property.connection:
				dirty = true;
				break;
			case Human.Property.ban:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}