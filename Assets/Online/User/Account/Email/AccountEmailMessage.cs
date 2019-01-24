using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

public class AccountEmailMessage : MessageBase, AccountMessage
{

	public string email = "";

	public string password =  "";

	public override void Deserialize(NetworkReader reader)
	{
		email = reader.ReadString ();
		password = reader.ReadString ();
	}

	public override void Serialize(NetworkWriter writer)
	{
		writer.Write (email);
		writer.Write (password);
	}

	#region implement base

	public Account.Type getType()
	{
		return Account.Type.EMAIL;
	}

	public Account makeAccount()
	{
		AccountEmail accountEmail = new AccountEmail ();
		{
			accountEmail.email.v = this.email;
			accountEmail.password.v = this.password;
		}
		return accountEmail;
	}

	#endregion

	public override string ToString ()
	{
		return string.Format ("[AccountEmailMessage: {0}, {1}]", email, password);
	}

}