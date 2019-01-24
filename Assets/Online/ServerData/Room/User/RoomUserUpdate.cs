using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomUserUpdate : UpdateBehavior<RoomUser>
{

	#region Update

	public override void update ()
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

	public override void onAddCallBack<T> (T data)
	{
		if (data is RoomUser) {
			RoomUser roomUser = data as RoomUser;
			{
				roomUser.inform.allAddCallBack (this);
			}
			return;
		}
		if (data is Human) {
			Human human = data as Human;
			UpdateUtils.makeUpdate<HumanUpdate, Human> (human, this.transform);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is RoomUser) {
			RoomUser roomUser = data as RoomUser;
			{
				roomUser.inform.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (roomUser);
			return;
		}
		if (data is Human) {
			Human human = data as Human;
			human.removeCallBackAndDestroy (typeof(HumanUpdate));
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is RoomUser) {
			switch ((RoomUser.Property)wrapProperty.n) {
			case RoomUser.Property.role:
				break;
			case RoomUser.Property.inform:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
				}
				break;
			case RoomUser.Property.state:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		if (wrapProperty.p is Human) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}