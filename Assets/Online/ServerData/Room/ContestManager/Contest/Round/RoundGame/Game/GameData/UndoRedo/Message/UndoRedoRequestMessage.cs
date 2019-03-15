using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UndoRedoRequestMessage : ChatMessage.Content
{

    public VP<uint> userId;

    #region action

    public enum Action
    {
        Ask,
        Accept,
        Refuse
    }

    public VP<Action> action;

    #endregion

    public VP<UndoRedoRequest.Operation> operation;

    #region Constructor

    public enum Property
    {
        userId,
        action,
        operation
    }

    public UndoRedoRequestMessage() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.action = new VP<Action>(this, (byte)Property.action, Action.Ask);
        this.operation = new VP<UndoRedoRequest.Operation>(this, (byte)Property.operation, UndoRedoRequest.Operation.Undo);
    }

    #endregion

    public override Type getType()
    {
        return Type.UndoRedoRequest;
    }

    #region add

    public static void Add(Data data, uint userId, UndoRedoRequestMessage.Action action, UndoRedoRequest.Operation operation)
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
                                UndoRedoRequestMessage content = new UndoRedoRequestMessage();
                                {
                                    content.userId.v = userId;
                                    content.action.v = action;
                                    content.operation.v = operation;
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

    #endregion

}