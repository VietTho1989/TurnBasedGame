using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

namespace Weiqi
{
	public class WeiqiMoveUI : UIBehavior<WeiqiMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{

			public VP<ReferenceData<WeiqiMove>> weiqiMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				weiqiMove,
				isHint
			}

			public UIData() : base()
			{
				this.weiqiMove = new VP<ReferenceData<WeiqiMove>>(this, (byte)Property.weiqiMove, new ReferenceData<WeiqiMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.WeiqiMove;
			}
		}

		#endregion

		#region Refresh

		public GameObject contentContainer;
		public UILineRenderer lineRenderer;

		public Image imgHint;

		public GameObject passContainer;
		public Text tvPass;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					WeiqiMove move = this.data.weiqiMove.v.data;
					if (move != null) {
						// contentContainer
						if (contentContainer != null) {
							bool isEnable = false;
							{
								if (move.color.v == (int)Common.stone.S_BLACK || move.color.v == (int)Common.stone.S_WHITE) {
									if (move.coord.v >= Common.resign) {
										isEnable = true;
									} else {
										Debug.LogError ("move coord error: " + move.coord.v + "; " + this);
									}
								} else {
									Debug.LogError ("not correct color: " + move.color.v + "; " + this);
								}
							}
							contentContainer.SetActive (isEnable);
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
						// Find Weiqi
						Weiqi weiqi = null;
						{
							WeiqiGameDataUI.UIData weiqiGameDataUIData = this.data.findDataInParent<WeiqiGameDataUI.UIData> ();
							if (weiqiGameDataUIData != null) {
								GameData gameData = weiqiGameDataUIData.gameData.v.data;
								if (gameData != null) {
									if (gameData.gameType.v != null && gameData.gameType.v is Weiqi) {
										weiqi = gameData.gameType.v as Weiqi;
									} else {
										Debug.LogError ("weiqi null: " + this);
									}
								} else {
									Debug.LogError ("gameData null: " + this);
								}
							} else {
								Debug.LogError ("weiqiGameDataUIData null: " + this);
							}
						}
						// get board size
						int boardSize = weiqi!=null ? weiqi.b.v.size.v : 21;
						{
							if (boardSize < 5) {
								Debug.LogError ("why boardSize small: " + boardSize + "; " + this);
								boardSize = 5;
							}
						}
						// Update View
						if (move.coord.v != Common.pass && move.coord.v != Common.resign && move.coord.v > 0) {
							// get coord
							int x = Common.coord_x (boardSize, move.coord.v);
							int y = Common.coord_y (boardSize, move.coord.v);
							// UILineRenderer
							if (lineRenderer != null) {
								lineRenderer.enabled = true;
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
							{
								if (imgHint != null) {
									imgHint.enabled = true;
									if (this.data.isHint.v) {
										// sprite
										{
											// find playerIndex
											int playerIndex = 0;
											{
												if (weiqi != null) {
													playerIndex = weiqi.getPlayerIndex ();
												} else {
													Debug.LogError ("reversi null: " + this);
												}
											}
											// process: black move first
											imgHint.sprite = WeiqiSpriteContainer.get().getSprite(playerIndex==0 ? Common.stone.S_BLACK : Common.stone.S_WHITE);
										}
										// position
										imgHint.transform.localPosition = new Vector3 (x - boardSize / 2.0f + 0.5f, y - boardSize / 2.0f + 0.5f, 0);
									} else {
										imgHint.sprite = WeiqiSpriteContainer.get ().getSprite (Common.stone.S_NONE);
									}
									// Scale
									{
										int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
										imgHint.transform.localScale = (playerView == 0 ? new Vector3 (1, 1, 1) : new Vector3 (1, -1, 1));
									}
								} else {
									Debug.LogError ("imgHint null: " + this);
								}
							}
							// Pass
							{
								if (passContainer != null) {
									passContainer.SetActive (false);
								} else {
									Debug.LogError ("tvPass null: " + this);
								}
							}
						} else {
							// UILineRenderer
							{
								if (lineRenderer != null) {
									lineRenderer.enabled = false;
								} else {
									Debug.LogError ("lineRenderer null: " + this);
								}
							}
							// imgHint
							{
								if (imgHint != null) {
									imgHint.enabled = false;
								} else {
									Debug.LogError ("imgHint null: " + this);
								}
							}
							// Pass
							{
								if (passContainer != null) {
									passContainer.SetActive (true);
                                    // UITransform
                                    {
                                        // passContainer.transform.localPosition = new Vector3(0, 0, 0);
                                    }
                                    // Text
                                    if (tvPass != null) {
										if (this.data.isHint.v) {
											// find playerIndex
											int playerIndex = 0;
											{
												if (weiqi != null) {
													playerIndex = weiqi.getPlayerIndex ();
												} else {
													Debug.LogError ("weiqi null: " + this);
												}
											}
											// process: black move first
											switch (move.coord.v) {
											case Common.pass:
												{
													switch (playerIndex) {
													case 0:
														tvPass.text = "hint black pass";
														break;
													case 1:
														tvPass.text = "hint white pass";
														break;
													default:
														Debug.LogError ("unknown playerIndex: " + this);
														tvPass.text = "hint unknown pass";
														break;
													}
												}
												break;
											case Common.resign:
												{
													switch (playerIndex) {
													case 0:
														tvPass.text = "hint black resign";
														break;
													case 1:
														tvPass.text = "hint white resign";
														break;
													default:
														Debug.LogError ("unknown playerIndex: " + this);
														tvPass.text = "hint unknown resign";
														break;
													}
												}
												break;
											default:
												Debug.LogError ("unknown move: " + move + "; " + this);
												break;
											}
										} else {
											switch (move.coord.v) {
											case Common.pass:
												{
													switch ((Common.stone)move.color.v) {
													case Common.stone.S_BLACK:
														tvPass.text = "Black Pass";
														break;
													case Common.stone.S_WHITE:
														tvPass.text = "White Pass";
														break;
													default:
														Debug.LogError ("unknown color: " + move + "; " + this);
														tvPass.text = "unknown pass";
														break;
													}
												}
												break;
											case Common.resign:
												{
													switch ((Common.stone)move.color.v) {
													case Common.stone.S_BLACK:
														tvPass.text = "Black resign";
														break;
													case Common.stone.S_WHITE:
														tvPass.text = "White resign";
														break;
													default:
														Debug.LogError ("unknown color: " + move + "; " + this);
														tvPass.text = "unknown pass";
														break;
													}
												}
												break;
											default:
												Debug.LogError ("unknown move: " + move + "; " + this);
												break;
											}
										}
									} else {
										Debug.LogError ("tvPass null: " + this);
									}
								} else {
									Debug.LogError ("tvPass null: " + this);
								}
							}
						}
					} else {
						// Debug.Log ("move null: " + this);
						// contentContainer
						if (contentContainer != null) {
							contentContainer.SetActive (false);
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
				} else {
					// Debug.Log ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private WeiqiGameDataUI.UIData weiqiGameDataUIData = null;
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
					DataUtils.addParentCallBack (uiData, this, ref this.weiqiGameDataUIData);
				}
				// Child
				{
					uiData.weiqiMove.allAddCallBack (this);
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
			{
				if (data is WeiqiGameDataUI.UIData) {
					WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
					// Child
					{
						weiqiGameDataUIData.gameData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.gameType.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Weiqi
					{
						if (data is GameType) {
							GameType gameType = data as GameType;
							{
								if (gameType is Weiqi) {
									Weiqi weiqi = gameType as Weiqi;
									weiqi.b.allAddCallBack (this);
								}
							}
							dirty = true;
							return;
						}
						if (data is Board) {
							Board board = data as Board;
							// Child
							{
								board.last_move.allAddCallBack (this);
							}
							dirty = true;
							return;
						}
					}
				}
			}
			// Child
			if (data is WeiqiMove) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.weiqiGameDataUIData);
				}
				// Child
				{
					uiData.weiqiMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is WeiqiGameDataUI.UIData) {
					WeiqiGameDataUI.UIData weiqiGameDataUIData = data as WeiqiGameDataUI.UIData;
					// Child
					{
						weiqiGameDataUIData.gameData.allRemoveCallBack (this);
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
					// Weiqi
					{
						if (data is GameType) {
							GameType gameType = data as GameType;
							{
								if (gameType is Weiqi) {
									Weiqi weiqi = gameType as Weiqi;
									weiqi.b.allRemoveCallBack (this);
								}
							}
							return;
						}
						if (data is Board) {
							Board board = data as Board;
							// Child
							{
								board.last_move.allRemoveCallBack (this);
							}
							return;
						}
					}
				}
			}
			// Child
			if (data is WeiqiMove) {
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
				case UIData.Property.weiqiMove:
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
			// Check Change
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
				if (wrapProperty.p is WeiqiGameDataUI.UIData) {
					switch ((WeiqiGameDataUI.UIData.Property)wrapProperty.n) {
					case WeiqiGameDataUI.UIData.Property.gameData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case WeiqiGameDataUI.UIData.Property.transformOrganizer:
						break;
					case WeiqiGameDataUI.UIData.Property.isOnAnimation:
						break;
					case WeiqiGameDataUI.UIData.Property.board:
						break;
					case WeiqiGameDataUI.UIData.Property.information:
						break;
					case WeiqiGameDataUI.UIData.Property.lastMove:
						break;
					case WeiqiGameDataUI.UIData.Property.showHint:
						break;
					case WeiqiGameDataUI.UIData.Property.inputUI:
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
					// GameType
					{
						if (wrapProperty.p is GameType) {
							if (wrapProperty.p is Weiqi) {
								switch ((Weiqi.Property)wrapProperty.n) {
								case Weiqi.Property.b:
									{
										ValueChangeUtils.replaceCallBack (this, syncs);
										dirty = true;
									}
									break;
								case Weiqi.Property.deadgroup:
									break;
								case Weiqi.Property.scoreOwnerMap:
									break;
								case Weiqi.Property.scoreOwnerMapSize:
									break;
								case Weiqi.Property.scoreBlack:
									break;
								case Weiqi.Property.scoreWhite:
									break;
								case Weiqi.Property.dame:
									break;
								case Weiqi.Property.score:
									break;
								default:
									Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
									break;
								}
								return;
							}
							return;
						}
						if(wrapProperty.p is Board){
							switch ((Board.Property)wrapProperty.n) {
							case Board.Property.size:
								dirty = true;
								break;
							case Board.Property.size2:
								break;
							case Board.Property.bits2:
								break;
							case Board.Property.captures:
								break;
							case Board.Property.komi:
								break;
							case Board.Property.handicap:
								break;
							case Board.Property.rules:
								break;

							case Board.Property.moves:
								break;
							case Board.Property.last_move:
								{
									ValueChangeUtils.replaceCallBack(this, syncs);
									dirty = true;
								}
								break;
							case Board.Property.last_move2:
								break;
							case Board.Property.last_move3:
								break;
							case Board.Property.last_move4:
								break;
							case Board.Property.superko_violation:
								break;

							case Board.Property.b:
								break;
							case Board.Property.g:
								break;
							case Board.Property.pp:
								break;

							case Board.Property.pat3:
								break;

							case Board.Property.gi:
								break;

							case Board.Property.c:
								break;
							case Board.Property.clen:
								break;

							case Board.Property.symmetry:
								break;

							case Board.Property.last_ko:
								break;
							case Board.Property.last_ko_age:
								break;

							case Board.Property.ko:
								break;

							case Board.Property.quicked:
								break;

							case Board.Property.history_hash:
								break;
							case Board.Property.hash:
								break;
							case Board.Property.qhash:
								break;
							default:
								Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
								break;
							}
							return;
						}
					}
				}
			}
			// Child
			if (wrapProperty.p is WeiqiMove) {
				switch ((WeiqiMove.Property)wrapProperty.n) {
				case WeiqiMove.Property.coord:
					dirty = true;
					break;
				case WeiqiMove.Property.color:
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