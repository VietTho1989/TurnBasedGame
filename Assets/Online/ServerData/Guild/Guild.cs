using UnityEngine;
using System.Collections;

public class Guild : Data
{

	public VP<string> guildName;

	public LP<GuildUser> users;

	public VP<ChatRoom> chatRoom;

	#region Constructor

	public enum Property
	{
		guildName,
		users,
		chatRoom
	}

	public Guild() : base()
	{
		this.guildName = new VP<string> (this, (byte)Property.guildName, "");
		this.users = new LP<GuildUser> (this, (byte)Property.users);
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new GuildTopic ();
			}
			this.chatRoom = new VP<ChatRoom> (this, (byte)Property.chatRoom, chatRoom);
		}
	}

	#endregion

}