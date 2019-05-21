using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class ContestManagerUpdate : UpdateBehavior<ContestManager>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    // fastStart
                    {
                        Debug.LogError("ContestManagerUpdate: fast start: " + this.data.isFastStart);
                        if (this.data.isFastStart)
                        {
                            this.data.isFastStart = false;
                            if(this.data.state.v is ContestManagerStateLobby)
                            {
                                ContestManagerStateLobby contestManagerStateLobby = this.data.state.v as ContestManagerStateLobby;
                                contestManagerStateLobby.isFastStart = true;
                                // Update
                                {
                                    ContestManagerStateLobbyUpdate contestManagerStateLobbyUpdate = contestManagerStateLobby.findCallBack<ContestManagerStateLobbyUpdate>();
                                    if (contestManagerStateLobbyUpdate != null)
                                    {
                                        contestManagerStateLobbyUpdate.makeDirty();
                                    }
                                    else
                                    {
                                        Debug.LogError("contestManagerStateLobbyUpdate null");
                                    }
                                }
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
            if (data is ContestManager)
            {
                ContestManager contestManager = data as ContestManager;
                // Child
                {
                    contestManager.state.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is ContestManager.State)
                {
                    ContestManager.State state = data as ContestManager.State;
                    // Update
                    {
                        switch (state.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                {
                                    ContestManagerStateLobby lobby = state as ContestManagerStateLobby;
                                    UpdateUtils.makeUpdate<ContestManagerStateLobbyUpdate, ContestManagerStateLobby>(lobby, this.transform);
                                }
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    ContestManagerStatePlay play = state as ContestManagerStatePlay;
                                    UpdateUtils.makeUpdate<ContestManagerStatePlayUpdate, ContestManagerStatePlay>(play, this.transform);
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is ContestManager)
            {
                ContestManager contestManager = data as ContestManager;
                // Child
                {
                    contestManager.state.allRemoveCallBack(this);
                }
                this.setDataNull(contestManager);
                return;
            }
            // Child
            {
                if (data is ContestManager.State)
                {
                    ContestManager.State state = data as ContestManager.State;
                    // Update
                    {
                        switch (state.getType())
                        {
                            case ContestManager.State.Type.Lobby:
                                {
                                    ContestManagerStateLobby lobby = state as ContestManagerStateLobby;
                                    lobby.removeCallBackAndDestroy(typeof(ContestManagerStateLobbyUpdate));
                                }
                                break;
                            case ContestManager.State.Type.Play:
                                {
                                    ContestManagerStatePlay play = state as ContestManagerStatePlay;
                                    play.removeCallBackAndDestroy(typeof(ContestManagerStatePlayUpdate));
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + state.getType() + "; " + this);
                                break;
                        }
                    }
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is ContestManager)
            {
                switch ((ContestManager.Property)wrapProperty.n)
                {
                    case ContestManager.Property.state:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
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
                if (wrapProperty.p is ContestManager.State)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}