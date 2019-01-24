using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace MineSweeper
{
	public class MineSweeperMoveUI : UIBehavior<MineSweeperMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<MineSweeperMove>> mineSweeperMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				mineSweeperMove,
				isHint
			}

			public UIData() : base()
			{
				this.mineSweeperMove = new VP<ReferenceData<MineSweeperMove>>(this, (byte)Property.mineSweeperMove, new ReferenceData<MineSweeperMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.MineSweeperMove;
			}

		}

		#endregion

		#region Refresh

		public GameObject contentContainer;
		public UILineRenderer lineRenderer;

		public Image imgHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					MineSweeperMove mineSweeperMove = this.data.mineSweeperMove.v.data;
					if (mineSweeperMove != null) {
						BoardUI.UIData boardUIData = null;
						{
							MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData> ();
							if (mineSweeperGameDataUIData != null) {
								boardUIData = mineSweeperGameDataUIData.board.v;
							} else {
								Debug.LogError ("mineSweeperGameDataUIData null: " + this);
							}
						}
						if (boardUIData != null) {
							MineSweeper mineSweeper = boardUIData.mineSweeper.v.data;
							if (mineSweeper != null) {
								// find x, y
								int x = -1;
								int y = -1;
								{
									if (mineSweeper.Y.v > 0) {
										x = mineSweeperMove.move.v / mineSweeper.Y.v;
										y = mineSweeperMove.move.v % mineSweeper.Y.v;
									} else {
										Debug.LogError ("Y error: " + mineSweeper.Y.v);
									}
								}
								// Check inside board
								bool isInsideBoard = false;
								{
									if (mineSweeperMove.move.v >= 0) {
										if (x >= boardUIData.x.v && x < boardUIData.x.v + boardUIData.width.v
											&& y >= boardUIData.y.v && y < boardUIData.y.v + boardUIData.height.v) {
											isInsideBoard = true;
										}
									} else {
										Debug.LogError ("why move < 0: " + mineSweeperMove.move.v + "; " + this);
									}
								}
								// Process
								if (isInsideBoard) {
									// contentContainer
									if (contentContainer != null) {
										contentContainer.gameObject.SetActive (true);
									} else {
										Debug.LogError ("contentContainer null: " + this);
									}
									// line
									if (lineRenderer != null) {
										// find localPos
										Vector2 localPos = Common.converPosToLocalPosition (x, y, boardUIData);
										// Make point list
										{
											Vector2[] points = new Vector2[5];
											{
												points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
												points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
												points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
												points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
												points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
											}
											lineRenderer.Points = points;
										}
										// color
										lineRenderer.color = this.data.isHint.v ? Global.HintColor : Global.NormalColor;
									} else {
										Debug.LogError ("lineRender null: " + this);
									}
									// imgHint
									if (imgHint != null) {
										// TODO Can hoan thien
										{
											imgHint.gameObject.SetActive (false);
										}
										// scale
										{
											int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
											imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
										}
									} else {
										Debug.LogError ("imgHint null: " + this);
									}
								} else {
									// contentContainer
									if (contentContainer != null) {
										contentContainer.gameObject.SetActive (false);
									} else {
										Debug.LogError ("contentContainer null: " + this);
									}
								}
							} else {
								Debug.LogError ("mineSweeper null: " + this);
							}
						} else {
							Debug.LogError ("boardUIData null: " + this);
						}
					} else {
						// Debug.LogError ("mineSweeperMove null: " + this);
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
		private MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = null;

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
					DataUtils.addParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
				}
				// Child
				{
					uiData.mineSweeperMove.allAddCallBack (this);
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
				if (data is MineSweeperGameDataUI.UIData) {
					MineSweeperGameDataUI.UIData miniSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					// Child
					{
						miniSweeperGameDataUIData.board.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is BoardUI.UIData) {
					dirty = true;
					return;
				}
			}
			// Child
			if (data is MineSweeperMove) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
				}
				// Child
				{
					uiData.mineSweeperMove.allRemoveCallBack (this);
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
				if (data is MineSweeperGameDataUI.UIData) {
					MineSweeperGameDataUI.UIData miniSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					// Child
					{
						miniSweeperGameDataUIData.board.allAddCallBack (this);
					}
					return;
				}
				// Child
				if (data is BoardUI.UIData) {
					return;
				}
			}
			// Child
			if (data is MineSweeperMove) {
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
				case UIData.Property.mineSweeperMove:
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
				if (wrapProperty.p is MineSweeperGameDataUI.UIData) {
					switch ((MineSweeperGameDataUI.UIData.Property)wrapProperty.n) {
					case MineSweeperGameDataUI.UIData.Property.gameData:
						break;
					case MineSweeperGameDataUI.UIData.Property.updateTransform:
						break;
					case MineSweeperGameDataUI.UIData.Property.transformOrganizer:
						break;
					case MineSweeperGameDataUI.UIData.Property.isOnAnimation:
						break;
					case MineSweeperGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case MineSweeperGameDataUI.UIData.Property.lastMove:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is BoardUI.UIData) {
					switch ((BoardUI.UIData.Property)wrapProperty.n) {
					case BoardUI.UIData.Property.mineSweeper:
						break;
					case BoardUI.UIData.Property.background:
						break;
					case BoardUI.UIData.Property.boundary:
						break;
					case BoardUI.UIData.Property.pieces:
						break;
					case BoardUI.UIData.Property.booom:
						break;
					case BoardUI.UIData.Property.allowWatchBomb:
						break;
					case BoardUI.UIData.Property.maxWidth:
						break;
					case BoardUI.UIData.Property.maxHeight:
						break;
					case BoardUI.UIData.Property.x:
						dirty = true;
						break;
					case BoardUI.UIData.Property.y:
						dirty = true;
						break;
					case BoardUI.UIData.Property.width:
						dirty = true;
						break;
					case BoardUI.UIData.Property.height:
						dirty = true;
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			if (wrapProperty.p is MineSweeperMove) {
				switch ((MineSweeperMove.Property)wrapProperty.n) {
				case MineSweeperMove.Property.move:
					dirty = true;
					break;
				case MineSweeperMove.Property.Y:
					dirty = true;
					break;
				case MineSweeperMove.Property.X:
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