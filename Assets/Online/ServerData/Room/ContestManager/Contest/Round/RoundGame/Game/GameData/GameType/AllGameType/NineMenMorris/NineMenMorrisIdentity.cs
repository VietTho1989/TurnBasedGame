using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace NineMenMorris
{
    public class NineMenMorrisIdentity : DataIdentity
    {

        #region SyncVar

        #region board

        public SyncListInt board = new SyncListInt();

        private void OnBoardChanged(SyncListInt.Operation op, int index)
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.onSyncListChange(this.netData.clientData.board, this.board, op, index);
            }
            else
            {
                // Debug.LogError ("clientData null: " + this);
            }
        }

        #endregion

        #region moved

        [SyncVar(hook = "onChangeMoved")]
        public System.Int32 moved;

        public void onChangeMoved(System.Int32 newMoved)
        {
            this.moved = newMoved;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.moved.v = newMoved;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region moved_to

        [SyncVar(hook = "onChangeMoved_to")]
        public System.Int32 moved_to;

        public void onChangeMoved_to(System.Int32 newMoved_to)
        {
            this.moved_to = newMoved_to;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.moved_to.v = newMoved_to;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region action

        [SyncVar(hook = "onChangeAction")]
        public Common.NMMAction action;

        public void onChangeAction(Common.NMMAction newAction)
        {
            this.action = newAction;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.action.v = newAction;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region mill

        [SyncVar(hook = "onChangeMill")]
        public System.Boolean mill;

        public void onChangeMill(System.Boolean newMill)
        {
            this.mill = newMill;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.mill.v = newMill;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region terminal

        [SyncVar(hook = "onChangeTerminal")]
        public System.Boolean terminal;

        public void onChangeTerminal(System.Boolean newTerminal)
        {
            this.terminal = newTerminal;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.terminal.v = newTerminal;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region removed

        [SyncVar(hook = "onChangeRemoved")]
        public System.Int32 removed;

        public void onChangeRemoved(System.Int32 newRemoved)
        {
            this.removed = newRemoved;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.removed.v = newRemoved;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region utility

        [SyncVar(hook = "onChangeUtility")]
        public System.Single utility;

        public void onChangeUtility(System.Single newUtility)
        {
            this.utility = newUtility;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.utility.v = newUtility;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region turn

        [SyncVar(hook = "onChangeTurn")]
        public System.Int32 turn;

        public void onChangeTurn(System.Int32 newTurn)
        {
            this.turn = newTurn;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.turn.v = newTurn;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region isCustom

        [SyncVar(hook = "onChangeIsCustom")]
        public System.Boolean isCustom;

        public void onChangeIsCustom(System.Boolean newIsCustom)
        {
            this.isCustom = newIsCustom;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.isCustom.v = newIsCustom;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<NineMenMorris> netData = new NetData<NineMenMorris>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void addSyncListCallBack()
        {
            base.addSyncListCallBack();
            this.board.Callback += OnBoardChanged;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                IdentityUtils.refresh(this.netData.clientData.board, this.board);
                this.onChangeMoved(this.moved);
                this.onChangeMoved_to(this.moved_to);
                this.onChangeAction(this.action);
                this.onChangeMill(this.mill);
                this.onChangeTerminal(this.terminal);
                this.onChangeRemoved(this.removed);
                this.onChangeUtility(this.utility);
                this.onChangeTurn(this.turn);
                this.onChangeIsCustom(this.isCustom);
            }
            else
            {
                Debug.Log("clientData null");
            }
        }

        public override int refreshDataSize()
        {
            int ret = GetDataSize(this.netId);
            {
                ret += GetDataSize(this.board);
                ret += GetDataSize(this.moved);
                ret += GetDataSize(this.moved_to);
                ret += GetDataSize(this.action);
                ret += GetDataSize(this.mill);
                ret += GetDataSize(this.terminal);
                ret += GetDataSize(this.removed);
                ret += GetDataSize(this.utility);
                ret += GetDataSize(this.turn);
                ret += GetDataSize(this.isCustom);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is NineMenMorris)
            {
                NineMenMorris nineMenMorris = data as NineMenMorris;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, nineMenMorris.makeSearchInforms());
                    IdentityUtils.InitSync(this.board, nineMenMorris.board.vs);
                    this.moved = nineMenMorris.moved.v;
                    this.moved_to = nineMenMorris.moved_to.v;
                    this.action = nineMenMorris.action.v;
                    this.mill = nineMenMorris.mill.v;
                    this.terminal = nineMenMorris.terminal.v;
                    this.removed = nineMenMorris.removed.v;
                    this.utility = nineMenMorris.utility.v;
                    this.turn = nineMenMorris.turn.v;
                    this.isCustom = nineMenMorris.isCustom.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(nineMenMorris);
                    }
                    else
                    {
                        Debug.LogError("observer null: " + this);
                    }
                }
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is NineMenMorris)
            {
                // NineMenMorris nineMenMorris = data as NineMenMorris;
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.setCheckChangeData(null);
                    }
                    else
                    {
                        Debug.LogError("observer null: " + this);
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
            if (wrapProperty.p is NineMenMorris)
            {
                switch ((NineMenMorris.Property)wrapProperty.n)
                {
                    case NineMenMorris.Property.board:
                        IdentityUtils.UpdateSyncList(this.board, syncs, GlobalCast<T>.CastingInt32);
                        break;
                    case NineMenMorris.Property.moved:
                        this.moved = (System.Int32)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.moved_to:
                        this.moved_to = (System.Int32)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.action:
                        this.action = (Common.NMMAction)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.mill:
                        this.mill = (System.Boolean)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.terminal:
                        this.terminal = (System.Boolean)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.removed:
                        this.removed = (System.Int32)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.utility:
                        this.utility = (System.Single)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.turn:
                        this.turn = (System.Int32)wrapProperty.getValue();
                        break;
                    case NineMenMorris.Property.isCustom:
                        this.isCustom = (System.Boolean)wrapProperty.getValue();
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
}