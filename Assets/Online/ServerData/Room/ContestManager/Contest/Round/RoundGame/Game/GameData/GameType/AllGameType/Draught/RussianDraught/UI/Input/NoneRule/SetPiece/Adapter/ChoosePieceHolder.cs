﻿using UnityEngine;
using UnityEngine.UI;
using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections;
using System.Collections.Generic;

namespace RussianDraught.NoneRule
{
	public class ChoosePieceHolder : SriaHolderBehavior<ChoosePieceHolder.UIData>
	{

		#region UIData

		public class UIData : BaseItemViewsHolder
		{

			public VP<int> piece;

			#region Constructor

			public enum Property
			{
				piece
			}

			public UIData() : base()
			{
				this.piece = new VP<int>(this, (byte)Property.piece, Common.FREE);
			}

			#endregion

			public void updateView(ChoosePieceAdapter.UIData myParams)
			{
				// Find
				int piece = Common.FREE;
				{
					if (ItemIndex >= 0 && ItemIndex < myParams.pieces.Count) {
						piece = myParams.pieces [ItemIndex];
					} else {
						Debug.LogError ("ItemIdex error: " + this);
					}
				}
				// Update
				this.piece.v = piece;
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
							imgPiece.sprite = RussianDraughtPieceSprite.get ().getSprite (this.data.piece.v);
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
				case UIData.Property.piece:
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
					RussianDraughtCustomSet russianDraughtCustomSet = new RussianDraughtCustomSet ();
					{
						// square
						{
							SetPieceUI.UIData setPieceUIData = this.data.findDataInParent<SetPieceUI.UIData> ();
							if (setPieceUIData != null) {
								russianDraughtCustomSet.square.v = setPieceUIData.square.v;
							} else {
								Debug.LogError ("setPieceUIData null: " + this);
							}
						}
						russianDraughtCustomSet.piece.v = this.data.piece.v;
					}
					clientInput.makeSend (russianDraughtCustomSet);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}