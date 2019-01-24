using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
	public class ReversiMoveAnimation : MoveAnimation
	{

		public VP<Reversi> reversi;

		public VP<sbyte> move;

		public VP<System.UInt64> change;

		#region Duration

		public const float AppearDuration = 0.75f;
		public const float FlipDuration = 1.5f;

		public override void initDuration ()
		{
			
		}

		public override float getDuration ()
		{
			return (AppearDuration + FlipDuration) * AnimationManager.DefaultDuration;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			reversi,
			move,
			change
		}

		public ReversiMoveAnimation() : base()
		{
			this.move = new VP<sbyte> (this, (byte)Property.move, 0);
			this.reversi = new VP<Reversi> (this, (byte)Property.reversi, new Reversi ());
			this.change = new VP<ulong> (this, (byte)Property.change, 0);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.ReversiMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{
			if (gameType is Reversi) {
				Reversi reversi = gameType as Reversi;
				// change
				{
					System.UInt64 change = 0;
					{
						if (reversi.nMoveNum.v >= 1 && reversi.nMoveNum.v <= 64) {
							// change
							{
								if (reversi.nMoveNum.v - 1 >= 0 && reversi.nMoveNum.v - 1 < reversi.changes.vs.Count) {
									change = reversi.changes.vs [reversi.nMoveNum.v - 1];
								} else {
									Debug.LogError ("error, nMoveNum, changes error: " + reversi);
								}
							}
						}
					}
					this.change.v = change;
				}
			} else {
				Debug.LogError ("error, why gameType not reversi: " + gameType + "; " + this);
			}
		}

		public override GameMove makeGameMove ()
		{
			ReversiMove reversiMove = new ReversiMove ();
			{
				reversiMove.move.v = this.move.v;
			}
			return reversiMove;
		}

		public override bool isLoadFullData ()
		{
			return true;
		}

		#endregion

	}
}