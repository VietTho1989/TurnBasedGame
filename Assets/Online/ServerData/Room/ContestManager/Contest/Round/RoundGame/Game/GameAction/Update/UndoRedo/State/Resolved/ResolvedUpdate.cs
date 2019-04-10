using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UndoRedo
{
    public class ResolvedUpdate : UpdateBehavior<Resolved>
    {

        #region Update

        public override void update()
        {
            if (dirty)
            {
                dirty = false;
                if (this.data != null)
                {
                    Game game = this.data.findDataInParent<Game>();
                    if (game != null)
                    {
                        // Pause if this turn is computer
                        {
                            int currentPlayerIndex = game.gameData.v.turn.v.playerIndex.v;
                            GamePlayer currentPlayer = game.findGamePlayer(currentPlayerIndex);
                            if (currentPlayer != null)
                            {
                                if (currentPlayer.inform.v.getType() == GamePlayer.Inform.Type.Computer)
                                {
                                    // Refresh check game finish
                                    {
                                        // checkGameFinish
                                        {
                                            GameData gameData = game.gameData.v;
                                            if (gameData != null)
                                            {
                                                CheckGameFinishUpdate checkGameFinishUpdate = gameData.findCallBack<CheckGameFinishUpdate>();
                                                if (checkGameFinishUpdate != null)
                                                {
                                                    checkGameFinishUpdate.update();
                                                }
                                                else
                                                {
                                                    Debug.LogError("checkGameFinishUpdate null: " + this);
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("gameData null: " + this);
                                            }
                                        }
                                        // checkGameUpdate
                                        {
                                            GameState.GameCheckEndUpdate gameCheckEndUpdate = game.findCallBack<GameState.GameCheckEndUpdate>();
                                            if (gameCheckEndUpdate != null)
                                            {
                                                gameCheckEndUpdate.update();
                                            }
                                            else
                                            {
                                                Debug.LogError("gameCheckEndUpdate null: " + this);
                                            }
                                        }
                                    }
                                    // Computer, so you pause
                                    if (game.state.v is GameState.Play)
                                    {
                                        GameState.Play play = game.state.v as GameState.Play;
                                        // Chuyen sang PlayPause
                                        {
                                            GameState.PlayPause playPause = play.sub.newOrOld<GameState.PlayPause>();
                                            {
                                                playPause.human.v.playerId.v = Data.UNKNOWN_ID;
                                            }
                                            play.sub.v = playPause;
                                        }
                                    }
                                    else
                                    {
                                        Debug.LogError("why gameState not play");
                                    }
                                }
                                else
                                {
                                    Debug.LogError("Not computer, human turn, so not pause");
                                }
                            }
                            else
                            {
                                Debug.LogError("Why cannot find current player");
                            }
                        }
                        // Chuyen sang WaitAction
                        if (game != null)
                        {
                            // Chuyen sang waitInputAction
                            WaitInputAction waitInputAction = game.gameAction.newOrOld<WaitInputAction>();
                            // Update Property
                            {
                                Debug.Log("update property waitInputAction: " + waitInputAction + "; " + this);
                                // serverTime
                                // clientTime
                                // sub
                                // inputs
                            }
                            game.gameAction.v = waitInputAction;
                        }
                        else
                        {
                            Debug.LogError("gameData null");
                        }
                    }
                    else
                    {
                        Debug.LogError("why game null");
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

        public override void onAddCallBack<T>(T data)
        {
            if (data is Resolved)
            {
                dirty = true;
                return;
            }
            Debug.LogError("Don't process: " + data + "; " + this);
        }

        public override void onRemoveCallBack<T>(T data, bool isHide)
        {
            if (data is Resolved)
            {
                Resolved resolved = data as Resolved;
                // Child
                {

                }
                this.setDataNull(resolved);
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
            if (wrapProperty.p is Resolved)
            {
                switch ((Resolved.Property)wrapProperty.n)
                {
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
                        break;
                }
                return;
            }
            Debug.LogError("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
        }

        #endregion

    }
}