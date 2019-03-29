﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatRoomUpdate : UpdateBehavior<ChatRoom>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                // add adminChatViewer
                {
                    uint profileId = Server.getProfileUserId(this.data);
                    if (this.data.chatViewers.getInList(profileId) == null)
                    {
                        ChatViewer adminChatViewer = new ChatViewer();
                        {
                            adminChatViewer.uid = this.data.chatViewers.makeId();
                            adminChatViewer.userId.v = profileId;
                        }
                        this.data.chatViewers.add(adminChatViewer);
                    }
                }
                // maxId
                {
                    uint maxId = 0;
                    {
                        int min = Math.Max(0, this.data.messages.vs.Count - 50);
                        for (int i = this.data.messages.vs.Count - 1; i >= min; i--)
                        {
                            ChatMessage lastMessage = this.data.messages.vs[i];
                            if (lastMessage.content.v.isNeedMakeNew())
                            {
                                maxId = lastMessage.uid;
                                break;
                            }
                        }
                    }
                    this.data.maxId.v = maxId;
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is ChatRoom)
        {
            ChatRoom chatRoom = data as ChatRoom;
            // Update
            {
                UpdateUtils.makeUpdate<RemoveTypingPlayerUpdate, ChatRoom>(chatRoom, this.transform);
            }
            // child
            {
                chatRoom.players.allAddCallBack(this);
                chatRoom.chatViewers.allAddCallBack(this);
                chatRoom.typing.allAddCallBack(this);
                chatRoom.topic.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Child
        {
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    UpdateUtils.makeUpdate<HumanUpdate, Human>(human, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is ChatViewer)
            {
                ChatViewer chatViewer = data as ChatViewer;
                // Update
                {
                    UpdateUtils.makeUpdate<ChatViewerUpdate, ChatViewer>(chatViewer, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is Typing)
            {
                Typing typing = data as Typing;
                // Update
                {
                    UpdateUtils.makeUpdate<TypingUpdate, Typing>(typing, this.transform);
                }
                dirty = true;
                return;
            }
            if (data is Topic)
            {
                Topic topic = data as Topic;
                // Update
                {
                    switch (topic.getType())
                    {
                        case Topic.Type.General:
                            {
                                GeneralTopic generalTopic = topic as GeneralTopic;
                                UpdateUtils.makeUpdate<GeneralTopicUpdate, GeneralTopic>(generalTopic, this.transform);
                            }
                            break;
                        case Topic.Type.ShortQuestion:
                            {
                                ShortQuestionTopic shortQuestionTopic = topic as ShortQuestionTopic;
                                UpdateUtils.makeUpdate<ShortQuestionTopicUpdate, ShortQuestionTopic>(shortQuestionTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Bug:
                            {
                                BugTopic bugTopic = topic as BugTopic;
                                UpdateUtils.makeUpdate<BugTopicUpdate, BugTopic>(bugTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Suggestion:
                            {
                                SuggestionTopic suggestionTopic = topic as SuggestionTopic;
                                UpdateUtils.makeUpdate<SuggestionTopicUpdate, SuggestionTopic>(suggestionTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Off:
                            {
                                OffTopic offTopic = topic as OffTopic;
                                UpdateUtils.makeUpdate<OffTopicUpdate, OffTopic>(offTopic, this.transform);
                            }
                            break;
                        case Topic.Type.User:
                            {
                                UserTopic userTopic = topic as UserTopic;
                                UpdateUtils.makeUpdate<UserTopicUpdate, UserTopic>(userTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Friend:
                            {
                                FriendTopic friendTopic = topic as FriendTopic;
                                UpdateUtils.makeUpdate<FriendTopicUpdate, FriendTopic>(friendTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Guild:
                            {
                                GuildTopic guildTopic = topic as GuildTopic;
                                UpdateUtils.makeUpdate<GuildTopicUpdate, GuildTopic>(guildTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Room:
                            {
                                RoomTopic roomTopic = topic as RoomTopic;
                                UpdateUtils.makeUpdate<RoomTopicUpdate, RoomTopic>(roomTopic, this.transform);
                            }
                            break;
                        case Topic.Type.Game:
                            {
                                GameTopic gameTopic = topic as GameTopic;
                                UpdateUtils.makeUpdate<GameTopicUpdate, GameTopic>(gameTopic, this.transform);
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + topic.getType() + "; " + this);
                            break;
                    }
                }
                dirty = true;
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is ChatRoom)
        {
            ChatRoom chatRoom = data as ChatRoom;
            // Update
            {
                chatRoom.removeCallBackAndDestroy(typeof(RemoveTypingPlayerUpdate));
            }
            // child
            {
                chatRoom.players.allRemoveCallBack(this);
                chatRoom.chatViewers.allRemoveCallBack(this);
                chatRoom.typing.allRemoveCallBack(this);
                chatRoom.topic.allRemoveCallBack(this);
            }
            this.setDataNull(chatRoom);
            return;
        }
        // Child
        {
            if (data is Human)
            {
                Human human = data as Human;
                // Update
                {
                    human.removeCallBackAndDestroy(typeof(HumanUpdate));
                }
                return;
            }
            if (data is ChatViewer)
            {
                ChatViewer chatViewer = data as ChatViewer;
                // Update
                {
                    chatViewer.removeCallBackAndDestroy(typeof(ChatViewerUpdate));
                }
                return;
            }
            if (data is Typing)
            {
                Typing typing = data as Typing;
                // Update
                {
                    typing.removeCallBackAndDestroy(typeof(TypingUpdate));
                }
                return;
            }
            if (data is Topic)
            {
                Topic topic = data as Topic;
                // Update
                {
                    switch (topic.getType())
                    {
                        case Topic.Type.General:
                            {
                                GeneralTopic generalTopic = topic as GeneralTopic;
                                generalTopic.removeCallBackAndDestroy(typeof(GeneralTopicUpdate));
                            }
                            break;
                        case Topic.Type.ShortQuestion:
                            {
                                ShortQuestionTopic shortQuestionTopic = topic as ShortQuestionTopic;
                                shortQuestionTopic.removeCallBackAndDestroy(typeof(ShortQuestionTopicUpdate));
                            }
                            break;
                        case Topic.Type.Bug:
                            {
                                BugTopic bugTopic = topic as BugTopic;
                                bugTopic.removeCallBackAndDestroy(typeof(BugTopicUpdate));
                            }
                            break;
                        case Topic.Type.Suggestion:
                            {
                                SuggestionTopic suggestionTopic = topic as SuggestionTopic;
                                suggestionTopic.removeCallBackAndDestroy(typeof(SuggestionTopicUpdate));
                            }
                            break;
                        case Topic.Type.Off:
                            {
                                OffTopic offTopic = topic as OffTopic;
                                offTopic.removeCallBackAndDestroy(typeof(OffTopicUpdate));
                            }
                            break;
                        case Topic.Type.User:
                            {
                                UserTopic userTopic = topic as UserTopic;
                                userTopic.removeCallBackAndDestroy(typeof(UserTopicUpdate));
                            }
                            break;
                        case Topic.Type.Friend:
                            {
                                FriendTopic friendTopic = topic as FriendTopic;
                                friendTopic.removeCallBackAndDestroy(typeof(FriendTopicUpdate));
                            }
                            break;
                        case Topic.Type.Guild:
                            {
                                GuildTopic guildTopic = topic as GuildTopic;
                                guildTopic.removeCallBackAndDestroy(typeof(GuildTopicUpdate));
                            }
                            break;
                        case Topic.Type.Room:
                            {
                                RoomTopic roomTopic = topic as RoomTopic;
                                roomTopic.removeCallBackAndDestroy(typeof(RoomTopicUpdate));
                            }
                            break;
                        case Topic.Type.Game:
                            {
                                GameTopic gameTopic = topic as GameTopic;
                                gameTopic.removeCallBackAndDestroy(typeof(GameTopicUpdate));
                            }
                            break;
                        default:
                            Debug.LogError("unknown type: " + topic.getType() + "; " + this);
                            break;
                    }
                }
                return;
            }
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is ChatRoom)
        {
            switch ((ChatRoom.Property)wrapProperty.n)
            {
                case ChatRoom.Property.topic:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ChatRoom.Property.isEnable:
                    break;
                case ChatRoom.Property.players:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ChatRoom.Property.messages:
                    dirty = true;
                    break;
                case ChatRoom.Property.maxId:
                    break;
                case ChatRoom.Property.chatViewers:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case ChatRoom.Property.typing:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // Child
        {
            if (wrapProperty.p is Human)
            {
                return;
            }
            if (wrapProperty.p is ChatViewer)
            {
                return;
            }
            if (wrapProperty.p is Typing)
            {
                return;
            }
            if (wrapProperty.p is Topic)
            {
                return;
            }
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}