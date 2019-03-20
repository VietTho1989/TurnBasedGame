using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatMessage : Data
{

    #region State

    public enum State
    {
        Normal,
        Delete,
        TrueDelete
    }

    public VP<State> state;

    public bool isCanChangeState(uint userId, State newState)
    {
        if (this.state.v != newState)
        {
            switch (this.content.v.getType())
            {
                case ChatMessage.Content.Type.Normal:
                    {
                        ChatNormalContent normalContent = this.content.v as ChatNormalContent;
                        if (userId == normalContent.owner.v)
                        {
                            return true;
                        }
                    }
                    break;
                case ChatMessage.Content.Type.RoomUserState:
                    break;
                default:
                    Debug.LogError("unknown type: " + this.content.v.getType());
                    break;
            }
        }
        return false;
    }

    public void requestChangeState(uint userId, State newState)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeState(userId, newState);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is ChatMessageIdentity)
                    {
                        ChatMessageIdentity chatMessageIdentity = dataIdentity as ChatMessageIdentity;
                        chatMessageIdentity.requestChangeState(userId, newState);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeState(uint userId, State newState)
    {
        if (isCanChangeState(userId, newState))
        {
            this.state.v = newState;
        }
    }

    #endregion

    #region Time

    public VP<long> time;

    public static readonly DateTime EPOCH_START_TIME = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);

    public DateTime TimestampAsDateTime
    {
        get
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = EPOCH_START_TIME.AddSeconds(time.v / 1000).ToLocalTime();
            return dtDateTime;
        }
    }

    #endregion

    #region Content

    public abstract class Content : Data
    {

        public enum Type
        {
            Normal,
            UserAction,
            RoomUserState,
            FriendStateChange,
            GameMove,

            UndoRedoRequest,
            RequestDraw,
            GamePlayerState
        }

        public abstract Type getType();

    }

    public VP<Content> content;

    #endregion

    #region Constructor

    public enum Property
    {
        state,
        time,
        content
    }

    public ChatMessage() : base()
    {
        this.state = new VP<State>(this, (byte)Property.state, State.Normal);
        this.time = new VP<long>(this, (byte)Property.time, 0);
        this.content = new VP<Content>(this, (byte)Property.content, new ChatNormalContent());
    }

    #endregion

}