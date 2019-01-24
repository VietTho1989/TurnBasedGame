using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Weiqi.NoneRule
{
	public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<int> coord;

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				coord,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.coord = new VP<int>(this, (byte)Property.coord, 0);
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
						ClickMoveUI clickMoveUI = this.findCallBack<ClickMoveUI> ();
						if (clickMoveUI != null) {
							clickMoveUI.onEnterKey ();
						} else {
							Debug.LogError ("clickMoveUI null: " + this);
						}
						isProcess = true;
					} else if (InputEvent.isArrow (e)) {
						// find boardSize
						int boardSize = 19;
						{
							NoneRuleInputUI.UIData noneRuleInputUIData = this.findDataInParent<NoneRuleInputUI.UIData> ();
							if (noneRuleInputUIData != null) {
								Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
								if (weiqi != null) {
									boardSize = weiqi.b.v.size.v;
								} else {
									Debug.LogError ("weiqi null: " + this);
								}
							} else {
								Debug.LogError ("noneRuleInputUIData null: " + this);
							}
						}
						// process
						if (boardSize >= Weiqi.MinBoardSize) {
							if (this.keyX.v >= 1 && this.keyX.v < boardSize-1
							    && this.keyY.v >= 1 && this.keyY.v < boardSize-1) {
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
								if (newKeyX >= 1 && newKeyX < boardSize-1
								    && newKeyY >= 1 && newKeyY < boardSize-1) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								this.keyX.v = this.coord.v % boardSize;
								this.keyY.v = this.coord.v / boardSize;
							}
						} else {
							Debug.LogError ("boardSize too small: " + this);
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
					// find weiqi
					Weiqi weiqi = null;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							weiqi = noneRuleInputUIData.weiqi.v.data;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// Process
					if (weiqi != null) {
						// get board size
						int boardSize = weiqi!=null ? weiqi.b.v.size.v : 21;
						{
							if (boardSize < 5) {
								Debug.LogError ("why boardSize small: " + boardSize + "; " + this);
								boardSize = 5;
							}
						}
						// keySelect
						{
							if (keySelect != null) {
								if (this.data.keyX.v >= 1 && this.data.keyX.v < boardSize-1
									&& this.data.keyY.v >= 1 && this.data.keyY.v < boardSize-1) {
									keySelect.SetActive (true);
									keySelect.transform.localPosition = Common.convertCoordToLocalPosition (boardSize, this.data.keyX.v + boardSize * this.data.keyY.v);
								} else {
									keySelect.SetActive (false);
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
								Common.stone piece = weiqi.getPieceByCoord (this.data.coord.v);
								if (piece == Common.stone.S_BLACK || piece == Common.stone.S_WHITE) {
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
								imgSelect.transform.localPosition = Common.convertCoordToLocalPosition(boardSize, this.data.coord.v);
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
						Debug.LogError ("weiqi null: " + this);
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
						noneRuleInputUIData.weiqi.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is Weiqi) {
						Weiqi weiqi = data as Weiqi;
						// Child
						{
							weiqi.b.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Board) {
						dirty = true;
						return;
					}
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
						noneRuleInputUIData.weiqi.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is Weiqi) {
						Weiqi weiqi = data as Weiqi;
						// Child
						{
							weiqi.b.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Board) {
						return;
					}
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
				case UIData.Property.coord:
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
					case NoneRuleInputUI.UIData.Property.weiqi:
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
				{
					if (wrapProperty.p is Weiqi) {
						switch ((Weiqi.Property)wrapProperty.n) {
						case Weiqi.Property.b:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case Weiqi.Property.deadgroup:
							break;
						case Weiqi.Property.scoreOwnerMap:
							break;
						case Weiqi.Property.scoreOwnerMapSize:
							break;
						case Weiqi.Property.scoreBlack:
							break;
						case Weiqi.Property.scoreWhite:
							break;
						case Weiqi.Property.dame:
							break;
						case Weiqi.Property.score:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Board) {
						switch ((Board.Property)wrapProperty.n) {
						case Board.Property.size:
							dirty = true;
							break;
						case Board.Property.size2:
							break;
						case Board.Property.bits2:
							break;
						case Board.Property.captures:
							break;
						case Board.Property.komi:
							break;
						case Board.Property.handicap:
							break;
						case Board.Property.rules:
							break;
						case Board.Property.moves:
							break;
						case Board.Property.last_move:
							break;
						case Board.Property.last_move2:
							break;
						case Board.Property.last_move3:
							break;
						case Board.Property.last_move4:
							break;
						case Board.Property.superko_violation:
							break;
						case Board.Property.b:
							dirty = true;
							break;
						case Board.Property.g:
							break;
						case Board.Property.pp:
							break;
						case Board.Property.pat3:
							break;
						case Board.Property.gi:
							break;
						case Board.Property.c:
							break;
						case Board.Property.clen:
							break;
						case Board.Property.symmetry:
							break;
						case Board.Property.last_ko:
							break;
						case Board.Property.last_ko_age:
							break;
						case Board.Property.ko:
							break;
						case Board.Property.quicked:
							break;
						case Board.Property.history_hash:
							break;
						case Board.Property.hash:
							break;
						case Board.Property.qhash:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
				}
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		private void clickMove(int coord)
		{
			if (this.data != null) {
				Weiqi weiqi = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						weiqi = noneRuleInputUIData.weiqi.v.data;
						if (weiqi != null) {
							if (Game.IsPlaying (weiqi)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("weiqi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (coord >= 0 && coord < Common.BOARD_MAX_COORDS) {
						if (this.data.coord.v == coord) {
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
								WeiqiCustomMove weiqiCustomMove = new WeiqiCustomMove ();
								{
									weiqiCustomMove.from.v = this.data.coord.v;
									weiqiCustomMove.dest.v = coord;
								}
								clientInput.makeSend (weiqiCustomMove);
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
				// get board size
				int boardSize = 19;
				{
					// get board size
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
						if (weiqi != null) {
							boardSize = weiqi.b.v.size.v;
						} else {
							Debug.LogError ("weiqi null: " + this);
						}
					} else {
						Debug.LogError ("noneRuleInputUIData null: " + this);
					}
					// correct board size
					if (boardSize < 5) {
						Debug.LogError ("why board size so small: " + this);
						boardSize = 5;
					}
				}
				// make move
				if (this.data.keyX.v >= 1 && this.data.keyX.v < boardSize - 1
				    && this.data.keyY.v >= 1 && this.data.keyY.v < boardSize - 1) {
					this.clickMove (this.data.keyX.v + boardSize * this.data.keyY.v);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Debug.LogError ("OnPointerDown: " + eventData);
			if (this.data != null) {
				// get boardSize
				int boardSize = 19;
				{
					// get boardSize
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData>();
					if (noneRuleInputUIData != null) {
						Weiqi weiqi = noneRuleInputUIData.weiqi.v.data;
						if (weiqi != null) {
							boardSize = weiqi.b.v.size.v;
						} else {
							Debug.LogError ("weiqi null: " + this);
						}
					} else {
						Debug.LogError ("noneRuleInputUIData null: " + this);
					}
					// correct boardSize
					if (boardSize < 5) {
						Debug.LogError ("why board size so small: " + this);
						boardSize = 5;
					}
				}
				// get coord
				int coord = 0;
				{
					Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
					int x = Mathf.RoundToInt (localPosition.x + boardSize / 2.0f - 0.5f);
					int y = Mathf.RoundToInt (localPosition.y + boardSize / 2.0f - 0.5f);
					coord = x + boardSize * y;
					// Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y + "; " + move);
				}
				this.clickMove (coord);
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

	}
}