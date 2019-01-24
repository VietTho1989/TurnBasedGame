using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class WeiqiSpriteContainer : MonoBehaviour
	{

		private static WeiqiSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static WeiqiSpriteContainer get()
		{
			return instance;
		}

		public Sprite none;
		public Sprite black;
		public Sprite white;

		public Sprite getSprite(Common.stone color) {
			switch (color) {
			case Common.stone.S_BLACK:
				return black;
			case Common.stone.S_WHITE:
				return white;
			default:
				return none;
			}
		}

	}
}