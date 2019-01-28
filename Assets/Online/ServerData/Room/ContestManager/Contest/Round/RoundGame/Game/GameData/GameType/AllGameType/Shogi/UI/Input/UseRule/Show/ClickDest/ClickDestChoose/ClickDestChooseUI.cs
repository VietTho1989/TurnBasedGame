﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Shogi.UseRule
{
	public class ClickDestChooseUI : UIBehavior<ClickDestChooseUI.UIData>, BtnChosenMoveUI.OnClick
	{

		#region UIData

		public class UIData : ClickDestUI.UIData.Sub
		{

			public VP<Common.Square> square;

			public LP<BtnChosenMoveUI.UIData> btnChosenMoves;

			#region Constructor

			public enum Property
			{
				square,
				btnChosenMoves
			}

			public UIData() : base()
			{
				this.square = new VP<Common.Square>(this, (byte)Property.square, Common.Square.SQ11);
				this.btnChosenMoves = new LP<BtnChosenMoveUI.UIData>(this, (byte)Property.btnChosenMoves);
			}

			#endregion

			public override Type getType ()
			{
				return Type.Choose;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							ClickDestChooseUI clickDestChooseUI = this.findCallBack<ClickDestChooseUI> ();
							if (clickDestChooseUI != null) {
								clickDestChooseUI.onClickCancel ();
							} else {
								Debug.LogError ("clickDestChooseUI null: " + this);
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

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					List<ShogiMove> shogiMoves = new List<ShogiMove> ();
					{
						ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
						ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
						if (showUIData != null && clickDestUIData != null) {
							for (int i = 0; i < showUIData.legalMoves.vs.Count; i++) {
								ShogiMove legalMove = showUIData.legalMoves.vs [i];
								if (legalMove.from() == clickDestUIData.square.v && legalMove.to () == this.data.square.v) {
									shogiMoves.Add (legalMove);
								}
							}
						}
					}
					// contentContainer
					{
						if (contentContainer != null) {
							if (shogiMoves.Count > 1) {
								contentContainer.gameObject.SetActive (true);
							} else {
								contentContainer.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
					// btnChoseMoves
					if (shogiMoves.Count == 0) {
						Debug.LogError ("why chessMoves count = 0: " + this);
						// chuyen ve ClickPieceUI
						ShowUI.UIData showUI = this.data.findDataInParent<ShowUI.UIData> ();
						if (showUI != null) {
							ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
							{
								clickPieceUIData.uid = showUI.sub.makeId ();
							}
							showUI.sub.v = clickPieceUIData;
						} else {
							Debug.LogError ("showUI null: " + this);
						}
					} else if (shogiMoves.Count == 1) {
						ShogiMove shogiMove = shogiMoves [0];
						// Send
						ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
						if (clientInput != null) {
							clientInput.makeSend (shogiMove);
						} else {
							Debug.LogError ("clientInput null: " + this);
						}
					} else {
						List<BtnChosenMoveUI.UIData> oldBntChoseMoves = new List<BtnChosenMoveUI.UIData> ();
						// get olds
						oldBntChoseMoves.AddRange(this.data.btnChosenMoves.vs);
						// Update
						{
							for (int i = 0; i < shogiMoves.Count; i++) {
								ShogiMove shogiMove = shogiMoves [i];
								// Find bntChoseMoveUI
								BtnChosenMoveUI.UIData btnChoseMoveUIData = null;
								{
									// Find old
									if (oldBntChoseMoves.Count > 0) {
										btnChoseMoveUIData = oldBntChoseMoves [0];
										oldBntChoseMoves.RemoveAt (0);
									}
									// Make new
									if (btnChoseMoveUIData == null) {
										btnChoseMoveUIData = new BtnChosenMoveUI.UIData ();
										{
											btnChoseMoveUIData.uid = this.data.btnChosenMoves.makeId ();
										}
										this.data.btnChosenMoves.add (btnChoseMoveUIData);
									}
								}
								// Update Property
								if (btnChoseMoveUIData != null) {
									// chessMove
									btnChoseMoveUIData.shogiMove.v = new ReferenceData<ShogiMove> (shogiMove);
									// onClick
									btnChoseMoveUIData.onClick.v = this;
								} else {
									Debug.LogError ("btnChoseMoveUIData null: " + this);
								}
							}
						}
						// Remove old
						for (int i = 0; i < oldBntChoseMoves.Count; i++) {
							this.data.btnChosenMoves.remove (oldBntChoseMoves [i]);
						}
					}
				} else {
					// Debug.LogError ("data null: " + this);
					if (contentContainer != null) {
						contentContainer.gameObject.SetActive (false);
					} else {
						Debug.LogError ("contentContainer null: " + this);
					}
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return true;
		}

		public void onClickMove (ShogiMove shogiMove)
		{
			if (this.data != null) {
				// Send
				ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
				if (clientInput != null) {
					clientInput.makeSend (shogiMove);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onClickCancel()
		{
			Debug.LogError ("onClickCancel: " + this);
			if (this.data != null) {
				ShowUI.UIData showUI = this.data.findDataInParent<ShowUI.UIData> ();
				if (showUI != null) {
					ClickPieceUI.UIData clickPieceUIData = new ClickPieceUI.UIData ();
					{
						clickPieceUIData.uid = showUI.sub.makeId ();
					}
					showUI.sub.v = clickPieceUIData;
				} else {
					Debug.LogError ("showUI null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		#endregion

		#region implement callBacks

		public BtnChosenMoveUI btnChoseMovePrefab;
		public Transform btnChoseMovesContainter;

		private ShowUI.UIData showUIData = null;
		private ClickDestUI.UIData clickDestUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.showUIData);
					DataUtils.addParentCallBack (uiData, this, ref this.clickDestUIData);
				}
				// Child
				{
					uiData.btnChosenMoves.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Parent
			{
				// showUIData
				{
					if (data is ShowUI.UIData) {
						ShowUI.UIData showUIData = data as ShowUI.UIData;
						// Child
						{
							showUIData.legalMoves.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is ShogiMove) {
						dirty = true;
						return;
					}
				}
				// clickDestUIData
				if (data is ClickDestUI.UIData) {
					dirty = true;
					return;
				}
			}
			// Child
			{
				if (data is BtnChosenMoveUI.UIData) {
					BtnChosenMoveUI.UIData btnChoseMoveUIData = data as BtnChosenMoveUI.UIData;
					// UI
					{
						UIUtils.Instantiate (btnChoseMoveUIData, btnChoseMovePrefab, btnChoseMovesContainter);
					}
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
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.showUIData);
					DataUtils.removeParentCallBack (uiData, this, ref this.clickDestUIData);
				}
				// Child
				{
					uiData.btnChosenMoves.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Parent
			{
				// showUIData
				{
					if (data is ShowUI.UIData) {
						ShowUI.UIData showUIData = data as ShowUI.UIData;
						// Child
						{
							showUIData.legalMoves.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is ShogiMove) {
						return;
					}
				}
				// clickDestUIData
				if (data is ClickDestUI.UIData) {
					return;
				}
			}
			// Child
			{
				if (data is BtnChosenMoveUI.UIData) {
					BtnChosenMoveUI.UIData btnChoseMoveUIData = data as BtnChosenMoveUI.UIData;
					// UI
					{
						btnChoseMoveUIData.removeCallBackAndDestroy (typeof(BtnChosenMoveUI));
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
				case UIData.Property.square:
					dirty = true;
					break;
				case UIData.Property.btnChosenMoves:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			// Parent
			{
				// showUIData
				{
					if (wrapProperty.p is ShowUI.UIData) {
						switch ((ShowUI.UIData.Property)wrapProperty.n) {
						case ShowUI.UIData.Property.legalMoves:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case ShowUI.UIData.Property.sub:
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is ShogiMove) {
						switch ((ShogiMove.Property)wrapProperty.n) {
						case ShogiMove.Property.move:
							dirty = true;
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
				// clickDestUIData
				if (wrapProperty.p is ClickDestUI.UIData) {
					switch ((ClickDestUI.UIData.Property)wrapProperty.n) {
					case ClickDestUI.UIData.Property.square:
						dirty = true;
						break;
					case ClickDestUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
			}
			// Child
			{
				if (wrapProperty.p is BtnChosenMoveUI.UIData) {
					return;
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}