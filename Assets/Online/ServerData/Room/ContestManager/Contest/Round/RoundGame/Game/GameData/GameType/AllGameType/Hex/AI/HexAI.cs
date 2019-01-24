using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class HexAI : Computer.AI
	{

		#region limitTime

		public VP<int> limitTime;

		public void requestChangeLimitTime(uint userId, int newLimitTime){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeLimitTime (userId, newLimitTime);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is HexAIIdentity) {
							HexAIIdentity hexAIIdentity = dataIdentity as HexAIIdentity;
							hexAIIdentity.requestChangeLimitTime (userId, newLimitTime);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeLimitTime(uint userId, int newLimitTime){
			if (isCanRequest (userId)) {
				this.limitTime.v = newLimitTime;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region firstMoveCenter

		public VP<bool> firstMoveCenter;

		public void requestChangeFirstMoveCenter(uint userId, bool newFirstMoveCenter){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeFirstMoveCenter (userId, newFirstMoveCenter);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is HexAIIdentity) {
							HexAIIdentity hexAIIdentity = dataIdentity as HexAIIdentity;
							hexAIIdentity.requestChangeFirstMoveCenter (userId, newFirstMoveCenter);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request: " + this);
			}
		}

		public void changeFirstMoveCenter(uint userId, bool newFirstMoveCenter){
			if (isCanRequest (userId)) {
				this.firstMoveCenter.v = newFirstMoveCenter;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			limitTime,
			firstMoveCenter
		}

		public HexAI() : base()
		{
			this.limitTime = new VP<int> (this, (byte)Property.limitTime, 5);
			this.firstMoveCenter = new VP<bool> (this, (byte)Property.firstMoveCenter, false);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Hex;
		}

	}
}