using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Shatranj
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData: Data
		{
			
			public VP<ReferenceData<Shatranj>> shatranj;

			public VP<ShatranjFenUI.UIData> shatranjFen;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				shatranj,
				shatranjFen,
				pieces
			}

			public UIData() : base()
			{
				this.shatranj = new VP<ReferenceData<Shatranj>>(this, (byte)Property.shatranj, new ReferenceData<Shatranj>(null));
				this.shatranjFen = new VP<ShatranjFenUI.UIData>(this, (byte)Property.shatranjFen, new ShatranjFenUI.UIData());
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
			}

			#endregion

		}

		#endregion

		#region refresh

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					Shatranj shatranj = this.data.shatranj.v.data;
					if (shatranj != null) {
						// check load full
						bool isLoadFull = true;
						{
							// chess
							if (isLoadFull) {
								if (shatranj.board.vs.Count == 0) {
									Debug.LogError ("board not load");
									isLoadFull = false;
								}
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// shatranjFen
							{
								ShatranjFenUI.UIData shatranjFenUIData = this.data.shatranjFen.v;
								if (shatranjFenUIData != null) {
									shatranjFenUIData.shatranj.v = new ReferenceData<Shatranj> (shatranj);
								} else {
									Debug.LogError ("shatranjFenUIData null: " + this);
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
								List<int> board = shatranj.board.vs;
								{
									MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.ShatranjMove:
											{
												ShatranjMoveAnimation shatranjMoveAnimation = moveAnimation as ShatranjMoveAnimation;
												board = shatranjMoveAnimation.board.vs;
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
									for (int index = 0; index < board.Count; index++) {
										int pieceIndex = board [index];
										if (pieceIndex >= 0 && pieceIndex <= (int)Common.Piece.PIECE_NB) {
											Common.Piece piece = (Common.Piece)pieceIndex;
											if (piece != Common.Piece.NO_PIECE) {
												bool needAdd = false;
												// Find pieceUI
												PieceUI.UIData pieceUIData = null;
												{
													// Find old
                                                    foreach(PieceUI.UIData check in oldPieceUIs)
                                                    {
                                                        if (check.position.v == index)
                                                        {
                                                            pieceUIData = check;
                                                            break;
                                                        }
                                                    }
													// Make new
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
													// piece
													pieceUIData.piece.v = piece;
													// position
													pieceUIData.position.v = index;
												}
												// Add
												if (needAdd) {
													this.data.pieces.add (pieceUIData);
												}
											} else {
												// Debug.Log ("pieceIndex wrong: " + piece + "; " + this);
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
						Debug.LogError ("shatranj null: " + this);
					}
				} else {
					// Debug.LogError ("why data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		public ShatranjFenUI shatranjFenPrefab;
		public Transform shatranjFenContainer;

		public PieceUI piecePrefab;
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
					uiData.shatranj.allAddCallBack (this);
					uiData.shatranjFen.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
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
				if (data is Shatranj) {
					dirty = true;
					return;
				}
				if (data is ShatranjFenUI.UIData) {
					ShatranjFenUI.UIData shatranjFenUIData = data as ShatranjFenUI.UIData;
					// UI
					{
						UIUtils.Instantiate (shatranjFenUIData, shatranjFenPrefab, shatranjFenContainer);
					}
					dirty = true;
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, this.transform);
					}
					// dirty = true;
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
					uiData.shatranj.allRemoveCallBack (this);
					uiData.shatranjFen.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
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
				if (data is Shatranj) {
					return;
				}
				if (data is ShatranjFenUI.UIData) {
					ShatranjFenUI.UIData shatranjFenUIData = data as ShatranjFenUI.UIData;
					// UI
					{
						shatranjFenUIData.removeCallBackAndDestroy (typeof(ShatranjFenUI));
					}
					return;
				}
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						pieceUIData.removeCallBackAndDestroy (typeof(PieceUI));
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
				case UIData.Property.shatranj:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.shatranjFen:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.pieces:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						// dirty = true;
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
				if (wrapProperty.p is Shatranj) {
					switch ((Shatranj.Property)wrapProperty.n) {
					case Shatranj.Property.board:
						dirty = true;
						break;
					case Shatranj.Property.byTypeBB:
						break;
					case Shatranj.Property.byColorBB:
						break;
					case Shatranj.Property.pieceCount:
						break;
					case Shatranj.Property.pieceList:
						break;
					case Shatranj.Property.index:
						break;
					case Shatranj.Property.gamePly:
						break;
					case Shatranj.Property.sideToMove:
						break;
					case Shatranj.Property.st:
						break;
					case Shatranj.Property.chess960:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				if (wrapProperty.p is ShatranjFenUI.UIData) {
					return;
				}
				if (wrapProperty.p is PieceUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}