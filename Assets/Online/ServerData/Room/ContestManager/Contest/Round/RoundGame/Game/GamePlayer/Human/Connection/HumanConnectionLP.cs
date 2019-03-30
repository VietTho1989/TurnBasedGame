using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanConnectionLP : LP<HumanConnection>, ValueChangeCallBack
{

    #region Constructor

    public HumanConnectionLP(Data parent, byte name) : base(parent, name)
    {
        parent.addCallBack(this);
    }

    #endregion

    #region dictionary

    private Dictionary<uint, HumanConnection> humanConnectionDict = new Dictionary<uint, HumanConnection>();
    private HashSet<HumanConnection> notCorrectHumanConnections = new HashSet<HumanConnection>();

    public HumanConnection getInList(uint userId)
    {
        HumanConnection ret = null;
        {
            // get in dict
            HumanConnection oldHumanConnection = null;
            {
                if (!humanConnectionDict.TryGetValue(userId, out oldHumanConnection))
                {
                    Debug.LogError("Don't have humanConnection");
                }
            }
            // get in notCorrectHumanConnections
            if (oldHumanConnection != null && oldHumanConnection.playerId.v == userId)
            {
                // Debug.LogError("already found, not find in notCorrectHumanConnections anymore");
                ret = oldHumanConnection;
            }
            else
            {
                // add to notCorrectHumanConnections
                if (oldHumanConnection != null)
                {
                    notCorrectHumanConnections.Add(oldHumanConnection);
                    humanConnectionDict.Remove(userId);
                }
                // find in not correctHumanConnections
                {
                    // find
                    foreach (HumanConnection humanConnection in notCorrectHumanConnections)
                    {
                        if (humanConnection.playerId.v == userId)
                        {
                            ret = humanConnection;
                            break;
                        }
                    }
                    // add to dictionary
                    if (ret != null)
                    {
                        humanConnectionDict[userId] = ret;
                        notCorrectHumanConnections.Remove(ret);
                    }
                }
            }
        }
        return ret;
    }

    #endregion

    #region implement callBacks

    public void onAddCallBack<T>(T data) where T : Data
    {
        if (data == p)
        {
            return;
        }
        if (data is HumanConnection)
        {
            HumanConnection humanConnection = data as HumanConnection;
            // add
            {
                // find old
                HumanConnection oldHumanConnection = null;
                {
                    if (humanConnectionDict.TryGetValue(humanConnection.playerId.v, out oldHumanConnection))
                    {
                        Debug.LogError("already have oldHumanConnection: " + oldHumanConnection);
                    }
                }
                // process
                if (oldHumanConnection == null)
                {
                    humanConnectionDict[humanConnection.playerId.v] = humanConnection;
                }
                else
                {
                    notCorrectHumanConnections.Add(humanConnection);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onRemoveCallBack<T>(T data, bool isHide) where T : Data
    {
        if (data == p)
        {
            return;
        }
        if (data is HumanConnection)
        {
            HumanConnection humanConnection = data as HumanConnection;
            // remove
            {
                // find old
                HumanConnection oldHumanConnection = null;
                {
                    if (humanConnectionDict.TryGetValue(humanConnection.playerId.v, out oldHumanConnection))
                    {

                    }
                }
                // process
                if (oldHumanConnection == humanConnection)
                {
                    humanConnectionDict.Remove(humanConnection.playerId.v);
                    notCorrectHumanConnections.Remove(humanConnection);
                }
                else
                {
                    Debug.LogError("Don't have old humanConnection");
                    notCorrectHumanConnections.Remove(humanConnection);
                }
            }
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p == p)
        {
            if (wrapProperty == this)
            {
                ValueChangeUtils.replaceCallBack(this, syncs);
            }
            return;
        }
        // Child
        if (wrapProperty.p is HumanConnection)
        {
            switch ((HumanConnection.Property)wrapProperty.n)
            {
                case HumanConnection.Property.playerId:
                    {
                        HumanConnection humanConnection = wrapProperty.p as HumanConnection;
                        notCorrectHumanConnections.Add(humanConnection);
                    }
                    break;
                case HumanConnection.Property.connection:
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
    }

    #endregion

}