using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DefaultRoomNameAlways : DefaultRoomName
{

    public VP<string> roomName;

    #region Constructor

    public enum Property
    {
        roomName
    }

    public DefaultRoomNameAlways() : base()
    {
        this.roomName = new VP<string>(this, (byte)Property.roomName, "");
    }

    #endregion

    #region implement base

    public override Type getType()
    {
        return Type.Always;
    }

    public override string getRoomName()
    {
        return this.roomName.v;
    }

    public override void setLast(string roomName)
    {

    }

    #endregion

}