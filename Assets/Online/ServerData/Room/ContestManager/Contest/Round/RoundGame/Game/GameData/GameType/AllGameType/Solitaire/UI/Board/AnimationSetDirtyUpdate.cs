using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Solitaire
{
	public class AnimationSetDirtyUpdate : UpdateBehavior<BoardUI.UIData>
	{

		#region Update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Find MoveAnimation
					MoveAnimation moveAnimation = null;
					float time = 0;
					float duration = 0;
					{
						GameDataBoardUI.UIData.getCurrentMoveAnimationInfo (this.data, out moveAnimation, out time, out duration);
					}
					if (moveAnimation != null) {
						// Find cardUIData need to dirty
						List<CardUI.UIData> cardUIDatas = new List<CardUI.UIData>();
						{
							switch (moveAnimation.getType ()) {
							case GameMove.Type.SolitaireMove:
								{
									SolitaireMoveAnimation solitaireMoveAnimation = moveAnimation as SolitaireMoveAnimation;
									foreach (PileUI.UIData pileUIData in this.data.piles.vs) {
										if (pileUIData.pileIndex.v == solitaireMoveAnimation.From.v || pileUIData.pileIndex.v == solitaireMoveAnimation.To.v) {
											cardUIDatas.AddRange (pileUIData.cards.vs);
										}
									}
									// bring To pile to front
									foreach (PileUI.UIData pileUIData in this.data.piles.vs) {
										if (pileUIData.pileIndex.v == solitaireMoveAnimation.To.v) {
											PileUI pileUI = pileUIData.findCallBack<PileUI> ();
											if (pileUI != null) {
												pileUI.transform.SetAsLastSibling ();
											} else {
												Debug.LogError ("pileUI null: " + this);
											}
										}
									}
									// bring From pile to front
									foreach (PileUI.UIData pileUIData in this.data.piles.vs) {
										if (pileUIData.pileIndex.v == solitaireMoveAnimation.From.v) {
											PileUI pileUI = pileUIData.findCallBack<PileUI> ();
											if (pileUI != null) {
												pileUI.transform.SetAsLastSibling ();
											} else {
												Debug.LogError ("pileUI null: " + this);
											}
										}
									}
								}
								break;
							default:
								{
									Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
								}
								break;
							}
						}
						// Process
						// Debug.LogError("make cardUIDatas dirty: "+cardUIDatas.Count);
						foreach (CardUI.UIData cardUIData in cardUIDatas) {
							CardUI cardUI = cardUIData.findCallBack<CardUI> ();
							if (cardUI != null) {
								cardUI.makeDirty ();
							} else {
								Debug.LogError ("cardUI null: " + this);
							}
						}
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

		private AnimationManagerCheckChange<BoardUI.UIData> animationManagerCheckChange = new AnimationManagerCheckChange<BoardUI.UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is BoardUI.UIData) {
				BoardUI.UIData boardUIData = data as BoardUI.UIData;
				// checkChange
				{
					animationManagerCheckChange.needTimeChange = true;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (boardUIData);
				}
				// Child
				{
					boardUIData.piles.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<BoardUI.UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (data is PileUI.UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is BoardUI.UIData) {
				BoardUI.UIData boardUIData = data as BoardUI.UIData;
				// checkChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				// Child
				{
					boardUIData.piles.allRemoveCallBack (this);
				}
				this.setDataNull (boardUIData);
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<BoardUI.UIData>) {
				return;
			}
			// Child
			if (data is PileUI.UIData) {
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is BoardUI.UIData) {
				switch ((BoardUI.UIData.Property)wrapProperty.n) {
				case BoardUI.UIData.Property.solitaire:
					break;
				case BoardUI.UIData.Property.piles:
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
			// checkChange
			if (wrapProperty.p is AnimationManagerCheckChange<BoardUI.UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is PileUI.UIData) {
				switch ((PileUI.UIData.Property)wrapProperty.n) {
				case PileUI.UIData.Property.pile:
					break;
				case PileUI.UIData.Property.pileIndex:
					dirty = true;
					break;
				case PileUI.UIData.Property.cards:
					dirty = true;
					break;
				case PileUI.UIData.Property.pileLastMoveUIData:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}