using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Khet
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Khet>> khet;

			public VP<FenUI.UIData> fen;

			public LP<PieceUI.UIData> pieces;

			public VP<LaserPathUI.UIData> laserPath;

			public VP<LaserTargetUI.UIData> laserTarget;

			#region Constructor

			public enum Property
			{
				khet,
				fen,
				pieces,
				laserPath,
				laserTarget
			}

			public UIData() : base()
			{
				this.khet = new VP<ReferenceData<Khet>>(this, (byte)Property.khet, new ReferenceData<Khet>(null));
				this.fen = new VP<FenUI.UIData>(this, (byte)Property.fen, new FenUI.UIData());
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
				this.laserPath = new VP<LaserPathUI.UIData>(this, (byte)Property.laserPath, new LaserPathUI.UIData());
				this.laserTarget = new VP<LaserTargetUI.UIData>(this, (byte)Property.laserTarget, new LaserTargetUI.UIData());
			}

			#endregion

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Khet khet = this.data.khet.v.data;
					if (khet != null) {
						// check load full
						bool isLoadFull = true;
						{
							// khet
							if (isLoadFull) {
								isLoadFull = khet.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// fen
							{
								FenUI.UIData fenUIData = this.data.fen.v;
								if (fenUIData != null) {
									fenUIData.khet.v = new ReferenceData<Khet> (khet);
								} else {
									Debug.LogError ("fenUIData null: " + this);
								}
							}
							// laserPath
							{
								LaserPathUI.UIData laserPathUIData = this.data.laserPath.v;
								if (laserPathUIData != null) {
									laserPathUIData.khet.v = new ReferenceData<Khet> (khet);
								} else {
									Debug.LogError ("laserPathUIData null: " + this);
								}
							}
							// laserTarget
							{
								LaserTargetUI.UIData laserTargetUIData = this.data.laserTarget.v;
								if (laserTargetUIData != null) {
									laserTargetUIData.khet.v = new ReferenceData<Khet> (khet);
								} else {
									Debug.LogError ("laserTargetUIData null: " + this);
								}
							}
							// Normal board
							{
								// get olds
								List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData> ();
								{
									oldPieceUIs.AddRange (this.data.pieces.vs);
								}
								// Find board
								List<byte> board = khet._board.vs;
								{
									MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.KhetMove:
											{
												KhetMoveAnimation khetMoveAnimation = moveAnimation as KhetMoveAnimation;
												board = khetMoveAnimation.board.vs;
											}
											break;
										default:
											Debug.LogError ("unknown type: " + moveAnimation.getType () + "; " + this);
											break;
										}
									} else {
										// Debug.LogError ("moveAnimation null: " + this);
									}
								}
								// Make pieceUI
								{
									for (int y = Common.BoardHeight - 1; y > -1; y--) {
										for (int x = 0; x < Common.BoardWidth; x++) {
											int position = y * Common.BoardWidth + x;
											if (position >= 0 && position < board.Count) {
												if (board [position] == Common.OffBoard) {
													// offboard
												} else if (board [position] == Common.Empty) {
													// empty
												} else {
													Common.Player player = Common.GetOwner (board [position]);
													Common.Piece piece = Common.GetPiece (board [position]);
													Common.Orientation orientation = Common.GetOrientation (board [position]);
													// find pieceUIData
													PieceUI.UIData pieceUIData = null;
													bool needAdd = false;
													{
														// find old
														foreach (PieceUI.UIData check in oldPieceUIs) {
															if (check.position.v == position) {
																pieceUIData = check;
																break;
															}
														}
														// make new
														if (pieceUIData == null) {
															pieceUIData = new PieceUI.UIData ();
															{
																pieceUIData.uid = this.data.pieces.makeId ();
															}
															needAdd = true;
														} else {
															oldPieceUIs.Remove (pieceUIData);
														}
													}
													// Update
													{
														pieceUIData.position.v = position;
														pieceUIData.piece.v = piece;
														pieceUIData.owner.v = player;
														pieceUIData.orientation.v = orientation;
													}
													// Add
													if (needAdd) {
														this.data.pieces.add (pieceUIData);
													}
												}
											} else {
												Debug.LogError ("position error: " + position + ", " + board.Count);
											}
										}
									}
								}
								// Remove oldPieceUIs not reuse
								foreach (PieceUI.UIData oldPieceUI in oldPieceUIs) {
									// oldPieceUI.position.v = -1;
									this.data.pieces.remove (oldPieceUI);
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("khet null");
					}
				} else {
					Debug.LogError ("data null");
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public FenUI fenPrefab;
		public Transform fenContainer;

		public PieceUI piecePrefab;
		public Transform pieceContainer;

		public LaserPathUI laserPathPrefab;
		public Transform laserPathContainer;

		public LaserTargetUI laserTargetPrefab;
		public Transform laserTargetContainer;

		private AnimationManagerCheckChange<UIData> animationManagerCheckChange = new AnimationManagerCheckChange<UIData> ();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					animationManagerCheckChange.needTimeChange = false;
					animationManagerCheckChange.addCallBack (this);
					animationManagerCheckChange.setData (uiData);
				}
				// Update
				{
					UpdateUtils.makeUpdate<AnimationSetDirtyUpdate, UIData> (uiData, this.transform);
				}
				// Child
				{
					uiData.khet.allAddCallBack (this);
					uiData.fen.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
					uiData.laserPath.allAddCallBack (this);
					uiData.laserTarget.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (data is Khet) {
					dirty = true;
					return;
				}
				if (data is FenUI.UIData) {
					FenUI.UIData fenUIData = data as FenUI.UIData;
					// UI
					{
						UIUtils.Instantiate (fenUIData, fenPrefab, fenContainer);
					}
					dirty = true;
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, pieceContainer);
					}
					dirty = true;
					return;
				}
				if (data is LaserPathUI.UIData) {
					LaserPathUI.UIData laserPathUIData = data as LaserPathUI.UIData;
					// UI
					{
						UIUtils.Instantiate (laserPathUIData, laserPathPrefab, laserPathContainer);
					}
					dirty = true;
					return;
				}
				if (data is LaserTargetUI.UIData) {
					LaserTargetUI.UIData laserTargetUIData = data as LaserTargetUI.UIData;
					// UI
					{
						UIUtils.Instantiate (laserTargetUIData, laserTargetPrefab, laserTargetContainer);
					}
					dirty = true;
					return;
				}
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					animationManagerCheckChange.removeCallBack (this);
					animationManagerCheckChange.setData (null);
				}
				// Update
				{
					uiData.removeCallBackAndDestroy (typeof(AnimationSetDirtyUpdate));
				}
				// Child
				{
					uiData.khet.allRemoveCallBack (this);
					uiData.fen.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
					uiData.laserPath.allRemoveCallBack (this);
					uiData.laserTarget.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			if (data is AnimationManagerCheckChange<UIData>) {
				return;
			}
			// Child
			{
				if (data is Khet) {
					return;
				}
				if (data is FenUI.UIData) {
					FenUI.UIData fenUIData = data as FenUI.UIData;
					// UI
					{
						fenUIData.removeCallBackAndDestroy (typeof(FenUI));
					}
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData subUIData = data as PieceUI.UIData;
					// UI
					{
						subUIData.removeCallBackAndDestroy (typeof(PieceUI));
					}
					return;
				}
				if (data is LaserPathUI.UIData) {
					LaserPathUI.UIData laserPathUIData = data as LaserPathUI.UIData;
					// UI
					{
						laserPathUIData.removeCallBackAndDestroy (typeof(LaserPathUI));
					}
					return;
				}
				if (data is LaserTargetUI.UIData) {
					LaserTargetUI.UIData laserTargetUIData = data as LaserTargetUI.UIData;
					// UI
					{
						laserTargetUIData.removeCallBackAndDestroy (typeof(LaserTargetUI));
					}
					return;
				}
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
				case UIData.Property.khet:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.fen:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pieces:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.laserPath:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.laserTarget:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Check Change
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is Khet) {
					switch ((Khet.Property)wrapProperty.n) {
					case Khet.Property._playerToMove:
						break;
					case Khet.Property._checkmate:
						break;
					case Khet.Property._drawn:
						break;
					case Khet.Property._moveNumber:
						break;
					case Khet.Property._laser:
						break;
					case Khet.Property._board:
						dirty = true;
						break;
					case Khet.Property._pharaohPositions:
						break;
					case Khet.Property.khetSub:
						break;
					case Khet.Property.isCustom:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is FenUI.UIData) {
					return;
				}
				if (wrapProperty.p is PieceUI.UIData) {
					return;
				}
				if (wrapProperty.p is LaserPathUI.UIData) {
					return;
				}
				if (wrapProperty.p is LaserTargetUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}