using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace Janggi.NoneRule
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
						if (this.keyX.v >= 0 && this.keyX.v < 9
							&& this.keyY.v >= 0 && this.keyY.v < 10) {
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
							if (newKeyX >= 0 && newKeyX < 9
								&& newKeyY >= 0 && newKeyY < 10) {
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
							if (this.data.keyX.v >= 0 && this.data.keyX.v < 9
								&& this.data.keyY.v >= 0 && this.data.keyY.v < 10) {
								keySelect.SetActive (true);
								keySelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.keyX.v, this.data.keyY.v);
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
					}
					// find janggi
					Janggi janggi = null;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							janggi = noneRuleInputUIData.janggi.v.data;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// Process
					if (janggi != null) {
						// clickPiece?
						{
							// find isClickPiece
							bool isClickPiece = false;
							{
								if (this.data.x.v >= 0 && this.data.x.v < 9 && this.data.y.v >= 0 && this.data.y.v < 10) {
									int index = this.data.y.v * Board.Width + this.data.x.v;
									if (index >= 0 && index < janggi.stones.vs.Count) {
										uint stone = janggi.stones.vs [index];
										if (stone != (uint)StoneHelper.Stones.Empty) {
											isClickPiece = true;
										}
									}
								} else {
									Debug.LogError ("outside board: " + this.data.x.v + ", " + this.data.y.v);
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
								ivSelect.transform.localPosition = Common.convertXYToLocalPosition (this.data.x.v, this.data.y.v);
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
						Debug.LogError ("janggi null: " + this);
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
						noneRuleInputUIData.janggi.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				if (data is Janggi) {
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
						noneRuleInputUIData.janggi.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				if (data is Janggi) {
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
					case NoneRuleInputUI.UIData.Property.janggi:
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
				if (wrapProperty.p is Janggi) {
					switch ((Janggi.Property)wrapProperty.n) {
					case Janggi.Property.stones:
						dirty = true;
						break;
					case Janggi.Property.targets:
						break;
					case Janggi.Property.blocks:
						break;
					case Janggi.Property.positions:
						break;
					case Janggi.Property.isMyTurn:
						break;
					case Janggi.Property.Point:
						break;
					case Janggi.Property.isMyFirst:
						break;
					case Janggi.Property.isCustom:
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
				Janggi janggi = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						janggi = noneRuleInputUIData.janggi.v.data;
						if (janggi != null) {
							if (Game.IsPlaying (janggi)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("janggi null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 9 && y >= 0 && y < 10) {
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
								JanggiCustomMove janggiCustomMove = new JanggiCustomMove ();
								{
									janggiCustomMove.fromX.v = this.data.x.v;
									janggiCustomMove.fromY.v = this.data.y.v;
									janggiCustomMove.destX.v = x;
									janggiCustomMove.destY.v = y;
								}
								clientInput.makeSend (janggiCustomMove);
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
			Vector3 localPosition = transform.InverseTransformPoint (eventData.position);
			int x = 0;
			int y = 0;
			{
				Common.convertLocalPositionToXY (localPosition, out x, out y);
			}
			this.clickMove (x, y);
		}

	}
}