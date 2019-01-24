using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
	public class ReversiSpriteContainer : MonoBehaviour
	{

		private static ReversiSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static ReversiSpriteContainer get()
		{
			return instance;
		}

		public Sprite none;
		public Sprite white;
		public Sprite black;

		public Sprite getSprite(int pieceType)
		{
			switch (pieceType) {
			case Reversi.WHITE:
				return white;
			case Reversi.BLACK:
				return black;
			default:
				Debug.LogError ("unknown pieceType: " + pieceType);
				return none;
			}
		}

	}
}