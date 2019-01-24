using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendWorldUpdate : UpdateBehavior<FriendWorld>
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
		if (data is FriendWorld) {
			FriendWorld friendWorld = data as FriendWorld;
			// Child
			{
				friendWorld.friends.allAddCallBack (this);
			}
			return;
		}
		if (data is Friend) {
			Friend friend = data as Friend;
			{
				UpdateUtils.makeUpdate<FriendUpdate, Friend> (friend, this.transform);
			}
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is FriendWorld) {
			FriendWorld friendWorld = data as FriendWorld;
			// Child
			{
				friendWorld.friends.allRemoveCallBack (this);
			}
			// set data null
			this.setDataNull (friendWorld);
			return;
		}
		if (data is Friend) {
			Friend friend = data as Friend;
			{
				friend.removeCallBackAndDestroy (typeof(FriendUpdate));
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
		if (wrapProperty.p is FriendWorld) {
			switch ((FriendWorld.Property)wrapProperty.n) {
			case FriendWorld.Property.friends:
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
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}