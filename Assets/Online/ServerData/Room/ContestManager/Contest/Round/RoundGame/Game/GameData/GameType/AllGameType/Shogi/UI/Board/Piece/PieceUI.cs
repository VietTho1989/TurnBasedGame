using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class PieceUI : UIBehavior<PieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			#region State

			public VP<Common.Piece> piece;

			public VP<int> position;

			#endregion

			#region Constructor

			public enum Property
			{
				piece,
				position
			}

			public UIData() : base()
			{
				this.piece = new VP<Common.Piece> (this, (byte)Property.piece, Common.Piece.Empty);
				this.position = new VP<int> (this, (byte)Property.position, 0);
			}

			#endregion
		}

		#endregion

		public Image image;

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.position.v >= 0 && this.data.position.v < 90) {
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
							// Image
							{
								if (image != null) {
									image.enabled = true;
									// find correct sprite
									// set
									{
										// Find style
										ShogiGameDataUI.UIData.Style style = ShogiGameDataUI.UIData.Style.Western;
										{
											ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData> ();
											if (shogiGameDataUIData != null) {
												style = shogiGameDataUIData.style.v;
											} else {
												Debug.LogError ("shogiGameDataUIData null: " + this);
											}
										}
										// Process
										{
											ShogiGameDataUI.UIData.StyleInterface styleInterface = ShogiGameDataUI.GetStyleInterface (this.data, style);
											if (styleInterface != null) {
												// Find piece
												Common.Piece piece = this.data.piece.v;
												{
													if (moveAnimation != null) {
														switch (moveAnimation.getType ()) {
														case GameMove.Type.ShogiMove:
															{
																ShogiMoveAnimation shogiMoveAnimation = moveAnimation as ShogiMoveAnimation;
																// Get Inform
																ShogiMove shogiMove = new ShogiMove ();
																{
																	shogiMove.move.v = shogiMoveAnimation.move.v;
																}
																if (shogiMove.from () == (Common.Square)this.data.position.v) {
																	if (shogiMove.isPromotion () != 0) {
																		bool showPromotion = false;
																		{
																			float promotionDuration = ShogiMoveAnimation.PromotionDuration * AnimationManager.DefaultDuration;
																			float distanceDuration = duration - promotionDuration;
																			float promotionTime = time - distanceDuration;
																			if (promotionTime > 0) {
																				int flipFlop = Mathf.CeilToInt (promotionTime / (promotionDuration / 4));
																				showPromotion = (flipFlop % 2 == 0);
																			}
																		}
																		if (showPromotion) {
																			piece = Common.getPromotion (this.data.piece.v);
																		}
																	}
																	// this.transform.SetAsLastSibling ();
																}
															}
															break;
														default:
															Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
															break;
														}
													}
												}
												image.sprite = styleInterface.getSprite (piece);
											} else {
												Debug.LogError ("styleInterface null: " + this);
											}
										}
									}
								} else {
									Debug.LogError ("image null: " + this);
								}
							}
							// Position
							{
								Vector3 localPosition = Common.convertSquareToLocalPosition ((Common.Square)this.data.position.v);
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.ShogiMove:
										{
											ShogiMoveAnimation shogiMoveAnimation = moveAnimation as ShogiMoveAnimation;
											// Get Inform
											ShogiMove shogiMove = new ShogiMove ();
											{
												shogiMove.move.v = shogiMoveAnimation.move.v;
											}
											if (!shogiMove.isDrop ()) {
												Common.Square from = shogiMove.from ();
												Common.Square dest = shogiMove.to ();
												if (from != dest) {
													if ((int)from == this.data.position.v) {
														// get moveDuration
														float moveDuration = duration;
														{
															if (shogiMove.isPromotion () != 0) {
																moveDuration = duration - ShogiMoveAnimation.PromotionDuration * AnimationManager.DefaultDuration;
															}
														}
														if (moveDuration > 0) {
															Vector3 fromPos = Common.convertSquareToLocalPosition (from);
															Vector3 destPos = Common.convertSquareToLocalPosition (dest);
															localPosition = Vector3.Lerp (fromPos, destPos, time / moveDuration);
														} else {
															Debug.LogError ("error, moveDuration < 0");
														}
														this.transform.SetAsLastSibling ();
													}
												}
											}
										}
										break;
									default:
										Debug.LogError ("Don't process: " + moveAnimation + "; " + this);
										break;
									}
								}
								this.transform.localPosition = localPosition;
							}
							// Scale
							{
								// int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								float localScale = 1;
								{
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.ShogiMove:
											{
												ShogiMoveAnimation shogiMoveAnimation = moveAnimation as ShogiMoveAnimation;
												// Find inform
												ShogiMove shogiMove = new ShogiMove ();
												{
													shogiMove.move.v = shogiMoveAnimation.move.v;
												}
												// Process
												if (shogiMove.isDrop ()) {
													if (shogiMove.to () == (Common.Square)this.data.position.v) {
														if (duration > 0) {
															localScale = MoveAnimation.getAccelerateDecelerateInterpolation (time / duration);
															// Debug.LogError ("localScale: " + localScale);
														}
														// this.transform.SetAsLastSibling ();
													}
												}
											}
											break;
										default:
											Debug.LogError ("unknown moveAnimation: " + moveAnimation + "; " + this);
											break;
										}
									}
								}
								// this.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
								this.transform.localScale = new Vector3 (localScale, localScale, localScale);
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("outside board: " + this);
						// Image
						if (image != null) {
							image.enabled = false;
						} else {
							Debug.LogError ("image null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
					// Image
					if (image != null) {
						image.enabled = false;
					} else {
						Debug.LogError ("image null: " + this);
					}
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;
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
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref shogiGameDataUIData);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
				// ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
				{

				}
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
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref shogiGameDataUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			if (data is ShogiGameDataUI.UIData) {
				// ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
				{

				}
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
				case UIData.Property.position:
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
			// Parent
			if (wrapProperty.p is ShogiGameDataUI.UIData) {
				switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n) {
				case ShogiGameDataUI.UIData.Property.gameData:
					break;
				case ShogiGameDataUI.UIData.Property.style:
					dirty = true;
					break;
				case ShogiGameDataUI.UIData.Property.isOnAnimation:
					break;
				case ShogiGameDataUI.UIData.Property.board:
					break;
				case ShogiGameDataUI.UIData.Property.lastMove:
					break;
				case ShogiGameDataUI.UIData.Property.showHint:
					break;
				case ShogiGameDataUI.UIData.Property.inputUI:
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion
	}
}