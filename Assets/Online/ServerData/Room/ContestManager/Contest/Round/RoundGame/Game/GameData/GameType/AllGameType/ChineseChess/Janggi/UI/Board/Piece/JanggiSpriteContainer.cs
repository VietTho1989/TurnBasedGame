using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class JanggiSpriteContainer : MonoBehaviour
	{

		private static JanggiSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static JanggiSpriteContainer get()
		{
			return instance;
		}

		public Sprite None;

		public Sprite GreenGeneral;
		public Sprite GreenAdvisor;
		public Sprite GreenElephant;
		public Sprite GreenHorse;
		public Sprite GreenChariot;
		public Sprite GreenCannon;
		public Sprite GreenPawn;

		public Sprite RedGeneral;
		public Sprite RedAdvisor;
		public Sprite RedElephant;
		public Sprite RedHorse;
		public Sprite RedChariot;
		public Sprite RedCannon;
		public Sprite RedPawn;

		public Sprite getSprite(uint piece) {
			switch ((StoneHelper.Stones)piece) {
			case StoneHelper.Stones.Empty:
				return None;
			case StoneHelper.Stones.GreenPawn1:
			case StoneHelper.Stones.GreenPawn2:
			case StoneHelper.Stones.GreenPawn3:
			case StoneHelper.Stones.GreenPawn4:
			case StoneHelper.Stones.GreenPawn5:
				return GreenPawn;
			case StoneHelper.Stones.GreenElephant1:
			case StoneHelper.Stones.GreenElephant2:
				return GreenElephant;
			case StoneHelper.Stones.GreenHorse1:
			case StoneHelper.Stones.GreenHorse2:
				return GreenHorse;
			case StoneHelper.Stones.GreenCannon1:
			case StoneHelper.Stones.GreenCannon2:
				return GreenCannon;
			case StoneHelper.Stones.GreenChariot1:
			case StoneHelper.Stones.GreenChariot2:
				return GreenChariot;
			case StoneHelper.Stones.GreenAdvisor1:
			case StoneHelper.Stones.GreenAdvisor2:
				return GreenAdvisor;
			case StoneHelper.Stones.GreenGeneral:
				return GreenGeneral;

			case StoneHelper.Stones.RedPawn1:
			case StoneHelper.Stones.RedPawn2:
			case StoneHelper.Stones.RedPawn3:
			case StoneHelper.Stones.RedPawn4:
			case StoneHelper.Stones.RedPawn5:
				return RedPawn;
			case StoneHelper.Stones.RedElephant1:
			case StoneHelper.Stones.RedElephant2:
				return RedElephant;
			case StoneHelper.Stones.RedHorse1:
			case StoneHelper.Stones.RedHorse2:
				return RedHorse;
			case StoneHelper.Stones.RedCannon1:
			case StoneHelper.Stones.RedCannon2:
				return RedCannon;
			case StoneHelper.Stones.RedChariot1:
			case StoneHelper.Stones.RedChariot2:
				return RedChariot;
			case StoneHelper.Stones.RedAdvisor1:
			case StoneHelper.Stones.RedAdvisor2:
				return RedAdvisor;
			case StoneHelper.Stones.RedGeneral:
				return RedGeneral;

			case StoneHelper.Stones.Pawn:
				return GreenPawn;
			case StoneHelper.Stones.GreenPawn:
				return GreenPawn;
			case StoneHelper.Stones.RedPawn:
				return RedPawn;
			case StoneHelper.Stones.Elephant:
				return GreenElephant;
			case StoneHelper.Stones.Horse:
				return GreenHorse;
			case StoneHelper.Stones.Cannon:
				return GreenCannon;
			case StoneHelper.Stones.GreenCannon:
				return GreenCannon;
			case StoneHelper.Stones.RedCannon:
				return RedCannon;
			case StoneHelper.Stones.Chariot:
				return GreenChariot;
			case StoneHelper.Stones.GreenChariot:
				return GreenChariot;
			case StoneHelper.Stones.RedChariot:
				return RedChariot;
			case StoneHelper.Stones.Advisor:
				return GreenAdvisor;
			case StoneHelper.Stones.General:
				return GreenGeneral;
			case StoneHelper.Stones.Green:
				return GreenPawn;
			case StoneHelper.Stones.Red:
				return RedPawn;
			default:
				Debug.LogError ("unknown piece: " + piece);
				return None;
			}
		}

	}
}