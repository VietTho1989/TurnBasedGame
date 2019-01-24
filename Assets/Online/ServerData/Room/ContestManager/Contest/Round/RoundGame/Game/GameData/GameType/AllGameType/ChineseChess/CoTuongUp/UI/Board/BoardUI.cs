using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Rule;

namespace CoTuongUp
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData: Data
		{
			
			public VP<ReferenceData<CoTuongUp>> coTuongUp;

			public VP<bool> isWatcher;

			public LP<PieceUI.UIData> pieces;

			public LP<CaptureUI.UIData> captures;

			#region Constructor

			public enum Property
			{
				coTuongUp,
				isWatcher,
				pieces,
				captures
			}

			public UIData() : base()
			{
				this.coTuongUp = new VP<ReferenceData<CoTuongUp>>(this, (byte)Property.coTuongUp, new ReferenceData<CoTuongUp>(null));
				this.isWatcher = new VP<bool>(this, (byte)Property.isWatcher, false);
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
				this.captures = new LP<CaptureUI.UIData>(this, (byte)Property.captures);
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
					CoTuongUp coTuongUp = this.data.coTuongUp.v.data;
					if (coTuongUp != null) {
						// check load full
						bool isLoadFull = true;
						{
							// coTuongUp
							if (isLoadFull) {
								isLoadFull = coTuongUp.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// check canView
							{
								bool canView = false;
								{
									if (coTuongUp.allowWatcherViewHidden.v) {
										bool isYouViewer = true;
										{
											Game game = coTuongUp.findDataInParent<Game> ();
											if (game != null) {
												for (int i = 0; i < game.gamePlayers.vs.Count; i++) {
													GamePlayer gamePlayer = game.gamePlayers.vs [i];
													if (gamePlayer.inform.v is Human) {
														Human human = gamePlayer.inform.v as Human;
														if (human.playerId.v == Server.getProfileUserId (game)) {
															isYouViewer = false;
														}
													}
												}
											} else {
												Debug.LogError ("duel null: " + this);
												isYouViewer = false;
											}
										}
										if (isYouViewer) {
											canView = true;
										}
									}
								}
								this.data.isWatcher.v = canView;
							}
							// Update pieces, captures
							{
								// Find current node
								Node currentNode = null;
								{
									MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.CoTuongUpMove:
											{
												CoTuongUpMoveAnimation coTuongUpMoveAnimation = moveAnimation as CoTuongUpMoveAnimation;
												currentNode = coTuongUpMoveAnimation.node.v;
											}
											break;
										default:
											Debug.LogError ("unknown type: " + moveAnimation.getType () + "; " + this);
											break;
										}
									} else {
										if (coTuongUp.nodes.vs.Count > 0) {
											currentNode = coTuongUp.nodes.vs [coTuongUp.nodes.vs.Count - 1];
										}
									}
								}
								if (currentNode != null) {
									// Normal board
									{
										// get olds
										List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData> ();
										{
											oldPieceUIs.AddRange (this.data.pieces.vs);
										}
										// Make pieceUI
										{
											Board board = Rule.getBoard (currentNode);
											for (byte x = 0; x < board.board.GetLength (0); x++)
												for (byte y = 0; y < board.board.GetLength (1); y++) {
													if (board.board [x, y] != 0) {
														byte coord = Common.makeCoord (x, y);
														// Find pieceUIData
														bool needAdd = false;
														PieceUI.UIData pieceUIData = null;
														{
															// find old
															for (int i = 0; i < oldPieceUIs.Count; i++) {
																PieceUI.UIData check = oldPieceUIs [i];
																if (check.coord.v == coord) {
																	pieceUIData = check;
																	break;
																} else if (check.animationCoord == coord) {
																	pieceUIData = check;
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
														// Update Property
														{
															// coord
															pieceUIData.coord.v = coord;
															// piece
															pieceUIData.piece.v = board.board [x, y];
														}
														// add
														if (needAdd) {
															this.data.pieces.add (pieceUIData);
														}
													}
												}
										}
										// Remove oldPieceUIs not reuse
										foreach (PieceUI.UIData pieceUIData in oldPieceUIs) {
											this.data.pieces.remove (pieceUIData);
										}
									}
									// Captures
									{
										// get old list
										List<CaptureUI.UIData> oldCaptureUIs = new List<CaptureUI.UIData> ();
										{
											oldCaptureUIs.AddRange (this.data.captures.vs);
										}
										// Update
										{
											for (int i = 0; i < currentNode.captures.vs.Count; i++) {
												byte capture = currentNode.captures.vs [i];
												// Debug.LogError ("make captureUIData: " + capture + "; " + this);
												// Find captureUIData
												CaptureUI.UIData captureUIData = null;
												{
													// Find old
													{
														if (oldCaptureUIs.Count > 0) {
															captureUIData = oldCaptureUIs [0];
															oldCaptureUIs.RemoveAt (0);
														}
													}
													// Make new
													if (captureUIData == null) {
														captureUIData = new CaptureUI.UIData ();
														{
															captureUIData.uid = this.data.captures.makeId ();
														}
														this.data.captures.add (captureUIData);
													}
												}
												// Update Property
												{
													captureUIData.piece.v = capture;
												}
											}
										}
										// Remove old
										foreach (CaptureUI.UIData captureUIData in oldCaptureUIs) {
											this.data.captures.remove (captureUIData);
										}
									}
								} else {
									Debug.LogError ("currentNode null: " + this);
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("coTuongUp null: " + this);
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

		public PieceUI piecePrefab;

		public Transform captureContainer;
		public CaptureUI capturePrefab;

		private GameCheckPlayerChange<CoTuongUp> gameCheckPlayerChange = new GameCheckPlayerChange<CoTuongUp> ();
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
					uiData.coTuongUp.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
					uiData.captures.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<UIData>) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				// CoTuongUp
				{
					if (data is CoTuongUp) {
						CoTuongUp coTuongUp = data as CoTuongUp;
						// CheckChange
						{
							gameCheckPlayerChange.addCallBack (this);
							gameCheckPlayerChange.setData (coTuongUp);
						}
						// Child
						{
							coTuongUp.nodes.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// CheckChange
					if (data is GameCheckPlayerChange<CoTuongUp>) {
						dirty = true;
						return;
					}
					// Child
					if (data is Node) {
						dirty = true;
						return;
					}
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is CaptureUI.UIData) {
					CaptureUI.UIData captureUIData = data as CaptureUI.UIData;
					// UI
					{
						UIUtils.Instantiate (captureUIData, capturePrefab, captureContainer);
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
					uiData.coTuongUp.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
					uiData.captures.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// checkChange
			{
				if (data is AnimationManagerCheckChange<UIData>) {
					return;
				}
			}
			// Child
			{
				// CoTuongUp
				{
					if (data is CoTuongUp) {
						CoTuongUp coTuongUp = data as CoTuongUp;
						// CheckChange
						{
							gameCheckPlayerChange.removeCallBack (this);
							gameCheckPlayerChange.setData (null);
						}
						// Child
						{
							coTuongUp.nodes.allRemoveCallBack (this);
						}
						return;
					}
					if (data is GameCheckPlayerChange<CoTuongUp>) {
						return;
					}
					if (data is Node) {
						return;
					}
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						pieceUIData.removeCallBackAndDestroy (typeof(PieceUI));
					}
					return;
				}
				if (data is CaptureUI.UIData) {
					CaptureUI.UIData captureUIData = data as CaptureUI.UIData;
					// UI
					{
						captureUIData.removeCallBackAndDestroy (typeof(CaptureUI));
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
				case UIData.Property.coTuongUp:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.isWatcher:
					break;
				case UIData.Property.pieces:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.captures:
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
			{
				if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				// CoTuongUp
				{
					if (wrapProperty.p is CoTuongUp) {
						switch ((CoTuongUp.Property)wrapProperty.n) {
						case CoTuongUp.Property.allowOnlyFlip:
							break;
						case CoTuongUp.Property.turn:
							break;
						case CoTuongUp.Property.side:
							break;
						case CoTuongUp.Property.nodes:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case CoTuongUp.Property.plyDraw:
							break;
						case CoTuongUp.Property.isCustom:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					if(wrapProperty.p is GameCheckPlayerChange<CoTuongUp>){
						dirty = true;
						return;
					}
					if (wrapProperty.p is Node) {
						switch ((Node.Property)wrapProperty.n) {
						case Node.Property.ply:
							break;
						case Node.Property.pieces:
							dirty = true;
							break;
						case Node.Property.captures:
							dirty = true;
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				if (wrapProperty.p is PieceUI.UIData) {
					return;
				}
				if (wrapProperty.p is CaptureUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}