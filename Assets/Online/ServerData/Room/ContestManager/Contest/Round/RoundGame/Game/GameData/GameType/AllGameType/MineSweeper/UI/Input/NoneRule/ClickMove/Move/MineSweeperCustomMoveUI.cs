using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper.NoneRule
{
	public class MineSweeperCustomMoveUI : UIBehavior<MineSweeperCustomMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<MineSweeperCustomMove>> mineSweeperCustomMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				mineSweeperCustomMove,
				isHint
			}

			public UIData() : base()
			{
				this.mineSweeperCustomMove = new VP<ReferenceData<MineSweeperCustomMove>>(this, (byte)Property.mineSweeperCustomMove, new ReferenceData<MineSweeperCustomMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.MineSweeperCustomMove;
			}

		}

		#endregion

		#region Refresh

		public UILineRenderer lineRendererFrom;
		public UILineRenderer lineRendererDest;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					MineSweeperCustomMove mineSweeperCustomMove = this.data.mineSweeperCustomMove.v.data;
					if (mineSweeperCustomMove != null) {
						// from
						if (lineRendererFrom != null) {
							// point
							{
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
													x = mineSweeperCustomMove.from.v / mineSweeper.Y.v;
													y = mineSweeperCustomMove.from.v % mineSweeper.Y.v;
												} else {
													Debug.LogError ("Y error: " + mineSweeper.Y.v);
												}
											}
											// Check inside board
											bool isInsideBoard = false;
											{
												if (mineSweeperCustomMove.from.v >= 0) {
													if (x >= boardUIData.x.v && x < boardUIData.x.v + boardUIData.width.v
														&& y >= boardUIData.y.v && y < boardUIData.y.v + boardUIData.height.v) {
														isInsideBoard = true;
													}
												} else {
													Debug.LogError ("why square < 0: " + mineSweeperCustomMove.from.v + "; " + this);
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
												lineRendererFrom.Points = points;
											}
										} else {
											Debug.LogError ("mineSweeper null: " + this);
										}
									} else {
										Debug.LogError ("boardUIData null: " + this);
									}
								}
								lineRendererFrom.gameObject.SetActive (isShow);
							}
							// color
							{
								if (this.data.isHint.v) {
									lineRendererFrom.color = new Color (1, 0, 0, 0.5f);
								} else {
									lineRendererFrom.color = new Color (1, 0, 0, 1f);
								}
							}
						} else {
							Debug.LogError ("lineRendererFrom null: " + this);
						}
						// dest
						if (lineRendererDest != null) {
							// point
							{
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
													x = mineSweeperCustomMove.dest.v / mineSweeper.Y.v;
													y = mineSweeperCustomMove.dest.v % mineSweeper.Y.v;
												} else {
													Debug.LogError ("Y error: " + mineSweeper.Y.v);
												}
											}
											// Check inside board
											bool isInsideBoard = false;
											{
												if (mineSweeperCustomMove.dest.v >= 0) {
													if (x >= boardUIData.x.v && x < boardUIData.x.v + boardUIData.width.v
														&& y >= boardUIData.y.v && y < boardUIData.y.v + boardUIData.height.v) {
														isInsideBoard = true;
													}
												} else {
													Debug.LogError ("why square < 0: " + mineSweeperCustomMove.dest.v + "; " + this);
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
												lineRendererDest.Points = points;
											}
										} else {
											Debug.LogError ("mineSweeper null: " + this);
										}
									} else {
										Debug.LogError ("boardUIData null: " + this);
									}
								}
								lineRendererDest.gameObject.SetActive (isShow);
							}
							// color
							{
								if (this.data.isHint.v) {
									lineRendererDest.color = new Color (0, 1, 0, 0.5f);
								} else {
									lineRendererDest.color = new Color (0, 1, 0, 1f);
								}
							}
						} else {
							Debug.LogError ("lineRendererDest null: " + this);
						}
					} else {
						Debug.LogError ("mineSweeperCustomMove null: " + this);
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

		private MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
				}
				// Child
				{
					uiData.mineSweeperCustomMove.allAddCallBack (this);
				}
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
			if (data is MineSweeperCustomMove) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
				}
				// Child
				{
					uiData.mineSweeperCustomMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
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
			if (data is MineSweeperCustomMove) {
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
				case UIData.Property.mineSweeperCustomMove:
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
			// Parent
			{
				if (wrapProperty.p is MineSweeperGameDataUI.UIData) {
					switch ((MineSweeperGameDataUI.UIData.Property)wrapProperty.n) {
					case MineSweeperGameDataUI.UIData.Property.gameData:
						break;
					case MineSweeperGameDataUI.UIData.Property.transformOrganizer:
						break;
					case MineSweeperGameDataUI.UIData.Property.isOnAnimation:
						break;
					case MineSweeperGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case MineSweeperGameDataUI.UIData.Property.lastMove:
						break;
					case MineSweeperGameDataUI.UIData.Property.showHint:
						break;
					case MineSweeperGameDataUI.UIData.Property.inputUI:
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
					case BoardUI.UIData.Property.scrollView:
						break;
					case BoardUI.UIData.Property.pieces:
						break;
					case BoardUI.UIData.Property.booom:
						break;
					case BoardUI.UIData.Property.allowWatchBomb:
						break;
					case BoardUI.UIData.Property.maxWidth:
						dirty = true;
						break;
					case BoardUI.UIData.Property.maxHeight:
						dirty = true;
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
			if (wrapProperty.p is MineSweeperCustomMove) {
				switch ((MineSweeperCustomMove.Property)wrapProperty.n) {
				case MineSweeperCustomMove.Property.from:
					dirty = true;
					break;
				case MineSweeperCustomMove.Property.dest:
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