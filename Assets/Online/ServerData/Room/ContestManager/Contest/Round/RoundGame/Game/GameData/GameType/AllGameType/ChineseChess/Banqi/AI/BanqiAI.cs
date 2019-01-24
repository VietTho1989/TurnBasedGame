using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiAI : Computer.AI
	{

		#region maxVisitCount

		public VP<int> depth;

		public void requestChangeDepth(uint userId, int newDepth){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeDepth (userId, newDepth);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is BanqiAIIdentity) {
							BanqiAIIdentity banqiAIIdentity = dataIdentity as BanqiAIIdentity;
							banqiAIIdentity.requestChangeDepth (userId, newDepth);
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

		public void changeDepth(uint userId, int newDepth){
			if (isCanRequest (userId)) {
				this.depth.v = newDepth;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			depth
		}

		public BanqiAI() : base()
		{
			this.depth = new VP<int> (this, (byte)Property.depth, 5);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Banqi;
		}

	}
}