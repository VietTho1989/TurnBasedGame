using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
	public class SeirawanSpriteContainer : MonoBehaviour
	{

		private static SeirawanSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static SeirawanSpriteContainer get()
		{
			return instance;
		}

		public Sprite NoPiece;

		public Sprite WPawn;
		public Sprite WKnight;
		public Sprite WBishop;
		public Sprite WRook;
		public Sprite WQueen;
		public Sprite WKing;
		public Sprite WElephant;
		public Sprite WHawk;

		public Sprite BPawn;
		public Sprite BKnight;
		public Sprite BBishop;
		public Sprite BRook;
		public Sprite BQueen;
		public Sprite BKing;
		public Sprite BElephant;
		public Sprite BHawk;

		public Sprite Unknown;

		public Sprite getSprite(Common.Piece piece){
			switch (piece) {
			case Common.Piece.NO_PIECE:
				return NoPiece;
			case Common.Piece.W_PAWN:
				return WPawn;
			case Common.Piece.W_KNIGHT:
				return WKnight;
			case Common.Piece.W_BISHOP:
				return WBishop;
			case Common.Piece.W_ROOK:
				return WRook;
			case Common.Piece.W_QUEEN:
				return WQueen;
			case Common.Piece.W_KING:
				return WKing;
			case Common.Piece.W_ELEPHANT:
				return WElephant;
			case Common.Piece.W_HAWK:
				return WHawk;
			case Common.Piece.B_PAWN:
				return BPawn;
			case Common.Piece.B_KNIGHT:
				return BKnight;
			case Common.Piece.B_BISHOP:
				return BBishop;
			case Common.Piece.B_ROOK:
				return BRook;
			case Common.Piece.B_QUEEN:
				return BQueen;
			case Common.Piece.B_KING:
				return BKing;
			case Common.Piece.B_ELEPHANT:
				return BElephant;
			case Common.Piece.B_HAWK:
				return BHawk;
			default:
				return Unknown;
			}
		}

	}
}