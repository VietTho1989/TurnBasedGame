using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class DefaultChosenGame : Data
{

    public enum Type
    {
        Last,
        Always
    }

    public abstract Type getType();

    public abstract GameType.Type getGame();

    public abstract void setLast(GameType.Type gameType);

    #region UIData

    public abstract class UIData : Data
    {

        public abstract Type getType();

    }

    #endregion

}