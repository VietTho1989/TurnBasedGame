using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NineMenMorrisAIIdentity : DataIdentity
	{

		#region SyncVar

		#region MaxNormal

		[SyncVar(hook="onChangeMaxNormal")]
		public System.Int32 MaxNormal;

		public void onChangeMaxNormal(System.Int32 newMaxNormal)
		{
			this.MaxNormal = newMaxNormal;
			if (this.netData.clientData != null) {
				this.netData.clientData.MaxNormal.v = newMaxNormal;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region MaxPositioning

		[SyncVar(hook="onChangeMaxPositioning")]
		public System.Int32 MaxPositioning;

		public void onChangeMaxPositioning(System.Int32 newMaxPositioning)
		{
			this.MaxPositioning = newMaxPositioning;
			if (this.netData.clientData != null) {
				this.netData.clientData.MaxPositioning.v = newMaxPositioning;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region MaxBlackAndWhite3

		[SyncVar(hook="onChangeMaxBlackAndWhite3")]
		public System.Int32 MaxBlackAndWhite3;

		public void onChangeMaxBlackAndWhite3(System.Int32 newMaxBlackAndWhite3)
		{
			this.MaxBlackAndWhite3 = newMaxBlackAndWhite3;
			if (this.netData.clientData != null) {
				this.netData.clientData.MaxBlackAndWhite3.v = newMaxBlackAndWhite3;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region MaxBlackOrWhite3

		[SyncVar(hook="onChangeMaxBlackOrWhite3")]
		public System.Int32 MaxBlackOrWhite3;

		public void onChangeMaxBlackOrWhite3(System.Int32 newMaxBlackOrWhite3)
		{
			this.MaxBlackOrWhite3 = newMaxBlackOrWhite3;
			if (this.netData.clientData != null) {
				this.netData.clientData.MaxBlackOrWhite3.v = newMaxBlackOrWhite3;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region pickBestMove

		[SyncVar(hook="onChangePickBestMove")]
		public System.Int32 pickBestMove;

		public void onChangePickBestMove(System.Int32 newPickBestMove)
		{
			this.pickBestMove = newPickBestMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.pickBestMove.v = newPickBestMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<NineMenMorrisAI> netData = new NetData<NineMenMorrisAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeMaxNormal(this.MaxNormal);
				this.onChangeMaxPositioning(this.MaxPositioning);
				this.onChangeMaxBlackAndWhite3(this.MaxBlackAndWhite3);
				this.onChangeMaxBlackOrWhite3(this.MaxBlackOrWhite3);
				this.onChangePickBestMove(this.pickBestMove);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.MaxNormal);
				ret += GetDataSize (this.MaxPositioning);
				ret += GetDataSize (this.MaxBlackAndWhite3);
				ret += GetDataSize (this.MaxBlackOrWhite3);
				ret += GetDataSize (this.pickBestMove);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is NineMenMorrisAI) {
				NineMenMorrisAI nineMenMorrisAI = data as NineMenMorrisAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, nineMenMorrisAI.makeSearchInforms ());
					this.MaxNormal = nineMenMorrisAI.MaxNormal.v;
					this.MaxPositioning = nineMenMorrisAI.MaxPositioning.v;
					this.MaxBlackAndWhite3 = nineMenMorrisAI.MaxBlackAndWhite3.v;
					this.MaxBlackOrWhite3 = nineMenMorrisAI.MaxBlackOrWhite3.v;
					this.pickBestMove = nineMenMorrisAI.pickBestMove.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (nineMenMorrisAI);
					} else {
						Debug.LogError ("observer null: " + this);
					}
				}
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is NineMenMorrisAI) {
				// NineMenMorrisAI nineMenMorrisAI = data as NineMenMorrisAI;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.setCheckChangeData (null);
					} else {
						Debug.LogError ("observer null: " + this);
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
			if (wrapProperty.p is NineMenMorrisAI) {
				switch ((NineMenMorrisAI.Property)wrapProperty.n) {
				case NineMenMorrisAI.Property.MaxNormal:
					this.MaxNormal = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisAI.Property.MaxPositioning:
					this.MaxPositioning = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisAI.Property.MaxBlackAndWhite3:
					this.MaxBlackAndWhite3 = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisAI.Property.MaxBlackOrWhite3:
					this.MaxBlackOrWhite3 = (System.Int32)wrapProperty.getValue ();
					break;
				case NineMenMorrisAI.Property.pickBestMove:
					this.pickBestMove = (System.Int32)wrapProperty.getValue ();
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

		#region MaxNormal

		public void requestChangeMaxNormal(uint userId, int newMaxNormal)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdNineMenMorrisAIChangeMaxNormal (this.netId, userId, newMaxNormal);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxNormal(uint userId, int newMaxNormal){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxNormal (userId, newMaxNormal);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region MaxPositioning

		public void requestChangeMaxPositioning(uint userId, int newMaxPositioning)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdNineMenMorrisAIChangeMaxPositioning (this.netId, userId, newMaxPositioning);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxPositioning(uint userId, int newMaxPositioning){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxPositioning (userId, newMaxPositioning);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region MaxBlackAndWhite3

		public void requestChangeMaxBlackAndWhite3(uint userId, int newMaxBlackAndWhite3)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdNineMenMorrisAIChangeMaxBlackAndWhite3 (this.netId, userId, newMaxBlackAndWhite3);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxBlackAndWhite3(uint userId, int newMaxBlackAndWhite3){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxBlackAndWhite3 (userId, newMaxBlackAndWhite3);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region MaxBlackOrWhite3

		public void requestChangeMaxBlackOrWhite3(uint userId, int newMaxBlackOrWhite3)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdNineMenMorrisAIChangeMaxBlackOrWhite3 (this.netId, userId, newMaxBlackOrWhite3);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMaxBlackOrWhite3(uint userId, int newMaxBlackOrWhite3){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMaxBlackOrWhite3 (userId, newMaxBlackOrWhite3);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}


		#endregion

		#region pickBestMove

		public void requestChangePickBestMove(uint userId, int newPickBestMove)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdNineMenMorrisAIChangePickBestMove (this.netId, userId, newPickBestMove);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePickBestMove(uint userId, int newPickBestMove){
			if (this.netData.serverData != null) {
				this.netData.serverData.changePickBestMove (userId, newPickBestMove);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}