using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AccountFacebook : Account
{

    public VP<string> userId;

    public VP<string> firstName;

    public VP<string> lastName;

    #region Constructor

    public enum Property
    {
        userId,
        firstName,
        lastName
    }

    public AccountFacebook() : base()
    {
        this.userId = new VP<string>(this, (byte)Property.userId, "");
        this.firstName = new VP<string>(this, (byte)Property.firstName, "");
        this.lastName = new VP<string>(this, (byte)Property.lastName, "");
    }

    #endregion

    public override Type getType()
    {
        return Type.FACEBOOK;
    }

    public override void requestUpdate(uint userId, Account account)
    {
        if (account != null && account != this && account is AccountFacebook)
        {

        }
        else
        {
            Debug.LogError("not correct account: " + account + "; " + this);
        }
    }

    public override AccountMessage makeAccountMessage()
    {
        AccountFacebookMessage accountFacebookMessage = new AccountFacebookMessage();
        {
            accountFacebookMessage.userId = this.userId.v;
            accountFacebookMessage.firstName = this.firstName.v;
            accountFacebookMessage.lastName = this.lastName.v;
        }
        return accountFacebookMessage;
    }

    public override bool isEqual(AccountMessage accountMessage)
    {
        if (accountMessage is AccountFacebookMessage)
        {
            AccountFacebookMessage accountFacebookMessage = accountMessage as AccountFacebookMessage;
            return this.userId.v == accountFacebookMessage.userId;
        }
        else
        {
            return false;
        }
    }

    public override bool checkCorrectAccount(AccountMessage accountMessage)
    {
        return true;
    }

    public override void updateAccount(AccountMessage accountMessage)
    {
        if (accountMessage is AccountFacebookMessage)
        {
            AccountFacebookMessage accountFacebookMessage = accountMessage as AccountFacebookMessage;
            this.firstName.v = accountFacebookMessage.firstName;
            this.lastName.v = accountFacebookMessage.lastName;
        }
        else
        {

        }
    }

    public override string getName()
    {
        return this.firstName.v + " " + this.lastName.v;
    }

    public override string getAvatarUrl()
    {
        return "https://graph.facebook.com/" + this.userId.v + "/picture?type=large";
    }

}