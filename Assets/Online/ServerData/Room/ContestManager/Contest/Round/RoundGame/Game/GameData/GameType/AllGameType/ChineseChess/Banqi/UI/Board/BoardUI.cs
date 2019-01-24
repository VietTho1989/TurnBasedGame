using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Banqi
{
	public class BoardUI : UIBehavior<BoardUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<ReferenceData<Banqi>> banqi;

			public LP<PieceUI.UIData> pieces;

			#region Constructor

			public enum Property
			{
				banqi,
				pieces
			}

			public UIData() : base()
			{
				this.banqi = new VP<ReferenceData<Banqi>>(this, (byte)Property.banqi, new ReferenceData<Banqi>(null));
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
					Banqi banqi = this.data.banqi.v.data;
					if (banqi != null) {
						// check load full
						bool isLoadFull = true;
						{
							// chess
							if (isLoadFull) {
								if (string.IsNullOrEmpty (banqi.state.v)) {
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
								string state = banqi.state.v;
								{
									MoveAnimation moveAnimation = GameDataBoardUI.UIData.getCurrentMoveAnimation (this.data);
									if (moveAnimation != null) {
										switch (moveAnimation.getType ()) {
										case GameMove.Type.BanqiMove:
											{
												BanqiMoveAnimation banqiMoveAnimation = moveAnimation as BanqiMoveAnimation;
												state = banqiMoveAnimation.state.v;
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
									string[] graveyardSplit = state.Split (new char[]{ '.' });
									// string[] graveyardString = graveyardSplit [1].Split (new char[]{ ' ' });
									string[] split = graveyardSplit [0].Split (new char[]{ ' ' });
									Token.Ecolor color;
									Token.Type type;
									bool isFaceUp;
									for (int i = 0; i < split.Length; i++) {
										if (split [i].Equals ("XXX")) {
											continue;
										}
										if (string.IsNullOrEmpty (split [i])) {
											// Debug.LogError ("split i empty");
											continue;
										}
										if (split [i].Length >= 3) {
											if (split [i] [0] == 'B') {
												color = Token.Ecolor.BLACK;
											} else
												color = Token.Ecolor.RED;

											int temp = split [i] [1];
											switch (temp) {
											case '7':
												type = Token.Type.GENERAL;
												break;
											case '6':
												type = Token.Type.ADVISOR;
												break;
											case '5':
												type = Token.Type.ELEPHANT;
												break;
											case '4':
												type = Token.Type.CHARIOT;
												break;
											case '3':
												type = Token.Type.HORSE;
												break;
											case '2':
												type = Token.Type.CANNON;
												break;
											case '1':
												type = Token.Type.SOLDIER;
												break;
											default:
												Debug.LogError ("unknown type: " + temp);
												type = Token.Type.SOLDIER;
												break;
											}

											if (split [i] [2] == 'U') {
												isFaceUp = true;
											} else
												isFaceUp = false;

											// find UI
											PieceUI.UIData pieceUIData = null;
											bool needAdd = false;
											{
												// find old
												foreach (PieceUI.UIData check in oldPieces) {
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
													oldPieces.Remove (pieceUIData);
												}
											}
											// Update
											{
												pieceUIData.position.v = i;
												pieceUIData.type.v = type;
												pieceUIData.color.v = color;
												pieceUIData.isFaceUp.v = isFaceUp;
											}
											// Add
											if (needAdd) {
												this.data.pieces.add (pieceUIData);
											}
										} else {
											Debug.LogError ("split[i] length error");
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
						Debug.LogError ("banqi null");
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
					uiData.banqi.allAddCallBack (this);
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
				if (data is Banqi) {
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
					uiData.banqi.allRemoveCallBack (this);
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
				if (data is Banqi) {
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
				case UIData.Property.banqi:
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
				if (wrapProperty.p is Banqi) {
					switch ((Banqi.Property)wrapProperty.n) {
					case Banqi.Property.color:
						dirty = true;
						break;
					case Banqi.Property.state:
						dirty = true;
						break;
					case Banqi.Property.isCustom:
						dirty = true;
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