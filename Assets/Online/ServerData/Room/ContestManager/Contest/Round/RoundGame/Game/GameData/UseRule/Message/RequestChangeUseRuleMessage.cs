using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestChangeUseRuleMessage : ChatMessage.Content
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

    public VP<bool> newUseRule;

    #region Constructor

    public enum Property
    {
        userId,
        action,
        newUseRule
    }

    public RequestChangeUseRuleMessage() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.action = new VP<Action>(this, (byte)Property.action, Action.Ask);
        this.newUseRule = new VP<bool>(this, (byte)Property.newUseRule, false);
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
                                RequestChangeUseRuleMessage content = new RequestChangeUseRuleMessage();
                                {
                                    content.userId.v = userId;
                                    content.action.v = action;
                                    // newUseRule
                                    {
                                        bool newUseRule = false;
                                        {
                                            GameData gameData = data.findDataInParent<GameData>();
                                            if (gameData != null)
                                            {
                                                newUseRule = !gameData.useRule.v;
                                            }
                                            else
                                            {
                                                Debug.LogError("gameData null");
                                            }
                                        }
                                        content.newUseRule.v = newUseRule;
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
        return Type.RequestChangeUseRule;
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

    private static readonly TxtLanguage txtUseRule = new TxtLanguage("use rule");
    private static readonly TxtLanguage txtNotUseRule = new TxtLanguage("not use rule");

    static RequestChangeUseRuleMessage()
    {
        txtAsk.add(Language.Type.vi, "yêu cầu");
        txtAccept.add(Language.Type.vi, "chấp nhận");
        txtRefuse.add(Language.Type.vi, "từ chối");

        txtUseRule.add(Language.Type.vi, "dùng luật");
        txtNotUseRule.add(Language.Type.vi, "không dùng luật");
    }

    #endregion

    public string getMessage(string userName)
    {
        string ret = "";
        {
            // useRule
            string strUseRule = this.newUseRule.v ? txtUseRule.get() : txtNotUseRule.get();
            // action
            switch (this.action.v)
            {
                case Action.Ask:
                    ret = "<color=grey>" + userName + "</color> " + txtAsk.get() + " " + strUseRule;
                    break;
                case Action.Accept:
                    ret = "<color=grey>" + userName + "</color> " + txtAccept.get() + " " + strUseRule;
                    break;
                case Action.Refuse:
                    ret = "<color=grey>" + userName + "</color> " + txtRefuse.get() + " " + strUseRule;
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