using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class EnglishDraughtSpriteContainer : MonoBehaviour
	{

		private static EnglishDraughtSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static EnglishDraughtSpriteContainer get()
		{
			return instance;
		}

		public Sprite Free;
		public Sprite WhiteMan;
		public Sprite WhiteKing;
		public Sprite BlackMan;
		public Sprite BlackKing;

		public Sprite getSprite(byte piece)
		{
			switch (piece) {
			case Common.BPIECE:
				return BlackMan;
			case Common.BKING:
				return BlackKing;
			case Common.WPIECE:
				return WhiteMan;
			case Common.WKING:
				return WhiteKing;
			default:
				return Free;
			}
		}

		public Sprite DeadWhiteMan;
		public Sprite DeadWhiteKing;
		public Sprite DeadBlackMan;
		public Sprite DeadBlackKing;

		public Sprite getDeadSprite(int piece)
		{
			switch (piece) {
			case Common.BPIECE:
				return DeadBlackMan;
			case Common.BKING:
				return DeadBlackKing;
			case Common.WPIECE:
				return DeadWhiteMan;
			case Common.WKING:
				return DeadWhiteKing;
			default:
				return Free;
			}
		}

	}
}