using UnityEngine;
using System.Collections;

namespace Shogi
{
	public class ShogiMove : GameMove
	{
		public VP<System.UInt32> move;

		#region Constructor

		public enum Property
		{
			move
		}

		public ShogiMove() : base()
		{
			this.move = new VP<uint> (this, (byte)Property.move, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.ShogiMove;
		}

		public override string print ()
		{
			return Common.printMove (this.move.v);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Shogi) {
				Shogi shogi = gameType as Shogi;
				// Make animation
				ShogiMoveAnimation shogiMoveAnimation = new ShogiMoveAnimation();
				{
					shogiMoveAnimation.piece.vs.AddRange (shogi.piece.vs);
					shogiMoveAnimation.hand.vs.AddRange (shogi.hand.vs);
					shogiMoveAnimation.move.v = this.move.v;
				}
				return shogiMoveAnimation;
			} else {
				Debug.LogError ("unknown gameType: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

		/*public override string ToString ()
		{
			return string.Format ("[ShogiMove: {0}]", Common.printMove (this.move.v));
		}*/

		#region get information

		const System.UInt32 PromoteFlag = 1 << 14;

		// 移動先
		public Common.Square to() 
		{ 
			return (Common.Square)((this.move.v >> 0) & 0x7f);
		}

		// 移動元
		public Common.Square from()
		{
			return (Common.Square)((this.move.v >> 7) & 0x7f);
		}

		// 移動元、移動先
		public System.UInt32 fromAndTo()
		{
			return (this.move.v >> 0) & 0x3fff;
		}

		// 成り、移動元、移動先
		public System.UInt32 proFromAndTo()
		{
			return (this.move.v >> 0) & 0x7fff;
		}

		// 取った駒の種類
		public Common.PieceType cap()
		{
			return (Common.PieceType)((this.move.v >> 20) & 0xf);
		}

		// 成るかどうか
		public System.UInt32 isPromotion()
		{
			return this.move.v & PromoteFlag;
		}

		// 移動する駒の種類
		public Common.PieceType pieceTypeFrom()
		{
			return (Common.PieceType)((this.move.v >> 16) & 0xf);
		}

		// 移動した後の駒の種類
		public Common.PieceType pieceTypeTo()
		{
			return (isDrop () ? pieceTypeDropped () : pieceTypeTo (pieceTypeFrom ()));
		}

		// 移動前の PieceType を引数に取り、移動後の PieceType を返す。
		// 高速化の為、ptFrom が確定しているときに使用する。
		public Common.PieceType pieceTypeTo(Common.PieceType ptFrom) {
			return ((int)ptFrom + (Common.PieceType)((this.move.v & PromoteFlag) >> 11));
		}

		public bool isDrop()
		{
			return (int)this.from () >= 81;
		}

		// 0xf00000 は 取られる駒のマスク
		public bool isCapture()
		{
			return ((this.move.v & 0xf00000)!=0) ? true : false;
		}

		// 0xf04000 は 取られる駒と成のマスク
		public bool isCaptureOrPromotion()
		{ 
			return ((this.move.v & 0xf04000)!=0) ? true : false; 
		}

		public bool isCaptureOrPawnPromotion() 
		{ 
			return isCapture() || ((isPromotion()!=0) && (pieceTypeFrom() == Common.PieceType.Pawn)); 
		}

		// 打つ駒の種類
		public Common.PieceType pieceTypeDropped() 
		{ 
			return (Common.PieceType)(this.from() - (int)Common.Square.SquareNum + 1); 
		}

		public Common.PieceType pieceTypeFromOrDropped()
		{
			return (isDrop () ? pieceTypeDropped () : pieceTypeFrom ());
		}

		public Common.HandPiece handPieceDropped(){
			if (this.isDrop ()) {
				return pieceTypeToHandPiece(pieceTypeDropped());
			} else {
				return Common.HandPiece.HandPieceNum;
			}
		}

		#endregion

		public static readonly Common.HandPiece[] PieceTypeToHandPieceTable = {
			Common.HandPiece.HandPieceNum, 
			Common.HandPiece.HPawn, 
			Common.HandPiece.HLance, 
			Common.HandPiece.HKnight, 
			Common.HandPiece.HSilver, 
			Common.HandPiece.HBishop, 
			Common.HandPiece.HRook, 
			Common.HandPiece.HGold, 
			Common.HandPiece.HandPieceNum, 
			Common.HandPiece.HPawn, 
			Common.HandPiece.HLance,
			Common.HandPiece.HKnight, 
			Common.HandPiece.HSilver, 
			Common.HandPiece.HBishop, 
			Common.HandPiece.HRook
		};

		private Common.HandPiece pieceTypeToHandPiece(Common.PieceType pt)
		{
			int ptIndex = (int)pt;
			if (ptIndex >= 0 && ptIndex < PieceTypeToHandPieceTable.Length) {
				return PieceTypeToHandPieceTable [ptIndex];
			} else {
				Debug.LogError ("error, pieceTypeToHandPiece: index error: " + pt + "; " + ptIndex);
				return Common.HandPiece.HandPieceNum;
			}
		}
	}
}