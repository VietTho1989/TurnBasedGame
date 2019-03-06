using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace EnglishDraught.NoneRule
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
							Debug.LogError ("clickNoneUI null: " + this);
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
							this.keyX.v = this.square.v % 8;
							this.keyY.v = this.square.v / 8;
						}
						isProcess = true;
					}
				}
				return isProcess;
			}

		}

		#endregion

		#region Refresh

		public GameObject ivSelect;

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
					// find englishDraught
					EnglishDraught englishDraught = null;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							englishDraught = noneRuleInputUIData.englishDraught.v.data;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// Process
					if (englishDraught != null) {
						// clickPiece?
						{
							// find isClickPiece
							bool isClickPiece = false;
							{
								byte piece = EnglishDraught.getPiece (englishDraught.Sqs.vs, this.data.square.v);
								if (piece != 0) {
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
							if (ivSelect != null) {
								// position
								ivSelect.transform.localPosition = Common.convertSquareToLocalPosition (this.data.square.v);
								// Scale
								{
									int playerView = GameDataBoardUI.UIData.getPlayerView (this.data);
									ivSelect.transform.localScale = (playerView == 0 ? new Vector3 (1f, 1f, 1f) : new Vector3 (1f, -1f, 1f));
								}
							} else {
								Debug.LogError ("imgSelect null: " + this);
							}
						}
					} else {
						Debug.LogError ("englishDraught null: " + this);
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
						noneRuleInputUIData.englishDraught.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is EnglishDraught) {
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
						noneRuleInputUIData.englishDraught.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is EnglishDraught) {
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
				if (wrapProperty.p is NoneRuleInputUI.UIData) {
					switch ((NoneRuleInputUI.UIData.Property)wrapProperty.n) {
					case NoneRuleInputUI.UIData.Property.englishDraught:
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
				if (wrapProperty.p is EnglishDraught) {
					switch ((EnglishDraught.Property)wrapProperty.n) {
					case EnglishDraught.Property.Sqs:
						dirty = true;
						break;
					case EnglishDraught.Property.C:
						break;
					case EnglishDraught.Property.nPSq:
						break;
					case EnglishDraught.Property.eval:
						break;
					case EnglishDraught.Property.nWhite:
						break;
					case EnglishDraught.Property.nBlack:
						break;
					case EnglishDraught.Property.SideToMove:
						break;
					case EnglishDraught.Property.extra:
						break;
					case EnglishDraught.Property.HashKey:
						break;
					case EnglishDraught.Property.ply:
						break;
					case EnglishDraught.Property.RepNum:
						break;
					case EnglishDraught.Property.maxPly:
						break;
					case EnglishDraught.Property.turn:
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
				EnglishDraught englishDraught = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						englishDraught = noneRuleInputUIData.englishDraught.v.data;
						if (englishDraught != null) {
							if (Game.IsPlaying (englishDraught)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("englishDraught null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (square >= 0 && square < 64) {
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
							if (EnglishDraught.IsCorrectSquare (square)) {
								// send move
								ClientInput clientInput = InputUI.UIData.findClientInput (this.data);
								if (clientInput != null) {
									EnglishDraughtCustomMove englishDraughtCustomMove = new EnglishDraughtCustomMove ();
									{
										englishDraughtCustomMove.fromSquare.v = this.data.square.v;
										englishDraughtCustomMove.destSquare.v = square;
									}
									clientInput.makeSend (englishDraughtCustomMove);
								} else {
									Debug.LogError ("clientInput null: " + this);
								}
							} else {
								Debug.LogError ("not correct square: " + this);
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
				if (this.data.keyX.v >= 0 && this.data.keyX.v < 8
					&& this.data.keyY.v >= 0 && this.data.keyY.v < 8) {
					this.clickMove (this.data.keyX.v + 8 * this.data.keyY.v);
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			// Debug.LogError ("OnPointerDown: " + eventData);
			// get square
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int square = Common.convertLocalPositionToSquare (localPosition);
			Debug.LogError ("localPositition: " + localPosition + "; " + square);
			this.clickMove (square);
		}

	}
}