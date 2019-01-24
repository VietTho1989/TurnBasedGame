using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Seirawan
{
	public class SeirawanMoveUI : UIBehavior<SeirawanMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<SeirawanMove>> seirawanMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				seirawanMove,
				isHint
			}

			public UIData() : base()
			{
				this.seirawanMove = new VP<ReferenceData<SeirawanMove>>(this, (byte)Property.seirawanMove, new ReferenceData<SeirawanMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.SeirawanMove;
			}
		}

		#endregion

		#region Refresh

		private static Vector2 Delta = new Vector2 (4f, 4f);

		private Color normalColor = new Color (16/256f, 78/256f, 163/256f, 256/256f);
		private Color hintColor = Color.green;// new Color (0 / 256f, 1, 0, 256 / 256f);

		public Image imgPromotion;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					SeirawanMove seirawanMove = this.data.seirawanMove.v.data;
					if (seirawanMove != null) {
						// set line
						{
							UILineRenderer lineRenderer = GetComponent<UILineRenderer> ();
							if (lineRenderer != null) {
								// line
								{
									// Find position;
									int fromX = 0;
									int fromY = 0;
									int destX = 0;
									int destY = 0;
									{
										SeirawanMove.GetClickPosition (seirawanMove.move.v, out fromX, out fromY, out destX, out destY);
									}
									// Make point array
									Vector2[] points;
									{
										List<Vector2> temp = new List<Vector2> ();
										// From
										{
											Vector2 fro = new Vector2 (fromX + 0.5f - Delta.x, 
												fromY + 0.5f - Delta.y);
											temp.Add (fro);
										}
										// Middle: for horse move
										{
											// Check is horse move
											bool isHorseMove = false;
											{
												if ((Mathf.Abs (fromX - destX) == 2 && Mathf.Abs (fromY - destY) == 1)
													|| (Mathf.Abs (fromX - destX) == 1 && Mathf.Abs (fromY - destY) == 2)) {
													isHorseMove = true;
												}
											}
											// Make point
											if (isHorseMove) {
												Vector2 middle = Vector2.zero;
												//
												if (fromX + 2 == destX) {
													middle = new Vector2 (fromX + 0.5f + 1, fromY + 0.5f);
												} 
												//
												else if (fromX - 2 == destX) {
													middle = new Vector2 (fromX + 0.5f - 1, fromY + 0.5f);
												} 
												//
												else if (fromY + 2 == destY) {
													middle = new Vector2 (fromX + 0.5f, fromY + 1 + 0.5f);
												}
												//
												else if (fromY - 2 == destY) {
													middle = new Vector2 (fromX + 0.5f, fromY - 1 + 0.5f);
												}
												temp.Add (middle - Delta);
											} else {
												// Debug.Log ("not horse move");
											}
										}
										// Des
										{
											Vector2 des = new Vector2 (destX + 0.5f - Delta.x,  destY + 0.5f - Delta.y);
											temp.Add (des);
										}
										// Set
										{
											points = new Vector2[temp.Count];
											for (int i = 0; i < temp.Count; i++) {
												points [i] = temp [i];
											}
										}
									}
									lineRenderer.Points = points;
								}
								// color
								{
									if (this.data.isHint.v) {
										lineRenderer.color = hintColor;
									} else {
										lineRenderer.color = normalColor;
									}
								}
							} else {
								Debug.LogError ("lineRenderer null: " + this);
							}
						}
						// imgPromotion
						if (imgPromotion != null) {
							if (this.data.isHint.v) {
								SeirawanMove.Move move = new SeirawanMove.Move (seirawanMove.move.v);
								if (move.type == Common.MoveType.PROMOTION) {
									// sprite
									{
										// get playerIndex
										int playerIndex = 0;
										{
											SeirawanGameDataUI.UIData seirawanGameDataUIData = this.data.findDataInParent<SeirawanGameDataUI.UIData> ();
											if (seirawanGameDataUIData != null) {
												GameData gameData = seirawanGameDataUIData.gameData.v.data;
												if (gameData != null) {
													if (gameData.gameType.v != null && gameData.gameType.v is Seirawan) {
														Seirawan seirawan = gameData.gameType.v as Seirawan;
														playerIndex = seirawan.getPlayerIndex ();
													} else {
														Debug.LogError ("seirawan null: " + this);
													}
												} else {
													Debug.LogError ("gameData null: " + this);
												}
											} else {
												Debug.LogError ("useRuleInputUIData null: " + this);
											}
										}
										// process
										imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (
											Common.make_piece (playerIndex == 0 ? Common.Color.WHITE 
												: Common.Color.BLACK, move.promotion));
									}
									// position
									{
										int fromX = 0;
										int fromY = 0;
										int destX = 0;
										int destY = 0;
										SeirawanMove.GetClickPosition (seirawanMove.move.v, out fromX, out fromY, out destX, out destY);
										imgPromotion.transform.localPosition = new Vector3 (destX - 3.5f, destY - 3.5f, 0);
									}
								} else {
									imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.NO_PIECE);
								}
							} else {
								Debug.Log ("not hint: " + this);
								imgPromotion.sprite = SeirawanSpriteContainer.get ().getSprite (Common.Piece.NO_PIECE);
							}
						} else {
							Debug.LogError ("imgPromotion null: " + this);
						}
					} else {
						Debug.LogError ("seirawanMove null: " + this);
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

		private SeirawanGameDataUI.UIData seirawanGameDataUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.seirawanGameDataUIData);
				}
				// Child
				{
					uiData.seirawanMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is SeirawanGameDataUI.UIData) {
					SeirawanGameDataUI.UIData seirawanGameDataUIData = data as SeirawanGameDataUI.UIData;
					// Child
					{
						seirawanGameDataUIData.gameData.allAddCallBack (this);
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
			if (data is SeirawanMove) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.seirawanGameDataUIData);
				}
				// Child
				{
					uiData.seirawanMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				if (data is SeirawanGameDataUI.UIData) {
					SeirawanGameDataUI.UIData seirawanGameDataUIData = data as SeirawanGameDataUI.UIData;
					// Child
					{
						seirawanGameDataUIData.gameData.allRemoveCallBack (this);
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
			if (data is SeirawanMove) {
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
				case UIData.Property.seirawanMove:
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
			// Parent
			{
				if (wrapProperty.p is SeirawanGameDataUI.UIData) {
					switch ((SeirawanGameDataUI.UIData.Property)wrapProperty.n) {
					case SeirawanGameDataUI.UIData.Property.gameData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case SeirawanGameDataUI.UIData.Property.isOnAnimation:
						break;
					case SeirawanGameDataUI.UIData.Property.board:
						break;
					case SeirawanGameDataUI.UIData.Property.lastMove:
						break;
					case SeirawanGameDataUI.UIData.Property.showHint:
						break;
					case SeirawanGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
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
					if (wrapProperty.p is Seirawan) {
						switch ((Seirawan.Property)wrapProperty.n) {
						case Seirawan.Property.board:
							break;
						case Seirawan.Property.byTypeBB:
							break;
						case Seirawan.Property.byColorBB:
							break;
						case Seirawan.Property.pieceCount:
							break;
						case Seirawan.Property.pieceList:
							break;
						case Seirawan.Property.index:
							break;
						case Seirawan.Property.gamePly:
							break;
						case Seirawan.Property.sideToMove:
							dirty = true;
							break;
						case Seirawan.Property.st:
							break;
						case Seirawan.Property.chess960:
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
			// Child
			if (wrapProperty.p is SeirawanMove) {
				switch ((SeirawanMove.Property)wrapProperty.n) {
				case SeirawanMove.Property.move:
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