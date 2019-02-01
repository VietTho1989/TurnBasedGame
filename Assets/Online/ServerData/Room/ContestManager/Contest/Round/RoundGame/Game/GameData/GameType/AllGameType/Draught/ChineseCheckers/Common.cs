using UnityEngine;
using System.Collections;

namespace ChineseCheckers
{
    public static class Common
    {

        public const int X_SIZE = 19;
        public const int Y_SIZE = 19;

        public enum Pebble
        {
            NO_PEBBLE = 0,
            P1,
            P2,

            // Invalid squares set to non-zero to avoid bugs.
            INVALID = 123
        };


    }
}