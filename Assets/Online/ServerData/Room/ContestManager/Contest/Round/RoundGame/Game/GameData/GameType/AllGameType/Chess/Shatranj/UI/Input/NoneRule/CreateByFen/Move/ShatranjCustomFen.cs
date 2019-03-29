using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj.NoneRule
{
    public class ShatranjCustomFen : GameMove
    {

        public VP<string> fen;

        #region Constructor

        public enum Property
        {
            fen
        }

        public ShatranjCustomFen() : base()
        {
            this.fen = new VP<string>(this, (byte)Property.fen, "");
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.ShatranjCustomFen;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "ShatranjCustomFen: " + this.fen.v;
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

        #endregion

    }
}