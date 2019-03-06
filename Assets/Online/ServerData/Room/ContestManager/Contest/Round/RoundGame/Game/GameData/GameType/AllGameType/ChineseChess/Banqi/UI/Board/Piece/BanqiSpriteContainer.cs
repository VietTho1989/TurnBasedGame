using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
    public class BanqiSpriteContainer : MonoBehaviour
    {

        private static BanqiSpriteContainer instance;

        void Awake()
        {
            instance = this;
        }

        public static BanqiSpriteContainer get()
        {
            return instance;
        }

        public Sprite None;

        #region Normal

        public Sprite NormalRedGeneral;
        public Sprite NormalRedAdvisor;
        public Sprite NormalRedElephant;
        public Sprite NormalRedHorse;
        public Sprite NormalRedChariot;
        public Sprite NormalRedCannon;
        public Sprite NormalRedPawn;
        public Sprite NormalBlackGeneral;
        public Sprite NormalBlackAdvisor;
        public Sprite NormalBlackElephant;
        public Sprite NormalBlackHorse;
        public Sprite NormalBlackChariot;
        public Sprite NormalBlackPawn;
        public Sprite NormalBlackCannon;

        #endregion

        #region Western

        public Sprite WesternRedGeneral;
        public Sprite WesternRedAdvisor;
        public Sprite WesternRedElephant;
        public Sprite WesternRedHorse;
        public Sprite WesternRedChariot;
        public Sprite WesternRedCannon;
        public Sprite WesternRedPawn;
        public Sprite WesternBlackGeneral;
        public Sprite WesternBlackAdvisor;
        public Sprite WesternBlackElephant;
        public Sprite WesternBlackHorse;
        public Sprite WesternBlackChariot;
        public Sprite WesternBlackPawn;
        public Sprite WesternBlackCannon;

        #endregion

        public Sprite Hidden;

        public Sprite getSprite(Token.Type type, Token.Ecolor color, Setting.Style style)
        {
            switch (style)
            {
                case Setting.Style.Western:
                    {
                        switch (color)
                        {
                            case Token.Ecolor.RED:
                                {
                                    switch (type)
                                    {
                                        case Token.Type.GENERAL:
                                            return WesternRedGeneral;
                                        case Token.Type.ADVISOR:
                                            return WesternRedAdvisor;
                                        case Token.Type.ELEPHANT:
                                            return WesternRedElephant;
                                        case Token.Type.CHARIOT:
                                            return WesternRedChariot;
                                        case Token.Type.HORSE:
                                            return WesternRedHorse;
                                        case Token.Type.CANNON:
                                            return WesternRedCannon;
                                        case Token.Type.SOLDIER:
                                            return WesternRedPawn;
                                        default:
                                            Debug.LogError("unknown type: " + type);
                                            return None;
                                    }
                                }
                            // break;
                            case Token.Ecolor.BLACK:
                                {
                                    switch (type)
                                    {
                                        case Token.Type.GENERAL:
                                            return WesternBlackGeneral;
                                        case Token.Type.ADVISOR:
                                            return WesternBlackAdvisor;
                                        case Token.Type.ELEPHANT:
                                            return WesternBlackElephant;
                                        case Token.Type.CHARIOT:
                                            return WesternBlackChariot;
                                        case Token.Type.HORSE:
                                            return WesternBlackHorse;
                                        case Token.Type.CANNON:
                                            return WesternBlackCannon;
                                        case Token.Type.SOLDIER:
                                            return WesternBlackPawn;
                                        default:
                                            Debug.LogError("unknown type: " + type);
                                            return None;
                                    }
                                }
                            // break;
                            default:
                                Debug.LogError("unknown color: " + color);
                                return None;
                        }
                    }
                case Setting.Style.Normal:
                default:
                    {
                        switch (color)
                        {
                            case Token.Ecolor.RED:
                                {
                                    switch (type)
                                    {
                                        case Token.Type.GENERAL:
                                            return NormalRedGeneral;
                                        case Token.Type.ADVISOR:
                                            return NormalRedAdvisor;
                                        case Token.Type.ELEPHANT:
                                            return NormalRedElephant;
                                        case Token.Type.CHARIOT:
                                            return NormalRedChariot;
                                        case Token.Type.HORSE:
                                            return NormalRedHorse;
                                        case Token.Type.CANNON:
                                            return NormalRedCannon;
                                        case Token.Type.SOLDIER:
                                            return NormalRedPawn;
                                        default:
                                            Debug.LogError("unknown type: " + type);
                                            return None;
                                    }
                                }
                            // break;
                            case Token.Ecolor.BLACK:
                                {
                                    switch (type)
                                    {
                                        case Token.Type.GENERAL:
                                            return NormalBlackGeneral;
                                        case Token.Type.ADVISOR:
                                            return NormalBlackAdvisor;
                                        case Token.Type.ELEPHANT:
                                            return NormalBlackElephant;
                                        case Token.Type.CHARIOT:
                                            return NormalBlackChariot;
                                        case Token.Type.HORSE:
                                            return NormalBlackHorse;
                                        case Token.Type.CANNON:
                                            return NormalBlackCannon;
                                        case Token.Type.SOLDIER:
                                            return NormalBlackPawn;
                                        default:
                                            Debug.LogError("unknown type: " + type);
                                            return None;
                                    }
                                }
                            // break;
                            default:
                                Debug.LogError("unknown color: " + color);
                                return None;
                        }
                    }
            }
        }

    }
}