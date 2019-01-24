using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace RussianDraught.UseRule
{
	public class ClickDestChooseUI : UIBehavior<ClickDestChooseUI.UIData>, BtnChosenMoveUI.OnClick
	{

		#region UIData

		public class UIData : ClickDestUI.UIData.Sub
		{

			public VP<int> square;

			public LP<BtnChosenMoveUI.UIData> btnChosenMoves;

			#region Constructor

			public enum Property
			{
				square,
				btnChosenMoves
			}

			public UIData() : base()
			{
				this.square = new VP<int>(this, (byte)Property.square, 0);
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
					List<RussianDraughtMove> russianDraughtMoves = new List<RussianDraughtMove> ();
					{
						ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
						ClickDestUI.UIData clickDestUIData = this.data.findDataInParent<ClickDestUI.UIData> ();
						if (showUIData != null && clickDestUIData != null) {
							for (int i = 0; i < showUIData.legalMoves.vs.Count; i++) {
								RussianDraughtMove legalMove = showUIData.legalMoves.vs [i];
								if (legalMove.from() == clickDestUIData.square.v
								    && legalMove.getMoveSquareList ().Contains (this.data.square.v)) {
									russianDraughtMoves.Add (legalMove);
								}
							}
						}
					}
					// contentContainer
					{
						if (contentContainer != null) {
							if (russianDraughtMoves.Count > 1) {
								contentContainer.gameObject.SetActive (true);
							} else {
								contentContainer.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
					// btnChoseMoves
					if (russianDraughtMoves.Count == 0) {
						Debug.LogError ("why count = 0: " + this);
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
					} else if (russianDraughtMoves.Count == 1) {
						RussianDraughtMove russianDraughtMove = russianDraughtMoves [0];
						// Send
						ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
						if (clientInput != null) {
							clientInput.makeSend (russianDraughtMove);
						} else {
							Debug.LogError ("clientInput null: " + this);
						}
					} else {
						List<BtnChosenMoveUI.UIData> oldBntChoseMoves = new List<BtnChosenMoveUI.UIData> ();
						// get olds
						oldBntChoseMoves.AddRange(this.data.btnChosenMoves.vs);
						// Update
						{
							for (int i = 0; i < russianDraughtMoves.Count; i++) {
								RussianDraughtMove russianDraughtMove = russianDraughtMoves [i];
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
									// move
									btnChoseMoveUIData.russianDraughtMove.v = new ReferenceData<RussianDraughtMove> (russianDraughtMove);
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

		public void onClickMove (RussianDraughtMove russianDraughtMove)
		{
			if (this.data != null) {
				// Send
				ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
				if (clientInput != null) {
					clientInput.makeSend (russianDraughtMove);
				} else {
					Debug.LogError ("clientInput null: " + this);
				}
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
					if (data is RussianDraughtMove) {
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
					if (data is RussianDraughtMove) {
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
					if (wrapProperty.p is RussianDraughtMove) {
						switch ((RussianDraughtMove.Property)wrapProperty.n) {
						case RussianDraughtMove.Property.m:
							dirty = true;
							break;
						case RussianDraughtMove.Property.path:
							dirty = true;
							break;
						case RussianDraughtMove.Property.l:
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