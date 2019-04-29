using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable CS0618
namespace GameManager.Match.Swap
{
    [NetworkSettings(channel = DataIdentity.ChatChanel)]
    public class SwapPlayerMessageIdentity : DataIdentity
    {

        #region SyncVar

        #region userId

        [SyncVar(hook = "onChangeUserId")]
        public System.UInt32 userId;

        public void onChangeUserId(System.UInt32 newUserId)
        {
            this.userId = newUserId;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.userId.v = newUserId;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region action

        [SyncVar(hook = "onChangeAction")]
        public GameManager.Match.Swap.SwapPlayerMessage.Action action;

        public void onChangeAction(GameManager.Match.Swap.SwapPlayerMessage.Action newAction)
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

        #region teamIndex

        [SyncVar(hook = "onChangeTeamIndex")]
        public System.Int32 teamIndex;

        public void onChangeTeamIndex(System.Int32 newTeamIndex)
        {
            this.teamIndex = newTeamIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.teamIndex.v = newTeamIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region playerIndex

        [SyncVar(hook = "onChangePlayerIndex")]
        public System.Int32 playerIndex;

        public void onChangePlayerIndex(System.Int32 newPlayerIndex)
        {
            this.playerIndex = newPlayerIndex;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.playerIndex.v = newPlayerIndex;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region type

        [SyncVar(hook = "onChangeType")]
        public GamePlayer.Inform.Type type;

        public void onChangeType(GamePlayer.Inform.Type newType)
        {
            this.type = newType;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.type.v = newType;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #region humanId

        [SyncVar(hook = "onChangeHumanId")]
        public System.UInt32 humanId;

        public void onChangeHumanId(System.UInt32 newHumanId)
        {
            this.humanId = newHumanId;
            if (this.netData.clientData != null)
            {
                this.netData.clientData.humanId.v = newHumanId;
            }
            else
            {
                // Debug.LogError ("clientData null: "+this);
            }
        }

        #endregion

        #endregion

        #region NetData

        private NetData<SwapPlayerMessage> netData = new NetData<SwapPlayerMessage>();

        public override NetDataDelegate getNetData()
        {
            return this.netData;
        }

        public override void refreshClientData()
        {
            if (this.netData.clientData != null)
            {
                this.onChangeUserId(this.userId);
                this.onChangeAction(this.action);
                this.onChangeTeamIndex(this.teamIndex);
                this.onChangePlayerIndex(this.playerIndex);
                this.onChangeType(this.type);
                this.onChangeHumanId(this.humanId);
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
                ret += GetDataSize(this.userId);
                ret += GetDataSize(this.action);
                ret += GetDataSize(this.teamIndex);
                ret += GetDataSize(this.playerIndex);
                ret += GetDataSize(this.type);
                ret += GetDataSize(this.humanId);
            }
            return ret;
        }

        #endregion

        #region implemt callback

        public override void onAddCallBack<T>(T data)
        {
            if (data is SwapPlayerMessage)
            {
                SwapPlayerMessage swapPlayerMessage = data as SwapPlayerMessage;
                // Set new parent
                this.addTransformToParent();
                // Set property
                {
                    this.serialize(this.searchInfor, swapPlayerMessage.makeSearchInforms());
                    this.userId = swapPlayerMessage.userId.v;
                    this.action = swapPlayerMessage.action.v;
                    this.teamIndex = swapPlayerMessage.teamIndex.v;
                    this.playerIndex = swapPlayerMessage.playerIndex.v;
                    this.type = swapPlayerMessage.type.v;
                    this.humanId = swapPlayerMessage.humanId.v;
                }
                // Observer
                {
                    GameObserver observer = GetComponent<GameObserver>();
                    if (observer != null)
                    {
                        observer.checkChange = new FollowParentObserver(observer);
                        observer.setCheckChangeData(swapPlayerMessage);
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
            if (data is SwapPlayerMessage)
            {
                // SwapPlayerMessage swapPlayerMessage = data as SwapPlayerMessage;
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
            if (wrapProperty.p is SwapPlayerMessage)
            {
                switch ((SwapPlayerMessage.Property)wrapProperty.n)
                {
                    case SwapPlayerMessage.Property.userId:
                        this.userId = (System.UInt32)wrapProperty.getValue();
                        break;
                    case SwapPlayerMessage.Property.action:
                        this.action = (GameManager.Match.Swap.SwapPlayerMessage.Action)wrapProperty.getValue();
                        break;
                    case SwapPlayerMessage.Property.teamIndex:
                        this.teamIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case SwapPlayerMessage.Property.playerIndex:
                        this.playerIndex = (System.Int32)wrapProperty.getValue();
                        break;
                    case SwapPlayerMessage.Property.type:
                        this.type = (GamePlayer.Inform.Type)wrapProperty.getValue();
                        break;
                    case SwapPlayerMessage.Property.humanId:
                        this.humanId = (System.UInt32)wrapProperty.getValue();
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