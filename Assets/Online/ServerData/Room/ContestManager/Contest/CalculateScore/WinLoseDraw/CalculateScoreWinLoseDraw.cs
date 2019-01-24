using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class CalculateScoreWinLoseDraw : CalculateScore
	{

		#region winScore

		public VP<float> winScore;

		public void requestChangeWinScore(uint userId, float newWinScore) {
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeWinScore (userId, newWinScore);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is CalculateScoreWinLoseDrawIdentity) {
							CalculateScoreWinLoseDrawIdentity calculateScoreWinLoseDrawIdentity = dataIdentity as CalculateScoreWinLoseDrawIdentity;
							calculateScoreWinLoseDrawIdentity.requestChangeWinScore (userId, newWinScore);
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

		public void changeWinScore(uint userId, float newWinScore){
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.winScore.v = newWinScore;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region loseScore

		public VP<float> loseScore;

		public void requestChangeLoseScore(uint userId, float newLoseScore) {
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeLoseScore (userId, newLoseScore);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is CalculateScoreWinLoseDrawIdentity) {
							CalculateScoreWinLoseDrawIdentity calculateScoreWinLoseDrawIdentity = dataIdentity as CalculateScoreWinLoseDrawIdentity;
							calculateScoreWinLoseDrawIdentity.requestChangeLoseScore (userId, newLoseScore);
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

		public void changeLoseScore(uint userId, float newLoseScore){
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.loseScore.v = newLoseScore;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region drawScore

		public VP<float> drawScore;

		public void requestChangeDrawScore(uint userId, float newDrawScore) {
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeDrawScore (userId, newDrawScore);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is CalculateScoreWinLoseDrawIdentity) {
							CalculateScoreWinLoseDrawIdentity calculateScoreWinLoseDrawIdentity = dataIdentity as CalculateScoreWinLoseDrawIdentity;
							calculateScoreWinLoseDrawIdentity.requestChangeDrawScore (userId, newDrawScore);
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

		public void changeDrawScore(uint userId, float newDrawScore){
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.drawScore.v = newDrawScore;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			winScore,
			loseScore,
			drawScore
		}

		public CalculateScoreWinLoseDraw() : base()
		{
			this.winScore = new VP<float> (this, (byte)Property.winScore, 1);
			this.loseScore = new VP<float> (this, (byte)Property.loseScore, 0);
			this.drawScore = new VP<float> (this, (byte)Property.drawScore, 0.5f);
		}

		#endregion

		public override Type getType ()
		{
			return Type.WinLoseDraw;
		}

	}
}