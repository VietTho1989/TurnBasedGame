using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shogi
{
	public class SpriteWestern : MonoBehaviour, ShogiGameDataUI.UIData.StyleInterface 
	{

		// private static bool log = false;

		public Sprite BPawn;
		public Sprite BLance;
		public Sprite BKnight;
		public Sprite BSilver;
		public Sprite BBishop;
		public Sprite BRook;
		public Sprite BGold;
		public Sprite BKing;
		public Sprite BProPawn;
		public Sprite BProLance;
		public Sprite BProKnight;
		public Sprite BProSilver;
		public Sprite BHorse;
		public Sprite BDragon;

		public Sprite WPawn;
		public Sprite WLance;
		public Sprite WKnight;
		public Sprite WSilver; 
		public Sprite WBishop;
		public Sprite WRook;
		public Sprite WGold;
		public Sprite WKing;
		public Sprite WProPawn;
		public Sprite WProLance;
		public Sprite WProKnight;
		public Sprite WProSilver;
		public Sprite WHorse;
		public Sprite WDragon;

		public Sprite PieceNone;

		public Sprite getSpriteForHandPiece (Common.HandPiece handPiece, Common.Color color)
		{
			switch (color) {
			case Common.Color.Black:
				{
					switch (handPiece) {
					case Common.HandPiece.HPawn:
						return BPawn;
					case Common.HandPiece.HLance:
						return BLance;
					case Common.HandPiece.HKnight:
						return BKnight;
					case Common.HandPiece.HSilver:
						return BSilver;
					case Common.HandPiece.HGold:
						return BGold;
					case Common.HandPiece.HBishop:
						return BBishop;
					case Common.HandPiece.HRook:
						return BRook;
					default:
						Debug.LogError ("unknown handPiece: " + handPiece + "; " + this);
						return PieceNone;
					}
				}
			case Common.Color.White:
				{
					switch (handPiece) {
					case Common.HandPiece.HPawn:
						return WPawn;
					case Common.HandPiece.HLance:
						return WLance;
					case Common.HandPiece.HKnight:
						return WKnight;
					case Common.HandPiece.HSilver:
						return WSilver;
					case Common.HandPiece.HGold:
						return WGold;
					case Common.HandPiece.HBishop:
						return WBishop;
					case Common.HandPiece.HRook:
						return WRook;
					default:
						Debug.LogError ("unknown handPiece: " + handPiece + "; " + this);
						return PieceNone;
					}
				}
			default:
				Debug.LogError ("unknown color: " + color + "; " + this);
				return PieceNone;
			}	
		}

		public Sprite getSprite(Common.Piece piece)
		{
			switch (piece) {
			case Common.Piece.BPawn:
				return BPawn;
			case Common.Piece.BLance:
				return BLance;
			case Common.Piece.BKnight: 
				return BKnight;
			case Common.Piece.BSilver:
				return BSilver;
			case Common.Piece.BBishop:
				return BBishop;
			case Common.Piece.BRook:
				return BRook;
			case Common.Piece.BGold:
				return BGold;
			case Common.Piece.BKing:
				return BKing;
			case Common.Piece.BProPawn:
				return BProPawn;
			case Common.Piece.BProLance:
				return BProLance;
			case Common.Piece.BProKnight:
				return BProKnight;
			case Common.Piece.BProSilver:
				return BProSilver;
			case Common.Piece.BHorse:
				return BHorse;
			case Common.Piece.BDragon:
				return BDragon;
			case Common.Piece.WPawn:
				return WPawn;
			case Common.Piece.WLance:
				return WLance;
			case Common.Piece.WKnight:
				return WKnight;
			case Common.Piece.WSilver:
				return WSilver;
			case Common.Piece.WBishop:
				return WBishop;
			case Common.Piece.WRook:
				return WRook;
			case Common.Piece.WGold:
				return WGold;
			case Common.Piece.WKing:
				return WKing;
			case Common.Piece.WProPawn:
				return WProPawn;
			case Common.Piece.WProLance:
				return WProLance;
			case Common.Piece.WProKnight:
				return WProKnight;
			case Common.Piece.WProSilver:
				return WProSilver;
			case Common.Piece.WHorse:
				return WHorse;
			case Common.Piece.WDragon:
				return WDragon;
			default:
				// Debug.LogError ("unknown piece type: " + piece + ", " + this);
				return PieceNone;
			}
		}

	}

}