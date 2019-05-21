using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class SingleContestFactory : ContestManagerContentFactory
    {

        public bool isFastStart = false;

        #region playerPerTeam

        public VP<int> playerPerTeam;

        public void requestChangePlayerPerTeam(uint userId, int newPlayerPerTeam)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changePlayerPerTeam(userId, newPlayerPerTeam);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is SingleContestFactoryIdentity)
                        {
                            SingleContestFactoryIdentity singleContestFactoryIdentity = dataIdentity as SingleContestFactoryIdentity;
                            singleContestFactoryIdentity.requestChangePlayerPerTeam(userId, newPlayerPerTeam);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find dataIdentity");
                    }
                }
            }
            else
            {
                Debug.LogError("You cannot request");
            }
        }

        public void changePlayerPerTeam(uint userId, int newPlayerPerTeam)
        {
            if (ContestManagerStateLobby.IsCanChange(this, userId))
            {
                this.playerPerTeam.v = newPlayerPerTeam;
            }
            else
            {
                Debug.LogError("cannot change: " + userId + "; " + this);
            }
        }

        #endregion

        #region roundFactory

        public VP<RoundFactory> roundFactory;

        public void getTeamCountAndPlayerPerTeamGameType(out int teamCountPerContest, out int playerPerTeam, out GameType.Type gameTypeType)
        {
            gameTypeType = GameType.Type.Xiangqi;
            teamCountPerContest = 1;
            playerPerTeam = 1;
            {
                playerPerTeam = this.playerPerTeam.v;
                // gameTypeType, teamCount
                {
                    RoundFactory roundFactory = this.roundFactory.v;
                    if (roundFactory != null)
                    {
                        switch (roundFactory.getType())
                        {
                            case RoundFactory.Type.Normal:
                                {
                                    NormalRoundFactory normalRoundFactory = roundFactory as NormalRoundFactory;
                                    // check gameFactory
                                    {
                                        GameFactory gameFactory = normalRoundFactory.gameFactory.v;
                                        if (gameFactory != null)
                                        {
                                            // check gameDataFactory
                                            GameDataFactory gameDataFactory = gameFactory.gameDataFactory.v;
                                            if (gameDataFactory != null)
                                            {
                                                switch (gameDataFactory.getType())
                                                {
                                                    case GameDataFactory.Type.Default:
                                                        {
                                                            DefaultGameDataFactory defaultGameDataFactory = gameDataFactory as DefaultGameDataFactory;
                                                            // Check defaultGameType
                                                            {
                                                                DefaultGameType defaultGameType = defaultGameDataFactory.defaultGameType.v;
                                                                if (defaultGameType != null)
                                                                {
                                                                    gameTypeType = defaultGameType.getType();
                                                                    // teamCount
                                                                    {
                                                                        GameType gameType = defaultGameType.makeDefaultGameType();
                                                                        if (gameType != null)
                                                                        {
                                                                            teamCountPerContest = gameType.getTeamCount();
                                                                        }
                                                                        else
                                                                        {
                                                                            Debug.LogError("gameType null: " + this);
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("defaultGameType null: " + this);
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    case GameDataFactory.Type.Posture:
                                                        {
                                                            PostureGameDataFactory postureGameDataFactory = gameDataFactory as PostureGameDataFactory;
                                                            // Check GameData
                                                            {
                                                                GameData gameData = postureGameDataFactory.gameData.v;
                                                                if (gameData != null)
                                                                {
                                                                    GameType gameType = gameData.gameType.v;
                                                                    if (gameType != null)
                                                                    {
                                                                        gameTypeType = gameType.getType();
                                                                        teamCountPerContest = gameType.getTeamCount();
                                                                    }
                                                                    else
                                                                    {
                                                                        Debug.LogError("gameType null: " + this);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Debug.LogError("gameData null: " + this);
                                                                }
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Debug.LogError("unknown type: " + gameDataFactory.getType() + "; " + this);
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("gameDataFactory null: " + this);
                                            }
                                        }
                                        else
                                        {
                                            Debug.LogError("gameFactory null: " + this);
                                        }
                                    }
                                }
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                break;
                        }
                    }
                    else
                    {
                        Debug.LogError("roundFactory null: " + this);
                    }
                }
            }
        }

        public RoundFactory.Type getRoundFactoryType()
        {
            RoundFactory.Type ret = RoundFactory.Type.Normal;
            {
                if (this.roundFactory.v != null)
                {
                    ret = this.roundFactory.v.getType();
                }
                else
                {
                    Debug.LogError("roundFactory null: " + this);
                }
            }
            return ret;
        }

        public void requestChangeRoundFactoryType(uint userId, int newRoundFactoryType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeRoundFactoryType(userId, newRoundFactoryType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is SingleContestFactoryIdentity)
                        {
                            SingleContestFactoryIdentity singleContestFactoryIdentity = dataIdentity as SingleContestFactoryIdentity;
                            singleContestFactoryIdentity.requestChangeRoundFactoryType(userId, newRoundFactoryType);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find dataIdentity");
                    }
                }
            }
            else
            {
                Debug.LogError("You cannot request");
            }
        }

        public void changeRoundFactoryType(uint userId, int newRoundFactoryType)
        {
            if (ContestManagerStateLobby.IsCanChange(this, userId))
            {
                // check need make new
                bool needMakeNew = true;
                {
                    if (this.roundFactory.v != null)
                    {
                        if (this.roundFactory.v.getType() == (RoundFactory.Type)newRoundFactoryType)
                        {
                            needMakeNew = false;
                        }
                    }
                }
                // make new
                if (needMakeNew)
                {
                    // make
                    RoundFactory roundFactory = null;
                    {
                        switch ((RoundFactory.Type)newRoundFactoryType)
                        {
                            case RoundFactory.Type.Normal:
                                roundFactory = new NormalRoundFactory();
                                break;
                            default:
                                Debug.LogError("unknown type: " + roundFactory.getType() + "; " + this);
                                break;
                        }
                    }
                    // set
                    if (roundFactory != null)
                    {
                        roundFactory.uid = this.roundFactory.makeId();
                        this.roundFactory.v = roundFactory;
                    }
                    else
                    {
                        Debug.LogError("roundFactory null: " + this);
                    }
                }
            }
        }

        #endregion

        #region limit

        public VP<RequestNewRound.Limit> newRoundLimit;

        public RequestNewRound.Limit.Type getNewRoundLimitType()
        {
            RequestNewRound.Limit.Type ret = RequestNewRound.Limit.Type.NoLimit;
            {
                if (this.newRoundLimit.v != null)
                {
                    ret = this.newRoundLimit.v.getType();
                }
                else
                {
                    Debug.LogError("newRoundLimit null: " + this);
                }
            }
            return ret;
        }

        public void requestChangeNewRoundLimitType(uint userId, int newRoundLimitType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeNewRoundLimitType(userId, newRoundLimitType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is SingleContestFactoryIdentity)
                        {
                            SingleContestFactoryIdentity singleContestFactoryIdentity = dataIdentity as SingleContestFactoryIdentity;
                            singleContestFactoryIdentity.requestChangeNewRoundLimitType(userId, newRoundLimitType);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find dataIdentity");
                    }
                }
            }
            else
            {
                Debug.LogError("You cannot request");
            }
        }

        public void changeNewRoundLimitType(uint userId, int newRoundLimitType)
        {
            if (ContestManagerStateLobby.IsCanChange(this, userId))
            {
                // Find
                bool needMakeNew = true;
                {
                    if (this.newRoundLimit.v != null)
                    {
                        if (this.newRoundLimit.v.getType() == (RequestNewRound.Limit.Type)newRoundLimitType)
                        {
                            needMakeNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("newRoundLimit null: " + this);
                    }
                }
                // Make new
                if (needMakeNew)
                {
                    // make
                    RequestNewRound.Limit limit = null;
                    {
                        switch ((RequestNewRound.Limit.Type)newRoundLimitType)
                        {
                            case RequestNewRound.Limit.Type.NoLimit:
                                limit = new RequestNewRoundNoLimit();
                                break;
                            case RequestNewRound.Limit.Type.HaveLimit:
                                limit = new RequestNewRoundHaveLimit();
                                break;
                            default:
                                Debug.LogError("unknown type: " + newRoundLimitType + "; " + this);
                                break;
                        }
                    }
                    // add
                    if (limit != null)
                    {
                        limit.uid = this.newRoundLimit.makeId();
                        this.newRoundLimit.v = limit;
                    }
                    else
                    {
                        Debug.LogError("limit null: " + this);
                    }
                }
            }
        }

        #endregion

        #region calculateScore

        public VP<CalculateScore> calculateScore;

        public CalculateScore.Type getCalculateScoreType()
        {
            CalculateScore.Type ret = CalculateScore.Type.WinLoseDraw;
            {
                if (this.calculateScore.v != null)
                {
                    ret = this.calculateScore.v.getType();
                }
                else
                {
                    Debug.LogError("calculateScore null: " + this);
                }
            }
            return ret;
        }

        public void requestChangeCalculateScoreType(uint userId, int newCalculateScoreType)
        {
            Data.NeedRequest needRequest = this.isNeedRequestServerByNetworkIdentity();
            if (needRequest.canRequest)
            {
                if (!needRequest.needIdentity)
                {
                    this.changeCalculateScoreType(userId, newCalculateScoreType);
                }
                else
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is SingleContestFactoryIdentity)
                        {
                            SingleContestFactoryIdentity singleContestFactoryIdentity = dataIdentity as SingleContestFactoryIdentity;
                            singleContestFactoryIdentity.requestChangeCalculateScoreType(userId, newCalculateScoreType);
                        }
                        else
                        {
                            Debug.LogError("Why isn't correct identity");
                        }
                    }
                    else
                    {
                        Debug.LogError("cannot find dataIdentity");
                    }
                }
            }
            else
            {
                Debug.LogError("You cannot request");
            }
        }

        public void changeCalculateScoreType(uint userId, int newCalculateScoreType)
        {
            if (ContestManagerStateLobby.IsCanChange(this, userId))
            {
                // Find
                bool needMakeNew = true;
                {
                    if (this.calculateScore.v != null)
                    {
                        if (this.calculateScore.v.getType() == (CalculateScore.Type)newCalculateScoreType)
                        {
                            needMakeNew = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("newCalculateScoreType null: " + this);
                    }
                }
                // Make new
                if (needMakeNew)
                {
                    // make
                    CalculateScore calculateScore = null;
                    {
                        switch ((CalculateScore.Type)newCalculateScoreType)
                        {
                            case CalculateScore.Type.Sum:
                                calculateScore = new CalculateScoreSum();
                                break;
                            case CalculateScore.Type.WinLoseDraw:
                                calculateScore = new CalculateScoreWinLoseDraw();
                                break;
                            default:
                                Debug.LogError("unknown type: " + newCalculateScoreType + "; " + this);
                                break;
                        }
                    }
                    // add
                    if (calculateScore != null)
                    {
                        calculateScore.uid = this.calculateScore.makeId();
                        this.calculateScore.v = calculateScore;
                    }
                    else
                    {
                        Debug.LogError("limit null: " + this);
                    }
                }
            }
        }

        #endregion

        #region Constructor

        public enum Property
        {
            playerPerTeam,
            roundFactory,
            newRoundLimit,
            calculateScore
        }

        public SingleContestFactory() : base()
        {
            this.playerPerTeam = new VP<int>(this, (byte)Property.playerPerTeam, 1);
            this.roundFactory = new VP<RoundFactory>(this, (byte)Property.roundFactory, new NormalRoundFactory());
            this.newRoundLimit = new VP<RequestNewRound.Limit>(this, (byte)Property.newRoundLimit, new RequestNewRoundNoLimit());
            this.calculateScore = new VP<CalculateScore>(this, (byte)Property.calculateScore, new CalculateScoreWinLoseDraw());
        }

        #endregion

        public override ContestManagerContent.Type getType()
        {
            return ContestManagerContent.Type.Single;
        }

        public override ContestManagerContent makeContent()
        {
            SingleContestContent singleContestContent = new SingleContestContent();
            {
                singleContestContent.contest.v.playerPerTeam.v = this.playerPerTeam.v;
                // roundFactory
                {
                    RoundFactory roundFactory = DataUtils.cloneData(this.roundFactory.v) as RoundFactory;
                    {
                        roundFactory.uid = singleContestContent.contest.v.roundFactory.makeId();
                    }
                    singleContestContent.contest.v.roundFactory.v = roundFactory;
                }
                // limit
                {
                    singleContestContent.contest.v.requestNewRound.v.limit.v = DataUtils.cloneData(this.newRoundLimit.v) as RequestNewRound.Limit;
                }
                // calculateScore
                {
                    CalculateScore calculateScore = DataUtils.cloneData(this.calculateScore.v) as CalculateScore;
                    {
                        calculateScore.uid = singleContestContent.contest.v.calculateScore.makeId();
                    }
                    singleContestContent.contest.v.calculateScore.v = calculateScore;
                }
            }
            return singleContestContent;
        }

    }
}