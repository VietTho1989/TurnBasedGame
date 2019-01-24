using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FairyChess
{
	public class SpriteContainer : MonoBehaviour 
	{

		private static SpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static SpriteContainer get()
		{
			return instance;
		}

		public Sprite Transparent;

		public Sprite WhitePawn; 
		public Sprite WhiteKnight; 
		public Sprite WhiteBishop; 
		public Sprite WhiteRook;
		public Sprite WhiteQueen; 
		public Sprite WhiteFers; 
		public Sprite WhiteMet; 
		public Sprite WhiteAlfil; 
		public Sprite WhiteSilver; 
		public Sprite WhiteKhon;
		public Sprite WhiteAiwok;
		public Sprite WhiteBers;
		public Sprite WhiteDragon;
		public Sprite WhiteChancellor;
		public Sprite WhiteAmazon;
		public Sprite WhiteKnibis;
		public Sprite WhiteBiskni;
		public Sprite WhiteShogiPawn;
		public Sprite WhiteLance;
		public Sprite WhiteShogiKnight;
		public Sprite WhiteEuroShogiKnight;
		public Sprite WhiteGold;
		public Sprite WhiteHorse;
		public Sprite WhiteCommoner;
		public Sprite WhiteKing;

		public Sprite BlackPawn; 
		public Sprite BlackKnight; 
		public Sprite BlackBishop; 
		public Sprite BlackRook;
		public Sprite BlackQueen; 
		public Sprite BlackFers; 
		public Sprite BlackMet; 
		public Sprite BlackAlfil; 
		public Sprite BlackSilver; 
		public Sprite BlackKhon;
		public Sprite BlackAiwok;
		public Sprite BlackBers;
		public Sprite BlackDragon;
		public Sprite BlackChancellor;
		public Sprite BlackAmazon;
		public Sprite BlackKnibis;
		public Sprite BlackBiskni;
		public Sprite BlackShogiPawn;
		public Sprite BlackLance;
		public Sprite BlackShogiKnight;
		public Sprite BlackEuroShogiKnight;
		public Sprite BlackGold;
		public Sprite BlackHorse;
		public Sprite BlackCommoner;
		public Sprite BlackKing;

		public static void setImagePiece(Image image, Common.VariantType variantType, Common.Color color, Common.PieceType pieceType)
		{
			if (image != null) {
				if (pieceType == Common.PieceType.NO_PIECE_TYPE || pieceType == Common.PieceType.ALL_PIECES || pieceType == Common.PieceType.PIECE_TYPE_NB) {
					image.sprite = SpriteContainer.get().Transparent;
					return;
				}
				switch (variantType) {
				case Common.VariantType.chess:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + color + "; " + image);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.standard:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.makruk:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.KHON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKhon : SpriteContainer.get().BlackKhon;
							break;
						case Common.PieceType.MET:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteMet : SpriteContainer.get().BlackMet;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType );
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.asean:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.KHON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKhon : SpriteContainer.get().BlackKhon;
							break;
						case Common.PieceType.MET:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteMet : SpriteContainer.get().BlackMet;
							break;
						default:
							// Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.ai_wok:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.KHON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKhon : SpriteContainer.get().BlackKhon;
							break;
						case Common.PieceType.AIWOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteAiwok : SpriteContainer.get().BlackAiwok;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.shatranj:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.ALFIL:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteAlfil : SpriteContainer.get().BlackAlfil;
							break;
						case Common.PieceType.FERS:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteFers : SpriteContainer.get().BlackFers;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.amazon:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.AMAZON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteAmazon : SpriteContainer.get().BlackAmazon;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.hoppelpoppel:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.KNIBIS:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnibis : SpriteContainer.get().BlackKnibis;
							break;
						case Common.PieceType.BISKNI:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBiskni : SpriteContainer.get().BlackBiskni;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.kingofthehill:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType );
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.racingkings:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType );
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.losers:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.giveaway:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.COMMONER:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteCommoner : SpriteContainer.get().BlackCommoner;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.antichess:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.COMMONER:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteCommoner : SpriteContainer.get().BlackCommoner;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.extinction:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.COMMONER:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteCommoner : SpriteContainer.get().BlackCommoner;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.kinglet:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.COMMONER:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteCommoner : SpriteContainer.get().BlackCommoner;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.three_check:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.five_check:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.crazyhouse:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.loop:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType );
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.chessgi:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.pocketknight:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.euroshogi:
					{
						switch (pieceType) {
						case Common.PieceType.SHOGI_PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteShogiPawn : SpriteContainer.get().BlackShogiPawn;
							break;
						case Common.PieceType.EUROSHOGI_KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteEuroShogiKnight : SpriteContainer.get().BlackEuroShogiKnight;
							break;
						case Common.PieceType.GOLD:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteGold : SpriteContainer.get().BlackGold;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.HORSE:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteHorse : SpriteContainer.get().BlackHorse;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.DRAGON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteDragon : SpriteContainer.get().BlackDragon;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.judkinshogi:
					{
						switch (pieceType) {
						case Common.PieceType.SHOGI_PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteShogiPawn : SpriteContainer.get().BlackShogiPawn;
							break;
						case Common.PieceType.SHOGI_KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteShogiKnight : SpriteContainer.get().BlackShogiKnight;
							break;
						case Common.PieceType.SILVER:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteSilver : SpriteContainer.get().BlackSilver;
							break;
						case Common.PieceType.GOLD:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteGold : SpriteContainer.get().BlackGold;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.HORSE:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteHorse : SpriteContainer.get().BlackHorse;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.DRAGON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteDragon : SpriteContainer.get().BlackDragon;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.minishogi:
					{
						switch (pieceType) {
						case Common.PieceType.SHOGI_PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteShogiPawn : SpriteContainer.get().BlackShogiPawn;
							break;
						case Common.PieceType.SILVER:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteSilver : SpriteContainer.get().BlackSilver;
							break;
						case Common.PieceType.GOLD:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteGold : SpriteContainer.get().BlackGold;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.HORSE:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteHorse : SpriteContainer.get().BlackHorse;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.DRAGON:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteDragon : SpriteContainer.get().BlackDragon;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.losalamos:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.almost:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.CHANCELLOR:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteChancellor : SpriteContainer.get().BlackChancellor;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.chigorin:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.QUEEN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteQueen : SpriteContainer.get().BlackQueen;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.CHANCELLOR:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteChancellor : SpriteContainer.get().BlackChancellor;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				case Common.VariantType.shatar:
					{
						switch (pieceType) {
						case Common.PieceType.PAWN:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhitePawn : SpriteContainer.get().BlackPawn;
							break;
						case Common.PieceType.KNIGHT:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKnight : SpriteContainer.get().BlackKnight;
							break;
						case Common.PieceType.BISHOP:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBishop : SpriteContainer.get().BlackBishop;
							break;
						case Common.PieceType.ROOK:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteRook : SpriteContainer.get().BlackRook;
							break;
						case Common.PieceType.KING:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteKing : SpriteContainer.get().BlackKing;
							break;
						case Common.PieceType.BERS:
							image.sprite = color == Common.Color.WHITE ? SpriteContainer.get().WhiteBers : SpriteContainer.get().BlackBers;
							break;
						default:
							Debug.LogError ("unknown pieceType: " + pieceType);
							image.sprite = SpriteContainer.get().Transparent;
							break;
						}
					}
					break;
				default:
					Debug.LogError ("unknown variantType: " + pieceType);
					break;
				}
			} else {
				Debug.LogError ("image null");
			}
		}

	}
}