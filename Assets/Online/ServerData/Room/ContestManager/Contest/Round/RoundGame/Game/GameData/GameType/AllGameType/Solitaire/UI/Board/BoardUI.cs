using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Solitaire>> solitaire;

			public LP<PileUI.UIData> piles;

			#region Constructor

			public enum Property
			{
				solitaire,
				piles
			}

			public UIData() : base()
			{
				this.solitaire = new VP<ReferenceData<Solitaire>>(this, (byte)Property.solitaire, new ReferenceData<Solitaire>(null));
				this.piles = new LP<PileUI.UIData>(this, (byte)Property.piles);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Solitaire solitaire = this.data.solitaire.v.data;
					if (solitaire != null) {
						// check load full
						bool isLoadFull = true;
						{
							// solitaire
							if (isLoadFull) {
								if (!solitaire.isLoadFull ()) {
									isLoadFull = false;
								}
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// get olds
							List<PileUI.UIData> oldPileUIs = new List<PileUI.UIData> ();
							{
								oldPileUIs.AddRange (this.data.piles.vs);
							}
							// Find piles
							List<Pile> piles = solitaire.piles.vs;
							{
								MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.SolitaireMove:
										{
											SolitaireMoveAnimation solitaireMoveAnimation = moveAnimation as SolitaireMoveAnimation;
											piles = solitaireMoveAnimation.piles.vs;
										}
										break;
									case GameMove.Type.SolitaireReset:
										{
											SolitaireResetAnimation solitaireResetAnimation = moveAnimation as SolitaireResetAnimation;
											piles = solitaireResetAnimation.piles.vs;
										}
										break;
									default:
										Debug.LogError ("unknown type: " + moveAnimation.getType () + "; " + this);
										break;
									}
								} else {
									// Debug.LogError ("moveAnimation null: " + this);
								}
							}
							// Make pileUI
							{
								for (int pileIndex = 0; pileIndex < piles.Count; pileIndex++) {
									Pile pile = piles [pileIndex];
									// Find UIData
									PileUI.UIData pileUIData = null;
									bool needAdd = false;
									{
										// Find old
										for (int i = 0; i < oldPileUIs.Count; i++) {
											PileUI.UIData check = oldPileUIs [i];
											if (check.pileIndex.v == pileIndex) {
												pileUIData = check;
												break;
											}
										}
										// Make new
										if (pileUIData == null) {
											pileUIData = new PileUI.UIData ();
											{
												pileUIData.uid = this.data.piles.makeId ();
											}
											needAdd = true;
										} else {
											oldPileUIs.Remove (pileUIData);
										}
									}
									// Update Property
									{
										// pile
										pileUIData.pile.v = new ReferenceData<Pile>(pile);
										// pileIndex
										pileUIData.pileIndex.v = pileIndex;
									}
									// add
									if (needAdd) {
										this.data.piles.add (pileUIData);
									}
								}
							}
							// Remove oldPileUIs not reuse
							foreach (PileUI.UIData oldPileUI in oldPileUIs) {
								this.data.piles.remove (oldPileUI);
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("solitaire null: " + this);
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

		public PileUI pilePrefab;
		private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					animationManagerCheckChange.needTimeChange = false;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (uiData);
				}
				// Update
				{
					UpdateUtils.makeUpdate<AnimationSetDirtyUpdate, UIData> (uiData, this.transform);
				}
				// Child
				{
					uiData.solitaire.allAddCallBack (this);
					uiData.piles.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Solitaire) {
					dirty = true;
					return;
				}
				if (data is PileUI.UIData) {
					PileUI.UIData pileUIData = data as PileUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pileUIData, pilePrefab, this.transform);
					}
					// dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				// Update
				{
					uiData.removeCallBackAndDestroy (typeof(AnimationSetDirtyUpdate));
				}
				// Child
				{
					uiData.solitaire.allRemoveCallBack (this);
					uiData.piles.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				return;
			}
			// Child
			{
				if (data is Solitaire) {
					return;
				}
				if (data is PileUI.UIData) {
					PileUI.UIData pileUIData = data as PileUI.UIData;
					// UI
					{
						pileUIData.removeCallBackAndDestroy (typeof(PileUI));
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
				case UIData.Property.solitaire:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.piles:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						// dirty = true;
					}
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is Solitaire) {
					switch ((Solitaire.Property)wrapProperty.n) {
					case Solitaire.Property.piles:
						dirty = true;
						break;
					case Solitaire.Property.cards:
						break;
					case Solitaire.Property.movesAvailable:
						break;
					case Solitaire.Property.movesAvailableCount:
						break;
					case Solitaire.Property.drawCount:
						break;
					case Solitaire.Property.roundCount:
						break;
					case Solitaire.Property.foundationCount:
						break;
					case Solitaire.Property.solvedMoves:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is PileUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}