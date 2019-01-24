using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace FairyChess.UseRule
{
	public class DropPieceUI : UIBehavior<DropPieceUI.UIData>, BtnChosenMoveUI.OnClick
	{

		#region UIData

		public class UIData : ShowUI.UIData.Sub
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
				this.square = new VP<Common.Square>(this, (byte)Property.square, Common.Square.SQ_A1);
				this.btnChosenMoves = new LP<BtnChosenMoveUI.UIData>(this, (byte)Property.btnChosenMoves);
			}

			#endregion

			public override Type getType ()
			{
				return Type.DropPiece;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					// back
					if (!isProcess) {
						if (InputEvent.isBackEvent (e)) {
							DropPieceUI dropPieceUI = this.findCallBack<DropPieceUI> ();
							if (dropPieceUI != null) {
								dropPieceUI.onClickCancel ();
							} else {
								Debug.LogError ("dropPieceUI null: " + this);
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
					List<FairyChessMove> fairyChessMoves = new List<FairyChessMove> ();
					{
						ShowUI.UIData showUIData = this.data.findDataInParent<ShowUI.UIData> ();
						if (showUIData != null) {
							for (int i = 0; i < showUIData.legalMoves.vs.Count; i++) {
								FairyChessMove legalMove = showUIData.legalMoves.vs [i];
								if (Common.type_of ((Common.Move)legalMove.move.v) == Common.MoveType.DROP) {
									if (Common.to_sq ((Common.Move)legalMove.move.v) == this.data.square.v) {
										fairyChessMoves.Add (legalMove);
									}
								}
							}
						}
					}
					// contentContainer
					{
						if (contentContainer != null) {
							if (fairyChessMoves.Count >= 1) {
								contentContainer.gameObject.SetActive (true);
							} else {
								contentContainer.gameObject.SetActive (false);
							}
						} else {
							Debug.LogError ("contentContainer null: " + this);
						}
					}
					// btnChoseMoves
					if (fairyChessMoves.Count == 0) {
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
					} else {
						List<BtnChosenMoveUI.UIData> oldBntChoseMoves = new List<BtnChosenMoveUI.UIData> ();
						// get olds
						oldBntChoseMoves.AddRange(this.data.btnChosenMoves.vs);
						// Update
						{
							for (int i = 0; i < fairyChessMoves.Count; i++) {
								FairyChessMove fairyChessMove = fairyChessMoves [i];
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
									btnChoseMoveUIData.fairyChessMove.v = new ReferenceData<FairyChessMove> (fairyChessMove);
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

		public void onClickMove (FairyChessMove fairyChessMove)
		{
			if (this.data != null) {
				// Find ClientInput
				ClientInput clientInput = null;
				{
					// Find FairyChess
					FairyChess fairyChess = null;
					{
						InputUI.UIData inputUIData = this.data.findDataInParent<InputUI.UIData> ();
						if (inputUIData != null) {
							fairyChess = inputUIData.fairyChess.v.data;
						} else {
							Debug.LogError ("inputUIData null: " + this);
						}
					}
					// Process
					if (fairyChess != null) {
						Game game = fairyChess.findDataInParent<Game> ();
						if (game != null) {
							GameAction gameAction = game.gameAction.v;
							if (gameAction != null && gameAction is WaitInputAction) {
								WaitInputAction waitInputAction = gameAction as WaitInputAction;
								clientInput = waitInputAction.clientInput.v;
							} else {
								Debug.LogError ("not waitInputAction null: " + this);
							}
						} else {
							Debug.LogError ("game null: " + this);
						}
					}
				}
				// Send
				if (clientInput != null) {
					clientInput.makeSend (fairyChessMove);
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

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.showUIData);
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
					if (data is FairyChessMove) {
						dirty = true;
						return;
					}
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
					if (data is FairyChessMove) {
						return;
					}
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
					if (wrapProperty.p is FairyChessMove) {
						switch ((FairyChessMove.Property)wrapProperty.n) {
						case FairyChessMove.Property.move:
							dirty = true;
							break;
						default:
							Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
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