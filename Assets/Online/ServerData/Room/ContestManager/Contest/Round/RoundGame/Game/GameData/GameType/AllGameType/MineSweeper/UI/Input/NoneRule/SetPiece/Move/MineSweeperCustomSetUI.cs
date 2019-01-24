using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper.NoneRule
{
	public class MineSweeperCustomSetUI : UIBehavior<MineSweeperCustomSetUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<MineSweeperCustomSet>> mineSweeperCustomSet;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				mineSweeperCustomSet,
				isHint
			}

			public UIData() : base()
			{
				this.mineSweeperCustomSet = new VP<ReferenceData<MineSweeperCustomSet>>(this, (byte)Property.mineSweeperCustomSet, new ReferenceData<MineSweeperCustomSet>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.MineSweeperCustomSet;
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
					MineSweeperCustomSet mineSweeperCustomSet = this.data.mineSweeperCustomSet.v.data;
					if (mineSweeperCustomSet != null) {
						// lineRenderer
						if (lineRenderer != null) {
							bool isShow = false;
							{
								// find boardUIData
								BoardUI.UIData boardUIData = null;
								{
									MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData> ();
									if (mineSweeperGameDataUIData != null) {
										boardUIData = mineSweeperGameDataUIData.board.v;
									} else {
										Debug.LogError ("mineSweeperGameDataUIData null: " + this);
									}
								}
								// process
								if (boardUIData != null) {
									MineSweeper mineSweeper = boardUIData.mineSweeper.v.data;
									if (mineSweeper != null) {
										// find x, y
										int x = -1;
										int y = -1;
										{
											if (mineSweeper.Y.v > 0) {
												x = mineSweeperCustomSet.square.v / mineSweeper.Y.v;
												y = mineSweeperCustomSet.square.v % mineSweeper.Y.v;
											} else {
												Debug.LogError ("Y error: " + mineSweeper.Y.v);
											}
										}
										// Check inside board
										bool isInsideBoard = false;
										{
											if (mineSweeperCustomSet.square.v >= 0) {
												if (x >= boardUIData.x.v && x < boardUIData.x.v + boardUIData.width.v
													&& y >= boardUIData.y.v && y < boardUIData.y.v + boardUIData.height.v) {
													isInsideBoard = true;
												}
											} else {
												Debug.LogError ("why square < 0: " + mineSweeperCustomSet.square.v + "; " + this);
											}
										}
										// Process
										if (isInsideBoard) {
											isShow = true;
											Vector2[] points = new Vector2[5];
											{
												Vector3 localPos = Common.converPosToLocalPosition (x, y, boardUIData);
												points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
												points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
												points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
												points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
												points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
											}
											lineRenderer.Points = points;
										}
									} else {
										Debug.LogError ("mineSweeper null: " + this);
									}
								} else {
									Debug.LogError ("boardUIData null: " + this);
								}
							}
							lineRenderer.gameObject.SetActive (isShow);
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (imgHint != null) {
							if (this.data.isHint.v) {
								// TODO Can hoan thien
								/*// sprite
								imgHint.sprite = ChessSpriteContainer.get ().getSprite (chessCustomSet.piece.v);
								// position
								{
									imgHint.transform.localPosition = Common.convertXYToLocalPosition (chessCustomSet.x.v, chessCustomSet.y.v);
								}
								// scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
								}*/
							} else {
								// imgHint.sprite = ChessSpriteContainer.get ().getSprite (Common.Piece.NO_PIECE);
							}
						} else {
							Debug.LogError ("imgHint null: " + this);
						}
					} else {
						Debug.LogError ("chessCustomSet null: " + this);
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
					uiData.mineSweeperCustomSet.allAddCallBack (this);
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
					MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					// Child
					{
						mineSweeperGameDataUIData.board.allAddCallBack (this);
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
			if (data is MineSweeperCustomSet) {
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
					uiData.mineSweeperCustomSet.allRemoveCallBack (this);
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
					MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					// Child
					{
						mineSweeperGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is BoardUI.UIData) {
					return;
				}
			}
			// Child
			if (data is MineSweeperCustomSet) {
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
				case UIData.Property.mineSweeperCustomSet:
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
			// Child
			if (wrapProperty.p is MineSweeperCustomSet) {
				switch ((MineSweeperCustomSet.Property)wrapProperty.n) {
				case MineSweeperCustomSet.Property.square:
					dirty = true;
					break;
				case MineSweeperCustomSet.Property.piece:
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