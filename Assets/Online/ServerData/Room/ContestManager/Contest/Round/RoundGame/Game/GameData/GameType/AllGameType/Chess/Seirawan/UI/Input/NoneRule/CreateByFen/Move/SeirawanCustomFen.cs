using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan.NoneRule
{
    public class SeirawanCustomFen : GameMove
    {

        public VP<string> fen;

        #region Constructor

        public enum Property
        {
            fen
        }

        public SeirawanCustomFen() : base()
        {
            this.fen = new VP<string>(this, (byte)Property.fen, "");
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.SeirawanCustomFen;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "SeirawanCustomFen: " + this.fen.v;
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

        #endregion

    }
}