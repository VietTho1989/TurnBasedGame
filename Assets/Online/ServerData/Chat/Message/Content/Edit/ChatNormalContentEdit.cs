using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChatNormalContentEdit : Data
{

    public VP<long> time;

    public VP<string> message;

    #region Constructor

    public enum Property
    {
        time,
        message
    }

    public ChatNormalContentEdit() : base()
    {
        this.time = new VP<long>(this, (byte)Property.time, 0);
        this.message = new VP<string>(this, (byte)Property.message, "");
    }

    #endregion

}