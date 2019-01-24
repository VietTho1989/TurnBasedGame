using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Gomoku
{
	public class UseRuleInputUI : UIBehavior<UseRuleInputUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : InputUI.UIData.Sub
		{
			
			public VP<ReferenceData<Gomoku>> gomoku;

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				gomoku,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.gomoku = new VP<ReferenceData<Gomoku>>(this, (byte)Property.gomoku, new ReferenceData<Gomoku>(null));
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
			}

			#endregion

			public override Type getType ()
			{
				return Type.UseRule;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					if (InputEvent.isEnter (e)) {
						// enter
						UseRuleInputUI useRuleInputUI = this.findCallBack<UseRuleInputUI> ();
						if (useRuleInputUI != null) {
							useRuleInputUI.onEnterKey ();
						} else {
							Debug.LogError ("useRuleInputUI null: " + this);
						}
						isProcess = true;
					} else if (InputEvent.isArrow (e)) {
						// find boardSize
						int boardSize = 19;
						{
							Gomoku gomoku = this.gomoku.v.data;
							if (gomoku != null) {
								boardSize = gomoku.boardSize.v;
							} else {
								Debug.LogError ("gomoku null: " + this);
							}
						}
						// process
						if (boardSize > 0) {
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
								if (newKeyX >= 0 && newKeyX < boardSize
									&& newKeyY >= 0 && newKeyY < boardSize) {
									this.keyX.v = newKeyX;
									this.keyY.v = newKeyY;
								}
							} else {
								// bring to lastMove
								int lastKeyX = boardSize/2;
								int lastKeyY = boardSize/2;
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
										case GameMove.Type.GomokuMove:
											{
												GomokuMove gomokuMove = gameMove as GomokuMove;
												lastKeyX = gomokuMove.move.v % boardSize;
												lastKeyY = gomokuMove.move.v / boardSize;
											}
											break;
										case GameMove.Type.GomokuCustomSet:
											{
												NoneRule.GomokuCustomSet gomokuCustomSet = gameMove as NoneRule.GomokuCustomSet;
												lastKeyX = gomokuCustomSet.square.v % boardSize;
												lastKeyY = gomokuCustomSet.square.v / boardSize;
											}
											break;
										case GameMove.Type.GomokuCustomMove:
											{
												NoneRule.GomokuCustomMove gomokuCustomMove = gameMove as NoneRule.GomokuCustomMove;
												lastKeyX = gomokuCustomMove.dest.v % boardSize;
												lastKeyY = gomokuCustomMove.dest.v / boardSize;
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
							Debug.LogError ("boardSize < 0: " + boardSize);
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
					Gomoku gomoku = this.data.gomoku.v.data;
					if (gomoku != null) {
						int boardSize = gomoku.boardSize.v;
						if (boardSize > 0) {
							// keySelect
							{
								if (keySelect != null) {
									if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
										&& this.data.keyY.v >= 0 && this.data.keyY.v < boardSize) {
										keySelect.SetActive (true);
										keySelect.transform.localPosition = Common.convertSquareToLocalPosition (boardSize, this.data.keyX.v + boardSize * this.data.keyY.v);
									} else {
										keySelect.SetActive (false);
									}
								} else {
									Debug.LogError ("keySelect null: " + this);
								}
							}
						} else {
							Debug.LogError ("boardSize < 0: " + boardSize);
						}
					} else {
						Debug.LogError ("gomoku null: " + this);
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
				UIData uiData = data as UIData;
				// Child
				{
					uiData.gomoku.allAddCallBack (this);
				}
				dirty = true;
				return;
			}
			// Child
			if (data is Gomoku) {
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
					uiData.gomoku.allRemoveCallBack (this);
				}
				this.setDataNull (uiData);
				return;
			}
			// Child
			if (data is Gomoku) {
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
				case UIData.Property.gomoku:
					{
						ValueChangeUtils.replaceCallBack (this, syncs);
						dirty = true;
					}
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
			// Child
			if (wrapProperty.p is Gomoku) {
				switch ((Gomoku.Property)wrapProperty.n) {
				case Gomoku.Property.boardSize:
					dirty = true;
					break;
				case Gomoku.Property.gs:
					break;
				case Gomoku.Property.player:
					break;
				case Gomoku.Property.winningPlayer:
					break;
				case Gomoku.Property.lastMove:
					break;
				case Gomoku.Property.winSize:
					break;
				case Gomoku.Property.winCoord:
					break;
				case Gomoku.Property.isCustom:
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

		private void clickMove(int move)
		{
			if (this.data != null) {
				Gomoku gomoku = null;
				// Check isActive
				bool isActive = false;
				{
					gomoku = this.data.gomoku.v.data;
					if (gomoku != null) {
						if (Game.IsPlaying (gomoku)) {
							isActive = true;
						}
					} else {
						Debug.LogError ("gomoku null: " + this);
						return;
					}
				}
				if (isActive) {
					if (Core.unityIsLegalMove (gomoku, Core.CanCorrect, move)) {
						// Send
						ClientInput clientInput = InputUI.UIData.findClientInput(this.data);
						if (clientInput != null) {
							GomokuMove gomokuMove = new GomokuMove();
							{
								gomokuMove.move.v = move;
							}
							clientInput.makeSend (gomokuMove);
						} else {
							Debug.LogError ("clientInput null: " + this);
						}
					} else {
						Debug.LogError ("not legal move: " + move + "; " + this);
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
				Gomoku gomoku = this.data.gomoku.v.data;
				if (gomoku != null) {
					int boardSize = gomoku.boardSize.v;
					if (boardSize > 0) {
						if (this.data.keyX.v >= 0 && this.data.keyX.v < boardSize
							&& this.data.keyY.v >= 0 && this.data.keyY.v < boardSize) {
							this.clickMove (this.data.keyX.v + boardSize * this.data.keyY.v);
						} else {
							Debug.LogError ("outside board: " + boardSize + ", " + this.data.keyX.v + ", " + this.data.keyY.v);
						}
					} else {
						Debug.LogError ("boardSize < 0: " + boardSize);
					}
				} else {
					Debug.LogError ("gomoku null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			Debug.LogError ("OnPointerDown: " + eventData);
			if (this.data != null) {
				Gomoku gomoku = this.data.gomoku.v.data;
				if (gomoku != null) {
					Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
					int move = Common.convertLocalPositionToSquare (gomoku, localPosition);
					Debug.LogError ("localPosition: " + localPosition + ", " + move);
					this.clickMove (move);
				} else {
					Debug.LogError ("gomoku null: " + this);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}
	}

}