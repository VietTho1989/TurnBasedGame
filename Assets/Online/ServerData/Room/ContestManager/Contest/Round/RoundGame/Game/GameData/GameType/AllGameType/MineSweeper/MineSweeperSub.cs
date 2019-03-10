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

    }
}