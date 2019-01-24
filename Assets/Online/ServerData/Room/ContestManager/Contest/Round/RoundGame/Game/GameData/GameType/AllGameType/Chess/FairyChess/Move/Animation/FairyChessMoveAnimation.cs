using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class FairyChessMoveAnimation : MoveAnimation
	{

		/**Piece board[SQUARE_NB];*/
		public LP<int> board;

		/** int32_t pieceCountInHand[COLOR_NB][PIECE_TYPE_NB];*/
		public LP<int> pieceCountInHand;

		public VP<Common.Piece> promoteOrDropPiece;

		public VP<int> move;

		#region Duration

		public VP<float> duration;

		public const float PromotionDuration = 1.5f;
		public const float DropDuration = 1.5f;

		public override void initDuration()
		{
			float duration = AnimationManager.DefaultDuration;
			{
				FairyChessMove.Move move = new FairyChessMove.Move (this.move.v);
				switch (move.type) {
				case Common.MoveType.NORMAL:
					{
						int distance = Common.GetDistance (move.ori, move.dest);
						duration = GetDistanceMoveDuration (distance);
					}
					break;
				case Common.MoveType.PROMOTION:
				case Common.MoveType.PIECE_PROMOTION:
					{
						int distance = Common.GetDistance (move.ori, move.dest);
						duration = GetDistanceMoveDuration (distance) + PromotionDuration * AnimationManager.DefaultDuration;
					}
					break;
				case Common.MoveType.CASTLING:
					{
						duration = GetDistanceMoveDuration (2);
					}
					break;
				case Common.MoveType.ENPASSANT:
					{
						duration = GetDistanceMoveDuration (2);
					}
					break;
				case Common.MoveType.DROP:
					{
						duration = DropDuration * AnimationManager.DefaultDuration;
					}
					break;
				default:
					Debug.LogError ("unknown moveType: " + move.type + "; " + this);
					break;
				}
			}
			this.duration.v = duration;
		}

		public override float getDuration ()
		{
			return this.duration.v;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			board,
			pieceCountInHand,
			promoteOrDropPiece,
			move,
			duration
		}

		public FairyChessMoveAnimation() : base()
		{
			this.board = new LP<int> (this, (byte)Property.board);
			this.pieceCountInHand = new LP<int> (this, (byte)Property.pieceCountInHand);
			this.promoteOrDropPiece = new VP<Common.Piece> (this, (byte)Property.promoteOrDropPiece, Common.Piece.NO_PIECE);
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		public override GameMove.Type getType ()
		{
			return GameMove.Type.FairyChessMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			if (gameType is FairyChess) {
				FairyChess fairyChess = gameType as FairyChess;
				// update promoteOrDrop
				{
					FairyChessMove.Move move = new FairyChessMove.Move (this.move.v);
					switch (move.type) {
					case Common.MoveType.NORMAL:
						break;
					case Common.MoveType.ENPASSANT:
						break;
					case Common.MoveType.CASTLING:
						break;
					case Common.MoveType.PROMOTION:
					case Common.MoveType.DROP:
					case Common.MoveType.PIECE_PROMOTION:
						{
							if ((int)move.dest >= 0 && (int)move.dest < fairyChess.board.vs.Count) {
								this.promoteOrDropPiece.v = (Common.Piece)fairyChess.board.vs [(int)move.dest];
							}
						}
						break;
					default:
						Debug.LogError ("unknown move type: " + move.type + "; " + this);
						break;
					}
				}
			} else {
				Debug.LogError ("error, why not fairyChess: " + gameType);
			}
		}

		public override GameMove makeGameMove ()
		{
			FairyChessMove fairyChessMove = new FairyChessMove ();
			{
				// move
				fairyChessMove.move.v = this.move.v;
				// strMove
			}
			return fairyChessMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

	}
}