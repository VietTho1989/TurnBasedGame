using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;
using System.Collections;
using System.Collections.Generic;

namespace Shogi
{
	public class ShogiMoveUI : UIBehavior<ShogiMoveUI.UIData>
	{

		#region UIData

		public class UIData : LastMoveSub
		{
			public VP<ReferenceData<ShogiMove>> shogiMove;

			public VP<bool> isHint;

			#region Constructor

			public enum Property
			{
				shogiMove,
				isHint
			}

			public UIData() : base()
			{
				this.shogiMove = new VP<ReferenceData<ShogiMove>>(this, (byte)Property.shogiMove, new ReferenceData<ShogiMove>(null));
				this.isHint = new VP<bool>(this, (byte)Property.isHint, false);
			}

			#endregion

			public override GameMove.Type getType ()
			{
				return GameMove.Type.ShogiMove;
			}
		}

		#endregion

		#region Refresh

		private const float DeltaX = 4.5f;
		private const float DeltaY = 4.5f;

		private static Color NormalColor = Color.blue;
		private static Color PromotionColor = Color.red;
		private static Color DropColor = Color.green;

		private static Color hintNormalColor = new Color(0, 0, 1, 0.5f);
		private static Color hintPromotionColor = new Color(1, 0, 0, 0.5f);
		private static Color hintDropColor = new Color(0, 1, 0, 0.5f);

		public UILineRenderer lineRenderer;

		public Image imgHint;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					ShogiMove shogiMove = this.data.shogiMove.v.data;
					if (shogiMove != null) {
						/*if (log)
							Debug.LogError (string.Format ("shogiMoveUI: to: {0}; from: {1}; fromAndTo: {2}; " +
								"proFromAndTo: {3}; cap: {4}; isPromotion: {5}; " +
								"pieceTypeFrom: {6}; pieceTypeTo: {7}; isDrop: {8}; " +
								"isCapture: {9}; isCaptureOrPromotion: {10}; isCaptureOrPawnPromotion: {11};" +
								" pieceTypeDropped: {12}; pieceTypeFromOrDropped: {13}; " +
								"handPieceDropped: {14}; toString: {15}", 
								shogiMove.to (), shogiMove.from (), shogiMove.fromAndTo (),
								shogiMove.proFromAndTo (), shogiMove.cap (), shogiMove.isPromotion (), 
								shogiMove.pieceTypeFrom (), shogiMove.pieceTypeTo (), shogiMove.isDrop (),
								shogiMove.isCapture (), shogiMove.isCaptureOrPromotion (), 
								shogiMove.isCaptureOrPawnPromotion (), shogiMove.pieceTypeDropped (), 
								shogiMove.pieceTypeFromOrDropped (), shogiMove.handPieceDropped (), Core.unityMoveToString(shogiMove.move.v)));*/
						// Debug.LogError ("shogiMove: " + Common.printMove (shogiMove.move.v));
						// UI
						{
							if (lineRenderer != null) {
								lineRenderer.enabled = true;
								Piece.Position from = new Piece.Position (0, 0);
								Piece.Position dest = new Piece.Position (0, 0);
								// find position
								{
									// drop move
									if (shogiMove.isDrop ()) {
										// Color
										lineRenderer.color = this.data.isHint.v ? hintDropColor : DropColor;
										// from
										{
											Common.Square fromSquare = shogiMove.to ();
											from.X = (8 - (int)fromSquare / 9);
											from.Y = (8 - (int)fromSquare % 9);
										}
										// dest
										{
											Common.Square destSquare = shogiMove.to ();
											dest.X = (8 - (int)destSquare / 9);
											dest.Y = (8 - (int)destSquare % 9);
										}
									}
									// promotion move
									else if (shogiMove.isPromotion () != 0) {
										// Color
										lineRenderer.color = this.data.isHint.v ? hintPromotionColor : PromotionColor;
										// from
										{
											Common.Square fromSquare = shogiMove.from ();
											from.X = (8 - (int)fromSquare / 9);
											from.Y = (8 - (int)fromSquare % 9);
										}
										// dest
										{
											Common.Square destSquare = shogiMove.to ();
											dest.X = (8 - (int)destSquare / 9);
											dest.Y = (8 - (int)destSquare % 9);
										}
									} 
									// normal move
									else {
										// Color
										lineRenderer.color = this.data.isHint.v ? hintNormalColor : NormalColor;
										// from
										{
											Common.Square fromSquare = shogiMove.from ();
											from.X = (8 - (int)fromSquare / 9);
											from.Y = (8 - (int)fromSquare % 9);
										}
										// dest
										{
											Common.Square destSquare = shogiMove.to ();
											dest.X = (8 - (int)destSquare / 9);
											dest.Y = (8 - (int)destSquare % 9);
										}
									}
								}
								// process
								// Debug.LogError("from, dest: "+from+"; "+dest+"; "+this);
								if (Common.isInsideBoard (from.X, from.Y) && Common.isInsideBoard (dest.X, dest.Y)) {
									if (from.X != dest.X || from.Y != dest.Y) {
										// Make point array
										Vector2[] points;
										{
											List<Vector2> temp = new List<Vector2> ();
											// From
											{
												Vector2 fro = new Vector2 (from.X + 0.5f - DeltaX, 
													from.Y + 0.5f - DeltaY);
												temp.Add (fro);
											}
											// Middle: for horse move
											{
												// Check is horse move
												bool isHorseMove = false;
												{
													if ((Mathf.Abs (from.X - dest.X) == 2 && Mathf.Abs (from.Y - dest.Y) == 1)
														|| (Mathf.Abs (from.X - dest.X) == 1 && Mathf.Abs (from.Y - dest.Y) == 2)) {
														isHorseMove = true;
													}
												}
												// Make point
												if (isHorseMove) {
													Vector2 middle = Vector2.zero;
													//
													if (from.X + 2 == dest.X) {
														middle = new Vector2 (from.X + 0.5f + 1, from.Y + 0.5f);
													} 
													//
													else if (from.X - 2 == dest.X) {
														middle = new Vector2 (from.X + 0.5f - 1, from.Y + 0.5f);
													} 
													//
													else if (from.Y + 2 == dest.Y) {
														middle = new Vector2 (from.X + 0.5f, from.Y + 1 + 0.5f);
													}
													//
													else if (from.Y - 2 == dest.Y) {
														middle = new Vector2 (from.X + 0.5f, from.Y - 1 + 0.5f);
													}
													temp.Add (new Vector2 (middle.x - DeltaX, middle.y - DeltaY));
												} else {
													// Debug.Log ("not horse move");
												}
											}
											// Des
											{
												Vector2 des = new Vector2 (dest.X + 0.5f - DeltaX,  dest.Y + 0.5f - DeltaY);
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
									} else {
										// position the same, so this is drop
										// Debug.LogError ("why position the same: " + from + "; " + dest + "; " + this);
										Vector2[] points = new Vector2[5];
										{
											points [0] = new Vector2 (dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
											points [1] = new Vector2 (dest.X - 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
											points [2] = new Vector2 (dest.X - 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY - 0.5f);
											points [3] = new Vector2 (dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY - 0.5f);
											points [4] = new Vector2 (dest.X + 0.5f - DeltaX + 0.5f, dest.Y + 0.5f - DeltaY + 0.5f);
										}
										lineRenderer.Points = points;
									}
								} else {
									Debug.LogError ("why position not inside board: " + from + "; " + dest + "; " + this);
									lineRenderer.Points = new Vector2[]{};
								}
							} else {
								Debug.LogError ("lineRenderer null: " + this);
							}
						}
						// Image
						if (imgHint != null) {
							imgHint.enabled = true;
							// sprite
							{
								// get piece type
								Common.Piece piece = Common.Piece.Empty;
								{
									if (this.data.isHint.v) {
										if (shogiMove.isDrop ()) {
											// Find playerIndex
											int playerIndex = 0;
											{
												ShogiGameDataUI.UIData shogiGameDataUIData = this.data.findDataInParent<ShogiGameDataUI.UIData> ();
												if (shogiGameDataUIData != null) {
													GameData gameData = shogiGameDataUIData.gameData.v.data;
													if (gameData != null) {
														Turn turn = gameData.turn.v;
														if (turn != null) {
															playerIndex = turn.playerIndex.v;
														} else {
															Debug.LogError ("turn null: " + this);
														}
													} else {
														Debug.LogError ("gameData null: " + this);
													}
												} else {
													Debug.LogError ("shogiGameDataUIData null: " + this);
												}
											}
											switch (playerIndex) {
											case 0:
												{
													switch (shogiMove.pieceTypeDropped ()) {
													case Common.PieceType.Pawn:
														piece = Common.Piece.BPawn;
														break;
													case Common.PieceType.Lance:
														piece = Common.Piece.BLance;
														break;
													case Common.PieceType.Knight:
														piece = Common.Piece.BKnight;
														break;
													case Common.PieceType.Silver:
														piece = Common.Piece.BSilver;
														break;
													case Common.PieceType.Bishop:
														piece = Common.Piece.BBishop;
														break;
													case Common.PieceType.Rook:
														piece = Common.Piece.BRook;
														break;
													case Common.PieceType.Gold:
														piece = Common.Piece.BGold;
														break;
													default:
														Debug.LogError ("unknow piece type: " + shogiMove.pieceTypeDropped () + "; " + this);
														break;
													}
												}
												break;
											case 1:
												{
													switch (shogiMove.pieceTypeDropped ()) {
													case Common.PieceType.Pawn:
														piece = Common.Piece.WPawn;
														break;
													case Common.PieceType.Lance:
														piece = Common.Piece.WLance;
														break;
													case Common.PieceType.Knight:
														piece = Common.Piece.WKnight;
														break;
													case Common.PieceType.Silver:
														piece = Common.Piece.WSilver;
														break;
													case Common.PieceType.Bishop:
														piece = Common.Piece.WBishop;
														break;
													case Common.PieceType.Rook:
														piece = Common.Piece.WRook;
														break;
													case Common.PieceType.Gold:
														piece = Common.Piece.WGold;
														break;
													default:
														Debug.LogError ("unknow piece type: " + shogiMove.pieceTypeDropped () + "; " + this);
														break;
													}
												}
												break;
											default:
												Debug.LogError ("unknown playerIndex: " + playerIndex + "; " + this);
												break;
											}
										}
									}
								}
								// process
								{
									// Find style
									Setting.Style style = Setting.get().style.v;
                                    // Process
                                    imgHint.sprite = ShogiSpriteContainer.get().getSprite(style, piece);
                                }
							}
							// position
							{
								Common.Square destSquare = shogiMove.to ();
								int destX = (8 - (int)destSquare / 9);
								int destY = (8 - (int)destSquare % 9);
								imgHint.transform.localPosition = new Vector3 (destX - DeltaX + 0.5f, destY - DeltaY + 0.5f, 0);
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
						// Debug.LogError ("shogiMove null: " + this);
						// lineRenderer
						if (lineRenderer != null) {
							lineRenderer.enabled = false;
						} else {
							Debug.LogError ("lineRenderer null: " + this);
						}
						// imgHint
						if (imgHint != null) {
							imgHint.enabled = false;
						} else {
							Debug.LogError ("imgHint null: " + this);
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

		#region implement callBack

		private ShogiGameDataUI.UIData shogiGameDataUIData = null;
		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().addCallBack(this);
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				// Child
				{
					uiData.shogiMove.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
            // Setting
            if(data is Setting)
            {
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
				if (data is ShogiGameDataUI.UIData) {
					ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
					// Child
					{
						shogiGameDataUIData.gameData.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.turn.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					if (data is Turn) {
						dirty = true;
						return;
					}
				}
			}
			// Child
			if (data is ShogiMove) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
                // Setting
                Setting.get().removeCallBack(this);
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.shogiGameDataUIData);
				}
				// Child
				{
					uiData.shogiMove.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
            // Setting
            if(data is Setting)
            {
                return;
            }
            // CheckChange
            if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is ShogiGameDataUI.UIData) {
					ShogiGameDataUI.UIData shogiGameDataUIData = data as ShogiGameDataUI.UIData;
					// Child
					{
						shogiGameDataUIData.gameData.allRemoveCallBack (this);
					}
					return;
				}
				// GameData
				{
					if (data is GameData) {
						GameData gameData = data as GameData;
						{
							gameData.turn.allRemoveCallBack (this);
						}
						return;
					}
					if (data is Turn) {
						return;
					}
				}
			}
			// Child
			if (data is ShogiMove) {
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
				case UIData.Property.shogiMove:
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
            // Setting
            if(wrapProperty.p is Setting)
            {
                switch ((Setting.Property)wrapProperty.n)
                {
                    case Setting.Property.language:
                        break;
                    case Setting.Property.style:
                        dirty = true;
                        break;
                    case Setting.Property.showLastMove:
                        break;
                    case Setting.Property.viewUrlImage:
                        break;
                    case Setting.Property.animationSetting:
                        break;
                    case Setting.Property.maxThinkCount:
                        break;
                    default:
                        Debug.LogError("Don't process: " + wrapProperty + "; " + this);
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
				if (wrapProperty.p is ShogiGameDataUI.UIData) {
					switch ((ShogiGameDataUI.UIData.Property)wrapProperty.n) {
					case ShogiGameDataUI.UIData.Property.gameData:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case ShogiGameDataUI.UIData.Property.isOnAnimation:
						break;
					case ShogiGameDataUI.UIData.Property.board:
						break;
					case ShogiGameDataUI.UIData.Property.lastMove:
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
							break;
						case GameData.Property.useRule:
							break;
						case GameData.Property.turn:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
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
					if (wrapProperty.p is Turn) {
						switch ((Turn.Property)wrapProperty.n) {
						case Turn.Property.turn:
							break;
						case Turn.Property.playerIndex:
							dirty = true;
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			// Child
			if (wrapProperty.p is ShogiMove) {
				switch ((ShogiMove.Property)wrapProperty.n) {
				case ShogiMove.Property.move:
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