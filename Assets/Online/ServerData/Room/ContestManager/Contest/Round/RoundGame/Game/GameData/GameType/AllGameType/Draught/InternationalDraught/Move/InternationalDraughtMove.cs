using UnityEngine;
using System.Collections;

namespace InternationalDraught
{
	public class InternationalDraughtMove : GameMove
	{
		
		public VP<System.UInt64> move;

		#region Constructor

		public enum Property
		{
			move
		}

		public InternationalDraughtMove() : base()
		{
			this.move = new VP<ulong> (this, (byte)Property.move, 0);
		}

		#endregion

		public override Type getType ()
		{
			return Type.InternationalDraughtMove;
		}

		public override string print ()
		{
			return Common.printMove (this.move.v);
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is InternationalDraught) {
				InternationalDraught internationalDraught = gameType as InternationalDraught;
				// Make animation
				InternationalDraughtMoveAnimation internationalDraughtMoveAnimation = new InternationalDraughtMoveAnimation();
				{
					// pos
					{
						Pos currentPos = internationalDraught.getCurrentPos ();
						if (currentPos != null) {
							Pos pos = DataUtils.cloneData (currentPos) as Pos;
							{
								pos.uid = internationalDraughtMoveAnimation.pos.makeId ();
							}
							internationalDraughtMoveAnimation.pos.v = pos;
						} else {
							Debug.LogError ("why currentPos null: " + this);
						}
					}
					// move
					internationalDraughtMoveAnimation.move.v = this.move.v;
				}
				return internationalDraughtMoveAnimation;
			} else {
				Debug.LogError ("why gameType not internationalDraught: " + gameType + "; " + this);
				return null;
			}
		}

		public override void getInforBeforeProcess (GameType gameType)
		{
			
		}

		public static int from (System.UInt64 mv) {
			return (int)((mv >> 6) & 63);
		}

		public static int to(System.UInt64 mv) { 
			return (int)((mv >> 0) & 63); 
		}

		public static System.UInt64 captured (System.UInt64 mv) { 
			return (mv & ~(System.UInt64)511) >> 5; 
		}

	}
}