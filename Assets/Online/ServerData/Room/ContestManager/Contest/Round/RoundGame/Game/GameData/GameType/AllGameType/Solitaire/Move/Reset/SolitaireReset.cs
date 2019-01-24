using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireReset : GameMove
	{

		#region Constructor

		public enum Property
		{

		}

		public SolitaireReset() : base()
		{

		}

		#endregion

		public override Type getType()
		{
			return Type.SolitaireReset;
		}

		public override MoveAnimation makeAnimation (GameType gameType)
		{
			if (gameType is Solitaire) {
				Solitaire solitaire = gameType as Solitaire;
				// make animation
				SolitaireResetAnimation solitaireResetAnimation = new SolitaireResetAnimation();
				{
					// piles
					{
						foreach (Pile pile in solitaire.piles.vs) {
							Pile animationPile = DataUtils.cloneData (pile) as Pile;
							{
								animationPile.uid = solitaireResetAnimation.piles.makeId ();
							}
							solitaireResetAnimation.piles.add (animationPile);
						}
					}
					solitaireResetAnimation.drawCount.v = solitaire.drawCount.v;
				}
				return solitaireResetAnimation;
			} else {
				Debug.LogError ("why not solitaire");
				return null;
			}
		}

		public override string print()
		{
			return "Solitaire Reset";
		}

		public override void getInforBeforeProcess (GameType gameType)
		{

		}

	}
}