using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanLP : LP<Human>, ValueChangeCallBack
{

    #region Constructor

    public HumanLP(Data parent, byte name) : base(parent, name)
    {
        parent.addCallBack(this);
    }

    #endregion

    #region dictionary

    private Dictionary<uint, Human> humanDict = new Dictionary<uint, Human>();
    private HashSet<Human> notCorrectHumans = new HashSet<Human>();

    public Human getInList(uint playerId)
    {
        Human ret = null;
        {
            // get in dict
            Human oldHuman = null;
            {
                if (!humanDict.TryGetValue(playerId, out oldHuman))
                {
                    Debug.LogError("Don't have human");
                }
            }
            // get in notCorrectHumans
            if (oldHuman != null && oldHuman.playerId.v == playerId)
            {
                // Debug.LogError("already found, not find in notCorrectHumans anymore");
                ret = oldHuman;
            }
            else
            {
                // add to notCorrectHumans
                if (oldHuman != null)
                {
                    notCorrectHumans.Add(oldHuman);
                    humanDict.Remove(playerId);
                }
                // find in not correctHumans
                {
                    // find
                    foreach (Human human in notCorrectHumans)
                    {
                        if (human.playerId.v == playerId)
                        {
                            ret = human;
                            break;
                        }
                    }
                    // add to dictionary
                    if (ret != null)
                    {
                        humanDict[playerId] = ret;
                        notCorrectHumans.Remove(ret);
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
        if(data == p)
        {
            return;
        }
        if (data is Human)
        {
            Human human = data as Human;
            // add
            {
                // find old
                Human oldHuman = null;
                {
                    if (humanDict.TryGetValue(human.playerId.v, out oldHuman))
                    {
                        Debug.LogError("already have oldHuman: " + oldHuman);
                    }
                }
                // process
                if (oldHuman == null)
                {
                    humanDict[human.playerId.v] = human;
                }
                else
                {
                    notCorrectHumans.Add(human);
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
        if (data is Human)
        {
            Human human = data as Human;
            // remove
            {
                // find old
                Human oldHuman = null;
                {
                    if (humanDict.TryGetValue(human.playerId.v, out oldHuman))
                    {

                    }
                }
                // process
                if (oldHuman == human)
                {
                    humanDict.Remove(human.playerId.v);
                    notCorrectHumans.Remove(human);
                }
                else
                {
                    Debug.LogError("Don't have old human");
                    notCorrectHumans.Remove(human);
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
        if (wrapProperty.p is Human)
        {
            switch ((Human.Property)wrapProperty.n)
            {
                case Human.Property.playerId:
                    {
                        Human human = wrapProperty.p as Human;
                        notCorrectHumans.Add(human);
                    }
                    break;
                case Human.Property.account:
                    break;
                case Human.Property.state:
                    break;
                case Human.Property.email:
                    break;
                case Human.Property.phoneNumber:
                    break;
                case Human.Property.status:
                    break;
                case Human.Property.birthday:
                    break;
                case Human.Property.sex:
                    break;
                case Human.Property.connection:
                    break;
                case Human.Property.ban:
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