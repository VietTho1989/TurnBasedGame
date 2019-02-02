using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ChineseCheckers
{
    public class ChineseCheckersSpriteContainer : MonoBehaviour
    {

        private static ChineseCheckersSpriteContainer instance;

        void Awake()
        {
            instance = this;
        }

        public static ChineseCheckersSpriteContainer get()
        {
            return instance;
        }

        public Sprite noneSprite;
        public Sprite p1Sprite;
        public Sprite p2Sprite;
        public Sprite invalid;

        public Sprite getSprite(Common.Pebble pebble)
        {
            switch (pebble)
            {
                case Common.Pebble.NO_PEBBLE:
                    return noneSprite;
                case Common.Pebble.P1:
                    return p1Sprite;
                case Common.Pebble.P2:
                    return p2Sprite;
                default:
                    Debug.LogError("unknown pebble: " + pebble);
                    return invalid;
            }
        }

    }
}