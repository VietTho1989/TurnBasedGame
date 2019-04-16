using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeBlindFoldMessage : ChatMessage.Content
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

    public VP<bool> newBlindFold;

    #region Constructor

    public enum Property
    {
        userId,
        action,
        newBlindFold
    }

    public RequestChangeBlindFoldMessage() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.action = new VP<Action>(this, (byte)Property.action, Action.Ask);
        this.newBlindFold = new VP<bool>(this, (byte)Property.newBlindFold, false);
    }

    #endregion

    #region add

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
                                RequestChangeBlindFoldMessage content = new RequestChangeBlindFoldMessage();
                                {
                                    content.userId.v = userId;
                                    content.action.v = action;
                                    // newBlindFold
                                    {
                                        bool newBlindFold = false;
                                        {
                                            GameData gameData = data.findDataInParent<GameData>();
                                            if (gameData != null)
                                            {
                                                newBlindFold = !gameData.blindFold.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("gameData null");
                                            }
                                        }
                                        content.newBlindFold.v = newBlindFold;
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

    #region implement base

    public override Type getType()
    {
        return Type.RequestChangeBlindFold;
    }

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

    #region txt

    private static readonly TxtLanguage txtAsk = new TxtLanguage("request");
    private static readonly TxtLanguage txtAccept = new TxtLanguage("accept");
    private static readonly TxtLanguage txtRefuse = new TxtLanguage("refuse");

    private static readonly TxtLanguage txtBlindFold = new TxtLanguage("blindfold");
    private static readonly TxtLanguage txtNotBlindFold = new TxtLanguage("not blindfold");

    static RequestChangeBlindFoldMessage()
    {
        txtAsk.add(Language.Type.vi, "yêu cầu");
        txtAccept.add(Language.Type.vi, "chấp nhận");
        txtRefuse.add(Language.Type.vi, "từ chối");

        txtBlindFold.add(Language.Type.vi, "cờ mù");
        txtNotBlindFold.add(Language.Type.vi, "không cờ mù");
    }

    #endregion

    public string getMessage(string userName)
    {
        string ret = "";
        {
            // blindFold
            string strBlindFold = this.newBlindFold.v ? txtBlindFold.get() : txtNotBlindFold.get();
            // action
            switch (this.action.v)
            {
                case Action.Ask:
                    ret = "<color=grey>" + userName + "</color> " + txtAsk.get() + " " + strBlindFold;
                    break;
                case Action.Accept:
                    ret = "<color=grey>" + userName + "</color> " + txtAccept.get() + " " + strBlindFold;
                    break;
                case Action.Refuse:
                    ret = "<color=grey>" + userName + "</color> " + txtRefuse.get() + " " + strBlindFold;
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