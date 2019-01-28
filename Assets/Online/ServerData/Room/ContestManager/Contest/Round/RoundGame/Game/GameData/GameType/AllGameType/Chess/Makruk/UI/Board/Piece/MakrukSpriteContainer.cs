using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Makruk
{
	public class MakrukSpriteContainer : MonoBehaviour
	{

		private static MakrukSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static MakrukSpriteContainer get()
		{
			return instance;
		}

		public Sprite NoPiece;

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

        #region board background

        public Sprite NormalBoardBackground;
        public Sprite WesternBoardBackground;

        public void setBoardBackground(Setting.Style style, Image bg)
        {
            if (bg != null)
            {
                switch (style)
                {
                    case Setting.Style.Normal:
                        {
                            bg.sprite = NormalBoardBackground;
                            // transform
                            {
                                RectTransform rectTransform = (RectTransform)bg.transform;
                                if (rectTransform.sizeDelta.x != 8f || rectTransform.sizeDelta.y != 8f)
                                {
                                    rectTransform.sizeDelta = new Vector2(8, 8);
                                }
                            }
                        }
                        break;
                    case Setting.Style.Western:
                        {
                            bg.sprite = WesternBoardBackground;
                            // transform
                            {
                                RectTransform rectTransform = (RectTransform)bg.transform;
                                if (rectTransform.sizeDelta.x != 9.2f || rectTransform.sizeDelta.y != 9.2f)
                                {
                                    rectTransform.sizeDelta = new Vector2(9.2f, 9.2f);
                                }
                            }
                        }
                        break;
                    default:
                        Debug.LogError("unknown style: " + style);
                        break;
                }
            }
            else
            {
                Debug.LogError("bg null");
            }
        }

        #endregion

        public Sprite Unknown;

		public Sprite getSprite(Setting.Style style, Common.Piece piece)
		{
            switch (style)
            {
                case Setting.Style.Normal:
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
                default:
                    Debug.LogError("unknown style: "+style);
                    return NoPiece;
            }
		}

	}
}