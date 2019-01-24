using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
	public class FairyChessCustomSetUI : UIBehavior<FairyChessCustomSetUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<FairyChessCustomSet>> fairyChessCustomSet;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				fairyChessCustomSet,
				isHint
			}

			public UIData() : base()
			{
				this.fairyChessCustomSet = new VP<ReferenceData<FairyChessCustomSet>>(this, (byte)Property.fairyChessCustomSet, new ReferenceData<FairyChessCustomSet>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.FairyChessCustomSet;
			}
		}

		#endregion

		#region Refresh

		public UILineRenderer lineRenderer;

		public Image imgHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					FairyChessCustomSet fairyChessCustomSet = this.data.fairyChessCustomSet.v.data;
					if (fairyChessCustomSet != null) {
						// lineRenderer
						if (lineRenderer != null) {
							Vector2[] points = new Vector2[5];
							{
								Vector2 localPos = Common.convertXYToLocalPosition (fairyChessCustomSet.x.v, fairyChessCustomSet.y.v);
								points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
								points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
								points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
								points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
							}
							lineRenderer.Points = points;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (imgHint != null) {
							// find vairiantType
							Common.VariantType variantType = Common.VariantType.asean;
							{
								FairyChessGameDataUI.UIData fairyChessGameDataUIData = this.data.findDataInParent<FairyChessGameDataUI.UIData> ();
								if (fairyChessGameDataUIData != null) {
									BoardUI.UIData boardUIData = fairyChessGameDataUIData.board.v;
									if (boardUIData != null) {
										FairyChess fairyChess = boardUIData.fairyChess.v.data;
										if (fairyChess != null) {
											variantType = (Common.VariantType)fairyChess.variantType.v;
										} else {
											Debug.LogError ("fairyChess null: " + this);
										}
									} else {
										Debug.LogError ("boardUIData null: " + this);
									}
								} else {
									Debug.LogError ("fairyChessGameDataUIData null: " + this);
								}
							}
							if (this.data.isHint.v) {
								// sprite
								SpriteContainer.setImagePiece (imgHint, variantType, fairyChessCustomSet.color.v, fairyChessCustomSet.pieceType.v);
								// position
								{
									imgHint.transform.localPosition = Common.convertXYToLocalPosition (fairyChessCustomSet.x.v, fairyChessCustomSet.y.v);
								}
								// scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
								}
							} else {
								SpriteContainer.setImagePiece (imgHint, variantType, fairyChessCustomSet.color.v, Common.PieceType.NO_PIECE_TYPE);
							}
						} else {
							Debug.LogError ("imgHint null: " + this);
						}
					} else {
						// Debug.LogError ("fairyChessCustomSet null: " + this);
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

		private FairyChessGameDataUI.UIData fairyChessGameDataUIData = null;

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
					DataUtils.addParentCallBack (uiData, this, ref this.fairyChessGameDataUIData);
				}
				// Child
				{
					uiData.fairyChessCustomSet.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is FairyChessGameDataUI.UIData) {
					FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
					// Child
					{
						fairyChessGameDataUIData.board.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.fairyChess.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is FairyChess) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is FairyChessCustomSet) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.fairyChessGameDataUIData);
				}
				// Child
				{
					uiData.fairyChessCustomSet.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is FairyChessGameDataUI.UIData) {
					FairyChessGameDataUI.UIData fairyChessGameDataUIData = data as FairyChessGameDataUI.UIData;
					// Child
					{
						fairyChessGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.fairyChess.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is FairyChess) {
						return;
					}
				}
			}
			// Child
			if (data is FairyChessCustomSet) {
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
				case UIData.Property.fairyChessCustomSet:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (wrapProperty.p is FairyChessGameDataUI.UIData) {
					switch ((FairyChessGameDataUI.UIData.Property)wrapProperty.n) {
					case FairyChessGameDataUI.UIData.Property.gameData:
						break;
					case FairyChessGameDataUI.UIData.Property.updateTransform:
						break;
					case FairyChessGameDataUI.UIData.Property.transformOrganizer:
						break;
					case FairyChessGameDataUI.UIData.Property.isOnAnimation:
						break;
					case FairyChessGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case FairyChessGameDataUI.UIData.Property.lastMove:
						break;
					case FairyChessGameDataUI.UIData.Property.showHint:
						break;
					case FairyChessGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				{
					if (wrapProperty.p is BoardUI.UIData) {
						switch ((BoardUI.UIData.Property)wrapProperty.n) {
						case BoardUI.UIData.Property.fairyChess:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case BoardUI.UIData.Property.pieces:
							break;
						case BoardUI.UIData.Property.whiteHand:
							break;
						case BoardUI.UIData.Property.blackHand:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is FairyChess) {
						switch ((FairyChess.Property)wrapProperty.n) {
						case FairyChess.Property.board:
							break;
						case FairyChess.Property.unpromotedBoard:
							break;
						case FairyChess.Property.byTypeBB:
							break;
						case FairyChess.Property.byColorBB:
							break;
						case FairyChess.Property.pieceCount:
							break;
						case FairyChess.Property.pieceList:
							break;
						case FairyChess.Property.index:
							break;
						case FairyChess.Property.castlingRightsMask:
							break;
						case FairyChess.Property.castlingRookSquare:
							break;
						case FairyChess.Property.castlingPath:
							break;
						case FairyChess.Property.gamePly:
							break;
						case FairyChess.Property.sideToMove:
							break;
						case FairyChess.Property.variantType:
							dirty = true;
							break;
						case FairyChess.Property.st:
							break;
						case FairyChess.Property.chess960:
							break;
						case FairyChess.Property.pieceCountInHand:
							break;
						case FairyChess.Property.promotedPieces:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			// Child
			if (wrapProperty.p is FairyChessCustomSet) {
				switch ((FairyChessCustomSet.Property)wrapProperty.n) {
				case FairyChessCustomSet.Property.x:
					dirty = true;
					break;
				case FairyChessCustomSet.Property.y:
					dirty = true;
					break;
				case FairyChessCustomSet.Property.color:
					dirty = true;
					break;
				case FairyChessCustomSet.Property.pieceType:
					dirty = true;
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