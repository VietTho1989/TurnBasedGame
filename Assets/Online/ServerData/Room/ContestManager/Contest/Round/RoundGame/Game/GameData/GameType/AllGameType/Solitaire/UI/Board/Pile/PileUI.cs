using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class PileUI : UIBehavior<PileUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Pile>> pile;

			public VP<int> pileIndex;

			public LP<CardUI.UIData> cards;

			public VP<PileLastMoveUI.UIData> pileLastMoveUIData;

			#region Constructor

			public enum Property
			{
				pile,
				pileIndex,
				cards,
				pileLastMoveUIData
			}

			public UIData() : base()
			{
				this.pile = new VP<ReferenceData<Pile>>(this, (byte)Property.pile, new ReferenceData<Pile>(null));
				this.pileIndex = new VP<int>(this, (byte)Property.pileIndex, 0);
				this.cards = new LP<CardUI.UIData>(this, (byte)Property.cards);
				this.pileLastMoveUIData = new VP<PileLastMoveUI.UIData>(this, (byte)Property.pileLastMoveUIData, new PileLastMoveUI.UIData());
			}

			#endregion

		}

		#endregion

		#region Refresh

		public static Vector2 GetPilePosition(Pile.Piles pileType)
		{
			switch (pileType) {
			case Pile.Piles.WASTE:
				return new Vector2 (-2.5f, 3);
			case Pile.Piles.TABLEAU1:
				return new Vector2 (-2.5f, 1);
			case Pile.Piles.TABLEAU2:
				return new Vector2 (-1.5f, 1);
			case Pile.Piles.TABLEAU3:
				return new Vector2 (-0.5f, 1);
			case Pile.Piles.TABLEAU4:
				return new Vector2 (0.5f, 1);
			case Pile.Piles.TABLEAU5:
				return new Vector2 (1.5f, 1);
			case Pile.Piles.TABLEAU6:
				return new Vector2 (2.5f, 1);
			case Pile.Piles.TABLEAU7:
				return new Vector2 (3.5f, 1);
			case Pile.Piles.STOCK:
				return new Vector2 (-3.5f, 3);
			case Pile.Piles.FOUNDATION1C:
				return new Vector2 (0.5f, 3);
			case Pile.Piles.FOUNDATION2D:
				return new Vector2 (1.5f, 3);
			case Pile.Piles.FOUNDATION3S:
				return new Vector2 (2.5f, 3);
			case Pile.Piles.FOUNDATION4H:
				return new Vector2 (3.5f, 3);
			default:
				Debug.LogError ("unknown pileIndex: " + pileType);
				return Vector2.zero;
			}
		}

		public Text tvPileIndex;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Pile pile = this.data.pile.v.data;
					if (pile != null) {
						// check load full
						bool isLoadFull = true;
						{
							// solitaire
							if (isLoadFull) {
								Solitaire solitaire = pile.findDataInParent<Solitaire> ();
								if (solitaire != null) {
									if (!solitaire.isLoadFull ()) {
										isLoadFull = false;
									}
								} else {
									Debug.LogError ("solitaire null");
								}
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// cards
							{
								// get olds
								List<CardUI.UIData> oldCardUIs = new List<CardUI.UIData> ();
								{
									oldCardUIs.AddRange (this.data.cards.vs);
								}
								// find cards
								List<Card> cards = new List<Card> ();
								int downSize = 0;
								{
									// down
									if (pile.downSize.v >= 0 && pile.downSize.v <= pile.down.vs.Count) {
										downSize = pile.downSize.v;
										cards.AddRange (pile.down.vs.GetRange (0, downSize));
									}
									// up
									if (pile.upSize.v >= 0 && pile.upSize.v <= pile.up.vs.Count) {
										cards.AddRange (pile.up.vs.GetRange (0, pile.upSize.v));
									}
								}
								// update
								{
									for (int cardIndex = 0; cardIndex < cards.Count; cardIndex++) {
										Card card = cards [cardIndex];
										// Find UIData
										CardUI.UIData cardUIData = null;
										bool needAdd = false;
										{
											// Find old
											for (int i = 0; i < oldCardUIs.Count; i++) {
												CardUI.UIData check = oldCardUIs [i];
												if (check.cardIndex.v == cardIndex) {
													cardUIData = check;
													break;
												}
											}
											// Make new
											if (cardUIData == null) {
												cardUIData = new CardUI.UIData ();
												{
													cardUIData.uid = this.data.cards.makeId ();
												}
												needAdd = true;
											} else {
												oldCardUIs.Remove (cardUIData);
											}
										}
										// Update Property
										{
											// card
											cardUIData.card.v = new ReferenceData<Card> (card);
											// cardIndex
											cardUIData.cardIndex.v = cardIndex;
											// isUp
											cardUIData.isDown.v = (cardIndex < downSize);
										}
										// add
										if (needAdd) {
											this.data.cards.add (cardUIData);
										}
									}
								}
								// remove oldCardUIs not reuse
								foreach (CardUI.UIData oldCardUI in oldCardUIs) {
									this.data.cards.remove (oldCardUI);
								}
							}
							// tvPileIndex
							if (tvPileIndex != null) {
								tvPileIndex.text = "Pile Index: " + this.data.pileIndex.v + "; " + (Pile.Piles)this.data.pileIndex.v;
							} else {
								Debug.LogError ("tvPileIndex null: " + this);
							}
							// position
							{
								this.transform.localPosition = GetPilePosition ((Pile.Piles)this.data.pileIndex.v);
							}
							// name
							this.gameObject.name = "Pile " + (Pile.Piles)this.data.pileIndex.v;
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("pile null: " + this);
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public CardUI cardPrefab;
		public Transform cardContainer;

		public PileLastMoveUI pileLastMovePrefab;
		public Transform pileLastMoveContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.pile.allAddCallBack (this);
					uiData.cards.allAddCallBack (this);
					uiData.pileLastMoveUIData.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Pile) {
					dirty = true;
					return;
				}
				if (data is CardUI.UIData) {
					CardUI.UIData cardUIData = data as CardUI.UIData;
					// UI
					{
						UIUtils.Instantiate (cardUIData, cardPrefab, cardContainer);
					}
					dirty = true;
					return;
				}
				if (data is PileLastMoveUI.UIData) {
					PileLastMoveUI.UIData pileLastMoveUIData = data as PileLastMoveUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pileLastMoveUIData, pileLastMovePrefab, pileLastMoveContainer);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{
					uiData.pile.allRemoveCallBack (this);
					uiData.cards.allRemoveCallBack (this);
					uiData.pileLastMoveUIData.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			{
				if (data is Pile) {
					return;
				}
				if (data is CardUI.UIData) {
					CardUI.UIData cardUIData = data as CardUI.UIData;
					// UI
					{
						cardUIData.removeCallBackAndDestroy (typeof(CardUI));
					}
					return;
				}
				if (data is PileLastMoveUI.UIData) {
					PileLastMoveUI.UIData pileLastMoveUIData = data as PileLastMoveUI.UIData;
					// UI
					{
						pileLastMoveUIData.removeCallBackAndDestroy (typeof(PileLastMoveUI));
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.pile:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pileIndex:
					dirty = true;
					break;
				case UIData.Property.cards:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pileLastMoveUIData:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Child
			{
				if (wrapProperty.p is Pile) {
					switch ((Pile.Property)wrapProperty.n) {
					case Pile.Property.down:
						dirty = true;
						break;
					case Pile.Property.up:
						dirty = true;
						break;
					case Pile.Property.size:
						dirty = true;
						break;
					case Pile.Property.downSize:
						dirty = true;
						break;
					case Pile.Property.upSize:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is CardUI.UIData) {
					return;
				}
				if (wrapProperty.p is PileLastMoveUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickPile()
		{
			if (this.data != null) {
				Pile pile = this.data.pile.v.data;
				if (pile != null) {
					SolitaireGameDataUI.UIData solitaireGameDataUIData = this.data.findDataInParent<SolitaireGameDataUI.UIData> ();
					if (solitaireGameDataUIData != null) {
						InputUI.UIData inputUIData = solitaireGameDataUIData.inputUI.v;
						if (inputUIData != null) {
							InputUI.UIData.Sub sub = inputUIData.sub.v;
							if (sub != null) {
								sub.onClickPile (pile);
							} else {
								Debug.LogError ("sub null");
							}
						} else {
							Debug.LogError ("inputUIData null");
						}
					} else {
						Debug.LogError ("solitaireGameDataUIData null");
					}
				} else {
					Debug.LogError ("pile null");
				}
			} else {
				Debug.LogError ("data null");
			}
		}

	}
}