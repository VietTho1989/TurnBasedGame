using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolvedMoves : Data
	{

		public VP<SolitaireSolved> solved;

		/** -1: don't move any move, -2: not correct move*/
		public VP<int> moveIndex;

		#region Constructor

		public enum Property
		{
			solved,
			moveIndex
		}

		public SolvedMoves() : base()
		{
			{
				this.solved = new VP<SolitaireSolved> (this, (byte)Property.solved, new SolitaireSolved ());
				this.solved.nh = 0;
			}
			this.moveIndex = new VP<int> (this, (byte)Property.moveIndex, -1);
		}

		#endregion

		public GameMove getSolvedMove()
		{
			GameMove ret = new SolitaireReset ();
			{
				if (this.solved.v.result.v != SolitaireSolved.SolveResult.NotSolved) {
					if (this.moveIndex.v < -1 || this.moveIndex.v >= this.solved.v.moves.vs.Count) {
						ret = new SolitaireReset ();
					} else {
						if (this.moveIndex.v + 1 >= 0 && this.moveIndex.v + 1 < this.solved.v.moves.vs.Count) {
							ret = this.solved.v.moves.vs [this.moveIndex.v + 1];
						} else {
							ret = new SolitaireReset ();
						}
					}
				}
			}
			return ret;
		}

		public void processMove(SolitaireMove move)
		{
			int nextIndex = this.moveIndex.v + 1;
			// update moveIndex
			bool isCorrectMove = false;
			{
				SolitaireSolved solved = this.solved.v;
				if (solved != null) {
					if (solved.result.v != SolitaireSolved.SolveResult.NotSolved) {
						if (nextIndex >= 0 && nextIndex < solved.moves.vs.Count) {
							SolitaireMove solvedMove = solved.moves.vs [nextIndex];
							if (solvedMove.From.v == move.From.v && solvedMove.To.v == move.To.v
							    && solvedMove.Count.v == move.Count.v && solvedMove.Extra.v == move.Extra.v) {
								isCorrectMove = true;
							}
						}
					}
				} else {
					Debug.LogError ("solved null");
				}
			}
			// process
			if (isCorrectMove) {
				this.moveIndex.v = nextIndex;
			} else {
				this.moveIndex.v = -2;
			}
		}

	}
}