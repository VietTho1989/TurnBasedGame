using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace HEX
{
	public class PieceUI : UIBehavior<PieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<System.UInt16> x;

			public VP<System.UInt16> y;

			public VP<Common.Color> color;

			#region Constructor

			public enum Property
			{
				x,
				y,
				color
			}

			public UIData() : base()
			{
				this.x = new VP<ushort>(this, (byte)Property.x, 0);
				this.y = new VP<ushort>(this, (byte)Property.y, 0);
				this.color = new VP<Common.Color>(this, (byte)Property.color, Common.Color.Empty);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Image imgPiece;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
					if (boardUIData != null) {
						if (boardUIData.boardSize.v >= Hex.MIN_BOARD_SIZE && boardUIData.boardSize.v <= Hex.MAX_BOARD_SIZE) {
							if (this.data.x.v >= 0 && this.data.x.v < boardUIData.boardSize.v
							    && this.data.y.v >= 0 && this.data.y.v < boardUIData.boardSize.v) {
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
									{
										this.transform.localPosition = Common.GetLocalPosition (this.data.x.v, this.data.y.v, boardUIData);
									}
									// imgPiece
									{
										if (imgPiece != null) {
											float alpha = 1f;
											{
												if (moveAnimation != null) {
													switch (moveAnimation.getType ()) {
													case GameMove.Type.HexMove:
														{
															HexMoveAnimation hexMoveAnimation = moveAnimation as HexMoveAnimation;
															System.UInt16 x = 0;
															System.UInt16 y = 0;
															{
																if (boardUIData.boardSize.v > 0) {
																	x = (System.UInt16)(hexMoveAnimation.move.v % boardUIData.boardSize.v);
																	y = (System.UInt16)(hexMoveAnimation.move.v / boardUIData.boardSize.v);
																} else {
																	Debug.LogError ("why board size too small: " + this);
																}
															}
															if (x == this.data.x.v && y == this.data.y.v) {
																if (duration > 0) {
																	alpha = MoveAnimation.getAccelerateDecelerateInterpolation (time / duration);
																} else {
																	Debug.LogError ("duration <= 0: " + duration + "; " + this);
																}
																// Debug.LogError ("hexMoveAnimation: " + time + "; " + duration);
															}
														}
														break;
													default:
														Debug.LogError ("Don't process: " + moveAnimation.getType () + "; " + this);
														break;
													}
												} else {
													// Debug.LogError ("moveAnimation null: " + this);
												}
											}
											switch (this.data.color.v) {
											case Common.Color.Empty:
												imgPiece.color = Global.TransparentColor;
												break;
											case Common.Color.Red:
												imgPiece.color = new Color (1, 0, 0, alpha);
												break;
											case Common.Color.Blue:
												imgPiece.color = new Color (0, 0, 1, alpha);
												break;
											default:
												Debug.LogError ("unknown color: " + this.data.color.v + "; " + this);
												imgPiece.color = Global.TransparentColor;
												break;
											}
										} else {
											Debug.LogError ("imgPiece null: " + this);
										}
									}
									// Scale
									{
										// khong can
									}
								} else {
									Debug.LogError ("not load full");
									dirty = true;
								}
							} else {
								// outside board
							}
						} else {
							Debug.LogError ("boardUIData size error: " + this);
						}
					} else {
						Debug.LogError ("boardUIData null: " + this);
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

		private BoardUI.UIData boardUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.boardUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			if(data is BoardUI.UIData){
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.boardUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			if(data is BoardUI.UIData){
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
				case UIData.Property.x:
					dirty = true;
					break;
				case UIData.Property.y:
					dirty = true;
					break;
				case UIData.Property.color:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if(wrapProperty.p is BoardUI.UIData){
				switch ((BoardUI.UIData.Property)wrapProperty.n) {
				case BoardUI.UIData.Property.hex:
					break;
				case BoardUI.UIData.Property.boardSize:
					dirty = true;
					break;
				case BoardUI.UIData.Property.pieces:
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