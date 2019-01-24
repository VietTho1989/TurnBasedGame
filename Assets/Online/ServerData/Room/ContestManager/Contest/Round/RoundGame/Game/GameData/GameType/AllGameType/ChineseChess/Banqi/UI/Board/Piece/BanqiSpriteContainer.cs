using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BanqiSpriteContainer : MonoBehaviour
	{

		private static BanqiSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static BanqiSpriteContainer get()
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

		public Sprite getSprite(Token.Type type, Token.Ecolor color)
		{
			switch (color) {
			case Token.Ecolor.RED:
				{
					switch (type) {
					case Token.Type.GENERAL:
						return RedGeneral;
					case Token.Type.ADVISOR:
						return RedAdvisor;
					case Token.Type.ELEPHANT:
						return RedElephant;
					case Token.Type.CHARIOT:
						return RedChariot;
					case Token.Type.HORSE:
						return RedHorse;
					case Token.Type.CANNON:
						return RedCannon;
					case Token.Type.SOLDIER:
						return RedPawn;
					default:
						Debug.LogError ("unknown type: " + type);
						return None;
					}
				}
				// break;
			case Token.Ecolor.BLACK:
				{
					switch (type) {
					case Token.Type.GENERAL:
						return BlackGeneral;
					case Token.Type.ADVISOR:
						return BlackAdvisor;
					case Token.Type.ELEPHANT:
						return BlackElephant;
					case Token.Type.CHARIOT:
						return BlackChariot;
					case Token.Type.HORSE:
						return BlackHorse;
					case Token.Type.CANNON:
						return BlackCannon;
					case Token.Type.SOLDIER:
						return BlackPawn;
					default:
						Debug.LogError ("unknown type: " + type);
						return None;
					}
				}
				// break;
			default:
				Debug.LogError ("unknown color: " + color);
				return None;
			}
		}

	}
}