using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
	public class HandsUI : UIBehavior<HandsUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<bool> whiteElephantInHand;

			public VP<bool> whiteHawkInHand;

			public VP<bool> blackElephantInHand;

			public VP<bool> blackHawkInHand;

			#region Constructor

			public enum Property
			{
				whiteElephantInHand,
				whiteHawkInHand,
				blackElephantInHand,
				blackHawkInHand
			}

			public UIData() : base()
			{
				this.whiteElephantInHand = new VP<bool>(this, (byte)Property.whiteElephantInHand, true);
				this.whiteHawkInHand = new VP<bool>(this, (byte)Property.whiteHawkInHand, true);
				this.blackElephantInHand = new VP<bool>(this, (byte)Property.blackElephantInHand, true);
				this.blackHawkInHand = new VP<bool>(this, (byte)Property.blackHawkInHand, true);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Image imgWhiteElephant;
		public Image imgWhiteHawk;

		public Image imgBlackElephant;
		public Image imgBlackHawk;

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
						int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
						// Find MoveAnimation
						MoveAnimation moveAnimation = null;
						float time = 0;
						float duration = 0;
						{
							GameDataBoardUI.UIData.getCurrentMoveAnimationInfo (this.data, out moveAnimation, out time, out duration);
						}
						// Find Color
						Common.Color color = Common.Color.WHITE;
						{
							BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
							if (boardUIData != null) {
								Seirawan seirawan = boardUIData.seirawan.v.data;
								if (seirawan != null) {
									color = seirawan.getPlayerIndex () == 0 ? Common.Color.WHITE : Common.Color.BLACK;
								} else {
									Debug.LogError ("seirawan null: " + this);
								}
							} else {
								Debug.LogError ("boardUIData null: " + this);
							}
						}
						// whiteElephant
						if (imgWhiteElephant != null) {
							imgWhiteElephant.enabled = this.data.whiteElephantInHand.v;
							imgWhiteElephant.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.W_ELEPHANT);
							// scale
							{
								float scale = 1;
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.SeirawanMove:
										{
											SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
											if (Common.is_gating (seirawanMoveAnimation.move.v)) {
												if (Common.gating_type (seirawanMoveAnimation.move.v) == Common.PieceType.ELEPHANT) {
													if (color == Common.Color.BLACK) {
														if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration) {
															scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation (
																(time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
																(SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
														}
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
								imgWhiteElephant.transform.localScale = (playerView == 0 ? new Vector3 (scale, scale, scale) : new Vector3 (scale, -scale, scale));
							}
						} else {
							Debug.LogError ("imgWhiteElephant null: " + this);
						}
						// WhiteHawk
						if (imgWhiteHawk != null) {
							imgWhiteHawk.enabled = this.data.whiteHawkInHand.v;
							imgWhiteHawk.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.W_HAWK);
							// scale
							{
								float scale = 1;
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.SeirawanMove:
										{
											SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
											if (Common.is_gating (seirawanMoveAnimation.move.v)) {
												if (Common.gating_type (seirawanMoveAnimation.move.v) == Common.PieceType.HAWK) {
													if (color == Common.Color.BLACK) {
														if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration) {
															scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation (
																(time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
																(SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
														}
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
								imgWhiteHawk.transform.localScale = (playerView == 0 ? new Vector3 (scale, scale, scale) : new Vector3 (scale, -scale, scale));
							}
						} else {
							Debug.LogError ("imgWhiteHawk null: " + this);
						}
						// blackElephant
						if (imgBlackElephant != null) {
							imgBlackElephant.enabled = this.data.blackElephantInHand.v;
							imgBlackElephant.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.B_ELEPHANT);
							// scale
							{
								float scale = 1;
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.SeirawanMove:
										{
											SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
											if (Common.is_gating (seirawanMoveAnimation.move.v)) {
												if (Common.gating_type (seirawanMoveAnimation.move.v) == Common.PieceType.ELEPHANT) {
													if (color == Common.Color.WHITE) {
														if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration) {
															scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation (
																(time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
																(SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
														}
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
								imgBlackElephant.transform.localScale = (playerView == 0 ? new Vector3 (scale, scale, scale) : new Vector3 (scale, -scale, scale));
							}
						} else {
							Debug.LogError ("imgBlackElephant null: " + this);
						}
						// blackHawk
						if (imgBlackHawk != null) {
							imgBlackHawk.enabled = this.data.blackHawkInHand.v;
							imgBlackHawk.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.B_HAWK);
							// scale
							{
								float scale = 1;
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.SeirawanMove:
										{
											SeirawanMoveAnimation seirawanMoveAnimation = moveAnimation as SeirawanMoveAnimation;
											if (Common.is_gating (seirawanMoveAnimation.move.v)) {
												if (Common.gating_type (seirawanMoveAnimation.move.v) == Common.PieceType.HAWK) {
													if (color == Common.Color.WHITE) {
														if (time >= duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration) {
															scale = 1 - MoveAnimation.getAccelerateDecelerateInterpolation (
																(time - (duration - SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration)) /
																(SeirawanMoveAnimation.SeirawanDuration * AnimationManager.DefaultDuration));
														}
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
								imgBlackHawk.transform.localScale = (playerView == 0 ? new Vector3 (scale, scale, scale) : new Vector3 (scale, -scale, scale));
							}
						} else {
							Debug.LogError ("imgBlackHawk null: " + this);
						}
					} else {
						Debug.LogError ("not load full");
						dirty = true;
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
		private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData> ();

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
					// animationManager 
					{
						animationManagerCheckChange.needTimeChange = true;
						animationManagerCheckChange.addCallBack (this);
						animationManagerCheckChange.setData (uiData);
					}
				}
				dirty = true;
				return;
			}
			// CheckChange
			{
				if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
					dirty = true;
					return;
				}
				if (data is AnimationManagerCheckChange<UIData>) {
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
				// CheckChange
				{
					// perspective
					{
						perspectiveChange.removeCallBack (this);
						perspectiveChange.setData (null);
					}
					// animationManager 
					{
						animationManagerCheckChange.removeCallBack (this);
						animationManagerCheckChange.setData (null);
					}
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			{
				if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
					return;
				}
				if (data is AnimationManagerCheckChange<UIData>) {
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
				case UIData.Property.whiteElephantInHand:
					dirty = true;
					break;
				case UIData.Property.whiteHawkInHand:
					dirty = true;
					break;
				case UIData.Property.blackElephantInHand:
					dirty = true;
					break;
				case UIData.Property.blackHawkInHand:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			{
				if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
					dirty = true;
					return;
				}
				if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}