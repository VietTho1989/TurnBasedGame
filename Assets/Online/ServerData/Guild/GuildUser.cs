using UnityEngine;
using System.Collections;

public class GuildUser : Data
{
	public enum Role
	{
		Normal,
		Admin
	}
	public VP<Role> role;

	public enum State
	{
		Normal,
		Kick
	}
	public VP<State> state;

	public VP<Human> human;

	#region Constructor

	public enum Property
	{
		role,
		state,
		human
	}

	public GuildUser() : base()
	{
		this.role = new VP<Role> (this, (byte)Property.role, Role.Normal);
		this.state = new VP<State> (this, (byte)Property.state, State.Normal);
		this.human = new VP<Human> (this, (byte)Property.human, new Human ());
	}

	#endregion

}