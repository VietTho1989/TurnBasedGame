using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class NineMenMorrisSpriteContainer : MonoBehaviour
	{

		private static NineMenMorrisSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static NineMenMorrisSpriteContainer get()
		{
			return instance;
		}

		public Sprite Empty;
		public Sprite Black;
		public Sprite White;

		public Sprite getSprite(Common.SpotStatus piece)
		{
			switch (piece) {
			case Common.SpotStatus.SS_Empty:
				return Empty;
			case Common.SpotStatus.SS_Black:
				return Black;
			case Common.SpotStatus.SS_White:
				return White;
			default:
				Debug.LogError ("unknown piece type: " + piece + ", " + this);
				return Empty;
			}
		}

	}
}