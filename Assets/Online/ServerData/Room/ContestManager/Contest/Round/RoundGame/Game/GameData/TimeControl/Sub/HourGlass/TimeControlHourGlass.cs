using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace TimeControl.HourGlass
{
	public class TimeControlHourGlass : TimeControl.Sub
	{

		#region initTime

		public VP<float> initTime;

		public void requestChangeInitTime(uint userId, float newInitTime){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeInitTime (userId, newInitTime);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is TimeControlHourGlassIdentity) {
							TimeControlHourGlassIdentity timeControlHourGlassIdentity = dataIdentity as TimeControlHourGlassIdentity;
							timeControlHourGlassIdentity.requestChangeInitTime (userId, newInitTime);
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

		public void changeInitTime(uint userId, float newInitTime){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.initTime.v = newInitTime;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region lagCompensation

		public VP<float> lagCompensation;

		public void requestChangeLagCompensation(uint userId, float newLagCompensation){
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeLagCompensation (userId, newLagCompensation);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is TimeControlHourGlassIdentity) {
							TimeControlHourGlassIdentity timeControlHourGlassIdentity = dataIdentity as TimeControlHourGlassIdentity;
							timeControlHourGlassIdentity.requestChangeLagCompensation (userId, newLagCompensation);
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

		public void changeLagCompensation(uint userId, float newLagCompensation){
			if (GameManager.Match.ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.lagCompensation.v = newLagCompensation;
			} else {
				Debug.LogError ("cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region playerTimes

		public LP<PlayerTime> playerTimes;

		public PlayerTime getPlayerTime(int playerIndex)
		{
			return this.playerTimes.vs.Find (playerTime => playerTime.playerIndex.v == playerIndex);
		}

		#endregion

		#region Constructor

		public enum Property
		{
			initTime,
			lagCompensation,
			playerTimes
		}

		public TimeControlHourGlass() : base()
		{
			{
				this.initTime = new VP<float> (this, (byte)Property.initTime, PlayerTime.DefaultTime);
				this.initTime.nh = 0;
			}
			{
				this.lagCompensation = new VP<float> (this, (byte)Property.lagCompensation, PlayerTime.DefaultLagCompensation);
				this.lagCompensation.nh = 0;
			}
			this.playerTimes = new LP<PlayerTime> (this, (byte)Property.playerTimes);
		}

		#endregion

		public override Type getType ()
		{
			return Type.HourGlass;
		}

	}
}