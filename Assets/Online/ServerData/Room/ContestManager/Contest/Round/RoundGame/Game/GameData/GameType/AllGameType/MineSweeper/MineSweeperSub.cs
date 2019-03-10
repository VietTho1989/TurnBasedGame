using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
    public class MineSweeperSub : Data
    {

        public const int MaxCount = 500;

        public LP<sbyte> bombs;

        public LP<sbyte> flags;

        public LP<sbyte> board;

        #region Constructor

        public enum Property
        {
            bombs,
            flags,
            board
        }

        public MineSweeperSub() : base()
        {
            this.bombs = new LP<sbyte>(this, (byte)Property.bombs);
            this.flags = new LP<sbyte>(this, (byte)Property.flags);
            this.board = new LP<sbyte>(this, (byte)Property.board);
        }

        #endregion

    }
}