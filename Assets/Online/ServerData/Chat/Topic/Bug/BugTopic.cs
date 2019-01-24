using UnityEngine;
using System.Collections;

public class BugTopic : Topic
{

	#region Constructor

	public enum Property
	{

	}

	public BugTopic() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Bug;
	}

	public override bool isCanSendNormalMessage (uint userId)
	{
		Server server = this.findDataInParent<Server> ();
		if (server != null) {
			User user = server.findUser (userId);
			if (user != null) {
				if (user.human.v.ban.v.getType() == Ban.Type.Normal) {
					return true;
				} else {
					Debug.LogError ("user is ban: " + user + "; " + this);
					return false;
				}
			} else {
				Debug.LogError ("Cannot find user: " + userId + "; " + this);
				return false;
			}
		} else {
			Debug.LogError ("server null: " + this);
			return false;
		}
	}

}