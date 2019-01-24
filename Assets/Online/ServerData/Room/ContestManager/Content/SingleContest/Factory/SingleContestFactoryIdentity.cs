using UnityEngine;
using Mirror;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class SingleContestFactoryIdentity : DataIdentity
	{

		#region SyncVar

		#region playerPerTeam

		[SyncVar(hook="onChangePlayerPerTeam")]
		public System.Int32 playerPerTeam;

		public void onChangePlayerPerTeam(System.Int32 newPlayerPerTeam)
		{
			this.playerPerTeam = newPlayerPerTeam;
			if (this.netData.clientData != null) {
				this.netData.clientData.playerPerTeam.v = newPlayerPerTeam;
			} else {
				// Debug.LogError ("clientData null: "+this);
			}
		}

		#endregion

		#endregion

		#region NetData

		private NetData<SingleContestFactory> netData = new NetData<SingleContestFactory>();

		public override NetDataDelegate getNetData ()
		{
			return this.netData;
		}

		public override void refreshClientData ()
		{
			if (this.netData.clientData != null) {
				this.onChangePlayerPerTeam(this.playerPerTeam);
			} else {
				Debug.Log ("clientData null");
			}
		}

		public override int refreshDataSize ()
		{
			int ret = GetDataSize (this.netId);
			{
				ret += GetDataSize (this.playerPerTeam);
			}
			return ret;
		}

		#endregion

		#region implemt callback

		public override void onAddCallBack<T> (T data)
		{
			if (data is SingleContestFactory) {
				SingleContestFactory singleContestFactory = data as SingleContestFactory;
				// Set new parent
				this.addTransformToParent();
				// Set property
				{
					this.serialize (this.searchInfor, singleContestFactory.makeSearchInforms ());
					this.playerPerTeam = singleContestFactory.playerPerTeam.v;
				}
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
						observer.setCheckChangeData (singleContestFactory);
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
			if (data is SingleContestFactory) {
				// SingleContestFactory singleContestFactory = data as SingleContestFactory;
				// Observer
				{
					GameObserver observer = GetComponent<GameObserver> ();
					if (observer != null) {
						observer.checkChange = new FollowParentObserver (observer);
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
			if (wrapProperty.p is SingleContestFactory) {
				switch ((SingleContestFactory.Property)wrapProperty.n) {
				case SingleContestFactory.Property.playerPerTeam:
					this.playerPerTeam = (System.Int32)wrapProperty.getValue ();
					break;
				case SingleContestFactory.Property.roundFactory:
					break;
				case SingleContestFactory.Property.newRoundLimit:
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

		#region playerPerTeam

		public void requestChangePlayerPerTeam(uint userId, int newPlayerPerTeam)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSingleContestFactoryChangePlayerPerTeam (this.netId, userId, newPlayerPerTeam);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changePlayerPerTeam(uint userId, int newPlayerPerTeam){
			if (this.netData.serverData != null) {
				this.netData.serverData.changePlayerPerTeam (userId, newPlayerPerTeam);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region roundFactory

		public void requestChangeRoundFactoryType(uint userId, int newRoundFactoryType)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSingleContestFactoryChangeRoundFactoryType (this.netId, userId, newRoundFactoryType);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeRoundFactoryType(uint userId, int newRoundFactoryType){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeRoundFactoryType (userId, newRoundFactoryType);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region newRoundLimit

		public void requestChangeNewRoundLimitType(uint userId, int newRoundLimitType)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSingleContestFactoryChangeNewRoundLimitType (this.netId, userId, newRoundLimitType);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeNewRoundLimitType(uint userId, int newRoundLimitType){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeNewRoundLimitType (userId, newRoundLimitType);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

		#region calculateScore

		public void requestChangeCalculateScoreType(uint userId, int newCalculateScoreType)
		{
			ClientConnectIdentity clientConnect = ClientConnectIdentity.findYourClientConnectIdentity (this.netData.clientData);
			if (clientConnect != null) {
				clientConnect.CmdSingleContestFactoryChangeCalculateScoreType (this.netId, userId, newCalculateScoreType);
			} else {
				Debug.LogError ("Cannot find clientConnect: " + this);
			}
		}

		public void changeCalculateScoreType(uint userId, int newCalculateScoreType){
			if (this.netData.serverData != null) {
				this.netData.serverData.changeCalculateScoreType (userId, newCalculateScoreType);
			} else {
				Debug.LogError ("serverData null: " + this);
			}
		}

		#endregion

	}
}