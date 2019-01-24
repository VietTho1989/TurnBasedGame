using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NineMenMorris
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<NineMenMorris>> nineMenMorris;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				nineMenMorris,
				pieces
			}

			public UIData() : base()
			{
				this.nineMenMorris = new VP<ReferenceData<NineMenMorris>>(this, (byte)Property.nineMenMorris, new ReferenceData<NineMenMorris>(null));
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
					NineMenMorris nineMenMorris = this.data.nineMenMorris.v.data;
					if (nineMenMorris != null) {
						// check load full
						bool isLoadFull = true;
						{
							// nineMenMorris
							if (isLoadFull) {
								isLoadFull = nineMenMorris.isLoadFull ();
							}
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// get olds
							List<PieceUI.UIData> oldPieceUIs = new List<PieceUI.UIData> ();
							{
								oldPieceUIs.AddRange (this.data.pieces.vs);
							}
							// board
							List<int> board = nineMenMorris.board.vs;
							int placePos = -1;
							Common.SpotStatus placePiece = Common.SpotStatus.SS_Empty;
							{
								MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
								if (moveAnimation != null) {
									switch (moveAnimation.getType ()) {
									case GameMove.Type.NineMenMorrisMove:
										{
											NineMenMorrisMoveAnimation nineMenMorrisMoveAnimation = moveAnimation as NineMenMorrisMoveAnimation;
											board = nineMenMorrisMoveAnimation.board.vs;
											if (nineMenMorrisMoveAnimation.positioningDuration.v > 0) {
												placePos = nineMenMorrisMoveAnimation.moved.v;
												placePiece = nineMenMorrisMoveAnimation.turn.v % 2 == 0 ? Common.SpotStatus.SS_White : Common.SpotStatus.SS_Black;
											}
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
							// update
							{
								for (int i = 0; i < Common.BOARD_SPOT; i++) {
									// get piece
									Common.SpotStatus piece = Common.SpotStatus.SS_Empty;
									{
										if (i == placePos) {
											piece = placePiece;
										} else if (i >= 0 && i < board.Count) {
											piece = (Common.SpotStatus)board [i];
										}
									}
									if (piece != Common.SpotStatus.SS_Empty) {
										// find pieceUI
										PieceUI.UIData pieceUIData = null;
										bool needAdd = false;
										{
											// find old
											foreach (PieceUI.UIData check in oldPieceUIs) {
												if (check.position.v == i) {
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
											pieceUIData.position.v = i;
											pieceUIData.piece.v = piece;
										}
										// add
										if (needAdd) {
											this.data.pieces.add (pieceUIData);
										}
									}
								}
							}
							// remove old
							foreach (PieceUI.UIData oldPieceUI in oldPieceUIs) {
								this.data.pieces.remove (oldPieceUI);
							}
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						Debug.LogError ("nineMenMorris null");
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
					uiData.nineMenMorris.allAddCallBack (this);
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
				if (data is NineMenMorris) {
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
					uiData.nineMenMorris.allRemoveCallBack (this);
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
				if (data is NineMenMorris) {
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
				case UIData.Property.nineMenMorris:
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
				if (wrapProperty.p is NineMenMorris) {
					switch ((NineMenMorris.Property)wrapProperty.n) {
					case NineMenMorris.Property.board:
						dirty = true;
						break;
					case NineMenMorris.Property.moved:
						break;
					case NineMenMorris.Property.moved_to:
						break;
					case NineMenMorris.Property.action:
						break;
					case NineMenMorris.Property.mill:
						break;
					case NineMenMorris.Property.terminal:
						break;
					case NineMenMorris.Property.removed:
						break;
					case NineMenMorris.Property.utility:
						break;
					case NineMenMorris.Property.turn:
						break;
					case NineMenMorris.Property.isCustom:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
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