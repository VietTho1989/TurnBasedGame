﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * Danh sach player va vi tri trong 1 duel: co le se ko thay doi khi da set
 * */
public class GamePlayer : Data
{

    #region playerIndex

    public VP<int> playerIndex;

    public static int GetPlayerIndex(Data data)
    {
        int ret = 0;
        {
            if (data != null)
            {
                GamePlayer gamePlayer = data.findDataInParent<GamePlayer>();
                if (gamePlayer != null)
                {
                    ret = gamePlayer.playerIndex.v;
                }
                else
                {
                    Debug.LogError("gamePlayer null");
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
        return ret;
    }

    #endregion

    #region Infor

    public abstract class Inform : Data
    {

        public enum Type
        {
            None,
            Human,
            Computer
        }

        public abstract Type getType();

        public virtual string getPlayerName()
        {
            return "";
        }

    }

    public VP<Inform> inform;

    public Computer.AI getAI()
    {
        if (inform.v is Computer)
        {
            Computer computer = inform.v as Computer;
            return computer.ai.v;
        }
        else
        {
            Debug.LogError("Why not computer: " + this);
        }
        return null;
    }

    #endregion

    #region State

    public abstract class State : Data
    {
        public enum Type
        {
            Normal,
            Surrender
        }

        public abstract Type getType();

    }

    public VP<State> state;

    #endregion

    #region Constructor

    public enum Property
    {
        playerIndex,
        inform,
        state
    }

    public GamePlayer() : base()
    {
        this.playerIndex = new VP<int>(this, (byte)Property.playerIndex, -1);
        this.inform = new VP<Inform>(this, (byte)Property.inform, new EmptyInform());
        this.state = new VP<State>(this, (byte)Property.state, new GamePlayerStateNormal());
    }

    #endregion

    public static GamePlayer findYourGamePlayer(Data data)
    {
        Game game = data.findDataInParent<Game>();
        if (game != null)
        {
            Server server = data.findDataInParent<Server>();
            if (server != null)
            {
                for (int i = 0; i < game.gamePlayers.vs.Count; i++)
                {
                    GamePlayer gamePlayer = game.gamePlayers.vs[i];
                    if (gamePlayer.inform.v is Human)
                    {
                        Human human = gamePlayer.inform.v as Human;
                        if (human.playerId.v == server.profileId.v)
                        {
                            return gamePlayer;
                        }
                    }
                }
            }
            else
            {
                // Debug.LogError ("server null");
                for (int i = 0; i < game.gamePlayers.vs.Count; i++)
                {
                    GamePlayer gamePlayer = game.gamePlayers.vs[i];
                    if (gamePlayer.inform.v is Human)
                    {
                        return gamePlayer;
                    }
                }
            }
        }
        else
        {
            // Debug.LogError ("Cannot find duel");
        }
        return null;
    }

}