using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class RequestNewRoundHaveLimit : RequestNewRound.Limit
	{

		#region maxRound

		public VP<int> maxRound;

		public void requestChangeMaxRound(uint userId, int newMaxRound) {
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeMaxRound (userId, newMaxRound);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RequestNewRoundHaveLimitIdentity) {
							RequestNewRoundHaveLimitIdentity requestNewRoundHaveLimitIdentity = dataIdentity as RequestNewRoundHaveLimitIdentity;
							requestNewRoundHaveLimitIdentity.requestChangeMaxRound (userId, newMaxRound);
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

		public void changeMaxRound(uint userId, int newMaxRound){
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.maxRound.v = newMaxRound;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region enoughScoreStop

		public VP<bool> enoughScoreStop;

		public void requestChangeEnoughScoreStop(uint userId, bool newEnoughScoreStop){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeEnoughScoreStop (userId, newEnoughScoreStop);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RequestNewRoundHaveLimitIdentity) {
							RequestNewRoundHaveLimitIdentity requestNewRoundHaveLimitIdentity = dataIdentity as RequestNewRoundHaveLimitIdentity;
							requestNewRoundHaveLimitIdentity.requestChangeEnoughScoreStop(userId, newEnoughScoreStop);
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

		public void changeEnoughScoreStop(uint userId, bool newEnoughScoreStop){
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.enoughScoreStop.v = newEnoughScoreStop;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			maxRound,
			enoughScoreStop
		}

		public RequestNewRoundHaveLimit() : base()
		{
			this.maxRound = new VP<int> (this, (byte)Property.maxRound, 3);
			this.enoughScoreStop = new VP<bool> (this, (byte)Property.enoughScoreStop, true);
		}

		#endregion

		public override Type getType ()
		{
			return Type.HaveLimit;
		}

		public override bool isCanMakeMoreRound ()
		{
			int currentRoundCount = 0;
			{
				Contest contest = this.findDataInParent<Contest> ();
				if (contest != null) {
					currentRoundCount = contest.rounds.vs.Count;
				} else {
					Debug.LogError ("contest null: " + this);
				}
			}
			if (currentRoundCount < this.maxRound.v) {
				return true;
			} else {
				// TODO Can phai check enoughScoreStop nua
				{
					// TODO Can phai check cac score
				}
				return false;
			}
		}

	}
}