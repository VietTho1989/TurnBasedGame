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
		public Sprite RedGeneral;
		public Sprite RedAdvisor;
		public Sprite RedElephant;
		public Sprite RedHorse;
		public Sprite RedChariot;
		public Sprite RedCannon;
		public Sprite RedPawn;
		public Sprite BlackGeneral;
		public Sprite BlackAdvisor;
		public Sprite BlackElephant;
		public Sprite BlackHorse;
		public Sprite BlackChariot;
		public Sprite BlackPawn;
		public Sprite BlackCannon;
		public Sprite Hidden;

		public Sprite getSprite(byte piece)
		{
			switch (piece) {
			case 0:
				return None;
			case Common.K:
				return RedGeneral;
			case Common.A:
				return RedAdvisor;
			case Common.B:
				return RedElephant;
			case Common.R:
				return RedChariot;
			case Common.C:
				return RedCannon;
			case Common.N:
				return RedHorse;
			case Common.P:
				return RedPawn;
			case Common.k:
				return BlackGeneral;
			case Common.a:
				return BlackAdvisor;
			case Common.b:
				return BlackElephant;
			case Common.r:
				return BlackChariot;
			case Common.c:
				return BlackCannon;
			case Common.n:
				return BlackHorse;
			case Common.p:
				return BlackPawn;
			default:
				return Hidden;
			}
		}

	}
}