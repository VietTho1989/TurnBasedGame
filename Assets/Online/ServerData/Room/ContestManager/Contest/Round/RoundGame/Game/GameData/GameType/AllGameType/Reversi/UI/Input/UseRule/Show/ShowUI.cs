using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Reversi.UseRule
{
	public class ShowUI : UIBehavior<ShowUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : UseRuleInputUI.UIData.State
		{
			
			public LP<ReversiMove> legalMoves;

			public VP<int> keyX;

			public VP<int> keyY;

			#region Constructor

			public enum Property
			{
				legalMoves,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.legalMoves = new LP<ReversiMove> (this, (byte)Property.legalMoves);
				this.keyX = new VP<int>(this, (byte)Property.keyX, -1);
				this.keyY = new VP<int>(this, (byte)Property.keyY, -1);
			}

			#endregion

			public override Type getType ()
			{
				return Type.Show;
			}

			public override bool processEvent (Event e)
			{
				bool isProcess = false;
				{
					if (InputEvent.isEnter (e)) {
						// enter
						ShowUI showUI = this.findCallBack<ShowUI> ();
						if (showUI != null) {
							showUI.onEnterKey ();
						} else {
							Debug.LogError ("showUI null: " + this);
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
							if (newKeyX >= 0 && newKeyX < 8
								&& newKeyY >= 0 && newKeyY < 8) {
								this.keyX.v = newKeyX;
								this.keyY.v = newKeyY;
							}
						} else {
							// bring to lastMove
							int lastKeyX = 4;
							int lastKeyY = 4;
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
									case GameMove.Type.ReversiMove:
										{
											ReversiMove reversiMove = gameMove as ReversiMove;
											lastKeyX = reversiMove.move.v % 8;
											lastKeyY = reversiMove.move.v / 8;
										}
										break;
									case GameMove.Type.ReversiCustomSet:
										{
											NoneRule.ReversiCustomSet reversiCustomSet = gameMove as NoneRule.ReversiCustomSet;
											lastKeyX = reversiCustomSet.square.v % 8;
											lastKeyY = reversiCustomSet.square.v / 8;
										}
										break;
									case GameMove.Type.ReversiCustomMove:
										{
											NoneRule.ReversiCustomMove reversiCustomMove = gameMove as NoneRule.ReversiCustomMove;
											lastKeyX = reversiCustomMove.dest.v % 8;
											lastKeyY = reversiCustomMove.dest.v / 8;
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
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertSquareToLocalPosition (this.data.keyX.v + 8 * this.data.keyY.v);
							} else {
								keySelect.SetActive (false);
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
			Debug.LogError ("don't process: " + data + "; " + this);
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
			Debug.LogError ("don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is UIData) {
				switch ((UIData.Property)wrapProperty.n) {
				case UIData.Property.legalMoves:
					break;
				case UIData.Property.keyX:
					dirty = true;
					break;
				case UIData.Property.keyY:
					dirty = true;
					break;
				default:
					Debug.LogError ("unknown wrapProperty: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

		private void clickMove(int x, int y)
		{
			if (this.data != null) {
				Reversi reversi = null;
				// Check isActive
				bool isActive = false;
				{
					UseRuleInputUI.UIData useRuleInputUIData = this.data.findDataInParent<UseRuleInputUI.UIData> ();
					if (useRuleInputUIData != null) {
						reversi = useRuleInputUIData.reversi.v.data;
						if (reversi != null) {
							if (Game.IsPlaying (reversi)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("reversi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 8 && y >= 0 && y < 8) {
						sbyte move = (sbyte)(x + 8 * y);
						if (Core.unityIsLegalMove (reversi, Core.CanCorrect, move)) {
							// Find ClientInput
							ClientInput clientInput = null;
							{
								Game game = reversi.findDataInParent<Game> ();
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
							// Send
							if (clientInput != null) {
								ReversiMove reversiMove = new ReversiMove();
								{
									reversiMove.move.v = move;
								}
								clientInput.makeSend (reversiMove);
							} else {
								Debug.LogError ("clientInput null: " + this);
							}
						} else {
							Toast.showMessage ("error, not correct movve");
						}
					} else {
						Debug.LogError ("click outside board");
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
			Debug.LogError ("OnPointerDown: " + eventData);
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int x = Mathf.RoundToInt (localPosition.x + 3.5f);
			int y = 7 - Mathf.RoundToInt (localPosition.y + 3.5f);
			Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			this.clickMove (x, y);
		}
	}
}