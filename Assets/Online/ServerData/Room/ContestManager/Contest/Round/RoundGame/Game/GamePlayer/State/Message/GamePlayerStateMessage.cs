using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GamePlayerStateMessage : ChatMessage.Content
{

    public VP<uint> userId;

    public VP<int> playerIndex;

    #region action

    public enum Action
    {
        Surrender,
        Cancel,
        AcceptCancel,
        RefuseCancel
    }

    public VP<Action> action;

    #endregion

    #region Constructor

    public enum Property
    {
        userId,
        playerIndex,
        action
    }

    public GamePlayerStateMessage() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.playerIndex = new VP<int>(this, (byte)Property.playerIndex, 0);
        this.action = new VP<Action>(this, (byte)Property.action, Action.Surrender);
    }

    #endregion

    public override Type getType()
    {
        return Type.GamePlayerState;
    }

    public static void Add(Data data, uint userId, int playerIdex, Action action)
    {
        // Debug.LogWarning("AddUndoRedoRequest");
        if (data != null)
        {
            Game game = data.findDataInParent<Game>();
            if (game != null)
            {
                ChatRoom chatRoom = game.chatRoom.v;
                if (chatRoom != null)
                {
                    if (chatRoom.topic.v is GameTopic)
                    {
                        GameTopic gameTopic = chatRoom.topic.v as GameTopic;
                        // Add player
                        chatRoom.addPlayer(userId);
                        // Make new message
                        ChatMessage chatMessage = new ChatMessage();
                        {
                            chatMessage.uid = chatRoom.messages.makeId();
                            // state
                            chatMessage.state.v = ChatMessage.State.Normal;
                            // time
                            chatMessage.time.v = Global.getRealTimeInMiliSeconds();
                            // content
                            {
                                GamePlayerStateMessage content = new GamePlayerStateMessage();
                                {
                                    content.userId.v = userId;
                                    content.playerIndex.v = playerIdex;
                                    content.action.v = action;
                                }
                                chatMessage.content.v = content;
                            }
                        }
                        // Add
                        chatRoom.messages.add(chatMessage);
                    }
                    else
                    {
                        Debug.LogError("why not gameTopic: " + chatRoom.topic.v);
                    }
                }
                else
                {
                    Debug.LogError("chatRoom null");
                }
            }
            else
            {
                Debug.LogError("game null: " + data);
            }
        }
        else
        {
            Debug.LogError("data null");
        }
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
                case GamePlayerStateMessage.Action.Surrender:
                    ret = "<color=grey>" + userName + "</color>(" + GamePlayerStateMessageUI.txtPlayer.get("Player") + " " + this.playerIndex.v + ") " + GamePlayerStateMessageUI.txtSurrender.get("surrender");
                    break;
                case GamePlayerStateMessage.Action.Cancel:
                    ret = "<color=grey>" + userName + "</color> " + GamePlayerStateMessageUI.txtRequest.get("request") + " " + GamePlayerStateMessageUI.txtPlayerLowerCase.get("player") + " " + this.playerIndex.v + " " + GamePlayerStateMessageUI.txtSurrenderCancellation.get(GamePlayerStateMessageUI.DefaultSurrenderCancellation);
                    break;
                case GamePlayerStateMessage.Action.AcceptCancel:
                    ret = "<color=grey>" + userName + "</color> " + GamePlayerStateMessageUI.txtAccept.get("accept") + " " + GamePlayerStateMessageUI.txtPlayerLowerCase.get("player") + " " + this.playerIndex.v + " " + GamePlayerStateMessageUI.txtSurrenderCancellation.get(GamePlayerStateMessageUI.DefaultSurrenderCancellation);
                    break;
                case GamePlayerStateMessage.Action.RefuseCancel:
                    ret = "<color=grey>" + userName + "</color> " + GamePlayerStateMessageUI.txtRefuse.get("refuse") + " " + GamePlayerStateMessageUI.txtPlayerLowerCase.get("player") + " " + this.playerIndex.v + " " + GamePlayerStateMessageUI.txtSurrenderCancellation.get(GamePlayerStateMessageUI.DefaultSurrenderCancellation);
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