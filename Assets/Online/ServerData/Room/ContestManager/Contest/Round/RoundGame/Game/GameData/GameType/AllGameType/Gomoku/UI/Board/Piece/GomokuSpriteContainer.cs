using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku
{
	public class GomokuSpriteContainer : MonoBehaviour
	{

		private static GomokuSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static GomokuSpriteContainer get()
		{
			return instance;
		}

		public Sprite None;
		public Sprite Black;
		public Sprite White;

		public Sprite getSprite(Common.Type type) {
			switch (type) {
			case Common.Type.None:
				return None;
			case Common.Type.Black:
				return Black;
			case Common.Type.White:
				return White;
			default:
				Debug.LogError ("unknown type: " + type + "; " + this);
				return None;
			}
		}

	}
}