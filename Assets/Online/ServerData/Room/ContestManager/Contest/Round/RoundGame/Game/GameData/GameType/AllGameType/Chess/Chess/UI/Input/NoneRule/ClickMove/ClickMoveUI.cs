﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Chess.NoneRule
{
	public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> x;

			public VP<int> y;

			#region keyEvent

			public VP<int> keyX;

			public VP<int> keyY;

			#endregion

			#region Constructor

			public enum Property
			{
				x,
				y,

				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.x = new VP<int>(this, (byte)Property.x, 0);
				this.y = new VP<int>(this, (byte)Property.y, 0);
				// keyEvent
				{
					this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
					this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
				}
			}

			#endregion

			public override Type getType ()
			{
				return Type.ClickMove;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					if (InputEvent.isEnter (e)) {
						// enter
						ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI> ();
						if (clickMoveUI != null) {
							clickMoveUI.onEnterKey ();
						} else {
							Debug.LogError ("clickMoveUI null: " + this);
						}
						isProcess = true;
					} else if (InputEvent.isArrow (e)) {
						if (this.keyX.v >= 0 && this.keyX.v < 8
							&& this.keyY.v >= 0 && this.keyY.v < 8) {
							// find new key position
							int newKeyX = this.keyX.v;
							int newKeyY = this.keyY.v;
							{
								switch (e.keyCode) {
								case KeyCode.LeftArrow:
									newKeyX--;
									break;
								case KeyCode.RightArrow:
									newKeyX++;
									break;
								case KeyCode.UpArrow:
									newKeyY++;
									break;
								case KeyCode.DownArrow:
									newKeyY--;
									break;
								default:
									Debug.LogError ("unknown keyCode: " + e.keyCode);
									break;
								}
							}
							// set
							if (newKeyX >= 0 && newKeyX < 8
								&& newKeyY >= 0 && newKeyY < 8) {
								this.keyX.v = newKeyX;
								this.keyY.v = newKeyY;
							}
						} else {
							this.keyX.v = this.x.v;
							this.keyY.v = this.y.v;
						}
						isProcess = true;
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public Image imgSelect;

		public GameObject keySelect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// keySelect
					{
						if (keySelect != null) {
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.keyX.v, this.data.keyY.v);
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
					}
					// find chess
					Chess chess = null;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							chess = noneRuleInputUIData.chess.v.data;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// Process
					if (chess != null) {
						// clickPiece?
						{
							// find isClickPiece
							bool isClickPiece = false;
							{
								Common.Square square = Common.make_square ((Common.File)this.data.x.v, (Common.Rank)this.data.y.v);
								Common.Piece piece = chess.piece_on (square);
								if (piece != Common.Piece.NO_PIECE && piece != Common.Piece.PIECE_NB) {
									isClickPiece = true;
								}
							}
							// Process
							if (!isClickPiece) {
								// change to none
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
							}
						}
						// imgSelect
						{
							if (imgSelect != null) {
								// position
								imgSelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.x.v, this.data.y.v);
								// Scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									imgSelect.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
								}
							} else {
								Debug.LogError ("imgSelect null: " + this);
							}
						}
					} else {
						Debug.LogError ("chess null: " + this);
					}
				} else {
					// Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region implement callBacks

		private GameDataBoardCheckPerspectiveChange<UIData> perspectiveChange = new GameDataBoardCheckPerspectiveChange<UIData>();
		private NoneRuleInputUI.UIData noneRuleInputUIData = null;

		public override void onAddCallBack<T> (T data)
		{
			if (data is UIData) {
				UIData uiData = data as UIData;
				// CheckChange
				{
					perspectiveChange.addCallBack (this);
					perspectiveChange.setData (uiData);
				}
				// Parent
				{
					DataUtils.addParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				dirty = true;
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				dirty = true;
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.chess.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Chess) {
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
					perspectiveChange.removeCallBack (this);
					perspectiveChange.setData (null);
				}
				// Parent
				{
					DataUtils.removeParentCallBack (uiData, this, ref this.noneRuleInputUIData);
				}
				this.setDataNull (uiData);
				return;
			}
			// CheckChange
			if (data is GameDataBoardCheckPerspectiveChange<UIData>) {
				return;
			}
			// Parent
			{
				if (data is NoneRuleInputUI.UIData) {
					NoneRuleInputUI.UIData noneRuleInputUIData = data as NoneRuleInputUI.UIData;
					// Child
					{
						noneRuleInputUIData.chess.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Chess) {
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
				case UIData.Property.x:
					dirty = true;
					break;
				case UIData.Property.y:
					dirty = true;
					break;
				case UIData.Property.keyX:
					dirty = true;
					break;
				case UIData.Property.keyY:
					dirty = true;
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
			// Parent
			{
				if (wrapProperty.p is NoneRuleInputUI.UIData) {
					switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
					case NoneRuleInputUI.UIData.Property.chess:
						{
							ValueChangeUtils.replaceCallBack (this, syncs);
							dirty = true;
						}
						break;
					case NoneRuleInputUI.UIData.Property.sub:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is Chess) {
					switch ((Chess.Property)wrapProperty.n) {
					case Chess.Property.board:
						dirty = true;
						break;
					case Chess.Property.byTypeBB:
						break;
					case Chess.Property.byColorBB:
						break;
					case Chess.Property.pieceCount:
						break;
					case Chess.Property.pieceList:
						break;
					case Chess.Property.index:
						break;
					case Chess.Property.castlingRightsMask:
						break;
					case Chess.Property.castlingRookSquare:
						break;
					case Chess.Property.castlingPath:
						break;
					case Chess.Property.gamePly:
						break;
					case Chess.Property.sideToMove:
						break;
					case Chess.Property.st:
						break;
					case Chess.Property.chess960:
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

		private void clickMove(int x, int y)
		{
			if (this.data != null) {
				Chess chess = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						chess = noneRuleInputUIData.chess.v.data;
						if (chess != null) {
							if (Game.IsPlaying (chess)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("chess null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 8 && y >= 0 && y < 8) {
						if (this.data.x.v == x && this.data.y.v == y) {
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
							// send move
							ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
							if (clientInput != null) {
								ChessCustomMove chessCustomMove = new ChessCustomMove ();
								{
									chessCustomMove.fromX.v = this.data.x.v;
									chessCustomMove.fromY.v = this.data.y.v;
									chessCustomMove.destX.v = x;
									chessCustomMove.destY.v = y;
								}
								clientInput.makeSend (chessCustomMove);
							} else {
								Debug.LogError ("clientInput null: " + this);
							}
						}
					} else {
						Debug.LogError ("click outside board: " + this);
					}
				} else {
					Debug.LogError ("not active: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void onEnterKey()
		{
			if (this.data != null) {
				this.clickMove (this.data.keyX.v, this.data.keyY.v);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Debug.LogError ("OnPointerDown: " + eventData);
			// get x, y
			int x = -1;
			int y = -1;
			{
				Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
				Common.convertLocalPositionToXY (localPosition, out x, out y);
				// Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			}
			this.clickMove (x, y);
		}

	}
}