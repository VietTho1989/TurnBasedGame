using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtAI : Computer.AI
	{

		#region timeLimit

		public VP<int> timeLimit;

		public void requestChangeTimeLimit(uint userId, int newTimeLimit){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeTimeLimit (userId, newTimeLimit);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RussianDraughtAIIdentity) {
							RussianDraughtAIIdentity russianDraughtAIIdentity = dataIdentity as RussianDraughtAIIdentity;
							russianDraughtAIIdentity.requestChangeTimeLimit (userId, newTimeLimit);
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

		public void changeTimeLimit(uint userId, int newTimeLmit){
			if (isCanRequest (userId)) {
				this.timeLimit.v = newTimeLmit;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region pickBestMove

		public VP<int> pickBestMove;

		public void requestChangePickBestMove(uint userId, int newPickBestMove){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changePickBestMove (userId, newPickBestMove);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RussianDraughtAIIdentity) {
							RussianDraughtAIIdentity russianDraughtAIIdentity = dataIdentity as RussianDraughtAIIdentity;
							russianDraughtAIIdentity.requestChangePickBestMove (userId, newPickBestMove);
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

		public void changePickBestMove(uint userId, int newPickBestMove){
			if (isCanRequest (userId)) {
				this.pickBestMove.v = newPickBestMove;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			timeLimit,
			pickBestMove
		}

		public RussianDraughtAI() : base()
		{
			this.timeLimit = new VP<int> (this, (byte)Property.timeLimit, 3000);
			this.pickBestMove = new VP<int> (this, (byte)Property.pickBestMove, 90);
		}

		#endregion

		public override GameType.Type getType ()
		{
			return GameType.Type.RussianDraught;
		}

	}
}