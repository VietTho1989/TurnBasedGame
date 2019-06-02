using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rubiks
{
    public class RubiksAI : Computer.AI
    {

        #region Constructor

        public enum Property
        {

        }

        public RubiksAI() : base()
        {

        }

        #endregion

        public override GameType.Type getType()
        {
            return GameType.Type.Rubiks;
        }

    }
}