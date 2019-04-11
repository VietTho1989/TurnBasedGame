using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Swap
{
    public class SwapPlayerMessage : ChatMessage.Content
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

        public VP<int> teamIndex;

        public VP<int> playerIndex;

        #region inform

        public VP<GamePlayer.Inform.Type> type;

        public VP<uint> humanId;

        #endregion

        #region Constructor

        public enum Property
        {
            userId,
            action,
            teamIndex,
            playerIndex,
            type,
            humanId
        }

        public SwapPlayerMessage() : base()
        {
            this.userId = new VP<uint>(this, (byte)Property.userId, 0);
            this.action = new VP<Action>(this, (byte)Property.action, Action.Ask);
            this.teamIndex = new VP<int>(this, (byte)Property.teamIndex, 0);
            this.playerIndex = new VP<int>(this, (byte)Property.playerIndex, 0);
            this.type = new VP<GamePlayer.Inform.Type>(this, (byte)Property.type, GamePlayer.Inform.Type.Human);
            this.humanId = new VP<uint>(this, (byte)Property.humanId, 0);
        }

        #endregion

        #region add

        public static void Add(Data data, uint userId, Action action, int teamIndex, int playerIndex, GamePlayer.Inform.Type type, uint humanId)
        {
            // Debug.LogWarning("AddUndoRedoRequest");
            if (data != null)
            {
                Room room = data.findDataInParent<Room>();
                if (room != null)
                {
                    ChatRoom chatRoom = room.chatRoom.v;
                    if (chatRoom != null)
                    {
                        if (chatRoom.topic.v is RoomTopic)
                        {
                            RoomTopic roomTopic = chatRoom.topic.v as RoomTopic;
                            // Add player
                            {
                                chatRoom.addPlayer(userId);
                                if (type == GamePlayer.Inform.Type.Human)
                                {
                                    chatRoom.addPlayer(humanId);
                                }
                            }

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
                                    SwapPlayerMessage content = new SwapPlayerMessage();
                                    {
                                        content.userId.v = userId;
                                        content.action.v = action;
                                        content.teamIndex.v = teamIndex;
                                        content.playerIndex.v = playerIndex;
                                        content.type.v = type;
                                        content.humanId.v = humanId;
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
                    Debug.LogError("room null: " + data);
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
            return Type.SwapPlayer;
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
                // find humanName
                string humanName = "";
                {
                    if (this.type.v == GamePlayer.Inform.Type.Human)
                    {
                        Human human = ChatRoom.findHuman(this, this.humanId.v);
                        if (human != null)
                        {
                            humanName = human.getPlayerName();
                        }
                        else
                        {
                            Debug.LogError("human null");
                        }
                    }
                }
            }
            return ret;
        }

        #region txt

        private static readonly TxtLanguage txtAsk = new TxtLanguage("ask");
        private static readonly TxtLanguage txtAccept = new TxtLanguage("accept");
        private static readonly TxtLanguage txtRefuse = new TxtLanguage("refuse");

        private static readonly TxtLanguage txtSwap = new TxtLanguage("to swap");

        private static readonly TxtLanguage txtTeam = new TxtLanguage("team");
        private static readonly TxtLanguage txtPlayer = new TxtLanguage("player");

        private static readonly TxtLanguage txtBy = new TxtLanguage("by");

        private static readonly TxtLanguage txtHuman = new TxtLanguage("user");
        private static readonly TxtLanguage txtComputer = new TxtLanguage("computer");

        static SwapPlayerMessage()
        {
            txtAsk.add(Language.Type.vi, "yêu cầu");
            txtAccept.add(Language.Type.vi, "chấp nhận");
            txtRefuse.add(Language.Type.vi, "từ chối");

            txtSwap.add(Language.Type.vi, "thay đổi");

            txtTeam.add(Language.Type.vi, "đội");
            txtPlayer.add(Language.Type.vi, "người chơi");

            txtBy.add(Language.Type.vi, "bằng");

            txtHuman.add(Language.Type.vi, "người dùng");
            txtComputer.add(Language.Type.vi, "máy tính");
        }

        #endregion

        public string getMessage(string userName, string humanName)
        {
            string ret = "";
            {
                // action
                string strAction = txtAsk.get();
                {
                    switch (this.action.v)
                    {
                        case Action.Ask:
                            strAction = txtAsk.get();
                            break;
                        case Action.Accept:
                            strAction = txtAccept.get();
                            break;
                        case Action.Refuse:
                            strAction = txtRefuse.get();
                            break;
                        default:
                            Debug.LogError("unknown action: " + this.action.v);
                            break;
                    }
                }
                // newPlayer
                string strNewPlayer = "";
                {
                    switch (this.type.v)
                    {
                        case GamePlayer.Inform.Type.Human:
                            strNewPlayer = txtHuman.get() + " <color=grey>" + humanName + "</color>";
                            break;
                        case GamePlayer.Inform.Type.Computer:
                            strNewPlayer = txtComputer.get();
                            break;
                        default:
                            Debug.LogError("unknown type: " + this.type.v);
                            break;
                    }
                }
                // message
                ret = "<color=grey>" + userName + "</color> " + strAction + " " + txtSwap.get()
                    + " " + txtPlayer.get() + " " + this.playerIndex.v + ", " + txtTeam.get() + " " + this.teamIndex.v
                    + " " + txtBy.get() + " " + strNewPlayer;
            }
            return ret;
        }

        #endregion

    }
}