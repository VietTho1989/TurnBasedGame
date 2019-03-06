using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiSpriteContainer : MonoBehaviour
	{

		private static XiangqiSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static XiangqiSpriteContainer get()
		{
			return instance;
		}

		public Sprite None;

        #region normal

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
		public Sprite NormalBlackCannon;
		public Sprite NormalBlackPawn;

        #endregion

        #region western

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
        public Sprite WesternBlackCannon;
        public Sprite WesternBlackPawn;

        #endregion

        public Sprite getSprite(int piece, Setting.Style style) {
            switch (style)
            {
                case Setting.Style.Western:
                    {
                        switch (piece)
                        {
                            case (int)Common.Piece.None:
                                return None;
                            case (int)Common.Piece.RedGeneral:
                                return WesternRedGeneral;
                            case (int)Common.Piece.RedAdvisor:
                                return WesternRedAdvisor;
                            case (int)Common.Piece.RedElephant:
                                return WesternRedElephant;
                            case (int)Common.Piece.RedHorse:
                                return WesternRedHorse;
                            case (int)Common.Piece.RedChariot:
                                return WesternRedChariot;
                            case (int)Common.Piece.RedCannon:
                                return WesternRedCannon;
                            case (int)Common.Piece.RedPawn:
                                return WesternRedPawn;
                            case (int)Common.Piece.BlackGeneral:
                                return WesternBlackGeneral;
                            case (int)Common.Piece.BlackAdvisor:
                                return WesternBlackAdvisor;
                            case (int)Common.Piece.BlackElephant:
                                return WesternBlackElephant;
                            case (int)Common.Piece.BlackHorse:
                                return WesternBlackHorse;
                            case (int)Common.Piece.BlackChariot:
                                return WesternBlackChariot;
                            case (int)Common.Piece.BlackCannon:
                                return WesternBlackCannon;
                            case (int)Common.Piece.BlackPawn:
                                return WesternBlackPawn;
                            default:
                                Debug.LogError("unknown piece: " + piece);
                                return None;
                        }
                    }
                case Setting.Style.Normal:
                default:
                    {
                        switch (piece)
                        {
                            case (int)Common.Piece.None:
                                return None;
                            case (int)Common.Piece.RedGeneral:
                                return NormalRedGeneral;
                            case (int)Common.Piece.RedAdvisor:
                                return NormalRedAdvisor;
                            case (int)Common.Piece.RedElephant:
                                return NormalRedElephant;
                            case (int)Common.Piece.RedHorse:
                                return NormalRedHorse;
                            case (int)Common.Piece.RedChariot:
                                return NormalRedChariot;
                            case (int)Common.Piece.RedCannon:
                                return NormalRedCannon;
                            case (int)Common.Piece.RedPawn:
                                return NormalRedPawn;
                            case (int)Common.Piece.BlackGeneral:
                                return NormalBlackGeneral;
                            case (int)Common.Piece.BlackAdvisor:
                                return NormalBlackAdvisor;
                            case (int)Common.Piece.BlackElephant:
                                return NormalBlackElephant;
                            case (int)Common.Piece.BlackHorse:
                                return NormalBlackHorse;
                            case (int)Common.Piece.BlackChariot:
                                return NormalBlackChariot;
                            case (int)Common.Piece.BlackCannon:
                                return NormalBlackCannon;
                            case (int)Common.Piece.BlackPawn:
                                return NormalBlackPawn;
                            default:
                                Debug.LogError("unknown piece: " + piece);
                                return None;
                        }
                    }
            }
		}

	}
}