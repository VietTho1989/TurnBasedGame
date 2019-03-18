using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rights;

namespace UndoRedo
{
    public class AskUpdate : UpdateBehavior<Ask>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    RequestInform requestInform = this.data.requestInform.v;
                    if (requestInform != null)
                    {
                        // Find history
                        History history = null;
                        {
                            Game game = this.data.findDataInParent<Game>();
                            if (game != null)
                            {
                                history = game.history.v;
                            }
                            else
                            {
                                Debug.LogError("game null: " + this);
                            }
                        }
                        // Process
                        if (history != null)
                        {
                            if (requestInform.isRequestCorrect(history))
                            {
                                // check all accept
                                bool allAccept = false;
                                {
                                    // isNeedAccept
                                    bool needAccept = true;
                                    {
                                        Room room = this.data.findDataInParent<Room>();
                                        if (room != null)
                                        {
                                            ChangeRights changeRights = room.changeRights.v;
                                            if (changeRights != null)
                                            {
                                                UndoRedoRight undoRedoRight = changeRights.undoRedoRight.v;
                                                if (undoRedoRight != null)
                                                {
                                                    needAccept = undoRedoRight.needAccept.v;
                                                }
                                                else
                                                {
                                                    Debug.LogError("undoRedoRight null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("changeRights null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("room null: " + this);
                                        }
                                    }
                                    // Process
                                    {
                                        if (needAccept)
                                        {
                                            HashSet<uint> whoCanAnswers = UndoRedoRequest.getWhoCanAnswer(this.data);
                                            // update whoCanAsks Human
                                            {
                                                // get old
                                                List<Human> oldHumans = new List<Human>();
                                                {
                                                    oldHumans.AddRange(this.data.whoCanAsks.vs);
                                                }
                                                // Update
                                                {
                                                    foreach (uint userId in whoCanAnswers)
                                                    {
                                                        // get human
                                                        Human human = null;
                                                        bool needAdd = false;
                                                        {
                                                            // get old
                                                            if (oldHumans.Count > 0)
                                                            {
                                                                human = oldHumans[0];
                                                            }
                                                            // make new
                                                            if (human == null)
                                                            {
                                                                human = new Human();
                                                                {
                                                                    human.uid = this.data.whoCanAsks.makeId();
                                                                }
                                                                needAdd = true;
                                                            }
                                                            else
                                                            {
                                                                oldHumans.Remove(human);
                                                            }
                                                        }
                                                        // Update Property
                                                        {
                                                            human.playerId.v = userId;
                                                        }
                                                        // add
                                                        if (needAdd)
                                                        {
                                                            this.data.whoCanAsks.add(human);
                                                        }
                                                    }
                                                }
                                                // Remove old
                                                foreach (Human oldHuman in oldHumans)
                                                {
                                                    this.data.whoCanAsks.remove(oldHuman);
                                                }
                                            }
                                            // Remove anyone cannot answer
                                            {
                                                // Accept
                                                {
                                                    for (int i = this.data.accepts.vs.Count - 1; i >= 0; i--)
                                                    {
                                                        uint checkAccept = this.data.accepts.vs[i];
                                                        if (!whoCanAnswers.Contains(checkAccept))
                                                        {
                                                            Debug.LogError("Not contain anymore: " + checkAccept);
                                                            this.data.accepts.remove(checkAccept);
                                                        }
                                                    }
                                                }
                                                // Cancel
                                                {
                                                    for (int i = this.data.cancels.vs.Count - 1; i >= 0; i--)
                                                    {
                                                        uint checkCancel = this.data.cancels.vs[i];
                                                        if (!whoCanAnswers.Contains(checkCancel))
                                                        {
                                                            Debug.LogError("Not contain anymore: " + checkCancel);
                                                            this.data.cancels.remove(checkCancel);
                                                        }
                                                    }
                                                }
                                            }
                                            // Process
                                            if (this.data.cancels.vs.Count > 0)
                                            {
                                                // Cancel: chuyen ve none
                                                UndoRedoRequest undoRedoRequest = this.data.findDataInParent<UndoRedoRequest>();
                                                if (undoRedoRequest != null)
                                                {
                                                    None none = new None();
                                                    {
                                                        none.uid = undoRedoRequest.state.makeId();
                                                    }
                                                    undoRedoRequest.state.v = none;
                                                }
                                                else
                                                {
                                                    Debug.LogError("undoRedoRequest null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                allAccept = true;
                                                {
                                                    foreach (uint whoAnswer in whoCanAnswers)
                                                    {
                                                        if (!this.data.accepts.vs.Contains(whoAnswer))
                                                        {
                                                            Debug.LogError("not all accept: " + whoAnswer);
                                                            allAccept = false;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            allAccept = true;
                                        }
                                    }
                                }
                                // Process
                                if (allAccept)
                                {
                                    // add count
                                    {
                                        // find playerIndex
                                        int playerIndex = 0;
                                        {
                                            Game game = this.data.findDataInParent<Game>();
                                            if (game != null)
                                            {
                                                GameData gameData = game.gameData.v;
                                                if (gameData != null)
                                                {
                                                    Turn turn = gameData.turn.v;
                                                    if (turn != null)
                                                    {
                                                        playerIndex = turn.playerIndex.v;
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("turn null");
                                                    }
                                                }
                                                else
                                                {
                                                    Debug.LogError("gameData null");
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("game null");
                                            }
                                        }
                                        // add
                                        {
                                            UndoRedoRequest undoRedoRequest = this.data.findDataInParent<UndoRedoRequest>();
                                            if (undoRedoRequest != null)
                                            {
                                                undoRedoRequest.addCount(playerIndex);
                                            }
                                            else
                                            {
                                                Debug.LogError("undoRedoRequest null");
                                            }
                                        }
                                    }
                                    // goi undoRedoAction
                                    {
                                        Game game = this.data.findDataInParent<Game>();
                                        if (game != null)
                                        {
                                            UndoRedoAction newAction = new UndoRedoAction();
                                            {
                                                newAction.uid = game.gameAction.makeId();
                                                newAction.state.v = null;
                                                newAction.requestInform.v = DataUtils.cloneData(requestInform) as RequestInform;
                                            }
                                            game.gameAction.v = newAction;
                                        }
                                        else
                                        {
                                            Debug.LogError("Why game null");
                                        }
                                    }
                                    // chuyen ve none
                                    {
                                        UndoRedoRequest undoRedoRequest = this.data.findDataInParent<UndoRedoRequest>();
                                        if (undoRedoRequest != null)
                                        {
                                            None none = new None();
                                            {
                                                none.uid = undoRedoRequest.state.makeId();
                                            }
                                            undoRedoRequest.state.v = none;
                                        }
                                        else
                                        {
                                            Debug.LogError("undoRedoRequest null: " + this);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Chuyen ve none: vi request inform error
                                UndoRedoRequest undoRedoRequest = this.data.findDataInParent<UndoRedoRequest>();
                                if (undoRedoRequest != null)
                                {
                                    None none = new None();
                                    {
                                        none.uid = undoRedoRequest.state.makeId();
                                    }
                                    undoRedoRequest.state.v = none;
                                }
                                else
                                {
                                    Debug.LogError("undoRedoRequest null: " + this);
                                }
                            }
                        }
                        else
                        {
                            Debug.LogError("history null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("requestInform null: " + this);
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
        private UndoRedoRequest undoRedoRequest = null;
        private Room room = null;

        private GameCheckPlayerChange<Ask> gameCheckPlayerChange = new GameCheckPlayerChange<Ask>();
        private RoomCheckChangeAdminChange<Ask> roomCheckAdminChange = new RoomCheckChangeAdminChange<Ask>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is Ask)
            {
                Ask ask = data as Ask;
                // CheckChange
                {
                    // check player
                    {
                        gameCheckPlayerChange.addCallBack(this);
                        gameCheckPlayerChange.setData(ask);
                    }
                    // check admin
                    {
                        roomCheckAdminChange.addCallBack(this);
                        roomCheckAdminChange.setData(ask);
                    }
                }
                // Parent
                {
                    DataUtils.addParentCallBack(ask, this, ref this.game);
                    DataUtils.addParentCallBack(ask, this, ref this.undoRedoRequest);
                    DataUtils.addParentCallBack(ask, this, ref this.room);
                }
                // Child
                {
                    ask.requestInform.allAddCallBack(this);
                    ask.whoCanAsks.allAddCallBack(this);
                }
                dirty = true;
                return;
            }
            // CheckChange
            {
                if (data is GameCheckPlayerChange<Ask>)
                {
                    dirty = true;
                    return;
                }
                if (data is RoomCheckChangeAdminChange<Ask>)
                {
                    dirty = true;
                    return;
                }
            }
            // Parent
            {
                // Game
                {
                    if (data is Game)
                    {
                        Game game = data as Game;
                        // Child
                        {
                            game.history.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    if (data is History)
                    {
                        dirty = true;
                        return;
                    }
                }
                // UndoRedoRequest
                if (data is UndoRedoRequest)
                {
                    dirty = true;
                    return;
                }
                // Room
                {
                    if (data is Room)
                    {
                        Room room = data as Room;
                        // Child
                        {
                            room.changeRights.allAddCallBack(this);
                        }
                        dirty = true;
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeRights)
                        {
                            ChangeRights changeRights = data as ChangeRights;
                            // Child
                            {
                                changeRights.undoRedoRight.allAddCallBack(this);
                            }
                            dirty = true;
                            return;
                        }
                        // Child
                        if (data is UndoRedoRight)
                        {
                            dirty = true;
                            return;
                        }
                    }
                }
            }
            // Child
            {
                if (data is RequestInform)
                {
                    dirty = true;
                    return;
                }
                if (data is Human)
                {
                    Human human = data as Human;
                    // Update
                    {
                        UpdateUtils.makeUpdate<HumanUpdate, Human>(human, this.transform);
                    }
                    dirty = true;
                    return;
                }
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is Ask)
            {
                Ask ask = data as Ask;
                // CheckChange
                {
                    // check player
                    {
                        gameCheckPlayerChange.removeCallBack(this);
                        gameCheckPlayerChange.setData(null);
                    }
                    // check admin
                    {
                        roomCheckAdminChange.removeCallBack(this);
                        roomCheckAdminChange.setData(null);
                    }
                }
                // Parent
                {
                    DataUtils.removeParentCallBack(ask, this, ref this.game);
                    DataUtils.removeParentCallBack(ask, this, ref this.undoRedoRequest);
                    DataUtils.removeParentCallBack(ask, this, ref this.room);
                }
                // Child
                {
                    ask.requestInform.allRemoveCallBack(this);
                    ask.whoCanAsks.allRemoveCallBack(this);
                }
                this.setDataNull(ask);
                return;
            }
            // CheckChange
            {
                if (data is GameCheckPlayerChange<Ask>)
                {
                    return;
                }
                if (data is RoomCheckChangeAdminChange<Ask>)
                {
                    return;
                }
            }
            // Parent
            {
                // Game
                {
                    if (data is Game)
                    {
                        Game game = data as Game;
                        // Child
                        {
                            game.history.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    if (data is History)
                    {
                        return;
                    }
                }
                // UndoRedoRequest
                if (data is UndoRedoRequest)
                {
                    return;
                }
                // Room
                {
                    if (data is Room)
                    {
                        Room room = data as Room;
                        // Child
                        {
                            room.changeRights.allRemoveCallBack(this);
                        }
                        return;
                    }
                    // Child
                    {
                        if (data is ChangeRights)
                        {
                            ChangeRights changeRights = data as ChangeRights;
                            // Child
                            {
                                changeRights.undoRedoRight.allRemoveCallBack(this);
                            }
                            return;
                        }
                        // Child
                        if (data is UndoRedoRight)
                        {
                            return;
                        }
                    }
                }
            }
            // Child
            {
                if (data is RequestInform)
                {
                    return;
                }
                if (data is Human)
                {
                    Human human = data as Human;
                    // Update
                    {
                        human.removeCallBackAndDestroy(typeof(HumanUpdate));
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
            if (wrapProperty.p is Ask)
            {
                switch ((Ask.Property)wrapProperty.n)
                {
                    case Ask.Property.requestInform:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case Ask.Property.whoCanAsks:
                        {
                            ValueChangeUtils.replaceCallBack(this, syncs);
                            dirty = true;
                        }
                        break;
                    case Ask.Property.accepts:
                        dirty = true;
                        break;
                    case Ask.Property.cancels:
                        dirty = true;
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            // CheckChange
            {
                if (wrapProperty.p is GameCheckPlayerChange<Ask>)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is RoomCheckChangeAdminChange<Ask>)
                {
                    dirty = true;
                    return;
                }
            }
            // Parent
            {
                // Game
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
                                break;
                            case Game.Property.history:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
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
                    if (wrapProperty.p is History)
                    {
                        switch ((History.Property)wrapProperty.n)
                        {
                            case History.Property.isActive:
                                break;
                            case History.Property.changes:
                                dirty = true;
                                break;
                            case History.Property.position:
                                dirty = true;
                                break;
                            case History.Property.changeCount:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                }
                // UndoRedoRequest
                if (wrapProperty.p is UndoRedoRequest)
                {
                    switch ((UndoRedoRequest.Property)wrapProperty.n)
                    {
                        case UndoRedoRequest.Property.state:
                            break;
                        case UndoRedoRequest.Property.count:
                            break;
                        default:
                            Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                            break;
                    }
                    return;
                }
                // Room
                {
                    if (wrapProperty.p is Room)
                    {
                        switch ((Room.Property)wrapProperty.n)
                        {
                            case Room.Property.changeRights:
                                {
                                    ValueChangeUtils.replaceCallBack(this, syncs);
                                    dirty = true;
                                }
                                break;
                            case Room.Property.name:
                                break;
                            case Room.Property.password:
                                break;
                            case Room.Property.users:
                                break;
                            case Room.Property.state:
                                break;
                            case Room.Property.contestManagers:
                                break;
                            case Room.Property.timeCreated:
                                break;
                            case Room.Property.chatRoom:
                                break;
                            case Room.Property.allowHint:
                                break;
                            default:
                                Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                break;
                        }
                        return;
                    }
                    // Child
                    {
                        if (wrapProperty.p is ChangeRights)
                        {
                            switch ((ChangeRights.Property)wrapProperty.n)
                            {
                                case ChangeRights.Property.undoRedoRight:
                                    {
                                        ValueChangeUtils.replaceCallBack(this, syncs);
                                        dirty = true;
                                    }
                                    break;
                                case ChangeRights.Property.changeGamePlayerRight:
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                        // Child
                        if (wrapProperty.p is UndoRedoRight)
                        {
                            switch ((UndoRedoRight.Property)wrapProperty.n)
                            {
                                case UndoRedoRight.Property.needAccept:
                                    dirty = true;
                                    break;
                                case UndoRedoRight.Property.needAdmin:
                                    dirty = true;
                                    break;
                                case UndoRedoRight.Property.limit:
                                    dirty = true;
                                    break;
                                default:
                                    Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                                    break;
                            }
                            return;
                        }
                    }
                }
            }
            // Child
            {
                if (wrapProperty.p is RequestInform)
                {
                    dirty = true;
                    return;
                }
                if (wrapProperty.p is Human)
                {
                    return;
                }
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}