using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperMoveAnimation : MoveAnimation
    {

        #region mineSweeper inform

        public VP<int> X;

        public VP<int> Y;

        public LP<MineSweeperSub> sub;

        public VP<bool> booom;

        public LP<MineSweeperFlags> myFlags;

        #endregion

        #region move

        public VP<int> move;

        public VP<MineSweeperMove.MoveType> type;

        #endregion

        #region Constructor

        public enum Property
        {
            X,
            Y,
            sub,
            booom,
            myFlags,

            move,
            type
        }

        public MineSweeperMoveAnimation() : base()
        {
            // inform
            {
                this.X = new VP<int>(this, (byte)Property.X, 10);
                this.Y = new VP<int>(this, (byte)Property.Y, 10);
                this.sub = new LP<MineSweeperSub>(this, (byte)Property.sub);
                this.booom = new VP<bool>(this, (byte)Property.booom, false);
                this.myFlags = new LP<MineSweeperFlags>(this, (byte)Property.myFlags);
            }
            this.move = new VP<int>(this, (byte)Property.move, -1);
            this.type = new VP<MineSweeperMove.MoveType>(this, (byte)Property.type, MineSweeperMove.MoveType.Normal);
        }

        #endregion

        #region implement base

        public override GameMove.Type getType()
        {
            return GameMove.Type.MineSweeperMove;
        }

        public override void updateAfterProcessGameMove(GameType gameType)
        {

        }

        public override void initDuration()
        {

        }

        public override float getDuration()
        {
            return 0.1f;
        }

        public override GameMove makeGameMove()
        {
            MineSweeperMove mineSweeperMove = new MineSweeperMove();
            {
                mineSweeperMove.move.v = this.move.v;
                mineSweeperMove.type.v = this.type.v;
                // N
                // M
            }
            return mineSweeperMove;
        }

        public override bool isLoadFullData()
        {
            bool ret = true;
            {
                // check sub
                if (ret)
                {
                    DataIdentity dataIdentity = null;
                    if (DataIdentity.clientMap.TryGetValue(this, out dataIdentity))
                    {
                        if (dataIdentity is MineSweeperMoveAnimationIdentity)
                        {
                            MineSweeperMoveAnimationIdentity mineSweeperMoveAnimationIdentity = dataIdentity as MineSweeperMoveAnimationIdentity;
                            if (mineSweeperMoveAnimationIdentity.sub != this.sub.vs.Count 
                                || mineSweeperMoveAnimationIdentity.myFlags != this.myFlags.vs.Count)
                            {
                                Debug.LogError("sub. myFlags count error");
                                ret = false;
                            }
                        }
                        else
                        {
                            Debug.LogError("why not subIdentity");
                        }
                    }
                }
            }
            return true;
        }

        #endregion

    }
}