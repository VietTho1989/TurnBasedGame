using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
    public class GomokuMoveAnimation : MoveAnimation
    {

        public VP<int> move;

        public VP<Gomoku> gomoku;

        #region duration

        public VP<float> duration;

        public override void initDuration()
        {
            this.duration.v = 0.25f * AnimationManager.DefaultDuration;
        }

        public override float getDuration()
        {
            return this.duration.v;
        }

        #endregion

        #region Constructor

        public enum Property
        {
            move,
            gomoku,
            duration
        }

        public GomokuMoveAnimation() : base()
        {
            this.move = new VP<int>(this, (byte)Property.move, 0);
            this.gomoku = new VP<Gomoku>(this, (byte)Property.gomoku, new Gomoku());
            this.duration = new VP<float>(this, (byte)Property.duration, AnimationManager.DefaultDuration);
        }

        #endregion

        public override GameMove.Type getType()
        {
            return GameMove.Type.GomokuMove;
        }

        public override void updateAfterProcessGameMove(GameType gameType)
        {

        }

        public override GameMove makeGameMove()
        {
            GomokuMove gomokuMove = new GomokuMove();
            {
                gomokuMove.move.v = this.move.v;
                // boardSize
            }
            return gomokuMove;
        }

        public override bool isLoadFullData()
        {
            bool ret = true;
            {
                // gomoku
                if (ret)
                {
                    Gomoku gomku = this.gomoku.v;
                    if (gomoku != null)
                    {
                        if (gomku.gs.vs.Count == 0)
                        {
                            Debug.LogError("gomoku gs count 0");
                            ret = false;
                        }
                    }
                    else
                    {
                        Debug.LogError("gomoku null");
                        ret = false;
                    }
                }
            }
            return ret;
        }

    }
}