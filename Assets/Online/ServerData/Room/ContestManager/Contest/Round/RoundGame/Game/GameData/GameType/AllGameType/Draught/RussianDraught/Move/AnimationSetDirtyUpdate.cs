using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught
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
						// Find pieceUIData need to dirty
						List<PieceUI.UIData> pieceUIDatas = new List<PieceUI.UIData>();
						{
							switch (moveAnimation.getType ()) {
							/*case GameMove.Type.RussianDraughtMove:
								{
									RussianDraughtMoveAnimation russianDraughtMoveAnimation = moveAnimation as RussianDraughtMoveAnimation;
									{
										RussianDraughtMove russianDraughtMove = russianDraughtMoveAnimation.move.v;
										if (russianDraughtMove != null) {
											// get inform
											int from = russianDraughtMove.from ();
											// find
											foreach (PieceUI.UIData pieceUIData in this.data.pieces.vs) {
												if (from == pieceUIData.square.v) {
													pieceUIDatas.Add (pieceUIData);
												} else {
													bool isDead = false;
													{
														if (russianDraughtMove.l.v >= 2 && russianDraughtMove.l.v < russianDraughtMove.m.vs.Count && russianDraughtMove.m.vs.Count == 12) {
															for (int i = 2; i < russianDraughtMove.l.v; i++) {
																int sq = RussianDraughtMove.convertMtoSq (russianDraughtMove.m.vs [i]);
																if (sq == pieceUIData.square.v) {
																	isDead = true;
																	break;
																} else {
																	// Debug.LogError ("why sq so small: " + sq + "; " + this);
																}
															}
														} else {
															Debug.LogError ("russianDraughtMove error: " + russianDraughtMove + "; " + this);
														}
													}
													if(isDead)
														pieceUIDatas.Add(pieceUIData);
												}
											}
										} else {
											Debug.LogError ("russianDraughtMove null: " + this);
										}
									}
								}
								break;*/
							default:
								{
									// Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
									foreach (PieceUI.UIData pieceUIData in this.data.pieces.vs) {
										pieceUIDatas.Add (pieceUIData);
									}
								}
								break;
							}
						}
						// Process
						foreach (PieceUI.UIData pieceUIData in pieceUIDatas) {
							PieceUI pieceUI = pieceUIData.findCallBack<PieceUI> ();
							if (pieceUI != null) {
								pieceUI.makeDirty ();
							} else {
								Debug.LogError ("pieceUI null: " + this);
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
				dirty = true;
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<BoardUI.UIData>) {
					dirty = true;
					return;
				}
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
				this.setDataNull (boardUIData);
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<BoardUI.UIData>) {
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
			if (wrapProperty.p is BoardUI.UIData) {
				switch ((BoardUI.UIData.Property)wrapProperty.n) {
				case BoardUI.UIData.Property.russianDraught:
					break;
				case BoardUI.UIData.Property.pieces:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			{
				if (wrapProperty.p is AnimationManagerCheckChange<BoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}