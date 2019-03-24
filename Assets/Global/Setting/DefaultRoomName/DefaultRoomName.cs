using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class DefaultRoomName : Data
{

    public enum Type
    {
        Last,
        Always
    }

    public abstract Type getType();

    public abstract string getRoomName();

    public abstract void setLast(string roomName);

    #region UIData

    public abstract class UIData : Data
    {

        public abstract Type getType();

    }

    #endregion

}