using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UndoRedoRequestMessage : ChatMessage.Content
{

    public VP<uint> userId;

    #region action

    public enum Action
    {
        Ask,
        Accept,
        Refuse
    }

    public VP<Action> action;

    #endregion

    public VP<UndoRedoRequest.Operation> operation;

    #region Constructor

    public enum Property
    {
        userId,
        action,
        operation
    }

    public UndoRedoRequestMessage() : base()
    {
        this.userId = new VP<uint>(this, (byte)Property.userId, 0);
        this.action = new VP<Action>(this, (byte)Property.action, Action.Ask);
        this.operation = new VP<UndoRedoRequest.Operation>(this, (byte)Property.operation, UndoRedoRequest.Operation.Undo);
    }

    #endregion

    public override Type getType()
    {
        return Type.UndoRedoRequest;
    }

}