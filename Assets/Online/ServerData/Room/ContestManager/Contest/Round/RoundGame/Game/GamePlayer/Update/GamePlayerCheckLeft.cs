using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayerCheckLeft : UpdateBehavior<GamePlayer>
{

    #region Update

    public override void update()
    {
        if (dirty)
        {
            dirty = false;
            if (this.data != null)
            {
                switch (this.data.state.v.getType())
                {
                    case GamePlayer.State.Type.Normal:
                        {
                            switch (this.data.inform.v.getType())
                            {
                                case GamePlayer.Inform.Type.None:
                                    break;
                                case GamePlayer.Inform.Type.Human:
                                    {
                                        Human human = this.data.inform.v as Human;
                                        // Check already left
                                        bool alreadyLeft = false;
                                        {
                                            Room room = this.data.findDataInParent<Room>();
                                            if (room != null)
                                            {
                                                if (room.state.v is RoomStateNormal)
                                                {
                                                    RoomUser roomUser = room.users.getInList(human.playerId.v);
                                                    if (roomUser == null || !roomUser.isInsideRoom())
                                                    {
                                                        Debug.LogError("this gamePlayer already left: " + this.data);
                                                        alreadyLeft = true;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("room null: " + this);
                                            }
                                        }
                                        // Process left or not
                                        if (alreadyLeft)
                                        {
                                            if (this.data.state.v is GamePlayerStateNormal)
                                            {
                                                GamePlayerStateNormal gamePlayerStateNormal = this.data.state.v as GamePlayerStateNormal;
                                                gamePlayerStateNormal.surrender(human.playerId.v);
                                            }
                                        }
                                        else
                                        {
                                            // Debug.LogError ("this player not left: " + this.data);
                                        }
                                    }
                                    break;
                                case GamePlayer.Inform.Type.Computer:
                                    break;
                                default:
                                    Debug.LogError("unknown inform type: " + this.data.inform.v.getType());
                                    break;
                            }
                        }
                        break;
                    case GamePlayer.State.Type.Surrender:
                        {
                            Debug.LogError("this player already surrender");
                        }
                        break;
                    default:
                        Debug.LogError("unknown gamePlayer state: " + this.data.state.v);
                        break;
                }
            }
            else
            {
                Debug.LogError("gamePlayer null");
            }
        }
    }

    public override bool isShouldDisableUpdate()
    {
        return true;
    }

    #endregion

    #region implement callBacks

    private RoomCheckChangeAdminChange<GamePlayer> roomCheckAdminChange = new RoomCheckChangeAdminChange<GamePlayer>();
    private GameIsPlayingChange<GamePlayer> gameIsPlayingChange = new GameIsPlayingChange<GamePlayer>();

    public override void onAddCallBack<T>(T data)
    {
        if (data is GamePlayer)
        {
            GamePlayer gamePlayer = data as GamePlayer;
            // CheckChange
            {
                // roomUser
                {
                    roomCheckAdminChange.addCallBack(this);
                    roomCheckAdminChange.setData(gamePlayer);
                }
                // game
                {
                    gameIsPlayingChange.addCallBack(this);
                    gameIsPlayingChange.setData(gamePlayer);
                }
            }
            // Child
            {
                gamePlayer.inform.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // CheckChange
        {
            if (data is RoomCheckChangeAdminChange<GamePlayer>)
            {
                dirty = true;
                return;
            }
            if (data is GameIsPlayingChange<GamePlayer>)
            {
                dirty = true;
                return;
            }
        }
        // Child
        if (data is GamePlayer.Inform)
        {
            dirty = true;
            return;
        }
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is GamePlayer)
        {
            GamePlayer gamePlayer = data as GamePlayer;
            // CheckChange
            {
                // roomUser
                {
                    roomCheckAdminChange.removeCallBack(this);
                    roomCheckAdminChange.setData(null);
                }
                // game
                {
                    gameIsPlayingChange.removeCallBack(this);
                    gameIsPlayingChange.setData(null);
                }
            }
            // Child
            {
                gamePlayer.inform.allRemoveCallBack(this);
            }
            this.setDataNull(gamePlayer);
            return;
        }
        // CheckChange
        {
            if (data is RoomCheckChangeAdminChange<GamePlayer>)
            {
                return;
            }
            if (data is GameIsPlayingChange<GamePlayer>)
            {
                return;
            }
        }
        // Child
        if (data is GamePlayer.Inform)
        {
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
        if (wrapProperty.p is GamePlayer)
        {
            switch ((GamePlayer.Property)wrapProperty.n)
            {
                case GamePlayer.Property.playerIndex:
                    break;
                case GamePlayer.Property.inform:
                    {
                        ValueChangeUtils.replaceCallBack(this, syncs);
                        dirty = true;
                    }
                    break;
                case GamePlayer.Property.state:
                    dirty = true;
                    break;
                default:
                    Debug.LogError("unknown wrapProperty: " + wrapProperty + "; " + this);
                    break;
            }
            return;
        }
        // CheckChange
        {
            if (wrapProperty.p is RoomCheckChangeAdminChange<GamePlayer>)
            {
                dirty = true;
                return;
            }
            if (wrapProperty.p is GameIsPlayingChange<GamePlayer>)
            {
                dirty = true;
                return;
            }
        }
        // Child
        if (wrapProperty.p is GamePlayer.Inform)
        {
            if (wrapProperty.p is Human)
            {
                Human.onUpdateSyncPlayerIdChange(wrapProperty, this);
            }
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}