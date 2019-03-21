using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneralTopic : Topic
{

    #region Constructor

    public enum Property
    {

    }

    public GeneralTopic() : base()
    {

    }

    #endregion

    public override Type getType()
    {
        return Type.General;
    }

    public override bool isCanSendNormalMessage(uint userId)
    {
        Server server = this.findDataInParent<Server>();
        if (server != null)
        {
            User user = server.users.getInList(userId);
            if (user != null)
            {
                if (user.human.v.ban.v.getType() == Ban.Type.Normal)
                {
                    return true;
                }
                else
                {
                    Debug.LogError("user is ban: " + user + "; " + this);
                    return false;
                }
            }
            else
            {
                Debug.LogError("Cannot find user: " + userId + "; " + this);
                return false;
            }
        }
        else
        {
            Debug.LogError("server null: " + this);
            return false;
        }
    }

}