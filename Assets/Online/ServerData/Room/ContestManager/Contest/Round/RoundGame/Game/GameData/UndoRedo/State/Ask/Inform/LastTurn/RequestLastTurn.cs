using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
    public class RequestLastTurn : RequestInform
    {

        public VP<UndoRedoRequest.Operation> operation;

        #region Constructor

        public enum Property
        {
            operation
        }

        public RequestLastTurn() : base()
        {
            this.operation = new VP<UndoRedoRequest.Operation>(this, (byte)Property.operation, UndoRedoRequest.Operation.Undo);
        }

        #endregion

        public override Type getType()
        {
            return Type.LastTurn;
        }

        public override bool isRequestCorrect(History history)
        {
            bool ret = false;
            if (history != null)
            {
                switch (this.operation.v)
                {
                    case UndoRedoRequest.Operation.Undo:
                        {
                            if (history.position.v > 0)
                            {
                                ret = true;
                            }
                            else
                            {
                                Debug.LogError("cannot undo: " + this);
                            }
                        }
                        break;
                    case UndoRedoRequest.Operation.Redo:
                        {
                            if (history.position.v < history.changes.vs.Count)
                            {
                                ret = true;
                            }
                            else
                            {
                                Debug.LogError("cannot redo: " + this);
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown operation: " + operation + "; " + this);
                        break;
                }
            }
            else
            {
                Debug.LogError("history null: " + this);
            }
            return ret;
        }

        public override int getIndex()
        {
            int index = -1;
            {
                // get current turn
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
                // get history
                History history = null;
                {
                    Game game = this.findDataInParent<Game>();
                    if (game != null)
                    {
                        history = game.history.v;
                    }
                    else
                    {
                        Debug.LogError("game null: " + this);
                    }
                }
                // get index
                if (history != null)
                {
                    switch (this.operation.v)
                    {
                        case UndoRedoRequest.Operation.Undo:
                            {
                                if (history.position.v <= history.changes.vs.Count - 1)
                                {
                                    for (int i = history.position.v - 1; i >= 0; i--)
                                    {
                                        if (history.changes.vs[i] is TurnChange)
                                        {
                                            TurnChange turnChange = history.changes.vs[i] as TurnChange;
                                            if (turnChange.turn.v == currentTurn - 1)
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
                                for (int i = history.position.v + 1; i < history.changes.vs.Count; i++)
                                {
                                    if (history.changes.vs[i] is TurnChange)
                                    {
                                        TurnChange turnChange = history.changes.vs[i] as TurnChange;
                                        if (turnChange.turn.v == currentTurn + 1)
                                        {
                                            index = i;
                                            break;
                                        }
                                    }
                                    // TODO luot cuoi ko co new turn change
                                    if (i == history.changes.vs.Count - 1)
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
                else
                {
                    Debug.LogError("history null: " + this);
                }
            }
            return index;
        }

        public override UndoRedoRequest.Operation getOperation()
        {
            return this.operation.v;
        }

    }
}