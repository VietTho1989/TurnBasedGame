using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Xiangqi
{
	public class XiangqiBoardUI : UIBehavior<XiangqiBoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{
			
			public VP<ReferenceData<Xiangqi>> xiangqi;

			public VP<XiangqiFenUI.UIData> xiangqiFen;

			public LP<XiangqiPieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				xiangqi,
				xiangqiFen,
				pieces
			}

			public UIData() : base()
			{
				this.xiangqi = new VP<ReferenceData<Xiangqi>>(this, (byte)Property.xiangqi, new ReferenceData<Xiangqi>(null));
				this.xiangqiFen = new VP<XiangqiFenUI.UIData>(this, (byte)Property.xiangqiFen, new XiangqiFenUI.UIData());
				this.pieces = new LP<XiangqiPieceUI.UIData>(this, (byte)Property.pieces);
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
					Xiangqi xiangqi = this.data.xiangqi.v.data;
					if (xiangqi != null) {
						// check load full
						bool isLoadFull = true;
						{
							// chess
							if (isLoadFull) {
								if (xiangqi.ucpcSquares.vs.Count == 0) {
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
							// xiangqiFen
							{
								XiangqiFenUI.UIData xiangqiFenUIData = this.data.xiangqiFen.v;
								if (xiangqiFenUIData != null) {
									xiangqiFenUIData.xiangqi.v = new ReferenceData<Xiangqi> (xiangqi);
								} else {
									Debug.LogError ("xiangqiFenUIData null: " + this);
								}
							}
							// Normal board
							{
								// get olds
								List<XiangqiPieceUI.UIData> oldPieceUIs = new List<XiangqiPieceUI.UIData> ();
								{
									oldPieceUIs.AddRange (this.data.pieces.vs);
								}
								// make pieceUI
								{
									// find ucpcSquares
									List<byte> ucpcSquares = xiangqi.ucpcSquares.vs;
									{
										MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
										if (moveAnimation != null) {
											switch (moveAnimation.getType ()) {
											case GameMove.Type.XiangqiMove:
												{
													XiangqiMoveAnimation xiangqiMoveAnimation = moveAnimation as XiangqiMoveAnimation;
													ucpcSquares = xiangqiMoveAnimation.ucpcSquares.vs;
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
									// Process
									{
										int[,] board = Common.getBoardArray (ucpcSquares);
										for (int y = 0; y < 10; y++)
											for (int x = 0; x < 9; x++) {
												// get piece
												int piece = board [x, y];
												if (piece != 0) {
													int position = 9 * y + x;
													// find pieceUI
													bool needAdd = false;
													XiangqiPieceUI.UIData pieceUIData = null;
													{
														// find old
														{
															for (int i = 0; i < oldPieceUIs.Count; i++) {
																XiangqiPieceUI.UIData check = oldPieceUIs [i];
																if (check.position.v < 0) {
																	pieceUIData = check;
																} else if (check.position.v == position) {
																	pieceUIData = check;
																	break;
																}
															}
														}
														// make new
														if (pieceUIData == null) {
															pieceUIData = new XiangqiPieceUI.UIData ();
															{
																pieceUIData.uid = this.data.pieces.makeId ();
															}
															needAdd = true;
														} else {
															oldPieceUIs.Remove (pieceUIData);
														}
													}
													// update property
													{
														// piece
														pieceUIData.piece.v = piece;
														// position
														pieceUIData.position.v = position;
													}
													// add
													if (needAdd) {
														this.data.pieces.add (pieceUIData);
													}
												}
											}
									}
								}
								// remove old pieceUI not used
								foreach (XiangqiPieceUI.UIData oldPieceUI in oldPieceUIs) {
									this.data.pieces.remove(oldPieceUI);
								}
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						// Debug.LogError ("xiangqi null: " + this);
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

		public XiangqiFenUI xiangqiFenPrefab;
		public Transform xiangqiFenContainer;

		public XiangqiPieceUI piecePrefab;
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
					uiData.xiangqi.allAddCallBack (this);
					uiData.xiangqiFen.allAddCallBack (this);
					uiData.pieces.allAddCallBack (this);
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
				if (data is XiangqiPieceUI.UIData) {
					XiangqiPieceUI.UIData pieceUIData = data as XiangqiPieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, this.transform);
					}
					// dirty = true;
					return;
				}
				if (data is XiangqiFenUI.UIData) {
					XiangqiFenUI.UIData xiangqiFenUIData = data as XiangqiFenUI.UIData;
					// UI
					{
						UIUtils.Instantiate (xiangqiFenUIData, xiangqiFenPrefab, xiangqiFenContainer);
					}
					dirty = true;
					return;
				}
				if (data is Xiangqi) {
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
					uiData.xiangqi.allRemoveCallBack (this);
					uiData.xiangqiFen.allRemoveCallBack (this);
					uiData.pieces.allRemoveCallBack (this);
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
				if (data is XiangqiPieceUI.UIData) {
					XiangqiPieceUI.UIData pieceUIData = data as XiangqiPieceUI.UIData;
					// UI
					{
						pieceUIData.removeCallBackAndDestroy (typeof(XiangqiPieceUI));
					}
					return;
				}
				if (data is XiangqiFenUI.UIData) {
					XiangqiFenUI.UIData xiangqiFenUIData = data as XiangqiFenUI.UIData;
					// UI
					{
						xiangqiFenUIData.removeCallBackAndDestroy (typeof(XiangqiFenUI));
					}
					return;
				}
				if (data is Xiangqi) {
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
				case UIData.Property.xiangqi:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				case UIData.Property.xiangqiFen:
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
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is XiangqiPieceUI.UIData) {
					return;
				}
				if (wrapProperty.p is XiangqiFenUI.UIData) {
					return;
				}
				if (wrapProperty.p is Xiangqi) {
					switch ((Xiangqi.Property)wrapProperty.n) {
					case Xiangqi.Property.sdPlayer:
						break;
					case Xiangqi.Property.ucpcSquares:
						dirty = true;
						break;
					case Xiangqi.Property.ucsqPieces:
						break;
					case Xiangqi.Property.zobr:
						break;
					case Xiangqi.Property.dwBitPiece:
						break;
					case Xiangqi.Property.wBitRanks:
						break;
					case Xiangqi.Property.wBitFiles:
						break;
					case Xiangqi.Property.vlWhite:
						break;
					case Xiangqi.Property.vlBlack:
						break;
					case Xiangqi.Property.nMoveNum:
						break;
					case Xiangqi.Property.nDistance:
						break;
					case Xiangqi.Property.rbsList:
						break;
					case Xiangqi.Property.ucRepHash:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}