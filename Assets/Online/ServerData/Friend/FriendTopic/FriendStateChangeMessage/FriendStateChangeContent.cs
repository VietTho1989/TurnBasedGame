using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FriendStateChangeContent : ChatMessage.Content
{

	public VP<uint> userId;

	#region Action

	public enum Action
	{
		Request,
		Accept,
		Refuse,
		Cancel,
		UnFriend,
		Ban,
		UnBan
	}

	public VP<Action> action;

	#endregion

	#region Constructor

	public enum Property
	{
		userId,
		action
	}

	public FriendStateChangeContent() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		this.action = new VP<Action> (this, (byte)Property.action, Action.Request);
	}

	#endregion

	public override Type getType ()
	{
		return Type.FriendStateChange;
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
                case FriendStateChangeContent.Action.Request:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtRequest.get();
                    break;
                case FriendStateChangeContent.Action.Accept:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtAccept.get();
                    break;
                case FriendStateChangeContent.Action.Refuse:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtRefuse.get();
                    break;
                case FriendStateChangeContent.Action.Cancel:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtCancel.get();
                    break;
                case FriendStateChangeContent.Action.UnFriend:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtUnFriend.get();
                    break;
                case FriendStateChangeContent.Action.Ban:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtBan.get();
                    break;
                case FriendStateChangeContent.Action.UnBan:
                    ret = "<color=grey>" + userName + "</color> " + FriendStateChangeContentUI.txtUnBan.get();
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