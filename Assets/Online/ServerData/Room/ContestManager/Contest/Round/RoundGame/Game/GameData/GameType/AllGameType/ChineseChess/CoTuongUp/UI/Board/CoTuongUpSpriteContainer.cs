using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp
{
	public class CoTuongUpSpriteContainer : MonoBehaviour
	{

		private static CoTuongUpSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static CoTuongUpSpriteContainer get()
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

		public Sprite getSprite(byte piece, Setting.Style style)
		{
            switch (style)
            {
                case Setting.Style.Western:
                    {
                        switch (piece)
                        {
                            case 0:
                                return None;
                            case Common.K:
                                return WesternRedGeneral;
                            case Common.A:
                                return WesternRedAdvisor;
                            case Common.B:
                                return WesternRedElephant;
                            case Common.R:
                                return WesternRedChariot;
                            case Common.C:
                                return WesternRedCannon;
                            case Common.N:
                                return WesternRedHorse;
                            case Common.P:
                                return WesternRedPawn;
                            case Common.k:
                                return WesternBlackGeneral;
                            case Common.a:
                                return WesternBlackAdvisor;
                            case Common.b:
                                return WesternBlackElephant;
                            case Common.r:
                                return WesternBlackChariot;
                            case Common.c:
                                return WesternBlackCannon;
                            case Common.n:
                                return WesternBlackHorse;
                            case Common.p:
                                return WesternBlackPawn;
                            default:
                                return Hidden;
                        }
                    }
                case Setting.Style.Normal:
                default:
                    {
                        switch (piece)
                        {
                            case 0:
                                return None;
                            case Common.K:
                                return NormalRedGeneral;
                            case Common.A:
                                return NormalRedAdvisor;
                            case Common.B:
                                return NormalRedElephant;
                            case Common.R:
                                return NormalRedChariot;
                            case Common.C:
                                return NormalRedCannon;
                            case Common.N:
                                return NormalRedHorse;
                            case Common.P:
                                return NormalRedPawn;
                            case Common.k:
                                return NormalBlackGeneral;
                            case Common.a:
                                return NormalBlackAdvisor;
                            case Common.b:
                                return NormalBlackElephant;
                            case Common.r:
                                return NormalBlackChariot;
                            case Common.c:
                                return NormalBlackCannon;
                            case Common.n:
                                return NormalBlackHorse;
                            case Common.p:
                                return NormalBlackPawn;
                            default:
                                return Hidden;
                        }
                    }
            }
		}

	}
}