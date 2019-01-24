using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Reversi
{
	public class AnimationSetDirtyUpdate : UpdateBehavior<ReversiBoardUI.UIData>
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
						// Find
						List<ReversiPieceUI.UIData> pieceUIDatas = new List<ReversiPieceUI.UIData>();
						{
							switch (moveAnimation.getType ()) {
							/*case GameMove.Type.ReversiMove:
								{
									ReversiMoveAnimation reversiMoveAnimation = moveAnimation as ReversiMoveAnimation;
									{
										foreach (ReversiPieceUI.UIData pieceUIData in this.data.pieces.vs) {
											if (pieceUIData.position.v >= 0 && pieceUIData.position.v < 64) {
												if (pieceUIData.position.v == reversiMoveAnimation.move.v) {
													pieceUIDatas.Add (pieceUIData);
												} else {
													// flips
													bool isFlip = false;
													{
														if (pieceUIData.position.v >= 0 && pieceUIData.position.v < Common.MOVEMASK.Length) {
															if ((reversiMoveAnimation.change.v & Common.MOVEMASK [pieceUIData.position.v]) != 0) {
																isFlip = true;
															}
														}
													}
													if (isFlip) {
														pieceUIDatas.Add (pieceUIData);
													}
												}
											}
										}
									}

								}
								break;*/
							default:
								{
									// Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
									foreach (ReversiPieceUI.UIData pieceUIData in this.data.pieces.vs) {
										pieceUIDatas.Add (pieceUIData);
									}
								}
								break;
							}
						}
						// Set Dirty
						foreach (ReversiPieceUI.UIData pieceUIData in pieceUIDatas) {
							ReversiPieceUI pieceUI = pieceUIData.findCallBack<ReversiPieceUI> ();
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

		private AnimationManagerCheckChange<ReversiBoardUI.UIData> animationManagerCheckChange = new AnimationManagerCheckChange<ReversiBoardUI.UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is ReversiBoardUI.UIData) {
				ReversiBoardUI.UIData boardUIData = data as ReversiBoardUI.UIData;
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
				if (data is AnimationManagerCheckChange<ReversiBoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is ReversiBoardUI.UIData) {
				ReversiBoardUI.UIData boardUIData = data as ReversiBoardUI.UIData;
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
				if (data is AnimationManagerCheckChange<ReversiBoardUI.UIData>) {
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
			if (wrapProperty.p is ReversiBoardUI.UIData) {
				switch ((ReversiBoardUI.UIData.Property)wrapProperty.n) {
				case ReversiBoardUI.UIData.Property.reversi:
					break;
				case ReversiBoardUI.UIData.Property.pieces:
					dirty = true;
					break;
				case ReversiBoardUI.UIData.Property.legals:
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			{
				if (wrapProperty.p is AnimationManagerCheckChange<ReversiBoardUI.UIData>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}