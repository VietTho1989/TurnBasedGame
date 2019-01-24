using UnityEngine;
using System.Collections;

public class Login : Data
{

	#region State

	public abstract class State : Data
	{
		
		public enum Type
		{
			None,
			Log
		}

		public abstract Type getType();

	}
		
	public VP<State> state;

	#endregion

	public VP<Account> account;

	#region Constructor

	public enum Property
	{
		state,
		account
	}

	public Login() : base()
	{
		this.state = new VP<State> (this, (byte)Property.state, new LoginState.None ());
		this.account = new VP<Account> (this, (byte)Property.account, null);
	}

	#endregion

}