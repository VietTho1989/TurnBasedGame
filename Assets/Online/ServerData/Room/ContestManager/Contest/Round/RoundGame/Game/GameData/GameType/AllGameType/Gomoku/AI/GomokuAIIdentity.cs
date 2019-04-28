using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
	public class GomokuAIIdentity : DataIdentity
	{

		#region SyncVar

		#region searchDepth

		[SyncVar(hook="onChangeSearchDepth")]
		public System.Int32 searchDepth;

		public void onChangeSearchDepth(System.Int32 newSearchDepth)
		{
			this.searchDepth = newSearchDepth;
			if (this.netData.clientData != null) {
				this.netData.clientData.searchDepth.v = newSearchDepth;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region timeLimit

		[SyncVar(hook="onChangeTimeLimit")]
		public System.Int32 timeLimit;

		public void onChangeTimeLimit(System.Int32 newTimeLimit)
		{
			this.timeLimit = newTimeLimit;
			if (this.netData.clientData != null) {
				this.netData.clientData.timeLimit.v = newTimeLimit;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region level

		[SyncVar(hook="onChangeLevel")]
		public System.Int32 level;

		public void onChangeLevel(System.Int32 newLevel)
		{
			this.level = newLevel;
			if (this.netData.clientData != null) {
				this.netData.clientData.level.v = newLevel;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<GomokuAI> netData = new NetData<GomokuAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSearchDepth(this.searchDepth);
				this.onChangeTimeLimit(this.timeLimit);
				this.onChangeLevel(this.level);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.searchDepth);
				ret += GetDataSize (this.timeLimit);
				ret += GetDataSize (this.level);
				return ret;
			}
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is GomokuAI) {
				GomokuAI gomokuAI = data as GomokuAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, gomokuAI.makeSearchInforms ());
					this.searchDepth = gomokuAI.searchDepth.v;
					this.timeLimit = gomokuAI.timeLimit.v;
					this.level = gomokuAI.level.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (gomokuAI);
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
			if (data is GomokuAI) {
				// GomokuAI gomokuAI = data as GomokuAI;
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
			if (wrapProperty.p is GomokuAI) {
				switch ((GomokuAI.Property)wrapProperty.n) {
				case GomokuAI.Property.searchDepth:
					this.searchDepth = (System.Int32)wrapProperty.getValue ();
					break;
				case GomokuAI.Property.timeLimit:
					this.timeLimit = (System.Int32)wrapProperty.getValue ();
					break;
				case GomokuAI.Property.level:
					this.level = (System.Int32)wrapProperty.getValue ();
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

		#region Change SearchDepth

		public void requestChangeSearchDepth(uint userId, int newSearchDepth)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdGomokuAIChangeSearchDepth (this.netId, userId, newSearchDepth);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeSearchDepth(uint userId, int newSearchDepth)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeSearchDepth (userId, newSearchDepth);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Change TimeLimit

		public void requestChangeTimeLimit(uint userId, int newTimeLimit)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdGomokuAIChangeTimeLimit (this.netId, userId, newTimeLimit);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeTimeLimit(uint userId, int newTimeLimit)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeTimeLimit (userId, newTimeLimit);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region Change Level

		public void requestChangeLevel(uint userId, int newLevel)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdGomokuAIChangeLevel (this.netId, userId, newLevel);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeLevel(uint userId, int newLevel)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeLevel (userId, newLevel);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}