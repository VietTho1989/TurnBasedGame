using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class LimitRoomContainerObserver : GameObserver.CheckChange
{

	public LimitRoomContainerObserver(GameObserver gameObserver) : base(gameObserver)
	{

	}

	#region setData

	public LimitRoomContainer data = null;

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
				this.data = newData as LimitRoomContainer;
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
		return Type.LimitRoomContainer;
	}

	#endregion

	#region implement callBacks

	public override void onAddCallBack<T> (T data)
	{
		if (data is LimitRoomContainer) {
			LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
			// Child
			{
				limitRoomContainer.users.allAddCallBack (this);
			}
			return;
		}
		// Child
		if (data is Human) {
			return;
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public override void onRemoveCallBack<T> (T data, bool isHide)
	{
		if (data is LimitRoomContainer) {
			LimitRoomContainer limitRoomContainer = data as LimitRoomContainer;
			// Child
			{
				limitRoomContainer.users.allRemoveCallBack (this);
			}
			this.data = null;
			return;
		}
		// Child
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
		if (wrapProperty.p is LimitRoomContainer) {
			switch ((LimitRoomContainer.Property)wrapProperty.n) {
			case LimitRoomContainer.Property.maxUserCount:
				break;
			case LimitRoomContainer.Property.userCount:
				break;
			case LimitRoomContainer.Property.users:
				{
					ValueChangeUtils.replaceCallBack (this, syncs);
					gameObserver.dirty = true;
					gameObserver.needRefresh = true;
				}
				break;
			case LimitRoomContainer.Property.gameTypes:
				break;
			case LimitRoomContainer.Property.rooms:
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
				{
					gameObserver.dirty = true;
					gameObserver.needRefresh = true;
				}
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

	public override void refreshObserverConnections ()
	{
		gameObserver.allConnections.Clear ();
		if (this.data != null) {
			List<NetworkConnection> parentConnections = gameObserver.getParentObserver ();
			foreach (Human human in this.data.users.vs) {
				if (human.connection.v != null) {
					if (parentConnections.Contains (human.connection.v)) {
						gameObserver.allConnections.Add (human.connection.v);
					} else {
						Debug.LogError ("why parentConnections not contain: " + human.connection.v);
					}
				}
			}
		} else {
			Debug.LogError ("chatMessage null: " + this);
		}
		// Debug.LogError ("refreshObserverConnections: humConnectionObserver: " + gameObserver.allConnections.Count);
	}

	public override void onChangeParentObservers (System.Collections.ObjectModel.ReadOnlyCollection<NetworkConnection> parentObserver)
	{
		gameObserver.dirty = true;
		gameObserver.needRefresh = true;
	}

}