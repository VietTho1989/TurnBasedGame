using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountNone : Account
{

	#region Constructor

	public enum Property
	{

	}

	public AccountNone() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.NONE;
	}

	public override void requestUpdate (uint userId, Account account)
	{
		if (account != null && account != this && account is AccountNone) {

		} else {
			Debug.LogError ("not correct account: " + account + "; " + this);
		}
	}

	public override AccountMessage makeAccountMessage ()
	{
		return null;
	}

	public override bool isEqual (AccountMessage accountMessage)
	{
		if (accountMessage.getType() == Type.NONE) {
			return true;
		} else {
			return false;
		}
	}

	public override bool checkCorrectAccount (AccountMessage accountMessage)
	{
		return true;
	}

	public override void updateAccount (AccountMessage accountMessage)
	{
		
	}

	public override string getName ()
	{
		return "";
	}

	public override string getAvatarUrl ()
	{
		return "";
	}

}