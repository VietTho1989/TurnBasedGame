using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
	public class NormalRoundFactory : RoundFactory
	{

		#region gameFactory

		public VP<GameFactory> gameFactory;

		#endregion

		#region isChangeSideBetweenRound

		public VP<bool> isChangeSideBetweenRound;

		public void requestChangeIsChangeSideBetweenRound(uint userId, bool newIsChangeSideBetweenRound)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeIsChangeSideBetweenRound (userId, newIsChangeSideBetweenRound);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NormalRoundFactoryIdentity) {
							NormalRoundFactoryIdentity normalRoundFactoryIdentity = dataIdentity as NormalRoundFactoryIdentity;
							normalRoundFactoryIdentity.requestChangeIsChangeSideBetweenRound(userId, newIsChangeSideBetweenRound);
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

		public void changeIsChangeSideBetweenRound(uint userId, bool newIsChangeSideBetweenRound)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.isChangeSideBetweenRound.v = newIsChangeSideBetweenRound;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region isSwitchPlayer

		public VP<bool> isSwitchPlayer;

		public void requestChangeIsSwitchPlayer(uint userId, bool newIsSwitchPlayer)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeIsSwitchPlayer (userId, newIsSwitchPlayer);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NormalRoundFactoryIdentity) {
							NormalRoundFactoryIdentity normalRoundFactoryIdentity = dataIdentity as NormalRoundFactoryIdentity;
							normalRoundFactoryIdentity.requestChangeIsSwitchPlayer(userId, newIsSwitchPlayer);
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

		public void changeIsSwitchPlayer(uint userId, bool newIsSwitchPlayer)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.isSwitchPlayer.v = newIsSwitchPlayer;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region isDifferentInTeam

		public VP<bool> isDifferentInTeam;

		public void requestChangeIsDifferentInTeam(uint userId, bool newIsDifferentInTeam)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeIsDifferentInTeam (userId, newIsDifferentInTeam);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NormalRoundFactoryIdentity) {
							NormalRoundFactoryIdentity normalRoundFactoryIdentity = dataIdentity as NormalRoundFactoryIdentity;
							normalRoundFactoryIdentity.requestChangeIsDifferentInTeam(userId, newIsDifferentInTeam);
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

		public void changeIsDifferentInTeam(uint userId, bool newIsDifferentInTeam)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				this.isDifferentInTeam.v = newIsDifferentInTeam;
			} else {
				Debug.LogError ("cannot change: " + userId + "; " + this);
			}
		}

		#endregion

		#region caculateScore

		public VP<CalculateScore> calculateScore;

		public CalculateScore.Type getCalculateScoreType()
		{
			CalculateScore.Type ret = CalculateScore.Type.WinLoseDraw;
			{
				if (this.calculateScore.v != null) {
					ret = this.calculateScore.v.getType ();
				} else {
					Debug.LogError ("calculateScore null: " + this);
				}
			}
			return ret;
		}

		public void requestChangeCalculateScoreType(uint userId, int newCalculateScoreType)
		{
			Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity ();
			if (needRequest.canRequest) {
				if (!needRequest.needIdentity) {
					this.changeCalculateScoreType (userId, newCalculateScoreType);
				} else {
					DataIdentity dataIdentity = null;
					if (DataIdentity.clientMap.TryGetValue (this, out dataIdentity)) {
						if (dataIdentity is NormalRoundFactoryIdentity) {
							NormalRoundFactoryIdentity normalRoundFactoryIdentity = dataIdentity as NormalRoundFactoryIdentity;
							normalRoundFactoryIdentity.requestChangeCalculateScoreType(userId, newCalculateScoreType);	
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

		public void changeCalculateScoreType(uint userId, int newCalculateScoreType)
		{
			if (ContestManagerStateLobby.IsCanChange (this, userId)) {
				// Find
				bool needMakeNew = true;
				{
					if (this.calculateScore.v != null) {
						if (this.calculateScore.v.getType () == (CalculateScore.Type)newCalculateScoreType) {
							needMakeNew = false;
						}
					} else {
						Debug.LogError ("newCalculateScoreType null: " + this);
					}
				}
				// Make new
				if (needMakeNew) {
					// make
					CalculateScore calculateScore = null;
					{
						switch ((CalculateScore.Type)newCalculateScoreType) {
						case CalculateScore.Type.Sum:
							calculateScore = new CalculateScoreSum ();
							break;
						case CalculateScore.Type.WinLoseDraw:
							calculateScore = new CalculateScoreWinLoseDraw ();
							break;
						default:
							Debug.LogError ("unknown type: " + newCalculateScoreType + "; " + this);
							break;
						}
					}
					// add
					if (calculateScore != null) {
						calculateScore.uid = this.calculateScore.makeId ();
						this.calculateScore.v = calculateScore;
					} else {
						Debug.LogError ("limit null: " + this);
					}
				}
			}
		}

		#endregion

		#region Constructor

		public enum Property
		{
			gameFactory,
			isChangeSideBetweenRound,
			isSwitchPlayer,
			isDifferentInTeam,
			calculateScore
		}

		public NormalRoundFactory() : base()
		{
			this.gameFactory = new VP<GameFactory> (this, (byte)Property.gameFactory, new GameFactory ());
			this.isChangeSideBetweenRound = new VP<bool> (this, (byte)Property.isChangeSideBetweenRound, true);
			this.isSwitchPlayer = new VP<bool> (this, (byte)Property.isSwitchPlayer, true);
			this.isDifferentInTeam = new VP<bool> (this, (byte)Property.isDifferentInTeam, true);
			this.calculateScore = new VP<CalculateScore> (this, (byte)Property.calculateScore, new CalculateScoreSum ());
		}

		#endregion

		public override Type getType ()
		{
			return Type.Normal;
		}

		public override int getPlayerCountPerGame ()
		{
			int ret = 1;
			{
				GameFactory gameFactory = this.gameFactory.v;
				if (gameFactory != null) {
					GameDataFactory gameDataFactory = gameFactory.gameDataFactory.v;
					if (gameDataFactory != null) {
						switch (gameDataFactory.getType ()) {
						case GameDataFactory.Type.Default:
							{
								DefaultGameDataFactory defaultGameDataFactory = gameDataFactory as DefaultGameDataFactory;
								DefaultGameType defaultGameType = defaultGameDataFactory.defaultGameType.v;
								if (defaultGameType != null) {
									GameType gameType = defaultGameType.makeDefaultGameType ();
									if (gameType != null) {
										ret = gameType.getTeamCount ();
									} else {
										Debug.LogError ("gameType null: " + this);
									}
								} else {
									Debug.LogError ("defaultGameType null: " + this);
								}
							}
							break;
						case GameDataFactory.Type.Posture:
							{
								PostureGameDataFactory postureGameDataFactory = gameDataFactory as PostureGameDataFactory;
								GameData gameData = postureGameDataFactory.gameData.v;
								if (gameData != null) {
									GameType gameType = gameData.gameType.v;
									if (gameType != null) {
										ret = gameType.getTeamCount ();
									} else {
										Debug.LogError ("gameType null: " + this);
									}
								} else {
									Debug.LogError ("gameData null: " + this);
								}
							}
							break;
						default:
							Debug.LogError ("unknown type: " + gameDataFactory.getType () + "; " + this);
							break;
						}
					} else {
						Debug.LogError ("gameDataFactory null: " + this);
					}
				} else {
					Debug.LogError ("gameFactory null: " + this);
				}
			}
			return ret;
		}

		public override Round makeRound ()
		{
			Round round = new Round ();
			{
				// state: de default
				// index
				{
					int index = 0;
					{
						Contest contest = this.findDataInParent<Contest> ();
						if (contest != null) {
							index = contest.rounds.vs.Count;
						} else {
							Debug.LogError ("contest null: " + this);
						}
					}
					round.index.v = index;
				}
				// roundGames
				{
					int playerPerTeam = 1;
					{
						Contest contest = this.findDataInParent<Contest> ();
						if (contest != null) {
							playerPerTeam = contest.getPlayerPerTeam ();
						} else {
							Debug.LogError ("contest null: " + this);
						}
					}
					for (int gameIndex = 0; gameIndex < playerPerTeam; gameIndex++) {
						RoundGame roundGame = new RoundGame ();
						{
							roundGame.uid = round.roundGames.makeId ();
							roundGame.index.v = gameIndex;
							// playerInTeam
							{
								Contest contest = this.findDataInParent<Contest> ();
								if (contest != null) {
									if (this.isSwitchPlayer.v) {
										// round 0: (0 0) (1 1)
										// round 1: (0 (0+1*1)) (1 (1+1*1))
										// round 2: (0 (0+2*1)) (1 (1+2*1))
										for (int i = 0; i < contest.teams.vs.Count; i++) {
											roundGame.playerInTeam.add ((gameIndex + round.index.v * i) % playerPerTeam);
										}
									} else {
										// (0 0) (1 1)
										for (int i = 0; i < contest.teams.vs.Count; i++) {
											roundGame.playerInTeam.add (gameIndex);
										}
									}
								} else {
									Debug.LogError ("contest null: " + this);
								}
							}
							// playerInGame
							{
								Contest contest = this.findDataInParent<Contest> ();
								if (contest != null) {
									if (contest.teams.vs.Count > 0) {
										if (this.isChangeSideBetweenRound.v) {
											// round.index.v co tac dung
											if (this.isDifferentInTeam.v) {
												for (int i = 0; i < contest.teams.vs.Count; i++) {
													roundGame.playerInGame.add ((gameIndex + i + round.index.v) % contest.teams.vs.Count);
												}
											} else {
												for (int i = 0; i < contest.teams.vs.Count; i++) {
													roundGame.playerInGame.add ((i + round.index.v) % contest.teams.vs.Count);
												}
											}
										} else {
											// every round the same
											if (this.isDifferentInTeam.v) {
												// same team different gamePlayerIndex
												for (int i = 0; i < contest.teams.vs.Count; i++) {
													roundGame.playerInGame.add ((gameIndex + i) % contest.teams.vs.Count);
												}
											} else {
												// same team same gamePlayerIndex
												for (int i = 0; i < contest.teams.vs.Count; i++) {
													roundGame.playerInGame.add (i);
												}
											}
										}
									} else {
										Debug.LogError ("team count error: " + contest.teams.vs.Count + "; " + this);
									}
								} else {
									Debug.LogError ("contest null: " + this);
								}
							}
							// game
							{
								Game game = new Game ();
								{
									// GameData
									this.gameFactory.v.gameDataFactory.v.initGameData(game.gameData.v);
									// TimeControl
									game.gameData.v.timeControl.v = (TimeControl.TimeControl)DataUtils.cloneData(this.gameFactory.v.timeControl.v);
								}
								roundGame.game.v = game;
							}
						}
						round.roundGames.add (roundGame);
					}
				}
				// calculateScore
				{
					CalculateScore calculateScore = DataUtils.cloneData (this.calculateScore.v) as CalculateScore;
					{
						calculateScore.uid = round.calculateScore.makeId ();
					}
					round.calculateScore.v = calculateScore;
				}
			}
			return round;
		}

		public override float getMaxAbleScore ()
		{
			return 1;
		}

		public override float getMinAbleScore ()
		{
			return 0;
		}

		public override GameType.Type getGameTypeType ()
		{
			GameType.Type gameTypeType = GameType.Type.CHESS;
			{
				GameFactory gameFactory = this.gameFactory.v;
				if (gameFactory != null) {
					GameDataFactory gameDataFactory = gameFactory.gameDataFactory.v;
					if (gameDataFactory != null) {
						gameTypeType = gameDataFactory.getGameTypeType ();
					} else {
						Debug.LogError ("gameDataFactory null: " + this);
					}
				} else {
					Debug.LogError ("gameFactory null: " + this);
				}
			}
			return gameTypeType;
		}

	}
}