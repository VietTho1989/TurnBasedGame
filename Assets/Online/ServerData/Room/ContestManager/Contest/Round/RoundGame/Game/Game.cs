using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : Data
{

    #region GamePlayer

    public LP<GamePlayer> gamePlayers;

    public GamePlayer findYourGamePlayer(uint yourUserId)
    {
        // TODO nen dung list file
        for (int i = 0; i < this.gamePlayers.vs.Count; i++)
        {
            GamePlayer gamePlayer = this.gamePlayers.vs[i];
            if (gamePlayer.inform.v.getType() == GamePlayer.Inform.Type.Human)
            {
                Human human = gamePlayer.inform.v as Human;
                if (human.playerId.v == yourUserId)
                {
                    return gamePlayer;
                }
            }
        }
        return null;
    }

    public GamePlayer findGamePlayer(int playerIndex)
    {
        return this.gamePlayers.vs.Find(gamePlayer => gamePlayer.playerIndex.v == playerIndex);
    }

    public bool isHaveGamePlayer(int playerIndex)
    {
        GamePlayer findPlayer = this.gamePlayers.vs.Find(gamePlayer => gamePlayer.playerIndex.v == playerIndex);
        if (findPlayer != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    #endregion

    #region RequestDraw

    public VP<RequestDraw> requestDraw;

    #endregion

    #region state

    public VP<GameState.State> state;

    public static bool IsPlaying(Data data, bool needCheckPause = true)
    {
        bool ret = false;
        {
            if (data != null)
            {
                // Game
                {
                    Game game = data.findDataInParent<Game>();
                    if (game != null)
                    {
                        if (game.state.v != null && game.state.v is GameState.Play)
                        {
                            GameState.Play play = game.state.v as GameState.Play;
                            if (needCheckPause)
                            {
                                if (play.sub.v != null && play.sub.v is GameState.PlayNormal)
                                {
                                    ret = true;
                                }
                            }
                            else
                            {
                                ret = true;
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("game null: " + data);
                    }
                }
                // Room
                if (ret)
                {
                    Room room = data.findDataInParent<Room>();
                    if (room != null)
                    {
                        if (!(room.state.v is RoomStateNormal))
                        {
                            ret = false;
                        }
                    }
                    else
                    {
                        // Debug.LogError ("room null: " + data);
                    }
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
            }
        }
        return ret;
    }

    public static bool IsPlayingOrFinish(Data data)
    {
        bool ret = false;
        {
            if (data != null)
            {
                // Game
                {
                    Game game = data.findDataInParent<Game>();
                    if (game != null)
                    {
                        if (game.state.v != null && (game.state.v is GameState.Play || game.state.v is GameState.End))
                        {
                            ret = true;
                        }
                    }
                    else
                    {
                        Debug.LogError("game null: " + data);
                    }
                }
                // Room
                if (ret)
                {
                    Room room = data.findDataInParent<Room>();
                    if (room != null)
                    {
                        if (!(room.state.v is RoomStateNormal))
                        {
                            ret = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("room null: " + data);
                    }
                }
                // TODO Can phai check cac bac cao hon
                if (ret)
                {
                    // TODO Can hoan thien
                }
            }
            else
            {
                Debug.LogError("data null: " + data);
            }
        }
        return ret;
    }

    #endregion

    public VP<GameData> gameData;

    public VP<History> history;

    #region GameAction

    public VP<GameAction> gameAction;

    public VP<UndoRedoRequest> undoRedoRequest;

    #endregion

    public VP<ChatRoom> chatRoom;

    public VP<AnimationData> animationData;

    #region Constructor

    public enum Property
    {
        gamePlayers,
        requestDraw,
        state,
        gameData,
        history,
        gameAction,
        undoRedoRequest,
        chatRoom,
        animationData
    }

    public Game() : base()
    {
        this.gamePlayers = new LP<GamePlayer>(this, (byte)Property.gamePlayers);
        this.requestDraw = new VP<RequestDraw>(this, (byte)Property.requestDraw, new RequestDraw());
        this.state = new VP<GameState.State>(this, (byte)Property.state, new GameState.Load());
        this.gameData = new VP<GameData>(this, (byte)Property.gameData, new GameData());
        this.history = new VP<History>(this, (byte)Property.history, new History());
        this.gameAction = new VP<GameAction>(this, (byte)Property.gameAction, new NonAction());
        this.undoRedoRequest = new VP<UndoRedoRequest>(this, (byte)Property.undoRedoRequest, new UndoRedoRequest());
        {
            ChatRoom chatRoom = new ChatRoom();
            {
                chatRoom.topic.v = new GameTopic();
            }
            this.chatRoom = new VP<ChatRoom>(this, (byte)Property.chatRoom, chatRoom);
        }
        this.animationData = new VP<AnimationData>(this, (byte)Property.animationData, new AnimationData());
    }

    #endregion

}