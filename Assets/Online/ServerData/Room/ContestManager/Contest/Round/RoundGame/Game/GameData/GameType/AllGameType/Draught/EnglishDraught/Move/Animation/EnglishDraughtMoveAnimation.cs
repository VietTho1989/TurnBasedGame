using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
{
	public class EnglishDraughtMoveAnimation : MoveAnimation
	{

		public LP<byte> Sqs;

		public VP<EnglishDraughtMove> move;

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
			Sqs,
			move,
			duration
		}

		public EnglishDraughtMoveAnimation() : base()
		{
			this.Sqs = new LP<byte> (this, (byte)Property.Sqs);
			this.move = new VP<EnglishDraughtMove> (this, (byte)Property.move, new EnglishDraughtMove ());
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		public override GameMove.Type getType ()
		{
			return GameMove.Type.EnglishDraughtMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			EnglishDraughtMove englishDraughtMove = DataUtils.cloneData (this.move.v) as EnglishDraughtMove;
			return englishDraughtMove;
		}

		public override bool isLoadFullData ()
		{
			bool ret = true;
			{
				// check englishDraughtMove
				if (ret) {
					EnglishDraughtMove englishDraughtMove = this.move.v;
					if (englishDraughtMove != null) {
						if (englishDraughtMove.cPath.vs.Count == 0) {
							Debug.LogError ("englishDraughtMove don't have path");
							ret = false;
						}
					} else {
						Debug.LogError ("englishDraughtMove null");
					}
				}
			}
			return ret;
		}

	}
}