using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi.NoneRule
{
    public class XiangqiCustomFen : GameMove
    {

        public VP<string> fen;

        #region Constructor

        public enum Property
        {
            fen
        }

        public XiangqiCustomFen() : base()
        {
            this.fen = new VP<string>(this, (byte)Property.fen, "");
        }

        #endregion

        #region implement base

        public override Type getType()
        {
            return Type.XiangqiCustomFen;
        }

        public override MoveAnimation makeAnimation(GameType gameType)
        {
            return null;
        }

        public override string print()
        {
            return "XiangqiCustomFen: " + this.fen.v;
        }

        public override void getInforBeforeProcess(GameType gameType)
        {

        }

        #endregion

    }
}