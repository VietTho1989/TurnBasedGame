using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace MineSweeper.NoneRule
{
	public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> square;

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				square,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.square = new VP<int>(this, (byte)Property.square, 0);
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
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
								this.keyX.v = this.square.v / Y;
								this.keyY.v = this.square.v % Y;
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

		public Image imgSelect;

		public GameObject keySelect;

		public override void refresh ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					// find mineSweeper
					MineSweeper mineSweeper = null;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							mineSweeper = noneRuleInputUIData.mineSweeper.v.data;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// Process
					if (mineSweeper != null) {
						// keySelect
						{
							if (keySelect != null) {
								// find X, Y
								int X = mineSweeper.X.v;
								int Y = mineSweeper.Y.v;
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
						// clickPiece?
						{
							// find isClickPiece
							bool isClickPiece = false;
							{
								if (mineSweeper.getPiece (this.data.square.v) != -1) {
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
								Common.show(imgSelect, this.data.square.v, this.data);
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
						Debug.LogError ("mineSweeper null: " + this);
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

		private MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = null;

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
					DataUtils.addParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
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
				if (data is MineSweeperGameDataUI.UIData) {
					MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					// Child
					{
						mineSweeperGameDataUIData.board.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is BoardUI.UIData) {
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
					DataUtils.removeParentCallBack (uiData, this, ref this.mineSweeperGameDataUIData);
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
				if (data is MineSweeperGameDataUI.UIData) {
					MineSweeperGameDataUI.UIData mineSweeperGameDataUIData = data as MineSweeperGameDataUI.UIData;
					// Child
					{
						mineSweeperGameDataUIData.board.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is BoardUI.UIData) {
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
				if (wrapProperty.p is MineSweeperGameDataUI.UIData) {
					switch ((MineSweeperGameDataUI.UIData.Property)wrapProperty.n) {
					case MineSweeperGameDataUI.UIData.Property.gameData:
						break;
					case MineSweeperGameDataUI.UIData.Property.updateTransform:
						break;
					case MineSweeperGameDataUI.UIData.Property.transformOrganizer:
						break;
					case MineSweeperGameDataUI.UIData.Property.isOnAnimation:
						break;
					case MineSweeperGameDataUI.UIData.Property.board:
						{
							ValueChangeUtils.replaceCallBack(this, syncs);
							dirty = true;
						}
						break;
					case MineSweeperGameDataUI.UIData.Property.lastMove:
						break;
					case MineSweeperGameDataUI.UIData.Property.showHint:
						break;
					case MineSweeperGameDataUI.UIData.Property.inputUI:
						break;
					default:
						Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
						break;
					}
					return;
				}
				// Child
				if (wrapProperty.p is BoardUI.UIData) {
					switch ((BoardUI.UIData.Property)wrapProperty.n) {
					case BoardUI.UIData.Property.mineSweeper:
						break;
					case BoardUI.UIData.Property.background:
						break;
					case BoardUI.UIData.Property.boundary:
						break;
					case BoardUI.UIData.Property.scrollView:
						break;
					case BoardUI.UIData.Property.pieces:
						dirty = true;
						break;
					case BoardUI.UIData.Property.booom:
						break;
					case BoardUI.UIData.Property.allowWatchBomb:
						break;
					case BoardUI.UIData.Property.maxWidth:
						dirty = true;
						break;
					case BoardUI.UIData.Property.maxHeight:
						dirty = true;
						break;
					case BoardUI.UIData.Property.x:
						dirty = true;
						break;
					case BoardUI.UIData.Property.y:
						dirty = true;
						break;
					case BoardUI.UIData.Property.width:
						dirty = true;
						break;
					case BoardUI.UIData.Property.height:
						dirty = true;
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

		private void clickMove(int square)
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
							Debug.LogError ("mineSweeper null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (square >= 0 && square < mineSweeper.X.v * mineSweeper.Y.v) {
						if (this.data.square.v == square) {
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
								MineSweeperCustomMove mineSweeperCustomMove = new MineSweeperCustomMove ();
								{
									mineSweeperCustomMove.from.v = this.data.square.v;
									mineSweeperCustomMove.dest.v = square;
								}
								clientInput.makeSend (mineSweeperCustomMove);
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
						this.clickMove (this.data.keyX.v * Y + this.data.keyY.v);
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
				this.clickMove (square);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}