using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
	public class ReversiAIIdentity : DataIdentity
	{

		#region SyncVar

		#region sort

		[SyncVar(hook="onChangeSort")]
		public System.Int32 sort;

		public void onChangeSort(System.Int32 newSort)
		{
			this.sort = newSort;
			if (this.netData.clientData != null) {
				this.netData.clientData.sort.v = newSort;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region min

		[SyncVar(hook="onChangeMin")]
		public System.Int32 min;

		public void onChangeMin(System.Int32 newMin)
		{
			this.min = newMin;
			if (this.netData.clientData != null) {
				this.netData.clientData.min.v = newMin;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region max

		[SyncVar(hook="onChangeMax")]
		public System.Int32 max;

		public void onChangeMax(System.Int32 newMax)
		{
			this.max = newMax;
			if (this.netData.clientData != null) {
				this.netData.clientData.max.v = newMax;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region end

		[SyncVar(hook="onChangeEnd")]
		public System.Int32 end;

		public void onChangeEnd(System.Int32 newEnd)
		{
			this.end = newEnd;
			if (this.netData.clientData != null) {
				this.netData.clientData.end.v = newEnd;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#region msLeft

		[SyncVar(hook="onChangeMsLeft")]
		public System.Int32 msLeft;

		public void onChangeMsLeft(System.Int32 newMsLeft)
		{
			this.msLeft = newMsLeft;
			if (this.netData.clientData != null) {
				this.netData.clientData.msLeft.v = newMsLeft;
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

		#region percent

		[SyncVar(hook="onChangePercent")]
		public System.Int32 percent;

		public void onChangePercent(System.Int32 newPercent)
		{
			this.percent = newPercent;
			if (this.netData.clientData != null) {
				this.netData.clientData.percent.v = newPercent;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<ReversiAI> netData = new NetData<ReversiAI>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangeSort(this.sort);
				this.onChangeMin(this.min);
				this.onChangeMax(this.max);
				this.onChangeEnd(this.end);
				this.onChangeMsLeft(this.msLeft);
				this.onChangeUseBook(this.useBook);
				this.onChangePercent(this.percent);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.sort);
				ret += GetDataSize (this.min);
				ret += GetDataSize (this.max);
				ret += GetDataSize (this.end);
				ret += GetDataSize (this.msLeft);
				ret += GetDataSize (this.useBook);
				ret += GetDataSize (this.percent);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is ReversiAI) {
				ReversiAI reversiAI = data as ReversiAI;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, reversiAI.makeSearchInforms ());
					this.sort = reversiAI.sort.v;
					this.min = reversiAI.min.v;
					this.max = reversiAI.max.v;
					this.end = reversiAI.end.v;
					this.msLeft = reversiAI.msLeft.v;
					this.useBook = reversiAI.useBook.v;
					this.percent = reversiAI.percent.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (reversiAI);
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
			if (data is ReversiAI) {
				// ReversiAI reversiAI = data as ReversiAI;
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
			if (wrapProperty.p is ReversiAI) {
				switch ((ReversiAI.Property)wrapProperty.n) {
				case ReversiAI.Property.sort:
					this.sort = (System.Int32)wrapProperty.getValue ();
					break;
				case ReversiAI.Property.min:
					this.min = (System.Int32)wrapProperty.getValue ();
					break;
				case ReversiAI.Property.max:
					this.max = (System.Int32)wrapProperty.getValue ();
					break;
				case ReversiAI.Property.end:
					this.end = (System.Int32)wrapProperty.getValue ();
					break;
				case ReversiAI.Property.msLeft:
					this.msLeft = (System.Int32)wrapProperty.getValue ();
					break;
				case ReversiAI.Property.useBook:
					this.useBook = (System.Boolean)wrapProperty.getValue ();
					break;
				case ReversiAI.Property.percent:
					this.percent = (System.Int32)wrapProperty.getValue ();
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

		#region change sort

		public void requestChangeSort(uint userId, int newSort)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdReversiAIChangeSort (this.netId, userId, newSort);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeSort(uint userId, int newSort)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeSort (userId, newSort);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change min

		public void requestChangeMin(uint userId, int newMin)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdReversiAIChangeMin (this.netId, userId, newMin);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMin(uint userId, int newMin)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMin (userId, newMin);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change max

		public void requestChangeMax(uint userId, int newMax)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdReversiAIChangeMax (this.netId, userId, newMax);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMax(uint userId, int newMax)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMax (userId, newMax);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change end

		public void requestChangeEnd(uint userId, int newEnd)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdReversiAIChangeEnd (this.netId, userId, newEnd);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeEnd(uint userId, int newEnd)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changeEnd (userId, newEnd);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region change msLeft

		public void requestChangeMsLeft(uint userId, int newMsLeft)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdReversiAIChangeMsLeft (this.netId, userId, newMsLeft);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeMsLeft(uint userId, int newMsLeft){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeMsLeft (userId, newMsLeft);
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
				clientConnect.CmdReversiAIChangeUseBook (this.netId, userId, newUseBook);
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

		#region change percent

		public void requestChangePercent(uint userId, int newPercent)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdReversiAIChangePercent (this.netId, userId, newPercent);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePercent(uint userId, int newPercent)
		{
			if (this.netData.serverData != null) {
				this.netData.serverData.changePercent (userId, newPercent);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}