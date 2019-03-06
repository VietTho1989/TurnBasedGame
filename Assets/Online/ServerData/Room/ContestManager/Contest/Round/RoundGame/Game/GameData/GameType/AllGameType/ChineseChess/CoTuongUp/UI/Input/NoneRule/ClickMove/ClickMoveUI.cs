using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

namespace CoTuongUp.NoneRule
{
	public class ClickMoveUI : UIBehavior<ClickMoveUI.UIData>, IPointerDownHandler
	{

		#region UIData

		public class UIData : NoneRuleInputUI.UIData.Sub
		{

			public VP<byte> coord;

			#region keyEvent

			public VP<byte> keyX;

			public VP<byte> keyY;

			#endregion

			#region Constructor

			public enum Property
			{
				coord,
				keyX,
				keyY
			}

			public UIData() : base()
			{
				this.coord = new VP<byte>(this, (byte)Property.coord, 0);
				this.keyX = new VP<byte>(this, (byte)Property.keyX, 20);
				this.keyY = new VP<byte>(this, (byte)Property.keyY, 20);
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
							byte newKeyX = this.keyX.v;
							byte newKeyY = this.keyY.v;
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
							if (newKeyX >= 0 && newKeyX < 9
								&& newKeyY >= 0 && newKeyY < 10) {
								this.keyX.v = newKeyX;
								this.keyY.v = newKeyY;
							}
						} else {
							// bring to lastMove
							byte lastKeyX = 4;
							byte lastKeyY = 5;
							{
								Common.parseCoord (this.coord.v, out lastKeyX, out lastKeyY);
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
								keySelect.transform.localPosition = Common.convertCoordToLocalPosition (Common.makeCoord (this.data.keyX.v, this.data.keyY.v));
							} else {
								keySelect.SetActive (false);
							}
						} else {
							Debug.LogError ("keySelect null: " + this);
						}
					}
					// find coTuongUp
					CoTuongUp coTuongUp = null;
					{
						NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
						if (noneRuleInputUIData != null) {
							coTuongUp = noneRuleInputUIData.coTuongUp.v.data;
						} else {
							Debug.LogError ("noneRuleInputUIData null: " + this);
						}
					}
					// Process
					if (coTuongUp != null) {
						// clickPiece?
						{
							// find isClickPiece
							bool isClickPiece = false;
							{
								byte piece = coTuongUp.getPieceByCoord (this.data.coord.v);
								if (piece != Common.x) {
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
								ivSelect.transform.localPosition = Common.convertCoordToLocalPosition (this.data.coord.v);
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
						Debug.LogError ("coTuongUp null: " + this);
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
						noneRuleInputUIData.coTuongUp.allAddCallBack (this);
					}
					dirty = true;
					return;
				}
				// Child
				{
					if (data is CoTuongUp) {
						CoTuongUp coTuongUp = data as CoTuongUp;
						// Child
						{
							coTuongUp.nodes.allAddCallBack (this);
						}
						dirty = true;
						return;
					}
					// Child
					if (data is Node) {
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
						noneRuleInputUIData.coTuongUp.allRemoveCallBack (this);
					}
					return;
				}
				// Child
				{
					if (data is CoTuongUp) {
						CoTuongUp coTuongUp = data as CoTuongUp;
						// Child
						{
							coTuongUp.nodes.allRemoveCallBack (this);
						}
						return;
					}
					// Child
					if (data is Node) {
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
					case NoneRuleInputUI.UIData.Property.coTuongUp:
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
					if (wrapProperty.p is CoTuongUp) {
						switch ((CoTuongUp.Property)wrapProperty.n) {
						case CoTuongUp.Property.allowViewCapture:
							break;
						case CoTuongUp.Property.allowWatcherViewHidden:
							break;
						case CoTuongUp.Property.allowOnlyFlip:
							break;
						case CoTuongUp.Property.turn:
							break;
						case CoTuongUp.Property.side:
							break;
						case CoTuongUp.Property.nodes:
							{
								ValueChangeUtils.replaceCallBack (this, syncs);
								dirty = true;
							}
							break;
						case CoTuongUp.Property.plyDraw:
							break;
						default:
							Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
							break;
						}
						return;
					}
					// Child
					if (wrapProperty.p is Node) {
						switch ((Node.Property)wrapProperty.n) {
						case Node.Property.ply:
							break;
						case Node.Property.pieces:
							dirty = true;
							break;
						case Node.Property.captures:
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

		private void clickMove(byte x, byte y)
		{
			if (this.data != null) {
				CoTuongUp coTuongUp = null;
				// Check isActive
				bool isActive = false;
				{
					NoneRuleInputUI.UIData noneRuleInputUIData = this.data.findDataInParent<NoneRuleInputUI.UIData> ();
					if (noneRuleInputUIData != null) {
						coTuongUp = noneRuleInputUIData.coTuongUp.v.data;
						if (coTuongUp != null) {
							if (Game.IsPlaying (coTuongUp)) {
								isActive = true;
							}
						} else {
							Debug.LogError ("coTuongUp null: " + this);
							return;
						}
					} else {
						Debug.LogError ("useRuleInputUIData null: " + this);
					}
				}
				if (isActive) {
					if (x >= 0 && x < 9 && y >= 0 && y < 10) {
						byte coord = Common.makeCoord ((byte)x, (byte)y);
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
								CoTuongUpCustomMove coTuongUpCustomMove = new CoTuongUpCustomMove ();
								{
									coTuongUpCustomMove.from.v = this.data.coord.v;
									coTuongUpCustomMove.dest.v = coord;
								}
								clientInput.makeSend (coTuongUpCustomMove);
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
			Common.convertLocalPositionToXY (localPosition, out x, out y);
			Debug.LogError ("localPosition: " + localPosition + ", " + x + ", " + y);
			this.clickMove ((byte)x, (byte)y);
		}

	}
}