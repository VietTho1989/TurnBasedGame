using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match.Elimination
{
	public class EliminationFactory : ContestManagerContentFactory
	{

		public VP<SingleContestFactory> singleContestFactory;

		//////////////////////////////////////////////////////////////////////////////////
		/////////////////////////// initTeamCounts ////////////////////////////
		//////////////////////////////////////////////////////////////////////////////////

		#region initTeamCounts

		public LP<uint> initTeamCounts;

		#region change initTeamCount by index

		public void requestChangeInitTeamCountLength(uint userId, int newLength)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeInitTeamCountLength(userId, newLength);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is EliminationFactoryIdentity) {
							EliminationFactoryIdentity eliminationFactoryIdentity = dataIdentity as EliminationFactoryIdentity;
							eliminationFactoryIdentity.requestChangeInitTeamCountLength(userId, newLength);
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

		public void changeInitTeamCountLength(uint userId, int newLength)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				// correct input
				newLength = Mathf.Clamp (newLength, 1, EliminationContent.MAX_BRACKET);
				// input
				if (newLength >= 0) {
					// make new list
					List<uint> newInitTeamCounts = new List<uint> ();
					{
						newInitTeamCounts.AddRange (this.initTeamCounts.vs);
						// length
						if (newLength < newInitTeamCounts.Count) {
							newInitTeamCounts.RemoveRange (newLength, newInitTeamCounts.Count - newLength);
						} else {
							for (int i = newInitTeamCounts.Count; i < newLength; i++) {
								newInitTeamCounts.Add (0);
							}
						}
					}
					// Update
					{
						IdentityUtils.refresh (this.initTeamCounts, newInitTeamCounts);
					}
				} else {
					Debug.LogError ("newLength error: " + newLength);
				}
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region change initTeamCount by index

		public void requestChangeInitTeamCount(uint userId, int index, uint newInitTeamCount)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeInitTeamCount(userId, index, newInitTeamCount);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is EliminationFactoryIdentity) {
							EliminationFactoryIdentity eliminationFactoryIdentity = dataIdentity as EliminationFactoryIdentity;
							eliminationFactoryIdentity.requestChangeInitTeamCount(userId, index, newInitTeamCount);
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

		public void changeInitTeamCount(uint userId, int index, uint newInitTeamCount)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				// correct input
				newInitTeamCount = (uint)Mathf.Clamp (newInitTeamCount, index == 0 ? 4 : 0, EliminationContent.MAX_TEAM_PER_BRACKET);
				if (index >= 0 && index < this.initTeamCounts.vs.Count) {
					this.initTeamCounts.set (index, newInitTeamCount);
				}
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#endregion

		#region Constructor

		public enum Property
		{
			singleContestFactory,
			initTeamCounts
		} 

		public EliminationFactory() : base()
		{
			this.singleContestFactory = new VP<SingleContestFactory> (this, (byte)Property.singleContestFactory, new SingleContestFactory ());
			this.initTeamCounts = new LP<uint> (this, (byte)Property.initTeamCounts);
		}

		#endregion

		#region implement base

		public override ContestManagerContent.Type getType ()
		{
			return ContestManagerContent.Type.Elimination;
		}

		public override ContestManagerContent makeContent ()
		{
			EliminationContent eliminationContent = new EliminationContent ();
			{
				// singleContestFactory
				{
					SingleContestFactory singleContestFactory = DataUtils.cloneData (this.singleContestFactory.v) as SingleContestFactory;
					{
						singleContestFactory.uid = eliminationContent.singleContestFactory.makeId ();
					}
					eliminationContent.singleContestFactory.v = singleContestFactory;
				}
				// initTeamCounts
				eliminationContent.initTeamCounts.vs.AddRange(this.initTeamCounts.vs);
			}
			return eliminationContent;
		}

		#endregion

	}
}