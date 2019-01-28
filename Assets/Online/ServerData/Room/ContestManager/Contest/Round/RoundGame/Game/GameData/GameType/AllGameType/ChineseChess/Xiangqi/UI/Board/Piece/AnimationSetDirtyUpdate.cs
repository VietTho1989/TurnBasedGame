using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
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
						switch (moveAnimation.getType ()) {
						case GameMove.Type.XiangqiMove:
							{
								XiangqiMoveAnimation xiangqiMoveAnimation = moveAnimation as XiangqiMoveAnimation;
								Common.MoveStruct moveStruct = new Common.MoveStruct (xiangqiMoveAnimation.move.v);
								foreach (PieceUI.UIData pieceUIData in this.data.pieces.vs) {
									// check need dirty
									// TODO Test
									bool needDirty = true;
									{
										int x = pieceUIData.position.v % 9;
										int y = 9 - pieceUIData.position.v / 9;
										if (moveStruct.srcX == x && moveStruct.srcY == y) {
											needDirty = true;
										}
									}
									// process
									if (needDirty) {
										PieceUI pieceUI = pieceUIData.findCallBack<PieceUI> ();
										if (pieceUI != null) {
											pieceUI.makeDirty ();
										} else {
											Debug.LogError ("pieceUI null: " + this);
										}
									}
								}
							}
							break;
						default:
							Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
							break;
						}
					} else {
						// Debug.LogError ("moveAnimation null: " + this);
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
				case BoardUI.UIData.Property.xiangqi:
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