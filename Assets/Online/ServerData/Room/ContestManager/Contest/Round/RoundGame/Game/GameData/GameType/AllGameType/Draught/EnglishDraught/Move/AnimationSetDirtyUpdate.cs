using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught
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
							case GameMove.Type.EnglishDraughtMove:
								{
									EnglishDraughtMoveAnimation englishDraughtMoveAnimation = moveAnimation as EnglishDraughtMoveAnimation;
									{
										EnglishDraughtMove englishDraughtMove = englishDraughtMoveAnimation.move.v;
										if (englishDraughtMove != null) {
											List<int> squareList = englishDraughtMove.getMoveSquareList ();
											int from = englishDraughtMove.from ();
											foreach (PieceUI.UIData pieceUIData in this.data.pieces.vs) {
												if (from == pieceUIData.square.v) {
													pieceUIDatas.Add (pieceUIData);
												} else {
													bool isDead = false;
													{
														if (squareList.Count >= 2) {
															int yourSquareX = pieceUIData.square.v % 8;
															int yourSquareY = pieceUIData.square.v / 8;
															for (int i = 0; i < squareList.Count - 1; i++) {
																int square = squareList [i];
																int nextSquare = squareList [i + 1];
																if (square != pieceUIData.square.v && nextSquare != pieceUIData.square.v) {
																	// get x, y
																	int squareX = square % 8;
																	int squareY = square / 8;
																	int nextSquareX = nextSquare % 8;
																	int nextSquareY = nextSquare / 8;
																	// check
																	if ((Mathf.Abs (yourSquareX - squareX) == Mathf.Abs (yourSquareY - squareY))
																		&& (Mathf.Abs (yourSquareX - nextSquareX) == Mathf.Abs (yourSquareY - nextSquareY))) {
																		if ((yourSquareX - squareX) * (yourSquareX - nextSquareX) < 0 && (yourSquareY - squareY) * (yourSquareY - nextSquareY) < 0) {
																			isDead = true;
																			break;
																		}
																	}
																}
															}
														} else {
															Debug.LogError ("error, squareList too small: " + this);
														}
													}
													if (isDead) {
														pieceUIDatas.Add (pieceUIData);
													}
												}
											}
										} else {
											Debug.LogError ("englishDraughtMove null: " + this);
										}
									}
								}
								break;
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
						// Set Dirty
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
				case BoardUI.UIData.Property.englishDraught:
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