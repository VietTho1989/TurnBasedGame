using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace InternationalDraught.NoneRule
{
	public class ChoosePieceHolder : SriaHolderBehavior<ChoosePieceHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<Common.Piece_Side> pieceSide;

			#region Constructor

			public enum Property
			{
				pieceSide
			}

			public UIData() : base()
			{
				this.pieceSide = new VP<Common.Piece_Side>(this, (byte)Property.pieceSide, Common.Piece_Side.Empty);
			}

			#endregion

			public void updateView(ChoosePieceAdapter.UIData myParams)
			{
				// Find
				Common.Piece_Side pieceSide = Common.Piece_Side.Empty;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.pieceSides.Count) {
						pieceSide = myParams.pieceSides [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.pieceSide.v = pieceSide;
			}

		}

		#endregion

		#region Refresh

		public Image imgPiece;

		public override void refresh ()
		{
			base.refresh ();
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// imgPiece
					{
						if (imgPiece != null) {
							imgPiece.sprite = InternationalDraughtSpriteContainer.get ().getSprite ((int)this.data.pieceSide.v);
						} else {
							Debug.LogError ("imgPiece null: " + this);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Child
				{

				}
				this.setDataNull (uiData);
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
				case UIData.Property.pieceSide:
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

		public void onClickBtnChoose()
		{
			if (this.data != null) {
				// Find ClientInput
				ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
				// Process
				if (clientInput != null) {
					InternationalDraughtCustomSet internationalDraughtCustomSet = new InternationalDraughtCustomSet ();
					{
						// square
						{
							SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData> ();
							if (setPieceUIData != null) {
								internationalDraughtCustomSet.square.v = setPieceUIData.square.v;
							} else {
								Debug.LogError ("setPieceUIData null: " + this);
							}
						}
						internationalDraughtCustomSet.pieceSide.v = this.data.pieceSide.v;
					}
					clientInput.makeSend (internationalDraughtCustomSet);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}