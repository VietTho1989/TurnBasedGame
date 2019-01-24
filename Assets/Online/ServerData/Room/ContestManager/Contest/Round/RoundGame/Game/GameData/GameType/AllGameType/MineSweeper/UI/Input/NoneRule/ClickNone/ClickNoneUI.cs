using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace MineSweeper.NoneRule
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
							Debug.LogError ("clickNone null: " + this);
						}
						isProcess = true;
					} else if (InputEvent.isArrow (e)) {
						// find X, Y
						int X = 10;
						int Y = 10;
						{
							NoneRuleInputUI.UIData noneRuleInputUIData = this.findDataInParent<NoneRuleInputUI.UIData> ();
							if (noneRuleInputUIData != null) {
								MineSweeper mineSweeper = noneRuleInputUIData.mineSweeper.v.data;
								if (mineSweeper != null) {
									X = mineSweeper.X.v;
									Y = mineSweeper.Y.v;
								} else {
									Debug.LogError ("mineSweeper null: " + this);
								}
							} else {
								Debug.LogError ("noneRuleInputUIData null: " + this);
							}
						}
						if (X >= MineSweeper.MIN_DIMENSION_SIZE && Y >= MineSweeper.MIN_DIMENSION_SIZE) {
							if (this.keyX.v >= 0 && this.keyX.v < X
								&& this.keyY.v >= 0 && this.keyY.v < Y) {
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
								if (newKeyX >= 0 && newKeyX < X
									&& newKeyY >= 0 && newKeyY < Y) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								// bring to lastMove
								int lastKeyX = X / 2;
								int lastKeyY = Y / 2;
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
										case GameMove.Type.MineSweeperMove:
											{
												MineSweeperMove mineSweeperMove = gameMove as MineSweeperMove;
												lastKeyX = mineSweeperMove.move.v / Y;
												lastKeyY = mineSweeperMove.move.v % Y;
											}
											break;
										case GameMove.Type.MineSweeperCustomSet:
											{
												NoneRule.MineSweeperCustomSet mineSweeperCustomSet = gameMove as NoneRule.MineSweeperCustomSet;
												lastKeyX = mineSweeperCustomSet.square.v / Y;
												lastKeyY = mineSweeperCustomSet.square.v % Y;
											}
											break;
										case GameMove.Type.MineSweeperCustomMove:
											{
												NoneRule.MineSweeperCustomMove mineSweeperCustomMove = gameMove as NoneRule.MineSweeperCustomMove;
												lastKeyX = mineSweeperCustomMove.dest.v / Y;
												lastKeyY = mineSweeperCustomMove.dest.v % Y;
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
							Debug.LogError ("boardSize too small: " + X + ", " + Y + ", " + this);
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
							// find X, Y
							int X = 10;
							int Y = 10;
							{
								NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
								if (noneRuleInputUIData != null) {
									MineSweeper mineSweeper = noneRuleInputUIData.mineSweeper.v.data;
									if (mineSweeper != null) {
										X = mineSweeper.X.v;
										Y = mineSweeper.Y.v;
									} else {
										Debug.LogError ("mineSweeper null: " + this);
									}
								} else {
									Debug.LogError ("noneRuleInputUIData null: " + this);
								}
							}
							if (X >= MineSweeper.MIN_DIMENSION_SIZE && Y >= MineSweeper.MIN_DIMENSION_SIZE) {
								if (this.data.keyX.v >= 0 && this.data.keyX.v < X
									&& this.data.keyY.v >= 0 && this.data.keyY.v < Y) {
									keySelect.SetActive (true);
									// find boardUIData
									BoardUI.UIData boardUIData = null;
									{
										MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData> ();
										if (mineSweeperGameDataUIData != null) {
											boardUIData = mineSweeperGameDataUIData.board.v;
										} else {
											Debug.LogError ("mineSweeperGameDataUIData null: " + this);
										}
									}
									// Process
									if (boardUIData != null) {
										keySelect.transform.localPosition = Common.converPosToLocalPosition (this.data.keyX.v, this.data.keyY.v, boardUIData);
									} else {
										Debug.LogError ("boardUIData null: " + this);
									}
								} else {
									keySelect.SetActive (false);
								}
							} else {
								Debug.LogError ("X, Y too small: " + X + ", " + Y + "; " + this);
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

		private void clickNone(int square)
		{
			if (this.data != null) {
				MineSweeper mineSweeper = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						mineSweeper = noneRuleInputUIData.mineSweeper.v.data;
						if (mineSweeper != null) {
							if (Game.IsPlaying (mineSweeper)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("xiangqi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (square >= 0 && square < mineSweeper.X.v * mineSweeper.Y.v) {
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
				int X = 10;
				int Y = 10;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						MineSweeper mineSweeper = noneRuleInputUIData.mineSweeper.v.data;
						if (mineSweeper != null) {
							X = mineSweeper.X.v;
							Y = mineSweeper.Y.v;
						} else {
							Debug.LogError ("mineSweeper null: " + this);
						}
					} else {
						Debug.LogError ("noneRuleInputUIData null: " + this);
					}
				}
				if (X >= MineSweeper.MIN_DIMENSION_SIZE && Y >= MineSweeper.MIN_DIMENSION_SIZE) {
					if (this.data.keyX.v >= 0 && this.data.keyX.v < X
						&& this.data.keyY.v >= 0 && this.data.keyY.v < Y) {
						this.clickNone (this.data.keyX.v * Y + this.data.keyY.v);
					}
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Debug.LogError ("OnPointerDown: " + eventData);
			if (this.data != null) {
				// get x, y
				Vector2 localPosition = transform.InverseTransformPoint (eventData.position);
				int square = -1;
				{
					// find boardUIData
					BoardUI.UIData boardUIData = null;
					{
						MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = this.data.findDataInParent<MineSweeperGameDataUI.UIData> ();
						if (mineSweeperGameDataUIData != null) {
							boardUIData = mineSweeperGameDataUIData.board.v;
						} else {
							Debug.LogError ("mineSweeperGameDataUIData null: " + this);
						}
					}
					// Process
					if (boardUIData != null) {
						square = Common.convertLocalPositionToPos (localPosition, boardUIData);
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