using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultChosenGameLast : DefaultChosenGame
{

    public VP<GameType.Type> gameType;

    #region Constructor

    public enum Property
    {
        gameType
    }

    public DefaultChosenGameLast() : base()
    {
        this.gameType = new VP<GameType.Type>(this, (byte)Property.gameType, GameType.Type.CHESS);
    }

    #endregion

    #region implement base

    public override Type getType()
    {
        return Type.Last;
    }

    public override GameType.Type getGame()
    {
        return this.gameType.v;
    }

    public override void setLast(GameType.Type gameType)
    {
        this.gameType.v = gameType;
    }

    #endregion

}