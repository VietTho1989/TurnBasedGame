using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTopic : Topic
{

    #region Constructor

    public enum Property
    {

    }

    public GameTopic() : base()
    {

    }

    #endregion

    public override Type getType()
    {
        return Type.Game;
    }

    public override bool isCanSendNormalMessage(uint userId)
    {
        return true;
    }

    #region add undoRedoRequest message

    public static void AddUndoRedoRequest(Data data, uint userId, UndoRedoRequestMessage.Action action, UndoRedoRequest.Operation operation)
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

    #region add game move message

    public void addGameMove(Turn turn, GameMove gameMove)
    {
        if (gameMove.isCanMakeMoveMessage())
        {
            ChatRoom chatRoom = this.findDataInParent<ChatRoom>();
            if (chatRoom != null)
            {
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
                        ChatGameMoveContent content = new ChatGameMoveContent();
                        {
                            content.uid = chatMessage.content.makeId();
                            // turn
                            {
                                Turn cloneTurn = (Turn)DataUtils.cloneData(turn);
                                {
                                    cloneTurn.uid = 0;
                                }
                                content.turn.v = cloneTurn;
                            }
                            // gameMove
                            {
                                GameMove cloneGameMove = (GameMove)DataUtils.cloneData(gameMove);
                                {
                                    cloneGameMove.uid = 0;
                                }
                                content.gameMove.v = cloneGameMove;
                            }
                        }
                        chatMessage.content.v = content;
                    }
                }
                // Add
                chatRoom.messages.add(chatMessage);
            }
            else
            {
                Debug.LogError("chatRoom null: " + this);
            }
        }
    }

    #endregion

}