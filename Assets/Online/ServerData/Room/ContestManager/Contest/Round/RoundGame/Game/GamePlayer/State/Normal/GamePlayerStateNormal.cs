using UnityEngine;
using System.Collections;

public class GamePlayerStateNormal : GamePlayer.State
{

    #region Constructor

    public enum Property
    {

    }

    public GamePlayerStateNormal() : base()
    {

    }

    #endregion

    public override Type getType()
    {
        return Type.Normal;
    }

    public bool isCanSurrender(uint userId)
    {
        if (Game.IsPlaying(this))
        {
            GamePlayer gamePlayer = this.findDataInParent<GamePlayer>();
            if (gamePlayer != null)
            {
                if (gamePlayer.inform.v is Human)
                {
                    // Normal user
                    Human human = gamePlayer.inform.v as Human;
                    if (human.playerId.v == userId)
                    {
                        return true;
                    }
                }
                else
                {
                    // Admin can surrender
                    RoomUser admin = Room.findAdmin(this);
                    if (admin != null)
                    {
                        if (admin.inform.v.playerId.v == userId)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        Debug.LogError("admin null");
                    }
                }
            }
            else
            {
                Debug.LogError("gamePlayer null: " + this);
            }
        }
        else
        {
            // Debug.LogError ("game isn't playing: " + this);
        }
        return false;
    }

    public void requestSurrender(uint userId)
    {
        // Debug.LogError ("requestSurrender: " + userId);
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.surrender(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is GamePlayerStateNormalIdentity)
                    {
                        GamePlayerStateNormalIdentity gamePlayerStateNormalIdentity = dataIdentity as GamePlayerStateNormalIdentity;
                        gamePlayerStateNormalIdentity.requestSurrender(userId);
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

    public void surrender(uint userId)
    {
        if (isCanSurrender(userId))
        {
            GamePlayer gamePlayer = this.findDataInParent<GamePlayer>();
            if (gamePlayer != null)
            {
                // add message
                GamePlayerStateMessage.Add(this, userId, GamePlayer.GetPlayerIndex(this), GamePlayerStateMessage.Action.Surrender);
                // change state
                GamePlayerStateSurrender surrender = new GamePlayerStateSurrender();
                {
                    surrender.uid = gamePlayer.state.makeId();
                }
                gamePlayer.state.v = surrender;
            }
            else
            {
                Debug.LogError("gamePlayer null: " + this);
            }
        }
        else
        {
            Debug.LogError("You cannot surrender");
        }
    }

}