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

    #region Constructor

    public enum Property
    {
        state
    }

    public UndoRedoRequest() : base()
    {
        this.state = new VP<State>(this, (byte)Property.state, new None());
    }

    #endregion

    public static bool isGameActionCorrect(GameAction gameAction)
    {
        // TODO Can xem xet lai
        return true;
    }

}