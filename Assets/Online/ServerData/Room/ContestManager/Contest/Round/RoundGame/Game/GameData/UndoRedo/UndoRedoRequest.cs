using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UndoRedo;
using Rights;

public class UndoRedoRequest : Data
{

    #region Operation

    public enum Operation
    {
        Undo,
        Redo
    }

    #endregion

    public abstract class State : Data
    {

        public enum Type
        {
            None,
            Ask
        }

        public abstract Type getType();

    }
    public VP<State> state;

    #region Answer

    public HashSet<uint> getWhoCanAnswer()
    {
        HashSet<uint> ret = new HashSet<uint>();
        {
            // Find UndoRedoRight
            UndoRedoRight undoRedoRight = null;
            {
                Room room = this.findDataInParent<Room>();
                if (room != null)
                {
                    ChangeRights changeRights = room.changeRights.v;
                    if (changeRights != null)
                    {
                        undoRedoRight = changeRights.undoRedoRight.v;
                    }
                    else
                    {
                        Debug.LogError("changeRights null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("room null: " + this);
                }
            }
            // Process
            if (undoRedoRight != null)
            {
                // check undo redo limit
                bool isAlreadyLimit = false;
                {
                    // find count
                    int count = 0;
                    {
                        // find playerIndex
                        int playerIndex = 0;
                        {
                            Game game = this.findDataInParent<Game>();
                            if (game != null)
                            {
                                GameData gameData = game.gameData.v;
                                if (gameData != null)
                                {
                                    Turn turn = gameData.turn.v;
                                    if (turn != null)
                                    {
                                        playerIndex = turn.playerIndex.v;
                                    }
                                    else
                                    {
                                        Debug.LogError("turn null");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("gameData null");
                                }
                            }
                            else
                            {
                                Debug.LogError("game null");
                            }
                        }
                        // process
                        count = this.getCount(playerIndex);
                    }
                    // process
                    if (undoRedoRight.limit.v.isOverLimit(count))
                    {
                        isAlreadyLimit = true;
                    }
                }
                // process
                if (!isAlreadyLimit)
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
                            Debug.LogError("Duel null");
                        }
                    }
                    // Admin
                    if (ret.Count == 0 || undoRedoRight.needAdmin.v)
                    {
                        RoomUser admin = Room.findAdmin(this);
                        if (admin != null)
                        {
                            ret.Add(admin.inform.v.playerId.v);
                        }
                        else
                        {
                            Debug.LogError("admin null");
                        }
                    }
                }
                else
                {
                    // already limit
                }
            }
            else
            {
                // Debug.LogError ("undoRedoRight null: " + this);
                // add gamePlayer
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
                        Debug.LogError("Duel null");
                    }
                }
            }
        }
        // Debug.LogError ("WhoCanAnswer: " + GameUtils.Utils.getListString (ret));
        return ret;
    }

    public static HashSet<uint> getWhoCanAnswer(Data data)
    {
        if (data != null)
        {
            UndoRedoRequest undoRedoRequest = data.findDataInParent<UndoRedoRequest>();
            if (undoRedoRequest != null)
            {
                return undoRedoRequest.getWhoCanAnswer();
            }
            else
            {
                Debug.LogError("undoRedoRequest null: " + data);
            }
        }
        else
        {
            Debug.LogError("data null");
        }
        return new HashSet<uint>();
    }

    #endregion

    #region count

    public LP<int> count;

    public int getCount(int playerIndex)
    {
        int ret = 0;
        {
            if(playerIndex>=0 && playerIndex < this.count.vs.Count)
            {
                ret = this.count.vs[playerIndex];
            }
            else
            {
                Debug.LogError("playerIndex error");
            }
        }
        return ret;
    }

    public void addCount(int playerIndex)
    {
        if (playerIndex < this.count.vs.Count)
        {
            int oldCount = this.count.vs[playerIndex];
            this.count.set(playerIndex, oldCount + 1);
        }
        else
        {
            List<int> countList = new List<int>();
            {
                for (int i = 0; i < playerIndex; i++)
                {
                    int count = 0;
                    {
                        if (i < this.count.vs.Count)
                        {
                            count = this.count.vs[i];
                        }
                    }
                    countList.Add(count);
                }
                countList.Add(1);
            }
            this.count.copyList(countList);
        }
    }

    #endregion

    #region Constructor

    public enum Property
    {
        state,
        count
    }

    public UndoRedoRequest() : base()
    {
        this.state = new VP<State>(this, (byte)Property.state, new None());
        this.count = new LP<int>(this, (byte)Property.count);
    }

    #endregion

    public static bool isGameActionCorrect(GameAction gameAction)
    {
        // TODO Can xem xet lai
        return true;
    }

}