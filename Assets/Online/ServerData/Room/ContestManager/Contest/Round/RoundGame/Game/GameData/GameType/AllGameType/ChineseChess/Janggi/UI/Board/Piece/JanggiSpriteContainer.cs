using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
    public class JanggiSpriteContainer : MonoBehaviour
    {

        private static JanggiSpriteContainer instance;

        void Awake()
        {
            instance = this;
        }

        public static JanggiSpriteContainer get()
        {
            return instance;
        }

        public Sprite None;

        #region Normal

        public Sprite NormalGreenGeneral;
        public Sprite NormalGreenAdvisor;
        public Sprite NormalGreenElephant;
        public Sprite NormalGreenHorse;
        public Sprite NormalGreenChariot;
        public Sprite NormalGreenCannon;
        public Sprite NormalGreenPawn;

        public Sprite NormalRedGeneral;
        public Sprite NormalRedAdvisor;
        public Sprite NormalRedElephant;
        public Sprite NormalRedHorse;
        public Sprite NormalRedChariot;
        public Sprite NormalRedCannon;
        public Sprite NormalRedPawn;

        #endregion

        #region Western

        public Sprite WesternGreenGeneral;
        public Sprite WesternGreenAdvisor;
        public Sprite WesternGreenElephant;
        public Sprite WesternGreenHorse;
        public Sprite WesternGreenChariot;
        public Sprite WesternGreenCannon;
        public Sprite WesternGreenPawn;

        public Sprite WesternRedGeneral;
        public Sprite WesternRedAdvisor;
        public Sprite WesternRedElephant;
        public Sprite WesternRedHorse;
        public Sprite WesternRedChariot;
        public Sprite WesternRedCannon;
        public Sprite WesternRedPawn;

        #endregion

        public Sprite getSprite(uint piece, Setting.Style style)
        {
            switch (style)
            {
                case Setting.Style.Western:
                    {
                        switch ((StoneHelper.Stones)piece)
                        {
                            case StoneHelper.Stones.Empty:
                                return None;
                            case StoneHelper.Stones.GreenPawn1:
                            case StoneHelper.Stones.GreenPawn2:
                            case StoneHelper.Stones.GreenPawn3:
                            case StoneHelper.Stones.GreenPawn4:
                            case StoneHelper.Stones.GreenPawn5:
                                return WesternGreenPawn;
                            case StoneHelper.Stones.GreenElephant1:
                            case StoneHelper.Stones.GreenElephant2:
                                return WesternGreenElephant;
                            case StoneHelper.Stones.GreenHorse1:
                            case StoneHelper.Stones.GreenHorse2:
                                return WesternGreenHorse;
                            case StoneHelper.Stones.GreenCannon1:
                            case StoneHelper.Stones.GreenCannon2:
                                return WesternGreenCannon;
                            case StoneHelper.Stones.GreenChariot1:
                            case StoneHelper.Stones.GreenChariot2:
                                return WesternGreenChariot;
                            case StoneHelper.Stones.GreenAdvisor1:
                            case StoneHelper.Stones.GreenAdvisor2:
                                return WesternGreenAdvisor;
                            case StoneHelper.Stones.GreenGeneral:
                                return WesternGreenGeneral;

                            case StoneHelper.Stones.RedPawn1:
                            case StoneHelper.Stones.RedPawn2:
                            case StoneHelper.Stones.RedPawn3:
                            case StoneHelper.Stones.RedPawn4:
                            case StoneHelper.Stones.RedPawn5:
                                return WesternRedPawn;
                            case StoneHelper.Stones.RedElephant1:
                            case StoneHelper.Stones.RedElephant2:
                                return WesternRedElephant;
                            case StoneHelper.Stones.RedHorse1:
                            case StoneHelper.Stones.RedHorse2:
                                return WesternRedHorse;
                            case StoneHelper.Stones.RedCannon1:
                            case StoneHelper.Stones.RedCannon2:
                                return WesternRedCannon;
                            case StoneHelper.Stones.RedChariot1:
                            case StoneHelper.Stones.RedChariot2:
                                return WesternRedChariot;
                            case StoneHelper.Stones.RedAdvisor1:
                            case StoneHelper.Stones.RedAdvisor2:
                                return WesternRedAdvisor;
                            case StoneHelper.Stones.RedGeneral:
                                return WesternRedGeneral;

                            case StoneHelper.Stones.Pawn:
                                return WesternGreenPawn;
                            case StoneHelper.Stones.GreenPawn:
                                return WesternGreenPawn;
                            case StoneHelper.Stones.RedPawn:
                                return WesternRedPawn;
                            case StoneHelper.Stones.Elephant:
                                return WesternGreenElephant;
                            case StoneHelper.Stones.Horse:
                                return WesternGreenHorse;
                            case StoneHelper.Stones.Cannon:
                                return WesternGreenCannon;
                            case StoneHelper.Stones.GreenCannon:
                                return WesternGreenCannon;
                            case StoneHelper.Stones.RedCannon:
                                return WesternRedCannon;
                            case StoneHelper.Stones.Chariot:
                                return WesternGreenChariot;
                            case StoneHelper.Stones.GreenChariot:
                                return WesternGreenChariot;
                            case StoneHelper.Stones.RedChariot:
                                return WesternRedChariot;
                            case StoneHelper.Stones.Advisor:
                                return WesternGreenAdvisor;
                            case StoneHelper.Stones.General:
                                return WesternGreenGeneral;
                            case StoneHelper.Stones.Green:
                                return WesternGreenPawn;
                            case StoneHelper.Stones.Red:
                                return WesternRedPawn;
                            default:
                                Debug.LogError("unknown piece: " + piece);
                                return None;
                        }
                    }
                case Setting.Style.Normal:
                default:
                    {
                        switch ((StoneHelper.Stones)piece)
                        {
                            case StoneHelper.Stones.Empty:
                                return None;
                            case StoneHelper.Stones.GreenPawn1:
                            case StoneHelper.Stones.GreenPawn2:
                            case StoneHelper.Stones.GreenPawn3:
                            case StoneHelper.Stones.GreenPawn4:
                            case StoneHelper.Stones.GreenPawn5:
                                return NormalGreenPawn;
                            case StoneHelper.Stones.GreenElephant1:
                            case StoneHelper.Stones.GreenElephant2:
                                return NormalGreenElephant;
                            case StoneHelper.Stones.GreenHorse1:
                            case StoneHelper.Stones.GreenHorse2:
                                return NormalGreenHorse;
                            case StoneHelper.Stones.GreenCannon1:
                            case StoneHelper.Stones.GreenCannon2:
                                return NormalGreenCannon;
                            case StoneHelper.Stones.GreenChariot1:
                            case StoneHelper.Stones.GreenChariot2:
                                return NormalGreenChariot;
                            case StoneHelper.Stones.GreenAdvisor1:
                            case StoneHelper.Stones.GreenAdvisor2:
                                return NormalGreenAdvisor;
                            case StoneHelper.Stones.GreenGeneral:
                                return NormalGreenGeneral;

                            case StoneHelper.Stones.RedPawn1:
                            case StoneHelper.Stones.RedPawn2:
                            case StoneHelper.Stones.RedPawn3:
                            case StoneHelper.Stones.RedPawn4:
                            case StoneHelper.Stones.RedPawn5:
                                return NormalRedPawn;
                            case StoneHelper.Stones.RedElephant1:
                            case StoneHelper.Stones.RedElephant2:
                                return NormalRedElephant;
                            case StoneHelper.Stones.RedHorse1:
                            case StoneHelper.Stones.RedHorse2:
                                return NormalRedHorse;
                            case StoneHelper.Stones.RedCannon1:
                            case StoneHelper.Stones.RedCannon2:
                                return NormalRedCannon;
                            case StoneHelper.Stones.RedChariot1:
                            case StoneHelper.Stones.RedChariot2:
                                return NormalRedChariot;
                            case StoneHelper.Stones.RedAdvisor1:
                            case StoneHelper.Stones.RedAdvisor2:
                                return NormalRedAdvisor;
                            case StoneHelper.Stones.RedGeneral:
                                return NormalRedGeneral;

                            case StoneHelper.Stones.Pawn:
                                return NormalGreenPawn;
                            case StoneHelper.Stones.GreenPawn:
                                return NormalGreenPawn;
                            case StoneHelper.Stones.RedPawn:
                                return NormalRedPawn;
                            case StoneHelper.Stones.Elephant:
                                return NormalGreenElephant;
                            case StoneHelper.Stones.Horse:
                                return NormalGreenHorse;
                            case StoneHelper.Stones.Cannon:
                                return NormalGreenCannon;
                            case StoneHelper.Stones.GreenCannon:
                                return NormalGreenCannon;
                            case StoneHelper.Stones.RedCannon:
                                return NormalRedCannon;
                            case StoneHelper.Stones.Chariot:
                                return NormalGreenChariot;
                            case StoneHelper.Stones.GreenChariot:
                                return NormalGreenChariot;
                            case StoneHelper.Stones.RedChariot:
                                return NormalRedChariot;
                            case StoneHelper.Stones.Advisor:
                                return NormalGreenAdvisor;
                            case StoneHelper.Stones.General:
                                return NormalGreenGeneral;
                            case StoneHelper.Stones.Green:
                                return NormalGreenPawn;
                            case StoneHelper.Stones.Red:
                                return NormalRedPawn;
                            default:
                                Debug.LogError("unknown piece: " + piece);
                                return None;
                        }
                    }
            }
        }

    }
}