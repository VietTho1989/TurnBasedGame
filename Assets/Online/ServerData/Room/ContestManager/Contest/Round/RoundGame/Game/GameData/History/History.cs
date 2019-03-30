using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class History : Data
{

    public VP<bool> isActive;

    #region Change

    public LP<HistoryChange> changes;

    #endregion

    /** chi vao index cua change: 0 -> count - 1*/
    public VP<int> position;

    public VP<uint> changeCount;

    #region HumanConnection

    public HumanConnectionLP humanConnections;

    #region add

    public void requestAddHumanConnection(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.addHumanConnection(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is HistoryIdentity)
                    {
                        HistoryIdentity historyIdentity = dataIdentity as HistoryIdentity;
                        historyIdentity.requestAddHumanConnection(userId);
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

    public void addHumanConnection(uint userId)
    {
        // find old
        HumanConnection humanConnection = this.humanConnections.getInList(userId);
        if (humanConnection == null)
        {
            bool allowLoadHistory = false;
            {
                Room room = this.findDataInParent<Room>();
                if (room != null)
                {
                    allowLoadHistory = room.allowLoadHistory.v;
                }
                else
                {
                    Debug.LogError("room null: " + this);
                }
            }
            // make new
            if (allowLoadHistory)
            {
                humanConnection = new HumanConnection();
                {
                    humanConnection.uid = this.humanConnections.makeId();
                    humanConnection.playerId.v = userId;
                }
                this.humanConnections.add(humanConnection);
            }
            else
            {
                Debug.LogError("not allow load history: " + this);
            }
        }
        else
        {
            Debug.LogError("already have humanConnection: " + this);
        }
    }

    #endregion

    #region remove

    public void requestRemoveHumanConnection(uint userId)
    {
        Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
        if (needRequest.canRequest)
        {
            if (!needRequest.needIdentity)
            {
                this.removeHumanConnection(userId);
            }
            else
            {
                DataIdentity dataIdentity = null;
                if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                {
                    if (dataIdentity is HistoryIdentity)
                    {
                        HistoryIdentity historyIdentity = dataIdentity as HistoryIdentity;
                        historyIdentity.requestRemoveHumanConnection(userId);
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

    public void removeHumanConnection(uint userId)
    {
        // find old
        HumanConnection humanConnection = this.humanConnections.getInList(userId);
        if (humanConnection != null)
        {
            // remove old
            this.humanConnections.remove(humanConnection);
        }
        else
        {
            Debug.LogError("don't have humanConnection: " + this);
        }
    }

    #endregion

    #endregion

    #region Constructor

    public enum Property
    {
        isActive,
        changes,
        position,
        changeCount,
        humanConnections
    }

    public History() : base()
    {
        this.isActive = new VP<bool>(this, (byte)Property.isActive, true);
        this.changes = new LP<HistoryChange>(this, (byte)Property.changes);
        this.position = new VP<int>(this, (byte)Property.position, -1);
        this.changeCount = new VP<uint>(this, (byte)Property.changeCount, 0);
        this.humanConnections = new HumanConnectionLP(this, (byte)Property.humanConnections);
    }

    #endregion

    public GameData getGameData()
    {
        Game game = this.findDataInParent<Game>();
        if (game != null)
        {
            return game.gameData.v;
        }
        else
        {
            Debug.LogError("game null: " + this);
        }
        return null;
    }

    public void reset()
    {
        this.isActive.v = true;
        this.changes.clear();
        this.position.v = -1;
        this.changeCount.v = 0;
    }

    #region get information

    public WrapProperty findWrapProperty(WrapChange change)
    {
        GameData gameData = this.getGameData();
        if (gameData != null)
        {
            Data parent = gameData.findData(change.pi.v);
            if (parent != null)
            {
                WrapProperty wrapProperty = parent.findProperty(change.vn.v);
                // Debug.LogError ("findWrapProperty: " + wrapProperty);
                return wrapProperty;
            }
            else
            {
                Debug.LogError("Cannot find gameData");
            }
        }
        else
        {
            Debug.LogError("Why cannot find gameData");
            Server server = this.findDataInParent<Server>();
            if (server != null)
            {
                Data parent = server.findData(change.pi.v);
                if (parent != null)
                {
                    WrapProperty wrapProperty = parent.findProperty(change.vn.v);
                    return wrapProperty;
                }
            }
            else
            {
                Debug.LogError("server null");
            }
        }
        return null;
    }

    #endregion

    #region add new update

    private void clearFuture()
    {
        for (int i = this.changes.vs.Count - 1; i >= 0; i--)
        {
            if (i > this.position.v)
            {
                this.changes.removeAt(i);
            }
        }
        // refresh change count
        this.changeCount.v = (uint)this.changes.vs.Count;
    }

    public void addTurnChange(TurnChange turnChange)
    {
        // Debug.LogError ("turnChange: " + StringSerializationAPI.Serialize (typeof(TurnChange), turnChange));
        // Debug.LogError ("addTurnChange: " + turnChange + "; " + turnChange.turn);
        if (!isActive.v)
        {
            // Debug.LogError ("the history isn't active");
            return;
        }
        this.clearFuture();
        // Add
        {
            turnChange.uid = this.changes.makeId();
            this.changes.add(turnChange);
        }
        // position
        this.position.v++;
        // refresh change count
        this.changeCount.v = (uint)this.changes.vs.Count;
    }

    public void makeHistoryChange<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
    {
        if (!isActive.v)
        {
            // Debug.LogError ("the history isn't active");
            return;
        }
        // Debug.LogError ("makeHistoryChange: " + wrapProperty + "; " + this);
        // Clear futures: all change have position larger than current index
        this.clearFuture();
        // Make change
        WrapChange newChange = new WrapChange();
        {
            newChange.uid = this.changes.makeId();
            // Search info
            {
                newChange.pi.v = wrapProperty.p.makeSearchInforms(this.getGameData());
                newChange.vn.v = wrapProperty.n;
            }
            // Content
            {
                // newChange.syncsObject = syncs;
                newChange.setSyncsObject(syncs);
            }
            // Position
            this.position.v++;
        }
        changes.add(newChange);
        // refresh change count
        this.changeCount.v = (uint)this.changes.vs.Count;
        // Debug.LogError ("newChange: " + StringSerializationAPI.Serialize (typeof(WrapChange), newChange));
    }

    #endregion

    public void changePosition(int newIndex)
    {
        if (newIndex >= 0 && newIndex < this.changes.vs.Count)
        {
            if (newIndex != this.position.v)
            {
                // change
                {
                    // disable make history change 
                    this.isActive.v = false;
                    {
                        int differ = (newIndex < this.position.v) ? -1 : 1;
                        while (this.position.v != newIndex)
                        {
                            int newPosition = this.position.v + differ;
                            if (newPosition >= 0 && newPosition < this.changes.vs.Count)
                            {
                                this.position.v = newPosition;
                                // TODO make undo/RedoAnimation
                                {
                                    // TODO Can hoan thien
                                }
                                // Update gameData
                                {
                                    HistoryChange change = this.changes.vs[newPosition];
                                    switch (change.getType())
                                    {
                                        case HistoryChange.Type.Wrap:
                                            {
                                                WrapChange wrapChange = change as WrapChange;
                                                // Update
                                                {
                                                    WrapProperty wrapProperty = this.findWrapProperty(wrapChange);
                                                    if (differ < 0)
                                                    {
                                                        wrapProperty.processUndo(wrapChange);
                                                    }
                                                    else
                                                    {
                                                        wrapProperty.processRedo(wrapChange);
                                                    }
                                                }
                                            }
                                            break;
                                        case HistoryChange.Type.Turn:
                                            {
                                                TurnChange turnChange = change as TurnChange;
                                                // Update
                                                {
                                                    GameData gameData = this.getGameData();
                                                    if (gameData != null)
                                                    {
                                                        Turn turn = gameData.turn.v;
                                                        if (turn != null)
                                                        {
                                                            turn.turn.v = turnChange.turn.v;
                                                            turn.playerIndex.v = turnChange.playerIndex.v;
                                                            turn.gameTurn.v = turnChange.gameTurn.v;
                                                        }
                                                        else
                                                        {
                                                            Debug.LogError("turn null: " + this);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Debug.LogError("gameData null: " + this);
                                                    }
                                                }
                                            }
                                            break;
                                        default:
                                            Debug.LogError("unknown type: " + change.getType() + "; " + this);
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("outside history: " + newPosition + "; " + this.changes.vs.Count + "; " + this);
                                break;
                            }
                        }
                    }
                    // enable make history change
                    this.isActive.v = true;
                }
                // change history position
                if (this.position.v != newIndex)
                {
                    Debug.LogError("change position not correct");
                    this.position.v = newIndex;
                }
            }
            else
            {
                Debug.LogError("not new position: " + this);
            }
        }
    }

    public int getIndex(int turnIndex)
    {
        int index = -1;
        {
            UndoRedoRequest.Operation operation = UndoRedoRequest.Operation.Undo;
            // get current turn
            {
                int currentTurn = -1;
                {
                    Game game = this.findDataInParent<Game>();
                    if (game != null)
                    {
                        GameData gameData = game.gameData.v;
                        if (gameData != null)
                        {
                            Turn turn = gameData.turn.v;
                            currentTurn = turn.turn.v;
                            // set operation
                            operation = (turnIndex < currentTurn) ? UndoRedoRequest.Operation.Undo : UndoRedoRequest.Operation.Redo;
                        }
                        else
                        {
                            Debug.LogError("gameData null: " + this);
                        }
                    }
                    else
                    {
                        Debug.LogError("game null: " + this);
                    }
                }
            }
            // get index
            {
                switch (operation)
                {
                    case UndoRedoRequest.Operation.Undo:
                        {
                            if (this.position.v <= this.changes.vs.Count - 1)
                            {
                                for (int i = this.position.v - 1; i >= 0; i--)
                                {
                                    if (this.changes.vs[i] is TurnChange)
                                    {
                                        TurnChange turnChange = this.changes.vs[i] as TurnChange;
                                        // Debug.LogError ("check turnChange: " + turnChange.turn + "; " + turnChange.playerIndex + "; " + turnChange.gameTurn + "; " + ", " + turnIndex);
                                        if (turnChange.turn.v == turnIndex)
                                        {
                                            index = i;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Debug.LogError("why position too large");
                            }
                        }
                        break;
                    case UndoRedoRequest.Operation.Redo:
                        {
                            for (int i = this.position.v + 1; i < this.changes.vs.Count; i++)
                            {
                                if (this.changes.vs[i] is TurnChange)
                                {
                                    TurnChange turnChange = this.changes.vs[i] as TurnChange;
                                    if (turnChange.turn.v == turnIndex)
                                    {
                                        index = i;
                                        break;
                                    }
                                }
                                // TODO luot cuoi ko co new turn change
                                if (i == this.changes.vs.Count - 1)
                                {
                                    Debug.LogError("last turn");
                                    index = i;
                                }
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown operation: " + operation + "; " + this);
                        break;
                }
            }
        }
        // Debug.LogError ("find index by turn: " + index);
        return index;
    }

}