using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI.Extensions;

namespace Reversi
{
	public class ReversiPieceUI : UIBehavior<ReversiPieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			#region Property

			public VP<int> position;

			public VP<int> type;

			public VP<int> flip;

			#endregion

			#region Constructor

			public enum Property
			{
				position,
				type,
				flip
			}

			public UIData() : base()
			{
				this.position = new VP<int> (this, (byte)Property.position, -1);
				this.type = new VP<int> (this, (byte)Property.type, Reversi.BLACK);
				this.flip = new VP<int> (this, (byte)Property.flip, -1);
			}

			#endregion
		}

		#endregion

		#region Refresh

		public Image imgPiece;

		private readonly Color lastMoveColor = Color.red;
		private readonly Color flipColor = Color.yellow;
		public UILineRenderer flip;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					int position = this.data.position.v;
					if (position >= 0 && position < 64) {
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
							// position
							this.transform.localPosition = Common.convertSquareToLocalPosition (position);
							// image
							{
								if (imgPiece != null) {
									// find piece type
									int pieceType = this.data.type.v;
									{
										if (moveAnimation != null) {
											switch (moveAnimation.getType ()) {
											case GameMove.Type.ReversiMove:
												{
													ReversiMoveAnimation reversiMoveAnimation = moveAnimation as ReversiMoveAnimation;
													if (reversiMoveAnimation.move.v == this.data.position.v) {
														pieceType = this.data.type.v;
													} else {
														bool isFlip = false;
														{
															if (this.data.position.v >= 0 && this.data.position.v < Common.MOVEMASK.Length) {
																if ((reversiMoveAnimation.change.v & Common.MOVEMASK [this.data.position.v]) != 0) {
																	isFlip = true;
																}
															}
														}
														if (isFlip) {
															float appearDuration = ReversiMoveAnimation.AppearDuration * AnimationManager.DefaultDuration;
															float flipDuration = ReversiMoveAnimation.FlipDuration * AnimationManager.DefaultDuration;
															// appear
															if (time <= appearDuration) {
																pieceType = this.data.type.v;
															} else {
																float flipTime = time - appearDuration;
																if (flipTime <= flipDuration / 2) {
																	pieceType = this.data.type.v;
																} else {
																	pieceType = this.data.type.v == Reversi.BLACK ? Reversi.WHITE : Reversi.BLACK;
																}
															}
														} else {
															pieceType = this.data.type.v;
														}
													}
												}
												break;
											default:
												pieceType = this.data.type.v;
												break;
											}
										} else {
											pieceType = this.data.type.v;
										}
									}
									// process
									imgPiece.sprite = ReversiSpriteContainer.get ().getSprite (pieceType);
								} else {
									Debug.LogError ("imgPiece null: " + this);
								}
							}
							// flip
							{
								if (flip != null) {
									if (this.data.type.v == Reversi.WHITE || this.data.type.v == Reversi.BLACK) {
										// find flip
										int flipIndex = this.data.flip.v;
										// process
										if (flipIndex >= 0 && flipIndex < 64) {
											flip.enabled = true;
											if (flipIndex == position) {
												flip.color = lastMoveColor;
											} else {
												flip.color = flipColor;
											}
										} else {
											flip.enabled = false;
										}
									} else {
										flip.enabled = false;
									}
								} else {
									Debug.LogError ("flip null: " + this);
								}
							}
							// Scale
							{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								// find localScale
								float localScale = 1;
								{
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.ReversiMove:
											{
												ReversiMoveAnimation reversiMoveAnimation = moveAnimation as ReversiMoveAnimation;
												float appearDuration = ReversiMoveAnimation.AppearDuration * AnimationManager.DefaultDuration;
												if (reversiMoveAnimation.move.v == this.data.position.v) {
													if (duration > 0) {
														localScale = MoveAnimation.getAccelerateDecelerateInterpolation (time / appearDuration);
													} else {
														Debug.LogError ("error, why duration < 0: " + this);
													}
												} else {
													bool isFlip = false;
													{
														if (this.data.position.v >= 0 && this.data.position.v < Common.MOVEMASK.Length) {
															if ((reversiMoveAnimation.change.v & Common.MOVEMASK [this.data.position.v]) != 0) {
																isFlip = true;
															}
														}
													}
													if (isFlip) {
														if (duration > 0) {
															if (time >= appearDuration) {
																float flipTime = time - ReversiMoveAnimation.AppearDuration * AnimationManager.DefaultDuration;
																float flipDuration = ReversiMoveAnimation.FlipDuration * AnimationManager.DefaultDuration;
																if (flipTime < flipDuration / 2) {
																	localScale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation (flipTime / (flipDuration / 2));
																} else {
																	localScale = MoveAnimation.getAccelerateDecelerateInterpolation ((flipTime - flipDuration / 2) / (flipDuration / 2));
																}
															}
														} else {
															Debug.LogError ("error, why duration < 0: " + this);
														}
													}
												}
											}
											break;
										default:
											break;
										}
									}
								}
								this.transform.localScale = (playerView == 0 ? new Vector3 (localScale, localScale, 1) : new Vector3 (localScale, -localScale, 1));
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {

					}
				} else {
					// Debug.LogError ("data null: " + this);
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
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
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
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
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
				case UIData.Property.flip:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
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