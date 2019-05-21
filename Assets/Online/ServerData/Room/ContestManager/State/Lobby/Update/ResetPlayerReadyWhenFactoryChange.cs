using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ResetPlayerReadyWhenFactoryChange : UpdateBehavior<ContestManagerStateLobby>
    {


        #region Update

        private bool needReset = false;

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    if (needReset)
                    {
                        foreach (LobbyTeam team in this.data.teams.vs)
                        {
                            foreach (LobbyPlayer player in team.players.vs)
                            {
                                player.isReady.v = false;
                            }
                        }
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
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
            if (data is ContestManagerStateLobby)
            {
                ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                // Child
                {
                    contestManagerStateLobby.contentFactory.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                data.addCallBackAllChildren(this);
                return;
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is ContestManagerStateLobby)
            {
                ContestManagerStateLobby contestManagerStateLobby = data as ContestManagerStateLobby;
                // Child
                {
                    contestManagerStateLobby.contentFactory.allRemoveCallBack(this);
                }
                this.setDataNull(contestManagerStateLobby);
                return;
            }
            // Child
            {
                data.removeCallBackAllChildren(this);
                return;
            }
            // Debug.LogError ("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is ContestManagerStateLobby)
            {
                switch ((ContestManagerStateLobby.Property)wrapProperty.n)
                {
                    case ContestManagerStateLobby.Property.state:
                        break;
                    case ContestManagerStateLobby.Property.teams:
                        break;
                    case ContestManagerStateLobby.Property.gameType:
                        break;
                    case ContestManagerStateLobby.Property.randomTeamIndex:
                        {
                            dirty = true;
                            needReset = true;
                        }
                        break;
                    case ContestManagerStateLobby.Property.contentFactory:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                            needReset = true;
                        }
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (Generic.IsAddCallBackInterface<T>())
                {
                    ValueChangeUtils.replaceCallBack(this, syncs);
                }
                dirty = true;
                needReset = true;
                return;
            }
            // Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}