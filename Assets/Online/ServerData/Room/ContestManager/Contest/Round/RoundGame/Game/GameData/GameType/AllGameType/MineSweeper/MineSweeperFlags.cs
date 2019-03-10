using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperFlags : Data
    {

        public const int MaxCount = 500;

        public LP<ushort> myFlags;

        #region Constructor

        public enum Property
        {
            myFlags
        }

        public MineSweeperFlags() : base()
        {
            this.myFlags = new LP<ushort>(this, (byte)Property.myFlags);
        }

        #endregion

    }
}