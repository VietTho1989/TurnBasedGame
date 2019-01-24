using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtPieceSprite : MonoBehaviour
	{

		private static RussianDraughtPieceSprite instance;

		void Awake() {
			instance = this;
		}

		public static RussianDraughtPieceSprite get()
		{
			return instance;
		}

		public Sprite Free;

		public Sprite WhiteMan;
		public Sprite WhiteKing;
		public Sprite BlackMan;
		public Sprite BlackKing;

		public Sprite getSprite(int piece)
		{
			switch (piece) {
			case Common.WHT_MAN:
				return WhiteMan;
			case Common.WHT_KNG:
				return WhiteKing;
			case Common.BLK_MAN:
				return BlackMan;
			case Common.BLK_KNG:
				return BlackKing;
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
			case Common.WHT_MAN:
				return DeadWhiteMan;
			case Common.WHT_KNG:
				return DeadWhiteKing;
			case Common.BLK_MAN:
				return DeadBlackMan;
			case Common.BLK_KNG:
				return DeadBlackKing;
			default:
				return Free;
			}
		}

	}
}