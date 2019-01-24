using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Janggi
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Janggi>> janggi;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				janggi,
				pieces
			}

			public UIData() : base()
			{
				this.janggi = new VP<ReferenceData<Janggi>>(this, (byte)Property.janggi, new ReferenceData<Janggi>(null));
				this.pieces = new LP<PieceUI.UIData>(this, (byte)Property.pieces);
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
					Janggi janggi = this.data.janggi.v.data;
					if (janggi != null) {
						// check load full
						bool isLoadFull = true;
						{
							// janggi
							if (isLoadFull) {
								if (janggi.stones.vs.Count == 0) {
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
							// get olds
							List<PieceUI.UIData> oldPieces = new List<PieceUI.UIData> ();
							{
								oldPieces.AddRange (this.data.pieces.vs);
							}
							// Update
							{
								// get data
								List<uint> stones = janggi.stones.vs;
								{
									MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.JanggiMove:
											{
												JanggiMoveAnimation janggiMoveAnimation = moveAnimation as JanggiMoveAnimation;
												stones = janggiMoveAnimation.stones.vs;
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
								// Update
								{
									for (int y = 0; y < Board.Height; y++) {
										for (int x = 0; x < Board.Width; x++) {
											int index = y * Board.Width + x;
											if (index >= 0 && index < stones.Count) {
												uint stone = stones [index];
												if (stone != (uint)StoneHelper.Stones.Empty) {
													// find pieceUI
													PieceUI.UIData pieceUIData = null;
													bool needAdd = false;
													{
														// find old
														foreach (PieceUI.UIData check in oldPieces) {
															if (check.x.v == x && check.y.v == y) {
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
															oldPieces.Remove (pieceUIData);
														}
													}
													// Update
													{
														pieceUIData.piece.v = stone;
														pieceUIData.x.v = x;
														pieceUIData.y.v = y;
													}
													// Add
													if (needAdd) {
														this.data.pieces.add (pieceUIData);
													}
												}
											} else {
												Debug.LogError ("index error: " + index + ", " + stones.Count);
											}
										}
									}
								}
							}
							// Remove old
							foreach (PieceUI.UIData oldPiece in oldPieces) {
								this.data.pieces.remove (oldPiece);
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("janggi null");
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
					uiData.janggi.allAddCallBack (this);
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
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						UIUtils.Instantiate (pieceUIData, piecePrefab, this.transform);
					}
					dirty = true;
					return;
				}
				if (data is Janggi) {
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
					uiData.janggi.allRemoveCallBack (this);
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
				if (data is PieceUI.UIData) {
					PieceUI.UIData pieceUIData = data as PieceUI.UIData;
					// UI
					{
						pieceUIData.removeCallBackAndDestroy (typeof(PieceUI));
					}
					return;
				}
				if (data is Janggi) {
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
				case UIData.Property.janggi:
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
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// checkChange
			if (wrapProperty.p is AnimationManagerCheckChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			{
				if (wrapProperty.p is PieceUI.UIData) {
					return;
				}
				if (wrapProperty.p is Janggi) {
					switch ((Janggi.Property)wrapProperty.n) {
					case Janggi.Property.stones:
						dirty = true;
						break;
					case Janggi.Property.targets:
						break;
					case Janggi.Property.blocks:
						break;
					case Janggi.Property.positions:
						break;
					case Janggi.Property.isMyTurn:
						break;
					case Janggi.Property.Point:
						break;
					case Janggi.Property.isMyFirst:
						break;
					case Janggi.Property.isCustom:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
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