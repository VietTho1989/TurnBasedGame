using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
    public class None : UndoRedoRequest.State
    {

        #region Constructor

        public enum Property
        {

        }

        public None() : base()
        {

        }

        #endregion

        public override Type getType()
        {
            return Type.None;
        }

        #region request last turn

        public void requestAskLastTurn(uint userId, UndoRedoRequest.Operation operation)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.askLastTurn(userId, operation);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is NoneIdentity)
                        {
                            NoneIdentity noneIdentity = dataIdentity as NoneIdentity;
                            noneIdentity.requestAskLastTurn(userId, operation);
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

        public void askLastTurn(uint userId, UndoRedoRequest.Operation operation)
        {
            if (UndoRedoRequest.getWhoCanAnswer(this).Contains(userId))
            {
                // make request
                RequestLastTurn requestLastTurn = new RequestLastTurn();
                {
                    requestLastTurn.operation.v = operation;
                }
                // check correct
                bool isCorrectRequest = false;
                {
                    // find history
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
                    // Process
                    if (history != null)
                    {
                        isCorrectRequest = requestLastTurn.isRequestCorrect(history);
                    }
                    else
                    {
                        Debug.LogError("history null: " + this);
                    }
                }
                // Process
                if (isCorrectRequest)
                {
                    // makeMessage
                    UndoRedoRequestMessage.Add(this, userId, UndoRedoRequestMessage.Action.Ask, operation);
                    // Chuyen sang ask
                    UndoRedoRequest undoRedoRequest = this.findDataInParent<UndoRedoRequest>();
                    if (undoRedoRequest != null)
                    {
                        Ask ask = new Ask();
                        {
                            ask.uid = undoRedoRequest.state.makeId();
                            ask.requestInform.v = DataUtils.cloneData(requestLastTurn) as RequestLastTurn;
                            ask.accepts.add(userId);
                        }
                        undoRedoRequest.state.v = ask;
                    }
                    else
                    {
                        Debug.LogError("game null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("request not correct: " + this);
                }
            }
            else
            {
                Debug.LogError("cannot request: " + userId);
            }
        }

        #endregion

        #region request last turn

        public void requestAskLastYourTurn(uint userId, UndoRedoRequest.Operation operation)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.askLastYourTurn(userId, operation);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is NoneIdentity)
                        {
                            NoneIdentity noneIdentity = dataIdentity as NoneIdentity;
                            noneIdentity.requestAskLastYourTurn(userId, operation);
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

        public void askLastYourTurn(uint userId, UndoRedoRequest.Operation operation)
        {
            if (UndoRedoRequest.getWhoCanAnswer(this).Contains(userId))
            {
                // make request
                RequestLastYourTurn requestLastYourTurn = new RequestLastYourTurn();
                {
                    requestLastYourTurn.operation.v = operation;
                    requestLastYourTurn.userId.v = userId;
                }
                // check correct
                bool isCorrectRequest = false;
                {
                    // find history
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
                    // Process
                    if (history != null)
                    {
                        isCorrectRequest = requestLastYourTurn.isRequestCorrect(history);
                    }
                    else
                    {
                        Debug.LogError("history null: " + this);
                    }
                }
                // Process
                if (isCorrectRequest)
                {
                    // makeMessage
                    UndoRedoRequestMessage.Add(this, userId, UndoRedoRequestMessage.Action.Ask, operation);
                    // Chuyen sang ask
                    UndoRedoRequest undoRedoRequest = this.findDataInParent<UndoRedoRequest>();
                    if (undoRedoRequest != null)
                    {
                        Ask ask = new Ask();
                        {
                            ask.uid = undoRedoRequest.state.makeId();
                            ask.requestInform.v = DataUtils.cloneData(requestLastYourTurn) as RequestLastYourTurn;
                            ask.accepts.add(userId);
                        }
                        undoRedoRequest.state.v = ask;
                    }
                    else
                    {
                        Debug.LogError("game null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("request not correct: " + this);
                }
            }
            else
            {
                Debug.LogError("cannot request: " + userId);
            }
        }

        #endregion

    }
}