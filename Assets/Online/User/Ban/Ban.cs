using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Ban: Data
{
	public enum Type
	{
		Normal,
		Ban
	}

	public abstract Type getType ();

	public bool isCanBanOrUnBan(uint userId)
	{
		bool ret = true;
		{
			// self ban?
			if (ret) {
				Human human = this.findDataInParent<Human> ();
				if (human != null) {
					if (human.playerId.v == userId) {
						Debug.LogError ("self ban: " + this);
						ret = false;
					}
				} else {
					Debug.LogError ("human null: " + this);
					ret = false;
				}
			}
			// check is normal user
			if (ret) {
				User user = this.findDataInParent<User> ();
				if (user != null) {
					if (user.role.v != User.Role.Normal) {
						Debug.LogError ("not normal user, cannot ban: " + user + "; " + this);
						ret = false;
					}
				} else {
					Debug.LogError ("user null: " + this);
					ret = false;
				}
			}
			// check have right to ban: userId is admin
			if (ret) {
				Server server = this.findDataInParent<Server> ();
				if (server != null) {
					User userRequestBan = server.findUser (userId);
					if (userRequestBan != null) {
						if (userRequestBan.role.v != User.Role.Admin) {
							Debug.LogError ("userRequestBan don't have right to ban: " + userRequestBan + "; " + this);
							ret = false;
						}
					} else {
						Debug.LogError ("cannot find userRequestBan: " + userId + "; " + this);
						ret = false;
					}
				} else {
					Debug.LogError ("server null: " + this);
					ret = false;
				}
			}
		}
		return ret;
	}

}