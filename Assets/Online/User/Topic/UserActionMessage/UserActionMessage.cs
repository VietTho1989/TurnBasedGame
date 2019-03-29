using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserActionMessage : ChatMessage.Content
{

	public VP<uint> userId;

	#region Action

	public enum Action
	{
		Register,
		Login,
		Logout,
		Disconnect,
		Banned,
		UnBanned
	}

	public VP<Action> action;

	#endregion

	#region Constructor

	public enum Property
	{
		userId,
		action
	}

	public UserActionMessage() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		this.action = new VP<Action> (this, (byte)Property.action, Action.Register);
	}

	#endregion

	public override Type getType ()
	{
		return Type.UserAction;
	}

    public override bool isNeedMakeNew()
    {
        return false;
    }

    #region getMessage

    public override string getMessage()
    {
        string ret = "";
        {
            // find userName
            string userName = "";
            {
                Human human = ChatRoom.findHuman(this, this.userId.v);
                if (human != null)
                {
                    userName = human.getPlayerName();
                }
                else
                {
                    Debug.LogError("human null");
                }
            }
            // set
            ret = getMessage(userName);
        }
        return ret;
    }

    public string getMessage(string userName)
    {
        string ret = "";
        {
            switch (this.action.v)
            {
                case UserActionMessage.Action.Register:
                    ret = "<color=grey>" + userName + "</color> " + UserActionMessageUI.txtRegister.get("register");
                    break;
                case UserActionMessage.Action.Login:
                    ret = "<color=grey>" + userName + "</color> " + UserActionMessageUI.txtLogin.get("login");
                    break;
                case UserActionMessage.Action.Logout:
                    ret = "<color=grey>" + userName + "</color> " + UserActionMessageUI.txtLogout.get("logout");
                    break;
                case UserActionMessage.Action.Disconnect:
                    ret = "<color=grey>" + userName + "</color> " + UserActionMessageUI.txtDisconnect.get("disconnect");
                    break;
                case UserActionMessage.Action.Banned:
                    ret = "<color=grey>" + userName + "</color> " + UserActionMessageUI.txtBanned.get("was banned");
                    break;
                case UserActionMessage.Action.UnBanned:
                    ret = "<color=grey>" + userName + "</color> " + UserActionMessageUI.txtUnBanned.get("was unbanned");
                    break;
                default:
                    Debug.LogError("unknown action: " + this.action.v + "; " + this);
                    break;
            }
        }
        return ret;
    }

    #endregion

}