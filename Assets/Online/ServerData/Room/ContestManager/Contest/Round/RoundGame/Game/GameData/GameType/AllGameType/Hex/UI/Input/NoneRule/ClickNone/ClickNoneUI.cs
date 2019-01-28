﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace HEX.NoneRule
{
	public class ClickNoneUI : UIBehavior<ClickNoneUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
			}

			#endregion

			public override Type getType ()
			{
				return Type.ClickNone;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					if (InputEvent.isEnter (e)) {
						// enter
						ClickNoneUI clickNoneUI = this.findCallBack<ClickNoneUI> ();
						if (clickNoneUI != null) {
							clickNoneUI.onEnterKey ();
						} else {
							Debug.LogError ("clickNoneUI null: " + this);
						}
						isProcess = true;
					} else if (InputEvent.isArrow (e)) {
						// find boardSize
						int boardSize = 11;
						{
							NoneRuleInputUI.UIData noneRuleInputUIData = this.findDataInParent<NoneRuleInputUI.UIData>();
							if (noneRuleInputUIData != null) {
								Hex hex = noneRuleInputUIData.hex.v.data;
								if (hex != null) {
									boardSize = hex.boardSize.v;
								} else {
									Debug.LogError ("hex null: " + this);
								}
							} else {
								Debug.LogError ("noneRuleInputUIData null: " + this);
							}
						}
						// Process
						if (boardSize >= Hex.MIN_BOARD_SIZE) {
							if (this.keyX.v >= 0 && this.keyX.v < boardSize
								&& this.keyY.v >= 0 && this.keyY.v < boardSize) {
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
										newKeyY--;
										break;
									case KeyCode.DownArrow:
										newKeyY++;
										break;
									default:
										Debug.LogError ("unknown keyCode: " + e.keyCode);
										break;
									}
								}
								// set
								if (newKeyX >= 0 && newKeyX < boardSize
									&& newKeyY >= 0 && newKeyY < boardSize) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								// bring to lastMove
								int lastKeyX = boardSize / 2;
								int lastKeyY = boardSize / 2;
								{
									// find gameMove
									GameMove gameMove = null;
									{
										// Find gameData
										GameData gameData = null;
										{
											GameDataUI.UIData gameDataUIData = this.findDataInParent<GameDataUI.UIData> ();
											if (gameDataUIData != null) {
												gameData = gameDataUIData.gameData.v.data;
											} else {
												Debug.LogError ("gameDataUIData null: ");
											}
										}
										// Process
										if (gameData != null) {
											LastMove lastMove = gameData.lastMove.v;
											if (lastMove != null) {
												gameMove = lastMove.gameMove.v;
											} else {
												Debug.LogError ("lastMove null: " + this);
											}
										} else {
											// Debug.LogError ("gameData null: " + data);
										}
									}
									// process
									if (gameMove != null) {
										switch (gameMove.getType ()) {
										case GameMove.Type.HexMove:
											{
												HexMove hexMove = gameMove as HexMove;
												lastKeyX = hexMove.move.v % boardSize;
												lastKeyY = hexMove.move.v / boardSize;
											}
											break;
										case GameMove.Type.HexCustomSet:
											{
												NoneRule.HexCustomSet hexCustomSet = gameMove as NoneRule.HexCustomSet;
												lastKeyX = hexCustomSet.square.v % boardSize;
												lastKeyY = hexCustomSet.square.v / boardSize;
											}
											break;
										case GameMove.Type.HexCustomMove:
											{
												NoneRule.HexCustomMove hexCustomMove = gameMove as NoneRule.HexCustomMove;
												lastKeyX = hexCustomMove.dest.v % boardSize;
												lastKeyY = hexCustomMove.dest.v / boardSize;
											}
											break;
										case GameMove.Type.None:
											break;
										default:
											Debug.LogError ("unknown type: " + gameMove.getType () + "; " + this);
											break;
										}
									} else {
										Debug.LogError ("gameMove null: " + this);
									}
								}
								// set
								this.keyX.v = lastKeyX;
								this.keyY.v = lastKeyY;
							}
						} else {
							Debug.LogError ("boardSize too small: " + boardSize + "; " + this);
						}
						isProcess = true;
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public GameObject keySelect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// keySelect
					{
						if (keySelect != null) {
							// find hex
							Hex hex = null;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									hex = noneRuleInputUIData.hex.v.data;
								} else {
									Debug.LogError ("noneRuleInputUIData null: " + this);
								}
							}
							// process
							if (hex != null) {
								ushort boardSize = hex.boardSize.v;
								if (boardSize >= Hex.MIN_BOARD_SIZE) {
									if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
										&& this.data.keyY.v >= 0 && this.data.keyY.v < boardSize) {
										keySelect.SetActive (true);
										keySelect.transform.localPosition = Common.GetLocalPosition ((ushort)(this.data.keyX.v + boardSize * this.data.keyY.v), this.data);
									} else {
										keySelect.SetActive (false);
									}
								}
							} else {
								Debug.LogError ("hex null: " + this);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
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
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		#region IPointerDownHandler

		private void clickNone(ushort square)
		{
			if (this.data != null) {
				Hex hex = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						hex = noneRuleInputUIData.hex.v.data;
						if (hex != null) {
							if (Game.IsPlaying (hex)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("hex null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (square >= 0 && square < hex.boardSize.v * hex.boardSize.v) {
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							ClickPosUI.UIData clickPosUIData = new ClickPosUI.UIData ();
							{
								clickPosUIData.uid = noneRuleInputUIData.sub.makeId ();
								clickPosUIData.square.v = square;
							}
							noneRuleInputUIData.sub.v = clickPosUIData;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
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
				// find boardSize
				ushort boardSize = 11;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						Hex hex = noneRuleInputUIData.hex.v.data;
						if (hex != null) {
							boardSize = hex.boardSize.v;
						} else {
							Debug.LogError ("hex null: " + this);
						}
					} else {
						Debug.LogError ("noneRuleInputUIData null: " + this);
					}
				}
				// process
				if (boardSize >= Hex.MIN_BOARD_SIZE) {
					if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
						&& this.data.keyY.v >= 0 && this.data.keyY.v < boardSize) {
						this.clickNone ((ushort)(this.data.keyX.v + boardSize * this.data.keyY.v));
					} else {
						Debug.LogError ("outside board: " + boardSize + ", " + this.data.keyX.v + ", " + this.data.keyY.v);
					}
				} else {
					Debug.LogError ("boardSize too small: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Debug.LogError ("OnPointerDown: " + eventData);
			if (this.data != null) {
				// get square
				System.UInt16 square = System.UInt16.MaxValue;
				{
					Vector2 localPosition = transform.InverseTransformPoint (eventData.position);
					// find boardUIData
					BoardUI.UIData boardUIData = null;
					{
						HexGameDataUI.UIData hexGameDataUIData = this.data.findDataInParent<HexGameDataUI.UIData> ();
						if (hexGameDataUIData != null) {
							boardUIData = hexGameDataUIData.board.v;
						} else {
							Debug.LogError ("hexGameDataUIData null: " + this);
						}
					}
					// Process
					if (boardUIData != null) {
						square = Common.GetIndex (localPosition, boardUIData);
					} else {
						Debug.LogError ("boardUIData null: " + this);
					}
				}
				this.clickNone (square);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		#endregion

	}
}