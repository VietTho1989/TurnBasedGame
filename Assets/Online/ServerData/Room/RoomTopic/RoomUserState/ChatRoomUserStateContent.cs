using UnityEngine;
using System.Collections;

public class ChatRoomUserStateContent : ChatMessage.Content
{

	public VP<uint> userId;

	#region Action

	public enum Action
	{
		Create,
		Join,
		Left,
		Disconnect,
		Kick,
		UnKick,
		Ban
	}

	public VP<Action> action;

	#endregion

	#region Constructor

	public enum Property
	{
		userId,
		action
	}

	public ChatRoomUserStateContent() : base()
	{
		this.userId = new VP<uint> (this, (byte)Property.userId, 0);
		this.action = new VP<Action> (this, (byte)Property.action, Action.Create);
	}

	#endregion

	public override Type getType ()
	{
		return Type.RoomUserState;
	}

    #region get message

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
        string message = "";
        {
            // state
            switch (this.action.v)
            {
                case ChatRoomUserStateContent.Action.Create:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtCreate.get();
                    break;
                case ChatRoomUserStateContent.Action.Join:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtJoin.get();
                    break;
                case ChatRoomUserStateContent.Action.Left:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtLeft.get();
                    break;
                case ChatRoomUserStateContent.Action.Disconnect:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtDisconnect.get();
                    break;
                case ChatRoomUserStateContent.Action.Kick:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtKick.get();
                    break;
                case ChatRoomUserStateContent.Action.UnKick:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtUnKick.get();
                    break;
                case ChatRoomUserStateContent.Action.Ban:
                    message = "<color=grey>" + userName + "</color> " + ChatRoomUserStateUI.txtBan.get();
                    break;
                default:
                    Debug.LogError("unknown action: " + this.action.v + "; " + this);
                    break;
            }
        }
        return message;
    }

    #endregion

}