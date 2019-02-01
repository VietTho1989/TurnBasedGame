using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RussianDraught
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<RussianDraught>> russianDraught;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				russianDraught,
				pieces
			}

			public UIData() : base()
			{
				this.russianDraught = new VP<ReferenceData<RussianDraught>>(this, (byte)Property.russianDraught, new ReferenceData<RussianDraught>(null));
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public override void refresh ()
		{
			if (dirty) {
				if (this.data != null) {
					RussianDraught russianDraught = this.data.russianDraught.v.data;
					if (russianDraught != null) {
						// check load full
						bool isLoadFull = true;
						{
							// russianDraught
							if (isLoadFull) {
								isLoadFull = russianDraught.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// pieces
							{
								// get old
								List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData> ();
								{
									oldPieces.AddRange (this.data.pieces.vs);
								}
								// update board
								{
									// get board matrix
									int[,] b = new int[8, 8];
									{
										// get board array
										List<int> Board = russianDraught.Board.vs;
										{
											MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
											if (moveAnimation != null) {
												switch (moveAnimation.getType ()) {
												case GameMove.Type.RussianDraughtMove:
													{
														RussianDraughtMoveAnimation russianDraughtMoveAnimation = moveAnimation as RussianDraughtMoveAnimation;
														Board = russianDraughtMoveAnimation.Board.vs;
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
										// make board matrix
										Common.makeBoardMatrix (b, Board);
									}
									for (int y = 0; y < 8; y++) {
										for (int x = 0; x < 8; x++) {
											int square = x + 8 * y;
											int piece = b [x, y];
											if (Common.isRealPiece (piece)) {
												bool needAdd = false;
												// Find PieceUI
												PieceUI.UIData pieceUIData = null;
												{
													// Find old
                                                    foreach(PieceUI.UIData check in oldPieces)
                                                    {
                                                        if (check.square.v == square)
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
														oldPieces.Remove (pieceUIData);
													}
												}
												// Update Property
												{
													pieceUIData.square.v = square;
													pieceUIData.piece.v = piece;
												}
												// Add
												if (needAdd) {
													this.data.pieces.add (pieceUIData);
												}
											}
										}
									}
								}
								// remove unused piece
								foreach (PieceUI.UIData oldPiece in oldPieces) {
									this.data.pieces.remove (oldPiece);
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("russianDraught null: " + this);
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
					uiData.russianDraught.allAddCallBack (this);
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
				if (data is RussianDraught) {
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
					uiData.russianDraught.allRemoveCallBack (this);
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
				if (data is RussianDraught) {
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
			if(WrapProperty.checkError(wrapProperty)){
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.russianDraught:
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
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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
				if (wrapProperty.p is RussianDraught) {
					switch ((RussianDraught.Property)wrapProperty.n) {
					case RussianDraught.Property.Board:
						dirty = true;
						break;
					case RussianDraught.Property.num_wpieces:
						break;
					case RussianDraught.Property.num_bpieces:
						break;
					case RussianDraught.Property.Color:
						break;
					case RussianDraught.Property.g_root_mb:
						break;
					case RussianDraught.Property.realdepth:
						break;
					case RussianDraught.Property.RepNum:
						break;
					case RussianDraught.Property.HASH_KEY:
						break;
					case RussianDraught.Property.p_list:
						break;
					case RussianDraught.Property.indices:
						break;
					case RussianDraught.Property.g_pieces:
						break;
					case RussianDraught.Property.Reversible:
						break;
					case RussianDraught.Property.c_num:
						break;
					case RussianDraught.Property.isCustom:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
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