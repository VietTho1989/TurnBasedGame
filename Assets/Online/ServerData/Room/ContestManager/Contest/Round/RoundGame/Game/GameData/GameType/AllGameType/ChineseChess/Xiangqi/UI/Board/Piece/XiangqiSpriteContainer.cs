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
		public Sprite BlackCannon;
		public Sprite BlackPawn;

		public Sprite getSprite(int piece) {
			switch (piece) {
			case (int)Common.Piece.None:
				return None;
			case (int)Common.Piece.RedGeneral:
				return RedGeneral;
			case (int)Common.Piece.RedAdvisor:
				return RedAdvisor;
			case (int)Common.Piece.RedElephant:
				return RedElephant;
			case (int)Common.Piece.RedHorse:
				return RedHorse;
			case (int)Common.Piece.RedChariot:
				return RedChariot;
			case (int)Common.Piece.RedCannon:
				return RedCannon;
			case (int)Common.Piece.RedPawn:
				return RedPawn;
			case (int)Common.Piece.BlackGeneral:
				return BlackGeneral;
			case (int)Common.Piece.BlackAdvisor:
				return BlackAdvisor;
			case (int)Common.Piece.BlackElephant:
				return BlackElephant;
			case (int)Common.Piece.BlackHorse:
				return BlackHorse;
			case (int)Common.Piece.BlackChariot:
				return BlackChariot;
			case (int)Common.Piece.BlackCannon:
				return BlackCannon;
			case (int)Common.Piece.BlackPawn:
				return BlackPawn;
			default:
				Debug.LogError ("unknown piece: " + piece);
				return None;
			}
		}

	}
}