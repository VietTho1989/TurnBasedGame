using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rights;

namespace GameManager.Match.Swap
{
	public class Swap : Data
	{

		#region

		public LP<SwapRequest> swapRequests;

		public SwapRequest findRequest(int playerIdex, int teamIndex)
		{
			return this.swapRequests.vs.Find (swapRequest => swapRequest.playerIndex.v == playerIdex && swapRequest.teamIndex.v == teamIndex);
		}

		#endregion

		#region Constructor

		public enum Property
		{
			swapRequests
		}

		public Swap() : base()
		{
			this.swapRequests = new LP<SwapRequest> (this, (byte)Property.swapRequests);
		}

		#endregion

		#region makeRequest

		public bool isCanMakeRequest(uint userId, int teamIndex, int playerIndex)
		{
			bool ret = true;
			{
				// right allow
				if (ret) {
					// find
					bool rightAllow = false;
					{
						Room room = this.findDataInParent<Room> ();
						if (room != null) {
							ChangeRights changeRights = room.changeRights.v;
							if (changeRights != null) {
								ChangeGamePlayerRight changeGamePlayerRight = changeRights.changeGamePlayerRight.v;
								if (changeGamePlayerRight != null) {
									if (changeGamePlayerRight.canChange.v) {
										rightAllow = true;
									}
								} else {
									Debug.LogError ("changeGamePlayerRight null: " + this);
								}
							} else {
								Debug.LogError ("changeRights null: " + this);
							}
						} else {
							Debug.LogError ("room null: " + this);
						}
					}
					// process
					if (!rightAllow) {
						ret = false;
					} else {
						Debug.LogError ("right not allow: " + this);
					}
				}
				// player exist?
				if (ret) {
					// find
					bool playerExist = false;
					{
						ContestManagerStatePlay contestManagerStatePlay = this.findDataInParent<ContestManagerStatePlay> ();
						if (contestManagerStatePlay != null) {
							if (teamIndex >= 0 && teamIndex < contestManagerStatePlay.teams.vs.Count) {
								MatchTeam matchTeam = contestManagerStatePlay.teams.vs [teamIndex];
								if (playerIndex >= 0 && playerIndex < matchTeam.players.vs.Count) {
									playerExist = true;
								} else {
									Debug.LogError ("playerIndex error: " + playerIndex + "; " + this);
								}
							} else {
								Debug.LogError ("teamIndex error: "+teamIndex+"; " + this);
							}
						} else {
							Debug.LogError ("contestManagerPlay null: " + this);
						}
					}
					// process
					if (!playerExist) {
						ret = false;
					} else {
						Debug.LogError ("player not exist: " + this);
					}
				}
				// already request
				if (ret) {
					// find
					bool alreadyRequest = false;
					{
						foreach (SwapRequest swapRequest in this.swapRequests.vs) {
							if (swapRequest.teamIndex.v == teamIndex && swapRequest.playerIndex.v == playerIndex) {
								alreadyRequest = true;
								break;
							}
						}
					}
					// process
					if (alreadyRequest) {
						ret = false;
					}
				}
				// isAdmin?
				if (ret) {
					// find
					bool isAdmin = false;
					{
						RoomUser admin = Room.findAdmin (this);
						if (admin != null) {
							Human human = admin.inform.v;
							if (human != null) {
								if (human.playerId.v == userId) {
									isAdmin = true;
								}
							} else {
								Debug.LogError ("human null: " + this);
							}
						} else {
							Debug.LogError ("admin null: " + this);
						}
					}
					// process
					if (!isAdmin) {
						ret = false;
					}
				}
			}
			return ret;
		}

		#region change Human

		public void requestChangeHuman(uint userId, int teamIndex, int playerIndex, uint newHumanId)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeHuman(userId, teamIndex, playerIndex, newHumanId);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SwapIdentity) {
							SwapIdentity swapIdentity = dataIdentity as SwapIdentity;
							swapIdentity.requestChangeHuman (userId, teamIndex, playerIndex, newHumanId);
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

		public void changeHuman(uint userId, int teamIndex, int playerIndex, uint newHumanId)
		{
			if (isCanMakeRequest (userId, teamIndex, playerIndex)) {
				// check correct inform
				bool correctInform = true;
				{
					ContestManagerStatePlay contestManagerStatePlay = this.findDataInParent<ContestManagerStatePlay> ();
					if (contestManagerStatePlay != null) {
						TeamPlayer teamPlayer = contestManagerStatePlay.findPlayer (teamIndex, playerIndex);
						if (teamPlayer != null) {
							if (teamPlayer.inform.v is Human) {
								Human human = teamPlayer.inform.v as Human;
								if (human.playerId.v == newHumanId) {
									Debug.LogError ("already set: " + newHumanId);
									correctInform = false;
								}
							}
						} else {
							Debug.LogError ("teamPlayer null: " + this);
							correctInform = false;
						}
					} else {
						Debug.LogError ("contestManagerStatePlay null: " + this);
						correctInform = false;
					}
				}
				// Process
				if (correctInform) {
					// make new request
					SwapRequest swapRequest = new SwapRequest();
					{
						swapRequest.uid = this.swapRequests.makeId ();
						// state
						{
							if (swapRequest.state.v is SwapRequestStateAsk) {
								SwapRequestStateAsk swapRequestStateAsk = swapRequest.state.v as SwapRequestStateAsk;
								swapRequestStateAsk.accepts.add (userId);
							} else {
								Debug.LogError ("why not state ask: " + this);
							}
						}
						swapRequest.teamIndex.v = teamIndex;
						swapRequest.playerIndex.v = playerIndex;
						// inform
						{
							Human human = new Human ();
							{
								human.uid = swapRequest.inform.makeId ();
								human.playerId.v = newHumanId;
							}
							swapRequest.inform.v = human;
						}
					}
					this.swapRequests.add (swapRequest);
				}
			} else {
				Debug.LogError ("Cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#region change computer

		public void requestChangeComputer(uint userId, int teamIndex, int playerIndex, Computer newComputer)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeComputer(userId, teamIndex, playerIndex, newComputer);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is SwapIdentity) {
							SwapIdentity swapIdentity = dataIdentity as SwapIdentity;
							swapIdentity.requestChangeComputer (userId, teamIndex, playerIndex, newComputer);
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

		public void changeComputer(uint userId, int teamIndex, int playerIndex, Computer newComputer)
		{
			if (isCanMakeRequest (userId, teamIndex, playerIndex)) {
				// check correct inform
				bool correctInform = true;
				{
					ContestManagerStatePlay contestManagerStatePlay = this.findDataInParent<ContestManagerStatePlay> ();
					if (contestManagerStatePlay != null) {
						TeamPlayer teamPlayer = contestManagerStatePlay.findPlayer (teamIndex, playerIndex);
						if (teamPlayer != null) {
							if (teamPlayer.inform.v is Computer) {
								Computer computer = teamPlayer.inform.v as Computer;
								if (!DataUtils.IsDifferent (newComputer, computer)) {
									Debug.LogError ("newComputer the same as old: " + this);
									correctInform = false;
								}
							}
						} else {
							Debug.LogError ("teamPlayer null: " + this);
							correctInform = false;
						}
					} else {
						Debug.LogError ("contestManagerStatePlay null: " + this);
						correctInform = false;
					}
				}
				// Process
				if (correctInform) {
					// make new request
					SwapRequest swapRequest = new SwapRequest();
					{
						swapRequest.uid = this.swapRequests.makeId ();
						// state
						{
							if (swapRequest.state.v is SwapRequestStateAsk) {
								SwapRequestStateAsk swapRequestStateAsk = swapRequest.state.v as SwapRequestStateAsk;
								swapRequestStateAsk.accepts.add (userId);
							} else {
								Debug.LogError ("why not state ask: " + this);
							}
						}
						swapRequest.teamIndex.v = teamIndex;
						swapRequest.playerIndex.v = playerIndex;
						// inform
						{
							Computer computer = DataUtils.cloneData(newComputer) as Computer;
							{
								computer.uid = swapRequest.inform.makeId ();
							}
							swapRequest.inform.v = computer;
						}
					}
					this.swapRequests.add (swapRequest);
				}
			} else {
				Debug.LogError ("Cannot request: " + userId + "; " + this);
			}
		}

		#endregion

		#endregion

	}
}