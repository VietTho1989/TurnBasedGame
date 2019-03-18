using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rights
{
    public class UndoRedoRight : Data
    {

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
                        if (dataIdentity is UndoRedoRightIdentity)
                        {
                            UndoRedoRightIdentity undoRedoRightIdentity = dataIdentity as UndoRedoRightIdentity;
                            undoRedoRightIdentity.requestChangeNeedAccept(userId, newNeedAccept);
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
                        if (dataIdentity is UndoRedoRightIdentity)
                        {
                            UndoRedoRightIdentity undoRedoRightIdentity = dataIdentity as UndoRedoRightIdentity;
                            undoRedoRightIdentity.requestChangeNeedAdmin(userId, newNeedAdmin);
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

        #region limit

        public VP<Limit> limit;

        public Limit.Type getLimitType()
        {
            Limit.Type ret = Limit.Type.NoLimit;
            {
                Limit limit = this.limit.v;
                if (limit != null)
                {
                    ret = limit.getType();
                }
                else
                {
                    Debug.LogError("limit null: " + this);
                }
            }
            return ret;
        }

        public void requestChangeLimitType(uint userId, int newLimitType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeLimitType(userId, newLimitType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is UndoRedoRightIdentity)
                        {
                            UndoRedoRightIdentity undoRedoRightIdentity = dataIdentity as UndoRedoRightIdentity;
                            undoRedoRightIdentity.requestChangeLimitType(userId, newLimitType);
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

        public void changeLimitType(uint userId, int newLimitType)
        {
            if (Room.IsCanEditSetting(this, userId))
            {
                // Find
                bool needNew = true;
                {
                    Limit limit = this.limit.v;
                    if (limit != null)
                    {
                        if (limit.getType() == (Limit.Type)newLimitType)
                        {
                            needNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("limit null: " + this);
                    }
                }
                // Process
                if (needNew)
                {
                    // Find
                    Limit limit = null;
                    {
                        switch ((Limit.Type)newLimitType)
                        {
                            case Limit.Type.NoLimit:
                                limit = new NoLimit();
                                break;
                            case Limit.Type.HaveLimit:
                                limit = new HaveLimit();
                                break;
                            default:
                                Debug.LogError("unknown type: " + newLimitType + "; " + this);
                                break;
                        }
                    }
                    // Process
                    if (limit != null)
                    {
                        limit.uid = this.limit.makeId();
                        this.limit.v = limit;
                    }
                    else
                    {
                        Debug.LogError("limit null: " + this);
                    }
                }
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
            needAccept,
            needAdmin,
            limit
        }

        public UndoRedoRight() : base()
        {
            this.needAccept = new VP<bool>(this, (byte)Property.needAccept, true);
            this.needAdmin = new VP<bool>(this, (byte)Property.needAdmin, false);
            this.limit = new VP<Limit>(this, (byte)Property.limit, new NoLimit());
        }

        #endregion

    }
}