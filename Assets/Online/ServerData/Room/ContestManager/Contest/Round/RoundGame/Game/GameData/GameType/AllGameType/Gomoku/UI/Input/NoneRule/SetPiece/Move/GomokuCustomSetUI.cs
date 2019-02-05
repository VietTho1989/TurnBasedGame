using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Gomoku.NoneRule
{
	public class GomokuCustomSetUI : UIBehavior<GomokuCustomSetUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<GomokuCustomSet>> gomokuCustomSet;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				gomokuCustomSet,
				isHint
			}

			public UIData() : base()
			{
				this.gomokuCustomSet = new VP<ReferenceData<GomokuCustomSet>>(this, (byte)Property.gomokuCustomSet, new ReferenceData<GomokuCustomSet>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.GomokuCustomSet;
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
					GomokuCustomSet gomokuCustomSet = this.data.gomokuCustomSet.v.data;
					if (gomokuCustomSet != null) {
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
						// lineRenderer
						if (lineRenderer != null) {
							Vector2[] points = new Vector2[5];
							{
								Vector3 localPos = Common.convertSquareToLocalPosition (boardSize, gomokuCustomSet.square.v);
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
							if (this.data.isHint.v) {
								// sprite
								imgHint.sprite = GomokuSpriteContainer.get ().getSprite (gomokuCustomSet.piece.v);
								// position
								{
									imgHint.transform.localPosition = Common.convertSquareToLocalPosition (boardSize, gomokuCustomSet.square.v);
								}
								// scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									imgHint.gameObject.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
								}
							} else {
								imgHint.sprite = GomokuSpriteContainer.get ().getSprite (Common.Type.None);
							}
						} else {
							Debug.LogError ("imgHint null: " + this);
						}
					} else {
						Debug.LogError ("gomokuCustomSet null: " + this);
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

		private GomokuGameDataUI.UIData gomokuGameDataUIData = null;

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
					DataUtils.addParentCallBack (uiData, this, ref this.gomokuGameDataUIData);
				}
				// Child
				{
					uiData.gomokuCustomSet.allAddCallBack (this);
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
			if (data is GomokuCustomSet) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.gomokuGameDataUIData);
				}
				// Child
				{
					uiData.gomokuCustomSet.allRemoveCallBack (this);
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
			if (data is GomokuCustomSet) {
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
				case UIData.Property.gomokuCustomSet:
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
							ValueChangeUtils.replaceCallBack (this, syncs);
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
			if (wrapProperty.p is GomokuCustomSet) {
				switch ((GomokuCustomSet.Property)wrapProperty.n) {
				case GomokuCustomSet.Property.square:
					dirty = true;
					break;
				case GomokuCustomSet.Property.piece:
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