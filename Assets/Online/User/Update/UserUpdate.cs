using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserUpdate : UpdateBehavior<User>
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

	#region implement callBack

	public override void onAddCallBack<T> (T data)
	{
		if (data is User) {
			User user = data as User;
			// Update
			{
				UpdateUtils.makeUpdate<UserDisconnectUpdate, User> (user, this.transform);
			}
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is User) {
			User user = data as User;
			// Update
			{
				user.removeCallBackAndDestroy (typeof(UserDisconnectUpdate));
			}
			this.setDataNull (user);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is User) {
			switch ((User.Property)wrapProperty.n) {
			case User.Property.human:
				break;
			case User.Property.role:
				break;
			case User.Property.ipAddress:
				break;
			case User.Property.registerTime:
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