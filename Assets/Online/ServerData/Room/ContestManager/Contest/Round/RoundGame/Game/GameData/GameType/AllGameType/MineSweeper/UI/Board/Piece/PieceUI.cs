using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace MineSweeper
{
	public class PieceUI : UIBehavior<PieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<int> x;

			public VP<int> y;

			public VP<sbyte> piece;

			public VP<sbyte> bomb;

			public VP<sbyte> flag;

			#region Constructor

			public enum Property
			{
				x,
				y,
				piece,
				bomb,
				flag
			}

			public UIData() : base()
			{
				this.x = new VP<int>(this, (byte)Property.x, 0);
				this.y = new VP<int>(this, (byte)Property.y, 0);
				this.piece = new VP<sbyte>(this, (byte)Property.piece, 0);
				this.bomb = new VP<sbyte>(this, (byte)Property.bomb, 0);
				this.flag = new VP<sbyte>(this, (byte)Property.flag, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public GameObject piece;
		public Text tvPiece;

		public Image imgBomb;
		public GameObject flag;

		private readonly Color alphaColor = new Color (1, 1, 1, 0.5f); 

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					if (this.data.x.v >= 0 && this.data.y.v >= 0) {
						// check load full
						bool isLoadFull = true;
						{
							// animation
							if (isLoadFull) {
								isLoadFull = AnimationManager.IsLoadFull (this.data);
							}
						}
						// process
						if (isLoadFull) {
							// piece
							{
								if (piece != null) {
									if (this.data.bomb.v == 0) {
										if (this.data.piece.v == -1) {
											// not set
											piece.SetActive (false);
										} else {
											// already set
											piece.SetActive (true);
											// tvPiece
											if (tvPiece != null) {
												tvPiece.text = (this.data.piece.v == 0) ? "" : "" + this.data.piece.v;
											} else {
												Debug.LogError ("tvPiece null: " + this);
											}
										}
									} else {
										// have bomb
										piece.SetActive (false);
									}
								} else {
									Debug.LogError ("piece null: " + this);
								}
							}
							// bomb
							{
								if (imgBomb != null) {
									if (this.data.bomb.v != 0) {
										// check is booom
										bool isBooom = false;
										bool canWatchBomb = false;
										{
											BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
											if (boardUIData != null) {
												isBooom = boardUIData.booom.v;
												canWatchBomb = boardUIData.allowWatchBomb.v;
											} else {
												Debug.LogError ("boardUIData null: " + this);
											}
										}
										// Process
										if (isBooom) {
											imgBomb.gameObject.SetActive (true);
											imgBomb.color = Color.white;
										} else {
											if (canWatchBomb) {
												imgBomb.gameObject.SetActive (true);
												imgBomb.color = alphaColor;
											} else {
												imgBomb.gameObject.SetActive (false);
											}
										}
									} else {
										imgBomb.gameObject.SetActive (false);
									}
								} else {
									Debug.LogError ("bomb null: " + this);
								}
							}
							// flag
							{
								if (flag != null) {
									// TODO Cu an het da
									flag.SetActive (false);
								} else {
									Debug.LogError ("flag null: " + this);
								}
							}
							// LocalPosition
							{
								BoardUI.UIData boardUIData = this.data.findDataInParent<BoardUI.UIData> ();
								if (boardUIData != null) {
									this.transform.localPosition = Common.converPosToLocalPosition (this.data.x.v, this.data.y.v, boardUIData);
								} else {
									Debug.LogError ("boardUIData null: " + this);
								}
							}
							// Scale: co le ko can
							/*{
								int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
								this.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
							}*/
						} else {
							Debug.LogError ("not load full");
							dirty = true;
						}
					} else {
						// contentContainer
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

		private BoardUI.UIData boardUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.boardUIData);
				}
				dirty = true;
				return;
			}
			// Parent
			if (data is BoardUI.UIData) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.boardUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			if (data is BoardUI.UIData) {
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
				case UIData.Property.x:
					dirty = true;
					break;
				case UIData.Property.y:
					dirty = true;
					break;
				case UIData.Property.piece:
					dirty = true;
					break;
				case UIData.Property.bomb:
					dirty = true;
					break;
				case UIData.Property.flag:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			if (wrapProperty.p is BoardUI.UIData) {
				switch ((BoardUI.UIData.Property)wrapProperty.n) {
				case BoardUI.UIData.Property.mineSweeper:
					break;
				case BoardUI.UIData.Property.background:
					break;
				case BoardUI.UIData.Property.pieces:
					break;
				case BoardUI.UIData.Property.booom:
					dirty = true;
					break;
				case BoardUI.UIData.Property.allowWatchBomb:
					dirty = true;
					break;
				case BoardUI.UIData.Property.maxWidth:
					dirty = true;
					break;
				case BoardUI.UIData.Property.maxHeight:
					dirty = true;
					break;
				case BoardUI.UIData.Property.x:
					dirty = true;
					break;
				case BoardUI.UIData.Property.y:
					dirty = true;
					break;
				case BoardUI.UIData.Property.width:
					dirty = true;
					break;
				case BoardUI.UIData.Property.height:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}