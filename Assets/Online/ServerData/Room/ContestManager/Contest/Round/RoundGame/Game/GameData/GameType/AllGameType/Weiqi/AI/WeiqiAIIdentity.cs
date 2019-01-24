using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class WeiqiAIIdentity : DataIdentity
	{

		#region SyncVar

		#region canResign

		[SyncVar(hook="onChangeCanResign")]
		public System.Boolean canResign;

		public void onChangeCanResign(System.Boolean newCanResign)
		{
			this.canResign = newCanResign;
			if (this.netData.clientData != null) {
				this.netData.clientData.canResign.v = newCanResign;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region useBook

		[SyncVar(hook="onChangeUseBook")]
		public System.Boolean useBook;

		public void onChangeUseBook(System.Boolean newUseBook)
		{
			this.useBook = newUseBook;
			if (this.netData.clientData != null) {
				this.netData.clientData.useBook.v = newUseBook;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region time

		[SyncVar(hook="onChangeTime")]
		public System.Int32 time;

		public void onChangeTime(System.Int32 newTime)
		{
			this.time = newTime;
			if (this.netData.clientData != null) {
				this.netData.clientData.time.v = newTime;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region games

		[SyncVar(hook="onChangeGames")]
		public System.Int32 games;

		public void onChangeGames(System.Int32 newGames)
		{
			this.games = newGames;
			if (this.netData.clientData != null) {
				this.netData.clientData.games.v = newGames;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region engine

		[SyncVar(hook="onChangeEngine")]
		public System.Int32 engine;

		public void onChangeEngine(System.Int32 newEngine)
		{
			this.engine = newEngine;
			if (this.netData.clientData != null) {
				this.netData.clientData.engine.v = newEngine;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<WeiqiAI> netData = new NetData<WeiqiAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeCanResign(this.canResign);
				this.onChangeUseBook(this.useBook);
				this.onChangeTime(this.time);
				this.onChangeGames(this.games);
				this.onChangeEngine(this.engine);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.canResign);
				ret += GetDataSize (this.useBook);
				ret += GetDataSize (this.time);
				ret += GetDataSize (this.games);
				ret += GetDataSize (this.engine);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is WeiqiAI) {
				WeiqiAI weiqiAI = data as WeiqiAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, weiqiAI.makeSearchInforms ());
					this.canResign = weiqiAI.canResign.v;
					this.useBook = weiqiAI.useBook.v;
					this.time = weiqiAI.time.v;
					this.games = weiqiAI.games.v;
					this.engine = weiqiAI.engine.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (weiqiAI);
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
			if (data is WeiqiAI) {
				// WeiqiAI weiqiAI = data as WeiqiAI;
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
			if (wrapProperty.p is WeiqiAI) {
				switch ((WeiqiAI.Property)wrapProperty.n) {
				case WeiqiAI.Property.canResign:
					this.canResign = (System.Boolean)wrapProperty.getValue ();
					break;
				case WeiqiAI.Property.useBook:
					this.useBook = (System.Boolean)wrapProperty.getValue ();
					break;
				case WeiqiAI.Property.time:
					this.time = (System.Int32)wrapProperty.getValue ();
					break;
				case WeiqiAI.Property.games:
					this.games = (System.Int32)wrapProperty.getValue ();
					break;
				case WeiqiAI.Property.engine:
					this.engine = (System.Int32)wrapProperty.getValue ();
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

		#region change canResign

		public void requestChangeCanResign(uint userId, bool newCanResign)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdWeiqiAIChangeCanResign (this.netId, userId, newCanResign);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeCanResign(uint userId, bool newCanResign)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeCanResign (userId, newCanResign);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change useBook

		public void requestChangeUseBook(uint userId, bool newUseBook)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdWeiqiAIChangeUseBook (this.netId, userId, newUseBook);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeUseBook(uint userId, bool newUseBook)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeUseBook (userId, newUseBook);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change time

		public void requestChangeTime(uint userId, int newTime)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdWeiqiAIChangeTime (this.netId, userId, newTime);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeTime(uint userId, int newTime)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeTime (userId, newTime);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change games

		public void requestChangeGames(uint userId, int newGames)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdWeiqiAIChangeGames (this.netId, userId, newGames);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeGames(uint userId, int newGames)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeGames (userId, newGames);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change engine

		public void requestChangeEngine(uint userId, int newEngine)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdWeiqiAIChangeEngine (this.netId, userId, newEngine);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeEngine(uint userId, int newEngine)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeEngine (userId, newEngine);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}