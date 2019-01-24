using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class PieceUI : UIBehavior<PieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<int> position;

			public VP<Token.Type> type;

			public VP<Token.Ecolor> color;

			public VP<bool> isFaceUp;

			#region Constructor

			public enum Property
			{
				position,
				type,
				color,
				isFaceUp
			}

			public UIData() : base()
			{
				this.position = new VP<int>(this, (byte)Property.position, 0);
				this.type = new VP<Token.Type>(this, (byte)Property.type, Token.Type.SOLDIER);
				this.color = new VP<Token.Ecolor>(this, (byte)Property.color, Token.Ecolor.RED);
				this.isFaceUp = new VP<bool>(this, (byte)Property.isFaceUp, false);
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
					if (this.data.position.v >= 0 && this.data.position.v < 32) {
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
									Sprite sprite = null;
									{
										if (this.data.isFaceUp.v) {
											sprite = BanqiSpriteContainer.get ().getSprite (this.data.type.v, this.data.color.v);
										} else {
											sprite = BanqiSpriteContainer.get ().Hidden;
										}
										if (moveAnimation != null) {
											switch (moveAnimation.getType ()) {
											case GameMove.Type.BanqiMove:
												{
													BanqiMoveAnimation banqiMoveAnimation = moveAnimation as BanqiMoveAnimation;
													if (duration > 0) {
														if (banqiMoveAnimation.fromX.v == banqiMoveAnimation.destX.v && banqiMoveAnimation.fromY.v == banqiMoveAnimation.destY.v) {
															if (this.data.position.v == 8 * (3 - (banqiMoveAnimation.fromY.v - 1)) + (banqiMoveAnimation.fromX.v - 1)) {
																if (time <= duration / 2) {
																	sprite = BanqiSpriteContainer.get ().Hidden;
																} else {
																	sprite = BanqiSpriteContainer.get ().getSprite (this.data.type.v, this.data.color.v);
																}
															}
														}
													} else {
														Debug.LogError ("why duration > 0");
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
									image.sprite = sprite;
								} else {
									Debug.LogError ("image null");
								}
							}
							// position
							{
								Vector2 localPos = Common.convertPosToLocalPosition (this.data.position.v);
								{
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.BanqiMove:
											{
												BanqiMoveAnimation banqiMoveAnimation = moveAnimation as BanqiMoveAnimation;
												if (duration > 0) {
													if (banqiMoveAnimation.fromX.v != banqiMoveAnimation.destX.v || banqiMoveAnimation.fromY.v != banqiMoveAnimation.destY.v) {
														if (this.data.position.v == 8 * (3 - (banqiMoveAnimation.fromY.v - 1)) + (banqiMoveAnimation.fromX.v - 1)) {
															this.transform.SetAsLastSibling ();
															Vector2 fromPos = Common.convertPosToLocalPosition (8 * (3 - (banqiMoveAnimation.fromY.v - 1)) + (banqiMoveAnimation.fromX.v - 1));
															Vector2 destPos = Common.convertPosToLocalPosition (8 * (3 - (banqiMoveAnimation.destY.v - 1)) + (banqiMoveAnimation.destX.v - 1));
															localPos = Vector2.Lerp (fromPos, destPos, MoveAnimation.getAccelerateDecelerateInterpolation (time / duration));
														}
													}
												} else {
													Debug.LogError ("why duration > 0");
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
								// find
								float scale = 1;
								{
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.BanqiMove:
											{
												BanqiMoveAnimation banqiMoveAnimation = moveAnimation as BanqiMoveAnimation;
												if (duration > 0) {
													if (banqiMoveAnimation.fromX.v == banqiMoveAnimation.destX.v && banqiMoveAnimation.fromY.v == banqiMoveAnimation.destY.v) {
														if (this.data.position.v == 8 * (3 - (banqiMoveAnimation.fromY.v - 1)) + (banqiMoveAnimation.fromX.v - 1)) {
															if (time <= duration / 2) {
																scale = Mathf.Lerp (1, 0, MoveAnimation.getAccelerateDecelerateInterpolation (time / (duration / 2)));
															} else {
																scale = Mathf.Lerp (0, 1, MoveAnimation.getAccelerateDecelerateInterpolation ((time - duration / 2) / (duration / 2)));
															}
														}
													}
												} else {
													Debug.LogError ("why duration > 0");
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
								// set
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								this.transform.localScale = (playerView == 0 ? new Vector3 (scale, scale, 1) : new Vector3 (scale, -scale, 1));
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("position error: " + this.data.position.v);
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
				case UIData.Property.position:
					dirty = true;
					break;
				case UIData.Property.type:
					dirty = true;
					break;
				case UIData.Property.color:
					dirty = true;
					break;
				case UIData.Property.isFaceUp:
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