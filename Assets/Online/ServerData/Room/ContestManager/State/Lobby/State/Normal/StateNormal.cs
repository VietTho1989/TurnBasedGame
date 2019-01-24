using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Lobby
{
	public class StateNormal : ContestManagerStateLobby.State
	{

		#region Constructor

		public enum Property
		{

		}

		public StateNormal() : base()
		{

		}

		#endregion

		public override Type getType ()
		{
			return Type.Normal;
		}

		#region Start

		public void requestStart(uint userId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.start (userId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is StateNormalIdentity) {
							StateNormalIdentity stateNormalIdentity = dataIdentity as StateNormalIdentity;
							stateNormalIdentity.requestStart(userId);
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

		public void start(uint userId)
		{
			if (ContestManagerStateLobby.IsCanStart (this, userId)) {
				ContestManagerStateLobby contestManagerStateLobby = this.findDataInParent<ContestManagerStateLobby> ();
				if (contestManagerStateLobby != null) {
					Lobby.StateStart stateStart = new StateStart ();
					{
						stateStart.uid = contestManagerStateLobby.state.makeId ();
					}
					contestManagerStateLobby.state.v = stateStart;
				} else {
					Debug.LogError ("contestManagerStateLobby null: " + this);
				}
			} else {
				Debug.LogError ("cannot start: " + userId + "; " + this);
			}
		}

		#endregion

	}
}