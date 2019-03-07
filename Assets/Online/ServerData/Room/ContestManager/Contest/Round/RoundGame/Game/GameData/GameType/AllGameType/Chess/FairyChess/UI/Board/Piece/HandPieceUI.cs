using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess
{
	public class HandPieceUI : UIBehavior<HandPieceUI.UIData>
	{

		#region UIData

		public class UIData : Data
		{

			public VP<Common.VariantType> variantType;

			public VP<Common.Piece> piece;

			public VP<int> count;

			#region Constructor

			public enum Property
			{
				variantType,
				piece,
				count
			}

			public UIData() : base()
			{
				this.variantType = new VP<Common.VariantType>(this, (byte)Property.variantType, Common.VariantType.asean);
				this.piece = new VP<Common.Piece>(this, (byte)Property.piece, Common.Piece.NO_PIECE);
				this.count = new VP<int>(this, (byte)Property.count, 0);
			}

			#endregion

		}

		#endregion

		#region Refresh

		public Image imgPiece;
		public Text txtCount;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
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
						// imgPiece
						{
							if (imgPiece != null) {
								SpriteContainer.setImagePiece (imgPiece, this.data.variantType.v, 
									Common.color_of (this.data.piece.v), Common.type_of (this.data.piece.v));
							} else {
								Debug.LogError ("imgPiece null: " + this);
							}
						}
						// txtCount
						{
							if (txtCount != null) {
								txtCount.text = "" + this.data.count.v;
							} else {
								Debug.LogError ("txtCount null: " + this);
							}
						}
						// scale
						{
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							// get localScale
							float localScale = 1;
							{
								// TODO Can hoan thien
							}
							this.transform.localScale = (playerView == 0 ? new Vector3 (localScale, localScale, 1f) : new Vector3 (localScale, -localScale, 1f));
						}
					} else {
						Debug.LogError ("not load full");
						dirty = true;
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

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
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
				case UIData.Property.variantType:
					dirty = true;
					break;
				case UIData.Property.piece:
					dirty = true;
					break;
				case UIData.Property.count:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}