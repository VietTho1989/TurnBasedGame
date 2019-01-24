using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
{
	public class RussianDraughtMoveAnimation : MoveAnimation
	{

		/** int32_t Board[46];*/
		public LP<int> Board;

		public VP<RussianDraughtMove> move;

		#region Duration

		public VP<float> duration;

		public const float MoveDuration = 1f;
		public const float StayDuration = 1f;

		public static float getMoveDurationByDistance(int distance)
		{
			return MoveDuration * (0.6f + 0.25f * distance);
		}

		public override void initDuration ()
		{
			List<int> squareList = this.move.v.getMoveSquareList ();
			float ret = 0;
			// Find
			if (squareList.Count >= 2) {
				for (int i = 0; i < squareList.Count - 1; i++) {
					int square = squareList [i];
					int nextSquare = squareList [i + 1];
					ret += getMoveDurationByDistance (Mathf.Abs (square % 8 - nextSquare % 8));
				}
				// stay
				ret += StayDuration*squareList.Count - 2;
			} else {
				Debug.LogError ("why squareList count < 2: " + squareList.Count + "; " + this);
			}
			this.duration.v = ret * AnimationManager.DefaultDuration;
		}

		public override float getDuration ()
		{
			return this.duration.v;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			Board,
			move,
			duration
		}

		public RussianDraughtMoveAnimation() : base()
		{
			this.Board = new LP<int> (this, (byte)Property.Board);
			this.move = new VP<RussianDraughtMove> (this, (byte)Property.move, new RussianDraughtMove ());
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.RussianDraughtMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			RussianDraughtMove russianDraughtMove = DataUtils.cloneData (this.move.v) as RussianDraughtMove;
			return russianDraughtMove;
		}

		public override bool isLoadFullData ()
		{
			bool ret = true;
			{
				// move
				if (ret) {
					RussianDraughtMove russianDraughtMove = this.move.v;
					if (russianDraughtMove != null) {
						if (russianDraughtMove.m.vs.Count == 0) {
							Debug.LogError ("russianDraughtMove m error");
							ret = false;
						}
					} else {
						Debug.LogError ("russianDraughtMove null");
						ret = false;
					}
				}
			}
			return ret;
		}

		#endregion

	}
}