using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultChosenGameAlways : DefaultChosenGame
{

    public VP<GameType.Type> gameType;

    #region Constructor

    public enum Property
    {
        gameType
    }

    public DefaultChosenGameAlways() : base()
    {
        this.gameType = new VP<GameType.Type>(this, (byte)Property.gameType, GameType.Type.CHESS);
    }

    #endregion

    #region implement base

    public override Type getType()
    {
        return Type.Always;
    }

    public override GameType.Type getGame()
    {
        return this.gameType.v;
    }

    public override void setLast(GameType.Type gameType)
    {

    }

    #endregion

}