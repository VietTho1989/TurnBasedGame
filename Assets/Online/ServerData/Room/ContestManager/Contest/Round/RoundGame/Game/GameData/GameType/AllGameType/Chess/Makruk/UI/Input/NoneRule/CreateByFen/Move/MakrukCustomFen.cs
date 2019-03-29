using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Makruk.NoneRule
{
    public class MakrukCustomFen : GameMove
    {

        public VP<string> fen;

        #region Constructor

        public enum Property
        {
            fen
        }

        public MakrukCustomFen() : base()
        {
            this.fen = new VP<string>(this, (byte)Property.fen, "");
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.MakrukCustomFen;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "MakrukCustomFen: " + this.fen.v;
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

        #endregion

    }
}