using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught
{
	public class InternationalDraughtMoveAnimation : MoveAnimation
	{

		public VP<Pos> pos;

		public VP<System.UInt64> move;

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
			List<int> squareList = Core.unityGetMoveSquareList (this.move.v);
			float ret = 0;
			// Find
			if (squareList.Count >= 2) {
				for (int i = 0; i < squareList.Count - 1; i++) {
					int square = squareList [i];
					int nextSquare = squareList [i + 1];
					ret += getMoveDurationByDistance (Mathf.Abs (Common.square_file (square) - Common.square_file (nextSquare)));
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
			pos,
			move,
			duration
		}

		public InternationalDraughtMoveAnimation() : base()
		{
			this.pos = new VP<Pos> (this, (byte)Property.pos, new Pos ());
			this.move = new VP<ulong> (this, (byte)Property.move, 0);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.InternationalDraughtMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			
		}

		public override GameMove makeGameMove ()
		{
			InternationalDraughtMove internationalDraughtMove = new InternationalDraughtMove ();
			{
				internationalDraughtMove.move.v = this.move.v;
			}
			return internationalDraughtMove;
		}

		public override bool isLoadFullData ()
		{
			bool ret = true;
			{
				// pos
				if (ret) {
					Pos pos = this.pos.v;
					if (pos != null) {
						if (pos.p_piece.vs.Count == 0) {
							Debug.LogError ("don't have any p_piece");
							ret = false;
						}
					} else {
						Debug.LogError ("pos null");
						ret = false;
					}
				}
			}
			return ret;
		}

		#endregion

	}
}