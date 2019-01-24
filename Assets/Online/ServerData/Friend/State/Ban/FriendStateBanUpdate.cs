using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateBanUpdate : UpdateBehavior<FriendStateBan>
{

	#region update

	public override void update ()
	{
		if (dirty) {
			dirty = false;
			if (this.data != null) {
				List<uint> whoCanAnswer = Friend.GetWhoCanAnswer (this.data);
				if (whoCanAnswer.Contains (this.data.userId.v)) {
					// correct ban
				} else {
					// cannot ban, chuyen ve none
					Friend friend = this.data.findDataInParent<Friend>();
					if (friend != null) {
						FriendStateNone friendStateNone = new FriendStateNone();
						{
							friendStateNone.uid = friend.state.makeId ();
						}
						friend.state.v = friendStateNone;
					} else {
						Debug.LogError ("friend null: " + this);
					}
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

	private Friend friend = null;

	public override void onAddCallBack<T> (T data)
	{
		if (data is FriendStateBan) {
			FriendStateBan friendStateBan = data as FriendStateBan;
			// Parent
			{
				DataUtils.addParentCallBack (friendStateBan, this, ref this.friend);
			}
			dirty = true;
			return;
		}
		// Parent
		{
			if (data is Friend) {
				Friend friend = data as Friend;
				// Child
				{
					friend.user1.allAddCallBack (this);
					friend.user2.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Human) {
				dirty = true;
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is FriendStateBan) {
			FriendStateBan friendStateBan = data as FriendStateBan;
			// Parent
			{
				DataUtils.removeParentCallBack (friendStateBan, this, ref this.friend);
			}
			this.setDataNull (friendStateBan);
			return;
		}
		// Parent
		{
			if (data is Friend) {
				Friend friend = data as Friend;
				// Child
				{
					friend.user1.allRemoveCallBack (this);
					friend.user2.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is Human) {
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
		if (wrapProperty.p is FriendStateBan) {
			switch ((FriendStateBan.Property)wrapProperty.n) {
			case FriendStateBan.Property.userId:
				dirty = true;
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Parent
		{
			if (wrapProperty.p is Friend) {
				switch ((Friend.Property)wrapProperty.n) {
				case Friend.Property.state:
					break;
				case Friend.Property.user1:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case Friend.Property.user2:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
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
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
		}
		Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
	}

	#endregion

}