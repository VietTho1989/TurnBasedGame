using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GameManager.Match.RoundRobin;
using GameManager.Match.Elimination;

namespace GameManager.Match
{
	public class ContestManagerStateLobby : ContestManager.State
	{

		public const int MAX_TEAM_COUNT = 50;

		#region State

		public abstract class State : Data
		{

			public enum Type
			{
				Normal,
				Start
			}

			public abstract Type getType ();

		}

		public VP<State> state;

		#endregion

		public LP<LobbyTeam> teams;

		public VP<GameType.Type> gameType;

		#region randomTeamIndex

		public VP<bool> randomTeamIndex;

		public void requestChangeRandomTeamIndex(uint userId, bool newRandomTeamIndex)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeRandomTeamIndex (userId, newRandomTeamIndex);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ContestManagerStateLobbyIdentity) {
							ContestManagerStateLobbyIdentity contestManagerStateLobbyIdentity = dataIdentity as ContestManagerStateLobbyIdentity;
							contestManagerStateLobbyIdentity.requestChangeRandomTeamIndex(userId, newRandomTeamIndex);
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

		public void changeRandomTeamIndex(uint userId, bool newRandomTeamIndex)
		{
			if (this.isCanChange (userId)) {
				this.randomTeamIndex.v = newRandomTeamIndex;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region Factory

		public VP<ContestManagerContentFactory> contentFactory;

		public ContestManagerContent.Type getContentFactoryType()
		{
			ContestManagerContent.Type ret = ContestManagerContent.Type.Single;
			{
				if (this.contentFactory.v != null) {
					ret = this.contentFactory.v.getType ();
				} else {
					Debug.LogError ("contentFactory null: " + this);
				}
			}
			return ret;
		}

		public void requestChangeContentFactoryType(uint userId, int newContentFactoryType)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeContentFactoryType (userId, newContentFactoryType);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is ContestManagerStateLobbyIdentity) {
							ContestManagerStateLobbyIdentity contestManagerStateLobbyIdentity = dataIdentity as ContestManagerStateLobbyIdentity;
							contestManagerStateLobbyIdentity.requestChangeContentFactoryType(userId, newContentFactoryType);
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

		public void changeContentFactoryType(uint userId, int newContentFactoryType)
		{
			if (this.isCanChange (userId)) {
				ContestManagerContent.Type contentFactoryType = (ContestManagerContent.Type)newContentFactoryType;
				// check need change
				bool needChange = true;
				{
					if (this.contentFactory.v != null) {
						if (this.contentFactory.v.getType () == contentFactoryType) {
							needChange = false;
						}
					} else {
						Debug.LogError ("contentFactory null: " + this);
					}
				}
				// Make change
				if (needChange) {
					ContestManagerContentFactory contestManagerContentFactory = null;
					// get old singleContestFactory
					SingleContestFactory oldSingleContestFactory = null;
					{
						if (this.contentFactory.v != null) {
							switch (this.contentFactory.v.getType ()) {
							case ContestManagerContent.Type.Single:
								{
									SingleContestFactory singleContestFactory = this.contentFactory.v as SingleContestFactory;
									oldSingleContestFactory = singleContestFactory;
								}
								break;
							case ContestManagerContent.Type.RoundRobin:
								{
									RoundRobinFactory roundRobinFactory = this.contentFactory.v as RoundRobinFactory;
									oldSingleContestFactory = roundRobinFactory.singleContestFactory.v;
								}
								break;
							case ContestManagerContent.Type.Elimination:
								{
									EliminationFactory eliminationFactory = this.contentFactory.v as EliminationFactory;
									oldSingleContestFactory = eliminationFactory.singleContestFactory.v;
								}
								break;
							default:
								Debug.LogError ("unknown type: " + this.contentFactory.v.getType () + "; " + this);
								break;
							}
						} else {
							Debug.LogError ("contentFactory null: " + this);
						}
					}
					// make new
					{
						switch (contentFactoryType) {
						case ContestManagerContent.Type.Single:
							{
								if (oldSingleContestFactory == null) {
									Debug.LogError ("oldSingleContestFactory null: " + this);
									contestManagerContentFactory = new SingleContestFactory ();
								} else {
									contestManagerContentFactory = DataUtils.cloneData (oldSingleContestFactory) as SingleContestFactory;
								}
							}
							break;
						case ContestManagerContent.Type.RoundRobin:
							{
								contestManagerContentFactory = new RoundRobinFactory ();
								// singleContestFactory
								{
									if (oldSingleContestFactory != null) {
										RoundRobinFactory roundRobinFactory = contestManagerContentFactory as RoundRobinFactory;
										// Copy
										SingleContestFactory singleContestFactory = DataUtils.cloneData (oldSingleContestFactory) as SingleContestFactory;
										{
											singleContestFactory.uid = roundRobinFactory.singleContestFactory.makeId ();
											// request new round
											{
												if (singleContestFactory.newRoundLimit.v.getType () == RequestNewRound.Limit.Type.NoLimit) {
													RequestNewRoundHaveLimit requestNewRoundHaveLimit = new RequestNewRoundHaveLimit ();
													{
														requestNewRoundHaveLimit.uid = singleContestFactory.newRoundLimit.makeId ();
														requestNewRoundHaveLimit.maxRound.v = 1;
													}
													singleContestFactory.newRoundLimit.v = requestNewRoundHaveLimit;
												}
											}
										}
										roundRobinFactory.singleContestFactory.v = singleContestFactory;
									} else {
										Debug.LogError ("oldSingleContestFactory null: " + this);
									}
								}
							}
							break;
						case ContestManagerContent.Type.Elimination:
							{
								EliminationFactory eliminationFactory = new EliminationFactory ();
								{
									// singleContestFactory
									{
										if (oldSingleContestFactory != null) {
											// Copy
											SingleContestFactory singleContestFactory = DataUtils.cloneData (oldSingleContestFactory) as SingleContestFactory;
											{
												singleContestFactory.uid = eliminationFactory.singleContestFactory.makeId ();
												// request new round
												{
													if (singleContestFactory.newRoundLimit.v.getType () == RequestNewRound.Limit.Type.NoLimit) {
														RequestNewRoundHaveLimit requestNewRoundHaveLimit = new RequestNewRoundHaveLimit ();
														{
															requestNewRoundHaveLimit.uid = singleContestFactory.newRoundLimit.makeId ();
															requestNewRoundHaveLimit.maxRound.v = 1;
														}
														singleContestFactory.newRoundLimit.v = requestNewRoundHaveLimit;
													}
												}
											}
											eliminationFactory.singleContestFactory.v = singleContestFactory;
										} else {
											Debug.LogError ("oldSingleContestFactory null: " + this);
										}
									}
									// initTeamCount
									eliminationFactory.initTeamCounts.add(4);
								}
								contestManagerContentFactory = eliminationFactory;
							}
							break;
						default:
							Debug.LogError ("unknown contentFactoryType: " + contentFactoryType + "; " + this);
							break;
						}
					}
					if (contestManagerContentFactory != null) {
						contestManagerContentFactory.uid = this.contentFactory.makeId ();
						this.contentFactory.v = contestManagerContentFactory;
					}
				}
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			state,
			teams,
			gameType,
			randomTeamIndex,
			contentFactory
		}

		public ContestManagerStateLobby() : base()
		{
			this.state = new VP<State> (this, (byte)Property.state, new Lobby.StateNormal ());
			this.teams = new LP<LobbyTeam> (this, (byte)Property.teams);
			this.gameType = new VP<GameType.Type> (this, (byte)Property.gameType, GameType.Type.Xiangqi);
			this.randomTeamIndex = new VP<bool> (this, (byte)Property.randomTeamIndex, false);
			this.contentFactory = new VP<ContestManagerContentFactory> (this, (byte)Property.contentFactory, new SingleContestFactory ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Lobby;
		}

		#region canChange

		public static bool IsCanChange(Data data, uint userId)
		{
			if (data != null) {
				ContestManagerStateLobby lobby = data.findDataInParent<ContestManagerStateLobby> ();
				if (lobby != null) {
					return lobby.isCanChange (userId);
				} else {
					Debug.LogError ("lobby null: " + data);
				}
			} else {
				Debug.LogError ("data null");
			}
			return false;
		}

		public bool isCanChange(uint userId)
		{
			bool canChange = true;
			{
				// check is admin
				if (canChange) {
					bool isAdmin = false;
					{
						Room room = this.findDataInParent<Room> ();
						if (room != null) {
							RoomUser admin = room.findAdmin ();
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
						} else {
							Debug.LogError ("room null: " + this);
							isAdmin = true;
						}
					}
					if (!isAdmin) {
						canChange = false;
					}
				}
				// check state correct
				if (canChange) {
					if (!(this.state.v is Lobby.StateNormal)) {
						Debug.LogError ("not in state normal: " + userId + "; " + this);
						canChange = false;
					}
				}
			}
			return canChange;
		}

		#endregion

		public void refreshTeam(int teamCount, int playerPerTeam)
		{
			// correct input
			teamCount = Mathf.Clamp (teamCount, 1, MAX_TEAM_COUNT);
			playerPerTeam = Mathf.Max (playerPerTeam, 1);
			// Refresh
			{
				// get old
				List<LobbyTeam> oldTeams = new List<LobbyTeam> ();
				{
					oldTeams.AddRange (this.teams.vs);
				}
				// Update
				{
					for (int teamIndex = 0; teamIndex < teamCount; teamIndex++) {
						// find team
						LobbyTeam team = null;
						{
							// find old
							if (oldTeams.Count > 0) {
								team = oldTeams [0];
							}
							// Make new
							if (team == null) {
								team = new LobbyTeam ();
								{
									team.uid = this.teams.makeId ();
								}
								this.teams.add (team);
							} else {
								oldTeams.Remove (team);
							}
						}
						// Update
						{
							team.teamIndex.v = teamIndex;
							// players
							{
								// get old players
								List<LobbyPlayer> oldPlayers = new List<LobbyPlayer>();
								{
									oldPlayers.AddRange (team.players.vs);
								}
								// Update
								{
									for (int playerIndex = 0; playerIndex < playerPerTeam; playerIndex++) {
										// find player
										LobbyPlayer player = null;
										{
											// find old
											if (oldPlayers.Count > 0) {
												player = oldPlayers [0];
											}
											// make new
											if (player == null) {
												player = new LobbyPlayer ();
												{
													player.uid = team.players.makeId ();
												}
												team.players.add (player);
											} else {
												oldPlayers.Remove (player);
											}
										}
										// Update
										{
											player.playerIndex.v = playerIndex;
											// inform: ko can
										}
									}
								}
								// Remove old
								foreach (LobbyPlayer oldPlayer in oldPlayers) {
									team.players.remove (oldPlayer);
								}
							}
						}
					}
				}
				// Remove old
				foreach (LobbyTeam oldTeam in oldTeams) {
					this.teams.remove (oldTeam);
				}
			}
		}

		#region Start

		public static bool IsCanStart(Data data, uint userId)
		{
			if (data != null) {
				ContestManagerStateLobby contestManagerStateLobby = data.findDataInParent<ContestManagerStateLobby> ();
				if (contestManagerStateLobby != null) {
					// find is admin?
					bool isAdmin = false;
					{
						RoomUser admin = Room.findAdmin (contestManagerStateLobby);
						if (admin != null) {
							Human human = admin.inform.v;
							if (human != null) {
								if (userId == human.playerId.v) {
									isAdmin = true;
								}
							} else {
								Debug.LogError ("human null: " + data);
							}
						} else {
							Debug.LogError ("admin null: " + data);
						}
					}
					// Process
					if (isAdmin) {
						if (contestManagerStateLobby.IsCanStart ()) {
							return true;
						}
					}
				} else {
					Debug.LogError ("contestManagerStateLobby null: " + data);
				}
			} else {
				Debug.LogError ("data null");
			}
			return false;
		}

		public bool IsCanStart()
		{
			bool allReady = true;
			{
				// get adminId
				uint adminId = 0;
				{
					RoomUser admin = Room.findAdmin (this);
					if (admin != null) {
						Human human = admin.inform.v;
						if (human != null) {
							adminId = human.playerId.v;
						} else {
							Debug.LogError ("human null: " + this);
						}
					} else {
						Debug.LogError ("admin null: " + this);
					}
				}
				// Check allready
				foreach (LobbyTeam team in this.teams.vs) {
					foreach (LobbyPlayer player in team.players.vs) {
						if (player.inform.v is Human) {
							Human human = player.inform.v as Human;
							if (human.playerId.v != adminId) {
								if (!player.isReady.v) {
									Debug.LogError ("not all ready: " + human);
									allReady = false;
									break;
								}
							}
						} else if (player.inform.v is EmptyInform) {
							allReady = false;
							break;
						}
					}
				}
			}
			return allReady;
		}

		#endregion

	}
}