using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku.NoneRule
{
	public class GomokuCustomMoveUI : UIBehavior<GomokuCustomMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<GomokuCustomMove>> gomokuCustomMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				gomokuCustomMove,
				isHint
			}

			public UIData() : base()
			{
				this.gomokuCustomMove = new VP<ReferenceData<GomokuCustomMove>>(this, (byte)Property.gomokuCustomMove, new ReferenceData<GomokuCustomMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.GomokuCustomMove;
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
					GomokuCustomMove gomokuCustomMove = this.data.gomokuCustomMove.v.data;
					if (gomokuCustomMove != null) {
						// find boardSize
						int boardSize = 19;
						{
							GomokuGameDataUI.UIData gomokuGameDataUIData = this.data.findDataInParent<GomokuGameDataUI.UIData> ();
							if (gomokuGameDataUIData != null) {
								BoardUI.UIData boardUIData = gomokuGameDataUIData.board.v;
								if (boardUIData != null) {
									Gomoku gomoku = boardUIData.gomoku.v.data;
									if (gomoku != null) {
										boardSize = gomoku.boardSize.v;
									} else {
										Debug.LogError ("gomoku null: " + this);
									}
								} else {
									Debug.LogError ("boardUIData null: " + this);
								}
							} else {
								Debug.LogError ("gomokuGameDataUIData null: " + this);
							}
						}
						// from
						if (lineRendererFrom != null) {
							// point
							{
								Vector2[] points = new Vector2[5];
								{
									Vector3 localPos = Common.convertSquareToLocalPosition (boardSize, gomokuCustomMove.from.v);
									points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
									points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
									points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
									points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
									points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								}
								lineRendererFrom.Points = points;
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
								Vector2[] points = new Vector2[5];
								{
									Vector3 localPos = Common.convertSquareToLocalPosition (boardSize, gomokuCustomMove.dest.v);
									points [0] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
									points [1] = new Vector2 (localPos.x - 0.5f, localPos.y + 0.5f);
									points [2] = new Vector2 (localPos.x - 0.5f, localPos.y - 0.5f);
									points [3] = new Vector2 (localPos.x + 0.5f, localPos.y - 0.5f);
									points [4] = new Vector2 (localPos.x + 0.5f, localPos.y + 0.5f);
								}
								lineRendererDest.Points = points;
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
						Debug.LogError ("gomokuCustomMove null: " + this);
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

		private GomokuGameDataUI.UIData gomokuGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.gomokuGameDataUIData);
				}
				// Child
				{
					uiData.gomokuCustomMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is GomokuGameDataUI.UIData) {
					GomokuGameDataUI.UIData gomokuGameDataUIData = data as GomokuGameDataUI.UIData;
					// Child
					{
						gomokuGameDataUIData.board.allAddCallBack (this);
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
							boardUIData.gomoku.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Gomoku) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is GomokuCustomMove) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.gomokuGameDataUIData);
				}
				// Child
				{
					uiData.gomokuCustomMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is GomokuGameDataUI.UIData) {
					GomokuGameDataUI.UIData gomokuGameDataUIData = data as GomokuGameDataUI.UIData;
					// Child
					{
						gomokuGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is BoardUI.UIData) {
						BoardUI.UIData boardUIData = data as BoardUI.UIData;
						// Child
						{
							boardUIData.gomoku.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Gomoku) {
						return;
					}
				}
			}
			// Child
			if (data is GomokuCustomMove) {
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
				case UIData.Property.gomokuCustomMove:
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
				if (wrapProperty.p is GomokuGameDataUI.UIData) {
					switch ((GomokuGameDataUI.UIData.Property)wrapProperty.n) {
					case GomokuGameDataUI.UIData.Property.gameData:
						break;
					case GomokuGameDataUI.UIData.Property.transformOrganizer:
						break;
					case GomokuGameDataUI.UIData.Property.isOnAnimation:
						break;
					case GomokuGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case GomokuGameDataUI.UIData.Property.lastMove:
						break;
					case GomokuGameDataUI.UIData.Property.showHint:
						break;
					case GomokuGameDataUI.UIData.Property.inputUI:
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
						case BoardUI.UIData.Property.gomoku:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case BoardUI.UIData.Property.boardSize:
							break;
						case BoardUI.UIData.Property.background:
							break;
						case BoardUI.UIData.Property.pieces:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Gomoku) {
						switch ((Gomoku.Property)wrapProperty.n) {
						case Gomoku.Property.boardSize:
							dirty = true;
							break;
						case Gomoku.Property.gs:
							break;
						case Gomoku.Property.player:
							break;
						case Gomoku.Property.winningPlayer:
							break;
						case Gomoku.Property.lastMove:
							break;
						case Gomoku.Property.winSize:
							break;
						case Gomoku.Property.winCoord:
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
			if (wrapProperty.p is GomokuCustomMove) {
				switch ((GomokuCustomMove.Property)wrapProperty.n) {
				case GomokuCustomMove.Property.from:
					dirty = true;
					break;
				case GomokuCustomMove.Property.dest:
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