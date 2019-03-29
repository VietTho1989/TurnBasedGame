using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.NoneRule
{
    public class EnglishDraughtCustomFen : GameMove
    {

        public VP<string> fen;

        #region Constructor

        public enum Property
        {
            fen
        }

        public EnglishDraughtCustomFen() : base()
        {
            this.fen = new VP<string>(this, (byte)Property.fen, "");
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.EnglishDraughtCustomFen;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "EnglishDraughtCustomFen: " + this.fen.v;
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

        #endregion

    }
}