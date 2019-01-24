using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class InternationalDraughtAIIdentity : DataIdentity
	{

		#region SyncVar

		#region bMove

		[SyncVar(hook="onChangeBMove")]
		public System.Boolean bMove;

		public void onChangeBMove(System.Boolean newBMove)
		{
			this.bMove = newBMove;
			if (this.netData.clientData != null) {
				this.netData.clientData.bMove.v = newBMove;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region book

		[SyncVar(hook="onChangeBook")]
		public System.Boolean book;

		public void onChangeBook(System.Boolean newBook)
		{
			this.book = newBook;
			if (this.netData.clientData != null) {
				this.netData.clientData.book.v = newBook;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region depth

		[SyncVar(hook="onChangeDepth")]
		public System.Int32 depth;

		public void onChangeDepth(System.Int32 newDepth)
		{
			this.depth = newDepth;
			if (this.netData.clientData != null) {
				this.netData.clientData.depth.v = newDepth;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region time

		[SyncVar(hook="onChangeTime")]
		public System.Single time;

		public void onChangeTime(System.Single newTime)
		{
			this.time = newTime;
			if (this.netData.clientData != null) {
				this.netData.clientData.time.v = newTime;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region input

		[SyncVar(hook="onChangeInput")]
		public System.Boolean input;

		public void onChangeInput(System.Boolean newInput)
		{
			this.input = newInput;
			if (this.netData.clientData != null) {
				this.netData.clientData.input.v = newInput;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region useEndGameDatabase

		[SyncVar(hook="onChangeUseEndGameDatabase")]
		public System.Boolean useEndGameDatabase;

		public void onChangeUseEndGameDatabase(System.Boolean newUseEndGameDatabase)
		{
			this.useEndGameDatabase = newUseEndGameDatabase;
			if (this.netData.clientData != null) {
				this.netData.clientData.useEndGameDatabase.v = newUseEndGameDatabase;
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

		private NetData<InternationalDraughtAI> netData = new NetData<InternationalDraughtAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeBMove(this.bMove);
				this.onChangeBook(this.book);
				this.onChangeDepth(this.depth);
				this.onChangeTime(this.time);
				this.onChangeInput(this.input);
				this.onChangeUseEndGameDatabase(this.useEndGameDatabase);
				this.onChangePickBestMove(this.pickBestMove);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.bMove);
				ret += GetDataSize (this.book);
				ret += GetDataSize (this.depth);
				ret += GetDataSize (this.time);
				ret += GetDataSize (this.input);
				ret += GetDataSize (this.useEndGameDatabase);
				ret += GetDataSize (this.pickBestMove);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is InternationalDraughtAI) {
				InternationalDraughtAI internationalDraughtAI = data as InternationalDraughtAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, internationalDraughtAI.makeSearchInforms ());
					this.bMove = internationalDraughtAI.bMove.v;
					this.book = internationalDraughtAI.book.v;
					this.depth = internationalDraughtAI.depth.v;
					this.time = internationalDraughtAI.time.v;
					this.input = internationalDraughtAI.input.v;
					this.useEndGameDatabase = internationalDraughtAI.useEndGameDatabase.v;
					this.pickBestMove = internationalDraughtAI.pickBestMove.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (internationalDraughtAI);
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
			if (data is InternationalDraughtAI) {
				// InternationalDraughtAI internationalDraughtAI = data as InternationalDraughtAI;
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
			if (wrapProperty.p is InternationalDraughtAI) {
				switch ((InternationalDraughtAI.Property)wrapProperty.n) {
				case InternationalDraughtAI.Property.bMove:
					this.bMove = (System.Boolean)wrapProperty.getValue ();
					break;
				case InternationalDraughtAI.Property.book:
					this.book = (System.Boolean)wrapProperty.getValue ();
					break;
				case InternationalDraughtAI.Property.depth:
					this.depth = (System.Int32)wrapProperty.getValue ();
					break;
				case InternationalDraughtAI.Property.time:
					this.time = (System.Single)wrapProperty.getValue ();
					break;
				case InternationalDraughtAI.Property.input:
					this.input = (System.Boolean)wrapProperty.getValue ();
					break;
				case InternationalDraughtAI.Property.useEndGameDatabase:
					this.useEndGameDatabase = (System.Boolean)wrapProperty.getValue ();
					break;
				case InternationalDraughtAI.Property.pickBestMove:
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

		#region change bMove

		public void requestChangeBMove(uint userId, bool newBMove)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdInternationalDraughtAIChangeBMove (this.netId, userId, newBMove);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeBMove(uint userId, bool newBMove)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeBMove (userId, newBMove);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change book

		public void requestChangeBook(uint userId, bool newBook)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdInternationalDraughtAIChangeBook (this.netId, userId, newBook);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeBook(uint userId, bool newBook)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeBook (userId, newBook);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change depth

		public void requestChangeDepth(uint userId, int newDepth)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdInternationalDraughtAIChangeDepth (this.netId, userId, newDepth);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeDepth(uint userId, int newDepth)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeDepth (userId, newDepth);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change time

		public void requestChangeTime(uint userId, float newTime)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdInternationalDraughtAIChangeTime (this.netId, userId, newTime);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeTime(uint userId, float newTime)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeTime (userId, newTime);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change input

		public void requestChangeInput(uint userId, bool newInput)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdInternationalDraughtAIChangeInput (this.netId, userId, newInput);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeInput(uint userId, bool newInput)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeInput (userId, newInput);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change useEndGameDatabase

		public void requestChangeUseEndGameDatabase(uint userId, bool newUseEndGameDatabase)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdInternationalDraughtAIChangeUseEndGameDatabase (this.netId, userId, newUseEndGameDatabase);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeUseEndGameDatabase(uint userId, bool newUseEndGameDatabase)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeUseEndGameDatabase (userId, newUseEndGameDatabase);
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
				clientConnect.CmdInternationalDraughtAIChangePickBestMove (this.netId, userId, newPickBestMove);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePickBestMove(uint userId, int newPickBestMove)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changePickBestMove (userId, newPickBestMove);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}