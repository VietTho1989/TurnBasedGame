using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
    public class NineMenMorrisMoveAnimation : MoveAnimation
    {

        public VP<int> moved;

        public VP<int> moved_to;

        public VP<Common.NMMAction> action;

        public VP<bool> mill;

        public VP<int> removed;

        public LP<int> board;

        public VP<int> turn;

        #region duration

        public VP<float> duration;

        public VP<float> positioningDuration;

        public VP<float> moveDuration;

        public VP<float> removedDuration;

        public override void initDuration()
        {
            // positioning
            if (this.action.v == Common.NMMAction.Place)
            {
                this.positioningDuration.v = 1.5f * AnimationManager.DefaultDuration;
            }
            else
            {
                this.positioningDuration.v = 0;
            }
            // move
            if (this.action.v != Common.NMMAction.Place)
            {
                Vector2 from = Common.convertPositionToLocal(this.moved.v);
                Vector2 dest = Common.convertPositionToLocal(this.moved_to.v);
                float distance = Mathf.Abs(dest.x - from.x) + Mathf.Abs(dest.y - from.y);
                this.moveDuration.v = GetDistanceMoveDuration(distance);
            }
            else
            {
                this.moveDuration.v = 0;
            }
            // remove
            if (this.removed.v >= 0 && this.removed.v < Common.BOARD_SPOT)
            {
                this.removedDuration.v = 3f * AnimationManager.DefaultDuration;
            }
            else
            {
                this.removedDuration.v = 0;
            }
            this.duration.v = this.positioningDuration.v + this.moveDuration.v + this.removedDuration.v;
        }

        public override float getDuration()
        {
            return this.duration.v;
        }

        #endregion

        #region Constructor

        public enum Property
        {
            moved,
            moved_to,
            action,
            mill,
            removed,
            board,
            turn,
            duration,
            positioningDuration,
            moveDuration,
            removedDuration
        }

        public NineMenMorrisMoveAnimation() : base()
        {
            this.moved = new VP<int>(this, (byte)Property.moved, 0);
            this.moved_to = new VP<int>(this, (byte)Property.moved_to, 0);
            this.action = new VP<Common.NMMAction>(this, (byte)Property.action, Common.NMMAction.Place);
            this.mill = new VP<bool>(this, (byte)Property.mill, false);
            this.removed = new VP<int>(this, (byte)Property.removed, -1);
            this.board = new LP<int>(this, (byte)Property.board);
            this.turn = new VP<int>(this, (byte)Property.turn, 0);
            this.duration = new VP<float>(this, (byte)Property.duration, AnimationManager.DefaultDuration);
            this.positioningDuration = new VP<float>(this, (byte)Property.positioningDuration, 0);
            this.moveDuration = new VP<float>(this, (byte)Property.moveDuration, 0);
            this.removedDuration = new VP<float>(this, (byte)Property.removedDuration, 0);
        }

        #endregion

        #region implement base

        public override GameMove.Type getType()
        {
            return GameMove.Type.NineMenMorrisMove;
        }

        public override void updateAfterProcessGameMove(GameType gameType)
        {

        }

        public override GameMove makeGameMove()
        {
            NineMenMorrisMove nineMenMorrisMove = new NineMenMorrisMove();
            {
                nineMenMorrisMove.moved.v = this.moved.v;
                nineMenMorrisMove.moved_to.v = this.moved_to.v;
                nineMenMorrisMove.action.v = this.action.v;
                nineMenMorrisMove.mill.v = this.mill.v;
                nineMenMorrisMove.removed.v = this.removed.v;
            }
            return nineMenMorrisMove;
        }

        public override bool isLoadFullData()
        {
            return true;
        }

        #endregion

    }
}