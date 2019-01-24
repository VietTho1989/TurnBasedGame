using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class KhetMoveAnimation : MoveAnimation
	{

		public VP<uint> move;

		#region board

		public VP<int> playerToMove;

		public LP<byte> board;

		#region laser

		/** laserTargetIndex: after make move*/
		public VP<int> laserTargetIndex;

		/** laserTargetSquare: after make move*/
		public VP<byte> laserTargetSquare;

		/** laserTargetPiece: after make move*/
		public VP<int> laserTargetPiece;

		public VP<bool> isKill;

		#endregion

		/** silverLine: after make move*/
		public LP<int> silverLine;

		/** redLine: after make move*/
		public LP<int> redLine;

		#endregion

		#region time of animation

		public const float DefaultMoveTime = 2*AnimationManager.DefaultDuration;
		public const float DefaultRotateTime = 2*AnimationManager.DefaultDuration;
		public const float DefaultLaserTime = 4*AnimationManager.DefaultDuration;

		public VP<float> moveTime;

		public VP<float> rotateTime;

		public VP<float> laserTime;

		#endregion

		#region Constructor

		public enum Property
		{
			move,
			playerToMove,
			board,

			laserTargetIndex,
			laserTargetSquare,
			laserTargetPiece,
			isKill,

			silverLine,
			redLine,

			moveTime,
			rotateTime,
			laserTime
		}

		public KhetMoveAnimation() : base()
		{
			this.move = new VP<uint> (this, (byte)Property.move, 0);
			this.playerToMove = new VP<int> (this, (byte)Property.playerToMove, 0);
			this.board = new LP<byte> (this, (byte)Property.board);

			this.laserTargetIndex = new VP<int> (this, (byte)Property.laserTargetIndex, 0);
			this.laserTargetSquare = new VP<byte> (this, (byte)Property.laserTargetSquare, 0);
			this.laserTargetPiece = new VP<int> (this, (byte)Property.laserTargetPiece, 0);
			this.isKill = new VP<bool> (this, (byte)Property.isKill, false);

			this.silverLine = new LP<int> (this, (byte)Property.silverLine);
			this.redLine = new LP<int> (this, (byte)Property.redLine);

			this.moveTime = new VP<float> (this, (byte)Property.moveTime, 0);
			this.rotateTime = new VP<float> (this, (byte)Property.rotateTime, 0);
			this.laserTime = new VP<float> (this, (byte)Property.laserTime, 0);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType()
		{
			return GameMove.Type.KhetMove;
		}

		public override float getDuration()
		{
			return this.moveTime.v + this.rotateTime.v + this.laserTime.v;
		}

		public override void initDuration()
		{
			if (KhetMove.GetStart (this.move.v) != KhetMove.GetEnd (this.move.v)) {
				this.moveTime.v = DefaultMoveTime;
				this.rotateTime.v = 0;
			} else {
				this.moveTime.v = 0;
				this.rotateTime.v = DefaultRotateTime;
			}
			this.laserTime.v = DefaultLaserTime;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			if (gameType is Khet) {
				Khet khet = gameType as Khet;
				// laser
				{
					this.laserTargetIndex.v = khet._laser.v._targetIndex.v;
					this.laserTargetSquare.v = khet._laser.v._targetSquare.v;
					this.laserTargetPiece.v = khet._laser.v._targetPiece.v;
					// isKill
					{
						bool isKill = false;
						{
							if (this.laserTargetIndex.v >= 0 && this.laserTargetIndex.v < khet._board.vs.Count) {
								if (khet._board.vs [this.laserTargetIndex.v] == Common.Empty) {
									isKill = true;
								}
							} else {
								Debug.LogError ("laserTargetIndex error: " + this.laserTargetIndex.v + ", " + khet._board.vs.Count);
							}
						}
						this.isKill.v = isKill;
					}
				}
				// line
				{
					this.silverLine.add (Core.unityGetMyLaserPath (khet, Core.CanCorrect, Common.Player.Silver));
					this.redLine.add (Core.unityGetMyLaserPath (khet, Core.CanCorrect, Common.Player.Red));
				}
			} else {
				Debug.LogError ("why gameType not khet: " + gameType);
			}
		}

		public override GameMove makeGameMove()
		{
			KhetMove khetMove = new KhetMove ();
			{
				khetMove.move.v = this.move.v;
			}
			return khetMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}