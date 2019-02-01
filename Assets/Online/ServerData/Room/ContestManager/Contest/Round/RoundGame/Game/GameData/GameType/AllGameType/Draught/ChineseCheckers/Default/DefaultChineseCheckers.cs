using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChineseCheckers
{
    public class DefaultChineseCheckers : DefaultGameType
    {

        #region Constructor

        public enum Property
        {

        }

        public DefaultChineseCheckers() : base()
        {

        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.ChineseCheckers;
        }

        public override GameType makeDefaultGameType()
        {
            ChineseCheckers newChineseCheckers = Core.unityMakePositionByFen(ChineseCheckers.INITIAL_POSITION);
            return newChineseCheckers;
        }

    }
}