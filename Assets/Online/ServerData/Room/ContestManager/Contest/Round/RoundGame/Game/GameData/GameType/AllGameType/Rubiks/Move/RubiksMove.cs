using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class RubiksMove : GameMove
    {

        public VP<string> main;
        public VP<int> layerNo;
        public VP<bool> translation;

        public VP<int> lastMoveId;
        public VP<int> lastMoveIndex;

        #region Constructor

        public enum Property
        {
            main,
            layerNo,
            translation,
            lastMoveId,
            lastMoveIndex
        }

        public RubiksMove() : base()
        {
            this.main = new VP<string>(this, (byte)Property.main, "");
            this.layerNo = new VP<int>(this, (byte)Property.layerNo, 0);
            this.translation = new VP<bool>(this, (byte)Property.translation, false);
            this.lastMoveId = new VP<int>(this, (byte)Property.lastMoveId, 0);
            this.lastMoveIndex = new VP<int>(this, (byte)Property.lastMoveIndex, 0);
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.RubiksMove;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "";
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

        #endregion

    }
}