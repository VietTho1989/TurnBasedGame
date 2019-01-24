using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class PieceUI : UIBehavior<PieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<uint> piece;

			public VP<int> x;

			public VP<int> y;

			#region Constructor

			public enum Property
			{
				piece,
				x,
				y
			}

			public UIData() : base()
			{
				this.piece = new VP<uint>(this, (byte)Property.piece, 0);
				this.x = new VP<int>(this, (byte)Property.x, 0);
				this.y = new VP<int>(this, (byte)Property.y, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Image image;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// check load full
					bool isLoadFull = true;
					{
						// animation
						if (isLoadFull) {
							isLoadFull = AnimationManager.IsLoadFull (this.data);
						}
					}
					// process
					if (isLoadFull) {
						// Find MoveAnimation
						MoveAnimation moveAnimation = null;
						float time = 0;
						float duration = 0;
						{
							GameDataBoardUI.UIData.getCurrentMoveAnimationInfo (this.data, out moveAnimation, out time, out duration);
						}
						// image
						{
							if (image != null) {
								Sprite sprite = JanggiSpriteContainer.get ().getSprite (this.data.piece.v);
								{
									// animation?
								}
								image.sprite = sprite;
							} else {
								Debug.LogError ("image null");
							}
						}
						// position
						{
							Vector2 localPos = Common.convertXYToLocalPosition (this.data.x.v, this.data.y.v);
							{
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.JanggiMove:
										{
											JanggiMoveAnimation janggiMoveAnimation = moveAnimation as JanggiMoveAnimation;
											if (duration > 0) {
												if (this.data.x.v == janggiMoveAnimation.fromX.v && this.data.y.v == janggiMoveAnimation.fromY.v) {
													this.transform.SetAsLastSibling ();
													Vector2 fromPos = Common.convertXYToLocalPosition (janggiMoveAnimation.fromX.v, janggiMoveAnimation.fromY.v);
													Vector2 destPos = Common.convertXYToLocalPosition (janggiMoveAnimation.toX.v, janggiMoveAnimation.toY.v);
													localPos = Vector2.Lerp (fromPos, destPos, MoveAnimation.getAccelerateDecelerateInterpolation (time / duration));
												}
											} else {
												Debug.LogError ("why duration < 0");
											}
										}
										break;
									default:
										Debug.LogError ("unknown moveAnimation: " + moveAnimation);
										break;
									}
								} else {
									Debug.LogError ("moveAnimation null");
								}
							}
							this.transform.localPosition = localPos;
						}
						// Scale
						{
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							this.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
						}
					} else {
						Debug.LogError ("not load full");
						dirty = true;
					}
				} else {
					Debug.LogError ("data null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					// perspective
					{
						perspectiveChange.addCallBack (this);
						perspectiveChange.setData (uiData);
					}
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					// perspective
					{
						perspectiveChange.removeCallBack (this);
						perspectiveChange.setData (null);
					}
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
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
				case UIData.Property.piece:
					dirty = true;
					break;
				case UIData.Property.x:
					dirty = true;
					break;
				case UIData.Property.y:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Check Change
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}