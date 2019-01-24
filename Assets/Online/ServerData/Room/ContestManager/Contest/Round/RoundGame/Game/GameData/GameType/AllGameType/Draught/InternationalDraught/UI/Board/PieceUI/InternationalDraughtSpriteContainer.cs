using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class InternationalDraughtSpriteContainer : MonoBehaviour
	{

		private static InternationalDraughtSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static InternationalDraughtSpriteContainer get()
		{
			return instance;
		}

		public Sprite Free;
		public Sprite WhiteMan;
		public Sprite WhiteKing;
		public Sprite BlackMan;
		public Sprite BlackKing;

		public Sprite getSprite(int pieceSide)
		{
			switch (pieceSide) {
			case (int)Common.Piece_Side.White_Man:
				return WhiteMan;
			case (int)Common.Piece_Side.Black_Man:
				return BlackMan;
			case (int)Common.Piece_Side.White_King:
				return WhiteKing;
			case (int)Common.Piece_Side.Black_King:
				return BlackKing;
			case (int)Common.Piece_Side.Empty:
				return Free;
			default:
				Debug.LogError ("unknown piece side: " + pieceSide + "; " + this);
				return Free;
			}
		}

		public Sprite DeadWhiteMan;
		public Sprite DeadWhiteKing;
		public Sprite DeadBlackMan;
		public Sprite DeadBlackKing;

		public Sprite getDeadSprite(int pieceSide)
		{
			switch (pieceSide) {
			case (int)Common.Piece_Side.White_Man:
				return DeadWhiteMan;
			case (int)Common.Piece_Side.Black_Man:
				return DeadBlackMan;
			case (int)Common.Piece_Side.White_King:
				return DeadWhiteKing;
			case (int)Common.Piece_Side.Black_King:
				return DeadBlackKing;
			case (int)Common.Piece_Side.Empty:
				return Free;
			default:
				Debug.LogError ("unknown piece side: " + pieceSide + "; " + this);
				return Free;
			}
		}

	}
}