using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AutoMakeLimitRoomContainersUpdate : UpdateBehavior<AllLimitRoomContainers>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                if (this.data.limitRoomContainers.vs.Count == 0)
                {
                    Debug.LogError("Don't hane any limitRoomContainers");
                    // make all
                    {
                        LimitRoomContainer limitRoomContainer = new LimitRoomContainer();
                        {
                            limitRoomContainer.uid = this.data.limitRoomContainers.makeId();
                            limitRoomContainer.maxUserCount.v = LimitRoomContainer.DefaultUserCount;
                            // userCount
                            // users
                            limitRoomContainer.gameTypes.copyList(GameType.AllEnableGameTypes);
                            // rooms
                        }
                        this.data.limitRoomContainers.add(limitRoomContainer);
                    }
                    // make each
                    {
                        foreach (int gameType in Server.GetGameTypes(this.data))
                        {
                            LimitRoomContainer limitRoomContainer = new LimitRoomContainer();
                            {
                                limitRoomContainer.uid = this.data.limitRoomContainers.makeId();
                                limitRoomContainer.maxUserCount.v = LimitRoomContainer.DefaultUserCount;
                                // userCount
                                // users
                                limitRoomContainer.gameTypes.add((GameType.Type)gameType);
                                // rooms
                            }
                            this.data.limitRoomContainers.add(limitRoomContainer);
                        }
                    }
                }
            }
            else
            {
                Debug.LogError("data null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    public override void onAddCallBack<T>(T data)
    {
        if (data is AllLimitRoomContainers)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is AllLimitRoomContainers)
        {
            AllLimitRoomContainers allLimitRoomContainers = data as AllLimitRoomContainers;
            // Child
            {

            }
            this.setDataNull(allLimitRoomContainers);
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (WrapProperty.checkError(wrapProperty))
        {
            return;
        }
        if (wrapProperty.p is AllLimitRoomContainers)
        {
            switch ((AllLimitRoomContainers.Property)wrapProperty.n)
            {
                case AllLimitRoomContainers.Property.limitRoomContainers:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}