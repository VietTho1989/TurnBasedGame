using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class AccountFacebookMessage : MessageBase, AccountMessage
{

	public string userId = "";

	public string firstName = "";

	public string lastName = "";

	public override void Deserialize(NetworkReader reader)
	{
		userId = reader.ReadString ();
		firstName = reader.ReadString ();
		lastName = reader.ReadString ();
	}

	public override void Serialize(NetworkWriter writer)
	{
		writer.Write (userId);
		writer.Write (firstName);
		writer.Write (lastName);
	}

	#region implement base

	public Account.Type getType()
	{
		return Account.Type.FACEBOOK;
	}

	public Account makeAccount()
	{
		AccountFacebook accountFacebook = new AccountFacebook ();
		{
			accountFacebook.userId.v = this.userId;
			accountFacebook.firstName.v = this.firstName;
			accountFacebook.lastName.v = this.lastName;
		}
		return accountFacebook;
	}

	#endregion

	public override string ToString ()
	{
		return string.Format ("[AccountFacebookMessage: {0}, {1}, {2}]", userId, firstName, lastName);
	}

}