using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
	public class CoTuongUpMoveAnimation : MoveAnimation
	{

		public VP<int> move;

		public VP<Node> node;

		#region Duration

		public VP<float> duration;

		public const float FlipDuration = 1.5f;

		public bool isFlipMove()
		{
			Rules.Move move = CoTuongUpMove.getMove (this.move.v);
			Board board = Rule.getBoard (this.node.v);
			if (move.from.x >= 0 && move.from.x < board.board.GetLength (0)
				&& move.from.y >= 0 && move.from.y < board.board.GetLength (1)) {
				byte piece = board.board [move.from.x, move.from.y];
				return Common.Visibility.isHide (piece);
			} else {
				Debug.LogError ("move from error: " + move);
				return false;
			}
		}

		public override void initDuration ()
		{
			float duration = 0;
			{
				// distance
				{
					Rules.Move move = CoTuongUpMove.getMove (this.move.v);
					duration += GetDistanceMoveDuration (Mathf.Abs (move.dest.x - move.from.x) + Mathf.Abs (move.dest.y - move.from.y));
				}
				// flip
				if (isFlipMove ()) {
					duration += FlipDuration * AnimationManager.DefaultDuration;
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
			move,
			node,
			duration
		}

		public CoTuongUpMoveAnimation() : base()
		{
			this.move = new VP<int> (this, (byte)Property.move, 0);
			this.node = new VP<Node> (this, (byte)Property.node, new Node ());
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.CoTuongUpMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			CoTuongUpMove coTuongUpMove = new CoTuongUpMove ();
			{
				coTuongUpMove.move.v = this.move.v;
			}
			return coTuongUpMove;
		}

		public override bool isLoadFullData ()
		{
			bool ret = true;
			{
				// check node
				if (ret) {
					Node node = this.node.v;
					if (node != null) {
						if (node.pieces.vs.Count == 0) {
							Debug.LogError ("don't have piece in nodes");
							ret = false;
						}
					} else {
						Debug.LogError ("node null");
						ret = false;
					}
				}
			}
			return ret;
		}

		#endregion

	}
}