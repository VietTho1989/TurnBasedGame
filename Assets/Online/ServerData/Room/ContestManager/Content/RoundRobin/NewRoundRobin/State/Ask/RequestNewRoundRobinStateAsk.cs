using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RequestNewRoundRobinStateAsk : RequestNewRoundRobin.State
	{

		public LP<Human> whoCanAsks;

		#region accepts

		public LP<uint> accepts;

		#region accept

		public void requestAccept(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.accept (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RequestNewRoundRobinStateAskIdentity) {
							RequestNewRoundRobinStateAskIdentity requestNewRoundRobinStateAskIdentity = dataIdentity as RequestNewRoundRobinStateAskIdentity;
							requestNewRoundRobinStateAskIdentity.requestAccept (userId);
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

		public bool isCanAccept(uint userId)
		{
			if (!this.accepts.vs.Contains (userId)) {
				// Find
				bool canAccept = false;
				{
					foreach (Human human in whoCanAsks.vs) {
						if (human.playerId.v == userId) {
							canAccept = true;
							break;
						}
					}
				}
				// Process
				if (canAccept) {
					return true;
				} else {
					return false;
				}
			} else {
				Debug.LogError ("already accept: " + this);
				return false;
			}
		}

		public void accept(uint userId)
		{
			if (isCanAccept (userId)) {
				this.accepts.add (userId);
			} else {
				Debug.LogError ("Cannot accept: " + userId);
			}
		}

		#endregion

		#region cancel

		public void requestCancel(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.cancel (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RequestNewRoundRobinStateAskIdentity) {
							RequestNewRoundRobinStateAskIdentity requestNewRoundRobinStateAskIdentity = dataIdentity as RequestNewRoundRobinStateAskIdentity;
							requestNewRoundRobinStateAskIdentity.requestCancel (userId);
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

		public bool isCanCancel(uint userId)
		{
			if (this.accepts.vs.Contains (userId)) {
				// Find
				bool canCancel = false;
				{
					foreach (Human human in whoCanAsks.vs) {
						if (human.playerId.v == userId) {
							canCancel = true;
							break;
						}
					}
				}
				// Process
				if (canCancel) {
					return true;
				} else {
					return false;
				}
			} else {
				Debug.LogError ("not already accept: " + this);
				return false;
			}
		}

		public void cancel(uint userId)
		{
			if (isCanCancel (userId)) {
				this.accepts.remove (userId);
			} else {
				Debug.LogError ("Cannot accept: " + userId);
			}
		}

		#endregion

		#endregion

		#region Constructor

		public enum Property
		{
			whoCanAsks,
			accepts
		}

		public RequestNewRoundRobinStateAsk() : base()
		{
			this.whoCanAsks = new LP<Human> (this, (byte)Property.whoCanAsks);
			this.accepts = new LP<uint> (this, (byte)Property.accepts);
		}

		#endregion

		public override Type getType ()
		{
			return Type.Ask;
		}

	}
}