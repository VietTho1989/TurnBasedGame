using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateUpdate : UpdateBehavior<Friend>
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
		if (data is Friend) {
			Friend friend = data as Friend;
			// Child
			{
				friend.state.allAddCallBack (this);
			}
			dirty = true;
			return;
		}
		// Child
		if (data is Friend.State) {
			Friend.State state = data as Friend.State;
			// Update
			{
				switch (state.getType ()) {
				case Friend.State.Type.None:
					{
						FriendStateNone friendStateNone = state as FriendStateNone;
						UpdateUtils.makeUpdate<FriendStateNoneUpdate, FriendStateNone> (friendStateNone, this.transform);
					}
					break;
				case Friend.State.Type.Request:
					{
						FriendStateRequest friendStateRequest = state as FriendStateRequest;
						UpdateUtils.makeUpdate<FriendStateRequestUpdate, FriendStateRequest> (friendStateRequest, this.transform);
					}
					break;
				case Friend.State.Type.Accept:
					{
						FriendStateAccept friendStateAccept = state as FriendStateAccept;
						UpdateUtils.makeUpdate<FriendStateAcceptUpdate, FriendStateAccept> (friendStateAccept, this.transform);
					}
					break;
				case Friend.State.Type.Cancel:
					{
						FriendStateCancel friendStateCancel = state as FriendStateCancel;
						UpdateUtils.makeUpdate<FriendStateCancelUpdate, FriendStateCancel> (friendStateCancel, this.transform);
					}
					break;
				case Friend.State.Type.Ban:
					{
						FriendStateBan friendStateBan = state as FriendStateBan;
						UpdateUtils.makeUpdate<FriendStateBanUpdate, FriendStateBan> (friendStateBan, this.transform);
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
		if (data is Friend) {
			Friend friend = data as Friend;
			// Child
			{
				friend.state.allRemoveCallBack (this);
			}
			this.setDataNull (friend);
			return;
		}
		// Child
		if (data is Friend.State) {
			Friend.State state = data as Friend.State;
			// Update
			{
				switch (state.getType ()) {
				case Friend.State.Type.None:
					{
						FriendStateNone friendStateNone = state as FriendStateNone;
						friendStateNone.removeCallBackAndDestroy (typeof(FriendStateNoneUpdate));
					}
					break;
				case Friend.State.Type.Request:
					{
						FriendStateRequest friendStateRequest = state as FriendStateRequest;
						friendStateRequest.removeCallBackAndDestroy (typeof(FriendStateRequestUpdate));
					}
					break;
				case Friend.State.Type.Accept:
					{
						FriendStateAccept friendStateAccept = state as FriendStateAccept;
						friendStateAccept.removeCallBackAndDestroy (typeof(FriendStateAcceptUpdate));
					}
					break;
				case Friend.State.Type.Cancel:
					{
						FriendStateCancel friendStateCancel = state as FriendStateCancel;
						friendStateCancel.removeCallBackAndDestroy (typeof(FriendStateCancelUpdate));
					}
					break;
				case Friend.State.Type.Ban:
					{
						FriendStateBan friendStateBan = state as FriendStateBan;
						friendStateBan.removeCallBackAndDestroy (typeof(FriendStateBanUpdate));
					}
					break;
				default:
					Debug.LogError ("unknown type: " + state.getType () + "; " + this);
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
		if (wrapProperty.p is Friend) {
			switch ((Friend.Property)wrapProperty.n) {
			case Friend.Property.state:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					dirty = true;
				}
				break;
			case Friend.Property.user1:
				break;
			case Friend.Property.user2:
				break;
			case Friend.Property.time:
				break;
			case Friend.Property.chatRoom:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		if (wrapProperty.p is Friend.State) {
			return;
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion
}