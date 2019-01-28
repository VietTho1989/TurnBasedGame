﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace FairyChess.NoneRule
{
	public class SetHandUI : UIBehavior<SetHandUI.UIData>
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<SetHandAdapter.UIData> setHandAdapter;

			#region Constructor

			public enum Property
			{
				setHandAdapter
			}

			public UIData() : base()
			{
				this.setHandAdapter = new VP<SetHandAdapter.UIData>(this, (byte)Property.setHandAdapter, new SetHandAdapter.UIData());
			}

			#endregion

			public override Type getType ()
			{
				return Type.SetHand;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							SetHandUI setHandUI = this.findCallBack<SetHandUI> ();
							if (setHandUI != null) {
								setHandUI.onClickBtnBack ();
							} else {
								Debug.LogError ("setHandUI null: " + this);
							}
							isProcess = true;
						}
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public Transform contentContainer;

		public InputField edtPieceCount;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// Scale
					{
						if (contentContainer != null) {
							int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
							float scale = 0.015f;
							contentContainer.localScale = (playerView == 0 ? new Vector3 (scale, scale, 1f) : new Vector3 (scale, -scale, 1f));
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		#endregion

		#region implement callBacks

		private GameDataBoardCheckPerspectiveChange<UIData> checkPerspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData> ();

		public SetHandAdapter setHandAdapterPrefab;
		public Transform setHandAdapterContainer;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					checkPerspectiveChange.addCallBack (this);
					checkPerspectiveChange.setData (uiData);
				}
				// Child
				{
					uiData.setHandAdapter.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (data is SetHandAdapter.UIData) {
				SetHandAdapter.UIData setHandAdapterUIData = data as SetHandAdapter.UIData;
				// UI
				{
					UIUtils.Instantiate (setHandAdapterUIData, setHandAdapterPrefab, setHandAdapterContainer);
				}
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
					checkPerspectiveChange.removeCallBack (this);
					checkPerspectiveChange.setData (null);
				}
				// Child
				{
					uiData.setHandAdapter.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Child
			if (data is SetHandAdapter.UIData) {
				SetHandAdapter.UIData setHandAdapterUIData = data as SetHandAdapter.UIData;
				// UI
				{
					setHandAdapterUIData.removeCallBackAndDestroy (typeof(SetHandAdapter));
				}
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
				case UIData.Property.setHandAdapter:
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
			// CheckChange
			if (wrapProperty.p is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Child
			if (wrapProperty.p is SetHandAdapter.UIData) {
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		public void onClickBtnBack()
		{
			if (this.data != null) {
				NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
				if (noneRuleInputUIData != null) {
					ClickNoneUI.UIData clickNoneUIData = new ClickNoneUI.UIData ();
					{
						clickNoneUIData.uid = noneRuleInputUIData.sub.makeId ();
					}
					noneRuleInputUIData.sub.v = clickNoneUIData;
				} else {
					Debug.LogError ("noneRuleInputUIData null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickBtnSet()
		{
			if (this.data != null) {
				// get piece count
				if (edtPieceCount != null) {
					string strPieceCount = edtPieceCount.text;
					int pieceCount = 0;
					if (int.TryParse (strPieceCount, out pieceCount)) {
						// find chosen
						SetHandAdapter.UIData setHandAdapterUIData = this.data.setHandAdapter.v;
						if (setHandAdapterUIData != null) {
							Common.ColorAndPiece chosenPiece = setHandAdapterUIData.chosen.v;
							if (chosenPiece != null) {
								// send
								ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
								if (clientInput != null) {
									FairyChessCustomHand fairyChessCustomHand = new FairyChessCustomHand ();
									{
										fairyChessCustomHand.color.v = chosenPiece.color;
										fairyChessCustomHand.pieceType.v = chosenPiece.pieceType;
										fairyChessCustomHand.pieceCount.v = pieceCount;
									}
									clientInput.makeSend (fairyChessCustomHand);
								} else {
									Debug.LogError ("clientInput null: " + this);
								}
							} else {
								Debug.LogError ("chosenPiece null: " + this);
							}
						} else {
							Debug.LogError ("setHandAdapterUIData null: " + this);
						}
					} else {
						Debug.LogError ("pieceCount null: " + this);
					}
				} else {
					Debug.LogError ("edtPieceCount null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}