using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace Gomoku
{
	public class GomokuMoveUI : UIBehavior<GomokuMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<GomokuMove>> gomokuMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				gomokuMove,
				isHint
			}

			public UIData() : base()
			{
				this.gomokuMove = new VP<ReferenceData<GomokuMove>>(this, (byte)Property.gomokuMove, new ReferenceData<GomokuMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.GomokuMove;
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
					GomokuMove gomokuMove = this.data.gomokuMove.v.data;
					if (gomokuMove != null) {
						if (gomokuMove.move.v >= 0) {
							// contentContainer
							if (contentContainer != null) {
								contentContainer.gameObject.SetActive (true);
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
							// Find Gomoku
							Gomoku gomoku = null;
							{
								GomokuGameDataUI.UIData gomokuGameDataUIData = this.data.findDataInParent<GomokuGameDataUI.UIData> ();
								if (gomokuGameDataUIData != null) {
									GameData gameData = gomokuGameDataUIData.gameData.v.data;
									if (gameData != null) {
										if (gameData.gameType.v != null && gameData.gameType.v is Gomoku) {
											gomoku = gameData.gameType.v as Gomoku;
										} else {
											Debug.LogError ("gomoku null: " + this);
										}
									} else {
										Debug.LogError ("gameData null: " + this);
									}
								} else {
									Debug.LogError ("gomokuGameDataUIData null: " + this);
								}
							}
							// get coord
							int x = 0;
							int y = 0;
							int boardSize = 1;
							{
								if (gomoku != null) {
									{
										boardSize = gomoku.boardSize.v;
										if (boardSize <= 0) {
											boardSize = 1;
										}
									}
									{
										int coord = gomokuMove.move.v;
										x = coord % boardSize;
										y = coord / boardSize;
									}
								} else {
									Debug.LogError ("gomoku null: " + this);
								}
							}
							// UILineRenderer
							if (lineRenderer != null) {
								Vector2[] points = new Vector2[5];
								{
									points [0] = new Vector2 (x + 0.5f - boardSize / 2.0f + 0.5f, y + 0.5f - boardSize / 2.0f + 0.5f);
									points [1] = new Vector2 (x - 0.5f - boardSize / 2.0f + 0.5f, y + 0.5f - boardSize / 2.0f + 0.5f);
									points [2] = new Vector2 (x - 0.5f - boardSize / 2.0f + 0.5f, y - 0.5f - boardSize / 2.0f + 0.5f);
									points [3] = new Vector2 (x + 0.5f - boardSize / 2.0f + 0.5f, y - 0.5f - boardSize / 2.0f + 0.5f);
									points [4] = new Vector2 (x + 0.5f - boardSize / 2.0f + 0.5f, y + 0.5f - boardSize / 2.0f + 0.5f);
								}
								lineRenderer.Points = points;
							} else {
								Debug.LogError ("lineRenderer null: " + this);
							}
							// imgHint
							if (imgHint != null) {
								// sprite
								if (this.data.isHint.v) {
									// sprite
									{
										// find playerIndex
										int playerIndex = 0;
										{
											if (gomoku != null) {
												playerIndex = gomoku.getPlayerIndex ();
											} else {
												Debug.LogError ("gomoku null: " + this);
											}
										}
										// process: black move first
										{
											Common.Type type = playerIndex == 0 ? Common.Type.Black : Common.Type.White;
											imgHint.sprite = GomokuSpriteContainer.get ().getSprite (type);
										}
									}
									// position
									imgHint.transform.localPosition = new Vector3 (x - boardSize / 2.0f + 0.5f, y - boardSize / 2.0f + 0.5f, 0);
								} else {
									imgHint.sprite = GomokuSpriteContainer.get ().getSprite (Common.Type.None);
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
							Debug.LogError ("gomokuMove < 0: " + gomokuMove.move.v);
							if (contentContainer != null) {
								contentContainer.gameObject.SetActive (false);
							} else {
								Debug.LogError ("contentContainer null: " + this);
							}
						}
					} else {
						Debug.LogError ("gomokuMove null: " + this);
						// contentContainer
						if (contentContainer != null) {
							contentContainer.gameObject.SetActive (false);
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
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

		private GomokuGameDataUI.UIData gomokuGameDataUIData = null;
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
					DataUtils.addParentCallBack (uiData, this, ref this.gomokuGameDataUIData);
				}
				// Child
				{
					uiData.gomokuMove.allAddCallBack (this);
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
						gomokuGameDataUIData.gameData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.gameType.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is GameType) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is GomokuMove) {
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
					uiData.gomokuMove.allRemoveCallBack (this);
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
						gomokuGameDataUIData.gameData.allRemoveCallBack (this);
					}
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						// Child
						{
							gameData.gameType.allRemoveCallBack (this);
						}
						return;
					}
					if (data is GameType) {
						return;
					}
				}
			}
			// Child
			if (data is GomokuMove) {
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
				case UIData.Property.gomokuMove:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isHint:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				switch ((GameDataBoardCheckPerspectiveChange<UIData>.Property)wrapProperty.n) {
				case GameDataBoardCheckPerspectiveChange<UIData>.Property.change:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				if (wrapProperty.p is GomokuGameDataUI.UIData) {
					switch ((GomokuGameDataUI.UIData.Property)wrapProperty.n) {
					case GomokuGameDataUI.UIData.Property.gameData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case GomokuGameDataUI.UIData.Property.isOnAnimation:
						break;
					case GomokuGameDataUI.UIData.Property.board:
						break;
					case GomokuGameDataUI.UIData.Property.lastMove:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// GameData
				{
					if (wrapProperty.p is GameData) {
						switch ((GameData.Property)wrapProperty.n) {
						case GameData.Property.gameType:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							break;
						case GameData.Property.timeControl:
							break;
						case GameData.Property.lastMove:
							break;
						case GameData.Property.state:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					if (wrapProperty.p is GameType) {
						if (wrapProperty.p is Gomoku) {
							switch ((Gomoku.Property)wrapProperty.n) {
							case Gomoku.Property.boardSize:
								dirty = true;
								break;
							case Gomoku.Property.gs:
								break;
							case Gomoku.Property.player:
								dirty = true;
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
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
						return;
					}
				}
			}
			// Child
			if (wrapProperty.p is GomokuMove) {
				switch ((GomokuMove.Property)wrapProperty.n) {
				case GomokuMove.Property.move:
					dirty = true;
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