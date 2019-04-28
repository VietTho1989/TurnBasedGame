using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class MineSweeperAIIdentity : DataIdentity
	{

		#region SyncVar

		#region firstMoveType

		[SyncVar(hook="onChangeFirstMoveType")]
		public MineSweeperAI.FirstMoveType firstMoveType;

		public void onChangeFirstMoveType(MineSweeperAI.FirstMoveType newFirstMoveType)
		{
			this.firstMoveType = newFirstMoveType;
			if (this.netData.clientData != null) {
				this.netData.clientData.firstMoveType.v = newFirstMoveType;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<MineSweeperAI> netData = new NetData<MineSweeperAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeFirstMoveType(this.firstMoveType);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.firstMoveType);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is MineSweeperAI) {
				MineSweeperAI mineSweeperAI = data as MineSweeperAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, mineSweeperAI.makeSearchInforms ());
					this.firstMoveType = mineSweeperAI.firstMoveType.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (mineSweeperAI);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is MineSweeperAI) {
				// MineSweeperAI mineSweeperAI = data as MineSweeperAI;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null");
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is MineSweeperAI) {
				switch ((MineSweeperAI.Property)wrapProperty.n) {
				case MineSweeperAI.Property.firstMoveType:
					this.firstMoveType = (MineSweeperAI.FirstMoveType)wrapProperty.getValue ();
					break;
				default:
					Debug.LogError ("Unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		#region firstMoveType

		public void requestChangeFirstMoveType(uint userId, int newFistMoveType)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdMineSweeperAIChangeFirstMoveType (this.netId, userId, newFistMoveType);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeFirstMoveType(uint userId, int newFirstMoveType)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeFirstMoveType (userId, newFirstMoveType);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}