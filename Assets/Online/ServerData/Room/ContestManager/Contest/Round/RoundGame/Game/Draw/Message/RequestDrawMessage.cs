using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDrawMessage : ChatMessage.Content
{

    public VP<uint> userId;

    #region action

    public enum Action
    {
        Request,

        AskAccept,
        AskRefuse,

        AcceptAccept,
        AcceptRefuse
    }

    public VP<Action> action;

    #endregion

    #region Constructor

    public enum Property
    {
        userId,
        action
    }

    public RequestDrawMessage() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.action = new VP<Action>(this, (byte)Property.action, Action.Request);
    }

    #endregion

    public override Type getType()
    {
        return Type.RequestDraw;
    }

    public static void Add(Data data, uint userId, Action action)
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
                                RequestDrawMessage content = new RequestDrawMessage();
                                {
                                    content.userId.v = userId;
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

}