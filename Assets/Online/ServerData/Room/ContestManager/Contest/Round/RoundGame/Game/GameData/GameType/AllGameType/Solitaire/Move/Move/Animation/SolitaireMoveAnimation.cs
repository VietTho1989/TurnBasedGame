using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class SolitaireMoveAnimation : MoveAnimation
	{

		#region move

		public VP<byte> From;

		public VP<byte> To;

		public VP<byte> Count;

		public VP<byte> Extra;

		#endregion

		#region board

		public LP<Pile> piles;

		public VP<int> drawCount;

		#endregion

		#region update result

		public VP<float> duration;

		public VP<int> drawAmount;
		public VP<float> drawDuration;

		public VP<float> moveDuration;
		public VP<Vector2> from;
		public VP<Vector2> dest;

		public VP<bool> isFlip;
		public const float FlipTime = 5 * AnimationManager.DefaultDuration;

		public VP<byte> fromRank;
		public VP<byte> fromSuit;

		public override void initDuration ()
		{
			// find distance
			float duration = 0;
			{
				// draw
				{
					// find drawAmout
					int drawAmount = 0;
					{
						// get stockSize
						int stockSize = 0;
						{
							int stockIndex = (int)Pile.Piles.STOCK;
							if (stockIndex >= 0 && stockIndex < this.piles.vs.Count) {
								Pile pile = this.piles.vs [stockIndex];
								stockSize = pile.size.v;
							}
						}
						// get waste size
						int wasteSize = 0;
						{
							int wasteIndex = (int)Pile.Piles.WASTE;
							if (wasteIndex >= 0 && wasteIndex < this.piles.vs.Count) {
								Pile pile = this.piles.vs [wasteIndex];
								wasteSize = pile.size.v;
							}
						}
						// process
						int drawCount = this.drawCount.v;
						{
							if (drawCount <= 0) {
								Debug.LogError ("drawCount error: " + drawCount);
								drawCount = 1;
							}
						}
						if (this.Extra.v <= stockSize) {
							drawAmount = this.Extra.v / drawCount + ((this.Extra.v % drawCount) == 0 ? 0 : 1);
						} else {
							drawAmount = this.Extra.v - stockSize - stockSize - wasteSize;
							drawAmount = drawAmount / drawCount + ((drawAmount % drawCount) == 0 ? 0 : 1);
							drawAmount += stockSize / drawCount + ((stockSize % drawCount) == 0 ? 0 : 1);
						}
					}
					if (drawAmount >= 0 && drawAmount <= 24) {
						this.drawAmount.v = drawAmount;
						this.drawDuration.v = drawAmount * AnimationManager.DefaultDuration;
						duration += this.drawDuration.v;
					} else {
						Debug.LogError ("drawAmount error: " + drawAmount);
					}
				}
				// move
				if (this.From.v != this.To.v) {
					Vector2 from = PileUI.GetPilePosition ((Pile.Piles)this.From.v);
					{
						switch ((Pile.Piles)this.From.v) {
						case Pile.Piles.WASTE:
							break;
						case Pile.Piles.TABLEAU1:
						case Pile.Piles.TABLEAU2:
						case Pile.Piles.TABLEAU3:
						case Pile.Piles.TABLEAU4:
						case Pile.Piles.TABLEAU5:
						case Pile.Piles.TABLEAU6:
						case Pile.Piles.TABLEAU7:
							{
								// cardIndex
								int cardIndex = 0;
								{
									// get fromPile
									if (this.From.v >= 0 && this.From.v < this.piles.vs.Count) {
										Pile fromPile = this.piles.vs [this.From.v];
										cardIndex = fromPile.size.v - this.Count.v;
									}
								}
								from.y -= cardIndex / CardUI.CardY;;
							}
							break;
						case Pile.Piles.STOCK:
							break;
						case Pile.Piles.FOUNDATION1C:
							break;
						case Pile.Piles.FOUNDATION2D:
							break;
						case Pile.Piles.FOUNDATION3S:
							break;
						case Pile.Piles.FOUNDATION4H:
							break;
						default:
							Debug.LogError ("unknown pile: "+this.From.v);
							break;
						}
					}
					Vector2 dest = PileUI.GetPilePosition ((Pile.Piles)this.To.v);
					{
						switch ((Pile.Piles)this.To.v) {
						case Pile.Piles.WASTE:
							break;
						case Pile.Piles.TABLEAU1:
						case Pile.Piles.TABLEAU2:
						case Pile.Piles.TABLEAU3:
						case Pile.Piles.TABLEAU4:
						case Pile.Piles.TABLEAU5:
						case Pile.Piles.TABLEAU6:
						case Pile.Piles.TABLEAU7:
							{
								// cardIndex
								int cardIndex = 0;
								{
									// get destPile
									if (this.To.v >= 0 && this.To.v < this.piles.vs.Count) {
										Pile destPile = this.piles.vs [this.To.v];
										cardIndex = destPile.size.v;
									}
								}
								dest.y -= cardIndex / CardUI.CardY;
							}
							break;
						case Pile.Piles.STOCK:
							break;
						case Pile.Piles.FOUNDATION1C:
							break;
						case Pile.Piles.FOUNDATION2D:
							break;
						case Pile.Piles.FOUNDATION3S:
							break;
						case Pile.Piles.FOUNDATION4H:
							break;
						default:
							Debug.LogError ("unknown pile: "+this.From.v);
							break;
						}
					}
					// set
					{
						this.from.v = from;
						this.dest.v = dest;
					}
					// duration
					{
						float distance = Mathf.Abs (Vector2.Distance (from, dest));
						this.moveDuration.v = 4 * GetDistanceMoveDuration (distance);
						duration += this.moveDuration.v;
					}
				}
				// flip
				{
					bool isFlip = false;
					if (this.Extra.v > 0) {
						if (this.From.v != (int)Pile.Piles.WASTE) {
							duration += FlipTime;
							isFlip = true;
						}
					}
					this.isFlip.v = isFlip;
				}
			}
			// set duration
			if (duration == 0) {
				Debug.LogError ("why duration = 0");
				duration = AnimationManager.DefaultDuration;
			}
			this.duration.v = duration;
			Debug.LogError ("animationDuration: " + duration);
			// fromRank, fromSuit
			{
				byte fromRank = 0;
				byte fromSuit = 0;
				{
					// get stockSize
					int stockSize = 0;
					{
						int stockIndex = (int)Pile.Piles.STOCK;
						if (stockIndex >= 0 && stockIndex < this.piles.vs.Count) {
							Pile pile = this.piles.vs [stockIndex];
							stockSize = pile.size.v;
						}
					}
					// get waste size
					int wasteSize = 0;
					{
						int wasteIndex = (int)Pile.Piles.WASTE;
						if (wasteIndex >= 0 && wasteIndex < this.piles.vs.Count) {
							Pile pile = this.piles.vs [wasteIndex];
							wasteSize = pile.size.v;
						}
					}
					// drawCount
					int drawCount = this.drawCount.v;
					{
						if (drawCount <= 0) {
							Debug.LogError ("drawCount error: " + drawCount);
							drawCount = 1;
						}
					}
					// find
					if (this.Extra.v > 0) {
						if (this.From.v != (int)Pile.Piles.WASTE) {
							if (this.Count.v > 1) {
								
							} else {
								// find card
								Card card = null;
								{
									if (this.From.v >= 0 && this.From.v < this.piles.vs.Count) {
										Pile pile = this.piles.vs [this.From.v];
										card = pile.Low ();
									}
								}
								// set
								if (card != null) {
									fromRank = card.Rank.v;
									fromSuit = card.Suit.v;
								} else {
									Debug.LogError ("card null");
								}
							}
						} else {
							int drawAmount = 0;
							if (this.Extra.v <= stockSize) {
								drawAmount = this.Extra.v / drawCount + ((this.Extra.v % drawCount) == 0 ? 0 : 1);
								// find card
								Card card = null;
								{
									int pileIndex = (int)Pile.Piles.STOCK;
									if (pileIndex >= 0 && pileIndex < this.piles.vs.Count) {
										Pile pile = this.piles.vs [pileIndex];
										int cardIndex = stockSize - this.Extra.v;
										if (cardIndex >= 0 && cardIndex < pile.up.vs.Count) {
											card = pile.up.vs [cardIndex];
										}
									} else {
										Debug.LogError ("pileIndex error: " + pileIndex + ", " + this.piles.vs.Count);
									}
								}
								// set
								if (card != null) {
									fromRank = card.Rank.v;
									fromSuit = card.Suit.v;
								} else {
									Debug.LogError ("card null");
								}
							} else {
								drawAmount = this.Extra.v - stockSize - stockSize - wasteSize;
								drawAmount = drawAmount / drawCount + ((drawAmount % drawCount) == 0 ? 0 : 1);
								drawAmount += stockSize / drawCount + ((stockSize % drawCount) == 0 ? 0 : 1);

								int cardsToMove = stockSize + stockSize + wasteSize + wasteSize - this.Extra.v;
								if (cardsToMove > 0) {
									// find card
									Card card = null;
									{
										int pileIndex = (int)Pile.Piles.WASTE;
										if (pileIndex >= 0 && pileIndex < this.piles.vs.Count) {
											Pile pile = this.piles.vs [pileIndex];
											if (wasteSize - cardsToMove - 1 >= 0 && wasteSize - cardsToMove - 1 < pile.up.vs.Count) {
												card = pile.up.vs [wasteSize - cardsToMove - 1];
											}
										}
									}
									// set
									if (card != null) {
										fromRank = card.Rank.v;
										fromSuit = card.Suit.v;
									} else {
										Debug.LogError ("card null");
									}
								} else {
									// find card
									Card card = null;
									{
										int pileIndex = (int)Pile.Piles.STOCK;
										if (pileIndex >= 0 && pileIndex < this.piles.vs.Count) {
											Pile pile = this.piles.vs [pileIndex];
											if (stockSize + cardsToMove >= 0 && stockSize + cardsToMove < pile.up.vs.Count) {
												card = pile.up.vs [stockSize + cardsToMove];
											} else {
												Debug.LogError ("card index error");
											}
										}
									}
									// set
									if (card != null) {
										fromRank = card.Rank.v;
										fromSuit = card.Suit.v;
									} else {
										Debug.LogError ("card null");
									}
								}
							}
						}
					} else if (this.Count.v > 1) {
						
					} else {
						// find card
						Card card = null;
						{
							if (this.From.v >= 0 && this.From.v < this.piles.vs.Count) {
								Pile pile = this.piles.vs [this.From.v];
								card = pile.Low ();
							}
						}
						// set
						if (card != null) {
							fromRank = card.Rank.v;
							fromSuit = card.Suit.v;
						} else {
							Debug.LogError ("card null");
						}
					}
				}
				this.fromRank.v = fromRank;
				this.fromSuit.v = fromSuit;
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
			From,
			To,
			Count,
			Extra,

			piles,
			drawCount,

			/** result*/
			duration,
			drawAmount,
			drawDuration,

			moveDuration,
			from,
			dest,

			isFlip,

			fromRank,
			fromSuit
		}

		public SolitaireMoveAnimation() : base()
		{
			this.From = new VP<byte> (this, (byte)Property.From, 0);
			this.To = new VP<byte> (this, (byte)Property.To, 0);
			this.Count = new VP<byte> (this, (byte)Property.Count, 0);
			this.Extra = new VP<byte> (this, (byte)Property.Extra, 0);

			this.piles = new LP<Pile> (this, (byte)Property.piles);
			this.drawCount = new VP<int> (this, (byte)Property.drawCount, 1);

			/** result*/
			this.duration = new VP<float> (this, (byte)Property.duration, 0);
			this.drawAmount = new VP<int> (this, (byte)Property.drawAmount, 0);
			this.drawDuration = new VP<float> (this, (byte)Property.drawDuration, 0);
			this.moveDuration = new VP<float> (this, (byte)Property.moveDuration, 0);
			this.from = new VP<Vector2> (this, (byte)Property.from, Vector2.zero);
			this.dest = new VP<Vector2> (this, (byte)Property.dest, Vector2.zero);
			this.isFlip = new VP<bool> (this, (byte)Property.isFlip, false);
			this.fromRank = new VP<byte> (this, (byte)Property.fromRank, (byte)Card.Cards.ACE);
			this.fromSuit = new VP<byte> (this, (byte)Property.fromSuit, (byte)Card.Suits.NONE);
		}

		#endregion

		#region implement base

		public override GameMove.Type getType ()
		{
			return GameMove.Type.SolitaireMove;
		}

		public override void updateAfterProcessGameMove (GameType gameType)
		{

		}

		public override GameMove makeGameMove ()
		{
			SolitaireMove solitaireMove = new SolitaireMove ();
			{
				solitaireMove.From.v = this.From.v;
				solitaireMove.To.v = this.To.v;
				solitaireMove.Count.v = this.Count.v;
				solitaireMove.Extra.v = this.Extra.v;
			}
			return solitaireMove;
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