using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ChangeUseRuleRight : Data
{

    #region canChange

    public VP<bool> canChange;

    public void requestChangeCanChange(uint userId, bool newCanChange)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeCanChange(userId, newCanChange);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is ChangeUseRuleRightIdentity)
                    {
                        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = dataIdentity as ChangeUseRuleRightIdentity;
                        changeUseRuleRightIdentity.requestChangeCanChange(userId, newCanChange);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeCanChange(uint userId, bool newCanChange)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.canChange.v = newCanChange;
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

    #region onlyAdmin

    public VP<bool> onlyAdmin;

    public void requestChangeOnlyAdmin(uint userId, bool newOnlyAdmin)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeOnlyAdmin(userId, newOnlyAdmin);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is ChangeUseRuleRightIdentity)
                    {
                        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = dataIdentity as ChangeUseRuleRightIdentity;
                        changeUseRuleRightIdentity.requestChangeOnlyAdmin(userId, newOnlyAdmin);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeOnlyAdmin(uint userId, bool newOnlyAdmin)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.onlyAdmin.v = newOnlyAdmin;
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

    #region needAdmin

    public VP<bool> needAdmin;

    public void requestChangeNeedAdmin(uint userId, bool newNeedAdmin)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeNeedAdmin(userId, newNeedAdmin);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is ChangeUseRuleRightIdentity)
                    {
                        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = dataIdentity as ChangeUseRuleRightIdentity;
                        changeUseRuleRightIdentity.requestChangeNeedAdmin(userId, newNeedAdmin);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeNeedAdmin(uint userId, bool newNeedAdmin)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.needAdmin.v = newNeedAdmin;
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

    #region needAccept

    public VP<bool> needAccept;

    public void requestChangeNeedAccept(uint userId, bool newNeedAccept)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.changeNeedAccept(userId, newNeedAccept);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is ChangeUseRuleRightIdentity)
                    {
                        ChangeUseRuleRightIdentity changeUseRuleRightIdentity = dataIdentity as ChangeUseRuleRightIdentity;
                        changeUseRuleRightIdentity.requestChangeNeedAccept(userId, newNeedAccept);
                    }
                    else
                    {
                        Debug.LogError("Why isn't correct identity");
                    }
                }
                else
                {
                    Debug.LogError("cannot find dataIdentity");
                }
            }
        }
        else
        {
            Debug.LogError("You cannot request");
        }
    }

    public void changeNeedAccept(uint userId, bool newNeedAccept)
    {
        if (Room.IsCanEditSetting(this, userId))
        {
            this.needAccept.v = newNeedAccept;
        }
        else
        {
            Debug.LogError("cannot change: " + userId + "; " + this);
        }
    }

    #endregion

    #region Constructor

    public enum Property
    {
        canChange,
        onlyAdmin,
        needAdmin,
        needAccept
    }

    public ChangeUseRuleRight() : base()
    {
        this.canChange = new VP<bool>(this, (byte)Property.canChange, true);
        this.onlyAdmin = new VP<bool>(this, (byte)Property.onlyAdmin, false);
        this.needAdmin = new VP<bool>(this, (byte)Property.needAdmin, true);
        this.needAccept = new VP<bool>(this, (byte)Property.needAccept, true);
    }

    #endregion

}