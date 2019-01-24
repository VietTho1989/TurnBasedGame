using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Janggi.Ai;

namespace Janggi
{
	public class JanggiAI : Computer.AI
	{

		#region maxVisitCount

		public VP<int> maxVisitCount;

		public void requestChangeMaxVisitCount(uint userId, int newMaxVisitCount){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxVisitCount (userId, newMaxVisitCount);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is JanggiAIIdentity) {
							JanggiAIIdentity janggiAIIdentity = dataIdentity as JanggiAIIdentity;
							janggiAIIdentity.requestChangeMaxVisitCount (userId, newMaxVisitCount);
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

		public void changeMaxVisitCount(uint userId, int newMaxVisitCount){
			if (isCanRequest (userId)) {
				this.maxVisitCount.v = newMaxVisitCount;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			maxVisitCount
		}

		public JanggiAI() : base()
		{
			this.maxVisitCount = new VP<int> (this, (byte)Property.maxVisitCount, Mcts.DefaultMaxVisitCount); 
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.Janggi;
		}

	}
}