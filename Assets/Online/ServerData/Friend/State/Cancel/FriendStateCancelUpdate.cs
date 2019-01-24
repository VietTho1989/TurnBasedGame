using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateCancelUpdate : UpdateBehavior<FriendStateCancel>
{

	#region update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				switch (this.data.state.v) {
				case FriendStateCancel.State.Start:
					this.data.state.v = FriendStateCancel.State.End;
					break;
				case FriendStateCancel.State.End:
					{
						Friend friend = this.data.findDataInParent<Friend> ();
						if (friend != null) {
							FriendStateNone friendStateNone = new FriendStateNone ();
							{
								friendStateNone.uid = friend.state.makeId ();
							}
							friend.state.v = friendStateNone;
						} else {
							Debug.LogError ("friend null: " + this);
						}
					}
					break;
				default:
					Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
					break;
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
		if (data is FriendStateCancel) {
			dirty = true;
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is FriendStateCancel) {
			FriendStateCancel friendStateCancel = data as FriendStateCancel;
			{

			}
			this.setDataNull (friendStateCancel);
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if(WrapProperty.checkError(wrapProperty)){
			return;
		}
		if (wrapProperty.p is FriendStateCancel) {
			switch ((FriendStateCancel.Property)wrapProperty.n) {
			case FriendStateCancel.Property.state:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}