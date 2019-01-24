using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireSpriteContainer : MonoBehaviour
	{

		private static SolitaireSpriteContainer instance;

		void Awake() {
			instance = this;
		}

		public static SolitaireSpriteContainer get()
		{
			return instance;
		}

		#region sprites

		public Sprite[] clubs;
		public Sprite[] diamonds;
		public Sprite[] spades;
		public Sprite[] hearts;

		public Sprite getSprite(Card card)
		{
			Sprite ret = null;
			if (card != null) {
				int cardRank = card.Rank.v - 1;
				switch ((Card.Suits)card.Suit.v) {
				case Card.Suits.CLUBS:
					{
						if (cardRank >= 0 && cardRank < clubs.Length) {
							ret = clubs [cardRank];
						} else {
							Debug.LogError ("cardRank error: " + cardRank);
						}
					}
					break;
				case Card.Suits.DIAMONDS:
					{
						if (cardRank >= 0 && cardRank < diamonds.Length) {
							ret = diamonds [cardRank];
						} else {
							Debug.LogError ("cardRank error: " + cardRank);
						}
					}
					break;
				case Card.Suits.SPADES:
					{
						if (cardRank >= 0 && cardRank < spades.Length) {
							ret = spades [cardRank];
						} else {
							Debug.LogError ("cardRank error: " + cardRank);
						}
					}
					break;
				case Card.Suits.HEARTS:
					{
						if (cardRank >= 0 && cardRank < hearts.Length) {
							ret = hearts [cardRank];
						} else {
							Debug.LogError ("cardRank error: " + cardRank);
						}
					}
					break;
				default:
					Debug.LogError ("unknown suit: " + card.Suit.v);
					break;
				}
			} else {
				Debug.LogError ("card null: " + this);
			}
			return ret;
		}

		#endregion

	}
}