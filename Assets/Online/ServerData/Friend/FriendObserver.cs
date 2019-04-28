using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Collections;
using System.Collections.Generic;

public class FriendObserver : GameObserver.CheckChange
{

	public FriendObserver(GameObserver gameObserver) : base(gameObserver)
	{

	}

	#region setData

	private Friend data = null;

	public override void setData(Data newData)
	{
		// set
		if (this.data != newData) {
			// remove old
			if (this.data != null) {
				this.data.removeCallBack (this);
			}
			// set new 
			{
				this.data = newData as Friend;
				if (this.data != null) {
					this.data.addCallBack (this);
				}
			}
		} else {
			// Debug.LogError ("the same: " + this + ", " + data + ", " + newData);
		}
	}

	public override Type getType ()
	{
		return Type.Friend;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is Friend) {
			Friend friend = data as Friend;
			// Child
			{
				friend.user1.allAddCallBack(this);
				friend.user2.allAddCallBack(this);
			}
			// dirty = true;
			// needRefresh = true;
			return;
		}
		// Child
		{
			if (data is Human) {
				Human human = data as Human;
				// Child
				{
					human.state.allAddCallBack (this);
				}
				// dirty = true;
				// needRefresh = true;
				return;
			}
			// Child
			if (data is UserState) {
				return;
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is Friend) {
			Friend friend = data as Friend;
			// Child
			{
				friend.user1.allRemoveCallBack (this);
				friend.user2.allRemoveCallBack (this);
			}
			// set data null
			this.data = null;
			return;
		}
		// Child
		{
			if (data is Human) {
				Human human = data as Human;
				// Child
				{
					human.state.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			if (data is UserState) {
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
		if (wrapProperty.p is Friend) {
			switch ((Friend.Property)wrapProperty.n) {
			case Friend.Property.state:
				break;
			case Friend.Property.user1:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					gameObserver.dirty = true;
					gameObserver.needRefresh = true;
				}
				break;
			case Friend.Property.user2:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					gameObserver.dirty = true;
					gameObserver.needRefresh = true;
				}
				break;
			case Friend.Property.time:
				break;
			case Friend.Property.chatRoom:
				break;
			default:
				Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is Human) {
				switch ((Human.Property)wrapProperty.n) {
				case Human.Property.playerId:
					break;
				case Human.Property.account:
					break;
				case Human.Property.state:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
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
					{
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			if (wrapProperty.p is UserState) {
				switch ((UserState.Property)wrapProperty.n) {
				case UserState.Property.state:
					{
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
					break;
				case UserState.Property.hide:
					{
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
					break;
				case UserState.Property.time:
					{
						gameObserver.dirty = true;
						gameObserver.needRefresh = true;
					}
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

	#region Global

	public override void refreshObserverConnections ()
	{
		gameObserver.allConnections.Clear ();
		if (this.data != null) {
			// User1
			{
				Human user1 = this.data.user1.v;
				// find state
				switch (user1.state.v.state.v) {
				case UserState.State.Online:
					if (user1.connection.v != null) {
						gameObserver.allConnections.Add (user1.connection.v);
					} else {
						Debug.LogError ("user1 connection null");
					}
					break;
				case UserState.State.Disconnect:
					break;
				case UserState.State.Offline:
					break;
				default:
					Debug.LogError ("unknown state: " + user1.state.v);
					break;
				}
			}
			// User2
			{
				Human user2 = this.data.user2.v;
				switch (user2.state.v.state.v) {
				case UserState.State.Online:
					if (user2.connection.v != null) {
						gameObserver.allConnections.Add (user2.connection.v);
					} else {
						Debug.LogError ("user2 connection null");
					}
					break;
				case UserState.State.Disconnect:
					break;
				case UserState.State.Offline:
					break;
				default:
					Debug.LogError ("unknown state: " + user2.state.v);
					break;
				}
			}
		} else {
			Debug.LogError ("data null: " + this);
		}
	}

	public override void onChangeParentObservers (System.Collections.ObjectModel.ReadOnlyCollection<NetworkConnection> parentObserver)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

	#endregion
}