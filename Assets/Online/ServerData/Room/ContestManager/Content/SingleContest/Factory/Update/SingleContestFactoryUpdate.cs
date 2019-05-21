using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GameManager.Match
{
    public class SingleContestFactoryUpdate : UpdateBehavior<SingleContestFactory>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    ContestManagerStateLobby lobby = this.data.findDataInParent<ContestManagerStateLobby>();
                    if (lobby != null)
                    {
                        GameType.Type gameTypeType = GameType.Type.Xiangqi;
                        int teamCount = 1;
                        int playerPerTeam = 1;
                        // Find
                        {
                            this.data.getTeamCountAndPlayerPerTeamGameType(out teamCount, out playerPerTeam, out gameTypeType);
                        }
                        // Update
                        {
                            lobby.gameType.v = gameTypeType;
                            lobby.refreshTeam(teamCount, playerPerTeam);
                        }
                        // fastStart
                        {
                            Debug.LogError("singleContestFactory fast start: " + this.data.isFastStart);
                            if (this.data.isFastStart)
                            {
                                Debug.LogError("singleContestFactory fast start");
                                // check correct
                                bool isCorrect = false;
                                {
                                    if (lobby.teams.vs.Count == teamCount)
                                    {
                                        isCorrect = true;
                                    }
                                }
                                // process
                                if (isCorrect)
                                {
                                    this.data.isFastStart = false;
                                    foreach (LobbyTeam lobbyTeam in lobby.teams.vs)
                                    {
                                        // make computer
                                        Computer computer = new Computer();
                                        // request
                                        uint profileId = Server.getProfileUserId(this.data);
                                        foreach (LobbyPlayer lobbyPlayer in lobbyTeam.players.vs)
                                        {
                                            if (lobbyPlayer.inform.v.getType() == GamePlayer.Inform.Type.None)
                                            {
                                                // name
                                                {
                                                    int playerIndex = lobbyPlayer.playerIndex.v;
                                                    int teamIndex = lobbyTeam.teamIndex.v;
                                                    computer.computerName.v = "Player " + playerIndex + ", Team: " + teamIndex;
                                                }
                                                lobbyPlayer.requestAdminChangeComputer(profileId, computer);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Debug.LogError("lobby null: " + this);
                    }
                }
                else
                {
                    Debug.LogError("data null: " + this);
                }
            }
        }

        public override bool isShouldDisableUpdate()
        {
            return true;
        }

        #endregion

        #region implement callBacks

        private SingleContestFactoryCheckChange<SingleContestFactory> singleContestFactoryCheckChange = new SingleContestFactoryCheckChange<SingleContestFactory>();

        public override void onAddCallBack<T>(T data)
        {
            if (data is SingleContestFactory)
            {
                SingleContestFactory singleContestFactory = data as SingleContestFactory;
                // CheckChange
                {
                    singleContestFactoryCheckChange.addCallBack(this);
                    singleContestFactoryCheckChange.setData(singleContestFactory);
                }
                dirty = true;
                return;
            }
            // CheckChange
            if (data is SingleContestFactoryCheckChange<SingleContestFactory>)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is SingleContestFactory)
            {
                SingleContestFactory singleContestFactory = data as SingleContestFactory;
                // CheckChange
                {
                    singleContestFactoryCheckChange.removeCallBack(this);
                    singleContestFactoryCheckChange.setData(null);
                }
                this.setDataNull(singleContestFactory);
                return;
            }
            // CheckChange
            if (data is SingleContestFactoryCheckChange<SingleContestFactory>)
            {
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onUpdateSync<T>(WrapProperty wrapProperty, List<Sync<T>> syncs)
        {
            if (WrapProperty.checkError(wrapProperty))
            {
                return;
            }
            if (wrapProperty.p is SingleContestFactory)
            {
                return;
            }
            // CheckChange
            if (wrapProperty.p is SingleContestFactoryCheckChange<SingleContestFactory>)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}