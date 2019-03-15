using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UndoRedo;

public class UndoRedoRequestUpdate : UpdateBehavior<UndoRedoRequest>
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
                // check null
                if (this.data.state.v == null)
                {
                    None none = new None();
                    {
                        none.uid = this.data.state.makeId();
                    }
                    this.data.state.v = none;
                }
                // reset
                if (needReset)
                {
                    needReset = false;
                    if (!(this.data.state.v is None))
                    {
                        None none = new None();
                        {
                            none.uid = this.data.state.makeId();
                        }
                        this.data.state.v = none;
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

    private Game game = null;

    public override void onAddCallBack<T>(T data)
    {
        if (data is UndoRedoRequest)
        {
            UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
            // Parent
            {
                DataUtils.addParentCallBack(undoRedoRequest, this, ref this.game);
            }
            // Child
            {
                undoRedoRequest.state.allAddCallBack(this);
            }
            dirty = true;
            return;
        }
        // Parent
        {
            if (data is Game)
            {
                Game game = data as Game;
                // Child
                {
                    game.gameData.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Child
                    {
                        gameData.turn.allAddCallBack(this);
                    }
                    dirty = true;
                    return;
                }
                // Child
                if (data is Turn)
                {
                    dirty = true;
                    needReset = true;
                    return;
                }
            }
        }
        // Child
        if (data is UndoRedoRequest.State)
        {
            UndoRedoRequest.State state = data as UndoRedoRequest.State;
            // Update
            {
                switch (state.getType())
                {
                    case UndoRedoRequest.State.Type.None:
                        {
                            None none = state as None;
                            UpdateUtils.makeUpdate<NoneUpdate, None>(none, this.transform);
                        }
                        break;
                    case UndoRedoRequest.State.Type.Ask:
                        {
                            Ask ask = state as Ask;
                            UpdateUtils.makeUpdate<AskUpdate, Ask>(ask, this.transform);
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
        Debug.LogError("Don't process: " + data + "; " + this);
    }

    public override void onRemoveCallBack<T>(T data, bool isHide)
    {
        if (data is UndoRedoRequest)
        {
            UndoRedoRequest undoRedoRequest = data as UndoRedoRequest;
            // Parent
            {
                DataUtils.removeParentCallBack(undoRedoRequest, this, ref this.game);
            }
            // Child
            {
                undoRedoRequest.state.allRemoveCallBack(this);
            }
            this.setDataNull(undoRedoRequest);
            return;
        }
        // Parent
        {
            if (data is Game)
            {
                Game game = data as Game;
                // Child
                {
                    game.gameData.allRemoveCallBack(this);
                }
                return;
            }
            // Child
            {
                if (data is GameData)
                {
                    GameData gameData = data as GameData;
                    // Child
                    {
                        gameData.turn.allRemoveCallBack(this);
                    }
                    return;
                }
                // Child
                if (data is Turn)
                {
                    return;
                }
            }
        }
        // Child
        if (data is UndoRedoRequest.State)
        {
            UndoRedoRequest.State state = data as UndoRedoRequest.State;
            // Update
            {
                switch (state.getType())
                {
                    case UndoRedoRequest.State.Type.None:
                        {
                            None none = state as None;
                            none.removeCallBackAndDestroy(typeof(NoneUpdate));
                        }
                        break;
                    case UndoRedoRequest.State.Type.Ask:
                        {
                            Ask ask = state as Ask;
                            ask.removeCallBackAndDestroy(typeof(AskUpdate));
                        }
                        break;
                    default:
                        Debug.LogError("unknown type: " + state.getType() + "; " + this);
                        break;
                }
            }
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
        if (wrapProperty.p is UndoRedoRequest)
        {
            switch ((UndoRedoRequest.Property)wrapProperty.n)
            {
                case UndoRedoRequest.Property.state:
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
        // Parent
        {
            if (wrapProperty.p is Game)
            {
                switch ((Game.Property)wrapProperty.n)
                {
                    case Game.Property.gamePlayers:
                        break;
                    case Game.Property.requestDraw:
                        break;
                    case Game.Property.state:
                        break;
                    case Game.Property.gameData:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case Game.Property.history:
                        break;
                    case Game.Property.gameAction:
                        break;
                    case Game.Property.undoRedoRequest:
                        break;
                    case Game.Property.chatRoom:
                        break;
                    case Game.Property.animationData:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // Child
            {
                if (wrapProperty.p is GameData)
                {
                    switch ((GameData.Property)wrapProperty.n)
                    {
                        case GameData.Property.gameType:
                            break;
                        case GameData.Property.useRule:
                            break;
                        case GameData.Property.turn:
                            {
                                ValueChangeUtils.replaceCallBack(this, syncs);
                                dirty = true;
                            }
                            break;
                        case GameData.Property.timeControl:
                            break;
                        case GameData.Property.lastMove:
                            break;
                        case GameData.Property.state:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Child
                if (wrapProperty.p is Turn)
                {
                    dirty = true;
                    needReset = true;
                    return;
                }
            }
        }
        // Child
        if (wrapProperty.p is UndoRedoRequest.State)
        {
            return;
        }
        Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
    }

    #endregion

}