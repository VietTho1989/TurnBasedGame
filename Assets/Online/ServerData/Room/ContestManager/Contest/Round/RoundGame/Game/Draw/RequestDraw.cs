using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RequestDraw : Data
{

    #region State

    public abstract class State : Data
    {

        public enum Type
        {
            None,
            Ask,
            Accept,
            Cancel
        }

        public abstract Type getType();

    }

    public VP<State> state;

    #endregion

    public LP<Human> whoCanAsks;

    #region Constructor

    public enum Property
    {
        state,
        whoCanAsks
    }

    public RequestDraw() : base()
    {
        this.state = new VP<State>(this, (byte)Property.state, new RequestDrawStateNone());
        this.whoCanAsks = new LP<Human>(this, (byte)Property.whoCanAsks);
    }

    #endregion

    public HashSet<uint> getWhoCanAsk()
    {
        HashSet<uint> ret = new HashSet<uint>();
        {
            // GamePlayer
            {
                Game game = this.findDataInParent<Game>();
                if (game != null)
                {
                    for (int i = 0; i < game.gamePlayers.vs.Count; i++)
                    {
                        GamePlayer gamePlayer = game.gamePlayers.vs[i];
                        if (gamePlayer.inform.v is Human)
                        {
                            Human human = gamePlayer.inform.v as Human;
                            ret.Add(human.playerId.v);
                        }
                    }
                }
                else
                {
                    Debug.LogError("duel null");
                }
            }
            // Admin
            {
                if (ret.Count == 0)
                {
                    // need admin
                    Room room = this.findDataInParent<Room>();
                    if (room != null)
                    {
                        RoomUser admin = room.findAdmin();
                        if (admin != null)
                        {
                            ret.Add(admin.inform.v.playerId.v);
                        }
                        else
                        {
                            Debug.LogError("admin null");
                        }
                    }
                    else
                    {
                        Debug.LogError("room null");
                    }
                }
            }
        }
        return ret;
    }

}