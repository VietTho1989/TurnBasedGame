using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireResetAnimation : MoveAnimation
	{

		public LP<Pile> piles;

		public VP<int> drawCount;

		#region duration

		public override void initDuration ()
		{
			
		}

		public override float getDuration ()
		{
			return 3*AnimationManager.DefaultDuration;
		}

		#endregion

		#region Constructor

		public enum Property
		{
			piles,
			drawCount
		}

		public SolitaireResetAnimation() : base()
		{
			this.piles = new LP<Pile> (this, (byte)Property.piles);
			this.drawCount = new VP<int> (this, (byte)Property.drawCount, 1);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.SolitaireReset;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{

		}

		public override GameMove makeGameMove ()
		{
			SolitaireReset solitaireReset = new SolitaireReset ();
			{

			}
			return solitaireReset;
		}

		public override bool isLoadFullData ()
		{
			bool ret = true;
			{
				// check solitaire
				if (ret) {
					if (this.piles.vs.Count != 13) {
						Debug.LogError ("solitaire error");
						ret = false;
					}
				}
				// check pile
				if (ret) {
					for (int i = 0; i < this.piles.vs.Count; i++) {
						Pile pile = this.piles.vs [i];
						if (pile.downSize.v != pile.down.vs.Count || pile.upSize.v != pile.up.vs.Count) {
							Debug.LogError ("pile error: " + pile + ", " + pile.down.vs.Count + ", " + pile.up.vs.Count);
							ret = false;
							break;
						}
					}
				}
			}
			return ret;
		}

		#endregion

	}
}