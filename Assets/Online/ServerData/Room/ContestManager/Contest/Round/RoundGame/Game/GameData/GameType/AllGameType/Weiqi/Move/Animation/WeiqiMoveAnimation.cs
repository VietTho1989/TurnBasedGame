using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Weiqi
{
	public class WeiqiMoveAnimation : MoveAnimation
	{

		public LP<int> b;

		public VP<int> coord;

		public VP<int> color;

		public LP<int> captureCoords;

		#region duration

		public VP<float> duration;

		public const float AppearDuration = 1f;
		public const float StandDuration = 1f;
		public const float CaptureDuration = 1f;

		public override void initDuration ()
		{
			if (this.captureCoords.vs.Count == 0) {
				this.duration.v = 1 * AnimationManager.DefaultDuration;
			} else {
				this.duration.v = (AppearDuration + StandDuration + CaptureDuration) * AnimationManager.DefaultDuration;
			}
		}

		public override float getDuration ()
		{
			return this.duration.v;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			b,
			coord,
			color,
			captureCoords,
			duration
		}

		public WeiqiMoveAnimation() : base()
		{
			this.b = new LP<int> (this, (byte)Property.b);
			this.coord = new VP<int> (this, (byte)Property.coord, 0);
			this.color = new VP<int> (this, (byte)Property.color, 0);
			this.captureCoords = new LP<int> (this, (byte)Property.captureCoords);
			this.duration = new VP<float> (this, (byte)Property.duration, AnimationManager.DefaultDuration);
		}

		#endregion

		public override GameMove.Type getType ()
		{
			return GameMove.Type.WeiqiMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			if (gameType is Weiqi) {
				Weiqi weiqi = gameType as Weiqi;
				// find capture coord
				{
					int boardSize = weiqi.b.v.size.v;
					for (int y = boardSize - 2; y >= 1; y--) {
						for (int x = 1; x < boardSize - 1; x++) {
							int coord = x + boardSize * y;
							// Update
							Common.stone lastStone = Board.GetBoardStone (this.b.vs, coord);
							Common.stone currentStone = Board.GetBoardStone (weiqi.b.v.b.vs, coord);
							if (lastStone != currentStone && this.coord.v != coord) {
								Debug.LogError ("have capture stone: " + coord);
								this.captureCoords.add (coord);
							}
						}
					}
				}
			} else {
				Debug.LogError ("error, why not weiqi: " + gameType + "; " + this);
			}
		}

		public override GameMove makeGameMove ()
		{
			WeiqiMove move = new WeiqiMove ();
			{
				move.coord.v = this.coord.v;
				move.color.v = this.color.v;
				// boardSize
			}
			return move;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

	}
}