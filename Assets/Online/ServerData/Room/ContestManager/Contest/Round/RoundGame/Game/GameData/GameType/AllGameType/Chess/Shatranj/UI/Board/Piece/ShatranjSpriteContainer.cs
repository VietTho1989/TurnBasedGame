using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
	public class ShatranjSpriteContainer : MonoBehaviour
	{

		private static ShatranjSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static ShatranjSpriteContainer get()
		{
			return instance;
		}

		public Sprite NoPiece;

        #region Western

        public Sprite WesternWPawn;
		public Sprite WesternWKnight;
		public Sprite WesternWBishop;
		public Sprite WesternWRook;
		public Sprite WesternWQueen;
		public Sprite WesternWKing;

		public Sprite WesternBPawn;
		public Sprite WesternBKnight;
		public Sprite WesternBBishop;
		public Sprite WesternBRook;
		public Sprite WesternBQueen;
		public Sprite WesternBKing;

        #endregion

        #region Normal

        public Sprite NormalWPawn;
        public Sprite NormalWKnight;
        public Sprite NormalWBishop;
        public Sprite NormalWRook;
        public Sprite NormalWQueen;
        public Sprite NormalWKing;

        public Sprite NormalBPawn;
        public Sprite NormalBKnight;
        public Sprite NormalBBishop;
        public Sprite NormalBRook;
        public Sprite NormalBQueen;
        public Sprite NormalBKing;

        #endregion

        public Sprite Unknown;

		public Sprite getSprite(Common.Piece piece, Setting.Style style)
		{
            switch (style)
            {
                case Setting.Style.Western:
                    {
                        switch (piece)
                        {
                            case Common.Piece.NO_PIECE:
                                return NoPiece;
                            case Common.Piece.W_PAWN:
                                return WesternWPawn;
                            case Common.Piece.W_KNIGHT:
                                return WesternWKnight;
                            case Common.Piece.W_BISHOP:
                                return WesternWBishop;
                            case Common.Piece.W_ROOK:
                                return WesternWRook;
                            case Common.Piece.W_QUEEN:
                                return WesternWQueen;
                            case Common.Piece.W_KING:
                                return WesternWKing;
                            case Common.Piece.B_PAWN:
                                return WesternBPawn;
                            case Common.Piece.B_KNIGHT:
                                return WesternBKnight;
                            case Common.Piece.B_BISHOP:
                                return WesternBBishop;
                            case Common.Piece.B_ROOK:
                                return WesternBRook;
                            case Common.Piece.B_QUEEN:
                                return WesternBQueen;
                            case Common.Piece.B_KING:
                                return WesternBKing;
                            default:
                                Debug.LogError("unknown piece type: " + piece + ", " + this);
                                return Unknown;
                        }
                    }
                case Setting.Style.Normal:
                default:
                    {
                        switch (piece)
                        {
                            case Common.Piece.NO_PIECE:
                                return NoPiece;
                            case Common.Piece.W_PAWN:
                                return NormalWPawn;
                            case Common.Piece.W_KNIGHT:
                                return NormalWKnight;
                            case Common.Piece.W_BISHOP:
                                return NormalWBishop;
                            case Common.Piece.W_ROOK:
                                return NormalWRook;
                            case Common.Piece.W_QUEEN:
                                return NormalWQueen;
                            case Common.Piece.W_KING:
                                return NormalWKing;
                            case Common.Piece.B_PAWN:
                                return NormalBPawn;
                            case Common.Piece.B_KNIGHT:
                                return NormalBKnight;
                            case Common.Piece.B_BISHOP:
                                return NormalBBishop;
                            case Common.Piece.B_ROOK:
                                return NormalBRook;
                            case Common.Piece.B_QUEEN:
                                return NormalBQueen;
                            case Common.Piece.B_KING:
                                return NormalBKing;
                            default:
                                Debug.LogError("unknown piece type: " + piece + ", " + this);
                                return Unknown;
                        }
                    }
            }
		}

	}
}