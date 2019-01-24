using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.RoundRobin
{
	public class RoundRobinFactory : ContestManagerContentFactory
	{

		public VP<SingleContestFactory> singleContestFactory;

		#region teamCount

		public VP<int> teamCount;

		public void requestChangeTeamCount(uint userId, int newTeamCount)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeTeamCount (userId, newTeamCount);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RoundRobinFactoryIdentity) {
							RoundRobinFactoryIdentity roundRobinFactoryIdentity = dataIdentity as RoundRobinFactoryIdentity;
							roundRobinFactoryIdentity.requestChangeTeamCount (userId, newTeamCount);
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

		public void changeTeamCount(uint userId, int newTeamCount)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.teamCount.v = newTeamCount;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region

		public VP<bool> needReturnRound;

		public void requestChangeNeedReturnRound(uint userId, bool newNeedReturnRound)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeNeedReturnRound (userId, newNeedReturnRound);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is RoundRobinFactoryIdentity) {
							RoundRobinFactoryIdentity roundRobinFactoryIdentity = dataIdentity as RoundRobinFactoryIdentity;
							roundRobinFactoryIdentity.requestChangeNeedReturnRound (userId, newNeedReturnRound);
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

		public void changeNeedReturnRound(uint userId, bool newNeedReturnRound)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.needReturnRound.v = newNeedReturnRound;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			singleContestFactory,
			teamCount,
			needReturnRound
		}

		public RoundRobinFactory() : base()
		{
			this.singleContestFactory = new VP<SingleContestFactory> (this, (byte)Property.singleContestFactory, new SingleContestFactory ());
			this.teamCount = new VP<int> (this, (byte)Property.teamCount, 4);
			this.needReturnRound = new VP<bool> (this, (byte)Property.needReturnRound, false);
		}

		#endregion

		public override ContestManagerContent.Type getType ()
		{
			return ContestManagerContent.Type.RoundRobin;
		}

		public override ContestManagerContent makeContent ()
		{
			RoundRobinContent roundRobinContent = new RoundRobinContent ();
			{
				// singleContestFactory
				{
					SingleContestFactory singleContestFactory = DataUtils.cloneData (this.singleContestFactory.v) as SingleContestFactory;
					{
						singleContestFactory.uid = roundRobinContent.singleContestFactory.makeId ();
					}
					roundRobinContent.singleContestFactory.v = singleContestFactory;
				}
				// roundRobins: khong can
				roundRobinContent.needReturnRound.v = this.needReturnRound.v;
			}
			return roundRobinContent;
		}

	}
}