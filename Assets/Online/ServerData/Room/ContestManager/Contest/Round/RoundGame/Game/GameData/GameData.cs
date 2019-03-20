using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : Data
{

    #region GameType

    public VP<GameType> gameType;

    #endregion

    #region useRule

    public VP<bool> useRule;

    public static bool IsUseRule(Data data)
    {
        if (data != null)
        {
            GameData gameData = data.findDataInParent<GameData>();
            if (gameData != null)
            {
                return gameData.useRule.v;
            }
            else
            {
                Debug.LogError("gameData null: " + data);
            }
        }
        else
        {
            Debug.LogError("data null: " + data);
        }
        return true;
    }

    public VP<RequestChangeUseRule> requestChangeUseRule;

    #endregion

    #region Turn

    public VP<Turn> turn;

    #endregion

    /** Cho vao gameData thi history moi kiem soat duoc*/
    public VP<TimeControl.TimeControl> timeControl;

    #region Piece

    public VP<LastMove> lastMove;

    #endregion

    #region State

    public abstract class State : Data
    {

        public enum Type
        {
            Normal,
            Finish
        }

        public abstract Type getType();

    }

    public VP<State> state;

    #endregion

    #region Constructor

    public enum Property
    {
        gameType,
        useRule,
        requestChangeUseRule,
        turn,
        timeControl,
        lastMove,
        state
    }

    public GameData() : base()
    {
        this.gameType = new VP<GameType>(this, (byte)Property.gameType, new Xiangqi.Xiangqi());
        {
            this.useRule = new VP<bool>(this, (byte)Property.useRule, true);
            this.useRule.nh = 0;
        }
        this.requestChangeUseRule = new VP<RequestChangeUseRule>(this, (byte)Property.requestChangeUseRule, new RequestChangeUseRule());
        {
            this.turn = new VP<Turn>(this, (byte)Property.turn, new Turn());
            this.turn.nh = 0;
        }
        this.timeControl = new VP<TimeControl.TimeControl>(this, (byte)Property.timeControl, new TimeControl.TimeControl());
        this.lastMove = new VP<LastMove>(this, (byte)Property.lastMove, new LastMove());
        this.state = new VP<State>(this, (byte)Property.state, new GameDataStateNormal());
    }

    #endregion

}