using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserHashMap : ValueChangeCallBack
{

	private void addHuman(Human human)
	{
		// TODO Can hoan thien
	}

	private void removeHuman(Human human)
	{
		// TODO Can hoan thien
	}

	public void onAddCallBack<T> (T data) where T:Data
	{
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				server.users.allAddCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is User) {
				User user = data as User;
				// Child
				{
					user.human.allAddCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is Human) {
					Human human = data as Human;
					{
						this.addHuman (human);
					}
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onRemoveCallBack<T> (T data, bool isHide) where T:Data
	{
		if (data is Server) {
			Server server = data as Server;
			// Child
			{
				server.users.allRemoveCallBack (this);
			}
			return;
		}
		// Child
		{
			if (data is User) {
				User user = data as User;
				// Child
				{
					user.human.allRemoveCallBack (this);
				}
				return;
			}
			// Child
			{
				if (data is Human) {
					Human human = data as Human;
					{
						this.removeHuman (human);
					}
					return;
				}
			}
		}
		Debug.LogError ("Don't process: " + data + "; " + this);
	}

	public void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
	{
		if (WrapProperty.checkError (wrapProperty)) {
			return;
		}
		if (wrapProperty.p is Server) {
			switch ((Server.Property)wrapProperty.n) {
			case Server.Property.serverConfig:
				break;
			case Server.Property.startState:
				break;
			case Server.Property.type:
				break;
			case Server.Property.profile:
				break;
			case Server.Property.state:
				break;
			case Server.Property.users:
				{
					ValueChangeUtils.replaceCallBack(this, syncs);
				}
				break;
			case Server.Property.roomManager:
				break;
			case Server.Property.globalChat:
				break;
			case Server.Property.friendWorld:
				break;
			case Server.Property.guilds:
				break;
			default:
				Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
				break;
			}
			return;
		}
		// Child
		{
			if (wrapProperty.p is User) {
				switch ((User.Property)wrapProperty.n) {
				case User.Property.human:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
					}
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
			// Child
			{
				if (wrapProperty.p is Human) {
					switch ((Human.Property)wrapProperty.n) {
					case Human.Property.playerId:
						this.addHuman ((Human)wrapProperty.p);
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
		}
	}

}