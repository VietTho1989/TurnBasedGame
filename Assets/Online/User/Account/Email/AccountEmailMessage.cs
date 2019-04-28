using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

public class AccountEmailMessage : MessageBase, AccountMessage
{

    public string email = "";

    public string password = "";

    public string customName = "";

    public bool isRegister = false;

    public override void Deserialize(NetworkReader reader)
    {
        email = reader.ReadString();
        password = reader.ReadString();
        customName = reader.ReadString();
        isRegister = reader.ReadBoolean();
    }

    public override void Serialize(NetworkWriter writer)
    {
        writer.Write(email);
        writer.Write(password);
        writer.Write(customName);
        writer.Write(isRegister);
    }

    #region implement base

    public Account.Type getType()
    {
        return Account.Type.EMAIL;
    }

    public Account makeAccount()
    {
        AccountEmail accountEmail = new AccountEmail();
        {
            accountEmail.email.v = this.email;
            accountEmail.password.v = this.password;
            accountEmail.customName.v = this.customName;
            Debug.LogError("makeAccount: " + this.email + ", " + this.password + ", " + this.customName);
        }
        return accountEmail;
    }

    #endregion

    public override string ToString()
    {
        return string.Format("[AccountEmailMessage: {0}, {1}]", email, password);
    }

}