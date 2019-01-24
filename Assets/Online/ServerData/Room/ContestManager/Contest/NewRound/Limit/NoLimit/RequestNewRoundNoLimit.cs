using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundNoLimit : RequestNewRound.Limit
	{

		#region isStopMakeMoreRound

		public VP<bool> isStopMakeMoreRound;

		public bool isCanChangeIsStopMakeMoreRound(uint userId)
		{
			return Room.isUserAdmin (userId, this);
		}

		public void requestChangeIsStopMakeMoreRound(uint userId, bool newIsStopMakeMoreRound)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeIsStopMakeMoreRound (userId, newIsStopMakeMoreRound);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RequestNewRoundNoLimitIdentity) {
							RequestNewRoundNoLimitIdentity requestNewRoundNoLimitIdentity = dataIdentity as RequestNewRoundNoLimitIdentity;
							requestNewRoundNoLimitIdentity.requestChangeIsStopMakeMoreRound(userId, newIsStopMakeMoreRound);
						} else {
							Debug.LogError ("Why isn't correct identity");
						}
					} else {
						Debug.LogError ("cannot find dataIdentity");
					}
				}
			} else {
				Debug.LogError ("You cannot request");
			}
		}

		public void changeIsStopMakeMoreRound(uint userId, bool newIsStopMakeMoreRound)
		{
			if (isCanChangeIsStopMakeMoreRound (userId)) {
				this.isStopMakeMoreRound.v = newIsStopMakeMoreRound;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			isStopMakeMoreRound
		}

		public RequestNewRoundNoLimit() : base()
		{
			this.isStopMakeMoreRound = new VP<bool> (this, (byte)Property.isStopMakeMoreRound, false);
		}

		#endregion

		public override Type getType ()
		{
			return Type.NoLimit;
		}

		public override bool isCanMakeMoreRound ()
		{
			return !this.isStopMakeMoreRound.v;
		}

	}
}